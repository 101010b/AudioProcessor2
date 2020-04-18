using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.Processing
{
    class PLL:RTForm
    {

        public void InitializeComponent()
        {
            this.ioOI = new AudioProcessor.RTIO();
            this.dlLoop = new AudioProcessor.RTDial();
            this.ioII = new AudioProcessor.RTIO();
            this.ioIQ = new AudioProcessor.RTIO();
            this.ioOQ = new AudioProcessor.RTIO();
            this.ioA = new AudioProcessor.RTIO();
            this.ioF = new AudioProcessor.RTIO();
            this.dlCenterf = new AudioProcessor.RTDial();
            this.dlloopgain = new AudioProcessor.RTDial();
            this.SuspendLayout();
            // 
            // ioOI
            // 
            this.ioOI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOI.contactBackColor = System.Drawing.Color.Black;
            this.ioOI.contactColor = System.Drawing.Color.DimGray;
            this.ioOI.Location = new System.Drawing.Point(295, 32);
            this.ioOI.Name = "ioOI";
            this.ioOI.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOI.showTitle = true;
            this.ioOI.Size = new System.Drawing.Size(37, 20);
            this.ioOI.TabIndex = 13;
            this.ioOI.Text = "rtio3";
            this.ioOI.title = "I";
            this.ioOI.titleColor = System.Drawing.Color.DimGray;
            this.ioOI.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOI.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // dlLoop
            // 
            this.dlLoop.dialColor = System.Drawing.Color.Silver;
            this.dlLoop.dialDiameter = 50D;
            this.dlLoop.dialMarkColor = System.Drawing.Color.Red;
            this.dlLoop.format = "F2";
            this.dlLoop.Location = new System.Drawing.Point(38, 30);
            this.dlLoop.logScale = true;
            this.dlLoop.maxVal = 100D;
            this.dlLoop.minVal = 0.01D;
            this.dlLoop.Name = "dlLoop";
            this.dlLoop.scaleColor = System.Drawing.Color.Gold;
            this.dlLoop.showScale = true;
            this.dlLoop.showTitle = true;
            this.dlLoop.showValue = true;
            this.dlLoop.Size = new System.Drawing.Size(80, 100);
            this.dlLoop.TabIndex = 12;
            this.dlLoop.Text = "rtDial1";
            this.dlLoop.title = "Loop F";
            this.dlLoop.titleColor = System.Drawing.Color.DimGray;
            this.dlLoop.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlLoop.unit = "Hz";
            this.dlLoop.val = 10D;
            this.dlLoop.valueColor = System.Drawing.Color.DimGray;
            this.dlLoop.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioII
            // 
            this.ioII.contactBackColor = System.Drawing.Color.Black;
            this.ioII.contactColor = System.Drawing.Color.DimGray;
            this.ioII.Location = new System.Drawing.Point(0, 32);
            this.ioII.Name = "ioII";
            this.ioII.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioII.showTitle = true;
            this.ioII.Size = new System.Drawing.Size(32, 20);
            this.ioII.TabIndex = 11;
            this.ioII.Text = "rtio1";
            this.ioII.title = "I";
            this.ioII.titleColor = System.Drawing.Color.DimGray;
            this.ioII.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioII.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioIQ
            // 
            this.ioIQ.contactBackColor = System.Drawing.Color.Black;
            this.ioIQ.contactColor = System.Drawing.Color.DimGray;
            this.ioIQ.Location = new System.Drawing.Point(0, 58);
            this.ioIQ.Name = "ioIQ";
            this.ioIQ.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioIQ.showTitle = true;
            this.ioIQ.Size = new System.Drawing.Size(32, 20);
            this.ioIQ.TabIndex = 15;
            this.ioIQ.Text = "rtio1";
            this.ioIQ.title = "Q";
            this.ioIQ.titleColor = System.Drawing.Color.DimGray;
            this.ioIQ.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioIQ.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioOQ
            // 
            this.ioOQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOQ.contactBackColor = System.Drawing.Color.Black;
            this.ioOQ.contactColor = System.Drawing.Color.DimGray;
            this.ioOQ.Location = new System.Drawing.Point(295, 58);
            this.ioOQ.Name = "ioOQ";
            this.ioOQ.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOQ.showTitle = true;
            this.ioOQ.Size = new System.Drawing.Size(37, 20);
            this.ioOQ.TabIndex = 16;
            this.ioOQ.Text = "rtio3";
            this.ioOQ.title = "Q";
            this.ioOQ.titleColor = System.Drawing.Color.DimGray;
            this.ioOQ.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOQ.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioA
            // 
            this.ioA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioA.contactBackColor = System.Drawing.Color.Black;
            this.ioA.contactColor = System.Drawing.Color.DimGray;
            this.ioA.Location = new System.Drawing.Point(295, 84);
            this.ioA.Name = "ioA";
            this.ioA.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioA.showTitle = true;
            this.ioA.Size = new System.Drawing.Size(37, 20);
            this.ioA.TabIndex = 17;
            this.ioA.Text = "rtio3";
            this.ioA.title = "[A]";
            this.ioA.titleColor = System.Drawing.Color.DimGray;
            this.ioA.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioA.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioF
            // 
            this.ioF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioF.contactBackColor = System.Drawing.Color.Black;
            this.ioF.contactColor = System.Drawing.Color.DimGray;
            this.ioF.Location = new System.Drawing.Point(295, 110);
            this.ioF.Name = "ioF";
            this.ioF.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioF.showTitle = true;
            this.ioF.Size = new System.Drawing.Size(37, 20);
            this.ioF.TabIndex = 18;
            this.ioF.Text = "rtio4";
            this.ioF.title = "f";
            this.ioF.titleColor = System.Drawing.Color.DimGray;
            this.ioF.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioF.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // dlCenterf
            // 
            this.dlCenterf.dialColor = System.Drawing.Color.Silver;
            this.dlCenterf.dialDiameter = 50D;
            this.dlCenterf.dialMarkColor = System.Drawing.Color.Red;
            this.dlCenterf.format = "F0";
            this.dlCenterf.Location = new System.Drawing.Point(124, 30);
            this.dlCenterf.logScale = true;
            this.dlCenterf.maxVal = 100000D;
            this.dlCenterf.minVal = 100D;
            this.dlCenterf.Name = "dlCenterf";
            this.dlCenterf.scaleColor = System.Drawing.Color.Gold;
            this.dlCenterf.showScale = true;
            this.dlCenterf.showTitle = true;
            this.dlCenterf.showValue = true;
            this.dlCenterf.Size = new System.Drawing.Size(80, 100);
            this.dlCenterf.TabIndex = 19;
            this.dlCenterf.Text = "rtDial1";
            this.dlCenterf.title = "Center F";
            this.dlCenterf.titleColor = System.Drawing.Color.DimGray;
            this.dlCenterf.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlCenterf.unit = "Hz";
            this.dlCenterf.val = 1000D;
            this.dlCenterf.valueColor = System.Drawing.Color.DimGray;
            this.dlCenterf.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dlloopgain
            // 
            this.dlloopgain.dialColor = System.Drawing.Color.Silver;
            this.dlloopgain.dialDiameter = 50D;
            this.dlloopgain.dialMarkColor = System.Drawing.Color.Red;
            this.dlloopgain.format = "F0";
            this.dlloopgain.Location = new System.Drawing.Point(210, 32);
            this.dlloopgain.logScale = false;
            this.dlloopgain.maxVal = 100D;
            this.dlloopgain.minVal = -40D;
            this.dlloopgain.Name = "dlloopgain";
            this.dlloopgain.scaleColor = System.Drawing.Color.Gold;
            this.dlloopgain.showScale = true;
            this.dlloopgain.showTitle = true;
            this.dlloopgain.showValue = true;
            this.dlloopgain.Size = new System.Drawing.Size(80, 100);
            this.dlloopgain.TabIndex = 20;
            this.dlloopgain.Text = "rtDial2";
            this.dlloopgain.title = "Loop Gain";
            this.dlloopgain.titleColor = System.Drawing.Color.DimGray;
            this.dlloopgain.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlloopgain.unit = "dB";
            this.dlloopgain.val = 60D;
            this.dlloopgain.valueColor = System.Drawing.Color.DimGray;
            this.dlloopgain.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // PLL
            // 
            this.canShrink = false;
            this.Controls.Add(this.dlloopgain);
            this.Controls.Add(this.dlCenterf);
            this.Controls.Add(this.ioF);
            this.Controls.Add(this.ioA);
            this.Controls.Add(this.ioOQ);
            this.Controls.Add(this.ioIQ);
            this.Controls.Add(this.ioOI);
            this.Controls.Add(this.dlLoop);
            this.Controls.Add(this.ioII);
            this.Name = "PLL";
            this.Size = new System.Drawing.Size(332, 136);
            this.title = "PLL";
            this.ResumeLayout(false);

        }

        double fc;
        double fl;
        double KA;

        BiQuad loopstage;
        BiQuadC fclpa, fclpb;
        BiQuadC fchpa, fchpb;

        //BiQuadC lp1, lp2;
        BiQuad lp1, lp2;
        BiQuad lp3, lp4;


        bool updateNeeded;
        private RTIO ioOI;
        private RTDial dlLoop;
        private RTIO ioII;
        private RTIO ioIQ;
        private RTIO ioOQ;
        private RTIO ioA;
        private RTIO ioF;
        private RTDial dlCenterf;
        private RTDial dlloopgain;

        // Operation Variables
        double phs;

        private void init()
        {
            InitializeComponent();

            dlLoop.val = fl;
            dlCenterf.val = fc;
            dlloopgain.val = KA;

            dlLoop.valueChanged += DlLoop_valueChanged;
            dlCenterf.valueChanged += DlCenterf_valueChanged;
            dlloopgain.valueChanged += Dlloopgain_valueChanged;

            updateNeeded = false;

            processingType = ProcessingType.Processor;
        }

        private void Dlloopgain_valueChanged(object sender, EventArgs e)
        {
            KA = dlloopgain.val;
            updateNeeded = false;
        }

        private void DlCenterf_valueChanged(object sender, EventArgs e)
        {
            fc = dlCenterf.val;
            updateNeeded = false;
        }

        private void DlLoop_valueChanged(object sender, EventArgs e)
        {
            fl = dlLoop.val;
            updateNeeded = false;
        }

        public PLL():base()
        {
            fl = 10;
            fc = 1000;
            KA = 60;

            init();
        }

        public PLL(SystemPanel _owner, BinaryReader src):base(_owner, src)
        {
            fc = src.ReadDouble();
            fl = src.ReadDouble();
            KA = src.ReadDouble();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(fc);
            tgt.Write(fl);
            tgt.Write(KA);
        }

        public override void tick()
        {
            if (!_active) return;

            if (loopstage == null)
            {
                loopstage = new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.LoopFilter, fl, 1.0 / Math.Sqrt(2), 1000);

                fclpa = new BiQuadC(owner.sampleRate, BiQuadC.BiQuadOrder.Second, BiQuadC.BiQuadMode.LowPass, fc * 1.2, 1.0 / Math.Sqrt(2));
                fclpb = new BiQuadC(owner.sampleRate, BiQuadC.BiQuadOrder.Second, BiQuadC.BiQuadMode.LowPass, fc * 1.2, 1.0);
                fchpa = new BiQuadC(owner.sampleRate, BiQuadC.BiQuadOrder.Second, BiQuadC.BiQuadMode.HighPass, fc / 1.2, 1.0 / Math.Sqrt(2));
                fchpb = new BiQuadC(owner.sampleRate, BiQuadC.BiQuadOrder.Second, BiQuadC.BiQuadMode.HighPass, fc / 1.2, 1.0);

                //lp1 = new BiQuadC(owner.sampleRate, BiQuadC.BiQuadOrder.Second, BiQuadC.BiQuadMode.LowPass, fc / 2, 1.0 / Math.Sqrt(2));
                //lp2 = new BiQuadC(owner.sampleRate, BiQuadC.BiQuadOrder.Second, BiQuadC.BiQuadMode.LowPass, fc / 2, 1.0);
                lp1 = new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.LowPass, fc / 2, 1.0 / Math.Sqrt(2));
                lp2 = new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.LowPass, fc / 2, 1.0);
                lp3 = new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.LowPass, fc / 2, 1.0 / Math.Sqrt(2));
                lp4 = new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.LowPass, fc / 2, 1.0);

                updateNeeded = false;
            }

            if (updateNeeded)
            {
                loopstage.frequency = fl;
                loopstage.KA = Math.Pow(10,KA/20);

                fclpa.frequency = fc * 1.2;
                fclpb.frequency = fc * 1.2;

                fchpa.frequency = fc / 1.2;
                fchpb.frequency = fc / 1.2;

                lp1.frequency = fc / 2;
                lp2.frequency = fc / 2;
                lp3.frequency = fc / 2;
                lp4.frequency = fc / 2;

                updateNeeded = false;
            }

            DataBuffer INI = getInputBuffer(ioII);
            DataBuffer INQ = getInputBuffer(ioIQ);

            DataBuffer OUTI = getOutputBuffer(ioOI);
            DataBuffer OUTQ = getOutputBuffer(ioOQ);
            DataBuffer OUTA = getOutputBuffer(ioA);
            DataBuffer OUTF = getOutputBuffer(ioF);

            for (int i = 0; i < owner.blockSize; i++)
            {
                double ini = (INI != null) ? INI.data[i] : 0.0;
                double inq = (INQ != null) ? INQ.data[i] : 0.0;
                Complex inv = new Complex(ini, inq);

                Complex inf = fclpa.filter(fclpb.filter(fchpa.filter(fchpb.filter(inv))));
                double infa = inf.abs;

                double sval = Math.Sin(phs);
                double cval = Math.Cos(phs);

                double lin = Complex.arg(inf * Complex.conj(Complex.exp(new Complex(0, phs))));
                double lout = loopstage.filter(lin);

                phs = lout;
                phs -= 2 * Math.PI * Math.Floor(phs / (2 * Math.PI));

                double xr = sval * ini + cval * inq;
                double xi = sval * inq - cval * ini;

                // Complex o = lp2.filter(lp1.filter(new Complex(xr, xi)));
                double o = lp2.filter(lp1.filter(Math.Abs(xr * xr + xi * xi)));
                double p = lp4.filter(lp3.filter(Math.Atan2(xi,xr)));

                if (OUTI != null)
                    OUTI.data[i] = sval;
                if (OUTQ != null)
                    OUTQ.data[i] = cval;
                if (OUTA != null)
                    // OUTA.data[i] = o.abs;
                    OUTA.data[i] = o;
                if (OUTF != null)
                    OUTF.data[i] = p; //  o.phi;
            }
        }

        class RegisterClass : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "PLL" }; }
            public override RTForm Instantiate() { return new PLL(); }
        }
        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass());
        }



    }
}
