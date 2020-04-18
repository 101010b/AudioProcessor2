using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using System.IO;


namespace AudioProcessor.RealtimeSinkSource
{
    public class WASAPISource : GenericNAudioSinkSource
    {

        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WASAPISource));
            this.ledOvl = new AudioProcessor.RTLED();
            this.ioR = new AudioProcessor.RTIO();
            this.ioL = new AudioProcessor.RTIO();
            this.slDev = new AudioProcessor.RTSelector();
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
            this.ledOvl.Location = new System.Drawing.Point(160, 53);
            this.ledOvl.Name = "ledOvl";
            this.ledOvl.offText = "";
            this.ledOvl.onText = "";
            this.ledOvl.Size = new System.Drawing.Size(100, 25);
            this.ledOvl.TabIndex = 13;
            this.ledOvl.Text = "rtled1";
            this.ledOvl.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ledOvl.textOffColor = System.Drawing.Color.DimGray;
            this.ledOvl.textOnColor = System.Drawing.Color.Red;
            this.ledOvl.title = "Overflow";
            this.ledOvl.titleColor = System.Drawing.Color.DimGray;
            this.ledOvl.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ledOvl.titlePos = AudioProcessor.RTLED.RTTitlePos.Left;
            // 
            // ioR
            // 
            this.ioR.contactBackColor = System.Drawing.Color.Black;
            this.ioR.contactColor = System.Drawing.Color.DimGray;
            this.ioR.Location = new System.Drawing.Point(266, 53);
            this.ioR.Name = "ioR";
            this.ioR.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioR.showTitle = true;
            this.ioR.Size = new System.Drawing.Size(54, 20);
            this.ioR.TabIndex = 12;
            this.ioR.Text = "rtio2";
            this.ioR.title = "R";
            this.ioR.titleColor = System.Drawing.Color.DimGray;
            this.ioR.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioR.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioL
            // 
            this.ioL.contactBackColor = System.Drawing.Color.Black;
            this.ioL.contactColor = System.Drawing.Color.DimGray;
            this.ioL.Location = new System.Drawing.Point(266, 27);
            this.ioL.Name = "ioL";
            this.ioL.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioL.showTitle = true;
            this.ioL.Size = new System.Drawing.Size(54, 20);
            this.ioL.TabIndex = 11;
            this.ioL.Text = "rtio1";
            this.ioL.title = "L";
            this.ioL.titleColor = System.Drawing.Color.DimGray;
            this.ioL.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioL.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // slDev
            // 
            this.slDev.entries = ((System.Collections.Generic.List<string>)(resources.GetObject("slDev.entries")));
            this.slDev.frameColor = System.Drawing.Color.DimGray;
            this.slDev.Location = new System.Drawing.Point(3, 25);
            this.slDev.Name = "slDev";
            this.slDev.selectedItem = -1;
            this.slDev.Size = new System.Drawing.Size(257, 22);
            this.slDev.TabIndex = 10;
            this.slDev.Text = "rtSelector1";
            this.slDev.textColor = System.Drawing.Color.White;
            this.slDev.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.slDev.title = "Device";
            this.slDev.titleColor = System.Drawing.Color.DimGray;
            this.slDev.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.slDev.xdim = 200;
            // 
            // WASAPISource
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.canShrink = false;
            this.Controls.Add(this.ledOvl);
            this.Controls.Add(this.ioR);
            this.Controls.Add(this.ioL);
            this.Controls.Add(this.slDev);
            this.Name = "WASAPISource";
            this.Size = new System.Drawing.Size(320, 84);
            this.title = "WASAPI Source";
            this.ResumeLayout(false);

        }

        List<string> devices;
        List<int> devindex;
        int selectedDevice;
        private RTLED ledOvl;
        private RTIO ioR;
        private RTIO ioL;
        private RTSelector slDev;
        IWaveIn waveIn;

        private void init()
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

            processingType = ProcessingType.Source;
        }

        public void fillDevicesList()
        {
            devices = new List<string>();
            devindex = new List<int>();

            devices.Add("[none]");
            devindex.Add(-1);

            List<NAudio.CoreAudioApi.MMDevice> MMdevices;
            MMDeviceEnumerator deviceEnum = new MMDeviceEnumerator();
            MMdevices = deviceEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active).ToList();

            for (int i = 0; i < MMdevices.Count; i++)
            {
                devices.Add(MMdevices[i].FriendlyName);
                devindex.Add(i);
            }
        }

        public WASAPISource() : base()
        {

            fillDevicesList();

            processingType = ProcessingType.Source;
            selectedDevice = 0;
            waveIn = null;

            init();
        }

        public WASAPISource(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {

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

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            if (selectedDevice > 0)
            {
                tgt.Write(devices[selectedDevice]);
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
                selectedDevice = slDev.selectedItem;
                sinkSourceMode = SinkSourceMode.GoOnline;
            }
        }

        protected override SinkSourceMode driverConnect()
        {
            if (selectedDevice <= 0)
                return SinkSourceMode.Offline;

            owner.logText(String.Format("Opening Audio WASAPI Device {0}", devices[selectedDevice]));
            try
            {
                List<NAudio.CoreAudioApi.MMDevice> MMdevices;
                MMDeviceEnumerator deviceEnum = new MMDeviceEnumerator();
                MMdevices = deviceEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active).ToList();
                //   DataFlow.Capture, DeviceState.Active
                waveIn = new WasapiCapture(MMdevices[selectedDevice - 1]);
                // waveIn = new WasapiLoopbackCapture(MMdevices[selectedDevice - 1]);
                WASAPIDataFormat = waveIn.WaveFormat.Encoding;
                if (waveIn.WaveFormat.SampleRate != owner.sampleRate)
                {
                    // Bad SampleRate
                    throw new Exception(String.Format("WASAPI Device cannopt be opened - works on SampleRate {0} only",
                        waveIn.WaveFormat.SampleRate));
                }
                if ((WASAPIDataFormat != WaveFormatEncoding.Pcm) && (WASAPIDataFormat != WaveFormatEncoding.IeeeFloat))
                {
                    throw new Exception("WASAPI Device cannot be used - bad data format");
                }
                // waveIn.WaveFormat = new WaveFormat(44100, 16, 2);
                // waveIn.DeviceNumber = selectedDevice - 1;
                waveIn.DataAvailable += WASAPI_DataAvailable;
                // waveIn.BufferMilliseconds = 25; // 1200 samples at 48 kHz

                setChannels(new RTIO[] { ioL, ioR }, null);

                waveIn.StartRecording();
                owner.logText(String.Format("Device WASAPI {0} open", devices[selectedDevice]));
                processingType = ProcessingType.SynchronousSource;
                return SinkSourceMode.Online;
            }
            catch (Exception e)
            {
                owner.showLogWin();
                owner.logText(e.Message);
                if (waveIn != null)
                    waveIn.Dispose();
                waveIn = null;
                return SinkSourceMode.Error;
            }
        }

        protected override void driverDisconnect()
        {
            if (waveIn != null)
            {
                waveIn.StopRecording();
                waveIn.Dispose();
                waveIn = null;
                owner.logText(String.Format("Audio WASAPI Device {0} closed", devices[selectedDevice]));
            }
            processingType = ProcessingType.Source;
            selectedDevice = 0;
        }


        class RegisterClass : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Source", "Live", "WASAPI Source" }; }
            public override RTForm Instantiate() { return new WASAPISource(); }
        }
        public static void Register(List<RTObjectReference> l) { l.Add(new RegisterClass()); }

    }
}
