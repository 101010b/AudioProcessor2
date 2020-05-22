using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.Processing
{
    class IIRAFilter : RTForm
    {

        public void InitializeComponent()
        {
            this.ioO = new AudioProcessor.RTIO();
            this.ioI = new AudioProcessor.RTIO();
            this.SuspendLayout();
            // 
            // ioO
            // 
            this.ioO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO.contactBackColor = System.Drawing.Color.Black;
            this.ioO.contactColor = System.Drawing.Color.DimGray;
            this.ioO.Location = new System.Drawing.Point(98, 23);
            this.ioO.Name = "ioO";
            this.ioO.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO.showTitle = false;
            this.ioO.Size = new System.Drawing.Size(21, 20);
            this.ioO.TabIndex = 12;
            this.ioO.Text = "rtio3";
            this.ioO.title = "0°";
            this.ioO.titleColor = System.Drawing.Color.DimGray;
            this.ioO.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioI
            // 
            this.ioI.contactBackColor = System.Drawing.Color.Black;
            this.ioI.contactColor = System.Drawing.Color.DimGray;
            this.ioI.Location = new System.Drawing.Point(0, 23);
            this.ioI.Name = "ioI";
            this.ioI.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI.showTitle = false;
            this.ioI.Size = new System.Drawing.Size(21, 20);
            this.ioI.TabIndex = 11;
            this.ioI.Text = "rtio1";
            this.ioI.title = "FM";
            this.ioI.titleColor = System.Drawing.Color.DimGray;
            this.ioI.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // IIRAFilter
            // 
            this.canShrink = false;
            this.Controls.Add(this.ioO);
            this.Controls.Add(this.ioI);
            this.Name = "IIRAFilter";
            this.Size = new System.Drawing.Size(119, 48);
            this.title = "A-Filter";
            this.ResumeLayout(false);

        }

        private RTIO ioO;
        private RTIO ioI;
        AFilterIIR filter;

        private void init()
        {
            InitializeComponent();

            processingType = ProcessingType.Processor;
        }


        public IIRAFilter():base()
        {
            init();
        }

        public IIRAFilter(SystemPanel _owner, BinaryReader src): base(_owner,src)
        {
            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
        }

        public override void tick()
        {
            if (!_active)
                return;
            SignalBuffer dbin = getSignalInputBuffer(ioI);
            SignalBuffer dbout = getSignalOutputBuffer(ioO);
            if ((dbin == null) && (dbout == null))
                return;

            if (filter == null)
                filter = new AFilterIIR(owner.sampleRate);

            if (dbin != null)
            {
                for (int i = 0; i < owner.blockSize; i++)
                {
                    double x = dbin.data[i];
                    double y = filter.filter(x);
                    if (dbout != null) dbout.data[i] = y;
                }
            }
        }

        class RegisterClass : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "Weighting", "A-Weighting" }; }
            public override RTForm Instantiate() { return new IIRAFilter(); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass());
        }

    }
}
