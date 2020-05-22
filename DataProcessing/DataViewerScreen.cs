using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioProcessor.DataProcessing
{
    public partial class DataViewerScreen : Control
    {

        DataViewerWin root;

        private Color _backColor = Color.Black;
        private Brush backBrush = new SolidBrush(Color.Black);
        public Color backColor
        {
            set { _backColor = value; backBrush = new SolidBrush(value); Invalidate(); }
            get { return _backColor; }
        }

        private Color _frameColor = Color.White;
        private Pen framePen = new Pen(Color.White);
        public Color frameColor
        {
            set { _frameColor = value; framePen = new Pen(value); Invalidate(); }
            get { return _frameColor; }
        }

        private Color _gridColor = Color.FromArgb(0,32,0);
        private Pen gridPen = new Pen(Color.FromArgb(0, 32, 0));
        public Color gridColor
        {
            set { _gridColor = value; gridPen = new Pen(value); Invalidate(); }
            get { return _gridColor; }
        }

        private Color _majorGridColor = Color.FromArgb(0,64,0);
        private Pen majorGridPen = new Pen(Color.FromArgb(0, 64, 0));
        public Color majorGridColor
        {
            set { _majorGridColor = value; majorGridPen = new Pen(value); Invalidate(); }
            get { return _majorGridColor; }
        }

        private Font _gridFont = new Font(FontFamily.GenericSansSerif, 8);
        public Font gridFont
        {
            set { _gridFont = value; Invalidate(); }
            get { return _gridFont; }
        }

        private Color _gridFontColor = Color.DimGray;
        private Brush gridFontBrush = new SolidBrush(Color.DimGray);
        public Color gridFontColor
        {
            set { _gridFontColor = value; gridFontBrush = new SolidBrush(value); Invalidate(); }
            get { return _gridFontColor; }
        }

        private GridCalculator xAxis;
        private GridCalculator yAxis;
        private DataTrace[] traces;

        private int _traceLength;
        public int traceLength
        {
            get { return _traceLength; }
        }

        private double _traceTime;
        public double traceTime
        {
            get { return _traceTime; }
        }

        private class DataTrace
        {
            double[] data;
            int write;
            int contains;
            DataViewerScreen root;
            PointF[] pts;
            Pen p;
            bool on;

            public double tracemin, tracemax;
            int minidx, maxidx;

            public DataTrace(DataViewerScreen _root, int len)
            {
                data = new double[len];
                write = contains = 0;
                root = _root;
                p = new Pen(Color.DimGray);
                on = true;
                tracemin = -1;
                tracemax = 1;
                minidx = maxidx = -1;
            }

            public void getminmax()
            {
                int idx = write;
                minidx = maxidx = -1;
                tracemin = -1;
                tracemax = 1;
                int ctx = contains;
                while (ctx > 0)
                {
                    idx = (data.Length + idx - 1) % data.Length;
                    if (!Double.IsNaN(data[idx]))
                    {
                        if ((minidx == -1) || (data[idx] < tracemin))
                        {
                            minidx = idx;
                            tracemin = data[idx];
                        }
                        if ((maxidx == -1) || (data[idx] > tracemax))
                        {
                            maxidx = idx;
                            tracemax = data[idx];
                        }
                    }
                    ctx--;
                }
            }

            public void updateLen(int newlen)
            {
                if (data.Length == newlen+1) return;
                double[] newdata = new double[newlen];
                int newwrite = newlen - 1;
                int read = (write + data.Length - 1) % data.Length;
                int maxcopy = contains;
                while ((newwrite >= 0) && (maxcopy > 0))
                {
                    newdata[newwrite] = data[read];
                    newwrite--;
                    read = (read + data.Length - 1) % data.Length;
                    maxcopy--;
                }
                data = newdata;
                write = 0;
                if (contains > newlen)
                    contains = newlen;
                getminmax();
            }

            public void addData(int steps, double d)
            {
                while (steps > 1)
                {
                    data[write] = Double.NaN;
                    if (contains < data.Length)
                        contains++;
                    if ((write == minidx)||(write==maxidx))
                    {
                        write = (write + 1) % data.Length;
                        getminmax();
                    }
                    else
                        write = (write + 1) % data.Length;

                    steps--;
                }
                if (steps > 0)
                {
                    data[write] = d;
                    if (contains < data.Length)
                        contains++;

                    if ((write == minidx) || (write == maxidx))
                    {
                        // do new search
                        write = (write + 1) % data.Length;
                        getminmax();
                    } else
                    {
                        if (minidx == -1)
                        {
                            minidx = write;
                            tracemin = d;
                        }
                        if (maxidx == -1)
                        {
                            maxidx = write;
                            tracemax = d;
                        }
                        if (d < tracemin)
                        {
                            tracemin = d;
                            minidx = write;
                        }
                        if (d > tracemax)
                        {
                            tracemax = d;
                            maxidx = write;
                        }
                        write = (write + 1) % data.Length;
                    }
                    steps--;
                }
            }

            public void plot(Graphics g, GridCalculator XAxis, GridCalculator YAxis)
            {
                if (!on) return;
                if ((pts == null) || (pts.Length != data.Length))
                    pts = new PointF[data.Length];
                if (contains == 0)
                    return;

                int i = 0;
                int pnum = 0;
                while (i < contains)
                {
                    double ydata = data[(write + data.Length - 1 - i) % data.Length];
                    if (!Double.IsNaN(ydata))
                    {
                        pts[pnum].X = (float)XAxis.getInterpolatedPos((double)i / data.Length * root.traceTime);
                        pts[pnum].Y = (float)YAxis.getInterpolatedPos(ydata);
                        pnum++;
                    }
                    i++;
                }
                for (int j = 0; j < pnum - 1; j++)
                    g.DrawLine(p, pts[j], pts[j + 1]);
            }

            public void setColor(Color col, bool _on)
            {
                p.Color = col;
                on = _on;
            }
            
        }

        public void updateTraceNumber(int tracenum)
        {
            if (tracenum <= 0)
            {
                traces = null;
                return;
            }
            if ((traces == null) || (tracenum != traces.Length))
            {
                DataTrace[] newtraces = new DataTrace[tracenum];
                int i = 0;
                while ((i < tracenum) && (traces != null) && (i < traces.Length))
                {
                    newtraces[i] = traces[i];
                    i++;
                }
                while (i < tracenum)
                {
                    newtraces[i] = new DataTrace(this, _traceLength);
                    i++;
                }
                traces = newtraces;
            }
        }

        public void updateTraceTime(int __tracelength, double __tracetime)
        {
            if (_traceLength != __tracelength)
            {
                if (traces != null)
                    for (int i = 0; i < traces.Length; i++)
                        traces[i].updateLen(__tracelength);
                xAxis.newRange(0, __tracetime);
                _traceLength = __tracelength;
                _traceTime = __tracetime;
            }
        }

        public void addTraceData(int trace, int steps, double d)
        {
            if (trace < 0) return;
            if (traces == null) return;
            if (trace >= traces.Length) return;
            traces[trace].addData(steps,d);
        }

        public void updateTraceColor(int trace, Color col, bool on)
        {
            if (trace < 0) return;
            if (traces == null) return;
            if (trace >= traces.Length) return;
            traces[trace].setColor(col,on);
        }

        public void updateYRange(double ymin, double ymax, bool isLog, bool isAutoScale)
        {
            if (isAutoScale)
            {
                autoscale = true;
                if (isLog)
                    yAxis.logScale = true;
                else
                    yAxis.logScale = false;
            } else
            {
                autoscale = false;
                if (isLog)
                {
                    if (ymin <= 0) ymin = 1e-12;
                    if (ymax <= ymin) ymax = ymin * 100;
                    yAxis.newRange(ymin, ymax);
                    yAxis.logScale = true;
                } else
                {
                    yAxis.logScale = false;
                    yAxis.newRange(ymin, ymax);
                }
            }
        }

        private int designW, designH;
        bool autoscale;

        public DataViewerScreen()
        {
            DoubleBuffered = true;
            designW = Width;
            designH = Height;
            _traceLength = 100;
            _traceTime = 10;
            xAxis = new GridCalculator(0, 100, 0.01, 0.1, 1, 0, _traceTime, false, 50, Width - 10, 30);
            yAxis = new GridCalculator(-100, 100, 1e-6, 1e-20, 2, -1, 1, false, Height - 20, 5, 10);
            autoscale = false;
        }

        private void drawTo(Graphics g)
        {
            Rectangle r = new Rectangle(0, 0, Width-1, Height-1);

            if ((designW != Width) || (designH != Height))
            {
                // ReGrid
                xAxis.reScreen(50, Width - 10);
                yAxis.reScreen(Height - 20, 5);
                designW = Width;
                designH = Height;
            }

            if (autoscale && (traces != null) && (traces.Length > 0))
            {
                double amin, amax;
                amin = traces[0].tracemin;
                amax = traces[0].tracemax;
                for (int i=1;i<traces.Length;i++)
                {
                    if (traces[i].tracemin < amin)
                        amin = traces[i].tracemin;
                    if (traces[i].tracemax > amax)
                        amax = traces[i].tracemax;
                }
                if (yAxis.logScale)
                {
                    if (amin < 1e-12)
                        amin = 1e-12;
                    if (amax <= amin)
                        amax = amin * 2;
                }
                yAxis.newRange(amin, amax);
            }

            Rectangle rdis = new Rectangle((int)xAxis.low, (int)yAxis.high, (int)(xAxis.high - xAxis.low), (int)(yAxis.low - yAxis.high));
            Rectangle rframe = new Rectangle(rdis.Left - 1, rdis.Top - 1, rdis.Width + 2, rdis.Height + 2);
            g.DrawRectangle(framePen, rframe);
            for (int i = 0;i<xAxis.gridLength;i++)
            {
                float xpos = (float)xAxis.grid[i].screen;
                if (xAxis.grid[i].isMajor)
                    g.DrawLine(majorGridPen, xpos, rdis.Top, xpos, rdis.Bottom);
                else
                    g.DrawLine(gridPen, xpos, rdis.Top, xpos, rdis.Bottom);
                if (xAxis.grid[i].show)
                    GraphicsUtil.drawText(g, Vector.V(xpos, rdis.Bottom), gridFont, 1, xAxis.grid[i].name, 0, 2, 0, 1, Vector.X, gridFontBrush);
            }
            for (int i = 0; i < yAxis.gridLength; i++)
            {
                float ypos = (float)yAxis.grid[i].screen;
                if (yAxis.grid[i].isMajor)
                    g.DrawLine(majorGridPen, rdis.Left, ypos, rdis.Right, ypos);
                else
                    g.DrawLine(gridPen, rdis.Left, ypos, rdis.Right, ypos);
                if (yAxis.grid[i].show)
                    GraphicsUtil.drawText(g, Vector.V(rdis.Left, ypos), gridFont, 1, yAxis.grid[i].name, 0, 2, 1, 0, Vector.X, gridFontBrush);
            }
            if (traces != null)
            {
                g.SetClip(rdis);
                for (int i = 0; i < traces.Length; i++)
                    traces[i].plot(g, xAxis, yAxis);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            drawTo(pe.Graphics);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

    }
}
