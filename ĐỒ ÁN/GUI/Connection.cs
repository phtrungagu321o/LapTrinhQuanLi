using ĐỒ_ÁN.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐỒ_ÁN.GUI
{
    public partial class Connection : Form
    {

        public Connection()
        {
            InitializeComponent();
        }
        public static string Encrypt(string toEncrypt)
        {
            string key = "ToiTenLaTrung";

            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

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

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// Giản mã
        /// </summary>
        /// <param name="toDecrypt">Chuỗi đã mã hóa</param>
        /// <returns>Chuỗi giản mã</returns>
       
        private void btnconnection_Click(object sender, EventArgs e)
        {
            string ConnectionStr = "";
           

            string encodestring = Encrypt(txtPassWord.Text);
            if (!ChkBSQL.Checked)
            {
                ConnectionStr = @"Server=" + cbbServer.Text + ";Database=QuanLiPhongKaraoke;Trusted_Connection=True;";
            }
            else
            {
                ConnectionStr = @"Server=" + cbbServer.Text + ";Database=QuanLiPhongKaraoke;User Id=" + txtUsername.Text + ";Password=" + txtPassWord.Text + ";";
            }
            SqlConnection sqlconn = new SqlConnection(ConnectionStr);
            try
            {
                sqlconn.Open();
                sqlconn.Close();
                MessageBox.Show("Kết nối thành công");
                string encodingConnectionString = Encrypt(ConnectionStr);
                ĐỒ_ÁN.Properties.Settings.Default.ServerName = cbbServer.Text;
                ĐỒ_ÁN.Properties.Settings.Default.userName = txtUsername.Text;
                ĐỒ_ÁN.Properties.Settings.Default.Password = encodestring;

                ĐỒ_ÁN.Properties.Settings.Default.ConnectionStr = encodingConnectionString;
               

                ĐỒ_ÁN.Properties.Settings.Default.Save();
               
               

                // ĐỒ_ÁN.Properties.Settings.Default.QuanLiPhongKaraokeConnectionString.Cont = ConnectionStr;
                this.Close();

            }
            catch(Exception)
            {
                MessageBox.Show("Kết nối thất bại");
               
            }
        }
       
        private void Connection_Load(object sender, EventArgs e)
        {
            txtPassWord.Enabled = false;
            txtUsername.Enabled = false;
            /*  SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
              DataTable table = instance.GetDataSources();
              string ServerName = Environment.MachineName;
              foreach (DataRow row in table.Rows)
              {
                  cbbServername.Items.Add(ServerName + "\\" + row["InstanceName"].ToString());
              }*/
            string ServerName = Environment.MachineName;
            cbbServer.Items.Add(ServerName);
        }

        private void ChkBSQL_CheckedChanged(object sender, EventArgs e)
        {
            if(ChkBSQL.Checked)
            {
                txtPassWord.Enabled = true;
                txtUsername.Enabled = true;
            }   
            else
            {
                txtPassWord.Enabled = false;
                txtUsername.Enabled = false;
            }                
         }
    }
}
