using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Security;
using System.Runtime.InteropServices;

namespace AudioProcessor
{

    public class Win32
    {
        [DllImport("user32")]
        public static extern int LockWindowUpdate(System.IntPtr hwnd);
    }
    
    public partial class SystemPanel : Control
    {

        AudioProcessorWin root;

        public Vector center;
        Vector centerPos;
        public double scale;
        public int grid;

        // Configuration variable for all elements
        public int sampleRate;
        public int blockSize;
        // Timing and buffers
        public int sourceBufferSize;
        public int sinkBufferSize;
        public int startSourceMinFill;
        public int startSinkMinFill;
        public int startInSleepFill;
        public int startOutSleepFill;
        // Failure counter value
        public int overrunCounterStart;


        Thread workThread;
        public volatile Boolean stopWorkThread;
        public volatile Boolean suspendWork;
        public volatile Boolean suspendingWork;

        public List<RTForm> elements;
        // public List<ProcessingElement> elements;
        public List<ProcessingNet> nets;

        public LogWin logWin;
        public delegate void logTextDelegateCall(string text);
        Delegate logTextDelegate;
        public delegate void showLogWinDelegateCall();
        Delegate showLogWinDelegate;

        System.Windows.Forms.Timer drawingTimer;

        private APSelection selection = new APSelection();

        // AudioProcessor.SinkSource.Sequencer test;

        enum DragMode
        {
            None,
            MouseDown,
            SelectWin
        };
        DragMode dragMode;

        private Color _colorGrid = Color.FromArgb(0,32,0);
        private Pen penGrid;
        private Pen penGrid0;
        public Color colorGrid
        {
            get { return _colorGrid; }
            set { _colorGrid = value; penGrid = new Pen(_colorGrid); penGrid0 = new Pen(_colorGrid, 3); Invalidate(); }
        }

        // public Color colorBackground;
        public Brush brushBackground;

        private Color _colorSelect = Color.RoyalBlue;
        private Pen penSelect;
        public Color colorSelect
        {
            set { _colorSelect = value; penSelect = new Pen(_colorSelect); Invalidate(); }
            get { return _colorSelect; }
        }

        public SystemPanel()
        {
            //elements = new List<ProcessingElement>();
            elements = new List<RTForm>();
            nets = new List<ProcessingNet>();

            InitializeComponent();

            center.set(0, 0);
            centerPos.set(Width / 2, Height / 2);
            scale = 1;
            grid = 25;

            // colorGrid = Color.Gray;
            // colorBackground = BackColor;
            penGrid = new Pen(_colorGrid);
            penGrid0 = new Pen(_colorGrid, 3);
            penSelect = new Pen(Color.RoyalBlue);
            brushBackground = new SolidBrush(BackColor);
            dragMode = DragMode.None;

            DoubleBuffered = true;

            sampleRate = 48000;
            blockSize = 32;

            sourceBufferSize = sampleRate / 2;
            sinkBufferSize = sampleRate / 2;
            //startSourceMinFill = sampleRate / 10;
            //startSinkMinFill = sampleRate / 10;
            startSourceMinFill = sampleRate / 100; // 10 ms
            startSinkMinFill = sampleRate / 100; // 10 ms
            overrunCounterStart = sampleRate / blockSize;
            startInSleepFill = sampleRate / 5;  // 100; // 5 100 for ASIO, 5 for regular windows devices
            startOutSleepFill = sampleRate / 5; //  100; // 5

            logWin = null;
            logTextDelegate = new logTextDelegateCall(logText);
            showLogWinDelegate = new showLogWinDelegateCall(showLogWin);

            // Process Interaction with Working Thread
            stopWorkThread = false;
            suspendWork = false;
            suspendingWork = false;

            workThread = new Thread(new ThreadStart(this.workThreadRun));
            workThread.SetApartmentState(ApartmentState.STA);
            // workThread.Priority = ThreadPriority.AboveNormal;
            workThread.Priority = ThreadPriority.Highest;
            workThread.Start();

            drawingTimer = new System.Windows.Forms.Timer();
            drawingTimer.Interval = 100; // ms
            drawingTimer.Tick += drawingTimer_Tick;
            drawingTimer.Enabled = true;

        }

        public void addElement(RTForm rt)
        {
            this.Controls.Add(rt);
            elements.Add(rt);
            rt.storePosData();
            rt.center = center;
            rt.updateFromRoot();
            selection.unselect();
            rt.BringToFront();
            selection.select(rt);
        }

        public void setAudioProcessorWin(AudioProcessorWin _root)
        {
            root = _root;
            if (workThread != null)
                root.changeStatusString("Online");
        }

        public RTForm findElement(string uid)
        {
            for (int i = 0; i < elements.Count; i++)
                if (elements[i].uniqueID.Equals(uid))
                    return elements[i];
            return null;
        }

        public void writeFile(BinaryWriter tgt)
        {
            string magic = "AudioProcBinary";
            tgt.Write(magic);
            int version = 2;
            tgt.Write(version);

            tgt.Write(sampleRate);
            tgt.Write(sourceBufferSize);
            tgt.Write(sinkBufferSize);
            tgt.Write(startSourceMinFill);
            tgt.Write(startSinkMinFill);
            tgt.Write(overrunCounterStart);
            tgt.Write(startInSleepFill);
            tgt.Write(startOutSleepFill);

            for (int i = 0; i < elements.Count; i++)
                elements[i].uniqueID = String.Format("EL{0}", i);

            tgt.Write(elements.Count);
            UInt32 frametest = 0xDEADBEEF;
            for (int i = 0; i < elements.Count; i++)
            {
                tgt.Write(frametest);
                tgt.Write(elements[i].GetType().ToString());
                elements[i].writeToFile(tgt);
            }
            tgt.Write(frametest);
            tgt.Write(nets.Count);
            for (int i = 0; i < nets.Count; i++)
                nets[i].writeToFile(tgt);
        }

        public void readFile(BinaryReader src)
        {
            string magic = "AudioProcBinary";
            string magicRead;
            magicRead = src.ReadString();
            if (!magicRead.Equals(magic))
                throw new Exception("Bad File Format: Header does not match");
            int version = src.ReadInt32();
            if (version != 2)
                throw new Exception("Bad File Format: File Version higher than this one --> Cannot Read");

            sampleRate = src.ReadInt32();
            sourceBufferSize = src.ReadInt32();
            sinkBufferSize = src.ReadInt32();
            startSourceMinFill = src.ReadInt32();
            startSinkMinFill = src.ReadInt32();
            overrunCounterStart = src.ReadInt32(); 
            startInSleepFill = src.ReadInt32();
            startOutSleepFill = src.ReadInt32();

            // Clear up
            while (nets.Count > 0)
            {
                nets[0].Disconnect();
                nets.RemoveAt(0);
            }
            while (elements.Count > 0)
            {
                elements[0].Disconnect();
                elements.RemoveAt(0);
            }

            int emts = src.ReadInt32();
            if (emts < 0)
                throw new Exception("Bad File Format: File Corrupt in head read");
            string previousclass = "undefined";
            UInt32 frametest = 0;
            for (int i = 0; i < emts; i++)
            {
                frametest = src.ReadUInt32();
                if (frametest != 0xDEADBEEF)
                    throw new Exception(String.Format("Bad File Format: Liley problem in code of Class {0}", previousclass));
                string classname = src.ReadString();
                Type t = Type.GetType(classname);
                ConstructorInfo ci = t.GetConstructor(new Type[] { this.GetType(), src.GetType() });
                RTForm ne = (RTForm) ci.Invoke(new object[] { this, src });
                this.Controls.Add(ne);
                ne.calcIORanks();
                elements.Add(ne);
                Vector cr = ne.center;
                ne.storePosData();
                Vector loc = cr - ne.dim / 2;
                ne.Location = toScreen(loc).Point;
                ne.center = cr;
                ne.updateFromRoot();
                ne.BringToFront();
                ne.updateShrinkState();
                previousclass = classname;
            }
            frametest = src.ReadUInt32();
            if (frametest != 0xDEADBEEF)
                throw new Exception(String.Format("Bad File Format: Liley problem in code of Class {0}", previousclass));
            int nts = src.ReadInt32();
            if (nts < 0)
                throw new Exception("Bad File Format: File Corrupt in head read");
            for (int i = 0; i < nts; i++)
                nets.Add(new ProcessingNet(this,src));
        }

        public void changeSampleRate(int newRate)
        {
            Boolean canChange = true;
            foreach (RTForm pe in elements)
            {
                if ((pe.processingType == RTForm.ProcessingType.SynchronousSink) ||
                    (pe.processingType == RTForm.ProcessingType.SynchronousSource))
                    canChange = false;
            }
            if (canChange)
                sampleRate = newRate;
            else
                MessageBox.Show("Sample Rate cannot be changed when synchronous Devices are online", "Sample Rate Change", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void drawingTimer_Tick(object sender, EventArgs e)
        {
            if (suspendWork) return;
        }

        public void logText(string text)
        {
            if (stopWorkThread)
                return;
            if (logWin == null)
                return;
            if (logWin.InvokeRequired)
            {
                logWin.Invoke(logTextDelegate, text);
                return;
            }
            DateTime dt = DateTime.Now;
            logWin.logText.Text += dt.ToString("yyyy-MM-dd HH:mm:ss") + " " + text + "\r\n";
            logWin.logText.SelectionStart = logWin.logText.Text.Length;
            if (text.StartsWith("AudioProcessor OnLine") && (root != null))
                root.changeStatusString("Online");
        }

        private delegate void CallElementDisconnectInWorkThreadDelegate(RTForm e);
        CallElementDisconnectInWorkThreadDelegate CallElementDisconnectInWorkThread;

        public void showLogWin()
        {
            if (logWin == null)
                return;
            if (logWin.InvokeRequired)
            {
                logWin.Invoke(showLogWinDelegate);
                return;
            }
            logWin.Show();
        }

        private double max(double a, double b)
        {
            return (a > b) ? a : b;
        }

        void workThreadRun()
        {
            int syncctr = 0;
            logText("Work Thread Started");
            CallElementDisconnectInWorkThread = new CallElementDisconnectInWorkThreadDelegate(CallElementDisconnect);

            logText("AudioProcessor OnLine and running");
            while (!stopWorkThread)
            {
                Boolean syncavaillable = false;
                double minWaitTime = 0;
                double wt;

                // First: Process Data Sources
                foreach (RTForm pe in elements)
                    if (pe.processingType == RTForm.ProcessingType.Source)
                        pe.tick();
                
                // Process Synchronous Soruces
                foreach (RTForm pe in elements)
                    if (pe.processingType == RTForm.ProcessingType.SynchronousSource)
                    {
                        pe.tick();
                        if ((wt = pe.inQueueLow()) > 0)
                            minWaitTime = max(minWaitTime, wt);
                        syncavaillable = true;
                    }

                // Process Synchronous SinkSources
                foreach (RTForm pe in elements)
                    if (pe.processingType == RTForm.ProcessingType.SynchronousSinkSource)
                    {
                        pe.tick();
                        if ((wt = pe.inQueueLow()) > 0)
                            minWaitTime = max(minWaitTime, wt);
                        if ((wt = pe.outQueueHigh()) > 0)
                            minWaitTime = max(minWaitTime, wt);
                        syncavaillable = true;
                    }

                // Process Filters and others
                foreach (RTForm pe in elements)
                    if (pe.processingType == RTForm.ProcessingType.Processor)
                        pe.tick();

                // Process Synchronous Sinks
                foreach (RTForm pe in elements)
                    if (pe.processingType == RTForm.ProcessingType.SynchronousSink)
                    {
                        pe.tick();
                        if ((wt = pe.outQueueHigh()) > 0)
                            minWaitTime = max(minWaitTime, wt);
                        syncavaillable = true;
                    }

                // Finally Data Sinks
                foreach (RTForm pe in elements)
                    if (pe.processingType == RTForm.ProcessingType.Sink)
                        pe.tick();

                // Process Nets
                foreach (ProcessingNet pn in nets)
                    pn.tick();

                if (!syncavaillable)
                {
                    // Sync manually to roughly the right rate
                    if (syncctr > 0)
                        syncctr-=blockSize;
                    else
                    {
                        System.Threading.Thread.Sleep(10);
                        syncctr = sampleRate / 100; // 480
                    }
                }
                else
                {
                    if (minWaitTime > 0)
                    {
                        double mssleep = Math.Floor(minWaitTime * 1000.0 + 0.5);
                        if (mssleep < 1.0) mssleep = 1.0;
                        System.Threading.Thread.Sleep((int)mssleep);
                    }
                }
                if (suspendWork)
                {
                    suspendingWork = true;
                    while (!stopWorkThread && suspendWork)
                    {
                        System.Threading.Thread.Sleep(1);
                    }
                    if (!suspendWork)
                        suspendingWork = false;
                }
                else
                    suspendingWork = false;
            }
            logText("Work Thread Stopped");
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            centerPos.set(Width / 2, Height / 2);
            foreach (RTForm r in elements)
                r.updateFromRoot();
            Invalidate();
        }


        public void DeleteElement(RTForm r)
        {
            r.Disconnect();
            r.WorkDisconnect();
            elements.Remove(r);
            Controls.Remove(r);
            r.Dispose();
            Invalidate();
        }

        public void Shutdown()
        {
            LockWorker();
            while (elements.Count > 0) {
                RTForm rf = elements[0];
                rf.Disconnect();
                rf.WorkDisconnect();
                elements.Remove(rf);
                Controls.Remove(rf);
                rf.Dispose();
            }
            UnLockWorker();
            Invalidate();
            stopWorkThread = true;
        }


        Vector dragStart;
        Vector dragStop;
        bool showCaret;

        public void selectMe(RTForm f)
        {
            if (f == null) return;
            selection.select(f);
        }

        public void selectMe(ProcessingNet n)
        {
            if (n == null) return;
            selection.select(n);
        }

        public void selectMe(ProcessingNet n, int conn)
        {
            if (n == null) return;
            if (conn < 0)
                selection.select(n);
            else
                selection.select(n, conn);
        }

        public void unselectAll()
        {
            selection.unselect();
        }

        public void initiateMove(RTForm rootmover)
        {
            selection.initateMove(rootmover);
        }

        public void temporaryMove(RTForm rootmover, Vector delta)
        {
            selection.temporaryMove(rootmover, delta);
        }

        public void finalizeMove(RTForm rootmover, Vector delta)
        {
            selection.finalizeMove(rootmover, delta);
        }

        void abortDrag()
        {
            switch (dragMode)
            {
                case DragMode.None: break;
                case DragMode.SelectWin:
                    if (showCaret)
                    {
                        showCaret = false;
                        Invalidate();
                    }
                    break;
            }
            dragMode = DragMode.None;
        }

        void unSelectAll()
        {
            if (selection.items > 0)
            {
                selection.unselect();
                Invalidate();
            }
        }

        public void LockWorker()
        {
            suspendWork = true;
            while (!suspendingWork)
            {
                System.Threading.Thread.Sleep(1);
            }
        }

        public void UnLockWorker()
        {
            suspendWork = false;
            while (suspendingWork)
            {
                System.Threading.Thread.Sleep(1);
            }
        }

        private void CallElementDisconnect(RTForm e)
        {
            try
            {
                e.WorkDisconnect();
            }
            catch (Exception ex)
            {
                logText("Exception occured when dispatching Disconnect to Element: " + ex.Message);
            }
        }

        public void DeleteClicked()
        {
            if (dragMode != DragMode.None) return;

            if (selection.items > 0)
            {
                LockWorker();
                // First remove connections
                selection.removeConnections();
                // Then remove Elements
                selection.removeElements();
                UnLockWorker();

                Invalidate();
            }

        }

        public void CallElementWorkDisconnect(RTForm e)
        {
            this.Invoke(CallElementDisconnectInWorkThread, e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            
            if (e.Button==MouseButtons.Left)
            {
                if (dragMode != DragMode.None) {
                    abortDrag();
                    return;
                }

                Vector mp = fromScreen(new Vector(e.Location.X, e.Location.Y));

                if (selection.items > 0)
                {
                    selection.unselect();
                    Invalidate();
                }

                dragMode = DragMode.MouseDown;
                dragStart = mp;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            switch (dragMode)
            {
                case DragMode.None: return;
                case DragMode.MouseDown:
                    // Window Seelct
                    dragMode = DragMode.SelectWin;
                    dragStop = fromScreen(new Vector(e.Location.X, e.Location.Y));
                    showCaret = true;
                    Invalidate();
                    break;
                case DragMode.SelectWin:
                    dragStop = fromScreen(new Vector(e.Location.X, e.Location.Y));
                    Invalidate();
                    break;

            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            switch (dragMode)
            {
                case DragMode.None:
                    break;
                case DragMode.MouseDown:
                    // Just Mouse up again --> a click
                    Vector mp = fromScreen(new Vector(e.Location.X, e.Location.Y));
                    foreach (ProcessingNet n in nets)
                    {
                        n.selectOnHit(mp, selection);
                    }
                    if (selection.items > 0)
                        Invalidate();
                    dragMode = DragMode.None;
                    break;
                case DragMode.SelectWin:
                    // unSelectAll();
                    dragStop = fromScreen(new Vector(e.Location.X, e.Location.Y));
                    VectorRect selwin = VectorRect.FromTwoPoints(dragStart, dragStop);
                    foreach (RTForm f in elements)
                        f.selectOnContained(selwin, selection);
                    foreach (ProcessingNet n in nets)
                        n.selectOnContained(selwin, selection);
                    showCaret = false;
                    dragMode = DragMode.None;
                    Invalidate();
                    break;
            }
        }

        private Vector temporaryConnectionFrom = Vector.Zero;
        private Vector temporaryConnectionTo = Vector.Zero;
        bool showConnection = false;

        public void showTemporaryConnection(Vector from, Vector to)
        {
            temporaryConnectionFrom = from;
            temporaryConnectionTo = to;
            showConnection = true;
            Invalidate();
        }

        public void hideTemporaryConnection()
        {
            showConnection = false;
            Invalidate();
        }

        public RTIO findIO(Vector v)
        {
            v = toScreen(v);
            foreach (RTForm rf in elements)
            {
                RTIO rio = rf.findIO(v);
                if (rio != null) return rio;
            }
            return null;
        }

        public void createConnection(RTIO io, RTIO ioto)
        {
            if (io == ioto) return; // Loop back not allowed
            // Check for attached nets
            if ((ioto.connectedTo != null) && (io.connectedTo != null))
            {
                // Both connected already 
                if (ioto.connectedTo == io.connectedTo)
                    return; // Already connected!
                // Merge Nets
                ProcessingNet voidNet = ioto.connectedTo;
                LockWorker();
                io.connectedTo.MergeFrom(ioto.connectedTo);
                nets.Remove(voidNet);
                io.connectedTo.addConnection(io, ioto);
                UnLockWorker();
                return;
            }
            if (io.connectedTo != null)
            {
                LockWorker();
                io.connectedTo.addConnection(io, ioto);
                UnLockWorker();
                return;
            }
            if (ioto.connectedTo != null)
            {
                LockWorker();
                ioto.connectedTo.addConnection(io, ioto);
                UnLockWorker();
                return;
            }
            // Still here --> create new net
            ProcessingNet net = new ProcessingNet(this);
            LockWorker();
            net.addConnection(io, ioto);
            nets.Add(net);
            UnLockWorker(); 
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            Vector mp = fromScreen(new Vector(e.Location.X, e.Location.Y));

            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            { // Scaling
                double s2 = 1.0;
                if (e.Delta > 0)
                    s2 = scale * 1.2;
                else
                    s2 = scale / 1.2;
                Vector c2 = center * (scale / s2) - mp * ((scale - s2) / s2);
                scale = s2;
                center = c2;


            } else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                if (e.Delta > 0)    
                    center.x -=  40/scale;
                else
                    center.x += 40/scale;
            }
            else
            {
                if (e.Delta > 0)
                    center.y -= 40/scale;
                else
                    center.y += 40/scale;
            }

            Win32.LockWindowUpdate(this.Handle);
            try {
                Invalidate();
                foreach (RTForm rt in elements)
                    rt.updateFromRoot();
            }
            finally
            {
                Win32.LockWindowUpdate((System.IntPtr)0);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Delete)
            {
                DeleteClicked();
            }
        }



        void drawTo(Graphics g)
        {
            //brushBackground = new SolidBrush(BackColor);
            // g.FillRectangle(brushBackground, this.ClientRectangle);

            centerPos.set(Width / 2, Height / 2);

            Vector v = fromScreen(Vector.V(0, 0));
            Vector w = fromScreen(Vector.V(Width - 1, Height - 1));

            int n = 1;
            double dx = grid * scale;
            while (dx < 10)
            {
                n *= 2;
                dx *= 2;
            }
            double gridN = grid * n;

            int gstartx = (int)Math.Floor(v.x / gridN);
            int gstopx = (int)Math.Ceiling(w.x / gridN);
            int gstarty = (int)Math.Floor(v.y / gridN);
            int gstopy = (int)Math.Ceiling(w.y / gridN);

            for (int x = gstartx; x <= gstopx; x++)
            {
                double x1 = (x * gridN - center.x) * scale + centerPos.x;
                if (x == 0)
                    g.DrawLine(penGrid0, (float)x1, 0, (float)x1, Height - 1);
                else
                    g.DrawLine(penGrid, (float)x1, 0, (float)x1, Height - 1);
            }
            for (int y = gstarty; y <= gstopy; y++)
            {
                double y1 = (y * gridN - center.y) * scale + centerPos.y;
                if (y == 0)
                    g.DrawLine(penGrid0, 0, (float)y1, Width - 1, (float)y1);
                else
                    g.DrawLine(penGrid, 0, (float)y1, Width - 1, (float)y1);
            }

            for (int i = 0; i < nets.Count; i++)
                nets[i].draw(g);

            if (showCaret)
            {
                RectangleF rf = Vector.RFxy(toScreen(dragStart), toScreen(dragStop));
                g.DrawRectangle(penSelect, rf.Left, rf.Top, rf.Width, rf.Height);
            }
            if (showConnection)
            {
                PointF p1 = toScreen(temporaryConnectionFrom).PointF;
                PointF p2 = toScreen(temporaryConnectionTo).PointF;
                g.DrawLine(penSelect, p1, p2);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // base.OnPaint(pe);
            drawTo(pe.Graphics);
        }

        public Vector toScreen(Vector v)
        {
            return (v-center) * scale + centerPos;
        }

        public Vector fromScreen(Vector s)
        {
            return (s - centerPos) * (1 / scale) + center;
        }

        public RectangleF toScreenRF(Vector pos, Vector size)
        {
            return new RectangleF(toScreen(pos).PointF, new SizeF((float)(size.x * scale), (float)(size.y * scale)));
        }

        public VectorRect toScreen(VectorRect r)
        {
            return new VectorRect(toScreen(r.LL), toScreen(r.UR));
        }

        public VectorRect toScreenVR(VectorRect v)
        {
            return new VectorRect(toScreen(v.LL), toScreen(v.UR));
        }
 
    }

}
