using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.Processing
{
    class Mux:RTForm
    {

        public void InitializeComponent()
        {
            this.io1 = new AudioProcessor.RTIO();
            this.io2 = new AudioProcessor.RTIO();
            this.io3 = new AudioProcessor.RTIO();
            this.io4 = new AudioProcessor.RTIO();
            this.io5 = new AudioProcessor.RTIO();
            this.io6 = new AudioProcessor.RTIO();
            this.io7 = new AudioProcessor.RTIO();
            this.io8 = new AudioProcessor.RTIO();
            this.ioOut = new AudioProcessor.RTIO();
            this.bn1 = new AudioProcessor.RTButton();
            this.bn2 = new AudioProcessor.RTButton();
            this.bn3 = new AudioProcessor.RTButton();
            this.bn4 = new AudioProcessor.RTButton();
            this.bn5 = new AudioProcessor.RTButton();
            this.bn6 = new AudioProcessor.RTButton();
            this.bn7 = new AudioProcessor.RTButton();
            this.bn8 = new AudioProcessor.RTButton();
            this.SuspendLayout();
            // 
            // io1
            // 
            this.io1.contactBackColor = System.Drawing.Color.Black;
            this.io1.contactColor = System.Drawing.Color.DimGray;
            this.io1.Location = new System.Drawing.Point(0, 35);
            this.io1.Name = "io1";
            this.io1.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io1.showTitle = false;
            this.io1.Size = new System.Drawing.Size(21, 20);
            this.io1.TabIndex = 0;
            this.io1.Text = "rtio1";
            this.io1.title = "IO";
            this.io1.titleColor = System.Drawing.Color.DimGray;
            this.io1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io1.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // io2
            // 
            this.io2.contactBackColor = System.Drawing.Color.Black;
            this.io2.contactColor = System.Drawing.Color.DimGray;
            this.io2.Location = new System.Drawing.Point(0, 61);
            this.io2.Name = "io2";
            this.io2.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io2.showTitle = false;
            this.io2.Size = new System.Drawing.Size(21, 20);
            this.io2.TabIndex = 1;
            this.io2.Text = "rtio2";
            this.io2.title = "IO";
            this.io2.titleColor = System.Drawing.Color.DimGray;
            this.io2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io2.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // io3
            // 
            this.io3.contactBackColor = System.Drawing.Color.Black;
            this.io3.contactColor = System.Drawing.Color.DimGray;
            this.io3.Location = new System.Drawing.Point(0, 87);
            this.io3.Name = "io3";
            this.io3.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io3.showTitle = false;
            this.io3.Size = new System.Drawing.Size(21, 20);
            this.io3.TabIndex = 2;
            this.io3.Text = "rtio3";
            this.io3.title = "IO";
            this.io3.titleColor = System.Drawing.Color.DimGray;
            this.io3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io3.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // io4
            // 
            this.io4.contactBackColor = System.Drawing.Color.Black;
            this.io4.contactColor = System.Drawing.Color.DimGray;
            this.io4.Location = new System.Drawing.Point(0, 113);
            this.io4.Name = "io4";
            this.io4.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io4.showTitle = false;
            this.io4.Size = new System.Drawing.Size(21, 20);
            this.io4.TabIndex = 3;
            this.io4.Text = "rtio4";
            this.io4.title = "IO";
            this.io4.titleColor = System.Drawing.Color.DimGray;
            this.io4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io4.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // io5
            // 
            this.io5.contactBackColor = System.Drawing.Color.Black;
            this.io5.contactColor = System.Drawing.Color.DimGray;
            this.io5.Location = new System.Drawing.Point(0, 139);
            this.io5.Name = "io5";
            this.io5.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io5.showTitle = false;
            this.io5.Size = new System.Drawing.Size(21, 20);
            this.io5.TabIndex = 4;
            this.io5.Text = "rtio5";
            this.io5.title = "IO";
            this.io5.titleColor = System.Drawing.Color.DimGray;
            this.io5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io5.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // io6
            // 
            this.io6.contactBackColor = System.Drawing.Color.Black;
            this.io6.contactColor = System.Drawing.Color.DimGray;
            this.io6.Location = new System.Drawing.Point(0, 165);
            this.io6.Name = "io6";
            this.io6.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io6.showTitle = false;
            this.io6.Size = new System.Drawing.Size(21, 20);
            this.io6.TabIndex = 5;
            this.io6.Text = "rtio6";
            this.io6.title = "IO";
            this.io6.titleColor = System.Drawing.Color.DimGray;
            this.io6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io6.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // io7
            // 
            this.io7.contactBackColor = System.Drawing.Color.Black;
            this.io7.contactColor = System.Drawing.Color.DimGray;
            this.io7.Location = new System.Drawing.Point(0, 191);
            this.io7.Name = "io7";
            this.io7.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io7.showTitle = false;
            this.io7.Size = new System.Drawing.Size(21, 20);
            this.io7.TabIndex = 6;
            this.io7.Text = "rtio7";
            this.io7.title = "IO";
            this.io7.titleColor = System.Drawing.Color.DimGray;
            this.io7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io7.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // io8
            // 
            this.io8.contactBackColor = System.Drawing.Color.Black;
            this.io8.contactColor = System.Drawing.Color.DimGray;
            this.io8.Location = new System.Drawing.Point(0, 217);
            this.io8.Name = "io8";
            this.io8.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io8.showTitle = false;
            this.io8.Size = new System.Drawing.Size(21, 20);
            this.io8.TabIndex = 7;
            this.io8.Text = "rtio8";
            this.io8.title = "IO";
            this.io8.titleColor = System.Drawing.Color.DimGray;
            this.io8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io8.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioOut
            // 
            this.ioOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut.contactBackColor = System.Drawing.Color.Black;
            this.ioOut.contactColor = System.Drawing.Color.DimGray;
            this.ioOut.Location = new System.Drawing.Point(80, 35);
            this.ioOut.Name = "ioOut";
            this.ioOut.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut.showTitle = false;
            this.ioOut.Size = new System.Drawing.Size(21, 20);
            this.ioOut.TabIndex = 8;
            this.ioOut.Text = "rtio9";
            this.ioOut.title = "IO";
            this.ioOut.titleColor = System.Drawing.Color.DimGray;
            this.ioOut.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOut.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // bn1
            // 
            this.bn1.buttonDim = new System.Drawing.Size(30, 15);
            this.bn1.buttonState = false;
            this.bn1.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bn1.fillOffColor = System.Drawing.Color.Black;
            this.bn1.fillOnColor = System.Drawing.Color.DarkRed;
            this.bn1.frameHoldColor = System.Drawing.Color.Yellow;
            this.bn1.frameOffColor = System.Drawing.Color.DimGray;
            this.bn1.frameOnColor = System.Drawing.Color.Red;
            this.bn1.Location = new System.Drawing.Point(27, 37);
            this.bn1.Name = "bn1";
            this.bn1.offText = "Off";
            this.bn1.onText = "On";
            this.bn1.Size = new System.Drawing.Size(31, 16);
            this.bn1.TabIndex = 9;
            this.bn1.Text = "rtButton1";
            this.bn1.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bn1.textOffColor = System.Drawing.Color.DimGray;
            this.bn1.textOnColor = System.Drawing.Color.Red;
            this.bn1.title = "Button";
            this.bn1.titleColor = System.Drawing.Color.DimGray;
            this.bn1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bn1.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // bn2
            // 
            this.bn2.buttonDim = new System.Drawing.Size(30, 15);
            this.bn2.buttonState = false;
            this.bn2.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bn2.fillOffColor = System.Drawing.Color.Black;
            this.bn2.fillOnColor = System.Drawing.Color.DarkRed;
            this.bn2.frameHoldColor = System.Drawing.Color.Yellow;
            this.bn2.frameOffColor = System.Drawing.Color.DimGray;
            this.bn2.frameOnColor = System.Drawing.Color.Red;
            this.bn2.Location = new System.Drawing.Point(27, 63);
            this.bn2.Name = "bn2";
            this.bn2.offText = "Off";
            this.bn2.onText = "On";
            this.bn2.Size = new System.Drawing.Size(31, 16);
            this.bn2.TabIndex = 10;
            this.bn2.Text = "rtButton2";
            this.bn2.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bn2.textOffColor = System.Drawing.Color.DimGray;
            this.bn2.textOnColor = System.Drawing.Color.Red;
            this.bn2.title = "Button";
            this.bn2.titleColor = System.Drawing.Color.DimGray;
            this.bn2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bn2.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // bn3
            // 
            this.bn3.buttonDim = new System.Drawing.Size(30, 15);
            this.bn3.buttonState = false;
            this.bn3.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bn3.fillOffColor = System.Drawing.Color.Black;
            this.bn3.fillOnColor = System.Drawing.Color.DarkRed;
            this.bn3.frameHoldColor = System.Drawing.Color.Yellow;
            this.bn3.frameOffColor = System.Drawing.Color.DimGray;
            this.bn3.frameOnColor = System.Drawing.Color.Red;
            this.bn3.Location = new System.Drawing.Point(27, 89);
            this.bn3.Name = "bn3";
            this.bn3.offText = "Off";
            this.bn3.onText = "On";
            this.bn3.Size = new System.Drawing.Size(31, 16);
            this.bn3.TabIndex = 11;
            this.bn3.Text = "rtButton3";
            this.bn3.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bn3.textOffColor = System.Drawing.Color.DimGray;
            this.bn3.textOnColor = System.Drawing.Color.Red;
            this.bn3.title = "Button";
            this.bn3.titleColor = System.Drawing.Color.DimGray;
            this.bn3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bn3.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // bn4
            // 
            this.bn4.buttonDim = new System.Drawing.Size(30, 15);
            this.bn4.buttonState = false;
            this.bn4.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bn4.fillOffColor = System.Drawing.Color.Black;
            this.bn4.fillOnColor = System.Drawing.Color.DarkRed;
            this.bn4.frameHoldColor = System.Drawing.Color.Yellow;
            this.bn4.frameOffColor = System.Drawing.Color.DimGray;
            this.bn4.frameOnColor = System.Drawing.Color.Red;
            this.bn4.Location = new System.Drawing.Point(27, 115);
            this.bn4.Name = "bn4";
            this.bn4.offText = "Off";
            this.bn4.onText = "On";
            this.bn4.Size = new System.Drawing.Size(31, 16);
            this.bn4.TabIndex = 12;
            this.bn4.Text = "rtButton4";
            this.bn4.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bn4.textOffColor = System.Drawing.Color.DimGray;
            this.bn4.textOnColor = System.Drawing.Color.Red;
            this.bn4.title = "Button";
            this.bn4.titleColor = System.Drawing.Color.DimGray;
            this.bn4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bn4.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // bn5
            // 
            this.bn5.buttonDim = new System.Drawing.Size(30, 15);
            this.bn5.buttonState = false;
            this.bn5.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bn5.fillOffColor = System.Drawing.Color.Black;
            this.bn5.fillOnColor = System.Drawing.Color.DarkRed;
            this.bn5.frameHoldColor = System.Drawing.Color.Yellow;
            this.bn5.frameOffColor = System.Drawing.Color.DimGray;
            this.bn5.frameOnColor = System.Drawing.Color.Red;
            this.bn5.Location = new System.Drawing.Point(27, 141);
            this.bn5.Name = "bn5";
            this.bn5.offText = "Off";
            this.bn5.onText = "On";
            this.bn5.Size = new System.Drawing.Size(31, 16);
            this.bn5.TabIndex = 13;
            this.bn5.Text = "rtButton5";
            this.bn5.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bn5.textOffColor = System.Drawing.Color.DimGray;
            this.bn5.textOnColor = System.Drawing.Color.Red;
            this.bn5.title = "Button";
            this.bn5.titleColor = System.Drawing.Color.DimGray;
            this.bn5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bn5.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // bn6
            // 
            this.bn6.buttonDim = new System.Drawing.Size(30, 15);
            this.bn6.buttonState = false;
            this.bn6.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bn6.fillOffColor = System.Drawing.Color.Black;
            this.bn6.fillOnColor = System.Drawing.Color.DarkRed;
            this.bn6.frameHoldColor = System.Drawing.Color.Yellow;
            this.bn6.frameOffColor = System.Drawing.Color.DimGray;
            this.bn6.frameOnColor = System.Drawing.Color.Red;
            this.bn6.Location = new System.Drawing.Point(27, 167);
            this.bn6.Name = "bn6";
            this.bn6.offText = "Off";
            this.bn6.onText = "On";
            this.bn6.Size = new System.Drawing.Size(31, 16);
            this.bn6.TabIndex = 14;
            this.bn6.Text = "rtButton6";
            this.bn6.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bn6.textOffColor = System.Drawing.Color.DimGray;
            this.bn6.textOnColor = System.Drawing.Color.Red;
            this.bn6.title = "Button";
            this.bn6.titleColor = System.Drawing.Color.DimGray;
            this.bn6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bn6.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // bn7
            // 
            this.bn7.buttonDim = new System.Drawing.Size(30, 15);
            this.bn7.buttonState = false;
            this.bn7.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bn7.fillOffColor = System.Drawing.Color.Black;
            this.bn7.fillOnColor = System.Drawing.Color.DarkRed;
            this.bn7.frameHoldColor = System.Drawing.Color.Yellow;
            this.bn7.frameOffColor = System.Drawing.Color.DimGray;
            this.bn7.frameOnColor = System.Drawing.Color.Red;
            this.bn7.Location = new System.Drawing.Point(27, 193);
            this.bn7.Name = "bn7";
            this.bn7.offText = "Off";
            this.bn7.onText = "On";
            this.bn7.Size = new System.Drawing.Size(31, 16);
            this.bn7.TabIndex = 15;
            this.bn7.Text = "rtButton7";
            this.bn7.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bn7.textOffColor = System.Drawing.Color.DimGray;
            this.bn7.textOnColor = System.Drawing.Color.Red;
            this.bn7.title = "Button";
            this.bn7.titleColor = System.Drawing.Color.DimGray;
            this.bn7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bn7.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // bn8
            // 
            this.bn8.buttonDim = new System.Drawing.Size(30, 15);
            this.bn8.buttonState = false;
            this.bn8.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bn8.fillOffColor = System.Drawing.Color.Black;
            this.bn8.fillOnColor = System.Drawing.Color.DarkRed;
            this.bn8.frameHoldColor = System.Drawing.Color.Yellow;
            this.bn8.frameOffColor = System.Drawing.Color.DimGray;
            this.bn8.frameOnColor = System.Drawing.Color.Red;
            this.bn8.Location = new System.Drawing.Point(27, 219);
            this.bn8.Name = "bn8";
            this.bn8.offText = "Off";
            this.bn8.onText = "On";
            this.bn8.Size = new System.Drawing.Size(31, 16);
            this.bn8.TabIndex = 16;
            this.bn8.Text = "rtButton8";
            this.bn8.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bn8.textOffColor = System.Drawing.Color.DimGray;
            this.bn8.textOnColor = System.Drawing.Color.Red;
            this.bn8.title = "Button";
            this.bn8.titleColor = System.Drawing.Color.DimGray;
            this.bn8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bn8.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // Mux
            // 
            this.canShrink = false;
            this.Controls.Add(this.bn8);
            this.Controls.Add(this.bn7);
            this.Controls.Add(this.bn6);
            this.Controls.Add(this.bn5);
            this.Controls.Add(this.bn4);
            this.Controls.Add(this.bn3);
            this.Controls.Add(this.bn2);
            this.Controls.Add(this.bn1);
            this.Controls.Add(this.ioOut);
            this.Controls.Add(this.io8);
            this.Controls.Add(this.io7);
            this.Controls.Add(this.io6);
            this.Controls.Add(this.io5);
            this.Controls.Add(this.io4);
            this.Controls.Add(this.io3);
            this.Controls.Add(this.io2);
            this.Controls.Add(this.io1);
            this.Name = "Mux";
            this.Size = new System.Drawing.Size(101, 243);
            this.title = "Mux";
            this.ResumeLayout(false);

        }

        int channels;
        private RTIO io1;
        private RTIO io2;
        private RTIO io3;
        private RTIO io4;
        private RTIO io5;
        private RTIO io6;
        private RTIO io7;
        private RTIO io8;
        private RTIO ioOut;
        private RTButton bn1;
        private RTButton bn2;
        private RTButton bn3;
        private RTButton bn4;
        private RTButton bn5;
        private RTButton bn6;
        private RTButton bn7;
        private RTButton bn8;
        int input;

        private void init()
        {
            InitializeComponent();

            int h = Height;
            if (channels < 8) { io8.Hide(); bn8.Hide(); h = io8.Location.Y; }
            if (channels < 7) { io7.Hide(); bn7.Hide(); h = io7.Location.Y; }
            if (channels < 6) { io6.Hide(); bn6.Hide(); h = io6.Location.Y; }
            if (channels < 5) { io5.Hide(); bn5.Hide(); h = io5.Location.Y; }
            if (channels < 4) { io4.Hide(); bn4.Hide(); h = io4.Location.Y; }
            if (channels < 3) { io3.Hide(); bn3.Hide(); h = io3.Location.Y; }
            Height = h;

            if (channels >= 1) bn1.buttonState = (input == 0);
            if (channels >= 2) bn2.buttonState = (input == 1);
            if (channels >= 3) bn3.buttonState = (input == 2);
            if (channels >= 4) bn4.buttonState = (input == 3);
            if (channels >= 5) bn5.buttonState = (input == 4);
            if (channels >= 6) bn6.buttonState = (input == 5);
            if (channels >= 7) bn7.buttonState = (input == 6);
            if (channels >= 8) bn8.buttonState = (input == 7);

            if (channels >= 1) bn1.buttonStateChanged += Bn1_buttonStateChanged;
            if (channels >= 2) bn2.buttonStateChanged += Bn2_buttonStateChanged;
            if (channels >= 3) bn3.buttonStateChanged += Bn3_buttonStateChanged;
            if (channels >= 4) bn4.buttonStateChanged += Bn4_buttonStateChanged;
            if (channels >= 5) bn5.buttonStateChanged += Bn5_buttonStateChanged;
            if (channels >= 6) bn6.buttonStateChanged += Bn6_buttonStateChanged;
            if (channels >= 7) bn7.buttonStateChanged += Bn7_buttonStateChanged;
            if (channels >= 8) bn8.buttonStateChanged += Bn8_buttonStateChanged;

            processingType = ProcessingType.Processor;
        }


        public Mux(int _channels):base()
        {
            channels = _channels;
            input = 0;

            init();
        }

        public Mux(SystemPanel _owner, BinaryReader src):base(_owner,src)
        {

            channels = src.ReadInt32();
            input = src.ReadInt32();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(channels);
            tgt.Write(input);
        }

        private void Bn1_buttonStateChanged(object sender, EventArgs e)
        {
            if (bn1.buttonState) switchTo(0);
        }

        private void Bn2_buttonStateChanged(object sender, EventArgs e)
        {
            if (bn2.buttonState) switchTo(1);
        }

        private void Bn3_buttonStateChanged(object sender, EventArgs e)
        {
            if (bn3.buttonState) switchTo(2);
        }

        private void Bn4_buttonStateChanged(object sender, EventArgs e)
        {
            if (bn4.buttonState) switchTo(3);
        }

        private void Bn5_buttonStateChanged(object sender, EventArgs e)
        {
            if (bn5.buttonState) switchTo(4);
        }

        private void Bn6_buttonStateChanged(object sender, EventArgs e)
        {
            if (bn6.buttonState) switchTo(5);
        }

        private void Bn7_buttonStateChanged(object sender, EventArgs e)
        {
            if (bn7.buttonState) switchTo(6);
        }

        private void Bn8_buttonStateChanged(object sender, EventArgs e)
        {
            if (bn8.buttonState) switchTo(7);
        }

        private void switchTo(int ch)
        {
            if ((ch < 0) || (ch >= channels)) return;
            if (ch == input) return;
            input = ch;
            if (channels >= 1) bn1.buttonState = (input == 0);
            if (channels >= 2) bn2.buttonState = (input == 1);
            if (channels >= 3) bn3.buttonState = (input == 2);
            if (channels >= 4) bn4.buttonState = (input == 3);
            if (channels >= 5) bn5.buttonState = (input == 4);
            if (channels >= 6) bn6.buttonState = (input == 5);
            if (channels >= 7) bn7.buttonState = (input == 6);
            if (channels >= 8) bn8.buttonState = (input == 7);
        }


        public override void tick()
        {
            if (!_active) return;
            DataBuffer dbout = getOutputBuffer(ioOut);
            if (dbout == null)
                return;
            DataBuffer dbin = null;
            if ((channels >= 1) && (input == 0)) dbin = getInputBuffer(io1);
            if ((channels >= 2) && (input == 1)) dbin = getInputBuffer(io2);
            if ((channels >= 3) && (input == 2)) dbin = getInputBuffer(io3);
            if ((channels >= 4) && (input == 3)) dbin = getInputBuffer(io4);
            if ((channels >= 5) && (input == 4)) dbin = getInputBuffer(io5);
            if ((channels >= 6) && (input == 5)) dbin = getInputBuffer(io6);
            if ((channels >= 7) && (input == 6)) dbin = getInputBuffer(io7);
            if ((channels >= 8) && (input == 7)) dbin = getInputBuffer(io8);

            if (dbin == null)
                return;

            dbout.CopyFrom(dbin);
        }

        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Mux", "2 x" }; }
            public override RTForm Instantiate() { return new Mux(2); }
        }
        class RegisterClass3 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Mux", "3 x" }; }
            public override RTForm Instantiate() { return new Mux(3); }
        }
        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Mux", "4 x" }; }
            public override RTForm Instantiate() { return new Mux(4); }
        }
        class RegisterClass6 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Mux", "6 x" }; }
            public override RTForm Instantiate() { return new Mux(6); }
        }
        class RegisterClass8 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Mux", "8 x" }; }
            public override RTForm Instantiate() { return new Mux(8); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass2());
            l.Add(new RegisterClass3());
            l.Add(new RegisterClass4());
            l.Add(new RegisterClass6());
            l.Add(new RegisterClass8());
        }


    }
}
