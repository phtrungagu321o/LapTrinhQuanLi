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
    public partial class invoicePrintting : Form
    {
        private int iDBill;
        public invoicePrintting()
        {
            InitializeComponent();
        }

        public int IDBill { get => iDBill; set => iDBill = value; }

        private void invoicePrintting_Load(object sender, EventArgs e)
        {
            this.uSP_GetBillInfoByRoomTableAdapter1.Fill(this.quanLiPhongKaraokeDataSet3.USP_GetBillInfoByRoom, IDBill);
            this.reportViewerInvoice.RefreshReport();
        }
    }
}
