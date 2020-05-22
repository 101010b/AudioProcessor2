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
    public class WavFileWriter : RTForm
    {

        public void InitializeComponent()
        {
            this.io1 = new AudioProcessor.RTIO();
            this.io2 = new AudioProcessor.RTIO();
            this.io3 = new AudioProcessor.RTIO();
            this.io4 = new AudioProcessor.RTIO();
            this.io8 = new AudioProcessor.RTIO();
            this.io7 = new AudioProcessor.RTIO();
            this.io6 = new AudioProcessor.RTIO();
            this.io5 = new AudioProcessor.RTIO();
            this.bnFile = new AudioProcessor.RTButton();
            this.ioGate = new AudioProcessor.RTIO();
            this.ledRecord = new AudioProcessor.RTLED();
            this.bnRecord = new AudioProcessor.RTButton();
            this.bnClose = new AudioProcessor.RTButton();
            this.SuspendLayout();
            // 
            // io1
            // 
            this.io1.contactBackColor = System.Drawing.Color.Black;
            this.io1.contactColor = System.Drawing.Color.DimGray;
            this.io1.Location = new System.Drawing.Point(0, 50);
            this.io1.Name = "io1";
            this.io1.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io1.showTitle = true;
            this.io1.Size = new System.Drawing.Size(55, 20);
            this.io1.TabIndex = 0;
            this.io1.Text = "rtio1";
            this.io1.title = "1,L";
            this.io1.titleColor = System.Drawing.Color.DimGray;
            this.io1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io1.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // io2
            // 
            this.io2.contactBackColor = System.Drawing.Color.Black;
            this.io2.contactColor = System.Drawing.Color.DimGray;
            this.io2.Location = new System.Drawing.Point(0, 76);
            this.io2.Name = "io2";
            this.io2.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io2.showTitle = true;
            this.io2.Size = new System.Drawing.Size(55, 20);
            this.io2.TabIndex = 1;
            this.io2.Text = "rtio2";
            this.io2.title = "2,R";
            this.io2.titleColor = System.Drawing.Color.DimGray;
            this.io2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io2.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // io3
            // 
            this.io3.contactBackColor = System.Drawing.Color.Black;
            this.io3.contactColor = System.Drawing.Color.DimGray;
            this.io3.Location = new System.Drawing.Point(0, 102);
            this.io3.Name = "io3";
            this.io3.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io3.showTitle = true;
            this.io3.Size = new System.Drawing.Size(55, 20);
            this.io3.TabIndex = 2;
            this.io3.Text = "rtio3";
            this.io3.title = "3";
            this.io3.titleColor = System.Drawing.Color.DimGray;
            this.io3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io3.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // io4
            // 
            this.io4.contactBackColor = System.Drawing.Color.Black;
            this.io4.contactColor = System.Drawing.Color.DimGray;
            this.io4.Location = new System.Drawing.Point(0, 128);
            this.io4.Name = "io4";
            this.io4.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io4.showTitle = true;
            this.io4.Size = new System.Drawing.Size(55, 20);
            this.io4.TabIndex = 3;
            this.io4.Text = "rtio4";
            this.io4.title = "4";
            this.io4.titleColor = System.Drawing.Color.DimGray;
            this.io4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io4.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // io8
            // 
            this.io8.contactBackColor = System.Drawing.Color.Black;
            this.io8.contactColor = System.Drawing.Color.DimGray;
            this.io8.Location = new System.Drawing.Point(0, 232);
            this.io8.Name = "io8";
            this.io8.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io8.showTitle = true;
            this.io8.Size = new System.Drawing.Size(55, 20);
            this.io8.TabIndex = 7;
            this.io8.Text = "rtio5";
            this.io8.title = "8";
            this.io8.titleColor = System.Drawing.Color.DimGray;
            this.io8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io8.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // io7
            // 
            this.io7.contactBackColor = System.Drawing.Color.Black;
            this.io7.contactColor = System.Drawing.Color.DimGray;
            this.io7.Location = new System.Drawing.Point(0, 206);
            this.io7.Name = "io7";
            this.io7.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io7.showTitle = true;
            this.io7.Size = new System.Drawing.Size(55, 20);
            this.io7.TabIndex = 6;
            this.io7.Text = "rtio6";
            this.io7.title = "7";
            this.io7.titleColor = System.Drawing.Color.DimGray;
            this.io7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io7.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // io6
            // 
            this.io6.contactBackColor = System.Drawing.Color.Black;
            this.io6.contactColor = System.Drawing.Color.DimGray;
            this.io6.Location = new System.Drawing.Point(0, 180);
            this.io6.Name = "io6";
            this.io6.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io6.showTitle = true;
            this.io6.Size = new System.Drawing.Size(55, 20);
            this.io6.TabIndex = 5;
            this.io6.Text = "rtio7";
            this.io6.title = "6";
            this.io6.titleColor = System.Drawing.Color.DimGray;
            this.io6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io6.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // io5
            // 
            this.io5.contactBackColor = System.Drawing.Color.Black;
            this.io5.contactColor = System.Drawing.Color.DimGray;
            this.io5.Location = new System.Drawing.Point(0, 154);
            this.io5.Name = "io5";
            this.io5.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io5.showTitle = true;
            this.io5.Size = new System.Drawing.Size(55, 20);
            this.io5.TabIndex = 4;
            this.io5.Text = "rtio8";
            this.io5.title = "5";
            this.io5.titleColor = System.Drawing.Color.DimGray;
            this.io5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io5.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
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
            this.bnFile.Location = new System.Drawing.Point(75, 21);
            this.bnFile.Name = "bnFile";
            this.bnFile.offText = "[NONE]";
            this.bnFile.onText = "[NONE]";
            this.bnFile.Size = new System.Drawing.Size(215, 63);
            this.bnFile.TabIndex = 8;
            this.bnFile.Text = "rtButton1";
            this.bnFile.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnFile.textOffColor = System.Drawing.Color.DimGray;
            this.bnFile.textOnColor = System.Drawing.Color.Red;
            this.bnFile.title = "File";
            this.bnFile.titleColor = System.Drawing.Color.DimGray;
            this.bnFile.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnFile.titlePos = AudioProcessor.RTButton.RTTitlePos.Above;
            // 
            // ioGate
            // 
            this.ioGate.contactBackColor = System.Drawing.Color.Black;
            this.ioGate.contactColor = System.Drawing.Color.DimGray;
            this.ioGate.Location = new System.Drawing.Point(0, 21);
            this.ioGate.Name = "ioGate";
            this.ioGate.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioGate.showTitle = true;
            this.ioGate.Size = new System.Drawing.Size(55, 20);
            this.ioGate.TabIndex = 9;
            this.ioGate.Text = "rtio1";
            this.ioGate.title = "gate";
            this.ioGate.titleColor = System.Drawing.Color.DimGray;
            this.ioGate.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioGate.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ledRecord
            // 
            this.ledRecord.fillOffColor = System.Drawing.Color.Black;
            this.ledRecord.fillOnColor = System.Drawing.Color.DarkRed;
            this.ledRecord.frameOffColor = System.Drawing.Color.DimGray;
            this.ledRecord.frameOnColor = System.Drawing.Color.Red;
            this.ledRecord.LEDDim = new System.Drawing.Size(15, 15);
            this.ledRecord.LEDState = false;
            this.ledRecord.Location = new System.Drawing.Point(241, 3);
            this.ledRecord.Name = "ledRecord";
            this.ledRecord.offText = "";
            this.ledRecord.onText = "";
            this.ledRecord.Size = new System.Drawing.Size(114, 29);
            this.ledRecord.TabIndex = 10;
            this.ledRecord.Text = "rtled1";
            this.ledRecord.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ledRecord.textOffColor = System.Drawing.Color.DimGray;
            this.ledRecord.textOnColor = System.Drawing.Color.Red;
            this.ledRecord.title = "Recording";
            this.ledRecord.titleColor = System.Drawing.Color.DimGray;
            this.ledRecord.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ledRecord.titlePos = AudioProcessor.RTLED.RTTitlePos.Left;
            // 
            // bnRecord
            // 
            this.bnRecord.buttonDim = new System.Drawing.Size(50, 20);
            this.bnRecord.buttonState = false;
            this.bnRecord.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bnRecord.fillOffColor = System.Drawing.Color.Black;
            this.bnRecord.fillOnColor = System.Drawing.Color.DarkRed;
            this.bnRecord.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnRecord.frameOffColor = System.Drawing.Color.DimGray;
            this.bnRecord.frameOnColor = System.Drawing.Color.Red;
            this.bnRecord.Location = new System.Drawing.Point(76, 84);
            this.bnRecord.Name = "bnRecord";
            this.bnRecord.offText = "Idle";
            this.bnRecord.onText = "Record";
            this.bnRecord.Size = new System.Drawing.Size(64, 31);
            this.bnRecord.TabIndex = 11;
            this.bnRecord.Text = "rtButton1";
            this.bnRecord.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnRecord.textOffColor = System.Drawing.Color.DimGray;
            this.bnRecord.textOnColor = System.Drawing.Color.Red;
            this.bnRecord.title = "Record";
            this.bnRecord.titleColor = System.Drawing.Color.DimGray;
            this.bnRecord.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnRecord.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // bnClose
            // 
            this.bnClose.buttonDim = new System.Drawing.Size(60, 20);
            this.bnClose.buttonState = false;
            this.bnClose.buttonType = AudioProcessor.RTButton.RTButtonType.ClickButton;
            this.bnClose.fillOffColor = System.Drawing.Color.Black;
            this.bnClose.fillOnColor = System.Drawing.Color.DarkRed;
            this.bnClose.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnClose.frameOffColor = System.Drawing.Color.DimGray;
            this.bnClose.frameOnColor = System.Drawing.Color.Red;
            this.bnClose.Location = new System.Drawing.Point(289, 48);
            this.bnClose.Name = "bnClose";
            this.bnClose.offText = "Close";
            this.bnClose.onText = "Close";
            this.bnClose.Size = new System.Drawing.Size(76, 31);
            this.bnClose.TabIndex = 12;
            this.bnClose.Text = "rtButton2";
            this.bnClose.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnClose.textOffColor = System.Drawing.Color.DimGray;
            this.bnClose.textOnColor = System.Drawing.Color.Red;
            this.bnClose.title = "Close";
            this.bnClose.titleColor = System.Drawing.Color.DimGray;
            this.bnClose.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnClose.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // WavFileWriter
            // 
            this.canShrink = false;
            this.Controls.Add(this.bnClose);
            this.Controls.Add(this.bnRecord);
            this.Controls.Add(this.ledRecord);
            this.Controls.Add(this.ioGate);
            this.Controls.Add(this.bnFile);
            this.Controls.Add(this.io8);
            this.Controls.Add(this.io7);
            this.Controls.Add(this.io6);
            this.Controls.Add(this.io5);
            this.Controls.Add(this.io4);
            this.Controls.Add(this.io3);
            this.Controls.Add(this.io2);
            this.Controls.Add(this.io1);
            this.hasActiveSwitch = false;
            this.Name = "WavFileWriter";
            this.Size = new System.Drawing.Size(378, 259);
            this.title = "WaveFile";
            this.ResumeLayout(false);

        }

        int channels;
        BinaryWriter outputFile;
        String filename;
        Boolean online;
        int samples;
        private enum FileWriterCommand
        {
            Idle,
            GoOnline,
            GoOffline
        }
        FileWriterCommand fileWriterCommand = FileWriterCommand.Idle;
        Boolean isActive = false;
        Boolean oldIsActive = false;
        private RTIO io1;
        private RTIO io2;
        private RTIO io3;
        private RTIO io4;
        private RTIO io8;
        private RTIO io7;
        private RTIO io6;
        private RTIO io5;
        private RTButton bnFile;
        private RTIO ioGate;
        private RTLED ledRecord;
        private RTButton bnRecord;
        private RTButton bnClose;
        Boolean manualActive = false;

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
            if (channels < 4) { io4.Hide(); h = io4.Location.Y; }
            if (channels < 3) { io3.Hide(); h = io4.Location.Y; }
            if (channels < 2) { io2.Hide(); h = io4.Location.Y; }
            Height = h;

            if ((filename == null) || (filename.Length < 1))
                bnFile.onText = bnFile.offText = "[NONE]";
            else
                bnFile.onText = bnFile.offText = shortfile(filename);

            ledRecord.LEDState = false;
            bnRecord.buttonStateChanged += BnRecord_buttonStateChanged;
            bnClose.buttonStateChanged += BnClose_buttonStateChanged;
            bnFile.buttonStateChanged += BnFile_buttonStateChanged;

            processingType = ProcessingType.Sink;
        }


        public WavFileWriter(): this(8)
        {
        }

        public WavFileWriter(int _channels): base()
        {
            channels = _channels;
            outputFile = null;
            filename = null;
            online = false;
            fileWriterCommand = FileWriterCommand.Idle;

            init();
        }

        public WavFileWriter(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            channels = src.ReadInt32();
            filename = src.ReadString();
            if ((filename == null) || (filename.Length < 1) || filename.Equals("[NONE]"))
                filename = null;
            outputFile = null;
            online = false;
            fileWriterCommand = FileWriterCommand.Idle;

            init();

            if (filename != null)
                fileWriterCommand = FileWriterCommand.GoOnline;
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(channels);
            if ((filename == null) || (filename.Length < 1))
                tgt.Write("[NONE]");
            else
                tgt.Write(filename);
        }

        private void BnClose_buttonStateChanged(object sender, EventArgs e)
        {
            fileWriterCommand = FileWriterCommand.GoOffline;
            filename = null;
            bnFile.onText = bnFile.offText = "[NONE]";
        }

        private void BnRecord_buttonStateChanged(object sender, EventArgs e)
        {
            manualActive = bnRecord.buttonState;
        }

        private void BnFile_buttonStateChanged(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "WAV File|*.wav";
            sfd.Title = "Save a WAV File";
            sfd.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (sfd.FileName != "")
            {
                filename = sfd.FileName;
                bnFile.onText = bnFile.offText = shortfile(filename);
                fileWriterCommand = FileWriterCommand.GoOnline;
            }
        }

        private void writeRIFFHeader(string name)
        {
            for (int i = 0; i < 4; i++)
                outputFile.Write((sbyte)name[i]);
        }

        private void writeInt32(int val)
        {
            outputFile.Write((int)val);
        }

        private void writeInt16(int val)
        {
            outputFile.Write((short)val);
        }

        private void writeWAVHeader()
        {
            int subchunk1size = 16;
            int subchunk2size = samples * channels * 2;

            // Header
            writeRIFFHeader("RIFF");
            writeInt32(4 + (8 + subchunk1size) + (8 + subchunk2size));
            writeRIFFHeader("WAVE");

            // SubChunk 1 (fmt)
            writeRIFFHeader("fmt ");
            writeInt32(subchunk1size);
            writeInt16(1);
            writeInt16(channels);
            writeInt32(owner.sampleRate);
            writeInt32(owner.sampleRate * channels * 2);
            writeInt16(channels * 2);
            writeInt16(16);

            // SubChunk2 (data)
            writeRIFFHeader("data");
            writeInt32(subchunk2size);
        }

        private void stopFile()
        {
            if (outputFile == null) return;

            // update Header
            outputFile.Seek(0, SeekOrigin.Begin);
            writeWAVHeader();

            // Close File
            outputFile.Close();
            outputFile = null;
            online = false;
        }

        private void startFile()
        {
            if (outputFile != null)
                stopFile();
            outputFile = null;
            online = false;
            samples = 0;
            if ((filename == null) || (filename.Length < 1)) return;
            try
            {
                outputFile = new BinaryWriter(new FileStream(filename, FileMode.Create));
            } catch (Exception e)
            {
                outputFile = null;
                owner.logText("Cannot Open File: " + e.Message);
                owner.showLogWin();
                return;
            }
            online = true;
            writeWAVHeader();
        }

        Int16[] writeBuf;
        Boolean[] active;

        private Int16 doubleToInt16(double d)
        {
            d *= 32767.0;
            if (d > 32767.0) return 32767;
            if (d < -32768.0) return -32768;
            return (Int16)Math.Floor(d + 0.5);
        }

        public override void tick()
        {
            if (fileWriterCommand == FileWriterCommand.GoOnline)
            {
                if (online)
                    stopFile();
                if (!online)
                    startFile();
                fileWriterCommand = FileWriterCommand.Idle;
            }
            if (fileWriterCommand == FileWriterCommand.GoOffline)
            {
                if (online)
                    stopFile();
                fileWriterCommand = FileWriterCommand.Idle;
            }
            if (online)
            {
                if ((writeBuf == null) || (writeBuf.Length != channels * owner.blockSize))
                    writeBuf = new Int16[channels * owner.blockSize];
                if ((active == null) || (active.Length != owner.blockSize))
                    active = new Boolean[owner.blockSize];
                Array.Clear(writeBuf, 0, writeBuf.Length);
                int smps = 0;

                SignalBuffer[] dbin = new SignalBuffer[channels];
                if ((channels > 0) && (io1.connectedTo != null)) dbin[0] = io1.connectedTo.signalOutput;
                if ((channels > 1) && (io2.connectedTo != null)) dbin[1] = io2.connectedTo.signalOutput;
                if ((channels > 2) && (io3.connectedTo != null)) dbin[2] = io3.connectedTo.signalOutput;
                if ((channels > 3) && (io4.connectedTo != null)) dbin[3] = io4.connectedTo.signalOutput;
                if ((channels > 4) && (io5.connectedTo != null)) dbin[4] = io5.connectedTo.signalOutput;
                if ((channels > 5) && (io6.connectedTo != null)) dbin[5] = io6.connectedTo.signalOutput;
                if ((channels > 6) && (io7.connectedTo != null)) dbin[6] = io7.connectedTo.signalOutput;
                if ((channels > 7) && (io8.connectedTo != null)) dbin[7] = io8.connectedTo.signalOutput;

                if (ioGate.connectedTo != null)
                {
                    SignalBuffer db = ioGate.connectedTo.signalOutput;
                    for (int i = 0; i < owner.blockSize; i++)
                    {
                        active[i] = (db.data[i] > 0.5) && manualActive;
                        if (active[i])
                            smps++;
                    }
                } else
                {
                    for (int i = 0; i < owner.blockSize; i++)
                        active[i] = manualActive;
                    if (manualActive)
                        smps = owner.blockSize;
                }
                for (int i = 0; i < channels; i++)
                    if (dbin[i] != null)
                    {
                        int idx = i;
                        for (int j = 0; j < owner.blockSize; j++, idx += channels)
                            writeBuf[idx] = doubleToInt16(dbin[i].data[j]);
                    }
                try
                {
                    for (int i = 0; i < smps * channels; i++)
                        outputFile.Write(writeBuf[i]);
                } catch (Exception e) { }
                isActive = active[owner.blockSize - 1];
                samples += smps;
            } else
                isActive = false;

            if (isActive && !ledRecord.LEDState)
                ledRecord.LEDState = true;
            if (!isActive && ledRecord.LEDState)
                ledRecord.LEDState = false;
        }

        public override void Disconnect()
        {
            if (online)
                stopFile();
            base.Disconnect();
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Sink", "WavFileWriter","1 x" }; }
            public override RTForm Instantiate() { return new WavFileWriter(1); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Sink", "WavFileWriter", "2 x" }; }
            public override RTForm Instantiate() { return new WavFileWriter(2); }
        }
        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Sink", "WavFileWriter", "4 x" }; }
            public override RTForm Instantiate() { return new WavFileWriter(4); }
        }
        class RegisterClass8 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Sink", "WavFileWriter", "8 x" }; }
            public override RTForm Instantiate() { return new WavFileWriter(8); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
            l.Add(new RegisterClass2());
            l.Add(new RegisterClass4());
            l.Add(new RegisterClass8());
        }

    }
}
