using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.Processing
{
    public class BooleanOP : RTForm
    {

        public void InitializeComponent()
        {
            this.io1 = new AudioProcessor.RTIO();
            this.io2 = new AudioProcessor.RTIO();
            this.io3 = new AudioProcessor.RTIO();
            this.io4 = new AudioProcessor.RTIO();
            this.ioOut = new AudioProcessor.RTIO();
            this.SuspendLayout();
            // 
            // io1
            // 
            this.io1.contactBackColor = System.Drawing.Color.Black;
            this.io1.contactColor = System.Drawing.Color.DimGray;
            this.io1.Location = new System.Drawing.Point(0, 27);
            this.io1.Name = "io1";
            this.io1.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io1.showTitle = false;
            this.io1.Size = new System.Drawing.Size(21, 20);
            this.io1.TabIndex = 0;
            this.io1.Text = "rtio1";
            this.io1.title = "IO";
            this.io1.titleColor = System.Drawing.Color.DimGray;
            this.io1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io1.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // io2
            // 
            this.io2.contactBackColor = System.Drawing.Color.Black;
            this.io2.contactColor = System.Drawing.Color.DimGray;
            this.io2.Location = new System.Drawing.Point(0, 53);
            this.io2.Name = "io2";
            this.io2.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io2.showTitle = false;
            this.io2.Size = new System.Drawing.Size(21, 20);
            this.io2.TabIndex = 1;
            this.io2.Text = "rtio2";
            this.io2.title = "IO";
            this.io2.titleColor = System.Drawing.Color.DimGray;
            this.io2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io2.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // io3
            // 
            this.io3.contactBackColor = System.Drawing.Color.Black;
            this.io3.contactColor = System.Drawing.Color.DimGray;
            this.io3.Location = new System.Drawing.Point(0, 79);
            this.io3.Name = "io3";
            this.io3.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io3.showTitle = false;
            this.io3.Size = new System.Drawing.Size(21, 20);
            this.io3.TabIndex = 2;
            this.io3.Text = "rtio3";
            this.io3.title = "IO";
            this.io3.titleColor = System.Drawing.Color.DimGray;
            this.io3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io3.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // io4
            // 
            this.io4.contactBackColor = System.Drawing.Color.Black;
            this.io4.contactColor = System.Drawing.Color.DimGray;
            this.io4.Location = new System.Drawing.Point(0, 105);
            this.io4.Name = "io4";
            this.io4.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io4.showTitle = false;
            this.io4.Size = new System.Drawing.Size(21, 20);
            this.io4.TabIndex = 3;
            this.io4.Text = "rtio4";
            this.io4.title = "IO";
            this.io4.titleColor = System.Drawing.Color.DimGray;
            this.io4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io4.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioOut
            // 
            this.ioOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut.contactBackColor = System.Drawing.Color.Black;
            this.ioOut.contactColor = System.Drawing.Color.DimGray;
            this.ioOut.Location = new System.Drawing.Point(64, 27);
            this.ioOut.Name = "ioOut";
            this.ioOut.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut.showTitle = false;
            this.ioOut.Size = new System.Drawing.Size(21, 20);
            this.ioOut.TabIndex = 4;
            this.ioOut.Text = "rtio5";
            this.ioOut.title = "IO";
            this.ioOut.titleColor = System.Drawing.Color.DimGray;
            this.ioOut.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOut.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // BooleanOP
            // 
            this.canShrink = false;
            this.Controls.Add(this.ioOut);
            this.Controls.Add(this.io4);
            this.Controls.Add(this.io3);
            this.Controls.Add(this.io2);
            this.Controls.Add(this.io1);
            this.hasActiveSwitch = false;
            this.Name = "BooleanOP";
            this.Size = new System.Drawing.Size(85, 132);
            this.title = "XNOR";
            this.ResumeLayout(false);

        }

        int channels;

        public enum BooleanMode
        {
            And,
            Or,
            Xor,
            Nand,
            Nor,
            XNor,
            Not
        }
        BooleanMode booleanOp;

        bool[,] inputs;
        private RTIO io1;
        private RTIO io2;
        private RTIO io3;
        private RTIO io4;
        private RTIO ioOut;
        bool[] outputs;

        private void init()
        {
            InitializeComponent();

            int h = Height;
            if (channels < 4) { io4.Hide(); h = io4.Location.Y; }
            if (channels < 3) { io3.Hide(); h = io3.Location.Y; }
            if (channels < 2) { io2.Hide(); h = io2.Location.Y; }
            Height = h;

            switch (booleanOp)
            {
                case BooleanMode.And: title = "AND"; break;
                case BooleanMode.Or: title = "OR"; break;
                case BooleanMode.Xor: title = "XOR"; break;
                case BooleanMode.Nand: title = "NAND"; break;
                case BooleanMode.Nor: title = "NOR"; break;
                case BooleanMode.XNor: title = "XNOR"; break;
                case BooleanMode.Not: title = "NOT"; break;
            }

            processingType = ProcessingType.Processor;
        }

        public BooleanOP(): this(BooleanMode.And,4)
        {
        }

        public BooleanOP(BooleanMode _booleanOp, int _channels) : base()
        {
            booleanOp = _booleanOp;
            channels = _channels;
            init();
        }

        public BooleanOP(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            channels = src.ReadInt32();
            booleanOp = (BooleanMode)src.ReadInt32();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(channels);
            tgt.Write((int)booleanOp);
        }

        public override void tick()
        {
            SignalBuffer dbout = getSignalOutputBuffer(ioOut);
            if (dbout == null)
                return;
            SignalBuffer[] dbin = new SignalBuffer[channels];
            if (channels >= 1) dbin[0] = getSignalInputBuffer(io1);
            if (channels >= 2) dbin[1] = getSignalInputBuffer(io2);
            if (channels >= 3) dbin[2] = getSignalInputBuffer(io3);
            if (channels >= 4) dbin[3] = getSignalInputBuffer(io4);

            if (inputs == null)
                inputs = new bool[channels,owner.blockSize];
            if (outputs == null)
                outputs = new bool[owner.blockSize];

            for (int i=0;i<channels;i++)
            {
                if (dbin[i] == null)
                    for (int j = 0; j < owner.blockSize; j++)
                        inputs[i, j] = false;
                else
                    for (int j = 0; j < owner.blockSize; j++)
                        inputs[i, j] = dbin[i].data[j] > 0.0;
            }

            switch (booleanOp)
            {
                case BooleanMode.And:
                    for (int i = 0; i < owner.blockSize; i++)
                    {
                        bool erg = inputs[0, i];
                        for (int j = 1; j < channels; j++)
                            erg &= inputs[j, i];
                        outputs[i] = erg;
                    }
                    break;
                case BooleanMode.Or:
                    for (int i = 0; i < owner.blockSize; i++)
                    {
                        bool erg = inputs[0, i];
                        for (int j = 1; j < channels; j++)
                            erg |= inputs[j, i];
                        outputs[i] = erg;
                    }
                    break;
                case BooleanMode.Xor:
                    for (int i = 0; i < owner.blockSize; i++)
                    {
                        bool erg = inputs[0, i];
                        for (int j = 1; j < channels; j++)
                            erg ^= inputs[j, i];
                        outputs[i] = erg;
                    }
                    break;
                case BooleanMode.Not:
                case BooleanMode.Nand:
                    for (int i = 0; i < owner.blockSize; i++)
                    {
                        bool erg = inputs[0, i];
                        for (int j = 1; j < channels; j++)
                            erg &= inputs[j, i];
                        outputs[i] = ! erg;
                    }
                    break;
                case BooleanMode.Nor:
                    for (int i = 0; i < owner.blockSize; i++)
                    {
                        bool erg = inputs[0, i];
                        for (int j = 1; j < channels; j++)
                            erg |= inputs[j, i];
                        outputs[i] = ! erg;
                    }
                    break;
                case BooleanMode.XNor:
                    for (int i = 0; i < owner.blockSize; i++)
                    {
                        bool erg = inputs[0, i];
                        for (int j = 1; j < channels; j++)
                            erg ^= inputs[j, i];
                        outputs[i] = !erg;
                    }
                    break;
            }
            for (int i = 0; i < owner.blockSize; i++)
                dbout.data[i] = (outputs[i]) ? 1.0 : -1.0;
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Logic", "AND", "2 x" }; }
            public override RTForm Instantiate() { return new BooleanOP(BooleanMode.And, 2); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Logic", "AND", "3 x" }; }
            public override RTForm Instantiate() { return new BooleanOP(BooleanMode.And, 3); }
        }
        class RegisterClass3 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Logic", "AND", "4 x" }; }
            public override RTForm Instantiate() { return new BooleanOP(BooleanMode.And, 4); }
        }
        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Logic", "OR", "2 x" }; }
            public override RTForm Instantiate() { return new BooleanOP(BooleanMode.Or, 2); }
        }
        class RegisterClass5 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Logic", "OR", "3 x" }; }
            public override RTForm Instantiate() { return new BooleanOP(BooleanMode.Or, 3); }
        }
        class RegisterClass6 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Logic", "OR", "4 x" }; }
            public override RTForm Instantiate() { return new BooleanOP(BooleanMode.Or, 4); }
        }
        class RegisterClass7 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Logic", "XOR", "2 x" }; }
            public override RTForm Instantiate() { return new BooleanOP(BooleanMode.Xor, 2); }
        }
        class RegisterClass8 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Logic", "XOR", "3 x" }; }
            public override RTForm Instantiate() { return new BooleanOP(BooleanMode.Xor, 3); }
        }
        class RegisterClass9 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Logic", "XOR", "4 x" }; }
            public override RTForm Instantiate() { return new BooleanOP(BooleanMode.Xor, 4); }
        }

        class RegisterClass10 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Logic", "NAND", "2 x" }; }
            public override RTForm Instantiate() { return new BooleanOP(BooleanMode.Nand, 2); }
        }
        class RegisterClass11 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Logic", "NAND", "3 x" }; }
            public override RTForm Instantiate() { return new BooleanOP(BooleanMode.Nand, 3); }
        }
        class RegisterClass12 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Logic", "NAND", "4 x" }; }
            public override RTForm Instantiate() { return new BooleanOP(BooleanMode.Nand, 4); }
        }
        class RegisterClass13 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Logic", "NOR", "2 x" }; }
            public override RTForm Instantiate() { return new BooleanOP(BooleanMode.Nor, 2); }
        }
        class RegisterClass14 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Logic", "NOR", "3 x" }; }
            public override RTForm Instantiate() { return new BooleanOP(BooleanMode.Nor, 3); }
        }
        class RegisterClass15 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Logic", "NOR", "4 x" }; }
            public override RTForm Instantiate() { return new BooleanOP(BooleanMode.Nor, 4); }
        }
        class RegisterClass16 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Logic", "XNOR", "2 x" }; }
            public override RTForm Instantiate() { return new BooleanOP(BooleanMode.XNor, 2); }
        }
        class RegisterClass17 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Logic", "XNOR", "3 x" }; }
            public override RTForm Instantiate() { return new BooleanOP(BooleanMode.XNor, 3); }
        }
        class RegisterClass18 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Logic", "XNOR", "4 x" }; }
            public override RTForm Instantiate() { return new BooleanOP(BooleanMode.XNor, 4); }
        }

        class RegisterClass19 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Logic", "NOT" }; }
            public override RTForm Instantiate() { return new BooleanOP(BooleanMode.Not, 1); }
        }



        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
            l.Add(new RegisterClass2());
            l.Add(new RegisterClass3());
            l.Add(new RegisterClass4());
            l.Add(new RegisterClass5());
            l.Add(new RegisterClass6());
            l.Add(new RegisterClass7());
            l.Add(new RegisterClass8());
            l.Add(new RegisterClass9());
            l.Add(new RegisterClass10());
            l.Add(new RegisterClass11());
            l.Add(new RegisterClass12());
            l.Add(new RegisterClass13());
            l.Add(new RegisterClass14());
            l.Add(new RegisterClass15());
            l.Add(new RegisterClass16());
            l.Add(new RegisterClass17());
            l.Add(new RegisterClass18());
            l.Add(new RegisterClass19());
        }

    }
}
