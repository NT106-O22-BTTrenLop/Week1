namespace Lab3_Bai06
{
    partial class You
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
            rtbChatBox = new System.Windows.Forms.RichTextBox();
            txtMessage = new System.Windows.Forms.TextBox();
            btnChoose = new System.Windows.Forms.Button();
            btnSend = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // rtbChatBox
            // 
            rtbChatBox.Location = new System.Drawing.Point(25, 17);
            rtbChatBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            rtbChatBox.Name = "rtbChatBox";
            rtbChatBox.Size = new System.Drawing.Size(473, 161);
            rtbChatBox.TabIndex = 0;
            rtbChatBox.Text = "";
            // 
            // txtMessage
            // 
            txtMessage.Location = new System.Drawing.Point(25, 205);
            txtMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new System.Drawing.Size(273, 28);
            txtMessage.TabIndex = 1;
            // 
            // btnChoose
            // 
            btnChoose.Location = new System.Drawing.Point(311, 203);
            btnChoose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnChoose.Name = "btnChoose";
            btnChoose.Size = new System.Drawing.Size(69, 30);
            btnChoose.TabIndex = 2;
            btnChoose.Text = "...";
            btnChoose.UseVisualStyleBackColor = true;
            btnChoose.Click += btnChoose_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new System.Drawing.Point(386, 202);
            btnSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnSend.Name = "btnSend";
            btnSend.Size = new System.Drawing.Size(112, 31);
            btnSend.TabIndex = 3;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // You
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.HotPink;
            ClientSize = new System.Drawing.Size(525, 258);
            Controls.Add(btnSend);
            Controls.Add(btnChoose);
            Controls.Add(txtMessage);
            Controls.Add(rtbChatBox);
            Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "You";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "You";
            Load += You_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbChatBox;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Button btnSend;
    }
}