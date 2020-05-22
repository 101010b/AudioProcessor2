namespace AudioProcessor.DataProcessing
{
    partial class DataViewerWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataViewerWin));
            this.cbList = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctColor = new System.Windows.Forms.Control();
            this.bnColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbYLog = new System.Windows.Forms.CheckBox();
            this.tbYMax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbYMin = new System.Windows.Forms.TextBox();
            this.cbYAutoscale = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbRunning = new System.Windows.Forms.CheckBox();
            this.cbXRange = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dv = new AudioProcessor.DataProcessing.DataViewerScreen();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbList
            // 
            this.cbList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cbList.BackColor = System.Drawing.Color.Black;
            this.cbList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cbList.CheckOnClick = true;
            this.cbList.ForeColor = System.Drawing.Color.White;
            this.cbList.FormattingEnabled = true;
            this.cbList.Location = new System.Drawing.Point(12, 15);
            this.cbList.Name = "cbList";
            this.cbList.ScrollAlwaysVisible = true;
            this.cbList.Size = new System.Drawing.Size(125, 152);
            this.cbList.TabIndex = 2;
            this.cbList.SelectedIndexChanged += new System.EventHandler(this.cbList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.ctColor);
            this.groupBox1.Controls.Add(this.bnColor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(125, 48);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Style";
            // 
            // ctColor
            // 
            this.ctColor.BackColor = System.Drawing.Color.DimGray;
            this.ctColor.Location = new System.Drawing.Point(43, 14);
            this.ctColor.Name = "ctColor";
            this.ctColor.Size = new System.Drawing.Size(25, 25);
            this.ctColor.TabIndex = 2;
            this.ctColor.Text = "control1";
            // 
            // bnColor
            // 
            this.bnColor.ForeColor = System.Drawing.Color.Black;
            this.bnColor.Location = new System.Drawing.Point(74, 14);
            this.bnColor.Name = "bnColor";
            this.bnColor.Size = new System.Drawing.Size(43, 25);
            this.bnColor.TabIndex = 1;
            this.bnColor.Text = "Set";
            this.bnColor.UseVisualStyleBackColor = true;
            this.bnColor.Click += new System.EventHandler(this.bnColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Color";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.BackColor = System.Drawing.Color.Black;
            this.groupBox2.Controls.Add(this.cbYLog);
            this.groupBox2.Controls.Add(this.tbYMax);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbYMin);
            this.groupBox2.Controls.Add(this.cbYAutoscale);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 311);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(125, 118);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Y-Axis";
            // 
            // cbYLog
            // 
            this.cbYLog.AutoSize = true;
            this.cbYLog.Location = new System.Drawing.Point(38, 71);
            this.cbYLog.Name = "cbYLog";
            this.cbYLog.Size = new System.Drawing.Size(80, 17);
            this.cbYLog.TabIndex = 5;
            this.cbYLog.Text = "Logarithmic";
            this.cbYLog.UseVisualStyleBackColor = true;
            this.cbYLog.CheckedChanged += new System.EventHandler(this.cbYLog_CheckedChanged);
            // 
            // tbYMax
            // 
            this.tbYMax.BackColor = System.Drawing.Color.Black;
            this.tbYMax.ForeColor = System.Drawing.Color.White;
            this.tbYMax.Location = new System.Drawing.Point(38, 45);
            this.tbYMax.Name = "tbYMax";
            this.tbYMax.Size = new System.Drawing.Size(71, 20);
            this.tbYMax.TabIndex = 4;
            this.tbYMax.TextChanged += new System.EventHandler(this.tbYMax_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Max";
            // 
            // tbYMin
            // 
            this.tbYMin.BackColor = System.Drawing.Color.Black;
            this.tbYMin.ForeColor = System.Drawing.Color.White;
            this.tbYMin.Location = new System.Drawing.Point(38, 19);
            this.tbYMin.Name = "tbYMin";
            this.tbYMin.Size = new System.Drawing.Size(71, 20);
            this.tbYMin.TabIndex = 2;
            this.tbYMin.TextChanged += new System.EventHandler(this.tbYMin_TextChanged);
            // 
            // cbYAutoscale
            // 
            this.cbYAutoscale.AutoSize = true;
            this.cbYAutoscale.Location = new System.Drawing.Point(38, 94);
            this.cbYAutoscale.Name = "cbYAutoscale";
            this.cbYAutoscale.Size = new System.Drawing.Size(75, 17);
            this.cbYAutoscale.TabIndex = 1;
            this.cbYAutoscale.Text = "AutoScale";
            this.cbYAutoscale.UseVisualStyleBackColor = true;
            this.cbYAutoscale.CheckedChanged += new System.EventHandler(this.cbYAutoscale_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Min";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.BackColor = System.Drawing.Color.Black;
            this.groupBox3.Controls.Add(this.cbRunning);
            this.groupBox3.Controls.Add(this.cbXRange);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 237);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(125, 68);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "X-Axis";
            // 
            // cbRunning
            // 
            this.cbRunning.AutoSize = true;
            this.cbRunning.Location = new System.Drawing.Point(38, 46);
            this.cbRunning.Name = "cbRunning";
            this.cbRunning.Size = new System.Drawing.Size(66, 17);
            this.cbRunning.TabIndex = 2;
            this.cbRunning.Text = "Running";
            this.cbRunning.UseVisualStyleBackColor = true;
            this.cbRunning.CheckedChanged += new System.EventHandler(this.cbRunning_CheckedChanged);
            // 
            // cbXRange
            // 
            this.cbXRange.BackColor = System.Drawing.Color.Black;
            this.cbXRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbXRange.ForeColor = System.Drawing.Color.White;
            this.cbXRange.FormattingEnabled = true;
            this.cbXRange.Location = new System.Drawing.Point(51, 19);
            this.cbXRange.Name = "cbXRange";
            this.cbXRange.Size = new System.Drawing.Size(58, 21);
            this.cbXRange.TabIndex = 1;
            this.cbXRange.SelectedIndexChanged += new System.EventHandler(this.cbXRange_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "range";
            // 
            // dv
            // 
            this.dv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dv.backColor = System.Drawing.Color.Black;
            this.dv.frameColor = System.Drawing.Color.White;
            this.dv.gridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(0)))));
            this.dv.gridFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dv.gridFontColor = System.Drawing.Color.DimGray;
            this.dv.Location = new System.Drawing.Point(143, 12);
            this.dv.majorGridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.dv.Name = "dv";
            this.dv.Size = new System.Drawing.Size(469, 417);
            this.dv.TabIndex = 1;
            this.dv.Text = "dataViewerScreen1";
            // 
            // DataViewerWin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbList);
            this.Controls.Add(this.dv);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "DataViewerWin";
            this.Text = "Data Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataViewerWin_FormClosing);
            this.Load += new System.EventHandler(this.DataViewerWin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DataViewerScreen dv;
        private System.Windows.Forms.CheckedListBox cbList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbRunning;
        private System.Windows.Forms.ComboBox cbXRange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bnColor;
        private System.Windows.Forms.CheckBox cbYLog;
        private System.Windows.Forms.TextBox tbYMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbYMin;
        private System.Windows.Forms.CheckBox cbYAutoscale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Control ctColor;
    }
}