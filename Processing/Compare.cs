using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.Processing
{

    public class Compare : RTForm
    {

        public void InitializeComponent()
        {
            this.ioA = new AudioProcessor.RTIO();
            this.ioB = new AudioProcessor.RTIO();
            this.ioOut = new AudioProcessor.RTIO();
            this.SuspendLayout();
            // 
            // ioA
            // 
            this.ioA.contactBackColor = System.Drawing.Color.Black;
            this.ioA.contactColor = System.Drawing.Color.DimGray;
            this.ioA.Location = new System.Drawing.Point(0, 27);
            this.ioA.Name = "ioA";
            this.ioA.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioA.showTitle = true;
            this.ioA.Size = new System.Drawing.Size(42, 20);
            this.ioA.TabIndex = 0;
            this.ioA.Text = "rtio1";
            this.ioA.title = "A";
            this.ioA.titleColor = System.Drawing.Color.DimGray;
            this.ioA.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioA.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioB
            // 
            this.ioB.contactBackColor = System.Drawing.Color.Black;
            this.ioB.contactColor = System.Drawing.Color.DimGray;
            this.ioB.Location = new System.Drawing.Point(0, 53);
            this.ioB.Name = "ioB";
            this.ioB.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB.showTitle = true;
            this.ioB.Size = new System.Drawing.Size(42, 20);
            this.ioB.TabIndex = 1;
            this.ioB.Text = "rtio1";
            this.ioB.title = "B";
            this.ioB.titleColor = System.Drawing.Color.DimGray;
            this.ioB.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioOut
            // 
            this.ioOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut.contactBackColor = System.Drawing.Color.Black;
            this.ioOut.contactColor = System.Drawing.Color.DimGray;
            this.ioOut.Location = new System.Drawing.Point(63, 27);
            this.ioOut.Name = "ioOut";
            this.ioOut.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut.showTitle = false;
            this.ioOut.Size = new System.Drawing.Size(21, 20);
            this.ioOut.TabIndex = 2;
            this.ioOut.Text = "rtio1";
            this.ioOut.title = "A";
            this.ioOut.titleColor = System.Drawing.Color.DimGray;
            this.ioOut.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOut.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // Compare
            // 
            this.canShrink = false;
            this.Controls.Add(this.ioOut);
            this.Controls.Add(this.ioB);
            this.Controls.Add(this.ioA);
            this.hasActiveSwitch = false;
            this.Name = "Compare";
            this.Size = new System.Drawing.Size(84, 80);
            this.title = "A>=B";
            this.ResumeLayout(false);

        }

        private RTIO ioA;
        private RTIO ioB;
        private RTIO ioOut;

        public enum CompareMode
        {
            A_larger_B,
            A_larger_equal_B,
            A_smaller_B,
            A_smaller_equal_B
        }
        CompareMode mode;

        private void init()
        {
            InitializeComponent();

            switch(mode)
            {
                case CompareMode.A_larger_B: title = "A>B"; break;
                case CompareMode.A_larger_equal_B: title = "A≥B"; break;
                case CompareMode.A_smaller_B: title = "A<B"; break;
                case CompareMode.A_smaller_equal_B: title = "A≤B"; break;
            }

            processingType = ProcessingType.Processor;
        }

        public Compare() : this(CompareMode.A_larger_B)
        {
        }

        public Compare(CompareMode _mode) : base()
        {
            mode = _mode;
            init();
        }

        public Compare(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            mode = (CompareMode)src.ReadInt32();
            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write((int)mode);
        }

        public override void tick()
        {
            SignalBuffer dbA = getSignalInputBuffer(ioA);
            SignalBuffer dbB = getSignalInputBuffer(ioB);
            SignalBuffer dbout = getSignalOutputBuffer(ioOut);

            if (dbout == null)
                return;

            if ((dbA == null) && (dbB == null))
            {
                if ((mode == CompareMode.A_larger_equal_B) || (mode == CompareMode.A_smaller_equal_B))
                    dbout.one();
                else
                    dbout.zero();
                return;
            }

            switch (mode)
            {
                case CompareMode.A_larger_B:
                    if (dbA == null)
                    {
                        for (int i = 0; i < owner.blockSize; i++)
                            dbout.data[i] = (0 > dbB.data[i]) ? 1 : -1;
                        return;
                    }
                    if (dbB == null)
                    {
                        for (int i = 0; i < owner.blockSize; i++)
                            dbout.data[i] = (dbA.data[i] > 0) ? 1 : -1;
                        return;
                    }
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = (dbA.data[i] > dbB.data[i]) ? 1 : -1;
                    return;
                case CompareMode.A_larger_equal_B:
                    if (dbA == null)
                    {
                        for (int i = 0; i < owner.blockSize; i++)
                            dbout.data[i] = (0 >= dbB.data[i]) ? 1 : -1;
                        return;
                    }
                    if (dbB == null)
                    {
                        for (int i = 0; i < owner.blockSize; i++)
                            dbout.data[i] = (dbA.data[i] >= 0) ? 1 : -1;
                        return;
                    }
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = (dbA.data[i] >= dbB.data[i]) ? 1 : -1;
                    return;
                case CompareMode.A_smaller_B:
                    if (dbA == null)
                    {
                        for (int i = 0; i < owner.blockSize; i++)
                            dbout.data[i] = (0 < dbB.data[i]) ? 1 : -1;
                        return;
                    }
                    if (dbB == null)
                    {
                        for (int i = 0; i < owner.blockSize; i++)
                            dbout.data[i] = (dbA.data[i] < 0) ? 1 : -1;
                        return;
                    }
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = (dbA.data[i] < dbB.data[i]) ? 1 : -1;
                    return;
                case CompareMode.A_smaller_equal_B:
                    if (dbA == null)
                    {
                        for (int i = 0; i < owner.blockSize; i++)
                            dbout.data[i] = (0 <= dbB.data[i]) ? 1 : -1;
                        return;
                    }
                    if (dbB == null)
                    {
                        for (int i = 0; i < owner.blockSize; i++)
                            dbout.data[i] = (dbA.data[i] <= 0) ? 1 : -1;
                        return;
                    }
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = (dbA.data[i] <= dbB.data[i]) ? 1 : -1;
                    return;
            }

        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Compare", "A > B" }; }
            public override RTForm Instantiate() { return new Compare(CompareMode.A_larger_B); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Compare", "A >= B" }; }
            public override RTForm Instantiate() { return new Compare(CompareMode.A_larger_equal_B); }
        }
        class RegisterClass3 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Compare", "A < B" }; }
            public override RTForm Instantiate() { return new Compare(CompareMode.A_smaller_B); }
        }
        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Compare", "A <= B" }; }
            public override RTForm Instantiate() { return new Compare(CompareMode.A_smaller_equal_B); }
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
