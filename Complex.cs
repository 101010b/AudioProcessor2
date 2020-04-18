using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor
{
    public struct Complex
    {
        public double R;
        public double I;

        public Complex(double _R, double _I)
        {
            R = _R;
            I = _I;
        }

        public Complex(double _R)
        {
            R = _R;
            I = 0;
        }

        public Complex(Complex src)
        {
            R = src.R;
            I = src.I;
        }

        public void set(double _R, double _I)
        {
            R = _R;
            I = _I;
        }

        public double abs { get { return Math.Sqrt(R * R + I * I); } }

        public double phi { get
            {
                if ((R == 0) && (I == 0))
                    return 0;
                return Math.Atan2(I, R);
            }
        }


        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.R + b.R, a.I + b.I);
        }

        public static Complex operator +(Complex a, double b)
        {
            return new Complex(a.R + b, a.I );
        }

        public static Complex operator +(double a, Complex b)
        {
            return new Complex(a + b.R, b.I);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.R - b.R, a.I - b.I);
        }

        public static Complex operator -(Complex a, double b)
        {
            return new Complex(a.R - b, a.I);
        }

        public static Complex operator -(double a, Complex b)
        {
            return new Complex(a - b.R, -b.I);
        }

        public static Complex operator -(Complex a)
        {
            return new Complex(-a.R, -a.I);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.R * b.R - a.I * b.I, a.R * b.I + a.I * b.R);
        }

        public static Complex operator *(Complex a, double b)
        {
            return new Complex(a.R * b, a.I * b);
        }

        public static Complex operator *(double a, Complex b)
        {
            return new Complex(a * b.R, a * b.I);
        }

        public static Complex operator /(Complex a, Complex b)
        {
            double det = b.R * b.R + b.I * b.I;
            return new Complex((a.R * b.R + a.I * b.I) / det, (-a.R * b.I + a.I * b.R) / det);
        }
        public static Complex operator /(Complex a, double b)
        {
            return new Complex(a.R / b, a.I / b);
        }
        public static Complex operator /(double a, Complex b)
        {
            double det = b.R * b.R + b.I * b.I;
            return new Complex(a * b.R / det, -a * b.I / det);
        }        

        public override string ToString()
        {
            if (I == 0)
                return String.Format("{0}", R);
            if (R == 0)
                return String.Format("{0}i>", I);
            if (I < 0)
                return String.Format("{0}-{1}i>",R,-I);
            else
                return String.Format("{0}+{1}i>",R,I);
        }

        public static Complex exp(Complex i)
        {
            double r = Math.Exp(i.R);
            return new Complex(r * Math.Cos(i.I), r * Math.Sin(i.I));
        }
        public static Complex conj(Complex r)
        {
            return new Complex(r.R, -r.I);
        }

        public static double arg(Complex r)
        {
            return Math.Atan2(r.I, r.R);
        }

    }


}
