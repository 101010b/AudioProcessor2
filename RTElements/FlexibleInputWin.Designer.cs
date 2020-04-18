namespace AudioProcessor
{
    partial class FlexibleInputWin
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
            this.numericInVal = new System.Windows.Forms.TextBox();
            this.numericInUnit = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericInVal
            // 
            this.numericInVal.AcceptsReturn = true;
            this.numericInVal.Location = new System.Drawing.Point(6, 6);
            this.numericInVal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericInVal.Name = "numericInVal";
            this.numericInVal.Size = new System.Drawing.Size(96, 20);
            this.numericInVal.TabIndex = 0;
            this.numericInVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericInUnit
            // 
            this.numericInUnit.AutoSize = true;
            this.numericInUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.numericInUnit.ForeColor = System.Drawing.Color.White;
            this.numericInUnit.Location = new System.Drawing.Point(108, 9);
            this.numericInUnit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.numericInUnit.Name = "numericInUnit";
            this.numericInUnit.Size = new System.Drawing.Size(35, 13);
            this.numericInUnit.TabIndex = 12;
            this.numericInUnit.Text = "label2";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.numericInVal);
            this.panel1.Controls.Add(this.numericInUnit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 31);
            this.panel1.TabIndex = 13;
            // 
            // FlexibleInputWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(153, 31);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FlexibleInputWin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "NumericInputWin";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox numericInVal;
        private System.Windows.Forms.Label numericInUnit;
        private System.Windows.Forms.Panel panel1;
    }
}