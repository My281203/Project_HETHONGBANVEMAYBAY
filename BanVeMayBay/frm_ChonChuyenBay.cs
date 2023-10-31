using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
    public partial class frm_ChonChuyenBay : Form
    {
        public frm_ChonChuyenBay()
        {
            InitializeComponent();
        }
        public delegate void TruyenChoCha(string s1);
        public TruyenChoCha TruyenData;
        public delegate void TruyenChoCha1(string s1,string s2, string s3);
        public TruyenChoCha1 TruyenData1;
        public void XemPhieuDatCho()
        {
            PhieuDatChoBUS pdc = new PhieuDatChoBUS();
            //  NhanVienBUS nvBUS = new NhanVienBUS();
            DataTable dt = new DataTable();
            dt = pdc.LayChuyenBay1();
            dgv_PDC.DataSource = dt;
            dgv_PDC.Columns[0].HeaderText = "Mã Chuyến Bay";
            dgv_PDC.Columns[1].HeaderText = "Ngày Bay";
            dgv_PDC.Columns[2].HeaderText = "Thời Gian Bay";
            dgv_PDC.Columns[3].HeaderText = "Thời Gian Đến Dự Kiến";
            dgv_PDC.Columns[4].HeaderText = "Giờ Khởi Hành";
            dgv_PDC.Columns[5].HeaderText = "Mã Tuyến Bay";
            dgv_PDC.Columns[6].HeaderText = "Mã Máy Bay";





            dgv_PDC.Columns[0].Width = 120;
            dgv_PDC.Columns[1].Width = 120;
            dgv_PDC.Columns[2].Width = 120;
            dgv_PDC.Columns[3].Width = 150;
            dgv_PDC.Columns[4].Width = 120;
            dgv_PDC.Columns[5].Width = 120;
            dgv_PDC.Columns[5].Width = 100;


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
        private void frm_ChonChuyenBay_Load(object sender, EventArgs e)
        {
            XemPhieuDatCho();
        }

        private void btn_Chon_Click(object sender, EventArgs e)
        {
            int i;
            i = dgv_PDC.CurrentRow.Index;
            string S1 = dgv_PDC[0, i].Value.ToString();
            TruyenData(S1);
            this.Close();
        }
    }
}
