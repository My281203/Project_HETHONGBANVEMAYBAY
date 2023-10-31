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
    public partial class frm_Menu_Admin : Form
    {
        public frm_Menu_Admin()
        {
            InitializeComponent();
        }
        private DataTable dt;
        public DataTable DT { set => dt = value; }
        private void EditButtonColor(Button btn, String topname)
        {
            btn_Home.Visible = true;
            btn_BanVe.BackColor = Color.FromArgb(102, 165, 173);
            btn_DanhSach.BackColor = Color.FromArgb(102, 165, 173);
            btn_ChuyenBay.BackColor = Color.FromArgb(102, 165, 173);
            btn_TuyenBay.BackColor = Color.FromArgb(102, 165, 173);
            btn_MayBay.BackColor = Color.FromArgb(102, 165, 173);
            btn_NhanVien.BackColor = Color.FromArgb(102, 165, 173);
            btn_KhachHang.BackColor = Color.FromArgb(102, 165, 173);
            btn_ThongKe.BackColor = Color.FromArgb(102, 165, 173);
            btn_DoiMatKhau.BackColor = Color.FromArgb(102, 165, 173);
            btn_Thoat.BackColor = Color.FromArgb(102, 165, 173);

            if (topname == "TRANG CHỦ")
            {
                btn.BackColor = Color.FromArgb(102, 165, 173);
                pnl_Top.BackColor = Color.FromArgb(102, 165, 173);
            }
            else
            {
                btn.BackColor = Color.FromArgb(196, 223, 230);
                pnl_Top.BackColor = Color.FromArgb(196, 223, 230);
            }
            lb_TopName.Text = topname;
        }
        void AddForm(Form f)
        {
            ms_DanhSach.Visible = false;
            this.pnl_Main.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            pnl_Main.Controls.Add(f);
            f.Show();
        }
        private void btn_BanVe_Click(object sender, EventArgs e)
        {
            EditButtonColor(btn_BanVe, "BÁN VÉ");
            frm_BanVe frmBV = new frm_BanVe();
            AddForm(frmBV);
        }

        private void btn_DanhSach_Click(object sender, EventArgs e)
        {
            EditButtonColor(btn_DanhSach, "DANH SÁCH HÓA ĐƠN");
            frm_DSHoaDon frmHD = new frm_DSHoaDon();
            AddForm(frmHD);
            ms_DanhSach.Visible = true;
        }

        private void ms_DanhSachHD_Click(object sender, EventArgs e)
        {
            lb_TopName.Text = "DANH SÁCH HÓA ĐƠN";
            frm_DSHoaDon frmHD = new frm_DSHoaDon();
            AddForm(frmHD);
            ms_DanhSach.Visible = true;
        }

        private void ms_DanhSachPDC_Click(object sender, EventArgs e)
        {
            lb_TopName.Text = "DANH SÁCH PHIẾU ĐẶT CHỖ";
            frm_DSPhieuDatCho frmPDC = new frm_DSPhieuDatCho();
            AddForm(frmPDC);
            ms_DanhSach.Visible = true;
        }

        private void ms_DanhSachHangVe_Click(object sender, EventArgs e)
        {
            lb_TopName.Text = "DANH SÁCH HẠNG VÉ";
            frm_DSHangVe frmHV = new frm_DSHangVe();
            AddForm(frmHV);
            ms_DanhSach.Visible = true;
        }

        private void btn_ChuyenBay_Click(object sender, EventArgs e)
        {
            EditButtonColor(btn_ChuyenBay, "CHUYẾN BAY");
            frm_ChuyenBay frmCB = new frm_ChuyenBay();
            AddForm(frmCB);
        }

        private void btn_MayBay_Click(object sender, EventArgs e)
        {
            EditButtonColor(btn_MayBay, "MÁY BAY");
            frm_MayBay frmMB = new frm_MayBay();
            AddForm(frmMB);
        }

        private void btn_TuyenBay_Click(object sender, EventArgs e)
        {
            EditButtonColor(btn_TuyenBay, "TUYẾN BAY");
            frm_TuyenBay frmTB = new frm_TuyenBay();
            AddForm(frmTB);
        }

        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            EditButtonColor(btn_NhanVien, "NHÂN VIÊN");
            frm_NhanVien frmNV = new frm_NhanVien();
            AddForm(frmNV);
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            EditButtonColor(btn_KhachHang, "KHÁCH HÀNG");
            frm_KhachHang frmKH = new frm_KhachHang();
            AddForm(frmKH);
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            EditButtonColor(btn_ThongKe, "THỐNG KÊ");
            frm_ThongKe frmTK = new frm_ThongKe();
            AddForm(frmTK);
        }

        private void btn_DoiMatKhau_Click(object sender, EventArgs e)
        {
            EditButtonColor(btn_DoiMatKhau, "ĐỔI MẬT KHẨU");
            frm_DoiMatKhau frmDMK = new frm_DoiMatKhau();
            frmDMK.DT = dt;
            AddForm(frmDMK);
            frmDMK.StartPosition.Equals(FormStartPosition.CenterScreen);
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            EditButtonColor(btn_Thoat, "THOÁT");
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            EditButtonColor(btn_Home, "TRANG CHỦ");
            btn_Home.Visible = false;
            ms_DanhSach.Visible = false;
            this.pnl_Main.Controls.Clear();
        }

        private void frm_Menu_Load(object sender, EventArgs e)
        {
            btn_Home.Visible = false;
            ms_DanhSach.Visible = false;

        }

        private void pnl_Top_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_Logo_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Role()
        {
            if (dt.Rows[0].ItemArray[3].ToString() == "2")
            {
                btn_DanhSach.Visible = false;
                btn_ChuyenBay.Visible = false;
                btn_MayBay.Visible = false;
                btn_NhanVien.Visible = false;
                btn_ThongKe.Visible = false;
                btn_TuyenBay.Visible = false;
                btn_KhachHang.Location = new Point(0, 114);
                btn_DoiMatKhau.Location = new Point(0, 163);
                btn_Thoat.Location = new Point(0, 212);
                lb_Role.Text = "EMPLOYEE";
            }
        }

        private void lb_Role_Click(object sender, EventArgs e)
        {

        }

        private void pnl_Main_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
