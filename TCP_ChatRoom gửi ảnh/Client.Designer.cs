namespace Lab3_Bai06
{
    partial class Client
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
            lstChatBox = new System.Windows.Forms.ListBox();
            grbName = new System.Windows.Forms.GroupBox();
            btnConnect = new System.Windows.Forms.Button();
            txtName = new System.Windows.Forms.TextBox();
            grbMessage = new System.Windows.Forms.GroupBox();
            btnSend = new System.Windows.Forms.Button();
            txtMessage = new System.Windows.Forms.TextBox();
            grbParticipants = new System.Windows.Forms.GroupBox();
            lstParticipants = new System.Windows.Forms.ListBox();
            grbName.SuspendLayout();
            grbMessage.SuspendLayout();
            grbParticipants.SuspendLayout();
            SuspendLayout();
            // 
            // lstChatBox
            // 
            lstChatBox.FormattingEnabled = true;
            lstChatBox.ItemHeight = 20;
            lstChatBox.Location = new System.Drawing.Point(30, 18);
            lstChatBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            lstChatBox.Name = "lstChatBox";
            lstChatBox.Size = new System.Drawing.Size(454, 184);
            lstChatBox.TabIndex = 0;
            // 
            // grbName
            // 
            grbName.Controls.Add(btnConnect);
            grbName.Controls.Add(txtName);
            grbName.Location = new System.Drawing.Point(30, 227);
            grbName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            grbName.Name = "grbName";
            grbName.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            grbName.Size = new System.Drawing.Size(454, 67);
            grbName.TabIndex = 1;
            grbName.TabStop = false;
            grbName.Text = "Your name";
            // 
            // btnConnect
            // 
            btnConnect.Location = new System.Drawing.Point(316, 24);
            btnConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new System.Drawing.Size(112, 27);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtName
            // 
            txtName.Location = new System.Drawing.Point(29, 24);
            txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(236, 28);
            txtName.TabIndex = 0;
            // 
            // grbMessage
            // 
            grbMessage.Controls.Add(btnSend);
            grbMessage.Controls.Add(txtMessage);
            grbMessage.Location = new System.Drawing.Point(30, 318);
            grbMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            grbMessage.Name = "grbMessage";
            grbMessage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            grbMessage.Size = new System.Drawing.Size(454, 67);
            grbMessage.TabIndex = 2;
            grbMessage.TabStop = false;
            grbMessage.Text = "Message";
            // 
            // btnSend
            // 
            btnSend.Location = new System.Drawing.Point(316, 22);
            btnSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnSend.Name = "btnSend";
            btnSend.Size = new System.Drawing.Size(112, 27);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtMessage
            // 
            txtMessage.Location = new System.Drawing.Point(29, 24);
            txtMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new System.Drawing.Size(236, 28);
            txtMessage.TabIndex = 1;
            // 
            // grbParticipants
            // 
            grbParticipants.Controls.Add(lstParticipants);
            grbParticipants.Location = new System.Drawing.Point(510, 17);
            grbParticipants.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            grbParticipants.Name = "grbParticipants";
            grbParticipants.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            grbParticipants.Size = new System.Drawing.Size(185, 369);
            grbParticipants.TabIndex = 3;
            grbParticipants.TabStop = false;
            grbParticipants.Text = "Participants";
            // 
            // lstParticipants
            // 
            lstParticipants.FormattingEnabled = true;
            lstParticipants.ItemHeight = 20;
            lstParticipants.Location = new System.Drawing.Point(10, 24);
            lstParticipants.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            lstParticipants.Name = "lstParticipants";
            lstParticipants.Size = new System.Drawing.Size(169, 324);
            lstParticipants.TabIndex = 0;
            lstParticipants.SelectedIndexChanged += lstParticipants_SelectedIndexChanged;
            // 
            // Client
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.DarkCyan;
            ClientSize = new System.Drawing.Size(719, 402);
            Controls.Add(grbParticipants);
            Controls.Add(grbMessage);
            Controls.Add(grbName);
            Controls.Add(lstChatBox);
            Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "Client";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Client";
            grbName.ResumeLayout(false);
            grbName.PerformLayout();
            grbMessage.ResumeLayout(false);
            grbMessage.PerformLayout();
            grbParticipants.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox lstChatBox;
        private System.Windows.Forms.GroupBox grbName;
        private System.Windows.Forms.GroupBox grbMessage;
        private System.Windows.Forms.GroupBox grbParticipants;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ListBox lstParticipants;
    }
}