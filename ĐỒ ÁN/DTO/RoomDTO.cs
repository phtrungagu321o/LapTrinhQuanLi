﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DTO
{
    public class RoomDTO
    {
        public RoomDTO(int id,string name,int idroomcategory,string status,string roominfor)
        {
            this.ID = id;
            this.Name = name;
            this.IDRoomCategory = idroomcategory;
            this.Status = status;
            this.RoomInfor = roominfor;
        }
        public RoomDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.IDRoomCategory = (int)row["idRoomCategory"];
            this.Status = row["status"].ToString();
            this.RoomInfor = row["RoomInformation"].ToString();
        }
        private int iD;
        private string name;
        private int iDRoomCategory;
        private string status;
        private string roomInfor;
        public string Name { get => name; set => name = value; }
        public int IDRoomCategory { get => iDRoomCategory; set => iDRoomCategory = value; }
        public int ID { get => iD; set => iD = value; }
        public string Status { get => status; set => status = value; }
        public string RoomInfor { get => roomInfor; set => roomInfor = value; }
    }
}
