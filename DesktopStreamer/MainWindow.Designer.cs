namespace DesktopStreamer
{
    partial class MainWindow
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
            this.udpButton = new System.Windows.Forms.RadioButton();
            this.tcpButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sentFramesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // udpButton
            // 
            this.udpButton.AutoSize = true;
            this.udpButton.Checked = true;
            this.udpButton.Location = new System.Drawing.Point(13, 13);
            this.udpButton.Name = "udpButton";
            this.udpButton.Size = new System.Drawing.Size(48, 17);
            this.udpButton.TabIndex = 0;
            this.udpButton.TabStop = true;
            this.udpButton.Text = "UDP";
            this.udpButton.UseVisualStyleBackColor = true;
            this.udpButton.Click += new System.EventHandler(this.UDPButton_Clicked);
            // 
            // tcpButton
            // 
            this.tcpButton.AutoSize = true;
            this.tcpButton.Location = new System.Drawing.Point(13, 37);
            this.tcpButton.Name = "tcpButton";
            this.tcpButton.Size = new System.Drawing.Size(46, 17);
            this.tcpButton.TabIndex = 1;
            this.tcpButton.Text = "TCP";
            this.tcpButton.UseVisualStyleBackColor = true;
            this.tcpButton.Click += new System.EventHandler(this.TCPButton_Clicked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(289, 13);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(143, 20);
            this.ipTextBox.TabIndex = 3;
            this.ipTextBox.TextChanged += new System.EventHandler(this.ipTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sent Frames:";
            // 
            // sentFramesLabel
            // 
            this.sentFramesLabel.AutoSize = true;
            this.sentFramesLabel.Location = new System.Drawing.Point(89, 76);
            this.sentFramesLabel.Name = "sentFramesLabel";
            this.sentFramesLabel.Size = new System.Drawing.Size(0, 13);
            this.sentFramesLabel.TabIndex = 5;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(453, 264);
            this.Controls.Add(this.sentFramesLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tcpButton);
            this.Controls.Add(this.udpButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DesktopStreamer";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton udpButton;
        private System.Windows.Forms.RadioButton tcpButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sentFramesLabel;
    }
}

