using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.Processing
{
    class FFTFilter : RTForm
    {

        public void InitializeComponent()
        {
            this.ioI = new AudioProcessor.RTIO();
            this.ioO = new AudioProcessor.RTIO();
            this.dl1 = new AudioProcessor.RTDial();
            this.dl2 = new AudioProcessor.RTDial();
            this.SuspendLayout();
            // 
            // ioI
            // 
            this.ioI.contactBackColor = System.Drawing.Color.Black;
            this.ioI.contactColor = System.Drawing.Color.DimGray;
            this.ioI.Location = new System.Drawing.Point(0, 45);
            this.ioI.Name = "ioI";
            this.ioI.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI.showTitle = false;
            this.ioI.Size = new System.Drawing.Size(21, 20);
            this.ioI.TabIndex = 0;
            this.ioI.Text = "rtio1";
            this.ioI.title = "IO";
            this.ioI.titleColor = System.Drawing.Color.DimGray;
            this.ioI.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioO
            // 
            this.ioO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO.contactBackColor = System.Drawing.Color.Black;
            this.ioO.contactColor = System.Drawing.Color.DimGray;
            this.ioO.Location = new System.Drawing.Point(202, 45);
            this.ioO.Name = "ioO";
            this.ioO.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO.showTitle = false;
            this.ioO.Size = new System.Drawing.Size(21, 20);
            this.ioO.TabIndex = 1;
            this.ioO.Text = "rtio2";
            this.ioO.title = "IO";
            this.ioO.titleColor = System.Drawing.Color.DimGray;
            this.ioO.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // dl1
            // 
            this.dl1.dialColor = System.Drawing.Color.Silver;
            this.dl1.dialDiameter = 50D;
            this.dl1.dialMarkColor = System.Drawing.Color.Red;
            this.dl1.format = "F1";
            this.dl1.Location = new System.Drawing.Point(27, 31);
            this.dl1.logScale = true;
            this.dl1.maxVal = 100000D;
            this.dl1.minVal = 0.1D;
            this.dl1.Name = "dl1";
            this.dl1.scaleColor = System.Drawing.Color.Gold;
            this.dl1.showScale = true;
            this.dl1.showTitle = true;
            this.dl1.showValue = true;
            this.dl1.Size = new System.Drawing.Size(80, 100);
            this.dl1.TabIndex = 2;
            this.dl1.Text = "rtDial1";
            this.dl1.title = "F1";
            this.dl1.titleColor = System.Drawing.Color.DimGray;
            this.dl1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl1.unit = "Hz";
            this.dl1.val = 1000D;
            this.dl1.valueColor = System.Drawing.Color.DimGray;
            this.dl1.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dl2
            // 
            this.dl2.dialColor = System.Drawing.Color.Silver;
            this.dl2.dialDiameter = 50D;
            this.dl2.dialMarkColor = System.Drawing.Color.Red;
            this.dl2.format = "F1";
            this.dl2.Location = new System.Drawing.Point(113, 31);
            this.dl2.logScale = true;
            this.dl2.maxVal = 100000D;
            this.dl2.minVal = 0.1D;
            this.dl2.Name = "dl2";
            this.dl2.scaleColor = System.Drawing.Color.Gold;
            this.dl2.showScale = true;
            this.dl2.showTitle = true;
            this.dl2.showValue = true;
            this.dl2.Size = new System.Drawing.Size(80, 100);
            this.dl2.TabIndex = 12;
            this.dl2.Text = "rtDial2";
            this.dl2.title = "F2";
            this.dl2.titleColor = System.Drawing.Color.DimGray;
            this.dl2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl2.unit = "Hz";
            this.dl2.val = 2000D;
            this.dl2.valueColor = System.Drawing.Color.DimGray;
            this.dl2.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // FFTFilter
            // 
            this.canShrink = false;
            this.Controls.Add(this.dl2);
            this.Controls.Add(this.dl1);
            this.Controls.Add(this.ioO);
            this.Controls.Add(this.ioI);
            this.Name = "FFTFilter";
            this.Size = new System.Drawing.Size(223, 141);
            this.title = "LP{1024}";
            this.ResumeLayout(false);

        }

        int blockSize;
        FFTProcessor.WindowType fftWindow;

        FFTProcessor fft;

        double phi;
        double f1;
        double f2;
        private RTIO ioI;
        private RTIO ioO;
        private RTDial dl1;
        private RTDial dl2;

        public enum FFTFilterMode {
            LowPass,
            HighPass,
            BandPass,
            BandStop,
            AllPass,
            FrequencyShifter
        }

        public FFTFilterMode filterMode;

        private void init()
        {
            InitializeComponent();


            switch (filterMode)
            {
                case FFTFilterMode.LowPass:
                    dl2.Hide();
                    Width = Width - dl2.Width;
                    dl1.title = "f";
                    dl1.val = f1;
                    dl1.valueChanged += Dl1_valueChanged;
                    title = string.Format("LP{0}", blockSize);
                    break;
                case FFTFilterMode.HighPass:
                    dl2.Hide();
                    Width = Width - dl2.Width;
                    dl1.title = "f";
                    dl1.val = f1;
                    dl1.valueChanged += Dl1_valueChanged;
                    title = string.Format("HP{0}", blockSize);
                    break;
                case FFTFilterMode.BandPass:
                    dl1.title = "f1";
                    dl1.val = f1;
                    dl1.valueChanged += Dl1_valueChanged;
                    dl2.title = "f2";
                    dl2.val = f2;
                    dl2.valueChanged += Dl2_valueChanged;
                    title = string.Format("BP{0}", blockSize);
                    break;
                case FFTFilterMode.BandStop:
                    dl1.title = "f1";
                    dl1.val = f1;
                    dl1.valueChanged += Dl1_valueChanged;
                    dl2.title = "f2";
                    dl2.val = f2;
                    dl2.valueChanged += Dl2_valueChanged;
                    title = string.Format("BS{0}", blockSize);
                    break;
                case FFTFilterMode.AllPass:
                    dl2.Hide();
                    Width = Width - dl2.Width;
                    dl1.title = "phi";
                    dl1.logScale = false;
                    dl1.minVal = -180;
                    dl1.maxVal = 180;
                    dl1.val = phi*180/Math.PI;
                    dl1.valueChanged += Dl1_valueChanged;
                    title = string.Format("AP{0}", blockSize);
                    break;
                case FFTFilterMode.FrequencyShifter:
                    dl2.Hide();
                    Width = Width - dl2.Width;
                    dl1.title = "f";
                    dl1.val = f1;
                    dl1.valueChanged += Dl1_valueChanged;
                    title = string.Format("FS{0}", blockSize);
                    break;
            }

            processingType = ProcessingType.Processor;
        }


        public FFTFilter():this(FFTFilterMode.BandPass,1024)
        {
        }

        public FFTFilter(FFTFilterMode _filterMode, int _blockSize) : base()
        {
            filterMode = _filterMode;
            blockSize = _blockSize;
            f1 = 1000;
            f2 = 2000;
            phi = 0;
            init();
        }

        public FFTFilter(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            filterMode = (FFTFilterMode)src.ReadInt32();
            blockSize = src.ReadInt32();

            switch (filterMode)
            {
                case FFTFilterMode.LowPass:
                case FFTFilterMode.HighPass:
                case FFTFilterMode.FrequencyShifter:
                    f1 = src.ReadDouble();
                    break;
                case FFTFilterMode.BandPass:
                case FFTFilterMode.BandStop:
                    f1 = src.ReadDouble();
                    f2 = src.ReadDouble();
                    break;
                case FFTFilterMode.AllPass:
                    phi = src.ReadDouble();
                    // f1Select.value = phi * 180.0 / Math.PI;
                    break;
            }

            init();

        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write((int)filterMode);
            tgt.Write(blockSize);

            switch (filterMode)
            {
                case FFTFilterMode.LowPass:
                case FFTFilterMode.HighPass:
                case FFTFilterMode.FrequencyShifter:
                    tgt.Write(f1);
                    break;
                case FFTFilterMode.BandPass:
                case FFTFilterMode.BandStop:
                    tgt.Write(f1);
                    tgt.Write(f2);
                    break;
                case FFTFilterMode.AllPass:
                    tgt.Write(phi);
                    break;
            }
        }

        private void Dl1_valueChanged(object sender, EventArgs e)
        {
            if (filterMode == FFTFilterMode.AllPass)
                phi = dl1.val * Math.PI / 180;
            else
                f1 = dl1.val;
        }

        private void Dl2_valueChanged(object sender, EventArgs e)
        {
            f2 = dl2.val;
        }

        private double[] buffIn;
        private double[] fftOut;
        private double[] buffOut;
        private double[] re;
        private double[] im;
        private int buffInFill;
        private int buffOutFill;
        private int buffOutRead;

        public override void tick()
        {
            if (fft == null)
                fft = new FFTProcessor(FFTProcessor.ProcessorMode.Bidirectional, blockSize, owner.sampleRate, FFTProcessor.WindowType.Hann);

            SignalBuffer dbout = getSignalOutputBuffer(ioO);
            SignalBuffer dbin = getSignalInputBuffer(ioI);

            if (!_active)
                return;

            if ((dbout == null) && (dbin == null))
                return;

            if (buffIn == null)
            {
                buffIn = new double[blockSize];
                buffOut = new double[blockSize];
                fftOut = new double[blockSize];
                re = new double[blockSize / 2];
                im = new double[blockSize / 2];
                
                buffInFill = 0;
                buffOutFill = 0;
                buffOutRead = 0;
            }

            if (dbin != null)
            {
                Array.Copy(dbin.data, 0, buffIn, buffInFill, owner.blockSize);
                buffInFill += owner.blockSize;

                if (buffInFill == blockSize)
                {
                    fft.runFFT(ref buffIn, true, ref re, ref im);
                    Array.Copy(buffIn, blockSize / 2, buffIn, 0, buffInFill-blockSize/2);
                    buffInFill -= blockSize / 2;
                    // Process FFT
                    int n1, n2;
                    double s, c;
                    switch (filterMode)
                    {
                        case FFTFilterMode.LowPass:
                            n1 = (int)Math.Floor(f1 / (double)owner.sampleRate * blockSize);
                            if (n1 < 0) n1 = 0;
                            for (int i = n1; i < blockSize / 2; i++)
                                re[i] = im[i] = 0;
                            break;
                        case FFTFilterMode.HighPass:
                            n1 = (int)Math.Ceiling(f1 / (double)owner.sampleRate * blockSize);
                            if (n1 >= blockSize / 2) n1 = blockSize / 2 - 1;
                            for (int i = 0; i < n1; i++)
                                re[i] = im[i] = 0;
                            break;
                        case FFTFilterMode.BandPass:
                            n1 = (int)Math.Floor(f1 / (double)owner.sampleRate * blockSize);
                            n2 = (int)Math.Ceiling(f2 / (double)owner.sampleRate * blockSize);
                            if (n1 < 0) n1 = 0;
                            if (n2 >= blockSize / 2) n2 = blockSize / 2 - 1;
                            for (int i = 0; i < n1; i++)
                                re[i] = im[i] = 0;
                            for (int i = n2+1; i < blockSize / 2; i++)
                                re[i] = im[i] = 0;
                            break;
                        case FFTFilterMode.BandStop:
                            n1 = (int)Math.Floor(f1 / (double)owner.sampleRate * blockSize);
                            n2 = (int)Math.Ceiling(f2 / (double)owner.sampleRate * blockSize);
                            if (n1 < 0) n1 = 0;
                            if (n2 >= blockSize / 2) n2 = blockSize / 2 - 1;
                            for (int i = n1+1; i < n2; i++)
                                re[i] = im[i] = 0;
                            break;
                        case FFTFilterMode.AllPass:
                            s = Math.Sin(phi);
                            c = Math.Cos(phi);
                            for (int i = 1; i < blockSize/2; i++) {
                                double _re = re[i] * c - im[i] * s;
                                double _im = re[i] * s + im[i] * c;
                                re[i] = _re;
                                im[i] = _im;
                            }
                            break;
                        case FFTFilterMode.FrequencyShifter:
                            n1 = (int)Math.Floor(f1 / (double)owner.sampleRate * blockSize+0.5);
                            if (n1 > 0)
                            {   // positive shift
                                double df = (double)owner.sampleRate / (double)blockSize; // Bin Spacing
                                Array.Copy(re, 1, re, 1 + n1, blockSize/2 - 1 - n1);
                                Array.Copy(im, 1, im, 1 + n1, blockSize/2 - 1 - n1);
                                Array.Clear(re, 1, n1);
                                Array.Clear(im, 1, n1);
                                for (int i=1+n1;i<blockSize/2;i++)
                                {
                                    double T = 1.0 / i / df;
                                    double T2 = 1.0 / (i + n1) / df;
                                    double dphi = -2.0 * Math.PI * (T - T2) * (i+n1)*df;
                                    s = Math.Sin(dphi);
                                    c = Math.Cos(dphi);
                                    double _re = re[i] * c - im[i] * s;
                                    double _im = re[i] * s + im[i] * c;
                                    re[i] = _re;
                                    im[i] = _im;
                                }

                            }
                            if (n1 < 0)
                            {
                                n1 = -n1;
                                Array.Copy(re, n1 + 1, re, 1, blockSize / 2 - n1 - 1);
                                Array.Copy(im, n1 + 1, im, 1, blockSize / 2 - n1 - 1);
                                Array.Clear(re, blockSize / 2 - 1 - n1, n1);
                                Array.Clear(im, blockSize / 2 - 1 - n1, n1);
                            }
                            break;                            
                    }

                    // Transfer Back
                    fft.runIFFT(ref re, ref im, ref fftOut);
                    Array.Copy(buffOut, blockSize / 2, buffOut, 0, blockSize / 2);
                    Array.Clear(buffOut, blockSize / 2, blockSize / 2);
                    for (int i = 0; i < blockSize; i++)
                        buffOut[i] += fftOut[i];
                    buffOutFill = blockSize / 2;
                    buffOutRead = 0;
                }
                if (buffOutFill > 0)
                {
                    if (dbout != null)
                    {
                        Array.Copy(buffOut, buffOutRead, dbout.data, 0, owner.blockSize);
                        buffOutRead += owner.blockSize;
                    }
                }
            }
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "LowPass", "FFT","1024" }; }
            public override RTForm Instantiate() { return new FFTFilter(FFTFilterMode.LowPass, 1024); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "LowPass", "FFT","2048" }; }
            public override RTForm Instantiate() { return new FFTFilter(FFTFilterMode.LowPass, 2048); }
        }
        class RegisterClass3 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "LowPass", "FFT","4096" }; }
            public override RTForm Instantiate() { return new FFTFilter(FFTFilterMode.LowPass, 4096); }
        }

        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "HighPass", "FFT","1024" }; }
            public override RTForm Instantiate() { return new FFTFilter(FFTFilterMode.HighPass, 1024); }
        }
        class RegisterClass5 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "HighPass", "FFT","2048" }; }
            public override RTForm Instantiate() { return new FFTFilter(FFTFilterMode.HighPass, 2048); }
        }
        class RegisterClass6 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "HighPass", "FFT","4096" }; }
            public override RTForm Instantiate() { return new FFTFilter(FFTFilterMode.HighPass, 4096); }
        }
        
        class RegisterClass7 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "BandPass", "FFT","1024" }; }
            public override RTForm Instantiate() { return new FFTFilter(FFTFilterMode.BandPass, 1024); }
        }
        class RegisterClass8 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "BandPass", "FFT", "2048" }; }
            public override RTForm Instantiate() { return new FFTFilter(FFTFilterMode.BandPass, 2048); }
        }
        class RegisterClass9 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "BandPass", "FFT", "4096" }; }
            public override RTForm Instantiate() { return new FFTFilter(FFTFilterMode.BandPass, 4096); }
        }

        class RegisterClass10 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "BandStop", "FFT", "1024" }; }
            public override RTForm Instantiate() { return new FFTFilter(FFTFilterMode.BandStop, 1024); }
        }
        class RegisterClass11 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "BandStop", "FFT", "2048" }; }
            public override RTForm Instantiate() { return new FFTFilter(FFTFilterMode.BandStop, 2048); }
        }
        class RegisterClass12 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "BandStop", "FFT", "4096" }; }
            public override RTForm Instantiate() { return new FFTFilter(FFTFilterMode.BandStop, 4096); }
        }


        class RegisterClass13 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "AllPass", "FFT", "1024" }; }
            public override RTForm Instantiate() { return new FFTFilter(FFTFilterMode.AllPass, 1024); }
        }
        class RegisterClass14 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "AllPass", "FFT", "2048" }; }
            public override RTForm Instantiate() { return new FFTFilter(FFTFilterMode.AllPass, 2048); }
        }
        class RegisterClass15 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "AllPass", "FFT", "4096" }; }
            public override RTForm Instantiate() { return new FFTFilter(FFTFilterMode.AllPass, 4096); }
        }

        class RegisterClass16 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Frequency Shift", "FFT", "1024" }; }
            public override RTForm Instantiate() { return new FFTFilter(FFTFilterMode.FrequencyShifter, 1024); }
        }
        class RegisterClass17 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Frequency Shift", "FFT", "2048" }; }
            public override RTForm Instantiate() { return new FFTFilter(FFTFilterMode.FrequencyShifter, 2048); }
        }
        class RegisterClass18 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Frequency Shift", "FFT", "4096" }; }
            public override RTForm Instantiate() { return new FFTFilter(FFTFilterMode.FrequencyShifter, 4096); }
        }


        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
            l.Add(new RegisterClass2());
            l.Add(new RegisterClass3());
            l.Add(new RegisterClass4());
            l.Add(new RegisterClass5());
            l.Add(new RegisterClass6());
            l.Add(new RegisterClass7());
            l.Add(new RegisterClass8());
            l.Add(new RegisterClass9());
            l.Add(new RegisterClass10());
            l.Add(new RegisterClass11());
            l.Add(new RegisterClass12());
            l.Add(new RegisterClass13());
            l.Add(new RegisterClass14());
            l.Add(new RegisterClass15());
            l.Add(new RegisterClass16());
            l.Add(new RegisterClass17());
            l.Add(new RegisterClass18());
        }



    }


}
