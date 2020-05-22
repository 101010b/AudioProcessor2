using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.DataProcessing
{
    class DataMerge : RTForm
    {

        public void InitializeComponent()
        {
            this.ioData1 = new AudioProcessor.RTIO();
            this.ioOut = new AudioProcessor.RTIO();
            this.ioData2 = new AudioProcessor.RTIO();
            this.ioData4 = new AudioProcessor.RTIO();
            this.ioData3 = new AudioProcessor.RTIO();
            this.ioData8 = new AudioProcessor.RTIO();
            this.ioData7 = new AudioProcessor.RTIO();
            this.ioData6 = new AudioProcessor.RTIO();
            this.ioData5 = new AudioProcessor.RTIO();
            this.bnSync = new AudioProcessor.RTButton();
            this.SuspendLayout();
            // 
            // ioData1
            // 
            this.ioData1.contactBackColor = System.Drawing.Color.Black;
            this.ioData1.contactColor = System.Drawing.Color.DimGray;
            this.ioData1.contactHighlightColor = System.Drawing.Color.Red;
            this.ioData1.highlighted = false;
            this.ioData1.IOtype = AudioProcessor.RTIO.ProcessingIOType.DataInput;
            this.ioData1.Location = new System.Drawing.Point(0, 25);
            this.ioData1.Name = "ioData1";
            this.ioData1.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioData1.showTitle = true;
            this.ioData1.Size = new System.Drawing.Size(43, 20);
            this.ioData1.TabIndex = 13;
            this.ioData1.Text = "rtio1";
            this.ioData1.title = "D1";
            this.ioData1.titleColor = System.Drawing.Color.DimGray;
            this.ioData1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioOut
            // 
            this.ioOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut.contactBackColor = System.Drawing.Color.Black;
            this.ioOut.contactColor = System.Drawing.Color.DimGray;
            this.ioOut.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut.highlighted = false;
            this.ioOut.IOtype = AudioProcessor.RTIO.ProcessingIOType.DataOutput;
            this.ioOut.Location = new System.Drawing.Point(128, 25);
            this.ioOut.Name = "ioOut";
            this.ioOut.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut.showTitle = false;
            this.ioOut.Size = new System.Drawing.Size(21, 20);
            this.ioOut.TabIndex = 33;
            this.ioOut.Text = "rtio1";
            this.ioOut.title = "FM";
            this.ioOut.titleColor = System.Drawing.Color.DimGray;
            this.ioOut.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioData2
            // 
            this.ioData2.contactBackColor = System.Drawing.Color.Black;
            this.ioData2.contactColor = System.Drawing.Color.DimGray;
            this.ioData2.contactHighlightColor = System.Drawing.Color.Red;
            this.ioData2.highlighted = false;
            this.ioData2.IOtype = AudioProcessor.RTIO.ProcessingIOType.DataInput;
            this.ioData2.Location = new System.Drawing.Point(0, 51);
            this.ioData2.Name = "ioData2";
            this.ioData2.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioData2.showTitle = true;
            this.ioData2.Size = new System.Drawing.Size(43, 20);
            this.ioData2.TabIndex = 34;
            this.ioData2.Text = "rtio1";
            this.ioData2.title = "D2";
            this.ioData2.titleColor = System.Drawing.Color.DimGray;
            this.ioData2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioData4
            // 
            this.ioData4.contactBackColor = System.Drawing.Color.Black;
            this.ioData4.contactColor = System.Drawing.Color.DimGray;
            this.ioData4.contactHighlightColor = System.Drawing.Color.Red;
            this.ioData4.highlighted = false;
            this.ioData4.IOtype = AudioProcessor.RTIO.ProcessingIOType.DataInput;
            this.ioData4.Location = new System.Drawing.Point(0, 103);
            this.ioData4.Name = "ioData4";
            this.ioData4.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioData4.showTitle = true;
            this.ioData4.Size = new System.Drawing.Size(43, 20);
            this.ioData4.TabIndex = 36;
            this.ioData4.Text = "rtio2";
            this.ioData4.title = "D4";
            this.ioData4.titleColor = System.Drawing.Color.DimGray;
            this.ioData4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioData3
            // 
            this.ioData3.contactBackColor = System.Drawing.Color.Black;
            this.ioData3.contactColor = System.Drawing.Color.DimGray;
            this.ioData3.contactHighlightColor = System.Drawing.Color.Red;
            this.ioData3.highlighted = false;
            this.ioData3.IOtype = AudioProcessor.RTIO.ProcessingIOType.DataInput;
            this.ioData3.Location = new System.Drawing.Point(0, 77);
            this.ioData3.Name = "ioData3";
            this.ioData3.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioData3.showTitle = true;
            this.ioData3.Size = new System.Drawing.Size(43, 20);
            this.ioData3.TabIndex = 35;
            this.ioData3.Text = "rtio1";
            this.ioData3.title = "D3";
            this.ioData3.titleColor = System.Drawing.Color.DimGray;
            this.ioData3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioData8
            // 
            this.ioData8.contactBackColor = System.Drawing.Color.Black;
            this.ioData8.contactColor = System.Drawing.Color.DimGray;
            this.ioData8.contactHighlightColor = System.Drawing.Color.Red;
            this.ioData8.highlighted = false;
            this.ioData8.IOtype = AudioProcessor.RTIO.ProcessingIOType.DataInput;
            this.ioData8.Location = new System.Drawing.Point(0, 207);
            this.ioData8.Name = "ioData8";
            this.ioData8.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioData8.showTitle = true;
            this.ioData8.Size = new System.Drawing.Size(43, 20);
            this.ioData8.TabIndex = 40;
            this.ioData8.Text = "rtio4";
            this.ioData8.title = "D8";
            this.ioData8.titleColor = System.Drawing.Color.DimGray;
            this.ioData8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioData7
            // 
            this.ioData7.contactBackColor = System.Drawing.Color.Black;
            this.ioData7.contactColor = System.Drawing.Color.DimGray;
            this.ioData7.contactHighlightColor = System.Drawing.Color.Red;
            this.ioData7.highlighted = false;
            this.ioData7.IOtype = AudioProcessor.RTIO.ProcessingIOType.DataInput;
            this.ioData7.Location = new System.Drawing.Point(0, 181);
            this.ioData7.Name = "ioData7";
            this.ioData7.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioData7.showTitle = true;
            this.ioData7.Size = new System.Drawing.Size(43, 20);
            this.ioData7.TabIndex = 39;
            this.ioData7.Text = "rtio1";
            this.ioData7.title = "D7";
            this.ioData7.titleColor = System.Drawing.Color.DimGray;
            this.ioData7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioData6
            // 
            this.ioData6.contactBackColor = System.Drawing.Color.Black;
            this.ioData6.contactColor = System.Drawing.Color.DimGray;
            this.ioData6.contactHighlightColor = System.Drawing.Color.Red;
            this.ioData6.highlighted = false;
            this.ioData6.IOtype = AudioProcessor.RTIO.ProcessingIOType.DataInput;
            this.ioData6.Location = new System.Drawing.Point(0, 155);
            this.ioData6.Name = "ioData6";
            this.ioData6.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioData6.showTitle = true;
            this.ioData6.Size = new System.Drawing.Size(43, 20);
            this.ioData6.TabIndex = 38;
            this.ioData6.Text = "rtio6";
            this.ioData6.title = "D6";
            this.ioData6.titleColor = System.Drawing.Color.DimGray;
            this.ioData6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioData5
            // 
            this.ioData5.contactBackColor = System.Drawing.Color.Black;
            this.ioData5.contactColor = System.Drawing.Color.DimGray;
            this.ioData5.contactHighlightColor = System.Drawing.Color.Red;
            this.ioData5.highlighted = false;
            this.ioData5.IOtype = AudioProcessor.RTIO.ProcessingIOType.DataInput;
            this.ioData5.Location = new System.Drawing.Point(0, 129);
            this.ioData5.Name = "ioData5";
            this.ioData5.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioData5.showTitle = true;
            this.ioData5.Size = new System.Drawing.Size(43, 20);
            this.ioData5.TabIndex = 37;
            this.ioData5.Text = "rtio1";
            this.ioData5.title = "D5";
            this.ioData5.titleColor = System.Drawing.Color.DimGray;
            this.ioData5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // bnSync
            // 
            this.bnSync.buttonDim = new System.Drawing.Size(60, 15);
            this.bnSync.buttonState = false;
            this.bnSync.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bnSync.fillOffColor = System.Drawing.Color.Green;
            this.bnSync.fillOnColor = System.Drawing.Color.Navy;
            this.bnSync.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnSync.frameOffColor = System.Drawing.Color.Lime;
            this.bnSync.frameOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnSync.Location = new System.Drawing.Point(49, 27);
            this.bnSync.Name = "bnSync";
            this.bnSync.offText = "Sync";
            this.bnSync.onText = "ASync";
            this.bnSync.Size = new System.Drawing.Size(61, 16);
            this.bnSync.TabIndex = 41;
            this.bnSync.Text = "rtButton2";
            this.bnSync.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnSync.textOffColor = System.Drawing.Color.Lime;
            this.bnSync.textOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnSync.title = "Button";
            this.bnSync.titleColor = System.Drawing.Color.DimGray;
            this.bnSync.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnSync.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // DataMerge
            // 
            this.Controls.Add(this.bnSync);
            this.Controls.Add(this.ioData8);
            this.Controls.Add(this.ioData7);
            this.Controls.Add(this.ioData6);
            this.Controls.Add(this.ioData5);
            this.Controls.Add(this.ioData4);
            this.Controls.Add(this.ioData3);
            this.Controls.Add(this.ioData2);
            this.Controls.Add(this.ioOut);
            this.Controls.Add(this.ioData1);
            this.Name = "DataMerge";
            this.shrinkSize = new System.Drawing.Size(86, 236);
            this.shrinkTitle = "M";
            this.Size = new System.Drawing.Size(149, 236);
            this.title = "Merge";
            this.ResumeLayout(false);

        }

        private RTIO ioData1;

        private RTIO ioOut;
        private RTIO ioData2;
        private RTIO ioData4;
        private RTIO ioData3;
        private RTIO ioData8;
        private RTIO ioData7;
        private RTIO ioData6;
        private RTIO ioData5;
        private RTButton bnSync;

        private int channels;
        private bool async;

        private void init()
        {
            InitializeComponent();

            int h = Height;
            if (channels < 8) { ioData8.Hide(); h = ioData8.Top; }
            if (channels < 7) { ioData7.Hide(); h = ioData7.Top; }
            if (channels < 6) { ioData6.Hide(); h = ioData6.Top; }
            if (channels < 5) { ioData5.Hide(); h = ioData5.Top; }
            if (channels < 4) { ioData4.Hide(); h = ioData4.Top; }
            if (channels < 3) { ioData3.Hide(); h = ioData3.Top; }
            Height = h;
            shrinkSize = new System.Drawing.Size(shrinkSize.Width, h);

            bnSync.buttonState = async;

            bnSync.buttonStateChanged += BnSync_buttonStateChanged;

            processingType = ProcessingType.Processor;
        }

        private void BnSync_buttonStateChanged(object sender, EventArgs e)
        {
            async = bnSync.buttonState;
        }

        public DataMerge() : this(8)
        {
        }

        public DataMerge(int _channels) : base()
        {
            channels = _channels;
            async = false;

            init();
        }

        public DataMerge(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            channels = src.ReadInt32();
            async = src.ReadBoolean();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write(channels);
            tgt.Write(async);
        }

        public DataBuffer getChannel(int i)
        {
            if (i >= channels) return null;
            if (i == 0) return getDataInputBuffer(ioData1);
            if (i == 1) return getDataInputBuffer(ioData2);
            if (i == 2) return getDataInputBuffer(ioData3);
            if (i == 3) return getDataInputBuffer(ioData4);
            if (i == 4) return getDataInputBuffer(ioData5);
            if (i == 5) return getDataInputBuffer(ioData6);
            if (i == 6) return getDataInputBuffer(ioData7);
            if (i == 7) return getDataInputBuffer(ioData8);
            return null;
        }

        private class channeldata
        {
            public bool newdata;
            public bool connected;
            public double[] data;

            public channeldata()
            {
                newdata = false;
                connected = false;
                data = null;
            }

            public void setdata(double[] d)
            {
                if ((d == null) || (d.Length < 1))
                    return;
                if ((data == null) || (data.Length != d.Length))
                    data = new double[d.Length];
                Array.Copy(d, data, d.Length);
                newdata = true;
            }
        }

        private channeldata[] chs;
        private double[] sendset;

        public override void tick()
        {
            if (chs == null)
            {
                chs = new channeldata[channels];
                for (int i = 0; i < channels; i++)
                    chs[i] = new channeldata();
            }

            if (!_active)
                return;

            DataBuffer dbout = getDataOutputBuffer(ioOut);
            if (dbout == null)
                return;
            for (int i=0;i<channels;i++)
            {
                DataBuffer dbin = getChannel(i);
                if (dbin == null)
                {
                    // Not connected
                    chs[i].connected = false;
                } else
                {
                    // Connected
                    chs[i].connected = true;
                    if (dbin.size > 0)
                        chs[i].setdata(dbin.data);
                }
            }

            bool dosend = true;
            if (async)
            {
                // send as soon as one dataset shows up
                dosend = false;
                for (int i=0;i<channels;i++)
                {
                    if (chs[i].connected && chs[i].newdata)
                        dosend = true;
                }
            } else
            {
                // Sync --> wait for all Data to show up
                dosend = true;
                for (int i=0;i<channels;i++)
                {
                    if (chs[i].connected && !chs[i].newdata)
                        dosend = false;
                }
            }

            if (dosend)
            {
                int asize = 0;
                for (int i = 0; i < channels; i++)
                    if (chs[i].connected && (chs[i].data != null) && (chs[i].data.Length > 0))
                        asize += chs[i].data.Length;
                if (asize > 0)
                {
                    if ((sendset == null) || (sendset.Length != asize))
                        sendset = new double[asize];
                    int idx = 0;
                    for (int i=0;i<channels;i++)
                    {
                        if (chs[i].connected && (chs[i].data != null) && (chs[i].data.Length > 0))
                        {
                            Array.Copy(chs[i].data, 0, sendset, idx, chs[i].data.Length);
                            idx += chs[i].data.Length;
                        }
                    }
                    dbout.initialize(asize);
                    dbout.set(sendset);
                }
                for (int i = 0; i < channels; i++)
                    chs[i].newdata = false;
            }
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Data", "Merge", "2x"}; }
            public override RTForm Instantiate() { return new DataMerge(2); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Data", "Merge", "4x" }; }
            public override RTForm Instantiate() { return new DataMerge(4); }
        }
        class RegisterClass3 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Data", "Merge", "6x" }; }
            public override RTForm Instantiate() { return new DataMerge(6); }
        }
        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Data", "Merge", "8x" }; }
            public override RTForm Instantiate() { return new DataMerge(8); }
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
