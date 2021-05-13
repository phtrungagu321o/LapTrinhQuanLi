using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DTO
{
    public class PositionDTO
    {
        public PositionDTO(int id,string namePosition)
        {
            this.ID = id;
            this.NamePosition = namePosition;
        }
        public PositionDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.NamePosition = row["NamePosition"].ToString();
        }
        private int iD;
        private string namePosition;

        public int ID { get => iD; set => iD = value; }
        public string NamePosition { get => namePosition; set => namePosition = value; }
    }
}
