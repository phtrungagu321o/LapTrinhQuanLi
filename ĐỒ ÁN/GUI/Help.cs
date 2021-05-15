using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐỒ_ÁN.GUI
{
    public partial class Help : Form
    {
        public Form ChildRoom;
        public Help()
        {
            InitializeComponent();
            
        }

        private void pnMain_Paint(object sender, PaintEventArgs e)
        {

        }
        private void OpenChildForm(Form childRoom)
        {
            if (ChildRoom != null)
            {
                ChildRoom.Close();
            }

            ChildRoom = childRoom;
            childRoom.TopLevel = false;
            childRoom.FormBorderStyle = FormBorderStyle.None;
            childRoom.Dock = DockStyle.Fill;
            pnMain.Controls.Add(childRoom);
            pnMain.Tag = childRoom;
            childRoom.BringToFront();
            childRoom.Show();
            
        }

        private void iconButtonHelpHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildFormHelp.HomeHelp());
        }

        private void iconButtonHelpBackUpAndRestore_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildFormHelp.BackUpAndRestoreHelp());
        }

        private void iconButtonHelpStatictistical_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildFormHelp.StatisticalHelp());
        }

        private void iconButtonHelpAdmin_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildFormHelp.AdminHelp());
        }

        private void iconButtonHelpRoomManager_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildFormHelp.RoomManagerHelp());
        }

        private void iconButtonHelpProFile_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildFormHelp.ProfileHelp());
        }
    }
}
