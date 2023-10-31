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
    public partial class frm_HuyVe : Form
    {
        public frm_HuyVe()
        {
            InitializeComponent();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void frm_HuyVe_Load(object sender, EventArgs e)
        {
            txtTienHoantra.Enabled = false;
            Bientoancuc.mamaybay = "";
            Bientoancuc.machuyenbay = "";
            Bientoancuc.giaghe = "";
            Bientoancuc.matuyenbay = "";
        }

        private void btnTracuu_Click(object sender, EventArgs e)
        {
            BanVeBUS bv = new BanVeBUS();
            DataTable dt = new DataTable();
            dt = bv.LayThongTinVeByMaVe(txtNhapMaVe.Text);

           if(dt.Rows.Count > 0 )
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
            }
        }

        private void btnHuyVe_Click(object sender, EventArgs e)
        {
            BanVeBUS bv = new BanVeBUS();
            DataTable dt = new DataTable();
            dt = bv.HuyVe(lbmave.Text);
            if(dt.Rows.Count > 0)
            {
                string s2 = dt.Rows[0].ItemArray[1].ToString();
                MessageBox.Show(s2);
                txtTienHoantra.Text = dt.Rows[0].ItemArray[0].ToString();
                
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
            }
        }
        private void txtNhapMaVe_TextChanged(object sender, EventArgs e)
        {

         LoadVe();
        }

        private void txthoten_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
