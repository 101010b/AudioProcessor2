using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Wave.Asio;
using System.IO;


namespace AudioProcessor.RealtimeSinkSource
{
    public class ASIODevice : GenericNAudioSinkSource
    {

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ASIODevice));
            this.ledOvl = new AudioProcessor.RTLED();
            this.ioO2 = new AudioProcessor.RTIO();
            this.ioO1 = new AudioProcessor.RTIO();
            this.slDev = new AudioProcessor.RTSelector();
            this.ioI2 = new AudioProcessor.RTIO();
            this.ioI1 = new AudioProcessor.RTIO();
            this.ioI4 = new AudioProcessor.RTIO();
            this.ioI3 = new AudioProcessor.RTIO();
            this.ioI8 = new AudioProcessor.RTIO();
            this.ioI7 = new AudioProcessor.RTIO();
            this.ioI6 = new AudioProcessor.RTIO();
            this.ioI5 = new AudioProcessor.RTIO();
            this.ioO4 = new AudioProcessor.RTIO();
            this.ioO3 = new AudioProcessor.RTIO();
            this.ioO8 = new AudioProcessor.RTIO();
            this.ioO7 = new AudioProcessor.RTIO();
            this.ioO6 = new AudioProcessor.RTIO();
            this.ioO5 = new AudioProcessor.RTIO();
            this.SuspendLayout();
            // 
            // ledOvl
            // 
            this.ledOvl.fillOffColor = System.Drawing.Color.Black;
            this.ledOvl.fillOnColor = System.Drawing.Color.DarkRed;
            this.ledOvl.frameOffColor = System.Drawing.Color.DimGray;
            this.ledOvl.frameOnColor = System.Drawing.Color.Red;
            this.ledOvl.LEDDim = new System.Drawing.Size(15, 15);
            this.ledOvl.LEDState = false;
            this.ledOvl.Location = new System.Drawing.Point(70, 73);
            this.ledOvl.Name = "ledOvl";
            this.ledOvl.offText = "";
            this.ledOvl.onText = "";
            this.ledOvl.Size = new System.Drawing.Size(100, 25);
            this.ledOvl.TabIndex = 18;
            this.ledOvl.Text = "rtled1";
            this.ledOvl.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ledOvl.textOffColor = System.Drawing.Color.DimGray;
            this.ledOvl.textOnColor = System.Drawing.Color.Red;
            this.ledOvl.title = "Overflow";
            this.ledOvl.titleColor = System.Drawing.Color.DimGray;
            this.ledOvl.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ledOvl.titlePos = AudioProcessor.RTLED.RTTitlePos.Left;
            // 
            // ioO2
            // 
            this.ioO2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO2.contactBackColor = System.Drawing.Color.Black;
            this.ioO2.contactColor = System.Drawing.Color.DimGray;
            this.ioO2.Location = new System.Drawing.Point(213, 76);
            this.ioO2.Name = "ioO2";
            this.ioO2.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO2.showTitle = true;
            this.ioO2.Size = new System.Drawing.Size(54, 20);
            this.ioO2.TabIndex = 17;
            this.ioO2.Text = "rtio2";
            this.ioO2.title = "2";
            this.ioO2.titleColor = System.Drawing.Color.DimGray;
            this.ioO2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO2.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioO1
            // 
            this.ioO1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO1.contactBackColor = System.Drawing.Color.Black;
            this.ioO1.contactColor = System.Drawing.Color.DimGray;
            this.ioO1.Location = new System.Drawing.Point(213, 50);
            this.ioO1.Name = "ioO1";
            this.ioO1.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO1.showTitle = true;
            this.ioO1.Size = new System.Drawing.Size(54, 20);
            this.ioO1.TabIndex = 16;
            this.ioO1.Text = "rtio1";
            this.ioO1.title = "1";
            this.ioO1.titleColor = System.Drawing.Color.DimGray;
            this.ioO1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO1.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // slDev
            // 
            this.slDev.entries = ((System.Collections.Generic.List<string>)(resources.GetObject("slDev.entries")));
            this.slDev.frameColor = System.Drawing.Color.DimGray;
            this.slDev.Location = new System.Drawing.Point(3, 20);
            this.slDev.Name = "slDev";
            this.slDev.selectedItem = -1;
            this.slDev.Size = new System.Drawing.Size(257, 22);
            this.slDev.TabIndex = 15;
            this.slDev.Text = "rtSelector1";
            this.slDev.textColor = System.Drawing.Color.White;
            this.slDev.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.slDev.title = "Device";
            this.slDev.titleColor = System.Drawing.Color.DimGray;
            this.slDev.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.slDev.xdim = 200;
            // 
            // ioI2
            // 
            this.ioI2.contactBackColor = System.Drawing.Color.Black;
            this.ioI2.contactColor = System.Drawing.Color.DimGray;
            this.ioI2.Location = new System.Drawing.Point(0, 76);
            this.ioI2.Name = "ioI2";
            this.ioI2.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI2.showTitle = true;
            this.ioI2.Size = new System.Drawing.Size(54, 20);
            this.ioI2.TabIndex = 21;
            this.ioI2.Text = "rtio2";
            this.ioI2.title = "2";
            this.ioI2.titleColor = System.Drawing.Color.DimGray;
            this.ioI2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI2.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioI1
            // 
            this.ioI1.contactBackColor = System.Drawing.Color.Black;
            this.ioI1.contactColor = System.Drawing.Color.DimGray;
            this.ioI1.Location = new System.Drawing.Point(0, 50);
            this.ioI1.Name = "ioI1";
            this.ioI1.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI1.showTitle = true;
            this.ioI1.Size = new System.Drawing.Size(54, 20);
            this.ioI1.TabIndex = 20;
            this.ioI1.Text = "rtio1";
            this.ioI1.title = "1";
            this.ioI1.titleColor = System.Drawing.Color.DimGray;
            this.ioI1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI1.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioI4
            // 
            this.ioI4.contactBackColor = System.Drawing.Color.Black;
            this.ioI4.contactColor = System.Drawing.Color.DimGray;
            this.ioI4.Location = new System.Drawing.Point(0, 128);
            this.ioI4.Name = "ioI4";
            this.ioI4.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI4.showTitle = true;
            this.ioI4.Size = new System.Drawing.Size(54, 20);
            this.ioI4.TabIndex = 23;
            this.ioI4.Text = "rtio2";
            this.ioI4.title = "4";
            this.ioI4.titleColor = System.Drawing.Color.DimGray;
            this.ioI4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI4.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioI3
            // 
            this.ioI3.contactBackColor = System.Drawing.Color.Black;
            this.ioI3.contactColor = System.Drawing.Color.DimGray;
            this.ioI3.Location = new System.Drawing.Point(0, 102);
            this.ioI3.Name = "ioI3";
            this.ioI3.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI3.showTitle = true;
            this.ioI3.Size = new System.Drawing.Size(54, 20);
            this.ioI3.TabIndex = 22;
            this.ioI3.Text = "rtio1";
            this.ioI3.title = "3";
            this.ioI3.titleColor = System.Drawing.Color.DimGray;
            this.ioI3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI3.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioI8
            // 
            this.ioI8.contactBackColor = System.Drawing.Color.Black;
            this.ioI8.contactColor = System.Drawing.Color.DimGray;
            this.ioI8.Location = new System.Drawing.Point(0, 232);
            this.ioI8.Name = "ioI8";
            this.ioI8.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI8.showTitle = true;
            this.ioI8.Size = new System.Drawing.Size(54, 20);
            this.ioI8.TabIndex = 27;
            this.ioI8.Text = "rtio2";
            this.ioI8.title = "8";
            this.ioI8.titleColor = System.Drawing.Color.DimGray;
            this.ioI8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI8.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioI7
            // 
            this.ioI7.contactBackColor = System.Drawing.Color.Black;
            this.ioI7.contactColor = System.Drawing.Color.DimGray;
            this.ioI7.Location = new System.Drawing.Point(0, 206);
            this.ioI7.Name = "ioI7";
            this.ioI7.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI7.showTitle = true;
            this.ioI7.Size = new System.Drawing.Size(54, 20);
            this.ioI7.TabIndex = 26;
            this.ioI7.Text = "rtio1";
            this.ioI7.title = "7";
            this.ioI7.titleColor = System.Drawing.Color.DimGray;
            this.ioI7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI7.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioI6
            // 
            this.ioI6.contactBackColor = System.Drawing.Color.Black;
            this.ioI6.contactColor = System.Drawing.Color.DimGray;
            this.ioI6.Location = new System.Drawing.Point(0, 180);
            this.ioI6.Name = "ioI6";
            this.ioI6.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI6.showTitle = true;
            this.ioI6.Size = new System.Drawing.Size(54, 20);
            this.ioI6.TabIndex = 25;
            this.ioI6.Text = "rtio2";
            this.ioI6.title = "6";
            this.ioI6.titleColor = System.Drawing.Color.DimGray;
            this.ioI6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI6.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioI5
            // 
            this.ioI5.contactBackColor = System.Drawing.Color.Black;
            this.ioI5.contactColor = System.Drawing.Color.DimGray;
            this.ioI5.Location = new System.Drawing.Point(0, 154);
            this.ioI5.Name = "ioI5";
            this.ioI5.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI5.showTitle = true;
            this.ioI5.Size = new System.Drawing.Size(54, 20);
            this.ioI5.TabIndex = 24;
            this.ioI5.Text = "rtio1";
            this.ioI5.title = "5";
            this.ioI5.titleColor = System.Drawing.Color.DimGray;
            this.ioI5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI5.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioO4
            // 
            this.ioO4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO4.contactBackColor = System.Drawing.Color.Black;
            this.ioO4.contactColor = System.Drawing.Color.DimGray;
            this.ioO4.Location = new System.Drawing.Point(213, 128);
            this.ioO4.Name = "ioO4";
            this.ioO4.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO4.showTitle = true;
            this.ioO4.Size = new System.Drawing.Size(54, 20);
            this.ioO4.TabIndex = 29;
            this.ioO4.Text = "rtio2";
            this.ioO4.title = "4";
            this.ioO4.titleColor = System.Drawing.Color.DimGray;
            this.ioO4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO4.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioO3
            // 
            this.ioO3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO3.contactBackColor = System.Drawing.Color.Black;
            this.ioO3.contactColor = System.Drawing.Color.DimGray;
            this.ioO3.Location = new System.Drawing.Point(213, 102);
            this.ioO3.Name = "ioO3";
            this.ioO3.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO3.showTitle = true;
            this.ioO3.Size = new System.Drawing.Size(54, 20);
            this.ioO3.TabIndex = 28;
            this.ioO3.Text = "rtio1";
            this.ioO3.title = "3";
            this.ioO3.titleColor = System.Drawing.Color.DimGray;
            this.ioO3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO3.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioO8
            // 
            this.ioO8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO8.contactBackColor = System.Drawing.Color.Black;
            this.ioO8.contactColor = System.Drawing.Color.DimGray;
            this.ioO8.Location = new System.Drawing.Point(213, 232);
            this.ioO8.Name = "ioO8";
            this.ioO8.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO8.showTitle = true;
            this.ioO8.Size = new System.Drawing.Size(54, 20);
            this.ioO8.TabIndex = 33;
            this.ioO8.Text = "rtio2";
            this.ioO8.title = "8";
            this.ioO8.titleColor = System.Drawing.Color.DimGray;
            this.ioO8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO8.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioO7
            // 
            this.ioO7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO7.contactBackColor = System.Drawing.Color.Black;
            this.ioO7.contactColor = System.Drawing.Color.DimGray;
            this.ioO7.Location = new System.Drawing.Point(213, 206);
            this.ioO7.Name = "ioO7";
            this.ioO7.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO7.showTitle = true;
            this.ioO7.Size = new System.Drawing.Size(54, 20);
            this.ioO7.TabIndex = 32;
            this.ioO7.Text = "rtio1";
            this.ioO7.title = "7";
            this.ioO7.titleColor = System.Drawing.Color.DimGray;
            this.ioO7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO7.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioO6
            // 
            this.ioO6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO6.contactBackColor = System.Drawing.Color.Black;
            this.ioO6.contactColor = System.Drawing.Color.DimGray;
            this.ioO6.Location = new System.Drawing.Point(213, 180);
            this.ioO6.Name = "ioO6";
            this.ioO6.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO6.showTitle = true;
            this.ioO6.Size = new System.Drawing.Size(54, 20);
            this.ioO6.TabIndex = 31;
            this.ioO6.Text = "rtio2";
            this.ioO6.title = "6";
            this.ioO6.titleColor = System.Drawing.Color.DimGray;
            this.ioO6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO6.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioO5
            // 
            this.ioO5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO5.contactBackColor = System.Drawing.Color.Black;
            this.ioO5.contactColor = System.Drawing.Color.DimGray;
            this.ioO5.Location = new System.Drawing.Point(213, 154);
            this.ioO5.Name = "ioO5";
            this.ioO5.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO5.showTitle = true;
            this.ioO5.Size = new System.Drawing.Size(54, 20);
            this.ioO5.TabIndex = 30;
            this.ioO5.Text = "rtio1";
            this.ioO5.title = "5";
            this.ioO5.titleColor = System.Drawing.Color.DimGray;
            this.ioO5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO5.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ASIODevice
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.canShrink = false;
            this.Controls.Add(this.ioO8);
            this.Controls.Add(this.ioO7);
            this.Controls.Add(this.ioO6);
            this.Controls.Add(this.ioO5);
            this.Controls.Add(this.ioO4);
            this.Controls.Add(this.ioO3);
            this.Controls.Add(this.ioI8);
            this.Controls.Add(this.ioI7);
            this.Controls.Add(this.ioI6);
            this.Controls.Add(this.ioI5);
            this.Controls.Add(this.ioI4);
            this.Controls.Add(this.ioI3);
            this.Controls.Add(this.ioI2);
            this.Controls.Add(this.ioI1);
            this.Controls.Add(this.ledOvl);
            this.Controls.Add(this.ioO2);
            this.Controls.Add(this.ioO1);
            this.Controls.Add(this.slDev);
            this.Name = "ASIODevice";
            this.Size = new System.Drawing.Size(267, 256);
            this.title = "ASIO Device";
            this.ResumeLayout(false);

        }



        List<string> driverNames;
        List<int> driverIndex;
        int selectedDriver;

        int maxChannels;
        private RTLED ledOvl;
        private RTIO ioO2;
        private RTIO ioO1;
        private RTSelector slDev;
        private RTIO ioI2;
        private RTIO ioI1;
        private RTIO ioI4;
        private RTIO ioI3;
        private RTIO ioI8;
        private RTIO ioI7;
        private RTIO ioI6;
        private RTIO ioI5;
        private RTIO ioO4;
        private RTIO ioO3;
        private RTIO ioO8;
        private RTIO ioO7;
        private RTIO ioO6;
        private RTIO ioO5;
        AsioOut waveDev;

        private void init()
        {
            InitializeComponent();

            if (maxChannels < 8)
            {
                // Resize Window and deactivate the IOs
                int ymax = 0;
                if (maxChannels < 8) { ioI8.Hide(); ioO8.Hide(); ymax = ioI8.Location.Y; }
                if (maxChannels < 7) { ioI7.Hide(); ioO7.Hide(); ymax = ioI7.Location.Y; }
                if (maxChannels < 6) { ioI6.Hide(); ioO6.Hide(); ymax = ioI6.Location.Y; }
                if (maxChannels < 5) { ioI5.Hide(); ioO5.Hide(); ymax = ioI5.Location.Y; }
                if (maxChannels < 4) { ioI4.Hide(); ioO4.Hide(); ymax = ioI4.Location.Y; }
                if (maxChannels < 3) { ioI3.Hide(); ioO3.Hide(); ymax = ioI3.Location.Y; }
                if (maxChannels < 2) { ioI2.Hide(); ioO2.Hide(); ymax = ioI2.Location.Y; }
                Height = ymax;
            }

            for (int i = 0; i < driverNames.Count; i++)
            {
                slDev.entries.Add(driverNames[i]);
            }
            slDev.selectedItem = selectedDriver;
            if (selectedDriver > 0)
                slDev.Enabled = false;

            slDev.selectionStateChanged += SlDev_selectionStateChanged;
            overflowLED = ledOvl;

            processingType = ProcessingType.Source;
        }


        void fillDeviceList()
        {
            string[] drvn = AsioOut.GetDriverNames();
            driverNames = new List<string>();
            driverNames.Add("None");
            for (int i = 0; i < drvn.Length; i++)
                driverNames.Add(drvn[i]);
        }

        public ASIODevice():this(8)
        {
        }

        public ASIODevice(int _maxChannels)
        {
            maxChannels = _maxChannels;
            fillDeviceList();
            selectedDriver = 0;
            init();
        }

        public ASIODevice(SystemPanel _owner, int _maxChannels) : this(_maxChannels)
        {
            init();
        }

        public ASIODevice(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            maxChannels = src.ReadInt32();

            fillDeviceList();

            string usedev = src.ReadString();
            int idx = driverNames.IndexOf(usedev);
            if (idx > 0)
            {
                selectedDriver = idx;
                sinkSourceMode = SinkSourceMode.GoOnline;
            }

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write(maxChannels);
            if (selectedDriver > 0)
            {
                tgt.Write(driverNames[selectedDriver]);
            }
            else
            {
                tgt.Write("NO DEVICE SELECTED");
            }
        }

        private void SlDev_selectionStateChanged(object sender, EventArgs e)
        {
            if (slDev.selectedItem > 0)
            {
                slDev.Enabled = false;
                selectedDriver = slDev.selectedItem;
                sinkSourceMode = SinkSourceMode.GoOnline;
            }
        }

        private int min(int a, int b) { return (a < b) ? a : b; }

        protected override void driverDisconnect()
        {
            if (waveDev != null)
            {
                waveDev.Dispose();
                waveDev = null;
                owner.logText(String.Format("ASIO Device {0} closed", driverNames[selectedDriver]));
            }
            processingType = ProcessingType.Source;
            selectedDriver = 0;
        }

        protected override SinkSourceMode driverConnect()
        {
            if (selectedDriver <= 0)
                return SinkSourceMode.Offline;

            owner.logText(String.Format("Opening ASIO Device {0}", driverNames[selectedDriver]));
            try
            {
                waveDev = new AsioOut(driverNames[selectedDriver]);
                waveDev.ChannelOffset = 0;
                waveDev.InputChannelOffset = 0;

                if ((waveDev.DriverInputChannelCount == 0) && (waveDev.DriverOutputChannelCount == 0))
                    throw new Exception(String.Format("ASIO Driver {0} proveides no Input or output channels", driverNames[selectedDriver]));

                RTIO[] ins = new RTIO[min(waveDev.DriverInputChannelCount, maxChannels)];
                RTIO[] outs = new RTIO[min(waveDev.DriverOutputChannelCount, maxChannels)];
                if ((waveDev.DriverInputChannelCount > 0) && (maxChannels > 0)) ins[0] = ioI1;
                if ((waveDev.DriverInputChannelCount > 1) && (maxChannels > 1)) ins[1] = ioI2;
                if ((waveDev.DriverInputChannelCount > 2) && (maxChannels > 2)) ins[2] = ioI3;
                if ((waveDev.DriverInputChannelCount > 3) && (maxChannels > 3)) ins[3] = ioI4;
                if ((waveDev.DriverInputChannelCount > 4) && (maxChannels > 4)) ins[4] = ioI5;
                if ((waveDev.DriverInputChannelCount > 5) && (maxChannels > 5)) ins[5] = ioI6;
                if ((waveDev.DriverInputChannelCount > 6) && (maxChannels > 6)) ins[6] = ioI7;
                if ((waveDev.DriverInputChannelCount > 7) && (maxChannels > 7)) ins[7] = ioI8;
                if ((waveDev.DriverOutputChannelCount > 0) && (maxChannels > 0)) outs[0] = ioO1;
                if ((waveDev.DriverOutputChannelCount > 1) && (maxChannels > 1)) outs[1] = ioO2;
                if ((waveDev.DriverOutputChannelCount > 2) && (maxChannels > 2)) outs[2] = ioO3;
                if ((waveDev.DriverOutputChannelCount > 3) && (maxChannels > 3)) outs[3] = ioO4;
                if ((waveDev.DriverOutputChannelCount > 4) && (maxChannels > 4)) outs[4] = ioO5;
                if ((waveDev.DriverOutputChannelCount > 5) && (maxChannels > 5)) outs[5] = ioO6;
                if ((waveDev.DriverOutputChannelCount > 6) && (maxChannels > 6)) outs[6] = ioO7;
                if ((waveDev.DriverOutputChannelCount > 7) && (maxChannels > 7)) outs[7] = ioO8;

                setChannels(outs, ins);

                if (waveProvider == null)
                    waveProvider = new NAudioShortWaveProvider(this);
                waveProvider.SetWaveFormat(owner.sampleRate, toDriverChannels);

                if (fromDriverChannels == 0)
                    waveDev.InitRecordAndPlayback(waveProvider, 0, owner.sampleRate);
                else if (toDriverChannels == 0)
                    waveDev.InitRecordAndPlayback(null, fromDriverChannels, owner.sampleRate);
                else
                    waveDev.InitRecordAndPlayback(waveProvider, fromDriverChannels, owner.sampleRate);

                if (fromDriverChannels > 0)
                    waveDev.AudioAvailable += ASIO_AudioAvailable;

                waveDev.Play();

                if (fromDriverChannels == 0)
                    processingType = ProcessingType.SynchronousSource;
                else
                    processingType = ProcessingType.SynchronousSink;
                owner.logText(String.Format("ASIO Device {0} open", driverNames[selectedDriver]));
                return SinkSourceMode.Online;
            }
            catch (Exception e)
            {
                owner.showLogWin();
                owner.logText(e.Message);
                return SinkSourceMode.Error;
            }

        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Source", "Live", "ASIO Device", "2 Channels" }; }
            public override RTForm Instantiate() { return new ASIODevice(2); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Source", "Live", "ASIO Device", "4 Channels" }; }
            public override RTForm Instantiate() { return new ASIODevice(4); }
        }
        class RegisterClass3 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Source", "Live", "ASIO Device", "8 Channels" }; }
            public override RTForm Instantiate() { return new ASIODevice(8); }
        }
        class RegisterClass5 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Sink", "Live", "ASIO Device", "2 Channels" }; }
            public override RTForm Instantiate() { return new ASIODevice(2); }
        }
        class RegisterClass6 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Sink", "Live", "ASIO Device", "4 Channels" }; }
            public override RTForm Instantiate() { return new ASIODevice(4); }
        }
        class RegisterClass7 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Sink", "Live", "ASIO Device", "8 Channels" }; }
            public override RTForm Instantiate() { return new ASIODevice(8); }
        }
        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
            l.Add(new RegisterClass2());
            l.Add(new RegisterClass3());
            l.Add(new RegisterClass5());
            l.Add(new RegisterClass6());
            l.Add(new RegisterClass7());
        }

    }
}
