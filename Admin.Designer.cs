﻿namespace MainApplication
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.label1 = new System.Windows.Forms.Label();
            this.btnFtp = new System.Windows.Forms.Button();
            this.lblFtpStatusMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome Admin";
            // 
            // btnFtp
            // 
            this.btnFtp.Location = new System.Drawing.Point(122, 125);
            this.btnFtp.Name = "btnFtp";
            this.btnFtp.Size = new System.Drawing.Size(179, 23);
            this.btnFtp.TabIndex = 1;
            this.btnFtp.Text = "Backup Data to FTP Server";
            this.btnFtp.UseVisualStyleBackColor = true;
            this.btnFtp.Click += new System.EventHandler(this.btnFtp_Click);
            // 
            // lblFtpStatusMessage
            // 
            this.lblFtpStatusMessage.AutoSize = true;
            this.lblFtpStatusMessage.Location = new System.Drawing.Point(119, 186);
            this.lblFtpStatusMessage.Name = "lblFtpStatusMessage";
            this.lblFtpStatusMessage.Size = new System.Drawing.Size(0, 13);
            this.lblFtpStatusMessage.TabIndex = 2;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 262);
            this.Controls.Add(this.lblFtpStatusMessage);
            this.Controls.Add(this.btnFtp);
            this.Controls.Add(this.label1);
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFtp;
        private System.Windows.Forms.Label lblFtpStatusMessage;
    }
}