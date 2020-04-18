using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.Processing
{
    class VectorDetector : RTForm
    {

        public void InitializeComponent()
        {
            this.ioOQ = new AudioProcessor.RTIO();
            this.ioOI = new AudioProcessor.RTIO();
            this.ioIn = new AudioProcessor.RTIO();
            this.ioRef0 = new AudioProcessor.RTIO();
            this.ioRef90 = new AudioProcessor.RTIO();
            this.ioA = new AudioProcessor.RTIO();
            this.dlF = new AudioProcessor.RTDial();
            this.SuspendLayout();
            // 
            // ioOQ
            // 
            this.ioOQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOQ.contactBackColor = System.Drawing.Color.Black;
            this.ioOQ.contactColor = System.Drawing.Color.DimGray;
            this.ioOQ.Location = new System.Drawing.Point(134, 61);
            this.ioOQ.Name = "ioOQ";
            this.ioOQ.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOQ.showTitle = true;
            this.ioOQ.Size = new System.Drawing.Size(46, 20);
            this.ioOQ.TabIndex = 15;
            this.ioOQ.Text = "rtio3";
            this.ioOQ.title = "Q";
            this.ioOQ.titleColor = System.Drawing.Color.DimGray;
            this.ioOQ.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOQ.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioOI
            // 
            this.ioOI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOI.contactBackColor = System.Drawing.Color.Black;
            this.ioOI.contactColor = System.Drawing.Color.DimGray;
            this.ioOI.Location = new System.Drawing.Point(134, 35);
            this.ioOI.Name = "ioOI";
            this.ioOI.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOI.showTitle = true;
            this.ioOI.Size = new System.Drawing.Size(46, 20);
            this.ioOI.TabIndex = 13;
            this.ioOI.Text = "rtio3";
            this.ioOI.title = "I";
            this.ioOI.titleColor = System.Drawing.Color.DimGray;
            this.ioOI.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOI.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioIn
            // 
            this.ioIn.contactBackColor = System.Drawing.Color.Black;
            this.ioIn.contactColor = System.Drawing.Color.DimGray;
            this.ioIn.Location = new System.Drawing.Point(0, 35);
            this.ioIn.Name = "ioIn";
            this.ioIn.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioIn.showTitle = true;
            this.ioIn.Size = new System.Drawing.Size(46, 20);
            this.ioIn.TabIndex = 12;
            this.ioIn.Text = "rtio1";
            this.ioIn.title = "In";
            this.ioIn.titleColor = System.Drawing.Color.DimGray;
            this.ioIn.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioIn.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioRef0
            // 
            this.ioRef0.contactBackColor = System.Drawing.Color.Black;
            this.ioRef0.contactColor = System.Drawing.Color.DimGray;
            this.ioRef0.Location = new System.Drawing.Point(0, 61);
            this.ioRef0.Name = "ioRef0";
            this.ioRef0.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioRef0.showTitle = true;
            this.ioRef0.Size = new System.Drawing.Size(46, 20);
            this.ioRef0.TabIndex = 16;
            this.ioRef0.Text = "rtio1";
            this.ioRef0.title = "0°";
            this.ioRef0.titleColor = System.Drawing.Color.DimGray;
            this.ioRef0.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioRef0.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioRef90
            // 
            this.ioRef90.contactBackColor = System.Drawing.Color.Black;
            this.ioRef90.contactColor = System.Drawing.Color.DimGray;
            this.ioRef90.Location = new System.Drawing.Point(0, 87);
            this.ioRef90.Name = "ioRef90";
            this.ioRef90.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioRef90.showTitle = true;
            this.ioRef90.Size = new System.Drawing.Size(46, 20);
            this.ioRef90.TabIndex = 17;
            this.ioRef90.Text = "rtio2";
            this.ioRef90.title = "90°";
            this.ioRef90.titleColor = System.Drawing.Color.DimGray;
            this.ioRef90.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioRef90.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioA
            // 
            this.ioA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioA.contactBackColor = System.Drawing.Color.Black;
            this.ioA.contactColor = System.Drawing.Color.DimGray;
            this.ioA.Location = new System.Drawing.Point(134, 87);
            this.ioA.Name = "ioA";
            this.ioA.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioA.showTitle = true;
            this.ioA.Size = new System.Drawing.Size(46, 20);
            this.ioA.TabIndex = 18;
            this.ioA.Text = "rtio3";
            this.ioA.title = "|A|";
            this.ioA.titleColor = System.Drawing.Color.DimGray;
            this.ioA.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioA.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // dlF
            // 
            this.dlF.dialColor = System.Drawing.Color.Silver;
            this.dlF.dialDiameter = 50D;
            this.dlF.dialMarkColor = System.Drawing.Color.Red;
            this.dlF.format = "F0";
            this.dlF.Location = new System.Drawing.Point(52, 23);
            this.dlF.logScale = true;
            this.dlF.maxVal = 100D;
            this.dlF.minVal = 0.01D;
            this.dlF.Name = "dlF";
            this.dlF.scaleColor = System.Drawing.Color.Gold;
            this.dlF.showScale = true;
            this.dlF.showTitle = true;
            this.dlF.showValue = true;
            this.dlF.Size = new System.Drawing.Size(80, 100);
            this.dlF.TabIndex = 19;
            this.dlF.Text = "rtDial1";
            this.dlF.title = "Filter";
            this.dlF.titleColor = System.Drawing.Color.DimGray;
            this.dlF.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlF.unit = "Hz";
            this.dlF.val = 10D;
            this.dlF.valueColor = System.Drawing.Color.DimGray;
            this.dlF.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // VectorDetector
            // 
            this.canShrink = false;
            this.Controls.Add(this.dlF);
            this.Controls.Add(this.ioA);
            this.Controls.Add(this.ioRef90);
            this.Controls.Add(this.ioRef0);
            this.Controls.Add(this.ioOQ);
            this.Controls.Add(this.ioOI);
            this.Controls.Add(this.ioIn);
            this.Name = "VectorDetector";
            this.Size = new System.Drawing.Size(180, 128);
            this.title = "Vector Detector";
            this.ResumeLayout(false);

        }

        double sval;
        double cval;
        double fc;

        BiQuad stage1a, stage2a;
        BiQuad stage1b, stage2b;
        private RTIO ioOQ;
        private RTIO ioOI;
        private RTIO ioIn;
        private RTIO ioRef0;
        private RTIO ioRef90;
        private RTIO ioA;
        private RTDial dlF;

        private void init()
        {
            InitializeComponent();

            dlF.val = fc;

            dlF.valueChanged += DlF_valueChanged;

            sval = cval = 0;

            processingType = ProcessingType.Processor;
        }

        bool updateNeeded;

        public VectorDetector():base()
        {
            fc = 10;
            init();
        }

        public VectorDetector(SystemPanel _owner, BinaryReader src):base(_owner, src)
        {
            fc = src.ReadDouble();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(fc);
        }

        private void DlF_valueChanged(object sender, EventArgs e)
        {
            fc = dlF.val;
            updateNeeded = true;
        }


        public override void tick()
        {
            if (!_active)
                return;

            DataBuffer IN = getInputBuffer(ioIn);
            DataBuffer SIN = getInputBuffer(ioRef0);
            DataBuffer COS = getInputBuffer(ioRef90);

            DataBuffer OUTI = getOutputBuffer(ioOI);
            DataBuffer OUTQ = getOutputBuffer(ioOQ);
            DataBuffer OUTA = getOutputBuffer(ioA);

            if ((IN == null) || (SIN == null) || (COS == null))
                return;
            if ((OUTI == null) && (OUTQ == null) && (OUTA == null))
                return;

            if (stage1a == null)
            {
                stage1a = new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.LowPass, fc, Math.Sqrt(Math.Sqrt(2)));
                stage2a = new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.LowPass, fc, Math.Sqrt(Math.Sqrt(2)));
                stage1b = new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.LowPass, fc, Math.Sqrt(Math.Sqrt(2)));
                stage2b = new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.LowPass, fc, Math.Sqrt(Math.Sqrt(2)));
                updateNeeded = false;
            }
            if (updateNeeded)
            {
                stage1a.frequency = fc;
                stage1b.frequency = fc;
                stage2a.frequency = fc;
                stage2b.frequency = fc;
                updateNeeded = false;
            }

            for (int i = 0; i < owner.blockSize; i++)
            {
                sval = SIN.data[i] * IN.data[i];
                cval = COS.data[i] * IN.data[i];

                double sout = stage2a.filter(stage1a.filter(sval));
                double cout = stage2b.filter(stage1b.filter(cval));

                if (OUTI != null)
                    OUTI.data[i] = sout;
                if (OUTQ != null)
                    OUTQ.data[i] = cout;
                if (OUTA != null)
                    OUTA.data[i] = Math.Sqrt(sout*sout + cout*cout);
            }
        }

        class RegisterClass : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Vector Detector" }; }
            public override RTForm Instantiate() { return new VectorDetector(); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass());
        }


    }
}
