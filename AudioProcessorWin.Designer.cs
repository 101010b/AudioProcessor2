namespace AudioProcessor
{
    partial class AudioProcessorWin
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioProcessorWin));
            this.audioProcessorStatusStrip = new System.Windows.Forms.StatusStrip();
            this.audioProcessorStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.audioProcessingSampleRate = new System.Windows.Forms.ToolStripDropDownButton();
            this.audioProcessingBufferLength = new System.Windows.Forms.ToolStripDropDownButton();
            this.audioProcessorMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioProcessorFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.audioProcessorFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.audioProcessorFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.audioProcessorFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioProcessorWindowLog = new System.Windows.Forms.ToolStripMenuItem();
            this.audioProcessorToolBar = new System.Windows.Forms.ToolStrip();
            this.tsOpen = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.audioProcessorTSInput = new System.Windows.Forms.ToolStripMenuItem();
            this.audioProcessorTSOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.audioProcessorTSGenerators = new System.Windows.Forms.ToolStripMenuItem();
            this.audioProcessorTSFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.audioProcessorTSArith = new System.Windows.Forms.ToolStripMenuItem();
            this.audioProcessorTSTools = new System.Windows.Forms.ToolStripMenuItem();
            this.audioProcessorTSControl = new System.Windows.Forms.ToolStripMenuItem();
            this.audioProcessorTSData = new System.Windows.Forms.ToolStripMenuItem();
            this.systemPanel = new AudioProcessor.SystemPanel();
            this.audioProcessorStatusStrip.SuspendLayout();
            this.audioProcessorMenu.SuspendLayout();
            this.audioProcessorToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // audioProcessorStatusStrip
            // 
            this.audioProcessorStatusStrip.BackColor = System.Drawing.Color.Black;
            this.audioProcessorStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.audioProcessorStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.audioProcessorStatusLabel,
            this.audioProcessingSampleRate,
            this.audioProcessingBufferLength});
            this.audioProcessorStatusStrip.Location = new System.Drawing.Point(0, 819);
            this.audioProcessorStatusStrip.Name = "audioProcessorStatusStrip";
            this.audioProcessorStatusStrip.Size = new System.Drawing.Size(1230, 22);
            this.audioProcessorStatusStrip.TabIndex = 0;
            this.audioProcessorStatusStrip.Text = "statusStrip1";
            // 
            // audioProcessorStatusLabel
            // 
            this.audioProcessorStatusLabel.ForeColor = System.Drawing.Color.Lime;
            this.audioProcessorStatusLabel.Name = "audioProcessorStatusLabel";
            this.audioProcessorStatusLabel.Size = new System.Drawing.Size(43, 17);
            this.audioProcessorStatusLabel.Text = "Offline";
            // 
            // audioProcessingSampleRate
            // 
            this.audioProcessingSampleRate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.audioProcessingSampleRate.ForeColor = System.Drawing.Color.Lime;
            this.audioProcessingSampleRate.Image = ((System.Drawing.Image)(resources.GetObject("audioProcessingSampleRate.Image")));
            this.audioProcessingSampleRate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.audioProcessingSampleRate.Name = "audioProcessingSampleRate";
            this.audioProcessingSampleRate.Size = new System.Drawing.Size(50, 20);
            this.audioProcessingSampleRate.Text = "44100";
            // 
            // audioProcessingBufferLength
            // 
            this.audioProcessingBufferLength.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.audioProcessingBufferLength.ForeColor = System.Drawing.Color.Lime;
            this.audioProcessingBufferLength.Image = ((System.Drawing.Image)(resources.GetObject("audioProcessingBufferLength.Image")));
            this.audioProcessingBufferLength.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.audioProcessingBufferLength.Name = "audioProcessingBufferLength";
            this.audioProcessingBufferLength.Size = new System.Drawing.Size(54, 20);
            this.audioProcessingBufferLength.Text = "200ms";
            // 
            // audioProcessorMenu
            // 
            this.audioProcessorMenu.BackColor = System.Drawing.Color.Black;
            this.audioProcessorMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.audioProcessorMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.windowToolStripMenuItem});
            this.audioProcessorMenu.Location = new System.Drawing.Point(0, 0);
            this.audioProcessorMenu.Name = "audioProcessorMenu";
            this.audioProcessorMenu.Size = new System.Drawing.Size(1230, 24);
            this.audioProcessorMenu.TabIndex = 1;
            this.audioProcessorMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.audioProcessorFileOpen,
            this.audioProcessorFileSave,
            this.audioProcessorFileSaveAs,
            this.toolStripSeparator1,
            this.audioProcessorFileExit});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // audioProcessorFileOpen
            // 
            this.audioProcessorFileOpen.Name = "audioProcessorFileOpen";
            this.audioProcessorFileOpen.Size = new System.Drawing.Size(114, 22);
            this.audioProcessorFileOpen.Text = "Open";
            // 
            // audioProcessorFileSave
            // 
            this.audioProcessorFileSave.Name = "audioProcessorFileSave";
            this.audioProcessorFileSave.Size = new System.Drawing.Size(114, 22);
            this.audioProcessorFileSave.Text = "Save";
            // 
            // audioProcessorFileSaveAs
            // 
            this.audioProcessorFileSaveAs.Name = "audioProcessorFileSaveAs";
            this.audioProcessorFileSaveAs.Size = new System.Drawing.Size(114, 22);
            this.audioProcessorFileSaveAs.Text = "Save As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(111, 6);
            // 
            // audioProcessorFileExit
            // 
            this.audioProcessorFileExit.Name = "audioProcessorFileExit";
            this.audioProcessorFileExit.Size = new System.Drawing.Size(114, 22);
            this.audioProcessorFileExit.Text = "Exit";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.addToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.addToolStripMenuItem.Text = "New Element";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.windowToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.audioProcessorWindowLog});
            this.windowToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // audioProcessorWindowLog
            // 
            this.audioProcessorWindowLog.Name = "audioProcessorWindowLog";
            this.audioProcessorWindowLog.Size = new System.Drawing.Size(94, 22);
            this.audioProcessorWindowLog.Text = "Log";
            // 
            // audioProcessorToolBar
            // 
            this.audioProcessorToolBar.BackColor = System.Drawing.Color.Black;
            this.audioProcessorToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.audioProcessorToolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.audioProcessorToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOpen,
            this.tsSave,
            this.toolStripSeparator2,
            this.tsDelete,
            this.toolStripSeparator3,
            this.audioProcessorTSInput,
            this.audioProcessorTSOutput,
            this.toolStripSeparator4,
            this.audioProcessorTSGenerators,
            this.audioProcessorTSFilter,
            this.audioProcessorTSArith,
            this.audioProcessorTSTools,
            this.audioProcessorTSControl,
            this.audioProcessorTSData});
            this.audioProcessorToolBar.Location = new System.Drawing.Point(0, 24);
            this.audioProcessorToolBar.Name = "audioProcessorToolBar";
            this.audioProcessorToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.audioProcessorToolBar.Size = new System.Drawing.Size(1230, 27);
            this.audioProcessorToolBar.TabIndex = 3;
            this.audioProcessorToolBar.Text = "ROOT";
            // 
            // tsOpen
            // 
            this.tsOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsOpen.Image")));
            this.tsOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsOpen.Name = "tsOpen";
            this.tsOpen.Size = new System.Drawing.Size(24, 24);
            this.tsOpen.Text = "Open";
            // 
            // tsSave
            // 
            this.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSave.Image = ((System.Drawing.Image)(resources.GetObject("tsSave.Image")));
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(24, 24);
            this.tsSave.Text = "Save";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tsDelete
            // 
            this.tsDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsDelete.Image")));
            this.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(24, 24);
            this.tsDelete.Text = "Delete";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // audioProcessorTSInput
            // 
            this.audioProcessorTSInput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.audioProcessorTSInput.Image = ((System.Drawing.Image)(resources.GetObject("audioProcessorTSInput.Image")));
            this.audioProcessorTSInput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.audioProcessorTSInput.Name = "audioProcessorTSInput";
            this.audioProcessorTSInput.Size = new System.Drawing.Size(32, 27);
            this.audioProcessorTSInput.Text = "Input";
            this.audioProcessorTSInput.ToolTipText = "Inputs";
            // 
            // audioProcessorTSOutput
            // 
            this.audioProcessorTSOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.audioProcessorTSOutput.Image = ((System.Drawing.Image)(resources.GetObject("audioProcessorTSOutput.Image")));
            this.audioProcessorTSOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.audioProcessorTSOutput.Name = "audioProcessorTSOutput";
            this.audioProcessorTSOutput.Size = new System.Drawing.Size(32, 27);
            this.audioProcessorTSOutput.Text = "Output";
            this.audioProcessorTSOutput.ToolTipText = "Outputs";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // audioProcessorTSGenerators
            // 
            this.audioProcessorTSGenerators.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.audioProcessorTSGenerators.Image = ((System.Drawing.Image)(resources.GetObject("audioProcessorTSGenerators.Image")));
            this.audioProcessorTSGenerators.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.audioProcessorTSGenerators.Name = "audioProcessorTSGenerators";
            this.audioProcessorTSGenerators.Size = new System.Drawing.Size(32, 27);
            this.audioProcessorTSGenerators.Text = "Generators";
            this.audioProcessorTSGenerators.ToolTipText = "Generators";
            // 
            // audioProcessorTSFilter
            // 
            this.audioProcessorTSFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.audioProcessorTSFilter.Image = ((System.Drawing.Image)(resources.GetObject("audioProcessorTSFilter.Image")));
            this.audioProcessorTSFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.audioProcessorTSFilter.Name = "audioProcessorTSFilter";
            this.audioProcessorTSFilter.Size = new System.Drawing.Size(32, 27);
            this.audioProcessorTSFilter.Text = "Filter";
            this.audioProcessorTSFilter.ToolTipText = "Filter";
            // 
            // audioProcessorTSArith
            // 
            this.audioProcessorTSArith.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.audioProcessorTSArith.Image = ((System.Drawing.Image)(resources.GetObject("audioProcessorTSArith.Image")));
            this.audioProcessorTSArith.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.audioProcessorTSArith.Name = "audioProcessorTSArith";
            this.audioProcessorTSArith.Size = new System.Drawing.Size(32, 27);
            this.audioProcessorTSArith.Text = "Arithmetic";
            this.audioProcessorTSArith.ToolTipText = "Arithmetic";
            // 
            // audioProcessorTSTools
            // 
            this.audioProcessorTSTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.audioProcessorTSTools.Image = ((System.Drawing.Image)(resources.GetObject("audioProcessorTSTools.Image")));
            this.audioProcessorTSTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.audioProcessorTSTools.Name = "audioProcessorTSTools";
            this.audioProcessorTSTools.Size = new System.Drawing.Size(32, 27);
            this.audioProcessorTSTools.Text = "Tools";
            this.audioProcessorTSTools.ToolTipText = "Tools";
            // 
            // audioProcessorTSControl
            // 
            this.audioProcessorTSControl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.audioProcessorTSControl.Image = ((System.Drawing.Image)(resources.GetObject("audioProcessorTSControl.Image")));
            this.audioProcessorTSControl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.audioProcessorTSControl.Name = "audioProcessorTSControl";
            this.audioProcessorTSControl.Size = new System.Drawing.Size(32, 27);
            this.audioProcessorTSControl.Text = "Controls";
            this.audioProcessorTSControl.ToolTipText = "Controls";
            // 
            // audioProcessorTSData
            // 
            this.audioProcessorTSData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.audioProcessorTSData.Image = ((System.Drawing.Image)(resources.GetObject("audioProcessorTSData.Image")));
            this.audioProcessorTSData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.audioProcessorTSData.Name = "audioProcessorTSData";
            this.audioProcessorTSData.Size = new System.Drawing.Size(32, 27);
            this.audioProcessorTSData.Text = "Data";
            this.audioProcessorTSData.ToolTipText = "Data";
            // 
            // systemPanel
            // 
            this.systemPanel.BackColor = System.Drawing.Color.Black;
            this.systemPanel.colorGrid = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(0)))));
            this.systemPanel.colorSelect = System.Drawing.Color.RoyalBlue;
            this.systemPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.systemPanel.Location = new System.Drawing.Point(0, 51);
            this.systemPanel.Name = "systemPanel";
            this.systemPanel.netNameColor = System.Drawing.Color.DimGray;
            this.systemPanel.netNameFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.systemPanel.Size = new System.Drawing.Size(1230, 768);
            this.systemPanel.TabIndex = 4;
            // 
            // AudioProcessorWin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1230, 841);
            this.Controls.Add(this.systemPanel);
            this.Controls.Add(this.audioProcessorToolBar);
            this.Controls.Add(this.audioProcessorStatusStrip);
            this.Controls.Add(this.audioProcessorMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.audioProcessorMenu;
            this.Name = "AudioProcessorWin";
            this.Text = "Audio Processor";
            this.audioProcessorStatusStrip.ResumeLayout(false);
            this.audioProcessorStatusStrip.PerformLayout();
            this.audioProcessorMenu.ResumeLayout(false);
            this.audioProcessorMenu.PerformLayout();
            this.audioProcessorToolBar.ResumeLayout(false);
            this.audioProcessorToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip audioProcessorStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel audioProcessorStatusLabel;
        private System.Windows.Forms.MenuStrip audioProcessorMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem audioProcessorFileOpen;
        private System.Windows.Forms.ToolStripMenuItem audioProcessorFileSave;
        private System.Windows.Forms.ToolStripMenuItem audioProcessorFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem audioProcessorFileExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem audioProcessorWindowLog;
        private System.Windows.Forms.ToolStripDropDownButton audioProcessingSampleRate;
        private System.Windows.Forms.ToolStrip audioProcessorToolBar;
        private System.Windows.Forms.ToolStripButton tsOpen;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem audioProcessorTSInput;
        private System.Windows.Forms.ToolStripMenuItem audioProcessorTSOutput;
        private SystemPanel systemPanel;
        private System.Windows.Forms.ToolStripMenuItem audioProcessorTSGenerators;
        private System.Windows.Forms.ToolStripMenuItem audioProcessorTSFilter;
        private System.Windows.Forms.ToolStripMenuItem audioProcessorTSArith;
        private System.Windows.Forms.ToolStripMenuItem audioProcessorTSTools;
        private System.Windows.Forms.ToolStripDropDownButton audioProcessingBufferLength;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem audioProcessorTSControl;
        private System.Windows.Forms.ToolStripMenuItem audioProcessorTSData;
    }
}

