using ĐỒ_ÁN.DAO;
using ĐỒ_ÁN.DAO.Z;
using ĐỒ_ÁN.DTO;
using ĐỒ_ÁN.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using log4net;

namespace ĐỒ_ÁN
{
    public partial class login : Form
    {
        ILog log = LogManager.GetLogger(typeof(login));
        public login()
        {
            InitializeComponent();
            waterWark();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        void waterWark()
        {
            txtUser.Text = "Vui lòng nhập Tài Khoản";
            txtUser.ForeColor = Color.LightGray;
            txtUser.Font = new Font(txtUser.Font.Name, txtUser.Font.Size, FontStyle.Italic);

            txtPassWord.Text = "Vui lòng nhập Mật Khẩu";
            txtPassWord.ForeColor = Color.LightGray;
            txtPassWord.Font = new Font(txtPassWord.Font.Name, txtPassWord.Font.Size, FontStyle.Italic);

            txtUser.Leave += new System.EventHandler(this.TxtUser_Leave);
            txtUser.Enter += new System.EventHandler(this.TxtUser_Enter);

            txtPassWord.Leave += new System.EventHandler(this.TxtPassWord_Leave);
            txtPassWord.Enter += new System.EventHandler(this.TxtPassWord_Enter);
        }

        private void TxtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Vui lòng nhập Tài Khoản")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.White;
                txtUser.Font = new Font(txtUser.Font.Name, txtUser.Font.Size, FontStyle.Regular);
            }
        }
        private void TxtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Vui lòng nhập Tài Khoản";
                txtUser.ForeColor = Color.LightGray;
                txtUser.Font = new Font(txtUser.Font.Name, txtUser.Font.Size, FontStyle.Italic);
            }
        }


        private void TxtPassWord_Leave(object sender, EventArgs e)
        {
            if (txtPassWord.Text == "")
            {
                txtPassWord.Text = "Vui lòng nhập Mật Khẩu";
                txtPassWord.ForeColor = Color.LightGray;
                txtPassWord.Font = new Font(txtPassWord.Font.Name, txtPassWord.Font.Size, FontStyle.Italic);
            }
        }
       
        private void TxtPassWord_Enter(object sender, EventArgs e)
        {
            if (txtPassWord.Text == "Vui lòng nhập Mật Khẩu")
            {
                txtPassWord.Text = "";
                txtPassWord.ForeColor = Color.White;
                txtPassWord.Font = new Font(txtPassWord.Font.Name, txtPassWord.Font.Size, FontStyle.Regular);
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
        }
        bool Login(string UserName,string PassWord)
        {
            return AccountDAO.Instance.Login(UserName, PassWord);
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRestoreAndBackup_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUser.Text;
                string passWord = txtPassWord.Text;
                if (Login(userName, passWord))
                {
                    log.Info("Đăng nhập thành công! user: |" + userName +"| - vào ngày:");
                    
                    AccountDTO loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                    progress_bar_Form R = new progress_bar_Form(loginAccount);
                    this.Hide();
                    R.UserN = txtUser.Text;
                    R.ShowDialog();
                    this.Show();

                }
                else
                {
                    var a = new Nudge(this);
                    a.NudgeMe();
                    MessageBox.Show("Sai tên tài khoản hoặc mật khẩu", "Thông báo");

                }
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
      
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult t;
            t = MessageBox.Show("Bạn có muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
                Application.Exit();
        }

        private void iconButtonMini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void iconButtonClose_Click(object sender, EventArgs e)
        {
            DialogResult t;
            t = MessageBox.Show("Bạn có muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
                Application.Exit();
        }

        private void login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void login_Load(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
