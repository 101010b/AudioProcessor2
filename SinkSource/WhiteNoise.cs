using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.SinkSource
{
    class WhiteNoise : RTForm
    {
        public void InitializeComponent()
        {
            this.ioOut = new AudioProcessor.RTIO();
            this.dlAmp = new AudioProcessor.RTDial();
            this.ioAM = new AudioProcessor.RTIO();
            this.bnANoOfs = new AudioProcessor.RTButton();
            this.bnRMSAMP = new AudioProcessor.RTButton();
            this.SuspendLayout();
            // 
            // ioOut
            // 
            this.ioOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut.contactBackColor = System.Drawing.Color.Black;
            this.ioOut.contactColor = System.Drawing.Color.DimGray;
            this.ioOut.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut.highlighted = false;
            this.ioOut.Location = new System.Drawing.Point(134, 33);
            this.ioOut.Name = "ioOut";
            this.ioOut.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut.showTitle = true;
            this.ioOut.Size = new System.Drawing.Size(46, 20);
            this.ioOut.TabIndex = 7;
            this.ioOut.Text = "rtio3";
            this.ioOut.title = "Out";
            this.ioOut.titleColor = System.Drawing.Color.DimGray;
            this.ioOut.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOut.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // dlAmp
            // 
            this.dlAmp.dialColor = System.Drawing.Color.Silver;
            this.dlAmp.dialDiameter = 50D;
            this.dlAmp.dialMarkColor = System.Drawing.Color.Red;
            this.dlAmp.format = "F1";
            this.dlAmp.Location = new System.Drawing.Point(52, 18);
            this.dlAmp.logScale = false;
            this.dlAmp.maxVal = 100D;
            this.dlAmp.minVal = -100D;
            this.dlAmp.Name = "dlAmp";
            this.dlAmp.scaleColor = System.Drawing.Color.Gold;
            this.dlAmp.showScale = true;
            this.dlAmp.showTitle = false;
            this.dlAmp.showValue = true;
            this.dlAmp.Size = new System.Drawing.Size(80, 80);
            this.dlAmp.TabIndex = 6;
            this.dlAmp.Text = "rtDial2";
            this.dlAmp.title = "Amplitude";
            this.dlAmp.titleColor = System.Drawing.Color.DimGray;
            this.dlAmp.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlAmp.unit = "dB";
            this.dlAmp.val = -20D;
            this.dlAmp.valueColor = System.Drawing.Color.DimGray;
            this.dlAmp.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioAM
            // 
            this.ioAM.contactBackColor = System.Drawing.Color.Black;
            this.ioAM.contactColor = System.Drawing.Color.DimGray;
            this.ioAM.contactHighlightColor = System.Drawing.Color.Red;
            this.ioAM.highlighted = false;
            this.ioAM.Location = new System.Drawing.Point(0, 33);
            this.ioAM.Name = "ioAM";
            this.ioAM.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioAM.showTitle = true;
            this.ioAM.Size = new System.Drawing.Size(46, 20);
            this.ioAM.TabIndex = 5;
            this.ioAM.Text = "rtio2";
            this.ioAM.title = "AM";
            this.ioAM.titleColor = System.Drawing.Color.DimGray;
            this.ioAM.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioAM.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // bnANoOfs
            // 
            this.bnANoOfs.buttonDim = new System.Drawing.Size(30, 15);
            this.bnANoOfs.buttonState = false;
            this.bnANoOfs.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bnANoOfs.fillOffColor = System.Drawing.Color.Green;
            this.bnANoOfs.fillOnColor = System.Drawing.Color.Navy;
            this.bnANoOfs.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnANoOfs.frameOffColor = System.Drawing.Color.Lime;
            this.bnANoOfs.frameOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnANoOfs.Location = new System.Drawing.Point(15, 59);
            this.bnANoOfs.Name = "bnANoOfs";
            this.bnANoOfs.offText = "+1";
            this.bnANoOfs.onText = "0";
            this.bnANoOfs.Size = new System.Drawing.Size(31, 16);
            this.bnANoOfs.TabIndex = 21;
            this.bnANoOfs.Text = "rtButton2";
            this.bnANoOfs.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnANoOfs.textOffColor = System.Drawing.Color.Lime;
            this.bnANoOfs.textOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnANoOfs.title = "Button";
            this.bnANoOfs.titleColor = System.Drawing.Color.DimGray;
            this.bnANoOfs.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnANoOfs.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // bnRMSAMP
            // 
            this.bnRMSAMP.buttonDim = new System.Drawing.Size(30, 15);
            this.bnRMSAMP.buttonState = false;
            this.bnRMSAMP.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bnRMSAMP.fillOffColor = System.Drawing.Color.Green;
            this.bnRMSAMP.fillOnColor = System.Drawing.Color.Navy;
            this.bnRMSAMP.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnRMSAMP.frameOffColor = System.Drawing.Color.Lime;
            this.bnRMSAMP.frameOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnRMSAMP.Location = new System.Drawing.Point(76, 18);
            this.bnRMSAMP.Name = "bnRMSAMP";
            this.bnRMSAMP.offText = "RMS";
            this.bnRMSAMP.onText = "Amp";
            this.bnRMSAMP.Size = new System.Drawing.Size(31, 16);
            this.bnRMSAMP.TabIndex = 20;
            this.bnRMSAMP.Text = "rtButton1";
            this.bnRMSAMP.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnRMSAMP.textOffColor = System.Drawing.Color.Lime;
            this.bnRMSAMP.textOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnRMSAMP.title = "Button";
            this.bnRMSAMP.titleColor = System.Drawing.Color.DimGray;
            this.bnRMSAMP.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnRMSAMP.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // WhiteNoise
            // 
            this.canShrink = false;
            this.Controls.Add(this.bnANoOfs);
            this.Controls.Add(this.bnRMSAMP);
            this.Controls.Add(this.ioOut);
            this.Controls.Add(this.dlAmp);
            this.Controls.Add(this.ioAM);
            this.Name = "WhiteNoise";
            this.shrinkTitle = "White Noise";
            this.Size = new System.Drawing.Size(180, 104);
            this.title = "White Noise";
            this.ResumeLayout(false);

        }

        private double genAmp;
        private bool inAmp;
        private bool AMNoOfs;

        private RTIO ioOut;
        private RTDial dlAmp;
        private RTIO ioAM;
        private RTButton bnANoOfs;
        private RTButton bnRMSAMP;
        Random rng;

        private void init()
        {
            InitializeComponent();

            rng = new Random();

            dlAmp.val = genAmp;
            bnRMSAMP.buttonState = inAmp;
            bnANoOfs.buttonState = AMNoOfs;

            dlAmp.valueChanged += DlAmp_valueChanged;
            bnRMSAMP.buttonStateChanged += BnRMSAMP_buttonStateChanged;
            bnANoOfs.buttonStateChanged += BnANoOfs_buttonStateChanged;
            
            processingType = ProcessingType.Source;

        }

        public WhiteNoise() : base()
        {
            genAmp = -20;
            inAmp = false;
            AMNoOfs = false;
            init();
        }

        public WhiteNoise(SystemPanel _owner, BinaryReader src):base(_owner, src)
        {
            genAmp = src.ReadDouble();
            inAmp = src.ReadBoolean();
            AMNoOfs = src.ReadBoolean();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(genAmp);
            tgt.Write(inAmp);
            tgt.Write(AMNoOfs);
        }


        private void DlAmp_valueChanged(object sender, EventArgs e)
        {
            genAmp = dlAmp.val;
        }

        private void BnANoOfs_buttonStateChanged(object sender, EventArgs e)
        {
            AMNoOfs = bnANoOfs.buttonState;
        }

        private void BnRMSAMP_buttonStateChanged(object sender, EventArgs e)
        {
            inAmp = bnRMSAMP.buttonState;
        }

        private double func()
        {
            return rng.NextDouble() * 2.0 - 1.0;
        }

        public override void tick()
        {
            if (!_active)
                return;
            DataBuffer dbout = getOutputBuffer(ioOut);
            if (dbout == null)
                return;

            DataBuffer dbAM = getInputBuffer(ioAM);
            double amp0;
            if (inAmp)
                amp0 = Math.Pow(10.0, genAmp / 20.0);
            else
                amp0 = Math.Pow(10.0, (genAmp + 4.8) / 20.0);

            if (dbAM != null)
            {
                if (AMNoOfs)
                {
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = amp0 * dbAM.data[i] * func();
                }
                else
                {
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = amp0 * (1 + dbAM.data[i]) * func();
                }
            }
            else
            {
                for (int i = 0; i < owner.blockSize; i++)
                    dbout.data[i] = amp0 * func();
            }
        }

        class RegisterClass : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Generator", "White Noise" }; }
            public override RTForm Instantiate() { return new WhiteNoise(); }
        }
        public static void Register(List<RTObjectReference> l) { l.Add(new RegisterClass()); }


    }
}
