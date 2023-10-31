using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS;

namespace BanVeMayBay
{
    public partial class frm_NutChonHoTroBanVe : Form
    {
        int i;
        string S1,S2,S3;
        public delegate void TruyenChoCha(string s1,string s2,string s3);
        public delegate void TruyenChoCha1(string s1, string s2, string s3,string s4);
        public TruyenChoCha TruyenData;
        public TruyenChoCha1 TruyenData1;
       

        public frm_NutChonHoTroBanVe()
        {
            InitializeComponent();
        }

        private void Load1()
        {
            if(Bientoancuc.mamaybay != null || Bientoancuc.mamaybay != "") {
              
                PhieuDatChoBUS pdc = new PhieuDatChoBUS();
                DataTable dt8 = new DataTable();
                dt8 = pdc.LayChoNgoi1(Bientoancuc.mamaybay.Trim());
                //dt8 = bv1.LayGhe(Convert.ToInt32(Bientoancuc.soghe));
                dgv1.DataSource = dt8;
            }
            else
            {
                this.Close();
            }    
           
        }

        private void frm_NutChonHoTroBanVe_Load_1(object sender, EventArgs e)
        {
            Load1();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            i = dgv1.CurrentRow.Index;
            S1 = dgv1[0, i].Value.ToString();
            S2 = dgv1[2, i].Value.ToString();
            S3 = dgv1[3, i].Value.ToString();
            TruyenData(S1,S2,S3);
            this.Close();


        }
    }
}
