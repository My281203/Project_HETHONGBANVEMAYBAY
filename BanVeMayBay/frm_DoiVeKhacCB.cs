using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
    public partial class frm_DoiVeKhacCB : Form
    {
        public frm_DoiVeKhacCB()
        {
            InitializeComponent();
        }

        int i;
        string S1, S2, S3;
        public delegate void TruyenChoCha(string s1, string s2, string s3);
        public TruyenChoCha TruyenData;

        private void btnLuu_Click(object sender, EventArgs e)
        {
            S1 = Bientoancuc.machuyenbay;

            S2 = txt_SoGhe.Text;
            // S3 = dataGridView1[3, i].Value.ToString();
            S3 = Bientoancuc.giaghe;
            TruyenData(S1, S2, S3);
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string s1;
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
            guna2Button1.Enabled = true;
        }
        string machuyen, tuyenbay, mamaybay, machuyenbay;
        private void LoadData1(string s1, string s2, string s3, string s4)
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
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frm_NutChonHoTroBanVe f = new frm_NutChonHoTroBanVe();
            f.TruyenData = new frm_NutChonHoTroBanVe.TruyenChoCha(LoadData);
            f.ShowDialog();
            btnLuu.Enabled = true;
        }
        string giatien;
        private const int CP_DISABLE_CLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CP_DISABLE_CLOSE_BUTTON;
                return cp;
            }
        }
        private void frm_DoiVeKhacCB_Load_1(object sender, EventArgs e)
        {
            XemViTri1();
            XemViTri2();
            btnLuu.Enabled = false;
            guna2Button1.Enabled = false;
            dtp_NgayBay.Value = DateTime.Now;
        }

        private void frm_DoiVeKhacCB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                e.Handled = true; // Ngăn chặn sự kiện đóng form
            }
        }

        private void LoadData(string data, string data2, string data3)
        {
            txt_SoGhe.Text = data;
            // string sample1 = data2;
            txt_HangGhe.Text = data2;
            giatien = data3;
            Bientoancuc.giaghe = giatien;
            // string s2;
            // s2 = string.Concat(mahangve,sample1);
            // s2.Replace(" ","");
            // machuyenold = mahangve;
            // txt_MaHV.Text= s2;          
        }
        private void btn_ChonKH_Click(object sender, EventArgs e)
        {

        }

        private void frm_DoiVeKhacCB_Load(object sender, EventArgs e)
        {
            XemViTri1();
            XemViTri2();
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
    }
}
