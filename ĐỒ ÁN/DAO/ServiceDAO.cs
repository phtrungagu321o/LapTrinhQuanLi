using ĐỒ_ÁN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DAO
{
    public class ServiceDAO
    {
        private static ServiceDAO instance;

        public static ServiceDAO Instance {
            get { if (instance == null) instance = new ServiceDAO();return ServiceDAO.instance; }
            private set { ServiceDAO.instance = value; }
        }
        private ServiceDAO() { }
        public ServiceDTO GetServiceById(int id)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select *from Service where id={0}", id));
            foreach (DataRow item in data.Rows)
            {
                return new ServiceDTO(item);
            }
            return null;
        }
        public List<ServiceDTO> GetListServiceByCategory(int id)
        {
            List<ServiceDTO> list = new List<ServiceDTO>();
            string query = "SELECT *FROM dbo.Service where idServiceCategory=" + id ;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                ServiceDTO food = new ServiceDTO(item);
                list.Add(food);
            }    
            return list;
        }
        public List<MenuServicebyCategoryDTO> GetlistService()
        {
            List<MenuServicebyCategoryDTO> list = new List<MenuServicebyCategoryDTO>();
            string query = "SELECT s.id,s.name,sc.name as NameCategory,sc.id as idCategory,s.price FROM dbo.Service as s, ServiceCategory as sc where s.idServiceCategory=sc.id ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                MenuServicebyCategoryDTO food = new MenuServicebyCategoryDTO(item);
                list.Add(food);
            }
            return list;
        }
        public List<ServiceDTO> listService()
        {
            List<ServiceDTO> list = new List<ServiceDTO>();
            string query = "SELECT *FROM dbo.Service";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ServiceDTO food = new ServiceDTO(item);
                list.Add(food);
            }
            return list;
        }
        public List<MenuServicebyCategoryDTO> GetlistSearchService(string query)
        {
            List<MenuServicebyCategoryDTO> list = new List<MenuServicebyCategoryDTO>();

            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                MenuServicebyCategoryDTO food = new MenuServicebyCategoryDTO(item);
                list.Add(food);
            }
            return list;
        }
        public List<MenuServicebyCategoryDTO> SearchServiceByName(string name)
        {
            List<MenuServicebyCategoryDTO> list = new List<MenuServicebyCategoryDTO>();
            string query = string.Format("SELECT s.id,s.name,sc.name as NameCategory,sc.id as idCategory,s.price FROM dbo.Service as s, ServiceCategory as sc where s.idServiceCategory=sc.id and dbo.fuConvertToUnsign2(s.name) LIKE N'%' +dbo.fuConvertToUnsign2(N'{0}')+'%'", name) ;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                MenuServicebyCategoryDTO food = new MenuServicebyCategoryDTO(item);
                list.Add(food);
            }
            return list;
        }
        public List<MenuServicebyCategoryDTO> SearchServiceByNameAndCategory(string nameS,string nameSC)
        {
            List<MenuServicebyCategoryDTO> list = new List<MenuServicebyCategoryDTO>();
            string query = string.Format("SELECT s.id,s.name,sc.name as NameCategory,sc.id as idCategory,s.price FROM dbo.Service as s, ServiceCategory as sc where s.idServiceCategory=sc.id and dbo.fuConvertToUnsign2(s.name) LIKE N'%' +dbo.fuConvertToUnsign2(N'{0}')+'%' AND dbo.fuConvertToUnsign2(sc.name) LIKE N'%' +dbo.fuConvertToUnsign2(N'{1}')+'%'", nameS,nameSC);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                MenuServicebyCategoryDTO food = new MenuServicebyCategoryDTO(item);
                list.Add(food);
            }
            return list;
        }

        public List<MenuServicebyCategoryDTO> SearchServiceByCategory(string name)
        {
            List<MenuServicebyCategoryDTO> list = new List<MenuServicebyCategoryDTO>();
            string query = string.Format("SELECT s.id,s.name,sc.name as NameCategory,sc.id as idCategory,s.price FROM dbo.Service as s, ServiceCategory as sc where s.idServiceCategory=sc.id and dbo.fuConvertToUnsign2(sc.name) LIKE N'%' +dbo.fuConvertToUnsign2(N'{0}')+'%'", name);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                MenuServicebyCategoryDTO food = new MenuServicebyCategoryDTO(item);
                list.Add(food);
            }
            return list;
        }

        public bool InsertService(int idcategory, string name, float price)
        {
            string query = string.Format("INSERT dbo.Service(name,idServiceCategory, price)VALUES(   N'{0}', {1}, {2} )",name,idcategory,price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateService(int id,int idcategory, string name, float price)
        {
            string query = string.Format("UPDATE dbo.Service SET name =N'{0}',idServiceCategory={1},price={2} WHERE id={3};", name, idcategory, price,id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteService(int id)
        {
            BillInfoDAO.Instance.DeleteBillInfoByServiceID(id);
            string query = string.Format("Delete Service where id= {0}",id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public void DeleteServiceByCategory(int id)
        {
            List<ServiceDTO> list = ServiceDAO.Instance.GetListServiceByCategory(id);
            foreach(ServiceDTO item in list)
            {
                BillInfoDAO.Instance.DeleteBillInfoByServiceID(item.ID);
            }    
            DataProvider.Instance.ExcuteQuery("delete from service where idServiceCategory= " + id);
        }
    }
}
