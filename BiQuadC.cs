using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor
{
    class BiQuadC
    {

        double _sampleRate;
        public double sampleRate
        {
            set { _sampleRate = value; reCalc(); }
            get { return _sampleRate; }
        }
        public enum BiQuadMode
        {
            HighPass,
            LowPass,
            BandPass,
            BandStop,
            Allpass
        }
        BiQuadMode _biQuadMode;
        public BiQuadMode biQuadMode
        {
            set { _biQuadMode = value; reCalc(); }
            get { return _biQuadMode; }
        }
        public enum BiQuadOrder
        {
            First,
            Second
        }
        BiQuadOrder _biQuadOrder;
        public BiQuadOrder biQuadOrder
        {
            set { _biQuadOrder = value; reCalc(); }
            get { return _biQuadOrder; }
        }

        double _frequency;
        public double frequency
        {
            set { _frequency = value; reCalc(); }
            get { return _frequency; }
        }
        double _Q;
        public double Q
        {
            set { _Q = value; reCalc(); }
            get { return _Q; }
        }

        // Data
        double a1, a2;
        double b0, b1, b2;

        // TimeData
        Complex x1, x2;
        Complex y1, y2;

        public BiQuadC(double __sampleRate, BiQuadOrder __biQuadOrder, BiQuadMode __biQuadMode, double __frequency, double __Q)
        {
            _sampleRate = __sampleRate;
            _biQuadOrder = __biQuadOrder;
            _biQuadMode = __biQuadMode;
            _frequency = __frequency;
            _Q = __Q;

            x1 = new Complex(0);
            x2 = new Complex(0);
            y1 = new Complex(0);
            y2 = new Complex(0);

            reCalc();
        }
        public BiQuadC(double __sampleRate, BiQuadMode __biQuadMode, double __frequency):
            this(__sampleRate,BiQuadOrder.First,__biQuadMode,__frequency,1.0)
        {
        }

        private void reCalc()
        {
            if (_frequency >= _sampleRate * 0.95)
                _frequency = _sampleRate * 0.95;
            double wc = 2.0 * Math.PI * _frequency / _sampleRate;
            double K = Math.Tan(wc / 2.0);
            double alpha = 1.0 + K;
            double W;
            double DE;
            double g;
            switch (_biQuadOrder)
            {
                case BiQuadOrder.First:
                    a1 = -(1.0 - K) / alpha;
                    a2 = 0;
                    switch (biQuadMode)
                    {
                        case BiQuadMode.LowPass:
                            b0 = K / alpha;
                            b1 = K / alpha;
                            b2 = 0;
                            break;
                        case BiQuadMode.HighPass:
                            b0 = 1.0 / alpha;
                            b1 = -1.0 / alpha;
                            b2 = 0;
                            break;
                        case BiQuadMode.Allpass:
                            g = (K - 1.0) / (K + 1.0);
                            b0 = g;
                            b1 = 1.0;
                            b2 = 0;
                            a1 = g;
                            a2 = 0;
                            break;
                    }
                    break;
                case BiQuadOrder.Second:
                    W = K * K;
                    DE = 1.0 + K / Q + W;
                    a1 = 2.0 * (W - 1.0) / DE;
                    a2 = (1.0 - K / Q + W) / DE;
                    switch (biQuadMode)
                    {
                        case BiQuadMode.LowPass:
                            b0 = W / DE;
                            b1 = 2.0 * W / DE;
                            b2 = W / DE;
                            break;
                        case BiQuadMode.HighPass:
                            b0 = 1.0 / DE;
                            b1 = -2.0 / DE;
                            b2 = 1.0 / DE;
                            break;
                        case BiQuadMode.BandPass:
                            b0 = K / Q / DE;
                            b1 = 0;
                            b2 = -K / Q / DE;
                            break;
                        case BiQuadMode.BandStop:
                            b0 = (1.0 + W) / DE;
                            b1 = 2.0 * (W - 1.0) / DE;
                            b2 = (1.0 + W) / DE;
                            a1 = 2.0 * (W - 1.0) / DE;
                            break;
                        case BiQuadMode.Allpass:
                            alpha = Math.Sin(wc) / (2.0 * Q);
                            DE = 1.0 + alpha;
                            b0 = (1.0 - alpha) / DE;
                            b1 = -2.0 * Math.Cos(wc) / DE;
                            b2 = (1.0 + alpha) / DE;
                            a1 = -2.0 * Math.Cos(wc) / DE;
                            a2 = (1.0 - alpha) / DE;
                            break;
                    }
                    break;
            }
        }

        public Complex filter(Complex x)
        {
            Complex y = b0 * x + b1 * x1 + b2 * x2 - a1 * y1 - a2 * y2;
            x2 = x1;
            x1 = x;
            y2 = y1;
            y1 = y;
            return y;
        }
    }
}
