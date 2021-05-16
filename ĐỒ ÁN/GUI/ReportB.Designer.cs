
namespace ĐỒ_ÁN.GUI
{
    partial class ReportB
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.uSPGetListBillByDateForReportBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.dBSearchForCBB = new ĐỒ_ÁN.DBSearchForCBB();
            this.uSPGetListBillByDateForReportBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetB = new ĐỒ_ÁN.dataSetB();
            this.uSPGetListBillByDateForReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBSearchForCBBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewerBill = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.cbbSearchService = new System.Windows.Forms.ComboBox();
            this.uSPGetListBillByDateForReportBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dBSearchForCBBBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.uSP_GetListBillByDateForReportTableAdapter1 = new ĐỒ_ÁN.DBSearchForCBBTableAdapters.USP_GetListBillByDateForReportTableAdapter();
            this.uSP_GetListBillByDateForReportTableAdapter = new ĐỒ_ÁN.dataSetBTableAdapters.USP_GetListBillByDateForReportTableAdapter();
            this.uSPGetListBillByDateForReportBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBSearchForCBB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBSearchForCBBBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBSearchForCBBBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // uSPGetListBillByDateForReportBindingSource4
            // 
            this.uSPGetListBillByDateForReportBindingSource4.DataMember = "USP_GetListBillByDateForReport";
            this.uSPGetListBillByDateForReportBindingSource4.DataSource = this.dBSearchForCBB;
            // 
            // dBSearchForCBB
            // 
            this.dBSearchForCBB.DataSetName = "DBSearchForCBB";
            this.dBSearchForCBB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uSPGetListBillByDateForReportBindingSource1
            // 
            this.uSPGetListBillByDateForReportBindingSource1.DataMember = "USP_GetListBillByDateForReport";
            this.uSPGetListBillByDateForReportBindingSource1.DataSource = this.dataSetB;
            // 
            // dataSetB
            // 
            this.dataSetB.DataSetName = "dataSetB";
            this.dataSetB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uSPGetListBillByDateForReportBindingSource
            // 
            this.uSPGetListBillByDateForReportBindingSource.DataMember = "USP_GetListBillByDateForReport";
            this.uSPGetListBillByDateForReportBindingSource.DataSource = this.dBSearchForCBBBindingSource;
            // 
            // dBSearchForCBBBindingSource
            // 
            this.dBSearchForCBBBindingSource.DataSource = this.dBSearchForCBB;
            this.dBSearchForCBBBindingSource.Position = 0;
            // 
            // reportViewerBill
            // 
            this.reportViewerBill.AutoSize = true;
            this.reportViewerBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerBill.Font = new System.Drawing.Font("UTM Neo Sans Intel", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            reportDataSource1.Name = "DataSetB";
            reportDataSource1.Value = this.uSPGetListBillByDateForReportBindingSource4;
            this.reportViewerBill.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerBill.LocalReport.ReportEmbeddedResource = "ĐỒ_ÁN.Report.ReportB.rdlc";
            this.reportViewerBill.Location = new System.Drawing.Point(0, 100);
            this.reportViewerBill.Name = "reportViewerBill";
            this.reportViewerBill.ServerReport.BearerToken = null;
            this.reportViewerBill.Size = new System.Drawing.Size(829, 293);
            this.reportViewerBill.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cbbSearchService);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(829, 100);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Font = new System.Drawing.Font("UTM Neo Sans Intel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(477, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Tìm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbbSearchService
            // 
            this.cbbSearchService.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbbSearchService.Font = new System.Drawing.Font("UTM Neo Sans Intel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSearchService.FormattingEnabled = true;
            this.cbbSearchService.Location = new System.Drawing.Point(296, 37);
            this.cbbSearchService.Name = "cbbSearchService";
            this.cbbSearchService.Size = new System.Drawing.Size(175, 26);
            this.cbbSearchService.TabIndex = 0;
            // 
            // uSP_GetListBillByDateForReportTableAdapter1
            // 
            this.uSP_GetListBillByDateForReportTableAdapter1.ClearBeforeFill = true;
            // 
            // uSP_GetListBillByDateForReportTableAdapter
            // 
            this.uSP_GetListBillByDateForReportTableAdapter.ClearBeforeFill = true;
            // 
            // uSPGetListBillByDateForReportBindingSource3
            // 
            this.uSPGetListBillByDateForReportBindingSource3.DataMember = "USP_GetListBillByDateForReport";
            this.uSPGetListBillByDateForReportBindingSource3.DataSource = this.dBSearchForCBB;
            // 
            // ReportB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 393);
            this.Controls.Add(this.reportViewerBill);
            this.Controls.Add(this.panel1);
            this.Name = "ReportB";
            this.Text = "ReportB";
            this.Load += new System.EventHandler(this.ReportB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBSearchForCBB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBSearchForCBBBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBSearchForCBBBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerBill;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbbSearchService;
        private DBSearchForCBBTableAdapters.USP_GetListBillByDateForReportTableAdapter uSP_GetListBillByDateForReportTableAdapter1;
        private System.Windows.Forms.BindingSource uSPGetListBillByDateForReportBindingSource2;
        private System.Windows.Forms.BindingSource dBSearchForCBBBindingSource1;
        private System.Windows.Forms.BindingSource uSPGetListBillByDateForReportBindingSource;
        private System.Windows.Forms.BindingSource dBSearchForCBBBindingSource;
        private DBSearchForCBB dBSearchForCBB;
        private System.Windows.Forms.BindingSource uSPGetListBillByDateForReportBindingSource1;
        private dataSetB dataSetB;
        private dataSetBTableAdapters.USP_GetListBillByDateForReportTableAdapter uSP_GetListBillByDateForReportTableAdapter;
        private System.Windows.Forms.BindingSource uSPGetListBillByDateForReportBindingSource3;
        private System.Windows.Forms.BindingSource uSPGetListBillByDateForReportBindingSource4;
    }
}