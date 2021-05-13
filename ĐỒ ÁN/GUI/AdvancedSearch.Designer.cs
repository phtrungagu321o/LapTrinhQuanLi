
namespace ĐỒ_ÁN.GUI
{
    partial class AdvancedSearch
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
            this.dgvSearchAdvanced = new System.Windows.Forms.DataGridView();
            this.cbbOrAnd = new System.Windows.Forms.ComboBox();
            this.cbbField = new System.Windows.Forms.ComboBox();
            this.cbbOperator = new System.Windows.Forms.ComboBox();
            this.txtInputSearchString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddConditions = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnreset = new System.Windows.Forms.Button();
            this.btnRemoveCondition = new System.Windows.Forms.Button();
            this.btnViewer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchAdvanced)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSearchAdvanced
            // 
            this.dgvSearchAdvanced.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSearchAdvanced.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSearchAdvanced.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchAdvanced.Location = new System.Drawing.Point(42, 53);
            this.dgvSearchAdvanced.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSearchAdvanced.Name = "dgvSearchAdvanced";
            this.dgvSearchAdvanced.Size = new System.Drawing.Size(668, 208);
            this.dgvSearchAdvanced.TabIndex = 0;
            // 
            // cbbOrAnd
            // 
            this.cbbOrAnd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbbOrAnd.Font = new System.Drawing.Font("UTM Neo Sans Intel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbOrAnd.FormattingEnabled = true;
            this.cbbOrAnd.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.cbbOrAnd.Location = new System.Drawing.Point(42, 354);
            this.cbbOrAnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbbOrAnd.Name = "cbbOrAnd";
            this.cbbOrAnd.Size = new System.Drawing.Size(79, 26);
            this.cbbOrAnd.TabIndex = 1;
            this.cbbOrAnd.Text = "AND";
            // 
            // cbbField
            // 
            this.cbbField.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbbField.Font = new System.Drawing.Font("UTM Neo Sans Intel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbField.FormattingEnabled = true;
            this.cbbField.Items.AddRange(new object[] {
            "ID dịch vụ",
            "tên dịch vụ",
            "ID loại dịch vụ",
            "tên loại dịch vụ",
            "giá dịch vụ"});
            this.cbbField.Location = new System.Drawing.Point(128, 354);
            this.cbbField.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbbField.Name = "cbbField";
            this.cbbField.Size = new System.Drawing.Size(175, 26);
            this.cbbField.TabIndex = 2;
            // 
            // cbbOperator
            // 
            this.cbbOperator.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbbOperator.Font = new System.Drawing.Font("UTM Neo Sans Intel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbOperator.FormattingEnabled = true;
            this.cbbOperator.Items.AddRange(new object[] {
            "Equal",
            "Contain",
            "Not Contain",
            "Start With"});
            this.cbbOperator.Location = new System.Drawing.Point(311, 354);
            this.cbbOperator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbbOperator.Name = "cbbOperator";
            this.cbbOperator.Size = new System.Drawing.Size(125, 26);
            this.cbbOperator.TabIndex = 3;
            // 
            // txtInputSearchString
            // 
            this.txtInputSearchString.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtInputSearchString.Font = new System.Drawing.Font("UTM Neo Sans Intel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputSearchString.Location = new System.Drawing.Point(444, 356);
            this.txtInputSearchString.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInputSearchString.Name = "txtInputSearchString";
            this.txtInputSearchString.Size = new System.Drawing.Size(164, 25);
            this.txtInputSearchString.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("UTM Neo Sans Intel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Từ nối";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("UTM Neo Sans Intel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(125, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Trường thuộc tính cần tìm";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("UTM Neo Sans Intel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(308, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Toán tử so sánh";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("UTM Neo Sans Intel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(441, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nhập từ khóa cần tìm";
            // 
            // btnAddConditions
            // 
            this.btnAddConditions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddConditions.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(67)))), ((int)(((byte)(106)))));
            this.btnAddConditions.FlatAppearance.BorderSize = 2;
            this.btnAddConditions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddConditions.Font = new System.Drawing.Font("UTM Neo Sans Intel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddConditions.Location = new System.Drawing.Point(623, 341);
            this.btnAddConditions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddConditions.Name = "btnAddConditions";
            this.btnAddConditions.Size = new System.Drawing.Size(87, 55);
            this.btnAddConditions.TabIndex = 9;
            this.btnAddConditions.Text = "Thêm điều kiện";
            this.btnAddConditions.UseVisualStyleBackColor = true;
            this.btnAddConditions.Click += new System.EventHandler(this.btnAddConditions_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(67)))), ((int)(((byte)(106)))));
            this.btnSearch.FlatAppearance.BorderSize = 2;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("UTM Neo Sans Intel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(264, 419);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(116, 63);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("UTM Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(261, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(218, 31);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tìm kiếm nâng cao";
            // 
            // btnreset
            // 
            this.btnreset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnreset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(67)))), ((int)(((byte)(106)))));
            this.btnreset.FlatAppearance.BorderSize = 2;
            this.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreset.Font = new System.Drawing.Font("UTM Neo Sans Intel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreset.Location = new System.Drawing.Point(623, 468);
            this.btnreset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(87, 55);
            this.btnreset.TabIndex = 12;
            this.btnreset.Text = "Làm mới";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnRemoveCondition
            // 
            this.btnRemoveCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveCondition.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(67)))), ((int)(((byte)(106)))));
            this.btnRemoveCondition.FlatAppearance.BorderSize = 2;
            this.btnRemoveCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveCondition.Font = new System.Drawing.Font("UTM Neo Sans Intel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveCondition.Location = new System.Drawing.Point(623, 277);
            this.btnRemoveCondition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemoveCondition.Name = "btnRemoveCondition";
            this.btnRemoveCondition.Size = new System.Drawing.Size(87, 55);
            this.btnRemoveCondition.TabIndex = 13;
            this.btnRemoveCondition.Text = "Xóa điều kiện";
            this.btnRemoveCondition.UseVisualStyleBackColor = true;
            this.btnRemoveCondition.Click += new System.EventHandler(this.btnRemoveCondition_Click);
            // 
            // btnViewer
            // 
            this.btnViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(67)))), ((int)(((byte)(106)))));
            this.btnViewer.FlatAppearance.BorderSize = 2;
            this.btnViewer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewer.Font = new System.Drawing.Font("UTM Neo Sans Intel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewer.Location = new System.Drawing.Point(623, 404);
            this.btnViewer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewer.Name = "btnViewer";
            this.btnViewer.Size = new System.Drawing.Size(87, 55);
            this.btnViewer.TabIndex = 14;
            this.btnViewer.Text = "Xem Điều kiện";
            this.btnViewer.UseVisualStyleBackColor = true;
            this.btnViewer.Click += new System.EventHandler(this.btnViewer_Click);
            // 
            // AdvancedSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(737, 525);
            this.Controls.Add(this.btnViewer);
            this.Controls.Add(this.btnRemoveCondition);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAddConditions);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInputSearchString);
            this.Controls.Add(this.cbbOperator);
            this.Controls.Add(this.cbbField);
            this.Controls.Add(this.cbbOrAnd);
            this.Controls.Add(this.dgvSearchAdvanced);
            this.Font = new System.Drawing.Font("UTM Neo Sans Intel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(753, 564);
            this.Name = "AdvancedSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdvancedSearch";
            this.Load += new System.EventHandler(this.AdvancedSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchAdvanced)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSearchAdvanced;
        private System.Windows.Forms.ComboBox cbbOrAnd;
        private System.Windows.Forms.ComboBox cbbField;
        private System.Windows.Forms.ComboBox cbbOperator;
        private System.Windows.Forms.TextBox txtInputSearchString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddConditions;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Button btnRemoveCondition;
        private System.Windows.Forms.Button btnViewer;
    }
}