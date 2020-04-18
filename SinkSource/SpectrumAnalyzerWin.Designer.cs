namespace AudioProcessor.SinkSource
{
    partial class SpectrumAnalyzerWin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpectrumAnalyzerWin));
            this.SpectrumAnalyzerBlockSize = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SpectrumAnalyzerChannelOnD = new System.Windows.Forms.CheckBox();
            this.SpectrumAnalyzerChannelOnC = new System.Windows.Forms.CheckBox();
            this.SpectrumAnalyzerChannelOnB = new System.Windows.Forms.CheckBox();
            this.SpectrumAnalyzerChannelOnA = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SpectrumAnalyzerGrid = new System.Windows.Forms.CheckBox();
            this.SpectrumAnalyzerRun = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SpectrumAnalyzerWindow = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SpectrumAnalyzerSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SpectrumAnalyzerAutoScale = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.SpectrumAnalyzerYMax = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.SpectrumAnalyzerYMin = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SpectrumAnalyzerFMax = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SpectrumAnalyzerFMin = new System.Windows.Forms.NumericUpDown();
            this.SpectrumAnalyzerFLog = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SpectrumAnalyzerAvgD = new System.Windows.Forms.CheckBox();
            this.SpectrumAnalyzerAvgC = new System.Windows.Forms.CheckBox();
            this.SpectrumAnalyzerAvgB = new System.Windows.Forms.CheckBox();
            this.SpectrumAnalyzerAvgA = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SpectrumAnalyzerPkHldD = new System.Windows.Forms.CheckBox();
            this.SpectrumAnalyzerPkHldC = new System.Windows.Forms.CheckBox();
            this.SpectrumAnalyzerPkHldB = new System.Windows.Forms.CheckBox();
            this.SpectrumAnalyzerPkHldA = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.spectrumAnalyzerScreen = new AudioProcessor.SinkSource.SpectrumAnalyzerScreen();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpectrumAnalyzerYMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectrumAnalyzerYMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectrumAnalyzerFMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectrumAnalyzerFMin)).BeginInit();
            this.SuspendLayout();
            // 
            // SpectrumAnalyzerBlockSize
            // 
            this.SpectrumAnalyzerBlockSize.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerBlockSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SpectrumAnalyzerBlockSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SpectrumAnalyzerBlockSize.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerBlockSize.FormattingEnabled = true;
            this.SpectrumAnalyzerBlockSize.Location = new System.Drawing.Point(62, 19);
            this.SpectrumAnalyzerBlockSize.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerBlockSize.Name = "SpectrumAnalyzerBlockSize";
            this.SpectrumAnalyzerBlockSize.Size = new System.Drawing.Size(95, 21);
            this.SpectrumAnalyzerBlockSize.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(35, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "On";
            // 
            // SpectrumAnalyzerChannelOnD
            // 
            this.SpectrumAnalyzerChannelOnD.AutoSize = true;
            this.SpectrumAnalyzerChannelOnD.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerChannelOnD.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerChannelOnD.Location = new System.Drawing.Point(40, 93);
            this.SpectrumAnalyzerChannelOnD.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerChannelOnD.Name = "SpectrumAnalyzerChannelOnD";
            this.SpectrumAnalyzerChannelOnD.Size = new System.Drawing.Size(15, 14);
            this.SpectrumAnalyzerChannelOnD.TabIndex = 9;
            this.SpectrumAnalyzerChannelOnD.UseVisualStyleBackColor = false;
            // 
            // SpectrumAnalyzerChannelOnC
            // 
            this.SpectrumAnalyzerChannelOnC.AutoSize = true;
            this.SpectrumAnalyzerChannelOnC.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerChannelOnC.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerChannelOnC.Location = new System.Drawing.Point(39, 71);
            this.SpectrumAnalyzerChannelOnC.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerChannelOnC.Name = "SpectrumAnalyzerChannelOnC";
            this.SpectrumAnalyzerChannelOnC.Size = new System.Drawing.Size(15, 14);
            this.SpectrumAnalyzerChannelOnC.TabIndex = 8;
            this.SpectrumAnalyzerChannelOnC.UseVisualStyleBackColor = false;
            // 
            // SpectrumAnalyzerChannelOnB
            // 
            this.SpectrumAnalyzerChannelOnB.AutoSize = true;
            this.SpectrumAnalyzerChannelOnB.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerChannelOnB.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerChannelOnB.Location = new System.Drawing.Point(39, 49);
            this.SpectrumAnalyzerChannelOnB.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerChannelOnB.Name = "SpectrumAnalyzerChannelOnB";
            this.SpectrumAnalyzerChannelOnB.Size = new System.Drawing.Size(15, 14);
            this.SpectrumAnalyzerChannelOnB.TabIndex = 7;
            this.SpectrumAnalyzerChannelOnB.UseVisualStyleBackColor = false;
            // 
            // SpectrumAnalyzerChannelOnA
            // 
            this.SpectrumAnalyzerChannelOnA.AutoSize = true;
            this.SpectrumAnalyzerChannelOnA.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerChannelOnA.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerChannelOnA.Location = new System.Drawing.Point(39, 27);
            this.SpectrumAnalyzerChannelOnA.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerChannelOnA.Name = "SpectrumAnalyzerChannelOnA";
            this.SpectrumAnalyzerChannelOnA.Size = new System.Drawing.Size(15, 14);
            this.SpectrumAnalyzerChannelOnA.TabIndex = 6;
            this.SpectrumAnalyzerChannelOnA.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Black;
            this.groupBox2.Controls.Add(this.SpectrumAnalyzerGrid);
            this.groupBox2.Controls.Add(this.SpectrumAnalyzerRun);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.SpectrumAnalyzerWindow);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.SpectrumAnalyzerBlockSize);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(130, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(162, 104);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FFT Parameters";
            // 
            // SpectrumAnalyzerGrid
            // 
            this.SpectrumAnalyzerGrid.AutoSize = true;
            this.SpectrumAnalyzerGrid.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerGrid.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerGrid.Location = new System.Drawing.Point(112, 76);
            this.SpectrumAnalyzerGrid.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerGrid.Name = "SpectrumAnalyzerGrid";
            this.SpectrumAnalyzerGrid.Size = new System.Drawing.Size(45, 17);
            this.SpectrumAnalyzerGrid.TabIndex = 41;
            this.SpectrumAnalyzerGrid.Text = "Grid";
            this.SpectrumAnalyzerGrid.UseVisualStyleBackColor = false;
            // 
            // SpectrumAnalyzerRun
            // 
            this.SpectrumAnalyzerRun.AutoSize = true;
            this.SpectrumAnalyzerRun.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerRun.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerRun.Location = new System.Drawing.Point(7, 76);
            this.SpectrumAnalyzerRun.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerRun.Name = "SpectrumAnalyzerRun";
            this.SpectrumAnalyzerRun.Size = new System.Drawing.Size(46, 17);
            this.SpectrumAnalyzerRun.TabIndex = 26;
            this.SpectrumAnalyzerRun.Text = "Run";
            this.SpectrumAnalyzerRun.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Window";
            // 
            // SpectrumAnalyzerWindow
            // 
            this.SpectrumAnalyzerWindow.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerWindow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SpectrumAnalyzerWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SpectrumAnalyzerWindow.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerWindow.FormattingEnabled = true;
            this.SpectrumAnalyzerWindow.Location = new System.Drawing.Point(62, 43);
            this.SpectrumAnalyzerWindow.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerWindow.Name = "SpectrumAnalyzerWindow";
            this.SpectrumAnalyzerWindow.Size = new System.Drawing.Size(95, 21);
            this.SpectrumAnalyzerWindow.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "BlockSize";
            // 
            // SpectrumAnalyzerSave
            // 
            this.SpectrumAnalyzerSave.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SpectrumAnalyzerSave.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerSave.Location = new System.Drawing.Point(138, 36);
            this.SpectrumAnalyzerSave.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerSave.Name = "SpectrumAnalyzerSave";
            this.SpectrumAnalyzerSave.Size = new System.Drawing.Size(44, 25);
            this.SpectrumAnalyzerSave.TabIndex = 40;
            this.SpectrumAnalyzerSave.Text = "Save";
            this.SpectrumAnalyzerSave.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.SpectrumAnalyzerAvgD);
            this.panel2.Controls.Add(this.SpectrumAnalyzerAvgC);
            this.panel2.Controls.Add(this.SpectrumAnalyzerAvgB);
            this.panel2.Controls.Add(this.SpectrumAnalyzerAvgA);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.SpectrumAnalyzerPkHldD);
            this.panel2.Controls.Add(this.SpectrumAnalyzerPkHldC);
            this.panel2.Controls.Add(this.SpectrumAnalyzerPkHldB);
            this.panel2.Controls.Add(this.SpectrumAnalyzerPkHldA);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.SpectrumAnalyzerChannelOnD);
            this.panel2.Controls.Add(this.SpectrumAnalyzerChannelOnC);
            this.panel2.Controls.Add(this.SpectrumAnalyzerChannelOnB);
            this.panel2.Controls.Add(this.SpectrumAnalyzerChannelOnA);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 371);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(498, 117);
            this.panel2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.SpectrumAnalyzerAutoScale);
            this.groupBox1.Controls.Add(this.SpectrumAnalyzerSave);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.SpectrumAnalyzerYMax);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.SpectrumAnalyzerYMin);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.SpectrumAnalyzerFMax);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.SpectrumAnalyzerFMin);
            this.groupBox1.Controls.Add(this.SpectrumAnalyzerFLog);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(297, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(190, 104);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display Parameters";
            // 
            // SpectrumAnalyzerAutoScale
            // 
            this.SpectrumAnalyzerAutoScale.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerAutoScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SpectrumAnalyzerAutoScale.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerAutoScale.Location = new System.Drawing.Point(148, 65);
            this.SpectrumAnalyzerAutoScale.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerAutoScale.Name = "SpectrumAnalyzerAutoScale";
            this.SpectrumAnalyzerAutoScale.Size = new System.Drawing.Size(34, 31);
            this.SpectrumAnalyzerAutoScale.TabIndex = 39;
            this.SpectrumAnalyzerAutoScale.Text = "[ ]";
            this.SpectrumAnalyzerAutoScale.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Black;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(106, 80);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "dBFS";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Black;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(4, 80);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "Y Max";
            // 
            // SpectrumAnalyzerYMax
            // 
            this.SpectrumAnalyzerYMax.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerYMax.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerYMax.Location = new System.Drawing.Point(42, 78);
            this.SpectrumAnalyzerYMax.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerYMax.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.SpectrumAnalyzerYMax.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.SpectrumAnalyzerYMax.Name = "SpectrumAnalyzerYMax";
            this.SpectrumAnalyzerYMax.Size = new System.Drawing.Size(60, 20);
            this.SpectrumAnalyzerYMax.TabIndex = 36;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Black;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(106, 60);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "dBFS";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Black;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(4, 60);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 34;
            this.label17.Text = "Y Min";
            // 
            // SpectrumAnalyzerYMin
            // 
            this.SpectrumAnalyzerYMin.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerYMin.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerYMin.Location = new System.Drawing.Point(42, 58);
            this.SpectrumAnalyzerYMin.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerYMin.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.SpectrumAnalyzerYMin.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.SpectrumAnalyzerYMin.Name = "SpectrumAnalyzerYMin";
            this.SpectrumAnalyzerYMin.Size = new System.Drawing.Size(60, 20);
            this.SpectrumAnalyzerYMin.TabIndex = 33;
            this.SpectrumAnalyzerYMin.Value = new decimal(new int[] {
            120,
            0,
            0,
            -2147483648});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(106, 41);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Hz";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(4, 41);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "F Max";
            // 
            // SpectrumAnalyzerFMax
            // 
            this.SpectrumAnalyzerFMax.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerFMax.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerFMax.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.SpectrumAnalyzerFMax.Location = new System.Drawing.Point(42, 39);
            this.SpectrumAnalyzerFMax.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerFMax.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.SpectrumAnalyzerFMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpectrumAnalyzerFMax.Name = "SpectrumAnalyzerFMax";
            this.SpectrumAnalyzerFMax.Size = new System.Drawing.Size(60, 20);
            this.SpectrumAnalyzerFMax.TabIndex = 30;
            this.SpectrumAnalyzerFMax.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(106, 21);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Hz";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(4, 21);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "F Min";
            // 
            // SpectrumAnalyzerFMin
            // 
            this.SpectrumAnalyzerFMin.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerFMin.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerFMin.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.SpectrumAnalyzerFMin.Location = new System.Drawing.Point(42, 20);
            this.SpectrumAnalyzerFMin.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerFMin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.SpectrumAnalyzerFMin.Name = "SpectrumAnalyzerFMin";
            this.SpectrumAnalyzerFMin.Size = new System.Drawing.Size(60, 20);
            this.SpectrumAnalyzerFMin.TabIndex = 27;
            this.SpectrumAnalyzerFMin.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // SpectrumAnalyzerFLog
            // 
            this.SpectrumAnalyzerFLog.AutoSize = true;
            this.SpectrumAnalyzerFLog.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerFLog.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerFLog.Location = new System.Drawing.Point(138, 17);
            this.SpectrumAnalyzerFLog.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerFLog.Name = "SpectrumAnalyzerFLog";
            this.SpectrumAnalyzerFLog.Size = new System.Drawing.Size(44, 17);
            this.SpectrumAnalyzerFLog.TabIndex = 26;
            this.SpectrumAnalyzerFLog.Text = "Log";
            this.SpectrumAnalyzerFLog.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(98, 8);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Avg";
            // 
            // SpectrumAnalyzerAvgD
            // 
            this.SpectrumAnalyzerAvgD.AutoSize = true;
            this.SpectrumAnalyzerAvgD.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerAvgD.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerAvgD.Location = new System.Drawing.Point(103, 93);
            this.SpectrumAnalyzerAvgD.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerAvgD.Name = "SpectrumAnalyzerAvgD";
            this.SpectrumAnalyzerAvgD.Size = new System.Drawing.Size(15, 14);
            this.SpectrumAnalyzerAvgD.TabIndex = 37;
            this.SpectrumAnalyzerAvgD.UseVisualStyleBackColor = false;
            // 
            // SpectrumAnalyzerAvgC
            // 
            this.SpectrumAnalyzerAvgC.AutoSize = true;
            this.SpectrumAnalyzerAvgC.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerAvgC.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerAvgC.Location = new System.Drawing.Point(102, 71);
            this.SpectrumAnalyzerAvgC.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerAvgC.Name = "SpectrumAnalyzerAvgC";
            this.SpectrumAnalyzerAvgC.Size = new System.Drawing.Size(15, 14);
            this.SpectrumAnalyzerAvgC.TabIndex = 36;
            this.SpectrumAnalyzerAvgC.UseVisualStyleBackColor = false;
            // 
            // SpectrumAnalyzerAvgB
            // 
            this.SpectrumAnalyzerAvgB.AutoSize = true;
            this.SpectrumAnalyzerAvgB.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerAvgB.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerAvgB.Location = new System.Drawing.Point(102, 49);
            this.SpectrumAnalyzerAvgB.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerAvgB.Name = "SpectrumAnalyzerAvgB";
            this.SpectrumAnalyzerAvgB.Size = new System.Drawing.Size(15, 14);
            this.SpectrumAnalyzerAvgB.TabIndex = 35;
            this.SpectrumAnalyzerAvgB.UseVisualStyleBackColor = false;
            // 
            // SpectrumAnalyzerAvgA
            // 
            this.SpectrumAnalyzerAvgA.AutoSize = true;
            this.SpectrumAnalyzerAvgA.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerAvgA.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerAvgA.Location = new System.Drawing.Point(102, 27);
            this.SpectrumAnalyzerAvgA.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerAvgA.Name = "SpectrumAnalyzerAvgA";
            this.SpectrumAnalyzerAvgA.Size = new System.Drawing.Size(15, 14);
            this.SpectrumAnalyzerAvgA.TabIndex = 34;
            this.SpectrumAnalyzerAvgA.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(61, 8);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "PkHld";
            // 
            // SpectrumAnalyzerPkHldD
            // 
            this.SpectrumAnalyzerPkHldD.AutoSize = true;
            this.SpectrumAnalyzerPkHldD.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerPkHldD.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerPkHldD.Location = new System.Drawing.Point(71, 93);
            this.SpectrumAnalyzerPkHldD.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerPkHldD.Name = "SpectrumAnalyzerPkHldD";
            this.SpectrumAnalyzerPkHldD.Size = new System.Drawing.Size(15, 14);
            this.SpectrumAnalyzerPkHldD.TabIndex = 32;
            this.SpectrumAnalyzerPkHldD.UseVisualStyleBackColor = false;
            // 
            // SpectrumAnalyzerPkHldC
            // 
            this.SpectrumAnalyzerPkHldC.AutoSize = true;
            this.SpectrumAnalyzerPkHldC.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerPkHldC.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerPkHldC.Location = new System.Drawing.Point(70, 71);
            this.SpectrumAnalyzerPkHldC.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerPkHldC.Name = "SpectrumAnalyzerPkHldC";
            this.SpectrumAnalyzerPkHldC.Size = new System.Drawing.Size(15, 14);
            this.SpectrumAnalyzerPkHldC.TabIndex = 31;
            this.SpectrumAnalyzerPkHldC.UseVisualStyleBackColor = false;
            // 
            // SpectrumAnalyzerPkHldB
            // 
            this.SpectrumAnalyzerPkHldB.AutoSize = true;
            this.SpectrumAnalyzerPkHldB.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerPkHldB.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerPkHldB.Location = new System.Drawing.Point(70, 49);
            this.SpectrumAnalyzerPkHldB.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerPkHldB.Name = "SpectrumAnalyzerPkHldB";
            this.SpectrumAnalyzerPkHldB.Size = new System.Drawing.Size(15, 14);
            this.SpectrumAnalyzerPkHldB.TabIndex = 30;
            this.SpectrumAnalyzerPkHldB.UseVisualStyleBackColor = false;
            // 
            // SpectrumAnalyzerPkHldA
            // 
            this.SpectrumAnalyzerPkHldA.AutoSize = true;
            this.SpectrumAnalyzerPkHldA.BackColor = System.Drawing.Color.Black;
            this.SpectrumAnalyzerPkHldA.ForeColor = System.Drawing.Color.White;
            this.SpectrumAnalyzerPkHldA.Location = new System.Drawing.Point(70, 27);
            this.SpectrumAnalyzerPkHldA.Margin = new System.Windows.Forms.Padding(2);
            this.SpectrumAnalyzerPkHldA.Name = "SpectrumAnalyzerPkHldA";
            this.SpectrumAnalyzerPkHldA.Size = new System.Drawing.Size(15, 14);
            this.SpectrumAnalyzerPkHldA.TabIndex = 29;
            this.SpectrumAnalyzerPkHldA.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Fuchsia;
            this.label7.Location = new System.Drawing.Point(9, 92);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "D";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Aqua;
            this.label6.Location = new System.Drawing.Point(9, 70);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "C";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Lime;
            this.label5.Location = new System.Drawing.Point(9, 48);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "B";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(9, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "A";
            // 
            // spectrumAnalyzerScreen
            // 
            this.spectrumAnalyzerScreen.axesFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.spectrumAnalyzerScreen.BackColor = System.Drawing.Color.Black;
            this.spectrumAnalyzerScreen.colorFrame = System.Drawing.Color.White;
            this.spectrumAnalyzerScreen.colorGrid = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(0)))));
            this.spectrumAnalyzerScreen.colorMajorGrid = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.spectrumAnalyzerScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spectrumAnalyzerScreen.drawGrid = true;
            this.spectrumAnalyzerScreen.Location = new System.Drawing.Point(0, 0);
            this.spectrumAnalyzerScreen.Margin = new System.Windows.Forms.Padding(2);
            this.spectrumAnalyzerScreen.Name = "spectrumAnalyzerScreen";
            this.spectrumAnalyzerScreen.Size = new System.Drawing.Size(498, 371);
            this.spectrumAnalyzerScreen.TabIndex = 5;
            // 
            // SpectrumAnalyzerWin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(498, 488);
            this.Controls.Add(this.spectrumAnalyzerScreen);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(514, 527);
            this.Name = "SpectrumAnalyzerWin";
            this.Text = "Spectrum Analyzer";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpectrumAnalyzerYMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectrumAnalyzerYMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectrumAnalyzerFMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectrumAnalyzerFMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox SpectrumAnalyzerBlockSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox SpectrumAnalyzerChannelOnD;
        private System.Windows.Forms.CheckBox SpectrumAnalyzerChannelOnC;
        private System.Windows.Forms.CheckBox SpectrumAnalyzerChannelOnB;
        private System.Windows.Forms.CheckBox SpectrumAnalyzerChannelOnA;
        private SpectrumAnalyzerScreen spectrumAnalyzerScreen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SpectrumAnalyzerWindow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown SpectrumAnalyzerFMax;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown SpectrumAnalyzerFMin;
        private System.Windows.Forms.CheckBox SpectrumAnalyzerFLog;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox SpectrumAnalyzerAvgD;
        private System.Windows.Forms.CheckBox SpectrumAnalyzerAvgC;
        private System.Windows.Forms.CheckBox SpectrumAnalyzerAvgB;
        private System.Windows.Forms.CheckBox SpectrumAnalyzerAvgA;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox SpectrumAnalyzerPkHldD;
        private System.Windows.Forms.CheckBox SpectrumAnalyzerPkHldC;
        private System.Windows.Forms.CheckBox SpectrumAnalyzerPkHldB;
        private System.Windows.Forms.CheckBox SpectrumAnalyzerPkHldA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown SpectrumAnalyzerYMax;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown SpectrumAnalyzerYMin;
        private System.Windows.Forms.Button SpectrumAnalyzerAutoScale;
        private System.Windows.Forms.CheckBox SpectrumAnalyzerRun;
        private System.Windows.Forms.Button SpectrumAnalyzerSave;
        private System.Windows.Forms.CheckBox SpectrumAnalyzerGrid;
    }
}