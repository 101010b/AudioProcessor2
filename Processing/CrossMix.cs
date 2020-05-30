using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.Processing
{
    class CrossMix : RTForm
    {
        public void InitializeComponent()
        {
            this.ioU = new AudioProcessor.RTIO();
            this.ioA = new AudioProcessor.RTIO();
            this.ioV = new AudioProcessor.RTIO();
            this.ioB = new AudioProcessor.RTIO();
            this.dlQ = new AudioProcessor.RTSlider();
            this.SuspendLayout();
            // 
            // ioU
            // 
            this.ioU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioU.contactBackColor = System.Drawing.Color.Black;
            this.ioU.contactColor = System.Drawing.Color.DimGray;
            this.ioU.contactHighlightColor = System.Drawing.Color.Red;
            this.ioU.hideOnShrink = false;
            this.ioU.highlighted = false;
            this.ioU.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioU.Location = new System.Drawing.Point(148, 23);
            this.ioU.Name = "ioU";
            this.ioU.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioU.showTitle = true;
            this.ioU.Size = new System.Drawing.Size(41, 20);
            this.ioU.TabIndex = 13;
            this.ioU.Text = "rtio3";
            this.ioU.title = "U";
            this.ioU.titleColor = System.Drawing.Color.DimGray;
            this.ioU.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioA
            // 
            this.ioA.contactBackColor = System.Drawing.Color.Black;
            this.ioA.contactColor = System.Drawing.Color.DimGray;
            this.ioA.contactHighlightColor = System.Drawing.Color.Red;
            this.ioA.hideOnShrink = false;
            this.ioA.highlighted = false;
            this.ioA.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioA.Location = new System.Drawing.Point(0, 23);
            this.ioA.Name = "ioA";
            this.ioA.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioA.showTitle = true;
            this.ioA.Size = new System.Drawing.Size(40, 20);
            this.ioA.TabIndex = 11;
            this.ioA.Text = "rtio1";
            this.ioA.title = "A";
            this.ioA.titleColor = System.Drawing.Color.DimGray;
            this.ioA.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioV
            // 
            this.ioV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioV.contactBackColor = System.Drawing.Color.Black;
            this.ioV.contactColor = System.Drawing.Color.DimGray;
            this.ioV.contactHighlightColor = System.Drawing.Color.Red;
            this.ioV.hideOnShrink = false;
            this.ioV.highlighted = false;
            this.ioV.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioV.Location = new System.Drawing.Point(148, 49);
            this.ioV.Name = "ioV";
            this.ioV.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioV.showTitle = true;
            this.ioV.Size = new System.Drawing.Size(41, 20);
            this.ioV.TabIndex = 16;
            this.ioV.Text = "rtio3";
            this.ioV.title = "V";
            this.ioV.titleColor = System.Drawing.Color.DimGray;
            this.ioV.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioB
            // 
            this.ioB.contactBackColor = System.Drawing.Color.Black;
            this.ioB.contactColor = System.Drawing.Color.DimGray;
            this.ioB.contactHighlightColor = System.Drawing.Color.Red;
            this.ioB.hideOnShrink = false;
            this.ioB.highlighted = false;
            this.ioB.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioB.Location = new System.Drawing.Point(0, 49);
            this.ioB.Name = "ioB";
            this.ioB.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB.showTitle = true;
            this.ioB.Size = new System.Drawing.Size(40, 20);
            this.ioB.TabIndex = 15;
            this.ioB.Text = "rtio1";
            this.ioB.title = "B";
            this.ioB.titleColor = System.Drawing.Color.DimGray;
            this.ioB.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dlQ
            // 
            this.dlQ.format = "F2";
            this.dlQ.hideOnShrink = true;
            this.dlQ.lableLength = 3D;
            this.dlQ.Location = new System.Drawing.Point(44, 18);
            this.dlQ.logScale = false;
            this.dlQ.maxVal = 100D;
            this.dlQ.minVal = 0D;
            this.dlQ.Name = "dlQ";
            this.dlQ.scaleColor = System.Drawing.Color.DimGray;
            this.dlQ.scaleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlQ.scaleValueColor = System.Drawing.Color.DimGray;
            this.dlQ.showScale = false;
            this.dlQ.showScaleValues = true;
            this.dlQ.showTitle = true;
            this.dlQ.showValue = true;
            this.dlQ.Size = new System.Drawing.Size(100, 54);
            this.dlQ.slideColor = System.Drawing.Color.Silver;
            this.dlQ.slideDirection = AudioProcessor.RTSlider.SlideDirection.Horizontal;
            this.dlQ.slideKnob = 20D;
            this.dlQ.slideMarkColor = System.Drawing.Color.Red;
            this.dlQ.slideMarkFill = System.Drawing.Color.DarkRed;
            this.dlQ.slideScaleDist = 20D;
            this.dlQ.slideScaleWidth = 10D;
            this.dlQ.slideWidth = 5D;
            this.dlQ.TabIndex = 30;
            this.dlQ.Text = "rtSlider1";
            this.dlQ.title = "A ↔ B";
            this.dlQ.titleColor = System.Drawing.Color.DimGray;
            this.dlQ.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlQ.unit = "";
            this.dlQ.val = 0D;
            this.dlQ.valueColor = System.Drawing.Color.DimGray;
            this.dlQ.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // CrossMix
            // 
            this.canShrink = false;
            this.Controls.Add(this.dlQ);
            this.Controls.Add(this.ioV);
            this.Controls.Add(this.ioB);
            this.Controls.Add(this.ioU);
            this.Controls.Add(this.ioA);
            this.Name = "CrossMix";
            this.shrinkTitle = "CX";
            this.Size = new System.Drawing.Size(189, 78);
            this.title = "CrossMix";
            this.ResumeLayout(false);

        }


        private RTIO ioU;
        private RTIO ioA;
        private RTIO ioV;
        private RTIO ioB;
        private RTSlider dlQ;
        private double m;

        private void init()
        {
            InitializeComponent();

            dlQ.val = m*100;
            dlQ.valueChanged += DlQ_valueChanged1;

            processingType = ProcessingType.Processor;
        }

        private void DlQ_valueChanged1(object sender, EventArgs e)
        {
            m = dlQ.val/100;
        }

        public CrossMix() : base()
        {
            m = 0.5;

            init();
        }

        public CrossMix(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            m = src.ReadDouble();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write(m);
        }

        public override void tick()
        {

            if (!_active)
                return;

            SignalBuffer sigA, sigB, sigU, sigV;

            sigA = getSignalInputBuffer(ioA);
            sigB = getSignalInputBuffer(ioB);
            sigU = getSignalOutputBuffer(ioU);
            sigV = getSignalOutputBuffer(ioV);

            if (sigU != null)
            {
                if ((sigA != null) && (sigB != null))
                {
                    for (int i = 0; i < owner.blockSize; i++)
                        sigU.data[i] = (m - 1) * sigA.data[i] + m * sigB.data[i];
                } else if (sigA != null)
                {
                    for (int i = 0; i < owner.blockSize; i++)
                        sigU.data[i] = (m - 1) * sigA.data[i];
                } else if (sigB != null)
                {
                    for (int i = 0; i < owner.blockSize; i++)
                        sigU.data[i] = m * sigB.data[i];
                }
            }
            if (sigV != null)
            {
                if ((sigA != null) && (sigB != null))
                {
                    for (int i = 0; i < owner.blockSize; i++)
                        sigV.data[i] = m * sigA.data[i] + (m-1) * sigB.data[i];
                }
                else if (sigA != null)
                {
                    for (int i = 0; i < owner.blockSize; i++)
                        sigV.data[i] = m * sigA.data[i];
                }
                else if (sigB != null)
                {
                    for (int i = 0; i < owner.blockSize; i++)
                        sigV.data[i] = (m-1) * sigB.data[i];
                }
            }

        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "CrossMix" }; }
            public override RTForm Instantiate() { return new CrossMix(); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
        }


    }
}
