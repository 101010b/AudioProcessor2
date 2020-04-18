using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.SinkSource
{
    public class SpectrumAnalyzer : RTForm
    {

        public void InitializeComponent()
        {
            this.bnDisplayWin = new AudioProcessor.RTButton();
            this.ioD = new AudioProcessor.RTIO();
            this.ioC = new AudioProcessor.RTIO();
            this.ioB = new AudioProcessor.RTIO();
            this.ioA = new AudioProcessor.RTIO();
            this.SuspendLayout();
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
            this.bnDisplayWin.Location = new System.Drawing.Point(47, 63);
            this.bnDisplayWin.Name = "bnDisplayWin";
            this.bnDisplayWin.offText = "Display";
            this.bnDisplayWin.onText = "Display";
            this.bnDisplayWin.Size = new System.Drawing.Size(62, 22);
            this.bnDisplayWin.TabIndex = 9;
            this.bnDisplayWin.Text = "rtButton1";
            this.bnDisplayWin.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnDisplayWin.textOffColor = System.Drawing.Color.DimGray;
            this.bnDisplayWin.textOnColor = System.Drawing.Color.Red;
            this.bnDisplayWin.title = "Button";
            this.bnDisplayWin.titleColor = System.Drawing.Color.DimGray;
            this.bnDisplayWin.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnDisplayWin.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // ioD
            // 
            this.ioD.contactBackColor = System.Drawing.Color.Black;
            this.ioD.contactColor = System.Drawing.Color.DimGray;
            this.ioD.Location = new System.Drawing.Point(0, 102);
            this.ioD.Name = "ioD";
            this.ioD.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioD.showTitle = true;
            this.ioD.Size = new System.Drawing.Size(41, 20);
            this.ioD.TabIndex = 8;
            this.ioD.Text = "rtio4";
            this.ioD.title = "D";
            this.ioD.titleColor = System.Drawing.Color.Fuchsia;
            this.ioD.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioD.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioC
            // 
            this.ioC.contactBackColor = System.Drawing.Color.Black;
            this.ioC.contactColor = System.Drawing.Color.DimGray;
            this.ioC.Location = new System.Drawing.Point(0, 76);
            this.ioC.Name = "ioC";
            this.ioC.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioC.showTitle = true;
            this.ioC.Size = new System.Drawing.Size(41, 20);
            this.ioC.TabIndex = 7;
            this.ioC.Text = "rtio3";
            this.ioC.title = "C";
            this.ioC.titleColor = System.Drawing.Color.Aqua;
            this.ioC.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioC.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioB
            // 
            this.ioB.contactBackColor = System.Drawing.Color.Black;
            this.ioB.contactColor = System.Drawing.Color.DimGray;
            this.ioB.Location = new System.Drawing.Point(0, 50);
            this.ioB.Name = "ioB";
            this.ioB.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB.showTitle = true;
            this.ioB.Size = new System.Drawing.Size(41, 20);
            this.ioB.TabIndex = 6;
            this.ioB.Text = "rtio2";
            this.ioB.title = "B";
            this.ioB.titleColor = System.Drawing.Color.Lime;
            this.ioB.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioA
            // 
            this.ioA.contactBackColor = System.Drawing.Color.Black;
            this.ioA.contactColor = System.Drawing.Color.DimGray;
            this.ioA.Location = new System.Drawing.Point(0, 24);
            this.ioA.Name = "ioA";
            this.ioA.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioA.showTitle = true;
            this.ioA.Size = new System.Drawing.Size(41, 20);
            this.ioA.TabIndex = 5;
            this.ioA.Text = "rtio1";
            this.ioA.title = "A";
            this.ioA.titleColor = System.Drawing.Color.Red;
            this.ioA.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioA.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // SpectrumAnalyzer
            // 
            this.canShrink = false;
            this.Controls.Add(this.bnDisplayWin);
            this.Controls.Add(this.ioD);
            this.Controls.Add(this.ioC);
            this.Controls.Add(this.ioB);
            this.Controls.Add(this.ioA);
            this.hasActiveSwitch = false;
            this.Name = "SpectrumAnalyzer";
            this.shrinkTitle = "Spectrum";
            this.Size = new System.Drawing.Size(119, 127);
            this.title = "Spectrum";
            this.ResumeLayout(false);

        }

        int channels;
        private RTButton bnDisplayWin;
        private RTIO ioD;
        private RTIO ioC;
        private RTIO ioB;
        private RTIO ioA;
        SpectrumAnalyzerWin ow;

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

            int ymax = Height;
            if (channels < 4) { ioD.Hide(); ymax = ioD.Location.Y; }
            if (channels < 3) { ioC.Hide(); ymax = ioC.Location.Y; }
            if (channels < 2) { ioB.Hide(); ymax = ioB.Location.Y; }
            Height = ymax;

            bnDisplayWin.buttonStateChanged += BnDisplayWin_buttonStateChanged;

            processingType = ProcessingType.Sink;
        }

        public SpectrumAnalyzer() : this(4)
        {
        }

        public SpectrumAnalyzer(int _channels) : base()
        {
            channels = _channels;
            init();
        }

        public SpectrumAnalyzer(SystemPanel _owner, int _channels) : base(_owner)
        {
            channels = _channels;
            init();
        }

        public SpectrumAnalyzer(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            channels = src.ReadInt32();
            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(channels);
        }


        private void BnDisplayWin_buttonStateChanged(object sender, EventArgs e)
        {
            if (ow == null)
            {
                ow = new SpectrumAnalyzerWin();
                ow.initSpectrumAnalyzer(this, channels, owner.sampleRate / 2);
                ow.Show();
            }
            else
            {
                ow.Show();
            }
        }

        public override void tick()
        {
            if (ow == null) return;
            if ((channels > 0) && (ow.channels > 0))
            {
                if (ioA.connectedTo != null)
                {
                    ow.inputs[0].insert(ioA.connectedTo.output);
                    ow.inputsActive[0] = true;
                }
                else
                {
                    ow.inputs[0].insert(0, owner.blockSize); // Insert Zeros
                    ow.inputsActive[0] = false;
                }
            }
            if ((channels > 1) && (ow.channels > 1))
            {
                if (ioB.connectedTo != null)
                {
                    ow.inputs[1].insert(ioB.connectedTo.output);
                    ow.inputsActive[1] = true;
                }
                else
                {
                    ow.inputs[1].insert(0, owner.blockSize); // Insert Zeros
                    ow.inputsActive[1] = false;
                }
            }
            if ((channels > 2) && (ow.channels > 2))
            {
                if (ioC.connectedTo != null)
                {
                    ow.inputs[2].insert(ioC.connectedTo.output);
                    ow.inputsActive[2] = true;
                }
                else
                {
                    ow.inputs[2].insert(0, owner.blockSize); // Insert Zeros
                    ow.inputsActive[2] = false;
                }
            }
            if ((channels > 2) && (ow.channels > 3))
            {
                if (ioD.connectedTo != null)
                {
                    ow.inputs[3].insert(ioD.connectedTo.output);
                    ow.inputsActive[3] = true;
                }
                else
                {
                    ow.inputs[3].insert(0, owner.blockSize); // Insert Zeros
                    ow.inputsActive[3] = false;
                }
            }
        }

        public override void Disconnect()
        {
            base.Disconnect();
            if (ow != null)
            {
                ow.CanClose = true;
                ow.Close();
                ow.spectrumAnalyzer = null;
                ow = null;
            }

        }

        class RegisterClass : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Tools", "Spectrum Analyzer" }; }
            public override RTForm Instantiate() { return new SpectrumAnalyzer(4); }
        }
        public static void Register(List<RTObjectReference> l) { l.Add(new RegisterClass()); }

    }
}
