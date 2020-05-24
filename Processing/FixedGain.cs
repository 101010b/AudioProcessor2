using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.Processing
{
    class FixedGain : RTForm
    {

        public void InitializeComponent()
        {
            this.ioI1 = new AudioProcessor.RTIO();
            this.ioI2 = new AudioProcessor.RTIO();
            this.ioI3 = new AudioProcessor.RTIO();
            this.ioI4 = new AudioProcessor.RTIO();
            this.ioI5 = new AudioProcessor.RTIO();
            this.ioI6 = new AudioProcessor.RTIO();
            this.ioI7 = new AudioProcessor.RTIO();
            this.ioI8 = new AudioProcessor.RTIO();
            this.ioO8 = new AudioProcessor.RTIO();
            this.ioO7 = new AudioProcessor.RTIO();
            this.ioO6 = new AudioProcessor.RTIO();
            this.ioO5 = new AudioProcessor.RTIO();
            this.ioO4 = new AudioProcessor.RTIO();
            this.ioO3 = new AudioProcessor.RTIO();
            this.ioO2 = new AudioProcessor.RTIO();
            this.ioO1 = new AudioProcessor.RTIO();
            this.dlGain = new AudioProcessor.RTDial();
            this.clTime = new AudioProcessor.RTChoice();
            this.bnAC = new AudioProcessor.RTButton();
            this.lv1 = new AudioProcessor.RTLevel();
            this.lv2 = new AudioProcessor.RTLevel();
            this.lv4 = new AudioProcessor.RTLevel();
            this.lv3 = new AudioProcessor.RTLevel();
            this.lv6 = new AudioProcessor.RTLevel();
            this.lv5 = new AudioProcessor.RTLevel();
            this.lv8 = new AudioProcessor.RTLevel();
            this.lv7 = new AudioProcessor.RTLevel();
            this.bnSet = new AudioProcessor.RTButton();
            this.bnPost = new AudioProcessor.RTButton();
            this.SuspendLayout();
            // 
            // ioI1
            // 
            this.ioI1.contactBackColor = System.Drawing.Color.Black;
            this.ioI1.contactColor = System.Drawing.Color.DimGray;
            this.ioI1.contactHighlightColor = System.Drawing.Color.Red;
            this.ioI1.hideOnShrink = false;
            this.ioI1.highlighted = false;
            this.ioI1.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioI1.Location = new System.Drawing.Point(0, 28);
            this.ioI1.Name = "ioI1";
            this.ioI1.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI1.showTitle = true;
            this.ioI1.Size = new System.Drawing.Size(45, 20);
            this.ioI1.TabIndex = 11;
            this.ioI1.Text = "rtio1";
            this.ioI1.title = "1/M";
            this.ioI1.titleColor = System.Drawing.Color.DimGray;
            this.ioI1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI2
            // 
            this.ioI2.contactBackColor = System.Drawing.Color.Black;
            this.ioI2.contactColor = System.Drawing.Color.DimGray;
            this.ioI2.contactHighlightColor = System.Drawing.Color.Red;
            this.ioI2.hideOnShrink = false;
            this.ioI2.highlighted = false;
            this.ioI2.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioI2.Location = new System.Drawing.Point(0, 54);
            this.ioI2.Name = "ioI2";
            this.ioI2.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI2.showTitle = true;
            this.ioI2.Size = new System.Drawing.Size(45, 20);
            this.ioI2.TabIndex = 13;
            this.ioI2.Text = "rtio1";
            this.ioI2.title = "2";
            this.ioI2.titleColor = System.Drawing.Color.DimGray;
            this.ioI2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI3
            // 
            this.ioI3.contactBackColor = System.Drawing.Color.Black;
            this.ioI3.contactColor = System.Drawing.Color.DimGray;
            this.ioI3.contactHighlightColor = System.Drawing.Color.Red;
            this.ioI3.hideOnShrink = false;
            this.ioI3.highlighted = false;
            this.ioI3.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioI3.Location = new System.Drawing.Point(0, 80);
            this.ioI3.Name = "ioI3";
            this.ioI3.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI3.showTitle = true;
            this.ioI3.Size = new System.Drawing.Size(45, 20);
            this.ioI3.TabIndex = 14;
            this.ioI3.Text = "rtio1";
            this.ioI3.title = "3";
            this.ioI3.titleColor = System.Drawing.Color.DimGray;
            this.ioI3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI4
            // 
            this.ioI4.contactBackColor = System.Drawing.Color.Black;
            this.ioI4.contactColor = System.Drawing.Color.DimGray;
            this.ioI4.contactHighlightColor = System.Drawing.Color.Red;
            this.ioI4.hideOnShrink = false;
            this.ioI4.highlighted = false;
            this.ioI4.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioI4.Location = new System.Drawing.Point(0, 106);
            this.ioI4.Name = "ioI4";
            this.ioI4.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI4.showTitle = true;
            this.ioI4.Size = new System.Drawing.Size(45, 20);
            this.ioI4.TabIndex = 15;
            this.ioI4.Text = "rtio1";
            this.ioI4.title = "4";
            this.ioI4.titleColor = System.Drawing.Color.DimGray;
            this.ioI4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI5
            // 
            this.ioI5.contactBackColor = System.Drawing.Color.Black;
            this.ioI5.contactColor = System.Drawing.Color.DimGray;
            this.ioI5.contactHighlightColor = System.Drawing.Color.Red;
            this.ioI5.hideOnShrink = false;
            this.ioI5.highlighted = false;
            this.ioI5.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioI5.Location = new System.Drawing.Point(0, 132);
            this.ioI5.Name = "ioI5";
            this.ioI5.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI5.showTitle = true;
            this.ioI5.Size = new System.Drawing.Size(45, 20);
            this.ioI5.TabIndex = 16;
            this.ioI5.Text = "rtio1";
            this.ioI5.title = "5";
            this.ioI5.titleColor = System.Drawing.Color.DimGray;
            this.ioI5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI6
            // 
            this.ioI6.contactBackColor = System.Drawing.Color.Black;
            this.ioI6.contactColor = System.Drawing.Color.DimGray;
            this.ioI6.contactHighlightColor = System.Drawing.Color.Red;
            this.ioI6.hideOnShrink = false;
            this.ioI6.highlighted = false;
            this.ioI6.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioI6.Location = new System.Drawing.Point(0, 158);
            this.ioI6.Name = "ioI6";
            this.ioI6.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI6.showTitle = true;
            this.ioI6.Size = new System.Drawing.Size(45, 20);
            this.ioI6.TabIndex = 17;
            this.ioI6.Text = "rtio1";
            this.ioI6.title = "6";
            this.ioI6.titleColor = System.Drawing.Color.DimGray;
            this.ioI6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI7
            // 
            this.ioI7.contactBackColor = System.Drawing.Color.Black;
            this.ioI7.contactColor = System.Drawing.Color.DimGray;
            this.ioI7.contactHighlightColor = System.Drawing.Color.Red;
            this.ioI7.hideOnShrink = false;
            this.ioI7.highlighted = false;
            this.ioI7.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioI7.Location = new System.Drawing.Point(0, 184);
            this.ioI7.Name = "ioI7";
            this.ioI7.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI7.showTitle = true;
            this.ioI7.Size = new System.Drawing.Size(45, 20);
            this.ioI7.TabIndex = 18;
            this.ioI7.Text = "rtio1";
            this.ioI7.title = "7";
            this.ioI7.titleColor = System.Drawing.Color.DimGray;
            this.ioI7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI8
            // 
            this.ioI8.contactBackColor = System.Drawing.Color.Black;
            this.ioI8.contactColor = System.Drawing.Color.DimGray;
            this.ioI8.contactHighlightColor = System.Drawing.Color.Red;
            this.ioI8.hideOnShrink = false;
            this.ioI8.highlighted = false;
            this.ioI8.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioI8.Location = new System.Drawing.Point(0, 210);
            this.ioI8.Name = "ioI8";
            this.ioI8.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI8.showTitle = true;
            this.ioI8.Size = new System.Drawing.Size(45, 20);
            this.ioI8.TabIndex = 19;
            this.ioI8.Text = "rtio1";
            this.ioI8.title = "8";
            this.ioI8.titleColor = System.Drawing.Color.DimGray;
            this.ioI8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioO8
            // 
            this.ioO8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO8.contactBackColor = System.Drawing.Color.Black;
            this.ioO8.contactColor = System.Drawing.Color.DimGray;
            this.ioO8.contactHighlightColor = System.Drawing.Color.Red;
            this.ioO8.hideOnShrink = false;
            this.ioO8.highlighted = false;
            this.ioO8.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioO8.Location = new System.Drawing.Point(305, 210);
            this.ioO8.Name = "ioO8";
            this.ioO8.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO8.showTitle = true;
            this.ioO8.Size = new System.Drawing.Size(42, 20);
            this.ioO8.TabIndex = 27;
            this.ioO8.Text = "rtio1";
            this.ioO8.title = "8";
            this.ioO8.titleColor = System.Drawing.Color.DimGray;
            this.ioO8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioO7
            // 
            this.ioO7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO7.contactBackColor = System.Drawing.Color.Black;
            this.ioO7.contactColor = System.Drawing.Color.DimGray;
            this.ioO7.contactHighlightColor = System.Drawing.Color.Red;
            this.ioO7.hideOnShrink = false;
            this.ioO7.highlighted = false;
            this.ioO7.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioO7.Location = new System.Drawing.Point(305, 184);
            this.ioO7.Name = "ioO7";
            this.ioO7.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO7.showTitle = true;
            this.ioO7.Size = new System.Drawing.Size(42, 20);
            this.ioO7.TabIndex = 26;
            this.ioO7.Text = "rtio1";
            this.ioO7.title = "7";
            this.ioO7.titleColor = System.Drawing.Color.DimGray;
            this.ioO7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioO6
            // 
            this.ioO6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO6.contactBackColor = System.Drawing.Color.Black;
            this.ioO6.contactColor = System.Drawing.Color.DimGray;
            this.ioO6.contactHighlightColor = System.Drawing.Color.Red;
            this.ioO6.hideOnShrink = false;
            this.ioO6.highlighted = false;
            this.ioO6.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioO6.Location = new System.Drawing.Point(305, 158);
            this.ioO6.Name = "ioO6";
            this.ioO6.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO6.showTitle = true;
            this.ioO6.Size = new System.Drawing.Size(42, 20);
            this.ioO6.TabIndex = 25;
            this.ioO6.Text = "rtio1";
            this.ioO6.title = "6";
            this.ioO6.titleColor = System.Drawing.Color.DimGray;
            this.ioO6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioO5
            // 
            this.ioO5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO5.contactBackColor = System.Drawing.Color.Black;
            this.ioO5.contactColor = System.Drawing.Color.DimGray;
            this.ioO5.contactHighlightColor = System.Drawing.Color.Red;
            this.ioO5.hideOnShrink = false;
            this.ioO5.highlighted = false;
            this.ioO5.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioO5.Location = new System.Drawing.Point(305, 132);
            this.ioO5.Name = "ioO5";
            this.ioO5.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO5.showTitle = true;
            this.ioO5.Size = new System.Drawing.Size(42, 20);
            this.ioO5.TabIndex = 24;
            this.ioO5.Text = "rtio1";
            this.ioO5.title = "5";
            this.ioO5.titleColor = System.Drawing.Color.DimGray;
            this.ioO5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioO4
            // 
            this.ioO4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO4.contactBackColor = System.Drawing.Color.Black;
            this.ioO4.contactColor = System.Drawing.Color.DimGray;
            this.ioO4.contactHighlightColor = System.Drawing.Color.Red;
            this.ioO4.hideOnShrink = false;
            this.ioO4.highlighted = false;
            this.ioO4.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioO4.Location = new System.Drawing.Point(305, 106);
            this.ioO4.Name = "ioO4";
            this.ioO4.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO4.showTitle = true;
            this.ioO4.Size = new System.Drawing.Size(42, 20);
            this.ioO4.TabIndex = 23;
            this.ioO4.Text = "rtio1";
            this.ioO4.title = "4";
            this.ioO4.titleColor = System.Drawing.Color.DimGray;
            this.ioO4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioO3
            // 
            this.ioO3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO3.contactBackColor = System.Drawing.Color.Black;
            this.ioO3.contactColor = System.Drawing.Color.DimGray;
            this.ioO3.contactHighlightColor = System.Drawing.Color.Red;
            this.ioO3.hideOnShrink = false;
            this.ioO3.highlighted = false;
            this.ioO3.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioO3.Location = new System.Drawing.Point(305, 80);
            this.ioO3.Name = "ioO3";
            this.ioO3.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO3.showTitle = true;
            this.ioO3.Size = new System.Drawing.Size(42, 20);
            this.ioO3.TabIndex = 22;
            this.ioO3.Text = "rtio1";
            this.ioO3.title = "3";
            this.ioO3.titleColor = System.Drawing.Color.DimGray;
            this.ioO3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioO2
            // 
            this.ioO2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO2.contactBackColor = System.Drawing.Color.Black;
            this.ioO2.contactColor = System.Drawing.Color.DimGray;
            this.ioO2.contactHighlightColor = System.Drawing.Color.Red;
            this.ioO2.hideOnShrink = false;
            this.ioO2.highlighted = false;
            this.ioO2.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioO2.Location = new System.Drawing.Point(305, 54);
            this.ioO2.Name = "ioO2";
            this.ioO2.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO2.showTitle = true;
            this.ioO2.Size = new System.Drawing.Size(42, 20);
            this.ioO2.TabIndex = 21;
            this.ioO2.Text = "rtio14";
            this.ioO2.title = "2";
            this.ioO2.titleColor = System.Drawing.Color.DimGray;
            this.ioO2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioO1
            // 
            this.ioO1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO1.contactBackColor = System.Drawing.Color.Black;
            this.ioO1.contactColor = System.Drawing.Color.DimGray;
            this.ioO1.contactHighlightColor = System.Drawing.Color.Red;
            this.ioO1.hideOnShrink = false;
            this.ioO1.highlighted = false;
            this.ioO1.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioO1.Location = new System.Drawing.Point(305, 28);
            this.ioO1.Name = "ioO1";
            this.ioO1.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO1.showTitle = true;
            this.ioO1.Size = new System.Drawing.Size(42, 20);
            this.ioO1.TabIndex = 20;
            this.ioO1.Text = "rtio1";
            this.ioO1.title = "1";
            this.ioO1.titleColor = System.Drawing.Color.DimGray;
            this.ioO1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dlGain
            // 
            this.dlGain.dialColor = System.Drawing.Color.Silver;
            this.dlGain.dialDiameter = 50D;
            this.dlGain.dialMarkColor = System.Drawing.Color.Red;
            this.dlGain.format = "F2";
            this.dlGain.hideOnShrink = true;
            this.dlGain.Location = new System.Drawing.Point(55, 4);
            this.dlGain.logScale = false;
            this.dlGain.maxVal = 100D;
            this.dlGain.minVal = -100D;
            this.dlGain.Name = "dlGain";
            this.dlGain.scaleColor = System.Drawing.Color.Gold;
            this.dlGain.showScale = true;
            this.dlGain.showTitle = false;
            this.dlGain.showValue = true;
            this.dlGain.Size = new System.Drawing.Size(80, 80);
            this.dlGain.TabIndex = 28;
            this.dlGain.Text = "rtDial1";
            this.dlGain.title = "gain";
            this.dlGain.titleColor = System.Drawing.Color.DimGray;
            this.dlGain.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlGain.unit = "dB";
            this.dlGain.val = 0D;
            this.dlGain.valueColor = System.Drawing.Color.DimGray;
            this.dlGain.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // clTime
            // 
            this.clTime.backColor = System.Drawing.Color.Black;
            this.clTime.choiceType = AudioProcessor.RTChoice.ChoiceType.ListDefined;
            this.clTime.frontColor = System.Drawing.Color.DimGray;
            this.clTime.hideOnShrink = true;
            this.clTime.Location = new System.Drawing.Point(43, 108);
            this.clTime.Name = "clTime";
            this.clTime.numericMax = 100;
            this.clTime.numericMin = 0;
            this.clTime.offString = "off";
            this.clTime.selectedItem = -1;
            this.clTime.Size = new System.Drawing.Size(106, 20);
            this.clTime.TabIndex = 29;
            this.clTime.Text = "rtChoice1";
            this.clTime.title = "Time";
            this.clTime.titleColor = System.Drawing.Color.DimGray;
            this.clTime.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clTime.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clTime.xdim = 60;
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
            this.bnAC.hideOnShrink = true;
            this.bnAC.Location = new System.Drawing.Point(52, 88);
            this.bnAC.Name = "bnAC";
            this.bnAC.offText = "DC";
            this.bnAC.onText = "AC";
            this.bnAC.Size = new System.Drawing.Size(31, 16);
            this.bnAC.TabIndex = 30;
            this.bnAC.Text = "rtButton2";
            this.bnAC.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnAC.textOffColor = System.Drawing.Color.DimGray;
            this.bnAC.textOnColor = System.Drawing.Color.Red;
            this.bnAC.title = "Button";
            this.bnAC.titleColor = System.Drawing.Color.DimGray;
            this.bnAC.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnAC.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // lv1
            // 
            this.lv1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lv1.displaySize = new System.Drawing.Size(70, 10);
            this.lv1.fillColor = System.Drawing.Color.LimeGreen;
            this.lv1.format = "F2";
            this.lv1.frameColor = System.Drawing.Color.DimGray;
            this.lv1.hideOnShrink = false;
            this.lv1.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv1.Location = new System.Drawing.Point(155, 28);
            this.lv1.logScale = false;
            this.lv1.max = 20D;
            this.lv1.min = -120D;
            this.lv1.Name = "lv1";
            this.lv1.openAngle = 150;
            this.lv1.pointColor = System.Drawing.Color.Red;
            this.lv1.Size = new System.Drawing.Size(159, 20);
            this.lv1.TabIndex = 31;
            this.lv1.Text = "rtLevel1";
            this.lv1.title = "level";
            this.lv1.titleColor = System.Drawing.Color.DimGray;
            this.lv1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv1.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.lv1.unit = "dBFS";
            this.lv1.value = -120D;
            this.lv1.valueColor = System.Drawing.Color.DimGray;
            this.lv1.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lv1.valuePos = AudioProcessor.GraphicsUtil.TextAlignment.right;
            // 
            // lv2
            // 
            this.lv2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lv2.displaySize = new System.Drawing.Size(70, 10);
            this.lv2.fillColor = System.Drawing.Color.LimeGreen;
            this.lv2.format = "F2";
            this.lv2.frameColor = System.Drawing.Color.DimGray;
            this.lv2.hideOnShrink = false;
            this.lv2.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv2.Location = new System.Drawing.Point(155, 54);
            this.lv2.logScale = false;
            this.lv2.max = 20D;
            this.lv2.min = -120D;
            this.lv2.Name = "lv2";
            this.lv2.openAngle = 150;
            this.lv2.pointColor = System.Drawing.Color.Red;
            this.lv2.Size = new System.Drawing.Size(159, 20);
            this.lv2.TabIndex = 32;
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
            // lv4
            // 
            this.lv4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lv4.displaySize = new System.Drawing.Size(70, 10);
            this.lv4.fillColor = System.Drawing.Color.LimeGreen;
            this.lv4.format = "F2";
            this.lv4.frameColor = System.Drawing.Color.DimGray;
            this.lv4.hideOnShrink = false;
            this.lv4.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv4.Location = new System.Drawing.Point(155, 106);
            this.lv4.logScale = false;
            this.lv4.max = 20D;
            this.lv4.min = -120D;
            this.lv4.Name = "lv4";
            this.lv4.openAngle = 150;
            this.lv4.pointColor = System.Drawing.Color.Red;
            this.lv4.Size = new System.Drawing.Size(159, 20);
            this.lv4.TabIndex = 34;
            this.lv4.Text = "rtLevel3";
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
            // lv3
            // 
            this.lv3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lv3.displaySize = new System.Drawing.Size(70, 10);
            this.lv3.fillColor = System.Drawing.Color.LimeGreen;
            this.lv3.format = "F2";
            this.lv3.frameColor = System.Drawing.Color.DimGray;
            this.lv3.hideOnShrink = false;
            this.lv3.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv3.Location = new System.Drawing.Point(155, 80);
            this.lv3.logScale = false;
            this.lv3.max = 20D;
            this.lv3.min = -120D;
            this.lv3.Name = "lv3";
            this.lv3.openAngle = 150;
            this.lv3.pointColor = System.Drawing.Color.Red;
            this.lv3.Size = new System.Drawing.Size(159, 20);
            this.lv3.TabIndex = 33;
            this.lv3.Text = "rtLevel4";
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
            // lv6
            // 
            this.lv6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lv6.displaySize = new System.Drawing.Size(70, 10);
            this.lv6.fillColor = System.Drawing.Color.LimeGreen;
            this.lv6.format = "F2";
            this.lv6.frameColor = System.Drawing.Color.DimGray;
            this.lv6.hideOnShrink = false;
            this.lv6.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv6.Location = new System.Drawing.Point(155, 158);
            this.lv6.logScale = false;
            this.lv6.max = 20D;
            this.lv6.min = -120D;
            this.lv6.Name = "lv6";
            this.lv6.openAngle = 150;
            this.lv6.pointColor = System.Drawing.Color.Red;
            this.lv6.Size = new System.Drawing.Size(159, 20);
            this.lv6.TabIndex = 36;
            this.lv6.Text = "rtLevel5";
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
            // lv5
            // 
            this.lv5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lv5.displaySize = new System.Drawing.Size(70, 10);
            this.lv5.fillColor = System.Drawing.Color.LimeGreen;
            this.lv5.format = "F2";
            this.lv5.frameColor = System.Drawing.Color.DimGray;
            this.lv5.hideOnShrink = false;
            this.lv5.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv5.Location = new System.Drawing.Point(155, 132);
            this.lv5.logScale = false;
            this.lv5.max = 20D;
            this.lv5.min = -120D;
            this.lv5.Name = "lv5";
            this.lv5.openAngle = 150;
            this.lv5.pointColor = System.Drawing.Color.Red;
            this.lv5.Size = new System.Drawing.Size(159, 20);
            this.lv5.TabIndex = 35;
            this.lv5.Text = "rtLevel6";
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
            // lv8
            // 
            this.lv8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lv8.displaySize = new System.Drawing.Size(70, 10);
            this.lv8.fillColor = System.Drawing.Color.LimeGreen;
            this.lv8.format = "F2";
            this.lv8.frameColor = System.Drawing.Color.DimGray;
            this.lv8.hideOnShrink = false;
            this.lv8.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv8.Location = new System.Drawing.Point(155, 210);
            this.lv8.logScale = false;
            this.lv8.max = 20D;
            this.lv8.min = -120D;
            this.lv8.Name = "lv8";
            this.lv8.openAngle = 150;
            this.lv8.pointColor = System.Drawing.Color.Red;
            this.lv8.Size = new System.Drawing.Size(159, 20);
            this.lv8.TabIndex = 38;
            this.lv8.Text = "rtLevel7";
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
            // lv7
            // 
            this.lv7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lv7.displaySize = new System.Drawing.Size(70, 10);
            this.lv7.fillColor = System.Drawing.Color.LimeGreen;
            this.lv7.format = "F2";
            this.lv7.frameColor = System.Drawing.Color.DimGray;
            this.lv7.hideOnShrink = false;
            this.lv7.levelType = AudioProcessor.RTLevel.RTLevelType.LinearH;
            this.lv7.Location = new System.Drawing.Point(155, 184);
            this.lv7.logScale = false;
            this.lv7.max = 20D;
            this.lv7.min = -120D;
            this.lv7.Name = "lv7";
            this.lv7.openAngle = 150;
            this.lv7.pointColor = System.Drawing.Color.Red;
            this.lv7.Size = new System.Drawing.Size(159, 20);
            this.lv7.TabIndex = 37;
            this.lv7.Text = "rtLevel8";
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
            // bnSet
            // 
            this.bnSet.buttonDim = new System.Drawing.Size(30, 15);
            this.bnSet.buttonState = false;
            this.bnSet.buttonType = AudioProcessor.RTButton.RTButtonType.ClickButton;
            this.bnSet.fillOffColor = System.Drawing.Color.Black;
            this.bnSet.fillOnColor = System.Drawing.Color.DarkRed;
            this.bnSet.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnSet.frameOffColor = System.Drawing.Color.DimGray;
            this.bnSet.frameOnColor = System.Drawing.Color.Red;
            this.bnSet.hideOnShrink = true;
            this.bnSet.Location = new System.Drawing.Point(104, 88);
            this.bnSet.Name = "bnSet";
            this.bnSet.offText = "Set";
            this.bnSet.onText = "Set";
            this.bnSet.Size = new System.Drawing.Size(31, 16);
            this.bnSet.TabIndex = 39;
            this.bnSet.Text = "rtButton1";
            this.bnSet.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnSet.textOffColor = System.Drawing.Color.DimGray;
            this.bnSet.textOnColor = System.Drawing.Color.Red;
            this.bnSet.title = "Button";
            this.bnSet.titleColor = System.Drawing.Color.DimGray;
            this.bnSet.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnSet.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // bnPost
            // 
            this.bnPost.buttonDim = new System.Drawing.Size(35, 15);
            this.bnPost.buttonState = true;
            this.bnPost.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bnPost.fillOffColor = System.Drawing.Color.Navy;
            this.bnPost.fillOnColor = System.Drawing.Color.DarkRed;
            this.bnPost.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnPost.frameOffColor = System.Drawing.Color.DimGray;
            this.bnPost.frameOnColor = System.Drawing.Color.Red;
            this.bnPost.hideOnShrink = true;
            this.bnPost.Location = new System.Drawing.Point(228, 5);
            this.bnPost.Name = "bnPost";
            this.bnPost.offText = "Pre";
            this.bnPost.onText = "Post";
            this.bnPost.Size = new System.Drawing.Size(36, 16);
            this.bnPost.TabIndex = 40;
            this.bnPost.Text = "rtButton2";
            this.bnPost.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnPost.textOffColor = System.Drawing.Color.DimGray;
            this.bnPost.textOnColor = System.Drawing.Color.Red;
            this.bnPost.title = "Button";
            this.bnPost.titleColor = System.Drawing.Color.DimGray;
            this.bnPost.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnPost.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // FixedGain
            // 
            this.Controls.Add(this.bnPost);
            this.Controls.Add(this.bnSet);
            this.Controls.Add(this.lv8);
            this.Controls.Add(this.lv7);
            this.Controls.Add(this.lv6);
            this.Controls.Add(this.lv5);
            this.Controls.Add(this.lv4);
            this.Controls.Add(this.lv3);
            this.Controls.Add(this.lv2);
            this.Controls.Add(this.lv1);
            this.Controls.Add(this.bnAC);
            this.Controls.Add(this.clTime);
            this.Controls.Add(this.dlGain);
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
            this.Name = "FixedGain";
            this.shrinkSize = new System.Drawing.Size(244, 239);
            this.shrinkTitle = "Fixed Gain";
            this.Size = new System.Drawing.Size(347, 239);
            this.title = "Fixed Gain";
            this.ResumeLayout(false);

        }

        bool postgain;
        double gain;
        int inputs;

        double[] S;
        double[] S2;
        double[] value;

        int windowselect;
        Boolean removeDC;
        int count;
        int countMax;
        private RTIO ioI1;
        private RTIO ioI2;
        private RTIO ioI3;
        private RTIO ioI4;
        private RTIO ioI5;
        private RTIO ioI6;
        private RTIO ioI7;
        private RTIO ioI8;
        private RTIO ioO8;
        private RTIO ioO7;
        private RTIO ioO6;
        private RTIO ioO5;
        private RTIO ioO4;
        private RTIO ioO3;
        private RTIO ioO2;
        private RTIO ioO1;
        private RTDial dlGain;
        private RTChoice clTime;
        private RTButton bnAC;
        private RTLevel lv1;
        private RTLevel lv2;
        private RTLevel lv4;
        private RTLevel lv3;
        private RTLevel lv6;
        private RTLevel lv5;
        private RTLevel lv8;
        private RTLevel lv7;
        private RTButton bnSet;
        private RTButton bnPost;

        private List<string> Timings;
        private List<double> TimingsD;

        private double min(double a, double b)
        {
            return (a < b) ? a : b;
        }

        private void init()
        {
            InitializeComponent();

            int h = Height;
            int hh = Height;
            if (inputs < 8) { ioI8.Hide(); ioO8.Hide(); lv8.Hide(); h = ioI8.Location.Y; hh = ioI8.Location.Y; }
            if (inputs < 7) { ioI7.Hide(); ioO7.Hide(); lv7.Hide(); h = ioI7.Location.Y; hh = ioI7.Location.Y; }
            if (inputs < 6) { ioI6.Hide(); ioO6.Hide(); lv6.Hide(); h = ioI6.Location.Y; hh = ioI6.Location.Y; }
            if (inputs < 5) { ioI5.Hide(); ioO5.Hide(); lv5.Hide(); h = ioI5.Location.Y; hh = ioI5.Location.Y; }
            if (inputs < 4) { ioI4.Hide(); ioO4.Hide(); lv4.Hide(); h = ioI5.Location.Y; hh = ioI4.Location.Y; }
            if (inputs < 3) { ioI3.Hide(); ioO3.Hide(); lv3.Hide(); h = ioI5.Location.Y; hh = ioI3.Location.Y; }
            if (inputs < 2) { ioI2.Hide(); ioO2.Hide(); lv2.Hide(); h = ioI5.Location.Y; hh = ioI2.Location.Y; }
            Height = h;
            shrinkSize = new System.Drawing.Size(shrinkSize.Width, hh);

            bnPost.buttonState = postgain;
            dlGain.val = gain;
            bnAC.buttonState = removeDC;
            Timings = new List<string> { "1ms", "2ms", "5ms", "10ms", "20ms", "50ms", "100ms", "200ms", "500ms", "1s", "2s", "5s", "10s" };
            TimingsD = new List<double> { 0.001, 0.002, 0.005, 0.01, 0.02, 0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10 };
            List<RTChoice.RTDrawable> rtd = new List<RTChoice.RTDrawable>();
            for (int i = 0; i < Timings.Count(); i++) rtd.Add(new RTChoice.RTDrawableText(Timings[i]));
            clTime.setEntries(rtd);
            clTime.selectedItem = windowselect;

            bnPost.buttonStateChanged += BnPost_buttonStateChanged;
            dlGain.valueChanged += DlGain_valueChanged;
            bnAC.buttonStateChanged += BnAC_buttonStateChanged;
            clTime.choiceStateChanged += ClTime_choiceStateChanged;
            bnSet.buttonStateChanged += BnSet_buttonStateChanged;

            count = 0;
            S = new double[inputs];
            S2 = new double[inputs];
            value = new double[inputs];

            processingType = ProcessingType.Processor;
        }

        public FixedGain() : this(8)
        {
        }

        public FixedGain(int _inputs):base()
        {
            inputs = _inputs;
            postgain = false;
            gain = 0;
            removeDC = false;
            windowselect = 6;

            init();
        }

        public FixedGain(SystemPanel _owner, BinaryReader src):base(_owner,src)
        {
            inputs = src.ReadInt32();
            gain = src.ReadDouble();
            windowselect = src.ReadInt32();
            removeDC = src.ReadBoolean();
            postgain = src.ReadBoolean();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(inputs);
            tgt.Write(gain);
            tgt.Write(windowselect);
            tgt.Write(removeDC);
            tgt.Write(postgain);
        }

        private void BnSet_buttonStateChanged(object sender, EventArgs e)
        {
            gain = -value[0];
            dlGain.val = gain;
        }

        private void ClTime_choiceStateChanged(object sender, EventArgs e)
        {
            windowselect = clTime.selectedItem;
        }

        private void BnAC_buttonStateChanged(object sender, EventArgs e)
        {
            removeDC = bnAC.buttonState;
        }

        private void DlGain_valueChanged(object sender, EventArgs e)
        {
            gain = dlGain.val;
        }

        private void BnPost_buttonStateChanged(object sender, EventArgs e)
        {
            postgain = bnPost.buttonState;
        }
       
        private void processChannel(int channel, double a, SignalBuffer dbin, SignalBuffer dbout, RTLevel lvl)
        {
            if ((dbin != null) && (dbout != null))
            {
                for (int j = 0; j < owner.blockSize; j++)
                    dbout.data[j] = a * dbin.data[j];
            }
            if (dbin != null)
            {
                int cnt = count;
                for (int j = 0; j < owner.blockSize; j++)
                {
                    S[channel] += dbin.data[j];
                    S2[channel] += dbin.data[j] * dbin.data[j];
                    cnt++;
                    if (cnt >= countMax)
                    {
                        double v = Math.Sqrt(S2[channel] / cnt);
                        if (removeDC)
                            v -= Math.Abs(S[channel]) / cnt;
                        if (v < 1e-6)
                            value[channel] = -120;
                        else
                            value[channel] = 20.0 * Math.Log10(v);
                        cnt = 0;
                        S[channel] = S2[channel] = 0;
                    }
                }
            }
            if (postgain)
                lvl.value = value[channel] + gain;
            else
                lvl.value = value[channel];
        }

        public override void tick()
        {
            if (!_active)
                return;

            countMax = (int)Math.Floor(TimingsD[windowselect] * owner.sampleRate + 0.5);
            double a = Math.Pow(10.0, gain / 20.0);

            if (inputs >= 1) processChannel(0, a, getSignalInputBuffer(ioI1), getSignalOutputBuffer(ioO1), lv1);
            if (inputs >= 2) processChannel(1, a, getSignalInputBuffer(ioI2), getSignalOutputBuffer(ioO2), lv2);
            if (inputs >= 3) processChannel(2, a, getSignalInputBuffer(ioI3), getSignalOutputBuffer(ioO3), lv3);
            if (inputs >= 4) processChannel(3, a, getSignalInputBuffer(ioI4), getSignalOutputBuffer(ioO4), lv4);
            if (inputs >= 5) processChannel(4, a, getSignalInputBuffer(ioI5), getSignalOutputBuffer(ioO5), lv5);
            if (inputs >= 6) processChannel(5, a, getSignalInputBuffer(ioI6), getSignalOutputBuffer(ioO6), lv6);
            if (inputs >= 7) processChannel(6, a, getSignalInputBuffer(ioI7), getSignalOutputBuffer(ioO7), lv7);
            if (inputs >= 8) processChannel(7, a, getSignalInputBuffer(ioI8), getSignalOutputBuffer(ioO8), lv8);

            count = (count + owner.blockSize) % countMax;
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Fixed Gain", "1 x" }; }
            public override RTForm Instantiate() { return new FixedGain(1); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Fixed Gain", "2 x" }; }
            public override RTForm Instantiate() { return new FixedGain(2); }
        }
        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Fixed Gain", "4 x" }; }
            public override RTForm Instantiate() { return new FixedGain(4); }
        }
        class RegisterClass6 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Fixed Gain", "6 x" }; }
            public override RTForm Instantiate() { return new FixedGain(6); }
        }
        class RegisterClass8 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Fixed Gain", "8 x" }; }
            public override RTForm Instantiate() { return new FixedGain(8); }
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
