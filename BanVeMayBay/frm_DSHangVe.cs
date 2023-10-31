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
    public partial class frm_DSHangVe : Form
    {
        HangVe hv;
        public frm_DSHangVe()
        {
            InitializeComponent();
        }
        public void XemHangVe()
        {
            HangVeBUS hvBUS = new HangVeBUS();
            DataTable dt = new DataTable();
            dt = hvBUS.HienThi();

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
            dt.Columns.Remove("is_deleted");


            dgvDSHangVe.DataSource = dt;
            dgvDSHangVe.Columns[0].HeaderText = "Mã Vé";
            dgvDSHangVe.Columns[1].HeaderText = "Ngày Tạo Vé ";
            dgvDSHangVe.Columns[2].HeaderText = "Mã Hóa Đơn";
            dgvDSHangVe.Columns[3].HeaderText = "Trang thai";

            dgvDSHangVe.ColumnHeadersHeight = 40;
            dgvDSHangVe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDSHangVe.AllowUserToResizeColumns = false;   
            dgvDSHangVe.AllowUserToResizeRows = false;  
            
            foreach (DataGridViewColumn column in dgvDSHangVe.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }

            dgvDSHangVe.AllowUserToAddRows = false;
            dgvDSHangVe.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadComboBoxMaChuyenBay()
        {
            ChuyenBayBUS cbBUS = new ChuyenBayBUS();
            DataTable dt = new DataTable();
            dt = cbBUS.HienThi();
         //   cb_MaChuyenBay.DisplayMember = "MaChuyenBay";
          //  cb_MaChuyenBay.ValueMember = "MaChuyenBay";
           // cb_MaChuyenBay.DataSource = dt;
        }
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public bool CheckNhapMB()
        {
         
         
        
            if (txtMaHoaDon.Text == "")
            {
                MessageBox.Show("Nhập Mã hóa đơn!");
                txtMaHoaDon.Focus();
                return false;
            }
      
            else
            {
                return true;
            }
        }
        public void Reset()
        {
            txt_MaHangVe.ResetText();
            //txt_MaHangVe.Enabled = true;
            txtMaHoaDon.ResetText();
          
        }
        private void frm_DSHangVe_Load(object sender, EventArgs e)
        {
            XemHangVe();
         //   LoadComboBoxMaChuyenBay();
           // cb_MaChuyenBay.SelectedIndex = -1;
            txt_MaHangVe.Enabled = false;
            Bientoancuc.mamaybay = "";
            Bientoancuc.machuyenbay = "";
            Bientoancuc.giaghe = "";
            Bientoancuc.matuyenbay = "";
        }
        private void dgvDSHangVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahangve;
            int dongia;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDSHangVe.Rows[e.RowIndex];

                txt_MaHangVe.Text = row.Cells[0].Value.ToString();

                dtp_ngaytao.Value = Convert.ToDateTime(row.Cells[1].Value.ToString());
                txt_MaHangVe.Text = row.Cells[2].Value.ToString();
            }
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            HangVeBUS hvBUS = new HangVeBUS();
            if (CheckNhapMB())
            {
                hv = new HangVe(dtp_ngaytao.Value, txtMaHoaDon.Text,"0","0");
                hvBUS.ThemHV(hv);
                MessageBox.Show("Thêm hạng vé mới thành công!");
                Reset();
                XemHangVe();
            }
        }
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            HangVeBUS hvBUS = new HangVeBUS();
            if (txt_MaHangVe.Text == "")
            {
                MessageBox.Show("Vui lòng chọn hạng vé muốn xóa!");
            }
            else
            {
                hvBUS.XoaHV(txt_MaHangVe.Text);
                MessageBox.Show("Xóa hạng vé thành công!");
                Reset();
                XemHangVe();
            }
        }
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            HangVeBUS hvBUS = new HangVeBUS();
            if (CheckNhapMB())
            {
               hv = new HangVe(txt_MaHangVe.Text, dtp_ngaytao.Value,txtMaHoaDon.Text,"0", "0");
               hvBUS.SuaHV(hv);
               MessageBox.Show("Cập nhật hạng vé thành công!");
                Reset();
                XemHangVe();
            }
        }
        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (txt_TimKiemMaHangVe.Text == "")
            {
                MessageBox.Show("Nhập mã hạng vé muốn tìm!");
                txt_TimKiemMaHangVe.Focus();
            }
            else
            {
                HangVeBUS hvBUS = new HangVeBUS();
                DataTable dt = new DataTable();
                dt = hvBUS.TimHV(txt_TimKiemMaHangVe.Text);
                //txt_TimKiemMaHangVe.ResetText();
                if (dt.Rows.Count > 0)
                {
                    dgvDSHangVe.DataSource = dt;
                    dgvDSHangVe.Columns[0].HeaderText = "Mã hạng vé";
                    dgvDSHangVe.Columns[1].HeaderText = "Ngay tạo vé ";
                    dgvDSHangVe.Columns[2].HeaderText = "Mã Hóa Đơn";

                    dgvDSHangVe.ColumnHeadersHeight = 40;
                    dgvDSHangVe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    dgvDSHangVe.AllowUserToResizeColumns = false;
                    dgvDSHangVe.AllowUserToResizeRows = false;

                    foreach (DataGridViewColumn column in dgvDSHangVe.Columns)
                    {
                        column.Resizable = DataGridViewTriState.False;
                    }

                    dgvDSHangVe.AllowUserToAddRows = false;
                    dgvDSHangVe.EditMode = DataGridViewEditMode.EditProgrammatically;
         
                }
                else
                {
                    XemHangVe();
                   // MessageBox.Show("Không tìm thấy hạng vé!");
                }
            }
        }

        private void dgvDSHangVe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvDSHangVe_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaHangVe.Text = dgvDSHangVe.CurrentRow.Cells[0].Value.ToString();
            dtp_ngaytao.Value = Convert.ToDateTime(dgvDSHangVe.CurrentRow.Cells[1].Value.ToString());
            txtMaHoaDon.Text = dgvDSHangVe.CurrentRow.Cells[2].Value.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvDSHangVe_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_TimKiemMaHangVe_TextChanged(object sender, EventArgs e)
        {
            HangVeBUS hvBUS = new HangVeBUS();
            DataTable dt = new DataTable();
            dt = hvBUS.TimHV(txt_TimKiemMaHangVe.Text);
            //txt_TimKiemMaHangVe.ResetText();
            if (dt.Rows.Count > 0)
            {
                dgvDSHangVe.DataSource = dt;
                dgvDSHangVe.Columns[0].HeaderText = "Mã hạng vé";
                dgvDSHangVe.Columns[1].HeaderText = "Ngay tạo vé ";
                dgvDSHangVe.Columns[2].HeaderText = "Mã Hóa Đơn";

                dgvDSHangVe.AllowUserToAddRows = false;
                dgvDSHangVe.EditMode = DataGridViewEditMode.EditProgrammatically;
                MessageBox.Show("Tìm hạng vé thành công!");
            }
            else
            {
                XemHangVe();
                // MessageBox.Show("Không tìm thấy hạng vé!");
            }
        }

        private void guna2ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
