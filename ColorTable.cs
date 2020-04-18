using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor
{
    public class ColorTable
    {

        // Internal structure for color management
        private struct dColor
        {
            public double r;
            public double g;
            public double b;
            public void set(double _r, double _g, double _b)
            {
                r = _r;
                g = _g;
                b = _b;
            }
            private int getScaledInt(double a)
            {
                if (a <= 0) return 0;
                if (a >= 1.0) return 255;
                return (int)Math.Floor(a * 255.0 + 0.5);
            }

            public Color get()
            {
                return Color.FromArgb(getScaledInt(r), getScaledInt(g), getScaledInt(b));
            }

            public static dColor operator*(dColor a, double b)
            {
                dColor d;
                d.r = a.r * b;
                d.g = a.g * b;
                d.b = a.b * b;
                return d;
            }

            public static dColor operator *(double b, dColor a)
            {
                dColor d;
                d.r = a.r * b;
                d.g = a.g * b;
                d.b = a.b * b;
                return d;
            }

            public static dColor operator /(dColor a, double b)
            {
                dColor d;
                d.r = a.r / b;
                d.g = a.g / b;
                d.b = a.b / b;
                return d;
            }


            public static dColor operator+(dColor a, dColor b)
            {
                dColor d;
                d.r = a.r + b.r;
                d.g = a.g + b.g;
                d.b = a.b + b.b;
                return d;
            }
        }


        // Data

        public Boolean changed;
        private Color[] COLOR;


        private int _N;
        public int N
        {
            get
            {
                return _N;
            }
            set
            {
                _N = (value<2)?2:value;
                build();
            }
        }

        private String _scheme;
        public String scheme
        {
            get
            {
                return _scheme;
            }
            set
            {
                _scheme = value;
                build();
            }
        }


        // Constructors
        public ColorTable()
        {
            _N = 256;
            _scheme = "RGB";
            build();
        }

        public ColorTable(String __scheme)
        {
            _N = 256;
            _scheme = __scheme;
            build();
        }

        public ColorTable(int __N)
        {
            _N = __N;
            _scheme = "RGB";
            build();
        }

        public ColorTable(int __N, String __scheme)
        {
            _N = __N;
            _scheme = __scheme;
            build();
        }

        private bool getcolor(char c, ref dColor col)
        {
            char U = char.ToUpper(c);
            switch (U)
            {
                default:
                    return false;
                case 'K': col.set(0, 0, 0); break;

                case 'R': col.set(1, 0, 0); break;
                case 'G': col.set(0, 1, 0); break;
                case 'B': col.set(0, 0, 1); break;

                case 'Y': col.set(1, 1, 0); break;
                case 'M': col.set(1, 0, 1); break;
                case 'C': col.set(0, 1, 1); break;

                case 'W': col.set(1, 1, 1); break;

            }

            if (U != c)
                col = col * 0.5;
            return true;
        }

        private bool getspacer(char c, ref double w)
        {
            switch (c)
            {
                default:
                    return false;
                case ' ': w = 0.0; break;
                case '-': w = 1.0; break;
                case '.': w = 0.5; break;
            }
            return true;
        }

        private bool isspacer(char c)
        {
            double w = 0;
            return getspacer(c, ref w);
        }

        private bool iscolor(char c)
        {
            dColor dummy;
            dummy.r = dummy.g = dummy.b = 0.0;
            return getcolor(c, ref dummy);
        }

        public void col(int x, ref byte r, ref byte g, ref byte b)
        {
            if (x <= 0)
            {
                r = COLOR[0].R;
                g = COLOR[0].G;
                b = COLOR[0].B;
                return;
            }
            if (x >= N - 1)
            {
                r = COLOR[N - 1].R;
                g = COLOR[N - 1].G;
                b = COLOR[N - 1].B;
                return;
            }
            r = COLOR[x].R;
            g = COLOR[x].G;
            b = COLOR[x].B;
        }

        public void col(int x, ref int r, ref int g, ref int b)
        {
            if (x <= 0)
            {
                r = COLOR[0].R;
                g = COLOR[0].G;
                b = COLOR[0].B;
                return;
            }
            if (x >= N - 1)
            {
                r = COLOR[N - 1].R;
                g = COLOR[N - 1].G;
                b = COLOR[N - 1].B;
                return;
            }
            r = COLOR[x].R;
            g = COLOR[x].G;
            b = COLOR[x].B;
        }

        public void col(double x, ref byte r, ref byte g, ref byte b)
        {
            if (x <= 0.0)
            {
                r = COLOR[0].R;
                g = COLOR[0].G;
                b = COLOR[0].B;
                return;
            }
            if (x >= 1.0)
            {
                r = COLOR[N - 1].R;
                g = COLOR[N - 1].G;
                b = COLOR[N - 1].B;
                return;
            }
            int X = (int)Math.Floor(x * (N - 1) + 0.5);
            r = COLOR[X].R;
            g = COLOR[X].G;
            b = COLOR[X].B;
        }

        public void col(double x, ref int r, ref int g, ref int b)
        {
            if (x <= 0.0)
            {
                r = COLOR[0].R;
                g = COLOR[0].G;
                b = COLOR[0].B;
                return;
            }
            if (x >= 1.0)
            {
                r = COLOR[N - 1].R;
                g = COLOR[N - 1].G;
                b = COLOR[N - 1].B;
                return;
            }
            int X = (int)Math.Floor(x * (N - 1) + 0.5);
            r = COLOR[X].R;
            g = COLOR[X].G;
            b = COLOR[X].B;
        }

        public Color col(int x)
        {
            if (x < 0) return COLOR[0];
            if (x >= N) return COLOR[N-1];
            return COLOR[x];
        }

        public Color col(double x)
        {
            if (x < 0) return COLOR[0];
            if (x >= 1.0) return COLOR[N - 1];
            int X = (int)Math.Floor(x * (N-1) + 0.5);
            return COLOR[X];
        }

        private void reset()
        {
            if (_N <= 0) return;

            if ((COLOR == null) || (COLOR.Length != _N))
                COLOR = new Color[_N];

            for (int i = 0; i < _N; i++)
                COLOR[i] = Color.FromArgb(0);
        }

        private void reset(char c)
        {
            if (_N <= 0) return;

            if ((COLOR == null) || (COLOR.Length != _N))
                COLOR = new Color[_N];

            dColor d;
            d.r = d.g = d.b = 0;
            if (!getcolor(c,ref d))
                d.set(1, 0, 0);

            for (int i = 0; i < N; i++)
                COLOR[i] = d.get();

        }



        private void build()
        {
            changed = true;

            if ((COLOR == null) || (COLOR.Length != _N))
                COLOR = new Color[_N];

            String s = _scheme;

            while (s.Length > 0 && isspacer(s[0]))
                s = s.Substring(1);
            while (s.Length > 0 && isspacer(s[s.Length - 1]))
                s = s.Substring(0, s.Length - 1);

            int M = s.Length;
            if (M <= 0)
            {
                // Bad
                reset('R');
                return;
            }

            int clrs = 0;
            int sprs = 0;

            // Check chain
            for (int i = 0; i < M; i++)
            {
                if (iscolor(s[i]))
                    clrs++;
                else if (isspacer(s[i]))
                    sprs++;
                else {
                    // Bad
                    build();
                    return;
                }
            }

            // Less than two colors?
            if (clrs < 2)
            {
                for (int i = 0; i < M; i++)
                    if (iscolor(s[i]))
                    {
                        reset(s[i]);
                        return;
                    }
            }

            double[] rx = new double[clrs];
            dColor[] cd = new dColor[clrs];

            int idx = 0;
            double ofs = 0;
            for (int i = 0; i < M; i++)
            {
                double w = 0;
                dColor d;
                d.r = d.g = d.b = 0.0;

                if (getspacer(s[i], ref w))
                {
                    ofs += w;
                }
                else if (getcolor(s[i], ref d))
                {
                    rx[idx] = ofs;
                    cd[idx] = d;
                    ofs += 1.0;
                    idx++;
                }
            }

            for (int i = 0; i < clrs; i++)
            {
                rx[i] = rx[i] / rx[clrs - 1];
            }

            buildTable(clrs, rx, cd);
        }

        private dColor interpolate(dColor c1, double f1, dColor c2, double f2)
        {
            dColor d;
            d.r = c1.r * f1 + c2.r * f2;
            d.g = c1.g * f1 + c2.g * f2;
            d.b = c1.b * f1 + c2.b * f2;
            return d;
        }

        private void buildTable(int M, double[] rx, dColor[] cd)
        {
            // Special Cases
            if (M < 1)
            {
                for (int i = 0; i < N; i++)
                    COLOR[i] = Color.FromArgb(0);
                return;
            }
            if (M == 1)
            {
                Color d;
                d = cd[0].get();
                for (int i = 0; i < N; i++)
                    COLOR[i] = d;
                return;
            }

            // Sort
            for (int i = 0; i < M - 1; i++)
                for (int j = i + 1; j < M; j++)
                {
                    if (rx[j] < rx[i])
                    {
                        double t;
                        dColor tc;
                        t = rx[i]; rx[i] = rx[j]; rx[j] = t;
                        tc = cd[i];cd[i] = cd[j];cd[j] = tc;
                    }
                }

            // Build it
            for (int i = 0; i < N; i++)
            {
                double x = (double)i / ((double)N - 1.0);
                int left, right;
                if (x <= rx[0])
                    COLOR[i] = cd[0].get();
                else if (x >= rx[M - 1])
                    COLOR[i] = cd[M - 1].get();
                else
                {
                    right = 1;
                    while (rx[right] < x) right++;
                    left = right - 1;
                    double f2 = (x - rx[left]) / (rx[right] - rx[left]);
                    double f1 = 1.0 - f2;
                    COLOR[i] = (cd[left] * f1 + cd[right] * f2).get();
                }
            }

        }


    }
}
