using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN.DTO
{
    public class ConditionsBuildDTO
    {
        public ConditionsBuildDTO(string _orAND, string _Field, string _operator, string _inputsearching)
        {
            this.orAnd = _orAND;
            this.Field = _Field;
            this.Operator = _operator;
            this.InputSearching = _inputsearching;
        }
        public string orAnd { get; set; }
        public string Field { get; set; }
        public string Operator { get; set; }
        public string InputSearching { get; set; }
        public string convertOpertorWithIput { get; set; }
        public string convertFieldWithIput { get; set; }
        public string BuildOneCondition { get; set; }
        public string Condition(string _orAnd,string _Field,string _Operator,string _inputSearching)
        {
            switch(_Operator)
            {
                case "Equal":
                    convertOpertorWithIput = " ='" + _inputSearching + "' ";
                    break;
                case "Contain":
                    convertOpertorWithIput = " LIKE N'%' +dbo.fuConvertToUnsign2(N'" + _inputSearching + "')+'%' ";
                    break;
                case "Not Contain":
                    convertOpertorWithIput = " NOT LIKE N'%' +dbo.fuConvertToUnsign2(N'" + _inputSearching + "')+'%' ";
                    break;
                case "Start With":
                    convertOpertorWithIput = " Like N'" + _inputSearching + "%' ";
                    break;
                default:
                    break;
            }
            //ID dịch vụ
            //tên dịch vụ
            //ID loại dịch vụ
            //tên loại dịch vụ
            //giá dịch vụ
            switch (_Field)
            {
                case "ID dịch vụ":
                    convertFieldWithIput = "s.id";
                    break;
                case "tên dịch vụ":
                    convertFieldWithIput = "dbo.fuConvertToUnsign2(s.name)";
                    break;
                case "ID loại dịch vụ":
                    convertFieldWithIput = "sc.id";
                    break;
                case "tên loại dịch vụ":
                    convertFieldWithIput = "dbo.fuConvertToUnsign2(sc.name)";
                    break;
                case "giá dịch vụ":
                    convertFieldWithIput = "s.price";
                    break;

                default:
                    break;
            }  
            if(_orAnd=="OR")
            
                BuildOneCondition = " " + _orAnd + "(s.idServiceCategory=sc.id AND " + convertFieldWithIput + " " + convertOpertorWithIput + " )";
                
            else
                BuildOneCondition = " " + _orAnd + " " + convertFieldWithIput + " " + convertOpertorWithIput + " ";
            return BuildOneCondition;
        }
       
    }
}
