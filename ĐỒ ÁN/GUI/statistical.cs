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
    public partial class statistical : Form
    {
        public statistical()
        {
            InitializeComponent();
            loadRoom(cbbSearchRoom);
            LoadDateTimePickerBill();
        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            metroDateTimeFormRoom.Value = new DateTime(today.Year, today.Month, 1);
            metroDateTimeToRoom.Value = metroDateTimeFormRoom.Value.AddMonths(1).AddDays(-1);
        }
        void loadRoom(ComboBox cb)
        {
            cb.DataSource = RoomDAO.Instance.LoadListRoom();
            cb.DisplayMember = "name";
        }
        private void statistical_Load(object sender, EventArgs e)
        {
            this.dataTable1TableAdapter.Fill(this.dATASETReportService.DataTable1);

            this.reportViewerService.RefreshReport();
            // TODO: This line of code loads data into the 'dATASETReportService.DataTable1' table. You can move, or remove it, as needed.
            this.uSP_GetRoomByDateAndIDTableAdapter.Fill(this.datasetInfoRoom.USP_GetRoomByDateAndID,metroDateTimeFormRoom.Value,metroDateTimeToRoom.Value,"");
            this.reportViewerRoom.RefreshReport();


        }

        private void btnSearchService_Click(object sender, EventArgs e)
        {
            this.uSP_GetRoomByDateAndIDTableAdapter.Fill(this.datasetInfoRoom.USP_GetRoomByDateAndID, metroDateTimeFormRoom.Value, metroDateTimeToRoom.Value, cbbSearchRoom.Text);
            this.reportViewerRoom.RefreshReport();
        }
    }
}
