using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace AudioProcessor
{
    public class PlotTrace
    {
        private int points;
        private double[] x;
        private double[] y;

        private PointF[] pts;

        public DrawColor color;


        public PlotTrace()
        {
            x = null;
            y = null;
            points = 0;
            color = new DrawColor(Color.Red, 2.0);
        }

        public void clear()
        {
            points = 0;
        }

        public void add(double _x, double _y)
        {
            if (x == null) x = new double[32];
            if (y == null) y = new double[32];
            if (points >= x.Length)
            {
                // reallocate
                double[] xext = new double[x.Length + 32];
                double[] yext = new double[y.Length + 32];
                Array.Copy(x, xext, x.Length);
                Array.Copy(y, yext, y.Length);
                x = xext;
                y = yext;
            }
            x[points] = _x;
            y[points] = _y;
            points++;
        }

        public void add(double[] _x, double[] _y, int start, int len)
        {
            if (x == null) x = new double[len + 32];
            if (y == null) y = new double[len + 32];
            if (points + len > x.Length)
            {
                // reallocate
                double[] xext = new double[x.Length + len + 32];
                double[] yext = new double[y.Length + len + 32];
                Array.Copy(x, xext, x.Length);
                Array.Copy(y, yext, y.Length);
                x = xext;
                y = yext;
            }
            Array.Copy(_x, start, x, points, len);
            Array.Copy(_y, start, y, points, len);
            points += len;
        }

        public void add(double[] _x, double[] _y, int len)
        {
            add(_x, _y, 0, len);
        }

        public void add(double[] _x, double[] _y)
        {
            add(_x, _y, 0, _x.Length);
        }

        public void draw(Graphics g, Plot p)
        {
            if (points <= 1) return;
            if ((pts == null) || (pts.Length != points))
                pts = new PointF[points];
            for (int i = 0; i < points; i++)
            {
                double _x = p.xAxis.getInterpolatedPos(x[i]);
                double _y = p.yAxis.getInterpolatedPos(y[i]);
                pts[i].X = (float)_x;
                pts[i].Y = (float)_y;
            }
            g.DrawLines(color.pen, pts);
        }

        public double[] getXData()
        {
            double[] d = new double[points];
            Array.Copy(x, d, points);
            return d;
        }

        public double[] getYData()
        {
            double[] d = new double[points];
            Array.Copy(y, d, points);
            return d;
        }


    }
}
