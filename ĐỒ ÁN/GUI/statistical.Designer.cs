
namespace ĐỒ_ÁN.GUI
{
    partial class statistical
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dATASETReportService = new ĐỒ_ÁN.DATASETReportService();
            this.uSPGetRoomByDateAndIDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.datasetInfoRoom = new ĐỒ_ÁN.datasetInfoRoom();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.mtpStatisticalMD = new MetroFramework.Controls.MetroTabPage();
            this.reportViewerService = new Microsoft.Reporting.WinForms.ReportViewer();
            this.mtpStatisticalGroup = new MetroFramework.Controls.MetroTabPage();
            this.reportViewerRoom = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbSearchRoom = new MetroFramework.Controls.MetroComboBox();
            this.metroDateTimeToRoom = new MetroFramework.Controls.MetroDateTime();
            this.metroDateTimeFormRoom = new MetroFramework.Controls.MetroDateTime();
            this.btnSearchService = new FontAwesome.Sharp.IconButton();
            this.dataTable1TableAdapter = new ĐỒ_ÁN.DATASETReportServiceTableAdapters.DataTable1TableAdapter();
            this.uSP_GetRoomByDateAndIDTableAdapter = new ĐỒ_ÁN.datasetInfoRoomTableAdapters.USP_GetRoomByDateAndIDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dATASETReportService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetRoomByDateAndIDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datasetInfoRoom)).BeginInit();
            this.metroTabControl1.SuspendLayout();
            this.mtpStatisticalMD.SuspendLayout();
            this.mtpStatisticalGroup.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataTable1BindingSource
            // 
            this.dataTable1BindingSource.DataMember = "DataTable1";
            this.dataTable1BindingSource.DataSource = this.dATASETReportService;
            // 
            // dATASETReportService
            // 
            this.dATASETReportService.DataSetName = "DATASETReportService";
            this.dATASETReportService.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uSPGetRoomByDateAndIDBindingSource
            // 
            this.uSPGetRoomByDateAndIDBindingSource.DataMember = "USP_GetRoomByDateAndID";
            this.uSPGetRoomByDateAndIDBindingSource.DataSource = this.datasetInfoRoom;
            // 
            // datasetInfoRoom
            // 
            this.datasetInfoRoom.DataSetName = "datasetInfoRoom";
            this.datasetInfoRoom.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.mtpStatisticalMD);
            this.metroTabControl1.Controls.Add(this.mtpStatisticalGroup);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(0, 0);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(845, 438);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // mtpStatisticalMD
            // 
            this.mtpStatisticalMD.Controls.Add(this.reportViewerService);
            this.mtpStatisticalMD.HorizontalScrollbarBarColor = true;
            this.mtpStatisticalMD.HorizontalScrollbarHighlightOnWheel = false;
            this.mtpStatisticalMD.HorizontalScrollbarSize = 10;
            this.mtpStatisticalMD.Location = new System.Drawing.Point(4, 38);
            this.mtpStatisticalMD.Name = "mtpStatisticalMD";
            this.mtpStatisticalMD.Size = new System.Drawing.Size(837, 396);
            this.mtpStatisticalMD.TabIndex = 0;
            this.mtpStatisticalMD.Text = "Thống kê 1";
            this.mtpStatisticalMD.VerticalScrollbarBarColor = true;
            this.mtpStatisticalMD.VerticalScrollbarHighlightOnWheel = false;
            this.mtpStatisticalMD.VerticalScrollbarSize = 10;
            // 
            // reportViewerService
            // 
            this.reportViewerService.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetService";
            reportDataSource1.Value = this.dataTable1BindingSource;
            this.reportViewerService.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerService.LocalReport.ReportEmbeddedResource = "ĐỒ_ÁN.Report.ReportService.rdlc";
            this.reportViewerService.Location = new System.Drawing.Point(0, 0);
            this.reportViewerService.Name = "reportViewerService";
            this.reportViewerService.ServerReport.BearerToken = null;
            this.reportViewerService.Size = new System.Drawing.Size(837, 396);
            this.reportViewerService.TabIndex = 2;
            // 
            // mtpStatisticalGroup
            // 
            this.mtpStatisticalGroup.Controls.Add(this.reportViewerRoom);
            this.mtpStatisticalGroup.Controls.Add(this.panel1);
            this.mtpStatisticalGroup.HorizontalScrollbarBarColor = true;
            this.mtpStatisticalGroup.HorizontalScrollbarHighlightOnWheel = false;
            this.mtpStatisticalGroup.HorizontalScrollbarSize = 10;
            this.mtpStatisticalGroup.Location = new System.Drawing.Point(4, 38);
            this.mtpStatisticalGroup.Name = "mtpStatisticalGroup";
            this.mtpStatisticalGroup.Size = new System.Drawing.Size(837, 396);
            this.mtpStatisticalGroup.TabIndex = 1;
            this.mtpStatisticalGroup.Text = "Thống kê 2";
            this.mtpStatisticalGroup.VerticalScrollbarBarColor = true;
            this.mtpStatisticalGroup.VerticalScrollbarHighlightOnWheel = false;
            this.mtpStatisticalGroup.VerticalScrollbarSize = 10;
            // 
            // reportViewerRoom
            // 
            this.reportViewerRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSetInfoRoom";
            reportDataSource2.Value = this.uSPGetRoomByDateAndIDBindingSource;
            this.reportViewerRoom.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewerRoom.LocalReport.ReportEmbeddedResource = "ĐỒ_ÁN.Report.ReportRoomInFo.rdlc";
            this.reportViewerRoom.Location = new System.Drawing.Point(0, 73);
            this.reportViewerRoom.Name = "reportViewerRoom";
            this.reportViewerRoom.ServerReport.BearerToken = null;
            this.reportViewerRoom.Size = new System.Drawing.Size(837, 323);
            this.reportViewerRoom.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbbSearchRoom);
            this.panel1.Controls.Add(this.metroDateTimeToRoom);
            this.panel1.Controls.Add(this.metroDateTimeFormRoom);
            this.panel1.Controls.Add(this.btnSearchService);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 73);
            this.panel1.TabIndex = 3;
            // 
            // cbbSearchRoom
            // 
            this.cbbSearchRoom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbbSearchRoom.FormattingEnabled = true;
            this.cbbSearchRoom.ItemHeight = 23;
            this.cbbSearchRoom.Location = new System.Drawing.Point(322, 21);
            this.cbbSearchRoom.Name = "cbbSearchRoom";
            this.cbbSearchRoom.Size = new System.Drawing.Size(164, 29);
            this.cbbSearchRoom.TabIndex = 5;
            this.cbbSearchRoom.UseSelectable = true;
            // 
            // metroDateTimeToRoom
            // 
            this.metroDateTimeToRoom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.metroDateTimeToRoom.Location = new System.Drawing.Point(616, 21);
            this.metroDateTimeToRoom.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTimeToRoom.Name = "metroDateTimeToRoom";
            this.metroDateTimeToRoom.Size = new System.Drawing.Size(200, 29);
            this.metroDateTimeToRoom.TabIndex = 4;
            // 
            // metroDateTimeFormRoom
            // 
            this.metroDateTimeFormRoom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.metroDateTimeFormRoom.Location = new System.Drawing.Point(28, 21);
            this.metroDateTimeFormRoom.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTimeFormRoom.Name = "metroDateTimeFormRoom";
            this.metroDateTimeFormRoom.Size = new System.Drawing.Size(200, 29);
            this.metroDateTimeFormRoom.TabIndex = 3;
            // 
            // btnSearchService
            // 
            this.btnSearchService.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearchService.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnSearchService.IconColor = System.Drawing.Color.Black;
            this.btnSearchService.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearchService.Location = new System.Drawing.Point(492, 21);
            this.btnSearchService.Name = "btnSearchService";
            this.btnSearchService.Size = new System.Drawing.Size(75, 30);
            this.btnSearchService.TabIndex = 1;
            this.btnSearchService.Text = "Tìm";
            this.btnSearchService.UseVisualStyleBackColor = true;
            this.btnSearchService.Click += new System.EventHandler(this.btnSearchService_Click);
            // 
            // dataTable1TableAdapter
            // 
            this.dataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // uSP_GetRoomByDateAndIDTableAdapter
            // 
            this.uSP_GetRoomByDateAndIDTableAdapter.ClearBeforeFill = true;
            // 
            // statistical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 438);
            this.Controls.Add(this.metroTabControl1);
            this.MinimumSize = new System.Drawing.Size(861, 477);
            this.Name = "statistical";
            this.Text = "statistical";
            this.Load += new System.EventHandler(this.statistical_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dATASETReportService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPGetRoomByDateAndIDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datasetInfoRoom)).EndInit();
            this.metroTabControl1.ResumeLayout(false);
            this.mtpStatisticalMD.ResumeLayout(false);
            this.mtpStatisticalGroup.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage mtpStatisticalMD;
        private MetroFramework.Controls.MetroTabPage mtpStatisticalGroup;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerRoom;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerService;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnSearchService;
        private DATASETReportService dATASETReportService;
        private System.Windows.Forms.BindingSource dataTable1BindingSource;
        private DATASETReportServiceTableAdapters.DataTable1TableAdapter dataTable1TableAdapter;
        private MetroFramework.Controls.MetroComboBox cbbSearchRoom;
        private MetroFramework.Controls.MetroDateTime metroDateTimeToRoom;
        private MetroFramework.Controls.MetroDateTime metroDateTimeFormRoom;
        private System.Windows.Forms.BindingSource uSPGetRoomByDateAndIDBindingSource;
        private datasetInfoRoom datasetInfoRoom;
        private datasetInfoRoomTableAdapters.USP_GetRoomByDateAndIDTableAdapter uSP_GetRoomByDateAndIDTableAdapter;
    }
}