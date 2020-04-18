using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioProcessor.SinkSource
{
    public partial class VNAScreen : Control
    {

        public VNAWin root;

        public bool dualDisplay;
        Plot plot1, plot2;
        public VNAWin.PlotMode plot1Mode;
        public VNAWin.PlotMode plot2Mode;

        public class PlotSet
        {
            public string name;
            public PlotTrace absA;
            public PlotTrace[] absB;
            public PlotTrace[] absBA;
            public PlotTrace[] phiBA;
            public PlotTrace logA;
            public PlotTrace[] logB;
            public PlotTrace[] logBA;
        }
        List<PlotSet> plotSet;
        PlotSet current;

        Boolean logX;
        public GridCalculator x, y1, y2;

        double xleft;
        double xright;

        // Single Plot
        double ystop;
        double ysbottom;

        // Dual Plot
        double yd1top;
        double yd1bottom;
        double yd2top;
        double yd2bottom;

        Vector xlableSize;
        Vector ylableSize;

        private Brush brushBack;
        private Color _colorBack = Color.Black;
        public Color colorBack
        {
            set {
                _colorBack = value;
                brushBack = new SolidBrush(_colorBack);
                if (plot1 != null) plot1.colorBack = _colorBack;
                if (plot2 != null) plot2.colorBack = _colorBack;
                Invalidate(); }
            get { return _colorBack; }
        }
        private Pen penSelect;
        private Color _colorSelect = Color.Red;
        public Color colorSelect
        {
            set {
                _colorSelect = value;
                penSelect = new Pen(_colorSelect);
                Invalidate(); }
            get { return _colorSelect; }
        }
        private Font _axesFont = new Font(FontFamily.GenericSansSerif, (float)8);
        public Font axesFont
        {
            set {
                _axesFont = value;
                if (plot1 != null) plot1.fontText = _axesFont;
                if (plot2 != null) plot2.fontText = _axesFont;
                Invalidate(); }
            get { return _axesFont; }
        }
        private Color _colorFrame = Color.White;
        public Color colorFrame
        {
            set
            {
                _colorFrame = value;
                if (plot1 != null) plot1.colorFrame = _colorFrame;
                if (plot2 != null) plot2.colorFrame = _colorFrame;
                Invalidate();
            }
            get { return _colorFrame; }
        }
        private Color _colorGrid = Color.FromArgb(0, 32, 0);
        public Color colorGrid
        {
            set
            {
                _colorGrid = value;
                if (plot1 != null) plot1.colorGrid = _colorGrid;
                if (plot2 != null) plot2.colorGrid = _colorGrid;
                Invalidate();
            }
            get { return _colorGrid; }
        }
        private Color _colorGridMajor = Color.FromArgb(0, 64, 0);
        public Color colorGridMajor
        {
            set
            {
                _colorGridMajor = value;
                if (plot1 != null) plot1.colorGridMajor = _colorGridMajor;
                if (plot2 != null) plot2.colorGridMajor = _colorGridMajor;
                Invalidate();
            }
            get { return _colorGridMajor; }
        }
        private Color _colorText = Color.White;
        public Color colorText
        {
            set
            {
                _colorText = value;
                if (plot1 != null) plot1.colorText = _colorText;
                if (plot2 != null) plot2.colorText = _colorText;
                Invalidate();
            }
            get { return _colorText; }
        }


        public VNAScreen()
        {
            InitializeComponent();

            DoubleBuffered = true;

            ylableSize = GraphicsUtil.sizeText(_axesFont, "199.0", 2, 0, 0).boundingDim();
            xlableSize = GraphicsUtil.sizeText(_axesFont, "20.00k", 2, 0, 0).boundingDim();

            newSize();

            dualDisplay = false;
            plot1Mode = VNAWin.PlotMode.logBA;
            plot2Mode = VNAWin.PlotMode.phiBA;

            logX = true;

            brushBack = new SolidBrush(_colorBack);
            penSelect = new Pen(_colorSelect);

            if (root == null)
                x = new GridCalculator(0.1, 100000, 1, 0.1, 1.1, 100, 20000, logX, xleft, xright, xlableSize.x);
            else
                x = new GridCalculator(0.1, 100000, 1, 0.1, 1.1, root.sweepFMin, root.sweepFMax, logX, xleft, xright, xlableSize.x);

            y1 = new GridCalculator(-200, 200, 1, 1, 1.1, -100, 20, false, yd1bottom, yd1top, ylableSize.y);
            y2 = new GridCalculator(-200, 200, 1, 1, 1.1, -180, 180, false, yd2bottom, yd2top, ylableSize.y);

            plot1 = new Plot(x, y1);
            plot2 = new Plot(x, y2);

            plot1.fontText = _axesFont;
            plot1.colorBack = _colorBack;
            plot1.colorFrame = _colorFrame;
            plot1.colorGrid = _colorGrid;
            plot1.colorGridMajor = _colorGridMajor;
            plot1.colorText = _colorText;

            plot2.fontText = _axesFont;
            plot2.colorBack = _colorBack;
            plot2.colorFrame = _colorFrame;
            plot2.colorGrid = _colorGrid;
            plot2.colorGridMajor = _colorGridMajor;
            plot2.colorText = _colorText;

            plotSet = new List<PlotSet>();
            current = null;
        }

        private void newSize()
        {
            xleft = ylableSize.x + 10;
            xright = Width - 10;

            // Single Plot
            ystop = 10;
            ysbottom = Height - 10 - xlableSize.y;

            // Dual Plot
            yd1top = ystop;
            yd1bottom = Height / 2 - 10 -xlableSize.y;
            yd2top = Height / 2 + 10;
            yd2bottom = Height - 10 - xlableSize.y;
        }

        private PlotTrace[] getTrace(PlotSet p, VNAWin.PlotMode mode)
        {
            if (p == null)
                return null;
            switch (mode)
            {
                case VNAWin.PlotMode.absA: return new PlotTrace[1] { p.absA };
                case VNAWin.PlotMode.absB: return p.absB;
                case VNAWin.PlotMode.absBA: return p.absBA;
                case VNAWin.PlotMode.phiBA: return p.phiBA;
                case VNAWin.PlotMode.logA: return new PlotTrace[1] { p.logA };
                case VNAWin.PlotMode.logB: return p.logB;
                case VNAWin.PlotMode.logBA: return p.logBA;
            }
            return null;
        }
        
        private PlotTrace[] getTrace(int selection, VNAWin.PlotMode mode)
        {
            if (selection < 0)
                return getTrace(current, mode);
            else
                return getTrace(plotSet[selection], mode);
        }

        public void saveTrace()
        {
            if (current == null)
                return;
            if (root.running)
                return;
            current.absA.color.color = Color.Gray;
            current.logA.color.color = Color.Gray;
            for (int i=0;i<current.absB.Length;i++)
            {
                current.absB[i].color.color = Color.Gray;
                current.absBA[i].color.color = Color.Gray;
                current.phiBA[i].color.color = Color.Gray;
                current.logB[i].color.color = Color.Gray;
                current.logBA[i].color.color = Color.Gray;
            }
            plotSet.Insert(0, current);
            root.vnaMemoryList.Items.Insert(0, current.name);
            root.vnaMemoryList.SelectedIndex = 0;
            current = null;
            updatePlot1();
            updatePlot2();
            Invalidate();
        }

        public void deleteSelectedTrace()
        {
            int idx = root.vnaMemoryList.SelectedIndex;
            if (idx < 0) return;
            root.vnaMemoryList.Items.RemoveAt(idx);
            if (root.vnaMemoryList.Items.Count > 0)
            {
                if (idx >= root.vnaMemoryList.Items.Count)
                    root.vnaMemoryList.SelectedIndex = idx - 1;
            }
            plotSet.RemoveAt(idx);
            updatePlot1();
            updatePlot2();
            Invalidate();
        }

        private void updatePlot1()
        {
            plot1.clear();
            for (int i = 0; i < plotSet.Count; i++)
                plot1.addTrace(getTrace(i, plot1Mode));
            if (current != null)
                plot1.addTrace(getTrace(-1, plot1Mode));
        }

        private void updatePlot2()
        {
            plot2.clear();
            for (int i = 0; i < plotSet.Count; i++)
                plot2.addTrace(getTrace(i, plot2Mode));
            if (current != null)
                plot2.addTrace(getTrace(-1, plot2Mode));
        }

        public Color getTraceColor(int i)
        {
            switch (i % 8)
            {
                case 0: return Color.FromArgb(255, 0, 0);
                case 1: return Color.FromArgb(0, 255, 0);
                case 2: return Color.FromArgb(0, 0, 255);
                case 3: return Color.FromArgb(255, 255, 0);
                case 4: return Color.FromArgb(255, 0, 255);
                case 5: return Color.FromArgb(0, 255, 0);
                case 6: return Color.FromArgb(255, 127, 0);
                case 7: return Color.FromArgb(0, 255, 127);
            }
            return Color.Red;
        }

        public void addTraces(PlotTrace _absA, PlotTrace[] _absB, PlotTrace[] _absBA, PlotTrace[] _phiBA, PlotTrace _logA, PlotTrace[] _logB, PlotTrace[] _logBA)
        {
            PlotSet t = new PlotSet();
            t.name = DateTime.Now.ToLongDateString();
            t.absA = _absA;
            t.absB = (PlotTrace[])_absB.Clone();
            t.absBA = (PlotTrace[])_absBA.Clone();
            t.phiBA = (PlotTrace[])_phiBA.Clone();
            t.logA = _logA;
            t.logB = (PlotTrace[])_logB.Clone();
            t.logBA = (PlotTrace[])_logBA.Clone();

            current = t;
            for (int i=0;i<_absB.Length;i++)
            {
                current.absB[i].color.color = getTraceColor(i);
                current.absBA[i].color.color = getTraceColor(i);
                current.phiBA[i].color.color = getTraceColor(i);
                current.logB[i].color.color = getTraceColor(i);
                current.logBA[i].color.color = getTraceColor(i);
            }

            updatePlot1();
            updatePlot2();

            Invalidate();
        }

        private void setLimits(Plot p, VNAWin.PlotMode m)
        {
            switch (m)
            {
                case VNAWin.PlotMode.absA:
                case VNAWin.PlotMode.absB:
                case VNAWin.PlotMode.absBA:
                    p.yAxis.newRange(0, 10);
                    break;
                case VNAWin.PlotMode.phiBA:
                    p.yAxis.newRange(-180, 180);
                    break;
                case VNAWin.PlotMode.logA:
                case VNAWin.PlotMode.logB:
                case VNAWin.PlotMode.logBA:
                    p.yAxis.newRange(-120, 20);
                    break;
            }
            p.xAxis.newRange(100, 20000);
        }

        public void resetScale()
        {
            setLimits(plot1, plot1Mode);
            setLimits(plot2, plot2Mode);
            Invalidate();
        }

        public void changePlot(Boolean _dualDisplay, VNAWin.PlotMode _plot1Mode, VNAWin.PlotMode _plot2Mode)
        {
            if ((_dualDisplay==dualDisplay) && (_plot1Mode==plot1Mode) && (_plot2Mode == plot2Mode)) return;
            if (_plot1Mode != plot1Mode)
            {
                plot1Mode = _plot1Mode;
                updatePlot1();
                setLimits(plot1, plot1Mode);
            }
            if (_plot2Mode != plot2Mode)
            {
                plot2Mode = _plot2Mode;
                updatePlot2();
                setLimits(plot2, plot2Mode);
            }
            if (_dualDisplay != dualDisplay)
            {
                dualDisplay = _dualDisplay;
                y2.reScreen(yd2bottom, yd2top);
                if (dualDisplay)
                {
                    y1.reScreen(yd1bottom, yd1top);
                } else
                {
                    y1.reScreen(ysbottom, ystop);
                }
            }
            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if ((Width == 0) || (Height == 0)) return;

            newSize();

            x.reScreen(xleft, xright);
            if (dualDisplay)
            {
                y1.reScreen(yd1bottom, yd1top);
                y2.reScreen(yd2bottom, yd2top);
            } else
            {
                y1.reScreen(ysbottom, ystop);
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            /// base.OnPaint(pe);
            pe.Graphics.FillRectangle(brushBack, ClientRectangle);

            if (dualDisplay)
            {
                plot1.draw(pe.Graphics);
                plot2.draw(pe.Graphics);
            } else
            {
                plot1.draw(pe.Graphics);
            }

            if (dragging)
            {
                Region oldClip = pe.Graphics.Clip;
                if (selectedScreen == 0)
                {
                    if (dualDisplay)
                        pe.Graphics.Clip = new Region(new RectangleF((float)xleft, (float)yd1top, (float)(xright - xleft), (float)(yd1bottom - yd1top)));
                    else
                        pe.Graphics.Clip = new Region(new RectangleF((float)xleft, (float)ystop, (float)(xright - xleft), (float)(ysbottom - ystop)));
                } else
                    pe.Graphics.Clip = new Region(new RectangleF((float)xleft, (float)yd2top, (float)(xright - xleft), (float)(yd2bottom - yd2top)));

                Vector vmin = Vector.min(startDrag, stopDrag);
                Vector vmax = Vector.max(startDrag, stopDrag);
                RectangleF rf = new RectangleF((float)vmin.x, (float)vmin.y,
                    (float)(vmax.x - vmin.x + 1), (float)(vmax.y - vmin.y + 1));

                pe.Graphics.DrawRectangle(penSelect, rf.Left, rf.Top, rf.Width, rf.Height);
                pe.Graphics.Clip = oldClip;
            }
        }

        private Boolean dragging;
        private Vector startDrag;
        private Vector stopDrag;
        private int selectedScreen;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left) return;
            selectedScreen = 0;
            if ((e.Y > Height / 2) && (dualDisplay))
                selectedScreen = 1;
            startDrag = Vector.V(e.X, e.Y);
            stopDrag = startDrag;
            dragging = true;
            Capture = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (dragging)
            {
                stopDrag = Vector.V(e.X, e.Y);
                Invalidate();
            }
        }

        private void flip(ref double a, ref double b)
        {
            double t = a;
            a = b;
            b = t;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (dragging)
            {
                Capture = false;
                stopDrag = Vector.V(e.X, e.Y);
                dragging = false;

                if (Math.Abs(startDrag.x - stopDrag.x) < 5) return;
                if (Math.Abs(startDrag.y - stopDrag.y) < 5) return;

                double x1 = x.getAbsolutePos(startDrag.x);
                double x2 = x.getAbsolutePos(stopDrag.x);
                if (x1 > x2) flip(ref x1, ref x2);
                x.newRange(x1, x2);

                if (selectedScreen == 0)
                {
                    double u1 = y1.getAbsolutePos(startDrag.y);
                    double u2 = y1.getAbsolutePos(stopDrag.y);
                    if (u1 > u2) flip(ref u1, ref u2);
                    y1.newRange(u1, u2);
                } else
                {
                    double u1 = y2.getAbsolutePos(startDrag.y);
                    double u2 = y2.getAbsolutePos(stopDrag.y);
                    if (u1 > u2) flip(ref u1, ref u2);
                    y2.newRange(u1, u2);
                }
                root.updateRanges();

                Invalidate();
            }
        }


    }
}
