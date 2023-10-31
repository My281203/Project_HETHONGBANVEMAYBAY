using BUS;
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
    public partial class frm_DoiVe : Form
    {
        public frm_DoiVe()
        {
            InitializeComponent();
        }
        private string giagheold, machuyenbayold, sogheold;
        private DateTime ngaybayold;
        private void btnTracuu_Click(object sender, EventArgs e)
        {
            BanVeBUS bv = new BanVeBUS();
            DataTable dt = new DataTable();
            dt = bv.LayThongTinVeByMaVe(txtNhapMaVe.Text);

            if (dt.Rows.Count > 0)
            {
                txthoten.Text = dt.Rows[0].ItemArray[9].ToString();
                txtchuyenbay.Text = dt.Rows[0].ItemArray[6].ToString();
                txtcmnd.Text = dt.Rows[0].ItemArray[7].ToString();
                txtgiaghe.Text = dt.Rows[0].ItemArray[10].ToString();
                txtmahoadon.Text = dt.Rows[0].ItemArray[2].ToString();
                txtsdt.Text = dt.Rows[0].ItemArray[8].ToString();
                txtsg.Text = dt.Rows[0].ItemArray[4].ToString();
                txttrangthai.Text = dt.Rows[0].ItemArray[1].ToString();
                dtpngaybay.Value = Convert.ToDateTime(dt.Rows[0].ItemArray[5].ToString());
                txtthongtingd.Text = dt.Rows[0].ItemArray[3].ToString();
                lbngaydat.Text = Convert.ToDateTime(dt.Rows[0].ItemArray[11]).ToString("dd/MM/yyyy");

                lbmave.Text = dt.Rows[0].ItemArray[0].ToString();
                Bientoancuc.mamaybay = dt.Rows[0].ItemArray[13].ToString();

                giagheold = dt.Rows[0].ItemArray[10].ToString();
                machuyenbayold = dt.Rows[0].ItemArray[6].ToString();
                sogheold = dt.Rows[0].ItemArray[4].ToString();
                ngaybayold = Convert.ToDateTime(dt.Rows[0].ItemArray[5].ToString());

            }
        }
        private void LoadVe()
        {
            BanVeBUS bv = new BanVeBUS();
            DataTable dt = new DataTable();
            dt = bv.LayThongTinVeByMaVe(txtNhapMaVe.Text);

            if (dt.Rows.Count > 0)
            {
                txthoten.Text = dt.Rows[0].ItemArray[9].ToString();
                txtchuyenbay.Text = dt.Rows[0].ItemArray[6].ToString();
                txtcmnd.Text = dt.Rows[0].ItemArray[7].ToString();
                txtgiaghe.Text = dt.Rows[0].ItemArray[10].ToString();
                txtmahoadon.Text = dt.Rows[0].ItemArray[2].ToString();
                txtsdt.Text = dt.Rows[0].ItemArray[8].ToString();
                txtsg.Text = dt.Rows[0].ItemArray[4].ToString();
                txttrangthai.Text = dt.Rows[0].ItemArray[1].ToString();
                dtpngaybay.Value = Convert.ToDateTime(dt.Rows[0].ItemArray[5].ToString());
                txtthongtingd.Text = dt.Rows[0].ItemArray[3].ToString();
                lbngaydat.Text = Convert.ToDateTime(dt.Rows[0].ItemArray[11]).ToString("dd/MM/yyyy");

                lbmave.Text = dt.Rows[0].ItemArray[0].ToString();
                Bientoancuc.mamaybay = dt.Rows[0].ItemArray[13].ToString();
                Bientoancuc.matuyenbay = dt.Rows[0].ItemArray[12].ToString();

                giagheold = dt.Rows[0].ItemArray[10].ToString();
                machuyenbayold = dt.Rows[0].ItemArray[6].ToString();
                sogheold = dt.Rows[0].ItemArray[4].ToString();
                ngaybayold = Convert.ToDateTime(dt.Rows[0].ItemArray[5].ToString());

            }
        }
        private void frm_DoiVe_Load(object sender, EventArgs e)
        {
            lbCB.Hide();
            lbgiaghe.Hide();
            lbNgayBay.Hide();
            lbSoGhe.Hide();
        
        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }
        string giatien, hanghe;

        private void guna2RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

           
            
        }

        private void btnHuyVe_Click(object sender, EventArgs e)
        {
            BanVeBUS bv = new BanVeBUS();
            DataTable dt = new DataTable();
            dt = bv.DoiVe(lbmave.Text, txtchuyenbay.Text, Bientoancuc.matuyenbay, txtsg.Text, txtgiaghe.Text);
            if (dt.Rows.Count > 0)
            {
                // Kiểm tra mảng có tồn tại
                if (dt.Rows[0].ItemArray.Length > 1)
                {
                    string s2 = dt.Rows[0].ItemArray[1].ToString();
                    MessageBox.Show(s2);
                    txtTienHoantra.Text = dt.Rows[0].ItemArray[0].ToString();
                }

                if (dt.Rows[0].ItemArray.Length == 1)
                {
                    string s2 = dt.Rows[0].ItemArray[0].ToString();
                    MessageBox.Show(s2);
                }
            }
        }

        private void guna2RadioButton2_Click(object sender, EventArgs e)
        {
            frm_DoiVeKhacCB f1 = new frm_DoiVeKhacCB();
            f1.TruyenData = new frm_DoiVeKhacCB.TruyenChoCha(LoadData2);
            f1.ShowDialog();
          //  guna2RadioButton2.Checked = false;
        }

        private void guna2RadioButton1_Click(object sender, EventArgs e)
        {
            frm_NutChonHoTroBanVe f = new frm_NutChonHoTroBanVe();
            f.TruyenData = new frm_NutChonHoTroBanVe.TruyenChoCha(LoadData);
            f.ShowDialog();
            //guna2RadioButton1.Checked = false;
        }

        private void txtNhapMaVe_TextChanged(object sender, EventArgs e)
        {
            LoadVe();
        }

        private void LoadData2(string data, string data2, string data3)
        {

            txtchuyenbay.Text = data;
            txtsg.Text = data2;
            txtgiaghe.Text = data3;
            dtpngaybay.Value = Bientoancuc.ngaybay;

            if (machuyenbayold != data)
            {
                lbCB.Show();
            }
            if (sogheold != data2)
            {
                lbSoGhe.Show();
                lbgiaghe.Show();
            }
            if (ngaybayold != dtpngaybay.Value)
            {
                lbNgayBay.Show();
            }


        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void LoadData(string data, string data2, string data3)
        {

            txtsg.Text = data;
            // string sample1 = data2;
            hanghe = data2;
            giatien = data3;
            txtgiaghe.Text = giatien;
            if (sogheold != data)
            {
                lbgiaghe.Show();
                lbSoGhe.Show();
            }


            // string s2;
            // s2 = string.Concat(mahangve,sample1);
            // s2.Replace(" ","");
            // machuyenold = mahangve;
            // txt_MaHV.Text= s2;          
        }
    }

}

