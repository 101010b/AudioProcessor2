using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor
{
    public class RMSdetector
    {
        int _fs;
        public int fs
        {
            set { _fs = value; updateTau(); }
            get { return _fs; }
        }

        double _tau;
        public double tau
        {
            set { _tau = value;  updateTau(); }
            get { return _tau; }
        }

        BiQuad rmsdet;
        BiQuad dcFilt;

        public RMSdetector(int __fs, double __tau)
        {
            _fs = __fs;
            _tau = __tau;
            rmsdet = new BiQuad(_fs, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.LowPass, 1.0 / (2.0 * Math.PI * _tau), Math.Sqrt(2.0));
            dcFilt = new BiQuad(_fs, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.LowPass, 1.0 / (2.0 * Math.PI * 10.0 * _tau), Math.Sqrt(2.0));
            updateTau();
        }

        void updateTau()
        {
            rmsdet.sampleRate = fs;
            dcFilt.sampleRate = fs;
            rmsdet.frequency = 1.0 / (2.0 * Math.PI * tau);
            dcFilt.frequency = 1.0 / (2.0 * Math.PI * 10.0 * tau);
        }

        private double max(double a, double b)
        {
            return (a > b) ? a : b;
        }

        public double filter(double a)
        {
            double dcv = dcFilt.filter(a);
            return Math.Sqrt(max(0.0,rmsdet.filter((a - dcv) * (a - dcv))));            
        }
    }
}
