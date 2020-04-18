using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.Processing
{
    public class Unary : RTForm
    {
        public void InitializeComponent()
        {
            this.ioO8 = new AudioProcessor.RTIO();
            this.ioO7 = new AudioProcessor.RTIO();
            this.ioO6 = new AudioProcessor.RTIO();
            this.ioO5 = new AudioProcessor.RTIO();
            this.ioO4 = new AudioProcessor.RTIO();
            this.ioO3 = new AudioProcessor.RTIO();
            this.ioO2 = new AudioProcessor.RTIO();
            this.ioO1 = new AudioProcessor.RTIO();
            this.ioI8 = new AudioProcessor.RTIO();
            this.ioI7 = new AudioProcessor.RTIO();
            this.ioI6 = new AudioProcessor.RTIO();
            this.ioI5 = new AudioProcessor.RTIO();
            this.ioI4 = new AudioProcessor.RTIO();
            this.ioI3 = new AudioProcessor.RTIO();
            this.ioI2 = new AudioProcessor.RTIO();
            this.ioI1 = new AudioProcessor.RTIO();
            this.SuspendLayout();
            // 
            // ioO8
            // 
            this.ioO8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO8.contactBackColor = System.Drawing.Color.Black;
            this.ioO8.contactColor = System.Drawing.Color.DimGray;
            this.ioO8.Location = new System.Drawing.Point(84, 210);
            this.ioO8.Name = "ioO8";
            this.ioO8.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO8.showTitle = true;
            this.ioO8.Size = new System.Drawing.Size(35, 20);
            this.ioO8.TabIndex = 44;
            this.ioO8.Text = "rtio1";
            this.ioO8.title = "8";
            this.ioO8.titleColor = System.Drawing.Color.DimGray;
            this.ioO8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO8.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioO7
            // 
            this.ioO7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO7.contactBackColor = System.Drawing.Color.Black;
            this.ioO7.contactColor = System.Drawing.Color.DimGray;
            this.ioO7.Location = new System.Drawing.Point(84, 184);
            this.ioO7.Name = "ioO7";
            this.ioO7.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO7.showTitle = true;
            this.ioO7.Size = new System.Drawing.Size(35, 20);
            this.ioO7.TabIndex = 43;
            this.ioO7.Text = "rtio1";
            this.ioO7.title = "7";
            this.ioO7.titleColor = System.Drawing.Color.DimGray;
            this.ioO7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO7.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioO6
            // 
            this.ioO6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO6.contactBackColor = System.Drawing.Color.Black;
            this.ioO6.contactColor = System.Drawing.Color.DimGray;
            this.ioO6.Location = new System.Drawing.Point(84, 158);
            this.ioO6.Name = "ioO6";
            this.ioO6.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO6.showTitle = true;
            this.ioO6.Size = new System.Drawing.Size(35, 20);
            this.ioO6.TabIndex = 42;
            this.ioO6.Text = "rtio1";
            this.ioO6.title = "6";
            this.ioO6.titleColor = System.Drawing.Color.DimGray;
            this.ioO6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO6.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioO5
            // 
            this.ioO5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO5.contactBackColor = System.Drawing.Color.Black;
            this.ioO5.contactColor = System.Drawing.Color.DimGray;
            this.ioO5.Location = new System.Drawing.Point(84, 132);
            this.ioO5.Name = "ioO5";
            this.ioO5.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO5.showTitle = true;
            this.ioO5.Size = new System.Drawing.Size(35, 20);
            this.ioO5.TabIndex = 41;
            this.ioO5.Text = "rtio1";
            this.ioO5.title = "5";
            this.ioO5.titleColor = System.Drawing.Color.DimGray;
            this.ioO5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO5.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioO4
            // 
            this.ioO4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO4.contactBackColor = System.Drawing.Color.Black;
            this.ioO4.contactColor = System.Drawing.Color.DimGray;
            this.ioO4.Location = new System.Drawing.Point(84, 106);
            this.ioO4.Name = "ioO4";
            this.ioO4.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO4.showTitle = true;
            this.ioO4.Size = new System.Drawing.Size(35, 20);
            this.ioO4.TabIndex = 40;
            this.ioO4.Text = "rtio1";
            this.ioO4.title = "4";
            this.ioO4.titleColor = System.Drawing.Color.DimGray;
            this.ioO4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO4.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioO3
            // 
            this.ioO3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO3.contactBackColor = System.Drawing.Color.Black;
            this.ioO3.contactColor = System.Drawing.Color.DimGray;
            this.ioO3.Location = new System.Drawing.Point(84, 80);
            this.ioO3.Name = "ioO3";
            this.ioO3.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO3.showTitle = true;
            this.ioO3.Size = new System.Drawing.Size(35, 20);
            this.ioO3.TabIndex = 39;
            this.ioO3.Text = "rtio1";
            this.ioO3.title = "3";
            this.ioO3.titleColor = System.Drawing.Color.DimGray;
            this.ioO3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO3.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioO2
            // 
            this.ioO2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO2.contactBackColor = System.Drawing.Color.Black;
            this.ioO2.contactColor = System.Drawing.Color.DimGray;
            this.ioO2.Location = new System.Drawing.Point(84, 54);
            this.ioO2.Name = "ioO2";
            this.ioO2.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO2.showTitle = true;
            this.ioO2.Size = new System.Drawing.Size(35, 20);
            this.ioO2.TabIndex = 38;
            this.ioO2.Text = "rtio14";
            this.ioO2.title = "2";
            this.ioO2.titleColor = System.Drawing.Color.DimGray;
            this.ioO2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO2.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioO1
            // 
            this.ioO1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO1.contactBackColor = System.Drawing.Color.Black;
            this.ioO1.contactColor = System.Drawing.Color.DimGray;
            this.ioO1.Location = new System.Drawing.Point(84, 28);
            this.ioO1.Name = "ioO1";
            this.ioO1.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO1.showTitle = true;
            this.ioO1.Size = new System.Drawing.Size(35, 20);
            this.ioO1.TabIndex = 37;
            this.ioO1.Text = "rtio1";
            this.ioO1.title = "1";
            this.ioO1.titleColor = System.Drawing.Color.DimGray;
            this.ioO1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO1.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioI8
            // 
            this.ioI8.contactBackColor = System.Drawing.Color.Black;
            this.ioI8.contactColor = System.Drawing.Color.DimGray;
            this.ioI8.Location = new System.Drawing.Point(0, 210);
            this.ioI8.Name = "ioI8";
            this.ioI8.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI8.showTitle = true;
            this.ioI8.Size = new System.Drawing.Size(35, 20);
            this.ioI8.TabIndex = 36;
            this.ioI8.Text = "rtio1";
            this.ioI8.title = "8";
            this.ioI8.titleColor = System.Drawing.Color.DimGray;
            this.ioI8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI8.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioI7
            // 
            this.ioI7.contactBackColor = System.Drawing.Color.Black;
            this.ioI7.contactColor = System.Drawing.Color.DimGray;
            this.ioI7.Location = new System.Drawing.Point(0, 184);
            this.ioI7.Name = "ioI7";
            this.ioI7.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI7.showTitle = true;
            this.ioI7.Size = new System.Drawing.Size(35, 20);
            this.ioI7.TabIndex = 35;
            this.ioI7.Text = "rtio1";
            this.ioI7.title = "7";
            this.ioI7.titleColor = System.Drawing.Color.DimGray;
            this.ioI7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI7.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioI6
            // 
            this.ioI6.contactBackColor = System.Drawing.Color.Black;
            this.ioI6.contactColor = System.Drawing.Color.DimGray;
            this.ioI6.Location = new System.Drawing.Point(0, 158);
            this.ioI6.Name = "ioI6";
            this.ioI6.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI6.showTitle = true;
            this.ioI6.Size = new System.Drawing.Size(35, 20);
            this.ioI6.TabIndex = 34;
            this.ioI6.Text = "rtio1";
            this.ioI6.title = "6";
            this.ioI6.titleColor = System.Drawing.Color.DimGray;
            this.ioI6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI6.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioI5
            // 
            this.ioI5.contactBackColor = System.Drawing.Color.Black;
            this.ioI5.contactColor = System.Drawing.Color.DimGray;
            this.ioI5.Location = new System.Drawing.Point(0, 132);
            this.ioI5.Name = "ioI5";
            this.ioI5.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI5.showTitle = true;
            this.ioI5.Size = new System.Drawing.Size(35, 20);
            this.ioI5.TabIndex = 33;
            this.ioI5.Text = "rtio1";
            this.ioI5.title = "5";
            this.ioI5.titleColor = System.Drawing.Color.DimGray;
            this.ioI5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI5.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioI4
            // 
            this.ioI4.contactBackColor = System.Drawing.Color.Black;
            this.ioI4.contactColor = System.Drawing.Color.DimGray;
            this.ioI4.Location = new System.Drawing.Point(0, 106);
            this.ioI4.Name = "ioI4";
            this.ioI4.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI4.showTitle = true;
            this.ioI4.Size = new System.Drawing.Size(35, 20);
            this.ioI4.TabIndex = 32;
            this.ioI4.Text = "rtio1";
            this.ioI4.title = "4";
            this.ioI4.titleColor = System.Drawing.Color.DimGray;
            this.ioI4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI4.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioI3
            // 
            this.ioI3.contactBackColor = System.Drawing.Color.Black;
            this.ioI3.contactColor = System.Drawing.Color.DimGray;
            this.ioI3.Location = new System.Drawing.Point(0, 80);
            this.ioI3.Name = "ioI3";
            this.ioI3.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI3.showTitle = true;
            this.ioI3.Size = new System.Drawing.Size(35, 20);
            this.ioI3.TabIndex = 31;
            this.ioI3.Text = "rtio1";
            this.ioI3.title = "3";
            this.ioI3.titleColor = System.Drawing.Color.DimGray;
            this.ioI3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI3.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioI2
            // 
            this.ioI2.contactBackColor = System.Drawing.Color.Black;
            this.ioI2.contactColor = System.Drawing.Color.DimGray;
            this.ioI2.Location = new System.Drawing.Point(0, 54);
            this.ioI2.Name = "ioI2";
            this.ioI2.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI2.showTitle = true;
            this.ioI2.Size = new System.Drawing.Size(35, 20);
            this.ioI2.TabIndex = 30;
            this.ioI2.Text = "rtio1";
            this.ioI2.title = "2";
            this.ioI2.titleColor = System.Drawing.Color.DimGray;
            this.ioI2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI2.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioI1
            // 
            this.ioI1.contactBackColor = System.Drawing.Color.Black;
            this.ioI1.contactColor = System.Drawing.Color.DimGray;
            this.ioI1.Location = new System.Drawing.Point(0, 28);
            this.ioI1.Name = "ioI1";
            this.ioI1.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI1.showTitle = true;
            this.ioI1.Size = new System.Drawing.Size(35, 20);
            this.ioI1.TabIndex = 28;
            this.ioI1.Text = "rtio1";
            this.ioI1.title = "1";
            this.ioI1.titleColor = System.Drawing.Color.DimGray;
            this.ioI1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI1.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // Unary
            // 
            this.canShrink = false;
            this.Controls.Add(this.ioO8);
            this.Controls.Add(this.ioO7);
            this.Controls.Add(this.ioO6);
            this.Controls.Add(this.ioO5);
            this.Controls.Add(this.ioO4);
            this.Controls.Add(this.ioO3);
            this.Controls.Add(this.ioO2);
            this.Controls.Add(this.ioO1);
            this.Controls.Add(this.ioI8);
            this.Controls.Add(this.ioI7);
            this.Controls.Add(this.ioI6);
            this.Controls.Add(this.ioI5);
            this.Controls.Add(this.ioI4);
            this.Controls.Add(this.ioI3);
            this.Controls.Add(this.ioI2);
            this.Controls.Add(this.ioI1);
            this.hasActiveSwitch = false;
            this.Name = "Unary";
            this.Size = new System.Drawing.Size(119, 237);
            this.ResumeLayout(false);

        }

        int inputs;

        public enum Operation {
            Sqr,
            Cube,
            Quad,
            Sqrt,
            Sq3,
            Abs,
            NAbs,
            Inv,
            Sign,
            Pos,
            PosZ,
            Neg,
            NegZ,
            Sin,
            Cos
        }
        public static readonly string[] OperationNames = {
            "x²", "x³", "x^4", "sqrt(x)", "x^(1/3)","|x|", "-|x|", "-x,", "sign(x)", "x>0", "x>=0", "x<0", "x<=0", "sin(x)","cos(x)" };
        private RTIO ioO8;
        private RTIO ioO7;
        private RTIO ioO6;
        private RTIO ioO5;
        private RTIO ioO4;
        private RTIO ioO3;
        private RTIO ioO2;
        private RTIO ioO1;
        private RTIO ioI8;
        private RTIO ioI7;
        private RTIO ioI6;
        private RTIO ioI5;
        private RTIO ioI4;
        private RTIO ioI3;
        private RTIO ioI2;
        private RTIO ioI1;
        Operation op;

        private void init()
        {
            InitializeComponent();

            title = OperationNames[(int)op];

            int h = Height;
            if (inputs < 8) { ioI8.Hide(); ioO8.Hide(); h = ioO8.Location.Y; }
            if (inputs < 7) { ioI7.Hide(); ioO7.Hide(); h = ioO7.Location.Y; }
            if (inputs < 6) { ioI6.Hide(); ioO6.Hide(); h = ioO6.Location.Y; }
            if (inputs < 5) { ioI5.Hide(); ioO5.Hide(); h = ioO5.Location.Y; }
            if (inputs < 4) { ioI4.Hide(); ioO4.Hide(); h = ioO4.Location.Y; }
            if (inputs < 3) { ioI3.Hide(); ioO3.Hide(); h = ioO3.Location.Y; }
            if (inputs < 2) { ioI2.Hide(); ioO2.Hide(); h = ioO2.Location.Y; }
            Height = h;

            processingType = ProcessingType.Processor;
        }

        public Unary(): this(8, Operation.Abs)
        {
        }

        public Unary(int _inputs, Operation _op):base()
            {
            inputs = _inputs;
            op = _op;
            init();
        }

        public Unary(SystemPanel _owner, BinaryReader src):base(_owner,src)
            {
            inputs = src.ReadInt32();
            op = (Operation)src.ReadInt32();
            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(inputs);
            tgt.Write((int)op);
        }

        private void processChannel(DataBuffer dbin, DataBuffer dbout)
        {
            if ((dbin == null) || (dbout == null))
                return;
            switch (op)
            {
                case Operation.Abs:
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = Math.Abs(dbin.data[i]);
                    break;
                case Operation.Cube:
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = dbin.data[i] * dbin.data[i] * dbin.data[i];
                    break;
                case Operation.Inv:
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = -dbin.data[i];
                    break;
                case Operation.NAbs:
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = -Math.Abs(dbin.data[i]);
                    break;
                case Operation.Neg:
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = (dbin.data[i] < 0) ? 1.0 : 0.0;
                    break;
                case Operation.NegZ:
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = (dbin.data[i] <= 0) ? 1.0 : 0.0;
                    break;
                case Operation.Pos:
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = (dbin.data[i] > 0) ? 1.0 : 0.0;
                    break;
                case Operation.PosZ:
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = (dbin.data[i] >= 0) ? 1.0 : 0.0;
                    break;
                case Operation.Quad:
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = dbin.data[i] * dbin.data[i] * dbin.data[i] * dbin.data[i];
                    break;
                case Operation.Sign:
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = (dbin.data[i] >= 0) ? 1.0 : 0.0;
                    break;
                case Operation.Sq3:
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = (dbin.data[i] < 0) ? -Math.Pow(-dbin.data[i], 1.0 / 3.0) : Math.Pow(dbin.data[i], 1.0 / 3.0);
                    break;
                case Operation.Sqr:
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = dbin.data[i] * dbin.data[i];
                    break;
                case Operation.Sqrt:
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = (dbin.data[i] < 0) ? 0 : Math.Sqrt(dbin.data[i]);
                    break;
                case Operation.Sin:
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = Math.Sin(dbin.data[i]);
                    break;
                case Operation.Cos:
                    for (int i = 0; i < owner.blockSize; i++)
                        dbout.data[i] = Math.Cos(dbin.data[i]);
                    break;
            }
        }

        public override void tick()
        {
            if (inputs >= 1) processChannel(getInputBuffer(ioI1), getOutputBuffer(ioO1));
            if (inputs >= 2) processChannel(getInputBuffer(ioI2), getOutputBuffer(ioO2));
            if (inputs >= 3) processChannel(getInputBuffer(ioI3), getOutputBuffer(ioO3));
            if (inputs >= 4) processChannel(getInputBuffer(ioI4), getOutputBuffer(ioO4));
            if (inputs >= 5) processChannel(getInputBuffer(ioI5), getOutputBuffer(ioO5));
            if (inputs >= 6) processChannel(getInputBuffer(ioI6), getOutputBuffer(ioO6));
            if (inputs >= 7) processChannel(getInputBuffer(ioI7), getOutputBuffer(ioO7));
            if (inputs >= 8) processChannel(getInputBuffer(ioI8), getOutputBuffer(ioO8));
        }

        class RegisterClass10 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x²", "1x" }; }
            public override RTForm Instantiate() { return new Unary(1, Operation.Sqr); }
        }
        class RegisterClass11 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x²", "2x" }; }
            public override RTForm Instantiate() { return new Unary(2, Operation.Sqr); }
        }
        class RegisterClass12 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x²", "4x" }; }
            public override RTForm Instantiate() { return new Unary(4, Operation.Sqr); }
        }
        class RegisterClass13 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x²", "8x" }; }
            public override RTForm Instantiate() { return new Unary(8, Operation.Sqr); }
        }

        class RegisterClass20 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x³", "1x" }; }
            public override RTForm Instantiate() { return new Unary(1, Operation.Cube); }
        }
        class RegisterClass21 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x³", "2x" }; }
            public override RTForm Instantiate() { return new Unary(2, Operation.Cube); }
        }
        class RegisterClass22 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x³", "4x" }; }
            public override RTForm Instantiate() { return new Unary(4, Operation.Cube); }
        }
        class RegisterClass23 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x³", "8x" }; }
            public override RTForm Instantiate() { return new Unary(8, Operation.Cube); }
        }

        class RegisterClass30 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x^4", "1x" }; }
            public override RTForm Instantiate() { return new Unary(1, Operation.Quad); }
        }
        class RegisterClass31 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x^4", "2x" }; }
            public override RTForm Instantiate() { return new Unary(2, Operation.Quad); }
        }
        class RegisterClass32 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x^4", "4x" }; }
            public override RTForm Instantiate() { return new Unary(4, Operation.Quad); }
        }
        class RegisterClass33 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x^4", "8x" }; }
            public override RTForm Instantiate() { return new Unary(8, Operation.Quad); }
        }

        class RegisterClass40 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "sqrt(x)", "1x" }; }
            public override RTForm Instantiate() { return new Unary(1, Operation.Sqrt); }
        }
        class RegisterClass41 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "sqrt(x)", "2x" }; }
            public override RTForm Instantiate() { return new Unary(2, Operation.Sqrt); }
        }
        class RegisterClass42 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "sqrt(x)", "4x" }; }
            public override RTForm Instantiate() { return new Unary(4, Operation.Sqrt); }
        }
        class RegisterClass43 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "sqrt(x)", "8x" }; }
            public override RTForm Instantiate() { return new Unary(8, Operation.Sqrt); }
        }

        class RegisterClass50 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "sq3(x)", "1x" }; }
            public override RTForm Instantiate() { return new Unary(1, Operation.Sq3); }
        }
        class RegisterClass51 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "sq3(x)", "2x" }; }
            public override RTForm Instantiate() { return new Unary(2, Operation.Sq3); }
        }
        class RegisterClass52 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "sq3(x)", "4x" }; }
            public override RTForm Instantiate() { return new Unary(4, Operation.Sq3); }
        }
        class RegisterClass53 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "sq3(x)", "8x" }; }
            public override RTForm Instantiate() { return new Unary(8, Operation.Sq3); }
        }
        

        class RegisterClass60 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "|x|", "1x" }; }
            public override RTForm Instantiate() { return new Unary(1, Operation.Abs); }
        }
        class RegisterClass61 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "|x|", "2x" }; }
            public override RTForm Instantiate() { return new Unary(2, Operation.Abs); }
        }
        class RegisterClass62 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "|x|", "4x" }; }
            public override RTForm Instantiate() { return new Unary(4, Operation.Abs); }
        }
        class RegisterClass63 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "|x|", "8x" }; }
            public override RTForm Instantiate() { return new Unary(8, Operation.Abs); }
        }

        class RegisterClass70 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "-|x|", "1x" }; }
            public override RTForm Instantiate() { return new Unary(1, Operation.NAbs); }
        }
        class RegisterClass71 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "-|x|", "2x" }; }
            public override RTForm Instantiate() { return new Unary(2, Operation.NAbs); }
        }
        class RegisterClass72 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "-|x|", "4x" }; }
            public override RTForm Instantiate() { return new Unary(4, Operation.NAbs); }
        }
        class RegisterClass73 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "-|x|", "8x" }; }
            public override RTForm Instantiate() { return new Unary(8, Operation.NAbs); }
        }

        class RegisterClass80 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "-x", "1x" }; }
            public override RTForm Instantiate() { return new Unary(1, Operation.Inv); }
        }
        class RegisterClass81 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "-x", "2x" }; }
            public override RTForm Instantiate() { return new Unary(2, Operation.Inv); }
        }
        class RegisterClass82 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "-x", "4x" }; }
            public override RTForm Instantiate() { return new Unary(4, Operation.Inv); }
        }
        class RegisterClass83 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "-x", "8x" }; }
            public override RTForm Instantiate() { return new Unary(8, Operation.Inv); }
        }

        class RegisterClass90 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "sign(x)", "1x" }; }
            public override RTForm Instantiate() { return new Unary(1, Operation.Sign); }
        }
        class RegisterClass91 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "sign(x)", "2x" }; }
            public override RTForm Instantiate() { return new Unary(2, Operation.Sign); }
        }
        class RegisterClass92 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "sign(x)", "4x" }; }
            public override RTForm Instantiate() { return new Unary(4, Operation.Sign); }
        }
        class RegisterClass93 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "sign(x)", "8x" }; }
            public override RTForm Instantiate() { return new Unary(8, Operation.Sign); }
        }

        class RegisterClass100 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x>0", "1x" }; }
            public override RTForm Instantiate() { return new Unary(1, Operation.Pos); }
        }
        class RegisterClass101 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x>0", "2x" }; }
            public override RTForm Instantiate() { return new Unary(2, Operation.Pos); }
        }
        class RegisterClass102 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x>0", "4x" }; }
            public override RTForm Instantiate() { return new Unary(4, Operation.Pos); }
        }
        class RegisterClass103 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x>0", "8x" }; }
            public override RTForm Instantiate() { return new Unary(8, Operation.Pos); }
        }

        class RegisterClass110 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x>=0", "1x" }; }
            public override RTForm Instantiate() { return new Unary(1, Operation.PosZ); }
        }
        class RegisterClass111 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x>=0", "2x" }; }
            public override RTForm Instantiate() { return new Unary(2, Operation.PosZ); }
        }
        class RegisterClass112 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x>=0", "4x" }; }
            public override RTForm Instantiate() { return new Unary(4, Operation.PosZ); }
        }
        class RegisterClass113 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x>=0", "8x" }; }
            public override RTForm Instantiate() { return new Unary(8, Operation.PosZ); }
        }

        class RegisterClass120 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x<0", "1x" }; }
            public override RTForm Instantiate() { return new Unary(1, Operation.Neg); }
        }
        class RegisterClass121 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x<0", "2x" }; }
            public override RTForm Instantiate() { return new Unary(2, Operation.Neg); }
        }
        class RegisterClass122 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x<0", "4x" }; }
            public override RTForm Instantiate() { return new Unary(4, Operation.Neg); }
        }
        class RegisterClass123 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x<0", "8x" }; }
            public override RTForm Instantiate() { return new Unary(8, Operation.Neg); }
        }

        class RegisterClass130 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x<=0", "1x" }; }
            public override RTForm Instantiate() { return new Unary(1, Operation.NegZ); }
        }
        class RegisterClass131 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x<=0", "2x" }; }
            public override RTForm Instantiate() { return new Unary(2, Operation.NegZ); }
        }
        class RegisterClass132 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x<=0", "4x" }; }
            public override RTForm Instantiate() { return new Unary(4, Operation.NegZ); }
        }
        class RegisterClass133 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "x<=0", "8x" }; }
            public override RTForm Instantiate() { return new Unary(8, Operation.NegZ); }
        }

        class RegisterClass140 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "sin(x)", "1x" }; }
            public override RTForm Instantiate() { return new Unary(1, Operation.Sin); }
        }
        class RegisterClass141 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "sin(x)", "2x" }; }
            public override RTForm Instantiate() { return new Unary(2, Operation.Sin); }
        }
        class RegisterClass142 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "sin(x)", "4x" }; }
            public override RTForm Instantiate() { return new Unary(4, Operation.Sin); }
        }
        class RegisterClass143 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "sin(x)", "8x" }; }
            public override RTForm Instantiate() { return new Unary(8, Operation.Sin); }
        }

        class RegisterClass150 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "cos(x)", "1x" }; }
            public override RTForm Instantiate() { return new Unary(1, Operation.Cos); }
        }
        class RegisterClass151 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "cos(x)", "2x" }; }
            public override RTForm Instantiate() { return new Unary(2, Operation.Cos); }
        }
        class RegisterClass152 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "cos(x)", "4x" }; }
            public override RTForm Instantiate() { return new Unary(4, Operation.Cos); }
        }
        class RegisterClass153 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "cos(x)", "8x" }; }
            public override RTForm Instantiate() { return new Unary(8, Operation.Cos); }
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
            l.Add(new RegisterClass110()); l.Add(new RegisterClass111()); l.Add(new RegisterClass112()); l.Add(new RegisterClass113());
            l.Add(new RegisterClass120()); l.Add(new RegisterClass121()); l.Add(new RegisterClass122()); l.Add(new RegisterClass123());
            l.Add(new RegisterClass130()); l.Add(new RegisterClass131()); l.Add(new RegisterClass132()); l.Add(new RegisterClass133());
            l.Add(new RegisterClass140()); l.Add(new RegisterClass141()); l.Add(new RegisterClass142()); l.Add(new RegisterClass143());
            l.Add(new RegisterClass150()); l.Add(new RegisterClass151()); l.Add(new RegisterClass152()); l.Add(new RegisterClass153());
        }

    }
}
