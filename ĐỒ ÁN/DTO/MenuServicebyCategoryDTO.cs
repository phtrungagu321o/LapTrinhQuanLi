using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DTO
{
    public class MenuServicebyCategoryDTO
    {
        public MenuServicebyCategoryDTO(int id, string name,string namecategory,int idcategory  ,float price)
        {
            this.ID = id;
            this.Name = name;
            this.NameCategory = namecategory;
            this.IDCategory = idcategory;
            this.Price = price;
        }
        public MenuServicebyCategoryDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.NameCategory = row["NameCategory"].ToString();
            this.IDCategory = (int)row["idCategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }
        private int iD;
        private string name;
        private string nameCategory;
        private int iDCategory;
        private float price;


        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }

        public float Price { get => price; set => price = value; }
        public string NameCategory { get => nameCategory; set => nameCategory = value; }
        public int IDCategory { get => iDCategory; set => iDCategory = value; }
    }
}
