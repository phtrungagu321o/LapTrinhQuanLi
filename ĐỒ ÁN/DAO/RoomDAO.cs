using ĐỒ_ÁN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DAO
{
    public class RoomDAO
    {
        private static RoomDAO instance;

        public static RoomDAO Instance 
        {
            get { if (instance == null) instance = new RoomDAO();return RoomDAO.instance; }
            private set { RoomDAO.instance = value; }

        }
        private RoomDAO() { } 
        public static int RoomWidth = 90;
        public static int RoomHeight = 90;


        public void SwitchRoom(int id1,int id2)
        {
            DataProvider.Instance.ExcuteQuery("USP_SwitchTable @idTable1 , @idTable2",new object[] {id1,id2 });
        }
        public void SwitchOldTimePrice(int id1, int id2)
        {
            DataProvider.Instance.ExcuteQuery("USP_GetListPriceOldTime @IDRoom1 , @IDRoom2 ", new object[] { id1, id2 });
        }
        public List<RoomDTO> LoadRoomList()
        {
            List<RoomDTO> list = new List<RoomDTO>();

            DataTable data = DataProvider.Instance.ExcuteQuery("EXEC dbo.USP_GetRoomList");

            foreach(DataRow item in data.Rows)
            {
                RoomDTO room = new RoomDTO(item);
                list.Add(room);
            }    

            return list;
        }
        public List<RoomDTO> LoadListRoom()
        {
            List<RoomDTO> list = new List<RoomDTO>();

            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT *FROM dbo.Room");

            foreach (DataRow item in data.Rows)
            {
                RoomDTO room = new RoomDTO(item);
                list.Add(room);
            }

            return list;
        }
        public List<RoomDTO> LoadRoomListByID(int id)
        {
            List<RoomDTO> list = new List<RoomDTO>();

            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.Room WHERE id = "+id);

            foreach (DataRow item in data.Rows)
            {
                RoomDTO room = new RoomDTO(item);
                list.Add(room);
            }

            return list;
        }
        public RoomDTO GetRoomBId(int id)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select *from room where id={0}",id));
            foreach (DataRow item in data.Rows)
            {
                return new RoomDTO(item);
            }
            return null;
        }
        public List<RoomDTO> LoadRoomListByIDCategory(int id)
        {
            List<RoomDTO> list = new List<RoomDTO>();

            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.Room WHERE idRoomCategory = " + id);

            foreach (DataRow item in data.Rows)
            {
                RoomDTO room = new RoomDTO(item);
                list.Add(room);
            }

            return list;
        }
        public bool InsertRoom(string name,int id,string roominfor)
        {
            string query = string.Format("INSERT INTO dbo.Room(	name, idRoomCategory,status,RoomInformation)VALUES(   N'{0}', {1},N' Trống',N'{2}')",name,id, roominfor);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateRoom(string name, int id, int idRoom,string roominfor)
        {
            string query = string.Format("UPDATE dbo.Room SET name=N'{0}',idRoomCategory={1},RoomInformation=N'{3}' WHERE id={2}", name, id,idRoom, roominfor);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteRoom(int idRoom)
        {
            
            
                BillDAO.Instance.DeleteBillByidRoom(idRoom);
            
                int result = DataProvider.Instance.ExecuteNonQuery("delete Room where id="+idRoom);
                return result > 0;
            
        }
        public void DeteleRoomByCategory(int id)
        {
            List<RoomDTO> list = RoomDAO.Instance.LoadRoomListByIDCategory(id);
            foreach(RoomDTO item in list)
            {
                BillDAO.Instance.DeleteBillByidRoom(item.ID);
            }    
            DataProvider.Instance.ExcuteQuery("DELETE dbo.Room WHERE idRoomCategory=" +id);
        }
    }
}
