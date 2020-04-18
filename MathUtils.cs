using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor
{
    public class MathUtils
    {
        
        // WaveFrom Functions
        // Defined by phase going from 0 to 1
        // pwm is defined from -1 to 1, 0 being neutral
        // pwm is valid for pulse and triangulare waveform and ignored for saw and sine
        public enum WaveForm
        {
            Sine = 0,
            Triangle,
            Saw,
            Pulse
        }

        public static double AmplitudeFromRMS(WaveForm wf)
        {
            switch (wf)
            {
                case WaveForm.Sine:
                    return Math.Sqrt(2);
                case WaveForm.Triangle:
                case WaveForm.Saw:
                    return Math.Sqrt(3);
                case WaveForm.Pulse:
                    return 1.0;
            }
            return 1.0;
        }

        private static double tri(double p, double pwm)
        {
            double px = 0.25 + pwm / 4;
            px = (px < 0) ? 0 : ((px > 1) ? 1 : px);
            if (p < px) return p / px;
            if (p < 1 - px) return 1 - 2 * (p - px) / (1 - 2 * px);
            return -1 + (p - (1 - px)) / px;
        }

        private static double tri90(double p, double pwm)
        {
            return tri((p < 0.75) ? (p + 0.25) : (p - 0.75), pwm);
        }

        private static double tri(double p)
        {
            if (p < 0.25) return p * 4;
            if (p < 0.75) return 1 - 4 * (p - 0.25);
            return -1 + 4 * (p - 0.75);
        }

        private static double tri90(double p)
        {
            if (p < 0.5) return 1 - 4 * p;
            return -3 + 4 * p;
        }

        private static double saw(double p)
        {
            if (p < 0.5) return 2 * p;
            return -2 + 2 * p;
        }

        private static double saw90(double p)
        {
            if (p < 0.25) return 0.5 + 2 * p;
            return -1.5 + 2 * p;
        }

        private static double pulse(double p)
        {
            return (p < 0.5) ? 1 : -1;
        }

        private static double pulse(double p, double pwm)
        {
            double px = (pwm + 1) / 2;
            return (p < px) ? 1 : -1;
        }

        private static double pulse90(double p)
        {
            return ((p<0.25)||(p > 0.75))?1:-1;
        }

        private static double pulse90(double p, double pwm)
        {
            return pulse((p < 0.75) ? (p + 0.25) : (p - 0.75), pwm);
        }

        public static double waveForm(WaveForm wf, double p)
        {
            switch (wf)
            {
                case WaveForm.Sine:
                    return Math.Sin(p * 2 * Math.PI);
                case WaveForm.Saw:
                    return saw(p);
                case WaveForm.Triangle:
                    return tri(p);
                case WaveForm.Pulse:
                    return pulse(p);
            }
            return 0;
        }

        public static double waveForm90(WaveForm wf, double p)
        {
            switch (wf)
            {
                case WaveForm.Sine:
                    return Math.Cos(p * 2 * Math.PI);
                case WaveForm.Saw:
                    return saw90(p);
                case WaveForm.Triangle:
                    return tri90(p);
                case WaveForm.Pulse:
                    return pulse90(p);
            }
            return 0;
        }

        public static double waveForm(WaveForm wf, double p, double pwm)
        {
            switch (wf)
            {
                case WaveForm.Sine:
                    return Math.Sin(p * 2 * Math.PI);
                case WaveForm.Saw:
                    return saw(p);
                case WaveForm.Triangle:
                    return tri(p,pwm);
                case WaveForm.Pulse:
                    return pulse(p,pwm);
            }
            return 0;
        }

        public static double waveForm90(WaveForm wf, double p, double pwm)
        {
            switch (wf)
            {
                case WaveForm.Sine:
                    return Math.Cos(p * 2 * Math.PI);
                case WaveForm.Saw:
                    return saw90(p);
                case WaveForm.Triangle:
                    return tri((p < 0.75) ? (p + 0.25) : (p - 0.75), pwm);
                case WaveForm.Pulse:
                    return pulse((p < 0.75) ? (p + 0.25) : (p - 0.75), pwm);
            }
            return 0;
        }

        public static void waveForm(WaveForm wf, ref double zero, ref double ninety, double p, double pwm)
        {
            switch (wf)
            {
                case WaveForm.Sine:
                    zero = Math.Sin(p * 2 * Math.PI);
                    ninety = Math.Cos(p * 2 * Math.PI);
                    return;
                case WaveForm.Saw:
                    zero = saw(p);
                    ninety = saw90(p);
                    return;
                case WaveForm.Triangle:
                    if (pwm != 0)
                    {
                        zero = tri(p, pwm);
                        ninety = tri((p < 0.75) ? (p + 0.25) : (p - 0.75), pwm);
                    } else
                    {
                        zero = tri(p);
                        ninety = tri90(p);
                    }
                    return;
                case WaveForm.Pulse:
                    if (pwm != 0)
                    {
                        zero = pulse(p, pwm);
                        ninety = pulse((p < 0.75) ? (p + 0.25) : (p - 0.75), pwm);
                    } else
                    {
                        zero = pulse(p);
                        ninety = pulse90(p);
                    }
                    return;
            }
            zero = ninety = 0.0;
        }

        public static void waveForm(WaveForm wf, ref double zero, ref double ninety, double p)
        {
            switch (wf)
            {
                case WaveForm.Sine:
                    zero = Math.Sin(p * 2 * Math.PI);
                    ninety = Math.Cos(p * 2 * Math.PI);
                    return;
                case WaveForm.Saw:
                    zero = saw(p);
                    ninety = saw90(p);
                    return;
                case WaveForm.Triangle:
                    zero = tri(p);
                    ninety = tri90(p);
                    return;
                case WaveForm.Pulse:
                    zero = pulse(p);
                    ninety = pulse90(p);
                    return;
            }
            zero = ninety = 0.0;
        }

        public static double trig(double p)
        {
            return (p < 0.5) ? 1 : -1;
        }

    }
}
