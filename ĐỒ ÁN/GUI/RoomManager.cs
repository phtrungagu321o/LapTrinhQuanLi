using ĐỒ_ÁN.DAO;
using ĐỒ_ÁN.DTO;
using ĐỒ_ÁN.GUI;
using FontAwesome.Sharp;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐỒ_ÁN
{
    public partial class RoomManager : Form
    {

        private string userName;
        private Form currentEditRoom;
        private Form currentEditRoomDock;
        ILog log = LogManager.GetLogger(typeof(RoomManager));
        public string UserName { get => userName; set => userName = value; }
        private AccountDTO loginAccount;
        public AccountDTO LoginAccount { get => loginAccount; set => loginAccount = value; }

      

        public RoomManager(AccountDTO acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            LoadRoom();
            LoadServiceCategory();
            LoadComboBoxRoom(cbbSwitchRoom);
            loadAdmin();
         
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }


       
        #region Method


        void LoadRoom()
        {
            flpNormalRoom.Controls.Clear();
            flpVIPRoom.Controls.Clear();
           List<RoomDTO> RoomList= RoomDAO.Instance.LoadRoomList();
            foreach(RoomDTO item in RoomList)
            {
                IconButton btn = new IconButton() {Width=RoomDAO.RoomWidth,Height=RoomDAO.RoomHeight };
                btn.Text = item.Name + "\n\n" + item.Status;
                btn.IconChar = IconChar.Table;
                btn.IconSize = 80;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.TextImageRelation = TextImageRelation.ImageAboveText;
                btn.ImageAlign = ContentAlignment.MiddleCenter;
                btn.ForeColor= Color.Gainsboro;
                btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold);
                
                btn.Click += Btn_Click;
             
                btn.Tag = item;
                btn.ContextMenuStrip = contextMenuStrip1;

                switch (item.Status)
                {
                    case " Trống":
                        btn.IconColor = Color.LightBlue;
                        break;
                    default:
                        btn.IconColor = Color.LightCoral;
                        btn.ForeColor = Color.LightCoral;
                        break;
                }    
                
                if (item.IDRoomCategory == 1)
                    flpNormalRoom.Controls.Add(btn);
                else
                    flpVIPRoom.Controls.Add(btn);
                
            }   
                
        }
        private void Btn_Click(object sender, EventArgs e)
        {

            int roomID = ((sender as Button).Tag as RoomDTO).ID;
            lstvBill.Tag = (sender as Button).Tag;
            ShowServiceBill(roomID);
            ShowTimeBill(roomID);
            AddPriceOld(roomID);
            TotalPrice();




        }
        

        void ShowServiceBill(int id)
        {
            lstvBill.Items.Clear();
            List<MenuServiceDTO> listFoodBillInfo = MenuDAO.Instance.GetListMenuFoodByRoom(id);
            float totalPrice = 0;
            foreach(MenuServiceDTO item in listFoodBillInfo)
            {
                ListViewItem lvItem = new ListViewItem(item.ServiceName.ToString()); 
                lvItem.SubItems.Add(item.ServicePrice.ToString());
                lvItem.SubItems.Add(item.CountService.ToString());           
                lvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lstvBill.Items.Add(lvItem);
            }
            txtTotalPriceService.Text = totalPrice.ToString();

             
        }
   
        void ShowTimeBill(int id)
        {

            txtAddTime.Text = "?? tiếng ?? phút";
            int t = 0;
            txtPriceTimeTest.Text = "0";
            CultureInfo culture = new CultureInfo("vi-VN");
            txtPriceTime.Text = t.ToString("c",culture);
            List<MenuTimeDTO> listTimeBillInfo = MenuDAO.Instance.GetListTimeByIdRoom(id);
            foreach (MenuTimeDTO item in listTimeBillInfo)
            {
                txtAddTime.Text = item.Time;
                float f = item.TimePrice;
                Console.WriteLine(f.ToString());
                
                txtPriceTime.Text = f.ToString("c",culture);
                txtPriceTimeTest.Text = f.ToString();
                
            }
        }
       
        void AddTimeBill()
        {
          
            int tr = 0;
            DialogResult t;
            t = MessageBox.Show("Bạn có muốn xuất số giờ của bàn này vào Bill không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                ListViewItem list1 = new ListViewItem("--------------------");               
                lstvBill.Items.Add(list1);
                ListViewItem list2 = new ListViewItem("Số Giờ: "+txtAddTime.Text);
                list2.SubItems.Add("");
                list2.SubItems.Add("");
                list2.SubItems.Add(txtPriceTime.Text);
                lstvBill.Items.Add(list2);
                ListViewItem list3 = new ListViewItem("--------------------");
                lstvBill.Items.Add(list3);
                ListViewItem list4 = new ListViewItem("Số Tiền Bổ sung: ");
                list4.SubItems.Add("");
                list4.SubItems.Add("");
                list4.SubItems.Add(txtPriceTimeBillOld.Text);
                lstvBill.Items.Add(list4);

                CultureInfo culture = new CultureInfo("vi-VN");
                txtPriceTime.Text = tr.ToString("c",culture);
            }
        }
        void AddPriceOld(int id)
        {
            txtPriceTimeBillOld.Text = "0,00 ₫";
            txtTimeOldTest.Text = "0";
            List<MenuPriceOldDTO> listPriceOld = MenuDAO.Instance.GetPriceOld(id);
            foreach(MenuPriceOldDTO item in listPriceOld)
            {                
                float f = item.PriceOld1;
                CultureInfo culture = new CultureInfo("vi-VN");
                txtPriceTimeBillOld.Text = f.ToString("c",culture);
                txtTimeOldTest.Text = f.ToString();  
            }    
        }
        void TotalPrice()
        {
            
            double f = float.Parse(txtTotalPriceService.Text);
                     
            double t = float.Parse(txtPriceTimeTest.Text);
            double old = float.Parse(txtTimeOldTest.Text);
            double TP = f + t + old;
            CultureInfo culture = new CultureInfo("vi-VN");
            txtTotalPrice.Text = TP.ToString("c",culture);
            txtToTalPriceTest.Text = TP.ToString();
        }
        void LoadComboBoxRoom(ComboBox cb)
        {
            cb.DataSource = RoomDAO.Instance.LoadRoomList();
            cb.DisplayMember = "name";
        }
        void LoadServiceCategory()
        {
            List<ServiceCategoryDTO> listCategory = ServiceCategoryDAO.Instance.GetListCategory();
            cbbServiceCategory.DataSource = listCategory;
            cbbServiceCategory.DisplayMember = "name";
        }
        void LoadServiceListByCategoryID(int id)
        {
            List<ServiceDTO> listFood = ServiceDAO.Instance.GetListServiceByCategory(id);
            cbbService.DataSource = listFood;
            cbbService.DisplayMember = "name";
        }
        void  checkListView()
        {
            RoomDTO room = lstvBill.Tag as RoomDTO;
            int idBill = BillDAO.Instance.GetUnCheckBillIDByRoomID(room.ID);
            int idRoom = (lstvBill.Tag as RoomDTO).ID;
             BillInfoDAO.Instance.InsertBillInfo(idBill, 50, 0, idRoom);
             

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion

        #region Events

        private void Btn_DoubleClick(object sender, EventArgs e)
        {

            
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* AccountProfile af = new AccountProfile();
            af.UpdateAccount += Af_UpdateAccount;
            af.ShowDialog();*/
            
        }

        private void Af_UpdateAccount(object sender, AccountEvent e)
        {
            /*btnProFile.Text = "Thông tin tài khoản (" + e.Acc.DisPlayName + ")";*/
        }
        void loadAdmin()
        {
            AccountDTO login = AccountDAO.Instance.GetAccountByUserName(loginAccount.UserName);
            Admin a = new Admin(login);
           /* a.loginAccount = LoginAccount;*/
            a.InsertService += A_InsertService;
            a.UpdateService += A_UpdateService;
            a.DeleteService += A_DeleteService;

            a.InsertRoom += A_InsertRoom;
            a.UpdateRoom += A_UpdateRoom;
            a.DeleteRoom += A_DeleteRoom;

            a.InsertServiceCategory += A_InsertServiceCategory;
            a.UpdateServiceCategory += A_UpdateServiceCategory;
            a.DeleteServiceCategory += A_DeleteServiceCategory;

            a.InsertRoomCategory += A_InsertRoomCategory;
            a.UpdateRoomCategory += A_UpdateRoomCategory;
            a.DeleteRoomCategory += A_DeleteRoomCategory;
        }
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* Admin a = new Admin();
            a.ShowDialog();*/
        }

        private void A_DeleteRoomCategory(object sender, EventArgs e)
        {
            LoadRoom();
            LoadComboBoxRoom(cbbSwitchRoom);
            
        }

        private void A_UpdateRoomCategory(object sender, EventArgs e)
        {
            LoadRoom();
            LoadComboBoxRoom(cbbSwitchRoom);
        }

        private void A_InsertRoomCategory(object sender, EventArgs e)
        {
            LoadRoom();
            LoadComboBoxRoom(cbbSwitchRoom);
        }

        private void A_DeleteServiceCategory(object sender, EventArgs e)
        {
            LoadServiceCategory();
            LoadServiceListByCategoryID((cbbServiceCategory.SelectedItem as ServiceCategoryDTO).ID);
            
            if (lstvBill.Tag != null)
                ShowServiceBill((lstvBill.Tag as RoomDTO).ID);
            LoadRoom();
        }

        private void A_UpdateServiceCategory(object sender, EventArgs e)
        {
            LoadServiceCategory();
            LoadServiceListByCategoryID((cbbServiceCategory.SelectedItem as ServiceCategoryDTO).ID);

            if (lstvBill.Tag != null)
                ShowServiceBill((lstvBill.Tag as RoomDTO).ID);
        }

        private void A_InsertServiceCategory(object sender, EventArgs e)
        {
            LoadServiceCategory();
            LoadServiceListByCategoryID((cbbServiceCategory.SelectedItem as ServiceCategoryDTO).ID);

            if (lstvBill.Tag != null)
                ShowServiceBill((lstvBill.Tag as RoomDTO).ID);
        }

        private void A_DeleteRoom(object sender, EventArgs e)
        {
            LoadRoom();
            LoadComboBoxRoom(cbbSwitchRoom);
        }

        private void A_UpdateRoom(object sender, EventArgs e)
        {
            LoadRoom();
            LoadComboBoxRoom(cbbSwitchRoom);

        }

        private void A_InsertRoom(object sender, EventArgs e)
        {
            LoadRoom();
            LoadComboBoxRoom(cbbSwitchRoom);

        }

        private void A_DeleteService(object sender, EventArgs e)
        {
            LoadServiceListByCategoryID((cbbServiceCategory.SelectedItem as ServiceCategoryDTO).ID);
            if (lstvBill.Tag != null)
                ShowServiceBill((lstvBill.Tag as RoomDTO).ID);
            LoadRoom();
        }

        private void A_UpdateService(object sender, EventArgs e)
        {
            LoadServiceListByCategoryID((cbbServiceCategory.SelectedItem as ServiceCategoryDTO).ID);
            if(lstvBill.Tag !=null)
                ShowServiceBill((lstvBill.Tag as RoomDTO).ID);
        }

        private void A_InsertService(object sender, EventArgs e)
        {
            LoadServiceListByCategoryID((cbbServiceCategory.SelectedItem as ServiceCategoryDTO).ID);
            if (lstvBill.Tag != null)
                ShowServiceBill((lstvBill.Tag as RoomDTO).ID);
        }

        private void rdAddFood_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void rdSurcharge_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAddTime_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            
            RoomDTO room = lstvBill.Tag as RoomDTO;
            
            if (room == null)
            {
                MessageBox.Show("Hãy chọn bàn!!!");
                return;
            }
            int id = (lstvBill.Tag as RoomDTO).ID;
           
            List<RoomDTO> lits = RoomDAO.Instance.LoadRoomListByID(id);
            foreach(RoomDTO item in lits)
            {
                if(item.Status==" Trống")
                {
                    MessageBox.Show("Phòng hiện tại đang Trống", "Thông báo");
                    return;
                }    
            }
            
            int idBill = BillDAO.Instance.GetUnCheckBillIDByRoomID(room.ID);
            int disCount = (int)nmrDiscount.Value;
            int maxidBill = BillDAO.Instance.GetMaxIDBill();
            double totalPrice = float.Parse(txtToTalPriceTest.Text);

            double FinalTotalPrice = totalPrice - (totalPrice / 100) * disCount;

            string totalTime = txtAddTime.Text;
            float priceoldtime = float.Parse(txtTimeOldTest.Text);
               
            if (idBill !=-1) //bill đã có
            {
                if(MessageBox.Show(string.Format("Bạn có chắc muốn thanh toán hóa đơn cho bàn {0}\n Tổng tiền - (Tổng Tiền / 100) x Giảm giá\n<=> {1} - ({1}/100) x {2} = {3}",room.Name, totalPrice,disCount, FinalTotalPrice),"Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==System.Windows.Forms.DialogResult.OK)
                {
                    if (lstvBill.Items.Count == 0)
                    {
                        checkListView();
                    }
                    BillDAO.Instance.CheckOut(idBill, disCount, totalTime, priceoldtime,(float)FinalTotalPrice);
                    
                    ShowServiceBill(room.ID);
                }   
            }
             
               
                
            LoadRoom();
            ShowTimeBill(room.ID);
            AddPriceOld(room.ID);
            if (MessageBox.Show(string.Format("Bạn có muốn in hóa đơn không ?"), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                invoicePrintting f = new invoicePrintting();
                f.IDBill = idBill;
                f.ShowDialog();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            ServiceCategoryDTO selected = cb.SelectedItem as ServiceCategoryDTO;
            id = selected.ID;

            LoadServiceListByCategoryID(id);
        }
        private void cbbDeviceCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            
            RoomDTO room = lstvBill.Tag as RoomDTO;
            if(room==null)
            {
                MessageBox.Show("Hãy chọn bàn!!!");
                return; 
            }    
            
            int idBill = BillDAO.Instance.GetUnCheckBillIDByRoomID(room.ID);
            int Service = (cbbService.SelectedItem as ServiceDTO).ID;
            int countService = (int)nmrCountService.Value;
            int idRoom = (lstvBill.Tag as RoomDTO).ID;
           
            if (idBill == -1)//không có bill nào hết ;
            {
                BillDAO.Instance.InsertBill(room.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), Service, countService,idRoom); 
            }    
            else //Bill đã tồn tại
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, Service, countService,idRoom);
            }
            ShowServiceBill(room.ID);       
            TotalPrice();
            LoadRoom();
            ShowTimeBill(room.ID);
        }


        #endregion

        private void btnAddSurcharge_Click(object sender, EventArgs e)
        {
       
        }

        private void btnSwitchRoom_Click(object sender, EventArgs e)
        {
            RoomDTO room = lstvBill.Tag as RoomDTO;
            if(room==null)
            {
                MessageBox.Show("Vui lòng chọn phòng cần chuyển", "Thông báo");
                return;
            }    
            int id1 = (lstvBill.Tag as RoomDTO).ID;
            int id2 = (cbbSwitchRoom.SelectedItem as RoomDTO).ID;
            string name1 = (lstvBill.Tag as RoomDTO).Status;
            List<RoomDTO> list = RoomDAO.Instance.LoadRoomListByID(id2);
            foreach (RoomDTO item in list)
            {
                string f = item.Status;
                if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển  {0} qua  {1}", (lstvBill.Tag as RoomDTO).Name, (cbbSwitchRoom.SelectedItem as RoomDTO).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {     
                    if (f=="Có Người")
                        {
                             MessageBox.Show(string.Format("{0} đã có người", (cbbSwitchRoom.SelectedItem as RoomDTO).Name));
                         } 
                    else if(name1==" Trống")
                    {
                        MessageBox.Show(string.Format("Bàn {0} đang trống !!! ", (lstvBill.Tag as RoomDTO).Name));
                    }
                    
                    else 
                    {
                        RoomDAO.Instance.SwitchRoom(id1, id2);
                        RoomDAO.Instance.SwitchOldTimePrice(id1, id2);
                        LoadRoom();
                        ShowTimeBill(room.ID);
                        AddPriceOld(room.ID);
                    }

                }
            }
           
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            RoomDTO room = lstvBill.Tag as RoomDTO;
           
            if (room == null)
            {
                MessageBox.Show("Hãy chọn bàn!!!");
                return;
            }

            int idBill = BillDAO.Instance.GetUnCheckBillIDByRoomID(room.ID);
           
            int idRoom = (lstvBill.Tag as RoomDTO).ID;
            if (idBill == -1)//không có bill nào hết ;
            {
                BillDAO.Instance.InsertStartBill(room.ID);
              

            }

        
            else //Bill đã tồn tại
            {
                MessageBox.Show("Phòng này đã bắt đầu tính giờ", "Thông báo");
                return;
            }
           
            ShowServiceBill(room.ID);
            TotalPrice();
            LoadRoom();
            ShowTimeBill(room.ID);

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

       

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCheckOut_Click(this, new EventArgs());
        }

        private void bắtĐầuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnStart_Click(this, new EventArgs());
        }

        private void mởAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminToolStripMenuItem_Click(this, new EventArgs());
        }

        private void mởThôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thôngTinCáNhânToolStripMenuItem_Click(this, new EventArgs());
        }

        private void màuNềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void RoomManager_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* AccountProfile af = new AccountProfile(loginAccount);
            af.UpdateAccount += Af_UpdateAccount;
            af.ShowDialog();
            hideSubMenu();*/
        }
        

      

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AccountDTO login = AccountDAO.Instance.GetAccountByUserName(loginAccount.UserName);
            Admin a = new Admin(login);
           /* a.loginAccount = LoginAccount;*/
            a.InsertService += A_InsertService;
            a.UpdateService += A_UpdateService;
            a.DeleteService += A_DeleteService;

            a.InsertRoom += A_InsertRoom;
            a.UpdateRoom += A_UpdateRoom;
            a.DeleteRoom += A_DeleteRoom;

            a.InsertServiceCategory += A_InsertServiceCategory;
            a.UpdateServiceCategory += A_UpdateServiceCategory;
            a.DeleteServiceCategory += A_DeleteServiceCategory;

            a.InsertRoomCategory += A_InsertRoomCategory;
            a.UpdateRoomCategory += A_UpdateRoomCategory;
            a.DeleteRoomCategory += A_DeleteRoomCategory;
            a.ShowDialog();
           
        }


        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void phímTắtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            RoomDTO room = lstvBill.Tag as RoomDTO;
            if (room == null)
            {
                MessageBox.Show("Vui lòng chọn phòng cần chuyển", "Thông báo");
                return;
            }
            int id1 = (lstvBill.Tag as RoomDTO).ID;
            int id2 = (cbbSwitchRoom.SelectedItem as RoomDTO).ID;
            string name1 = (lstvBill.Tag as RoomDTO).Status;
            List<RoomDTO> list = RoomDAO.Instance.LoadRoomListByID(id2);
            foreach (RoomDTO item in list)
            {
                string f = item.Status;
                if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển  {0} qua  {1}", (lstvBill.Tag as RoomDTO).Name, (cbbSwitchRoom.SelectedItem as RoomDTO).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    if (f == "Có Người")
                    {
                        MessageBox.Show(string.Format("{0} đã có người", (cbbSwitchRoom.SelectedItem as RoomDTO).Name));
                    }
                    else if (name1 == " Trống")
                    {
                        MessageBox.Show(string.Format("Bàn {0} đang trống !!! ", (lstvBill.Tag as RoomDTO).Name));
                    }

                    else
                    {
                        RoomDAO.Instance.SwitchRoom(id1, id2);
                        RoomDAO.Instance.SwitchOldTimePrice(id1, id2);
                        LoadRoom();
                        ShowTimeBill(room.ID);
                        AddPriceOld(room.ID);
                    }

                }
            }
        }

        private void iconButtonCheckOut_Click(object sender, EventArgs e)
        {

            RoomDTO room = lstvBill.Tag as RoomDTO;

            if (room == null)
            {
                MessageBox.Show("Hãy chọn bàn!!!");
                return;
            }
            int id = (lstvBill.Tag as RoomDTO).ID;

            List<RoomDTO> lits = RoomDAO.Instance.LoadRoomListByID(id);
            foreach (RoomDTO item in lits)
            {
                if (item.Status == " Trống")
                {
                    MessageBox.Show("Phòng hiện tại đang Trống", "Thông báo");
                    return;
                }
            }

            int idBill = BillDAO.Instance.GetUnCheckBillIDByRoomID(room.ID);
            int disCount = (int)nmrDiscount.Value;
            int maxidBill = BillDAO.Instance.GetMaxIDBill();
            double totalPrice = float.Parse(txtToTalPriceTest.Text);

            double FinalTotalPrice = totalPrice - (totalPrice / 100) * disCount;

            string totalTime = txtAddTime.Text;
            float priceoldtime = float.Parse(txtTimeOldTest.Text);

            if (idBill != -1) //bill đã có
            {
                if (MessageBox.Show(string.Format("Bạn có chắc muốn thanh toán hóa đơn cho bàn {0}\n Tổng tiền - (Tổng Tiền / 100) x Giảm giá\n<=> {1} - ({1}/100) x {2} = {3}", room.Name, totalPrice, disCount, FinalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    if (lstvBill.Items.Count == 0)
                    {
                        checkListView();
                    }
                    BillDAO.Instance.CheckOut(idBill, disCount, totalTime, priceoldtime, (float)FinalTotalPrice);

                    ShowServiceBill(room.ID);
                    LoadRoom();
                    if (MessageBox.Show(string.Format("Bạn có muốn in hóa đơn không ?"), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    {
                        invoicePrintting f = new invoicePrintting();
                        f.IDBill = idBill;
                        f.ShowDialog();
                    }
                }
            }



            
            ShowTimeBill(room.ID);
            AddPriceOld(room.ID);
           
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {

            RoomDTO room = lstvBill.Tag as RoomDTO;
            if (room == null)
            {
                MessageBox.Show("Hãy chọn Phòng!!!");
                return;
            }

            int idBill = BillDAO.Instance.GetUnCheckBillIDByRoomID(room.ID);
            int Service = (cbbService.SelectedItem as ServiceDTO).ID;
            int countService = (int)nmrCountService.Value;
            int idRoom = (lstvBill.Tag as RoomDTO).ID;
            ServiceDTO service = ServiceDAO.Instance.GetServiceById(Service);
            RoomDTO Curentroom = RoomDAO.Instance.GetRoomBId(idRoom);
            if (idBill == -1)//không có bill nào hết ;
            {
                BillDAO.Instance.InsertBill(room.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), Service, countService, idRoom);
            }
            else //Bill đã tồn tại
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, Service, countService, idRoom);
            }
            ShowServiceBill(room.ID);
            TotalPrice();
            LoadRoom();
            ShowTimeBill(room.ID);

            log.Info("Đã thêm món |" + service.Name + "| vào |" + Curentroom.Name + "| Thành công! user: |" + LoginAccount.UserName+ "| - vào ngày: ");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

     
        }

        private void thêmMónToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            btnAddFood_Click(this, new EventArgs());
        }

        private void bắtĐầuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            btnStart_Click(this, new EventArgs());
        }

        private void chuyểnPhòngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            btnSwitchRoom_Click(this, new EventArgs());
        }

        private void thanhToánToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnCheckOut_Click(this, new EventArgs());
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void OpenInfroFormleft(Form childRoom)
        {
            if (currentEditRoom != null)
                currentEditRoom.Close();

            currentEditRoom = childRoom;
            childRoom.TopLevel = false;
            //childRoom.FormBorderStyle = FormBorderStyle.None;
            childRoom.Dock = DockStyle.Left;
            pnForm.Controls.Add(childRoom);

            childRoom.SendToBack();
            childRoom.Show();

        }
        private void OpenInfroFormRight(Form childRoom)
        {
            if (currentEditRoom != null)
                currentEditRoom.Close();

            currentEditRoom = childRoom;
            childRoom.TopLevel = false;
            //childRoom.FormBorderStyle = FormBorderStyle.None;
            childRoom.Dock = DockStyle.Right;
            pnForm.Controls.Add(childRoom);

            childRoom.SendToBack();
            childRoom.Show();

        }
        private void OpenInfroFormTop(Form childRoom)
        {
            if (currentEditRoom != null)
                currentEditRoom.Close();

            currentEditRoom = childRoom;
            childRoom.TopLevel = false;
            //childRoom.FormBorderStyle = FormBorderStyle.None;
            childRoom.Dock = DockStyle.Top;
            pnForm.Controls.Add(childRoom);

            childRoom.SendToBack();
            childRoom.Show();

        }
        private void OpenInfroFormBottom(Form childRoom)
        {
            if (currentEditRoom != null)
                currentEditRoom.Close();

            currentEditRoom = childRoom;
            childRoom.TopLevel = false;
            //childRoom.FormBorderStyle = FormBorderStyle.None;
            childRoom.Dock = DockStyle.Bottom;
            pnForm.Controls.Add(childRoom);

            childRoom.SendToBack();
            childRoom.Show();

        }
        private void OpenInfroFormFill(Form childRoom)
        {
            if (currentEditRoom != null)
                currentEditRoom.Close();

            currentEditRoom = childRoom;
            childRoom.TopLevel = false;
            //childRoom.FormBorderStyle = FormBorderStyle.None;
            childRoom.Dock = DockStyle.Fill;
            pnForm.Controls.Add(childRoom);

            childRoom.BringToFront();
            childRoom.Show();

        }
        private void OpenInfroFormDock(Form childRoom)
        {
            paneltop.Visible = true;
            if (currentEditRoomDock != null)
                currentEditRoomDock.Close();


            currentEditRoomDock = childRoom;
            childRoom.TopLevel = false;
            childRoom.FormBorderStyle = FormBorderStyle.None;
            childRoom.Dock = DockStyle.Fill;
            paneltop.Controls.Add(childRoom);

            childRoom.BringToFront();
            childRoom.Show();

        }
        private void thôngTinPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void mởVToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RoomDTO room = lstvBill.Tag as RoomDTO;

            if (room == null)
            {
                MessageBox.Show("Hãy chọn phòng", "Thông báo");
                return;
            }
            int id = (lstvBill.Tag as RoomDTO).ID;
            RoomDTO listroom = RoomDAO.Instance.GetRoomBId(id);
            RoomInfor f = new RoomInfor(listroom);
            OpenInfroFormleft(f);
        }

        private void mởBênPhảiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RoomDTO room = lstvBill.Tag as RoomDTO;

            if (room == null)
            {
                MessageBox.Show("Hãy chọn phòng", "Thông báo");
                return;
            }
            int id = (lstvBill.Tag as RoomDTO).ID;
            RoomDTO listroom = RoomDAO.Instance.GetRoomBId(id);
            RoomInfor f = new RoomInfor(listroom);
            OpenInfroFormRight(f);
        }

        private void mởToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomDTO room = lstvBill.Tag as RoomDTO;

            if (room == null)
            {
                MessageBox.Show("Hãy chọn phòng", "Thông báo");
                return;
            }
            int id = (lstvBill.Tag as RoomDTO).ID;
            RoomDTO listroom = RoomDAO.Instance.GetRoomBId(id);
            RoomInfor f = new RoomInfor(listroom) ;
            f.DockFill +=new EventHandler(F_DockFill);
            f.Dockleft += new EventHandler(F_Dockleft);
            f.Lockking += new EventHandler(F_LocKking);
            f.DockRight += new EventHandler(F_DockRight);
            f.ShowDialog();
        }

        private void F_DockRight(object sender, EventArgs e)
        {
            mởBênPhảiToolStripMenuItem_Click(this, new EventArgs());
        }

        private void F_LocKking(object sender, EventArgs e)
        {
            mởLênTrênToolStripMenuItem_Click(this, new EventArgs());
        }

        private void F_Dockleft(object sender, EventArgs e)
        {
            mởVToolStripMenuItem_Click(this, new EventArgs());
        }

        private void F_DockFill(object sender, EventArgs e)
        {
            mởFillToolStripMenuItem_Click(this, new EventArgs());
        }

        private void mởFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomDTO room = lstvBill.Tag as RoomDTO;

            if (room == null)
            {
                MessageBox.Show("Hãy chọn phòng", "Thông báo");
                return;
            }
            int id = (lstvBill.Tag as RoomDTO).ID;
            RoomDTO listroom = RoomDAO.Instance.GetRoomBId(id);
            RoomInfor f = new RoomInfor(listroom);
            
            OpenInfroFormFill(f);
        }

        private void mởLênTrênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomDTO room = lstvBill.Tag as RoomDTO;

            if (room == null)
            {
                MessageBox.Show("Hãy chọn phòng", "Thông báo");
                return;
            }
            int id = (lstvBill.Tag as RoomDTO).ID;
            RoomDTO listroom = RoomDAO.Instance.GetRoomBId(id);
            RoomInfor f = new RoomInfor(listroom);
            OpenInfroFormDock(f);
        }

        private void mởXuốngDướiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomDTO room = lstvBill.Tag as RoomDTO;

            if (room == null)
            {
                MessageBox.Show("Hãy chọn phòng", "Thông báo");
                return;
            }
            int id = (lstvBill.Tag as RoomDTO).ID;
            RoomDTO listroom = RoomDAO.Instance.GetRoomBId(id);
            RoomInfor f = new RoomInfor(listroom);
            OpenInfroFormBottom(f);
        }

        private void unDockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentEditRoomDock != null)
                currentEditRoomDock.Close();
            paneltop.Visible = false;
        }
    }
}
