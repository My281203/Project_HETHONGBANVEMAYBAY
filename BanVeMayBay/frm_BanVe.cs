
using BUS;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System.Diagnostics;
using System.Security.Cryptography;
//using Microsoft.Office.Interop.Excel;
//using Spire.Xls;
///using System.IO;


namespace BanVeMayBay
{
    public partial class frm_BanVe : Form
    {
        public string matuyen;
        public string s1;
        public string htoancuc;
        public string giodi;
        public string mahangve;
        public string machuyen, machuyenold;
       // public string soghe;
        public DateTime giodi1;
        public frm_BanVe()
        {
            InitializeComponent();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frm_NutChonHoTroBanVe f = new  frm_NutChonHoTroBanVe();
            f.TruyenData = new frm_NutChonHoTroBanVe.TruyenChoCha(LoadData);
            f.ShowDialog();
        }
        string giatien;
        private void LoadData(string data,string data2,string data3)
        {
            txt_SoGhe.Text = data;
           // string sample1 = data2;
            txt_HangGhe.Text = data2;
            giatien = data3;
           // string s2;
           // s2 = string.Concat(mahangve,sample1);
           // s2.Replace(" ","");
           // machuyenold = mahangve;
           // txt_MaHV.Text= s2;          
        }
        private void XemViTri1()
        {
            BanVeBUS bvBUS = new BanVeBUS();
            DataTable dt = new DataTable();
            dt = bvBUS.HienThi();
            cb_NoiDen.DataSource = dt;
            cb_NoiDen.DisplayMember = "ViTri";
           
        }
        private void XemViTri2()
        {
            BanVeBUS bvBUS = new BanVeBUS();
            DataTable dt = new DataTable();
            dt = bvBUS.HienThi();
            cb_NoiDi.DataSource = dt;
            cb_NoiDi.DisplayMember = "ViTri";

        }        
        public void HienThiPhieuDatCho()
        {
            BanVeBUS bv = new BanVeBUS();
            DataTable dt = bv.HienThiPhieuDatCho();

            if (dt.Columns.Contains("is_deleted"))
            {
                // Kiểm tra xem cột "Trạng thái" đã tồn tại trong DataTable hay chưa
                if (!dt.Columns.Contains("Trạng thái"))
                {
                    // Nếu cột "Trạng thái" chưa tồn tại, thêm cột mới vào DataTable
                    dt.Columns.Add("Trạng Thái", typeof(string));
                }

                // Lặp qua từng hàng trong DataTable
                foreach (DataRow row in dt.Rows)
                {
                    // Lấy giá trị boolean từ cột "is_deleted" trong hàng hiện tại
                    bool isDeleted = (bool)row["is_deleted"];

                    // Xử lý giá trị boolean và gán giá trị tương ứng vào cột "Trạng thái"
                    if (isDeleted == false)
                    {
                        row["Trạng Thái"] = "True";
                    }
                    else
                    {
                        row["Trạng Thái"] = "False";
                    }
                }
            }
            dt.Columns.Remove("is_deleted");
            dgv_PDC.DataSource = dt;
            dgv_PDC.Columns[0].HeaderText = "Mã Giao Dịch";
            dgv_PDC.Columns[1].HeaderText = "Thời Gian Đặt";
            dgv_PDC.Columns[2].HeaderText = "Mã Chuyến Bay";
            dgv_PDC.Columns[3].HeaderText = "Mã Ghế";
            dgv_PDC.Columns[4].HeaderText = "CCCD";
            dgv_PDC.Columns[5].HeaderText = "Trạng Thái";

            dgv_PDC.Columns[0].Width = 100;
            dgv_PDC.Columns[1].Width = 100;
            dgv_PDC.Columns[2].Width = 120;
            dgv_PDC.Columns[3].Width = 80;
            dgv_PDC.Columns[4].Width = 80;
            dgv_PDC.Columns[5].Width = 130;

            dgv_PDC.ColumnHeadersHeight = 50;

            dgv_PDC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_PDC.AllowUserToResizeColumns = false;
            dgv_PDC.AllowUserToResizeRows = false;

            // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
            foreach (DataGridViewColumn column in dgv_PDC.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }

            dgv_PDC.AllowUserToAddRows = false;
            dgv_PDC.EditMode = DataGridViewEditMode.EditProgrammatically;


        }
        private void frm_BanVe_Load(object sender, EventArgs e)
        {
            Bientoancuc.mamaybay = "";
            Bientoancuc.machuyenbay = "";
            Bientoancuc.giaghe = "";
            Bientoancuc.matuyenbay = "";
            dtp_NgayBay.CustomFormat = "yyyy-MM-dd";
            dtp_NgayBay.Value = DateTime.Now;
            dtp_ThoiGianDat.Value = DateTime.Now;

            HienThiPhieuDatCho();
            HienThiPhieuHoaDon();
            XemViTri1();
            XemViTri2();    
        }      
        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void ThemPhieu()
        {

            BanVeBUS nvBUS = new BanVeBUS();
            BanVe bv1 = new BanVe(DateTime.Now, Bientoancuc.machuyenbay,txt_SoGhe.Text,txt_MaKH.Text,"0");
            nvBUS.themPhieuDatCho(bv1);
            HienThiPhieuDatCho();
        }
            
    

        private void btn_ThemSB_Click(object sender, EventArgs e)
        {
            ThemPhieu();
            DialogResult result = MessageBox.Show("Vui lòng thanh toán hóa đơn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                frm_TTGDtoHD frm_TTGDtoHD = new frm_TTGDtoHD();
                frm_TTGDtoHD.ShowDialog();
                
            }
            else if (result == DialogResult.No)
            {
                // Xử lý khi người dùng bấm vào nút "No" ở đây
                // ...

                BanVeBUS nvBUS = new BanVeBUS();
                DataTable dt = new DataTable();
         
                dt = nvBUS.layTTGDtoHoaDon();

            
                string magiaodich = dt.Rows[0].ItemArray[0].ToString();
               
                PhieuDatChoBUS ttgd = new PhieuDatChoBUS();
                ttgd.XoaPhieuDatCho(magiaodich);
                MessageBox.Show("Thông tin giao dịch bị xóa ");
            }


        }

        private void cb_NoiDi_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(cb_NoiDi.Text != " " && cb_NoiDi.Text.ToString() != cb_NoiDen.Text.ToString())
            {
                BanVeBUS nhanVienBUS = new BanVeBUS();
                BanVeBUS nv2 = new BanVeBUS();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                string d2 = dtp_NgayBay.ToString();
                try
                {
                    dt1 = nhanVienBUS.TimKiemTuyenBay(cb_NoiDi.Text.ToString(), cb_NoiDen.Text.ToString());
                    if (dt1.Rows.Count > 0)
                    {
                        s1 = dt1.Rows[0].ItemArray[0].ToString();
                    }
                    dt2 = nv2.TimKiemKhungGioBay2(s1, dtp_NgayBay.Value);

                    foreach (DataRow row in dt2.Rows)
                    {
                        DateTime ngayBay = (DateTime)row["NgayBay"];
                        string ngayBayFormatted = ngayBay.ToShortDateString();
                        row["NgayBay"] = ngayBayFormatted;
                    }

                    dt2.Columns.Add("GioKhoiHanhNgayBay", typeof(string), "GioKhoiHanh + ' ' + NgayBay");

                    cb_ThoiGianKH.DataSource = dt2;
                    cb_ThoiGianKH.DisplayMember = "GioKhoiHanhNgayBay";

                }
                catch
                {

                }
              
            }    
        }
        private void cb_NoiDen_SelectedIndexChanged(object sender, EventArgs e)
        {
      

        }
        public void SuaPhieu()
        {           
            BanVeBUS nvBUS = new BanVeBUS();
            BanVe bv1 = new BanVe(txt_MaPhieuDC.Text,DateTime.Now,machuyen,txt_SoGhe.Text,txt_MaKH.Text);
            nvBUS.SuaPhieuDatCho(bv1);
            HienThiPhieuDatCho();          
        }
        private void btn_SuaSB_Click(object sender, EventArgs e)
        {          
            SuaPhieu();
        }

        private void dtp_NgayBay_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void cb_ThoiGianKH_SelectedValueChanged(object sender, EventArgs e)
        {
            htoancuc = cb_ThoiGianKH.Text.ToString();           
        }

        private void btn_SuaTB_Click(object sender, EventArgs e)
        {
           string maNV = "NV001";
           BanVeBUS bv1 = new BanVeBUS();
           BanVe bv = new BanVe(txt_MaHoaDon.Text,dtp_NgayTao.Value, txt_ThanhTien.Text, txt_MaKhachHang.Text, txt_MaNV.Text, maNV, maNV, maNV);
           Debug.WriteLine(dtp_NgayTao.Value);
           bv1.CapNhatHoaDon(bv);
           HienThiPhieuHoaDon();
        }
        private void btn_TimKiemSB_Click(object sender, EventArgs e)
        {
            SearchPhieuDatCho();
        }
    

        private void cb_ThoiGianKH_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void cb_NoiDi_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_NoiDi.Text != " " && cb_NoiDi.Text.ToString() != cb_NoiDen.Text.ToString())
            {
                BanVeBUS nhanVienBUS = new BanVeBUS();
                BanVeBUS nv2 = new BanVeBUS();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                string d2 = dtp_NgayBay.ToString();
                try
                {
                    dt1 = nhanVienBUS.TimKiemTuyenBay(cb_NoiDi.Text.ToString(), cb_NoiDen.Text.ToString());
                    s1 = dt1.Rows[0].ItemArray[0].ToString();
                    dt2 = nv2.TimKiemKhungGioBay2(s1, dtp_NgayBay.Value);
                    cb_ThoiGianKH.DataSource = dt2;
                    cb_ThoiGianKH.DisplayMember = "GioKhoiHanh";
                }
                catch
                {
                    MessageBox.Show("Không tìm thấy");
                }
             
            }
        }

        private void cb_NoiDen_SelectedValueChanged(object sender, EventArgs e)
        {
           /* if (cb_NoiDen.Text != " " && cb_NoiDi.Text.ToString() != cb_NoiDen.Text.ToString())
           // {
            //    BanVeBUS nhanVienBUS = new BanVeBUS();
           ///    BanVeBUS nv2 = new BanVeBUS();
           //     DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                string d2 = dtp_NgayBay.ToString();
                dt1 = nhanVienBUS.TimKiemTuyenBay(cb_NoiDi.Text.ToString(), cb_NoiDen.Text.ToString());
                s1 = dt1.Rows[0].ItemArray[0].ToString();
                dt2 = nv2.TimKiemKhungGioBay2(s1, dtp_NgayBay.Value);
                cb_ThoiGianKH.DataSource = dt2;
                cb_ThoiGianKH.DisplayMember = "GioKhoiHanh";
            }
           */
        
        }

        public void LoadKhachHang(string data)
        {
            txt_MaKH.Text = data;

        }
        private void btn_ChonKH_Click(object sender, EventArgs e)
        {
            frm_ChonKhachHang f = new frm_ChonKhachHang();
            f.TruyenData = new frm_ChonKhachHang.TruyenChoCha(LoadKhachHang);
            f.ShowDialog();
        }

        private void dgv_PDC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgv_PDC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaPhieuDC.Text = dgv_PDC.CurrentRow.Cells[0].Value.ToString();
            dtp_ThoiGianDat.Text = dgv_PDC.CurrentRow.Cells[1].Value.ToString();
            txt_SoGhe.Text = dgv_PDC.CurrentRow.Cells[3].Value.ToString();


            txt_HangGhe.Text = dgv_PDC.CurrentRow.Cells[3].Value.ToString();
           // txt_MaKhachHang.Text = dgv_PDC.CurrentRow.Cells[5].Value.ToString();
            txt_MaKH.Text = dgv_PDC.CurrentRow.Cells[4].Value.ToString();
            dtp_ThoiGianDat.Value = Convert.ToDateTime(dgv_PDC.CurrentRow.Cells[1].Value.ToString());
        
            //txt_MaHV.Text = dgv_PDC.CurrentRow.Cells[6].Value.ToString();
            string s = dgv_PDC.CurrentRow.Cells[5].Value.ToString();
       
            
            string s1 = dgv_PDC.CurrentRow.Cells[2].Value.ToString().Trim();
            //string machuyen1 = machuyen.Substring(0, machuyen.Length - 4);
            BanVeBUS bv = new BanVeBUS();
            ChuyenBayBUS cb = new ChuyenBayBUS();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            dt4 = cb.TimCB(machuyen);

            //dtp_NgayBay.Value = Convert.ToDateTime(dt4.Rows[0].ItemArray[1].ToString());
            dt1 = bv.LayNguocHBay(s1);

            cb_ThoiGianKH.DataSource = dt1;
            cb_ThoiGianKH.DisplayMember = "GioKhoiHanh";
            Bientoancuc.mamaybay= dt1.Rows[0].ItemArray[4].ToString().Trim();
            Bientoancuc.matuyenbay = dt1.Rows[0].ItemArray[1].ToString().Trim();
            Bientoancuc.ngaybay = Convert.ToDateTime(dt1.Rows[0].ItemArray[5].ToString());
            Debug.WriteLine(Bientoancuc.ngaybay);
            Debug.WriteLine(Bientoancuc.mamaybay);
            Debug.WriteLine(Bientoancuc.matuyenbay);
            string noidi1 = dt1.Rows[0].ItemArray[2].ToString();
            string noiden = dt1.Rows[0].ItemArray[3].ToString();
            dt2 = bv.LayNguocTenDenVaDI(noidi1);
            dt3 = bv.LayNguocTenDenVaDI(noiden);
            cb_NoiDi.Text = dt2.Rows[0].ItemArray[0].ToString();
            cb_NoiDen.Text = dt3.Rows[0].ItemArray[0].ToString();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchPhieuDatCho();
        }
        private void SearchPhieuDatCho()
        {
            BanVeBUS bv = new BanVeBUS();
            DataTable dt = bv.SearchPhieuDatCho(txtSearch.Text);

            // Kiểm tra xem cột "is_deleted" đã tồn tại trong DataTable
            if (dt.Columns.Contains("is_deleted"))
            {
                // Kiểm tra xem cột "Trạng thái" đã tồn tại trong DataTable hay chưa
                if (!dt.Columns.Contains("Trạng thái"))
                {
                    // Nếu cột "Trạng thái" chưa tồn tại, thêm cột mới vào DataTable
                    dt.Columns.Add("Trạng Thái", typeof(string));
                }

                // Lặp qua từng hàng trong DataTable
                foreach (DataRow row in dt.Rows)
                {
                    // Lấy giá trị boolean từ cột "is_deleted" trong hàng hiện tại
                    bool isDeleted = (bool)row["is_deleted"];

                    // Xử lý giá trị boolean và gán giá trị tương ứng vào cột "Trạng thái"
                    row["Trạng Thái"] = isDeleted ? "False" : "True";
                }
            }

            dgv_PDC.AutoGenerateColumns = false; // Ngăn tự động tạo cột

            if (dt.Rows.Count > 0)
            {
                dgv_PDC.DataSource = dt;

                // Đặt tên và kích thước cột
                dgv_PDC.Columns[0].HeaderText = "Mã Giao Dịch";
                dgv_PDC.Columns[1].HeaderText = "Thời Gian Đặt";
                dgv_PDC.Columns[2].HeaderText = "Mã Chuyến Bay";
                dgv_PDC.Columns[3].HeaderText = "Mã Ghế";
                dgv_PDC.Columns[4].HeaderText = "CCCD";
                dgv_PDC.Columns[5].HeaderText = "Trạng Thái";

                dgv_PDC.Columns[0].Width = 100;
                dgv_PDC.Columns[1].Width = 100;
                dgv_PDC.Columns[2].Width = 120;
                dgv_PDC.Columns[3].Width = 80;
                dgv_PDC.Columns[4].Width = 80;
                dgv_PDC.Columns[5].Width = 130;

                // Ngăn chặn thay đổi kích thước cột
                dgv_PDC.AllowUserToResizeColumns = false;

                dgv_PDC.ColumnHeadersHeight = 50;
                dgv_PDC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgv_PDC.AllowUserToResizeRows = false;

                // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
                foreach (DataGridViewColumn column in dgv_PDC.Columns)
                {
                    column.Resizable = DataGridViewTriState.False;
                }

                dgv_PDC.AllowUserToAddRows = false;
                dgv_PDC.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }

        private void HienThiPhieuHoaDon()
        {
            BanVeBUS bv = new BanVeBUS();
            DataTable dt = new DataTable();
            dt = bv.HienThiPhieuHoaDon();

            // Tạo một cột kiểu dữ liệu DataGridViewTextBoxColumn


            // Thêm cột vào DataGridView
            if (dt.Columns.Contains("is_deleted"))
            {
                // Kiểm tra xem cột "Trạng thái" đã tồn tại trong DataTable hay chưa
                if (!dt.Columns.Contains("Trạng Thái"))
                {
                    // Nếu cột "Trạng thái" chưa tồn tại, thêm cột mới vào DataTable
                    dt.Columns.Add("Trạng Thái", typeof(string));
                }

                // Lặp qua từng hàng trong DataTable
                foreach (DataRow row in dt.Rows)
                {
                    // Lấy giá trị boolean từ cột "is_deleted" trong hàng hiện tại
                    bool isDeleted = (bool)row["is_deleted"];

                    // Xử lý giá trị boolean và gán giá trị tương ứng vào cột "Trạng thái"
                    if (isDeleted == false)
                    {
                        row["Trạng Thái"] = "True";
                    }
                    else
                    {
                        row["Trạng Thái"] = "False";
                    }
                }
            }

            dt.Columns.Remove("is_deleted");
            dgv_PHD.DataSource = dt;
            dgv_PHD.Columns[0].HeaderText = "Mã Phiếu Hóa Đơn";
            dgv_PHD.Columns[1].HeaderText = "Mã Phiếu Giao Dịch ";
            dgv_PHD.Columns[2].HeaderText = "Ngày Lập";
            dgv_PHD.Columns[3].HeaderText = "Thành Tiền";
     
            dgv_PHD.Columns[4].HeaderText = "CCCD";
            dgv_PHD.Columns[5].HeaderText = "Mã Nhân Viên";
            dgv_PHD.Columns[6].HeaderText = "Trạng Thái";

            dgv_PHD.Columns[0].Width = 200;
            dgv_PHD.Columns[1].Width = 200;
            dgv_PHD.Columns[2].Width = 100;
            dgv_PHD.Columns[3].Width = 120;
            dgv_PHD.Columns[4].Width = 100;
            dgv_PHD.Columns[5].Width = 140;
            dgv_PHD.Columns[6].Width = 140;

            dgv_PHD.ColumnHeadersHeight = 40;

            dgv_PHD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_PHD.AllowUserToResizeColumns = false;
            dgv_PHD.AllowUserToResizeRows = false;

            // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
            foreach (DataGridViewColumn column in dgv_PHD.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }

            dgv_PHD.AllowUserToAddRows = false;
            dgv_PHD.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void  LoadPhieuDatCho(string s)
        {
            txt_MaPhieuDatCho.Text = s;
            BanVeBUS bv = new BanVeBUS();
            BanVeBUS bv1 = new BanVeBUS();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            dt1 = bv.LayThongTinTruyVanChoHoaDon(txt_MaPhieuDatCho.Text);
            string s1 = dt1.Rows[0].ItemArray[2].ToString().Trim();
            txt_MaKhachHang.Text = dt1.Rows[0].ItemArray[1].ToString();
            dt2 = bv1.LayThongTinGiaTienHoaDon(s1);
            txt_ThanhTien.Text = dt2.Rows[0].ItemArray[0].ToString();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            frm_ChonHoaDoncs f = new frm_ChonHoaDoncs();
            f.TruyenData = new frm_ChonHoaDoncs.TruyenChoCha(LoadPhieuDatCho);
            f.ShowDialog();
        }

        private void btn_ThemTB_Click(object sender, EventArgs e)
        {
            string s = ranDomId();
            txt_MaHoaDon.Text = s;
           // BanVeBUS bv1 = new BanVeBUS();
          //  BanVe bv = new BanVe(dtp_NgayTao.Value,txt_ThanhTien.Text,txt_MaKhachHang.Text, txt_MaNV.Text);
            //bv1.ThemHoaDon(bv);
            
            HienThiPhieuHoaDon();
            MessageBox.Show("Vui lòng tạo vé");


        }

        private void dgv_PHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           //txt_MaPhieuDatCho.Text = dgv_PHD.CurrentRow.Cells[0].Value.ToString();
           txt_MaHoaDon.Text = dgv_PHD.CurrentRow.Cells[0].Value.ToString();
           txt_ThanhTien.Text = dgv_PHD.CurrentRow.Cells[3].Value.ToString();
            dtp_NgayTao.Value = Convert.ToDateTime(dgv_PHD.CurrentRow.Cells[2].Value);
            txt_MaPhieuDatCho.Text = dgv_PHD.CurrentRow.Cells[1].Value.ToString();
            txt_MaNV.Text = dgv_PHD.CurrentRow.Cells[4].Value.ToString();
            txt_MaKhachHang.Text = dgv_PHD.CurrentRow.Cells[5].Value.ToString();

        }
     /*  public void InHoaDon()
        {
            string filePath = "";
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();

            // chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

            // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
            }

            // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                return;
            }

            Microsoft.Office.Interop.Excel.Application exApp;
            Microsoft.Office.Interop.Excel.Workbook workBook;
            Microsoft.Office.Interop.Excel.Worksheet workSheet;
            try
            {
                //Tạo đối tượng COM.
                exApp = new Microsoft.Office.Interop.Excel.Application();
                exApp.Visible = false;
                exApp.DisplayAlerts = false;
                //workBook = exApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);

                workBook = exApp.Workbooks.Add(Type.Missing);
                workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets["Sheet1"];

                workSheet.Name = "Hóa đơn đặt vé";
                workSheet.Cells.Style.Font.Size = 13;
                workSheet.Cells.Style.Font.Name = "Calibri";

                workSheet.Cells[1, 1].Value = "Hệ thống Bán vé máy bay  ";
                workSheet.Cells[1, 1].Font.Size = 14;
                workSheet.Cells[1, 1].Font.Bold = true;
                workSheet.Cells[2, 1].Value = "Địa Chỉ: Thủ Đức, Hồ Chí Minh";
                workSheet.Cells[3, 1].Value = "Điện thoại: 190012345";
                workSheet.Cells[4, 1].Value = "HÓA ĐƠN BÁN HÀNG";
                workSheet.Cells[4, 1].Font.Size = 16;
                workSheet.Cells[4, 1].Font.Bold = true;

              /*  for (int i = 1; i < dgv_PDC.ColumnCount; i++)
                {
                    workSheet.Cells[12, i] = dgv_PDC.Columns[i].HeaderText;
                    workSheet.Cells[12, i].Font.Bold = true;
                    workSheet.Cells[12, i].ColumnWidth = 10;
                    workSheet.Cells[12, i].Borders.LineStyle = true;
                }
              

              // int lasti = 0, lastj = 0;

                for (int i = 0; i < dgv_PDC.RowCount; i++)
                {
                    if (dgv_PDC.Rows[i].Cells[0].Value.ToString() == txt_MaPhieuDatCho.Text)
                    {
                        workSheet.Cells[10, 1] = "Ngày đặt: " + dgv_PDC.Rows[i].Cells[2].Value.ToString();
                        workSheet.Cells[11, 1] = "Mã Phiếu đặt chỗ : " + dgv_PHD.Rows[i].Cells[1].Value.ToString();
                        workSheet.Cells[12, 1] = "Khách hàng: " + dgv_PHD.Rows[i].Cells[3].Value.ToString();
                        workSheet.Cells[13, 1] = "Thu ngân: " + dgv_PHD.Rows[i].Cells[2].Value.ToString();
                        //   workSheet.Cells[10, 1] = "Mã Voucher: " + dgvDH.Rows[i].Cells[6].Value.ToString();
                        //  workSheet.Cells[lasti + 14, lastj] = dgvDH.Rows[i].Cells[7].Value.ToString();
                    }
                }


         
           //    workSheet.Cells[lasti + 14, lastj - 1] = "Tổng tiền:";
                for (int i = 0; i < dgv_PHD.RowCount; i++)
                {
                    if (dgv_PHD.Rows[i].Cells[0].Value.ToString() == txt_MaHoaDon.Text)
                    {
                        workSheet.Cells[6, 1] = "Mã hóa đơn: " + dgv_PHD.Rows[i].Cells[0].Value.ToString();
                        workSheet.Cells[7, 1] = "Mã Phiếu đặt chỗ : " + dgv_PHD.Rows[i].Cells[1].Value.ToString();
                        workSheet.Cells[8, 1] = "Mã Khách hàng: " + dgv_PHD.Rows[i].Cells[3].Value.ToString();
                        workSheet.Cells[9, 1] = "Mã Nhân viên: " + dgv_PHD.Rows[i].Cells[2].Value.ToString();
                     //   workSheet.Cells[10, 1] = "Mã Voucher: " + dgvDH.Rows[i].Cells[6].Value.ToString();
                      //  workSheet.Cells[lasti + 14, lastj] = dgvDH.Rows[i].Cells[7].Value.ToString();
                    }
                }
                workBook.Activate();
                workBook.SaveAs(filePath);
                workBook.Save();
                workBook.Close();
                exApp.Quit();
                bool flag = SaveAsPdf(filePath);
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workBook = null;
                workSheet = null;
            }
        }
        private bool SaveAsPdf(string saveAsLocation)
        {
            string saveas = (saveAsLocation.Split('.')[0]) + ".pdf";
            try
            {
                Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();
                workbook.LoadFromFile(saveAsLocation);

                //Save the document in PDF format
                workbook.SaveToFile(saveas, Spire.Xls.FileFormat.PDF);
                System.Diagnostics.Process.Start(saveas);
                Path.GetTempPath();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        */  

        private void btn_InHoaDon_Click(object sender, EventArgs e)
        {
           // InHoaDon();
        }

        private void txt_SoGhe_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_HangGhe_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_PHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnChonNoiKhoiHanh_Click(object sender, EventArgs e)
        {
            BanVeBUS nhanVienBUS = new BanVeBUS();
            BanVeBUS nv2 = new BanVeBUS();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            string d2 = dtp_NgayBay.ToString();
           
                dt1 = nhanVienBUS.TimKiemTuyenBay(cb_NoiDi.Text.ToString(), cb_NoiDen.Text.ToString());
                if (dt1.Rows.Count > 0)
                {
                    s1 = dt1.Rows[0].ItemArray[0].ToString();
                    Bientoancuc.matuyenbay = s1;
                }

      
        


            Bientoancuc.ngaybay = dtp_NgayBay.Value;
            Bientoancuc.matuyenbay = s1;
            frm_ChonChuyenBayBV f = new frm_ChonChuyenBayBV();
            f.TruyenData1 = new frm_ChonChuyenBayBV.TruyenChoCha1(LoadData1);
            f.ShowDialog();
            
        }
        string machuyenbay;
        string tuyenbay, mamaybay;

        private void btnTaoVe_Click(object sender, EventArgs e)
        {
            HangVe hv = new HangVe();
            HangVeBUS hvBUS = new HangVeBUS();        
            hv = new HangVe(DateTime.Today, txt_MaHoaDon.Text,"0","0");
            hvBUS.ThemHV(hv);
            MessageBox.Show("Thêm hạng vé mới thành công!");           
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_MaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadData1(string s1, string s2, string s3,string s4)
        {
            machuyen = s1;
            tuyenbay = s2;
            mamaybay = s3;
            // cb_ThoiGianKH.SelectedItem = s4.ToString();
            cb_ThoiGianKH.DataSource = null;

            cb_ThoiGianKH.Items.Add(s4);
            Bientoancuc.machuyenbay = s1;
            Bientoancuc.mamaybay = mamaybay;
            // Đặt giá trị đã chọn cho ComboBox
            cb_ThoiGianKH.SelectedItem = s4;
            Debug.WriteLine(machuyenbay);
            Debug.WriteLine(tuyenbay);
            Debug.WriteLine(s4);
           // cb_ThoiGianKH.Text = s4.ToString();
            

        }
        public string ranDomId()
        {
            string id = "";
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                if (random.Next(0, 2) == 1)
                {
                    int num = random.Next(65, 91);
                    id += (char)num;
                }
                else
                {
                    int num = random.Next(48, 58);
                    id += (char)num;
                }
            }
            return id;

        }
    }
}
