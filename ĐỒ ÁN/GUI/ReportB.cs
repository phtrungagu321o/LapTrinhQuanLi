using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐỒ_ÁN.GUI
{
    public partial class ReportB : Form
    {
        private DateTime checkIn;
        private DateTime checkOut;
        public ReportB()
        {
            InitializeComponent();
        }

        public DateTime CheckIn { get => checkIn; set => checkIn = value; }
        public DateTime CheckOut { get => checkOut; set => checkOut = value; }

        private void ReportB_Load(object sender, EventArgs e)
        {
            this.uSP_GetListBillByDateForReportTableAdapter.Fill(this.quanLiPhongKaraokeDataSet4.USP_GetListBillByDateForReport,CheckIn,CheckOut);
            this.reportViewer1.RefreshReport();
        }
    }
}
