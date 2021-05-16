using ĐỒ_ÁN.DTO;
using FontAwesome.Sharp;
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
using ĐỒ_ÁN.DAO;
using ĐỒ_ÁN.GUI;
using System.Globalization;
using log4net;

namespace ĐỒ_ÁN.GUI
{
  
   
    public partial class MainForm : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildRoom;
        private Form currentEditRoom;
        private AccountDTO loginAccount;
        ILog log = LogManager.GetLogger(typeof(MainForm));

        public AccountDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; }

        }

     

        public MainForm(AccountDTO acc)
        {
            InitializeComponent();
            customizeDesigning();
            this.loginAccount = acc;
            ChangeAccount();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            
            
        }
       void ChangeAccount()
        {
            switch(loginAccount.Type)
            {
                case 1:
                     iconButtonAdmin.Enabled = false;
                    break;
                default:
                    break;
            }    
           

            iconButtonProfile.Text += "\n (" + loginAccount.DisPlayName + ")";
        }
     
        //Structs

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
           

        }
        private void ActivateButton(object senderbtn, Color color)
        {
            if(senderbtn !=null)
            {
                DisableButton();
                //button
                currentBtn = (IconButton)senderbtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleCenter;

                //left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0,currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //icon child room current
                iconCurrenChildRoom.IconChar = currentBtn.IconChar;
                iconCurrenChildRoom.IconColor = color;
            }    
        }
        private void ActivateLinkLable(object senderbtn, Color color)
        {
            if (senderbtn != null)
            {
                DisableButton();

                //left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, iconButtonAdmin.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //icon child room current
                iconCurrenChildRoom.IconChar = iconButtonAdmin.IconChar;
                iconCurrenChildRoom.IconColor = color;
            }
        }
        private void ActivateShortCutKeyButton(object senderbtn, Color color)
        {
            if (senderbtn != null)
            {
                DisableButton();
                //button
                currentBtn = (IconButton)senderbtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
               
                
            }
        }
        private void ActivateChildButton(object senderbtn, Color color)
        {
            if (senderbtn != null)
            {
                DisableButton();
                //button
                currentBtn = (IconButton)senderbtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                iconCurrenChildRoom.IconChar = currentBtn.IconChar;
                iconCurrenChildRoom.IconColor = color;
            }
        }
        private void DisableButton()
        {
            if(currentBtn!=null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }    
        }
        private void customizeDesigning()
        {
            panelProfile.Visible = false;
            panelKeyOff.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelProfile.Visible == true)
            {
                panelProfile.Visible = false;
            }
            if (panelKeyOff.Visible == true)
                panelKeyOff.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void OpenChildForm(Form childRoom)
        {
            if (currentChildRoom != null)
            {
                currentChildRoom.Close();
            }

            currentChildRoom = childRoom;
            childRoom.TopLevel = false;
            childRoom.FormBorderStyle = FormBorderStyle.None;
            childRoom.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childRoom);
            panelDesktop.Tag = childRoom;
            childRoom.BringToFront();
            childRoom.Show();
            lblChildRoom.Text = childRoom.Text;
        }
        private void OpenInfroFormleft(Form childRoom)
        {
            if (currentEditRoom != null)
                currentEditRoom.Close();

            currentEditRoom = childRoom;
            childRoom.TopLevel = false;
            childRoom.FormBorderStyle = FormBorderStyle.None;
            childRoom.Dock = DockStyle.Left;
            panelDesktop.Controls.Add(childRoom);
            
            childRoom.BringToFront();
            childRoom.Show();
            
        }
        private void OpenEditFormRight(Form childRoom)
        {
            if (currentEditRoom != null)
                currentEditRoom.Close();

            currentEditRoom = childRoom;
            childRoom.TopLevel = false;
            childRoom.FormBorderStyle = FormBorderStyle.None;
            childRoom.Dock = DockStyle.Right;
            panelDesktop.Controls.Add(childRoom);

            childRoom.BringToFront();
            childRoom.Show();

        }
        private void OpenEditFormfill(Form childRoom)
        {
            if (currentEditRoom != null)
                currentEditRoom.Close();

            currentEditRoom = childRoom;
            childRoom.TopLevel = false;
            childRoom.FormBorderStyle = FormBorderStyle.None;
            childRoom.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childRoom);

            childRoom.BringToFront();
            childRoom.Show();

        }

        private void iconButtonAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                hideSubMenu();
                ActivateButton(sender, RGBColors.color1);
                AccountDTO login = AccountDAO.Instance.GetAccountByUserName(loginAccount.UserName);
                Admin a = new Admin(login);
                log.Info("User: |" + loginAccount.UserName + "| đã xem dữ liệu vào ngày: ");
                OpenChildForm(a);
                a.LoginAccount = loginAccount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void iconButtonRoomManager_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ActivateButton(sender, RGBColors.color2);
            AccountDTO login = AccountDAO.Instance.GetAccountByUserName(loginAccount.UserName);
            RoomManager f = new RoomManager(login);
            OpenChildForm(f);
        }

        

        private void iconButtonProfile_Click(object sender, EventArgs e)
        {
            if (currentChildRoom != null)
            { currentChildRoom.Close();
                reset(); 

                    }
            showSubMenu(panelProfile);
            lblChildRoom.Text = iconButtonProfile.Text;
            ActivateButton(sender, RGBColors.color3);
            
        }

        private void iconButtonEditProFile_Click(object sender, EventArgs e)
        {
            
            ActivateChildButton(sender, RGBColors.color4);
            AccountDTO login = AccountDAO.Instance.GetAccountByUserName(loginAccount.UserName);
            AccountProfile f = new AccountProfile(login);
            f.UpdateAccount += F_UpdateAccount;
            OpenChildForm(f);
            

            
        }

        private void F_UpdateAccount(object sender, AccountEvent e)
        {
            iconButtonProfile.Text = "Thông tin tài khoản \n (" + e.Acc.DisPlayName + ")";

        }

        private void iconButtonExit_Click(object sender, EventArgs e)
        {
            try
            {
                hideSubMenu();
                if (currentChildRoom != null)
                {
                    currentChildRoom.Close();
                    reset();
                }
                DialogResult t;
                t = MessageBox.Show("Bạn có muốn đăng xuất không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (t == DialogResult.Yes)
                {
                    log.Info("Đăng Xuất thành công! user: |" + loginAccount.UserName + "| - vào ngày:");
                    this.Close();
                }
            }
            catch ( Exception ex)
            {
                log.Error(ex.Message);
            }

        }

        private void iconButtonKeyOff_Click(object sender, EventArgs e)
        {
            
            showSubMenu(panelKeyOff);
            ActivateShortCutKeyButton(sender, RGBColors.color5);
            
        }

        private void iconButton11_Click(object sender, EventArgs e)
        {
            
            hideSubMenu();
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
           
            
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new Help());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildRoom != null)
            {
                currentChildRoom.Close();
                reset();
            }
        }

        private void reset()
        {
            hideSubMenu();
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrenChildRoom.IconChar = IconChar.Home;
            iconCurrenChildRoom.IconColor = Color.MediumPurple;
            lblChildRoom.Text = "Home";
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd,int wMsg,int wParam,int lParam); 

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            DialogResult t;
            t = MessageBox.Show("Bạn có muốn thoát chương trình không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
                this.Close();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if(WindowState==FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labeltime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void linkLabelFaceBooK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/phung.mcdoin.988");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
                if (loginAccount.Type == 1)
                {
                    MessageBox.Show("Admin mới có thể sử dụng quyền hạn này!", "Thông báo");
                        return;
                }
               
                    ActivateLinkLable(sender, RGBColors.color1);
                    hideSubMenu();
                    AccountDTO account = AccountDAO.Instance.GetAccountByUserName(loginAccount.UserName);
                    AccountVerification f = new AccountVerification(account);
                    f.ShowDialog();

                if (f.TestVerification == 1)
                {
                    AccountDTO login = AccountDAO.Instance.GetAccountByUserName(loginAccount.UserName);
                    BackUpAndRestoreData fB = new BackUpAndRestoreData(login);
                    OpenChildForm(fB);
                }
                    
                
         
            
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(btnPhone.Text);
            MessageBox.Show("Đã copy nội dung thành công", "Thông báo");
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(btnEmail.Text);
            MessageBox.Show("Đã copy nội dung thành công", "Thông báo");
        }

        private void btnHome_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void fillToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void traiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void phaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
        }

        private void tráiToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            statistical f = new statistical();
            f.ShowDialog();
        }
    }
}
