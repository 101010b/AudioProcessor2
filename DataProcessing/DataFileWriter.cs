using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace AudioProcessor.DataProcessing
{
    public class DataFileWriter : RTForm
    {

        public void InitializeComponent()
        {
            this.bnFile = new AudioProcessor.RTButton();
            this.ioData = new AudioProcessor.RTIO();
            this.ledRecord = new AudioProcessor.RTLED();
            this.bnRecord = new AudioProcessor.RTButton();
            this.bnClose = new AudioProcessor.RTButton();
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
            this.bnFile.hideOnShrink = true;
            this.bnFile.Location = new System.Drawing.Point(57, 21);
            this.bnFile.Name = "bnFile";
            this.bnFile.offText = "[NONE]";
            this.bnFile.onText = "[NONE]";
            this.bnFile.Size = new System.Drawing.Size(215, 57);
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
            // ioData
            // 
            this.ioData.contactBackColor = System.Drawing.Color.Black;
            this.ioData.contactColor = System.Drawing.Color.DimGray;
            this.ioData.contactHighlightColor = System.Drawing.Color.Red;
            this.ioData.hideOnShrink = false;
            this.ioData.highlighted = false;
            this.ioData.IOtype = AudioProcessor.RTIO.ProcessingIOType.DataInput;
            this.ioData.Location = new System.Drawing.Point(0, 21);
            this.ioData.Name = "ioData";
            this.ioData.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioData.showTitle = true;
            this.ioData.Size = new System.Drawing.Size(55, 20);
            this.ioData.TabIndex = 9;
            this.ioData.Text = "rtio1";
            this.ioData.title = "data";
            this.ioData.titleColor = System.Drawing.Color.DimGray;
            this.ioData.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ledRecord
            // 
            this.ledRecord.fillOffColor = System.Drawing.Color.Black;
            this.ledRecord.fillOnColor = System.Drawing.Color.DarkRed;
            this.ledRecord.frameOffColor = System.Drawing.Color.DimGray;
            this.ledRecord.frameOnColor = System.Drawing.Color.Red;
            this.ledRecord.hideOnShrink = true;
            this.ledRecord.LEDDim = new System.Drawing.Size(15, 15);
            this.ledRecord.LEDState = false;
            this.ledRecord.Location = new System.Drawing.Point(231, 3);
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
            this.bnRecord.hideOnShrink = true;
            this.bnRecord.Location = new System.Drawing.Point(64, 80);
            this.bnRecord.Name = "bnRecord";
            this.bnRecord.offText = "Idle";
            this.bnRecord.onText = "Record";
            this.bnRecord.Size = new System.Drawing.Size(51, 21);
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
            this.bnClose.hideOnShrink = true;
            this.bnClose.Location = new System.Drawing.Point(276, 47);
            this.bnClose.Name = "bnClose";
            this.bnClose.offText = "Close";
            this.bnClose.onText = "Close";
            this.bnClose.Size = new System.Drawing.Size(61, 21);
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
            // DataFileWriter
            // 
            this.canShrink = false;
            this.Controls.Add(this.bnClose);
            this.Controls.Add(this.bnRecord);
            this.Controls.Add(this.ledRecord);
            this.Controls.Add(this.ioData);
            this.Controls.Add(this.bnFile);
            this.hasActiveSwitch = false;
            this.Name = "DataFileWriter";
            this.shrinkTitle = "DataFileWriter";
            this.Size = new System.Drawing.Size(378, 116);
            this.title = "DataFileWriter";
            this.ResumeLayout(false);

        }

        StreamWriter outputFile;
        String filename;
        bool online;
        int samples;
        private enum FileWriterCommand
        {
            Idle,
            GoOnline,
            GoOffline
        }
        FileWriterCommand fileWriterCommand = FileWriterCommand.Idle;
        bool isActive = false;
        // bool oldIsActive = false;
        private RTButton bnFile;
        private RTIO ioData;
        private RTLED ledRecord;
        private RTButton bnRecord;
        private RTButton bnClose;
        bool manualActive = false;
        bool firstline = true;

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

        public DataFileWriter() : base()
        {
            outputFile = null;
            filename = null;
            online = false;
            fileWriterCommand = FileWriterCommand.Idle;

            init();
        }

        public DataFileWriter(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
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
            sfd.Filter = "Data File|*.xml";
            sfd.Title = "Save as XML File";
            sfd.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (sfd.FileName != "")
            {
                filename = sfd.FileName;
                bnFile.onText = bnFile.offText = shortfile(filename);
                fileWriterCommand = FileWriterCommand.GoOnline;
            }
        }

        public static DateTime UnixTimeStampToDateTime(Int64 unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        private void writeXMLHeader(Int64 offset)
        {
            outputFile.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            outputFile.WriteLine("<recording>");
            outputFile.WriteLine(string.Format("<tstartUXUTC>{0}</tstartUXUTC>", offset));
            outputFile.WriteLine(string.Format("<tstartTXT>{0}</tstartTXT>", 
                UnixTimeStampToDateTime(offset).ToString("yyyy-MM-dd HH:mm:ss")));
            outputFile.WriteLine(string.Format("<node>{0}</node>", System.Environment.MachineName));
            outputFile.WriteLine(string.Format("<user>{0}</user>", System.Environment.UserName));
            outputFile.WriteLine(string.Format("<sampleRate>{0}</sampleRate>", owner.sampleRate));
            outputFile.WriteLine(string.Format("<blockSize>{0}</blockSize>", owner.blockSize));
            firstline = true;
        }

        private void writeXMLFooter()
        {
            outputFile.WriteLine("</recording>");
        }

        private void stopFile()
        {
            if (outputFile == null) return;

            writeXMLFooter();

            // Close File
            outputFile.Close();
            outputFile = null;
            online = false;
        }

        private void startFile(Int64 offset)
        {
            if (outputFile != null)
                stopFile();
            outputFile = null;
            online = false;
            samples = 0;
            if ((filename == null) || (filename.Length < 1)) return;
            try
            {
                outputFile = new StreamWriter(new FileStream(filename, FileMode.Create));
            }
            catch (Exception e)
            {
                outputFile = null;
                owner.logText("Cannot Open File: " + e.Message);
                owner.showLogWin();
                return;
            }
            online = true;
            writeXMLHeader(offset);
        }

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
                    startFile(owner.timeStampOffset);
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
                DataBuffer db = getDataInputBuffer(ioData);
                if ((db != null) && (db.size > 0))
                {
                    if (manualActive)
                    {
                        isActive = true;
                        outputFile.Write(string.Format("<dset><blk>{0}</blk><tofs>{1}</tofs>",
                            owner.timeStamp, (double)owner.timeStamp*owner.blockSize / owner.sampleRate));
                        outputFile.Write(string.Format("<data>{0}",db.get(0)));
                        for (int i = 1; i < db.size; i++)
                            outputFile.Write(string.Format(",{0}", db.get(i)));
                        outputFile.WriteLine("</data></dset>");
                    } else
                    {
                        isActive = false;
                    }
                } 
                if (db == null)
                {
                    isActive = false;
                }
            }
            else
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
            public override List<string> GetAddress() { return new List<string> { "Data", "DataFileWriter" }; }
            public override RTForm Instantiate() { return new DataFileWriter(); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
        }

    }
}
