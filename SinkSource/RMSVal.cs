using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.SinkSource
{
    public class RMSVal : RTForm
    {

        public void InitializeComponent()
        {
            this.io1 = new AudioProcessor.RTIO();
            this.lv1 = new AudioProcessor.RTLevel();
            this.dlItime = new AudioProcessor.RTDial();
            this.bnAC = new AudioProcessor.RTButton();
            this.lv2 = new AudioProcessor.RTLevel();
            this.io2 = new AudioProcessor.RTIO();
            this.lv3 = new AudioProcessor.RTLevel();
            this.io3 = new AudioProcessor.RTIO();
            this.lv4 = new AudioProcessor.RTLevel();
            this.io4 = new AudioProcessor.RTIO();
            this.lv5 = new AudioProcessor.RTLevel();
            this.io5 = new AudioProcessor.RTIO();
            this.lv6 = new AudioProcessor.RTLevel();
            this.io6 = new AudioProcessor.RTIO();
            this.lv7 = new AudioProcessor.RTLevel();
            this.io7 = new AudioProcessor.RTIO();
            this.lv8 = new AudioProcessor.RTLevel();
            this.io8 = new AudioProcessor.RTIO();
            this.SuspendLayout();
            // 
            // io1
            // 
            this.io1.contactBackColor = System.Drawing.Color.Black;
            this.io1.contactColor = System.Drawing.Color.DimGray;
            this.io1.Location = new System.Drawing.Point(0, 30);
            this.io1.Name = "io1";
            this.io1.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io1.showTitle = true;
            this.io1.Size = new System.Drawing.Size(50, 20);
            this.io1.TabIndex = 0;
            this.io1.Text = "rtio1";
            this.io1.title = "1";
            this.io1.titleColor = System.Drawing.Color.DimGray;
            this.io1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io1.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // lv1
            // 
            this.lv1.displaySize = new System.Drawing.Size(150, 10);
            this.lv1.fillColor = System.Drawing.Color.LimeGreen;
            this.lv1.format = "F1";
            this.lv1.frameColor = System.Drawing.Color.DimGray;
            this.lv1.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv1.Location = new System.Drawing.Point(56, 30);
            this.lv1.logScale = false;
            this.lv1.max = 20D;
            this.lv1.min = -120D;
            this.lv1.Name = "lv1";
            this.lv1.openAngle = 150;
            this.lv1.pointColor = System.Drawing.Color.Red;
            this.lv1.Size = new System.Drawing.Size(227, 20);
            this.lv1.TabIndex = 1;
            this.lv1.Text = "rtLevel1";
            this.lv1.title = "level";
            this.lv1.titleColor = System.Drawing.Color.DimGray;
            this.lv1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv1.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.lv1.unit = "dB";
            this.lv1.value = -120D;
            this.lv1.valueColor = System.Drawing.Color.DimGray;
            this.lv1.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv1.valuePos = AudioProcessor.GraphicsUtil.TextAlignment.right;
            // 
            // dlItime
            // 
            this.dlItime.dialColor = System.Drawing.Color.Silver;
            this.dlItime.dialDiameter = 50D;
            this.dlItime.dialMarkColor = System.Drawing.Color.Red;
            this.dlItime.format = "F3";
            this.dlItime.Location = new System.Drawing.Point(289, 11);
            this.dlItime.logScale = true;
            this.dlItime.maxVal = 1D;
            this.dlItime.minVal = 0.001D;
            this.dlItime.Name = "dlItime";
            this.dlItime.scaleColor = System.Drawing.Color.Gold;
            this.dlItime.showScale = true;
            this.dlItime.showTitle = true;
            this.dlItime.showValue = true;
            this.dlItime.Size = new System.Drawing.Size(90, 100);
            this.dlItime.TabIndex = 2;
            this.dlItime.Text = "rtDial1";
            this.dlItime.title = "Integration";
            this.dlItime.titleColor = System.Drawing.Color.DimGray;
            this.dlItime.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlItime.unit = "s";
            this.dlItime.val = 0.1D;
            this.dlItime.valueColor = System.Drawing.Color.DimGray;
            this.dlItime.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // bnAC
            // 
            this.bnAC.buttonDim = new System.Drawing.Size(30, 15);
            this.bnAC.buttonState = false;
            this.bnAC.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bnAC.fillOffColor = System.Drawing.Color.Navy;
            this.bnAC.fillOnColor = System.Drawing.Color.DarkRed;
            this.bnAC.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnAC.frameOffColor = System.Drawing.Color.DimGray;
            this.bnAC.frameOnColor = System.Drawing.Color.Red;
            this.bnAC.Location = new System.Drawing.Point(317, 115);
            this.bnAC.Name = "bnAC";
            this.bnAC.offText = "DC";
            this.bnAC.onText = "AC";
            this.bnAC.Size = new System.Drawing.Size(31, 16);
            this.bnAC.TabIndex = 12;
            this.bnAC.Text = "rtButton2";
            this.bnAC.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnAC.textOffColor = System.Drawing.Color.DimGray;
            this.bnAC.textOnColor = System.Drawing.Color.Red;
            this.bnAC.title = "Button";
            this.bnAC.titleColor = System.Drawing.Color.DimGray;
            this.bnAC.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnAC.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // lv2
            // 
            this.lv2.displaySize = new System.Drawing.Size(150, 10);
            this.lv2.fillColor = System.Drawing.Color.LimeGreen;
            this.lv2.format = "F1";
            this.lv2.frameColor = System.Drawing.Color.DimGray;
            this.lv2.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv2.Location = new System.Drawing.Point(56, 56);
            this.lv2.logScale = false;
            this.lv2.max = 20D;
            this.lv2.min = -120D;
            this.lv2.Name = "lv2";
            this.lv2.openAngle = 150;
            this.lv2.pointColor = System.Drawing.Color.Red;
            this.lv2.Size = new System.Drawing.Size(227, 20);
            this.lv2.TabIndex = 14;
            this.lv2.Text = "rtLevel2";
            this.lv2.title = "level";
            this.lv2.titleColor = System.Drawing.Color.DimGray;
            this.lv2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv2.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.lv2.unit = "dB";
            this.lv2.value = -120D;
            this.lv2.valueColor = System.Drawing.Color.DimGray;
            this.lv2.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv2.valuePos = AudioProcessor.GraphicsUtil.TextAlignment.right;
            // 
            // io2
            // 
            this.io2.contactBackColor = System.Drawing.Color.Black;
            this.io2.contactColor = System.Drawing.Color.DimGray;
            this.io2.Location = new System.Drawing.Point(0, 56);
            this.io2.Name = "io2";
            this.io2.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io2.showTitle = true;
            this.io2.Size = new System.Drawing.Size(50, 20);
            this.io2.TabIndex = 13;
            this.io2.Text = "rtio2";
            this.io2.title = "2";
            this.io2.titleColor = System.Drawing.Color.DimGray;
            this.io2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io2.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // lv3
            // 
            this.lv3.displaySize = new System.Drawing.Size(150, 10);
            this.lv3.fillColor = System.Drawing.Color.LimeGreen;
            this.lv3.format = "F1";
            this.lv3.frameColor = System.Drawing.Color.DimGray;
            this.lv3.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv3.Location = new System.Drawing.Point(56, 82);
            this.lv3.logScale = false;
            this.lv3.max = 20D;
            this.lv3.min = -120D;
            this.lv3.Name = "lv3";
            this.lv3.openAngle = 150;
            this.lv3.pointColor = System.Drawing.Color.Red;
            this.lv3.Size = new System.Drawing.Size(227, 20);
            this.lv3.TabIndex = 16;
            this.lv3.Text = "rtLevel3";
            this.lv3.title = "level";
            this.lv3.titleColor = System.Drawing.Color.DimGray;
            this.lv3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv3.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.lv3.unit = "dB";
            this.lv3.value = -120D;
            this.lv3.valueColor = System.Drawing.Color.DimGray;
            this.lv3.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv3.valuePos = AudioProcessor.GraphicsUtil.TextAlignment.right;
            // 
            // io3
            // 
            this.io3.contactBackColor = System.Drawing.Color.Black;
            this.io3.contactColor = System.Drawing.Color.DimGray;
            this.io3.Location = new System.Drawing.Point(0, 82);
            this.io3.Name = "io3";
            this.io3.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io3.showTitle = true;
            this.io3.Size = new System.Drawing.Size(50, 20);
            this.io3.TabIndex = 15;
            this.io3.Text = "rtio3";
            this.io3.title = "3";
            this.io3.titleColor = System.Drawing.Color.DimGray;
            this.io3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io3.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // lv4
            // 
            this.lv4.displaySize = new System.Drawing.Size(150, 10);
            this.lv4.fillColor = System.Drawing.Color.LimeGreen;
            this.lv4.format = "F1";
            this.lv4.frameColor = System.Drawing.Color.DimGray;
            this.lv4.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv4.Location = new System.Drawing.Point(56, 108);
            this.lv4.logScale = false;
            this.lv4.max = 20D;
            this.lv4.min = -120D;
            this.lv4.Name = "lv4";
            this.lv4.openAngle = 150;
            this.lv4.pointColor = System.Drawing.Color.Red;
            this.lv4.Size = new System.Drawing.Size(227, 20);
            this.lv4.TabIndex = 18;
            this.lv4.Text = "rtLevel4";
            this.lv4.title = "level";
            this.lv4.titleColor = System.Drawing.Color.DimGray;
            this.lv4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv4.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.lv4.unit = "dB";
            this.lv4.value = -120D;
            this.lv4.valueColor = System.Drawing.Color.DimGray;
            this.lv4.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv4.valuePos = AudioProcessor.GraphicsUtil.TextAlignment.right;
            // 
            // io4
            // 
            this.io4.contactBackColor = System.Drawing.Color.Black;
            this.io4.contactColor = System.Drawing.Color.DimGray;
            this.io4.Location = new System.Drawing.Point(0, 108);
            this.io4.Name = "io4";
            this.io4.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io4.showTitle = true;
            this.io4.Size = new System.Drawing.Size(50, 20);
            this.io4.TabIndex = 17;
            this.io4.Text = "rtio4";
            this.io4.title = "4";
            this.io4.titleColor = System.Drawing.Color.DimGray;
            this.io4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io4.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // lv5
            // 
            this.lv5.displaySize = new System.Drawing.Size(150, 10);
            this.lv5.fillColor = System.Drawing.Color.LimeGreen;
            this.lv5.format = "F1";
            this.lv5.frameColor = System.Drawing.Color.DimGray;
            this.lv5.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv5.Location = new System.Drawing.Point(56, 134);
            this.lv5.logScale = false;
            this.lv5.max = 20D;
            this.lv5.min = -120D;
            this.lv5.Name = "lv5";
            this.lv5.openAngle = 150;
            this.lv5.pointColor = System.Drawing.Color.Red;
            this.lv5.Size = new System.Drawing.Size(227, 20);
            this.lv5.TabIndex = 20;
            this.lv5.Text = "rtLevel5";
            this.lv5.title = "level";
            this.lv5.titleColor = System.Drawing.Color.DimGray;
            this.lv5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv5.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.lv5.unit = "dB";
            this.lv5.value = -120D;
            this.lv5.valueColor = System.Drawing.Color.DimGray;
            this.lv5.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv5.valuePos = AudioProcessor.GraphicsUtil.TextAlignment.right;
            // 
            // io5
            // 
            this.io5.contactBackColor = System.Drawing.Color.Black;
            this.io5.contactColor = System.Drawing.Color.DimGray;
            this.io5.Location = new System.Drawing.Point(0, 134);
            this.io5.Name = "io5";
            this.io5.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io5.showTitle = true;
            this.io5.Size = new System.Drawing.Size(50, 20);
            this.io5.TabIndex = 19;
            this.io5.Text = "rtio5";
            this.io5.title = "5";
            this.io5.titleColor = System.Drawing.Color.DimGray;
            this.io5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io5.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // lv6
            // 
            this.lv6.displaySize = new System.Drawing.Size(150, 10);
            this.lv6.fillColor = System.Drawing.Color.LimeGreen;
            this.lv6.format = "F1";
            this.lv6.frameColor = System.Drawing.Color.DimGray;
            this.lv6.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv6.Location = new System.Drawing.Point(56, 160);
            this.lv6.logScale = false;
            this.lv6.max = 20D;
            this.lv6.min = -120D;
            this.lv6.Name = "lv6";
            this.lv6.openAngle = 150;
            this.lv6.pointColor = System.Drawing.Color.Red;
            this.lv6.Size = new System.Drawing.Size(227, 20);
            this.lv6.TabIndex = 22;
            this.lv6.Text = "rtLevel6";
            this.lv6.title = "level";
            this.lv6.titleColor = System.Drawing.Color.DimGray;
            this.lv6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv6.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.lv6.unit = "dB";
            this.lv6.value = -120D;
            this.lv6.valueColor = System.Drawing.Color.DimGray;
            this.lv6.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv6.valuePos = AudioProcessor.GraphicsUtil.TextAlignment.right;
            // 
            // io6
            // 
            this.io6.contactBackColor = System.Drawing.Color.Black;
            this.io6.contactColor = System.Drawing.Color.DimGray;
            this.io6.Location = new System.Drawing.Point(0, 160);
            this.io6.Name = "io6";
            this.io6.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io6.showTitle = true;
            this.io6.Size = new System.Drawing.Size(50, 20);
            this.io6.TabIndex = 21;
            this.io6.Text = "rtio6";
            this.io6.title = "6";
            this.io6.titleColor = System.Drawing.Color.DimGray;
            this.io6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io6.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // lv7
            // 
            this.lv7.displaySize = new System.Drawing.Size(150, 10);
            this.lv7.fillColor = System.Drawing.Color.LimeGreen;
            this.lv7.format = "F1";
            this.lv7.frameColor = System.Drawing.Color.DimGray;
            this.lv7.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv7.Location = new System.Drawing.Point(56, 186);
            this.lv7.logScale = false;
            this.lv7.max = 20D;
            this.lv7.min = -120D;
            this.lv7.Name = "lv7";
            this.lv7.openAngle = 150;
            this.lv7.pointColor = System.Drawing.Color.Red;
            this.lv7.Size = new System.Drawing.Size(227, 20);
            this.lv7.TabIndex = 24;
            this.lv7.Text = "rtLevel7";
            this.lv7.title = "level";
            this.lv7.titleColor = System.Drawing.Color.DimGray;
            this.lv7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv7.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.lv7.unit = "dB";
            this.lv7.value = -120D;
            this.lv7.valueColor = System.Drawing.Color.DimGray;
            this.lv7.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv7.valuePos = AudioProcessor.GraphicsUtil.TextAlignment.right;
            // 
            // io7
            // 
            this.io7.contactBackColor = System.Drawing.Color.Black;
            this.io7.contactColor = System.Drawing.Color.DimGray;
            this.io7.Location = new System.Drawing.Point(0, 186);
            this.io7.Name = "io7";
            this.io7.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io7.showTitle = true;
            this.io7.Size = new System.Drawing.Size(50, 20);
            this.io7.TabIndex = 23;
            this.io7.Text = "rtio7";
            this.io7.title = "7";
            this.io7.titleColor = System.Drawing.Color.DimGray;
            this.io7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io7.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // lv8
            // 
            this.lv8.displaySize = new System.Drawing.Size(150, 10);
            this.lv8.fillColor = System.Drawing.Color.LimeGreen;
            this.lv8.format = "F1";
            this.lv8.frameColor = System.Drawing.Color.DimGray;
            this.lv8.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv8.Location = new System.Drawing.Point(56, 212);
            this.lv8.logScale = false;
            this.lv8.max = 20D;
            this.lv8.min = -120D;
            this.lv8.Name = "lv8";
            this.lv8.openAngle = 150;
            this.lv8.pointColor = System.Drawing.Color.Red;
            this.lv8.Size = new System.Drawing.Size(227, 20);
            this.lv8.TabIndex = 26;
            this.lv8.Text = "rtLevel8";
            this.lv8.title = "level";
            this.lv8.titleColor = System.Drawing.Color.DimGray;
            this.lv8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv8.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.lv8.unit = "dB";
            this.lv8.value = -120D;
            this.lv8.valueColor = System.Drawing.Color.DimGray;
            this.lv8.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv8.valuePos = AudioProcessor.GraphicsUtil.TextAlignment.right;
            // 
            // io8
            // 
            this.io8.contactBackColor = System.Drawing.Color.Black;
            this.io8.contactColor = System.Drawing.Color.DimGray;
            this.io8.Location = new System.Drawing.Point(0, 212);
            this.io8.Name = "io8";
            this.io8.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.io8.showTitle = true;
            this.io8.Size = new System.Drawing.Size(50, 20);
            this.io8.TabIndex = 25;
            this.io8.Text = "rtio8";
            this.io8.title = "8";
            this.io8.titleColor = System.Drawing.Color.DimGray;
            this.io8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io8.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // RMSVal
            // 
            this.canShrink = false;
            this.Controls.Add(this.lv8);
            this.Controls.Add(this.io8);
            this.Controls.Add(this.lv7);
            this.Controls.Add(this.io7);
            this.Controls.Add(this.lv6);
            this.Controls.Add(this.io6);
            this.Controls.Add(this.lv5);
            this.Controls.Add(this.io5);
            this.Controls.Add(this.lv4);
            this.Controls.Add(this.io4);
            this.Controls.Add(this.lv3);
            this.Controls.Add(this.io3);
            this.Controls.Add(this.lv2);
            this.Controls.Add(this.io2);
            this.Controls.Add(this.bnAC);
            this.Controls.Add(this.dlItime);
            this.Controls.Add(this.lv1);
            this.Controls.Add(this.io1);
            this.Name = "RMSVal";
            this.Size = new System.Drawing.Size(406, 237);
            this.title = "RMS";
            this.ResumeLayout(false);

        }

        double windowLength;
        Boolean removeDC;

        int channels;
        Boolean resetCount;

        double[] S;
        double[] S2;

        int[] count;
        int countMax;
        private RTIO io1;
        private RTLevel lv1;
        private RTDial dlItime;
        private RTButton bnAC;
        private RTLevel lv2;
        private RTIO io2;
        private RTLevel lv3;
        private RTIO io3;
        private RTLevel lv4;
        private RTIO io4;
        private RTLevel lv5;
        private RTIO io5;
        private RTLevel lv6;
        private RTIO io6;
        private RTLevel lv7;
        private RTIO io7;
        private RTLevel lv8;
        private RTIO io8;
        double[] value;

        private RTIO[] ioX;
        private RTLevel[] lvX;

        private void init()
        {
            InitializeComponent();

            ioX = new RTIO[channels];
            lvX = new RTLevel[channels];

            int h = Height;
            if (channels < 8) { io8.Hide(); lv8.Hide(); h = io8.Location.Y; }
            if (channels < 7) { io7.Hide(); lv7.Hide(); h = io7.Location.Y; }
            if (channels < 6) { io6.Hide(); lv6.Hide(); h = io6.Location.Y; }
            if (channels < 5) { io5.Hide(); lv5.Hide(); h = io6.Location.Y; }
            if (channels < 4) { io4.Hide(); lv4.Hide(); h = io6.Location.Y; }
            if (channels < 3) { io3.Hide(); lv3.Hide(); h = io6.Location.Y; }
            if (channels < 2) { io2.Hide(); lv2.Hide(); h = io6.Location.Y; }
            Height = h;
            if (channels > 0) { ioX[0] = io1; lvX[0] = lv1; }
            if (channels > 1) { ioX[1] = io2; lvX[1] = lv2; }
            if (channels > 2) { ioX[2] = io3; lvX[2] = lv3; }
            if (channels > 3) { ioX[3] = io4; lvX[3] = lv4; }
            if (channels > 4) { ioX[4] = io5; lvX[4] = lv5; }
            if (channels > 5) { ioX[5] = io6; lvX[5] = lv6; }
            if (channels > 6) { ioX[6] = io7; lvX[6] = lv7; }
            if (channels > 7) { ioX[7] = io8; lvX[7] = lv8; }

            dlItime.val = windowLength;
            bnAC.buttonState = removeDC;

            dlItime.valueChanged += DlItime_valueChanged;
            bnAC.buttonStateChanged += BnAC_buttonStateChanged;

            resetCount = false;
            count = new int[channels];
            S = new double[channels];
            S2 = new double[channels];
            value = new double[channels];
            for (int i = 0; i < channels; i++)
                value[i] = -120;

            for (int i = 0; i < channels; i++)
                lvX[i].value = value[i];

            processingType = ProcessingType.Sink;
        }

        private void BnAC_buttonStateChanged(object sender, EventArgs e)
        {
            removeDC = bnAC.buttonState;
        }

        private void DlItime_valueChanged(object sender, EventArgs e)
        {
            windowLength = dlItime.val;
            resetCount = true;
        }

        public RMSVal() : this(8)
        {
        }

        public RMSVal(int _channels):base()
        {
            channels = _channels;
            windowLength = 0.1;
            removeDC = false;

            init();
        }

        public RMSVal(SystemPanel _owner, BinaryReader src):base(_owner,src)
        {
            channels = src.ReadInt32();
            windowLength = src.ReadDouble();
            removeDC = src.ReadBoolean();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(channels);
            tgt.Write(windowLength);
            tgt.Write(removeDC);
        }

        private void newValue(int channel, double v)
        {
            if (v != value[channel])
            {
                value[channel] = v;
                lvX[channel].value = v;
            }
        }

        public override void tick()
        {
            if (!_active) return;

            countMax = (int)Math.Floor(windowLength * owner.sampleRate + 0.5);

            if (resetCount)
            {
                for (int i=0;i<channels;i++)
                {
                    count[i] = 0;
                    S[i] = S2[i] = 0;
                }
                resetCount = false;
            }

            for (int j=0;j<channels;j++)
            {
                if (ioX[j].connectedTo != null)
                {
                    DataBuffer db = ioX[j].connectedTo.output;
                    for (int i = 0; i < owner.blockSize; i++)
                    {
                        S[j] += db.data[i];
                        S2[j] += db.data[i] * db.data[i];
                        count[j]++;
                        if (count[j] >= countMax)
                        {
                            double v = Math.Sqrt(S2[j] / count[j]);
                            if (removeDC)
                                v -= Math.Abs(S[j]) / count[j];
                            if (v < 1e-6)
                                newValue(j, -120);
                            else
                                newValue(j, 20.0 * Math.Log10(v));
                            count[j] = 0;
                            S[j] = S2[j] = 0;
                        }
                    }
                }
                else
                {
                    count[j] = 0;
                    S[j] = S2[j] = 0;
                    newValue(j,-120);
                }

            }
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Tools", "RMS Meter", "1 x" }; }
            public override RTForm Instantiate() { return new RMSVal(1); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Tools", "RMS Meter", "2 x" }; }
            public override RTForm Instantiate() { return new RMSVal(2); }
        }
        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Tools", "RMS Meter", "4 x" }; }
            public override RTForm Instantiate() { return new RMSVal(4); }
        }
        class RegisterClass8 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Tools", "RMS Meter", "8 x" }; }
            public override RTForm Instantiate() { return new RMSVal(8); }
        }
        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
            l.Add(new RegisterClass2());
            l.Add(new RegisterClass4());
            l.Add(new RegisterClass8());
        }


    }
}
