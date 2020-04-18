using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace AudioProcessor
{
    public struct VectorBox
    {
        public Vector pos;
        public Vector X;
        public Vector Y;

        public VectorBox(VectorBox v)
        {
            pos = v.pos;
            X = v.X;
            Y = v.Y;
        }

        public VectorBox(Vector _pos)
        {
            pos = _pos;
            X = Vector.V(1, 0);
            Y = Vector.V(0, 1);
        }

        public VectorBox(Vector _pos, Vector _X)
        {
            pos = _pos;
            X = _X;
            Y = X.vrot90();
        }

        public VectorBox(Vector _pos, Vector _X, Vector _Y)
        {
            pos = _pos;
            X = _X;
            Y = _Y;
        }

        public VectorBox(Vector _pos, double W, double H)
        {
            pos = _pos;
            X = new Vector(W, 0);
            Y = new Vector(0, H);
        }

        public void rot(double phi)
        {
            pos.rot(phi);
            X.rot(phi);
            Y.rot(phi);
        }

        public void tilt(double phi)
        {
            X.rot(phi);
            Y.rot(phi);
        }

        public void translate(Vector shift)
        {
            pos = pos + shift;
        }

        public void scale(double scale)
        {
            pos = pos * scale;
            X = X * scale;
            Y = Y * scale;
        }

        public void rotatearound(Vector ctr, double phi)
        {
            Vector ofs = pos - ctr;
            ofs.rot(phi);
            pos = ctr + ofs;
            X.rot(phi);
            Y.rot(phi);
        }


        private double min2(double a, double b) { return (a < b) ? a : b; }
        private double min4(double a, double b, double c, double d)
        {
            double m1 = min2(a, b);
            double m2 = min2(c, d);
            return (m1 < m2) ? m1 : m2;
        }
        private double max2(double a, double b) { return (a > b) ? a : b; }
        private double max4(double a, double b, double c, double d)
        {
            double m1 = max2(a, b);
            double m2 = max2(c, d);
            return (m1 > m2) ? m1 : m2;
        }

        public VectorBox boundingBox()
        {
            Vector A = pos;
            Vector B = pos + X;
            Vector C = pos + X + Y;
            Vector D = pos + Y;
            double minX = min4(A.x, B.x, C.x, D.x);
            double minY = min4(A.y, B.y, C.y, D.y);
            double maxX = max4(A.x, B.x, C.x, D.x);
            double maxY = max4(A.y, B.y, C.y, D.y);
            VectorBox v = new VectorBox(Vector.V(minX,minY),maxX-minX,maxY-minY);
            return v;
        }

        public RectangleF boundingBoxRF()
        {
            VectorBox v = boundingBox();
            return new RectangleF(v.pos.PointF, (v.X + v.Y).SizeF);
        }

        public Vector boundingDim()
        {
            Vector A = pos;
            Vector B = pos + X;
            Vector C = pos + X + Y;
            Vector D = pos + Y;
            double minX = min4(A.x, B.x, C.x, D.x);
            double minY = min4(A.y, B.y, C.y, D.y);
            double maxX = max4(A.x, B.x, C.x, D.x);
            double maxY = max4(A.y, B.y, C.y, D.y);
            return new Vector(maxX - minX, maxY - minY);
        }


    }
}
