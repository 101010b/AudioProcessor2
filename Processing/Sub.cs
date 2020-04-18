using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.Processing
{
    class Sub : RTForm
    {

        public void InitializeComponent()
        {
            this.ioOut = new AudioProcessor.RTIO();
            this.io8 = new AudioProcessor.RTIO();
            this.io7 = new AudioProcessor.RTIO();
            this.io6 = new AudioProcessor.RTIO();
            this.io5 = new AudioProcessor.RTIO();
            this.io4 = new AudioProcessor.RTIO();
            this.io3 = new AudioProcessor.RTIO();
            this.io2 = new AudioProcessor.RTIO();
            this.io1 = new AudioProcessor.RTIO();
            this.SuspendLayout();
            // 
            // ioOut
            // 
            this.ioOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut.contactBackColor = System.Drawing.Color.Black;
            this.ioOut.contactColor = System.Drawing.Color.DimGray;
            this.ioOut.Location = new System.Drawing.Point(30, 28);
            this.ioOut.Name = "ioOut";
            this.ioOut.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut.showTitle = false;
            this.ioOut.Size = new System.Drawing.Size(21, 20);
            this.ioOut.TabIndex = 17;
            this.ioOut.Text = "rtio9";
            this.ioOut.title = "IO";
            this.ioOut.titleColor = System.Drawing.Color.DimGray;
            this.ioOut.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOut.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // io8
            // 
            this.io8.contactBackColor = System.Drawing.Color.Black;
            this.io8.contactColor = System.Drawing.Color.DimGray;
            this.io8.Location = new System.Drawing.Point(0, 210);
            this.io8.Name = "io8";
            this.io8.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io8.showTitle = false;
            this.io8.Size = new System.Drawing.Size(21, 20);
            this.io8.TabIndex = 16;
            this.io8.Text = "rtio8";
            this.io8.title = "IO";
            this.io8.titleColor = System.Drawing.Color.DimGray;
            this.io8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io8.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // io7
            // 
            this.io7.contactBackColor = System.Drawing.Color.Black;
            this.io7.contactColor = System.Drawing.Color.DimGray;
            this.io7.Location = new System.Drawing.Point(0, 184);
            this.io7.Name = "io7";
            this.io7.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io7.showTitle = false;
            this.io7.Size = new System.Drawing.Size(21, 20);
            this.io7.TabIndex = 15;
            this.io7.Text = "rtio7";
            this.io7.title = "IO";
            this.io7.titleColor = System.Drawing.Color.DimGray;
            this.io7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io7.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // io6
            // 
            this.io6.contactBackColor = System.Drawing.Color.Black;
            this.io6.contactColor = System.Drawing.Color.DimGray;
            this.io6.Location = new System.Drawing.Point(0, 158);
            this.io6.Name = "io6";
            this.io6.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io6.showTitle = false;
            this.io6.Size = new System.Drawing.Size(21, 20);
            this.io6.TabIndex = 14;
            this.io6.Text = "rtio6";
            this.io6.title = "IO";
            this.io6.titleColor = System.Drawing.Color.DimGray;
            this.io6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io6.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // io5
            // 
            this.io5.contactBackColor = System.Drawing.Color.Black;
            this.io5.contactColor = System.Drawing.Color.DimGray;
            this.io5.Location = new System.Drawing.Point(0, 132);
            this.io5.Name = "io5";
            this.io5.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io5.showTitle = false;
            this.io5.Size = new System.Drawing.Size(21, 20);
            this.io5.TabIndex = 13;
            this.io5.Text = "rtio5";
            this.io5.title = "IO";
            this.io5.titleColor = System.Drawing.Color.DimGray;
            this.io5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io5.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // io4
            // 
            this.io4.contactBackColor = System.Drawing.Color.Black;
            this.io4.contactColor = System.Drawing.Color.DimGray;
            this.io4.Location = new System.Drawing.Point(0, 106);
            this.io4.Name = "io4";
            this.io4.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io4.showTitle = false;
            this.io4.Size = new System.Drawing.Size(21, 20);
            this.io4.TabIndex = 12;
            this.io4.Text = "rtio4";
            this.io4.title = "IO";
            this.io4.titleColor = System.Drawing.Color.DimGray;
            this.io4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io4.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // io3
            // 
            this.io3.contactBackColor = System.Drawing.Color.Black;
            this.io3.contactColor = System.Drawing.Color.DimGray;
            this.io3.Location = new System.Drawing.Point(0, 80);
            this.io3.Name = "io3";
            this.io3.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io3.showTitle = false;
            this.io3.Size = new System.Drawing.Size(21, 20);
            this.io3.TabIndex = 11;
            this.io3.Text = "rtio3";
            this.io3.title = "IO";
            this.io3.titleColor = System.Drawing.Color.DimGray;
            this.io3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io3.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // io2
            // 
            this.io2.contactBackColor = System.Drawing.Color.Black;
            this.io2.contactColor = System.Drawing.Color.DimGray;
            this.io2.Location = new System.Drawing.Point(0, 54);
            this.io2.Name = "io2";
            this.io2.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io2.showTitle = false;
            this.io2.Size = new System.Drawing.Size(21, 20);
            this.io2.TabIndex = 10;
            this.io2.Text = "rtio2";
            this.io2.title = "IO";
            this.io2.titleColor = System.Drawing.Color.DimGray;
            this.io2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io2.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // io1
            // 
            this.io1.contactBackColor = System.Drawing.Color.Black;
            this.io1.contactColor = System.Drawing.Color.DimGray;
            this.io1.Location = new System.Drawing.Point(0, 28);
            this.io1.Name = "io1";
            this.io1.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io1.showTitle = false;
            this.io1.Size = new System.Drawing.Size(21, 20);
            this.io1.TabIndex = 9;
            this.io1.Text = "rtio1";
            this.io1.title = "IO";
            this.io1.titleColor = System.Drawing.Color.DimGray;
            this.io1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io1.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // Sub
            // 
            this.canShrink = false;
            this.Controls.Add(this.ioOut);
            this.Controls.Add(this.io8);
            this.Controls.Add(this.io7);
            this.Controls.Add(this.io6);
            this.Controls.Add(this.io5);
            this.Controls.Add(this.io4);
            this.Controls.Add(this.io3);
            this.Controls.Add(this.io2);
            this.Controls.Add(this.io1);
            this.hasActiveSwitch = false;
            this.Name = "Sub";
            this.Size = new System.Drawing.Size(51, 237);
            this.title = "-";
            this.ResumeLayout(false);

        }

        private RTIO ioOut;
        private RTIO io8;
        private RTIO io7;
        private RTIO io6;
        private RTIO io5;
        private RTIO io4;
        private RTIO io3;
        private RTIO io2;
        private RTIO io1;
        int inputs;

        private void init()
        {
            InitializeComponent();

            int h = Height;
            if (inputs < 8) { io8.Hide(); h = io8.Location.Y; }
            if (inputs < 7) { io7.Hide(); h = io7.Location.Y; }
            if (inputs < 6) { io6.Hide(); h = io6.Location.Y; }
            if (inputs < 5) { io5.Hide(); h = io5.Location.Y; }
            if (inputs < 4) { io4.Hide(); h = io4.Location.Y; }
            if (inputs < 3) { io3.Hide(); h = io3.Location.Y; }
            Height = h;

            /*
            showName = false;
            size.set(50, 50 * inputs);
            io.Add(new ProcessingIO(owner, this, ProcessingIO.ProcessingIOType.Input, false, "+", true,
                ProcessingIO.ProcessingIOAlign.LeftFromTop, Vector.V(25, 0)));
            for (int i = 1; i < inputs; i++)
                io.Add(new ProcessingIO(owner, this, ProcessingIO.ProcessingIOType.Input, false, "-", true,
                    ProcessingIO.ProcessingIOAlign.LeftFromTop, Vector.V(25 + i * 50, 0)));
            io.Add(new ProcessingIO(owner, this, ProcessingIO.ProcessingIOType.Output, false, "=", false,
                ProcessingIO.ProcessingIOAlign.RightFromTop, Vector.V(25 * inputs, 0)));

            */
            processingType = ProcessingType.Processor;
        }



        public Sub(int _inputs):base()
        {
            inputs = _inputs;
            init();
        }

        public Sub(SystemPanel _owner, BinaryReader src):base(_owner, src)
        {
            inputs = src.ReadInt32();
            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(inputs);
        }

        public override void tick()
        {
            DataBuffer dbout = getOutputBuffer(ioOut);
            if (dbout == null)
                return;

            dbout.zero();
            if ((inputs > 0) && (io1.connectedTo != null)) { DataBuffer db = getInputBuffer(io1); for (int i = 0; i < owner.blockSize; i++) dbout.data[i] = db.data[i]; }
            if ((inputs > 1) && (io2.connectedTo != null)) { DataBuffer db = getInputBuffer(io2); for (int i = 0; i < owner.blockSize; i++) dbout.data[i] -= db.data[i]; }
            if ((inputs > 2) && (io3.connectedTo != null)) { DataBuffer db = getInputBuffer(io3); for (int i = 0; i < owner.blockSize; i++) dbout.data[i] -= db.data[i]; }
            if ((inputs > 3) && (io4.connectedTo != null)) { DataBuffer db = getInputBuffer(io4); for (int i = 0; i < owner.blockSize; i++) dbout.data[i] -= db.data[i]; }
            if ((inputs > 4) && (io5.connectedTo != null)) { DataBuffer db = getInputBuffer(io5); for (int i = 0; i < owner.blockSize; i++) dbout.data[i] -= db.data[i]; }
            if ((inputs > 5) && (io6.connectedTo != null)) { DataBuffer db = getInputBuffer(io6); for (int i = 0; i < owner.blockSize; i++) dbout.data[i] -= db.data[i]; }
            if ((inputs > 6) && (io7.connectedTo != null)) { DataBuffer db = getInputBuffer(io7); for (int i = 0; i < owner.blockSize; i++) dbout.data[i] -= db.data[i]; }
            if ((inputs > 7) && (io8.connectedTo != null)) { DataBuffer db = getInputBuffer(io8); for (int i = 0; i < owner.blockSize; i++) dbout.data[i] -= db.data[i]; }

        }

        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Sub", "2 x" }; }
            public override RTForm Instantiate() { return new Sub(2); }
        }
        class RegisterClass3 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Sub", "3 x" }; }
            public override RTForm Instantiate() { return new Sub(3); }
        }
        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Sub", "4 x" }; }
            public override RTForm Instantiate() { return new Sub(4); }
        }
        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass2());
            l.Add(new RegisterClass3());
            l.Add(new RegisterClass4());
        }



    }
}
