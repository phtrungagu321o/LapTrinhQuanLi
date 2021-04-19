
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
            this.uSPGetListBillByDateForReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLiPhongKaraokeDataSet4 = new ĐỒ_ÁN.QuanLiPhongKaraokeDataSet4();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.uSP_GetListBillByDateForReportTableAdapter = new ĐỒ_ÁN.QuanLiPhongKaraokeDataSet4TableAdapters.USP_GetListBillByDateForReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLiPhongKaraokeDataSet4)).BeginInit();
            this.SuspendLayout();
            // 
            // uSPGetListBillByDateForReportBindingSource
            // 
            this.uSPGetListBillByDateForReportBindingSource.DataMember = "USP_GetListBillByDateForReport";
            this.uSPGetListBillByDateForReportBindingSource.DataSource = this.quanLiPhongKaraokeDataSet4;
            // 
            // quanLiPhongKaraokeDataSet4
            // 
            this.quanLiPhongKaraokeDataSet4.DataSetName = "QuanLiPhongKaraokeDataSet4";
            this.quanLiPhongKaraokeDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetB";
            reportDataSource1.Value = this.uSPGetListBillByDateForReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ĐỒ_ÁN.Report.ReportB.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 85);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1083, 353);
            this.reportViewer1.TabIndex = 0;
            // 
            // uSP_GetListBillByDateForReportTableAdapter
            // 
            this.uSP_GetListBillByDateForReportTableAdapter.ClearBeforeFill = true;
            // 
            // ReportB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportB";
            this.Text = "ReportB";
            this.Load += new System.EventHandler(this.ReportB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetListBillByDateForReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLiPhongKaraokeDataSet4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uSPGetListBillByDateForReportBindingSource;
        private QuanLiPhongKaraokeDataSet4 quanLiPhongKaraokeDataSet4;
        private QuanLiPhongKaraokeDataSet4TableAdapters.USP_GetListBillByDateForReportTableAdapter uSP_GetListBillByDateForReportTableAdapter;
    }
}