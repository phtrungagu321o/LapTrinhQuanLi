using ĐỒ_ÁN.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DAO
{
    public class ConditionsBuildsDAO
    {
        private static ConditionsBuildsDAO instance;

        public static ConditionsBuildsDAO Instance {
            get { if (instance == null) instance = new ConditionsBuildsDAO();return ConditionsBuildsDAO.instance; }
            private set { ConditionsBuildsDAO.instance = value; }
             }
        private ConditionsBuildsDAO() { }

        public List<ConditionsBuildDTO> LoadString(string orAnd,string Field,string opera,string inputsearching)
        {
            List<ConditionsBuildDTO> list = new List<ConditionsBuildDTO>();
            ConditionsBuildDTO AddConditionnew = new ConditionsBuildDTO(orAnd, Field, opera, inputsearching);
            list.Add(AddConditionnew);
            return list;

        }
    }
}
