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
    public partial class frm_DSHoaDon : Form
    {
        public frm_DSHoaDon()
        {
            InitializeComponent();
        }

        private void frm_DSHoaDon_Load(object sender, EventArgs e)
        {
            HienThiPhieuHoaDon();
        }
        private void HienThiPhieuHoaDon()
        {
            BanVeBUS bv = new BanVeBUS();
            DataTable dt = new DataTable();
            dgvDSHoaDon.DataSource = bv.HienThiPhieuHoaDon();
           // dgvDSHoaDon.DataSource = dt;

            if (dt.Columns.Contains("is_deleted"))
            {
                // Kiểm tra xem cột "Trạng thái" đã tồn tại trong DataTable hay chưa
                if (!dt.Columns.Contains("Trạng thái"))
                {
                    // Nếu cột "Trạng thái" chưa tồn tại, thêm cột mới vào DataTable
                    dt.Columns.Add("Trạng Thái", typeof(string));
                }

                // Lặp qua từng hàng trong DataTable
                foreach (DataRow row in dt.Rows)
                {
                    // Lấy giá trị boolean từ cột "is_deleted" trong hàng hiện tại
                    bool isDeleted = (bool)row["is_deleted"];

                    // Xử lý giá trị boolean và gán giá trị tương ứng vào cột "Trạng thái"
                    if (isDeleted == false)
                    {
                        row["Trạng Thái"] = "True";
                    }
                    else
                    {
                        row["Trạng Thái"] = "False";
                    }
                }
            }


            dgvDSHoaDon.Columns[0].HeaderText = "Mã Phiếu Hóa Đơn";
            dgvDSHoaDon.Columns[1].HeaderText = "Mã phiếu giao dịch ";
            dgvDSHoaDon.Columns[2].HeaderText = "Ngày lập";
            dgvDSHoaDon.Columns[3].HeaderText = "Thành Tiền";
            dgvDSHoaDon.Columns[4].HeaderText = "Trạng thái";
            dgvDSHoaDon.Columns[5].HeaderText = "CCCD";
            dgvDSHoaDon.Columns[6].HeaderText = "Mã Nhân Viên";


            dgvDSHoaDon.Columns[0].Width = 170;
            dgvDSHoaDon.Columns[1].Width = 180;
            dgvDSHoaDon.Columns[2].Width = 200;
            dgvDSHoaDon.Columns[3].Width = 100;
            dgvDSHoaDon.Columns[4].Width = 100;
            dgvDSHoaDon.Columns[5].Width = 170;
            dgvDSHoaDon.Columns[6].Width = 150;

            dgvDSHoaDon.ColumnHeadersHeight = 40;

            dgvDSHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDSHoaDon.AllowUserToResizeColumns = false;
            dgvDSHoaDon.AllowUserToResizeRows = false;

            // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
            foreach (DataGridViewColumn column in dgvDSHoaDon.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }
            dgvDSHoaDon.AllowUserToAddRows = false;
           dgvDSHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void dgvDSHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaHD.Text = dgvDSHoaDon.CurrentRow.Cells[0].Value.ToString();
            txt_ThanhTien.Text = dgvDSHoaDon.CurrentRow.Cells[3].Value.ToString();
            dtp_NgayTao.Value = Convert.ToDateTime(dgvDSHoaDon.CurrentRow.Cells[2].Value);
            txt_MaNV.Text = dgvDSHoaDon.CurrentRow.Cells[6].Value.ToString();
            txt_MaKH.Text = dgvDSHoaDon.CurrentRow.Cells[5].Value.ToString();
            txt_MaPhieuDC.Text = dgvDSHoaDon.CurrentRow.Cells[1].Value.ToString();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
        
            HoaDonBUS hd = new HoaDonBUS();
            DanhSachHoaDon hdon = new DanhSachHoaDon(txt_MaHD.Text,dtp_NgayTao.Value,txt_MaNV.Text,txt_MaKH.Text,txt_ThanhTien.Text);
            //BanVe bv = new BanVe(txt_MaHD.Text, txt_MaKH.Text, txt_ThanhTien.Text, dtp_NgayTao.Value, txt_MaNV.Text, txt_MaKH.Text);
            hd.SuaPhieuDSHoaDon(hdon);
            HienThiPhieuHoaDon();
        }
        private void SearchPhieuDatCho()
        {
         
            DataTable dt = new DataTable();
            HoaDonBUS hd = new HoaDonBUS();
            dt = hd.SearchPhieuHoaDon(txtSearch.Text);



            dgvDSHoaDon.Columns[0].HeaderText = "Mã Phiếu Hóa Đơn";
            dgvDSHoaDon.Columns[1].HeaderText = "Mã phiếu giao dịch ";
            dgvDSHoaDon.Columns[2].HeaderText = "Ngày lập";
            dgvDSHoaDon.Columns[3].HeaderText = "Thành Tiền";
            dgvDSHoaDon.Columns[4].HeaderText = "Trạng thái";
            dgvDSHoaDon.Columns[5].HeaderText = "CCCD";
            dgvDSHoaDon.Columns[6].HeaderText = "Mã Nhân Viên";

            dgvDSHoaDon.Columns[0].Width = 170;
            dgvDSHoaDon.Columns[1].Width = 180;
            dgvDSHoaDon.Columns[2].Width = 200;
            dgvDSHoaDon.Columns[3].Width = 100;
            dgvDSHoaDon.Columns[4].Width = 100;
            dgvDSHoaDon.Columns[5].Width = 170;
            dgvDSHoaDon.Columns[6].Width = 150;

            dgvDSHoaDon.ColumnHeadersHeight = 40;

            dgvDSHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDSHoaDon.AllowUserToResizeColumns = false;
            dgvDSHoaDon.AllowUserToResizeRows = false;

            // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
            foreach (DataGridViewColumn column in dgvDSHoaDon.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }
            dgvDSHoaDon.AllowUserToAddRows = false;
            dgvDSHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            HoaDonBUS hd = new HoaDonBUS();
            hd.XoaPhieuHoaDon(txt_MaHD.Text);

            MessageBox.Show("Xóa thành công");
            HienThiPhieuHoaDon();
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            SearchPhieuDatCho();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchPhieuDatCho();
        }
    }
}
