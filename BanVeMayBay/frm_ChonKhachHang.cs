using BanVeMayBay.BUS;
using BanVeMayBay.DTO;
using BUS;
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
    public partial class frm_ChonKhachHang : Form
    {
        int i;
        public delegate void TruyenChoCha(string s1);
        public TruyenChoCha TruyenData;
        public frm_ChonKhachHang()
        {
            InitializeComponent();
        }

        private void dgvKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKH_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm_ChonKhachHang_Load(object sender, EventArgs e)
        {
            XemKhachHang();
        }
        public void XemKhachHang()
        {
            BanVeBUS bv = new BanVeBUS();
            //  NhanVienBUS nvBUS = new NhanVienBUS();
            DataTable dt = new DataTable();
            dt = bv.xemKhachHang();
            guna2DataGridView1.DataSource = dt;
            guna2DataGridView1.Columns[0].HeaderText = "CMND";
            guna2DataGridView1.Columns[1].HeaderText = "Tên khách hàng";
            guna2DataGridView1.Columns[2].HeaderText = "Giới tính";
            guna2DataGridView1.Columns[3].HeaderText = "Số điện thoại ";
            guna2DataGridView1.Columns[4].HeaderText = "Ngày sinh";
            guna2DataGridView1.Columns[5].HeaderText = "Địa chỉ";


            guna2DataGridView1.Columns[0].Width = 170;
            guna2DataGridView1.Columns[1].Width = 150;
            guna2DataGridView1.Columns[2].Width = 80;
            guna2DataGridView1.Columns[3].Width = 120;
            guna2DataGridView1.Columns[4].Width = 100;
            guna2DataGridView1.Columns[5].Width = 200;

            guna2DataGridView1.ColumnHeadersHeight = 40;

            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            guna2DataGridView1.AllowUserToResizeColumns = false;
            guna2DataGridView1.AllowUserToResizeRows = false;

            // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
            foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }

            guna2DataGridView1.AllowUserToAddRows = false;
            guna2DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public void TimKiemKhachHang()
        {
            BanVeBUS bv = new BanVeBUS();
            //  NhanVienBUS nvBUS = new NhanVienBUS();
            DataTable dt = new DataTable();
            dt = bv.xemKhachHang();
            guna2DataGridView1.DataSource = dt;
            guna2DataGridView1.Columns[0].HeaderText = "CMND";
            guna2DataGridView1.Columns[1].HeaderText = "Tên khách hàng";
            guna2DataGridView1.Columns[2].HeaderText = "Giới tính";
            guna2DataGridView1.Columns[3].HeaderText = "Số điện thoại ";
            guna2DataGridView1.Columns[4].HeaderText = "Ngày sinh";
            guna2DataGridView1.Columns[5].HeaderText = "Địa chỉ";


            guna2DataGridView1.Columns[0].Width = 170;
            guna2DataGridView1.Columns[1].Width = 150;
            guna2DataGridView1.Columns[2].Width = 80;
            guna2DataGridView1.Columns[3].Width = 120;
            guna2DataGridView1.Columns[4].Width = 100;
            guna2DataGridView1.Columns[5].Width = 200;

            guna2DataGridView1.ColumnHeadersHeight = 40;

            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            guna2DataGridView1.AllowUserToResizeColumns = false;
            guna2DataGridView1.AllowUserToResizeRows = false;

            // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
            foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }

            guna2DataGridView1.AllowUserToAddRows = false;
            guna2DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_CMND.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_TenKH.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_SDT.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
            cb_GioiTinh.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
            dtp_NgaySinh.Value = Convert.ToDateTime(guna2DataGridView1.CurrentRow.Cells[4].Value.ToString());
            txt_DiaChi.Text = guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

        private void btn_Chon_Click(object sender, EventArgs e)
        {
            i = guna2DataGridView1.CurrentRow.Index;
            string S1 = guna2DataGridView1[0, i].Value.ToString();
            TruyenData(S1);
            this.Close();
        }
        public void SearchKH()
        {
            KhachHangBUS nvBUS = new KhachHangBUS();
            DataTable dt1 = new DataTable();
            //    KhachHang bv1 = new KhachHang(txt_MaPhieuDC.Text, dtp_ThoiGianDat.Value, txt_SoGhe.Text, txt_HangGhe.Text, mahangve, txt_MaKH.Text, txt_MaHV.Text, txt_KhoiLuongHL.Text);
            dt1 = nvBUS.Search(txtSearch.Text);
            guna2DataGridView1.DataSource = dt1;

            guna2DataGridView1.Columns[0].HeaderText = "CMND";
            guna2DataGridView1.Columns[1].HeaderText = "Tên khách hàng";
            guna2DataGridView1.Columns[2].HeaderText = "Giới tính";
            guna2DataGridView1.Columns[3].HeaderText = "Số điện thoại ";
            guna2DataGridView1.Columns[4].HeaderText = "Ngày sinh";
            guna2DataGridView1.Columns[5].HeaderText = "Địa chỉ";


            guna2DataGridView1.Columns[0].Width = 170;
            guna2DataGridView1.Columns[1].Width = 150;
            guna2DataGridView1.Columns[2].Width = 80;
            guna2DataGridView1.Columns[3].Width = 120;
            guna2DataGridView1.Columns[4].Width = 100;
            guna2DataGridView1.Columns[5].Width = 200;

            guna2DataGridView1.ColumnHeadersHeight = 40;

            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            guna2DataGridView1.AllowUserToResizeColumns = false;
            guna2DataGridView1.AllowUserToResizeRows = false;

            // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
            foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }

            guna2DataGridView1.AllowUserToAddRows = false;
            guna2DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;


        }
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            SearchKH();
        }

        private void ThemKH()
        {
            KhachHangBUS nvBUS = new KhachHangBUS();
            KhachHang bv1 = new KhachHang(txt_CMND.Text, txt_TenKH.Text, txt_SDT.Text, cb_GioiTinh.Text, txt_DiaChi.Text, dtp_NgaySinh.Value);
            nvBUS.ThemKH(bv1);
            TimKiemKhachHang();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchKH();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            KhachHangBUS nvBUS = new KhachHangBUS();
            KhachHang bv1 = new KhachHang(txt_CMND.Text, txt_TenKH.Text, txt_SDT.Text, cb_GioiTinh.Text, txt_DiaChi.Text, dtp_NgaySinh.Value);
            nvBUS.XoaKH(bv1);
            TimKiemKhachHang();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            KhachHangBUS nvBUS = new KhachHangBUS();
            KhachHang bv1 = new KhachHang(txt_CMND.Text, txt_TenKH.Text, txt_SDT.Text, cb_GioiTinh.Text, txt_DiaChi.Text, dtp_NgaySinh.Value);
            nvBUS.SuaKH(bv1, txt_CMND.Text);
            TimKiemKhachHang();
        }

        private void btn_Them_Click_1(object sender, EventArgs e)
        {
            ThemKH();
        }
    }
}
