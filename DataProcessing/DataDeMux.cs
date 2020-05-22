using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.DataProcessing
{
    class DataDeMux : RTForm
    {

        public void InitializeComponent()
        {
            this.ioOut1 = new AudioProcessor.RTIO();
            this.ioOut2 = new AudioProcessor.RTIO();
            this.ioOut3 = new AudioProcessor.RTIO();
            this.ioOut4 = new AudioProcessor.RTIO();
            this.ioOut5 = new AudioProcessor.RTIO();
            this.ioOut6 = new AudioProcessor.RTIO();
            this.ioOut7 = new AudioProcessor.RTIO();
            this.ioOut8 = new AudioProcessor.RTIO();
            this.ioData = new AudioProcessor.RTIO();
            this.ioTrig = new AudioProcessor.RTIO();
            this.ioOut16 = new AudioProcessor.RTIO();
            this.ioOut15 = new AudioProcessor.RTIO();
            this.ioOut14 = new AudioProcessor.RTIO();
            this.ioOut13 = new AudioProcessor.RTIO();
            this.ioOut12 = new AudioProcessor.RTIO();
            this.ioOut11 = new AudioProcessor.RTIO();
            this.ioOut10 = new AudioProcessor.RTIO();
            this.ioOut9 = new AudioProcessor.RTIO();
            this.cl1 = new AudioProcessor.RTChoice();
            this.cl2 = new AudioProcessor.RTChoice();
            this.cl4 = new AudioProcessor.RTChoice();
            this.cl3 = new AudioProcessor.RTChoice();
            this.cl8 = new AudioProcessor.RTChoice();
            this.cl7 = new AudioProcessor.RTChoice();
            this.cl6 = new AudioProcessor.RTChoice();
            this.cl5 = new AudioProcessor.RTChoice();
            this.cl16 = new AudioProcessor.RTChoice();
            this.cl15 = new AudioProcessor.RTChoice();
            this.cl14 = new AudioProcessor.RTChoice();
            this.cl13 = new AudioProcessor.RTChoice();
            this.cl12 = new AudioProcessor.RTChoice();
            this.cl11 = new AudioProcessor.RTChoice();
            this.cl10 = new AudioProcessor.RTChoice();
            this.cl9 = new AudioProcessor.RTChoice();
            this.SuspendLayout();
            // 
            // ioOut1
            // 
            this.ioOut1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut1.contactBackColor = System.Drawing.Color.Black;
            this.ioOut1.contactColor = System.Drawing.Color.DimGray;
            this.ioOut1.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut1.highlighted = false;
            this.ioOut1.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioOut1.Location = new System.Drawing.Point(121, 51);
            this.ioOut1.Name = "ioOut1";
            this.ioOut1.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut1.showTitle = false;
            this.ioOut1.Size = new System.Drawing.Size(20, 20);
            this.ioOut1.TabIndex = 17;
            this.ioOut1.Text = "rtio9";
            this.ioOut1.title = "O";
            this.ioOut1.titleColor = System.Drawing.Color.DimGray;
            this.ioOut1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioOut2
            // 
            this.ioOut2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut2.contactBackColor = System.Drawing.Color.Black;
            this.ioOut2.contactColor = System.Drawing.Color.DimGray;
            this.ioOut2.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut2.highlighted = false;
            this.ioOut2.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioOut2.Location = new System.Drawing.Point(121, 77);
            this.ioOut2.Name = "ioOut2";
            this.ioOut2.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut2.showTitle = false;
            this.ioOut2.Size = new System.Drawing.Size(20, 20);
            this.ioOut2.TabIndex = 18;
            this.ioOut2.Text = "rtio9";
            this.ioOut2.title = "O";
            this.ioOut2.titleColor = System.Drawing.Color.DimGray;
            this.ioOut2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioOut3
            // 
            this.ioOut3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut3.contactBackColor = System.Drawing.Color.Black;
            this.ioOut3.contactColor = System.Drawing.Color.DimGray;
            this.ioOut3.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut3.highlighted = false;
            this.ioOut3.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioOut3.Location = new System.Drawing.Point(121, 103);
            this.ioOut3.Name = "ioOut3";
            this.ioOut3.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut3.showTitle = false;
            this.ioOut3.Size = new System.Drawing.Size(20, 20);
            this.ioOut3.TabIndex = 19;
            this.ioOut3.Text = "rtio9";
            this.ioOut3.title = "O";
            this.ioOut3.titleColor = System.Drawing.Color.DimGray;
            this.ioOut3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioOut4
            // 
            this.ioOut4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut4.contactBackColor = System.Drawing.Color.Black;
            this.ioOut4.contactColor = System.Drawing.Color.DimGray;
            this.ioOut4.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut4.highlighted = false;
            this.ioOut4.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioOut4.Location = new System.Drawing.Point(121, 129);
            this.ioOut4.Name = "ioOut4";
            this.ioOut4.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut4.showTitle = false;
            this.ioOut4.Size = new System.Drawing.Size(20, 20);
            this.ioOut4.TabIndex = 20;
            this.ioOut4.Text = "rtio9";
            this.ioOut4.title = "O";
            this.ioOut4.titleColor = System.Drawing.Color.DimGray;
            this.ioOut4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioOut5
            // 
            this.ioOut5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut5.contactBackColor = System.Drawing.Color.Black;
            this.ioOut5.contactColor = System.Drawing.Color.DimGray;
            this.ioOut5.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut5.highlighted = false;
            this.ioOut5.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioOut5.Location = new System.Drawing.Point(121, 155);
            this.ioOut5.Name = "ioOut5";
            this.ioOut5.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut5.showTitle = false;
            this.ioOut5.Size = new System.Drawing.Size(20, 20);
            this.ioOut5.TabIndex = 21;
            this.ioOut5.Text = "rtio9";
            this.ioOut5.title = "O";
            this.ioOut5.titleColor = System.Drawing.Color.DimGray;
            this.ioOut5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioOut6
            // 
            this.ioOut6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut6.contactBackColor = System.Drawing.Color.Black;
            this.ioOut6.contactColor = System.Drawing.Color.DimGray;
            this.ioOut6.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut6.highlighted = false;
            this.ioOut6.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioOut6.Location = new System.Drawing.Point(121, 181);
            this.ioOut6.Name = "ioOut6";
            this.ioOut6.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut6.showTitle = false;
            this.ioOut6.Size = new System.Drawing.Size(20, 20);
            this.ioOut6.TabIndex = 22;
            this.ioOut6.Text = "rtio9";
            this.ioOut6.title = "O";
            this.ioOut6.titleColor = System.Drawing.Color.DimGray;
            this.ioOut6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioOut7
            // 
            this.ioOut7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut7.contactBackColor = System.Drawing.Color.Black;
            this.ioOut7.contactColor = System.Drawing.Color.DimGray;
            this.ioOut7.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut7.highlighted = false;
            this.ioOut7.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioOut7.Location = new System.Drawing.Point(121, 207);
            this.ioOut7.Name = "ioOut7";
            this.ioOut7.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut7.showTitle = false;
            this.ioOut7.Size = new System.Drawing.Size(20, 20);
            this.ioOut7.TabIndex = 23;
            this.ioOut7.Text = "rtio9";
            this.ioOut7.title = "O";
            this.ioOut7.titleColor = System.Drawing.Color.DimGray;
            this.ioOut7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioOut8
            // 
            this.ioOut8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut8.contactBackColor = System.Drawing.Color.Black;
            this.ioOut8.contactColor = System.Drawing.Color.DimGray;
            this.ioOut8.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut8.highlighted = false;
            this.ioOut8.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioOut8.Location = new System.Drawing.Point(121, 233);
            this.ioOut8.Name = "ioOut8";
            this.ioOut8.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut8.showTitle = false;
            this.ioOut8.Size = new System.Drawing.Size(20, 20);
            this.ioOut8.TabIndex = 25;
            this.ioOut8.Text = "rtio9";
            this.ioOut8.title = "O";
            this.ioOut8.titleColor = System.Drawing.Color.DimGray;
            this.ioOut8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioData
            // 
            this.ioData.contactBackColor = System.Drawing.Color.Black;
            this.ioData.contactColor = System.Drawing.Color.DimGray;
            this.ioData.contactHighlightColor = System.Drawing.Color.Red;
            this.ioData.highlighted = false;
            this.ioData.IOtype = AudioProcessor.RTIO.ProcessingIOType.DataInput;
            this.ioData.Location = new System.Drawing.Point(0, 25);
            this.ioData.Name = "ioData";
            this.ioData.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioData.showTitle = true;
            this.ioData.Size = new System.Drawing.Size(54, 20);
            this.ioData.TabIndex = 26;
            this.ioData.Text = "rtio9";
            this.ioData.title = "Data";
            this.ioData.titleColor = System.Drawing.Color.DimGray;
            this.ioData.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioTrig
            // 
            this.ioTrig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioTrig.contactBackColor = System.Drawing.Color.Black;
            this.ioTrig.contactColor = System.Drawing.Color.DimGray;
            this.ioTrig.contactHighlightColor = System.Drawing.Color.Red;
            this.ioTrig.highlighted = false;
            this.ioTrig.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioTrig.Location = new System.Drawing.Point(91, 25);
            this.ioTrig.Name = "ioTrig";
            this.ioTrig.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioTrig.showTitle = true;
            this.ioTrig.Size = new System.Drawing.Size(50, 20);
            this.ioTrig.TabIndex = 27;
            this.ioTrig.Text = "rtio9";
            this.ioTrig.title = "Trig";
            this.ioTrig.titleColor = System.Drawing.Color.DimGray;
            this.ioTrig.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioOut16
            // 
            this.ioOut16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut16.contactBackColor = System.Drawing.Color.Black;
            this.ioOut16.contactColor = System.Drawing.Color.DimGray;
            this.ioOut16.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut16.highlighted = false;
            this.ioOut16.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioOut16.Location = new System.Drawing.Point(121, 441);
            this.ioOut16.Name = "ioOut16";
            this.ioOut16.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut16.showTitle = false;
            this.ioOut16.Size = new System.Drawing.Size(20, 20);
            this.ioOut16.TabIndex = 35;
            this.ioOut16.Text = "rtio9";
            this.ioOut16.title = "O";
            this.ioOut16.titleColor = System.Drawing.Color.DimGray;
            this.ioOut16.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioOut15
            // 
            this.ioOut15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut15.contactBackColor = System.Drawing.Color.Black;
            this.ioOut15.contactColor = System.Drawing.Color.DimGray;
            this.ioOut15.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut15.highlighted = false;
            this.ioOut15.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioOut15.Location = new System.Drawing.Point(121, 415);
            this.ioOut15.Name = "ioOut15";
            this.ioOut15.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut15.showTitle = false;
            this.ioOut15.Size = new System.Drawing.Size(20, 20);
            this.ioOut15.TabIndex = 34;
            this.ioOut15.Text = "rtio9";
            this.ioOut15.title = "O";
            this.ioOut15.titleColor = System.Drawing.Color.DimGray;
            this.ioOut15.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioOut14
            // 
            this.ioOut14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut14.contactBackColor = System.Drawing.Color.Black;
            this.ioOut14.contactColor = System.Drawing.Color.DimGray;
            this.ioOut14.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut14.highlighted = false;
            this.ioOut14.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioOut14.Location = new System.Drawing.Point(121, 389);
            this.ioOut14.Name = "ioOut14";
            this.ioOut14.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut14.showTitle = false;
            this.ioOut14.Size = new System.Drawing.Size(20, 20);
            this.ioOut14.TabIndex = 33;
            this.ioOut14.Text = "rtio9";
            this.ioOut14.title = "O";
            this.ioOut14.titleColor = System.Drawing.Color.DimGray;
            this.ioOut14.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioOut13
            // 
            this.ioOut13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut13.contactBackColor = System.Drawing.Color.Black;
            this.ioOut13.contactColor = System.Drawing.Color.DimGray;
            this.ioOut13.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut13.highlighted = false;
            this.ioOut13.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioOut13.Location = new System.Drawing.Point(121, 363);
            this.ioOut13.Name = "ioOut13";
            this.ioOut13.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut13.showTitle = false;
            this.ioOut13.Size = new System.Drawing.Size(20, 20);
            this.ioOut13.TabIndex = 32;
            this.ioOut13.Text = "rtio9";
            this.ioOut13.title = "O";
            this.ioOut13.titleColor = System.Drawing.Color.DimGray;
            this.ioOut13.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioOut12
            // 
            this.ioOut12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut12.contactBackColor = System.Drawing.Color.Black;
            this.ioOut12.contactColor = System.Drawing.Color.DimGray;
            this.ioOut12.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut12.highlighted = false;
            this.ioOut12.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioOut12.Location = new System.Drawing.Point(121, 337);
            this.ioOut12.Name = "ioOut12";
            this.ioOut12.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut12.showTitle = false;
            this.ioOut12.Size = new System.Drawing.Size(20, 20);
            this.ioOut12.TabIndex = 31;
            this.ioOut12.Text = "rtio9";
            this.ioOut12.title = "O";
            this.ioOut12.titleColor = System.Drawing.Color.DimGray;
            this.ioOut12.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioOut11
            // 
            this.ioOut11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut11.contactBackColor = System.Drawing.Color.Black;
            this.ioOut11.contactColor = System.Drawing.Color.DimGray;
            this.ioOut11.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut11.highlighted = false;
            this.ioOut11.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioOut11.Location = new System.Drawing.Point(121, 311);
            this.ioOut11.Name = "ioOut11";
            this.ioOut11.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut11.showTitle = false;
            this.ioOut11.Size = new System.Drawing.Size(20, 20);
            this.ioOut11.TabIndex = 30;
            this.ioOut11.Text = "rtio9";
            this.ioOut11.title = "O";
            this.ioOut11.titleColor = System.Drawing.Color.DimGray;
            this.ioOut11.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioOut10
            // 
            this.ioOut10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut10.contactBackColor = System.Drawing.Color.Black;
            this.ioOut10.contactColor = System.Drawing.Color.DimGray;
            this.ioOut10.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut10.highlighted = false;
            this.ioOut10.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioOut10.Location = new System.Drawing.Point(121, 285);
            this.ioOut10.Name = "ioOut10";
            this.ioOut10.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut10.showTitle = false;
            this.ioOut10.Size = new System.Drawing.Size(20, 20);
            this.ioOut10.TabIndex = 29;
            this.ioOut10.Text = "rtio9";
            this.ioOut10.title = "O";
            this.ioOut10.titleColor = System.Drawing.Color.DimGray;
            this.ioOut10.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioOut9
            // 
            this.ioOut9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut9.contactBackColor = System.Drawing.Color.Black;
            this.ioOut9.contactColor = System.Drawing.Color.DimGray;
            this.ioOut9.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut9.highlighted = false;
            this.ioOut9.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            this.ioOut9.Location = new System.Drawing.Point(121, 259);
            this.ioOut9.Name = "ioOut9";
            this.ioOut9.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut9.showTitle = false;
            this.ioOut9.Size = new System.Drawing.Size(20, 20);
            this.ioOut9.TabIndex = 28;
            this.ioOut9.Text = "rtio9";
            this.ioOut9.title = "O";
            this.ioOut9.titleColor = System.Drawing.Color.DimGray;
            this.ioOut9.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // cl1
            // 
            this.cl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cl1.backColor = System.Drawing.Color.Black;
            this.cl1.choiceType = AudioProcessor.RTChoice.ChoiceType.Numeric;
            this.cl1.frontColor = System.Drawing.Color.DimGray;
            this.cl1.Location = new System.Drawing.Point(65, 51);
            this.cl1.Name = "cl1";
            this.cl1.numericMax = 100000;
            this.cl1.numericMin = 0;
            this.cl1.offString = "off";
            this.cl1.selectedItem = 0;
            this.cl1.Size = new System.Drawing.Size(45, 20);
            this.cl1.TabIndex = 36;
            this.cl1.Text = "rtChoice1";
            this.cl1.title = "";
            this.cl1.titleColor = System.Drawing.Color.DimGray;
            this.cl1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl1.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl1.xdim = 30;
            // 
            // cl2
            // 
            this.cl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cl2.backColor = System.Drawing.Color.Black;
            this.cl2.choiceType = AudioProcessor.RTChoice.ChoiceType.Numeric;
            this.cl2.frontColor = System.Drawing.Color.DimGray;
            this.cl2.Location = new System.Drawing.Point(65, 77);
            this.cl2.Name = "cl2";
            this.cl2.numericMax = 100000;
            this.cl2.numericMin = 0;
            this.cl2.offString = "off";
            this.cl2.selectedItem = 0;
            this.cl2.Size = new System.Drawing.Size(45, 20);
            this.cl2.TabIndex = 37;
            this.cl2.Text = "rtChoice2";
            this.cl2.title = "";
            this.cl2.titleColor = System.Drawing.Color.DimGray;
            this.cl2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl2.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl2.xdim = 30;
            // 
            // cl4
            // 
            this.cl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cl4.backColor = System.Drawing.Color.Black;
            this.cl4.choiceType = AudioProcessor.RTChoice.ChoiceType.Numeric;
            this.cl4.frontColor = System.Drawing.Color.DimGray;
            this.cl4.Location = new System.Drawing.Point(65, 129);
            this.cl4.Name = "cl4";
            this.cl4.numericMax = 100000;
            this.cl4.numericMin = 0;
            this.cl4.offString = "off";
            this.cl4.selectedItem = 0;
            this.cl4.Size = new System.Drawing.Size(45, 20);
            this.cl4.TabIndex = 39;
            this.cl4.Text = "rtChoice3";
            this.cl4.title = "";
            this.cl4.titleColor = System.Drawing.Color.DimGray;
            this.cl4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl4.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl4.xdim = 30;
            // 
            // cl3
            // 
            this.cl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cl3.backColor = System.Drawing.Color.Black;
            this.cl3.choiceType = AudioProcessor.RTChoice.ChoiceType.Numeric;
            this.cl3.frontColor = System.Drawing.Color.DimGray;
            this.cl3.Location = new System.Drawing.Point(65, 103);
            this.cl3.Name = "cl3";
            this.cl3.numericMax = 100000;
            this.cl3.numericMin = 0;
            this.cl3.offString = "off";
            this.cl3.selectedItem = 0;
            this.cl3.Size = new System.Drawing.Size(45, 20);
            this.cl3.TabIndex = 38;
            this.cl3.Text = "rtChoice4";
            this.cl3.title = "";
            this.cl3.titleColor = System.Drawing.Color.DimGray;
            this.cl3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl3.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl3.xdim = 30;
            // 
            // cl8
            // 
            this.cl8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cl8.backColor = System.Drawing.Color.Black;
            this.cl8.choiceType = AudioProcessor.RTChoice.ChoiceType.Numeric;
            this.cl8.frontColor = System.Drawing.Color.DimGray;
            this.cl8.Location = new System.Drawing.Point(65, 233);
            this.cl8.Name = "cl8";
            this.cl8.numericMax = 100000;
            this.cl8.numericMin = 0;
            this.cl8.offString = "off";
            this.cl8.selectedItem = 0;
            this.cl8.Size = new System.Drawing.Size(45, 20);
            this.cl8.TabIndex = 43;
            this.cl8.Text = "rtChoice5";
            this.cl8.title = "";
            this.cl8.titleColor = System.Drawing.Color.DimGray;
            this.cl8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl8.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl8.xdim = 30;
            // 
            // cl7
            // 
            this.cl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cl7.backColor = System.Drawing.Color.Black;
            this.cl7.choiceType = AudioProcessor.RTChoice.ChoiceType.Numeric;
            this.cl7.frontColor = System.Drawing.Color.DimGray;
            this.cl7.Location = new System.Drawing.Point(65, 207);
            this.cl7.Name = "cl7";
            this.cl7.numericMax = 100000;
            this.cl7.numericMin = 0;
            this.cl7.offString = "off";
            this.cl7.selectedItem = 0;
            this.cl7.Size = new System.Drawing.Size(45, 20);
            this.cl7.TabIndex = 42;
            this.cl7.Text = "rtChoice6";
            this.cl7.title = "";
            this.cl7.titleColor = System.Drawing.Color.DimGray;
            this.cl7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl7.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl7.xdim = 30;
            // 
            // cl6
            // 
            this.cl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cl6.backColor = System.Drawing.Color.Black;
            this.cl6.choiceType = AudioProcessor.RTChoice.ChoiceType.Numeric;
            this.cl6.frontColor = System.Drawing.Color.DimGray;
            this.cl6.Location = new System.Drawing.Point(65, 181);
            this.cl6.Name = "cl6";
            this.cl6.numericMax = 100000;
            this.cl6.numericMin = 0;
            this.cl6.offString = "off";
            this.cl6.selectedItem = 0;
            this.cl6.Size = new System.Drawing.Size(45, 20);
            this.cl6.TabIndex = 41;
            this.cl6.Text = "rtChoice7";
            this.cl6.title = "";
            this.cl6.titleColor = System.Drawing.Color.DimGray;
            this.cl6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl6.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl6.xdim = 30;
            // 
            // cl5
            // 
            this.cl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cl5.backColor = System.Drawing.Color.Black;
            this.cl5.choiceType = AudioProcessor.RTChoice.ChoiceType.Numeric;
            this.cl5.frontColor = System.Drawing.Color.DimGray;
            this.cl5.Location = new System.Drawing.Point(65, 155);
            this.cl5.Name = "cl5";
            this.cl5.numericMax = 100000;
            this.cl5.numericMin = 0;
            this.cl5.offString = "off";
            this.cl5.selectedItem = 0;
            this.cl5.Size = new System.Drawing.Size(45, 20);
            this.cl5.TabIndex = 40;
            this.cl5.Text = "rtChoice8";
            this.cl5.title = "";
            this.cl5.titleColor = System.Drawing.Color.DimGray;
            this.cl5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl5.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl5.xdim = 30;
            // 
            // cl16
            // 
            this.cl16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cl16.backColor = System.Drawing.Color.Black;
            this.cl16.choiceType = AudioProcessor.RTChoice.ChoiceType.Numeric;
            this.cl16.frontColor = System.Drawing.Color.DimGray;
            this.cl16.Location = new System.Drawing.Point(65, 441);
            this.cl16.Name = "cl16";
            this.cl16.numericMax = 100000;
            this.cl16.numericMin = 0;
            this.cl16.offString = "off";
            this.cl16.selectedItem = 0;
            this.cl16.Size = new System.Drawing.Size(45, 20);
            this.cl16.TabIndex = 51;
            this.cl16.Text = "rtChoice9";
            this.cl16.title = "";
            this.cl16.titleColor = System.Drawing.Color.DimGray;
            this.cl16.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl16.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl16.xdim = 30;
            // 
            // cl15
            // 
            this.cl15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cl15.backColor = System.Drawing.Color.Black;
            this.cl15.choiceType = AudioProcessor.RTChoice.ChoiceType.Numeric;
            this.cl15.frontColor = System.Drawing.Color.DimGray;
            this.cl15.Location = new System.Drawing.Point(65, 415);
            this.cl15.Name = "cl15";
            this.cl15.numericMax = 100000;
            this.cl15.numericMin = 0;
            this.cl15.offString = "off";
            this.cl15.selectedItem = 0;
            this.cl15.Size = new System.Drawing.Size(45, 20);
            this.cl15.TabIndex = 50;
            this.cl15.Text = "rtChoice10";
            this.cl15.title = "";
            this.cl15.titleColor = System.Drawing.Color.DimGray;
            this.cl15.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl15.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl15.xdim = 30;
            // 
            // cl14
            // 
            this.cl14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cl14.backColor = System.Drawing.Color.Black;
            this.cl14.choiceType = AudioProcessor.RTChoice.ChoiceType.Numeric;
            this.cl14.frontColor = System.Drawing.Color.DimGray;
            this.cl14.Location = new System.Drawing.Point(65, 389);
            this.cl14.Name = "cl14";
            this.cl14.numericMax = 100000;
            this.cl14.numericMin = 0;
            this.cl14.offString = "off";
            this.cl14.selectedItem = 0;
            this.cl14.Size = new System.Drawing.Size(45, 20);
            this.cl14.TabIndex = 49;
            this.cl14.Text = "rtChoice11";
            this.cl14.title = "";
            this.cl14.titleColor = System.Drawing.Color.DimGray;
            this.cl14.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl14.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl14.xdim = 30;
            // 
            // cl13
            // 
            this.cl13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cl13.backColor = System.Drawing.Color.Black;
            this.cl13.choiceType = AudioProcessor.RTChoice.ChoiceType.Numeric;
            this.cl13.frontColor = System.Drawing.Color.DimGray;
            this.cl13.Location = new System.Drawing.Point(65, 363);
            this.cl13.Name = "cl13";
            this.cl13.numericMax = 100000;
            this.cl13.numericMin = 0;
            this.cl13.offString = "off";
            this.cl13.selectedItem = 0;
            this.cl13.Size = new System.Drawing.Size(45, 20);
            this.cl13.TabIndex = 48;
            this.cl13.Text = "rtChoice12";
            this.cl13.title = "";
            this.cl13.titleColor = System.Drawing.Color.DimGray;
            this.cl13.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl13.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl13.xdim = 30;
            // 
            // cl12
            // 
            this.cl12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cl12.backColor = System.Drawing.Color.Black;
            this.cl12.choiceType = AudioProcessor.RTChoice.ChoiceType.Numeric;
            this.cl12.frontColor = System.Drawing.Color.DimGray;
            this.cl12.Location = new System.Drawing.Point(65, 337);
            this.cl12.Name = "cl12";
            this.cl12.numericMax = 100000;
            this.cl12.numericMin = 0;
            this.cl12.offString = "off";
            this.cl12.selectedItem = 0;
            this.cl12.Size = new System.Drawing.Size(45, 20);
            this.cl12.TabIndex = 47;
            this.cl12.Text = "rtChoice13";
            this.cl12.title = "";
            this.cl12.titleColor = System.Drawing.Color.DimGray;
            this.cl12.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl12.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl12.xdim = 30;
            // 
            // cl11
            // 
            this.cl11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cl11.backColor = System.Drawing.Color.Black;
            this.cl11.choiceType = AudioProcessor.RTChoice.ChoiceType.Numeric;
            this.cl11.frontColor = System.Drawing.Color.DimGray;
            this.cl11.Location = new System.Drawing.Point(65, 311);
            this.cl11.Name = "cl11";
            this.cl11.numericMax = 100000;
            this.cl11.numericMin = 0;
            this.cl11.offString = "off";
            this.cl11.selectedItem = 0;
            this.cl11.Size = new System.Drawing.Size(45, 20);
            this.cl11.TabIndex = 46;
            this.cl11.Text = "rtChoice14";
            this.cl11.title = "";
            this.cl11.titleColor = System.Drawing.Color.DimGray;
            this.cl11.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl11.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl11.xdim = 30;
            // 
            // cl10
            // 
            this.cl10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cl10.backColor = System.Drawing.Color.Black;
            this.cl10.choiceType = AudioProcessor.RTChoice.ChoiceType.Numeric;
            this.cl10.frontColor = System.Drawing.Color.DimGray;
            this.cl10.Location = new System.Drawing.Point(65, 285);
            this.cl10.Name = "cl10";
            this.cl10.numericMax = 100000;
            this.cl10.numericMin = 0;
            this.cl10.offString = "off";
            this.cl10.selectedItem = 0;
            this.cl10.Size = new System.Drawing.Size(45, 20);
            this.cl10.TabIndex = 45;
            this.cl10.Text = "rtChoice15";
            this.cl10.title = "";
            this.cl10.titleColor = System.Drawing.Color.DimGray;
            this.cl10.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl10.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl10.xdim = 30;
            // 
            // cl9
            // 
            this.cl9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cl9.backColor = System.Drawing.Color.Black;
            this.cl9.choiceType = AudioProcessor.RTChoice.ChoiceType.Numeric;
            this.cl9.frontColor = System.Drawing.Color.DimGray;
            this.cl9.Location = new System.Drawing.Point(65, 259);
            this.cl9.Name = "cl9";
            this.cl9.numericMax = 100000;
            this.cl9.numericMin = 0;
            this.cl9.offString = "off";
            this.cl9.selectedItem = 0;
            this.cl9.Size = new System.Drawing.Size(45, 20);
            this.cl9.TabIndex = 44;
            this.cl9.Text = "rtChoice16";
            this.cl9.title = "";
            this.cl9.titleColor = System.Drawing.Color.DimGray;
            this.cl9.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl9.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cl9.xdim = 30;
            // 
            // DataDeMux
            // 
            this.Controls.Add(this.cl16);
            this.Controls.Add(this.cl15);
            this.Controls.Add(this.cl14);
            this.Controls.Add(this.cl13);
            this.Controls.Add(this.cl12);
            this.Controls.Add(this.cl11);
            this.Controls.Add(this.cl10);
            this.Controls.Add(this.cl9);
            this.Controls.Add(this.cl8);
            this.Controls.Add(this.cl7);
            this.Controls.Add(this.cl6);
            this.Controls.Add(this.cl5);
            this.Controls.Add(this.cl4);
            this.Controls.Add(this.cl3);
            this.Controls.Add(this.cl2);
            this.Controls.Add(this.cl1);
            this.Controls.Add(this.ioOut16);
            this.Controls.Add(this.ioOut15);
            this.Controls.Add(this.ioOut14);
            this.Controls.Add(this.ioOut13);
            this.Controls.Add(this.ioOut12);
            this.Controls.Add(this.ioOut11);
            this.Controls.Add(this.ioOut10);
            this.Controls.Add(this.ioOut9);
            this.Controls.Add(this.ioTrig);
            this.Controls.Add(this.ioData);
            this.Controls.Add(this.ioOut8);
            this.Controls.Add(this.ioOut7);
            this.Controls.Add(this.ioOut6);
            this.Controls.Add(this.ioOut5);
            this.Controls.Add(this.ioOut4);
            this.Controls.Add(this.ioOut3);
            this.Controls.Add(this.ioOut2);
            this.Controls.Add(this.ioOut1);
            this.Name = "DataDeMux";
            this.shrinkSize = new System.Drawing.Size(104, 469);
            this.shrinkTitle = "DX";
            this.Size = new System.Drawing.Size(141, 469);
            this.title = "DataDeMux";
            this.ResumeLayout(false);

        }

        int outputs;
        int[] selector;
        private RTIO ioOut1;
        private RTIO ioOut2;
        private RTIO ioOut3;
        private RTIO ioOut4;
        private RTIO ioOut5;
        private RTIO ioOut6;
        private RTIO ioOut8;
        private RTIO ioData;
        private RTIO ioTrig;
        private RTIO ioOut16;
        private RTIO ioOut15;
        private RTIO ioOut14;
        private RTIO ioOut13;
        private RTIO ioOut12;
        private RTIO ioOut11;
        private RTIO ioOut10;
        private RTIO ioOut9;
        private RTChoice cl1;
        private RTChoice cl2;
        private RTChoice cl4;
        private RTChoice cl3;
        private RTChoice cl8;
        private RTChoice cl7;
        private RTChoice cl6;
        private RTChoice cl5;
        private RTChoice cl16;
        private RTChoice cl15;
        private RTChoice cl14;
        private RTChoice cl13;
        private RTChoice cl12;
        private RTChoice cl11;
        private RTChoice cl10;
        private RTChoice cl9;
        private RTIO ioOut7;

        private void init()
        {
            InitializeComponent();

            int h = Height;
            if (outputs < 16) { ioOut16.Hide(); cl16.Hide(); h = ioOut16.Location.Y; }
            if (outputs < 15) { ioOut15.Hide(); cl15.Hide(); h = ioOut15.Location.Y; }
            if (outputs < 14) { ioOut14.Hide(); cl14.Hide(); h = ioOut14.Location.Y; }
            if (outputs < 13) { ioOut13.Hide(); cl13.Hide(); h = ioOut13.Location.Y; }
            if (outputs < 12) { ioOut12.Hide(); cl12.Hide(); h = ioOut12.Location.Y; }
            if (outputs < 11) { ioOut11.Hide(); cl11.Hide(); h = ioOut11.Location.Y; }
            if (outputs < 10) { ioOut10.Hide(); cl10.Hide(); h = ioOut10.Location.Y; }
            if (outputs < 9) { ioOut9.Hide(); cl9.Hide(); h = ioOut9.Location.Y; }
            if (outputs < 8) { ioOut8.Hide(); cl8.Hide(); h = ioOut8.Location.Y; }
            if (outputs < 7) { ioOut7.Hide(); cl7.Hide(); h = ioOut7.Location.Y; }
            if (outputs < 6) { ioOut6.Hide(); cl6.Hide(); h = ioOut6.Location.Y; }
            if (outputs < 5) { ioOut5.Hide(); cl5.Hide(); h = ioOut5.Location.Y; }
            if (outputs < 4) { ioOut4.Hide(); cl4.Hide(); h = ioOut4.Location.Y; }
            if (outputs < 3) { ioOut3.Hide(); cl3.Hide(); h = ioOut3.Location.Y; }
            if (outputs < 2) { ioOut2.Hide(); cl2.Hide(); h = ioOut2.Location.Y; }
            Height = h;
            shrinkSize = new System.Drawing.Size(shrinkSize.Width, h);

            if (outputs >= 1) { cl1.selectedItem = selector[0]; }
            if (outputs >= 2) { cl2.selectedItem = selector[1]; }
            if (outputs >= 3) { cl3.selectedItem = selector[2]; }
            if (outputs >= 4) { cl4.selectedItem = selector[3]; }
            if (outputs >= 5) { cl5.selectedItem = selector[4]; }
            if (outputs >= 6) { cl6.selectedItem = selector[5]; }
            if (outputs >= 7) { cl7.selectedItem = selector[6]; }
            if (outputs >= 8) { cl8.selectedItem = selector[7]; }
            if (outputs >= 9) { cl9.selectedItem = selector[8]; }
            if (outputs >= 10) { cl10.selectedItem = selector[9]; }
            if (outputs >= 11) { cl11.selectedItem = selector[10]; }
            if (outputs >= 12) { cl12.selectedItem = selector[11]; }
            if (outputs >= 13) { cl13.selectedItem = selector[12]; }
            if (outputs >= 14) { cl14.selectedItem = selector[13]; }
            if (outputs >= 15) { cl15.selectedItem = selector[14]; }
            if (outputs >= 16) { cl16.selectedItem = selector[15]; }

            if (outputs >= 1) cl1.choiceStateChanged += Cl1_choiceStateChanged;
            if (outputs >= 2) cl2.choiceStateChanged += Cl2_choiceStateChanged;
            if (outputs >= 3) cl3.choiceStateChanged += Cl3_choiceStateChanged;
            if (outputs >= 4) cl4.choiceStateChanged += Cl4_choiceStateChanged;
            if (outputs >= 5) cl5.choiceStateChanged += Cl5_choiceStateChanged;
            if (outputs >= 6) cl6.choiceStateChanged += Cl6_choiceStateChanged;
            if (outputs >= 7) cl7.choiceStateChanged += Cl7_choiceStateChanged;
            if (outputs >= 8) cl8.choiceStateChanged += Cl8_choiceStateChanged;
            if (outputs >= 9) cl9.choiceStateChanged += Cl9_choiceStateChanged;
            if (outputs >= 10) cl10.choiceStateChanged += Cl10_choiceStateChanged;
            if (outputs >= 11) cl11.choiceStateChanged += Cl11_choiceStateChanged;
            if (outputs >= 12) cl12.choiceStateChanged += Cl12_choiceStateChanged;
            if (outputs >= 13) cl13.choiceStateChanged += Cl13_choiceStateChanged;
            if (outputs >= 14) cl14.choiceStateChanged += Cl14_choiceStateChanged;
            if (outputs >= 15) cl15.choiceStateChanged += Cl15_choiceStateChanged;
            if (outputs >= 16) cl16.choiceStateChanged += Cl16_choiceStateChanged;

            processingType = ProcessingType.Processor;
        }

        private void Cl1_choiceStateChanged(object sender, EventArgs e)
        {
            selector[0] = ((RTChoice)sender).selectedItem;
        }
        private void Cl2_choiceStateChanged(object sender, EventArgs e)
        {
            selector[1] = ((RTChoice)sender).selectedItem;
        }
        private void Cl3_choiceStateChanged(object sender, EventArgs e)
        {
            selector[2] = ((RTChoice)sender).selectedItem;
        }
        private void Cl4_choiceStateChanged(object sender, EventArgs e)
        {
            selector[3] = ((RTChoice)sender).selectedItem;
        }
        private void Cl5_choiceStateChanged(object sender, EventArgs e)
        {
            selector[4] = ((RTChoice)sender).selectedItem;
        }
        private void Cl6_choiceStateChanged(object sender, EventArgs e)
        {
            selector[5] = ((RTChoice)sender).selectedItem;
        }
        private void Cl7_choiceStateChanged(object sender, EventArgs e)
        {
            selector[6] = ((RTChoice)sender).selectedItem;
        }
        private void Cl8_choiceStateChanged(object sender, EventArgs e)
        {
            selector[7] = ((RTChoice)sender).selectedItem;
        }
        private void Cl9_choiceStateChanged(object sender, EventArgs e)
        {
            selector[8] = ((RTChoice)sender).selectedItem;
        }
        private void Cl10_choiceStateChanged(object sender, EventArgs e)
        {
            selector[9] = ((RTChoice)sender).selectedItem;
        }
        private void Cl11_choiceStateChanged(object sender, EventArgs e)
        {
            selector[10] = ((RTChoice)sender).selectedItem;
        }
        private void Cl12_choiceStateChanged(object sender, EventArgs e)
        {
            selector[11] = ((RTChoice)sender).selectedItem;
        }
        private void Cl13_choiceStateChanged(object sender, EventArgs e)
        {
            selector[12] = ((RTChoice)sender).selectedItem;
        }
        private void Cl14_choiceStateChanged(object sender, EventArgs e)
        {
            selector[13] = ((RTChoice)sender).selectedItem;
        }
        private void Cl15_choiceStateChanged(object sender, EventArgs e)
        {
            selector[14] = ((RTChoice)sender).selectedItem;
        }
        private void Cl16_choiceStateChanged(object sender, EventArgs e)
        {
            selector[15] = ((RTChoice)sender).selectedItem;
        }

        public DataDeMux() : this(16)
        {
        }

        public DataDeMux(int _channels) : base()
        {
            outputs = _channels;
            selector = new int[outputs];
            for (int i = 0; i < outputs; i++)
                selector[i] = i;

            init();
        }

        public DataDeMux(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            outputs = src.ReadInt32();
            selector = new int[outputs];
            for (int i = 0; i < outputs; i++)
                selector[i] = src.ReadInt32();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(outputs);
            for (int i = 0; i < outputs; i++)
                tgt.Write(selector[i]);
        }

        private double[] datastore;

        private void processChannel(DataBuffer dbIn, int channel, int csel, SignalBuffer dbOut)
        {
            if (dbOut == null)
                return;
            if ((dbIn != null) && (dbIn.size > 0))
                datastore[channel] = dbIn.get(csel);
            dbOut.SetTo(datastore[channel]);
        }

        public override void tick()
        {
            if (!active)
                return;

            if (datastore == null)
                datastore = new double[outputs];

            DataBuffer dbIn = getDataInputBuffer(ioData);
            SignalBuffer dbTrig = getSignalOutputBuffer(ioTrig);
            if (dbIn == null)
            {
                // dbIn not connected --> 0 by default
                for (int i = 0; i < outputs; i++)
                    datastore[i] = 0;
            } else
            {
                // dbIn connected
                if (dbIn.size > 0)
                {
                    if (dbTrig != null)
                        dbTrig.data[0] = 1.0;
                }
            }
            if (outputs >= 1) processChannel(dbIn, 0, selector[0], getSignalOutputBuffer(ioOut1));
            if (outputs >= 2) processChannel(dbIn, 1, selector[1], getSignalOutputBuffer(ioOut2));
            if (outputs >= 3) processChannel(dbIn, 2, selector[2], getSignalOutputBuffer(ioOut3));
            if (outputs >= 4) processChannel(dbIn, 3, selector[3], getSignalOutputBuffer(ioOut4));
            if (outputs >= 5) processChannel(dbIn, 4, selector[4], getSignalOutputBuffer(ioOut5));
            if (outputs >= 6) processChannel(dbIn, 5, selector[5], getSignalOutputBuffer(ioOut6));
            if (outputs >= 7) processChannel(dbIn, 6, selector[6], getSignalOutputBuffer(ioOut7));
            if (outputs >= 8) processChannel(dbIn, 7, selector[7], getSignalOutputBuffer(ioOut8));
            if (outputs >= 9) processChannel(dbIn, 8, selector[8], getSignalOutputBuffer(ioOut9));
            if (outputs >= 10) processChannel(dbIn, 9, selector[9], getSignalOutputBuffer(ioOut10));
            if (outputs >= 11) processChannel(dbIn, 10, selector[10], getSignalOutputBuffer(ioOut11));
            if (outputs >= 12) processChannel(dbIn, 11, selector[11], getSignalOutputBuffer(ioOut12));
            if (outputs >= 13) processChannel(dbIn, 12, selector[12], getSignalOutputBuffer(ioOut13));
            if (outputs >= 14) processChannel(dbIn, 13, selector[13], getSignalOutputBuffer(ioOut14));
            if (outputs >= 15) processChannel(dbIn, 14, selector[14], getSignalOutputBuffer(ioOut15));
            if (outputs >= 16) processChannel(dbIn, 15, selector[15], getSignalOutputBuffer(ioOut16));
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Data", "DataDeMux", "1x" }; }
            public override RTForm Instantiate() { return new DataDeMux(1); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Data", "DataDeMux", "2x" }; }
            public override RTForm Instantiate() { return new DataDeMux(2); }
        }
        class RegisterClass3 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Data", "DataDeMux", "4x" }; }
            public override RTForm Instantiate() { return new DataDeMux(4); }
        }
        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Data", "DataDeMux", "8x" }; }
            public override RTForm Instantiate() { return new DataDeMux(8); }
        }
        class RegisterClass5 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Data", "DataDeMux", "16x" }; }
            public override RTForm Instantiate() { return new DataDeMux(16); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
            l.Add(new RegisterClass2());
            l.Add(new RegisterClass3());
            l.Add(new RegisterClass4());
            l.Add(new RegisterClass5());
        }


    }
}
