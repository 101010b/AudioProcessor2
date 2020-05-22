using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.DataProcessing
{
    class Chromagram : RTForm
    {

        public void InitializeComponent()
        {
            this.dlF = new AudioProcessor.RTDial();
            this.ioI = new AudioProcessor.RTIO();
            this.clWin = new AudioProcessor.RTChoice();
            this.clBlock = new AudioProcessor.RTChoice();
            this.bnNormalize = new AudioProcessor.RTButton();
            this.ioData = new AudioProcessor.RTIO();
            this.dlFMax = new AudioProcessor.RTDial();
            this.SuspendLayout();
            // 
            // dlF
            // 
            this.dlF.dialColor = System.Drawing.Color.Silver;
            this.dlF.dialDiameter = 50D;
            this.dlF.dialMarkColor = System.Drawing.Color.Red;
            this.dlF.format = "F0";
            this.dlF.Location = new System.Drawing.Point(67, 21);
            this.dlF.logScale = true;
            this.dlF.maxVal = 100000D;
            this.dlF.minVal = 1D;
            this.dlF.Name = "dlF";
            this.dlF.scaleColor = System.Drawing.Color.Gold;
            this.dlF.showScale = true;
            this.dlF.showTitle = true;
            this.dlF.showValue = true;
            this.dlF.Size = new System.Drawing.Size(80, 80);
            this.dlF.TabIndex = 12;
            this.dlF.Text = "rtDial1";
            this.dlF.title = "Base";
            this.dlF.titleColor = System.Drawing.Color.DimGray;
            this.dlF.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlF.unit = "Hz";
            this.dlF.val = 55D;
            this.dlF.valueColor = System.Drawing.Color.DimGray;
            this.dlF.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI
            // 
            this.ioI.contactBackColor = System.Drawing.Color.Black;
            this.ioI.contactColor = System.Drawing.Color.DimGray;
            this.ioI.contactHighlightColor = System.Drawing.Color.Red;
            this.ioI.highlighted = false;
            this.ioI.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioI.Location = new System.Drawing.Point(0, 30);
            this.ioI.Name = "ioI";
            this.ioI.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI.showTitle = false;
            this.ioI.Size = new System.Drawing.Size(21, 20);
            this.ioI.TabIndex = 13;
            this.ioI.Text = "rtio1";
            this.ioI.title = "FM";
            this.ioI.titleColor = System.Drawing.Color.DimGray;
            this.ioI.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // clWin
            // 
            this.clWin.backColor = System.Drawing.Color.Black;
            this.clWin.choiceType = AudioProcessor.RTChoice.ChoiceType.ListDefined;
            this.clWin.frontColor = System.Drawing.Color.DimGray;
            this.clWin.Location = new System.Drawing.Point(11, 109);
            this.clWin.Name = "clWin";
            this.clWin.numericMax = 100;
            this.clWin.numericMin = 0;
            this.clWin.offString = "off";
            this.clWin.selectedItem = -1;
            this.clWin.Size = new System.Drawing.Size(162, 20);
            this.clWin.TabIndex = 15;
            this.clWin.Text = "rtChoice1";
            this.clWin.title = "Window";
            this.clWin.titleColor = System.Drawing.Color.DimGray;
            this.clWin.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clWin.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clWin.xdim = 100;
            // 
            // clBlock
            // 
            this.clBlock.backColor = System.Drawing.Color.Black;
            this.clBlock.choiceType = AudioProcessor.RTChoice.ChoiceType.ListDefined;
            this.clBlock.frontColor = System.Drawing.Color.DimGray;
            this.clBlock.Location = new System.Drawing.Point(11, 135);
            this.clBlock.Name = "clBlock";
            this.clBlock.numericMax = 100;
            this.clBlock.numericMin = 0;
            this.clBlock.offString = "off";
            this.clBlock.selectedItem = -1;
            this.clBlock.Size = new System.Drawing.Size(162, 20);
            this.clBlock.TabIndex = 28;
            this.clBlock.Text = "rtChoice1";
            this.clBlock.title = "Block";
            this.clBlock.titleColor = System.Drawing.Color.DimGray;
            this.clBlock.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clBlock.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clBlock.xdim = 100;
            // 
            // bnNormalize
            // 
            this.bnNormalize.buttonDim = new System.Drawing.Size(30, 15);
            this.bnNormalize.buttonState = false;
            this.bnNormalize.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bnNormalize.fillOffColor = System.Drawing.Color.Black;
            this.bnNormalize.fillOnColor = System.Drawing.Color.DarkRed;
            this.bnNormalize.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnNormalize.frameOffColor = System.Drawing.Color.DimGray;
            this.bnNormalize.frameOnColor = System.Drawing.Color.Red;
            this.bnNormalize.Location = new System.Drawing.Point(179, 110);
            this.bnNormalize.Name = "bnNormalize";
            this.bnNormalize.offText = "Off";
            this.bnNormalize.onText = "On";
            this.bnNormalize.Size = new System.Drawing.Size(82, 45);
            this.bnNormalize.TabIndex = 29;
            this.bnNormalize.Text = "rtButton1";
            this.bnNormalize.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnNormalize.textOffColor = System.Drawing.Color.DimGray;
            this.bnNormalize.textOnColor = System.Drawing.Color.Red;
            this.bnNormalize.title = "Normalize";
            this.bnNormalize.titleColor = System.Drawing.Color.DimGray;
            this.bnNormalize.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnNormalize.titlePos = AudioProcessor.RTButton.RTTitlePos.Above;
            // 
            // ioData
            // 
            this.ioData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioData.contactBackColor = System.Drawing.Color.Black;
            this.ioData.contactColor = System.Drawing.Color.DimGray;
            this.ioData.contactHighlightColor = System.Drawing.Color.Red;
            this.ioData.highlighted = false;
            this.ioData.IOtype = AudioProcessor.RTIO.ProcessingIOType.DataOutput;
            this.ioData.Location = new System.Drawing.Point(274, 30);
            this.ioData.Name = "ioData";
            this.ioData.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioData.showTitle = false;
            this.ioData.Size = new System.Drawing.Size(21, 20);
            this.ioData.TabIndex = 31;
            this.ioData.Text = "rtio1";
            this.ioData.title = "Data";
            this.ioData.titleColor = System.Drawing.Color.DimGray;
            this.ioData.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dlFMax
            // 
            this.dlFMax.dialColor = System.Drawing.Color.Silver;
            this.dlFMax.dialDiameter = 50D;
            this.dlFMax.dialMarkColor = System.Drawing.Color.Red;
            this.dlFMax.format = "F0";
            this.dlFMax.Location = new System.Drawing.Point(153, 21);
            this.dlFMax.logScale = true;
            this.dlFMax.maxVal = 100000D;
            this.dlFMax.minVal = 1D;
            this.dlFMax.Name = "dlFMax";
            this.dlFMax.scaleColor = System.Drawing.Color.Gold;
            this.dlFMax.showScale = true;
            this.dlFMax.showTitle = true;
            this.dlFMax.showValue = true;
            this.dlFMax.Size = new System.Drawing.Size(80, 80);
            this.dlFMax.TabIndex = 32;
            this.dlFMax.Text = "rtDial1";
            this.dlFMax.title = "FMax";
            this.dlFMax.titleColor = System.Drawing.Color.DimGray;
            this.dlFMax.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlFMax.unit = "Hz";
            this.dlFMax.val = 4000D;
            this.dlFMax.valueColor = System.Drawing.Color.DimGray;
            this.dlFMax.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // Chromagram
            // 
            this.Controls.Add(this.dlFMax);
            this.Controls.Add(this.ioData);
            this.Controls.Add(this.bnNormalize);
            this.Controls.Add(this.clBlock);
            this.Controls.Add(this.clWin);
            this.Controls.Add(this.ioI);
            this.Controls.Add(this.dlF);
            this.Name = "Chromagram";
            this.shrinkSize = new System.Drawing.Size(85, 65);
            this.shrinkTitle = "CG";
            this.Size = new System.Drawing.Size(295, 168);
            this.title = "Chromagram";
            this.ResumeLayout(false);

        }

        int blockSize;
        FFTProcessor.WindowType fftWindow;
        bool normalize;

        FFTProcessor fft;

        double fA;
        double fMax;
        private RTDial dlF;
        private RTIO ioI;
        private RTChoice clWin;
        private RTChoice clBlock;
        int n;
        private RTButton bnNormalize;
        private RTIO ioData;
        private RTDial dlFMax;
        int[] blocks = { 256, 512, 1024, 2048, 4096, 8192 };

        private void init()
        {
            InitializeComponent();

            string[] windowList = Enum.GetNames(typeof(FFTProcessor.WindowType));
            List<RTChoice.RTDrawable> windows = new List<RTChoice.RTDrawable>();
            for (int i = 0; i < windowList.Length; i++)
                windows.Add(new RTChoice.RTDrawableText(windowList[i]));
            clWin.setEntries(windows);
            clWin.selectedItem = (int)fftWindow;

            string[] blockList = new string[blocks.Length];
            List<RTChoice.RTDrawable> bls = new List<RTChoice.RTDrawable>();
            for (int i = 0; i < blocks.Length; i++)
                bls.Add(new RTChoice.RTDrawableText(string.Format("{0} ({1:F0} ms)", blocks[i], 
                    1000.0/(((owner != null) ? owner.sampleRate : 48000) / blocks[i]))));
            clBlock.setEntries(bls);
            int bln = 0;
            for (int i = 1; i < blocks.Length; i++)
                if (blocks[i] == blockSize)
                    bln = i;
            clBlock.selectedItem = bln;
            blockSize = blocks[bln];

            dlF.val = fA;
            dlFMax.val = fMax;

            bnNormalize.buttonState = normalize;

            clWin.choiceStateChanged += ClWin_choiceStateChanged;
            clBlock.choiceStateChanged += ClBlock_choiceStateChanged;
            dlF.valueChanged += DlF_valueChanged;
            dlFMax.valueChanged += DlFMax_valueChanged;
            bnNormalize.buttonStateChanged += BnNormalize_buttonStateChanged;

            processingType = ProcessingType.Processor;
        }


        public Chromagram() : base()
        {
            blockSize = 4096;
            fA = 220;
            fMax = 220 * 16;
            fftWindow = FFTProcessor.WindowType.Hann;

            init();
        }

        public Chromagram(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            blockSize = src.ReadInt32();
            fftWindow = (FFTProcessor.WindowType)src.ReadInt32();
            fA = src.ReadDouble();
            fMax = src.ReadDouble();
            normalize = src.ReadBoolean();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write(blockSize);
            tgt.Write((int)fftWindow);
            tgt.Write(fA);
            tgt.Write(fMax);
            tgt.Write(normalize);
        }

        private void DlF_valueChanged(object sender, EventArgs e)
        {
            fA = dlF.val;
        }

        private void DlFMax_valueChanged(object sender, EventArgs e)
        {
            fMax = dlFMax.val;
        }

        private void BnNormalize_buttonStateChanged(object sender, EventArgs e)
        {
            normalize = bnNormalize.buttonState;
        }

        private void ClBlock_choiceStateChanged(object sender, EventArgs e)
        {
            blockSize = blocks[clBlock.selectedItem];
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
        private int[] addto;
        private double[] addtoCoeff;
        private double fA0 = -1;
        private double fMax0 = -1;
        private double[] on = new double[12];

        private double lowPass(double f, double fc)
        {
            return 1 / (1 + (f / fc)*(f/fc));
        }

        private double highPass(double f, double fc)
        {
            return 1 - lowPass(f, fc);
        }

        private double bandPass(double f, double f1, double f2)
        {
            return highPass(f, f1) * lowPass(f, f2);
        }

        public override void tick()
        {

            if (!_active)
                return;

            SignalBuffer dbin = getSignalInputBuffer(ioI);
            DataBuffer dbout = getDataOutputBuffer(ioData);

            if (dbin == null)
                return;

            if (oval == null)
                oval = new double[7];

            if ((buffIn == null) || (buffIn.Length != blockSize))
            {
                buffIn = new double[blockSize];
                re = new double[blockSize / 2];
                im = new double[blockSize / 2];
                buffInFill = 0;
                fft = null;
                addto = null;
            }
            if ((fft != null) && (fft.windowType != fftWindow))
                fft = new FFTProcessor(FFTProcessor.ProcessorMode.Bidirectional, blockSize, owner.sampleRate, fftWindow);


            Array.Copy(dbin.data, 0, buffIn, buffInFill, owner.blockSize);
            buffInFill += owner.blockSize;

            if (buffInFill == blockSize)
            {
                if (fft == null)
                    fft = new FFTProcessor(FFTProcessor.ProcessorMode.Bidirectional, blockSize, owner.sampleRate, fftWindow);
                if ((addto == null) || (fA != fA0) || (fMax != fMax0))
                {
                    fA0 = fA;
                    fMax0 = fMax;
                    double fC = fA * Math.Pow(2, -9.0 / 12.0);
                    addto = new int[blockSize / 2];
                    addtoCoeff = new double[blockSize / 2];
                    for (int i = 0; i < blockSize / 2; i++)
                    {
                        double f = fft.freq[i];
                        double weight = bandPass(f, fC, fMax);
                        if (weight < 0.1)
                            addto[i] = -1;
                        else
                        {
                            int fn = (int)Math.Floor(Math.Log(f / fC, 2.0) * 12 + 0.5);
                            addto[i] = fn % 12;
                            addtoCoeff[i] = weight;
                        }
                    }
                }

                // n = (int)Math.Floor((double)blockSize * fA / (owner.sampleRate));
                fft.windowType = fftWindow;

                fft.runFFT(ref buffIn, true, ref re, ref im);
                Array.Copy(buffIn, blockSize / 2, buffIn, 0, buffInFill - blockSize / 2);
                buffInFill -= blockSize / 2;

                // Process FFT Data
                //double[] on = new double[12];
                for (int i = 0; i < 12; i++) on[i] = 0;
                double[] n = new double[12];
                for (int i = 0; i < addto.Length; i++)
                {
                    if (addto[i] >= 0)
                    {
                        on[addto[i]] += addtoCoeff[i] * (re[i] * re[i] + im[i] * im[i]);
                        n[addto[i]] += addtoCoeff[i];
                    }
                }
                double emax = 0;
                double emin = 0;
                for (int i = 0; i < 12; i++)
                {
                    on[i] = Math.Sqrt(on[i] / n[i]);
                    if (i == 0)
                    {
                        emin = emax = on[i];
                    }
                    else
                    {
                        if (on[i] < emin) emin = on[i];
                        if (on[i] > emax) emax = on[i];
                    }
                }
                if (normalize)
                {
                    if (emax == emin) emax = emin + 1;
                    for (int i = 0; i < 12; i++)
                        on[i] = (on[i] - emin) / (emax - emin);
                } else
                {
                    double[] onLog = new double[12];
                    for (int i = 0; i < 12; i++)
                    {
                        if (on[i] < 1e-5)
                            onLog[i] = -100;
                        else if (on[i] > 1e1)
                            onLog[i] = 20;
                        else
                            onLog[i] = 20 * Math.Log10(on[i]);
                        onLog[i] = (onLog[i] - (-100)) / (20 - (-100));
                    }
                }
                if (dbout != null)
                {
                    dbout.initialize(12);
                    dbout.set(on);
                }
            }
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Data", "Chromagram" }; }
            public override RTForm Instantiate() { return new Chromagram(); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
        }



    }


}
