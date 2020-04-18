namespace AudioProcessor
{
    partial class LogWin
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
            this.logText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // logText
            // 
            this.logText.BackColor = System.Drawing.SystemColors.Info;
            this.logText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logText.Location = new System.Drawing.Point(0, 0);
            this.logText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.logText.Multiline = true;
            this.logText.Name = "logText";
            this.logText.ReadOnly = true;
            this.logText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logText.Size = new System.Drawing.Size(809, 132);
            this.logText.TabIndex = 0;
            // 
            // LogWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 132);
            this.Controls.Add(this.logText);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LogWin";
            this.ShowIcon = false;
            this.Text = "LogWin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox logText;
    }
}