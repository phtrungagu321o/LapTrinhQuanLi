
namespace ĐỒ_ÁN.GUI
{
    partial class ToolEncrytAnDecryt
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
            this.txt_url = new System.Windows.Forms.TextBox();
            this.btn_browser = new System.Windows.Forms.Button();
            this.btn_decrypt = new System.Windows.Forms.Button();
            this.btn_encrypt = new System.Windows.Forms.Button();
            this.txtDecipheredFile = new System.Windows.Forms.RichTextBox();
            this.txtCiphertextFile = new System.Windows.Forms.RichTextBox();
            this.txtPlaintextFile = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(7, 26);
            this.txt_url.Multiline = true;
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(220, 31);
            this.txt_url.TabIndex = 19;
            // 
            // btn_browser
            // 
            this.btn_browser.Location = new System.Drawing.Point(378, 24);
            this.btn_browser.Name = "btn_browser";
            this.btn_browser.Size = new System.Drawing.Size(83, 23);
            this.btn_browser.TabIndex = 18;
            this.btn_browser.Text = "Chọn file...";
            this.btn_browser.UseVisualStyleBackColor = true;
            this.btn_browser.Click += new System.EventHandler(this.btn_browser_Click);
            // 
            // btn_decrypt
            // 
            this.btn_decrypt.Location = new System.Drawing.Point(596, 109);
            this.btn_decrypt.Name = "btn_decrypt";
            this.btn_decrypt.Size = new System.Drawing.Size(63, 23);
            this.btn_decrypt.TabIndex = 17;
            this.btn_decrypt.Text = "Giải mã";
            this.btn_decrypt.UseVisualStyleBackColor = true;
            this.btn_decrypt.Click += new System.EventHandler(this.btn_decrypt_Click);
            // 
            // btn_encrypt
            // 
            this.btn_encrypt.Location = new System.Drawing.Point(233, 109);
            this.btn_encrypt.Name = "btn_encrypt";
            this.btn_encrypt.Size = new System.Drawing.Size(63, 23);
            this.btn_encrypt.TabIndex = 16;
            this.btn_encrypt.Text = "Mã hóa";
            this.btn_encrypt.UseVisualStyleBackColor = true;
            this.btn_encrypt.Click += new System.EventHandler(this.btn_encrypt_Click);
            // 
            // txtDecipheredFile
            // 
            this.txtDecipheredFile.Location = new System.Drawing.Point(665, 63);
            this.txtDecipheredFile.Name = "txtDecipheredFile";
            this.txtDecipheredFile.Size = new System.Drawing.Size(288, 158);
            this.txtDecipheredFile.TabIndex = 15;
            this.txtDecipheredFile.Text = "";
            // 
            // txtCiphertextFile
            // 
            this.txtCiphertextFile.Location = new System.Drawing.Point(302, 63);
            this.txtCiphertextFile.Name = "txtCiphertextFile";
            this.txtCiphertextFile.Size = new System.Drawing.Size(288, 163);
            this.txtCiphertextFile.TabIndex = 14;
            this.txtCiphertextFile.Text = "";
            // 
            // txtPlaintextFile
            // 
            this.txtPlaintextFile.Location = new System.Drawing.Point(7, 63);
            this.txtPlaintextFile.Name = "txtPlaintextFile";
            this.txtPlaintextFile.Size = new System.Drawing.Size(220, 158);
            this.txtPlaintextFile.TabIndex = 13;
            this.txtPlaintextFile.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_url);
            this.panel1.Controls.Add(this.btn_browser);
            this.panel1.Controls.Add(this.btn_decrypt);
            this.panel1.Controls.Add(this.btn_encrypt);
            this.panel1.Controls.Add(this.txtDecipheredFile);
            this.panel1.Controls.Add(this.txtCiphertextFile);
            this.panel1.Controls.Add(this.txtPlaintextFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(988, 305);
            this.panel1.TabIndex = 20;
            // 
            // ToolEncrytAnDecryt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 305);
            this.Controls.Add(this.panel1);
            this.Name = "ToolEncrytAnDecryt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ToolBackUpAndReStore";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.Button btn_browser;
        private System.Windows.Forms.Button btn_decrypt;
        private System.Windows.Forms.Button btn_encrypt;
        private System.Windows.Forms.RichTextBox txtDecipheredFile;
        private System.Windows.Forms.RichTextBox txtCiphertextFile;
        private System.Windows.Forms.RichTextBox txtPlaintextFile;
        private System.Windows.Forms.Panel panel1;
    }
}