using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.Processing
{
    public class Mixer : RTForm
    {

        public void InitializeComponent()
        {
            this.ioI1 = new AudioProcessor.RTIO();
            this.ioO = new AudioProcessor.RTIO();
            this.dl1 = new AudioProcessor.RTDial();
            this.dl2 = new AudioProcessor.RTDial();
            this.ioI2 = new AudioProcessor.RTIO();
            this.dl3 = new AudioProcessor.RTDial();
            this.ioI3 = new AudioProcessor.RTIO();
            this.dl4 = new AudioProcessor.RTDial();
            this.ioI4 = new AudioProcessor.RTIO();
            this.dl5 = new AudioProcessor.RTDial();
            this.ioI5 = new AudioProcessor.RTIO();
            this.dl6 = new AudioProcessor.RTDial();
            this.ioI6 = new AudioProcessor.RTIO();
            this.dl7 = new AudioProcessor.RTDial();
            this.ioI7 = new AudioProcessor.RTIO();
            this.dl8 = new AudioProcessor.RTDial();
            this.ioI8 = new AudioProcessor.RTIO();
            this.SuspendLayout();
            // 
            // ioI1
            // 
            this.ioI1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ioI1.contactBackColor = System.Drawing.Color.Black;
            this.ioI1.contactColor = System.Drawing.Color.DimGray;
            this.ioI1.Location = new System.Drawing.Point(40, 128);
            this.ioI1.Name = "ioI1";
            this.ioI1.orientation = AudioProcessor.RTIO.RTOrientation.South;
            this.ioI1.showTitle = false;
            this.ioI1.Size = new System.Drawing.Size(20, 21);
            this.ioI1.TabIndex = 0;
            this.ioI1.Text = "rtio1";
            this.ioI1.title = "IO";
            this.ioI1.titleColor = System.Drawing.Color.DimGray;
            this.ioI1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI1.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioO
            // 
            this.ioO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO.contactBackColor = System.Drawing.Color.Black;
            this.ioO.contactColor = System.Drawing.Color.DimGray;
            this.ioO.Location = new System.Drawing.Point(699, 59);
            this.ioO.Name = "ioO";
            this.ioO.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO.showTitle = false;
            this.ioO.Size = new System.Drawing.Size(21, 20);
            this.ioO.TabIndex = 1;
            this.ioO.Text = "rtio2";
            this.ioO.title = "IO";
            this.ioO.titleColor = System.Drawing.Color.DimGray;
            this.ioO.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // dl1
            // 
            this.dl1.dialColor = System.Drawing.Color.Silver;
            this.dl1.dialDiameter = 50D;
            this.dl1.dialMarkColor = System.Drawing.Color.Red;
            this.dl1.format = "F2";
            this.dl1.Location = new System.Drawing.Point(10, 23);
            this.dl1.logScale = false;
            this.dl1.maxVal = 20D;
            this.dl1.minVal = -100D;
            this.dl1.Name = "dl1";
            this.dl1.scaleColor = System.Drawing.Color.Gold;
            this.dl1.showScale = true;
            this.dl1.showTitle = false;
            this.dl1.showValue = true;
            this.dl1.Size = new System.Drawing.Size(80, 100);
            this.dl1.TabIndex = 2;
            this.dl1.Text = "rtDial1";
            this.dl1.title = "Dial";
            this.dl1.titleColor = System.Drawing.Color.DimGray;
            this.dl1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl1.unit = "dB";
            this.dl1.val = -20D;
            this.dl1.valueColor = System.Drawing.Color.DimGray;
            this.dl1.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dl2
            // 
            this.dl2.dialColor = System.Drawing.Color.Silver;
            this.dl2.dialDiameter = 50D;
            this.dl2.dialMarkColor = System.Drawing.Color.Red;
            this.dl2.format = "F2";
            this.dl2.Location = new System.Drawing.Point(96, 23);
            this.dl2.logScale = false;
            this.dl2.maxVal = 20D;
            this.dl2.minVal = -100D;
            this.dl2.Name = "dl2";
            this.dl2.scaleColor = System.Drawing.Color.Gold;
            this.dl2.showScale = true;
            this.dl2.showTitle = false;
            this.dl2.showValue = true;
            this.dl2.Size = new System.Drawing.Size(80, 100);
            this.dl2.TabIndex = 18;
            this.dl2.Text = "rtDial2";
            this.dl2.title = "Dial";
            this.dl2.titleColor = System.Drawing.Color.DimGray;
            this.dl2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl2.unit = "dB";
            this.dl2.val = -20D;
            this.dl2.valueColor = System.Drawing.Color.DimGray;
            this.dl2.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI2
            // 
            this.ioI2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ioI2.contactBackColor = System.Drawing.Color.Black;
            this.ioI2.contactColor = System.Drawing.Color.DimGray;
            this.ioI2.Location = new System.Drawing.Point(126, 128);
            this.ioI2.Name = "ioI2";
            this.ioI2.orientation = AudioProcessor.RTIO.RTOrientation.South;
            this.ioI2.showTitle = false;
            this.ioI2.Size = new System.Drawing.Size(20, 21);
            this.ioI2.TabIndex = 16;
            this.ioI2.Text = "ioI2";
            this.ioI2.title = "IO";
            this.ioI2.titleColor = System.Drawing.Color.DimGray;
            this.ioI2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI2.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // dl3
            // 
            this.dl3.dialColor = System.Drawing.Color.Silver;
            this.dl3.dialDiameter = 50D;
            this.dl3.dialMarkColor = System.Drawing.Color.Red;
            this.dl3.format = "F2";
            this.dl3.Location = new System.Drawing.Point(182, 23);
            this.dl3.logScale = false;
            this.dl3.maxVal = 20D;
            this.dl3.minVal = -100D;
            this.dl3.Name = "dl3";
            this.dl3.scaleColor = System.Drawing.Color.Gold;
            this.dl3.showScale = true;
            this.dl3.showTitle = false;
            this.dl3.showValue = true;
            this.dl3.Size = new System.Drawing.Size(80, 100);
            this.dl3.TabIndex = 21;
            this.dl3.Text = "rtDial3";
            this.dl3.title = "Dial";
            this.dl3.titleColor = System.Drawing.Color.DimGray;
            this.dl3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl3.unit = "dB";
            this.dl3.val = -20D;
            this.dl3.valueColor = System.Drawing.Color.DimGray;
            this.dl3.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI3
            // 
            this.ioI3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ioI3.contactBackColor = System.Drawing.Color.Black;
            this.ioI3.contactColor = System.Drawing.Color.DimGray;
            this.ioI3.Location = new System.Drawing.Point(212, 128);
            this.ioI3.Name = "ioI3";
            this.ioI3.orientation = AudioProcessor.RTIO.RTOrientation.South;
            this.ioI3.showTitle = false;
            this.ioI3.Size = new System.Drawing.Size(20, 21);
            this.ioI3.TabIndex = 19;
            this.ioI3.Text = "rtio6";
            this.ioI3.title = "IO";
            this.ioI3.titleColor = System.Drawing.Color.DimGray;
            this.ioI3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI3.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // dl4
            // 
            this.dl4.dialColor = System.Drawing.Color.Silver;
            this.dl4.dialDiameter = 50D;
            this.dl4.dialMarkColor = System.Drawing.Color.Red;
            this.dl4.format = "F2";
            this.dl4.Location = new System.Drawing.Point(268, 23);
            this.dl4.logScale = false;
            this.dl4.maxVal = 20D;
            this.dl4.minVal = -100D;
            this.dl4.Name = "dl4";
            this.dl4.scaleColor = System.Drawing.Color.Gold;
            this.dl4.showScale = true;
            this.dl4.showTitle = false;
            this.dl4.showValue = true;
            this.dl4.Size = new System.Drawing.Size(80, 100);
            this.dl4.TabIndex = 24;
            this.dl4.Text = "rtDial4";
            this.dl4.title = "Dial";
            this.dl4.titleColor = System.Drawing.Color.DimGray;
            this.dl4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl4.unit = "dB";
            this.dl4.val = -20D;
            this.dl4.valueColor = System.Drawing.Color.DimGray;
            this.dl4.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI4
            // 
            this.ioI4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ioI4.contactBackColor = System.Drawing.Color.Black;
            this.ioI4.contactColor = System.Drawing.Color.DimGray;
            this.ioI4.Location = new System.Drawing.Point(298, 128);
            this.ioI4.Name = "ioI4";
            this.ioI4.orientation = AudioProcessor.RTIO.RTOrientation.South;
            this.ioI4.showTitle = false;
            this.ioI4.Size = new System.Drawing.Size(20, 21);
            this.ioI4.TabIndex = 22;
            this.ioI4.Text = "rtio8";
            this.ioI4.title = "IO";
            this.ioI4.titleColor = System.Drawing.Color.DimGray;
            this.ioI4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI4.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // dl5
            // 
            this.dl5.dialColor = System.Drawing.Color.Silver;
            this.dl5.dialDiameter = 50D;
            this.dl5.dialMarkColor = System.Drawing.Color.Red;
            this.dl5.format = "F2";
            this.dl5.Location = new System.Drawing.Point(354, 23);
            this.dl5.logScale = false;
            this.dl5.maxVal = 20D;
            this.dl5.minVal = -100D;
            this.dl5.Name = "dl5";
            this.dl5.scaleColor = System.Drawing.Color.Gold;
            this.dl5.showScale = true;
            this.dl5.showTitle = false;
            this.dl5.showValue = true;
            this.dl5.Size = new System.Drawing.Size(80, 100);
            this.dl5.TabIndex = 27;
            this.dl5.Text = "rtDial5";
            this.dl5.title = "Dial";
            this.dl5.titleColor = System.Drawing.Color.DimGray;
            this.dl5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl5.unit = "dB";
            this.dl5.val = -20D;
            this.dl5.valueColor = System.Drawing.Color.DimGray;
            this.dl5.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI5
            // 
            this.ioI5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ioI5.contactBackColor = System.Drawing.Color.Black;
            this.ioI5.contactColor = System.Drawing.Color.DimGray;
            this.ioI5.Location = new System.Drawing.Point(384, 128);
            this.ioI5.Name = "ioI5";
            this.ioI5.orientation = AudioProcessor.RTIO.RTOrientation.South;
            this.ioI5.showTitle = false;
            this.ioI5.Size = new System.Drawing.Size(20, 21);
            this.ioI5.TabIndex = 25;
            this.ioI5.Text = "rtio10";
            this.ioI5.title = "IO";
            this.ioI5.titleColor = System.Drawing.Color.DimGray;
            this.ioI5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI5.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // dl6
            // 
            this.dl6.dialColor = System.Drawing.Color.Silver;
            this.dl6.dialDiameter = 50D;
            this.dl6.dialMarkColor = System.Drawing.Color.Red;
            this.dl6.format = "F2";
            this.dl6.Location = new System.Drawing.Point(440, 23);
            this.dl6.logScale = false;
            this.dl6.maxVal = 20D;
            this.dl6.minVal = -100D;
            this.dl6.Name = "dl6";
            this.dl6.scaleColor = System.Drawing.Color.Gold;
            this.dl6.showScale = true;
            this.dl6.showTitle = false;
            this.dl6.showValue = true;
            this.dl6.Size = new System.Drawing.Size(80, 100);
            this.dl6.TabIndex = 30;
            this.dl6.Text = "rtDial6";
            this.dl6.title = "Dial";
            this.dl6.titleColor = System.Drawing.Color.DimGray;
            this.dl6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl6.unit = "dB";
            this.dl6.val = -20D;
            this.dl6.valueColor = System.Drawing.Color.DimGray;
            this.dl6.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI6
            // 
            this.ioI6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ioI6.contactBackColor = System.Drawing.Color.Black;
            this.ioI6.contactColor = System.Drawing.Color.DimGray;
            this.ioI6.Location = new System.Drawing.Point(470, 128);
            this.ioI6.Name = "ioI6";
            this.ioI6.orientation = AudioProcessor.RTIO.RTOrientation.South;
            this.ioI6.showTitle = false;
            this.ioI6.Size = new System.Drawing.Size(20, 21);
            this.ioI6.TabIndex = 28;
            this.ioI6.Text = "rtio12";
            this.ioI6.title = "IO";
            this.ioI6.titleColor = System.Drawing.Color.DimGray;
            this.ioI6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI6.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // dl7
            // 
            this.dl7.dialColor = System.Drawing.Color.Silver;
            this.dl7.dialDiameter = 50D;
            this.dl7.dialMarkColor = System.Drawing.Color.Red;
            this.dl7.format = "F2";
            this.dl7.Location = new System.Drawing.Point(526, 23);
            this.dl7.logScale = false;
            this.dl7.maxVal = 20D;
            this.dl7.minVal = -100D;
            this.dl7.Name = "dl7";
            this.dl7.scaleColor = System.Drawing.Color.Gold;
            this.dl7.showScale = true;
            this.dl7.showTitle = false;
            this.dl7.showValue = true;
            this.dl7.Size = new System.Drawing.Size(80, 100);
            this.dl7.TabIndex = 33;
            this.dl7.Text = "rtDial7";
            this.dl7.title = "Dial";
            this.dl7.titleColor = System.Drawing.Color.DimGray;
            this.dl7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl7.unit = "dB";
            this.dl7.val = -20D;
            this.dl7.valueColor = System.Drawing.Color.DimGray;
            this.dl7.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI7
            // 
            this.ioI7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ioI7.contactBackColor = System.Drawing.Color.Black;
            this.ioI7.contactColor = System.Drawing.Color.DimGray;
            this.ioI7.Location = new System.Drawing.Point(556, 128);
            this.ioI7.Name = "ioI7";
            this.ioI7.orientation = AudioProcessor.RTIO.RTOrientation.South;
            this.ioI7.showTitle = false;
            this.ioI7.Size = new System.Drawing.Size(20, 21);
            this.ioI7.TabIndex = 31;
            this.ioI7.Text = "rtio14";
            this.ioI7.title = "IO";
            this.ioI7.titleColor = System.Drawing.Color.DimGray;
            this.ioI7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI7.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // dl8
            // 
            this.dl8.dialColor = System.Drawing.Color.Silver;
            this.dl8.dialDiameter = 50D;
            this.dl8.dialMarkColor = System.Drawing.Color.Red;
            this.dl8.format = "F2";
            this.dl8.Location = new System.Drawing.Point(612, 23);
            this.dl8.logScale = false;
            this.dl8.maxVal = 20D;
            this.dl8.minVal = -100D;
            this.dl8.Name = "dl8";
            this.dl8.scaleColor = System.Drawing.Color.Gold;
            this.dl8.showScale = true;
            this.dl8.showTitle = false;
            this.dl8.showValue = true;
            this.dl8.Size = new System.Drawing.Size(80, 100);
            this.dl8.TabIndex = 36;
            this.dl8.Text = "rtDial8";
            this.dl8.title = "Dial";
            this.dl8.titleColor = System.Drawing.Color.DimGray;
            this.dl8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl8.unit = "dB";
            this.dl8.val = -20D;
            this.dl8.valueColor = System.Drawing.Color.DimGray;
            this.dl8.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI8
            // 
            this.ioI8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ioI8.contactBackColor = System.Drawing.Color.Black;
            this.ioI8.contactColor = System.Drawing.Color.DimGray;
            this.ioI8.Location = new System.Drawing.Point(642, 128);
            this.ioI8.Name = "ioI8";
            this.ioI8.orientation = AudioProcessor.RTIO.RTOrientation.South;
            this.ioI8.showTitle = false;
            this.ioI8.Size = new System.Drawing.Size(20, 21);
            this.ioI8.TabIndex = 34;
            this.ioI8.Text = "rtio16";
            this.ioI8.title = "IO";
            this.ioI8.titleColor = System.Drawing.Color.DimGray;
            this.ioI8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI8.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // Mixer
            // 
            this.canShrink = false;
            this.Controls.Add(this.dl8);
            this.Controls.Add(this.ioI8);
            this.Controls.Add(this.dl7);
            this.Controls.Add(this.ioI7);
            this.Controls.Add(this.dl6);
            this.Controls.Add(this.ioI6);
            this.Controls.Add(this.dl5);
            this.Controls.Add(this.ioI5);
            this.Controls.Add(this.dl4);
            this.Controls.Add(this.ioI4);
            this.Controls.Add(this.dl3);
            this.Controls.Add(this.ioI3);
            this.Controls.Add(this.dl2);
            this.Controls.Add(this.ioI2);
            this.Controls.Add(this.dl1);
            this.Controls.Add(this.ioO);
            this.Controls.Add(this.ioI1);
            this.Name = "Mixer";
            this.Size = new System.Drawing.Size(720, 149);
            this.title = "Mixer";
            this.ResumeLayout(false);

        }

        double[] gain;
        private RTIO ioI1;
        private RTIO ioO;
        private RTDial dl1;
        private RTDial dl2;
        private RTIO ioI2;
        private RTDial dl3;
        private RTIO ioI3;
        private RTDial dl4;
        private RTIO ioI4;
        private RTDial dl5;
        private RTIO ioI5;
        private RTDial dl6;
        private RTIO ioI6;
        private RTDial dl7;
        private RTIO ioI7;
        private RTDial dl8;
        private RTIO ioI8;
        int inputs;

        private void init()
        {
            InitializeComponent();

            int w = Width;
            int dx = dl8.Location.X - dl7.Location.X;
            if (inputs < 8) { ioI8.Hide(); dl8.Hide(); w -= dx; }
            if (inputs < 7) { ioI7.Hide(); dl7.Hide(); w -= dx; }
            if (inputs < 6) { ioI6.Hide(); dl6.Hide(); w -= dx; }
            if (inputs < 5) { ioI5.Hide(); dl5.Hide(); w -= dx; }
            if (inputs < 4) { ioI4.Hide(); dl4.Hide(); w -= dx; }
            if (inputs < 3) { ioI3.Hide(); dl3.Hide(); w -= dx; }
            if (inputs < 2) { ioI2.Hide(); dl2.Hide(); w -= dx; }
            Width = w;

            if (inputs >= 1) dl1.val = gain[0];
            if (inputs >= 2) dl2.val = gain[1];
            if (inputs >= 3) dl3.val = gain[2];
            if (inputs >= 4) dl4.val = gain[3];
            if (inputs >= 5) dl5.val = gain[4];
            if (inputs >= 6) dl6.val = gain[5];
            if (inputs >= 7) dl7.val = gain[6];
            if (inputs >= 8) dl8.val = gain[7];

            if (inputs >= 1) dl1.valueChanged += Dl1_valueChanged;
            if (inputs >= 2) dl2.valueChanged += Dl2_valueChanged;
            if (inputs >= 3) dl3.valueChanged += Dl3_valueChanged;
            if (inputs >= 4) dl4.valueChanged += Dl4_valueChanged;
            if (inputs >= 5) dl5.valueChanged += Dl5_valueChanged;
            if (inputs >= 6) dl6.valueChanged += Dl6_valueChanged;
            if (inputs >= 7) dl7.valueChanged += Dl7_valueChanged;
            if (inputs >= 8) dl8.valueChanged += Dl8_valueChanged;
            
            processingType = ProcessingType.Processor;
        }

        private void Dl8_valueChanged(object sender, EventArgs e)
        {
            gain[7] = dl8.val;
        }

        private void Dl7_valueChanged(object sender, EventArgs e)
        {
            gain[6] = dl7.val;
        }

        private void Dl6_valueChanged(object sender, EventArgs e)
        {
            gain[5] = dl6.val;
        }

        private void Dl5_valueChanged(object sender, EventArgs e)
        {
            gain[4] = dl5.val;
        }

        private void Dl4_valueChanged(object sender, EventArgs e)
        {
            gain[3] = dl4.val;
        }

        private void Dl3_valueChanged(object sender, EventArgs e)
        {
            gain[2] = dl3.val;
        }

        private void Dl2_valueChanged(object sender, EventArgs e)
        {
            gain[1] = dl2.val;
        }
        private void Dl1_valueChanged(object sender, EventArgs e)
        {
            gain[0] = dl1.val;
        }

        public Mixer(): this(8)
        {
        }

        public Mixer(int _inputs):base()
        {
            inputs = _inputs;
            gain = new double[inputs];
            for (int i = 0; i < inputs; i++) gain[i] = -20;

            init();
        }

        public Mixer(SystemPanel _owner, BinaryReader src):base(_owner, src)
        {
            inputs = src.ReadInt32();
            gain = new double[inputs];

            for (int i = 0; i < inputs; i++)
            {
                gain[i] = src.ReadDouble();
            }

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write(inputs);
            for (int i = 0; i < inputs; i++)
                tgt.Write(gain[i]);

        }

        private void processChannel(int ch, DataBuffer dbin, DataBuffer dbout)
        {
            if (dbout == null) return;
            if (dbin == null) return;
            double a = Math.Pow(10, gain[ch] / 20);
            for (int i = 0; i < owner.blockSize; i++)
                dbout.data[i] += a * dbin.data[i];
        }

        public override void tick()
        {
            if (!_active)
                return;

            DataBuffer dbout = getOutputBuffer(ioO);

            if (inputs >= 1) processChannel(0, getInputBuffer(ioI1), dbout);
            if (inputs >= 2) processChannel(1, getInputBuffer(ioI2), dbout);
            if (inputs >= 3) processChannel(2, getInputBuffer(ioI3), dbout);
            if (inputs >= 4) processChannel(3, getInputBuffer(ioI4), dbout);
            if (inputs >= 5) processChannel(4, getInputBuffer(ioI5), dbout);
            if (inputs >= 6) processChannel(5, getInputBuffer(ioI6), dbout);
            if (inputs >= 7) processChannel(6, getInputBuffer(ioI7), dbout);
            if (inputs >= 8) processChannel(7, getInputBuffer(ioI8), dbout);

        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Mixer", "1 x" }; }
            public override RTForm Instantiate() { return new Mixer(1); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Mixer", "2 x" }; }
            public override RTForm Instantiate() { return new Mixer(2); }
        }
        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Mixer", "4 x" }; }
            public override RTForm Instantiate() { return new Mixer(4); }
        }
        class RegisterClass6 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Mixer", "6 x" }; }
            public override RTForm Instantiate() { return new Mixer(6); }
        }
        class RegisterClass8 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Mixer", "8 x" }; }
            public override RTForm Instantiate() { return new Mixer(8); }
        }
        public static void Register(List<RTObjectReference> l) {
            l.Add(new RegisterClass1());
            l.Add(new RegisterClass2());
            l.Add(new RegisterClass4());
            l.Add(new RegisterClass6());
            l.Add(new RegisterClass8());
        }
    }
}
