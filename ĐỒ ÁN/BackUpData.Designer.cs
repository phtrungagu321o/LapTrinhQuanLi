﻿
namespace ĐỒ_ÁN
{
    partial class BackUpAndRestoreData
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
            this.ac = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnBrowse1 = new System.Windows.Forms.Button();
            this.btnbackUp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReStore = new System.Windows.Forms.Button();
            this.btnBrowse2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdBackup = new System.Windows.Forms.RadioButton();
            this.rbRestore = new System.Windows.Forms.RadioButton();
            this.ac.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ac
            // 
            this.ac.Controls.Add(this.btnbackUp);
            this.ac.Controls.Add(this.btnBrowse1);
            this.ac.Controls.Add(this.textBox1);
            this.ac.Controls.Add(this.label1);
            this.ac.Location = new System.Drawing.Point(196, 8);
            this.ac.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ac.Name = "ac";
            this.ac.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ac.Size = new System.Drawing.Size(569, 131);
            this.ac.TabIndex = 0;
            this.ac.TabStop = false;
            this.ac.Text = "Sao lưu dữ liệu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Location:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(198, 56);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 25);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnBrowse1
            // 
            this.btnBrowse1.Location = new System.Drawing.Point(452, 53);
            this.btnBrowse1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowse1.Name = "btnBrowse1";
            this.btnBrowse1.Size = new System.Drawing.Size(112, 30);
            this.btnBrowse1.TabIndex = 2;
            this.btnBrowse1.Text = "Browse";
            this.btnBrowse1.UseVisualStyleBackColor = true;
            this.btnBrowse1.Click += new System.EventHandler(this.btnBrowse1_Click);
            // 
            // btnbackUp
            // 
            this.btnbackUp.Enabled = false;
            this.btnbackUp.Location = new System.Drawing.Point(452, 91);
            this.btnbackUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnbackUp.Name = "btnbackUp";
            this.btnbackUp.Size = new System.Drawing.Size(112, 30);
            this.btnbackUp.TabIndex = 3;
            this.btnbackUp.Text = "Sao Lưu";
            this.btnbackUp.UseVisualStyleBackColor = true;
            this.btnbackUp.Click += new System.EventHandler(this.btnbackUp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReStore);
            this.groupBox1.Controls.Add(this.btnBrowse2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(201, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(569, 131);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Khôi phục dữ liệu";
            // 
            // btnReStore
            // 
            this.btnReStore.Enabled = false;
            this.btnReStore.Location = new System.Drawing.Point(452, 91);
            this.btnReStore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReStore.Name = "btnReStore";
            this.btnReStore.Size = new System.Drawing.Size(112, 30);
            this.btnReStore.TabIndex = 3;
            this.btnReStore.Text = "Khôi phục";
            this.btnReStore.UseVisualStyleBackColor = true;
            this.btnReStore.Click += new System.EventHandler(this.btnReStore_Click);
            // 
            // btnBrowse2
            // 
            this.btnBrowse2.Location = new System.Drawing.Point(452, 53);
            this.btnBrowse2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowse2.Name = "btnBrowse2";
            this.btnBrowse2.Size = new System.Drawing.Size(112, 30);
            this.btnBrowse2.TabIndex = 2;
            this.btnBrowse2.Text = "Browse";
            this.btnBrowse2.UseVisualStyleBackColor = true;
            this.btnBrowse2.Click += new System.EventHandler(this.btnBrowse2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(198, 56);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(228, 25);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Location:";
            // 
            // rdBackup
            // 
            this.rdBackup.AutoSize = true;
            this.rdBackup.Location = new System.Drawing.Point(18, 12);
            this.rdBackup.Name = "rdBackup";
            this.rdBackup.Size = new System.Drawing.Size(123, 21);
            this.rdBackup.TabIndex = 5;
            this.rdBackup.TabStop = true;
            this.rdBackup.Text = "Sao lưu dữ liệu";
            this.rdBackup.UseVisualStyleBackColor = true;
            this.rdBackup.CheckedChanged += new System.EventHandler(this.rdBackup_CheckedChanged_1);
            // 
            // rbRestore
            // 
            this.rbRestore.AutoSize = true;
            this.rbRestore.Location = new System.Drawing.Point(18, 39);
            this.rbRestore.Name = "rbRestore";
            this.rbRestore.Size = new System.Drawing.Size(142, 21);
            this.rbRestore.TabIndex = 6;
            this.rbRestore.TabStop = true;
            this.rbRestore.Text = "Khôi phục dữ liệu";
            this.rbRestore.UseVisualStyleBackColor = true;
            this.rbRestore.CheckedChanged += new System.EventHandler(this.rbRestore_CheckedChanged_1);
            // 
            // BackUpAndRestoreData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 150);
            this.Controls.Add(this.rbRestore);
            this.Controls.Add(this.rdBackup);
            this.Controls.Add(this.ac);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BackUpAndRestoreData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sao lưu và Khôi phục Dữ liệu";
            this.ac.ResumeLayout(false);
            this.ac.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox ac;
        private System.Windows.Forms.Button btnbackUp;
        private System.Windows.Forms.Button btnBrowse1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReStore;
        private System.Windows.Forms.Button btnBrowse2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdBackup;
        private System.Windows.Forms.RadioButton rbRestore;
    }
}