using ĐỒ_ÁN.DAO;
using ĐỒ_ÁN.DTO;
using ĐỒ_ÁN.GUI;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐỒ_ÁN
{
    public partial class Admin : Form
    {
        ILog log = LogManager.GetLogger(typeof(Admin));
        BindingSource Servicelist = new BindingSource();
        BindingSource RoomList = new BindingSource();
        BindingSource ServiceCategoryList = new BindingSource();
        BindingSource RoomCategoryList = new BindingSource();
        BindingSource AccountList = new BindingSource();
        private AccountDTO loginAccount;

        public AccountDTO LoginAccount { get => loginAccount; set => loginAccount = value; }

        public Admin(AccountDTO acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
            dgvService.DataSource = Servicelist;
            dgvRoom.DataSource = RoomList;
            dgvServiceCategory.DataSource = ServiceCategoryList;
            dgvRoomCategory.DataSource = RoomCategoryList;
            dgvAccount.DataSource = AccountList;
          
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            customizeDesigning();
            LoadLitsBillByDate(dtpFromTime.Value, dtpToTime.Value);
            loadlist();
            AddBinding();
            LoadServiceCategory();
            LoadCategory();

            LoadWaterMark();

            


        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        void LoadWaterMark()
        {
            txtSearchServiceName.ForeColor = Color.LightGray;
            txtSearchServiceName.Text = "Vui lòng nhập tên dịch vụ cần tìm";
            txtSearchServiceName.Font = new Font(txtSearchServiceName.Font.Name, txtSearchServiceName.Font.Size, FontStyle.Italic);
            this.txtSearchServiceName.Leave += new System.EventHandler(this.TxtSearchServiceName_Leave);
            this.txtSearchServiceName.Enter += new System.EventHandler(this.TxtSearchServiceName_Enter);
        }

        private void TxtSearchServiceName_Enter(object sender, EventArgs e)
        {
            if (txtSearchServiceName.Text == "Vui lòng nhập tên dịch vụ cần tìm")
            {
                txtSearchServiceName.Text = "";
                txtSearchServiceName.ForeColor = Color.Gainsboro;
                txtSearchServiceName.Font = new Font(txtSearchServiceName.Font.Name, txtSearchServiceName.Font.Size, FontStyle.Bold);
            }
        }

        private void TxtSearchServiceName_Leave(object sender, EventArgs e)
        {
            if(txtSearchServiceName.Text=="")
            {
                txtSearchServiceName.Text = "Vui lòng nhập tên dịch vụ cần tìm";
                txtSearchServiceName.ForeColor = Color.Gray;
                txtSearchServiceName.Font = new Font(txtSearchServiceName.Font.Name, txtSearchServiceName.Font.Size, FontStyle.Italic);
            }    
        }

        void loadlist()
        {
            LoadLitsBillByDate(dtpFromTime.Value, dtpToTime.Value);
            LoadDateTimePickerBill();
            LoadListService();
            LoadListRoom();
            loadListServiceCategory();
            LoadListsRoomCategory();
            LoadListAccount();
        }
        void AddBinding()
        {
            AddServiceBinding();
            AddRoomBinding();
            AddServiceCategoryBinding();
            AddRoomSeviceBinding();
            AddAccountBinding();
        }
        void LoadCategory()
        {
            LoadCategoryIntoComboBox(cbbServiceCategory);
            loadRoomcategoryIntoCBB(cbbRoomcategory);
            LoadCategoryIntoComboBox(cbbSearchServiceCategory);
            loadPositionIntoCBB(cbbPosition);



        }

        List<MenuServicebyCategoryDTO> SearchNameService(string name)
        {
            List<MenuServicebyCategoryDTO> listService = ServiceDAO.Instance.SearchServiceByName(name);

         
            return listService;

        }
        List<MenuServicebyCategoryDTO> SearchNameServiceBycategory(string name)
        {
            List<MenuServicebyCategoryDTO> listService = ServiceDAO.Instance.SearchServiceByCategory(name);


            return listService;

        }
        List<MenuServicebyCategoryDTO> SearchNameServiceBycategoryAndName(string nameS,string nameSC)
        {
            List<MenuServicebyCategoryDTO> listService = ServiceDAO.Instance.SearchServiceByNameAndCategory(nameS, nameSC);


            return listService;

        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpFromTime.Value = new DateTime(today.Year, today.Month, 1);
            dtpToTime.Value = dtpFromTime.Value.AddMonths(1).AddDays(-1);
        }
        void LoadLitsBillByDate(DateTime checkIn, DateTime checkOut)
        {

            dgvBill.DataSource = BillDAO.Instance.GetBillListByDateTime(checkIn, checkOut);
        }
        void LoadListService()
        {
             
            Servicelist.DataSource = ServiceDAO.Instance.GetlistService();
        }
        void LoadListRoom()
        {
            RoomList.DataSource = RoomDAO.Instance.LoadListRoom();
        }
        void loadListServiceCategory()
        {
            ServiceCategoryList.DataSource = ServiceCategoryDAO.Instance.GetListCategory();
        }
        void LoadListsRoomCategory()
        {
            RoomCategoryList.DataSource = RoomCategoryDAO.Instance.ListRoomCategory();
        }
        void LoadListAccount()
        {
           
                AccountList.DataSource = AccountDAO.Instance.GetlistAccount();
            
        }
        void loadSearchAdvanced(string query)
        {
            Servicelist.DataSource = ServiceDAO.Instance.GetlistSearchService(query);
        }
        void AddAccountBinding()
        {
            txtAccountUser.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txtAccountDislayName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "DisPlayName", true, DataSourceUpdateMode.Never));
            nmrAccountType.DataBindings.Add(new Binding("Value", dgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }
        void AddServiceBinding()

        {
            txtServiceName.DataBindings.Add(new Binding("Text", dgvService.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtServiceID.DataBindings.Add(new Binding("Text", dgvService.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nudPrice.DataBindings.Add(new Binding("Value", dgvService.DataSource, "price", true, DataSourceUpdateMode.Never));
        }
        void AddRoomBinding()
        {
            txtRoomID.DataBindings.Add(new Binding("Text", dgvRoom.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtRoomName.DataBindings.Add(new Binding("Text", dgvRoom.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtRoominfo.DataBindings.Add(new Binding("Text", dgvRoom.DataSource, "RoomInfor", true, DataSourceUpdateMode.Never));
        }
        void AddServiceCategoryBinding()
        {
            txtIDServiceCategory.DataBindings.Add(new Binding("Text", dgvServiceCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtNameServiceCategory.DataBindings.Add(new Binding("Text", dgvServiceCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }
        void AddRoomSeviceBinding()
        {
            txtIDRoomCategory.DataBindings.Add(new Binding("Text", dgvRoomCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtNameRoomCategory.DataBindings.Add(new Binding("Text", dgvRoomCategory.DataSource, "NameRoomCategory", true, DataSourceUpdateMode.Never));
            nudTime.DataBindings.Add(new Binding("value", dgvRoomCategory.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        void LoadCategoryIntoComboBox(ComboBox cb)
        {
            cb.DataSource = ServiceCategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "name";
        }
        void loadRoomcategoryIntoCBB(ComboBox cb)
        {
            cb.DataSource = RoomCategoryDAO.Instance.ListRoomCategory();
            cb.DisplayMember = "NameRoomCategory";
        }
        void loadPositionIntoCBB(ComboBox cb)
        {
            cb.DataSource = AccountDAO.Instance.GetListPosition();
            cb.DisplayMember = "NamePosition";
        }
        void LoadServiceCategory()
        {
            List<ServiceCategoryDTO> listCategory = ServiceCategoryDAO.Instance.GetListCategory();
            cbbSearchSC.DataSource = listCategory;
            cbbSearchSC.DisplayMember = "name";
        }
        void LoadServiceListByCategoryID(int id)
        {
            List<ServiceDTO> listFood = ServiceDAO.Instance.GetListServiceByCategory(id);
            cbbSearchS.DataSource = listFood;
            cbbSearchS.DisplayMember = "name";
        }


        private void tp_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtFoodName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadLitsBillByDate(dtpFromTime.Value, dtpToTime.Value);
        }

        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListService();
        }

        private void txtServiceID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvService.SelectedCells.Count > 0 && dgvService.SelectedCells[0].OwningRow.Cells["idCategory"].Value!=null)
                {
                    int id = (int)dgvService.SelectedCells[0].OwningRow.Cells["idCategory"].Value;//chọn ô đầu tiên trong danh sach category sau đó lấy cái dòng chưa ô đã chọn


                    ServiceCategoryDTO Servicecategory = ServiceCategoryDAO.Instance.GetCategory(id);
                    cbbServiceCategory.SelectedItem = Servicecategory;
                    int index = -1;
                    int i = 0;
                    foreach (ServiceCategoryDTO item in cbbServiceCategory.Items)
                    {
                        if (item.ID == Servicecategory.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbbServiceCategory.SelectedIndex = index;
                }

            }
            catch {
                
            }

        }
        private void txtRoomID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvRoom.SelectedCells.Count > 0)
                {
                    int id = (int)dgvRoom.SelectedCells[0].OwningRow.Cells["idRoomCategory"].Value;

                    RoomCategoryDTO Roomcategory = RoomCategoryDAO.Instance.GetRoomCategoryByID(id);
                    cbbRoomcategory.SelectedItem = Roomcategory;
                    int index = -1;
                    int i = 0;
                    foreach (RoomCategoryDTO item in cbbRoomcategory.Items)
                    {
                        if (item.ID == Roomcategory.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbbRoomcategory.SelectedIndex = index;

                }
            }
            catch { }
        }
        private void btnAddServiceCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (loginAccount.Type == 3)
                {
                    MessageBox.Show("Bạn không có quyền thay đổi dữ liệu!", "Thông báo");
                    return;
                }
                string name = txtNameServiceCategory.Text;
                DialogResult t;
                t = MessageBox.Show(string.Format("Bạn có muốn Thêm Loại {0} không ?", name), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (t == DialogResult.Yes)
                {
                    List<ServiceCategoryDTO> list = ServiceCategoryDAO.Instance.GetListCategory();
                    foreach (ServiceCategoryDTO item in list)
                    {
                        if (name == item.Name)
                        {
                            MessageBox.Show(" Loại Dịch vụ đã có trong danh sách");
                            return;
                        }
                    }
                    if (ServiceCategoryDAO.Instance.InsertServiceCategory(name))
                    {
                        MessageBox.Show("Thêm danh mục dịch vụ thành công");
                        loadListServiceCategory();
                        LoadListService();
                        LoadCategoryIntoComboBox(cbbServiceCategory);
                        if (insertServiceCategory != null)
                            insertServiceCategory(this, new EventArgs());
                        log.Info("Đã Thêm thông tin tên loại dịch vụ: |" + name + "| thành công! user: |" + loginAccount.UserName + "| - vào ngày: ");
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi thêm!!");
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

            }

        }
        private void btnDeleteServicecategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (loginAccount.Type == 3)
                {
                    MessageBox.Show("Bạn không có quyền thay đổi dữ liệu!", "Thông báo");
                    return;
                }
                string name = txtNameServiceCategory.Text;
                int id = Convert.ToInt32(txtIDServiceCategory.Text);
                if (id == 24)
                {
                    MessageBox.Show("Không được xóa", "Thông báo");
                }
                else
                {
                    DialogResult t;
                    t = MessageBox.Show(string.Format("Bạn có muốn Xóa loại {0} không ?", name), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (t == DialogResult.Yes)
                    {
                        if (ServiceCategoryDAO.Instance.DeleteServiceCategory(id))
                        {
                            MessageBox.Show("Xóa danh mục dịch vụ thành công");
                            loadListServiceCategory();
                            LoadListService();
                            LoadCategoryIntoComboBox(cbbServiceCategory);
                            if (deleteServiceCategory != null)
                                deleteServiceCategory(this, new EventArgs());
                            log.Info("Đã Xóa thông tin |" + name + "| thành công! user: |" + loginAccount.UserName + "| - ngày: ");
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi khi Xóa!!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

            }
        }
        private void btnUpdateServiceCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (loginAccount.Type == 3)
                {
                    MessageBox.Show("Bạn không có quyền thay đổi dữ liệu!", "Thông báo");
                    return;
                }
                string name = txtNameServiceCategory.Text;
                int id = Convert.ToInt32(txtIDServiceCategory.Text);
                if (id == 24)
                {
                    MessageBox.Show("Không được sửa", "Thông báo");
                }
                else
                {
                    DialogResult t;
                    t = MessageBox.Show(string.Format("Bạn có muốn Sửa loại này không ?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (t == DialogResult.Yes)
                    {
                        ServiceCategoryDTO listServiceCategory = ServiceCategoryDAO.Instance.GetCategory(id);
                        if (!name.Equals(listServiceCategory.Name))
                        {
                            log.Info("Đã Sửa thông tin |" + listServiceCategory.Name + "| (" + "Tên loại dịch vụ: |" + listServiceCategory.Name + "| -> |" + name + "| ) Thành công! user: " + loginAccount.UserName + " -  vào ngày:");
                        }

                        if (ServiceCategoryDAO.Instance.UpdateServiceCategory(name, id))
                        {
                            MessageBox.Show("Sửa danh mục dịch vụ thành công");
                            loadListServiceCategory();
                            LoadListService();
                            LoadCategoryIntoComboBox(cbbServiceCategory);
                            if (updateServiceCategory != null)
                                updateServiceCategory(this, new EventArgs());
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi khi Sửa!!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                if (loginAccount.Type == 3)
                {
                    MessageBox.Show("Bạn không có quyền thay đổi dữ liệu!", "Thông báo");
                    return;
                }
                string name = txtServiceName.Text;
                int categoryID = (cbbServiceCategory.SelectedItem as ServiceCategoryDTO).ID;
                float price = (float)nudPrice.Value;
                DialogResult t;
                t = MessageBox.Show(string.Format("Bạn có muốn thêm dịch vụ này không ?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (t == DialogResult.Yes)
                {
                    List<ServiceDTO> list = ServiceDAO.Instance.listService();
                    foreach (ServiceDTO item in list)
                    {
                        if (name == item.Name)
                        {
                            MessageBox.Show("Dịch vụ đã có trong danh sách");
                            return;
                        }
                    }
                    if (ServiceDAO.Instance.InsertService(categoryID, name, price))
                    {
                        MessageBox.Show("Thêm món thành công");
                        LoadListService();
                        if (insertService != null)
                            insertService(this, new EventArgs());
                        log.Info("Đã Thêm thông tin tên dịch vụ: |" + name + "| thành công! user: |" + loginAccount.UserName + "| - vào ngày:");
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi thêm thức ăn");
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

            }
        }

        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            try { 
            if (loginAccount.Type == 3)
            {
                MessageBox.Show("Bạn không có quyền thay đổi dữ liệu!", "Thông báo");
                return;
            }
            string name = txtServiceName.Text;
            int categoryID = (cbbServiceCategory.SelectedItem as ServiceCategoryDTO).ID;
            if (dgvService.SelectedCells.Count > 0 && dgvService.SelectedCells[0].OwningRow.Cells["idCategory"].Value != null)
            {
                int IDC = (int)dgvService.SelectedCells[0].OwningRow.Cells["idCategory"].Value;
            }
            string CategoryService = cbbServiceCategory.Text;
            float price = (float)nudPrice.Value;
            int id = Convert.ToInt32(txtServiceID.Text);
                if (id == 50)
                {
                    MessageBox.Show("Không được sửa", "Thông báo");

                }
                else if (MessageBox.Show(string.Format("Bạn có muốn thêm dịch vụ này không ?", "Thông báo"), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {

                    ServiceDTO listService = ServiceDAO.Instance.GetServiceById(id);
                    if (!name.Equals(listService.Name))
                    {
                        log.Info("Đã Sửa thông tin |" + listService.Name + "| (" + "Tên dịch vụ: |" + listService.Name + "| -> |" + name + "| ) Thành công! user: |" + loginAccount.UserName + "| -  vào ngày:");
                    }
                    if (dgvService.SelectedCells.Count > 0 && dgvService.SelectedCells[0].OwningRow.Cells["idCategory"].Value != null)
                    {
                        int IDC = (int)dgvService.SelectedCells[0].OwningRow.Cells["idCategory"].Value;

                        ServiceCategoryDTO ListSC = ServiceCategoryDAO.Instance.GetCategory(IDC);

                        if (!categoryID.Equals(listService.IDServiceCategory))
                        {
                            log.Info("Đã Sửa thông tin |" + listService.Name + "| (" + "loại dịch vụ: |" + ListSC.Name + "| -> |" + CategoryService + "| ) Thành công! user: |" + loginAccount.UserName + "| - vào ngày:");
                        }
                    }
                    if (!price.Equals(listService.Price))
                    {
                        log.Info("Đã Sửa thông tin |" + listService.Name + "| (" + "Giá dịch vụ: |" + listService.Price + "| -> |" + price + "| ) Thành công! user: |" + loginAccount.UserName + "| - vào ngày:");
                    }
                    if (ServiceDAO.Instance.UpdateService(id, categoryID, name, price))
                    {
                        MessageBox.Show("Sửa món thành công");
                        LoadListService();
                        if (updateService != null)
                        {
                            updateService(this, new EventArgs());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi Sủa thức ăn");
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            try
            {
                if (loginAccount.Type == 3)
                {
                    MessageBox.Show("Bạn không có quyền thay đổi dữ liệu!", "Thông báo");
                    return;
                }
                int id = Convert.ToInt32(txtServiceID.Text);
                string name = txtServiceName.Text;
                if (id == 50)
                {
                    MessageBox.Show("Không được xóa", "Thông báo");
                }
                else if (MessageBox.Show(string.Format("Bạn có muốn xóa dịch vụ này không ?", "Thông báo"), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    if (ServiceDAO.Instance.DeleteService(id))
                    {
                        MessageBox.Show("Xóa món thành công");
                        LoadListService();
                        if (deleteService != null)
                            deleteService(this, new EventArgs());
                        log.Info("Đã Xóa thông tin |" + name + "| thành công! user: |" + loginAccount.UserName + "| - ngày:");
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi Xóa thức ăn");
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

            }
        }
        
        private event EventHandler insertService;
        public event EventHandler InsertService
        {
            add { insertService += value; }
            remove { insertService -= value; }
        }

        private event EventHandler updateService;
        public event EventHandler UpdateService
        {
            add { updateService += value; }
            remove { updateService -= value; }
        }
        private event EventHandler deleteService;
        public event EventHandler DeleteService
        {
            add { deleteService += value; }
            remove { deleteService -= value; }
        }

        private event EventHandler insertRoom;
        public event EventHandler InsertRoom
        {
            add { insertRoom += value; }
            remove { insertRoom -= value; }
        }
        private event EventHandler deleteRoom;
        public event EventHandler DeleteRoom
        {
            add { deleteRoom += value; }
            remove { deleteRoom -= value; }
        }
        private event EventHandler updateRoom;
        public event EventHandler UpdateRoom
        {
            add { updateRoom += value; }
            remove { updateRoom -= value; }
        }
        private event EventHandler insertServiceCategory;
        public event EventHandler InsertServiceCategory
        {
            add { insertServiceCategory += value; }
            remove { insertServiceCategory -= value; }
        }
        private event EventHandler updateServiceCategory;
        public event EventHandler UpdateServiceCategory
        {
            add { updateServiceCategory += value; }
            remove { updateServiceCategory -= value; }
        }
        private event EventHandler deleteServiceCategory;
        public event EventHandler DeleteServiceCategory
        {
            add { deleteServiceCategory += value; }
            remove { deleteServiceCategory -= value; }
        }
        private event EventHandler insertRoomCategory;
        public event EventHandler InsertRoomCategory
        {
            add { insertRoomCategory += value; }
            remove { insertRoomCategory -= value; }
        }
        private event EventHandler updateRoomCategory;
        public event EventHandler UpdateRoomCategory
        {
            add { updateRoomCategory += value; }
            remove { updateRoomCategory -= value; }
        }
        private event EventHandler deleteRoomCategory;
        public event EventHandler DeleteRoomCategory
        {
            add { deleteRoomCategory += value; }
            remove { deleteRoomCategory -= value; }
        }

        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            if(txtSearchServiceName.Text=="")
            {
                MessageBox.Show("Vui Lòng Nhập Thông Tin Cần Tìm", "Thông báo");
                return;
            } 

           Servicelist.DataSource=SearchNameService(txtSearchServiceName.Text);
        }

        private void btnShowRoom_Click(object sender, EventArgs e)
        {
            LoadListRoom();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
           
                if (loginAccount.Type == 2)
                {
                    MessageBox.Show("Bạn không có quyền thay đổi dữ liệu!", "Thông báo");
                    return;
                }
                try
                {
                    string name = txtRoomName.Text;
                    int idCategory = (cbbRoomcategory.SelectedItem as RoomCategoryDTO).ID;
                    string RoomInfor = txtRoominfo.Text;
                    DialogResult t;
                    t = MessageBox.Show(string.Format("Bạn có muốn Thêm phòng {0} không ?", name), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (t == DialogResult.Yes)
                    {
                        List<RoomDTO> list = RoomDAO.Instance.LoadListRoom();
                        foreach (RoomDTO item in list)
                        {
                            if (name == item.Name)
                            {
                                MessageBox.Show("Phòng đã có trong danh sách");
                                return;
                            }
                        }
                    if (RoomDAO.Instance.InsertRoom(name, idCategory, RoomInfor))
                        {
                            MessageBox.Show("Thêm phòng thành công");
                            LoadListRoom();
                            if (insertRoom != null)
                                insertRoom(this, new EventArgs());
                            log.Info("Đã Thêm thông tin |" + name + "| thành công! user: |" + loginAccount.UserName + "| - ngày:");
                        }
                        else
                        {
                            MessageBox.Show("có lỗi khi thêm Phòng!!!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }
            
          

        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (loginAccount.Type == 2)
            {
                MessageBox.Show("Bạn không có quyền thay đổi dữ liệu!", "Thông báo");
                return;
            }
            try
            {
                int id = Convert.ToInt32(txtRoomID.Text);
                string name = txtRoomName.Text;

                DialogResult t;
                t = MessageBox.Show(string.Format("Bạn có muốn xóa phòng {0} không ?", name), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (t == DialogResult.Yes)
                {
                    if (RoomDAO.Instance.DeleteRoom(id))
                    {
                        MessageBox.Show("Xóa phòng thành công");
                        LoadListRoom();
                        if (deleteRoom != null)
                            deleteRoom(this, new EventArgs());

                        log.Info("Đã Xóa thông tin |" + name + "| thành công! user: |" + loginAccount.UserName + "| - ngày:");
                    }
                    else
                    {
                        MessageBox.Show("có lỗi khi Xóa Phòng!!!");
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            
            if (loginAccount.Type == 2)
            {
                MessageBox.Show("Bạn không có quyền thay đổi dữ liệu!", "Thông báo");
                return;
            }
                try
                {
                    string name = txtRoomName.Text;
                    int idCategory = (cbbRoomcategory.SelectedItem as RoomCategoryDTO).ID;
                    int id = Convert.ToInt32(txtRoomID.Text);
                    string RoomInfor = txtRoominfo.Text;
                    DialogResult t;
                    t = MessageBox.Show(string.Format("Bạn có muốn sửa không ?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (t == DialogResult.Yes)
                    {
                        RoomDTO listroom = RoomDAO.Instance.GetRoomBId(id);
                        if (!name.Equals(listroom.Name))
                        {
                            log.Info("Đã Sửa thông tin |" + listroom.Name + "| (" + "Tên phòng: |" + listroom.Name + "| -> |" + name + "| ) Thành công! user: |" + loginAccount.UserName + "| -  vào ngày:");
                        }
                        if (!idCategory.Equals(listroom.IDRoomCategory))
                        {
                            log.Info("Đã Sửa thông tin |" + listroom.Name + "| (" + "ID Loại phòng: |" + listroom.IDRoomCategory + "| -> |" + idCategory + "| ) Thành công! user: |" + loginAccount.UserName + "| - vào ngày:");
                        }
                        if (!RoomInfor.Equals(listroom.RoomInfor))
                        {
                            log.Info("Đã Sửa thông tin |" + listroom.Name + "| (" + "Thông tin phòng: |" + listroom.RoomInfor + "| -> |" + RoomInfor + "| ) Thành công! user: |" + loginAccount.UserName + "| - vào ngày:");
                        }

                        if (RoomDAO.Instance.UpdateRoom(name, idCategory, id, RoomInfor))
                        {
                            MessageBox.Show("Sửa phòng thành công");
                            LoadListRoom();
                            if (updateRoom != null)
                                updateRoom(this, new EventArgs());
                        }
                        else
                        {
                            MessageBox.Show("có lỗi khi Sửa Phòng!!!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }

            
          
        }

        private void btnShowServiceCategory_Click(object sender, EventArgs e)
        {
            loadListServiceCategory();
        }

        private void btnShowRoomCategory_Click(object sender, EventArgs e)
        {
            LoadListsRoomCategory();
        }

        private void btnAddRoomCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (loginAccount.Type == 2)
                {
                    MessageBox.Show("Bạn không có quyền thay đổi dữ liệu!", "Thông báo");
                    return;
                }
                int id = Convert.ToInt32(txtIDRoomCategory.Text);
                string name = txtNameRoomCategory.Text;
                float price = (float)nudTime.Value;
                DialogResult t;
                t = MessageBox.Show(string.Format("Bạn có muốn Thêm phòng {0} không ?", name), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (t == DialogResult.Yes)
                {
                    List<RoomCategoryDTO> list = RoomCategoryDAO.Instance.ListRoomCategory();
                    foreach (RoomCategoryDTO item in list)
                    {
                        if (name == item.NameRoomCategory)
                        {
                            MessageBox.Show(" Loại Phòng đã có trong danh sách");
                            return;
                        }
                    }
                    if (RoomCategoryDAO.Instance.InsertRoomCategory(name, price))
                    {
                        MessageBox.Show("Thêm phòng thành công");
                        LoadListsRoomCategory();
                        LoadListRoom();

                        if (insertRoomCategory != null)
                        {
                            insertRoomCategory(this, new EventArgs());
                            log.Info("Đã Thêm thông tin tên loại phòng: |" + name + "| thành công! user: |" + loginAccount.UserName + "| - vào ngày:");
                        }
                    }
                    else
                    {
                        MessageBox.Show("có lỗi khi Thêm Phòng!!!");
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

            }
        }

        private void btnUpdateRoomCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (loginAccount.Type == 2)
                {
                    MessageBox.Show("Bạn không có quyền thay đổi dữ liệu!", "Thông báo");
                    return;
                }
                int id = Convert.ToInt32(txtIDRoomCategory.Text);
                string name = txtNameRoomCategory.Text;
                float price = (float)nudTime.Value;
                DialogResult t;
                t = MessageBox.Show(string.Format("Bạn có muốn Thêm phòng {0} không ?", name), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (t == DialogResult.Yes)
                {
                    RoomCategoryDTO listroom = RoomCategoryDAO.Instance.GetRoomCategoryByID(id);
                    if (!name.Equals(listroom.NameRoomCategory))
                    {
                        log.Info("Đã Sửa thông tin |" + listroom.NameRoomCategory + " (" + "Tên Loại Phòng: |" + listroom.NameRoomCategory + "| -> |" + name + "| ) Thành công! user: |" + loginAccount.UserName + "| -  vào ngày:");
                    }
                    if (!price.Equals(listroom.Price))
                    {
                        log.Info("Đã Sửa thông tin |" + listroom.NameRoomCategory + "| (" + "Giá phòng: |" + listroom.Price + "| -> |" + price + "| ) Thành công! user: |" + loginAccount.UserName + "| - vào ngày:");
                    }

                    if (RoomCategoryDAO.Instance.UpdateRoomCategory(name, id, price))
                    {
                        MessageBox.Show("Sửa phòng thành công");
                        LoadListsRoomCategory();
                        LoadListRoom();

                        if (updateRoomCategory != null)
                            updateRoomCategory(this, new EventArgs());

                    }
                    else
                    {
                        MessageBox.Show("có lỗi khi Sửa Phòng!!!");
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

            }
        }

        private void btnDeleteRoomCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (loginAccount.Type == 2)
                {
                    MessageBox.Show("Bạn không có quyền thay đổi dữ liệu!", "Thông báo");
                    return;
                }
                int id = Convert.ToInt32(txtIDRoomCategory.Text);
                string name = txtNameRoomCategory.Text;
                float price = (float)nudTime.Value;
                DialogResult t;
                t = MessageBox.Show(string.Format("Bạn có muốn Xóa phòng {0} không ?", name), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (t == DialogResult.Yes)
                {
                    if (RoomCategoryDAO.Instance.DeteleRoomCategory(id))
                    {
                        MessageBox.Show(" Xóa thành công");
                        LoadListsRoomCategory();
                        LoadListRoom();

                        if (deleteRoomCategory != null)
                            deleteRoomCategory(this, new EventArgs());
                        log.Info("Đã Xóa thông tin |" + name + "| thành công! user: |" + loginAccount.UserName + "| - ngày:");
                    }
                    else
                    {
                        MessageBox.Show("có lỗi khi Xóa Phòng!!!");
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

            }
        }

        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadListAccount();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (loginAccount.Type == 4)
                {

                    string user = txtAccountUser.Text;
                    string displayname = txtAccountDislayName.Text;
                    int id = (cbbPosition.SelectedItem as PositionDTO).ID;
                    // int type =(int)nmrAccountType.Value;
                    DialogResult t;
                    t = MessageBox.Show(string.Format("Bạn có muốn Thêm tài khoản {0} không ?", user), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (t == DialogResult.Yes)
                    {
                        List<AccountDTO> list = AccountDAO.Instance.GetAccount();
                        foreach (AccountDTO item in list)
                        {
                            if (user == item.UserName)
                            {
                                MessageBox.Show("Tài khoản đã tồn tại");
                                return;
                            }
                        }
                        if (AccountDAO.Instance.InsertAccount(user, displayname, id))
                        {
                            MessageBox.Show("Thêm Tài Khoản thành công");
                            LoadListAccount();
                            log.Info("Đã Thêm thông tin tài khoản: |" + user + "| thành công! user: |" + loginAccount.UserName + "| - vào ngày:");
                        }
                        else
                        {
                            MessageBox.Show("Thêm Tài Khoản thất bại");
                        }
                    }
                }
                else
                {

                    MessageBox.Show("Bạn không có quyền thay đổi dữ liệu!", "Thông báo");
                    return;

                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (loginAccount.Type == 4)
                {
                    string user = txtAccountUser.Text;
                    DialogResult t;
                    t = MessageBox.Show(string.Format("Bạn có muốn Xóa tài khoản {0} không ?", user), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (t == DialogResult.Yes)
                    {
                        if (LoginAccount.UserName.Equals(user))
                        {
                            MessageBox.Show("Tài Khoản đang chạy");
                            return;
                        }
                        if (AccountDAO.Instance.DeleteAccount(user))
                        {
                            MessageBox.Show("Xóa Tài Khoản thành công");
                            LoadListAccount();
                            log.Info("Đã Xóa thông tin tài khoản: |" + user + "| thành công! user: |" + loginAccount.UserName + "| - ngày:");
                        }
                        else
                        {
                            MessageBox.Show("Xóa Tài Khoản thất bại");
                        }
                    }
                }
                else
                {

                    MessageBox.Show("Bạn không có quyền thay đổi dữ liệu!", "Thông báo");
                    return;

                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            try {
                if (loginAccount.Type == 4)
                {
                    string user = txtAccountUser.Text;
                    string displayname = txtAccountDislayName.Text;
                    int id = (cbbPosition.SelectedItem as PositionDTO).ID;
                    string position = cbbPosition.Text;
                    // int type = (int)nmrAccountType.Value;
                    DialogResult t;
                    t = MessageBox.Show(string.Format("Bạn có muốn Sửa thông tin Tài Khoản này không ?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (t == DialogResult.Yes)
                    {
                        if (dgvAccount.SelectedCells.Count > 0 && dgvAccount.SelectedCells[0].OwningRow.Cells["UserName"].Value != null)
                        {
                            string userN = dgvAccount.SelectedCells[0].OwningRow.Cells["UserName"].Value.ToString();
                            if (!user.Equals(userN))
                            {
                                MessageBox.Show("Không được sửa tài khoản!!", "Thông báo");
                                return;
                            }
                            {

                            }
                            if (dgvAccount.SelectedCells.Count > 0 && dgvAccount.SelectedCells[0].OwningRow.Cells["NamePosition"].Value != null)
                            {
                                string PositionN = dgvAccount.SelectedCells[0].OwningRow.Cells["NamePosition"].Value.ToString();
                                AccountDTO listAccount = AccountDAO.Instance.GetAccountByUserName(user);


                                if (!displayname.Equals(listAccount.DisPlayName))
                                {
                                    log.Info("Đã Sửa thông tin |" + listAccount.UserName + "| (" + "Tên hiển thị: |" + listAccount.DisPlayName + "| -> |" + displayname + " ) Thành công! user: |" + loginAccount.UserName + "| - vào ngày:");
                                }
                                if (!id.Equals(listAccount.Type))
                                {
                                    log.Info("Đã Sửa thông tin |" + listAccount.UserName + "| (" + "Chức vụ: |" + PositionN + "| -> |" + position + "| ) Thành công! user: |" + loginAccount.UserName + "| - vào ngày:");
                                }
                                if (AccountDAO.Instance.UpdateAccount(user, displayname, id))
                                {
                                    MessageBox.Show("Cập nhập Tài Khoản thành công");
                                    LoadListAccount();

                                }
                                else
                                {
                                    MessageBox.Show("Không được sửa tài khoản");
                                }
                            }
                        }
                    }
                }

                else
                {

                    MessageBox.Show("Bạn không có quyền thay đổi dữ liệu!", "Thông báo");
                    return;

                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

            }
        }

        private void btnResetPassWord_Click(object sender, EventArgs e)
        {
            try
            {
                if (loginAccount.Type == 4)
                {
                    string user = txtAccountUser.Text;
                    DialogResult t;
                    t = MessageBox.Show(string.Format("Bạn có muốn đặt lại mặt khẩu cho tài khoản {0} không ?", user), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (t == DialogResult.Yes)
                    {
                        if (AccountDAO.Instance.ResetPassWord(user))
                        {
                            MessageBox.Show("Đặt lại mật khẩu thành công");
                            log.Info("Đã đặt lại mật khẩu cho user: |" + user + "| thành công! user: |" + loginAccount.UserName + "| - ngày:");
                        }
                        else
                        {
                            MessageBox.Show("Đặt lại mật khẩu thất bại");
                        }
                    }
                }
                else
                {

                    MessageBox.Show("Bạn không có quyền thay đổi dữ liệu!", "Thông báo");
                    return;

                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

            }
        }

        private void btnFristPage_Click(object sender, EventArgs e)
        {
            txtNumPage.Text = "1";

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetBillNumByDateTime(dtpFromTime.Value, dtpToTime.Value);
            int LastPage = sumRecord / 10;
            if(sumRecord % 10 !=0)
            {
                LastPage++;
            }
            txtNumPage.Text = LastPage.ToString();
        }

        private void txtNumPage_TextChanged(object sender, EventArgs e)
        {
            dgvBill.DataSource = BillDAO.Instance.GetBillListByDateTimeAndPage(dtpFromTime.Value, dtpToTime.Value, Convert.ToInt32(txtNumPage.Text));
        }

        private void btnPervious_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txtNumPage.Text);

            if(page>1)
            {
                page--;
            }
            txtNumPage.Text = page.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txtNumPage.Text);
            int sumRecord = BillDAO.Instance.GetBillNumByDateTime(dtpFromTime.Value, dtpToTime.Value);

            if (page < sumRecord)
                page++;
            txtNumPage.Text = page.ToString(); 
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void Admin_Load(object sender, EventArgs e)
        {
           
            
        }

        private void rpViewer_Load(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            
            ReportB rp = new ReportB();
            rp.CheckIn = dtpFromTime.Value;//lấy thuộc tính này qua form khác thôi

            rp.CheckOut = dtpToTime.Value;
            rp.ShowDialog();







        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
          
        }

        private void txtSearchServiceName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tcService_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroTabControlRoom_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearchServiceCategory_Click(object sender, EventArgs e)
        {
            Servicelist.DataSource = SearchNameServiceBycategory(cbbSearchServiceCategory.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (loginAccount.Type == 3)
            {
                MessageBox.Show("Quyền đăng nhập của bạn không hỗ trợ tính năng này!", "Thông báo");
                return;
            }
            string query = "";
           
            AdvancedSearch f = new AdvancedSearch();
            
            f.ShowDialog();
            if (f.Query == null)
                return;
            query = f.Query;
            // f.UpdateLoadDGV += F_UpdateLoadDGV;
            this.loadSearchAdvanced(query);
            
        }

        private void F_UpdateLoadDGV(object sender, EventArgs e)
        {
            
           
        }

        private void cbbSearchSC_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            ServiceCategoryDTO selected = cb.SelectedItem as ServiceCategoryDTO;
            id = selected.ID;

            LoadServiceListByCategoryID(id);
        }

        private void btnSearchByCategoryAndName_Click(object sender, EventArgs e)
        {
            Servicelist.DataSource = SearchNameServiceBycategoryAndName(cbbSearchS.Text,cbbSearchSC.Text);
        }
        private void customizeDesigning()
        {
            pnSearchCategory.Visible = false;
            pnSearchName.Visible = false;
            pnSearchNameAndCateogry.Visible = false;
        }

        private void hideSubMenu()
        {
            if (pnSearchName.Visible == true)
            {
                pnSearchCategory.Visible = false;
                pnSearchNameAndCateogry.Visible = false;
            }
            if (pnSearchCategory.Visible == true)
            {
                pnSearchName.Visible = false;
                pnSearchNameAndCateogry.Visible = false;
            }
            if (pnSearchNameAndCateogry.Visible == true)
            {
                pnSearchName.Visible = false;
                pnSearchCategory.Visible = false;
            }
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void iconButtonSearchName_Click(object sender, EventArgs e)
        {
            showSubMenu(pnSearchName);
        }

        private void iconButtonSearchCategory_Click(object sender, EventArgs e)
        {
            showSubMenu(pnSearchCategory);
        }

        private void iconButtonSearchNameAndCategory_Click(object sender, EventArgs e)
        {
            showSubMenu(pnSearchNameAndCateogry);
        }

        private void metroTabControlRoom_Selecting(object sender, TabControlCancelEventArgs e)
        {
         
        }

        private void txtAccountUser_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvAccount.SelectedCells.Count > 0 && dgvAccount.SelectedCells[0].OwningRow.Cells["Type"].Value != null)
                {
                    int id = (int)dgvAccount.SelectedCells[0].OwningRow.Cells["Type"].Value;//chọn ô đầu tiên trong danh sach category sau đó lấy cái dòng chưa ô đã chọn


                    PositionDTO Position = AccountDAO.Instance.GetPositionByID(id);
                    cbbPosition.SelectedItem = Position;
                    int index = -1;
                    int i = 0;
                    foreach (PositionDTO item in cbbPosition.Items)
                    {
                        if (item.ID == Position.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbbPosition.SelectedIndex = index;
                }

            }
            catch
            {

            }
        }

        private void LlblTool_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(loginAccount.Type!=4)
            {
                MessageBox.Show("Bạn không có chức năng ủy thác!!", "Thông báo");
                return;
            }    
            ToolEncrytAnDecryt f = new ToolEncrytAnDecryt();
            f.ShowDialog();

        }
    }
}
