using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using System.IO;

namespace AudioProcessor.RealtimeSinkSource
{
    public class WindowsDeviceSink: GenericNAudioSinkSource
    {

        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowsDeviceSink));
            this.slDev = new AudioProcessor.RTSelector();
            this.ioL = new AudioProcessor.RTIO();
            this.ioR = new AudioProcessor.RTIO();
            this.ledOvl = new AudioProcessor.RTLED();
            this.SuspendLayout();
            // 
            // slDev
            // 
            this.slDev.entries = ((System.Collections.Generic.List<string>)(resources.GetObject("slDev.entries")));
            this.slDev.frameColor = System.Drawing.Color.DimGray;
            this.slDev.Location = new System.Drawing.Point(51, 25);
            this.slDev.Name = "slDev";
            this.slDev.selectedItem = -1;
            this.slDev.Size = new System.Drawing.Size(257, 22);
            this.slDev.TabIndex = 0;
            this.slDev.Text = "rtSelector1";
            this.slDev.textColor = System.Drawing.Color.White;
            this.slDev.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.slDev.title = "Device";
            this.slDev.titleColor = System.Drawing.Color.DimGray;
            this.slDev.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.slDev.xdim = 200;
            // 
            // ioL
            // 
            this.ioL.contactBackColor = System.Drawing.Color.Black;
            this.ioL.contactColor = System.Drawing.Color.DimGray;
            this.ioL.Location = new System.Drawing.Point(0, 25);
            this.ioL.Name = "ioL";
            this.ioL.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioL.showTitle = true;
            this.ioL.Size = new System.Drawing.Size(54, 20);
            this.ioL.TabIndex = 1;
            this.ioL.Text = "rtio1";
            this.ioL.title = "L";
            this.ioL.titleColor = System.Drawing.Color.DimGray;
            this.ioL.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioL.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioR
            // 
            this.ioR.contactBackColor = System.Drawing.Color.Black;
            this.ioR.contactColor = System.Drawing.Color.DimGray;
            this.ioR.Location = new System.Drawing.Point(0, 51);
            this.ioR.Name = "ioR";
            this.ioR.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioR.showTitle = true;
            this.ioR.Size = new System.Drawing.Size(54, 20);
            this.ioR.TabIndex = 2;
            this.ioR.Text = "rtio2";
            this.ioR.title = "R";
            this.ioR.titleColor = System.Drawing.Color.DimGray;
            this.ioR.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioR.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ledOvl
            // 
            this.ledOvl.fillOffColor = System.Drawing.Color.Black;
            this.ledOvl.fillOnColor = System.Drawing.Color.DarkRed;
            this.ledOvl.frameOffColor = System.Drawing.Color.DimGray;
            this.ledOvl.frameOnColor = System.Drawing.Color.Red;
            this.ledOvl.LEDDim = new System.Drawing.Size(15, 15);
            this.ledOvl.LEDState = false;
            this.ledOvl.Location = new System.Drawing.Point(208, 53);
            this.ledOvl.Name = "ledOvl";
            this.ledOvl.offText = "";
            this.ledOvl.onText = "";
            this.ledOvl.Size = new System.Drawing.Size(100, 25);
            this.ledOvl.TabIndex = 3;
            this.ledOvl.Text = "rtled1";
            this.ledOvl.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ledOvl.textOffColor = System.Drawing.Color.DimGray;
            this.ledOvl.textOnColor = System.Drawing.Color.Red;
            this.ledOvl.title = "Overflow";
            this.ledOvl.titleColor = System.Drawing.Color.DimGray;
            this.ledOvl.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ledOvl.titlePos = AudioProcessor.RTLED.RTTitlePos.Left;
            // 
            // WindowsDeviceSink
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.canShrink = false;
            this.Controls.Add(this.ledOvl);
            this.Controls.Add(this.ioR);
            this.Controls.Add(this.ioL);
            this.Controls.Add(this.slDev);
            this.Name = "WindowsDeviceSink";
            this.Size = new System.Drawing.Size(320, 84);
            this.title = "Windows Device";
            this.ResumeLayout(false);

        }

        List<string> devices;
        List<int> devindex;
        int selectedDevice;
        private RTSelector slDev;
        private RTIO ioL;
        private RTIO ioR;
        private RTLED ledOvl;
        WaveOut waveOut;


        public void init()
        {
            InitializeComponent();

            for (int i = 0; i < devices.Count; i++)
            {
                slDev.entries.Add(devices[i]);
            }
            slDev.selectedItem = selectedDevice;
            if (selectedDevice > 0)
                slDev.Enabled = false;

            slDev.selectionStateChanged += SlDev_selectionStateChanged;
            overflowLED = ledOvl;
        }


        public void fillDevicesList()
        {
            devices = new List<string>();
            devindex = new List<int>();

            devices.Add("[none]");
            devindex.Add(-1);

            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                WaveOutCapabilities devinfo = WaveOut.GetCapabilities(i);
                if (devinfo.Channels == 2)
                {
                    devices.Add(devinfo.ProductName);
                    devindex.Add(i);
                }
            }
        }

        public WindowsDeviceSink() : base()
        {

            processingType = ProcessingType.Sink;
            selectedDevice = 0;
            waveOut = null;

            fillDevicesList();

            init();
        }

        public WindowsDeviceSink(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            processingType = ProcessingType.Sink;
            selectedDevice = 0;
            waveOut = null;
            active = true;

            fillDevicesList();

            string usedev = src.ReadString();
            int idx = devices.IndexOf(usedev);
            if (idx > 0)
            {
                selectedDevice = idx;
                sinkSourceMode = SinkSourceMode.GoOnline;
            }

            init();
        }

        private void SlDev_selectionStateChanged(object sender, EventArgs e)
        {
            if (slDev.selectedItem > 0)
            {
                slDev.Enabled = false;
                selectedDevice = slDev.selectedItem;
                sinkSourceMode = SinkSourceMode.GoOnline;
            }
        }

               
        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            if (selectedDevice > 0)
            {
                tgt.Write(devices[selectedDevice]);
            } else
            {
                tgt.Write("NO DEVICE SELECTED");
            }

        }

        protected override void driverDisconnect()
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
                owner.logText(String.Format("Audio Device {0} closed", devices[selectedDevice]));
            }
            if (waveProvider != null)
            {
                waveProvider = null;
            }
            processingType = ProcessingType.Sink;
            selectedDevice = 0;
        }

        protected override SinkSourceMode driverConnect()
        {
            if (selectedDevice <= 0)
                return SinkSourceMode.Offline;

            owner.logText(String.Format("Opening Audio Device {0}", devices[selectedDevice]));
            try
            {
                if (waveProvider == null)
                    waveProvider = new NAudioShortWaveProvider(this);
                waveProvider.SetWaveFormat(owner.sampleRate, 2);
                waveOut = new WaveOut();
                waveOut.DeviceNumber = devindex[selectedDevice];
                waveOut.DesiredLatency = 100; // 100 ms = 4800 Samples;

                setChannels(null, new RTIO[] { ioL, ioR });

                // ioRefToDriver[0] = 0;
                // ioRefToDriver[1] = 1;


                waveOut.Init(waveProvider);
                waveOut.Play();
                owner.logText(String.Format("Audio Device {0} open", devices[selectedDevice]));
                processingType = ProcessingType.SynchronousSink;
                return SinkSourceMode.Online;
            }
            catch (Exception e)
            {
                owner.showLogWin();
                owner.logText(e.Message);
                return SinkSourceMode.Error;
            }
        }

        class RegisterClass : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Sink", "Live", "Windows Device" }; }
            public override RTForm Instantiate() { return new WindowsDeviceSink(); }
        }
        public static void Register(List<RTObjectReference> l) { l.Add(new RegisterClass()); }
    }
}
