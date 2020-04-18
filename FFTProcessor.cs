using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using FFTWSharp;


namespace AudioProcessor
{
    public class FFTProcessor
    {

        public enum WindowType
        {
            Rectangular,
            Hann,
            Hamming,
            Blackman,
            Triangular
        }

        public static double[] windowPowerCorrectionFactorsdB = { 0, 4.244, 4.028, 5.164, 0 };
        public static double[] windowAmplitudeCorrectionFactorsdB = { 0, 6.021, 5.343, 7.500,  0 };

        int sampleRate;
        int fftLength;
        public int blockSize
        {
            set
            {
                if (value != fftLength)
                {
                    fftLength = value;
                    initFFT();
                }
            }
            get { return fftLength; }
        }

        IntPtr pin, pout;
        double[] fout, fin;
        IntPtr fplan;
        IntPtr fiplan;
        double[] window;
        WindowType winFunc;
        public WindowType windowType
        {
            set
            {
                if (value != winFunc)
                {
                    winFunc = value;
                    makeWindow();
                }
            }
            get { return winFunc; }
        }
        public double[] freq;
        public double amp_cf;
        public double pwr_cf;

        public enum ProcessorMode
        {
            OneWay,
            Bidirectional
        }
        private ProcessorMode processorMode;

        public FFTProcessor(int _fftLength, int _sampleRate, WindowType _windowType)
        {
            fftLength = _fftLength;
            sampleRate = _sampleRate;
            winFunc = _windowType;

            pin = pout = IntPtr.Zero;
            fplan = IntPtr.Zero;
            fiplan = IntPtr.Zero;

            processorMode = ProcessorMode.OneWay;

            initFFT();
        }

        public FFTProcessor(ProcessorMode _processorMode, int _fftLength, int _sampleRate, WindowType _windowType)
        {
            fftLength = _fftLength;
            sampleRate = _sampleRate;
            winFunc = _windowType;

            pin = pout = IntPtr.Zero;
            fplan = IntPtr.Zero;
            fiplan = IntPtr.Zero;

            processorMode = _processorMode;

            initFFT();
        }
        
        private void initFFT()
        {

            if (pin != IntPtr.Zero)
            {
                fftw.free(pin);
                fftw.free(pout);
                pin = pout = IntPtr.Zero;
            }
            pin = fftw.malloc(fftLength * 2 * sizeof(double));
            pout = fftw.malloc(fftLength * 2 * sizeof(double));


            // Temporary buffers for data processing
            fin = new double[2 * fftLength];
            fout = new double[2 * fftLength];
            window = new double[fftLength];
            freq = new double[fftLength / 2];

            makeWindow();

            makeFreq();

            if (fplan == IntPtr.Zero)
            {
                fftw.destroy_plan(fplan);
                fplan = IntPtr.Zero;
            }
            if (fiplan == IntPtr.Zero)
            {
                fftw.destroy_plan(fiplan);
                fiplan = IntPtr.Zero;
            }
            fplan = fftw.dft_r2c_1d(fftLength, pin, pout, fftw_flags.Estimate);
            if (processorMode == ProcessorMode.Bidirectional)
                fiplan = fftw.dft_c2r_1d(fftLength, pout, pin, fftw_flags.Estimate);
        }

        private void makeFreq()
        {
            for (int i = 0; i < 2 * fftLength; i++) fin[i] = 0.0;
            for (int i = 0; i < fftLength / 2; i++) freq[i] = (double)i / (fftLength / 2) * sampleRate / 2;
        }

        private void makeWindow()
        {
            double alpha, a0, a1, a2;

            switch (winFunc)
            {
                case WindowType.Hann:
                    for (int i = 0; i < fftLength; i++)
                        window[i] = 0.5 - 0.5 * Math.Cos((double)i * 2 * Math.PI / (fftLength - 1));
                    amp_cf = 6;
                    pwr_cf = 4.3;
                    break;

                case WindowType.Hamming:
                    for (int i = 0; i < fftLength; i++)
                        window[i] = 0.54 - 0.46 * Math.Cos((double)i * 2 * Math.PI / (fftLength - 1));
                    amp_cf = 5.35;
                    pwr_cf = 4.0;
                    break;

                case WindowType.Blackman:
                    alpha = 0.16;
                    a0 = (1.0 - alpha) / 2.0;
                    a1 = 0.5;
                    a2 = alpha / 2;
                    for (int i = 0; i < fftLength; i++)
                        window[i] =
                                a0
                            - a1 * Math.Cos((double)i * 2 * Math.PI / (fftLength - 1))
                            + a2 * Math.Cos((double)i * 4 * Math.PI / (fftLength - 1));
                    amp_cf = 7.54;
                    pwr_cf = 5.2;
                    break;
                case WindowType.Triangular:
                    for (int i = 0; i < fftLength; i++)
                        window[i] = 1.0 - Math.Abs(i - (fftLength - 1) / 2) / (fftLength / 2);
                    break;

                case WindowType.Rectangular:
                default:
                    for (int i = 0; i < fftLength; i++)
                        window[i] = 1.0;
                    amp_cf = 0;
                    pwr_cf = 0;
                    break;

            }

        }

        public void runFFT(ref double[] inp, Boolean useWin, ref double[] re, ref double[] im)
        {
            // Step 1: applying the window
            if (useWin)
            {
                for (int i = 0; i < fftLength; i++)
                {
                    fin[i] = inp[i] * window[i];
                    fin[i + fftLength] = 0;
                }
            } else
            {
                for (int i = 0; i < fftLength; i++)
                {
                    fin[i] = inp[i];
                    fin[i + fftLength] = 0;
                }
            }
            double c = fftLength;
            double cf = 2.0;
            double cfc = cf / c / 2.0;
            // Step 2: Copy to fftw Memory
            Marshal.Copy(fin, 0, pin, fftLength * 2);
            // Step 3: Execute the plan
            fftwf.execute(fplan);
            // Step 4: Copy back results
            Marshal.Copy(pout, fout, 0, fftLength * 2);
            // Process Data into Voltage
            for (int i = 0; i < fftLength / 2; i++)
            {
                re[i] = fout[2 * i]*cfc;
                im[i] = fout[2 * i + 1] * cfc;
            }
        }

        public void runIFFT(ref double[] re, ref double[] im, ref double[] outp)
        {
            if (processorMode != ProcessorMode.Bidirectional)
                return;
            // Step 1: applying the window
            for (int i = 0; i < fftLength/2; i++)
            {
                fout[i * 2] = re[i];
                fout[i * 2 + 1] = im[i];
                fout[i + fftLength] = 0;
                fout[fftLength + i * 2] = re[i];
                fout[fftLength + i * 2 + 1] = -im[i];
            }
            // Step 2: Copy to fftw Memory
            Marshal.Copy(fout, 0, pout, fftLength * 2);
            // Step 3: Execute the plan
            fftwf.execute(fiplan);
            // Step 4: Copy back results
            Marshal.Copy(pin, fin, 0, fftLength * 2);
            // Process Data into Voltage
            for (int i = 0; i < fftLength; i++)
                outp[i] = fin[i];
        }


        public void runFFTdBFS(ref double[] inp, ref double[] outp)
        {
            // Step 1: applying the window
            for (int i = 0; i < fftLength; i++)
            {
                fin[i] = inp[i] * window[i];
                fin[i+fftLength] = 0;
            }
            double c = fftLength;
            double cf = 2.0;
            double cfc = 20.0 * Math.Log10(cf / c);
            // Step 2: Copy to fftw Memory
            Marshal.Copy(fin, 0, pin, fftLength * 2);
            // Step 3: Execute the plan
            fftwf.execute(fplan);
            // Step 4: Copy back results
            Marshal.Copy(pout, fout, 0, fftLength*2);
            // Process Data into Voltage
            double v2;
            for (int i = 0; i < fftLength / 2; i++)
            {
                // outpCH0[i] = cf * Math.Sqrt((fout1[2 * i] * fout1[2 * i] + fout1[2 * i + 1] * fout1[2 * i + 1]) / c);
                v2 = fout[2 * i] * fout[2 * i] + fout[2 * i + 1] * fout[2 * i + 1];
                if (v2 < 1e-20) v2 = 1e-20;
                outp[i] = cfc + 10 * Math.Log10(v2);
            }
        }

        public void runFFTdBFS(ref double[] inp, ref float[] outp)
        {
            // Step 1: applying the window
            for (int i = 0; i < fftLength; i++)
            {
                fin[i] = inp[i] * window[i];
                fin[i + fftLength] = 0;
            }
            double c = fftLength;
            double cf = 2.0;
            double cfc = 20.0 * Math.Log10(cf / c);
            // Step 2: Copy to fftw Memory
            Marshal.Copy(fin, 0, pin, fftLength * 2);
            // Step 3: Execute the plan
            fftwf.execute(fplan);
            // Step 4: Copy back results
            Marshal.Copy(pout, fout, 0, fftLength * 2);
            // Process Data into Voltage
            double v2;
            for (int i = 0; i < fftLength / 2; i++)
            {
                // outpCH0[i] = cf * Math.Sqrt((fout1[2 * i] * fout1[2 * i] + fout1[2 * i + 1] * fout1[2 * i + 1]) / c);
                v2 = fout[2 * i] * fout[2 * i] + fout[2 * i + 1] * fout[2 * i + 1];
                if (v2 < 1e-20) v2 = 1e-20;
                outp[i] = (float)(cfc + 10 * Math.Log10(v2));
            }
        }
        public void runFFTdBRMS(ref double[] inp, ref float[] outp)
        {
            // Step 1: applying the window
            for (int i = 0; i < fftLength; i++)
            {
                fin[i] = inp[i] * window[i];
                fin[i + fftLength] = 0;
            }
            double c = fftLength;
            double cf = 2.0;
            double cfc = 20.0 * Math.Log10(cf / c) - 3.02;
            // Step 2: Copy to fftw Memory
            Marshal.Copy(fin, 0, pin, fftLength * 2);
            // Step 3: Execute the plan
            fftwf.execute(fplan);
            // Step 4: Copy back results
            Marshal.Copy(pout, fout, 0, fftLength * 2);
            // Process Data into Voltage
            double v2;
            for (int i = 0; i < fftLength / 2; i++)
            {
                // outpCH0[i] = cf * Math.Sqrt((fout1[2 * i] * fout1[2 * i] + fout1[2 * i + 1] * fout1[2 * i + 1]) / c);
                v2 = fout[2 * i] * fout[2 * i] + fout[2 * i + 1] * fout[2 * i + 1];
                if (v2 < 1e-20) v2 = 1e-20;
                outp[i] = (float)(cfc + 10 * Math.Log10(v2));
            }
        }

        public void runFFTdBRMS(ref double[] inp, ref double[] outp)
        {
            // Step 1: applying the window
            for (int i = 0; i < fftLength; i++)
            {
                fin[i] = inp[i] * window[i];
                fin[i + fftLength] = 0;
            }
            double c = fftLength;
            double cf = 2.0;
            double cfc = 20.0 * Math.Log10(cf / c) - 3.02;
            // Step 2: Copy to fftw Memory
            Marshal.Copy(fin, 0, pin, fftLength * 2);
            // Step 3: Execute the plan
            fftwf.execute(fplan);
            // Step 4: Copy back results
            Marshal.Copy(pout, fout, 0, fftLength * 2);
            // Process Data into Voltage
            double v2;
            for (int i = 0; i < fftLength / 2; i++)
            {
                // outpCH0[i] = cf * Math.Sqrt((fout1[2 * i] * fout1[2 * i] + fout1[2 * i + 1] * fout1[2 * i + 1]) / c);
                v2 = fout[2 * i] * fout[2 * i] + fout[2 * i + 1] * fout[2 * i + 1];
                if (v2 < 1e-20) v2 = 1e-20;
                outp[i] = (float)(cfc + 10 * Math.Log10(v2));
            }
        }
        
    }
}
