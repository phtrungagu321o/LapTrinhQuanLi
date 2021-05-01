using ĐỒ_ÁN.DAO;
using ĐỒ_ÁN.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐỒ_ÁN.GUI
{
    public partial class AccountVerification : Form
    {
        private AccountDTO accountverification;

        public AccountDTO Accountverification { get => accountverification; set => accountverification = value; }
        private int testVerification;
        public int TestVerification { get => testVerification; set => testVerification = value; }

       
        public AccountVerification(AccountDTO acc)
        {
           
            InitializeComponent();
            this.accountverification = acc;
        }
        public static string Decrypt(string toDecrypt)
        {
            string key = "ToiTenLaTrung";
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;

            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }

        private void iconButtonVerification_Click(object sender, EventArgs e)
        {
            int test = 1;
            string Pass = txtPassWord.Text;
            string reenter = txtReEnterPass.Text;
            string DecrytPass = Decrypt(accountverification.PassWord1);
            if(txtPassWord.Text==string.Empty|| txtReEnterPass.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu đầy đủ","Thông báo");
            }    
            else
            {
                if(!Pass.Equals(reenter))
                {
                    MessageBox.Show("Mật khẩu xác thực không trùng với mật khẩu","Thông báo");
                }    
                else
                {
                    if (DecrytPass == txtPassWord.Text)
                    {
                        MessageBox.Show("Xác thực thành công", "Thông báo");
                        /*AccountDTO login = AccountDAO.Instance.GetAccountByUserName(accountverification.UserName);
                        MainForm f = new MainForm(login);*/
                        TestVerification = test;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sai Mật khẩu!", "Thông báo");
                        return;
                   }
                }    
            }    
        }
    }
}
