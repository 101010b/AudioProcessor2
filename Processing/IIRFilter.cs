using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.Processing
{
    class IIRFilter : RTForm
    {
        public void InitializeComponent()
        {
            this.ioO1 = new AudioProcessor.RTIO();
            this.dlFreq = new AudioProcessor.RTDial();
            this.ioI1 = new AudioProcessor.RTIO();
            this.ioO2 = new AudioProcessor.RTIO();
            this.ioI2 = new AudioProcessor.RTIO();
            this.ioO3 = new AudioProcessor.RTIO();
            this.ioI3 = new AudioProcessor.RTIO();
            this.ioO4 = new AudioProcessor.RTIO();
            this.ioI4 = new AudioProcessor.RTIO();
            this.ioO5 = new AudioProcessor.RTIO();
            this.ioI5 = new AudioProcessor.RTIO();
            this.ioO6 = new AudioProcessor.RTIO();
            this.ioI6 = new AudioProcessor.RTIO();
            this.ioO7 = new AudioProcessor.RTIO();
            this.ioI7 = new AudioProcessor.RTIO();
            this.ioO8 = new AudioProcessor.RTIO();
            this.ioI8 = new AudioProcessor.RTIO();
            this.dlQ = new AudioProcessor.RTDial();
            this.SuspendLayout();
            // 
            // ioO1
            // 
            this.ioO1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO1.contactBackColor = System.Drawing.Color.Black;
            this.ioO1.contactColor = System.Drawing.Color.DimGray;
            this.ioO1.Location = new System.Drawing.Point(200, 23);
            this.ioO1.Name = "ioO1";
            this.ioO1.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO1.showTitle = false;
            this.ioO1.Size = new System.Drawing.Size(21, 20);
            this.ioO1.TabIndex = 13;
            this.ioO1.Text = "rtio3";
            this.ioO1.title = "0°";
            this.ioO1.titleColor = System.Drawing.Color.DimGray;
            this.ioO1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO1.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // dlFreq
            // 
            this.dlFreq.dialColor = System.Drawing.Color.Silver;
            this.dlFreq.dialDiameter = 50D;
            this.dlFreq.dialMarkColor = System.Drawing.Color.Red;
            this.dlFreq.format = "F0";
            this.dlFreq.Location = new System.Drawing.Point(27, 21);
            this.dlFreq.logScale = true;
            this.dlFreq.maxVal = 100000D;
            this.dlFreq.minVal = 1D;
            this.dlFreq.Name = "dlFreq";
            this.dlFreq.scaleColor = System.Drawing.Color.Gold;
            this.dlFreq.showScale = true;
            this.dlFreq.showTitle = true;
            this.dlFreq.showValue = true;
            this.dlFreq.Size = new System.Drawing.Size(80, 100);
            this.dlFreq.TabIndex = 12;
            this.dlFreq.Text = "rtDial1";
            this.dlFreq.title = "Frequency";
            this.dlFreq.titleColor = System.Drawing.Color.DimGray;
            this.dlFreq.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlFreq.unit = "Hz";
            this.dlFreq.val = 440D;
            this.dlFreq.valueColor = System.Drawing.Color.DimGray;
            this.dlFreq.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI1
            // 
            this.ioI1.contactBackColor = System.Drawing.Color.Black;
            this.ioI1.contactColor = System.Drawing.Color.DimGray;
            this.ioI1.Location = new System.Drawing.Point(0, 23);
            this.ioI1.Name = "ioI1";
            this.ioI1.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI1.showTitle = false;
            this.ioI1.Size = new System.Drawing.Size(21, 20);
            this.ioI1.TabIndex = 11;
            this.ioI1.Text = "rtio1";
            this.ioI1.title = "FM";
            this.ioI1.titleColor = System.Drawing.Color.DimGray;
            this.ioI1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI1.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioO2
            // 
            this.ioO2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO2.contactBackColor = System.Drawing.Color.Black;
            this.ioO2.contactColor = System.Drawing.Color.DimGray;
            this.ioO2.Location = new System.Drawing.Point(200, 49);
            this.ioO2.Name = "ioO2";
            this.ioO2.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO2.showTitle = false;
            this.ioO2.Size = new System.Drawing.Size(21, 20);
            this.ioO2.TabIndex = 16;
            this.ioO2.Text = "rtio3";
            this.ioO2.title = "0°";
            this.ioO2.titleColor = System.Drawing.Color.DimGray;
            this.ioO2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO2.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioI2
            // 
            this.ioI2.contactBackColor = System.Drawing.Color.Black;
            this.ioI2.contactColor = System.Drawing.Color.DimGray;
            this.ioI2.Location = new System.Drawing.Point(0, 49);
            this.ioI2.Name = "ioI2";
            this.ioI2.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI2.showTitle = false;
            this.ioI2.Size = new System.Drawing.Size(21, 20);
            this.ioI2.TabIndex = 15;
            this.ioI2.Text = "rtio1";
            this.ioI2.title = "FM";
            this.ioI2.titleColor = System.Drawing.Color.DimGray;
            this.ioI2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI2.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioO3
            // 
            this.ioO3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO3.contactBackColor = System.Drawing.Color.Black;
            this.ioO3.contactColor = System.Drawing.Color.DimGray;
            this.ioO3.Location = new System.Drawing.Point(200, 75);
            this.ioO3.Name = "ioO3";
            this.ioO3.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO3.showTitle = false;
            this.ioO3.Size = new System.Drawing.Size(21, 20);
            this.ioO3.TabIndex = 18;
            this.ioO3.Text = "rtio3";
            this.ioO3.title = "0°";
            this.ioO3.titleColor = System.Drawing.Color.DimGray;
            this.ioO3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO3.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioI3
            // 
            this.ioI3.contactBackColor = System.Drawing.Color.Black;
            this.ioI3.contactColor = System.Drawing.Color.DimGray;
            this.ioI3.Location = new System.Drawing.Point(0, 75);
            this.ioI3.Name = "ioI3";
            this.ioI3.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI3.showTitle = false;
            this.ioI3.Size = new System.Drawing.Size(21, 20);
            this.ioI3.TabIndex = 17;
            this.ioI3.Text = "rtio1";
            this.ioI3.title = "FM";
            this.ioI3.titleColor = System.Drawing.Color.DimGray;
            this.ioI3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI3.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioO4
            // 
            this.ioO4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO4.contactBackColor = System.Drawing.Color.Black;
            this.ioO4.contactColor = System.Drawing.Color.DimGray;
            this.ioO4.Location = new System.Drawing.Point(200, 101);
            this.ioO4.Name = "ioO4";
            this.ioO4.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO4.showTitle = false;
            this.ioO4.Size = new System.Drawing.Size(21, 20);
            this.ioO4.TabIndex = 20;
            this.ioO4.Text = "rtio3";
            this.ioO4.title = "0°";
            this.ioO4.titleColor = System.Drawing.Color.DimGray;
            this.ioO4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO4.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioI4
            // 
            this.ioI4.contactBackColor = System.Drawing.Color.Black;
            this.ioI4.contactColor = System.Drawing.Color.DimGray;
            this.ioI4.Location = new System.Drawing.Point(0, 101);
            this.ioI4.Name = "ioI4";
            this.ioI4.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI4.showTitle = false;
            this.ioI4.Size = new System.Drawing.Size(21, 20);
            this.ioI4.TabIndex = 19;
            this.ioI4.Text = "rtio1";
            this.ioI4.title = "FM";
            this.ioI4.titleColor = System.Drawing.Color.DimGray;
            this.ioI4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI4.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioO5
            // 
            this.ioO5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO5.contactBackColor = System.Drawing.Color.Black;
            this.ioO5.contactColor = System.Drawing.Color.DimGray;
            this.ioO5.Location = new System.Drawing.Point(200, 127);
            this.ioO5.Name = "ioO5";
            this.ioO5.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO5.showTitle = false;
            this.ioO5.Size = new System.Drawing.Size(21, 20);
            this.ioO5.TabIndex = 22;
            this.ioO5.Text = "rtio3";
            this.ioO5.title = "0°";
            this.ioO5.titleColor = System.Drawing.Color.DimGray;
            this.ioO5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO5.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioI5
            // 
            this.ioI5.contactBackColor = System.Drawing.Color.Black;
            this.ioI5.contactColor = System.Drawing.Color.DimGray;
            this.ioI5.Location = new System.Drawing.Point(0, 127);
            this.ioI5.Name = "ioI5";
            this.ioI5.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI5.showTitle = false;
            this.ioI5.Size = new System.Drawing.Size(21, 20);
            this.ioI5.TabIndex = 21;
            this.ioI5.Text = "rtio1";
            this.ioI5.title = "FM";
            this.ioI5.titleColor = System.Drawing.Color.DimGray;
            this.ioI5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI5.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioO6
            // 
            this.ioO6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO6.contactBackColor = System.Drawing.Color.Black;
            this.ioO6.contactColor = System.Drawing.Color.DimGray;
            this.ioO6.Location = new System.Drawing.Point(200, 153);
            this.ioO6.Name = "ioO6";
            this.ioO6.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO6.showTitle = false;
            this.ioO6.Size = new System.Drawing.Size(21, 20);
            this.ioO6.TabIndex = 24;
            this.ioO6.Text = "rtio3";
            this.ioO6.title = "0°";
            this.ioO6.titleColor = System.Drawing.Color.DimGray;
            this.ioO6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO6.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioI6
            // 
            this.ioI6.contactBackColor = System.Drawing.Color.Black;
            this.ioI6.contactColor = System.Drawing.Color.DimGray;
            this.ioI6.Location = new System.Drawing.Point(0, 153);
            this.ioI6.Name = "ioI6";
            this.ioI6.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI6.showTitle = false;
            this.ioI6.Size = new System.Drawing.Size(21, 20);
            this.ioI6.TabIndex = 23;
            this.ioI6.Text = "rtio1";
            this.ioI6.title = "FM";
            this.ioI6.titleColor = System.Drawing.Color.DimGray;
            this.ioI6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI6.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioO7
            // 
            this.ioO7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO7.contactBackColor = System.Drawing.Color.Black;
            this.ioO7.contactColor = System.Drawing.Color.DimGray;
            this.ioO7.Location = new System.Drawing.Point(200, 179);
            this.ioO7.Name = "ioO7";
            this.ioO7.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO7.showTitle = false;
            this.ioO7.Size = new System.Drawing.Size(21, 20);
            this.ioO7.TabIndex = 26;
            this.ioO7.Text = "rtio3";
            this.ioO7.title = "0°";
            this.ioO7.titleColor = System.Drawing.Color.DimGray;
            this.ioO7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO7.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioI7
            // 
            this.ioI7.contactBackColor = System.Drawing.Color.Black;
            this.ioI7.contactColor = System.Drawing.Color.DimGray;
            this.ioI7.Location = new System.Drawing.Point(0, 179);
            this.ioI7.Name = "ioI7";
            this.ioI7.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI7.showTitle = false;
            this.ioI7.Size = new System.Drawing.Size(21, 20);
            this.ioI7.TabIndex = 25;
            this.ioI7.Text = "rtio1";
            this.ioI7.title = "FM";
            this.ioI7.titleColor = System.Drawing.Color.DimGray;
            this.ioI7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI7.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioO8
            // 
            this.ioO8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO8.contactBackColor = System.Drawing.Color.Black;
            this.ioO8.contactColor = System.Drawing.Color.DimGray;
            this.ioO8.Location = new System.Drawing.Point(200, 205);
            this.ioO8.Name = "ioO8";
            this.ioO8.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO8.showTitle = false;
            this.ioO8.Size = new System.Drawing.Size(21, 20);
            this.ioO8.TabIndex = 28;
            this.ioO8.Text = "rtio3";
            this.ioO8.title = "0°";
            this.ioO8.titleColor = System.Drawing.Color.DimGray;
            this.ioO8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO8.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioI8
            // 
            this.ioI8.contactBackColor = System.Drawing.Color.Black;
            this.ioI8.contactColor = System.Drawing.Color.DimGray;
            this.ioI8.Location = new System.Drawing.Point(0, 205);
            this.ioI8.Name = "ioI8";
            this.ioI8.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI8.showTitle = false;
            this.ioI8.Size = new System.Drawing.Size(21, 20);
            this.ioI8.TabIndex = 27;
            this.ioI8.Text = "rtio1";
            this.ioI8.title = "FM";
            this.ioI8.titleColor = System.Drawing.Color.DimGray;
            this.ioI8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI8.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // dlQ
            // 
            this.dlQ.dialColor = System.Drawing.Color.Silver;
            this.dlQ.dialDiameter = 50D;
            this.dlQ.dialMarkColor = System.Drawing.Color.Red;
            this.dlQ.format = "F0";
            this.dlQ.Location = new System.Drawing.Point(113, 23);
            this.dlQ.logScale = false;
            this.dlQ.maxVal = 30D;
            this.dlQ.minVal = -30D;
            this.dlQ.Name = "dlQ";
            this.dlQ.scaleColor = System.Drawing.Color.Gold;
            this.dlQ.showScale = true;
            this.dlQ.showTitle = true;
            this.dlQ.showValue = true;
            this.dlQ.Size = new System.Drawing.Size(80, 100);
            this.dlQ.TabIndex = 29;
            this.dlQ.Text = "rtDial1";
            this.dlQ.title = "Q";
            this.dlQ.titleColor = System.Drawing.Color.DimGray;
            this.dlQ.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlQ.unit = "dB";
            this.dlQ.val = 0D;
            this.dlQ.valueColor = System.Drawing.Color.DimGray;
            this.dlQ.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // IIRFilter
            // 
            this.canShrink = false;
            this.Controls.Add(this.dlQ);
            this.Controls.Add(this.ioO8);
            this.Controls.Add(this.ioI8);
            this.Controls.Add(this.ioO7);
            this.Controls.Add(this.ioI7);
            this.Controls.Add(this.ioO6);
            this.Controls.Add(this.ioI6);
            this.Controls.Add(this.ioO5);
            this.Controls.Add(this.ioI5);
            this.Controls.Add(this.ioO4);
            this.Controls.Add(this.ioI4);
            this.Controls.Add(this.ioO3);
            this.Controls.Add(this.ioI3);
            this.Controls.Add(this.ioO2);
            this.Controls.Add(this.ioI2);
            this.Controls.Add(this.ioO1);
            this.Controls.Add(this.dlFreq);
            this.Controls.Add(this.ioI1);
            this.Name = "IIRFilter";
            this.Size = new System.Drawing.Size(221, 232);
            this.title = "IIR Filter";
            this.ResumeLayout(false);

        }

        public enum FilterOrder
        {
            First,
            Second,
            Fourth
        }
        FilterOrder filterOrder;
        BiQuad.BiQuadMode filterType;
        double fc;
        double Q;


        int channels;
        List<BiQuad> stage1;
        private RTIO ioO1;
        private RTDial dlFreq;
        private RTIO ioI1;
        private RTIO ioO2;
        private RTIO ioI2;
        private RTIO ioO3;
        private RTIO ioI3;
        private RTIO ioO4;
        private RTIO ioI4;
        private RTIO ioO5;
        private RTIO ioI5;
        private RTIO ioO6;
        private RTIO ioI6;
        private RTIO ioO7;
        private RTIO ioI7;
        private RTIO ioO8;
        private RTIO ioI8;
        private RTDial dlQ;
        List<BiQuad> stage2;
        bool updateNeeded;


        private void init()
        {
            InitializeComponent();

            string ord = "";
            switch (filterOrder)
            {
                case FilterOrder.First: ord = "1st O."; break;
                case FilterOrder.Second: ord = "2nd O."; break;
                case FilterOrder.Fourth: ord = "4th O."; break;
            }
            switch (filterType)
            {
                case BiQuad.BiQuadMode.LowPass: title = "LP " + ord; break;
                case BiQuad.BiQuadMode.HighPass: title = "HP " + ord; break;
                case BiQuad.BiQuadMode.BandPass: title = "BP " + ord; break;
                case BiQuad.BiQuadMode.BandStop: title = "BS " + ord; break;
                case BiQuad.BiQuadMode.Allpass: title = "AP " + ord; break;

            }

            int h = Height;
            if (channels < 8) { ioI8.Hide(); ioO8.Hide(); h = ioO8.Location.Y; }
            if (channels < 7) { ioI7.Hide(); ioO7.Hide(); h = ioO7.Location.Y; }
            if (channels < 6) { ioI6.Hide(); ioO6.Hide(); h = ioO6.Location.Y; }
            if (channels < 5) { ioI5.Hide(); ioO5.Hide(); h = ioO5.Location.Y; }
            if (channels < 4) { ioI4.Hide(); ioO4.Hide(); h = ioO5.Location.Y; }
            if (channels < 3) { ioI3.Hide(); ioO3.Hide(); h = ioO5.Location.Y; }
            if (channels < 2) { ioI2.Hide(); ioO2.Hide(); h = ioO5.Location.Y; }
            Height = h;
            if (filterOrder == FilterOrder.First)
            {
                dlQ.Hide();
                Width = Width - dlQ.Width;
            }

            dlFreq.val = fc;
            if (filterOrder != FilterOrder.First)
                dlQ.val = Q;
            dlFreq.valueChanged += DlFreq_valueChanged;
            if (filterOrder != FilterOrder.First)
                dlQ.valueChanged += DlQ_valueChanged;

            updateNeeded = false;
            processingType = ProcessingType.Processor;
        }

        private void DlQ_valueChanged(object sender, EventArgs e)
        {
            Q = dlQ.val;
            updateNeeded = true;
        }

        private void DlFreq_valueChanged(object sender, EventArgs e)
        {
            fc = dlFreq.val;
            updateNeeded = true;
        }

        public IIRFilter(): this(8,FilterOrder.Second,BiQuad.BiQuadMode.LowPass)
        {
        }

        public IIRFilter(int _channels, FilterOrder _filterOrder, BiQuad.BiQuadMode _filterType):base()
        {
            filterOrder = _filterOrder;
            filterType = _filterType;
            channels = _channels;

            fc = 1000;
            Q = 1 / Math.Sqrt(2);
           
            init();
        }

        public IIRFilter(SystemPanel _owner, BinaryReader src): base(_owner,src)
        {
            filterOrder = (FilterOrder) src.ReadInt32();
            filterType = (BiQuad.BiQuadMode)src.ReadInt32();
            channels = src.ReadInt32();
            fc = src.ReadDouble();
            Q = src.ReadDouble();

            init();

        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write((int)filterOrder);
            tgt.Write((int)filterType);
            tgt.Write(channels);
            tgt.Write(fc);
            tgt.Write(Q);
        }

        public void updateStages()
        {
            switch (filterOrder)
            {
                case FilterOrder.First:
                    for (int i=0;i<channels;i++)
                        stage1[i].frequency = fc;
                    break;
                case FilterOrder.Second:
                    for (int i = 0; i < channels; i++)
                    {
                        stage1[i].frequency = fc;
                        stage1[i].Q = Math.Pow(10,Q/20);
                    }
                    break;
                case FilterOrder.Fourth:
                    for (int i = 0; i < channels; i++)
                    {
                        stage1[i].frequency = fc;
                        stage2[i].frequency = fc;
                        stage1[i].Q = Math.Sqrt(Math.Pow(10,Q/20));
                        stage2[i].Q = Math.Sqrt(Math.Pow(10,Q/20));
                    }
                    break;
            }
            updateNeeded = false;
        }

        private void processChannel(int ch, SignalBuffer dbin, SignalBuffer dbout)
        {
            if ((dbin == null) && (dbout == null))
                return;
            if (dbin != null)
            {
                switch (filterOrder)
                {
                    case FilterOrder.First:
                    case FilterOrder.Second:
                        for (int i = 0; i < owner.blockSize; i++)
                        {
                            double x = dbin.data[i];
                            double y = stage1[ch].filter(x);
                            if (dbout != null) dbout.data[i] = y;
                        }
                        break;
                    case FilterOrder.Fourth:
                        for (int i = 0; i < owner.blockSize; i++)
                        {
                            double x = dbin.data[i];
                            double u = stage1[ch].filter(x);
                            double y = stage2[ch].filter(u);
                            if (dbout != null) dbout.data[i] = y;
                        }
                        break;
                }
            }
        }

        public override void tick()
        {

            if (!_active)
                return;

            if (stage1 == null)
            {
                switch (filterOrder)
                {
                    case FilterOrder.First:
                        stage1 = new List<BiQuad>(channels);
                        for (int i = 0; i < channels; i++)
                            stage1.Add(new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.First, filterType, fc, Math.Pow(10,Q/20)));
                        break;
                    case FilterOrder.Second:
                        stage1 = new List<BiQuad>(channels);
                        for (int i = 0; i < channels; i++)
                            stage1.Add(new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, filterType, fc, Math.Pow(10,Q/20)));
                        break;
                    case FilterOrder.Fourth:
                        stage1 = new List<BiQuad>(channels);
                        for (int i = 0; i < channels; i++)
                            stage1.Add(new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, filterType, fc, Math.Sqrt(Math.Pow(10,Q/20))));
                        stage2 = new List<BiQuad>(channels);
                        for (int i = 0; i < channels; i++)
                            stage2.Add(new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, filterType, fc, Math.Sqrt(Math.Pow(10,Q/20))));
                        break;
                }
                updateNeeded = false;
            }

            if (updateNeeded)
                updateStages();

            if (channels >= 1) processChannel(0, getSignalInputBuffer(ioI1), getSignalOutputBuffer(ioO1));
            if (channels >= 2) processChannel(1, getSignalInputBuffer(ioI2), getSignalOutputBuffer(ioO2));
            if (channels >= 3) processChannel(2, getSignalInputBuffer(ioI3), getSignalOutputBuffer(ioO3));
            if (channels >= 4) processChannel(3, getSignalInputBuffer(ioI4), getSignalOutputBuffer(ioO4));
            if (channels >= 5) processChannel(4, getSignalInputBuffer(ioI5), getSignalOutputBuffer(ioO5));
            if (channels >= 6) processChannel(5, getSignalInputBuffer(ioI6), getSignalOutputBuffer(ioO6));
            if (channels >= 7) processChannel(6, getSignalInputBuffer(ioI7), getSignalOutputBuffer(ioO7));
            if (channels >= 8) processChannel(7, getSignalInputBuffer(ioI8), getSignalOutputBuffer(ioO8));

        }

        class RegisterClass10 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "LowPass", "IIR 1st Order","1x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 1,FilterOrder.First, BiQuad.BiQuadMode.LowPass); }
        }
        class RegisterClass11 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "LowPass", "IIR 1st Order","2x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 2,FilterOrder.First, BiQuad.BiQuadMode.LowPass); }
        }
        class RegisterClass12 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "LowPass", "IIR 1st Order", "4x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 4, FilterOrder.First, BiQuad.BiQuadMode.LowPass); }
        }
        class RegisterClass13 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "LowPass", "IIR 1st Order", "8x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 8, FilterOrder.First, BiQuad.BiQuadMode.LowPass); }
        }





        class RegisterClass20 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "LowPass", "IIR 2nd Order", "1x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 1, FilterOrder.Second, BiQuad.BiQuadMode.LowPass); }
        }
        class RegisterClass21 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "LowPass", "IIR 2nd Order", "2x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 2, FilterOrder.Second, BiQuad.BiQuadMode.LowPass); }
        }
        class RegisterClass22 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "LowPass", "IIR 2nd Order", "4x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 4, FilterOrder.Second, BiQuad.BiQuadMode.LowPass); }
        }
        class RegisterClass23 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "LowPass", "IIR 2nd Order", "8x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 8, FilterOrder.Second, BiQuad.BiQuadMode.LowPass); }
        }


        class RegisterClass30 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "LowPass", "IIR 4th Order", "1x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 1, FilterOrder.Fourth, BiQuad.BiQuadMode.LowPass); }
        }
        class RegisterClass31 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "LowPass", "IIR 4th Order", "2x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 2, FilterOrder.Fourth, BiQuad.BiQuadMode.LowPass); }
        }
        class RegisterClass32 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "LowPass", "IIR 4th Order", "4x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 4, FilterOrder.Fourth, BiQuad.BiQuadMode.LowPass); }
        }
        class RegisterClass33 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "LowPass", "IIR 4th Order", "8x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 8, FilterOrder.Fourth, BiQuad.BiQuadMode.LowPass); }
        }



        class RegisterClass40 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "HighPass", "IIR 1st Order", "1x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 1, FilterOrder.First, BiQuad.BiQuadMode.HighPass); }
        }
        class RegisterClass41 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "HighPass", "IIR 1st Order", "2x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 2, FilterOrder.First, BiQuad.BiQuadMode.HighPass); }
        }
        class RegisterClass42 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "HighPass", "IIR 1st Order", "4x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 4, FilterOrder.First, BiQuad.BiQuadMode.HighPass); }
        }
        class RegisterClass43 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "HighPass", "IIR 1st Order", "8x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 8, FilterOrder.First, BiQuad.BiQuadMode.HighPass); }
        }



        class RegisterClass50 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "HighPass", "IIR 2nd Order","1x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 1, FilterOrder.Second, BiQuad.BiQuadMode.HighPass); }
        }
        class RegisterClass51 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "HighPass", "IIR 2nd Order", "2x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 2, FilterOrder.Second, BiQuad.BiQuadMode.HighPass); }
        }
        class RegisterClass52 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "HighPass", "IIR 2nd Order", "4x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 4, FilterOrder.Second, BiQuad.BiQuadMode.HighPass); }
        }
        class RegisterClass53 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "HighPass", "IIR 2nd Order", "8x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 8, FilterOrder.Second, BiQuad.BiQuadMode.HighPass); }
        }


        class RegisterClass60 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "HighPass", "IIR 4th Order", "1x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 1, FilterOrder.Fourth, BiQuad.BiQuadMode.HighPass); }
        }
        class RegisterClass61 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "HighPass", "IIR 4th Order", "2x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 2, FilterOrder.Fourth, BiQuad.BiQuadMode.HighPass); }
        }
        class RegisterClass62 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "HighPass", "IIR 4th Order", "4x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 4, FilterOrder.Fourth, BiQuad.BiQuadMode.HighPass); }
        }
        class RegisterClass63 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "HighPass", "IIR 4th Order", "8x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 8, FilterOrder.Fourth, BiQuad.BiQuadMode.HighPass); }
        }

        class RegisterClass70 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "BandPass", "IIR 2nd Order", "1x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 1, FilterOrder.Second, BiQuad.BiQuadMode.BandPass); }
        }
        class RegisterClass71 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "BandPass", "IIR 2nd Order", "2x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 2, FilterOrder.Second, BiQuad.BiQuadMode.BandPass); }
        }
        class RegisterClass72 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "BandPass", "IIR 2nd Order", "4x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 4, FilterOrder.Second, BiQuad.BiQuadMode.BandPass); }
        }
        class RegisterClass73 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "BandPass", "IIR 2nd Order", "8x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 8, FilterOrder.Second, BiQuad.BiQuadMode.BandPass); }
        }

        class RegisterClass80 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "BandStop", "IIR 2nd Order", "1x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 1, FilterOrder.Second, BiQuad.BiQuadMode.BandStop); }
        }
        class RegisterClass81 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "BandStop", "IIR 2nd Order", "2x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 2, FilterOrder.Second, BiQuad.BiQuadMode.BandStop); }
        }
        class RegisterClass82 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "BandStop", "IIR 2nd Order", "4x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 4, FilterOrder.Second, BiQuad.BiQuadMode.BandStop); }
        }
        class RegisterClass83 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "BandStop", "IIR 2nd Order", "8x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 8, FilterOrder.Second, BiQuad.BiQuadMode.BandStop); }
        }
        
        class RegisterClass90 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "AllPass", "IIR 1st Order","1x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 1, FilterOrder.First, BiQuad.BiQuadMode.Allpass); }
        }
        class RegisterClass91 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "AllPass", "IIR 1st Order", "2x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 2, FilterOrder.First, BiQuad.BiQuadMode.Allpass); }
        }
        class RegisterClass92 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "AllPass", "IIR 1st Order", "4x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 4, FilterOrder.First, BiQuad.BiQuadMode.Allpass); }
        }
        class RegisterClass93 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "AllPass", "IIR 1st Order", "8x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 8, FilterOrder.First, BiQuad.BiQuadMode.Allpass); }
        }
        
        class RegisterClass100 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "AllPass", "IIR 2nd Order","1x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 1, FilterOrder.Second, BiQuad.BiQuadMode.Allpass); }
        }
        class RegisterClass101 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "AllPass", "IIR 2nd Order", "2x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 2, FilterOrder.Second, BiQuad.BiQuadMode.Allpass); }
        }
        class RegisterClass102 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "AllPass", "IIR 2nd Order", "4x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 4, FilterOrder.Second, BiQuad.BiQuadMode.Allpass); }
        }
        class RegisterClass103 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "AllPass", "IIR 2nd Order", "8x" }; }
            public override RTForm Instantiate() { return new IIRFilter( 8, FilterOrder.Second, BiQuad.BiQuadMode.Allpass); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass10()); l.Add(new RegisterClass11()); l.Add(new RegisterClass12()); l.Add(new RegisterClass13());
            l.Add(new RegisterClass20()); l.Add(new RegisterClass21()); l.Add(new RegisterClass22()); l.Add(new RegisterClass23());
            l.Add(new RegisterClass30()); l.Add(new RegisterClass31()); l.Add(new RegisterClass32()); l.Add(new RegisterClass33());
            l.Add(new RegisterClass40()); l.Add(new RegisterClass41()); l.Add(new RegisterClass42()); l.Add(new RegisterClass43());
            l.Add(new RegisterClass50()); l.Add(new RegisterClass51()); l.Add(new RegisterClass52()); l.Add(new RegisterClass53());
            l.Add(new RegisterClass60()); l.Add(new RegisterClass61()); l.Add(new RegisterClass62()); l.Add(new RegisterClass63());
            l.Add(new RegisterClass70()); l.Add(new RegisterClass71()); l.Add(new RegisterClass72()); l.Add(new RegisterClass73());
            l.Add(new RegisterClass80()); l.Add(new RegisterClass81()); l.Add(new RegisterClass82()); l.Add(new RegisterClass83());
            l.Add(new RegisterClass90()); l.Add(new RegisterClass91()); l.Add(new RegisterClass92()); l.Add(new RegisterClass93());
            l.Add(new RegisterClass100()); l.Add(new RegisterClass101()); l.Add(new RegisterClass102()); l.Add(new RegisterClass103());
        }


    }
}
