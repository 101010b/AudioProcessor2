using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.DataProcessing
{
    class DataFFT : RTForm
    {

        public void InitializeComponent()
        {
            this.ioI = new AudioProcessor.RTIO();
            this.clWin = new AudioProcessor.RTChoice();
            this.clBlock = new AudioProcessor.RTChoice();
            this.bnNormalize = new AudioProcessor.RTButton();
            this.ioData = new AudioProcessor.RTIO();
            this.ioTrig = new AudioProcessor.RTIO();
            this.clMode = new AudioProcessor.RTChoice();
            this.SuspendLayout();
            // 
            // ioI
            // 
            this.ioI.contactBackColor = System.Drawing.Color.Black;
            this.ioI.contactColor = System.Drawing.Color.DimGray;
            this.ioI.contactHighlightColor = System.Drawing.Color.Red;
            this.ioI.hideOnShrink = false;
            this.ioI.highlighted = false;
            this.ioI.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioI.Location = new System.Drawing.Point(0, 24);
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
            this.clWin.hideOnShrink = true;
            this.clWin.Location = new System.Drawing.Point(44, 24);
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
            this.clBlock.hideOnShrink = true;
            this.clBlock.Location = new System.Drawing.Point(51, 50);
            this.clBlock.Name = "clBlock";
            this.clBlock.numericMax = 100;
            this.clBlock.numericMin = 0;
            this.clBlock.offString = "off";
            this.clBlock.selectedItem = -1;
            this.clBlock.Size = new System.Drawing.Size(155, 20);
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
            this.bnNormalize.hideOnShrink = true;
            this.bnNormalize.Location = new System.Drawing.Point(204, 25);
            this.bnNormalize.Name = "bnNormalize";
            this.bnNormalize.offText = "Off";
            this.bnNormalize.onText = "On";
            this.bnNormalize.Size = new System.Drawing.Size(67, 45);
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
            this.ioData.hideOnShrink = false;
            this.ioData.highlighted = false;
            this.ioData.IOtype = AudioProcessor.RTIO.ProcessingIOType.DataOutput;
            this.ioData.Location = new System.Drawing.Point(275, 24);
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
            // ioTrig
            // 
            this.ioTrig.contactBackColor = System.Drawing.Color.Black;
            this.ioTrig.contactColor = System.Drawing.Color.DimGray;
            this.ioTrig.contactHighlightColor = System.Drawing.Color.Red;
            this.ioTrig.hideOnShrink = false;
            this.ioTrig.highlighted = false;
            this.ioTrig.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioTrig.Location = new System.Drawing.Point(0, 50);
            this.ioTrig.Name = "ioTrig";
            this.ioTrig.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioTrig.showTitle = true;
            this.ioTrig.Size = new System.Drawing.Size(45, 20);
            this.ioTrig.TabIndex = 32;
            this.ioTrig.Text = "rtio1";
            this.ioTrig.title = "_/―";
            this.ioTrig.titleColor = System.Drawing.Color.DimGray;
            this.ioTrig.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // clMode
            // 
            this.clMode.backColor = System.Drawing.Color.Black;
            this.clMode.choiceType = AudioProcessor.RTChoice.ChoiceType.ListDefined;
            this.clMode.frontColor = System.Drawing.Color.DimGray;
            this.clMode.hideOnShrink = true;
            this.clMode.Location = new System.Drawing.Point(51, 76);
            this.clMode.Name = "clMode";
            this.clMode.numericMax = 100;
            this.clMode.numericMin = 0;
            this.clMode.offString = "off";
            this.clMode.selectedItem = -1;
            this.clMode.Size = new System.Drawing.Size(155, 20);
            this.clMode.TabIndex = 33;
            this.clMode.Text = "rtChoice1";
            this.clMode.title = "Mode";
            this.clMode.titleColor = System.Drawing.Color.DimGray;
            this.clMode.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clMode.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clMode.xdim = 100;
            // 
            // DataFFT
            // 
            this.Controls.Add(this.clMode);
            this.Controls.Add(this.ioTrig);
            this.Controls.Add(this.ioData);
            this.Controls.Add(this.bnNormalize);
            this.Controls.Add(this.clBlock);
            this.Controls.Add(this.clWin);
            this.Controls.Add(this.ioI);
            this.Name = "DataFFT";
            this.shrinkSize = new System.Drawing.Size(95, 57);
            this.shrinkTitle = "FFT";
            this.Size = new System.Drawing.Size(296, 103);
            this.title = "FFT";
            this.ResumeLayout(false);

        }

        int blockSize;
        FFTProcessor.WindowType fftWindow;
        bool normalize;

        FFTProcessor fft;
        private RTIO ioI;
        private RTChoice clWin;
        private RTChoice clBlock;
        int n;
        private RTButton bnNormalize;
        private RTIO ioData;
        private RTIO ioTrig;
        private RTChoice clMode;
        int[] blocks = { 64, 128, 256, 512, 1024, 2048, 4096, 8192 };
        public enum FFTOutMode
        {
            ReIm,
            Re,
            Im,
            SigPhase,
            Sig,
            Phase
        }
        public string[] slist = { "Re+Im", "Re", "Im", "Sig+Phs", "Sig", "Phase" };
        private FFTOutMode mode;

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
                    1000.0 / (((owner != null) ? owner.sampleRate : 48000) / blocks[i]))));
            clBlock.setEntries(bls);
            int bln = 0;
            for (int i = 1; i < blocks.Length; i++)
                if (blocks[i] == blockSize)
                    bln = i;
            clBlock.selectedItem = bln;
            blockSize = blocks[bln];
            List<RTChoice.RTDrawable> mds = new List<RTChoice.RTDrawable>();
            for (int i = 0; i < slist.Length; i++)
                mds.Add(new RTChoice.RTDrawableText(slist[i]));
            clMode.setEntries(mds);
            clMode.selectedItem = (int)mode;

            bnNormalize.buttonState = normalize;

            clWin.choiceStateChanged += ClWin_choiceStateChanged;
            clBlock.choiceStateChanged += ClBlock_choiceStateChanged;
            clMode.choiceStateChanged += ClMode_choiceStateChanged;
            bnNormalize.buttonStateChanged += BnNormalize_buttonStateChanged;

            processingType = ProcessingType.Processor;
        }


        public DataFFT() : base()
        {
            blockSize = 512;
            fftWindow = FFTProcessor.WindowType.Hann;
            normalize = false;
            mode = FFTOutMode.Sig;

            init();
        }

        public DataFFT(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            blockSize = src.ReadInt32();
            fftWindow = (FFTProcessor.WindowType)src.ReadInt32();
            mode = (FFTOutMode)src.ReadInt32();
            normalize = src.ReadBoolean();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write(blockSize);
            tgt.Write((int)fftWindow);
            tgt.Write((int)mode);
            tgt.Write(normalize);
        }

        private void ClMode_choiceStateChanged(object sender, EventArgs e)
        {
            mode = (FFTOutMode)clMode.selectedItem;
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
        private double[] energy;
        private double emax, rmax, imax;
        private double[] outArray;
        private int buffInFill;
        private double lastTrig = 0;

        private void processBlock(DataBuffer dbout)
        {
            if (buffInFill == blockSize)
            {
                if (fft == null)
                    fft = new FFTProcessor(FFTProcessor.ProcessorMode.Bidirectional, blockSize, owner.sampleRate, fftWindow);

                if (fftWindow != fft.windowType)
                    fft.windowType = fftWindow;

                fft.runFFT(ref buffIn, true, ref re, ref im);
                Array.Copy(buffIn, blockSize / 2, buffIn, 0, buffInFill - blockSize / 2);
                buffInFill -= blockSize / 2;

                // Process FFT Data
                if (normalize || (mode == FFTOutMode.Phase) || (mode == FFTOutMode.Sig) || (mode == FFTOutMode.SigPhase))
                {
                    // Must calculate Energy
                    if ((energy == null) || (energy.Length != re.Length))
                        energy = new double[re.Length];
                    for (int i = 0; i < re.Length; i++)
                        energy[i] = re[i] * re[i] + im[i] * im[i];
                    emax = energy[0];
                    rmax = re[0];
                    imax = im[0];
                    for (int i = 1; i < re.Length; i++)
                    {
                        if (energy[i] > emax) emax = energy[i];
                        if (re[i] > rmax) rmax = re[i];
                        if (im[i] > imax) imax = im[i];
                        if (re[i] < -rmax) rmax = -re[i];
                        if (im[i] < -imax) imax = -im[i];
                    }
                }
                switch (mode)
                {
                    case FFTOutMode.ReIm:
                        if ((outArray == null) || (outArray.Length != 2 * re.Length))
                            outArray = new double[2 * re.Length];
                        if (normalize)
                        {
                            double sf = 1;
                            if (emax > 0)
                                sf = 1.0 / Math.Sqrt(emax);
                            for (int i = 0; i < re.Length; i++)
                            {
                                outArray[2 * i] = re[i] * sf;
                                outArray[2 * i + 1] = im[i] * sf;
                            }
                        }
                        else
                        {
                            for (int i = 0; i < re.Length; i++)
                            {
                                outArray[2 * i] = re[i];
                                outArray[2 * i + 1] = im[i];
                            }
                        }
                        break;
                    case FFTOutMode.Re:
                    case FFTOutMode.Im:
                        if ((outArray == null) || (outArray.Length != re.Length))
                            outArray = new double[re.Length];
                        if (normalize)
                        {
                            double sf = 1;
                            if (mode == FFTOutMode.Re)
                            {
                                if (rmax > 0) sf = 1 / rmax;
                                for (int i = 0; i < re.Length; i++)
                                    outArray[i] = re[i] * sf;
                            }
                            else
                            {
                                if (imax > 0) sf = 1 / imax;
                                for (int i = 0; i < re.Length; i++)
                                    outArray[i] = im[i] * sf;
                            }
                        }
                        else
                        {
                            if (mode == FFTOutMode.Re)
                                Array.Copy(re, outArray, re.Length);
                            else
                                Array.Copy(im, outArray, re.Length);
                        }
                        break;
                    case FFTOutMode.Phase:
                        if ((outArray == null) || (outArray.Length != re.Length))
                            outArray = new double[re.Length];
                        for (int i = 0; i < re.Length; i++)
                            outArray[i] = Math.Atan2(im[i], re[i]);
                        break;
                    case FFTOutMode.Sig:
                        if ((outArray == null) || (outArray.Length != re.Length))
                            outArray = new double[re.Length];
                        if (normalize)
                        {
                            double sf = 1;
                            if (emax > 0)
                                sf = 1.0 / Math.Sqrt(emax);
                            for (int i = 0; i < re.Length; i++)
                                outArray[i] = Math.Sqrt(energy[i]) * sf;
                        }
                        else
                        {
                            for (int i = 0; i < re.Length; i++)
                                outArray[i] = Math.Sqrt(energy[i]);
                        }
                        break;
                    case FFTOutMode.SigPhase:
                        if ((outArray == null) || (outArray.Length != 2 * re.Length))
                            outArray = new double[2 * re.Length];
                        if (normalize)
                        {
                            double sf = 1;
                            if (emax > 0)
                                sf = 1.0 / Math.Sqrt(emax);
                            for (int i = 0; i < re.Length; i++)
                            {
                                outArray[2 * i] = Math.Sqrt(energy[i]) * sf;
                                outArray[2 * i + 1] = Math.Atan2(im[i], re[i]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < re.Length; i++)
                            {
                                outArray[2 * i] = Math.Sqrt(energy[i]);
                                outArray[2 * i + 1] = Math.Atan2(im[i], re[i]);
                            }
                        }
                        break;
                }
                if (dbout != null)
                {
                    dbout.initialize(outArray.Length);
                    dbout.set(outArray);
                }
            }
        }

        public override void tick()
        {

            if (!_active)
                return;

            SignalBuffer dbin = getSignalInputBuffer(ioI);
            SignalBuffer dbTrig = getSignalInputBuffer(ioTrig);
            DataBuffer dbout = getDataOutputBuffer(ioData);

            if (dbin == null)
                return;

            if ((buffIn == null) || (buffIn.Length != blockSize))
            {
                buffIn = new double[blockSize];
                re = new double[blockSize / 2];
                im = new double[blockSize / 2];
                buffInFill = 0;
                fft = null;
            }
            if ((fft != null) && (fft.windowType != fftWindow))
                fft = new FFTProcessor(FFTProcessor.ProcessorMode.Bidirectional, blockSize, owner.sampleRate, fftWindow);

            if (dbTrig != null)
            { // Triggered mode
                int trigger = -1;
                for (int i = 0; i < owner.blockSize; i++)
                {
                    if ((dbTrig.data[i] > 0) && (lastTrig <= 0))
                        trigger = i;
                    lastTrig = dbTrig.data[i];
                }
                if (trigger >= 0)
                {
                    // Triggered somewhere in this block
                    buffInFill = 0;
                }
            }
            if (buffInFill + owner.blockSize <= blockSize)
            {
                Array.Copy(dbin.data, 0, buffIn, buffInFill, owner.blockSize);
                buffInFill += owner.blockSize;
            } else
            {
                // Going to fill it
                int rem = blockSize - buffInFill;
                Array.Copy(dbin.data, 0, buffIn, buffInFill, rem);
                buffInFill += rem;
                processBlock(dbout);
                buffInFill = 0;
                Array.Copy(dbin.data, rem, buffIn, 0, owner.blockSize - rem);
                buffInFill += owner.blockSize - rem;
            }
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Data", "FFT" }; }
            public override RTForm Instantiate() { return new DataFFT(); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
        }



    }


}
