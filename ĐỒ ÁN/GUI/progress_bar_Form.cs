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
    public partial class progress_bar_Form : Form
    {
        private string userN;
        private AccountDTO loginAccount;


        public AccountDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; }

        }

        public string UserN { get => userN; set => userN = value; }

        public progress_bar_Form(AccountDTO acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
            ChangeDisplayName();
        }

        void ChangeDisplayName()
        {

            lblDisPlayName.Text = loginAccount.DisPlayName;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            AccountDTO loginAccount = AccountDAO.Instance.GetAccountByUserName(UserN);
            MainForm frm = new MainForm(loginAccount);
            if (this.Opacity < 1) this.Opacity += 0.05;
            circularProgressBar1.Value += 1;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            if(circularProgressBar1.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
                this.Hide();
                frm.ShowDialog();
            }    
        }

        private void progress_bar_Form_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0;
            timer1.Start();
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if(this.Opacity==0)
            {
                timer2.Stop();
                this.Close();
            }    
        }
    }
}
