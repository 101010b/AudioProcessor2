using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.SinkSource
{
    public class Oscilloscope : RTForm
    {

        public void InitializeComponent()
        {
            this.ioA = new AudioProcessor.RTIO();
            this.ioB = new AudioProcessor.RTIO();
            this.ioC = new AudioProcessor.RTIO();
            this.ioD = new AudioProcessor.RTIO();
            this.bnDisplayWin = new AudioProcessor.RTButton();
            this.SuspendLayout();
            // 
            // ioA
            // 
            this.ioA.contactBackColor = System.Drawing.Color.Black;
            this.ioA.contactColor = System.Drawing.Color.DimGray;
            this.ioA.Location = new System.Drawing.Point(0, 23);
            this.ioA.Name = "ioA";
            this.ioA.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioA.showTitle = true;
            this.ioA.Size = new System.Drawing.Size(39, 20);
            this.ioA.TabIndex = 0;
            this.ioA.Text = "rtio1";
            this.ioA.title = "A";
            this.ioA.titleColor = System.Drawing.Color.Red;
            this.ioA.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioA.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioB
            // 
            this.ioB.contactBackColor = System.Drawing.Color.Black;
            this.ioB.contactColor = System.Drawing.Color.DimGray;
            this.ioB.Location = new System.Drawing.Point(0, 49);
            this.ioB.Name = "ioB";
            this.ioB.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB.showTitle = true;
            this.ioB.Size = new System.Drawing.Size(39, 20);
            this.ioB.TabIndex = 1;
            this.ioB.Text = "rtio2";
            this.ioB.title = "B";
            this.ioB.titleColor = System.Drawing.Color.Lime;
            this.ioB.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioC
            // 
            this.ioC.contactBackColor = System.Drawing.Color.Black;
            this.ioC.contactColor = System.Drawing.Color.DimGray;
            this.ioC.Location = new System.Drawing.Point(0, 75);
            this.ioC.Name = "ioC";
            this.ioC.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioC.showTitle = true;
            this.ioC.Size = new System.Drawing.Size(39, 20);
            this.ioC.TabIndex = 2;
            this.ioC.Text = "rtio3";
            this.ioC.title = "C";
            this.ioC.titleColor = System.Drawing.Color.Aqua;
            this.ioC.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioC.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioD
            // 
            this.ioD.contactBackColor = System.Drawing.Color.Black;
            this.ioD.contactColor = System.Drawing.Color.DimGray;
            this.ioD.Location = new System.Drawing.Point(0, 101);
            this.ioD.Name = "ioD";
            this.ioD.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioD.showTitle = true;
            this.ioD.Size = new System.Drawing.Size(39, 20);
            this.ioD.TabIndex = 3;
            this.ioD.Text = "rtio4";
            this.ioD.title = "D";
            this.ioD.titleColor = System.Drawing.Color.Fuchsia;
            this.ioD.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioD.type = AudioProcessor.RTIO.ProcessingIOType.Input;
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
            this.bnDisplayWin.Location = new System.Drawing.Point(45, 59);
            this.bnDisplayWin.Name = "bnDisplayWin";
            this.bnDisplayWin.offText = "Display";
            this.bnDisplayWin.onText = "Display";
            this.bnDisplayWin.Size = new System.Drawing.Size(61, 22);
            this.bnDisplayWin.TabIndex = 4;
            this.bnDisplayWin.Text = "rtButton1";
            this.bnDisplayWin.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnDisplayWin.textOffColor = System.Drawing.Color.DimGray;
            this.bnDisplayWin.textOnColor = System.Drawing.Color.Red;
            this.bnDisplayWin.title = "Button";
            this.bnDisplayWin.titleColor = System.Drawing.Color.DimGray;
            this.bnDisplayWin.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnDisplayWin.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // Oscilloscope
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.canShrink = false;
            this.Controls.Add(this.bnDisplayWin);
            this.Controls.Add(this.ioD);
            this.Controls.Add(this.ioC);
            this.Controls.Add(this.ioB);
            this.Controls.Add(this.ioA);
            this.hasActiveSwitch = false;
            this.Name = "Oscilloscope";
            this.shrinkTitle = "Oscilloscope";
            this.Size = new System.Drawing.Size(121, 127);
            this.title = "Oscilloscope";
            this.ResumeLayout(false);

        }

        int channels;
        private RTIO ioA;
        private RTIO ioB;
        private RTIO ioC;
        private RTIO ioD;
        private RTButton bnDisplayWin;
        OscilloscopeWin ow;

        private string channelName(int ch)
        {
            char[] a = new char[2];
            a[0]=Convert.ToChar(65+ch);
            a[1] = (char)0;
            string e = new string(a);
            return e;
        }

        private void init()
        {
            InitializeComponent();

            int ymax = Height;
            if (channels < 4) { ioD.Hide(); ymax = ioD.Location.Y; }
            if (channels < 3) { ioC.Hide(); ymax = ioC.Location.Y; }
            if (channels < 2) { ioB.Hide(); ymax = ioB.Location.Y; }
            Height = ymax;

            bnDisplayWin.buttonStateChanged += BnDisplayWin_buttonStateChanged;

            ow = null;
            processingType = ProcessingType.Sink;
        }


        public Oscilloscope() : this(4)
        {
        }

        public Oscilloscope(int _channels):base()
        {
            channels = _channels;

            init();
        }

        public Oscilloscope(SystemPanel _owner, BinaryReader src):base(_owner,src)
        {
            channels = src.ReadInt32();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write(channels);
        }

        private void processChannel(int channel, DataBuffer dbin)
        {
            if (dbin != null)
            {
                ow.inputs[channel].insert(dbin);
                ow.inputsActive[channel] = true;
            } else
            {
                ow.inputs[channel].insert(0, owner.blockSize);
                ow.inputsActive[channel] = false;
            }
        }

        public override void tick()
        {
            if (ow == null) return;
            if ((channels >= 1) && (ow.channels >= 1)) processChannel(0, getInputBuffer(ioA));
            if ((channels >= 2) && (ow.channels >= 2)) processChannel(1, getInputBuffer(ioB));
            if ((channels >= 3) && (ow.channels >= 3)) processChannel(2, getInputBuffer(ioC));
            if ((channels >= 4) && (ow.channels >= 4)) processChannel(3, getInputBuffer(ioD));
        }

        private void BnDisplayWin_buttonStateChanged(object sender, EventArgs e)
        {
            if (ow == null)
            {
                ow = new OscilloscopeWin();
                ow.initOscilloscope(this, channels, owner.sampleRate / 2);
                ow.Show();
            }
            else
            {
                ow.Show();
            }
        }

        public override void Disconnect()
        {
            base.Disconnect();
            if (ow != null)
            {
                ow.CanClose = true;
                ow.Close();
                ow.oscilloscope = null;
                ow = null;
            }
            
        }

        class RegisterClass : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Tools", "Oscilloscope" }; }
            public override RTForm Instantiate() { return new Oscilloscope(4); }
        }
        public static void Register(List<RTObjectReference> l) { l.Add(new RegisterClass()); }

    }
}
