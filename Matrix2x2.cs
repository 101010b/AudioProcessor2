using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor
{
    public struct Matrix2x2
    {
        double a11, a12;
        double a21, a22;

        public Matrix2x2(double _a11, double _a12, double _a21, double _a22)
        {
            a11 = _a11;
            a12 = _a12;
            a21 = _a21;
            a22 = _a22;
        }

        public Matrix2x2(Matrix2x2 m)
        {
            a11 = m.a11;
            a12 = m.a12;
            a21 = m.a21;
            a22 = m.a22;
        }

        public Matrix2x2(Vector U, Vector V)
        {
            a11 = U.x;a12 = V.x;
            a21 = U.y;a22 = V.y;
        }

        public static readonly Matrix2x2 Zero = new Matrix2x2(0, 0, 0, 0);
        public static readonly Matrix2x2 Unity = new Matrix2x2(1, 0, 0, 1);

        public static Vector operator * (Matrix2x2 m, Vector v)
        {
            return new Vector(m.a11 * v.x + m.a12 * v.y, m.a21 * v.x + m.a22 * v.y);
        }

        public static Matrix2x2 operator *(Matrix2x2 m, double d)
        {
            return new Matrix2x2(m.a11 * d, m.a12 * d, m.a21 * d, m.a22 * d);
        }

        public static Matrix2x2 operator *(double d, Matrix2x2 m)
        {
            return new Matrix2x2(m.a11 * d, m.a12 * d, m.a21 * d, m.a22 * d);
        }

        public static Matrix2x2 operator /(Matrix2x2 m, double d)
        {
            if (d == 0) throw new Exception("Division by Zero in Matrix2x2.cs at operator /");
            return new Matrix2x2(m.a11 / d, m.a12 / d, m.a21 / d, m.a22 / d);
        }

        public double det
        {
            get { return a11 * a22 - a12 * a21; }            
        }

        public static Matrix2x2 inv(Matrix2x2 m)
        {
            double det = m.det;
            if (det == 0) throw new Exception("Division by Zero in Matrix2x2 Inversion");
            return new Matrix2x2(m.a22 / det, -m.a12 / det, -m.a21 / det, m.a11 / det);
        }

    }
}
