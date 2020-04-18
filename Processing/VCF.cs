using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.Processing
{
    class VCF : RTForm
    {

        public void InitializeComponent()
        {
            this.ioOut = new AudioProcessor.RTIO();
            this.dlQm1 = new AudioProcessor.RTDial();
            this.dlFm1 = new AudioProcessor.RTDial();
            this.ioIn = new AudioProcessor.RTIO();
            this.dlFp1 = new AudioProcessor.RTDial();
            this.dlQp1 = new AudioProcessor.RTDial();
            this.ioF = new AudioProcessor.RTIO();
            this.ioQ = new AudioProcessor.RTIO();
            this.SuspendLayout();
            // 
            // ioOut
            // 
            this.ioOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut.contactBackColor = System.Drawing.Color.Black;
            this.ioOut.contactColor = System.Drawing.Color.DimGray;
            this.ioOut.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut.highlighted = false;
            this.ioOut.Location = new System.Drawing.Point(209, 22);
            this.ioOut.Name = "ioOut";
            this.ioOut.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut.showTitle = true;
            this.ioOut.Size = new System.Drawing.Size(45, 20);
            this.ioOut.TabIndex = 14;
            this.ioOut.Text = "rtio3";
            this.ioOut.title = "Out";
            this.ioOut.titleColor = System.Drawing.Color.DimGray;
            this.ioOut.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOut.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // dlQm1
            // 
            this.dlQm1.dialColor = System.Drawing.Color.Silver;
            this.dlQm1.dialDiameter = 50D;
            this.dlQm1.dialMarkColor = System.Drawing.Color.Red;
            this.dlQm1.format = "F0";
            this.dlQm1.Location = new System.Drawing.Point(42, 105);
            this.dlQm1.logScale = false;
            this.dlQm1.maxVal = 40D;
            this.dlQm1.minVal = -40D;
            this.dlQm1.Name = "dlQm1";
            this.dlQm1.scaleColor = System.Drawing.Color.Gold;
            this.dlQm1.showScale = true;
            this.dlQm1.showTitle = true;
            this.dlQm1.showValue = true;
            this.dlQm1.Size = new System.Drawing.Size(80, 80);
            this.dlQm1.TabIndex = 13;
            this.dlQm1.Text = "rtDial2";
            this.dlQm1.title = "Q(-1)";
            this.dlQm1.titleColor = System.Drawing.Color.DimGray;
            this.dlQm1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlQm1.unit = "dB";
            this.dlQm1.val = -20D;
            this.dlQm1.valueColor = System.Drawing.Color.DimGray;
            this.dlQm1.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dlFm1
            // 
            this.dlFm1.dialColor = System.Drawing.Color.Silver;
            this.dlFm1.dialDiameter = 50D;
            this.dlFm1.dialMarkColor = System.Drawing.Color.Red;
            this.dlFm1.format = "F0";
            this.dlFm1.Location = new System.Drawing.Point(42, 19);
            this.dlFm1.logScale = true;
            this.dlFm1.maxVal = 100000D;
            this.dlFm1.minVal = 1D;
            this.dlFm1.Name = "dlFm1";
            this.dlFm1.scaleColor = System.Drawing.Color.Gold;
            this.dlFm1.showScale = true;
            this.dlFm1.showTitle = true;
            this.dlFm1.showValue = true;
            this.dlFm1.Size = new System.Drawing.Size(80, 80);
            this.dlFm1.TabIndex = 12;
            this.dlFm1.Text = "rtDial1";
            this.dlFm1.title = "F(-1)";
            this.dlFm1.titleColor = System.Drawing.Color.DimGray;
            this.dlFm1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlFm1.unit = "Hz";
            this.dlFm1.val = 220D;
            this.dlFm1.valueColor = System.Drawing.Color.DimGray;
            this.dlFm1.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioIn
            // 
            this.ioIn.contactBackColor = System.Drawing.Color.Black;
            this.ioIn.contactColor = System.Drawing.Color.DimGray;
            this.ioIn.contactHighlightColor = System.Drawing.Color.Red;
            this.ioIn.highlighted = false;
            this.ioIn.Location = new System.Drawing.Point(0, 22);
            this.ioIn.Name = "ioIn";
            this.ioIn.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioIn.showTitle = true;
            this.ioIn.Size = new System.Drawing.Size(34, 20);
            this.ioIn.TabIndex = 11;
            this.ioIn.Text = "rtio1";
            this.ioIn.title = "In";
            this.ioIn.titleColor = System.Drawing.Color.DimGray;
            this.ioIn.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioIn.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // dlFp1
            // 
            this.dlFp1.dialColor = System.Drawing.Color.Silver;
            this.dlFp1.dialDiameter = 50D;
            this.dlFp1.dialMarkColor = System.Drawing.Color.Red;
            this.dlFp1.format = "F0";
            this.dlFp1.Location = new System.Drawing.Point(128, 19);
            this.dlFp1.logScale = true;
            this.dlFp1.maxVal = 100000D;
            this.dlFp1.minVal = 1D;
            this.dlFp1.Name = "dlFp1";
            this.dlFp1.scaleColor = System.Drawing.Color.Gold;
            this.dlFp1.showScale = true;
            this.dlFp1.showTitle = true;
            this.dlFp1.showValue = true;
            this.dlFp1.Size = new System.Drawing.Size(80, 80);
            this.dlFp1.TabIndex = 16;
            this.dlFp1.Text = "rtDial1";
            this.dlFp1.title = "F(+1)";
            this.dlFp1.titleColor = System.Drawing.Color.DimGray;
            this.dlFp1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlFp1.unit = "Hz";
            this.dlFp1.val = 880D;
            this.dlFp1.valueColor = System.Drawing.Color.DimGray;
            this.dlFp1.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dlQp1
            // 
            this.dlQp1.dialColor = System.Drawing.Color.Silver;
            this.dlQp1.dialDiameter = 50D;
            this.dlQp1.dialMarkColor = System.Drawing.Color.Red;
            this.dlQp1.format = "F0";
            this.dlQp1.Location = new System.Drawing.Point(128, 105);
            this.dlQp1.logScale = false;
            this.dlQp1.maxVal = 40D;
            this.dlQp1.minVal = -40D;
            this.dlQp1.Name = "dlQp1";
            this.dlQp1.scaleColor = System.Drawing.Color.Gold;
            this.dlQp1.showScale = true;
            this.dlQp1.showTitle = true;
            this.dlQp1.showValue = true;
            this.dlQp1.Size = new System.Drawing.Size(80, 80);
            this.dlQp1.TabIndex = 17;
            this.dlQp1.Text = "rtDial2";
            this.dlQp1.title = "Q(+1)";
            this.dlQp1.titleColor = System.Drawing.Color.DimGray;
            this.dlQp1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlQp1.unit = "dB";
            this.dlQp1.val = -20D;
            this.dlQp1.valueColor = System.Drawing.Color.DimGray;
            this.dlQp1.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioF
            // 
            this.ioF.contactBackColor = System.Drawing.Color.Black;
            this.ioF.contactColor = System.Drawing.Color.DimGray;
            this.ioF.contactHighlightColor = System.Drawing.Color.Red;
            this.ioF.highlighted = false;
            this.ioF.Location = new System.Drawing.Point(0, 48);
            this.ioF.Name = "ioF";
            this.ioF.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioF.showTitle = true;
            this.ioF.Size = new System.Drawing.Size(34, 20);
            this.ioF.TabIndex = 18;
            this.ioF.Text = "rtio1";
            this.ioF.title = "f";
            this.ioF.titleColor = System.Drawing.Color.DimGray;
            this.ioF.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioF.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioQ
            // 
            this.ioQ.contactBackColor = System.Drawing.Color.Black;
            this.ioQ.contactColor = System.Drawing.Color.DimGray;
            this.ioQ.contactHighlightColor = System.Drawing.Color.Red;
            this.ioQ.highlighted = false;
            this.ioQ.Location = new System.Drawing.Point(0, 74);
            this.ioQ.Name = "ioQ";
            this.ioQ.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioQ.showTitle = true;
            this.ioQ.Size = new System.Drawing.Size(34, 20);
            this.ioQ.TabIndex = 19;
            this.ioQ.Text = "rtio2";
            this.ioQ.title = "Q";
            this.ioQ.titleColor = System.Drawing.Color.DimGray;
            this.ioQ.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioQ.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // VCF
            // 
            this.Controls.Add(this.ioQ);
            this.Controls.Add(this.ioF);
            this.Controls.Add(this.dlQp1);
            this.Controls.Add(this.dlFp1);
            this.Controls.Add(this.ioOut);
            this.Controls.Add(this.dlQm1);
            this.Controls.Add(this.dlFm1);
            this.Controls.Add(this.ioIn);
            this.Name = "VCF";
            this.shrinkSize = new System.Drawing.Size(99, 97);
            this.shrinkTitle = "VCF";
            this.Size = new System.Drawing.Size(254, 197);
            this.title = "VCF";
            this.ResumeLayout(false);

        }

        double f1, f2;
        double q1, q2;

        bool HighPass;
        private RTIO ioOut;
        private RTDial dlQm1;
        private RTDial dlFm1;
        private RTIO ioIn;
        private RTDial dlFp1;
        private RTDial dlQp1;
        private RTIO ioF;
        private RTIO ioQ;
        BiQuad filter;

        private void init()
        {
            InitializeComponent();
            if (HighPass)
            {
                title = "VCF HP";
                shrinkTitle = "HP";
            }
            else
            {
                title = "VCF LP";
                shrinkTitle = "LP";
            }

            dlFm1.val = f1;
            dlFp1.val = f2;
            dlQm1.val = q1;
            dlQp1.val = q2;

            dlFm1.valueChanged += DlFm1_valueChanged;
            dlFp1.valueChanged += DlFp1_valueChanged;
            dlQm1.valueChanged += DlQm1_valueChanged;
            dlQp1.valueChanged += DlQp1_valueChanged;

            processingType = ProcessingType.Processor;
        }

        public VCF():this(false)
        {
        }

        public VCF(bool _highpass) : base()
        {
            HighPass = _highpass;
            f1 = 440;
            f2 = f1*4;
            q1 = -10;
            q2 = 10;

            init();
        }

        public VCF(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            HighPass = src.ReadBoolean();
            f1 = src.ReadDouble();
            f2 = src.ReadDouble();
            q1 = src.ReadDouble();
            q2 = src.ReadDouble();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            tgt.Write(HighPass);
            tgt.Write(f1);
            tgt.Write(f2);
            tgt.Write(q1);
            tgt.Write(q2);

            base.writeToFile(tgt);
        }

        private void DlQp1_valueChanged(object sender, EventArgs e)
        {
            q2 = dlQp1.val;
        }

        private void DlQm1_valueChanged(object sender, EventArgs e)
        {
            q1 = dlQm1.val;
        }

        private void DlFp1_valueChanged(object sender, EventArgs e)
        {
            f2 = dlFp1.val;
        }

        private void DlFm1_valueChanged(object sender, EventArgs e)
        {
            f1 = dlFm1.val;
        }

        public override void tick()
        {
            if (!_active) return;

            DataBuffer dbin = getInputBuffer(ioIn);
            DataBuffer dbout = getOutputBuffer(ioOut);
            if (!active)
            {
                if ((dbin != null) && (dbout != null))
                    dbout.CopyFrom(dbin);
                return;
            }
            DataBuffer dbf = getInputBuffer(ioF);
            DataBuffer dbq = getInputBuffer(ioQ);

            if (dbout == null)
                return;
            if (dbin == null)
                return;

            if (filter == null)
            {
                if (HighPass)
                    filter = new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.HighPass, Math.Sqrt(f1 * f2), Math.Pow(10, (q1 + q2) / 2 / 20));
                else
                    filter = new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.LowPass, Math.Sqrt(f1 * f2), Math.Pow(10, (q1 + q2) / 2 / 20));
            }

            for (int i=0;i<owner.blockSize;i++)
            {
                double fin = (dbf != null) ? dbf.data[i] : 0;
                double qin = (dbq != null) ? dbq.data[i] : 0;
                double sig = (dbin!=null) ? dbin.data[i]:0;
                fin = f1 * Math.Pow(f2 / f1, (fin + 1.0) / 2.0);
                qin = Math.Pow(10, (q1 + (q2 - q1) * (qin + 1.0) / 2) / 20);
                filter.frequency = fin;
                filter.Q = qin;
                sig = filter.filter(sig);
                dbout.data[i] = sig;
            }
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "LowPass","VCF" }; }
            public override RTForm Instantiate() { return new VCF(false); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "HighPass","VCF"}; }
            public override RTForm Instantiate() { return new VCF(true); }
        }
        public static void Register(List<RTObjectReference> l) {
            l.Add(new RegisterClass1());
            l.Add(new RegisterClass2());
        }


    }
}
