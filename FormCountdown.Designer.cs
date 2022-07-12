namespace WinCountdown
{
    partial class FormCountdown
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelCountdown = new CustomLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelCountdown
            // 
            this.labelCountdown.AutoSize = true;
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
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomLabel labelCountdown;
        private System.Windows.Forms.Timer timer;
    }
}