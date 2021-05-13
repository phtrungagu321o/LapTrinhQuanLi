using ĐỒ_ÁN.DAO;
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
            LoadCBB(cbbSearchService);
        }

        public DateTime CheckIn { get => checkIn; set => checkIn = value; }
        public DateTime CheckOut { get => checkOut; set => checkOut = value; }
        void LoadCBB(ComboBox cb)
        {
            cb.DataSource = ServiceDAO.Instance.GetlistService();
            cb.DisplayMember = "name";
        }
       
        private void ReportB_Load(object sender, EventArgs e)
        {
           
            this.uSP_GetListBillByDateForReportTableAdapter1.Fill(this.dBSearchForCBB.USP_GetListBillByDateForReport,CheckIn,CheckOut," ");
            this.reportViewerBill.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.uSP_GetListBillByDateForReportTableAdapter1.Fill(this.dBSearchForCBB.USP_GetListBillByDateForReport, CheckIn, CheckOut, cbbSearchService.Text);
            this.reportViewerBill.RefreshReport();
        }
    }
}
