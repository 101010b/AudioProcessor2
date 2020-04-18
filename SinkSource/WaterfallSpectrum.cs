using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.SinkSource
{
    public class WaterfallSpectrum : RTForm
    {

        public void InitializeComponent()
        {
            this.ioIn = new AudioProcessor.RTIO();
            this.bnDisplayWin = new AudioProcessor.RTButton();
            this.SuspendLayout();
            // 
            // ioIn
            // 
            this.ioIn.contactBackColor = System.Drawing.Color.Black;
            this.ioIn.contactColor = System.Drawing.Color.DimGray;
            this.ioIn.Location = new System.Drawing.Point(0, 28);
            this.ioIn.Name = "ioIn";
            this.ioIn.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioIn.showTitle = true;
            this.ioIn.Size = new System.Drawing.Size(51, 20);
            this.ioIn.TabIndex = 0;
            this.ioIn.Text = "rtio1";
            this.ioIn.title = "In";
            this.ioIn.titleColor = System.Drawing.Color.DimGray;
            this.ioIn.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioIn.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // bnDisplayWin
            // 
            this.bnDisplayWin.buttonDim = new System.Drawing.Size(60, 20);
            this.bnDisplayWin.buttonState = false;
            this.bnDisplayWin.buttonType = AudioProcessor.RTButton.RTButtonType.ClickButton;
            this.bnDisplayWin.fillOffColor = System.Drawing.Color.Black;
            this.bnDisplayWin.fillOnColor = System.Drawing.Color.DarkRed;
            this.bnDisplayWin.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnDisplayWin.frameOffColor = System.Drawing.Color.DimGray;
            this.bnDisplayWin.frameOnColor = System.Drawing.Color.Red;
            this.bnDisplayWin.Location = new System.Drawing.Point(57, 28);
            this.bnDisplayWin.Name = "bnDisplayWin";
            this.bnDisplayWin.offText = "Display";
            this.bnDisplayWin.onText = "Display";
            this.bnDisplayWin.Size = new System.Drawing.Size(70, 22);
            this.bnDisplayWin.TabIndex = 10;
            this.bnDisplayWin.Text = "rtButton1";
            this.bnDisplayWin.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnDisplayWin.textOffColor = System.Drawing.Color.DimGray;
            this.bnDisplayWin.textOnColor = System.Drawing.Color.Red;
            this.bnDisplayWin.title = "Button";
            this.bnDisplayWin.titleColor = System.Drawing.Color.DimGray;
            this.bnDisplayWin.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnDisplayWin.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // WaterfallSpectrum
            // 
            this.canShrink = false;
            this.Controls.Add(this.bnDisplayWin);
            this.Controls.Add(this.ioIn);
            this.hasActiveSwitch = false;
            this.Name = "WaterfallSpectrum";
            this.Size = new System.Drawing.Size(152, 60);
            this.title = "Waterfall";
            this.ResumeLayout(false);

        }

        private RTIO ioIn;
        private RTButton bnDisplayWin;
        WaterfallSpectrumWin ow;

        private string channelName(int ch)
        {
            char[] a = new char[2];
            a[0] = Convert.ToChar(65 + ch);
            a[1] = (char)0;
            string e = new string(a);
            return e;
        }

        private void init()
        {
            InitializeComponent();
            /*size.set(200, 25 + 50);

            io.Add(new ProcessingIO(owner, this, ProcessingIO.ProcessingIOType.Input, false, 
                "I", false, ProcessingIO.ProcessingIOAlign.LeftFromTop, Vector.V(25 + 25, 0)));

            ctrl.Add(new Controls.Button(owner, this, Vector.V(40, 40), "Open Window", 10, 5));*/

            bnDisplayWin.buttonStateChanged += BnDisplayWin_buttonStateChanged;

            ow = null;

            processingType = ProcessingType.Sink;

        }

        private void BnDisplayWin_buttonStateChanged(object sender, EventArgs e)
        {
            if (ow == null)
            {
                ow = new WaterfallSpectrumWin();
                ow.initWaterfallSpectrum(this);
                ow.Show();
            }
            else
            {
                ow.Show();
            }
        }

        public WaterfallSpectrum() : base()
        {
            init();
        }

        public WaterfallSpectrum(SystemPanel _owner) : base(_owner)
        {
            init();
        }

        public WaterfallSpectrum(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
        }
        
        public override void tick()
        {
            if (ow == null) return;
            if (ow.ready == false) return;
            if (ioIn.connectedTo != null)
            {
                ow.input.insert(ioIn.connectedTo.output);
                ow.inputActive = true;
            }
            else
            {
                ow.input.insert(0, owner.blockSize); // Insert Zeros
                ow.inputActive = false;
            }
        }

        public override void Disconnect()
        {
            base.Disconnect();
            if (ow != null)
            {
                ow.CanClose = true;
                ow.Close();
                ow.waterfallSpectrum = null;
                ow = null;
            }

        }

        class RegisterClass : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Tools", "Waterfall Spectrum Analyzer" }; }
            public override RTForm Instantiate() { return new WaterfallSpectrum(); }
        }
        public static void Register(List<RTObjectReference> l) { l.Add(new RegisterClass()); }

    }
}
