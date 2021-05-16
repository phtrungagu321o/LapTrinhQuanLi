using ĐỒ_ÁN.DTO;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐỒ_ÁN
{
    public partial class BackUpAndRestoreData : Form
    {
        private AccountDTO LoginAccount;
        ILog log = LogManager.GetLogger(typeof(BackUpAndRestoreData));
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
        SqlConnection con = new SqlConnection(Decrypt(ĐỒ_ÁN.Properties.Settings.Default.ConnectionStr));
        public BackUpAndRestoreData(AccountDTO acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            rdBackup.Checked = true;
            if (rdBackup.Checked == true)
            {
                ac.Visible = true;
                groupBox1.Visible = false;
            }
            if (rbRestore.Checked == true)
            {
                ac.Visible = false;
                groupBox1.Visible = true;
            }
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtBackup.Text = dlg.SelectedPath;

            }
        }

        private void btnbackUp_Click(object sender, EventArgs e)
        {
            DialogResult t;
            t = MessageBox.Show("Bạn có thực sự muốn sao lưu dữ liệu hiện tại?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                string database = con.Database.ToString();
                try
                {
                    if (txtBackup.Text == string.Empty)
                    {
                        MessageBox.Show("Vui lòng điền vị trí của file backup!!");
                    }
                    else
                    {
                        string cmd = "BACKUP DATABASE [" + database + "] TO DISK='" + txtBackup.Text + "\\" + "database_được_lưu_vào _ngày_giờ " + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".bak'";

                        using (SqlCommand command = new SqlCommand(cmd, con))
                        {
                            if (con.State != ConnectionState.Open)
                            {
                                con.Open();
                            }
                            command.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Dữ liệu của bạn đã được sao lưu thành công");
                            log.Info("Đã sao lưu dữ liệu thành công! User: |" + LoginAccount.UserName + "| - vào ngày: ");
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER database backup files|*.bak";
            dlg.Title = "Database restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtRestore.Text = dlg.FileName;

            }
        }

        private void btnReStore_Click(object sender, EventArgs e)
        {
            DialogResult t;
            t = MessageBox.Show("Bạn có thực sự muốn khôi phục dữ liệu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                string database = con.Database.ToString();
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                try
                {
                    string sqlStmt2 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand bu2 = new SqlCommand(sqlStmt2, con);
                    bu2.ExecuteNonQuery();

                    string sqlStmt3 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + txtRestore.Text + "'WITH REPLACE;";
                    SqlCommand bu3 = new SqlCommand(sqlStmt3, con);
                    bu3.ExecuteNonQuery();

                    string sqlStmt4 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
                    SqlCommand bu4 = new SqlCommand(sqlStmt4, con);
                    bu4.ExecuteNonQuery();

                    MessageBox.Show("Dữ liệu của bạn đã được khôi phục thành công");
                    log.Info("Đã khôi phục dữ liệu thành công! User: |" + LoginAccount.UserName + "| - vào ngày: ");
                    con.Close();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtBackup.Text == "")
                btnbackUp.Enabled = false;
            else
                btnbackUp.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (txtRestore.Text == "")
                btnReStore.Enabled = false;
            else
                btnReStore.Enabled = true;
        }

       

        private void rdBackup_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdBackup.Checked == true)
            {
                ac.Visible = true;
                groupBox1.Visible = false;
            }
            if (rbRestore.Checked == true)
            {
                ac.Visible = false;
                groupBox1.Visible = true;
            }
        }

        private void rbRestore_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdBackup.Checked == true)
            {
                ac.Visible = true;
                groupBox1.Visible = false;
            }
            if (rbRestore.Checked == true)
            {
                ac.Visible = false;
                groupBox1.Visible = true;
            }
        }
    }
}
