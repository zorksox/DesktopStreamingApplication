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
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.droppedFramesLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.receivedFramesLabel = new System.Windows.Forms.Label();
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
            this.udpButton.Location = new System.Drawing.Point(12, 16);
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
            this.tcpButton.Location = new System.Drawing.Point(12, 41);
            this.tcpButton.Name = "tcpButton";
            this.tcpButton.Size = new System.Drawing.Size(45, 19);
            this.tcpButton.TabIndex = 2;
            this.tcpButton.Text = "TCP";
            this.tcpButton.UseVisualStyleBackColor = true;
            this.tcpButton.Click += new System.EventHandler(this.TCPButton_Clicked);
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(240, 12);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(132, 23);
            this.ipTextBox.TabIndex = 3;
            this.ipTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dropped frames:";
            // 
            // droppedFramesLabel
            // 
            this.droppedFramesLabel.AutoSize = true;
            this.droppedFramesLabel.Location = new System.Drawing.Point(113, 80);
            this.droppedFramesLabel.Name = "droppedFramesLabel";
            this.droppedFramesLabel.Size = new System.Drawing.Size(0, 15);
            this.droppedFramesLabel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Received Frames:";
            // 
            // receivedFramesLabel
            // 
            this.receivedFramesLabel.AutoSize = true;
            this.receivedFramesLabel.Location = new System.Drawing.Point(113, 95);
            this.receivedFramesLabel.Name = "receivedFramesLabel";
            this.receivedFramesLabel.Size = new System.Drawing.Size(0, 15);
            this.receivedFramesLabel.TabIndex = 7;
            // 
            // DesktopViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(384, 216);
            this.Controls.Add(this.receivedFramesLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.droppedFramesLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.udpButton);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.tcpButton);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "DesktopViewer";
            this.Text = "DesktopViewer";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.DesktopViewer_Activated);
            this.Deactivate += new System.EventHandler(this.DesktopViewer_Deactivate);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private RadioButton udpButton;
        private RadioButton tcpButton;
        private TextBox ipTextBox;
        private Label label1;
        private Label droppedFramesLabel;
        private Label label2;
        private Label receivedFramesLabel;
    }
} 