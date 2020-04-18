using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using NAudio.Midi;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.AsyncSinkSource
{
    class MIDI_In : RTForm
    {

        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MIDI_In));
            this.ledOn = new AudioProcessor.RTLED();
            this.slDev = new AudioProcessor.RTSelector();
            this.ioPitch = new AudioProcessor.RTIO();
            this.ioTrig = new AudioProcessor.RTIO();
            this.ioAmp = new AudioProcessor.RTIO();
            this.ioC1 = new AudioProcessor.RTIO();
            this.ioC2 = new AudioProcessor.RTIO();
            this.ioC3 = new AudioProcessor.RTIO();
            this.ioC4 = new AudioProcessor.RTIO();
            this.SuspendLayout();
            // 
            // ledOn
            // 
            this.ledOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ledOn.fillOffColor = System.Drawing.Color.Black;
            this.ledOn.fillOnColor = System.Drawing.Color.DarkRed;
            this.ledOn.frameOffColor = System.Drawing.Color.DimGray;
            this.ledOn.frameOnColor = System.Drawing.Color.Red;
            this.ledOn.LEDDim = new System.Drawing.Size(15, 15);
            this.ledOn.LEDState = false;
            this.ledOn.Location = new System.Drawing.Point(269, 3);
            this.ledOn.Name = "ledOn";
            this.ledOn.offText = "";
            this.ledOn.onText = "";
            this.ledOn.Size = new System.Drawing.Size(63, 25);
            this.ledOn.TabIndex = 13;
            this.ledOn.Text = "rtled1";
            this.ledOn.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ledOn.textOffColor = System.Drawing.Color.DimGray;
            this.ledOn.textOnColor = System.Drawing.Color.Red;
            this.ledOn.title = "On";
            this.ledOn.titleColor = System.Drawing.Color.DimGray;
            this.ledOn.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ledOn.titlePos = AudioProcessor.RTLED.RTTitlePos.Left;
            // 
            // slDev
            // 
            this.slDev.entries = ((System.Collections.Generic.List<string>)(resources.GetObject("slDev.entries")));
            this.slDev.frameColor = System.Drawing.Color.DimGray;
            this.slDev.Location = new System.Drawing.Point(15, 28);
            this.slDev.Name = "slDev";
            this.slDev.selectedItem = -1;
            this.slDev.Size = new System.Drawing.Size(257, 22);
            this.slDev.TabIndex = 12;
            this.slDev.Text = "rtSelector1";
            this.slDev.textColor = System.Drawing.Color.White;
            this.slDev.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.slDev.title = "Device";
            this.slDev.titleColor = System.Drawing.Color.DimGray;
            this.slDev.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.slDev.xdim = 200;
            // 
            // ioPitch
            // 
            this.ioPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioPitch.contactBackColor = System.Drawing.Color.Black;
            this.ioPitch.contactColor = System.Drawing.Color.DimGray;
            this.ioPitch.Location = new System.Drawing.Point(294, 60);
            this.ioPitch.Name = "ioPitch";
            this.ioPitch.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioPitch.showTitle = true;
            this.ioPitch.Size = new System.Drawing.Size(61, 20);
            this.ioPitch.TabIndex = 15;
            this.ioPitch.Text = "rtio2";
            this.ioPitch.title = "pitch";
            this.ioPitch.titleColor = System.Drawing.Color.DimGray;
            this.ioPitch.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioPitch.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioTrig
            // 
            this.ioTrig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioTrig.contactBackColor = System.Drawing.Color.Black;
            this.ioTrig.contactColor = System.Drawing.Color.DimGray;
            this.ioTrig.Location = new System.Drawing.Point(294, 34);
            this.ioTrig.Name = "ioTrig";
            this.ioTrig.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioTrig.showTitle = true;
            this.ioTrig.Size = new System.Drawing.Size(61, 20);
            this.ioTrig.TabIndex = 14;
            this.ioTrig.Text = "rtio1";
            this.ioTrig.title = "Trg";
            this.ioTrig.titleColor = System.Drawing.Color.DimGray;
            this.ioTrig.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioTrig.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioAmp
            // 
            this.ioAmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioAmp.contactBackColor = System.Drawing.Color.Black;
            this.ioAmp.contactColor = System.Drawing.Color.DimGray;
            this.ioAmp.Location = new System.Drawing.Point(294, 86);
            this.ioAmp.Name = "ioAmp";
            this.ioAmp.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioAmp.showTitle = true;
            this.ioAmp.Size = new System.Drawing.Size(61, 20);
            this.ioAmp.TabIndex = 16;
            this.ioAmp.Text = "rtio2";
            this.ioAmp.title = "amp";
            this.ioAmp.titleColor = System.Drawing.Color.DimGray;
            this.ioAmp.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioAmp.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioC1
            // 
            this.ioC1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioC1.contactBackColor = System.Drawing.Color.Black;
            this.ioC1.contactColor = System.Drawing.Color.DimGray;
            this.ioC1.Location = new System.Drawing.Point(294, 112);
            this.ioC1.Name = "ioC1";
            this.ioC1.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioC1.showTitle = true;
            this.ioC1.Size = new System.Drawing.Size(61, 20);
            this.ioC1.TabIndex = 17;
            this.ioC1.Text = "rtio2";
            this.ioC1.title = "C1";
            this.ioC1.titleColor = System.Drawing.Color.DimGray;
            this.ioC1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioC1.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioC2
            // 
            this.ioC2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioC2.contactBackColor = System.Drawing.Color.Black;
            this.ioC2.contactColor = System.Drawing.Color.DimGray;
            this.ioC2.Location = new System.Drawing.Point(294, 138);
            this.ioC2.Name = "ioC2";
            this.ioC2.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioC2.showTitle = true;
            this.ioC2.Size = new System.Drawing.Size(61, 20);
            this.ioC2.TabIndex = 18;
            this.ioC2.Text = "rtio3";
            this.ioC2.title = "C2";
            this.ioC2.titleColor = System.Drawing.Color.DimGray;
            this.ioC2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioC2.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioC3
            // 
            this.ioC3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioC3.contactBackColor = System.Drawing.Color.Black;
            this.ioC3.contactColor = System.Drawing.Color.DimGray;
            this.ioC3.Location = new System.Drawing.Point(294, 164);
            this.ioC3.Name = "ioC3";
            this.ioC3.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioC3.showTitle = true;
            this.ioC3.Size = new System.Drawing.Size(61, 20);
            this.ioC3.TabIndex = 19;
            this.ioC3.Text = "rtio4";
            this.ioC3.title = "C3";
            this.ioC3.titleColor = System.Drawing.Color.DimGray;
            this.ioC3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioC3.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioC4
            // 
            this.ioC4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioC4.contactBackColor = System.Drawing.Color.Black;
            this.ioC4.contactColor = System.Drawing.Color.DimGray;
            this.ioC4.Location = new System.Drawing.Point(294, 190);
            this.ioC4.Name = "ioC4";
            this.ioC4.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioC4.showTitle = true;
            this.ioC4.Size = new System.Drawing.Size(61, 20);
            this.ioC4.TabIndex = 20;
            this.ioC4.Text = "rtio5";
            this.ioC4.title = "C4";
            this.ioC4.titleColor = System.Drawing.Color.DimGray;
            this.ioC4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioC4.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // MIDI_In
            // 
            this.canShrink = false;
            this.Controls.Add(this.ioC4);
            this.Controls.Add(this.ioC3);
            this.Controls.Add(this.ioC2);
            this.Controls.Add(this.ioC1);
            this.Controls.Add(this.ioAmp);
            this.Controls.Add(this.ioPitch);
            this.Controls.Add(this.ioTrig);
            this.Controls.Add(this.ledOn);
            this.Controls.Add(this.slDev);
            this.Name = "MIDI_In";
            this.Size = new System.Drawing.Size(355, 217);
            this.title = "MIDI In";
            this.ResumeLayout(false);

        }

        int channel;
        int ctrl1, ctrl2, ctrl3, ctrl4;
        bool online;

        List<string> devices;
        MidiIn midiIn;
        private RTLED ledOn;
        private RTSelector slDev;
        private RTIO ioPitch;
        private RTIO ioTrig;
        private RTIO ioAmp;
        private RTIO ioC1;
        private RTIO ioC2;
        private RTIO ioC3;
        private RTIO ioC4;
        int selectedDevice;


        /*
                private void stopListener()
                {
                    try
                    {
                        if (tcpClient != null)
                        {
                            tcpClient.Close();
                            tcpClient = null;
                        }
                    }
                    catch (Exception e)
                    {
                        owner.logText("AsyncNetListener: Closing Client Error: " + e.Message);
                        owner.showLogWin();
                    }
                    try
                    {
                        if (tcpListener != null)
                        {
                            tcpListener.Stop();
                            tcpListener = null;
                        }
                    }
                    catch (Exception e)
                    {
                        owner.logText("AsyncNetListener: Closing Listener Error: " + e.Message);
                        owner.showLogWin();
                    }
                }

                private void startListener()
                {
                    if ((tcpListener != null) || (tcpClient != null))
                        stopListener();

                    try
                    {
                        IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                        tcpListener = new TcpListener(localAddr, port);
                        tcpListener.Start();
                    }
                    catch (Exception e)
                    {
                        owner.logText("AsyncNetListener: Cannot Create Socket: " + e.Message);
                        owner.showLogWin();
                        tcpListener = null;
                    }

                }
        */


        private void init()
        {
            InitializeComponent();
            for (int i = 0; i < devices.Count; i++)
            {
                slDev.entries.Add(devices[i]);
            }
            slDev.selectedItem = selectedDevice;
            ledOn.LEDState = false;

            if (selectedDevice > 0)
            {
                // Try to open device
                openDevice(selectedDevice);
            }

            slDev.selectionStateChanged += SlDev_selectionStateChanged;

            processingType = ProcessingType.Source;
        }


        public void fillDevicesList()
        {
            devices = new List<string>();
            devices.Add("[NONE]");
            for (int i = 0; i < MidiIn.NumberOfDevices; i++)
            {
                devices.Add(String.Format("{0}", MidiIn.DeviceInfo(i).ProductName));
            }
        }

        public MIDI_In() : base()
        {
            fillDevicesList();
            selectedDevice = 0;
            init();
        }

        public MIDI_In(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            fillDevicesList();
            selectedDevice = 0;
            string dvn = src.ReadString();
            if ((dvn != null) && !dvn.Equals("[NONE]"))
            {
                // Try to identify device
                for (int i = 1; i < devices.Count; i++)
                {
                    if (dvn.Equals(devices[i]))
                        selectedDevice = i;
                }
            }
            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            if (selectedDevice > 0)
                tgt.Write(devices[selectedDevice]);
            else
                tgt.Write("[NONE]");
        }

        private void SlDev_selectionStateChanged(object sender, EventArgs e)
        {
            if (slDev.selectedItem > 0)
                openDevice(slDev.selectedItem);
        }

        private void openDevice(int i)
        {
            if (i < 1) return;
            if (midiIn != null)
            {
                midiIn.Stop();
                midiIn.Dispose();
                midiIn = null;
                selectedDevice = 0;
            }
            try
            {
                midiIn = new MidiIn(i - 1);
                midiIn.MessageReceived += MIDIMessageReceived;
                midiIn.ErrorReceived += MIDIErrorReceived;
                midiIn.Start();
                selectedDevice = i;
            }
            catch (Exception e)
            {
                midiIn = null;
                selectedDevice = 0;
                owner.logText(string.Format("Error: Cannot Open MIDI Device {0}: {1}",
                    devices[i], e.Message));
            }
            if (selectedDevice > 0)
            {
                slDev.selectedItem = selectedDevice;
                slDev.Enabled = false;
                online = true;
            }
        }

        private void MIDIErrorReceived(object sender, MidiInMessageEventArgs e)
        {
            owner.logText(String.Format("Time {0} Message 0x{1:X8} Event {2}",
                e.Timestamp, e.RawMessage, e.MidiEvent));
        }

        int onnote = -1;
        int newnote = -1;
        int newvel = -1;
        int stopvel = -1;

        int lastnote = -1;
        int lastvel = -1;
        double control1 = 0;
        double control2 = 0;
        double control3 = 0;
        double control4 = 0;
        double pitch = 0;

        private void MIDIMessageReceived(object sender, MidiInMessageEventArgs e)
        {
            if ((e.RawMessage & 0x000000F0) == 0x00000090)
            { // Note On
                int channel = e.RawMessage & 0x0000000F;
                if (channel != 0) return;
                int note = (e.RawMessage >> 8) & 0x0000007F;
                int vel = (e.RawMessage >> 16) & 0x0000007F;
                newnote = note;
                newvel = vel;
                onnote = note;
                stopvel = -1;
            }
            else if ((e.RawMessage & 0x000000F0) == 0x00000080)
            { // Note Off
                int channel = e.RawMessage & 0x0000000F;
                if (channel != 0) return;
                int note = (e.RawMessage >> 8) & 0x0000007F;
                int vel = (e.RawMessage >> 16) & 0x0000007F;
                if (onnote == note)
                {
                    stopvel = vel;
                }
            } else if ((e.RawMessage & 0x000000F0) == 0x000000E0)
            { // Pitch bend
                int channel = e.RawMessage & 0x0000000F;
                if (channel != 0) return;
                pitch = (double)((((e.RawMessage >> 8) & 0x007F) + ((e.RawMessage >> 16) & 0x007F)*128) - 8192) / 8192;
            } else if ((e.RawMessage & 0x000000F0) == 0x000000B0)
            { // Control
                int channel = e.RawMessage & 0x0000000F;
                if (channel != 0) return;
                int ctrl = (e.RawMessage >> 8) & 0x0000007F;
                int ctrlval = (e.RawMessage >> 16) & 0x0000007F;
                switch (ctrl)
                {
                    case 1: break; // Modulation Wheel
                    case 20: control1 = (double)ctrlval / 127.0; break;
                    case 21: control2 = (double)ctrlval / 127.0; break;
                    case 22: control3 = (double)ctrlval / 127.0; break;
                    case 23: control4 = (double)ctrlval / 127.0; break;
                }
            }
            owner.logText(String.Format("Time {0} Message 0x{1:X8} Event {2}",
               e.Timestamp, e.RawMessage, e.MidiEvent));
        }

        public override void tick()
        {
            if (!active) return;

            DataBuffer dbtrig = getOutputBuffer(ioTrig);
            DataBuffer dbpitch = getOutputBuffer(ioPitch);
            DataBuffer dbamp = getOutputBuffer(ioAmp);
            DataBuffer dbC1 = getOutputBuffer(ioC1);
            DataBuffer dbC2 = getOutputBuffer(ioC2);
            DataBuffer dbC3 = getOutputBuffer(ioC3);
            DataBuffer dbC4 = getOutputBuffer(ioC4);

            for (int i = 0; i < owner.blockSize; i++)
            {
                if (newnote >= 0)
                {
                    if (dbtrig != null) dbtrig.data[i] = 1;
                    onnote = newnote;
                    lastnote = newnote;
                    lastvel = newvel;
                    newnote = -1;
                } else if (stopvel >= 0)
                {
                    if (dbtrig != null) dbtrig.data[i] = 0;
                    stopvel = -1;
                    onnote = -1;
                } else
                {
                    if (dbtrig != null) dbtrig.data[i] = (onnote >= 0)?1:0;
                }
                if (dbpitch != null) dbpitch.data[i] = (double)(lastnote - 69) / 12 + pitch/12;
                if (dbamp != null) dbamp.data[i] = (double)lastvel / 127;
                if (dbC1 != null) dbC1.data[i] = control1;
                if (dbC2 != null) dbC2.data[i] = control2;
                if (dbC3 != null) dbC3.data[i] = control3;
                if (dbC4 != null) dbC4.data[i] = control4;
            }

            if ((onnote >= 0) && !ledOn.LEDState)
                ledOn.LEDState = true;
            if ((onnote == 0) && ledOn.LEDState)
                ledOn.LEDState = false;
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Source", "Async", "MIDI", "MIDI Input"}; }
            public override RTForm Instantiate() { return new MIDI_In(); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
        }


    }
}
