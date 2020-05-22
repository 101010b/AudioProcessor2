using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.Processing
{
    class Nop : RTForm
    {
        private RTIO ioO;
        private RTIO ioI;

        private void InitializeComponent()
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
            this.ioO.Location = new System.Drawing.Point(46, 25);
            this.ioO.Name = "ioO";
            this.ioO.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO.showTitle = false;
            this.ioO.Size = new System.Drawing.Size(21, 20);
            this.ioO.TabIndex = 19;
            this.ioO.Text = "rtio9";
            this.ioO.title = "A*B1";
            this.ioO.titleColor = System.Drawing.Color.DimGray;
            this.ioO.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioI
            // 
            this.ioI.contactBackColor = System.Drawing.Color.Black;
            this.ioI.contactColor = System.Drawing.Color.DimGray;
            this.ioI.Location = new System.Drawing.Point(0, 25);
            this.ioI.Name = "ioI";
            this.ioI.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI.showTitle = false;
            this.ioI.Size = new System.Drawing.Size(21, 20);
            this.ioI.TabIndex = 18;
            this.ioI.Text = "rtio1";
            this.ioI.title = "A";
            this.ioI.titleColor = System.Drawing.Color.DimGray;
            this.ioI.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // Nop
            // 
            this.canShrink = false;
            this.Controls.Add(this.ioO);
            this.Controls.Add(this.ioI);
            this.hasActiveSwitch = false;
            this.Name = "Nop";
            this.Size = new System.Drawing.Size(67, 52);
            this.title = "NOP";
            this.ResumeLayout(false);

        }

        private void init()
        {
            InitializeComponent();
            processingType = ProcessingType.Processor;
        }

        public Nop():base()
        {
            init();
        }

        public Nop(SystemPanel _owner, BinaryReader src): base(_owner, src)
        {
            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
        }

        public override void tick()
        {
            SignalBuffer dbin = getSignalInputBuffer(ioI);
            SignalBuffer dbout = getSignalOutputBuffer(ioO);

            if ((dbin == null) || (dbout == null))
                return;

            dbout.CopyFrom(dbin);
        }

        class RegisterClass : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "NOP" }; }
            public override RTForm Instantiate() { return new Nop(); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass());
        }

    }
}
