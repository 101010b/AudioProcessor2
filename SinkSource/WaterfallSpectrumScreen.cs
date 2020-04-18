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
    public partial class WaterfallSpectrumScreen : Control
    {
        WaterfallSpectrumWin root;
        public Boolean ready = false;

        private Brush backBrush;
        private Brush fontBrush;
        private Pen framePen;
        private Pen gridPen;
        private Pen selectPen;

        private Font _axesFont = new Font(FontFamily.GenericSansSerif, (float)8);
        public Font axesFont
        {
            set { _axesFont = value; Invalidate(); }
            get { return _axesFont; }
        }
        private Color _fontColor = Color.White;
        public Color fontColor
        {
            set { _fontColor = value; fontBrush = new SolidBrush(_fontColor); Invalidate(); }
            get { return _fontColor; }
        }
        private Color _frameColor = Color.White;
        public Color frameColor
        {
            set { _frameColor = value; framePen = new Pen(_frameColor); Invalidate(); }
            get { return _frameColor; }
        }
        private Color _gridColor = Color.FromArgb(0, 32, 0);
        public Color gridColor
        {
            set { _gridColor = value; gridPen = new Pen(_gridColor); Invalidate(); }
            get { return _gridColor; }
        }
        private Color _selectColor = Color.Red;
        public Color selectColor
        {
            set { _selectColor = value; selectPen = new Pen(_selectColor);Invalidate(); }
            get { return _selectColor; }
        }

        /*
        private Color _scaleColor = Color.Red;
        public Color scaleColor
        {
            set { _scaleColor = value;Invalidate(); }
            get { return _scaleColor; }
        }
        */
        public GridCalculator gridF;
        public GridCalculator gridY;
        public GridCalculator gridCol;
        Vector sizeXLable;
        Vector sizeYLable;
        Vector sizeColLable;
        int colbarHeight;

        public Boolean drawGrid;

        public ColorTable colorTable;

        public WaterfallSpectrumScreen()
        {
            InitializeComponent();

            framePen = new Pen(_frameColor);
            gridPen = new Pen(_gridColor);
            selectPen = new Pen(_selectColor);
            fontBrush = new SolidBrush(_fontColor);

            backBrush = new SolidBrush(BackColor);
            colorTable = new ColorTable("KrYW");

            BackColorChanged += WaterfallSpectrumScreen_BackColorChanged;

            colbarHeight = 10;

            drawGrid = true;
            DoubleBuffered = true;
            ready = false;
        }

        public void initWaterfallSpectrumScreen(WaterfallSpectrumWin _root)
        {
            root = _root;

            sizeXLable = GraphicsUtil.sizeText(Vector.Zero, _axesFont, 1.0, "100k", -1, 2, -1, 0, Vector.X).boundingDim();
            sizeYLable = GraphicsUtil.sizeText(Vector.Zero, _axesFont, 1.0, "60.0", -1, 2, -1, 0, Vector.X).boundingDim();
            sizeColLable = GraphicsUtil.sizeText(Vector.Zero, _axesFont, 1.0, "-120.0", -1, 2, -1, 0, Vector.X).boundingDim();

            // Horizontal Grid
            gridF = new GridCalculator(0, 1e6, 10, 0.1, 2, 100, 20000, false,
                sizeXLable.x + 10, Width - 10, sizeXLable.x + 10);

            // Vertical Grid
            gridY = new GridCalculator(0, 100, 1, 1e-10, 1.1, 0, 30, false,
                Height - sizeXLable.y - 10, sizeColLable.y+colbarHeight+10+10, sizeYLable.y + 10);

            // Color Grid
            gridCol = new GridCalculator(-200, 200, 1, 1e-10, 1.1, -120, 0, false,
                sizeColLable.x/2+10, Width-sizeColLable.x/2-10, sizeColLable.x + 10);

            ready = true;

        }

        private void WaterfallSpectrumScreen_BackColorChanged(object sender, EventArgs e)
        {
            backBrush = new SolidBrush(BackColor);
        }

        protected Bitmap colorbarBitmap;

        protected void createColorbarBitmap(int width, int height)
        {
            colorbarBitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            System.Drawing.Imaging.BitmapData bmd = colorbarBitmap.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            IntPtr ptr = bmd.Scan0;
            int strd = bmd.Stride / 4;
            int ints = bmd.Stride * bmd.Height / 4;
            int[] rgbvals = new int[ints];
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbvals, 0, ints);
            for (int x=0;x<width;x++)
            {
                Color col = colorTable.col((double)x / (width - 1.0));
                int c= col.ToArgb();
                for (int y = 0; y < height; y++)
                    rgbvals[y * strd + x] = c;
            }
            System.Runtime.InteropServices.Marshal.Copy(rgbvals, 0, ptr, ints);
            colorbarBitmap.UnlockBits(bmd);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {

            pe.Graphics.FillRectangle(backBrush, ClientRectangle);

            if (!ready) return;

            // Color Bar
            double startx = gridCol.low;
            double endx = gridCol.high;
            double starty = 5;
            double endy = 5+colbarHeight;
            int colorbarWidth = (int)Math.Floor(endx - startx + 1 + 0.5);

            RectangleF rf = new RectangleF((float)startx, (float)starty, (float)(endx - startx + 1), (float)(endy - starty + 1));
            if ((colorbarBitmap == null) || (colorbarBitmap.Width != colorbarWidth) || (colorTable.changed))
                createColorbarBitmap(colorbarWidth, colbarHeight);
            pe.Graphics.DrawImageUnscaled(colorbarBitmap, (int)Math.Floor(startx+0.5), (int)Math.Floor(starty+0.5)+1);
            pe.Graphics.DrawRectangle(framePen, rf.Left-2, rf.Top-2, rf.Width+3, rf.Height+3);

            
            for (int i = 0; i < gridCol.gridLength; i++)
            {
                double pos = gridCol.grid[i].screen;
                pe.Graphics.DrawLine(gridPen, (float)pos, (float)endy+3, (float)pos, (float)endy+8);
                if (gridCol.grid[i].show)
                    GraphicsUtil.drawText(pe.Graphics, Vector.V(pos, endy+10), _axesFont, 1, gridCol.grid[i].name, 0, 2, 0, 1, Vector.X, fontBrush);
            }
            

            // Main Screen
            startx = gridF.low;
            endx = gridF.high;
            starty = gridY.low;
            endy = gridY.high;

            rf = new RectangleF((float)startx, (float)endy, (float)(endx - startx + 1), (float)(starty - endy + 1));

            //Region oldReg = pe.Graphics.Clip;
            //pe.Graphics.Clip = new Region(rf);

            root.drawWaterfallBitmap(pe.Graphics, (int)Math.Floor(startx + 0.5), (int)Math.Floor(endy + 0.5));

            //pe.Graphics.Clip = oldReg;

            pe.Graphics.DrawRectangle(framePen, rf.Left-2, rf.Top-2, rf.Width+3, rf.Height+3);

            
            for (int i = 0; i < gridY.gridLength; i++)
            {
                double pos = gridY.grid[i].screen;
                if (drawGrid)
                    pe.Graphics.DrawLine(gridPen, (float)startx, (float)pos, (float)endx, (float)pos);
                if (gridY.grid[i].show)
                    GraphicsUtil.drawText(pe.Graphics, Vector.V(5, pos), _axesFont, 1, gridY.grid[i].name, -1, 2, -1, 0, Vector.X, fontBrush);
            }
            for (int i = 0; i < gridF.gridLength; i++)
            {
                double pos = gridF.grid[i].screen;
                if (drawGrid)
                    pe.Graphics.DrawLine(gridPen, (float)pos, (float)starty, (float)pos, (float)endy);
                if (gridF.grid[i].show)
                    GraphicsUtil.drawText(pe.Graphics, Vector.V(pos, Height - 5), _axesFont, 1, gridF.grid[i].name, 0, 2, 0, -1, Vector.X, fontBrush);
            }

            if (dragging)
            {
                Vector vmin = Vector.min(startDrag, stopDrag);
                Vector vmax = Vector.max(startDrag, stopDrag);
                rf = new RectangleF((float)vmin.x, (float)gridY.high,
                    (float)(vmax.x - vmin.x + 1), (float)(gridY.low - gridY.high+1));
                pe.Graphics.DrawRectangle(selectPen, rf.Left, rf.Top, rf.Width, rf.Height);
            }

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (!ready) return;
            if ((Width == 0) || (Height == 0)) return;
            gridF.reScreen(sizeXLable.x + 10, Width - 10);
            gridY.reScreen(Height - sizeXLable.y - 10, sizeColLable.y + colbarHeight + 10 + 10);
            gridCol.reScreen(sizeColLable.x / 2 + 10, Width - sizeColLable.x / 2 - 10);

            double bst = (double)root.blockSize / root.waterfallSpectrum.owner.sampleRate;
            gridY.max = (gridY.low - gridY.high) * bst;

            Invalidate();
        }

        private Boolean dragging;
        private Vector startDrag;
        private Vector stopDrag;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!ready) return;
            if (e.Button != MouseButtons.Left) return;
            if (e.X < gridF.low) return;
            if (e.X > gridF.high) return;
            if (e.Y < gridY.high) return;
            if (e.Y > gridY.low) return;

            startDrag = Vector.V(e.X, e.Y);
            stopDrag = startDrag;
            dragging = true;
            Capture = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!ready) return;
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
            if (!ready) return;

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
                // gridY.newRange(y1, y2);

                root.updateRanges();

                Invalidate();
            }
        }


    }
}
