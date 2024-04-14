namespace Lab3_Bai06
{
    partial class Server
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
            btnListen = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lstChatBox
            // 
            lstChatBox.FormattingEnabled = true;
            lstChatBox.ItemHeight = 20;
            lstChatBox.Location = new System.Drawing.Point(27, 66);
            lstChatBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            lstChatBox.Name = "lstChatBox";
            lstChatBox.Size = new System.Drawing.Size(391, 164);
            lstChatBox.TabIndex = 0;
            // 
            // btnListen
            // 
            btnListen.Location = new System.Drawing.Point(306, 23);
            btnListen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnListen.Name = "btnListen";
            btnListen.Size = new System.Drawing.Size(112, 27);
            btnListen.TabIndex = 1;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click;
            // 
            // Server
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(454, 254);
            Controls.Add(btnListen);
            Controls.Add(lstChatBox);
            Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "Server";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Server";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox lstChatBox;
        private System.Windows.Forms.Button btnListen;
    }
}