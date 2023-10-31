using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using System.Windows.Forms;
using System.Data.SqlClient;

namespace BanVeMayBay
{
    public partial class frm_NhanVien : Form
    {
        public frm_NhanVien()
        {
            InitializeComponent();
        }
        private string RandomString() {
            string str = "NV-";
            Random r = new Random();
            for (int i = 0; i < 7; i++) {
                str += r.Next(1, 9);
            }
            return str;
        }
        private void Clear()
        {
            txt_MaNV.Text = RandomString();
            txt_Search.Text = "";
            txt_CMND.Text = "";
            txt_DiaChi.Text = "";
            txt_SDT.Text = "";
            txt_TenNV.Text = "";
            cb_GioiTinh.SelectedIndex = 0;
            dtp_NgaySinh.Value = DateTime.Today;
        }
        private void XemNhanVien()
        {
            NhanVienBUS nvBUS = new NhanVienBUS();
            DataTable dt = new DataTable();
            dt = nvBUS.HienThi();
            dgvNV.DataSource = dt;
            dgvNV.Columns[0].HeaderText = "Mã nhân viên";
            dgvNV.Columns[1].HeaderText = "CMND";
            dgvNV.Columns[2].HeaderText = "Tên nhân viên";
            dgvNV.Columns[3].HeaderText = "Ngày sinh";
            dgvNV.Columns[4].HeaderText = "Giới tính";
            dgvNV.Columns[5].HeaderText = "Số điện thoại";
            dgvNV.Columns[6].HeaderText = "Địa chỉ";

            dgvNV.Columns[0].Width = 140;
            dgvNV.Columns[1].Width = 170;
            dgvNV.Columns[2].Width = 200;
            dgvNV.Columns[3].Width = 150;
            dgvNV.Columns[4].Width = 120;
            dgvNV.Columns[5].Width = 150;
            dgvNV.Columns[6].Width = 270;
            dgvNV.ColumnHeadersHeight = 40;

            dgvNV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvNV.AllowUserToResizeColumns = false;
            dgvNV.AllowUserToResizeRows = false;

            // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
            foreach (DataGridViewColumn column in dgvNV.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }
            dgvNV.AllowUserToAddRows = false;
            dgvNV.EditMode = DataGridViewEditMode.EditProgrammatically;
        }


        private void frm_NhanVien_Load(object sender, EventArgs e)
        {
            Clear();
            XemNhanVien();
            Bientoancuc.mamaybay = "";
            Bientoancuc.machuyenbay = "";
            Bientoancuc.giaghe = "";
            Bientoancuc.matuyenbay = "";
        }
        
        private void btn_Them_Click(object sender, EventArgs e)
        {
            NhanVienBUS nvBUS = new NhanVienBUS();
            NhanVien nv = new NhanVien(txt_CMND.Text, txt_TenNV.Text, cb_GioiTinh.Text, txt_SDT.Text, txt_DiaChi.Text, dtp_NgaySinh.Value);
            nvBUS.ThemNV(nv);
            frm_NhanVien_Load(sender,e);

        }

        private void txt_CMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            NhanVienBUS nhanVienBUS = new NhanVienBUS();
            NhanVien nv = new NhanVien();
            nv.Manv = dgvNV.CurrentRow.Cells[0].Value.ToString();
            nhanVienBUS.XoaNV(nv.Manv);
            XemNhanVien();
        }

        private void txt_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaNV.Text = dgvNV.CurrentRow.Cells[0].Value.ToString();
            txt_CMND.Text = dgvNV.CurrentRow.Cells[1].Value.ToString();
            txt_TenNV.Text = dgvNV.CurrentRow.Cells[2].Value.ToString();
            cb_GioiTinh.Text = dgvNV.CurrentRow.Cells[4].Value.ToString();
            dtp_NgaySinh.Value = Convert.ToDateTime(dgvNV.CurrentRow.Cells[3].Value.ToString());
            txt_SDT.Text = dgvNV.CurrentRow.Cells[5].Value.ToString();
            txt_DiaChi.Text = dgvNV.CurrentRow.Cells[6].Value.ToString();
        }
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            NhanVienBUS nhanVienBUS = new NhanVienBUS();
            NhanVien nv = new NhanVien(txt_MaNV.Text, txt_CMND.Text, txt_TenNV.Text, cb_GioiTinh.Text, txt_SDT.Text, txt_DiaChi.Text,Convert.ToDateTime(dtp_NgaySinh.Value));
            nhanVienBUS.SuaNV(nv);
            XemNhanVien();
           // frm_NhanVien_Load(sender, e);
        }

        private void TimKiemNV()
        {
            NhanVienBUS nhanVienBUS = new NhanVienBUS();
            DataTable dt = new DataTable();
            dt = nhanVienBUS.Search(txt_Search.Text); ;
            dgvNV.DataSource = dt;
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if(txt_Search.Text == "")
            {
                XemNhanVien();
            }
            else
            {
                TimKiemNV();
            }
        }
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void pnl_ThongTinNV_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
