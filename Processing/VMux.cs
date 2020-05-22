using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.Processing
{

    class VMux : RTForm
    {
        private RTIO ioSel;
        private RTIO ioO;
        private RTIO ioI1;
        private RTIO ioI0;

        public void InitializeComponent()
        {
            this.ioSel = new AudioProcessor.RTIO();
            this.ioO = new AudioProcessor.RTIO();
            this.ioI1 = new AudioProcessor.RTIO();
            this.ioI0 = new AudioProcessor.RTIO();
            this.SuspendLayout();
            // 
            // ioSel
            // 
            this.ioSel.contactBackColor = System.Drawing.Color.Black;
            this.ioSel.contactColor = System.Drawing.Color.DimGray;
            this.ioSel.Location = new System.Drawing.Point(0, 79);
            this.ioSel.Name = "ioSel";
            this.ioSel.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioSel.showTitle = true;
            this.ioSel.Size = new System.Drawing.Size(57, 20);
            this.ioSel.TabIndex = 10;
            this.ioSel.Text = "rtio5";
            this.ioSel.title = "sel";
            this.ioSel.titleColor = System.Drawing.Color.DimGray;
            this.ioSel.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioSel.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioO
            // 
            this.ioO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO.contactBackColor = System.Drawing.Color.Black;
            this.ioO.contactColor = System.Drawing.Color.DimGray;
            this.ioO.Location = new System.Drawing.Point(63, 27);
            this.ioO.Name = "ioO";
            this.ioO.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO.showTitle = true;
            this.ioO.Size = new System.Drawing.Size(52, 20);
            this.ioO.TabIndex = 9;
            this.ioO.Text = "rtio3";
            this.ioO.title = "Out";
            this.ioO.titleColor = System.Drawing.Color.DimGray;
            this.ioO.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioI1
            // 
            this.ioI1.contactBackColor = System.Drawing.Color.Black;
            this.ioI1.contactColor = System.Drawing.Color.DimGray;
            this.ioI1.Location = new System.Drawing.Point(0, 53);
            this.ioI1.Name = "ioI1";
            this.ioI1.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI1.showTitle = true;
            this.ioI1.Size = new System.Drawing.Size(57, 20);
            this.ioI1.TabIndex = 8;
            this.ioI1.Text = "rtio2";
            this.ioI1.title = "In(1)";
            this.ioI1.titleColor = System.Drawing.Color.DimGray;
            this.ioI1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI1.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioI0
            // 
            this.ioI0.contactBackColor = System.Drawing.Color.Black;
            this.ioI0.contactColor = System.Drawing.Color.DimGray;
            this.ioI0.Location = new System.Drawing.Point(0, 27);
            this.ioI0.Name = "ioI0";
            this.ioI0.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI0.showTitle = true;
            this.ioI0.Size = new System.Drawing.Size(57, 20);
            this.ioI0.TabIndex = 7;
            this.ioI0.Text = "rtio1";
            this.ioI0.title = "In(0)";
            this.ioI0.titleColor = System.Drawing.Color.DimGray;
            this.ioI0.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI0.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // VMux
            // 
            this.canShrink = false;
            this.Controls.Add(this.ioSel);
            this.Controls.Add(this.ioO);
            this.Controls.Add(this.ioI1);
            this.Controls.Add(this.ioI0);
            this.hasActiveSwitch = false;
            this.Name = "VMux";
            this.Size = new System.Drawing.Size(115, 106);
            this.title = "VMux";
            this.ResumeLayout(false);

        }

        private void init()
        {
            InitializeComponent();

            processingType = ProcessingType.Processor;
        }


        public VMux() : base()
        {
             init();
        }

        public VMux(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
        }

        public override void tick()
        {
            SignalBuffer dbA = getSignalInputBuffer(ioI0);
            SignalBuffer dbB = getSignalInputBuffer(ioI1);
            SignalBuffer dbSel = getSignalInputBuffer(ioSel);
            SignalBuffer dbOut = getSignalOutputBuffer(ioO);

            if (dbOut == null)
                return;

            if (dbSel == null)
            {   // No Selector connected
                if (dbA != null)
                    dbOut.CopyFrom(dbA);
                return;
            }
            if ((dbA == null) && (dbB == null))
            {   // No Inputs connected
                return;
            }

            if (dbA == null)
            {   // Input A not connected
                for (int i = 0; i < owner.blockSize; i++)
                    dbOut.data[i] = (dbSel.data[i] > 0) ? dbB.data[i] : 0.0;
                return;
            }
            if (dbB == null)
            {   // Input B not connected
                for (int i = 0; i < owner.blockSize; i++)
                    dbOut.data[i] = (dbSel.data[i] > 0) ? 0.0 : dbA.data[i];
                return;
            }

            for (int i = 0; i < owner.blockSize; i++)
                dbOut.data[i] = (dbSel.data[i] > 0) ? dbB.data[i] : dbA.data[i];
        }

        class RegisterClass : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "VCMux" }; }
            public override RTForm Instantiate() { return new VMux(); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass());
        }

    }
}
