using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;


namespace AudioProcessor
{
    public struct Vector
    {
        public double x;
        public double y;

        public Vector(double _x, double _y)
        {
            x = _x;
            y = _y;
        }

        public Vector(Point p)
        {
            x = p.X;
            y = p.Y;
        }

        public Vector(PointF p)
        {
            x = p.X;
            y = p.Y;
        }

        public Vector(Rectangle r)
        {
            x = r.Left + r.Width / 2;
            y = r.Top + r.Height / 2;
        }

        public Vector(RectangleF r)
        {
            x = r.Left + r.Width / 2;
            y = r.Top + r.Height / 2;
        }

        public Vector(Size s)
        {
            x = s.Width;
            y = s.Height;
        }

        public Vector(Vector src)
        {
            x = src.x;
            y = src.y;
        }

        public Vector(BinaryReader src)
        {
            x = src.ReadDouble();
            y = src.ReadDouble();
        }

        public void writeBinary(BinaryWriter tgt)
        {
            tgt.Write(x);
            tgt.Write(y);
        }

        public void set(double _x, double _y)
        {
            x = _x;
            y = _y;
        }

        public double Len {  get {  return Math.Sqrt(x * x + y * y); } }

        public double Phi { get
            {
                if ((x == 0.0) && (y == 0.0))
                    return 0.0;
                return Math.Atan2(y, x);
            }
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y);
        }

        public static Vector operator -(Vector a)
        {
            return new Vector(-a.x, -a.y);
        }

        public static Vector operator *(Vector a, double b)
        {
            return new Vector(a.x * b, a.y * b);
        }

        public static Vector operator /(Vector a, double b)
        {
            if (b == 0.0)
                throw new DivideByZeroException();
            return new Vector(a.x / b, a.y / b);
        }


        public static Vector operator *(double a, Vector b)
        {
            return new Vector(a * b.x, a * b.y);
        }

        public static double operator *(Vector a, Vector b)
        {
            return a.x * b.x + a.y * b.y;
        }

        public static double operator ^(Vector a, Vector b)
        {
            return a.x * b.y - a.y * b.x;
        }

        public static bool operator ==(Vector a, Vector b)
        {
            return (a.x == b.x) && (a.y == b.y);
        }

        public static bool operator !=(Vector a, Vector b)
        {
            return (a.x != b.x) || (a.y != b.y);
        }

        public override string ToString()
        {
            return String.Format("<{0},{1}>", x, y);
        }

        public Vector Vert { get { return new Vector(0, y); } }
        public Vector Horz { get { return new Vector(x, 0); } }

        public bool isZero { get { return (x == 0) && (y == 0); } }
        public bool nonZero { get { return (x != 0) || (y != 0); } }

        public Vector xToHorz()
        {
            return new Vector(x, 0);
        }

        public Vector xToVert()
        {
            return new Vector(0, x);
        }

        public Point Point { get { return new Point((int)Math.Round(x), (int)Math.Round(y)); } }
        public Size Size { get { return new Size((int)Math.Round(x), (int)Math.Round(y)); } }
        public PointF PointF {  get { return new PointF((float)x, (float)y); } }
        public SizeF SizeF { get { return new SizeF((float)x, (float)y); } }

        public Vector rot(double phi)
        {
            double xn = Math.Cos(phi) * x - Math.Sin(phi) * y;
            double yn = Math.Sin(phi) * x + Math.Cos(phi) * y;
            x = xn;
            y = yn;
            return this;
        }

        public Vector rot90()
        {
            double t = y;
            y = x;
            x = -t;
            return this;
        }

        public Vector rot270()
        {
            double t = y;
            y = -x;
            x = t;
            return this;
        }

        public Vector vrot(double phi)
        {
            double xn = Math.Cos(phi) * x - Math.Sin(phi) * y;
            double yn = Math.Sin(phi) * x + Math.Cos(phi) * y;
            return new Vector(xn, yn);
        }

        public Vector vrot90()
        {
            return new Vector(-y, x);
        }

        public Vector vrot270()
        {
            return new Vector(y, -x);
        }


        public void round()
        {
            x = Math.Floor(x + 0.5);
            y = Math.Floor(y + 0.5);
        }

        public void round(double scaler)
        {
            x = Math.Floor(x/scaler + 0.5)*scaler;
            y = Math.Floor(y/scaler + 0.5)*scaler;
        }

        public Vector norm
        {
            get
            {
                double l = Len;
                if (l != 0)
                    return new Vector(x / l, y / l);
                return Vector.Zero;
            }
        }

        // Statics

        public static Vector V()
        {
            return new Vector(0, 0);
        }

        public static Vector V(double x, double y)
        {
            return new Vector(x, y);
        }

        public static Vector V(Point p)
        {
            return new Vector(p);
        }

        public static Vector V(PointF p)
        {
            return new Vector(p);
        }

        public static Vector V(Rectangle r)
        {
            return new Vector(r);
        }

        public static Vector V(RectangleF r)
        {
            return new Vector(r);
        }

        public static Vector V(Size s)
        {
            return new Vector(s);
        }


        public static Rectangle R(Vector pos, Vector size)
        {
            return new Rectangle(pos.Point, size.Size);
        }

        public static RectangleF RF(Vector pos, Vector size)
        {
            return new RectangleF(pos.PointF, size.SizeF);
        }

        public static RectangleF RFC(Vector pos, Vector size)
        {
            Vector topLeft = pos - size / 2;
            return new RectangleF(topLeft.PointF, size.SizeF);
        }

        public static Rectangle Rxy(Vector pos1, Vector pos2)
        {
            int x1, y1, x2, y2;
            x1 = (int)Math.Round(pos1.x);
            y1 = (int)Math.Round(pos1.y);
            x2 = (int)Math.Round(pos2.x);
            y2 = (int)Math.Round(pos2.y);
            if (x1 > x2)
            {
                int temp = x1; x1 = x2; x2 = temp;
            }
            if (y1 > y2)
            {
                int temp = y1; y1 = y2; y2 = temp;
            }
            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        public static RectangleF RFxy(Vector pos1, Vector pos2)
        {
            float x1, y1, x2, y2;
            x1 = (float)pos1.x;
            y1 = (float)pos1.y;
            x2 = (float)pos2.x;
            y2 = (float)pos2.y;
            if (x1 > x2)
            {
                float temp = x1; x1 = x2; x2 = temp;
            }
            if (y1 > y2)
            {
                float temp = y1; y1 = y2; y2 = temp;
            }
            return new RectangleF(x1, y1, x2 - x1, y2 - y1);
        }

        private static double min2(double a, double b)
        {
            return (a < b) ? a : b;
        }

        private static double min3(double a, double b, double c)
        {
            if ((a < b) && (a < c)) return a;
            if ((b < a) && (b < c)) return b;
            return c;
        }

        public static double lineDist(Vector A, Vector B, Vector P)
        {
            double da = (A - P).Len;
            double db = (B - P).Len;
            double dc = Math.Abs(((P-A) ^ (B - A)) / (B - A).Len);
            double h = (P - A) * (B - A) / (B - A).Len;
            if ((h >= 0) && (h <= (B - A).Len))
                return min3(da, db, dc);
            else
                return min2(da, db);
        }

        public static Vector toGrid(Vector i, double grid)
        {
            return new Vector(Math.Floor(i.x/grid + 0.5)*grid, Math.Floor(i.y / grid + 0.5) * grid);            
        }

        public static readonly Vector X = new Vector(1, 0);
        public static readonly Vector Y = new Vector(0, 1);
        public static readonly Vector Null = new Vector(0, 0);
        public static readonly Vector Zero = new Vector(0, 0);
        public static readonly Vector One = new Vector(1, 1);

        public static Vector max(Vector a, Vector b)
        {
            return new Vector((a.x > b.x) ? a.x : b.x, (a.y > b.y) ? a.y : b.y);
        }

        public static Vector min(Vector a, Vector b)
        {
            return new Vector((a.x < b.x) ? a.x : b.x, (a.y < b.y) ? a.y : b.y);
        }

        public static Vector max(Vector a, Vector b, Vector c)
        {
            return max(a, max(b, c));
        }

        public static Vector min(Vector a, Vector b, Vector c)
        {
            return min(a, min(b, c));
        }

        public static Vector diag(double v)
        {
            return new Vector(v, v);
        }

    }
}
