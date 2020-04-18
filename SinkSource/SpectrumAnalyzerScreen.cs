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
    public partial class SpectrumAnalyzerScreen : Control
    {
        SpectrumAnalyzerWin root;
        public int channels;
        public SinkSource.SpectrumAnalyzerWin.SpectrumAnalyzerLine[] lines;

        private bool _drawGrid = true;
        public bool drawGrid
        {
            set { _drawGrid = value; Invalidate(); }
            get { return _drawGrid; }
        }

        private Brush brushBack;
        private Brush brushText;
        private Pen penFrame;
        private Pen penSelect;
        private Pen penMajorGrid;
        private Pen penGrid;

        private Font _axesFont = new Font(FontFamily.GenericSansSerif, (float)8);
        public Font axesFont
        {
            get { return _axesFont; }
            set { _axesFont = value; Invalidate(); }
        }

        private Color _colorGrid = Color.DimGray;
        public Color colorGrid
        {
            set { _colorGrid = value; penGrid = new Pen(_colorGrid); Invalidate(); }
            get { return _colorGrid; }
        }

        private Color _colorMajorGrid = Color.Gray;
        public Color colorMajorGrid
        {
            set { _colorMajorGrid = value; penMajorGrid = new Pen(_colorMajorGrid); Invalidate(); }
            get { return _colorMajorGrid; }
        }

        private Color _colorFrame = Color.White;
        public Color colorFrame
        {
            set { _colorFrame = value; penFrame = new Pen(_colorFrame); Invalidate(); }
            get { return _colorFrame; }
        }

        private Color _colorText = Color.White;
        public Color colorText
        {
            set { _colorText = value; brushText = new SolidBrush(_colorText); Invalidate(); }
            get { return _colorText; }
        }

        private Color _colorSelect = Color.Red;
        public Color colorSelect
        {
            set { _colorSelect = value; penSelect = new Pen(_colorSelect); Invalidate(); }
            get { return _colorSelect; }
        }

        public GridCalculator gridF;
        public GridCalculator gridY;

        public double[] freq;
        public double[] xpos;

        public SpectrumAnalyzerScreen()
        {
            InitializeComponent();

            brushBack = new SolidBrush(BackColor);

            penGrid = new Pen(_colorGrid);
            penMajorGrid = new Pen(_colorMajorGrid);
            penFrame = new Pen(_colorFrame);
            brushText = new SolidBrush(_colorText);
            penSelect = new Pen(_colorSelect);

            DoubleBuffered = true;
            channels = 0;
            BackColorChanged += SpectrumAnalyzerScreen_BackColorChanged;

        }

        private void SpectrumAnalyzerScreen_BackColorChanged(object sender, EventArgs e)
        {
            brushBack = new SolidBrush(BackColor);
        }

        private Vector sizeXLable;
        private Vector sizeYLable;

        public void initSpectrumAnalyzerScreen(SpectrumAnalyzerWin _root, int _channels, 
            SinkSource.SpectrumAnalyzerWin.SpectrumAnalyzerLine[] _lines)
        {
            root = _root;
            lines = _lines;

            sizeXLable = GraphicsUtil.sizeText(Vector.Zero, _axesFont, 1.0, "100k", -1, 2, -1, 0, Vector.X).boundingDim();
            sizeYLable = GraphicsUtil.sizeText(Vector.Zero, _axesFont, 1.0, "-120.0", -1, 2, -1, 0, Vector.X).boundingDim();

            gridF = new GridCalculator(0, 1e6, 10, 0.1, 2, 100, 20000, false, 
                sizeXLable.x+10,Width-10,sizeXLable.x+10);
            gridY = new GridCalculator(-200, 200, 1, 1e-10, 1.1, -120, 0, false,
                Height-sizeXLable.y-10, 10, sizeYLable.y + 10);

            channels = _channels;

            reCalcF();

        }

        public void reCalcX()
        {
            if (freq == null) return;
            if ((xpos == null) || (xpos.Length != freq.Length))
                xpos = new double[freq.Length];
            for (int i=0;i<freq.Length;i++)
                xpos[i] = gridF.getInterpolatedPos(freq[i]);
        }

        public void reCalcF()
        {
            int bs = root._blockSize;
            freq = new double[bs / 2];
            xpos = new double[bs / 2];
            double df = (double)root.spectrumAnalyzer.owner.sampleRate / 2.0 / (bs /2.0);
            for (int i = 0; i < bs / 2; i++)
                freq[i] = (double)i * df;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.FillRectangle(brushBack, ClientRectangle);

            if (channels == 0) return;

            double startx = gridF.low;
            double endx = gridF.high;
            double starty = gridY.low;
            double endy = gridY.high;

            RectangleF rf = new RectangleF((float)startx, (float)endy, (float)(endx - startx + 1), (float)(starty - endy + 1));

            pe.Graphics.DrawRectangle(penFrame, rf.Left-2,rf.Top-2, rf.Width+3, rf.Height+3);

            for (int i = 0; i < gridY.gridLength; i++)
            {
                double pos = gridY.grid[i].screen;
                if (_drawGrid)
                    pe.Graphics.DrawLine(penGrid, (float)startx, (float)pos, (float)endx, (float)pos);
                if (gridY.grid[i].show)
                    GraphicsUtil.drawText(pe.Graphics, Vector.V(5, pos), _axesFont, 1, gridY.grid[i].name, -1, 2, -1, 0, Vector.X, brushText);
            }
            for (int i = 0; i < gridF.gridLength; i++)
            {
                double pos = gridF.grid[i].screen;
                if (_drawGrid)
                    pe.Graphics.DrawLine(penGrid, (float)pos, (float)starty, (float)pos, (float)endy);
                if (gridF.grid[i].show)
                    GraphicsUtil.drawText(pe.Graphics, Vector.V(pos, Height - 5), _axesFont, 1, gridF.grid[i].name, 0, 2, 0, -1, Vector.X, brushText);
            }

            Region oldReg = pe.Graphics.Clip;
            pe.Graphics.Clip = new Region(rf);

            reCalcX();
            for (int i = 0; i < channels; i++)
                lines[i].Draw(pe.Graphics);

            pe.Graphics.Clip = oldReg;

            if (dragging)
            {
                Vector vmin = Vector.min(startDrag, stopDrag);
                Vector vmax = Vector.max(startDrag, stopDrag);
                rf = new RectangleF((float)vmin.x, (float)vmin.y,
                    (float)(vmax.x - vmin.x + 1), (float)(vmax.y - vmin.y + 1));
                pe.Graphics.DrawRectangle(penSelect, rf.Left, rf.Top, rf.Width, rf.Height);
            }

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (channels <= 0) return;
            if ((Width == 0) || (Height == 0)) return;
            gridF.reScreen(sizeXLable.x + 10, Width - 10);
            gridY.reScreen(Height - sizeXLable.y - 10, 10);
            Invalidate();
        }

        private Boolean dragging;
        private Vector startDrag;
        private Vector stopDrag;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left) return;
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

                double f1 = gridF.getAbsolutePos(startDrag.x);
                double f2 = gridF.getAbsolutePos(stopDrag.x);
                if (f1 > f2) flip(ref f1, ref f2);
                double y1 = gridY.getAbsolutePos(startDrag.y);
                double y2 = gridY.getAbsolutePos(stopDrag.y);
                if (y1 > y2) flip(ref y1, ref y2);
                gridF.newRange(f1, f2);
                gridY.newRange(y1, y2);

                root.updateRanges();

                Invalidate();
            }
        }

    }
}
