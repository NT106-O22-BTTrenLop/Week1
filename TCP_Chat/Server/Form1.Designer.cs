namespace Server

{
    partial class Form1
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
            label1 = new System.Windows.Forms.Label();
            txtIP = new System.Windows.Forms.TextBox();
            txtInfo = new System.Windows.Forms.TextBox();
            txtMessage = new System.Windows.Forms.TextBox();
            btnSend = new System.Windows.Forms.Button();
            btnStart = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            lstClientIP = new System.Windows.Forms.ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(36, 27);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(60, 20);
            label1.TabIndex = 0;
            label1.Text = "Server:";
            // 
            // txtIP
            // 
            txtIP.Location = new System.Drawing.Point(125, 27);
            txtIP.Name = "txtIP";
            txtIP.Size = new System.Drawing.Size(399, 28);
            txtIP.TabIndex = 1;
            txtIP.Text = "127.0.0.1:9000";
            // 
            // txtInfo
            // 
            txtInfo.Location = new System.Drawing.Point(125, 75);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtInfo.Size = new System.Drawing.Size(399, 190);
            txtInfo.TabIndex = 2;
            // 
            // txtMessage
            // 
            txtMessage.Location = new System.Drawing.Point(125, 285);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new System.Drawing.Size(399, 28);
            txtMessage.TabIndex = 3;
            // 
            // btnSend
            // 
            btnSend.Location = new System.Drawing.Point(277, 326);
            btnSend.Name = "btnSend";
            btnSend.Size = new System.Drawing.Size(112, 34);
            btnSend.TabIndex = 4;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new System.Drawing.Point(412, 326);
            btnStart.Name = "btnStart";
            btnStart.Size = new System.Drawing.Size(112, 34);
            btnStart.TabIndex = 5;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(36, 285);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(75, 20);
            label2.TabIndex = 6;
            label2.Text = "Message:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(554, 27);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(77, 20);
            label3.TabIndex = 7;
            label3.Text = "Client IP:";
            // 
            // lstClientIP
            // 
            lstClientIP.FormattingEnabled = true;
            lstClientIP.ItemHeight = 20;
            lstClientIP.Location = new System.Drawing.Point(557, 77);
            lstClientIP.Name = "lstClientIP";
            lstClientIP.Size = new System.Drawing.Size(258, 284);
            lstClientIP.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(840, 386);
            Controls.Add(lstClientIP);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnStart);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(txtInfo);
            Controls.Add(txtIP);
            Controls.Add(label1);
            Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Server";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstClientIP;
    }
}
