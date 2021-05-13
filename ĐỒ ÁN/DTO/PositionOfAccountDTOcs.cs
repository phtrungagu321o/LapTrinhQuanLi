using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DTO
{
    public class PositionOfAccountDTOcs
    {
        public PositionOfAccountDTOcs(string username, string displayname, int type,string namePosition ,string password = null)
        {
            this.UserName = username;
            this.DisPlayName = displayname;
            this.Type = type;
            this.NamePosition = namePosition;
            this.PassWord1 = password;

        }
        public PositionOfAccountDTOcs(DataRow row)
        {
            this.UserName = row["UserName"].ToString();
            this.DisPlayName = row["Displayname"].ToString();
            this.Type = (int)row["type"];
            this.NamePosition = row["NamePosition"].ToString();
            this.PassWord1 = row["PassWord"].ToString();

        }
        private string userName;
        private string disPlayName;
        private string PassWord;
        private int type;
        private string namePosition;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string DisPlayName
        {
            get { return disPlayName; }
            set { disPlayName = value; }
        }
        public string PassWord1
        {
            get { return PassWord; }
            set { PassWord = value; }
        }
        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public string NamePosition { get => namePosition; set => namePosition = value; }
    }
}
