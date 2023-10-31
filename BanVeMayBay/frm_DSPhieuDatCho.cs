using BUS;
using DocumentFormat.OpenXml.Wordprocessing;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
   
    public partial class frm_DSPhieuDatCho : Form
    {
        public string maveold;
        public frm_DSPhieuDatCho()
        {
            InitializeComponent();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            SuaPhieu();
        }
        private void HienThiPhieuDatCho()
        {
            PhieuDatChoBUS bv = new PhieuDatChoBUS();
            DataTable dt = new DataTable();
            dt = bv.HienThiPhieuDatCho();

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
            dgv_PDC.Columns[0].HeaderText = "Mã Giao dịch";
            dgv_PDC.Columns[1].HeaderText = "Thời gian đặt";
            dgv_PDC.Columns[2].HeaderText = "Mã Chuyến Bay";
            dgv_PDC.Columns[3].HeaderText = "Mã Ghế";
            //dgv_PDC.Columns[6].HeaderText = "Mã Hạng vé";
            dgv_PDC.Columns[4].HeaderText = "CCCD";
            dgv_PDC.Columns[5].HeaderText = "Trạng thái";

            dgv_PDC.Columns[0].Width = 130;
            dgv_PDC.Columns[1].Width = 100;
            dgv_PDC.Columns[2].Width = 80;
            dgv_PDC.Columns[3].Width = 50;
            dgv_PDC.Columns[4].Width = 130;
            dgv_PDC.Columns[5].Width = 100;


            dgv_PDC.ColumnHeadersHeight = 40;

            dgv_PDC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_PDC.AllowUserToResizeColumns = false;
            dgv_PDC.AllowUserToResizeRows = false;

            // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
            foreach (DataGridViewColumn column in dgv_PDC.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }

            dgv_PDC.AllowUserToAddRows = false;
            dgv_PDC.AllowUserToResizeRows = false;
            dgv_PDC.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        public void SuaPhieu()
        {
            PhieuDatChoBUS pdc = new PhieuDatChoBUS();
            DanhSachPhieuDatCho bv1 = new DanhSachPhieuDatCho(txt_MaPhieu.Text, dtp_NgayDat.Value,  txt_MaChuyenBay.Text, txt_SoGhe.Text, txt_MaKH.Text);
            pdc.SuaPhieuDatCho(bv1);
            HienThiPhieuDatCho();
        }
        private void frm_DSPhieuDatCho_Load(object sender, EventArgs e)
        {
            HienThiPhieuDatCho();
            dtp_NgayDat.CustomFormat = "yyyy-MM-dd";
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
        private void dgv_PDC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void ThemPhieu()
        {
            string s = ranDomId();
            PhieuDatChoBUS pdc = new PhieuDatChoBUS();
            BanVeBUS nvBUS = new BanVeBUS();
            txt_MaPhieu.Text = s;
            DanhSachPhieuDatCho bv = new DanhSachPhieuDatCho(s, DateTime.Now, txt_SoGhe.Text, txt_HangGhe.Text, txt_MaChuyenBay.Text, txt_MaKH.Text, txt_MaHangVe.Text);
            pdc.themPhieuDatCho(bv);
            HienThiPhieuDatCho();
        }
        private void dgv_PDC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaPhieu.Text = dgv_PDC.CurrentRow.Cells[0].Value.ToString();
            txt_SoGhe.Text = dgv_PDC.CurrentRow.Cells[3].Value.ToString();
            txt_HangGhe.Text = dgv_PDC.CurrentRow.Cells[3].Value.ToString();
            txt_MaKH.Text = dgv_PDC.CurrentRow.Cells[4].Value.ToString();
            dtp_NgayDat.Value = Convert.ToDateTime(dgv_PDC.CurrentRow.Cells[1].Value.ToString());
            txt_MaChuyenBay.Text = dgv_PDC.CurrentRow.Cells[2].Value.ToString();


            //  machuyen = dgv_PDC.CurrentRow.Cells[4].Value.ToString().Trim();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            PhieuDatChoBUS bv1 = new PhieuDatChoBUS();
            bv1.XoaPhieuDatCho(txt_MaPhieu.Text);
            MessageBox.Show("Xóa thành công");
            HienThiPhieuDatCho();
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            SearchPhieuDatCho();
        }
        private void SearchPhieuDatCho()
        {
            PhieuDatChoBUS bv = new PhieuDatChoBUS();
            DataTable dt = new DataTable();
            dt = bv.SearchPhieuDatCho(txt_Search.Text);
            dgv_PDC.DataSource = dt;
            dgv_PDC.Columns[0].HeaderText = "Mã Phiếu";
            dgv_PDC.Columns[1].HeaderText = "Thời gian đặt";
            dgv_PDC.Columns[2].HeaderText = "Số ghế";
            dgv_PDC.Columns[3].HeaderText = "Hạng ghế";
            dgv_PDC.Columns[4].HeaderText = "Mã Chuyến Bay";
      
            dgv_PDC.Columns[0].Width = 170;
            dgv_PDC.Columns[1].Width = 150;
            dgv_PDC.Columns[2].Width = 200;
            dgv_PDC.Columns[3].Width = 100;
            dgv_PDC.Columns[4].Width = 100;

            dgv_PDC.ColumnHeadersHeight = 40;

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

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            SearchPhieuDatCho();
        }

        private void btn_ChonMKH_Click(object sender, EventArgs e)
        {
            frm_ChonKhachHang f = new frm_ChonKhachHang();
            f.TruyenData = new frm_ChonKhachHang.TruyenChoCha(LoadKhachHang);
            f.ShowDialog();
           
        }

        private void btn_chonsoghe_Click(object sender, EventArgs e)
        {
           // frm_NutChonHoTroBanVe f = new frm_NutChonHoTroBanVe();
         //   f.TruyenData = new frm_NutChonHoTroBanVe.TruyenChoCha(LoadData);
           // f.ShowDialog();
        }
        private void LoadData(string data, string data2)
        {
            txt_SoGhe.Text = data;
            string sample1 = data2;
            txt_HangGhe.Text = data2;
            string s2;
            s2 = string.Concat(txt_MaChuyenBay.Text.Trim(), sample1);
            txt_MaHangVe.Text = s2;
          //  s2.Replace(" ", "");
           // machuyenold = mahangve;
          //  txt_MaHV.Text = s2;


        }
        public void LoadKhachHang(string data)
        {
            txt_MaKH.Text = data;

        }

        private void txt_MaChuyenBay_TextChanged(object sender, EventArgs e)
        {
            // sua doi
            if(txt_MaChuyenBay.Text == " ")
            {
             
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                PhieuDatChoBUS pdc = new PhieuDatChoBUS();
                PhieuDatChoBUS pdc1 = new PhieuDatChoBUS();

                //string d2 = dtp_NgayBay.ToString();
                // dt1 = nhanVienBUS.TimKiemTuyenBay(cb_NoiDi.Text.ToString(), cb_NoiDen.Text.ToString());
                dt1 = pdc.LayChuyenBay(txt_MaChuyenBay.Text);
              string  s1 = dt1.Rows[0].ItemArray[7].ToString();
              DateTime giodi1 = Convert.ToDateTime(dt1.Rows[0].ItemArray[2].ToString());
              string giodi = giodi1.Hour.ToString() + ':' + giodi1.Minute.ToString() + ':' + giodi1.Second.ToString();
                dt3 = pdc1.TimKiemGhe(s1, Convert.ToDateTime(dt1.Rows[0].ItemArray[1].ToString()), giodi);
                Bientoancuc.soghe = Convert.ToString(dt3.Rows[0].ItemArray[2].ToString());
             //   mahangve = Convert.ToString(dt3.Rows[0].ItemArray[1].ToString());
              //  machuyenold = Convert.ToString(dt3.Rows[0].ItemArray[2].ToString());
                txt_HangGhe.Text = Bientoancuc.soghe;
            }    
         
        }
        private void LoadData1(string s1)
        {
            txt_MaChuyenBay.Text = s1;
        }
        private void btnMCB_Click(object sender, EventArgs e)
        {
            frm_ChonChuyenBay f = new frm_ChonChuyenBay();
            f.TruyenData = new frm_ChonChuyenBay.TruyenChoCha(LoadData1);
            f.ShowDialog();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ThemPhieu();
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }
    }
}
