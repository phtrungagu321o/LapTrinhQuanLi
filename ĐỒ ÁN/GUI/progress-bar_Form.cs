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
    public partial class progress_bar_Form : Form
    {
        public progress_bar_Form()
        {
            InitializeComponent();
            if (PGB.Enabled == true)
            {
                PGB.Enabled = false;
                
                timer1.Start();
            }
            else
            {
                PGB.Enabled = true;
                
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            login frm = new login();    
            PGB.Increment(1);
            lbl_complete.Text = "Connecting to from " + PGB.Value.ToString() + "%";
            if (PGB.Value == PGB.Maximum)
            {
                timer1.Enabled = false;
                this.Hide();
                frm.ShowDialog();
            }
        }
    }
}
