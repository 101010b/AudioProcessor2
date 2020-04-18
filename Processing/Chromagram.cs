using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.Processing
{
    class Chromagram : RTForm
    {

        public void InitializeComponent()
        {
            this.dlF = new AudioProcessor.RTDial();
            this.ioI = new AudioProcessor.RTIO();
            this.clWin = new AudioProcessor.RTChoice();
            this.ioB = new AudioProcessor.RTIO();
            this.ioAis = new AudioProcessor.RTIO();
            this.ioA = new AudioProcessor.RTIO();
            this.ioGis = new AudioProcessor.RTIO();
            this.ioG = new AudioProcessor.RTIO();
            this.ioFis = new AudioProcessor.RTIO();
            this.ioC = new AudioProcessor.RTIO();
            this.ioCis = new AudioProcessor.RTIO();
            this.ioD = new AudioProcessor.RTIO();
            this.ioDis = new AudioProcessor.RTIO();
            this.ioE = new AudioProcessor.RTIO();
            this.ioF = new AudioProcessor.RTIO();
            this.clBlock = new AudioProcessor.RTChoice();
            this.SuspendLayout();
            // 
            // dlF
            // 
            this.dlF.dialColor = System.Drawing.Color.Silver;
            this.dlF.dialDiameter = 50D;
            this.dlF.dialMarkColor = System.Drawing.Color.Red;
            this.dlF.format = "F0";
            this.dlF.Location = new System.Drawing.Point(72, 21);
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
            this.ioI.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // clWin
            // 
            this.clWin.backColor = System.Drawing.Color.Black;
            this.clWin.frontColor = System.Drawing.Color.DimGray;
            this.clWin.Location = new System.Drawing.Point(11, 109);
            this.clWin.Name = "clWin";
            this.clWin.selectedItem = -1;
            this.clWin.Size = new System.Drawing.Size(162, 20);
            this.clWin.TabIndex = 15;
            this.clWin.Text = "rtChoice1";
            this.clWin.title = "Window";
            this.clWin.titleColor = System.Drawing.Color.DimGray;
            this.clWin.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clWin.xdim = 100;
            // 
            // ioB
            // 
            this.ioB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioB.contactBackColor = System.Drawing.Color.Black;
            this.ioB.contactColor = System.Drawing.Color.DimGray;
            this.ioB.contactHighlightColor = System.Drawing.Color.Red;
            this.ioB.highlighted = false;
            this.ioB.Location = new System.Drawing.Point(179, 30);
            this.ioB.Name = "ioB";
            this.ioB.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioB.showTitle = true;
            this.ioB.Size = new System.Drawing.Size(46, 20);
            this.ioB.TabIndex = 16;
            this.ioB.Text = "rtio1";
            this.ioB.title = "B";
            this.ioB.titleColor = System.Drawing.Color.DimGray;
            this.ioB.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioAis
            // 
            this.ioAis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioAis.contactBackColor = System.Drawing.Color.Black;
            this.ioAis.contactColor = System.Drawing.Color.DimGray;
            this.ioAis.contactHighlightColor = System.Drawing.Color.Red;
            this.ioAis.highlighted = false;
            this.ioAis.Location = new System.Drawing.Point(179, 56);
            this.ioAis.Name = "ioAis";
            this.ioAis.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioAis.showTitle = true;
            this.ioAis.Size = new System.Drawing.Size(46, 20);
            this.ioAis.TabIndex = 17;
            this.ioAis.Text = "rtio2";
            this.ioAis.title = "A#";
            this.ioAis.titleColor = System.Drawing.Color.DimGray;
            this.ioAis.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioAis.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioA
            // 
            this.ioA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioA.contactBackColor = System.Drawing.Color.Black;
            this.ioA.contactColor = System.Drawing.Color.DimGray;
            this.ioA.contactHighlightColor = System.Drawing.Color.Red;
            this.ioA.highlighted = false;
            this.ioA.Location = new System.Drawing.Point(179, 82);
            this.ioA.Name = "ioA";
            this.ioA.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioA.showTitle = true;
            this.ioA.Size = new System.Drawing.Size(46, 20);
            this.ioA.TabIndex = 18;
            this.ioA.Text = "rtio3";
            this.ioA.title = "A";
            this.ioA.titleColor = System.Drawing.Color.DimGray;
            this.ioA.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioA.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioGis
            // 
            this.ioGis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioGis.contactBackColor = System.Drawing.Color.Black;
            this.ioGis.contactColor = System.Drawing.Color.DimGray;
            this.ioGis.contactHighlightColor = System.Drawing.Color.Red;
            this.ioGis.highlighted = false;
            this.ioGis.Location = new System.Drawing.Point(179, 108);
            this.ioGis.Name = "ioGis";
            this.ioGis.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioGis.showTitle = true;
            this.ioGis.Size = new System.Drawing.Size(46, 20);
            this.ioGis.TabIndex = 19;
            this.ioGis.Text = "rtio4";
            this.ioGis.title = "G#";
            this.ioGis.titleColor = System.Drawing.Color.DimGray;
            this.ioGis.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioGis.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioG
            // 
            this.ioG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioG.contactBackColor = System.Drawing.Color.Black;
            this.ioG.contactColor = System.Drawing.Color.DimGray;
            this.ioG.contactHighlightColor = System.Drawing.Color.Red;
            this.ioG.highlighted = false;
            this.ioG.Location = new System.Drawing.Point(179, 134);
            this.ioG.Name = "ioG";
            this.ioG.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioG.showTitle = true;
            this.ioG.Size = new System.Drawing.Size(46, 20);
            this.ioG.TabIndex = 20;
            this.ioG.Text = "rtio5";
            this.ioG.title = "G";
            this.ioG.titleColor = System.Drawing.Color.DimGray;
            this.ioG.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioG.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioFis
            // 
            this.ioFis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioFis.contactBackColor = System.Drawing.Color.Black;
            this.ioFis.contactColor = System.Drawing.Color.DimGray;
            this.ioFis.contactHighlightColor = System.Drawing.Color.Red;
            this.ioFis.highlighted = false;
            this.ioFis.Location = new System.Drawing.Point(179, 160);
            this.ioFis.Name = "ioFis";
            this.ioFis.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioFis.showTitle = true;
            this.ioFis.Size = new System.Drawing.Size(46, 20);
            this.ioFis.TabIndex = 21;
            this.ioFis.Text = "rtio6";
            this.ioFis.title = "F#";
            this.ioFis.titleColor = System.Drawing.Color.DimGray;
            this.ioFis.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioFis.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioC
            // 
            this.ioC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioC.contactBackColor = System.Drawing.Color.Black;
            this.ioC.contactColor = System.Drawing.Color.DimGray;
            this.ioC.contactHighlightColor = System.Drawing.Color.Red;
            this.ioC.highlighted = false;
            this.ioC.Location = new System.Drawing.Point(179, 316);
            this.ioC.Name = "ioC";
            this.ioC.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioC.showTitle = true;
            this.ioC.Size = new System.Drawing.Size(46, 20);
            this.ioC.TabIndex = 27;
            this.ioC.Text = "rtio6";
            this.ioC.title = "C";
            this.ioC.titleColor = System.Drawing.Color.DimGray;
            this.ioC.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioC.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioCis
            // 
            this.ioCis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioCis.contactBackColor = System.Drawing.Color.Black;
            this.ioCis.contactColor = System.Drawing.Color.DimGray;
            this.ioCis.contactHighlightColor = System.Drawing.Color.Red;
            this.ioCis.highlighted = false;
            this.ioCis.Location = new System.Drawing.Point(179, 290);
            this.ioCis.Name = "ioCis";
            this.ioCis.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioCis.showTitle = true;
            this.ioCis.Size = new System.Drawing.Size(46, 20);
            this.ioCis.TabIndex = 26;
            this.ioCis.Text = "rtio5";
            this.ioCis.title = "C#";
            this.ioCis.titleColor = System.Drawing.Color.DimGray;
            this.ioCis.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioCis.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioD
            // 
            this.ioD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioD.contactBackColor = System.Drawing.Color.Black;
            this.ioD.contactColor = System.Drawing.Color.DimGray;
            this.ioD.contactHighlightColor = System.Drawing.Color.Red;
            this.ioD.highlighted = false;
            this.ioD.Location = new System.Drawing.Point(179, 264);
            this.ioD.Name = "ioD";
            this.ioD.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioD.showTitle = true;
            this.ioD.Size = new System.Drawing.Size(46, 20);
            this.ioD.TabIndex = 25;
            this.ioD.Text = "rtio4";
            this.ioD.title = "D";
            this.ioD.titleColor = System.Drawing.Color.DimGray;
            this.ioD.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioD.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioDis
            // 
            this.ioDis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioDis.contactBackColor = System.Drawing.Color.Black;
            this.ioDis.contactColor = System.Drawing.Color.DimGray;
            this.ioDis.contactHighlightColor = System.Drawing.Color.Red;
            this.ioDis.highlighted = false;
            this.ioDis.Location = new System.Drawing.Point(179, 238);
            this.ioDis.Name = "ioDis";
            this.ioDis.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioDis.showTitle = true;
            this.ioDis.Size = new System.Drawing.Size(46, 20);
            this.ioDis.TabIndex = 24;
            this.ioDis.Text = "rtio3";
            this.ioDis.title = "D#";
            this.ioDis.titleColor = System.Drawing.Color.DimGray;
            this.ioDis.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioDis.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioE
            // 
            this.ioE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioE.contactBackColor = System.Drawing.Color.Black;
            this.ioE.contactColor = System.Drawing.Color.DimGray;
            this.ioE.contactHighlightColor = System.Drawing.Color.Red;
            this.ioE.highlighted = false;
            this.ioE.Location = new System.Drawing.Point(179, 212);
            this.ioE.Name = "ioE";
            this.ioE.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioE.showTitle = true;
            this.ioE.Size = new System.Drawing.Size(46, 20);
            this.ioE.TabIndex = 23;
            this.ioE.Text = "rtio2";
            this.ioE.title = "E";
            this.ioE.titleColor = System.Drawing.Color.DimGray;
            this.ioE.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioE.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioF
            // 
            this.ioF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioF.contactBackColor = System.Drawing.Color.Black;
            this.ioF.contactColor = System.Drawing.Color.DimGray;
            this.ioF.contactHighlightColor = System.Drawing.Color.Red;
            this.ioF.highlighted = false;
            this.ioF.Location = new System.Drawing.Point(179, 186);
            this.ioF.Name = "ioF";
            this.ioF.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioF.showTitle = true;
            this.ioF.Size = new System.Drawing.Size(46, 20);
            this.ioF.TabIndex = 22;
            this.ioF.Text = "rtio1";
            this.ioF.title = "F";
            this.ioF.titleColor = System.Drawing.Color.DimGray;
            this.ioF.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioF.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // clBlock
            // 
            this.clBlock.backColor = System.Drawing.Color.Black;
            this.clBlock.frontColor = System.Drawing.Color.DimGray;
            this.clBlock.Location = new System.Drawing.Point(11, 135);
            this.clBlock.Name = "clBlock";
            this.clBlock.selectedItem = -1;
            this.clBlock.Size = new System.Drawing.Size(162, 20);
            this.clBlock.TabIndex = 28;
            this.clBlock.Text = "rtChoice1";
            this.clBlock.title = "Block";
            this.clBlock.titleColor = System.Drawing.Color.DimGray;
            this.clBlock.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clBlock.xdim = 100;
            // 
            // Chromagram
            // 
            this.Controls.Add(this.clBlock);
            this.Controls.Add(this.ioC);
            this.Controls.Add(this.ioCis);
            this.Controls.Add(this.ioD);
            this.Controls.Add(this.ioDis);
            this.Controls.Add(this.ioE);
            this.Controls.Add(this.ioF);
            this.Controls.Add(this.ioFis);
            this.Controls.Add(this.ioG);
            this.Controls.Add(this.ioGis);
            this.Controls.Add(this.ioA);
            this.Controls.Add(this.ioAis);
            this.Controls.Add(this.ioB);
            this.Controls.Add(this.clWin);
            this.Controls.Add(this.ioI);
            this.Controls.Add(this.dlF);
            this.Name = "Chromagram";
            this.shrinkSize = new System.Drawing.Size(93, 341);
            this.shrinkTitle = "CG";
            this.Size = new System.Drawing.Size(225, 341);
            this.title = "Chromagram";
            this.ResumeLayout(false);

        }

        int blockSize;
        FFTProcessor.WindowType fftWindow;


        FFTProcessor fft;

        double f;
        private RTDial dlF;
        private RTIO ioI;
        private RTChoice clWin;
        private RTIO ioB;
        private RTIO ioAis;
        private RTIO ioA;
        private RTIO ioGis;
        private RTIO ioG;
        private RTIO ioFis;
        private RTIO ioC;
        private RTIO ioCis;
        private RTIO ioD;
        private RTIO ioDis;
        private RTIO ioE;
        private RTIO ioF;
        private RTChoice clBlock;
        int n;

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
                if (blocks[i] == bln)
                    bln = i;
            clBlock.selectedItem = bln;
            blockSize = blocks[bln];

            dlF.val = f;

            clWin.choiceStateChanged += ClWin_choiceStateChanged;
            clBlock.choiceStateChanged += ClBlock_choiceStateChanged;
            dlF.valueChanged += DlF_valueChanged;

            processingType = ProcessingType.Processor;
        }

        private void ClBlock_choiceStateChanged(object sender, EventArgs e)
        {
            blockSize = blocks[clBlock.selectedItem];
        }

        public Chromagram() : base()
        {
            blockSize = 1024;
            f = 55;
            fftWindow = FFTProcessor.WindowType.Hann;

            init();
        }

        public Chromagram(SystemPanel _owner, BinaryReader src) : base(_owner, src)
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

            DataBuffer dbin = getInputBuffer(ioI);
            DataBuffer[] dbout = new DataBuffer[12];
            dbout[0] = getOutputBuffer(ioC);
            dbout[1] = getOutputBuffer(ioCis);
            dbout[2] = getOutputBuffer(ioD);
            dbout[3] = getOutputBuffer(ioDis);
            dbout[4] = getOutputBuffer(ioE);
            dbout[5] = getOutputBuffer(ioF);
            dbout[6] = getOutputBuffer(ioFis);
            dbout[7] = getOutputBuffer(ioG);
            dbout[8] = getOutputBuffer(ioGis);
            dbout[9] = getOutputBuffer(ioA);
            dbout[10] = getOutputBuffer(ioAis);
            dbout[11] = getOutputBuffer(ioB);

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
            }
            if ((fft != null) && (fft.windowType != fftWindow))
                fft = new FFTProcessor(FFTProcessor.ProcessorMode.Bidirectional, blockSize, owner.sampleRate, fftWindow);


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

                // Process FFT Data
                double f0 = (double)owner.sampleRate / blockSize;
                double[] on = new double[12];
                double emax = 0;
                double emin = 0;
                for (int i=0;i<12;i++)
                {
                    double ft = f * Math.Pow(2, (double)i / 12);
                    double r = 0;
                    int n = 0;
                    while (ft < owner.sampleRate/2)
                    {
                        int bin = (int) Math.Floor(ft / f0 + 0.5);
                        if ((bin > 0) && (bin < blockSize))
                        {
                            r = r + re[bin] * re[bin] + im[bin] * im[bin];
                            n++;
                        }
                        if ((bin - 1 > 0) && (bin - 1 < blockSize))
                        {
                            r = r + re[bin - 1] * re[bin - 1] + im[bin - 1] * im[bin - 1];
                            n++;
                        }
                        if ((bin + 1 > 0) && (bin + 1 < blockSize))
                        {
                            r = r + re[bin + 1] * re[bin + 1] + im[bin + 1] * im[bin + 1];
                            n++;
                        }
                        ft = ft * 2;
                    }
                    r = Math.Sqrt(r / n);
                    if (i == 0)
                        emax = emin = r;
                    else
                    {
                        if (r < emin) emin = r;
                        if (r > emax) emax = r;
                    }
                    on[i] = r;
                }
                if (emax == emin) emax = emin + 1;
                for (int i=0;i<12;i++)
                    if (dbout[i] != null)
                        dbout[i].SetTo((on[i]-emin)/(emax-emin));
            }
            /*
            for (int i = -3; i <= 3; i++)
            {
                if (dbout[i + 3] != null)
                    dbout[i + 3].SetTo(oval[i + 3]);
            }
            */
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Chromagram" }; }
            public override RTForm Instantiate() { return new Chromagram(); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
        }



    }


}
