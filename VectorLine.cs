using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor
{
    public struct VectorLine
    {
        public enum LineType
        {
            Infinite=0,
            AInf,
            InfB,
            AB,
            InfABInf
        }

        public Vector A;
        public Vector B;
        public LineType lt;

        public VectorLine(Vector _A, Vector _B, LineType _lt)
        {
            A = _A;
            B = _B;
            lt = _lt;
        }

        public VectorLine(Vector _A, Vector _B)
        {
            A = _A;
            B = _B;
            lt = LineType.Infinite;
        }

        public bool isLine
        {
            get { return A != B; }
        }

        public bool isOnLine(double fraction)
        {
            switch (lt)
            {
                case LineType.Infinite: return true;
                case LineType.AB: return (fraction >= 0) && (fraction <= 1);
                case LineType.AInf: return (fraction >= 0);
                case LineType.InfB: return (fraction <= 1);
                case LineType.InfABInf: return (fraction <= 0) || (fraction >= 1);
            }
            return false;
        }

        public static bool intersect(VectorLine U, VectorLine V, ref Vector ip)
        {
            if (!U.isLine || !V.isLine) return false;

            Matrix2x2 M = new Matrix2x2(V.B - V.A, U.A - U.B);
            Vector Q = U.A - V.A;
            double det = M.det;
            if (det == 0)
                return false; // parallel or overlapping
            Vector st = Matrix2x2.inv(M) * Q;
            if (U.isOnLine(st.y) && V.isOnLine(st.x))
            {
                ip = U.A + (U.B - U.A) * st.y;
                return true;
            }
            return false;
        }

        public void draw(Graphics g, Pen p)
        {
            if (!isLine) return;
            switch(lt)
            {
                case LineType.AB:
                    g.DrawLine(p, A.Point, B.Point);
                    return;
                case LineType.AInf:
                    g.DrawLine(p, A.Point, (A + 3000 * (B - A).norm).Point);
                    return;
                case LineType.InfB:
                    g.DrawLine(p, B.Point, (B - 3000 * (B - A).norm).Point);
                    return;
                case LineType.Infinite:
                    g.DrawLine(p, (A - 3000 * (B - A).norm).Point, (A + 3000 * (B - A).norm).Point);
                    return;
                case LineType.InfABInf:
                    g.DrawLine(p, (A - 3000 * (B - A).norm).Point, A.Point);
                    g.DrawLine(p, B.Point, (B + 3000 * (B - A).norm).Point);
                    return;
            }
        }


    }
}
