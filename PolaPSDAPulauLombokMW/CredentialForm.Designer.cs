
namespace PolaPSDAPulauLombokMW
{
    partial class CredentialForm
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
            this.txtPW = new System.Windows.Forms.TextBox();
            this.lblPW = new System.Windows.Forms.Label();
            this.lblPWMessage = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPW
            // 
            this.txtPW.Location = new System.Drawing.Point(74, 118);
            this.txtPW.Name = "txtPW";
            this.txtPW.Size = new System.Drawing.Size(199, 20);
            this.txtPW.TabIndex = 0;
            // 
            // lblPW
            // 
            this.lblPW.AutoSize = true;
            this.lblPW.Location = new System.Drawing.Point(12, 121);
            this.lblPW.Name = "lblPW";
            this.lblPW.Size = new System.Drawing.Size(56, 13);
            this.lblPW.TabIndex = 1;
            this.lblPW.Text = "Password:";
            // 
            // lblPWMessage
            // 
            this.lblPWMessage.AutoSize = true;
            this.lblPWMessage.Location = new System.Drawing.Point(125, 39);
            this.lblPWMessage.Name = "lblPWMessage";
            this.lblPWMessage.Size = new System.Drawing.Size(148, 13);
            this.lblPWMessage.TabIndex = 2;
            this.lblPWMessage.Text = "Silahkan masukkan password";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(290, 118);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // CredentialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 203);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblPWMessage);
            this.Controls.Add(this.lblPW);
            this.Controls.Add(this.txtPW);
            this.Name = "CredentialForm";
            this.Text = "Credential";
            this.Load += new System.EventHandler(this.CredentialForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPW;
        private System.Windows.Forms.Label lblPW;
        private System.Windows.Forms.Label lblPWMessage;
        private System.Windows.Forms.Button btnLogin;
    }
}