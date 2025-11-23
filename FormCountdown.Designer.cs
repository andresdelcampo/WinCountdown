namespace WinCountdown
{
    partial class FormCountdown
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCountdown));
            this.labelCountdown = new CustomLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.startPauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.add1MinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add5MinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtract1MinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.pauseResumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.hideLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.labelContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCountdown
            //
            this.labelCountdown.AutoSize = true;
            this.labelCountdown.ContextMenuStrip = this.labelContextMenuStrip;
            this.labelCountdown.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelCountdown.Font = new System.Drawing.Font("Segoe UI", 96F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCountdown.ForeColor = System.Drawing.Color.White;
            this.labelCountdown.Location = new System.Drawing.Point(18, 0);
            this.labelCountdown.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCountdown.Name = "labelCountdown";
            this.labelCountdown.OutlineForeColor = System.Drawing.Color.Black;
            this.labelCountdown.OutlineWidth = 2F;
            this.labelCountdown.Size = new System.Drawing.Size(542, 170);
            this.labelCountdown.TabIndex = 0;
            this.labelCountdown.Text = "00:05:00";
            this.labelCountdown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelCountdown_MouseDown);
            this.labelCountdown.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelCountdown_MouseMove);
            this.labelCountdown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelCountdown_MouseUp);
            //
            // timer
            //
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            //
            // notifyIcon
            //
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Text = "WinCountdown";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            //
            // contextMenuStrip
            //
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.hideToolStripMenuItem,
            this.toolStripSeparator1,
            this.startPauseToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(151, 126);
            //
            // showToolStripMenuItem
            //
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            //
            // hideToolStripMenuItem
            //
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            //
            // toolStripSeparator1
            //
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(147, 6);
            //
            // startPauseToolStripMenuItem
            //
            this.startPauseToolStripMenuItem.Name = "startPauseToolStripMenuItem";
            this.startPauseToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.startPauseToolStripMenuItem.Text = "Start/Pause";
            this.startPauseToolStripMenuItem.Click += new System.EventHandler(this.startPauseToolStripMenuItem_Click);
            //
            // resetToolStripMenuItem
            //
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            //
            // toolStripSeparator2
            //
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(147, 6);
            //
            // exitToolStripMenuItem
            //
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            //
            // labelContextMenuStrip
            //
            this.labelContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.add1MinToolStripMenuItem,
            this.add5MinToolStripMenuItem,
            this.subtract1MinToolStripMenuItem,
            this.toolStripSeparator3,
            this.pauseResumeToolStripMenuItem,
            this.resetLabelToolStripMenuItem,
            this.toolStripSeparator4,
            this.hideLabelToolStripMenuItem});
            this.labelContextMenuStrip.Name = "labelContextMenuStrip";
            this.labelContextMenuStrip.Size = new System.Drawing.Size(161, 148);
            //
            // add1MinToolStripMenuItem
            //
            this.add1MinToolStripMenuItem.Name = "add1MinToolStripMenuItem";
            this.add1MinToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.add1MinToolStripMenuItem.Text = "Add 1 Minute";
            this.add1MinToolStripMenuItem.Click += new System.EventHandler(this.add1MinToolStripMenuItem_Click);
            //
            // add5MinToolStripMenuItem
            //
            this.add5MinToolStripMenuItem.Name = "add5MinToolStripMenuItem";
            this.add5MinToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.add5MinToolStripMenuItem.Text = "Add 5 Minutes";
            this.add5MinToolStripMenuItem.Click += new System.EventHandler(this.add5MinToolStripMenuItem_Click);
            //
            // subtract1MinToolStripMenuItem
            //
            this.subtract1MinToolStripMenuItem.Name = "subtract1MinToolStripMenuItem";
            this.subtract1MinToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.subtract1MinToolStripMenuItem.Text = "Subtract 1 Minute";
            this.subtract1MinToolStripMenuItem.Click += new System.EventHandler(this.subtract1MinToolStripMenuItem_Click);
            //
            // toolStripSeparator3
            //
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            //
            // pauseResumeToolStripMenuItem
            //
            this.pauseResumeToolStripMenuItem.Name = "pauseResumeToolStripMenuItem";
            this.pauseResumeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.pauseResumeToolStripMenuItem.Text = "Pause/Resume";
            this.pauseResumeToolStripMenuItem.Click += new System.EventHandler(this.pauseResumeToolStripMenuItem_Click);
            //
            // resetLabelToolStripMenuItem
            //
            this.resetLabelToolStripMenuItem.Name = "resetLabelToolStripMenuItem";
            this.resetLabelToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.resetLabelToolStripMenuItem.Text = "Reset";
            this.resetLabelToolStripMenuItem.Click += new System.EventHandler(this.resetLabelToolStripMenuItem_Click);
            //
            // toolStripSeparator4
            //
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(157, 6);
            //
            // hideLabelToolStripMenuItem
            //
            this.hideLabelToolStripMenuItem.Name = "hideLabelToolStripMenuItem";
            this.hideLabelToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.hideLabelToolStripMenuItem.Text = "Hide";
            this.hideLabelToolStripMenuItem.Click += new System.EventHandler(this.hideLabelToolStripMenuItem_Click);
            //
            // FormCountdown
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 180);
            this.Controls.Add(this.labelCountdown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormCountdown";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.FormCountdown_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.labelContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomLabel labelCountdown;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem startPauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip labelContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem add1MinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem add5MinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subtract1MinToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem pauseResumeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetLabelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem hideLabelToolStripMenuItem;
    }
}