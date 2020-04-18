using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor
{
    public struct VectorRect
    {
        public Vector LL;
        public Vector UR;

        public VectorRect(Vector _LL, Vector _UR)
        {
            LL = _LL;
            UR = _UR;
            if (LL.x > UR.x)
            {
                double t = LL.x;
                LL.x = UR.x;
                UR.x = t;
            }
            if (LL.y > UR.y)
            {
                double t = LL.y;
                LL.y = UR.y;
                UR.y = t;
            }
        }

        public double area
        {
            get { return Math.Abs((UR.x - LL.x) * (UR.y - LL.y)); }
        }

        public bool isZero
        {
            get { return (LL == UR); }
        }

        public bool nonZero
        {
            get { return (LL != UR); }
        }

        public bool inside(Vector H)
        {
            if ((H.x >= LL.x) && (H.x <= UR.x) && (H.y >= LL.y) && (H.y <= UR.y))
                return true;
            return false;
        }

        public static bool operator ==(VectorRect A, VectorRect B)
        {
            return (A.LL == B.LL) && (A.UR == B.UR);
        }

        public static bool operator !=(VectorRect A, VectorRect B)
        {
            return (A.LL != B.LL) || (A.UR != B.UR);
        }

        public static VectorRect FromTwoPoints(Vector X, Vector Y)
        {
            return new VectorRect(X, Y);
        }

        public static VectorRect FromTwoPoints(double x1, double y1, double x2, double y2)
        {
            return new VectorRect(new Vector(x1,y1), new Vector (x2,y2));
        }

        public static VectorRect FromPointSize(Vector A, Vector size)
        {
            return new VectorRect(A, A + size);
        }

        public static VectorRect FromCenterSize(Vector A, Vector size)
        {
            return new VectorRect(A - size / 2, A + size / 2);
        }

        public static readonly VectorRect Empty = new VectorRect(Vector.Zero, Vector.Zero);

        public Rectangle rectangle
        {
            get { return new Rectangle(LL.Point, (UR - LL).Size); }
        }

        public RectangleF rectangleF
        {
            get { return new RectangleF(LL.PointF, (UR - LL).SizeF); }
        }

        public void inflate(Vector dim)
        {
            LL -= dim;
            UR += dim;
        }

        public void inflate(double dx, double dy)
        {
            LL.x -= dx;
            LL.y -= dy;
            UR.x += dx;
            UR.y += dy;
        }

        public void inflate(double d)
        {
            LL.x -= d;
            LL.y -= d;
            UR.x += d;
            UR.y += d;
        }

        public VectorLine LineBelow(double distance)
        {
            return new VectorLine(LL - distance * Vector.Y, LL - distance * Vector.Y + Vector.X, VectorLine.LineType.Infinite);
        }

        public VectorLine LineAbove(double distance)
        {
            return new VectorLine(UR + distance * Vector.Y, UR + distance * Vector.Y + Vector.X, VectorLine.LineType.Infinite);
        }

        public VectorLine LineLeft(double distance)
        {
            return new VectorLine(LL - distance * Vector.X, LL - distance * Vector.X + Vector.Y, VectorLine.LineType.Infinite);
        }

        public VectorLine LineRight(double distance)
        {
            return new VectorLine(UR + distance * Vector.X, UR + distance * Vector.X + Vector.Y, VectorLine.LineType.Infinite);
        }

        public bool Intersects(VectorLine v)
        {
            VectorLine L;
            Vector hp = Vector.Zero;
            L = new VectorLine(LL, Vector.V(UR.x, LL.y), VectorLine.LineType.AB);
            if (VectorLine.intersect(v,L, ref hp)) return true;
            L = new VectorLine(Vector.V(UR.x, LL.y),UR, VectorLine.LineType.AB);
            if (VectorLine.intersect(v, L, ref hp)) return true;
            L = new VectorLine(UR, Vector.V(LL.x, UR.y), VectorLine.LineType.AB);
            if (VectorLine.intersect(v, L, ref hp)) return true;
            L = new VectorLine(Vector.V(LL.x, UR.y),LL, VectorLine.LineType.AB);
            if (VectorLine.intersect(v, L, ref hp)) return true;
            //if ((v.A.x >= LL.x) && (v.A.x <= UR.x) && (v.A.y >= LL.y) && (v.A.y <= UR.y)) return true;
            return false;
        }

        public bool inside(VectorRect r)
        {
            return inside(r.LL) && inside(r.UR);
        }

    }
}
