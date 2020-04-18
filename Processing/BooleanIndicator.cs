using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.Processing
{
    public class BooleanIndicator : RTForm
    {

        public void InitializeComponent()
        {
            this.led1 = new AudioProcessor.RTLED();
            this.io1 = new AudioProcessor.RTIO();
            this.io2 = new AudioProcessor.RTIO();
            this.led2 = new AudioProcessor.RTLED();
            this.io3 = new AudioProcessor.RTIO();
            this.led3 = new AudioProcessor.RTLED();
            this.io4 = new AudioProcessor.RTIO();
            this.led4 = new AudioProcessor.RTLED();
            this.io5 = new AudioProcessor.RTIO();
            this.led5 = new AudioProcessor.RTLED();
            this.io6 = new AudioProcessor.RTIO();
            this.led6 = new AudioProcessor.RTLED();
            this.io7 = new AudioProcessor.RTIO();
            this.led7 = new AudioProcessor.RTLED();
            this.io8 = new AudioProcessor.RTIO();
            this.led8 = new AudioProcessor.RTLED();
            this.SuspendLayout();
            // 
            // led1
            // 
            this.led1.fillOffColor = System.Drawing.Color.Black;
            this.led1.fillOnColor = System.Drawing.Color.DarkRed;
            this.led1.frameOffColor = System.Drawing.Color.DimGray;
            this.led1.frameOnColor = System.Drawing.Color.Red;
            this.led1.LEDDim = new System.Drawing.Size(15, 15);
            this.led1.LEDState = false;
            this.led1.Location = new System.Drawing.Point(27, 25);
            this.led1.Name = "led1";
            this.led1.offText = "";
            this.led1.onText = "";
            this.led1.Size = new System.Drawing.Size(20, 20);
            this.led1.TabIndex = 0;
            this.led1.Text = "rtled1";
            this.led1.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.led1.textOffColor = System.Drawing.Color.DimGray;
            this.led1.textOnColor = System.Drawing.Color.Red;
            this.led1.title = "LED";
            this.led1.titleColor = System.Drawing.Color.DimGray;
            this.led1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.led1.titlePos = AudioProcessor.RTLED.RTTitlePos.Off;
            // 
            // io1
            // 
            this.io1.contactBackColor = System.Drawing.Color.Black;
            this.io1.contactColor = System.Drawing.Color.DimGray;
            this.io1.Location = new System.Drawing.Point(0, 25);
            this.io1.Name = "io1";
            this.io1.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io1.showTitle = false;
            this.io1.Size = new System.Drawing.Size(21, 20);
            this.io1.TabIndex = 1;
            this.io1.Text = "io1";
            this.io1.title = "IO";
            this.io1.titleColor = System.Drawing.Color.DimGray;
            this.io1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io1.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // io2
            // 
            this.io2.contactBackColor = System.Drawing.Color.Black;
            this.io2.contactColor = System.Drawing.Color.DimGray;
            this.io2.Location = new System.Drawing.Point(0, 51);
            this.io2.Name = "io2";
            this.io2.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io2.showTitle = false;
            this.io2.Size = new System.Drawing.Size(21, 20);
            this.io2.TabIndex = 3;
            this.io2.Text = "rtio2";
            this.io2.title = "IO";
            this.io2.titleColor = System.Drawing.Color.DimGray;
            this.io2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io2.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // led2
            // 
            this.led2.fillOffColor = System.Drawing.Color.Black;
            this.led2.fillOnColor = System.Drawing.Color.DarkRed;
            this.led2.frameOffColor = System.Drawing.Color.DimGray;
            this.led2.frameOnColor = System.Drawing.Color.Red;
            this.led2.LEDDim = new System.Drawing.Size(15, 15);
            this.led2.LEDState = false;
            this.led2.Location = new System.Drawing.Point(27, 51);
            this.led2.Name = "led2";
            this.led2.offText = "";
            this.led2.onText = "";
            this.led2.Size = new System.Drawing.Size(20, 20);
            this.led2.TabIndex = 2;
            this.led2.Text = "rtled2";
            this.led2.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.led2.textOffColor = System.Drawing.Color.DimGray;
            this.led2.textOnColor = System.Drawing.Color.Red;
            this.led2.title = "LED";
            this.led2.titleColor = System.Drawing.Color.DimGray;
            this.led2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.led2.titlePos = AudioProcessor.RTLED.RTTitlePos.Off;
            // 
            // io3
            // 
            this.io3.contactBackColor = System.Drawing.Color.Black;
            this.io3.contactColor = System.Drawing.Color.DimGray;
            this.io3.Location = new System.Drawing.Point(0, 77);
            this.io3.Name = "io3";
            this.io3.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io3.showTitle = false;
            this.io3.Size = new System.Drawing.Size(21, 20);
            this.io3.TabIndex = 5;
            this.io3.Text = "rtio3";
            this.io3.title = "IO";
            this.io3.titleColor = System.Drawing.Color.DimGray;
            this.io3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io3.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // led3
            // 
            this.led3.fillOffColor = System.Drawing.Color.Black;
            this.led3.fillOnColor = System.Drawing.Color.DarkRed;
            this.led3.frameOffColor = System.Drawing.Color.DimGray;
            this.led3.frameOnColor = System.Drawing.Color.Red;
            this.led3.LEDDim = new System.Drawing.Size(15, 15);
            this.led3.LEDState = false;
            this.led3.Location = new System.Drawing.Point(27, 77);
            this.led3.Name = "led3";
            this.led3.offText = "";
            this.led3.onText = "";
            this.led3.Size = new System.Drawing.Size(20, 20);
            this.led3.TabIndex = 4;
            this.led3.Text = "rtled3";
            this.led3.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.led3.textOffColor = System.Drawing.Color.DimGray;
            this.led3.textOnColor = System.Drawing.Color.Red;
            this.led3.title = "LED";
            this.led3.titleColor = System.Drawing.Color.DimGray;
            this.led3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.led3.titlePos = AudioProcessor.RTLED.RTTitlePos.Off;
            // 
            // io4
            // 
            this.io4.contactBackColor = System.Drawing.Color.Black;
            this.io4.contactColor = System.Drawing.Color.DimGray;
            this.io4.Location = new System.Drawing.Point(0, 103);
            this.io4.Name = "io4";
            this.io4.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io4.showTitle = false;
            this.io4.Size = new System.Drawing.Size(21, 20);
            this.io4.TabIndex = 7;
            this.io4.Text = "rtio4";
            this.io4.title = "IO";
            this.io4.titleColor = System.Drawing.Color.DimGray;
            this.io4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io4.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // led4
            // 
            this.led4.fillOffColor = System.Drawing.Color.Black;
            this.led4.fillOnColor = System.Drawing.Color.DarkRed;
            this.led4.frameOffColor = System.Drawing.Color.DimGray;
            this.led4.frameOnColor = System.Drawing.Color.Red;
            this.led4.LEDDim = new System.Drawing.Size(15, 15);
            this.led4.LEDState = false;
            this.led4.Location = new System.Drawing.Point(27, 103);
            this.led4.Name = "led4";
            this.led4.offText = "";
            this.led4.onText = "";
            this.led4.Size = new System.Drawing.Size(20, 20);
            this.led4.TabIndex = 6;
            this.led4.Text = "rtled4";
            this.led4.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.led4.textOffColor = System.Drawing.Color.DimGray;
            this.led4.textOnColor = System.Drawing.Color.Red;
            this.led4.title = "LED";
            this.led4.titleColor = System.Drawing.Color.DimGray;
            this.led4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.led4.titlePos = AudioProcessor.RTLED.RTTitlePos.Off;
            // 
            // io5
            // 
            this.io5.contactBackColor = System.Drawing.Color.Black;
            this.io5.contactColor = System.Drawing.Color.DimGray;
            this.io5.Location = new System.Drawing.Point(0, 129);
            this.io5.Name = "io5";
            this.io5.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io5.showTitle = false;
            this.io5.Size = new System.Drawing.Size(21, 20);
            this.io5.TabIndex = 9;
            this.io5.Text = "rtio5";
            this.io5.title = "IO";
            this.io5.titleColor = System.Drawing.Color.DimGray;
            this.io5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io5.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // led5
            // 
            this.led5.fillOffColor = System.Drawing.Color.Black;
            this.led5.fillOnColor = System.Drawing.Color.DarkRed;
            this.led5.frameOffColor = System.Drawing.Color.DimGray;
            this.led5.frameOnColor = System.Drawing.Color.Red;
            this.led5.LEDDim = new System.Drawing.Size(15, 15);
            this.led5.LEDState = false;
            this.led5.Location = new System.Drawing.Point(27, 129);
            this.led5.Name = "led5";
            this.led5.offText = "";
            this.led5.onText = "";
            this.led5.Size = new System.Drawing.Size(20, 20);
            this.led5.TabIndex = 8;
            this.led5.Text = "rtled5";
            this.led5.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.led5.textOffColor = System.Drawing.Color.DimGray;
            this.led5.textOnColor = System.Drawing.Color.Red;
            this.led5.title = "LED";
            this.led5.titleColor = System.Drawing.Color.DimGray;
            this.led5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.led5.titlePos = AudioProcessor.RTLED.RTTitlePos.Off;
            // 
            // io6
            // 
            this.io6.contactBackColor = System.Drawing.Color.Black;
            this.io6.contactColor = System.Drawing.Color.DimGray;
            this.io6.Location = new System.Drawing.Point(0, 155);
            this.io6.Name = "io6";
            this.io6.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io6.showTitle = false;
            this.io6.Size = new System.Drawing.Size(21, 20);
            this.io6.TabIndex = 11;
            this.io6.Text = "rtio6";
            this.io6.title = "IO";
            this.io6.titleColor = System.Drawing.Color.DimGray;
            this.io6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io6.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // led6
            // 
            this.led6.fillOffColor = System.Drawing.Color.Black;
            this.led6.fillOnColor = System.Drawing.Color.DarkRed;
            this.led6.frameOffColor = System.Drawing.Color.DimGray;
            this.led6.frameOnColor = System.Drawing.Color.Red;
            this.led6.LEDDim = new System.Drawing.Size(15, 15);
            this.led6.LEDState = false;
            this.led6.Location = new System.Drawing.Point(27, 155);
            this.led6.Name = "led6";
            this.led6.offText = "";
            this.led6.onText = "";
            this.led6.Size = new System.Drawing.Size(20, 20);
            this.led6.TabIndex = 10;
            this.led6.Text = "rtled6";
            this.led6.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.led6.textOffColor = System.Drawing.Color.DimGray;
            this.led6.textOnColor = System.Drawing.Color.Red;
            this.led6.title = "LED";
            this.led6.titleColor = System.Drawing.Color.DimGray;
            this.led6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.led6.titlePos = AudioProcessor.RTLED.RTTitlePos.Off;
            // 
            // io7
            // 
            this.io7.contactBackColor = System.Drawing.Color.Black;
            this.io7.contactColor = System.Drawing.Color.DimGray;
            this.io7.Location = new System.Drawing.Point(0, 181);
            this.io7.Name = "io7";
            this.io7.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io7.showTitle = false;
            this.io7.Size = new System.Drawing.Size(21, 20);
            this.io7.TabIndex = 13;
            this.io7.Text = "rtio7";
            this.io7.title = "IO";
            this.io7.titleColor = System.Drawing.Color.DimGray;
            this.io7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io7.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // led7
            // 
            this.led7.fillOffColor = System.Drawing.Color.Black;
            this.led7.fillOnColor = System.Drawing.Color.DarkRed;
            this.led7.frameOffColor = System.Drawing.Color.DimGray;
            this.led7.frameOnColor = System.Drawing.Color.Red;
            this.led7.LEDDim = new System.Drawing.Size(15, 15);
            this.led7.LEDState = false;
            this.led7.Location = new System.Drawing.Point(27, 181);
            this.led7.Name = "led7";
            this.led7.offText = "";
            this.led7.onText = "";
            this.led7.Size = new System.Drawing.Size(20, 20);
            this.led7.TabIndex = 12;
            this.led7.Text = "rtled7";
            this.led7.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.led7.textOffColor = System.Drawing.Color.DimGray;
            this.led7.textOnColor = System.Drawing.Color.Red;
            this.led7.title = "LED";
            this.led7.titleColor = System.Drawing.Color.DimGray;
            this.led7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.led7.titlePos = AudioProcessor.RTLED.RTTitlePos.Off;
            // 
            // io8
            // 
            this.io8.contactBackColor = System.Drawing.Color.Black;
            this.io8.contactColor = System.Drawing.Color.DimGray;
            this.io8.Location = new System.Drawing.Point(0, 207);
            this.io8.Name = "io8";
            this.io8.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io8.showTitle = false;
            this.io8.Size = new System.Drawing.Size(21, 20);
            this.io8.TabIndex = 15;
            this.io8.Text = "rtio8";
            this.io8.title = "IO";
            this.io8.titleColor = System.Drawing.Color.DimGray;
            this.io8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io8.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // led8
            // 
            this.led8.fillOffColor = System.Drawing.Color.Black;
            this.led8.fillOnColor = System.Drawing.Color.DarkRed;
            this.led8.frameOffColor = System.Drawing.Color.DimGray;
            this.led8.frameOnColor = System.Drawing.Color.Red;
            this.led8.LEDDim = new System.Drawing.Size(15, 15);
            this.led8.LEDState = false;
            this.led8.Location = new System.Drawing.Point(27, 207);
            this.led8.Name = "led8";
            this.led8.offText = "";
            this.led8.onText = "";
            this.led8.Size = new System.Drawing.Size(20, 20);
            this.led8.TabIndex = 14;
            this.led8.Text = "rtled8";
            this.led8.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.led8.textOffColor = System.Drawing.Color.DimGray;
            this.led8.textOnColor = System.Drawing.Color.Red;
            this.led8.title = "LED";
            this.led8.titleColor = System.Drawing.Color.DimGray;
            this.led8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.led8.titlePos = AudioProcessor.RTLED.RTTitlePos.Off;
            // 
            // BooleanIndicator
            // 
            this.canShrink = false;
            this.Controls.Add(this.io8);
            this.Controls.Add(this.led8);
            this.Controls.Add(this.io7);
            this.Controls.Add(this.led7);
            this.Controls.Add(this.io6);
            this.Controls.Add(this.led6);
            this.Controls.Add(this.io5);
            this.Controls.Add(this.led5);
            this.Controls.Add(this.io4);
            this.Controls.Add(this.led4);
            this.Controls.Add(this.io3);
            this.Controls.Add(this.led3);
            this.Controls.Add(this.io2);
            this.Controls.Add(this.led2);
            this.Controls.Add(this.io1);
            this.Controls.Add(this.led1);
            this.hasActiveSwitch = false;
            this.Name = "BooleanIndicator";
            this.Size = new System.Drawing.Size(59, 233);
            this.title = "Ind";
            this.ResumeLayout(false);

        }

        int channels;
        private RTLED led1;
        private RTIO io1;
        private RTIO io2;
        private RTLED led2;
        private RTIO io3;
        private RTLED led3;
        private RTIO io4;
        private RTLED led4;
        private RTIO io5;
        private RTLED led5;
        private RTIO io6;
        private RTLED led6;
        private RTIO io7;
        private RTLED led7;
        private RTIO io8;
        private RTLED led8;
        Boolean[] state;

        private void init()
        {
            InitializeComponent();

            int h = Height;
            if (channels < 8) { led8.Hide(); io8.Hide(); h = io8.Location.Y; }
            if (channels < 7) { led7.Hide(); io7.Hide(); h = io7.Location.Y; }
            if (channels < 6) { led6.Hide(); io6.Hide(); h = io6.Location.Y; }
            if (channels < 5) { led5.Hide(); io5.Hide(); h = io5.Location.Y; }
            if (channels < 4) { led4.Hide(); io4.Hide(); h = io4.Location.Y; }
            if (channels < 3) { led3.Hide(); io3.Hide(); h = io3.Location.Y; }
            if (channels < 2) { led2.Hide(); io2.Hide(); h = io2.Location.Y; }
            Height = h;

            state = new Boolean[channels];

            processingType = ProcessingType.Processor;
        }

        public BooleanIndicator(): this(8)
        {
        }

        public BooleanIndicator(int _channels) : base()
        {
            channels = _channels;
            init();
        }

        public BooleanIndicator(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            channels = src.ReadInt32();
            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(channels);
        }

        private void processChannel(DataBuffer d, RTLED rl, int led)
        {
            Boolean restate = state[led];
            if (d != null)
            {
                for (int j = 0; j < owner.blockSize; j++)
                    if (d.data[j] > 0)
                        restate = true;
                    else
                        restate = false;
            }
            else
                restate = false;
            state[led] = restate;
            if (state[led] && !rl.LEDState)
                rl.LEDState = true;
            if (!state[led] && rl.LEDState)
                rl.LEDState = false;
        }

        public override void tick()
        {
            if (channels > 0) processChannel(getInputBuffer(io1), led1, 0);
            if (channels > 1) processChannel(getInputBuffer(io2), led2, 1);
            if (channels > 2) processChannel(getInputBuffer(io3), led3, 2);
            if (channels > 3) processChannel(getInputBuffer(io4), led4, 3);
            if (channels > 4) processChannel(getInputBuffer(io5), led5, 4);
            if (channels > 5) processChannel(getInputBuffer(io6), led6, 5);
            if (channels > 6) processChannel(getInputBuffer(io7), led7, 6);
            if (channels > 7) processChannel(getInputBuffer(io8), led8, 7);
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Boolean Indicator", "1 x" }; }
            public override RTForm Instantiate() { return new BooleanIndicator(1); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Boolean Indicator", "2 x" }; }
            public override RTForm Instantiate() { return new BooleanIndicator(2); }
        }
        class RegisterClass3 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Boolean Indicator", "3 x" }; }
            public override RTForm Instantiate() { return new BooleanIndicator(3); }
        }
        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Boolean Indicator", "4 x" }; }
            public override RTForm Instantiate() { return new BooleanIndicator(4); }
        }
        class RegisterClass6 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Boolean Indicator", "6 x" }; }
            public override RTForm Instantiate() { return new BooleanIndicator(6); }
        }
        class RegisterClass8 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Boolean Indicator", "8 x" }; }
            public override RTForm Instantiate() { return new BooleanIndicator(8); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
            l.Add(new RegisterClass2());
            l.Add(new RegisterClass3());
            l.Add(new RegisterClass4());
            l.Add(new RegisterClass6());
            l.Add(new RegisterClass8());
        }

    }
}
