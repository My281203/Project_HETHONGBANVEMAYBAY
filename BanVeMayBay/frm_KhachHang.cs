using BanVeMayBay.BUS;
using BanVeMayBay.DTO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
    public partial class frm_KhachHang : Form
    {
        private string str_cmnd;
        public frm_KhachHang()
        {
            InitializeComponent();
        }
  
        private void XemKhachHang() 
        {
            KhachHangBUS khachHangBUS = new KhachHangBUS();
            dgvKH.DataSource = khachHangBUS.HienThi();
            dgvKH.Columns[0].HeaderText = "CMND";
            dgvKH.Columns[1].HeaderText = "Họ Tên KH";
            dgvKH.Columns[2].HeaderText = "Giới tính";
            dgvKH.Columns[3].HeaderText = "Số điện thoại";
            dgvKH.Columns[4].HeaderText = "Ngày Sinh";
            dgvKH.Columns[5].HeaderText = "Email";

            dgvKH.Columns[0].Width = 100;
            dgvKH.Columns[1].Width = 150;
            dgvKH.Columns[2].Width = 70;
            dgvKH.Columns[3].Width = 150;
            dgvKH.Columns[4].Width = 100;
            dgvKH.Columns[5].Width = 220;

            dgvKH.ColumnHeadersHeight = 40;

            dgvKH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvKH.AllowUserToResizeColumns = false;
            dgvKH.AllowUserToResizeRows = false;

            // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
            foreach (DataGridViewColumn column in dgvKH.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }
            dgvKH.AllowUserToAddRows = false;
            dgvKH.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Clear() {
            txt_Search.Text = "";
            txt_CMND.Text = "";
            txt_DiaChi.Text = "";
            txt_SDT.Text = "";
            txt_TenKH.Text = "";
            cb_GioiTinh.SelectedIndex = 0;
            dtp_NgaySinh.Value = DateTime.Today;
        }

        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            Clear();
            XemKhachHang();
            Bientoancuc.mamaybay = "";
            Bientoancuc.machuyenbay = "";
            Bientoancuc.giaghe = "";
            Bientoancuc.matuyenbay = "";
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_CMND.Text = dgvKH.CurrentRow.Cells[0].Value.ToString();
            txt_TenKH.Text = dgvKH.CurrentRow.Cells[1].Value.ToString();
            cb_GioiTinh.Text = dgvKH.CurrentRow.Cells[2].Value.ToString();
            txt_SDT.Text = dgvKH.CurrentRow.Cells[3].Value.ToString();
            dtp_NgaySinh.Text = dgvKH.CurrentRow.Cells[4].Value.ToString();
            txt_DiaChi.Text = dgvKH.CurrentRow.Cells[5].Value.ToString();
            str_cmnd = txt_CMND.Text;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang(txt_CMND.Text,txt_TenKH.Text,txt_SDT.Text,cb_GioiTinh.Text,txt_DiaChi.Text,dtp_NgaySinh.Value);
            KhachHangBUS khachHangBUS = new KhachHangBUS(); 
            khachHangBUS.ThemKH(kh);
            XemKhachHang();
            Clear();
        }

        private void txt_CMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            KhachHangBUS khachHangBUS = new KhachHangBUS();
            kh.cMND = txt_CMND.Text;
            khachHangBUS.XoaKH(kh);
            XemKhachHang();
            Clear();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            KhachHang khachHang = new KhachHang(txt_CMND.Text, txt_TenKH.Text, txt_SDT.Text, cb_GioiTinh.Text, txt_DiaChi.Text, dtp_NgaySinh.Value);
            KhachHangBUS khachHangBUS = new KhachHangBUS();
            khachHangBUS.SuaKH(khachHang, str_cmnd);
            XemKhachHang();
            Clear();
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            KhachHangBUS khachHangBUS = new KhachHangBUS();
            dgvKH.DataSource = khachHangBUS.Search(txt_Search.Text);
        }
        private void btn_TimKiem_Click_1(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
