using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.Processing
{
    class Echo : RTForm
    {
        public void InitializeComponent()
        {
            this.ioI = new AudioProcessor.RTIO();
            this.ioO = new AudioProcessor.RTIO();
            this.dlDelay = new AudioProcessor.RTDial();
            this.dlGain = new AudioProcessor.RTDial();
            this.bnRecursive = new AudioProcessor.RTButton();
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
            this.ioO.Location = new System.Drawing.Point(290, 45);
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
            // dlDelay
            // 
            this.dlDelay.dialColor = System.Drawing.Color.Silver;
            this.dlDelay.dialDiameter = 50D;
            this.dlDelay.dialMarkColor = System.Drawing.Color.Red;
            this.dlDelay.format = "F1";
            this.dlDelay.Location = new System.Drawing.Point(27, 21);
            this.dlDelay.logScale = true;
            this.dlDelay.maxVal = 5000D;
            this.dlDelay.minVal = 0.1D;
            this.dlDelay.Name = "dlDelay";
            this.dlDelay.scaleColor = System.Drawing.Color.Gold;
            this.dlDelay.showScale = true;
            this.dlDelay.showTitle = true;
            this.dlDelay.showValue = true;
            this.dlDelay.Size = new System.Drawing.Size(80, 85);
            this.dlDelay.TabIndex = 2;
            this.dlDelay.Text = "rtDial1";
            this.dlDelay.title = "Delay";
            this.dlDelay.titleColor = System.Drawing.Color.DimGray;
            this.dlDelay.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlDelay.unit = "ms";
            this.dlDelay.val = 100D;
            this.dlDelay.valueColor = System.Drawing.Color.DimGray;
            this.dlDelay.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dlGain
            // 
            this.dlGain.dialColor = System.Drawing.Color.Silver;
            this.dlGain.dialDiameter = 50D;
            this.dlGain.dialMarkColor = System.Drawing.Color.Red;
            this.dlGain.format = "F1";
            this.dlGain.Location = new System.Drawing.Point(113, 21);
            this.dlGain.logScale = false;
            this.dlGain.maxVal = 20D;
            this.dlGain.minVal = -60D;
            this.dlGain.Name = "dlGain";
            this.dlGain.scaleColor = System.Drawing.Color.Gold;
            this.dlGain.showScale = true;
            this.dlGain.showTitle = true;
            this.dlGain.showValue = true;
            this.dlGain.Size = new System.Drawing.Size(80, 85);
            this.dlGain.TabIndex = 12;
            this.dlGain.Text = "rtDial2";
            this.dlGain.title = "Gain";
            this.dlGain.titleColor = System.Drawing.Color.DimGray;
            this.dlGain.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlGain.unit = "dB";
            this.dlGain.val = -20D;
            this.dlGain.valueColor = System.Drawing.Color.DimGray;
            this.dlGain.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // bnRecursive
            // 
            this.bnRecursive.buttonDim = new System.Drawing.Size(30, 15);
            this.bnRecursive.buttonState = true;
            this.bnRecursive.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bnRecursive.fillOffColor = System.Drawing.Color.Black;
            this.bnRecursive.fillOnColor = System.Drawing.Color.DarkRed;
            this.bnRecursive.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnRecursive.frameOffColor = System.Drawing.Color.DimGray;
            this.bnRecursive.frameOnColor = System.Drawing.Color.Red;
            this.bnRecursive.Location = new System.Drawing.Point(199, 35);
            this.bnRecursive.Name = "bnRecursive";
            this.bnRecursive.offText = "Off";
            this.bnRecursive.onText = "On";
            this.bnRecursive.Size = new System.Drawing.Size(82, 53);
            this.bnRecursive.TabIndex = 13;
            this.bnRecursive.Text = "rtButton1";
            this.bnRecursive.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnRecursive.textOffColor = System.Drawing.Color.DimGray;
            this.bnRecursive.textOnColor = System.Drawing.Color.Red;
            this.bnRecursive.title = "Recursive";
            this.bnRecursive.titleColor = System.Drawing.Color.DimGray;
            this.bnRecursive.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnRecursive.titlePos = AudioProcessor.RTButton.RTTitlePos.Above;
            // 
            // Echo
            // 
            this.Controls.Add(this.bnRecursive);
            this.Controls.Add(this.dlGain);
            this.Controls.Add(this.dlDelay);
            this.Controls.Add(this.ioO);
            this.Controls.Add(this.ioI);
            this.Name = "Echo";
            this.shrinkSize = new System.Drawing.Size(118, 117);
            this.shrinkTitle = "Echo";
            this.Size = new System.Drawing.Size(311, 117);
            this.title = "Echo";
            this.ResumeLayout(false);

        }

        DynamicDelay dd;

        double delay;
        double gain;
        bool recursive;

        private RTIO ioI;
        private RTIO ioO;
        private RTDial dlDelay;
        private RTDial dlGain;
        private RTButton bnRecursive;

        private void init()
        {
            InitializeComponent();

            dlDelay.val = delay * 1000;
            dlGain.val = 20.0 * Math.Log10(gain);
            bnRecursive.buttonState = recursive;

            dlDelay.valueChanged += DlDelay_valueChanged;
            dlGain.valueChanged += DlGain_valueChanged;
            bnRecursive.buttonStateChanged += BnRecursive_buttonStateChanged;

            processingType = ProcessingType.Processor;
        }

        private void BnRecursive_buttonStateChanged(object sender, EventArgs e)
        {
            recursive = bnRecursive.buttonState;
        }

        private void DlGain_valueChanged(object sender, EventArgs e)
        {
            gain = Math.Pow(10, dlGain.val / 20);
        }

        private void DlDelay_valueChanged(object sender, EventArgs e)
        {
            delay = dlDelay.val / 1000;
        }

        public Echo() : base()
        {
            delay = 0.1;
            gain = 0.1;
            recursive = true;

            init();
        }

        public Echo(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            delay = src.ReadDouble();
            gain = src.ReadDouble();
            recursive = src.ReadBoolean();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(delay);
            tgt.Write(gain);
            tgt.Write(recursive);
        }
        
        public override void tick()
        {
            if (!_active) return;
            SignalBuffer dbin = getSignalInputBuffer(ioI);
            SignalBuffer dbout = getSignalOutputBuffer(ioO);
            UInt32 pick = (UInt32)Math.Floor(delay * owner.sampleRate + 0.5);
            if (pick > 10 * owner.sampleRate)
                pick = (UInt32) (10 * owner.sampleRate); // Hard limit to 10s !
            if (dd == null)
                dd = new DynamicDelay(pick+100);
            for (int i = 0; i < owner.blockSize; i++)
            {
                double rin = 0;
                if (dbin != null) rin = dbin.data[i];
                double delayout = dd.Fetch(pick) * gain;
                if (dbout != null)
                    dbout.data[i] = rin + delayout;
                if (recursive)
                    dd.Store(rin + delayout);
                else
                    dd.Store(rin);
            }            
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Enhance", "Echo" }; }
            public override RTForm Instantiate() { return new Echo(); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
        }



    }


}
