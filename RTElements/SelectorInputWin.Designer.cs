namespace AudioProcessor
{
    partial class SelectorInputWin
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
            this.SelectorWinList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // SelectorWinList
            // 
            this.SelectorWinList.BackColor = System.Drawing.Color.Black;
            this.SelectorWinList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectorWinList.ForeColor = System.Drawing.Color.White;
            this.SelectorWinList.FormattingEnabled = true;
            this.SelectorWinList.IntegralHeight = false;
            this.SelectorWinList.ItemHeight = 16;
            this.SelectorWinList.Location = new System.Drawing.Point(0, 0);
            this.SelectorWinList.Name = "SelectorWinList";
            this.SelectorWinList.Size = new System.Drawing.Size(331, 129);
            this.SelectorWinList.TabIndex = 0;
            // 
            // SelectorInputWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(331, 129);
            this.Controls.Add(this.SelectorWinList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectorInputWin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SelectorInputWin";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox SelectorWinList;
    }
}