using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.Processing
{
    class Agc : RTForm
    {
        public void InitializeComponent()
        {
            this.ioO1 = new AudioProcessor.RTIO();
            this.ioI1 = new AudioProcessor.RTIO();
            this.ioGain = new AudioProcessor.RTIO();
            this.dlGain = new AudioProcessor.RTDial();
            this.lv1 = new AudioProcessor.RTLevel();
            this.lv2 = new AudioProcessor.RTLevel();
            this.ioO2 = new AudioProcessor.RTIO();
            this.ioI2 = new AudioProcessor.RTIO();
            this.lv3 = new AudioProcessor.RTLevel();
            this.ioO3 = new AudioProcessor.RTIO();
            this.ioI3 = new AudioProcessor.RTIO();
            this.lv4 = new AudioProcessor.RTLevel();
            this.ioO4 = new AudioProcessor.RTIO();
            this.ioI4 = new AudioProcessor.RTIO();
            this.lv5 = new AudioProcessor.RTLevel();
            this.ioO5 = new AudioProcessor.RTIO();
            this.ioI5 = new AudioProcessor.RTIO();
            this.lv6 = new AudioProcessor.RTLevel();
            this.ioO6 = new AudioProcessor.RTIO();
            this.ioI6 = new AudioProcessor.RTIO();
            this.lv7 = new AudioProcessor.RTLevel();
            this.ioO7 = new AudioProcessor.RTIO();
            this.ioI7 = new AudioProcessor.RTIO();
            this.lv8 = new AudioProcessor.RTLevel();
            this.ioO8 = new AudioProcessor.RTIO();
            this.ioI8 = new AudioProcessor.RTIO();
            this.dlItime = new AudioProcessor.RTDial();
            this.SuspendLayout();
            // 
            // ioO1
            // 
            this.ioO1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO1.contactBackColor = System.Drawing.Color.Black;
            this.ioO1.contactColor = System.Drawing.Color.DimGray;
            this.ioO1.Location = new System.Drawing.Point(387, 59);
            this.ioO1.Name = "ioO1";
            this.ioO1.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO1.showTitle = true;
            this.ioO1.Size = new System.Drawing.Size(34, 20);
            this.ioO1.TabIndex = 12;
            this.ioO1.Text = "rtio3";
            this.ioO1.title = "1";
            this.ioO1.titleColor = System.Drawing.Color.DimGray;
            this.ioO1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO1.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioI1
            // 
            this.ioI1.contactBackColor = System.Drawing.Color.Black;
            this.ioI1.contactColor = System.Drawing.Color.DimGray;
            this.ioI1.Location = new System.Drawing.Point(0, 59);
            this.ioI1.Name = "ioI1";
            this.ioI1.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI1.showTitle = true;
            this.ioI1.Size = new System.Drawing.Size(40, 20);
            this.ioI1.TabIndex = 11;
            this.ioI1.Text = "ioI1";
            this.ioI1.title = "M";
            this.ioI1.titleColor = System.Drawing.Color.DimGray;
            this.ioI1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI1.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioGain
            // 
            this.ioGain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioGain.contactBackColor = System.Drawing.Color.Black;
            this.ioGain.contactColor = System.Drawing.Color.DimGray;
            this.ioGain.Location = new System.Drawing.Point(387, 33);
            this.ioGain.Name = "ioGain";
            this.ioGain.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioGain.showTitle = true;
            this.ioGain.Size = new System.Drawing.Size(34, 20);
            this.ioGain.TabIndex = 14;
            this.ioGain.Text = "rtio3";
            this.ioGain.title = "g";
            this.ioGain.titleColor = System.Drawing.Color.DimGray;
            this.ioGain.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioGain.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // dlGain
            // 
            this.dlGain.dialColor = System.Drawing.Color.Silver;
            this.dlGain.dialDiameter = 50D;
            this.dlGain.dialMarkColor = System.Drawing.Color.Red;
            this.dlGain.format = "F1";
            this.dlGain.Location = new System.Drawing.Point(213, 17);
            this.dlGain.logScale = false;
            this.dlGain.maxVal = 100D;
            this.dlGain.minVal = -100D;
            this.dlGain.Name = "dlGain";
            this.dlGain.scaleColor = System.Drawing.Color.Gold;
            this.dlGain.showScale = true;
            this.dlGain.showTitle = true;
            this.dlGain.showValue = true;
            this.dlGain.Size = new System.Drawing.Size(80, 100);
            this.dlGain.TabIndex = 15;
            this.dlGain.Text = "rtDial1";
            this.dlGain.title = "max gain";
            this.dlGain.titleColor = System.Drawing.Color.DimGray;
            this.dlGain.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlGain.unit = "dB";
            this.dlGain.val = -6D;
            this.dlGain.valueColor = System.Drawing.Color.DimGray;
            this.dlGain.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // lv1
            // 
            this.lv1.displaySize = new System.Drawing.Size(80, 10);
            this.lv1.fillColor = System.Drawing.Color.LimeGreen;
            this.lv1.format = "F1";
            this.lv1.frameColor = System.Drawing.Color.DimGray;
            this.lv1.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv1.Location = new System.Drawing.Point(47, 59);
            this.lv1.logScale = false;
            this.lv1.max = 40D;
            this.lv1.min = -120D;
            this.lv1.Name = "lv1";
            this.lv1.openAngle = 150;
            this.lv1.pointColor = System.Drawing.Color.Red;
            this.lv1.Size = new System.Drawing.Size(160, 20);
            this.lv1.TabIndex = 16;
            this.lv1.Text = "rtLevel1";
            this.lv1.title = "level";
            this.lv1.titleColor = System.Drawing.Color.DimGray;
            this.lv1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv1.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.lv1.unit = "dBFS";
            this.lv1.value = 0D;
            this.lv1.valueColor = System.Drawing.Color.DimGray;
            this.lv1.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv1.valuePos = AudioProcessor.GraphicsUtil.TextAlignment.right;
            // 
            // lv2
            // 
            this.lv2.displaySize = new System.Drawing.Size(80, 10);
            this.lv2.fillColor = System.Drawing.Color.LimeGreen;
            this.lv2.format = "F1";
            this.lv2.frameColor = System.Drawing.Color.DimGray;
            this.lv2.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv2.Location = new System.Drawing.Point(47, 85);
            this.lv2.logScale = false;
            this.lv2.max = 40D;
            this.lv2.min = -120D;
            this.lv2.Name = "lv2";
            this.lv2.openAngle = 150;
            this.lv2.pointColor = System.Drawing.Color.Red;
            this.lv2.Size = new System.Drawing.Size(160, 20);
            this.lv2.TabIndex = 19;
            this.lv2.Text = "rtLevel2";
            this.lv2.title = "level";
            this.lv2.titleColor = System.Drawing.Color.DimGray;
            this.lv2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv2.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.lv2.unit = "dBFS";
            this.lv2.value = 0D;
            this.lv2.valueColor = System.Drawing.Color.DimGray;
            this.lv2.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv2.valuePos = AudioProcessor.GraphicsUtil.TextAlignment.right;
            // 
            // ioO2
            // 
            this.ioO2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO2.contactBackColor = System.Drawing.Color.Black;
            this.ioO2.contactColor = System.Drawing.Color.DimGray;
            this.ioO2.Location = new System.Drawing.Point(387, 85);
            this.ioO2.Name = "ioO2";
            this.ioO2.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO2.showTitle = true;
            this.ioO2.Size = new System.Drawing.Size(34, 20);
            this.ioO2.TabIndex = 18;
            this.ioO2.Text = "rtio3";
            this.ioO2.title = "2";
            this.ioO2.titleColor = System.Drawing.Color.DimGray;
            this.ioO2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO2.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioI2
            // 
            this.ioI2.contactBackColor = System.Drawing.Color.Black;
            this.ioI2.contactColor = System.Drawing.Color.DimGray;
            this.ioI2.Location = new System.Drawing.Point(0, 85);
            this.ioI2.Name = "ioI2";
            this.ioI2.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI2.showTitle = true;
            this.ioI2.Size = new System.Drawing.Size(40, 20);
            this.ioI2.TabIndex = 17;
            this.ioI2.Text = "rtio1";
            this.ioI2.title = "2";
            this.ioI2.titleColor = System.Drawing.Color.DimGray;
            this.ioI2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI2.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // lv3
            // 
            this.lv3.displaySize = new System.Drawing.Size(80, 10);
            this.lv3.fillColor = System.Drawing.Color.LimeGreen;
            this.lv3.format = "F1";
            this.lv3.frameColor = System.Drawing.Color.DimGray;
            this.lv3.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv3.Location = new System.Drawing.Point(47, 111);
            this.lv3.logScale = false;
            this.lv3.max = 40D;
            this.lv3.min = -120D;
            this.lv3.Name = "lv3";
            this.lv3.openAngle = 150;
            this.lv3.pointColor = System.Drawing.Color.Red;
            this.lv3.Size = new System.Drawing.Size(160, 20);
            this.lv3.TabIndex = 22;
            this.lv3.Text = "rtLevel3";
            this.lv3.title = "level";
            this.lv3.titleColor = System.Drawing.Color.DimGray;
            this.lv3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv3.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.lv3.unit = "dBFS";
            this.lv3.value = 0D;
            this.lv3.valueColor = System.Drawing.Color.DimGray;
            this.lv3.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv3.valuePos = AudioProcessor.GraphicsUtil.TextAlignment.right;
            // 
            // ioO3
            // 
            this.ioO3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO3.contactBackColor = System.Drawing.Color.Black;
            this.ioO3.contactColor = System.Drawing.Color.DimGray;
            this.ioO3.Location = new System.Drawing.Point(387, 111);
            this.ioO3.Name = "ioO3";
            this.ioO3.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO3.showTitle = true;
            this.ioO3.Size = new System.Drawing.Size(34, 20);
            this.ioO3.TabIndex = 21;
            this.ioO3.Text = "rtio3";
            this.ioO3.title = "3";
            this.ioO3.titleColor = System.Drawing.Color.DimGray;
            this.ioO3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO3.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioI3
            // 
            this.ioI3.contactBackColor = System.Drawing.Color.Black;
            this.ioI3.contactColor = System.Drawing.Color.DimGray;
            this.ioI3.Location = new System.Drawing.Point(0, 111);
            this.ioI3.Name = "ioI3";
            this.ioI3.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI3.showTitle = true;
            this.ioI3.Size = new System.Drawing.Size(40, 20);
            this.ioI3.TabIndex = 20;
            this.ioI3.Text = "rtio1";
            this.ioI3.title = "3";
            this.ioI3.titleColor = System.Drawing.Color.DimGray;
            this.ioI3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI3.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // lv4
            // 
            this.lv4.displaySize = new System.Drawing.Size(80, 10);
            this.lv4.fillColor = System.Drawing.Color.LimeGreen;
            this.lv4.format = "F1";
            this.lv4.frameColor = System.Drawing.Color.DimGray;
            this.lv4.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv4.Location = new System.Drawing.Point(47, 137);
            this.lv4.logScale = false;
            this.lv4.max = 40D;
            this.lv4.min = -120D;
            this.lv4.Name = "lv4";
            this.lv4.openAngle = 150;
            this.lv4.pointColor = System.Drawing.Color.Red;
            this.lv4.Size = new System.Drawing.Size(160, 20);
            this.lv4.TabIndex = 25;
            this.lv4.Text = "rtLevel4";
            this.lv4.title = "level";
            this.lv4.titleColor = System.Drawing.Color.DimGray;
            this.lv4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv4.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.lv4.unit = "dBFS";
            this.lv4.value = 0D;
            this.lv4.valueColor = System.Drawing.Color.DimGray;
            this.lv4.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv4.valuePos = AudioProcessor.GraphicsUtil.TextAlignment.right;
            // 
            // ioO4
            // 
            this.ioO4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO4.contactBackColor = System.Drawing.Color.Black;
            this.ioO4.contactColor = System.Drawing.Color.DimGray;
            this.ioO4.Location = new System.Drawing.Point(387, 137);
            this.ioO4.Name = "ioO4";
            this.ioO4.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO4.showTitle = true;
            this.ioO4.Size = new System.Drawing.Size(34, 20);
            this.ioO4.TabIndex = 24;
            this.ioO4.Text = "rtio3";
            this.ioO4.title = "4";
            this.ioO4.titleColor = System.Drawing.Color.DimGray;
            this.ioO4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO4.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioI4
            // 
            this.ioI4.contactBackColor = System.Drawing.Color.Black;
            this.ioI4.contactColor = System.Drawing.Color.DimGray;
            this.ioI4.Location = new System.Drawing.Point(0, 137);
            this.ioI4.Name = "ioI4";
            this.ioI4.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI4.showTitle = true;
            this.ioI4.Size = new System.Drawing.Size(40, 20);
            this.ioI4.TabIndex = 23;
            this.ioI4.Text = "rtio1";
            this.ioI4.title = "4";
            this.ioI4.titleColor = System.Drawing.Color.DimGray;
            this.ioI4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI4.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // lv5
            // 
            this.lv5.displaySize = new System.Drawing.Size(80, 10);
            this.lv5.fillColor = System.Drawing.Color.LimeGreen;
            this.lv5.format = "F1";
            this.lv5.frameColor = System.Drawing.Color.DimGray;
            this.lv5.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv5.Location = new System.Drawing.Point(47, 163);
            this.lv5.logScale = false;
            this.lv5.max = 40D;
            this.lv5.min = -120D;
            this.lv5.Name = "lv5";
            this.lv5.openAngle = 150;
            this.lv5.pointColor = System.Drawing.Color.Red;
            this.lv5.Size = new System.Drawing.Size(160, 20);
            this.lv5.TabIndex = 28;
            this.lv5.Text = "rtLevel5";
            this.lv5.title = "level";
            this.lv5.titleColor = System.Drawing.Color.DimGray;
            this.lv5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv5.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.lv5.unit = "dBFS";
            this.lv5.value = 0D;
            this.lv5.valueColor = System.Drawing.Color.DimGray;
            this.lv5.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv5.valuePos = AudioProcessor.GraphicsUtil.TextAlignment.right;
            // 
            // ioO5
            // 
            this.ioO5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO5.contactBackColor = System.Drawing.Color.Black;
            this.ioO5.contactColor = System.Drawing.Color.DimGray;
            this.ioO5.Location = new System.Drawing.Point(387, 163);
            this.ioO5.Name = "ioO5";
            this.ioO5.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO5.showTitle = true;
            this.ioO5.Size = new System.Drawing.Size(34, 20);
            this.ioO5.TabIndex = 27;
            this.ioO5.Text = "rtio3";
            this.ioO5.title = "5";
            this.ioO5.titleColor = System.Drawing.Color.DimGray;
            this.ioO5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO5.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioI5
            // 
            this.ioI5.contactBackColor = System.Drawing.Color.Black;
            this.ioI5.contactColor = System.Drawing.Color.DimGray;
            this.ioI5.Location = new System.Drawing.Point(0, 163);
            this.ioI5.Name = "ioI5";
            this.ioI5.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI5.showTitle = true;
            this.ioI5.Size = new System.Drawing.Size(40, 20);
            this.ioI5.TabIndex = 26;
            this.ioI5.Text = "rtio1";
            this.ioI5.title = "5";
            this.ioI5.titleColor = System.Drawing.Color.DimGray;
            this.ioI5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI5.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // lv6
            // 
            this.lv6.displaySize = new System.Drawing.Size(80, 10);
            this.lv6.fillColor = System.Drawing.Color.LimeGreen;
            this.lv6.format = "F1";
            this.lv6.frameColor = System.Drawing.Color.DimGray;
            this.lv6.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv6.Location = new System.Drawing.Point(47, 189);
            this.lv6.logScale = false;
            this.lv6.max = 40D;
            this.lv6.min = -120D;
            this.lv6.Name = "lv6";
            this.lv6.openAngle = 150;
            this.lv6.pointColor = System.Drawing.Color.Red;
            this.lv6.Size = new System.Drawing.Size(160, 20);
            this.lv6.TabIndex = 31;
            this.lv6.Text = "rtLevel6";
            this.lv6.title = "level";
            this.lv6.titleColor = System.Drawing.Color.DimGray;
            this.lv6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv6.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.lv6.unit = "dBFS";
            this.lv6.value = 0D;
            this.lv6.valueColor = System.Drawing.Color.DimGray;
            this.lv6.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv6.valuePos = AudioProcessor.GraphicsUtil.TextAlignment.right;
            // 
            // ioO6
            // 
            this.ioO6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO6.contactBackColor = System.Drawing.Color.Black;
            this.ioO6.contactColor = System.Drawing.Color.DimGray;
            this.ioO6.Location = new System.Drawing.Point(387, 189);
            this.ioO6.Name = "ioO6";
            this.ioO6.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO6.showTitle = true;
            this.ioO6.Size = new System.Drawing.Size(34, 20);
            this.ioO6.TabIndex = 30;
            this.ioO6.Text = "rtio3";
            this.ioO6.title = "6";
            this.ioO6.titleColor = System.Drawing.Color.DimGray;
            this.ioO6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO6.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioI6
            // 
            this.ioI6.contactBackColor = System.Drawing.Color.Black;
            this.ioI6.contactColor = System.Drawing.Color.DimGray;
            this.ioI6.Location = new System.Drawing.Point(0, 189);
            this.ioI6.Name = "ioI6";
            this.ioI6.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI6.showTitle = true;
            this.ioI6.Size = new System.Drawing.Size(40, 20);
            this.ioI6.TabIndex = 29;
            this.ioI6.Text = "rtio1";
            this.ioI6.title = "6";
            this.ioI6.titleColor = System.Drawing.Color.DimGray;
            this.ioI6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI6.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // lv7
            // 
            this.lv7.displaySize = new System.Drawing.Size(80, 10);
            this.lv7.fillColor = System.Drawing.Color.LimeGreen;
            this.lv7.format = "F1";
            this.lv7.frameColor = System.Drawing.Color.DimGray;
            this.lv7.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv7.Location = new System.Drawing.Point(47, 215);
            this.lv7.logScale = false;
            this.lv7.max = 40D;
            this.lv7.min = -120D;
            this.lv7.Name = "lv7";
            this.lv7.openAngle = 150;
            this.lv7.pointColor = System.Drawing.Color.Red;
            this.lv7.Size = new System.Drawing.Size(160, 20);
            this.lv7.TabIndex = 34;
            this.lv7.Text = "rtLevel7";
            this.lv7.title = "level";
            this.lv7.titleColor = System.Drawing.Color.DimGray;
            this.lv7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv7.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.lv7.unit = "dBFS";
            this.lv7.value = 0D;
            this.lv7.valueColor = System.Drawing.Color.DimGray;
            this.lv7.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv7.valuePos = AudioProcessor.GraphicsUtil.TextAlignment.right;
            // 
            // ioO7
            // 
            this.ioO7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO7.contactBackColor = System.Drawing.Color.Black;
            this.ioO7.contactColor = System.Drawing.Color.DimGray;
            this.ioO7.Location = new System.Drawing.Point(387, 215);
            this.ioO7.Name = "ioO7";
            this.ioO7.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO7.showTitle = true;
            this.ioO7.Size = new System.Drawing.Size(34, 20);
            this.ioO7.TabIndex = 33;
            this.ioO7.Text = "rtio3";
            this.ioO7.title = "7";
            this.ioO7.titleColor = System.Drawing.Color.DimGray;
            this.ioO7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO7.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioI7
            // 
            this.ioI7.contactBackColor = System.Drawing.Color.Black;
            this.ioI7.contactColor = System.Drawing.Color.DimGray;
            this.ioI7.Location = new System.Drawing.Point(0, 215);
            this.ioI7.Name = "ioI7";
            this.ioI7.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI7.showTitle = true;
            this.ioI7.Size = new System.Drawing.Size(40, 20);
            this.ioI7.TabIndex = 32;
            this.ioI7.Text = "rtio1";
            this.ioI7.title = "7";
            this.ioI7.titleColor = System.Drawing.Color.DimGray;
            this.ioI7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI7.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // lv8
            // 
            this.lv8.displaySize = new System.Drawing.Size(80, 10);
            this.lv8.fillColor = System.Drawing.Color.LimeGreen;
            this.lv8.format = "F1";
            this.lv8.frameColor = System.Drawing.Color.DimGray;
            this.lv8.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv8.Location = new System.Drawing.Point(48, 241);
            this.lv8.logScale = false;
            this.lv8.max = 40D;
            this.lv8.min = -120D;
            this.lv8.Name = "lv8";
            this.lv8.openAngle = 150;
            this.lv8.pointColor = System.Drawing.Color.Red;
            this.lv8.Size = new System.Drawing.Size(160, 20);
            this.lv8.TabIndex = 37;
            this.lv8.Text = "rtLevel8";
            this.lv8.title = "level";
            this.lv8.titleColor = System.Drawing.Color.DimGray;
            this.lv8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv8.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.lv8.unit = "dBFS";
            this.lv8.value = 0D;
            this.lv8.valueColor = System.Drawing.Color.DimGray;
            this.lv8.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv8.valuePos = AudioProcessor.GraphicsUtil.TextAlignment.right;
            // 
            // ioO8
            // 
            this.ioO8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO8.contactBackColor = System.Drawing.Color.Black;
            this.ioO8.contactColor = System.Drawing.Color.DimGray;
            this.ioO8.Location = new System.Drawing.Point(388, 241);
            this.ioO8.Name = "ioO8";
            this.ioO8.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO8.showTitle = true;
            this.ioO8.Size = new System.Drawing.Size(34, 20);
            this.ioO8.TabIndex = 36;
            this.ioO8.Text = "rtio3";
            this.ioO8.title = "8";
            this.ioO8.titleColor = System.Drawing.Color.DimGray;
            this.ioO8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO8.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioI8
            // 
            this.ioI8.contactBackColor = System.Drawing.Color.Black;
            this.ioI8.contactColor = System.Drawing.Color.DimGray;
            this.ioI8.Location = new System.Drawing.Point(1, 241);
            this.ioI8.Name = "ioI8";
            this.ioI8.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI8.showTitle = true;
            this.ioI8.Size = new System.Drawing.Size(40, 20);
            this.ioI8.TabIndex = 35;
            this.ioI8.Text = "rtio1";
            this.ioI8.title = "8";
            this.ioI8.titleColor = System.Drawing.Color.DimGray;
            this.ioI8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI8.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // dlItime
            // 
            this.dlItime.dialColor = System.Drawing.Color.Silver;
            this.dlItime.dialDiameter = 50D;
            this.dlItime.dialMarkColor = System.Drawing.Color.Red;
            this.dlItime.format = "F1";
            this.dlItime.Location = new System.Drawing.Point(299, 17);
            this.dlItime.logScale = true;
            this.dlItime.maxVal = 1000D;
            this.dlItime.minVal = 10D;
            this.dlItime.Name = "dlItime";
            this.dlItime.scaleColor = System.Drawing.Color.Gold;
            this.dlItime.showScale = true;
            this.dlItime.showTitle = true;
            this.dlItime.showValue = true;
            this.dlItime.Size = new System.Drawing.Size(80, 100);
            this.dlItime.TabIndex = 38;
            this.dlItime.Text = "rtDial1";
            this.dlItime.title = "int. time";
            this.dlItime.titleColor = System.Drawing.Color.DimGray;
            this.dlItime.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlItime.unit = "ms";
            this.dlItime.val = 100D;
            this.dlItime.valueColor = System.Drawing.Color.DimGray;
            this.dlItime.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // Agc
            // 
            this.canShrink = false;
            this.Controls.Add(this.dlItime);
            this.Controls.Add(this.lv8);
            this.Controls.Add(this.ioO8);
            this.Controls.Add(this.ioI8);
            this.Controls.Add(this.lv7);
            this.Controls.Add(this.ioO7);
            this.Controls.Add(this.ioI7);
            this.Controls.Add(this.lv6);
            this.Controls.Add(this.ioO6);
            this.Controls.Add(this.ioI6);
            this.Controls.Add(this.lv5);
            this.Controls.Add(this.ioO5);
            this.Controls.Add(this.ioI5);
            this.Controls.Add(this.lv4);
            this.Controls.Add(this.ioO4);
            this.Controls.Add(this.ioI4);
            this.Controls.Add(this.lv3);
            this.Controls.Add(this.ioO3);
            this.Controls.Add(this.ioI3);
            this.Controls.Add(this.lv2);
            this.Controls.Add(this.ioO2);
            this.Controls.Add(this.ioI2);
            this.Controls.Add(this.lv1);
            this.Controls.Add(this.dlGain);
            this.Controls.Add(this.ioGain);
            this.Controls.Add(this.ioO1);
            this.Controls.Add(this.ioI1);
            this.Name = "Agc";
            this.Size = new System.Drawing.Size(421, 268);
            this.title = "AGC";
            this.ResumeLayout(false);

        }

        double gain;
        int inputs;

        int count;
        int countMax;

        double[] abuf;
        double[] S;
        double[] S2;
        double[] value;

        double tau;
        double gainmax;
        private RTIO ioO1;
        private RTIO ioI1;
        private RTIO ioGain;
        private RTDial dlGain;
        private RTLevel lv1;
        private RTLevel lv2;
        private RTIO ioO2;
        private RTIO ioI2;
        private RTLevel lv3;
        private RTIO ioO3;
        private RTIO ioI3;
        private RTLevel lv4;
        private RTIO ioO4;
        private RTIO ioI4;
        private RTLevel lv5;
        private RTIO ioO5;
        private RTIO ioI5;
        private RTLevel lv6;
        private RTIO ioO6;
        private RTIO ioI6;
        private RTLevel lv7;
        private RTIO ioO7;
        private RTIO ioI7;
        private RTLevel lv8;
        private RTIO ioO8;
        private RTIO ioI8;
        private RTDial dlItime;
        RMSdetector main;

        private double min(double a, double b)
        {
            return (a < b) ? a : b;
        }

        private void init()
        {
            InitializeComponent();

            int h = Height;
            if (inputs < 8) { ioI8.Hide(); lv8.Hide(); ioO8.Hide(); h = ioO8.Location.Y; }
            if (inputs < 7) { ioI7.Hide(); lv7.Hide(); ioO7.Hide(); h = ioO7.Location.Y; }
            if (inputs < 6) { ioI6.Hide(); lv6.Hide(); ioO6.Hide(); h = ioO6.Location.Y; }
            if (inputs < 5) { ioI5.Hide(); lv5.Hide(); ioO5.Hide(); h = ioO5.Location.Y; }
            if (inputs < 4) { ioI4.Hide(); lv4.Hide(); ioO4.Hide(); h = ioO4.Location.Y; }
            if (inputs < 3) { ioI3.Hide(); lv3.Hide(); ioO3.Hide(); h = ioO4.Location.Y; }
            if (inputs < 2) { ioI2.Hide(); lv2.Hide(); ioO2.Hide(); h = ioO4.Location.Y; }
            Height = h;

            dlGain.val = gainmax;
            dlItime.val = tau * 1000;

            S = new double[inputs];
            S2 = new double[inputs];
            value = new double[inputs];

            dlGain.valueChanged += DlGain_valueChanged;
            dlItime.valueChanged += DlItime_valueChanged;
            
            processingType = ProcessingType.Processor;
        }


        public Agc(): this(8)
        {
        }

        public Agc(int _inputs) : base()
        {
            inputs = _inputs;
            gainmax = -6;
            tau = 0.1;

            init();
        }

        public Agc(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            inputs = src.ReadInt32();
            tau = src.ReadDouble();
            countMax = (int)Math.Floor(tau * owner.sampleRate + 0.5);
            gainmax = src.ReadDouble();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(inputs);
            tgt.Write(tau);
            tgt.Write(gainmax);
        }

        private void DlItime_valueChanged(object sender, EventArgs e)
        {
            tau = dlItime.val / 1000;
            countMax = (int)Math.Floor(tau * owner.sampleRate + 0.5);
            main.tau = tau;
        }

        private void DlGain_valueChanged(object sender, EventArgs e)
        {
            gainmax = dlGain.val;
        }

        public void newValue(int channel, double v)
        {
            if (v != value[channel])
            {
                value[channel] = v;
                switch(channel)
                {
                    case 0: lv1.value = v; break;
                    case 1: lv2.value = v; break;
                    case 2: lv3.value = v; break;
                    case 3: lv4.value = v; break;
                    case 4: lv5.value = v; break;
                    case 5: lv6.value = v; break;
                    case 6: lv7.value = v; break;
                    case 7: lv8.value = v; break;
                }
            }
        }

        public override void tick()
        {
            if (!_active)
                return;

            if (main == null)
                main = new RMSdetector(owner.sampleRate, tau);

            countMax = (int)Math.Floor(tau * owner.sampleRate + 0.5);

            if ((abuf == null) || (abuf.Length != owner.blockSize))
                abuf = new double[owner.blockSize];
            double amax = Math.Pow(10.0, gainmax / 20.0);

            SignalBuffer min = getSignalInputBuffer(ioI1);
            if (min == null)
            {
                for (int i = 0; i < owner.blockSize; i++)
                {
                    double a = main.filter(0.0);
                    if (1 > amax * a)
                        abuf[i] = amax;
                    else
                        abuf[i] = 1 / a;
                }
            } else
            {
                for (int i = 0; i < owner.blockSize; i++)
                {
                    double a = main.filter(min.data[i]);
                    if (1 > a * amax)
                        abuf[i] = amax;
                    else
                        abuf[i] = 1 / a;
                }
            }
            if (!active)
            {
                for (int i = 0; i < owner.blockSize; i++)
                    abuf[i] = 1.0;
            }
            gain = 20.0 * Math.Log10(abuf[owner.blockSize - 1]);
            SignalBuffer dout = getSignalOutputBuffer(ioGain);
            if (dout != null)
            {
                if (active)
                {
                    for (int i = 0; i < owner.blockSize; i++)
                        dout.data[i] = abuf[i] / amax;
                } else
                {
                    for (int i = 0; i < owner.blockSize; i++)
                        dout.data[i] = 1.0;
                }
            }
            int countSave = count;
            for (int i = 0; i < inputs; i++)
            {
                SignalBuffer dbin=null, dbout=null;
                switch (i)
                {
                    case 0: dbin = getSignalInputBuffer(ioI1); dbout = getSignalOutputBuffer(ioO1); break;
                    case 1: dbin = getSignalInputBuffer(ioI2); dbout = getSignalOutputBuffer(ioO2); break;
                    case 2: dbin = getSignalInputBuffer(ioI3); dbout = getSignalOutputBuffer(ioO3); break;
                    case 3: dbin = getSignalInputBuffer(ioI4); dbout = getSignalOutputBuffer(ioO4); break;
                    case 4: dbin = getSignalInputBuffer(ioI5); dbout = getSignalOutputBuffer(ioO5); break;
                    case 5: dbin = getSignalInputBuffer(ioI6); dbout = getSignalOutputBuffer(ioO6); break;
                    case 6: dbin = getSignalInputBuffer(ioI7); dbout = getSignalOutputBuffer(ioO7); break;
                    case 7: dbin = getSignalInputBuffer(ioI8); dbout = getSignalOutputBuffer(ioO8); break;
                }
                if ((dbin != null) && (dbout != null))
                {
                    for (int j = 0; j < owner.blockSize; j++)
                        dbout.data[j] = abuf[j] * dbin.data[j];
                }
                if (dbin != null)
                {
                    count = countSave;
                    for (int j = 0; j < owner.blockSize; j++)
                    {
                        double din = abuf[j] * dbin.data[j];
                        S[i] += din;
                        S2[i] += din*din;
                        count++;
                        if (count >= countMax)
                        {
                            double v = Math.Sqrt(S2[i] / count);
                            v -= Math.Abs(S[i]) / count;
                            if (v < 1e-6)
                                newValue(i, -120);
                            else
                                newValue(i, 20.0 * Math.Log10(v));
                            count = 0;
                            S[i] = S2[i] = 0;
                        }
                    }
                } else
                {
                    newValue(i, -120);
                }
            }
            count = (countSave + owner.blockSize) % countMax;
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "AGC", "1 x" }; }
            public override RTForm Instantiate() { return new Agc(1); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "AGC", "2 x" }; }
            public override RTForm Instantiate() { return new Agc(2); }
        }
        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "AGC", "4 x" }; }
            public override RTForm Instantiate() { return new Agc(4); }
        }
        class RegisterClass6 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> {  "Arithmetic", "AGC", "6 x" }; }
            public override RTForm Instantiate() { return new Agc(6); }
        }
        class RegisterClass8 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "AGC", "8 x" }; }
            public override RTForm Instantiate() { return new Agc(8); }
        }
        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
            l.Add(new RegisterClass2());
            l.Add(new RegisterClass4());
            l.Add(new RegisterClass6());
            l.Add(new RegisterClass8());
        }

    }
}
