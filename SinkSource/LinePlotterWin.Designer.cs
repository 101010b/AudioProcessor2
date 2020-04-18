namespace AudioProcessor.SinkSource
{
    partial class LinePlotterWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinePlotterWin));
            this.LpVertChannelLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lpAutoScaleY = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lpScaleYMax = new System.Windows.Forms.NumericUpDown();
            this.lpScaleYMin = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.lpDisplays = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lpAutoScale = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lpRun = new System.Windows.Forms.CheckBox();
            this.LpStoreLength = new System.Windows.Forms.ComboBox();
            this.LpHorzScaleM = new System.Windows.Forms.Button();
            this.LpHorzScale = new System.Windows.Forms.ComboBox();
            this.LpHorzScaleP = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LpSaveButton = new System.Windows.Forms.Button();
            this.LpChannelOnD = new System.Windows.Forms.CheckBox();
            this.LpChannelOnC = new System.Windows.Forms.CheckBox();
            this.LpChannelOnB = new System.Windows.Forms.CheckBox();
            this.LpChannelOnA = new System.Windows.Forms.CheckBox();
            this.LpChannelSelectD = new System.Windows.Forms.RadioButton();
            this.LpChannelSelectC = new System.Windows.Forms.RadioButton();
            this.LpChannelSelectB = new System.Windows.Forms.RadioButton();
            this.LpChannelSelectA = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lpSelectDisplay = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LpVertAC = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LpVertMode = new System.Windows.Forms.ComboBox();
            this.LpVertScale = new System.Windows.Forms.ComboBox();
            this.LpVertScaleP = new System.Windows.Forms.Button();
            this.LpVertScaleM = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LpOffsetDCremove = new System.Windows.Forms.CheckBox();
            this.LpVertOfsMM = new System.Windows.Forms.Button();
            this.LpVertOfsM = new System.Windows.Forms.Button();
            this.LpVertOfs0 = new System.Windows.Forms.Button();
            this.LpVertOfsP = new System.Windows.Forms.Button();
            this.LpVertOfsPP = new System.Windows.Forms.Button();
            this.LpVertOfs = new System.Windows.Forms.TrackBar();
            this.LpVertOfsVal = new System.Windows.Forms.TextBox();
            this.LpScreen = new AudioProcessor.SinkSource.LinePlotterScreen();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lpScaleYMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lpScaleYMin)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LpVertOfs)).BeginInit();
            this.SuspendLayout();
            // 
            // LpVertChannelLabel
            // 
            this.LpVertChannelLabel.AutoSize = true;
            this.LpVertChannelLabel.BackColor = System.Drawing.Color.Black;
            this.LpVertChannelLabel.ForeColor = System.Drawing.Color.White;
            this.LpVertChannelLabel.Location = new System.Drawing.Point(4, 7);
            this.LpVertChannelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LpVertChannelLabel.Name = "LpVertChannelLabel";
            this.LpVertChannelLabel.Size = new System.Drawing.Size(35, 13);
            this.LpVertChannelLabel.TabIndex = 2;
            this.LpVertChannelLabel.Text = "label8";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.LpSaveButton);
            this.panel2.Controls.Add(this.LpChannelOnD);
            this.panel2.Controls.Add(this.LpChannelOnC);
            this.panel2.Controls.Add(this.LpChannelOnB);
            this.panel2.Controls.Add(this.LpChannelOnA);
            this.panel2.Controls.Add(this.LpChannelSelectD);
            this.panel2.Controls.Add(this.LpChannelSelectC);
            this.panel2.Controls.Add(this.LpChannelSelectB);
            this.panel2.Controls.Add(this.LpChannelSelectA);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 201);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(342, 117);
            this.panel2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.lpAutoScaleY);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lpScaleYMax);
            this.groupBox1.Controls.Add(this.lpScaleYMin);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lpDisplays);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(178, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(110, 104);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display";
            // 
            // lpAutoScaleY
            // 
            this.lpAutoScaleY.AutoSize = true;
            this.lpAutoScaleY.BackColor = System.Drawing.Color.Black;
            this.lpAutoScaleY.Location = new System.Drawing.Point(7, 41);
            this.lpAutoScaleY.Margin = new System.Windows.Forms.Padding(2);
            this.lpAutoScaleY.Name = "lpAutoScaleY";
            this.lpAutoScaleY.Size = new System.Drawing.Size(75, 17);
            this.lpAutoScaleY.TabIndex = 27;
            this.lpAutoScaleY.Text = "AutoScale";
            this.lpAutoScaleY.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(7, 83);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "Y Max";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(7, 63);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 55;
            this.label9.Text = "Y Min";
            // 
            // lpScaleYMax
            // 
            this.lpScaleYMax.BackColor = System.Drawing.Color.Black;
            this.lpScaleYMax.ForeColor = System.Drawing.Color.White;
            this.lpScaleYMax.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.lpScaleYMax.Location = new System.Drawing.Point(46, 81);
            this.lpScaleYMax.Margin = new System.Windows.Forms.Padding(2);
            this.lpScaleYMax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.lpScaleYMax.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.lpScaleYMax.Name = "lpScaleYMax";
            this.lpScaleYMax.Size = new System.Drawing.Size(60, 20);
            this.lpScaleYMax.TabIndex = 54;
            this.lpScaleYMax.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lpScaleYMin
            // 
            this.lpScaleYMin.BackColor = System.Drawing.Color.Black;
            this.lpScaleYMin.ForeColor = System.Drawing.Color.White;
            this.lpScaleYMin.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.lpScaleYMin.Location = new System.Drawing.Point(46, 62);
            this.lpScaleYMin.Margin = new System.Windows.Forms.Padding(2);
            this.lpScaleYMin.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.lpScaleYMin.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.lpScaleYMin.Name = "lpScaleYMin";
            this.lpScaleYMin.Size = new System.Drawing.Size(60, 20);
            this.lpScaleYMin.TabIndex = 53;
            this.lpScaleYMin.Value = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(4, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Displays";
            // 
            // lpDisplays
            // 
            this.lpDisplays.BackColor = System.Drawing.Color.Black;
            this.lpDisplays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lpDisplays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lpDisplays.ForeColor = System.Drawing.Color.White;
            this.lpDisplays.FormattingEnabled = true;
            this.lpDisplays.Location = new System.Drawing.Point(59, 17);
            this.lpDisplays.Margin = new System.Windows.Forms.Padding(2);
            this.lpDisplays.Name = "lpDisplays";
            this.lpDisplays.Size = new System.Drawing.Size(43, 21);
            this.lpDisplays.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Black;
            this.groupBox2.Controls.Add(this.lpAutoScale);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lpRun);
            this.groupBox2.Controls.Add(this.LpStoreLength);
            this.groupBox2.Controls.Add(this.LpHorzScaleM);
            this.groupBox2.Controls.Add(this.LpHorzScale);
            this.groupBox2.Controls.Add(this.LpHorzScaleP);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(63, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(110, 104);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Horizontal Scale";
            // 
            // lpAutoScale
            // 
            this.lpAutoScale.BackColor = System.Drawing.Color.Black;
            this.lpAutoScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lpAutoScale.Location = new System.Drawing.Point(7, 77);
            this.lpAutoScale.Margin = new System.Windows.Forms.Padding(0);
            this.lpAutoScale.Name = "lpAutoScale";
            this.lpAutoScale.Size = new System.Drawing.Size(34, 21);
            this.lpAutoScale.TabIndex = 2;
            this.lpAutoScale.Text = "[]";
            this.lpAutoScale.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 61);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Store";
            this.label5.Visible = false;
            // 
            // lpRun
            // 
            this.lpRun.AutoSize = true;
            this.lpRun.BackColor = System.Drawing.Color.Black;
            this.lpRun.Location = new System.Drawing.Point(58, 82);
            this.lpRun.Margin = new System.Windows.Forms.Padding(2);
            this.lpRun.Name = "lpRun";
            this.lpRun.Size = new System.Drawing.Size(46, 17);
            this.lpRun.TabIndex = 26;
            this.lpRun.Text = "Run";
            this.lpRun.UseVisualStyleBackColor = false;
            // 
            // LpStoreLength
            // 
            this.LpStoreLength.BackColor = System.Drawing.Color.Black;
            this.LpStoreLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LpStoreLength.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LpStoreLength.ForeColor = System.Drawing.Color.White;
            this.LpStoreLength.FormattingEnabled = true;
            this.LpStoreLength.Location = new System.Drawing.Point(43, 59);
            this.LpStoreLength.Margin = new System.Windows.Forms.Padding(2);
            this.LpStoreLength.Name = "LpStoreLength";
            this.LpStoreLength.Size = new System.Drawing.Size(63, 21);
            this.LpStoreLength.TabIndex = 23;
            this.LpStoreLength.Visible = false;
            // 
            // LpHorzScaleM
            // 
            this.LpHorzScaleM.BackColor = System.Drawing.Color.Black;
            this.LpHorzScaleM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LpHorzScaleM.ForeColor = System.Drawing.Color.White;
            this.LpHorzScaleM.Location = new System.Drawing.Point(74, 37);
            this.LpHorzScaleM.Margin = new System.Windows.Forms.Padding(2);
            this.LpHorzScaleM.Name = "LpHorzScaleM";
            this.LpHorzScaleM.Size = new System.Drawing.Size(26, 19);
            this.LpHorzScaleM.TabIndex = 4;
            this.LpHorzScaleM.Text = "-";
            this.LpHorzScaleM.UseVisualStyleBackColor = false;
            // 
            // LpHorzScale
            // 
            this.LpHorzScale.BackColor = System.Drawing.Color.Black;
            this.LpHorzScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LpHorzScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LpHorzScale.ForeColor = System.Drawing.Color.White;
            this.LpHorzScale.FormattingEnabled = true;
            this.LpHorzScale.Location = new System.Drawing.Point(7, 24);
            this.LpHorzScale.Margin = new System.Windows.Forms.Padding(2);
            this.LpHorzScale.Name = "LpHorzScale";
            this.LpHorzScale.Size = new System.Drawing.Size(63, 21);
            this.LpHorzScale.TabIndex = 22;
            // 
            // LpHorzScaleP
            // 
            this.LpHorzScaleP.BackColor = System.Drawing.Color.Black;
            this.LpHorzScaleP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LpHorzScaleP.ForeColor = System.Drawing.Color.White;
            this.LpHorzScaleP.Location = new System.Drawing.Point(74, 14);
            this.LpHorzScaleP.Margin = new System.Windows.Forms.Padding(2);
            this.LpHorzScaleP.Name = "LpHorzScaleP";
            this.LpHorzScaleP.Size = new System.Drawing.Size(26, 19);
            this.LpHorzScaleP.TabIndex = 21;
            this.LpHorzScaleP.Text = "+";
            this.LpHorzScaleP.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(38, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "On";
            // 
            // LpSaveButton
            // 
            this.LpSaveButton.BackColor = System.Drawing.Color.Black;
            this.LpSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LpSaveButton.ForeColor = System.Drawing.Color.White;
            this.LpSaveButton.Location = new System.Drawing.Point(301, 11);
            this.LpSaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.LpSaveButton.Name = "LpSaveButton";
            this.LpSaveButton.Size = new System.Drawing.Size(37, 27);
            this.LpSaveButton.TabIndex = 0;
            this.LpSaveButton.Text = "Save";
            this.LpSaveButton.UseVisualStyleBackColor = false;
            // 
            // LpChannelOnD
            // 
            this.LpChannelOnD.AutoSize = true;
            this.LpChannelOnD.BackColor = System.Drawing.Color.Black;
            this.LpChannelOnD.Location = new System.Drawing.Point(42, 93);
            this.LpChannelOnD.Margin = new System.Windows.Forms.Padding(2);
            this.LpChannelOnD.Name = "LpChannelOnD";
            this.LpChannelOnD.Size = new System.Drawing.Size(15, 14);
            this.LpChannelOnD.TabIndex = 9;
            this.LpChannelOnD.UseVisualStyleBackColor = false;
            // 
            // LpChannelOnC
            // 
            this.LpChannelOnC.AutoSize = true;
            this.LpChannelOnC.BackColor = System.Drawing.Color.Black;
            this.LpChannelOnC.Location = new System.Drawing.Point(41, 71);
            this.LpChannelOnC.Margin = new System.Windows.Forms.Padding(2);
            this.LpChannelOnC.Name = "LpChannelOnC";
            this.LpChannelOnC.Size = new System.Drawing.Size(15, 14);
            this.LpChannelOnC.TabIndex = 8;
            this.LpChannelOnC.UseVisualStyleBackColor = false;
            // 
            // LpChannelOnB
            // 
            this.LpChannelOnB.AutoSize = true;
            this.LpChannelOnB.BackColor = System.Drawing.Color.Black;
            this.LpChannelOnB.Location = new System.Drawing.Point(41, 49);
            this.LpChannelOnB.Margin = new System.Windows.Forms.Padding(2);
            this.LpChannelOnB.Name = "LpChannelOnB";
            this.LpChannelOnB.Size = new System.Drawing.Size(15, 14);
            this.LpChannelOnB.TabIndex = 7;
            this.LpChannelOnB.UseVisualStyleBackColor = false;
            // 
            // LpChannelOnA
            // 
            this.LpChannelOnA.AutoSize = true;
            this.LpChannelOnA.BackColor = System.Drawing.Color.Black;
            this.LpChannelOnA.Location = new System.Drawing.Point(41, 27);
            this.LpChannelOnA.Margin = new System.Windows.Forms.Padding(2);
            this.LpChannelOnA.Name = "LpChannelOnA";
            this.LpChannelOnA.Size = new System.Drawing.Size(15, 14);
            this.LpChannelOnA.TabIndex = 6;
            this.LpChannelOnA.UseVisualStyleBackColor = false;
            // 
            // LpChannelSelectD
            // 
            this.LpChannelSelectD.AutoSize = true;
            this.LpChannelSelectD.BackColor = System.Drawing.Color.Black;
            this.LpChannelSelectD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LpChannelSelectD.ForeColor = System.Drawing.Color.Fuchsia;
            this.LpChannelSelectD.Location = new System.Drawing.Point(8, 90);
            this.LpChannelSelectD.Margin = new System.Windows.Forms.Padding(2);
            this.LpChannelSelectD.Name = "LpChannelSelectD";
            this.LpChannelSelectD.Size = new System.Drawing.Size(37, 20);
            this.LpChannelSelectD.TabIndex = 4;
            this.LpChannelSelectD.TabStop = true;
            this.LpChannelSelectD.Text = "D";
            this.LpChannelSelectD.UseVisualStyleBackColor = false;
            // 
            // LpChannelSelectC
            // 
            this.LpChannelSelectC.AutoSize = true;
            this.LpChannelSelectC.BackColor = System.Drawing.Color.Black;
            this.LpChannelSelectC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LpChannelSelectC.ForeColor = System.Drawing.Color.Cyan;
            this.LpChannelSelectC.Location = new System.Drawing.Point(8, 68);
            this.LpChannelSelectC.Margin = new System.Windows.Forms.Padding(2);
            this.LpChannelSelectC.Name = "LpChannelSelectC";
            this.LpChannelSelectC.Size = new System.Drawing.Size(36, 20);
            this.LpChannelSelectC.TabIndex = 3;
            this.LpChannelSelectC.TabStop = true;
            this.LpChannelSelectC.Text = "C";
            this.LpChannelSelectC.UseVisualStyleBackColor = false;
            // 
            // LpChannelSelectB
            // 
            this.LpChannelSelectB.AutoSize = true;
            this.LpChannelSelectB.BackColor = System.Drawing.Color.Black;
            this.LpChannelSelectB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LpChannelSelectB.ForeColor = System.Drawing.Color.Lime;
            this.LpChannelSelectB.Location = new System.Drawing.Point(8, 46);
            this.LpChannelSelectB.Margin = new System.Windows.Forms.Padding(2);
            this.LpChannelSelectB.Name = "LpChannelSelectB";
            this.LpChannelSelectB.Size = new System.Drawing.Size(36, 20);
            this.LpChannelSelectB.TabIndex = 2;
            this.LpChannelSelectB.TabStop = true;
            this.LpChannelSelectB.Text = "B";
            this.LpChannelSelectB.UseVisualStyleBackColor = false;
            // 
            // LpChannelSelectA
            // 
            this.LpChannelSelectA.AutoSize = true;
            this.LpChannelSelectA.BackColor = System.Drawing.Color.Black;
            this.LpChannelSelectA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LpChannelSelectA.ForeColor = System.Drawing.Color.Red;
            this.LpChannelSelectA.Location = new System.Drawing.Point(8, 24);
            this.LpChannelSelectA.Margin = new System.Windows.Forms.Padding(2);
            this.LpChannelSelectA.Name = "LpChannelSelectA";
            this.LpChannelSelectA.Size = new System.Drawing.Size(36, 20);
            this.LpChannelSelectA.TabIndex = 1;
            this.LpChannelSelectA.TabStop = true;
            this.LpChannelSelectA.Text = "A";
            this.LpChannelSelectA.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lpSelectDisplay);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.LpVertChannelLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(342, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 318);
            this.panel1.TabIndex = 3;
            // 
            // lpSelectDisplay
            // 
            this.lpSelectDisplay.BackColor = System.Drawing.Color.Black;
            this.lpSelectDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lpSelectDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lpSelectDisplay.ForeColor = System.Drawing.Color.White;
            this.lpSelectDisplay.FormattingEnabled = true;
            this.lpSelectDisplay.Location = new System.Drawing.Point(128, 5);
            this.lpSelectDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.lpSelectDisplay.Name = "lpSelectDisplay";
            this.lpSelectDisplay.Size = new System.Drawing.Size(42, 21);
            this.lpSelectDisplay.TabIndex = 27;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Black;
            this.groupBox4.Controls.Add(this.LpVertAC);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.LpVertMode);
            this.groupBox4.Controls.Add(this.LpVertScale);
            this.groupBox4.Controls.Add(this.LpVertScaleP);
            this.groupBox4.Controls.Add(this.LpVertScaleM);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(10, 24);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(159, 110);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Y Scale";
            // 
            // LpVertAC
            // 
            this.LpVertAC.AutoSize = true;
            this.LpVertAC.BackColor = System.Drawing.Color.Black;
            this.LpVertAC.Location = new System.Drawing.Point(12, 40);
            this.LpVertAC.Margin = new System.Windows.Forms.Padding(2);
            this.LpVertAC.Name = "LpVertAC";
            this.LpVertAC.Size = new System.Drawing.Size(40, 17);
            this.LpVertAC.TabIndex = 4;
            this.LpVertAC.Text = "AC";
            this.LpVertAC.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Scale";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mode";
            // 
            // LpVertMode
            // 
            this.LpVertMode.BackColor = System.Drawing.Color.Black;
            this.LpVertMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LpVertMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LpVertMode.ForeColor = System.Drawing.Color.White;
            this.LpVertMode.FormattingEnabled = true;
            this.LpVertMode.Location = new System.Drawing.Point(46, 17);
            this.LpVertMode.Margin = new System.Windows.Forms.Padding(2);
            this.LpVertMode.Name = "LpVertMode";
            this.LpVertMode.Size = new System.Drawing.Size(109, 21);
            this.LpVertMode.TabIndex = 4;
            // 
            // LpVertScale
            // 
            this.LpVertScale.BackColor = System.Drawing.Color.Black;
            this.LpVertScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LpVertScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LpVertScale.ForeColor = System.Drawing.Color.White;
            this.LpVertScale.FormattingEnabled = true;
            this.LpVertScale.Location = new System.Drawing.Point(61, 70);
            this.LpVertScale.Margin = new System.Windows.Forms.Padding(2);
            this.LpVertScale.Name = "LpVertScale";
            this.LpVertScale.Size = new System.Drawing.Size(63, 21);
            this.LpVertScale.TabIndex = 1;
            // 
            // LpVertScaleP
            // 
            this.LpVertScaleP.BackColor = System.Drawing.Color.Black;
            this.LpVertScaleP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LpVertScaleP.ForeColor = System.Drawing.Color.White;
            this.LpVertScaleP.Location = new System.Drawing.Point(128, 60);
            this.LpVertScaleP.Margin = new System.Windows.Forms.Padding(2);
            this.LpVertScaleP.Name = "LpVertScaleP";
            this.LpVertScaleP.Size = new System.Drawing.Size(26, 19);
            this.LpVertScaleP.TabIndex = 0;
            this.LpVertScaleP.Text = "+";
            this.LpVertScaleP.UseVisualStyleBackColor = false;
            // 
            // LpVertScaleM
            // 
            this.LpVertScaleM.BackColor = System.Drawing.Color.Black;
            this.LpVertScaleM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LpVertScaleM.ForeColor = System.Drawing.Color.White;
            this.LpVertScaleM.Location = new System.Drawing.Point(128, 83);
            this.LpVertScaleM.Margin = new System.Windows.Forms.Padding(2);
            this.LpVertScaleM.Name = "LpVertScaleM";
            this.LpVertScaleM.Size = new System.Drawing.Size(26, 19);
            this.LpVertScaleM.TabIndex = 3;
            this.LpVertScaleM.Text = "-";
            this.LpVertScaleM.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Black;
            this.groupBox3.Controls.Add(this.LpOffsetDCremove);
            this.groupBox3.Controls.Add(this.LpVertOfsMM);
            this.groupBox3.Controls.Add(this.LpVertOfsM);
            this.groupBox3.Controls.Add(this.LpVertOfs0);
            this.groupBox3.Controls.Add(this.LpVertOfsP);
            this.groupBox3.Controls.Add(this.LpVertOfsPP);
            this.groupBox3.Controls.Add(this.LpVertOfs);
            this.groupBox3.Controls.Add(this.LpVertOfsVal);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(10, 139);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(159, 169);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Offset";
            // 
            // LpOffsetDCremove
            // 
            this.LpOffsetDCremove.AutoSize = true;
            this.LpOffsetDCremove.BackColor = System.Drawing.Color.Black;
            this.LpOffsetDCremove.Location = new System.Drawing.Point(73, 105);
            this.LpOffsetDCremove.Margin = new System.Windows.Forms.Padding(2);
            this.LpOffsetDCremove.Name = "LpOffsetDCremove";
            this.LpOffsetDCremove.Size = new System.Drawing.Size(84, 17);
            this.LpOffsetDCremove.TabIndex = 11;
            this.LpOffsetDCremove.Text = "Remove DC";
            this.LpOffsetDCremove.UseVisualStyleBackColor = false;
            // 
            // LpVertOfsMM
            // 
            this.LpVertOfsMM.BackColor = System.Drawing.Color.Black;
            this.LpVertOfsMM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LpVertOfsMM.ForeColor = System.Drawing.Color.White;
            this.LpVertOfsMM.Location = new System.Drawing.Point(43, 128);
            this.LpVertOfsMM.Margin = new System.Windows.Forms.Padding(2);
            this.LpVertOfsMM.Name = "LpVertOfsMM";
            this.LpVertOfsMM.Size = new System.Drawing.Size(26, 19);
            this.LpVertOfsMM.TabIndex = 10;
            this.LpVertOfsMM.Text = "--";
            this.LpVertOfsMM.UseVisualStyleBackColor = false;
            // 
            // LpVertOfsM
            // 
            this.LpVertOfsM.BackColor = System.Drawing.Color.Black;
            this.LpVertOfsM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LpVertOfsM.ForeColor = System.Drawing.Color.White;
            this.LpVertOfsM.Location = new System.Drawing.Point(43, 105);
            this.LpVertOfsM.Margin = new System.Windows.Forms.Padding(2);
            this.LpVertOfsM.Name = "LpVertOfsM";
            this.LpVertOfsM.Size = new System.Drawing.Size(26, 19);
            this.LpVertOfsM.TabIndex = 9;
            this.LpVertOfsM.Text = "-";
            this.LpVertOfsM.UseVisualStyleBackColor = false;
            // 
            // LpVertOfs0
            // 
            this.LpVertOfs0.BackColor = System.Drawing.Color.Black;
            this.LpVertOfs0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LpVertOfs0.ForeColor = System.Drawing.Color.White;
            this.LpVertOfs0.Location = new System.Drawing.Point(43, 81);
            this.LpVertOfs0.Margin = new System.Windows.Forms.Padding(2);
            this.LpVertOfs0.Name = "LpVertOfs0";
            this.LpVertOfs0.Size = new System.Drawing.Size(26, 19);
            this.LpVertOfs0.TabIndex = 8;
            this.LpVertOfs0.Text = "0";
            this.LpVertOfs0.UseVisualStyleBackColor = false;
            // 
            // LpVertOfsP
            // 
            this.LpVertOfsP.BackColor = System.Drawing.Color.Black;
            this.LpVertOfsP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LpVertOfsP.ForeColor = System.Drawing.Color.White;
            this.LpVertOfsP.Location = new System.Drawing.Point(43, 58);
            this.LpVertOfsP.Margin = new System.Windows.Forms.Padding(2);
            this.LpVertOfsP.Name = "LpVertOfsP";
            this.LpVertOfsP.Size = new System.Drawing.Size(26, 19);
            this.LpVertOfsP.TabIndex = 7;
            this.LpVertOfsP.Text = "+";
            this.LpVertOfsP.UseVisualStyleBackColor = false;
            // 
            // LpVertOfsPP
            // 
            this.LpVertOfsPP.BackColor = System.Drawing.Color.Black;
            this.LpVertOfsPP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LpVertOfsPP.ForeColor = System.Drawing.Color.White;
            this.LpVertOfsPP.Location = new System.Drawing.Point(43, 34);
            this.LpVertOfsPP.Margin = new System.Windows.Forms.Padding(0);
            this.LpVertOfsPP.Name = "LpVertOfsPP";
            this.LpVertOfsPP.Size = new System.Drawing.Size(26, 19);
            this.LpVertOfsPP.TabIndex = 6;
            this.LpVertOfsPP.Text = "++";
            this.LpVertOfsPP.UseVisualStyleBackColor = false;
            // 
            // LpVertOfs
            // 
            this.LpVertOfs.BackColor = System.Drawing.Color.Black;
            this.LpVertOfs.LargeChange = 10;
            this.LpVertOfs.Location = new System.Drawing.Point(12, 20);
            this.LpVertOfs.Margin = new System.Windows.Forms.Padding(2);
            this.LpVertOfs.Maximum = 100000;
            this.LpVertOfs.Minimum = -100000;
            this.LpVertOfs.Name = "LpVertOfs";
            this.LpVertOfs.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.LpVertOfs.Size = new System.Drawing.Size(45, 143);
            this.LpVertOfs.TabIndex = 4;
            this.LpVertOfs.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // LpVertOfsVal
            // 
            this.LpVertOfsVal.BackColor = System.Drawing.Color.Black;
            this.LpVertOfsVal.ForeColor = System.Drawing.Color.White;
            this.LpVertOfsVal.Location = new System.Drawing.Point(73, 81);
            this.LpVertOfsVal.Margin = new System.Windows.Forms.Padding(2);
            this.LpVertOfsVal.Name = "LpVertOfsVal";
            this.LpVertOfsVal.ReadOnly = true;
            this.LpVertOfsVal.Size = new System.Drawing.Size(70, 20);
            this.LpVertOfsVal.TabIndex = 5;
            // 
            // LpScreen
            // 
            this.LpScreen.BackColor = System.Drawing.Color.Black;
            this.LpScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LpScreen.Location = new System.Drawing.Point(0, 0);
            this.LpScreen.Margin = new System.Windows.Forms.Padding(2);
            this.LpScreen.Name = "LpScreen";
            this.LpScreen.Size = new System.Drawing.Size(342, 201);
            this.LpScreen.TabIndex = 6;
            // 
            // LinePlotterWin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(520, 318);
            this.Controls.Add(this.LpScreen);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(536, 354);
            this.Name = "LinePlotterWin";
            this.Text = "Line Plotter";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lpScaleYMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lpScaleYMin)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LpVertOfs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LpVertChannelLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button LpHorzScaleM;
        private System.Windows.Forms.ComboBox LpHorzScale;
        private System.Windows.Forms.Button LpHorzScaleP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox LpChannelOnD;
        private System.Windows.Forms.CheckBox LpChannelOnC;
        private System.Windows.Forms.CheckBox LpChannelOnB;
        private System.Windows.Forms.CheckBox LpChannelOnA;
        private System.Windows.Forms.RadioButton LpChannelSelectD;
        private System.Windows.Forms.RadioButton LpChannelSelectC;
        private System.Windows.Forms.RadioButton LpChannelSelectB;
        private System.Windows.Forms.RadioButton LpChannelSelectA;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox LpVertScale;
        private System.Windows.Forms.Button LpVertScaleP;
        private System.Windows.Forms.Button LpVertScaleM;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox LpVertAC;
        private System.Windows.Forms.Button LpVertOfsMM;
        private System.Windows.Forms.Button LpVertOfsM;
        private System.Windows.Forms.Button LpVertOfs0;
        private System.Windows.Forms.Button LpVertOfsP;
        private System.Windows.Forms.Button LpVertOfsPP;
        private System.Windows.Forms.TrackBar LpVertOfs;
        private System.Windows.Forms.TextBox LpVertOfsVal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox LpStoreLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox LpVertMode;
        private LinePlotterScreen LpScreen;
        private System.Windows.Forms.Button LpSaveButton;
        private System.Windows.Forms.CheckBox LpOffsetDCremove;
        private System.Windows.Forms.Button lpAutoScale;
        private System.Windows.Forms.CheckBox lpRun;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox lpDisplays;
        private System.Windows.Forms.CheckBox lpAutoScaleY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown lpScaleYMax;
        private System.Windows.Forms.NumericUpDown lpScaleYMin;
        private System.Windows.Forms.ComboBox lpSelectDisplay;
    }
}