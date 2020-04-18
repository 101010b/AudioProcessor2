using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace AudioProcessor.SinkSource
{
    public class WavFileReader : RTForm
    {

        public void InitializeComponent()
        {
            this.bnFile = new AudioProcessor.RTButton();
            this.io1 = new AudioProcessor.RTIO();
            this.io2 = new AudioProcessor.RTIO();
            this.io3 = new AudioProcessor.RTIO();
            this.io4 = new AudioProcessor.RTIO();
            this.ioGate = new AudioProcessor.RTIO();
            this.bnLoop = new AudioProcessor.RTButton();
            this.bnReset = new AudioProcessor.RTButton();
            this.dlAmp = new AudioProcessor.RTDial();
            this.dlSpeed = new AudioProcessor.RTDial();
            this.ioSpeed = new AudioProcessor.RTIO();
            this.ledPlay = new AudioProcessor.RTLED();
            this.io8 = new AudioProcessor.RTIO();
            this.io7 = new AudioProcessor.RTIO();
            this.io6 = new AudioProcessor.RTIO();
            this.io5 = new AudioProcessor.RTIO();
            this.SuspendLayout();
            // 
            // bnFile
            // 
            this.bnFile.buttonDim = new System.Drawing.Size(200, 20);
            this.bnFile.buttonState = false;
            this.bnFile.buttonType = AudioProcessor.RTButton.RTButtonType.ClickButton;
            this.bnFile.fillOffColor = System.Drawing.Color.Black;
            this.bnFile.fillOnColor = System.Drawing.Color.DarkRed;
            this.bnFile.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnFile.frameOffColor = System.Drawing.Color.DimGray;
            this.bnFile.frameOnColor = System.Drawing.Color.Red;
            this.bnFile.Location = new System.Drawing.Point(71, 22);
            this.bnFile.Name = "bnFile";
            this.bnFile.offText = "[NONE]";
            this.bnFile.onText = "[NONE]";
            this.bnFile.Size = new System.Drawing.Size(215, 63);
            this.bnFile.TabIndex = 0;
            this.bnFile.Text = "rtButton1";
            this.bnFile.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnFile.textOffColor = System.Drawing.Color.DimGray;
            this.bnFile.textOnColor = System.Drawing.Color.Red;
            this.bnFile.title = "File";
            this.bnFile.titleColor = System.Drawing.Color.DimGray;
            this.bnFile.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnFile.titlePos = AudioProcessor.RTButton.RTTitlePos.Above;
            // 
            // io1
            // 
            this.io1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.io1.contactBackColor = System.Drawing.Color.Black;
            this.io1.contactColor = System.Drawing.Color.DimGray;
            this.io1.Location = new System.Drawing.Point(454, 39);
            this.io1.Name = "io1";
            this.io1.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.io1.showTitle = true;
            this.io1.Size = new System.Drawing.Size(57, 20);
            this.io1.TabIndex = 1;
            this.io1.Text = "rtio1";
            this.io1.title = "L,1";
            this.io1.titleColor = System.Drawing.Color.DimGray;
            this.io1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io1.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // io2
            // 
            this.io2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.io2.contactBackColor = System.Drawing.Color.Black;
            this.io2.contactColor = System.Drawing.Color.DimGray;
            this.io2.Location = new System.Drawing.Point(454, 65);
            this.io2.Name = "io2";
            this.io2.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.io2.showTitle = true;
            this.io2.Size = new System.Drawing.Size(57, 20);
            this.io2.TabIndex = 2;
            this.io2.Text = "rtio2";
            this.io2.title = "R,2";
            this.io2.titleColor = System.Drawing.Color.DimGray;
            this.io2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io2.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // io3
            // 
            this.io3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.io3.contactBackColor = System.Drawing.Color.Black;
            this.io3.contactColor = System.Drawing.Color.DimGray;
            this.io3.Location = new System.Drawing.Point(454, 91);
            this.io3.Name = "io3";
            this.io3.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.io3.showTitle = true;
            this.io3.Size = new System.Drawing.Size(57, 20);
            this.io3.TabIndex = 3;
            this.io3.Text = "rtio3";
            this.io3.title = "3";
            this.io3.titleColor = System.Drawing.Color.DimGray;
            this.io3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io3.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // io4
            // 
            this.io4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.io4.contactBackColor = System.Drawing.Color.Black;
            this.io4.contactColor = System.Drawing.Color.DimGray;
            this.io4.Location = new System.Drawing.Point(454, 117);
            this.io4.Name = "io4";
            this.io4.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.io4.showTitle = true;
            this.io4.Size = new System.Drawing.Size(57, 20);
            this.io4.TabIndex = 4;
            this.io4.Text = "rtio4";
            this.io4.title = "4";
            this.io4.titleColor = System.Drawing.Color.DimGray;
            this.io4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io4.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioGate
            // 
            this.ioGate.contactBackColor = System.Drawing.Color.Black;
            this.ioGate.contactColor = System.Drawing.Color.DimGray;
            this.ioGate.Location = new System.Drawing.Point(0, 39);
            this.ioGate.Name = "ioGate";
            this.ioGate.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioGate.showTitle = true;
            this.ioGate.Size = new System.Drawing.Size(59, 20);
            this.ioGate.TabIndex = 5;
            this.ioGate.Text = "rtio5";
            this.ioGate.title = "Gate";
            this.ioGate.titleColor = System.Drawing.Color.DimGray;
            this.ioGate.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioGate.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // bnLoop
            // 
            this.bnLoop.buttonDim = new System.Drawing.Size(30, 15);
            this.bnLoop.buttonState = false;
            this.bnLoop.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bnLoop.fillOffColor = System.Drawing.Color.Black;
            this.bnLoop.fillOnColor = System.Drawing.Color.DarkRed;
            this.bnLoop.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnLoop.frameOffColor = System.Drawing.Color.DimGray;
            this.bnLoop.frameOnColor = System.Drawing.Color.Red;
            this.bnLoop.Location = new System.Drawing.Point(178, 80);
            this.bnLoop.Name = "bnLoop";
            this.bnLoop.offText = "Off";
            this.bnLoop.onText = "On";
            this.bnLoop.Size = new System.Drawing.Size(108, 31);
            this.bnLoop.TabIndex = 7;
            this.bnLoop.Text = "rtButton3";
            this.bnLoop.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnLoop.textOffColor = System.Drawing.Color.DimGray;
            this.bnLoop.textOnColor = System.Drawing.Color.Red;
            this.bnLoop.title = "Loop";
            this.bnLoop.titleColor = System.Drawing.Color.DimGray;
            this.bnLoop.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnLoop.titlePos = AudioProcessor.RTButton.RTTitlePos.Left;
            // 
            // bnReset
            // 
            this.bnReset.buttonDim = new System.Drawing.Size(50, 15);
            this.bnReset.buttonState = false;
            this.bnReset.buttonType = AudioProcessor.RTButton.RTButtonType.ClickButton;
            this.bnReset.fillOffColor = System.Drawing.Color.Black;
            this.bnReset.fillOnColor = System.Drawing.Color.DarkRed;
            this.bnReset.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnReset.frameOffColor = System.Drawing.Color.DimGray;
            this.bnReset.frameOnColor = System.Drawing.Color.Red;
            this.bnReset.Location = new System.Drawing.Point(71, 80);
            this.bnReset.Name = "bnReset";
            this.bnReset.offText = "Reset";
            this.bnReset.onText = "Reset";
            this.bnReset.Size = new System.Drawing.Size(63, 31);
            this.bnReset.TabIndex = 8;
            this.bnReset.Text = "rtButton4";
            this.bnReset.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnReset.textOffColor = System.Drawing.Color.DimGray;
            this.bnReset.textOnColor = System.Drawing.Color.Red;
            this.bnReset.title = "Button";
            this.bnReset.titleColor = System.Drawing.Color.DimGray;
            this.bnReset.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnReset.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // dlAmp
            // 
            this.dlAmp.dialColor = System.Drawing.Color.Silver;
            this.dlAmp.dialDiameter = 50D;
            this.dlAmp.dialMarkColor = System.Drawing.Color.Red;
            this.dlAmp.format = "F0";
            this.dlAmp.Location = new System.Drawing.Point(289, 24);
            this.dlAmp.logScale = false;
            this.dlAmp.maxVal = 100D;
            this.dlAmp.minVal = -100D;
            this.dlAmp.Name = "dlAmp";
            this.dlAmp.scaleColor = System.Drawing.Color.Gold;
            this.dlAmp.showScale = true;
            this.dlAmp.showTitle = true;
            this.dlAmp.showValue = true;
            this.dlAmp.Size = new System.Drawing.Size(80, 100);
            this.dlAmp.TabIndex = 9;
            this.dlAmp.Text = "rtDial2";
            this.dlAmp.title = "Amplitude";
            this.dlAmp.titleColor = System.Drawing.Color.DimGray;
            this.dlAmp.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlAmp.unit = "dB";
            this.dlAmp.val = -20D;
            this.dlAmp.valueColor = System.Drawing.Color.DimGray;
            this.dlAmp.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dlSpeed
            // 
            this.dlSpeed.dialColor = System.Drawing.Color.Silver;
            this.dlSpeed.dialDiameter = 50D;
            this.dlSpeed.dialMarkColor = System.Drawing.Color.Red;
            this.dlSpeed.format = "F1";
            this.dlSpeed.Location = new System.Drawing.Point(375, 22);
            this.dlSpeed.logScale = false;
            this.dlSpeed.maxVal = 1000D;
            this.dlSpeed.minVal = -1000D;
            this.dlSpeed.Name = "dlSpeed";
            this.dlSpeed.scaleColor = System.Drawing.Color.Gold;
            this.dlSpeed.showScale = true;
            this.dlSpeed.showTitle = true;
            this.dlSpeed.showValue = true;
            this.dlSpeed.Size = new System.Drawing.Size(80, 100);
            this.dlSpeed.TabIndex = 10;
            this.dlSpeed.Text = "rtDial2";
            this.dlSpeed.title = "Speed";
            this.dlSpeed.titleColor = System.Drawing.Color.DimGray;
            this.dlSpeed.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlSpeed.unit = "%";
            this.dlSpeed.val = 100D;
            this.dlSpeed.valueColor = System.Drawing.Color.DimGray;
            this.dlSpeed.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioSpeed
            // 
            this.ioSpeed.contactBackColor = System.Drawing.Color.Black;
            this.ioSpeed.contactColor = System.Drawing.Color.DimGray;
            this.ioSpeed.Location = new System.Drawing.Point(0, 65);
            this.ioSpeed.Name = "ioSpeed";
            this.ioSpeed.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioSpeed.showTitle = true;
            this.ioSpeed.Size = new System.Drawing.Size(76, 20);
            this.ioSpeed.TabIndex = 11;
            this.ioSpeed.Text = "rtio5";
            this.ioSpeed.title = "Speed";
            this.ioSpeed.titleColor = System.Drawing.Color.DimGray;
            this.ioSpeed.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioSpeed.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ledPlay
            // 
            this.ledPlay.fillOffColor = System.Drawing.Color.Black;
            this.ledPlay.fillOnColor = System.Drawing.Color.DarkRed;
            this.ledPlay.frameOffColor = System.Drawing.Color.DimGray;
            this.ledPlay.frameOnColor = System.Drawing.Color.Red;
            this.ledPlay.LEDDim = new System.Drawing.Size(15, 15);
            this.ledPlay.LEDState = false;
            this.ledPlay.Location = new System.Drawing.Point(375, 3);
            this.ledPlay.Name = "ledPlay";
            this.ledPlay.offText = "";
            this.ledPlay.onText = "";
            this.ledPlay.Size = new System.Drawing.Size(76, 20);
            this.ledPlay.TabIndex = 12;
            this.ledPlay.Text = "rtled1";
            this.ledPlay.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ledPlay.textOffColor = System.Drawing.Color.DimGray;
            this.ledPlay.textOnColor = System.Drawing.Color.Red;
            this.ledPlay.title = "Play";
            this.ledPlay.titleColor = System.Drawing.Color.DimGray;
            this.ledPlay.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ledPlay.titlePos = AudioProcessor.RTLED.RTTitlePos.Left;
            // 
            // io8
            // 
            this.io8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.io8.contactBackColor = System.Drawing.Color.Black;
            this.io8.contactColor = System.Drawing.Color.DimGray;
            this.io8.Location = new System.Drawing.Point(454, 221);
            this.io8.Name = "io8";
            this.io8.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.io8.showTitle = true;
            this.io8.Size = new System.Drawing.Size(57, 20);
            this.io8.TabIndex = 16;
            this.io8.Text = "rtio4";
            this.io8.title = "8";
            this.io8.titleColor = System.Drawing.Color.DimGray;
            this.io8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io8.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // io7
            // 
            this.io7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.io7.contactBackColor = System.Drawing.Color.Black;
            this.io7.contactColor = System.Drawing.Color.DimGray;
            this.io7.Location = new System.Drawing.Point(454, 195);
            this.io7.Name = "io7";
            this.io7.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.io7.showTitle = true;
            this.io7.Size = new System.Drawing.Size(57, 20);
            this.io7.TabIndex = 15;
            this.io7.Text = "rtio3";
            this.io7.title = "7";
            this.io7.titleColor = System.Drawing.Color.DimGray;
            this.io7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io7.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // io6
            // 
            this.io6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.io6.contactBackColor = System.Drawing.Color.Black;
            this.io6.contactColor = System.Drawing.Color.DimGray;
            this.io6.Location = new System.Drawing.Point(454, 169);
            this.io6.Name = "io6";
            this.io6.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.io6.showTitle = true;
            this.io6.Size = new System.Drawing.Size(57, 20);
            this.io6.TabIndex = 14;
            this.io6.Text = "rtio2";
            this.io6.title = "6";
            this.io6.titleColor = System.Drawing.Color.DimGray;
            this.io6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io6.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // io5
            // 
            this.io5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.io5.contactBackColor = System.Drawing.Color.Black;
            this.io5.contactColor = System.Drawing.Color.DimGray;
            this.io5.Location = new System.Drawing.Point(454, 143);
            this.io5.Name = "io5";
            this.io5.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.io5.showTitle = true;
            this.io5.Size = new System.Drawing.Size(57, 20);
            this.io5.TabIndex = 13;
            this.io5.Text = "rtio1";
            this.io5.title = "5";
            this.io5.titleColor = System.Drawing.Color.DimGray;
            this.io5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io5.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // WavFileReader
            // 
            this.canShrink = false;
            this.Controls.Add(this.io8);
            this.Controls.Add(this.io7);
            this.Controls.Add(this.io6);
            this.Controls.Add(this.io5);
            this.Controls.Add(this.ledPlay);
            this.Controls.Add(this.ioSpeed);
            this.Controls.Add(this.dlSpeed);
            this.Controls.Add(this.dlAmp);
            this.Controls.Add(this.bnReset);
            this.Controls.Add(this.bnLoop);
            this.Controls.Add(this.ioGate);
            this.Controls.Add(this.io4);
            this.Controls.Add(this.io3);
            this.Controls.Add(this.io2);
            this.Controls.Add(this.io1);
            this.Controls.Add(this.bnFile);
            this.Name = "WavFileReader";
            this.shrinkTitle = "WaveFile";
            this.Size = new System.Drawing.Size(511, 248);
            this.title = "WaveFile";
            this.ResumeLayout(false);

        }

        int channels;

        AudioUtils.WaveData wave;
        String filename ="";
        bool running=false;
        double position;
        private RTButton bnFile;
        private RTIO io1;
        private RTIO io2;
        private RTIO io3;
        private RTIO io4;
        private RTIO ioGate;
        private RTButton bnLoop;
        private RTButton bnReset;
        private RTDial dlAmp;
        bool loop;
        private RTDial dlSpeed;
        private RTIO ioSpeed;
        private RTLED ledPlay;
        double amp;
        private RTIO io8;
        private RTIO io7;
        private RTIO io6;
        private RTIO io5;
        double speed;

        private int min(int a, int b) { return (a < b) ? a : b; }
        private int max(int a, int b) { return (a > b) ? a : b; }

        private string shortfile(string fn)
        {
            if (fn == null) return null;
            return Path.GetFileName(fn);
        }

        private void init()
        {
            InitializeComponent();

            int h = Height;
            if (channels < 8) { io8.Hide(); h = io8.Location.Y; }
            if (channels < 7) { io7.Hide(); h = io7.Location.Y; }
            if (channels < 6) { io6.Hide(); h = io6.Location.Y; }
            if (channels < 5) { io5.Hide(); h = io5.Location.Y; }
            if (channels < 4) { io4.Hide(); h = io5.Location.Y; }
            if (channels < 3) { io3.Hide(); h = io5.Location.Y; }
            if (channels < 2) { io2.Hide(); h = io5.Location.Y; }
            Height = h;

            if ((filename == null) || (filename.Length < 1))
                bnFile.offText = bnFile.onText = "[NONE]";
            else
                bnFile.offText = bnFile.onText = shortfile(filename);

            bnLoop.buttonState = loop;
            dlAmp.val = amp;
            dlSpeed.val = speed;

            bnLoop.buttonStateChanged += BnLoop_buttonStateChanged;
            bnReset.buttonStateChanged += BnReset_buttonStateChanged;
            bnFile.buttonStateChanged += BnFile_buttonStateChanged;
            dlAmp.valueChanged += DlAmp_valueChanged;
            dlSpeed.valueChanged += DlSpeed_valueChanged;

            processingType = ProcessingType.Source;
        }


        public WavFileReader():this(8)
        {
        }

        public WavFileReader(int _channels):base()
        {
            channels = _channels;
            filename = null;
            loop = true;
            amp = -20;
            speed = 100;
            init();
        }

        public WavFileReader(SystemPanel _owner, int _channels) : base(_owner)
        {
            channels = _channels;
            init();
        }

        public WavFileReader(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            channels = src.ReadInt32();
            filename = src.ReadString();
            loop = src.ReadBoolean();
            amp = src.ReadDouble();
            speed = src.ReadDouble();
            if ((filename != null) && filename.Equals("[NONE]"))
                filename = null;
            if ((filename != null) && (filename.Length > 0))
            {
                try
                {
                    wave = AudioUtils.WaveData.readWAV(filename);
                }
                catch (Exception e)
                {
                    _owner.logText(String.Format("Failed to read File {0}: {1}", filename, e.Message));
                    filename = null;
                }
            }
            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(channels);
            if ((wave == null) || !wave.valid || (filename == null) || (filename.Length < 1))
                tgt.Write("[NONE]");
            else
                tgt.Write(filename);
            tgt.Write(loop);
            tgt.Write(amp);
            tgt.Write(speed);
        }

        private void BnFile_buttonStateChanged(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "WAV File|*.wav";
            sfd.Title = "Open a WAV File";
            sfd.ShowDialog();

            // If the file name is not an empty string open it for reading.
            if (sfd.FileName != "")
            {
                // Try to read the file
                if (readWAVFile(sfd.FileName))
                {
                    filename = sfd.FileName;
                    bnFile.onText = bnFile.offText = shortfile(filename);
                }
            }
        }

        private void DlAmp_valueChanged(object sender, EventArgs e)
        {
            amp = dlAmp.val;
        }

        private void DlSpeed_valueChanged(object sender, EventArgs e)
        {
            speed = dlSpeed.val;
        }

        private void BnReset_buttonStateChanged(object sender, EventArgs e)
        {
            position = 0;
            if (wave != null)
                running = true;
        }

        private void BnLoop_buttonStateChanged(object sender, EventArgs e)
        {
            loop = bnLoop.buttonState;
        }
              
        private bool readWAVFile(String _filename)
        {
            try
            {
                AudioUtils.WaveData wvd = AudioUtils.WaveData.readWAV(_filename);
                position = 0;
                wave = wvd;
                filename = _filename;
                running = true;
            }
            catch (Exception e)
            {
                owner.logText(String.Format("Failed to load File {0}: {1}", _filename, e.Message));
                return false;
            }
            return true;
        }

        public override void tick()
        {
            if ((wave == null) || !wave.valid || !_active)
                return;

            DataBuffer dbgate = null;
            DataBuffer dbspeed = null;
            if (ioGate.connectedTo != null)
                dbgate = ioGate.connectedTo.output;
            if (ioSpeed.connectedTo != null)
                dbspeed = ioSpeed.connectedTo.output;
            int chs = min(channels, wave.channels);
            DataBuffer[] outputs = new DataBuffer[chs];
            if ((chs > 0) && (io1.connectedTo != null)) outputs[0] = io1.connectedTo.input;
            if ((chs > 1) && (io2.connectedTo != null)) outputs[1] = io2.connectedTo.input;
            if ((chs > 2) && (io3.connectedTo != null)) outputs[2] = io3.connectedTo.input;
            if ((chs > 3) && (io4.connectedTo != null)) outputs[3] = io4.connectedTo.input;
            if ((chs > 4) && (io5.connectedTo != null)) outputs[4] = io5.connectedTo.input;
            if ((chs > 5) && (io6.connectedTo != null)) outputs[5] = io6.connectedTo.input;
            if ((chs > 6) && (io7.connectedTo != null)) outputs[6] = io7.connectedTo.input;
            if ((chs > 7) && (io8.connectedTo != null)) outputs[7] = io8.connectedTo.input;
            double gain = Math.Pow(10, amp / 20);
            for (int i=0;i<owner.blockSize;i++)
            {
                if ((dbgate != null) && !running && (dbgate.data[i] > 0.5))
                {
                    position = 0;
                    running = true;
                }
                if ((dbgate != null) && running && (dbgate.data[i] < 0.0)) 
                    running = false;
                if (running)
                {
                    UInt64 idx = (UInt64)Math.Floor(position + 0.5);
                    if ((idx >= 0) && (idx < wave.samples))
                    {
                        for (int j = 0; j < chs; j++)
                            if (outputs[j] != null) outputs[j].data[i] = gain * wave.wave[j][idx];
                    }
                    double phi = speed/100.0 * owner.sampleRate / wave.samplerate;
                    if (dbspeed != null) phi *= dbspeed.data[i];
                    position += phi;
                    if (position < 0)
                    {
                        if (loop)
                            position += wave.samples;
                        else
                            running = false;
                    }
                    if (position >= wave.samples)
                    {
                        if (loop)
                            position -= wave.samples;
                        else
                            running = false;
                    }
                }
            }
            if (running && ledPlay.LEDState == false)
                ledPlay.LEDState = true;
            if (!running && ledPlay.LEDState == true)
                ledPlay.LEDState = false;
        }

        public override void Disconnect()
        {
            base.Disconnect();
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Source", "WavFileReader", "1 x" }; }
            public override RTForm Instantiate() { return new WavFileReader(1); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Source", "WavFileReader", "2 x" }; }
            public override RTForm Instantiate() { return new WavFileReader(2); }
        }
        class RegisterClass3 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Source", "WavFileReader", "4 x" }; }
            public override RTForm Instantiate() { return new WavFileReader(4); }
        }
        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Source", "WavFileReader", "8 x" }; }
            public override RTForm Instantiate() { return new WavFileReader(4); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
            l.Add(new RegisterClass2());
            l.Add(new RegisterClass3());
            l.Add(new RegisterClass4());
        }

    }
}
