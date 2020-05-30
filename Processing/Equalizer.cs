using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.Processing
{
    class Equalizer : RTForm
    {
        public void InitializeComponent()
        {
            this.ioO1 = new AudioProcessor.RTIO();
            this.ioI1 = new AudioProcessor.RTIO();
            this.ioO2 = new AudioProcessor.RTIO();
            this.ioI2 = new AudioProcessor.RTIO();
            this.ioO3 = new AudioProcessor.RTIO();
            this.ioI3 = new AudioProcessor.RTIO();
            this.ioO4 = new AudioProcessor.RTIO();
            this.ioI4 = new AudioProcessor.RTIO();
            this.ioO5 = new AudioProcessor.RTIO();
            this.ioI5 = new AudioProcessor.RTIO();
            this.ioO6 = new AudioProcessor.RTIO();
            this.ioI6 = new AudioProcessor.RTIO();
            this.ioO7 = new AudioProcessor.RTIO();
            this.ioI7 = new AudioProcessor.RTIO();
            this.ioO8 = new AudioProcessor.RTIO();
            this.ioI8 = new AudioProcessor.RTIO();
            this.dl50 = new AudioProcessor.RTSlider();
            this.dl150 = new AudioProcessor.RTSlider();
            this.dl500 = new AudioProcessor.RTSlider();
            this.dl1k5 = new AudioProcessor.RTSlider();
            this.dl5k = new AudioProcessor.RTSlider();
            this.dl15k = new AudioProcessor.RTSlider();
            this.SuspendLayout();
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
            this.ioO1.Location = new System.Drawing.Point(459, 22);
            this.ioO1.Name = "ioO1";
            this.ioO1.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO1.showTitle = true;
            this.ioO1.Size = new System.Drawing.Size(34, 20);
            this.ioO1.TabIndex = 12;
            this.ioO1.Text = "rtio3";
            this.ioO1.title = "1";
            this.ioO1.titleColor = System.Drawing.Color.DimGray;
            this.ioO1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI1
            // 
            this.ioI1.contactBackColor = System.Drawing.Color.Black;
            this.ioI1.contactColor = System.Drawing.Color.DimGray;
            this.ioI1.contactHighlightColor = System.Drawing.Color.Red;
            this.ioI1.hideOnShrink = false;
            this.ioI1.highlighted = false;
            this.ioI1.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioI1.Location = new System.Drawing.Point(0, 22);
            this.ioI1.Name = "ioI1";
            this.ioI1.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI1.showTitle = true;
            this.ioI1.Size = new System.Drawing.Size(40, 20);
            this.ioI1.TabIndex = 11;
            this.ioI1.Text = "ioI1";
            this.ioI1.title = "1";
            this.ioI1.titleColor = System.Drawing.Color.DimGray;
            this.ioI1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
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
            this.ioO2.Location = new System.Drawing.Point(459, 48);
            this.ioO2.Name = "ioO2";
            this.ioO2.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO2.showTitle = true;
            this.ioO2.Size = new System.Drawing.Size(34, 20);
            this.ioO2.TabIndex = 18;
            this.ioO2.Text = "rtio3";
            this.ioO2.title = "2";
            this.ioO2.titleColor = System.Drawing.Color.DimGray;
            this.ioO2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI2
            // 
            this.ioI2.contactBackColor = System.Drawing.Color.Black;
            this.ioI2.contactColor = System.Drawing.Color.DimGray;
            this.ioI2.contactHighlightColor = System.Drawing.Color.Red;
            this.ioI2.hideOnShrink = false;
            this.ioI2.highlighted = false;
            this.ioI2.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioI2.Location = new System.Drawing.Point(0, 48);
            this.ioI2.Name = "ioI2";
            this.ioI2.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI2.showTitle = true;
            this.ioI2.Size = new System.Drawing.Size(40, 20);
            this.ioI2.TabIndex = 17;
            this.ioI2.Text = "rtio1";
            this.ioI2.title = "2";
            this.ioI2.titleColor = System.Drawing.Color.DimGray;
            this.ioI2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
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
            this.ioO3.Location = new System.Drawing.Point(459, 74);
            this.ioO3.Name = "ioO3";
            this.ioO3.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO3.showTitle = true;
            this.ioO3.Size = new System.Drawing.Size(34, 20);
            this.ioO3.TabIndex = 21;
            this.ioO3.Text = "rtio3";
            this.ioO3.title = "3";
            this.ioO3.titleColor = System.Drawing.Color.DimGray;
            this.ioO3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI3
            // 
            this.ioI3.contactBackColor = System.Drawing.Color.Black;
            this.ioI3.contactColor = System.Drawing.Color.DimGray;
            this.ioI3.contactHighlightColor = System.Drawing.Color.Red;
            this.ioI3.hideOnShrink = false;
            this.ioI3.highlighted = false;
            this.ioI3.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioI3.Location = new System.Drawing.Point(0, 74);
            this.ioI3.Name = "ioI3";
            this.ioI3.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI3.showTitle = true;
            this.ioI3.Size = new System.Drawing.Size(40, 20);
            this.ioI3.TabIndex = 20;
            this.ioI3.Text = "rtio1";
            this.ioI3.title = "3";
            this.ioI3.titleColor = System.Drawing.Color.DimGray;
            this.ioI3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
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
            this.ioO4.Location = new System.Drawing.Point(459, 100);
            this.ioO4.Name = "ioO4";
            this.ioO4.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO4.showTitle = true;
            this.ioO4.Size = new System.Drawing.Size(34, 20);
            this.ioO4.TabIndex = 24;
            this.ioO4.Text = "rtio3";
            this.ioO4.title = "4";
            this.ioO4.titleColor = System.Drawing.Color.DimGray;
            this.ioO4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI4
            // 
            this.ioI4.contactBackColor = System.Drawing.Color.Black;
            this.ioI4.contactColor = System.Drawing.Color.DimGray;
            this.ioI4.contactHighlightColor = System.Drawing.Color.Red;
            this.ioI4.hideOnShrink = false;
            this.ioI4.highlighted = false;
            this.ioI4.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioI4.Location = new System.Drawing.Point(0, 100);
            this.ioI4.Name = "ioI4";
            this.ioI4.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI4.showTitle = true;
            this.ioI4.Size = new System.Drawing.Size(40, 20);
            this.ioI4.TabIndex = 23;
            this.ioI4.Text = "rtio1";
            this.ioI4.title = "4";
            this.ioI4.titleColor = System.Drawing.Color.DimGray;
            this.ioI4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
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
            this.ioO5.Location = new System.Drawing.Point(459, 126);
            this.ioO5.Name = "ioO5";
            this.ioO5.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO5.showTitle = true;
            this.ioO5.Size = new System.Drawing.Size(34, 20);
            this.ioO5.TabIndex = 27;
            this.ioO5.Text = "rtio3";
            this.ioO5.title = "5";
            this.ioO5.titleColor = System.Drawing.Color.DimGray;
            this.ioO5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI5
            // 
            this.ioI5.contactBackColor = System.Drawing.Color.Black;
            this.ioI5.contactColor = System.Drawing.Color.DimGray;
            this.ioI5.contactHighlightColor = System.Drawing.Color.Red;
            this.ioI5.hideOnShrink = false;
            this.ioI5.highlighted = false;
            this.ioI5.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioI5.Location = new System.Drawing.Point(0, 126);
            this.ioI5.Name = "ioI5";
            this.ioI5.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI5.showTitle = true;
            this.ioI5.Size = new System.Drawing.Size(40, 20);
            this.ioI5.TabIndex = 26;
            this.ioI5.Text = "rtio1";
            this.ioI5.title = "5";
            this.ioI5.titleColor = System.Drawing.Color.DimGray;
            this.ioI5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
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
            this.ioO6.Location = new System.Drawing.Point(459, 152);
            this.ioO6.Name = "ioO6";
            this.ioO6.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO6.showTitle = true;
            this.ioO6.Size = new System.Drawing.Size(34, 20);
            this.ioO6.TabIndex = 30;
            this.ioO6.Text = "rtio3";
            this.ioO6.title = "6";
            this.ioO6.titleColor = System.Drawing.Color.DimGray;
            this.ioO6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI6
            // 
            this.ioI6.contactBackColor = System.Drawing.Color.Black;
            this.ioI6.contactColor = System.Drawing.Color.DimGray;
            this.ioI6.contactHighlightColor = System.Drawing.Color.Red;
            this.ioI6.hideOnShrink = false;
            this.ioI6.highlighted = false;
            this.ioI6.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioI6.Location = new System.Drawing.Point(0, 152);
            this.ioI6.Name = "ioI6";
            this.ioI6.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI6.showTitle = true;
            this.ioI6.Size = new System.Drawing.Size(40, 20);
            this.ioI6.TabIndex = 29;
            this.ioI6.Text = "rtio1";
            this.ioI6.title = "6";
            this.ioI6.titleColor = System.Drawing.Color.DimGray;
            this.ioI6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
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
            this.ioO7.Location = new System.Drawing.Point(459, 178);
            this.ioO7.Name = "ioO7";
            this.ioO7.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO7.showTitle = true;
            this.ioO7.Size = new System.Drawing.Size(34, 20);
            this.ioO7.TabIndex = 33;
            this.ioO7.Text = "rtio3";
            this.ioO7.title = "7";
            this.ioO7.titleColor = System.Drawing.Color.DimGray;
            this.ioO7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI7
            // 
            this.ioI7.contactBackColor = System.Drawing.Color.Black;
            this.ioI7.contactColor = System.Drawing.Color.DimGray;
            this.ioI7.contactHighlightColor = System.Drawing.Color.Red;
            this.ioI7.hideOnShrink = false;
            this.ioI7.highlighted = false;
            this.ioI7.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioI7.Location = new System.Drawing.Point(0, 178);
            this.ioI7.Name = "ioI7";
            this.ioI7.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI7.showTitle = true;
            this.ioI7.Size = new System.Drawing.Size(40, 20);
            this.ioI7.TabIndex = 32;
            this.ioI7.Text = "rtio1";
            this.ioI7.title = "7";
            this.ioI7.titleColor = System.Drawing.Color.DimGray;
            this.ioI7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
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
            this.ioO8.Location = new System.Drawing.Point(459, 204);
            this.ioO8.Name = "ioO8";
            this.ioO8.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO8.showTitle = true;
            this.ioO8.Size = new System.Drawing.Size(34, 20);
            this.ioO8.TabIndex = 36;
            this.ioO8.Text = "rtio3";
            this.ioO8.title = "8";
            this.ioO8.titleColor = System.Drawing.Color.DimGray;
            this.ioO8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioI8
            // 
            this.ioI8.contactBackColor = System.Drawing.Color.Black;
            this.ioI8.contactColor = System.Drawing.Color.DimGray;
            this.ioI8.contactHighlightColor = System.Drawing.Color.Red;
            this.ioI8.hideOnShrink = false;
            this.ioI8.highlighted = false;
            this.ioI8.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioI8.Location = new System.Drawing.Point(0, 204);
            this.ioI8.Name = "ioI8";
            this.ioI8.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI8.showTitle = true;
            this.ioI8.Size = new System.Drawing.Size(40, 20);
            this.ioI8.TabIndex = 35;
            this.ioI8.Text = "rtio1";
            this.ioI8.title = "8";
            this.ioI8.titleColor = System.Drawing.Color.DimGray;
            this.ioI8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dl50
            // 
            this.dl50.format = "F1";
            this.dl50.hideOnShrink = true;
            this.dl50.lableLength = 3D;
            this.dl50.Location = new System.Drawing.Point(43, 20);
            this.dl50.logScale = false;
            this.dl50.maxVal = 20D;
            this.dl50.minVal = -20D;
            this.dl50.Name = "dl50";
            this.dl50.scaleColor = System.Drawing.Color.DimGray;
            this.dl50.scaleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl50.scaleValueColor = System.Drawing.Color.DimGray;
            this.dl50.showScale = false;
            this.dl50.showScaleValues = false;
            this.dl50.showTitle = true;
            this.dl50.showValue = true;
            this.dl50.Size = new System.Drawing.Size(64, 100);
            this.dl50.slideColor = System.Drawing.Color.Silver;
            this.dl50.slideDirection = AudioProcessor.RTSlider.SlideDirection.Vertical;
            this.dl50.slideKnob = 20D;
            this.dl50.slideMarkColor = System.Drawing.Color.Red;
            this.dl50.slideMarkFill = System.Drawing.Color.DarkRed;
            this.dl50.slideScaleDist = 20D;
            this.dl50.slideScaleWidth = 10D;
            this.dl50.slideWidth = 5D;
            this.dl50.TabIndex = 42;
            this.dl50.Text = "rtSlider1";
            this.dl50.title = "50 Hz";
            this.dl50.titleColor = System.Drawing.Color.DimGray;
            this.dl50.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl50.unit = "dB";
            this.dl50.val = 0D;
            this.dl50.valueColor = System.Drawing.Color.DimGray;
            this.dl50.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dl150
            // 
            this.dl150.format = "F1";
            this.dl150.hideOnShrink = true;
            this.dl150.lableLength = 3D;
            this.dl150.Location = new System.Drawing.Point(112, 20);
            this.dl150.logScale = false;
            this.dl150.maxVal = 20D;
            this.dl150.minVal = -20D;
            this.dl150.Name = "dl150";
            this.dl150.scaleColor = System.Drawing.Color.DimGray;
            this.dl150.scaleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl150.scaleValueColor = System.Drawing.Color.DimGray;
            this.dl150.showScale = false;
            this.dl150.showScaleValues = false;
            this.dl150.showTitle = true;
            this.dl150.showValue = true;
            this.dl150.Size = new System.Drawing.Size(64, 100);
            this.dl150.slideColor = System.Drawing.Color.Silver;
            this.dl150.slideDirection = AudioProcessor.RTSlider.SlideDirection.Vertical;
            this.dl150.slideKnob = 20D;
            this.dl150.slideMarkColor = System.Drawing.Color.Red;
            this.dl150.slideMarkFill = System.Drawing.Color.DarkRed;
            this.dl150.slideScaleDist = 20D;
            this.dl150.slideScaleWidth = 10D;
            this.dl150.slideWidth = 5D;
            this.dl150.TabIndex = 43;
            this.dl150.Text = "rtSlider2";
            this.dl150.title = "150 Hz";
            this.dl150.titleColor = System.Drawing.Color.DimGray;
            this.dl150.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl150.unit = "dB";
            this.dl150.val = 0D;
            this.dl150.valueColor = System.Drawing.Color.DimGray;
            this.dl150.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dl500
            // 
            this.dl500.format = "F1";
            this.dl500.hideOnShrink = true;
            this.dl500.lableLength = 3D;
            this.dl500.Location = new System.Drawing.Point(181, 20);
            this.dl500.logScale = false;
            this.dl500.maxVal = 20D;
            this.dl500.minVal = -20D;
            this.dl500.Name = "dl500";
            this.dl500.scaleColor = System.Drawing.Color.DimGray;
            this.dl500.scaleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl500.scaleValueColor = System.Drawing.Color.DimGray;
            this.dl500.showScale = false;
            this.dl500.showScaleValues = false;
            this.dl500.showTitle = true;
            this.dl500.showValue = true;
            this.dl500.Size = new System.Drawing.Size(64, 100);
            this.dl500.slideColor = System.Drawing.Color.Silver;
            this.dl500.slideDirection = AudioProcessor.RTSlider.SlideDirection.Vertical;
            this.dl500.slideKnob = 20D;
            this.dl500.slideMarkColor = System.Drawing.Color.Red;
            this.dl500.slideMarkFill = System.Drawing.Color.DarkRed;
            this.dl500.slideScaleDist = 20D;
            this.dl500.slideScaleWidth = 10D;
            this.dl500.slideWidth = 5D;
            this.dl500.TabIndex = 44;
            this.dl500.Text = "rtSlider3";
            this.dl500.title = "500 Hz";
            this.dl500.titleColor = System.Drawing.Color.DimGray;
            this.dl500.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl500.unit = "dB";
            this.dl500.val = 0D;
            this.dl500.valueColor = System.Drawing.Color.DimGray;
            this.dl500.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dl1k5
            // 
            this.dl1k5.format = "F1";
            this.dl1k5.hideOnShrink = true;
            this.dl1k5.lableLength = 3D;
            this.dl1k5.Location = new System.Drawing.Point(250, 20);
            this.dl1k5.logScale = false;
            this.dl1k5.maxVal = 20D;
            this.dl1k5.minVal = -20D;
            this.dl1k5.Name = "dl1k5";
            this.dl1k5.scaleColor = System.Drawing.Color.DimGray;
            this.dl1k5.scaleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl1k5.scaleValueColor = System.Drawing.Color.DimGray;
            this.dl1k5.showScale = false;
            this.dl1k5.showScaleValues = false;
            this.dl1k5.showTitle = true;
            this.dl1k5.showValue = true;
            this.dl1k5.Size = new System.Drawing.Size(64, 100);
            this.dl1k5.slideColor = System.Drawing.Color.Silver;
            this.dl1k5.slideDirection = AudioProcessor.RTSlider.SlideDirection.Vertical;
            this.dl1k5.slideKnob = 20D;
            this.dl1k5.slideMarkColor = System.Drawing.Color.Red;
            this.dl1k5.slideMarkFill = System.Drawing.Color.DarkRed;
            this.dl1k5.slideScaleDist = 20D;
            this.dl1k5.slideScaleWidth = 10D;
            this.dl1k5.slideWidth = 5D;
            this.dl1k5.TabIndex = 45;
            this.dl1k5.Text = "rtSlider4";
            this.dl1k5.title = "1.5 kHz";
            this.dl1k5.titleColor = System.Drawing.Color.DimGray;
            this.dl1k5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl1k5.unit = "dB";
            this.dl1k5.val = 0D;
            this.dl1k5.valueColor = System.Drawing.Color.DimGray;
            this.dl1k5.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dl5k
            // 
            this.dl5k.format = "F1";
            this.dl5k.hideOnShrink = true;
            this.dl5k.lableLength = 3D;
            this.dl5k.Location = new System.Drawing.Point(319, 20);
            this.dl5k.logScale = false;
            this.dl5k.maxVal = 20D;
            this.dl5k.minVal = -20D;
            this.dl5k.Name = "dl5k";
            this.dl5k.scaleColor = System.Drawing.Color.DimGray;
            this.dl5k.scaleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl5k.scaleValueColor = System.Drawing.Color.DimGray;
            this.dl5k.showScale = false;
            this.dl5k.showScaleValues = false;
            this.dl5k.showTitle = true;
            this.dl5k.showValue = true;
            this.dl5k.Size = new System.Drawing.Size(64, 100);
            this.dl5k.slideColor = System.Drawing.Color.Silver;
            this.dl5k.slideDirection = AudioProcessor.RTSlider.SlideDirection.Vertical;
            this.dl5k.slideKnob = 20D;
            this.dl5k.slideMarkColor = System.Drawing.Color.Red;
            this.dl5k.slideMarkFill = System.Drawing.Color.DarkRed;
            this.dl5k.slideScaleDist = 20D;
            this.dl5k.slideScaleWidth = 10D;
            this.dl5k.slideWidth = 5D;
            this.dl5k.TabIndex = 46;
            this.dl5k.Text = "rtSlider5";
            this.dl5k.title = "5 kHz";
            this.dl5k.titleColor = System.Drawing.Color.DimGray;
            this.dl5k.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl5k.unit = "dB";
            this.dl5k.val = 0D;
            this.dl5k.valueColor = System.Drawing.Color.DimGray;
            this.dl5k.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dl15k
            // 
            this.dl15k.format = "F1";
            this.dl15k.hideOnShrink = true;
            this.dl15k.lableLength = 3D;
            this.dl15k.Location = new System.Drawing.Point(388, 20);
            this.dl15k.logScale = false;
            this.dl15k.maxVal = 20D;
            this.dl15k.minVal = -20D;
            this.dl15k.Name = "dl15k";
            this.dl15k.scaleColor = System.Drawing.Color.DimGray;
            this.dl15k.scaleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl15k.scaleValueColor = System.Drawing.Color.DimGray;
            this.dl15k.showScale = false;
            this.dl15k.showScaleValues = false;
            this.dl15k.showTitle = true;
            this.dl15k.showValue = true;
            this.dl15k.Size = new System.Drawing.Size(64, 100);
            this.dl15k.slideColor = System.Drawing.Color.Silver;
            this.dl15k.slideDirection = AudioProcessor.RTSlider.SlideDirection.Vertical;
            this.dl15k.slideKnob = 20D;
            this.dl15k.slideMarkColor = System.Drawing.Color.Red;
            this.dl15k.slideMarkFill = System.Drawing.Color.DarkRed;
            this.dl15k.slideScaleDist = 20D;
            this.dl15k.slideScaleWidth = 10D;
            this.dl15k.slideWidth = 5D;
            this.dl15k.TabIndex = 47;
            this.dl15k.Text = "rtSlider6";
            this.dl15k.title = "15 kHz";
            this.dl15k.titleColor = System.Drawing.Color.DimGray;
            this.dl15k.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dl15k.unit = "dB";
            this.dl15k.val = 0D;
            this.dl15k.valueColor = System.Drawing.Color.DimGray;
            this.dl15k.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // Equalizer
            // 
            this.Controls.Add(this.dl15k);
            this.Controls.Add(this.dl5k);
            this.Controls.Add(this.dl1k5);
            this.Controls.Add(this.dl500);
            this.Controls.Add(this.dl150);
            this.Controls.Add(this.dl50);
            this.Controls.Add(this.ioO8);
            this.Controls.Add(this.ioI8);
            this.Controls.Add(this.ioO7);
            this.Controls.Add(this.ioI7);
            this.Controls.Add(this.ioO6);
            this.Controls.Add(this.ioI6);
            this.Controls.Add(this.ioO5);
            this.Controls.Add(this.ioI5);
            this.Controls.Add(this.ioO4);
            this.Controls.Add(this.ioI4);
            this.Controls.Add(this.ioO3);
            this.Controls.Add(this.ioI3);
            this.Controls.Add(this.ioO2);
            this.Controls.Add(this.ioI2);
            this.Controls.Add(this.ioO1);
            this.Controls.Add(this.ioI1);
            this.Name = "Equalizer";
            this.shrinkSize = new System.Drawing.Size(84, 230);
            this.shrinkTitle = "Eq";
            this.Size = new System.Drawing.Size(493, 230);
            this.title = "Equalizer";
            this.ResumeLayout(false);

        }

        int inputs;

        double g50, g150, g500, g1k5, g5k, g15k;
        double g50d, g150d, g500d, g1k5d, g5kd, g15kd;

        private RTIO ioO1;
        private RTIO ioI1;
        private RTIO ioO2;
        private RTIO ioI2;
        private RTIO ioO3;
        private RTIO ioI3;
        private RTIO ioO4;
        private RTIO ioI4;
        private RTIO ioO5;
        private RTIO ioI5;
        private RTIO ioO6;
        private RTIO ioI6;
        private RTIO ioO7;
        private RTIO ioI7;
        private RTIO ioO8;
        private RTSlider dl50;
        private RTSlider dl150;
        private RTSlider dl500;
        private RTSlider dl1k5;
        private RTSlider dl5k;
        private RTSlider dl15k;
        private RTIO ioI8;

        private void init()
        {
            InitializeComponent();

            int h = Height;
            int hh = Height;
            if (inputs < 8) { ioI8.Hide(); ioO8.Hide(); h = ioO8.Location.Y; hh = ioO8.Location.Y; }
            if (inputs < 7) { ioI7.Hide(); ioO7.Hide(); h = ioO7.Location.Y; hh = ioO7.Location.Y; }
            if (inputs < 6) { ioI6.Hide(); ioO6.Hide(); h = ioO6.Location.Y; hh = ioO6.Location.Y; }
            if (inputs < 5) { ioI5.Hide(); ioO5.Hide(); h = ioO5.Location.Y; hh = ioO5.Location.Y; }
            if (inputs < 4) { ioI4.Hide(); ioO4.Hide(); h = ioO5.Location.Y; hh = ioO4.Location.Y; }
            if (inputs < 3) { ioI3.Hide(); ioO3.Hide(); h = ioO5.Location.Y; hh = ioO3.Location.Y; }
            if (inputs < 2) { ioI2.Hide(); ioO2.Hide(); h = ioO5.Location.Y; hh = ioO2.Location.Y; }
            Height = h;
            shrinkSize = new System.Drawing.Size(shrinkSize.Width, hh);

            dl50.val = g50;
            dl150.val = g150;
            dl500.val = g500;
            dl1k5.val = g1k5;
            dl5k.val = g5k;
            dl15k.val = g15k;

            dl50.valueChanged += Dl50_valueChanged;
            dl150.valueChanged += Dl150_valueChanged;
            dl500.valueChanged += Dl500_valueChanged;
            dl1k5.valueChanged += Dl1k5_valueChanged;
            dl5k.valueChanged += Dl5k_valueChanged;
            dl15k.valueChanged += Dl15k_valueChanged;

            g50d = Math.Pow(10, g50 / 20)-1;
            g150d = Math.Pow(10, g150 / 20)-1;
            g500d = Math.Pow(10, g500 / 20)-1;
            g1k5d = Math.Pow(10, g1k5 / 20)-1;
            g5kd = Math.Pow(10, g5k / 20)-1;
            g15kd = Math.Pow(10, g15k / 20)-1;

            processingType = ProcessingType.Processor;
        }


        public Equalizer() : this(8)
        {
        }

        public Equalizer(int _inputs) : base()
        {
            inputs = _inputs;
            g50 = 0;
            g150 = 0;
            g500 = 0;
            g1k5 = 0;
            g5k = 0;
            g15k = 0;

            init();
        }

        public Equalizer(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            inputs = src.ReadInt32();
            g50 = src.ReadDouble();
            g150 = src.ReadDouble();
            g500 = src.ReadDouble();
            g1k5 = src.ReadDouble();
            g5k = src.ReadDouble();
            g15k = src.ReadDouble();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(inputs);
            tgt.Write(g50);
            tgt.Write(g150);
            tgt.Write(g500);
            tgt.Write(g1k5);
            tgt.Write(g5k);
            tgt.Write(g15k);

        }


        private void Dl15k_valueChanged(object sender, EventArgs e)
        {
            g15k = dl15k.val;
            g15kd = Math.Pow(10, g15k / 20)-1;
        }

        private void Dl5k_valueChanged(object sender, EventArgs e)
        {
            g5k = dl5k.val;
            g5kd = Math.Pow(10, g5k / 20) - 1;
        }

        private void Dl1k5_valueChanged(object sender, EventArgs e)
        {
            g1k5 = dl1k5.val;
            g1k5d = Math.Pow(10, g1k5 / 20) - 1;
        }

        private void Dl500_valueChanged(object sender, EventArgs e)
        {
            g500 = dl500.val;
            g500d = Math.Pow(10, g500 / 20) - 1;
        }

        private void Dl150_valueChanged(object sender, EventArgs e)
        {
            g150 = dl150.val;
            g150d = Math.Pow(10, g150 / 20) - 1;
        }

        private void Dl50_valueChanged(object sender, EventArgs e)
        {
            g50 = dl50.val;
            g50d = Math.Pow(10, g50 / 20) - 1;
        }

        BiQuad[] filter50;
        BiQuad[] filter150;
        BiQuad[] filter500;
        BiQuad[] filter1k5;
        BiQuad[] filter5k;
        BiQuad[] filter15k;

        public override void tick()
        {
            if (!_active)
                return;

            SignalBuffer[] sin = new SignalBuffer[inputs];
            SignalBuffer[] sout = new SignalBuffer[inputs];

            if (inputs >= 1) { sin[0] = getSignalInputBuffer(ioI1); sout[0] = getSignalOutputBuffer(ioO1); }
            if (inputs >= 2) { sin[1] = getSignalInputBuffer(ioI2); sout[1] = getSignalOutputBuffer(ioO2); }
            if (inputs >= 3) { sin[2] = getSignalInputBuffer(ioI3); sout[2] = getSignalOutputBuffer(ioO3); }
            if (inputs >= 4) { sin[3] = getSignalInputBuffer(ioI4); sout[3] = getSignalOutputBuffer(ioO4); }
            if (inputs >= 5) { sin[4] = getSignalInputBuffer(ioI5); sout[4] = getSignalOutputBuffer(ioO5); }
            if (inputs >= 6) { sin[5] = getSignalInputBuffer(ioI6); sout[5] = getSignalOutputBuffer(ioO6); }
            if (inputs >= 7) { sin[6] = getSignalInputBuffer(ioI7); sout[6] = getSignalOutputBuffer(ioO7); }
            if (inputs >= 8) { sin[7] = getSignalInputBuffer(ioI8); sout[7] = getSignalOutputBuffer(ioO8); }

            const double a = 0.7;
            // const double b = 0.7;

            if (filter50 == null)
            {
                filter50 = new BiQuad[inputs];
                for (int i = 0; i < inputs; i++)
                    filter50[i] = new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.BandPass,50,a);
            }
            if (filter150 == null)
            {
                filter150 = new BiQuad[inputs];
                for (int i = 0; i < inputs; i++)
                    filter150[i] = new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.BandPass, 150, a);
            }
            if (filter500 == null)
            {
                filter500 = new BiQuad[inputs];
                for (int i = 0; i < inputs; i++)
                    filter500[i] = new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.BandPass, 500, a);
            }
            if (filter1k5 == null)
            {
                filter1k5 = new BiQuad[inputs];
                for (int i = 0; i < inputs; i++)
                    filter1k5[i] = new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.BandPass, 1500, a);
            }
            if (filter5k == null)
            {
                filter5k = new BiQuad[inputs];
                for (int i = 0; i < inputs; i++)
                    filter5k[i] = new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.BandPass, 5000, a);
            }
            if (filter15k == null)
            {
                filter15k = new BiQuad[inputs];
                for (int i = 0; i < inputs; i++)
                    filter15k[i] = new BiQuad(owner.sampleRate, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.BandPass, 15000, a);
            }


            for (int i=0;i<inputs;i++)
            {
                if (sin[i] != null)
                    for (int j=0;j<owner.blockSize;j++)
                    {
                        double din = sin[i].data[j];
                        double a50 = filter50[i].filter(din);
                        double a150 = filter150[i].filter(din);
                        double a500 = filter500[i].filter(din);
                        double a1k5 = filter1k5[i].filter(din);
                        double a5k = filter5k[i].filter(din);
                        double a15k = filter15k[i].filter(din);
                        if (sout[i] != null)
                            sout[i].data[j] = din + a50 * g50d + a150 * g150d + a500 * g500d + a1k5 * g1k5d + a5k * g5kd + a15k * g15kd;
                    }
            }

        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "Equalizer", "1 x" }; }
            public override RTForm Instantiate() { return new Equalizer(1); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "Equalizer", "2 x" }; }
            public override RTForm Instantiate() { return new Equalizer(2); }
        }
        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "Equalizer", "4 x" }; }
            public override RTForm Instantiate() { return new Equalizer(4); }
        }
        class RegisterClass6 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "Equalizer", "6 x" }; }
            public override RTForm Instantiate() { return new Equalizer(6); }
        }
        class RegisterClass8 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Filter", "Equalizer", "8 x" }; }
            public override RTForm Instantiate() { return new Equalizer(8); }
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


