namespace AudioProcessor.SinkSource
{
    partial class WaterfallSpectrumWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaterfallSpectrumWin));
            this.waterfallSpectrumAutoScale = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.waterfallSpectrumOverlap = new System.Windows.Forms.CheckBox();
            this.waterfallSpectrumRun = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.waterfallSpectrumWindow = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.waterfallSpectrumBlockSize = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.waterfallSpectrumShowGrid = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.waterfallSpectrumColorScheme = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.waterfallSpectrumFMax = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.waterfallSpectrumFMin = new System.Windows.Forms.NumericUpDown();
            this.waterfallSpectrumFLog = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.waterfallSpectrumScreen = new AudioProcessor.SinkSource.WaterfallSpectrumScreen();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waterfallSpectrumFMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterfallSpectrumFMin)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // waterfallSpectrumAutoScale
            // 
            this.waterfallSpectrumAutoScale.BackColor = System.Drawing.Color.Black;
            this.waterfallSpectrumAutoScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.waterfallSpectrumAutoScale.ForeColor = System.Drawing.Color.White;
            this.waterfallSpectrumAutoScale.Location = new System.Drawing.Point(299, 67);
            this.waterfallSpectrumAutoScale.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.waterfallSpectrumAutoScale.Name = "waterfallSpectrumAutoScale";
            this.waterfallSpectrumAutoScale.Size = new System.Drawing.Size(40, 29);
            this.waterfallSpectrumAutoScale.TabIndex = 39;
            this.waterfallSpectrumAutoScale.Text = "[ ]";
            this.waterfallSpectrumAutoScale.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Black;
            this.groupBox2.Controls.Add(this.waterfallSpectrumOverlap);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.waterfallSpectrumWindow);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.waterfallSpectrumBlockSize);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(9, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(162, 104);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FFT Parameters";
            // 
            // waterfallSpectrumOverlap
            // 
            this.waterfallSpectrumOverlap.AutoSize = true;
            this.waterfallSpectrumOverlap.BackColor = System.Drawing.Color.Black;
            this.waterfallSpectrumOverlap.ForeColor = System.Drawing.Color.White;
            this.waterfallSpectrumOverlap.Location = new System.Drawing.Point(73, 74);
            this.waterfallSpectrumOverlap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.waterfallSpectrumOverlap.Name = "waterfallSpectrumOverlap";
            this.waterfallSpectrumOverlap.Size = new System.Drawing.Size(85, 17);
            this.waterfallSpectrumOverlap.TabIndex = 27;
            this.waterfallSpectrumOverlap.Text = "Overlap FFT";
            this.waterfallSpectrumOverlap.UseVisualStyleBackColor = false;
            this.waterfallSpectrumOverlap.Visible = false;
            // 
            // waterfallSpectrumRun
            // 
            this.waterfallSpectrumRun.AutoSize = true;
            this.waterfallSpectrumRun.BackColor = System.Drawing.Color.Black;
            this.waterfallSpectrumRun.ForeColor = System.Drawing.Color.White;
            this.waterfallSpectrumRun.Location = new System.Drawing.Point(7, 74);
            this.waterfallSpectrumRun.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.waterfallSpectrumRun.Name = "waterfallSpectrumRun";
            this.waterfallSpectrumRun.Size = new System.Drawing.Size(46, 17);
            this.waterfallSpectrumRun.TabIndex = 26;
            this.waterfallSpectrumRun.Text = "Run";
            this.waterfallSpectrumRun.UseVisualStyleBackColor = false;
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
            // waterfallSpectrumWindow
            // 
            this.waterfallSpectrumWindow.BackColor = System.Drawing.Color.Black;
            this.waterfallSpectrumWindow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.waterfallSpectrumWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.waterfallSpectrumWindow.ForeColor = System.Drawing.Color.White;
            this.waterfallSpectrumWindow.FormattingEnabled = true;
            this.waterfallSpectrumWindow.Location = new System.Drawing.Point(62, 43);
            this.waterfallSpectrumWindow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.waterfallSpectrumWindow.Name = "waterfallSpectrumWindow";
            this.waterfallSpectrumWindow.Size = new System.Drawing.Size(95, 21);
            this.waterfallSpectrumWindow.TabIndex = 24;
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
            // waterfallSpectrumBlockSize
            // 
            this.waterfallSpectrumBlockSize.BackColor = System.Drawing.Color.Black;
            this.waterfallSpectrumBlockSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.waterfallSpectrumBlockSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.waterfallSpectrumBlockSize.ForeColor = System.Drawing.Color.White;
            this.waterfallSpectrumBlockSize.FormattingEnabled = true;
            this.waterfallSpectrumBlockSize.Location = new System.Drawing.Point(62, 19);
            this.waterfallSpectrumBlockSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.waterfallSpectrumBlockSize.Name = "waterfallSpectrumBlockSize";
            this.waterfallSpectrumBlockSize.Size = new System.Drawing.Size(95, 21);
            this.waterfallSpectrumBlockSize.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.waterfallSpectrumShowGrid);
            this.groupBox1.Controls.Add(this.waterfallSpectrumRun);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.waterfallSpectrumColorScheme);
            this.groupBox1.Controls.Add(this.waterfallSpectrumAutoScale);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.waterfallSpectrumFMax);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.waterfallSpectrumFMin);
            this.groupBox1.Controls.Add(this.waterfallSpectrumFLog);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(176, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(347, 104);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display Parameters";
            // 
            // waterfallSpectrumShowGrid
            // 
            this.waterfallSpectrumShowGrid.AutoSize = true;
            this.waterfallSpectrumShowGrid.BackColor = System.Drawing.Color.Black;
            this.waterfallSpectrumShowGrid.ForeColor = System.Drawing.Color.White;
            this.waterfallSpectrumShowGrid.Location = new System.Drawing.Point(115, 74);
            this.waterfallSpectrumShowGrid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.waterfallSpectrumShowGrid.Name = "waterfallSpectrumShowGrid";
            this.waterfallSpectrumShowGrid.Size = new System.Drawing.Size(75, 17);
            this.waterfallSpectrumShowGrid.TabIndex = 42;
            this.waterfallSpectrumShowGrid.Text = "Show Grid";
            this.waterfallSpectrumShowGrid.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(159, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Color Scheme";
            // 
            // waterfallSpectrumColorScheme
            // 
            this.waterfallSpectrumColorScheme.BackColor = System.Drawing.Color.Black;
            this.waterfallSpectrumColorScheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.waterfallSpectrumColorScheme.ForeColor = System.Drawing.Color.White;
            this.waterfallSpectrumColorScheme.FormattingEnabled = true;
            this.waterfallSpectrumColorScheme.Location = new System.Drawing.Point(236, 20);
            this.waterfallSpectrumColorScheme.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.waterfallSpectrumColorScheme.Name = "waterfallSpectrumColorScheme";
            this.waterfallSpectrumColorScheme.Size = new System.Drawing.Size(103, 21);
            this.waterfallSpectrumColorScheme.TabIndex = 40;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(112, 41);
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
            // waterfallSpectrumFMax
            // 
            this.waterfallSpectrumFMax.BackColor = System.Drawing.Color.Black;
            this.waterfallSpectrumFMax.ForeColor = System.Drawing.Color.White;
            this.waterfallSpectrumFMax.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.waterfallSpectrumFMax.Location = new System.Drawing.Point(40, 39);
            this.waterfallSpectrumFMax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.waterfallSpectrumFMax.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.waterfallSpectrumFMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.waterfallSpectrumFMax.Name = "waterfallSpectrumFMax";
            this.waterfallSpectrumFMax.Size = new System.Drawing.Size(68, 20);
            this.waterfallSpectrumFMax.TabIndex = 30;
            this.waterfallSpectrumFMax.Value = new decimal(new int[] {
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
            this.label11.Location = new System.Drawing.Point(112, 21);
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
            // waterfallSpectrumFMin
            // 
            this.waterfallSpectrumFMin.BackColor = System.Drawing.Color.Black;
            this.waterfallSpectrumFMin.ForeColor = System.Drawing.Color.White;
            this.waterfallSpectrumFMin.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.waterfallSpectrumFMin.Location = new System.Drawing.Point(40, 20);
            this.waterfallSpectrumFMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.waterfallSpectrumFMin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.waterfallSpectrumFMin.Name = "waterfallSpectrumFMin";
            this.waterfallSpectrumFMin.Size = new System.Drawing.Size(68, 20);
            this.waterfallSpectrumFMin.TabIndex = 27;
            this.waterfallSpectrumFMin.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // waterfallSpectrumFLog
            // 
            this.waterfallSpectrumFLog.AutoSize = true;
            this.waterfallSpectrumFLog.BackColor = System.Drawing.Color.Black;
            this.waterfallSpectrumFLog.ForeColor = System.Drawing.Color.White;
            this.waterfallSpectrumFLog.Location = new System.Drawing.Point(64, 74);
            this.waterfallSpectrumFLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.waterfallSpectrumFLog.Name = "waterfallSpectrumFLog";
            this.waterfallSpectrumFLog.Size = new System.Drawing.Size(44, 17);
            this.waterfallSpectrumFLog.TabIndex = 26;
            this.waterfallSpectrumFLog.Text = "Log";
            this.waterfallSpectrumFLog.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 371);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(536, 117);
            this.panel2.TabIndex = 6;
            // 
            // waterfallSpectrumScreen
            // 
            this.waterfallSpectrumScreen.BackColor = System.Drawing.Color.Black;
            this.waterfallSpectrumScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.waterfallSpectrumScreen.Location = new System.Drawing.Point(0, 0);
            this.waterfallSpectrumScreen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.waterfallSpectrumScreen.Name = "waterfallSpectrumScreen";
            this.waterfallSpectrumScreen.Size = new System.Drawing.Size(536, 371);
            this.waterfallSpectrumScreen.TabIndex = 7;
            // 
            // WaterfallSpectrumWin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(536, 488);
            this.Controls.Add(this.waterfallSpectrumScreen);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(552, 527);
            this.Name = "WaterfallSpectrumWin";
            this.Text = "Waterfall Spectrum";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waterfallSpectrumFMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterfallSpectrumFMin)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button waterfallSpectrumAutoScale;
        private WaterfallSpectrumScreen waterfallSpectrumScreen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox waterfallSpectrumRun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox waterfallSpectrumWindow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox waterfallSpectrumBlockSize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown waterfallSpectrumFMax;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown waterfallSpectrumFMin;
        private System.Windows.Forms.CheckBox waterfallSpectrumFLog;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox waterfallSpectrumColorScheme;
        private System.Windows.Forms.CheckBox waterfallSpectrumOverlap;
        private System.Windows.Forms.CheckBox waterfallSpectrumShowGrid;
    }
}