using ĐỒ_ÁN.DAO;
using ĐỒ_ÁN.DTO;
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
    public partial class RoomInfor : Form
    {
        private RoomDTO Room;
        public event EventHandler Dockleft;
        public event EventHandler DockRight;
        public event EventHandler DockFill;
        public event EventHandler Lockking;
       
       
        public RoomInfor(RoomDTO acc)
        {
            InitializeComponent();
            this.Room = acc;
            loadnameRoom();
         
            
        }

        public RoomDTO Room1 { get => Room; set => Room = value; }
       

        void loadnameRoom()
        {
            lblRoomName.Text = Room.Name;
            txtRoomInfo.Text = Room.RoomInfor;
        }

        private void tráiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void phảiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            if (DockRight != null)
                DockRight(sender, e);

        }

        private void tráiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
            if (Dockleft != null)
                Dockleft(sender, e);
        }

        private void trànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            if (DockFill != null)
                DockFill(sender, e);
        }

        private void dockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            if (Lockking != null)
                Lockking(sender, e);
        }
    }
}
