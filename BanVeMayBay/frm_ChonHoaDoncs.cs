using BUS;
using Guna.UI2.WinForms;
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
    public partial class frm_ChonHoaDoncs : Form
    {
        public delegate void TruyenChoCha(string s1);
        public TruyenChoCha TruyenData;
        public frm_ChonHoaDoncs()
        {
            InitializeComponent();
        }
        public void XemPhieuDatCho()
        {
            BanVeBUS bv = new BanVeBUS();
            //  NhanVienBUS nvBUS = new NhanVienBUS();
            DataTable dt = new DataTable();
            dt = bv.LayPhieuDatChotoHoaDon();
            dgv_PHD.DataSource = dt;
            if (dt.Columns.Contains("is_deleted"))
            {
                // Kiểm tra xem cột "Trạng thái" đã tồn tại trong DataTable hay chưa
                if (!dt.Columns.Contains("is_deleted"))
                {
                    // Nếu cột "Trạng thái" chưa tồn tại, thêm cột mới vào DataTable
                    dt.Columns.Add("is_deleted", typeof(string));
                }

                // Lặp qua từng hàng trong DataTable
                foreach (DataRow row in dt.Rows)
                {
                    // Lấy giá trị boolean từ cột "is_deleted" trong hàng hiện tại
                    bool isDeleted = (bool)row["is_deleted"];

                    // Xử lý giá trị boolean và gán giá trị tương ứng vào cột "Trạng thái"
                    if (isDeleted == false)
                    {
                        row["is_deleted"] = "True";
                    }
                    else
                    {
                        row["is_deleted"] = "False";
                    }
                }
            }
            //dgv_PHD.Columns[0].HeaderText = "Mã phiếu đặt";
            
            dgv_PHD.DataSource = dt;
            dgv_PHD.Columns[0].HeaderText = "Mã Giao Dịch";
            dgv_PHD.Columns[1].HeaderText = "Ngày Đặt";
            dgv_PHD.Columns[2].HeaderText = "Mã Chuyến Bay";
            dgv_PHD.Columns[3].HeaderText = "Mã Ghế";
            dgv_PHD.Columns[4].HeaderText = "CCCD";
            

            dgv_PHD.Columns[0].Width = 140;
            dgv_PHD.Columns[1].Width = 100;
            dgv_PHD.Columns[2].Width = 140;
            dgv_PHD.Columns[3].Width = 100;
            dgv_PHD.Columns[4].Width = 80;
            


            /// dgv_PHD.Columns[0].Width = 170;

            dgv_PHD.ColumnHeadersHeight = 40;

            dgv_PHD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_PHD.AllowUserToResizeColumns = false;
            dgv_PHD.AllowUserToResizeRows = false;


            // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
            foreach (DataGridViewColumn column in dgv_PHD.Columns)
            {
                column.Resizable = DataGridViewTriState.False;

            }


            dgv_PHD.AllowUserToAddRows = false;
            dgv_PHD.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void frm_ChonHoaDoncs_Load(object sender, EventArgs e)
        {
            XemPhieuDatCho();
        }

        private void btn_Chọn_Click(object sender, EventArgs e)
        {
            int i;
            i = dgv_PHD.CurrentRow.Index;
            string S1 = dgv_PHD[0, i].Value.ToString();
            TruyenData(S1);
            this.Close();   
        }
    }
}
