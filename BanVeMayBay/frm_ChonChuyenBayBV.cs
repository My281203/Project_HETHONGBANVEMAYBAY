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
    public partial class frm_ChonChuyenBayBV : Form
    {
        public frm_ChonChuyenBayBV() 
        {
            InitializeComponent();
        }
        public delegate void TruyenChoCha1(string s1, string s2, string s3,string s4);
        public TruyenChoCha1 TruyenData1;
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
        public void XemPhieuDatCho()
        {
            PhieuDatChoBUS pdc = new PhieuDatChoBUS();
            //  NhanVienBUS nvBUS = new NhanVienBUS();
            DataTable dt = new DataTable();
            dt = pdc.LayChuyenBay2(Bientoancuc.ngaybay,Bientoancuc.matuyenbay);
            dgv_PDC.DataSource = dt;
            dgv_PDC.Columns[0].HeaderText = "Mã Chuyến Bay";
            dgv_PDC.Columns[1].HeaderText = "Ngày Bay";
            dgv_PDC.Columns[2].HeaderText = "Thời Gian Bay";
            dgv_PDC.Columns[3].HeaderText = "Thời Gian Dự Kiến Đến";
            dgv_PDC.Columns[4].HeaderText = "Giờ Khởi Hành";    
            dgv_PDC.Columns[5].HeaderText = "Mã Tuyến Bay";
            dgv_PDC.Columns[6].HeaderText = "Mã Máy Bay";

            dgv_PDC.Columns[0].Width = 120;
            dgv_PDC.Columns[1].Width = 80;
            dgv_PDC.Columns[2].Width = 140;
            dgv_PDC.Columns[3].Width = 150;
            dgv_PDC.Columns[4].Width = 120;
            dgv_PDC.Columns[5].Width = 120;
            dgv_PDC.Columns[6].Width = 120;
            dgv_PDC.AllowUserToAddRows = false;
            dgv_PDC.EditMode = DataGridViewEditMode.EditProgrammatically;

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
        private void frm_ChonChuyenBayBV_Load(object sender, EventArgs e)
        {
            XemPhieuDatCho();
        }

        private void btn_Chon_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Chon_Click_1(object sender, EventArgs e)
        {
            int i;
            i = dgv_PDC.CurrentRow.Index;
            string S1 = dgv_PDC[0, i].Value.ToString();
            string S2 = dgv_PDC[5, i].Value.ToString();
            string S3 = dgv_PDC[6, i].Value.ToString();
            string S4 = dgv_PDC[4, i].Value.ToString();
            Bientoancuc.gioikhoihanh = Convert.ToDateTime(dgv_PDC[4, i].Value.ToString());
            TruyenData1(S1, S2, S3,S4);
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
