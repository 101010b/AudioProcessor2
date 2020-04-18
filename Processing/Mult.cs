using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.Processing
{
    class Mult : RTForm
    {

        public void InitializeComponent()
        {
            this.ioOut1 = new AudioProcessor.RTIO();
            this.ioB7 = new AudioProcessor.RTIO();
            this.ioB6 = new AudioProcessor.RTIO();
            this.ioB5 = new AudioProcessor.RTIO();
            this.ioB4 = new AudioProcessor.RTIO();
            this.ioB3 = new AudioProcessor.RTIO();
            this.ioB2 = new AudioProcessor.RTIO();
            this.ioB1 = new AudioProcessor.RTIO();
            this.ioA = new AudioProcessor.RTIO();
            this.ioOut2 = new AudioProcessor.RTIO();
            this.ioOut3 = new AudioProcessor.RTIO();
            this.ioOut4 = new AudioProcessor.RTIO();
            this.ioOut5 = new AudioProcessor.RTIO();
            this.ioOut6 = new AudioProcessor.RTIO();
            this.ioOut7 = new AudioProcessor.RTIO();
            this.ioOut8 = new AudioProcessor.RTIO();
            this.ioB8 = new AudioProcessor.RTIO();
            this.SuspendLayout();
            // 
            // ioOut1
            // 
            this.ioOut1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut1.contactBackColor = System.Drawing.Color.Black;
            this.ioOut1.contactColor = System.Drawing.Color.DimGray;
            this.ioOut1.Location = new System.Drawing.Point(58, 55);
            this.ioOut1.Name = "ioOut1";
            this.ioOut1.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut1.showTitle = true;
            this.ioOut1.Size = new System.Drawing.Size(58, 20);
            this.ioOut1.TabIndex = 17;
            this.ioOut1.Text = "rtio9";
            this.ioOut1.title = "A*B1";
            this.ioOut1.titleColor = System.Drawing.Color.DimGray;
            this.ioOut1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOut1.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioB7
            // 
            this.ioB7.contactBackColor = System.Drawing.Color.Black;
            this.ioB7.contactColor = System.Drawing.Color.DimGray;
            this.ioB7.Location = new System.Drawing.Point(0, 211);
            this.ioB7.Name = "ioB7";
            this.ioB7.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB7.showTitle = true;
            this.ioB7.Size = new System.Drawing.Size(40, 20);
            this.ioB7.TabIndex = 16;
            this.ioB7.Text = "rtio8";
            this.ioB7.title = "B7";
            this.ioB7.titleColor = System.Drawing.Color.DimGray;
            this.ioB7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB7.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioB6
            // 
            this.ioB6.contactBackColor = System.Drawing.Color.Black;
            this.ioB6.contactColor = System.Drawing.Color.DimGray;
            this.ioB6.Location = new System.Drawing.Point(0, 185);
            this.ioB6.Name = "ioB6";
            this.ioB6.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB6.showTitle = true;
            this.ioB6.Size = new System.Drawing.Size(40, 20);
            this.ioB6.TabIndex = 15;
            this.ioB6.Text = "rtio7";
            this.ioB6.title = "B6";
            this.ioB6.titleColor = System.Drawing.Color.DimGray;
            this.ioB6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB6.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioB5
            // 
            this.ioB5.contactBackColor = System.Drawing.Color.Black;
            this.ioB5.contactColor = System.Drawing.Color.DimGray;
            this.ioB5.Location = new System.Drawing.Point(0, 159);
            this.ioB5.Name = "ioB5";
            this.ioB5.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB5.showTitle = true;
            this.ioB5.Size = new System.Drawing.Size(40, 20);
            this.ioB5.TabIndex = 14;
            this.ioB5.Text = "rtio6";
            this.ioB5.title = "B5";
            this.ioB5.titleColor = System.Drawing.Color.DimGray;
            this.ioB5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB5.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioB4
            // 
            this.ioB4.contactBackColor = System.Drawing.Color.Black;
            this.ioB4.contactColor = System.Drawing.Color.DimGray;
            this.ioB4.Location = new System.Drawing.Point(0, 133);
            this.ioB4.Name = "ioB4";
            this.ioB4.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB4.showTitle = true;
            this.ioB4.Size = new System.Drawing.Size(40, 20);
            this.ioB4.TabIndex = 13;
            this.ioB4.Text = "rtio5";
            this.ioB4.title = "B4";
            this.ioB4.titleColor = System.Drawing.Color.DimGray;
            this.ioB4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB4.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioB3
            // 
            this.ioB3.contactBackColor = System.Drawing.Color.Black;
            this.ioB3.contactColor = System.Drawing.Color.DimGray;
            this.ioB3.Location = new System.Drawing.Point(0, 107);
            this.ioB3.Name = "ioB3";
            this.ioB3.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB3.showTitle = true;
            this.ioB3.Size = new System.Drawing.Size(40, 20);
            this.ioB3.TabIndex = 12;
            this.ioB3.Text = "rtio4";
            this.ioB3.title = "B3";
            this.ioB3.titleColor = System.Drawing.Color.DimGray;
            this.ioB3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB3.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioB2
            // 
            this.ioB2.contactBackColor = System.Drawing.Color.Black;
            this.ioB2.contactColor = System.Drawing.Color.DimGray;
            this.ioB2.Location = new System.Drawing.Point(0, 81);
            this.ioB2.Name = "ioB2";
            this.ioB2.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB2.showTitle = true;
            this.ioB2.Size = new System.Drawing.Size(40, 20);
            this.ioB2.TabIndex = 11;
            this.ioB2.Text = "rtio3";
            this.ioB2.title = "B2";
            this.ioB2.titleColor = System.Drawing.Color.DimGray;
            this.ioB2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB2.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioB1
            // 
            this.ioB1.contactBackColor = System.Drawing.Color.Black;
            this.ioB1.contactColor = System.Drawing.Color.DimGray;
            this.ioB1.Location = new System.Drawing.Point(0, 55);
            this.ioB1.Name = "ioB1";
            this.ioB1.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB1.showTitle = true;
            this.ioB1.Size = new System.Drawing.Size(40, 20);
            this.ioB1.TabIndex = 10;
            this.ioB1.Text = "rtio2";
            this.ioB1.title = "B1";
            this.ioB1.titleColor = System.Drawing.Color.DimGray;
            this.ioB1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB1.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioA
            // 
            this.ioA.contactBackColor = System.Drawing.Color.Black;
            this.ioA.contactColor = System.Drawing.Color.DimGray;
            this.ioA.Location = new System.Drawing.Point(0, 29);
            this.ioA.Name = "ioA";
            this.ioA.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioA.showTitle = true;
            this.ioA.Size = new System.Drawing.Size(40, 20);
            this.ioA.TabIndex = 9;
            this.ioA.Text = "rtio1";
            this.ioA.title = "A";
            this.ioA.titleColor = System.Drawing.Color.DimGray;
            this.ioA.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioA.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioOut2
            // 
            this.ioOut2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut2.contactBackColor = System.Drawing.Color.Black;
            this.ioOut2.contactColor = System.Drawing.Color.DimGray;
            this.ioOut2.Location = new System.Drawing.Point(58, 81);
            this.ioOut2.Name = "ioOut2";
            this.ioOut2.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut2.showTitle = true;
            this.ioOut2.Size = new System.Drawing.Size(58, 20);
            this.ioOut2.TabIndex = 18;
            this.ioOut2.Text = "rtio9";
            this.ioOut2.title = "A*B2";
            this.ioOut2.titleColor = System.Drawing.Color.DimGray;
            this.ioOut2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOut2.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioOut3
            // 
            this.ioOut3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut3.contactBackColor = System.Drawing.Color.Black;
            this.ioOut3.contactColor = System.Drawing.Color.DimGray;
            this.ioOut3.Location = new System.Drawing.Point(58, 107);
            this.ioOut3.Name = "ioOut3";
            this.ioOut3.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut3.showTitle = true;
            this.ioOut3.Size = new System.Drawing.Size(58, 20);
            this.ioOut3.TabIndex = 19;
            this.ioOut3.Text = "rtio9";
            this.ioOut3.title = "A*B3";
            this.ioOut3.titleColor = System.Drawing.Color.DimGray;
            this.ioOut3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOut3.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioOut4
            // 
            this.ioOut4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut4.contactBackColor = System.Drawing.Color.Black;
            this.ioOut4.contactColor = System.Drawing.Color.DimGray;
            this.ioOut4.Location = new System.Drawing.Point(58, 133);
            this.ioOut4.Name = "ioOut4";
            this.ioOut4.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut4.showTitle = true;
            this.ioOut4.Size = new System.Drawing.Size(58, 20);
            this.ioOut4.TabIndex = 20;
            this.ioOut4.Text = "rtio9";
            this.ioOut4.title = "A*B4";
            this.ioOut4.titleColor = System.Drawing.Color.DimGray;
            this.ioOut4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOut4.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioOut5
            // 
            this.ioOut5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut5.contactBackColor = System.Drawing.Color.Black;
            this.ioOut5.contactColor = System.Drawing.Color.DimGray;
            this.ioOut5.Location = new System.Drawing.Point(58, 159);
            this.ioOut5.Name = "ioOut5";
            this.ioOut5.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut5.showTitle = true;
            this.ioOut5.Size = new System.Drawing.Size(58, 20);
            this.ioOut5.TabIndex = 21;
            this.ioOut5.Text = "rtio9";
            this.ioOut5.title = "A*B5";
            this.ioOut5.titleColor = System.Drawing.Color.DimGray;
            this.ioOut5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOut5.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioOut6
            // 
            this.ioOut6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut6.contactBackColor = System.Drawing.Color.Black;
            this.ioOut6.contactColor = System.Drawing.Color.DimGray;
            this.ioOut6.Location = new System.Drawing.Point(58, 185);
            this.ioOut6.Name = "ioOut6";
            this.ioOut6.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut6.showTitle = true;
            this.ioOut6.Size = new System.Drawing.Size(58, 20);
            this.ioOut6.TabIndex = 22;
            this.ioOut6.Text = "rtio9";
            this.ioOut6.title = "A*B6";
            this.ioOut6.titleColor = System.Drawing.Color.DimGray;
            this.ioOut6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOut6.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioOut7
            // 
            this.ioOut7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut7.contactBackColor = System.Drawing.Color.Black;
            this.ioOut7.contactColor = System.Drawing.Color.DimGray;
            this.ioOut7.Location = new System.Drawing.Point(58, 211);
            this.ioOut7.Name = "ioOut7";
            this.ioOut7.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut7.showTitle = true;
            this.ioOut7.Size = new System.Drawing.Size(58, 20);
            this.ioOut7.TabIndex = 23;
            this.ioOut7.Text = "rtio9";
            this.ioOut7.title = "A*B7";
            this.ioOut7.titleColor = System.Drawing.Color.DimGray;
            this.ioOut7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOut7.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioOut8
            // 
            this.ioOut8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut8.contactBackColor = System.Drawing.Color.Black;
            this.ioOut8.contactColor = System.Drawing.Color.DimGray;
            this.ioOut8.Location = new System.Drawing.Point(58, 237);
            this.ioOut8.Name = "ioOut8";
            this.ioOut8.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut8.showTitle = true;
            this.ioOut8.Size = new System.Drawing.Size(58, 20);
            this.ioOut8.TabIndex = 25;
            this.ioOut8.Text = "rtio9";
            this.ioOut8.title = "A*B8";
            this.ioOut8.titleColor = System.Drawing.Color.DimGray;
            this.ioOut8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOut8.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioB8
            // 
            this.ioB8.contactBackColor = System.Drawing.Color.Black;
            this.ioB8.contactColor = System.Drawing.Color.DimGray;
            this.ioB8.Location = new System.Drawing.Point(0, 237);
            this.ioB8.Name = "ioB8";
            this.ioB8.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB8.showTitle = true;
            this.ioB8.Size = new System.Drawing.Size(40, 20);
            this.ioB8.TabIndex = 24;
            this.ioB8.Text = "rtio8";
            this.ioB8.title = "B8";
            this.ioB8.titleColor = System.Drawing.Color.DimGray;
            this.ioB8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB8.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // Mult
            // 
            this.canShrink = false;
            this.Controls.Add(this.ioOut8);
            this.Controls.Add(this.ioB8);
            this.Controls.Add(this.ioOut7);
            this.Controls.Add(this.ioOut6);
            this.Controls.Add(this.ioOut5);
            this.Controls.Add(this.ioOut4);
            this.Controls.Add(this.ioOut3);
            this.Controls.Add(this.ioOut2);
            this.Controls.Add(this.ioOut1);
            this.Controls.Add(this.ioB7);
            this.Controls.Add(this.ioB6);
            this.Controls.Add(this.ioB5);
            this.Controls.Add(this.ioB4);
            this.Controls.Add(this.ioB3);
            this.Controls.Add(this.ioB2);
            this.Controls.Add(this.ioB1);
            this.Controls.Add(this.ioA);
            this.hasActiveSwitch = false;
            this.Name = "Mult";
            this.shrinkTitle = "*";
            this.Size = new System.Drawing.Size(116, 261);
            this.title = "*";
            this.ResumeLayout(false);

        }

        int inputs;
        private RTIO ioOut1;
        private RTIO ioB7;
        private RTIO ioB6;
        private RTIO ioB5;
        private RTIO ioB4;
        private RTIO ioB3;
        private RTIO ioB2;
        private RTIO ioB1;
        private RTIO ioA;
        private RTIO ioOut2;
        private RTIO ioOut3;
        private RTIO ioOut4;
        private RTIO ioOut5;
        private RTIO ioOut6;
        private RTIO ioOut8;
        private RTIO ioB8;
        private RTIO ioOut7;

        private void init()
        {
            InitializeComponent();

            int h = Height;
            if (inputs < 8) { ioB8.Hide(); ioOut8.Hide(); h = ioB8.Location.Y; }
            if (inputs < 7) { ioB7.Hide(); ioOut7.Hide(); h = ioB7.Location.Y; }
            if (inputs < 6) { ioB6.Hide(); ioOut6.Hide(); h = ioB6.Location.Y; }
            if (inputs < 5) { ioB5.Hide(); ioOut5.Hide(); h = ioB5.Location.Y; }
            if (inputs < 4) { ioB4.Hide(); ioOut4.Hide(); h = ioB4.Location.Y; }
            if (inputs < 3) { ioB3.Hide(); ioOut3.Hide(); h = ioB3.Location.Y; }
            if (inputs < 2) { ioB2.Hide(); ioOut2.Hide(); h = ioB2.Location.Y; }
            Height = h;
            if (inputs < 2)
            {
                ioB1.title = "B";
                ioOut1.title = "A*B";
            }
           
            processingType = ProcessingType.Processor;
        }

        public Mult() : this(8)
        {
        }

        public Mult(int _channels):base()
        {
            inputs = _channels;

            init();
        }

        public Mult(SystemPanel _owner, BinaryReader src):base(_owner,src)
        {
            inputs = src.ReadInt32();
            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(inputs);
        }

        private void processChannel(DataBuffer dbA, DataBuffer dbB, DataBuffer dbOut)
        {
            if (dbOut == null)
                return;
            if ((dbA == null) || (dbB == null))
                return;
            for (int i = 0; i < owner.blockSize; i++)
                dbOut.data[i] = dbA.data[i] * dbB.data[i];
        }

        public override void tick()
        {
            DataBuffer dbA = getInputBuffer(ioA);
            if (inputs >= 1) processChannel(dbA, getInputBuffer(ioB1), getOutputBuffer(ioOut1));
            if (inputs >= 2) processChannel(dbA, getInputBuffer(ioB2), getOutputBuffer(ioOut2));
            if (inputs >= 3) processChannel(dbA, getInputBuffer(ioB3), getOutputBuffer(ioOut3));
            if (inputs >= 4) processChannel(dbA, getInputBuffer(ioB4), getOutputBuffer(ioOut4));
            if (inputs >= 5) processChannel(dbA, getInputBuffer(ioB5), getOutputBuffer(ioOut5));
            if (inputs >= 6) processChannel(dbA, getInputBuffer(ioB6), getOutputBuffer(ioOut6));
            if (inputs >= 7) processChannel(dbA, getInputBuffer(ioB7), getOutputBuffer(ioOut7));
            if (inputs >= 8) processChannel(dbA, getInputBuffer(ioB8), getOutputBuffer(ioOut8));
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Multiplier", "1x" }; }
            public override RTForm Instantiate() { return new Mult(1); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Multiplier", "2x" }; }
            public override RTForm Instantiate() { return new Mult(2); }
        }
        class RegisterClass3 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Multiplier", "4x" }; }
            public override RTForm Instantiate() { return new Mult(4); }
        }
        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Multiplier", "8x" }; }
            public override RTForm Instantiate() { return new Mult(8); }
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
