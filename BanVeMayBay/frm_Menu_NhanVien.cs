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
    public partial class frm_Menu_NhanVien : Form
    {
        public frm_Menu_NhanVien()
        {
            InitializeComponent();
        }

        private DataTable dt;
        public DataTable DT { set => dt = value; }
        private void EditButtonColor(Button btn, String topname)
        {
            btn_Home.Visible = true;
            btn_BanVe.BackColor = Color.FromArgb(102, 165, 173);
          
            btn_KhachHang.BackColor = Color.FromArgb(102, 165, 173);
    
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
 
            this.pnl_Main.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            pnl_Main.Controls.Add(f);
            f.Show();
        }
 
        private void btn_BanVe_Click_1(object sender, EventArgs e)
        {
            EditButtonColor(btn_BanVe, "BÁN VÉ");
            frm_BanVe frmBV = new frm_BanVe();
            AddForm(frmBV);
        }

        private void frm_Menu_NhanVien_Load(object sender, EventArgs e)
        {

        }
           
        private void btn_Home_Click_2(object sender, EventArgs e)
        {
            EditButtonColor(btn_Home, "TRANG CHỦ");
            btn_Home.Visible = false;
            this.pnl_Main.Controls.Clear();
        }

        private void btn_KhachHang_Click_1(object sender, EventArgs e)
        {
            EditButtonColor(btn_KhachHang, "KHÁCH HÀNG");
            frm_KhachHang frmKH = new frm_KhachHang();
            AddForm(frmKH);
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
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditButtonColor(btn_DoiMatKhau, "HỦY VÉ");
            frm_HuyVe frmDMK = new frm_HuyVe();

            AddForm(frmDMK);
            frmDMK.StartPosition.Equals(FormStartPosition.CenterScreen);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditButtonColor(btn_DoiMatKhau, "Đổi Vé");
            frm_DoiVe frmDMK = new frm_DoiVe();
            AddForm(frmDMK);
            frmDMK.StartPosition.Equals(FormStartPosition.CenterScreen);
        }

        private void pnl_Menu_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void lb_Role_Click(object sender, EventArgs e)
        {

        }
    }
}
