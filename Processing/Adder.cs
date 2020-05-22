using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.Processing
{
    public class Adder:RTForm
    {

        public void InitializeComponent()
        {
            this.io1 = new AudioProcessor.RTIO();
            this.io2 = new AudioProcessor.RTIO();
            this.io3 = new AudioProcessor.RTIO();
            this.io4 = new AudioProcessor.RTIO();
            this.io5 = new AudioProcessor.RTIO();
            this.io6 = new AudioProcessor.RTIO();
            this.io7 = new AudioProcessor.RTIO();
            this.io8 = new AudioProcessor.RTIO();
            this.ioOut = new AudioProcessor.RTIO();
            this.SuspendLayout();
            // 
            // io1
            // 
            this.io1.contactBackColor = System.Drawing.Color.Black;
            this.io1.contactColor = System.Drawing.Color.DimGray;
            this.io1.Location = new System.Drawing.Point(0, 30);
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
            this.io2.Location = new System.Drawing.Point(0, 56);
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
            this.io3.Location = new System.Drawing.Point(0, 82);
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
            this.io4.Location = new System.Drawing.Point(0, 108);
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
            // io5
            // 
            this.io5.contactBackColor = System.Drawing.Color.Black;
            this.io5.contactColor = System.Drawing.Color.DimGray;
            this.io5.Location = new System.Drawing.Point(0, 134);
            this.io5.Name = "io5";
            this.io5.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io5.showTitle = false;
            this.io5.Size = new System.Drawing.Size(21, 20);
            this.io5.TabIndex = 4;
            this.io5.Text = "rtio5";
            this.io5.title = "IO";
            this.io5.titleColor = System.Drawing.Color.DimGray;
            this.io5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io5.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // io6
            // 
            this.io6.contactBackColor = System.Drawing.Color.Black;
            this.io6.contactColor = System.Drawing.Color.DimGray;
            this.io6.Location = new System.Drawing.Point(0, 160);
            this.io6.Name = "io6";
            this.io6.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io6.showTitle = false;
            this.io6.Size = new System.Drawing.Size(21, 20);
            this.io6.TabIndex = 5;
            this.io6.Text = "rtio6";
            this.io6.title = "IO";
            this.io6.titleColor = System.Drawing.Color.DimGray;
            this.io6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io6.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // io7
            // 
            this.io7.contactBackColor = System.Drawing.Color.Black;
            this.io7.contactColor = System.Drawing.Color.DimGray;
            this.io7.Location = new System.Drawing.Point(0, 186);
            this.io7.Name = "io7";
            this.io7.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io7.showTitle = false;
            this.io7.Size = new System.Drawing.Size(21, 20);
            this.io7.TabIndex = 6;
            this.io7.Text = "rtio7";
            this.io7.title = "IO";
            this.io7.titleColor = System.Drawing.Color.DimGray;
            this.io7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io7.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // io8
            // 
            this.io8.contactBackColor = System.Drawing.Color.Black;
            this.io8.contactColor = System.Drawing.Color.DimGray;
            this.io8.Location = new System.Drawing.Point(0, 212);
            this.io8.Name = "io8";
            this.io8.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io8.showTitle = false;
            this.io8.Size = new System.Drawing.Size(21, 20);
            this.io8.TabIndex = 7;
            this.io8.Text = "rtio8";
            this.io8.title = "IO";
            this.io8.titleColor = System.Drawing.Color.DimGray;
            this.io8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io8.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioOut
            // 
            this.ioOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut.contactBackColor = System.Drawing.Color.Black;
            this.ioOut.contactColor = System.Drawing.Color.DimGray;
            this.ioOut.Location = new System.Drawing.Point(30, 30);
            this.ioOut.Name = "ioOut";
            this.ioOut.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut.showTitle = false;
            this.ioOut.Size = new System.Drawing.Size(21, 20);
            this.ioOut.TabIndex = 8;
            this.ioOut.Text = "rtio9";
            this.ioOut.title = "IO";
            this.ioOut.titleColor = System.Drawing.Color.DimGray;
            this.ioOut.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOut.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // Adder
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
            this.Name = "Adder";
            this.Size = new System.Drawing.Size(51, 237);
            this.title = "+";
            this.ResumeLayout(false);

        }

        private RTIO io1;
        private RTIO io2;
        private RTIO io3;
        private RTIO io4;
        private RTIO io5;
        private RTIO io6;
        private RTIO io7;
        private RTIO io8;
        private RTIO ioOut;
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

            processingType = ProcessingType.Processor;
        }
        
        public Adder() : this(8)
        {
        }

        public Adder(int _inputs):base()
        {
            // showName = false;
            inputs = _inputs;

            init();
        }

        public Adder(SystemPanel _owner, BinaryReader src):base(_owner,src)
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
            SignalBuffer dbout = getSignalOutputBuffer(ioOut);
            if (dbout == null)
                return;
            dbout.zero();
            if ((inputs > 0) && (io1.connectedTo != null)) { SignalBuffer db = getSignalInputBuffer(io1); for (int i = 0; i < owner.blockSize; i++) dbout.data[i] += db.data[i]; }
            if ((inputs > 1) && (io2.connectedTo != null)) { SignalBuffer db = getSignalInputBuffer(io2); for (int i = 0; i < owner.blockSize; i++) dbout.data[i] += db.data[i]; }
            if ((inputs > 2) && (io3.connectedTo != null)) { SignalBuffer db = getSignalInputBuffer(io3); for (int i = 0; i < owner.blockSize; i++) dbout.data[i] += db.data[i]; }
            if ((inputs > 3) && (io4.connectedTo != null)) { SignalBuffer db = getSignalInputBuffer(io4); for (int i = 0; i < owner.blockSize; i++) dbout.data[i] += db.data[i]; }
            if ((inputs > 4) && (io5.connectedTo != null)) { SignalBuffer db = getSignalInputBuffer(io5); for (int i = 0; i < owner.blockSize; i++) dbout.data[i] += db.data[i]; }
            if ((inputs > 5) && (io6.connectedTo != null)) { SignalBuffer db = getSignalInputBuffer(io6); for (int i = 0; i < owner.blockSize; i++) dbout.data[i] += db.data[i]; }
            if ((inputs > 6) && (io7.connectedTo != null)) { SignalBuffer db = getSignalInputBuffer(io7); for (int i = 0; i < owner.blockSize; i++) dbout.data[i] += db.data[i]; }
            if ((inputs > 7) && (io8.connectedTo != null)) { SignalBuffer db = getSignalInputBuffer(io8); for (int i = 0; i < owner.blockSize; i++) dbout.data[i] += db.data[i]; }
        }

        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Add", "2 x" }; }
            public override RTForm Instantiate() { return new Adder(2); }
        }
        class RegisterClass3 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Add", "3 x" }; }
            public override RTForm Instantiate() { return new Adder(3); }
        }
        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Add", "4 x" }; }
            public override RTForm Instantiate() { return new Adder(4); }
        }
        class RegisterClass6 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Add", "6 x" }; }
            public override RTForm Instantiate() { return new Adder(6); }
        }
        class RegisterClass8 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Add", "8 x" }; }
            public override RTForm Instantiate() { return new Adder(8); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass2());
            l.Add(new RegisterClass3());
            l.Add(new RegisterClass4());
            l.Add(new RegisterClass6());
            l.Add(new RegisterClass8());
        }

    }
}
