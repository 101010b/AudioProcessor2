using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace AudioProcessor
{
    public class RTForm: UserControl
    {

        public string uniqueID;

        public Vector center;
        public Vector dim;
        public double scale;


        public SystemPanel owner
        {
            get
            {
                if ((Parent != null) && (Parent is SystemPanel))
                    return (SystemPanel)Parent;
                return null;
            }
        }

        //public List<RTIO> io;
        // public List<ProcessingIO> io;
        // public List<ProcessingControl> ctrl;

        public enum ProcessingType
        {
            None,
            Processor,
            Source,
            Sink,
            SynchronousSource,
            SynchronousSink,
            SynchronousSinkSource
        }
        public ProcessingType processingType;

        // Parameters for configuration
        private Color _frameColor;
        private Pen framePen;
        public Color frameColor
        {
            set { _frameColor = value; framePen = new Pen(_frameColor); Invalidate(); }
            get { return _frameColor; }
        }

        private string _title;
        public string title
        {
            set { _title = value; if (_shrinkTitle == null) _shrinkTitle = value;  Invalidate(); }
            get { return _title; }
        }

        private string _shrinkTitle;
        public string shrinkTitle
        {
            set { _shrinkTitle = value; Invalidate(); }
            get { return _shrinkTitle; }
        }

        private Size _orgSize;
        private Size _shrinkSize;
        public Size shrinkSize
        {
            set { _shrinkSize = value; Invalidate(); }
            get { return _shrinkSize; }
        }

        private Font _titleFont;
        public Font titleFont
        {
            set { _titleFont = value; Invalidate(); }
            get { return _titleFont; }
        }

        private Color _titleColor;
        private Brush titleBrush;
        public Color titleColor
        {
            set { _titleColor = value; titleBrush = new SolidBrush(_titleColor); Invalidate(); }
            get { return _titleColor; }
        }

        private bool _selected;
        public bool selected
        {
            set { _selected = value; Invalidate(); }
            get { return _selected; }
        }

        private Color _selectColor;
        private Pen selectPen;
        private Brush selectBrush;
        public Color selectColor
        {
            set { _selectColor = value; selectPen = new Pen(_selectColor); selectBrush = new SolidBrush(_selectColor); Invalidate(); }
            get { return _selectColor; }
        }

        protected bool _active;
        public bool active
        {
            set { if (value != _active) { _active = value; Invalidate(); } }
            get { return _active; }
        }

        private bool _hasActiveSwitch;
        public bool hasActiveSwitch
        {
            set { if (value != _hasActiveSwitch) { _hasActiveSwitch = value; Invalidate(); } }
            get { return _hasActiveSwitch; }
        }

        private bool _canShrink;
        public bool canShrink
        {
            set { _canShrink = value; Invalidate(); }
            get { return _canShrink; }
        }

        private bool _shrinked;
        public bool shrinked
        {
            set { if (value != _shrinked) setShrinkMode(value); }
            get { return _shrinked; }
        }

        private Color _symbolColor;
        private Pen symbolPen;
        public Color symbolColor
        {
            set { _symbolColor = value; symbolPen = new Pen(_symbolColor); Invalidate(); }
            get { return _symbolColor; }

        }

        private Color _symbolOnColor;
        private Pen symbolOnPen;
        public Color symbolOnColor
        {
            set { _symbolOnColor = value; symbolOnPen = new Pen(_symbolOnColor); Invalidate(); }
            get { return _symbolOnColor; }
        }

        private Color _activeFillColor; 
        private Brush activeBrush;
        public Color activeFillColor
        {
            set { _activeFillColor = value;activeBrush = new SolidBrush(_activeFillColor); Invalidate(); }
            get { return _activeFillColor; }
        }

        private Color _activeSymbolColor;
        private Pen activePen;
        public Color activeSymbolColor
        {
            set { _activeSymbolColor = value;activePen = new Pen(_activeSymbolColor); Invalidate(); }
            get { return _activeSymbolColor; }
        }

        private Color _passiveSymbolColor;
        private Pen passivePen;
        public Color passiveSymbolColor
        {
            set { _passiveSymbolColor = value; passivePen = new Pen(_passiveSymbolColor); Invalidate(); }
            get { return _passiveSymbolColor; }
        }

        public RTForm():base()
        {
            scale = 1.0;
            BackColor = Color.Black;
            _title = null;
            _shrinkTitle = null;
            _frameColor = Color.DimGray;
            _titleColor = Color.DarkOrange;
            _titleFont = new Font(FontFamily.GenericSansSerif, 8);
            _selectColor = Color.Red;
            DoubleBuffered = true;
            center = Vector.V(0, 0);
            _orgSize = new Size(Width, Height);
            dim = Vector.V(Width, Height);
            processingType = ProcessingType.None;
            _selected = false;

            _active = true;
            _hasActiveSwitch = true;
            _canShrink = true;
            _shrinked = false;
            _symbolColor = Color.DimGray;
            _symbolOnColor = Color.Red;
            _activeFillColor = Color.DarkRed;
            _activeSymbolColor = Color.Yellow;
            _passiveSymbolColor = Color.DarkGray;

            framePen = new Pen(_frameColor);
            titleBrush = new SolidBrush(_titleColor);
            selectPen = new Pen(_selectColor);
            selectBrush = new SolidBrush(_selectColor);
            symbolPen = new Pen(_symbolColor);
            symbolOnPen = new Pen(_symbolOnColor);
            activeBrush = new SolidBrush(_activeFillColor);
            activePen = new Pen(_activeSymbolColor);
            passivePen = new Pen(_passiveSymbolColor);

            AutoScaleMode = AutoScaleMode.None;
            
        }

        public RTForm(SystemPanel _owner) : this()
        {
        }

        public RTForm(SystemPanel _owner, BinaryReader src) : this()
        {
            // name = src.ReadString();
            uniqueID = src.ReadString();
            center = new Vector(src);
            _active = src.ReadBoolean();
            _shrinked = src.ReadBoolean();
        }

        public virtual void writeToFile(BinaryWriter tgt)
        {
            // tgt.Write(name);
            tgt.Write(uniqueID);
            center.writeBinary(tgt);
            tgt.Write(_active);
            tgt.Write(_shrinked);
        }
        
        private void setShrinkMode(bool _shrink)
        {
            if (_shrink == _shrinked) return;
            _shrinked = _shrink;
            if (_shrinked)
            {
                foreach (Control ct in Controls)
                {
                    if ((ct is RTControl) && !(ct is RTIO))
                    {
                        RTControl c = (RTControl)ct;
                        c.Shrink(true);
                    }
                }
                int w = (int)Math.Floor(_shrinkSize.Width * scale + 0.5);
                int h = (int)Math.Floor(_shrinkSize.Height * scale + 0.5);
                if (w < 1) w = 1;
                if (h < 1) h = 1;
                int ofsx = (Width - w) / 2;
                int ofsy = (Height - h) / 2;
                Width = w;
                Height = h;
                Point newp = new Point(Location.X + ofsx, Location.Y + ofsy);
                Location = newp;
                Invalidate();
                owner?.Invalidate();
            }
            else
            {
                foreach (Control ct in Controls)
                {
                    if ((ct is RTControl) && !(ct is RTIO))
                    {
                        RTControl c = (RTControl)ct;
                        c.Shrink(false);
                    }
                }
                int w = (int)Math.Floor(dim.x * scale + 0.5);
                int h = (int)Math.Floor(dim.y * scale + 0.5);
                if (w < 1) w = 1;
                if (h < 1) h = 1;
                int ofsx = (Width - w) / 2;
                int ofsy = (Height - h) / 2;
                Width = w;
                Height = h;
                Point newp = new Point(Location.X + ofsx, Location.Y + ofsy);
                Location = newp;
                Invalidate();
                owner?.Invalidate();
            }
        }

        public void updateShrinkState()
        {
            if (!_shrinked) return;
            _shrinked = false;
            setShrinkMode(true);
        }

        public void storePosData()
        {
            center = Vector.V(0, 0);
            dim = Vector.V(Width, Height);
            _orgSize = new Size(Width, Height);
            foreach (Control c in Controls)
            {
                if (c is RTControl)
                {
                    RTControl cc = (RTControl)c;
                    cc.setOrg();
                }
            }
        }

        // Processing must happen here
        public virtual void tick()
        {
        }

        public virtual double inQueueLow()
        {
            return 0.0;
        }

        public virtual double outQueueHigh()
        {
            return 0.0;
        }

        // This function may be called from within Disconnect if neede for cleaning up 
        // resources in the work thread - like open Audio devices...
        public virtual void WorkDisconnect()
        {
        }


        public List<RTIO> GetIOs()
        {
            List<RTIO> rio = new List<RTIO>();
            foreach (Control ct in Controls)
            {
                if (ct is RTIO)
                    rio.Add((RTIO)ct);
            }
            if (rio.Count == 0)
                return null;
            return rio;
        }

        private void sortRank(List<RTIO>io, List<int>crit)
        {
            for (int i = 0; i < io.Count - 1; i++)
                for (int j = i+1; j < io.Count;j++)
                    if (crit[i] > crit[j])
                    {
                        RTIO tio = io[i];io[i] = io[j];io[j] = tio;
                        int tcrit = crit[i];crit[i] = crit[j];crit[j] = tcrit;
                    }
        }

        public void calcIORanks()
        {
            List<RTIO> north, south, east, west;
            List<int> northL, southL, eastL, westL;
            north = new List<RTIO>();
            south = new List<RTIO>();
            east = new List<RTIO>();
            west = new List<RTIO>();
            northL = new List<int>();
            southL = new List<int>();
            eastL = new List<int>();
            westL = new List<int>();
            // Find
            foreach (Control ct in Controls)
            {
                if (ct.Visible)
                {
                    if (ct is RTIO)
                    {
                        switch (((RTIO)ct).orientation)
                        {
                            case RTIO.RTOrientation.East: east.Add((RTIO)ct); eastL.Add(ct.Location.Y); break;
                            case RTIO.RTOrientation.West: west.Add((RTIO)ct); westL.Add(ct.Location.Y); break;
                            case RTIO.RTOrientation.South: south.Add((RTIO)ct); southL.Add(ct.Location.X); break;
                            case RTIO.RTOrientation.North: north.Add((RTIO)ct); northL.Add(ct.Location.X); break;
                        }
                    }
                }
            }
            // Sort
            sortRank(north, northL);
            sortRank(east, eastL);
            sortRank(south, southL);
            sortRank(west, westL);
            // Set Ranks
            for (int i = 0; i < north.Count; i++) north[i].setRank(i);
            for (int i = 0; i < east.Count; i++) east[i].setRank(i);
            for (int i = 0; i < south.Count; i++) south[i].setRank(i);
            for (int i = 0; i < west.Count; i++) west[i].setRank(i);
        }

        public int GetIOId(RTIO io)
        {
            int ctr = 0;
            foreach (Control ct in Controls)
            {
                if (ct is RTIO)
                {
                    RTIO i = (RTIO)ct;
                    if (i == io)
                        return ctr;
                    ctr++;
                }
            }
            return -1;
        }

        public virtual void Disconnect()
        {
            // Remove Object from the Panel
            foreach (Control ct in Controls)
            {
                if (ct is RTIO)
                {
                    RTIO io = (RTIO)ct;
                    if (io.connectedTo != null)
                    {
                        io.connectedTo.RemoveIO(io);
                        io.connectedTo = null;
                    }
                }
            }
        }
        /*
        public void unSelect()
        {
            selected = false;
        }

        public void doSelect()
        {
            selected = true;
        }
        */
        public SignalBuffer getSignalInputBuffer(RTIO io)
        {
            if (io == null) return null;
            if (io.connectedTo == null) return null;
            if (io.IOtype != RTIO.ProcessingIOType.SignalInput) return null;
            return io.connectedTo.signalOutput;
        }

        public SignalBuffer getSignalOutputBuffer(RTIO io)
        {
            if (io == null) return null;
            if (io.connectedTo == null) return null;
            if (io.IOtype != RTIO.ProcessingIOType.SignalOutput) return null;
            return io.connectedTo.signalInput;
        }

        public DataBuffer getDataInputBuffer(RTIO io)
        {
            if (io == null) return null;
            if (io.connectedTo == null) return null;
            if (io.IOtype != RTIO.ProcessingIOType.DataInput) return null;
            return io.connectedTo.dataOutput;
        }

        public DataBuffer getDataOutputBuffer(RTIO io)
        {
            if (io == null) return null;
            if (io.connectedTo == null) return null;
            if (io.IOtype != RTIO.ProcessingIOType.DataOutput) return null;
            return io.connectedTo.dataInput;
        }

        public enum DragMode
        {
            Idle = 0,
            Moving,
            DeleteBtn,
            ShrinkBtn,
            ActiveBtn
        }
        private DragMode dragMode = DragMode.Idle;
        private Vector dragStart;
        private Vector prevPos;
        private SystemPanel dragPa = null;
        private bool onDeleteButton = false;
        private bool onShrinkButton = false;
        private bool onActiveButton = false;


        private Rectangle getDeleteButton()
        {
            int bw = (int)Math.Floor(15 * scale + 0.5);
            return Rectangle.FromLTRB(Width - bw, 0, Width - 1, bw);
        }

        private Rectangle getShrinkButton()
        {
            int bw = (int)Math.Floor(15 * scale + 0.5);
            return Rectangle.FromLTRB(Width - 2 * bw, 0, Width - 1 - bw, bw);
        }

        private Rectangle getActiveButton()
        {
            int bw = (int)Math.Floor(15 * scale + 0.5);
            return Rectangle.FromLTRB(0, 0, 2 * bw, bw);
        }
        
        private void doPaint(Graphics g)
        {
            // Brush backBrush = new SolidBrush(Color.DarkMagenta);
            Rectangle cr = ClientRectangle;
            Rectangle deleteButton = getDeleteButton();
            Rectangle shrinkButton = getShrinkButton();
            Rectangle activeButton = getActiveButton();

            int x1 = 0;
            int x2 = Width - 1;
            x2 -= deleteButton.Width;
            if (_hasActiveSwitch) x1 += activeButton.Width;
            if (_canShrink) x2 -= shrinkButton.Width;
            int centerpos = (x1 + x2) / 2;
            
            /*
            if (_selected)
            {
                Rectangle titlebar = cr;
                titlebar.Height = deleteButton.Height+1;
                g.FillRectangle(selectBrush, titlebar);
            }
            */

            cr.Width -= 1;
            cr.Height -= 1;
            if (_selected)
                g.DrawRectangle(selectPen, cr);
            else
                g.DrawRectangle(framePen, cr);

            if (_shrinked)
            {
                if ((_shrinkTitle != null) && (_shrinkTitle.Length > 0))
                {
                    GraphicsUtil.drawText(g, Vector.V(centerpos, 0), _titleFont, scale,
                            _shrinkTitle, 0, 2, 0, 1, Vector.X, titleBrush);
                }
            }
            else
            {
                if ((_title != null) && (_title.Length > 0))
                {
                    GraphicsUtil.drawText(g, Vector.V(centerpos, 0), _titleFont, scale,
                            _title, 0, 2, 0, 1, Vector.X, titleBrush);
                }
            }

            //if (_selected)
            //    framePen = new Pen(Color.Red);
            // g.DrawLine(framePen, new PointF((float)scale * 5, (float)scale * 15), new PointF((float) (Width - scale*5), (float)scale * 15));

            if ((dragMode == DragMode.DeleteBtn) && onDeleteButton)
                GraphicsUtil.drawButton(g, deleteButton, GraphicsUtil.ButtonType.Delete, framePen, symbolOnPen);
            else
                GraphicsUtil.drawButton(g, deleteButton, GraphicsUtil.ButtonType.Delete, framePen, symbolPen);
            if (_canShrink)
            {
                if ((dragMode == DragMode.ShrinkBtn) && onShrinkButton)
                    GraphicsUtil.drawButton(g, shrinkButton, (_shrinked) ? GraphicsUtil.ButtonType.Expand : GraphicsUtil.ButtonType.Shrink, framePen, symbolOnPen);
                else
                    GraphicsUtil.drawButton(g, shrinkButton, (_shrinked) ? GraphicsUtil.ButtonType.Expand : GraphicsUtil.ButtonType.Shrink, framePen, symbolPen);
            }
            if (_hasActiveSwitch)
            {
                bool showActive = _active;
                if ((dragMode == DragMode.ActiveBtn) && onActiveButton)
                    showActive = !_active;
                if (showActive)
                {
                    g.FillRectangle(activeBrush, activeButton);
                    GraphicsUtil.drawButton(g, activeButton, GraphicsUtil.ButtonType.Active, framePen, activePen);
                }
                else
                {
                    GraphicsUtil.drawButton(g, activeButton, GraphicsUtil.ButtonType.InActive, framePen, passivePen);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            doPaint(e.Graphics);
        }
               
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            BringToFront();
            if ((Parent != null) && (e.Button == MouseButtons.Left))
            {
                if (!_selected)
                {
                    owner.unselectAll();
                    owner.selectMe(this);
                }
                else
                {
                    // Was part of the selection
                    // owner.unselectNets();
                }

                Rectangle deleteButton = getDeleteButton();
                Rectangle shrinkButton = getShrinkButton();
                Rectangle activeButton = getActiveButton();

                if (deleteButton.Contains(e.Location))
                {
                    dragMode = DragMode.DeleteBtn;
                    onDeleteButton = true;
                    Invalidate();
                }
                else if (_canShrink && shrinkButton.Contains(e.Location))
                {
                    dragMode = DragMode.ShrinkBtn;
                    onShrinkButton = true;
                    Invalidate();
                }
                else if (_hasActiveSwitch && activeButton.Contains(e.Location))
                {
                    dragMode = DragMode.ActiveBtn;
                    onActiveButton = true;
                    Invalidate();
                }
                else
                {
                    dragPa = (SystemPanel)Parent;
                    dragStart = dragPa.fromScreen(Vector.V(e.X + Location.X, e.Y + Location.Y));
                    prevPos = center;
                    dragMode = DragMode.Moving;
                    dragPa.initiateMove(this);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            switch (dragMode)
            {
                case DragMode.Moving:
                    Vector mpos = Vector.V(Location.X + e.X, Location.Y + e.Y);
                    Vector delta = dragPa.fromScreen(mpos) - dragStart;
                    center = prevPos + delta;
                    Vector loc = center - dim / 2;
                    if (shrinked)
                        loc = center - Vector.V(_shrinkSize)*scale / 2;
                    // loc.round(20);
                    Location = dragPa.toScreen(loc).Point;
                    dragPa.temporaryMove(this,delta);
                    dragPa.Invalidate();
                    break;
                case DragMode.DeleteBtn:
                    Rectangle deleteButton = getDeleteButton();
                    if (deleteButton.Contains(e.Location))
                    {
                        if (!onDeleteButton)
                        {
                            onDeleteButton = true;
                            Invalidate();
                        }
                    }
                    else
                    {
                        if (onDeleteButton)
                        {
                            onDeleteButton = false;
                            Invalidate();
                        }
                    }
                    break;
                case DragMode.ShrinkBtn:
                    Rectangle shrinkButton = getShrinkButton();
                    if (shrinkButton.Contains(e.Location))
                    {
                        if (!onShrinkButton)
                        {
                            onShrinkButton = true;
                            Invalidate();
                        }
                    }
                    else
                    {
                        if (onShrinkButton)
                        {
                            onShrinkButton = false;
                            Invalidate();
                        }
                    }
                    break;
                case DragMode.ActiveBtn:
                    Rectangle activeButton = getActiveButton();
                    if (activeButton.Contains(e.Location))
                    {
                        if (!onActiveButton)
                        {
                            onActiveButton = true;
                            Invalidate();
                        }
                    }
                    else
                    {
                        if (onActiveButton)
                        {
                            onActiveButton = false;
                            Invalidate();
                        }
                    }
                    break;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            switch (dragMode)
            {
                case DragMode.Moving:
                    Vector mpos = Vector.V(Location.X + e.X, Location.Y + e.Y);
                    Vector delta = dragPa.fromScreen(mpos) - dragStart;
                    center = prevPos + delta;
                    Vector loc = center - dim / 2;
                    if (shrinked)
                        loc = center - Vector.V(_shrinkSize) * scale / 2;
                    Location = dragPa.toScreen(loc).Point;
                    dragPa.finalizeMove(this, delta);
                    dragPa.Invalidate();
                    dragMode = DragMode.Idle;
                    break;
                case DragMode.DeleteBtn:
                    dragMode = DragMode.Idle;
                    Invalidate();
                    Rectangle deleteButton = getDeleteButton();
                    if (deleteButton.Contains(e.Location))
                        owner.DeleteElement(this);
                    break;
                case DragMode.ShrinkBtn:
                    dragMode = DragMode.Idle;
                    Invalidate();
                    Rectangle shrinkButton = getShrinkButton();
                    if (shrinkButton.Contains(e.Location))
                        setShrinkMode(!_shrinked);
                    break;
                case DragMode.ActiveBtn:
                    dragMode = DragMode.Idle;
                    Rectangle activeButton = getActiveButton();
                    if (activeButton.Contains(e.Location))
                    {
                        _active = !_active;
                        Invalidate();
                    }
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete)
            {
                owner.DeleteClicked();
                return true;
            } else 
                return base.ProcessCmdKey(ref msg, keyData);
        }
        
        public void initiateMove()
        {
            dragPa = (SystemPanel)Parent;
            prevPos = center;
        }

        public void temporaryMove(Vector delta)
        {
            center = prevPos + delta;
            Vector loc = center - dim / 2;
            if (shrinked)
                loc = center - Vector.V(_shrinkSize) * scale / 2;
            Location = dragPa.toScreen(loc).Point;
        }

        public void finalizeMove(Vector delta)
        {
            center = prevPos + delta;
            Vector loc = center - dim / 2;
            if (shrinked)
                loc = center - Vector.V(_shrinkSize) * scale / 2;
            Location = dragPa.toScreen(loc).Point;
        }

        public void updateFromRoot()
        {
            SystemPanel p = owner;
            if (p == null) return;
            RectangleF rf;
            if (_shrinked)
            {
                Vector dimS = Vector.V(_shrinkSize.Width, _shrinkSize.Height);
                rf = p.toScreenRF(center - dimS / 2, dimS);
            }
            else
                rf = p.toScreenRF(center - dim / 2, dim);
            Point loc = new Point((int)Math.Floor(rf.Left + 0.5), (int)Math.Floor(rf.Top + 0.5));
            scale = p.scale;
            Width = (int)Math.Floor(rf.Width + 0.5);
            Height = (int)Math.Floor(rf.Height + 0.5);
            Location = loc;
            foreach (Control c in Controls)
            {
                if ((c.GetType()).IsSubclassOf(typeof(RTControl)))
                {
                    RTControl cc = (RTControl)c;
                    cc.rescaleFromRoot(scale);
                }
            }
            Invalidate();
        }

        public void ForwardOnMouseDown(MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        public void ForwardOnMouseMove(MouseEventArgs e)
        {
            OnMouseMove(e);
        }

        public void ForwardOnMouseUp(MouseEventArgs e)
        {
            OnMouseUp(e);
        }

        public void ForwardOnMouseWheel(MouseEventArgs e)
        {
            OnMouseWheel(e);
        }

        public RTIO findIO(Vector v)
        {
            v -= Vector.V(Location);
            foreach (Control ct in Controls)
            {
                if ((ct is RTIO) && ct.Visible && ((RTIO)ct).hits(v))
                    return (RTIO)ct;
            }
            return null;
        }

        public void selectOnContained(VectorRect vr, APSelection sel)
        {
            VectorRect rf;            
            SystemPanel p = owner;
            if (p == null) return;
            if (_shrinked)
            {
                Vector dimS = Vector.V(_shrinkSize.Width, _shrinkSize.Height);
                rf = VectorRect.FromCenterSize(center, dimS);
            }
            else
                rf = VectorRect.FromCenterSize(center, dim);
            if (vr.inside(rf))
                sel.select(this);
        }

    }
}
