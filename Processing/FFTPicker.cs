using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.Processing
{
    class FFTPicker : RTForm
    {

        public void InitializeComponent()
        {
            this.dlF = new AudioProcessor.RTDial();
            this.ioI = new AudioProcessor.RTIO();
            this.ioP3 = new AudioProcessor.RTIO();
            this.clWin = new AudioProcessor.RTChoice();
            this.ioP2 = new AudioProcessor.RTIO();
            this.ioP1 = new AudioProcessor.RTIO();
            this.io0 = new AudioProcessor.RTIO();
            this.ioM1 = new AudioProcessor.RTIO();
            this.ioM2 = new AudioProcessor.RTIO();
            this.ioM3 = new AudioProcessor.RTIO();
            this.SuspendLayout();
            // 
            // dlF
            // 
            this.dlF.dialColor = System.Drawing.Color.Silver;
            this.dlF.dialDiameter = 50D;
            this.dlF.dialMarkColor = System.Drawing.Color.Red;
            this.dlF.format = "F0";
            this.dlF.Location = new System.Drawing.Point(76, 23);
            this.dlF.logScale = true;
            this.dlF.maxVal = 100000D;
            this.dlF.minVal = 1D;
            this.dlF.Name = "dlF";
            this.dlF.scaleColor = System.Drawing.Color.Gold;
            this.dlF.showScale = true;
            this.dlF.showTitle = true;
            this.dlF.showValue = true;
            this.dlF.Size = new System.Drawing.Size(80, 100);
            this.dlF.TabIndex = 12;
            this.dlF.Text = "rtDial1";
            this.dlF.title = "Frequency";
            this.dlF.titleColor = System.Drawing.Color.DimGray;
            this.dlF.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlF.unit = "Hz";
            this.dlF.val = 440D;
            this.dlF.valueColor = System.Drawing.Color.DimGray;
            this.dlF.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI
            // 
            this.ioI.contactBackColor = System.Drawing.Color.Black;
            this.ioI.contactColor = System.Drawing.Color.DimGray;
            this.ioI.Location = new System.Drawing.Point(0, 60);
            this.ioI.Name = "ioI";
            this.ioI.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI.showTitle = false;
            this.ioI.Size = new System.Drawing.Size(21, 20);
            this.ioI.TabIndex = 13;
            this.ioI.Text = "rtio1";
            this.ioI.title = "FM";
            this.ioI.titleColor = System.Drawing.Color.DimGray;
            this.ioI.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioP3
            // 
            this.ioP3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioP3.contactBackColor = System.Drawing.Color.Black;
            this.ioP3.contactColor = System.Drawing.Color.DimGray;
            this.ioP3.Location = new System.Drawing.Point(179, 29);
            this.ioP3.Name = "ioP3";
            this.ioP3.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioP3.showTitle = true;
            this.ioP3.Size = new System.Drawing.Size(46, 20);
            this.ioP3.TabIndex = 14;
            this.ioP3.Text = "rtio1";
            this.ioP3.title = "+3";
            this.ioP3.titleColor = System.Drawing.Color.DimGray;
            this.ioP3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioP3.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // clWin
            // 
            this.clWin.backColor = System.Drawing.Color.Black;
            this.clWin.frontColor = System.Drawing.Color.DimGray;
            this.clWin.Location = new System.Drawing.Point(1, 129);
            this.clWin.Name = "clWin";
            this.clWin.selectedItem = -1;
            this.clWin.Size = new System.Drawing.Size(178, 20);
            this.clWin.TabIndex = 15;
            this.clWin.Text = "rtChoice1";
            this.clWin.title = "Window";
            this.clWin.titleColor = System.Drawing.Color.DimGray;
            this.clWin.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clWin.xdim = 100;
            // 
            // ioP2
            // 
            this.ioP2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioP2.contactBackColor = System.Drawing.Color.Black;
            this.ioP2.contactColor = System.Drawing.Color.DimGray;
            this.ioP2.Location = new System.Drawing.Point(179, 55);
            this.ioP2.Name = "ioP2";
            this.ioP2.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioP2.showTitle = true;
            this.ioP2.Size = new System.Drawing.Size(46, 20);
            this.ioP2.TabIndex = 16;
            this.ioP2.Text = "rtio1";
            this.ioP2.title = "+2";
            this.ioP2.titleColor = System.Drawing.Color.DimGray;
            this.ioP2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioP2.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioP1
            // 
            this.ioP1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioP1.contactBackColor = System.Drawing.Color.Black;
            this.ioP1.contactColor = System.Drawing.Color.DimGray;
            this.ioP1.Location = new System.Drawing.Point(179, 81);
            this.ioP1.Name = "ioP1";
            this.ioP1.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioP1.showTitle = true;
            this.ioP1.Size = new System.Drawing.Size(46, 20);
            this.ioP1.TabIndex = 17;
            this.ioP1.Text = "rtio2";
            this.ioP1.title = "+1";
            this.ioP1.titleColor = System.Drawing.Color.DimGray;
            this.ioP1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioP1.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // io0
            // 
            this.io0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.io0.contactBackColor = System.Drawing.Color.Black;
            this.io0.contactColor = System.Drawing.Color.DimGray;
            this.io0.Location = new System.Drawing.Point(179, 107);
            this.io0.Name = "io0";
            this.io0.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.io0.showTitle = true;
            this.io0.Size = new System.Drawing.Size(46, 20);
            this.io0.TabIndex = 18;
            this.io0.Text = "rtio3";
            this.io0.title = "";
            this.io0.titleColor = System.Drawing.Color.DimGray;
            this.io0.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io0.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioM1
            // 
            this.ioM1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioM1.contactBackColor = System.Drawing.Color.Black;
            this.ioM1.contactColor = System.Drawing.Color.DimGray;
            this.ioM1.Location = new System.Drawing.Point(179, 133);
            this.ioM1.Name = "ioM1";
            this.ioM1.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioM1.showTitle = true;
            this.ioM1.Size = new System.Drawing.Size(46, 20);
            this.ioM1.TabIndex = 19;
            this.ioM1.Text = "rtio4";
            this.ioM1.title = "-1";
            this.ioM1.titleColor = System.Drawing.Color.DimGray;
            this.ioM1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioM1.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioM2
            // 
            this.ioM2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioM2.contactBackColor = System.Drawing.Color.Black;
            this.ioM2.contactColor = System.Drawing.Color.DimGray;
            this.ioM2.Location = new System.Drawing.Point(179, 159);
            this.ioM2.Name = "ioM2";
            this.ioM2.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioM2.showTitle = true;
            this.ioM2.Size = new System.Drawing.Size(46, 20);
            this.ioM2.TabIndex = 20;
            this.ioM2.Text = "rtio5";
            this.ioM2.title = "-2";
            this.ioM2.titleColor = System.Drawing.Color.DimGray;
            this.ioM2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioM2.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioM3
            // 
            this.ioM3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioM3.contactBackColor = System.Drawing.Color.Black;
            this.ioM3.contactColor = System.Drawing.Color.DimGray;
            this.ioM3.Location = new System.Drawing.Point(179, 185);
            this.ioM3.Name = "ioM3";
            this.ioM3.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioM3.showTitle = true;
            this.ioM3.Size = new System.Drawing.Size(46, 20);
            this.ioM3.TabIndex = 21;
            this.ioM3.Text = "rtio6";
            this.ioM3.title = "-3";
            this.ioM3.titleColor = System.Drawing.Color.DimGray;
            this.ioM3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioM3.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // FFTPicker
            // 
            this.canShrink = false;
            this.Controls.Add(this.ioM3);
            this.Controls.Add(this.ioM2);
            this.Controls.Add(this.ioM1);
            this.Controls.Add(this.io0);
            this.Controls.Add(this.ioP1);
            this.Controls.Add(this.ioP2);
            this.Controls.Add(this.clWin);
            this.Controls.Add(this.ioP3);
            this.Controls.Add(this.ioI);
            this.Controls.Add(this.dlF);
            this.Name = "FFTPicker";
            this.Size = new System.Drawing.Size(225, 213);
            this.title = "FFT Pick 1024";
            this.ResumeLayout(false);

        }

        int blockSize;
        FFTProcessor.WindowType fftWindow;


        FFTProcessor fft;

        double f;
        private RTDial dlF;
        private RTIO ioI;
        private RTIO ioP3;
        private RTChoice clWin;
        private RTIO ioP2;
        private RTIO ioP1;
        private RTIO io0;
        private RTIO ioM1;
        private RTIO ioM2;
        private RTIO ioM3;
        int n;

        private void init()
        {
            InitializeComponent();

            title = String.Format("FFT Pick {0}", blockSize);

            string[] windowList = Enum.GetNames(typeof(FFTProcessor.WindowType));
            List<RTChoice.RTDrawable> windows = new List<RTChoice.RTDrawable>();
            for (int i = 0; i < windowList.Length; i++)
                windows.Add(new RTChoice.RTDrawableText(windowList[i]));
            clWin.setEntries(windows);
            clWin.selectedItem = (int)fftWindow;

            dlF.val = f;

            clWin.choiceStateChanged += ClWin_choiceStateChanged;
            dlF.valueChanged += DlF_valueChanged;

            processingType = ProcessingType.Processor;
        }


        public FFTPicker() : this(1024)
        {
        }

        public FFTPicker(int _blockSize) : base()
        {
            blockSize = _blockSize;
            f = 1000;
            fftWindow = FFTProcessor.WindowType.Hann;

            init();
        }

        public FFTPicker(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            blockSize = src.ReadInt32();
            fftWindow = (FFTProcessor.WindowType)src.ReadInt32();
            f = src.ReadDouble();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write(blockSize);
            tgt.Write((int)fftWindow);
            tgt.Write(f);
        }

        private void DlF_valueChanged(object sender, EventArgs e)
        {
            f = dlF.val;
        }

        private void ClWin_choiceStateChanged(object sender, EventArgs e)
        {
            fftWindow = (FFTProcessor.WindowType)clWin.selectedItem;
        }


        private double[] buffIn;
        private double[] re;
        private double[] im;
        private int buffInFill;
        private double[] oval;

        public override void tick()
        {

            if (!_active)
                return;

            SignalBuffer dbin = getSignalInputBuffer(ioI);
            SignalBuffer[] dbout = new SignalBuffer[7];
            dbout[0] = getSignalOutputBuffer(ioM3);
            dbout[1] = getSignalOutputBuffer(ioM2);
            dbout[2] = getSignalOutputBuffer(ioM1);
            dbout[3] = getSignalOutputBuffer(io0);
            dbout[4] = getSignalOutputBuffer(ioP1);
            dbout[5] = getSignalOutputBuffer(ioP2);
            dbout[6] = getSignalOutputBuffer(ioP3);

            if (dbin == null)
                return;

            if (oval == null)
                oval = new double[7];

            if (buffIn == null)
            {
                buffIn = new double[blockSize];
                re = new double[blockSize / 2];
                im = new double[blockSize / 2];
                buffInFill = 0;
            }
            
            Array.Copy(dbin.data, 0, buffIn, buffInFill, owner.blockSize);
            buffInFill += owner.blockSize;

            if (buffInFill == blockSize)
            {
                if (fft == null)
                    fft = new FFTProcessor(FFTProcessor.ProcessorMode.Bidirectional, blockSize, owner.sampleRate, fftWindow);
                n = (int)Math.Floor((double)blockSize * f / (owner.sampleRate));
                fft.windowType = fftWindow;

                fft.runFFT(ref buffIn, true, ref re, ref im);
                Array.Copy(buffIn, blockSize / 2, buffIn, 0, buffInFill - blockSize / 2);
                buffInFill -= blockSize / 2;
                    
                // Process FFT
                for (int i=-3;i<=3;i++)
                {
                    int m = n + i;
                    oval[i+3] = 0;
                    if ((m >= 0) && (m < blockSize/2))
                        oval[i + 3] = Math.Sqrt(re[m] * re[m] + im[m] * im[m]);
                }

            }

            for (int i=-3;i<=3;i++)
            {
                if (dbout[i + 3] != null)
                    dbout[i + 3].SetTo(oval[i + 3]);
            }

        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "FFTBinPicker", "1024" }; }
            public override RTForm Instantiate() { return new FFTPicker(1024); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "FFTBinPicker", "2048" }; }
            public override RTForm Instantiate() { return new FFTPicker(2048); }
        }
        class RegisterClass3 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "FFTBinPicker", "4096" }; }
            public override RTForm Instantiate() { return new FFTPicker(4096); }
        }
        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "FFTBinPicker", "8192" }; }
            public override RTForm Instantiate() { return new FFTPicker(8192); }
        }
        class RegisterClass5 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "FFTBinPicker", "16384" }; }
            public override RTForm Instantiate() { return new FFTPicker(16384); }
        }
        
        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
            l.Add(new RegisterClass2());
            l.Add(new RegisterClass3());
            l.Add(new RegisterClass4());
            l.Add(new RegisterClass5());
        }



    }


}
