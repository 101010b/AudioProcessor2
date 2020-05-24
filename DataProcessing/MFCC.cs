using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.DataProcessing
{
    class MFCC : RTForm
    {

        public void InitializeComponent()
        {
            this.ioI = new AudioProcessor.RTIO();
            this.bnNormalize = new AudioProcessor.RTButton();
            this.ioData = new AudioProcessor.RTIO();
            this.clCoeffs = new AudioProcessor.RTChoice();
            this.SuspendLayout();
            // 
            // ioI
            // 
            this.ioI.contactBackColor = System.Drawing.Color.Black;
            this.ioI.contactColor = System.Drawing.Color.DimGray;
            this.ioI.contactHighlightColor = System.Drawing.Color.Red;
            this.ioI.highlighted = false;
            this.ioI.IOtype = AudioProcessor.RTIO.ProcessingIOType.DataInput;
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
            this.bnNormalize.Location = new System.Drawing.Point(145, 17);
            this.bnNormalize.Name = "bnNormalize";
            this.bnNormalize.offText = "Off";
            this.bnNormalize.onText = "On";
            this.bnNormalize.Size = new System.Drawing.Size(72, 45);
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
            this.ioData.Location = new System.Drawing.Point(228, 30);
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
            // clCoeffs
            // 
            this.clCoeffs.backColor = System.Drawing.Color.Black;
            this.clCoeffs.choiceType = AudioProcessor.RTChoice.ChoiceType.Numeric;
            this.clCoeffs.frontColor = System.Drawing.Color.DimGray;
            this.clCoeffs.Location = new System.Drawing.Point(32, 30);
            this.clCoeffs.Name = "clCoeffs";
            this.clCoeffs.numericMax = 100;
            this.clCoeffs.numericMin = 10;
            this.clCoeffs.offString = "off";
            this.clCoeffs.selectedItem = 10;
            this.clCoeffs.Size = new System.Drawing.Size(105, 20);
            this.clCoeffs.TabIndex = 33;
            this.clCoeffs.Text = "rtChoice1";
            this.clCoeffs.title = "Coeffs";
            this.clCoeffs.titleColor = System.Drawing.Color.DimGray;
            this.clCoeffs.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clCoeffs.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clCoeffs.xdim = 50;
            // 
            // MFCC
            // 
            this.Controls.Add(this.clCoeffs);
            this.Controls.Add(this.ioData);
            this.Controls.Add(this.bnNormalize);
            this.Controls.Add(this.ioI);
            this.Name = "MFCC";
            this.shrinkSize = new System.Drawing.Size(78, 67);
            this.shrinkTitle = "M";
            this.Size = new System.Drawing.Size(249, 67);
            this.title = "MFCC";
            this.ResumeLayout(false);

        }

        bool normalize;
        private RTIO ioI;
        private RTButton bnNormalize;
        private RTIO ioData;
        private RTChoice clCoeffs;
        int coeffs;

        private void init()
        {
            InitializeComponent();

            clCoeffs.selectedItem = coeffs - 10;

            bnNormalize.buttonState = normalize;

            clCoeffs.choiceStateChanged += ClCoeffs_choiceStateChanged;
            bnNormalize.buttonStateChanged += BnNormalize_buttonStateChanged;

            processingType = ProcessingType.Processor;
        }


        public MFCC() : base()
        {
            coeffs = 20;

            init();
        }

        public MFCC(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            coeffs = src.ReadInt32();
            normalize = src.ReadBoolean();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write(coeffs);
            tgt.Write(normalize);
        }

        private void BnNormalize_buttonStateChanged(object sender, EventArgs e)
        {
            normalize = bnNormalize.buttonState;
        }

        private void ClCoeffs_choiceStateChanged(object sender, EventArgs e)
        {
            coeffs = clCoeffs.selectedItem + 10;
        }


        double[] mels;
        double[] mfccs;

        public override void tick()
        {

            if (!_active)
                return;

            DataBuffer dbin = getDataInputBuffer(ioI);
            DataBuffer dbout = getDataOutputBuffer(ioData);

            if (dbin == null)
                return;

            if ((dbin == null) || (dbin.size <= 0))
                return;

            if ((mels == null) || (mels.Length > dbin.size))
                mels = new double[dbin.size];
            Array.Copy(dbin.data, mels, dbin.size);

            if ((mfccs == null) || (coeffs != mfccs.Length))
                mfccs = new double[coeffs];

            // Calculate MFCCs
            int melcoeffs = dbin.size;
            for (int i=0;i<coeffs;i++)
            {
                double mfcc = 0;
                for (int k = 0; k < melcoeffs; k++)
                    mfcc += mels[k] * Math.Cos(i * k * Math.PI / (melcoeffs-1));
                    // mfcc += mels[k] * Math.Cos(i * (1.0 + k - 0.5) * Math.PI / melcoeffs);
                mfccs[i] = mfcc;
            }

            if (normalize)
            {
                double max = Math.Abs(mfccs[0]);
                for (int i=1;i<coeffs;i++)
                {
                    double ax = Math.Abs(mfccs[i]);
                    if (ax > max) max = ax;
                }
                if (max == 0) max = 1;
                for (int i = 0; i < coeffs; i++)
                    mfccs[i] = mfccs[i] / max;
            }
                
            if (dbout != null)
            {
                dbout.initialize(coeffs);
                dbout.set(mfccs);
            }
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Data", "MFCC" }; }
            public override RTForm Instantiate() { return new MFCC(); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
        }



    }


}
