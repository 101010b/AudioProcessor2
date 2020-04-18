using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace AudioProcessor
{
    public class Plot
    {
        public GridCalculator xAxis;
        public GridCalculator yAxis;

        List<PlotTrace> traces;

        private Color _colorBack = Color.Black;
        private Brush brushBack;
        public Color colorBack
        {
            set { _colorBack = value; brushBack = new SolidBrush(_colorBack); }
            get { return _colorBack; }
        }
        private Color _colorFrame = Color.White;
        private Pen penFrame;
        public Color colorFrame
        {
            set { _colorFrame = value; penFrame = new Pen(_colorFrame); }
            get { return _colorFrame; }
        }
        private Color _colorGrid = Color.FromArgb(0, 32, 0);
        private Pen penGrid;
        public Color colorGrid
        {
            set { _colorGrid = value; penGrid = new Pen(_colorGrid); }
            get { return _colorGrid; }
        }
        private Color _colorGridMajor = Color.FromArgb(0, 64, 0);
        private Pen penGridMajor;
        public Color colorGridMajor
        {
            set { _colorGridMajor = value; penGridMajor = new Pen(_colorGridMajor); }
            get { return _colorGridMajor; }
        }
        private Color _colorText = Color.White;
        private Brush brushText;
        public Color colorText
        {
            set { _colorText = value; brushText = new SolidBrush(_colorText); }
            get { return _colorText; }
        }

        private Font _fontText = new Font(FontFamily.GenericSansSerif, (float)8);
        public Font fontText
        {
            set { _fontText = value; }
            get { return _fontText; }
        }

        public Plot(GridCalculator _xAxis, GridCalculator _yAxis)
        {
            xAxis = _xAxis;
            yAxis = _yAxis;
            traces = new List<PlotTrace>();

            brushBack = new SolidBrush(_colorBack);
            penFrame = new Pen(_colorFrame);
            penGrid = new Pen(_colorGrid);
            penGridMajor = new Pen(_colorGridMajor);
            brushText = new SolidBrush(_colorText);
        }

        public void clear()
        {
            traces.Clear();
        }

        public void addTrace(PlotTrace p)
        {
            if (p == null) return;
            traces.Add(p);
        }

        public void addTrace(PlotTrace[] p)
        {
            if (p == null) return;
            for (int i=0;i<p.Length;i++)
                traces.Add(p[i]);
        }

        private double min2(double a, double b) { return (a < b) ? a : b; }
        private double max2(double a, double b) { return (a > b) ? a : b; }

        public RectangleF getFrame()
        {
            double xmin, xmax;
            double ymin, ymax;

            xmin = min2(xAxis.low, xAxis.high);
            xmax = max2(xAxis.low, xAxis.high);

            ymin = min2(yAxis.low, yAxis.high);
            ymax = max2(yAxis.low, yAxis.high);

            return new RectangleF((float)xmin, (float)ymin, (float)(xmax - xmin), (float)(ymax - ymin));
        }

        public void draw(Graphics g)
        {
            RectangleF rf = getFrame();
            g.FillRectangle(brushBack, rf);
            g.DrawRectangle(penFrame, rf.Left-1, rf.Top-1, rf.Width+2, rf.Height+2);

            for (int i=0;i<xAxis.gridLength;i++)
            {
                double pos = xAxis.grid[i].screen;
                g.DrawLine((xAxis.grid[i].isMajor) ? penGridMajor : penGrid,
                    (float)pos, rf.Top, (float)pos, rf.Bottom);
                if (xAxis.grid[i].show)
                    GraphicsUtil.drawText(g, Vector.V(pos, rf.Bottom + 3), _fontText, 1, xAxis.grid[i].name, 0, 0, 0, 1, Vector.X, brushText);
            }

            for (int i = 0; i < yAxis.gridLength; i++)
            {
                double pos = yAxis.grid[i].screen;
                g.DrawLine((yAxis.grid[i].isMajor) ? penGridMajor : penGrid,
                    rf.Left,(float)pos, rf.Right, (float)pos);
                if (yAxis.grid[i].show)
                    GraphicsUtil.drawText(g, Vector.V(rf.Left-3, pos), _fontText, 1, yAxis.grid[i].name, 1,0, 1, 0, Vector.X, brushText);
            }

            if (traces.Count > 0) {
                Region oldClip = g.Clip;
                g.Clip = new Region(rf);

                foreach (PlotTrace pt in traces)
                    pt.draw(g, this);

                g.Clip = oldClip;
            }

        }


    }
}
