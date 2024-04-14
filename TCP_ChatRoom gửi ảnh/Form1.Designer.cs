namespace Lab3_Bai06
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
            btnServer = new System.Windows.Forms.Button();
            btnClient = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btnServer
            // 
            btnServer.Location = new System.Drawing.Point(30, 18);
            btnServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnServer.Name = "btnServer";
            btnServer.Size = new System.Drawing.Size(112, 27);
            btnServer.TabIndex = 0;
            btnServer.Text = "Server";
            btnServer.UseVisualStyleBackColor = true;
            btnServer.Click += btnServer_Click;
            // 
            // btnClient
            // 
            btnClient.Location = new System.Drawing.Point(187, 18);
            btnClient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnClient.Name = "btnClient";
            btnClient.Size = new System.Drawing.Size(112, 27);
            btnClient.TabIndex = 1;
            btnClient.Text = "Client";
            btnClient.UseVisualStyleBackColor = true;
            btnClient.Click += btnClient_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(338, 66);
            Controls.Add(btnClient);
            Controls.Add(btnServer);
            Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.Button btnClient;
    }
}
