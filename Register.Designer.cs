
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MainApplication
{
    partial class Register
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtRegisterUsername = new System.Windows.Forms.TextBox();
            this.lblRegisterUsername = new System.Windows.Forms.Label();
            this.lblRegisterPassword = new System.Windows.Forms.Label();
            this.txtRegisterPassword = new System.Windows.Forms.TextBox();
            this.lblRegisterConfirmPassword = new System.Windows.Forms.Label();
            this.txtRegisterConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtRegisterEmail = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnRegisterCancel = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "To register, complete this form and submit.";
            // 
            // txtRegisterUsername
            // 
            this.txtRegisterUsername.Location = new System.Drawing.Point(109, 64);
            this.txtRegisterUsername.Name = "txtRegisterUsername";
            this.txtRegisterUsername.Size = new System.Drawing.Size(142, 20);
            this.txtRegisterUsername.TabIndex = 1;
            // 
            // lblRegisterUsername
            // 
            this.lblRegisterUsername.AutoSize = true;
            this.lblRegisterUsername.Location = new System.Drawing.Point(48, 67);
            this.lblRegisterUsername.Name = "lblRegisterUsername";
            this.lblRegisterUsername.Size = new System.Drawing.Size(55, 13);
            this.lblRegisterUsername.TabIndex = 2;
            this.lblRegisterUsername.Text = "Username";
            // 
            // lblRegisterPassword
            // 
            this.lblRegisterPassword.AutoSize = true;
            this.lblRegisterPassword.Location = new System.Drawing.Point(50, 93);
            this.lblRegisterPassword.Name = "lblRegisterPassword";
            this.lblRegisterPassword.Size = new System.Drawing.Size(53, 13);
            this.lblRegisterPassword.TabIndex = 3;
            this.lblRegisterPassword.Text = "Password";
            // 
            // txtRegisterPassword
            // 
            this.txtRegisterPassword.Location = new System.Drawing.Point(109, 90);
            this.txtRegisterPassword.Name = "txtRegisterPassword";
            this.txtRegisterPassword.Size = new System.Drawing.Size(142, 20);
            this.txtRegisterPassword.TabIndex = 4;
            this.txtRegisterPassword.UseSystemPasswordChar = true;
            // 
            // lblRegisterConfirmPassword
            // 
            this.lblRegisterConfirmPassword.AutoSize = true;
            this.lblRegisterConfirmPassword.Location = new System.Drawing.Point(12, 119);
            this.lblRegisterConfirmPassword.Name = "lblRegisterConfirmPassword";
            this.lblRegisterConfirmPassword.Size = new System.Drawing.Size(91, 13);
            this.lblRegisterConfirmPassword.TabIndex = 5;
            this.lblRegisterConfirmPassword.Text = "Confirm Password";
            // 
            // txtRegisterConfirmPassword
            // 
            this.txtRegisterConfirmPassword.Location = new System.Drawing.Point(109, 116);
            this.txtRegisterConfirmPassword.Name = "txtRegisterConfirmPassword";
            this.txtRegisterConfirmPassword.Size = new System.Drawing.Size(142, 20);
            this.txtRegisterConfirmPassword.TabIndex = 6;
            this.txtRegisterConfirmPassword.UseSystemPasswordChar = true;
            // 
            // txtRegisterEmail
            // 
            this.txtRegisterEmail.Location = new System.Drawing.Point(109, 142);
            this.txtRegisterEmail.Name = "txtRegisterEmail";
            this.txtRegisterEmail.Size = new System.Drawing.Size(142, 20);
            this.txtRegisterEmail.TabIndex = 7;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(109, 185);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(142, 23);
            this.btnRegister.TabIndex = 8;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnRegisterCancel
            // 
            this.btnRegisterCancel.Location = new System.Drawing.Point(45, 185);
            this.btnRegisterCancel.Name = "btnRegisterCancel";
            this.btnRegisterCancel.Size = new System.Drawing.Size(58, 23);
            this.btnRegisterCancel.TabIndex = 9;
            this.btnRegisterCancel.Text = "Cancel";
            this.btnRegisterCancel.UseVisualStyleBackColor = true;
            this.btnRegisterCancel.Click += new System.EventHandler(this.btnRegisterCancel_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.AutoSize = true;
            this.txtEmail.Location = new System.Drawing.Point(57, 145);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(46, 13);
            this.txtEmail.TabIndex = 10;
            this.txtEmail.Text = "Email ID";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(277, 227);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnRegisterCancel);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtRegisterEmail);
            this.Controls.Add(this.txtRegisterConfirmPassword);
            this.Controls.Add(this.lblRegisterConfirmPassword);
            this.Controls.Add(this.txtRegisterPassword);
            this.Controls.Add(this.lblRegisterPassword);
            this.Controls.Add(this.lblRegisterUsername);
            this.Controls.Add(this.txtRegisterUsername);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtRegisterUsername;
		private System.Windows.Forms.Label lblRegisterUsername;
		private System.Windows.Forms.Label lblRegisterPassword;
		private System.Windows.Forms.TextBox txtRegisterPassword;
		private System.Windows.Forms.Label lblRegisterConfirmPassword;
		private System.Windows.Forms.TextBox txtRegisterConfirmPassword;
		private System.Windows.Forms.TextBox txtRegisterEmail;
		private System.Windows.Forms.Button btnRegister;
		private System.Windows.Forms.Button btnRegisterCancel;
		private System.Windows.Forms.Label txtEmail;
	}
}