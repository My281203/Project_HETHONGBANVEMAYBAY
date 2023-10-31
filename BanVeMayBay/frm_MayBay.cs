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
    public partial class frm_MayBay : Form
    {
        MayBay mb;
        public frm_MayBay()
        {
            InitializeComponent();
        }
        public void XemMayBay()
        {
            MayBayBUS mbBUS = new MayBayBUS();
            DataTable dt = new DataTable();
            dt = mbBUS.HienThi();
            dgvMB.DataSource = dt;
            dgvMB.Columns[0].HeaderText = "Mã máy bay";
            dgvMB.Columns[1].HeaderText = "Tên máy bay";
            dgvMB.Columns[2].HeaderText = "Số ghế loại A";
            dgvMB.Columns[3].HeaderText = "Số ghế loại B";

            dgvMB.ColumnHeadersHeight = 40;

            dgvMB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMB.AllowUserToResizeColumns = false;
            dgvMB.AllowUserToResizeRows = false;

            // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
            foreach (DataGridViewColumn column in dgvMB.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }

            dgvMB.AllowUserToAddRows = false;
            dgvMB.EditMode = DataGridViewEditMode.EditProgrammatically;
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
            if (txt_MaMayBay.Text == "")
            {
                MessageBox.Show("Nhập mã máy bay!");
                txt_MaMayBay.Focus();
                return false;
            }
            if (txt_LoaiMayBay.Text == "")
            {
                MessageBox.Show("Nhập loại máy bay!");
                txt_LoaiMayBay.Focus();
                return false;
            }
            if (txt_SoGhe.Text == "")
            {
                MessageBox.Show("Nhập số ghế!");
                txt_SoGhe.Focus();
                return false;
            }
            if (IsNumber(txt_SoGhe.Text) != true)
            {
                MessageBox.Show("Số ghế chỉ được nhập số nguyên!");
                txt_SoGhe.Focus();
                return false;
            }
            if (txtSoGheLoaiB.Text == "")
            {
                MessageBox.Show("Nhập số ghế!");
                txtSoGheLoaiB.Focus();
                return false;
            }
            if (IsNumber(txtSoGheLoaiB.Text) != true)
            {
                MessageBox.Show("Số ghế chỉ được nhập số nguyên!");
                txtSoGheLoaiB.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Reset()
        {
            txt_MaMayBay.ResetText();
            txt_MaMayBay.Enabled = true;
            txt_LoaiMayBay.ResetText();
            txt_SoGhe.ResetText();
            txt_MaMayBay.Focus();
        }
        private void frm_MayBay_Load(object sender, EventArgs e)
        {
            XemMayBay();
        }
        private void dgvMB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvMB.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txt_MaMayBay.Text = row.Cells[0].Value.ToString();
                txt_LoaiMayBay.Text = row.Cells[1].Value.ToString();
                txt_SoGhe.Text = row.Cells[2].Value.ToString();
                txtSoGheLoaiB.Text = row.Cells[3].Value.ToString();

                //Không cho phép sửa trường MaNV
                //txt_MaMayBay.Enabled = false;
            }
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            MayBayBUS mbBUS = new MayBayBUS();
            if(CheckNhapMB())
            {
                mb = new MayBay( txt_LoaiMayBay.Text, Convert.ToInt32(txt_SoGhe.Text),Convert.ToInt32(txtSoGheLoaiB.Text));
                mbBUS.ThemMB(mb);
                //MessageBox.Show("Thêm máy bay mới thành công!");
                Reset();
                XemMayBay();
            }    
        }
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            MayBayBUS mbBUS = new MayBayBUS();
            if (txt_MaMayBay.Text == "")
            {
                MessageBox.Show("Vui lòng chọn máy bay muốn xóa!");
            }
            else
            {
                mbBUS.XoaMB(txt_MaMayBay.Text);
                //MessageBox.Show("Xóa máy bay thành công!");
                Reset();
                XemMayBay();
            }
        }
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            MayBayBUS mbBUS = new MayBayBUS();
            if (CheckNhapMB())
            {
                mb = new MayBay(txt_MaMayBay.Text, txt_LoaiMayBay.Text, Convert.ToInt32(txt_SoGhe.Text), Convert.ToInt32(txtSoGheLoaiB.Text));
                mbBUS.SuaMB(mb);
                //MessageBox.Show("Cập nhật máy bay thành công!");
                //Reset();
                XemMayBay();
            }
        }
        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (txt_TimKiemMaMB.Text == "")
            {
                MessageBox.Show("Nhập mã máy bay muốn tìm!");
                txt_TimKiemMaMB.Focus();
            }
            else
            {
                MayBayBUS mbBUS = new MayBayBUS();
                DataTable dt = new DataTable();
                dt = mbBUS.TimMB(txt_TimKiemMaMB.Text);
                txt_TimKiemMaMB.ResetText();
                if (dt.Rows.Count > 0)
                {
                    dgvMB.DataSource = dt;
                    dgvMB.Columns[0].HeaderText = "Mã máy bay";
                    dgvMB.Columns[1].HeaderText = "Tên máy bay";
                    dgvMB.Columns[2].HeaderText = "Số ghế loại A";
                    dgvMB.Columns[3].HeaderText = "Số ghế loại B";

                    dgvMB.ColumnHeadersHeight = 40;

                    dgvMB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    dgvMB.AllowUserToResizeColumns = false;
                    dgvMB.AllowUserToResizeRows = false;

                    // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
                    foreach (DataGridViewColumn column in dgvMB.Columns)
                    {
                        column.Resizable = DataGridViewTriState.False;
                    }

                    dgvMB.AllowUserToAddRows = false;
                    dgvMB.EditMode = DataGridViewEditMode.EditProgrammatically;
                    MessageBox.Show("Tìm máy bay thành công!");
                }   
                else
                {
                    MessageBox.Show("Không tìm thấy máy bay!");
                }         
            }
        }

        private void txt_TimKiemMaMB_TextChanged(object sender, EventArgs e)
        {
            MayBayBUS mbBUS = new MayBayBUS();
            DataTable dt = new DataTable();
            dt = mbBUS.TimMB(txt_TimKiemMaMB.Text);
          //  txt_TimKiemMaMB.ResetText();
            if (dt.Rows.Count > 0)
            {
                dgvMB.DataSource = dt;
                dgvMB.Columns[0].HeaderText = "Mã máy bay";
                dgvMB.Columns[1].HeaderText = "Tên máy bay";
                dgvMB.Columns[2].HeaderText = "Số ghế loại A";
                dgvMB.Columns[3].HeaderText = "Số ghế loại B";

                dgvMB.ColumnHeadersHeight = 40;

                dgvMB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgvMB.AllowUserToResizeColumns = false;
                dgvMB.AllowUserToResizeRows = false;

                // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
                foreach (DataGridViewColumn column in dgvMB.Columns)
                {
                    column.Resizable = DataGridViewTriState.False;
                }

                dgvMB.AllowUserToAddRows = false;
                dgvMB.EditMode = DataGridViewEditMode.EditProgrammatically;
                MessageBox.Show("Tìm máy bay thành công!");
            }
            else if(txt_TimKiemMaMB.Text == "")
            {
                XemMayBay();
            }
        }
    }
}
