using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.AsyncSinkSource
{
    class AsyncNetListener : RTForm
    {
        public void InitializeComponent()
        {
            this.ioTrig = new AudioProcessor.RTIO();
            this.io1 = new AudioProcessor.RTIO();
            this.io2 = new AudioProcessor.RTIO();
            this.io3 = new AudioProcessor.RTIO();
            this.io4 = new AudioProcessor.RTIO();
            this.io5 = new AudioProcessor.RTIO();
            this.io6 = new AudioProcessor.RTIO();
            this.io7 = new AudioProcessor.RTIO();
            this.io8 = new AudioProcessor.RTIO();
            this.ledOn = new AudioProcessor.RTLED();
            this.fiPort = new AudioProcessor.RTFlexInput();
            this.SuspendLayout();
            // 
            // ioTrig
            // 
            this.ioTrig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioTrig.contactBackColor = System.Drawing.Color.Black;
            this.ioTrig.contactColor = System.Drawing.Color.DimGray;
            this.ioTrig.Location = new System.Drawing.Point(85, 31);
            this.ioTrig.Name = "ioTrig";
            this.ioTrig.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioTrig.showTitle = true;
            this.ioTrig.Size = new System.Drawing.Size(61, 20);
            this.ioTrig.TabIndex = 15;
            this.ioTrig.Text = "rtio1";
            this.ioTrig.title = "Trg";
            this.ioTrig.titleColor = System.Drawing.Color.DimGray;
            this.ioTrig.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioTrig.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // io1
            // 
            this.io1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.io1.contactBackColor = System.Drawing.Color.Black;
            this.io1.contactColor = System.Drawing.Color.DimGray;
            this.io1.Location = new System.Drawing.Point(85, 57);
            this.io1.Name = "io1";
            this.io1.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.io1.showTitle = true;
            this.io1.Size = new System.Drawing.Size(61, 20);
            this.io1.TabIndex = 16;
            this.io1.Text = "rtio1";
            this.io1.title = "1";
            this.io1.titleColor = System.Drawing.Color.DimGray;
            this.io1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io1.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // io2
            // 
            this.io2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.io2.contactBackColor = System.Drawing.Color.Black;
            this.io2.contactColor = System.Drawing.Color.DimGray;
            this.io2.Location = new System.Drawing.Point(85, 83);
            this.io2.Name = "io2";
            this.io2.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.io2.showTitle = true;
            this.io2.Size = new System.Drawing.Size(61, 20);
            this.io2.TabIndex = 17;
            this.io2.Text = "rtio2";
            this.io2.title = "2";
            this.io2.titleColor = System.Drawing.Color.DimGray;
            this.io2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io2.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // io3
            // 
            this.io3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.io3.contactBackColor = System.Drawing.Color.Black;
            this.io3.contactColor = System.Drawing.Color.DimGray;
            this.io3.Location = new System.Drawing.Point(85, 109);
            this.io3.Name = "io3";
            this.io3.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.io3.showTitle = true;
            this.io3.Size = new System.Drawing.Size(61, 20);
            this.io3.TabIndex = 18;
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
            this.io4.Location = new System.Drawing.Point(85, 135);
            this.io4.Name = "io4";
            this.io4.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.io4.showTitle = true;
            this.io4.Size = new System.Drawing.Size(61, 20);
            this.io4.TabIndex = 19;
            this.io4.Text = "rtio4";
            this.io4.title = "4";
            this.io4.titleColor = System.Drawing.Color.DimGray;
            this.io4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io4.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // io5
            // 
            this.io5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.io5.contactBackColor = System.Drawing.Color.Black;
            this.io5.contactColor = System.Drawing.Color.DimGray;
            this.io5.Location = new System.Drawing.Point(85, 161);
            this.io5.Name = "io5";
            this.io5.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.io5.showTitle = true;
            this.io5.Size = new System.Drawing.Size(61, 20);
            this.io5.TabIndex = 20;
            this.io5.Text = "rtio5";
            this.io5.title = "5";
            this.io5.titleColor = System.Drawing.Color.DimGray;
            this.io5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io5.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // io6
            // 
            this.io6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.io6.contactBackColor = System.Drawing.Color.Black;
            this.io6.contactColor = System.Drawing.Color.DimGray;
            this.io6.Location = new System.Drawing.Point(85, 187);
            this.io6.Name = "io6";
            this.io6.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.io6.showTitle = true;
            this.io6.Size = new System.Drawing.Size(61, 20);
            this.io6.TabIndex = 21;
            this.io6.Text = "rtio6";
            this.io6.title = "6";
            this.io6.titleColor = System.Drawing.Color.DimGray;
            this.io6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io6.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // io7
            // 
            this.io7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.io7.contactBackColor = System.Drawing.Color.Black;
            this.io7.contactColor = System.Drawing.Color.DimGray;
            this.io7.Location = new System.Drawing.Point(85, 213);
            this.io7.Name = "io7";
            this.io7.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.io7.showTitle = true;
            this.io7.Size = new System.Drawing.Size(61, 20);
            this.io7.TabIndex = 22;
            this.io7.Text = "rtio7";
            this.io7.title = "7";
            this.io7.titleColor = System.Drawing.Color.DimGray;
            this.io7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io7.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // io8
            // 
            this.io8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.io8.contactBackColor = System.Drawing.Color.Black;
            this.io8.contactColor = System.Drawing.Color.DimGray;
            this.io8.Location = new System.Drawing.Point(85, 239);
            this.io8.Name = "io8";
            this.io8.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.io8.showTitle = true;
            this.io8.Size = new System.Drawing.Size(61, 20);
            this.io8.TabIndex = 23;
            this.io8.Text = "rtio8";
            this.io8.title = "8";
            this.io8.titleColor = System.Drawing.Color.DimGray;
            this.io8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io8.type = AudioProcessor.RTIO.ProcessingIOType.Output;
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
            this.ledOn.Location = new System.Drawing.Point(26, 31);
            this.ledOn.Name = "ledOn";
            this.ledOn.offText = "";
            this.ledOn.onText = "";
            this.ledOn.Size = new System.Drawing.Size(63, 25);
            this.ledOn.TabIndex = 24;
            this.ledOn.Text = "rtled1";
            this.ledOn.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ledOn.textOffColor = System.Drawing.Color.DimGray;
            this.ledOn.textOnColor = System.Drawing.Color.Red;
            this.ledOn.title = "On";
            this.ledOn.titleColor = System.Drawing.Color.DimGray;
            this.ledOn.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ledOn.titlePos = AudioProcessor.RTLED.RTTitlePos.Left;
            // 
            // fiPort
            // 
            this.fiPort.drawFrame = true;
            this.fiPort.floatVal = 0D;
            this.fiPort.format = "F0";
            this.fiPort.frameColor = System.Drawing.Color.DimGray;
            this.fiPort.inputType = AudioProcessor.RTFlexInput.RTFlexInputType.Integer;
            this.fiPort.intVal = 1988;
            this.fiPort.Location = new System.Drawing.Point(3, 62);
            this.fiPort.maxVal = 65535D;
            this.fiPort.minVal = 0D;
            this.fiPort.Name = "fiPort";
            this.fiPort.Size = new System.Drawing.Size(100, 46);
            this.fiPort.stringVal = "";
            this.fiPort.TabIndex = 25;
            this.fiPort.Text = "rtFlexInput1";
            this.fiPort.title = "Port";
            this.fiPort.titleColor = System.Drawing.Color.DimGray;
            this.fiPort.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.fiPort.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.above;
            this.fiPort.unit = "";
            this.fiPort.valueColor = System.Drawing.Color.DimGray;
            this.fiPort.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.fiPort.valueSize = new System.Drawing.Size(80, 20);
            // 
            // AsyncNetListener
            // 
            this.canShrink = false;
            this.Controls.Add(this.fiPort);
            this.Controls.Add(this.ledOn);
            this.Controls.Add(this.io8);
            this.Controls.Add(this.io7);
            this.Controls.Add(this.io6);
            this.Controls.Add(this.io5);
            this.Controls.Add(this.io4);
            this.Controls.Add(this.io3);
            this.Controls.Add(this.io2);
            this.Controls.Add(this.io1);
            this.Controls.Add(this.ioTrig);
            this.Name = "AsyncNetListener";
            this.Size = new System.Drawing.Size(146, 264);
            this.title = "Net";
            this.ResumeLayout(false);

        }

        bool active;
        int channels;
        int port;
        bool online;
        TcpListener tcpListener;
        TcpClient tcpClient;
        byte[] buffer;
        double[] channelValues;
        bool newValue;
        private RTIO ioTrig;
        private RTIO io1;
        private RTIO io2;
        private RTIO io3;
        private RTIO io4;
        private RTIO io5;
        private RTIO io6;
        private RTIO io7;
        private RTIO io8;
        private RTLED ledOn;
        private RTFlexInput fiPort;
        CommandParser commandParser;

        private string channelName(int i)
        {
            return string.Format("C{0}", i + 1);
        }

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

        private void init()
        {
            InitializeComponent();

            online = false;
            channelValues = new double[channels];
            newValue = false;
            commandParser = new CommandParser(commandParserCallback);

            ledOn.LEDState = false;
            fiPort.intVal = port;

            int h = Height;
            if (channels < 8) { io8.Hide(); h = io8.Location.Y; }
            if (channels < 7) { io7.Hide(); h = io7.Location.Y; }
            if (channels < 6) { io6.Hide(); h = io6.Location.Y; }
            if (channels < 5) { io5.Hide(); h = io5.Location.Y; }
            if (channels < 4) { io4.Hide(); h = io5.Location.Y; }
            if (channels < 3) { io3.Hide(); h = io5.Location.Y; }
            if (channels < 2) { io2.Hide(); h = io5.Location.Y; }
            Height = h;

            fiPort.valueChanged += FiPort_valueChanged;

            /*
            size.set(200, 25 + 50 * (1 + channels));

            for (int i=0;i<channels;i++)
                io.Add(new ProcessingIO(owner, this, ProcessingIO.ProcessingIOType.Output, false, 
                    channelName(i), true, ProcessingIO.ProcessingIOAlign.RightFromTop, Vector.V(25 + 25 + i*50, 0)));

            io.Add(new ProcessingIO(owner, this, ProcessingIO.ProcessingIOType.Output, false, 
                "T", true, ProcessingIO.ProcessingIOAlign.RightFromTop, Vector.V(25 + 25 + channels*50, 0)));


            ctrl.Add(new Controls.Slider(owner, this, Vector.V(20, 40), 10, Controls.Slider.SliderMode.None,1, "Port", null, 
                1024, 65535, port, false, true, "{0:f0}"));
            ctrl.Add(new Controls.LED(owner, this, Vector.V(130, 50), 10, "On", Color.Red));
            */
            processingType = ProcessingType.Source;
        }

        private void FiPort_valueChanged(object sender, EventArgs e)
        {
            port = fiPort.intVal;
        }

        public AsyncNetListener():this(8)
        {
        }

        public AsyncNetListener(int _channels) : base()
        {
            port = 1889;
            channels = _channels;

            init();
        }

        public AsyncNetListener(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            port = src.ReadInt32();
            channels = src.ReadInt32();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write(port);
            tgt.Write(channels);
        }




        /*
        public override void ControlUpdate(ProcessingControl c)
        {
            if (c==ctrl[0])
            {
                // New Port
                port = (int)Math.Floor(((Controls.Slider)ctrl[0]).value + 0.5);
            }
        }
        */
        private class CommandParser
        {
            byte[] input = new byte[1 + 5 + 10 + 1];
            byte[] tgt = new byte[8];
            int len = 0;

            public delegate void CommandParserCallBack(int channel, double value);
            CommandParserCallBack cbk;

            public CommandParser(CommandParserCallBack _cbk)
            {
                cbk = _cbk;
            }

            private uint getbyte(int sp, int bitofs)
            {
                switch (bitofs)
                {
                    case 0: return (uint)(input[sp]     ) | (uint)(input[sp + 1] << 7);
                    case 1: return (uint)(input[sp] >> 1) | (uint)(input[sp + 1] << 6);
                    case 2: return (uint)(input[sp] >> 2) | (uint)(input[sp + 1] << 5);
                    case 3: return (uint)(input[sp] >> 3) | (uint)(input[sp + 1] << 4);
                    case 4: return (uint)(input[sp] >> 4) | (uint)(input[sp + 1] << 3);
                    case 5: return (uint)(input[sp] >> 5) | (uint)(input[sp + 1] << 2);
                    case 6: return (uint)(input[sp] >> 6) | (uint)(input[sp + 1] << 1);
                }
                return 0;
            }

            private void parseNBytes(ref int sp, int len)
            {
                int ofs = 0;
                int stb = 0;
                for (int i = 0; i < len; i++)
                {
                    tgt[i] = (byte) getbyte(sp + ofs, stb);
                    stb++;
                    ofs++;
                    if (stb == 7) { ofs++; stb = 0; }
                }
                sp += ofs + 1;
            }

            int parseUInt16(ref int sp)
            {
                parseNBytes(ref sp, 2);
                return BitConverter.ToUInt16(tgt, 0);
            }

            int parseInt16(ref int sp)
            {
                parseNBytes(ref sp, 2);
                return BitConverter.ToInt16(tgt, 0);
            }

            uint parseUInt32(ref int sp)
            {
                parseNBytes(ref sp, 4);
                return BitConverter.ToUInt32(tgt, 0);
            }

            int parseInt32(ref int sp)
            {
                parseNBytes(ref sp, 4);
                return BitConverter.ToInt32(tgt, 0);
            }

            float parseFloat(ref int sp)
            {
                parseNBytes(ref sp, 4);
                return BitConverter.ToSingle(tgt, 0);
            }

            double parseDouble(ref int sp)
            {
                parseNBytes(ref sp, 8);
                return BitConverter.ToDouble(tgt, 0);
            }

            void parsePacket()
            {
                int crc = 0;
                for (int i = 1; i < input.Length - 1; i++) crc ^= input[i];
                if (crc == input[input.Length-1])
                {
                    // CRC Match
                    int sp = 1;
                    int channel = parseInt32(ref sp);
                    double value = parseDouble(ref sp);
                    // byte[] ba = BitConverter.GetBytes(value);
                    cbk(channel, value);
                }
                len = 0;
            }

            public void add(byte s)
            {
                if (s == 0xFF)
                {
                    input[0] = s;
                    len = 1;
                    return;
                }
                input[len] = s;
                len++;
                if (len == input.Length)
                    parsePacket();
            }
        }

        private void commandParserCallback(int channel, double value)
        {
            if (channel < 0) return;
            if (channel >= channels) return;
            channelValues[channel] = value;
            newValue = true;
        }

        public override void tick()
        {
            if (!active) return;

            if (tcpClient != null)
            {
                if (tcpClient.Connected)
                {
                    online = true;
                    // Client is connected
                    int bytesav = tcpClient.Available;
                    while (bytesav > 0)
                    {
                        if (buffer == null)
                            buffer = new byte[32];
                        int N = 32;
                        if (bytesav < 32)
                            N = bytesav;
                        try
                        {
                            N = tcpClient.GetStream().Read(buffer, 0, N);
                        } catch (Exception e)
                        {
                            N = 0;
                            tcpClient.Close();
                            tcpClient = null;
                            online = false;
                            bytesav = 0;
                            owner.logText("AsyncNetListener: Client closed unexpectedly");
                            owner.showLogWin();
                        }
                        if (N > 0)
                        {
                            for (int i = 0; i < N; i++)
                                commandParser.add(buffer[i]);
                        }
                        bytesav -= N;
                    }
                }
                else
                {
                    online = false;
                    tcpClient.Close();
                    tcpClient = null;
                }
            }
            else if (tcpListener != null)
            {
                if (tcpListener.Pending())
                {
                    tcpClient = tcpListener.AcceptTcpClient();
                    if (!tcpClient.Connected)
                    {
                        tcpClient.Close();
                        tcpClient = null;
                        online = false;
                    }
                    else
                        online = true;
                }
                else
                    online = false;
            }
            else
            {
                startListener();
                online = false;
            }

            DataBuffer[] db = new DataBuffer[channels];
            if (channels > 0) db[0] = getOutputBuffer(io1);
            if (channels > 1) db[1] = getOutputBuffer(io2);
            if (channels > 2) db[2] = getOutputBuffer(io3);
            if (channels > 3) db[3] = getOutputBuffer(io4);
            if (channels > 4) db[4] = getOutputBuffer(io5);
            if (channels > 5) db[5] = getOutputBuffer(io6);
            if (channels > 6) db[6] = getOutputBuffer(io7);
            if (channels > 7) db[7] = getOutputBuffer(io8);

            for (int i=0;i<channels;i++)
                if (db[i] != null)
                    db[i].SetTo(channelValues[i]);

            DataBuffer dbTrig = getOutputBuffer(ioTrig);
            if (dbTrig != null)
            {
                if (newValue)
                {
                    dbTrig.data[0] = 1.0;
                }
            }
            newValue = false;
            if (online && !ledOn.LEDState)
                ledOn.LEDState = true;
            if (!online && ledOn.LEDState)
                ledOn.LEDState = false;
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Source", "Async", "Network Listener", "1 x" }; }
            public override RTForm Instantiate() { return new AsyncNetListener(1); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Source", "Async", "Network Listener", "2 x" }; }
            public override RTForm Instantiate() { return new AsyncNetListener(2); }
        }
        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Source", "Async", "Network Listener", "4 x" }; }
            public override RTForm Instantiate() { return new AsyncNetListener(4); }
        }
        class RegisterClass8 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Source", "Async", "Network Listener", "8 x" }; }
            public override RTForm Instantiate() { return new AsyncNetListener(8); }
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
