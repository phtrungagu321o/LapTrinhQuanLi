using ĐỒ_ÁN.DAO;
using ĐỒ_ÁN.DAO.Z;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐỒ_ÁN
{
    public partial class TestLogin : Form
    {
        public TestLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUser.Text;
            string passWord = txtPassWord.Text;
            if (Login(userName, passWord))
            {


                BackUpAndRestoreData f = new BackUpAndRestoreData();
                this.Hide();
                f.ShowDialog();
                
            }
            else
            {
                var a = new Nudge(this);
                a.NudgeMe();
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu", "Thông báo");

            }
        }
        bool Login(string UserName, string PassWord)
        {
            return AccountDAO.Instance.Login(UserName, PassWord);
        }
    }
}
