namespace DesktopViewer
{
    partial class DesktopViewer
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
            this.button1 = new System.Windows.Forms.Button();
            this.udpButton = new System.Windows.Forms.RadioButton();
            this.tcpButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // udpButton
            // 
            this.udpButton.AutoSize = true;
            this.udpButton.Checked = true;
            this.udpButton.Location = new System.Drawing.Point(12, 12);
            this.udpButton.Name = "udpButton";
            this.udpButton.Size = new System.Drawing.Size(48, 19);
            this.udpButton.TabIndex = 1;
            this.udpButton.TabStop = true;
            this.udpButton.Text = "UDP";
            this.udpButton.UseVisualStyleBackColor = true;
            this.udpButton.Click += new System.EventHandler(this.UDPButton_Clicked);
            // 
            // tcpButton
            // 
            this.tcpButton.AutoSize = true;
            this.tcpButton.Location = new System.Drawing.Point(12, 37);
            this.tcpButton.Name = "tcpButton";
            this.tcpButton.Size = new System.Drawing.Size(45, 19);
            this.tcpButton.TabIndex = 2;
            this.tcpButton.Text = "TCP";
            this.tcpButton.UseVisualStyleBackColor = true;
            this.tcpButton.Click += new System.EventHandler(this.TCPButton_Clicked);
            // 
            // DesktopViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(384, 216);
            this.Controls.Add(this.tcpButton);
            this.Controls.Add(this.udpButton);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DesktopViewer";
            this.Text = "DesktopViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DesktopViewer_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private RadioButton udpButton;
        private RadioButton tcpButton;
    }
}