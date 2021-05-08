
namespace ĐỒ_ÁN.GUI
{
    partial class invoicePrintting
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
            this.uSPGetBillInfoByRoomBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.quanLiPhongKaraokeDataSet3 = new ĐỒ_ÁN.QuanLiPhongKaraokeDataSet3();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.uSPGetBillInfoByRoomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSP_GetBillInfoByRoomTableAdapter1 = new ĐỒ_ÁN.QuanLiPhongKaraokeDataSet3TableAdapters.USP_GetBillInfoByRoomTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetBillInfoByRoomBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLiPhongKaraokeDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetBillInfoByRoomBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // uSPGetBillInfoByRoomBindingSource1
            // 
            this.uSPGetBillInfoByRoomBindingSource1.DataMember = "USP_GetBillInfoByRoom";
            this.uSPGetBillInfoByRoomBindingSource1.DataSource = this.quanLiPhongKaraokeDataSet3;
            // 
            // quanLiPhongKaraokeDataSet3
            // 
            this.quanLiPhongKaraokeDataSet3.DataSetName = "QuanLiPhongKaraokeDataSet3";
            this.quanLiPhongKaraokeDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetBill";
            reportDataSource1.Value = this.uSPGetBillInfoByRoomBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ĐỒ_ÁN.Report.ReportBillForRoom.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(577, 315);
            this.reportViewer1.TabIndex = 0;
            // 
            // uSPGetBillInfoByRoomBindingSource
            // 
            this.uSPGetBillInfoByRoomBindingSource.DataMember = "USP_GetBillInfoByRoom";
            // 
            // uSP_GetBillInfoByRoomTableAdapter1
            // 
            this.uSP_GetBillInfoByRoomTableAdapter1.ClearBeforeFill = true;
            // 
            // invoicePrintting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 315);
            this.Controls.Add(this.reportViewer1);
            this.Name = "invoicePrintting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In_Hóa_Đơn";
            this.Load += new System.EventHandler(this.invoicePrintting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetBillInfoByRoomBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLiPhongKaraokeDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetBillInfoByRoomBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uSPGetBillInfoByRoomBindingSource;
        private System.Windows.Forms.BindingSource uSPGetBillInfoByRoomBindingSource1;
        private QuanLiPhongKaraokeDataSet3 quanLiPhongKaraokeDataSet3;
        private QuanLiPhongKaraokeDataSet3TableAdapters.USP_GetBillInfoByRoomTableAdapter uSP_GetBillInfoByRoomTableAdapter1;
       
    }
}