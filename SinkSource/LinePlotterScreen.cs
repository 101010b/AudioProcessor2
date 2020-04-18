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
    public partial class LinePlotterScreen : Control
    {

        LinePlotterWin root;
        public int channels;
        public SinkSource.LinePlotterWin.Line[] lines;

        private bool _showGrid = true;
        public bool showGrid
        {
            set { _showGrid = value; Invalidate(); }
            get { return _showGrid; }
        }

        private Color _colorBack = Color.Black;
        private Brush brushBack = new SolidBrush(Color.Black);
        public Color colorBack
        {
            set { _colorBack = value; brushBack = new SolidBrush(_colorBack); Invalidate(); }
            get { return _colorBack; }
        }
        private Color _colorText = Color.White;
        private Brush brushText = new SolidBrush(Color.White);
        public Color colorText
        {
            set { _colorText = value; brushText = new SolidBrush(_colorText);Invalidate(); }
            get { return _colorText; }
        }
        private Color _colorGrid = Color.FromArgb(0, 32, 0);
        private Brush brushGrid = new SolidBrush(Color.FromArgb(0, 32, 0));
        private Pen penGrid = new Pen(Color.FromArgb(0, 32, 0));
        public Color colorGrid
        {
            set { _colorGrid = value; penGrid = new Pen(_colorGrid);brushGrid = new SolidBrush(_colorGrid); Invalidate(); }
        }
        private Color _colorMajorGrid = Color.FromArgb(0, 64, 0);
        private Pen penMajorGrid = new Pen(Color.FromArgb(0, 64, 0));
        public Color colorMajorGrid
        {
            set { _colorMajorGrid = value; penMajorGrid = new Pen(_colorMajorGrid); Invalidate(); }
            get { return _colorMajorGrid; }
        }
        private Color _colorFrame = Color.White;
        private Pen penFrame = new Pen(Color.White);
        public Color colorFrame
        {
            set { _colorFrame = value; penFrame = new Pen(_colorFrame); Invalidate(); }
            get { return _colorFrame; }
        }
        private Color _colorSelect = Color.Red;
        private Pen penSelect = new Pen(Color.Red);
        public Color colorSelect
        {
            set { _colorSelect = value; penSelect = new Pen(_colorSelect); Invalidate(); }
            get { return _colorSelect; }
        }
        private Font _axesFont = new Font(FontFamily.GenericSansSerif, (float)8);
        public Font axesFont
        {
            set { _axesFont = value;Invalidate(); }
            get { return _axesFont; }
        }

        public GridCalculator gridX;
        private int grids=4;
        public int useGrids;
        public GridCalculator[] gridY;
        public Boolean[] autoScale;

        public LinePlotterScreen()
        {
            InitializeComponent();

            DoubleBuffered = true;
            channels = 0;
            useGrids = 0;
            BackColorChanged += SpectrumAnalyzerScreen_BackColorChanged;
        }

        private void SpectrumAnalyzerScreen_BackColorChanged(object sender, EventArgs e)
        {
            colorBack = BackColor;
        }

        private Vector sizeXLable;
        private Vector sizeYLable;

        public void initLinePlotterScreen(LinePlotterWin _root, int _channels,
            SinkSource.LinePlotterWin.Line[] _lines)
        {
            root = _root;
            lines = _lines;

            sizeXLable = GraphicsUtil.sizeText(Vector.Zero, _axesFont, 1.0, "0.01", -1, 2, -1, 0, Vector.X).boundingDim();
            sizeYLable = GraphicsUtil.sizeText(Vector.Zero, _axesFont, 1.0, "-1.000", -1, 2, -1, 0, Vector.X).boundingDim();

            gridX = new GridCalculator(-60,0, 0.1, 0.1, 2, -60, 0, false,
                sizeYLable.x+5, Width - 10, sizeXLable.x + 10);

            gridY = new GridCalculator[grids];
            for (int i=0;i< grids;i++)
                gridY[i] = new GridCalculator(-1000, 1000, 1, 1e-10, 1.1, -5, 5, false,
                    Height - sizeXLable.y - 10, 10, sizeYLable.y + 10);
            autoScale = new Boolean[grids];
            for (int i = 0; i < grids; i++)
                autoScale[i] = false;

            useGrids = 1;
            arrangeGrids();

            channels = _channels;
        }

        public void arrangeGrids()
        {
            // H = 2+Q*N+spc*(N-1)+S
            double Q = (Height - 10 - sizeXLable.y - 5 - 10 * (useGrids - 1))/(useGrids);
            double strt = 10;
            for (int i = 0; i < useGrids; i++)
            {
                double high = strt;
                double low = strt + Q;
                strt += Q;
                strt += 10;
                gridY[i].reScreen(low, high);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // base.OnPaint(pe);
            // Grid

            pe.Graphics.FillRectangle(brushBack, ClientRectangle);

            if (channels == 0) return;

            double startx = gridX.low;
            double endx = gridX.high;
            RectangleF rf;

            for (int q=0;q<useGrids;q++)
            {
                double starty = gridY[q].low;
                double endy = gridY[q].high;

                if (autoScale[q])
                {
                    double asMin = -1;
                    double asMax = 1;
                    Boolean foundone = false;
                    for (int i = 0; i < channels; i++)
                        if ((lines[i].useScreen == q) || ((lines[i].useScreen >= useGrids) && (q == 0)))
                        {
                            if (!foundone)
                            {
                                asMin = lines[i].valMin * lines[i].scale + lines[i].offset;
                                asMax = lines[i].valMax * lines[i].scale + lines[i].offset;
                                foundone = true;
                            } else
                            {
                                double lmin = lines[i].valMin * lines[i].scale + lines[i].offset;
                                double lmax = lines[i].valMax * lines[i].scale + lines[i].offset;
                                if (lmax > asMax)
                                    asMax = lmax;
                                if (lmin < asMin)
                                    asMin = lmin;
                            }
                        }
                    gridY[q].newRange(asMin, asMax);
                }

                rf = new RectangleF((float)startx, (float)endy, (float)(endx - startx + 1), (float)(starty - endy + 1));

                pe.Graphics.DrawRectangle(penFrame, rf.Left-2, rf.Top-2, rf.Width+3, rf.Height+3);

                for (int i = 0; i < gridY[q].gridLength; i++)
                {
                    double pos = gridY[q].grid[i].screen;
                    if (_showGrid)
                        pe.Graphics.DrawLine(penGrid, (float)startx, (float)pos, (float)endx, (float)pos);
                    if (gridY[q].grid[i].show)
                        GraphicsUtil.drawText(pe.Graphics, Vector.V(startx-2, pos), _axesFont, 1, gridY[q].grid[i].name, 1, 2, 1, 0, Vector.X, brushText);
                }
                for (int i = 0; i < gridX.gridLength; i++)
                {
                    double pos = gridX.grid[i].screen;
                    if (_showGrid)
                        pe.Graphics.DrawLine(penGrid, (float)pos, (float)starty, (float)pos, (float)endy);
                    if ((q == useGrids-1) && (gridX.grid[i].show))
                        GraphicsUtil.drawText(pe.Graphics, Vector.V(pos, starty+2), _axesFont, 1, gridX.grid[i].name, 0, 2, 0, 1, Vector.X, brushText);
                }

                Region oldReg = pe.Graphics.Clip;
                pe.Graphics.Clip = new Region(rf);

                for (int i = 0; i < channels; i++)
                {
                    if ((lines[i].useScreen == q) || ((lines[i].useScreen >= useGrids) && (q == 0)))
                        lines[i].draw(pe.Graphics, gridX, gridY[(lines[i].useScreen>=useGrids)?0:q]);
                }

                pe.Graphics.Clip = oldReg;
            }

            if (dragging)
            {
                Vector vmin = Vector.min(startDrag, stopDrag);
                Vector vmax = Vector.max(startDrag, stopDrag);
                rf = new RectangleF((float)vmin.x, (float)gridY[0].high,
                    (float)(vmax.x - vmin.x + 1), (float)(gridY[useGrids-1].low-gridY[0].high));
                pe.Graphics.DrawRectangle(penSelect, rf.Left, rf.Top, rf.Width, rf.Height);
            }
            
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (channels <= 0) return;
            if ((Width == 0) || (Height == 0)) return;
            gridX.reScreen(sizeYLable.x + 5, Width - 10);
            arrangeGrids();
            // gridY.reScreen(Height - sizeXLable.y - 10, 10);
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

                
                double x1 = gridX.getAbsolutePos(startDrag.x);
                double x2 = gridX.getAbsolutePos(stopDrag.x);
                if (x1 > x2) flip(ref x1, ref x2);
                gridX.newRange(x1, x2);

                // root.updateRanges();
                Invalidate();
            }
        }

    }
}
