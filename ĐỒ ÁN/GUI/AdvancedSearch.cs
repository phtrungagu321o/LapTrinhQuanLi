using ĐỒ_ÁN.DAO;
using ĐỒ_ÁN.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐỒ_ÁN.GUI
{
    public partial class AdvancedSearch : Form
    {
        public AdvancedSearch()
        {
            InitializeComponent();
           
        }
        List<ConditionsBuild> listConditions = new List<ConditionsBuild>();
       void loadSearchAdvanced(string query)
        {
            this.dgvSearchAdvanced.DataSource = ServiceDAO.Instance.GetlistSearchService(query);
        }
       
        private void btnSearch_Click(object sender, EventArgs e)
         {
            string result = "SELECT s.id,s.name,sc.name as NameCategory,sc.id as idCategory,s.price FROM dbo.Service as s, ServiceCategory as sc where s.idServiceCategory=sc.id";
            string orAnd = cbbOrAnd.Text;
            string field = cbbField.Text;
            string operation = cbbOperator.Text;
            string inputsearching = txtInputSearchString.Text;
            
            foreach (ConditionsBuild item in listConditions)
            {
                
                 result += item.Condition(item.orAnd, item.Field, item.Operator, item.InputSearching);

            }
            MessageBox.Show("" + result);
            loadSearchAdvanced(result);
            btnRemoveCondition.Enabled = false;
        }

        private void AdvancedSearch_Load(object sender, EventArgs e)
        {

            var listQueryBinding = new BindingList<ConditionsBuild>(listConditions);
            this.dgvSearchAdvanced.DataSource = listQueryBinding;
        }

        private void btnAddConditions_Click(object sender, EventArgs e)
        {
           
            string orAnd = cbbOrAnd.Text;
            string field = cbbField.Text;
            string operation = cbbOperator.Text;
            string inputsearching = txtInputSearchString.Text;
            if(field==""||operation==""||inputsearching=="")
            {
                MessageBox.Show("Vui lòng điền vào chỗ còn trống");
                return;
            }    
            ConditionsBuild AddCondition = new ConditionsBuild(orAnd, field, operation, inputsearching);
            listConditions.Add(AddCondition);

            var listQueryBinding = new BindingList<ConditionsBuild>(listConditions);
            this.dgvSearchAdvanced.DataSource = listQueryBinding;

            AdvancedSearch_Load(sender, e);
            btnRemoveCondition.Enabled = true;

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            AdvancedSearch_Load(sender, e);
            if(dgvSearchAdvanced.Rows!=null)
                dgvSearchAdvanced.Rows.Clear();
            btnRemoveCondition.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveCondition_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dgvSearchAdvanced.SelectedCells)
            {
                if (oneCell.Selected)
                    dgvSearchAdvanced.Rows.RemoveAt(oneCell.RowIndex);
            }
        }

        private void btnViewer_Click(object sender, EventArgs e)
        {
            AdvancedSearch_Load(sender, e);
            btnRemoveCondition.Enabled = true;
        }
    }
}
