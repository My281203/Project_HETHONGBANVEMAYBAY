using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
    public partial class frm_TuyenBay : Form
    {
        SanBay sb;
        TuyenBay tb, tb2;
        public frm_TuyenBay()
        {
            InitializeComponent();
        }
        public void XemSanBay()
        {
            SanBayBUS sbBUS = new SanBayBUS();
            DataTable dt = new DataTable();
            dt = sbBUS.HienThi();
            dgv_SanBay.DataSource = dt;
            dgv_SanBay.Columns[0].HeaderText = "Mã sân bay";
            dgv_SanBay.Columns[1].HeaderText = "Tên sân bay";
            dgv_SanBay.Columns[2].HeaderText = "Vị trí";

            dgv_SanBay.AllowUserToAddRows = false;
            dgv_SanBay.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        public void XemTuyenBay()
        {
            TuyenBayBUS tbBUS = new TuyenBayBUS();
            DataTable dt = new DataTable();
            dt = tbBUS.HienThi();
            dgv_TuyenBay.DataSource = dt;
            dgv_TuyenBay.Columns[0].HeaderText = "Mã tuyến bay";
            dgv_TuyenBay.Columns[1].HeaderText = "Mã sân bay đi";
            //dgv_TuyenBay.Columns[2].HeaderText = "Mã sân bay đến";
            //dgv_TuyenBay.Columns[3].HeaderText = "Mã sân bay trung gian";

            dgv_TuyenBay.ColumnHeadersHeight = 40;

            dgv_TuyenBay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_TuyenBay.AllowUserToResizeColumns = false;
            dgv_TuyenBay.AllowUserToResizeRows = false;

            // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
            foreach (DataGridViewColumn column in dgv_TuyenBay.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }

            dgv_TuyenBay.AllowUserToAddRows = false;
            dgv_TuyenBay.EditMode = DataGridViewEditMode.EditProgrammatically;

            dgv_TuyenBay.AllowUserToAddRows = false;
            dgv_TuyenBay.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadComboBoxSanBayDi()
        {
            SanBayBUS sbBUS = new SanBayBUS();
            DataTable dt = new DataTable();
            dt = sbBUS.HienThi();
            cb_MaSanBayDi.DisplayMember = "MaSanBay";
            cb_MaSanBayDi.ValueMember = "MaSanBay";
            cb_MaSanBayDi.DataSource = dt;
        }
        private void LoadComboBoxSanBayDen()
        {
            SanBayBUS sbBUS = new SanBayBUS();
            DataTable dt = new DataTable();
            dt = sbBUS.HienThi();
            cb_MaSanBayDen.DisplayMember = "MaSanBay";
            cb_MaSanBayDen.ValueMember = "MaSanBay";
            cb_MaSanBayDen.DataSource = dt;
        }
        private void LoadComboBoxSanBayTrunGian()
        {
            SanBayBUS sbBUS = new SanBayBUS();
            DataTable dt = new DataTable();
            dt = sbBUS.HienThi();

        }
        private void frm_TuyenBay_Load(object sender, EventArgs e)
        {
            Bientoancuc.mamaybay = "";
            Bientoancuc.machuyenbay = "";
            Bientoancuc.giaghe = "";
            Bientoancuc.matuyenbay = "";
            XemSanBay();
            XemTuyenBay();
            LoadComboBoxSanBayDi();
            LoadComboBoxSanBayDen();
            LoadComboBoxSanBayTrunGian();
            cb_MaSanBayDi.SelectedIndex = -1;
            cb_MaSanBayDen.SelectedIndex = -1;

            txt_MaTuyenBay.Enabled = false;
        }
        private void dgv_SanBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgv_SanBay.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txt_MaSanBay.Text = row.Cells[0].Value.ToString();
                txt_TenSanBay.Text = row.Cells[1].Value.ToString();
                txt_ViTri.Text = row.Cells[2].Value.ToString();

                //Không cho phép sửa trường MaNV
                txt_MaSanBay.Enabled = false;
            }
        }
        public bool CheckNhapSB()
        {
            if (txt_MaSanBay.Text == "")
            {
                MessageBox.Show("Nhập mã nhân viên!");
                txt_MaSanBay.Focus();
                return false;
            }
            if (txt_TenSanBay.Text == "")
            {
                MessageBox.Show("Nhập tên sân bay!");
                txt_TenSanBay.Focus();
                return false;
            }
            if (txt_ViTri.Text == "")
            {
                MessageBox.Show("Nhập vị trí sân bay!");
                txt_ViTri.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Reset()
        {
            txt_MaSanBay.ResetText();
            txt_MaSanBay.Enabled = true;
            txt_TenSanBay.ResetText();
            txt_ViTri.ResetText();
            txt_MaSanBay.Focus();
            txt_MaTuyenBay.ResetText();
            cb_MaSanBayDen.ResetText();
            cb_MaSanBayDi.ResetText();
            //cb_MaSanBayTG.ResetText();
        }
        private void btn_ThemSB_Click(object sender, EventArgs e)
        {
            sb = new SanBay(txt_MaSanBay.Text, txt_TenSanBay.Text, txt_ViTri.Text);
            SanBayBUS sbBUS = new SanBayBUS();
            if (CheckNhapSB())
            {
                sbBUS.ThemSB(sb);
                //MessageBox.Show("Thêm sân bay mới thành công!");
                Reset();
                XemSanBay();
            }
        }
        private void btn_XoaSB_Click(object sender, EventArgs e)
        {
            SanBayBUS sbBUS = new SanBayBUS();
            if (txt_MaSanBay.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sân bay muốn xóa!");
            }
            else
            {
                sbBUS.XoaSB(txt_MaSanBay.Text);
                //MessageBox.Show("Xóa sân bay thành công!");
                Reset();
                XemSanBay();
            }
        }
        private void btn_SuaSB_Click(object sender, EventArgs e)
        {
            sb = new SanBay(txt_MaSanBay.Text, txt_TenSanBay.Text, txt_ViTri.Text);
            SanBayBUS sbBUS = new SanBayBUS();
            if (txt_MaSanBay.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sân bay muốn sửa!");
            }
            else
            {
                sbBUS.SuaSB(sb);
                //MessageBox.Show("Cập nhật sân bay thành công!");
                Reset();
                XemSanBay();
            }
        }
        private void btn_TimKiemSB_Click(object sender, EventArgs e)
        {
            if (txt_TimKiemMaSB.Text == "")
            {
                MessageBox.Show("Nhập mã sân bay muốn tìm!");
                txt_TimKiemMaSB.Focus();
            }
            else
            {
                SanBayBUS sbBUS = new SanBayBUS();
                DataTable dt = new DataTable();
                dt = sbBUS.TimSB(txt_TimKiemMaSB.Text);
                //txt_TimKiemMaSB.ResetText();
                if (dt.Rows.Count > 0)
                {
                    dgv_SanBay.DataSource = dt;
                    dgv_SanBay.Columns[0].HeaderText = "Mã sân bay";
                    dgv_SanBay.Columns[1].HeaderText = "Tên sân bay";
                    dgv_SanBay.Columns[2].HeaderText = "Vị trí";

                    dgv_SanBay.ColumnHeadersHeight = 40;

                    dgv_SanBay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    dgv_SanBay.AllowUserToResizeColumns = false;
                    dgv_SanBay.AllowUserToResizeRows = false;

                    // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
                    foreach (DataGridViewColumn column in dgv_TuyenBay.Columns)
                    {
                        column.Resizable = DataGridViewTriState.False;
                    }

                    dgv_SanBay.AllowUserToAddRows = false;
                    dgv_SanBay.EditMode = DataGridViewEditMode.EditProgrammatically;
                    //MessageBox.Show("Tìm sân bay thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sân bay!");
                }
            }
        }
        private void dgv_TuyenBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgv_TuyenBay.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txt_MaTuyenBay.Text = row.Cells[0].Value.ToString();

                string inputString = row.Cells[1].Value.ToString();

                // Tìm vị trí của ký tự gạch ngang "-"
                int dashIndex = inputString.IndexOf('-');

                // Cắt chuỗi ban đầu thành hai phần
                cb_MaSanBayDi.Text = inputString.Substring(10, dashIndex - 10);
                cb_MaSanBayDen.Text = inputString.Substring(dashIndex + 1);







                //cb_MaSanBayDi.Text = row.Cells[1].Value.ToString();
                //cb_MaSanBayDen.Text = row.Cells[2].Value.ToString();
                //cb_MaSanBayTG.Text = row.Cells[3].Value.ToString();

                //Không cho phép sửa trường MaNV
                txt_MaTuyenBay.Enabled = false;
            }
        }
        private void btn_ThemTB_Click(object sender, EventArgs e)
        {
            tb2 = new TuyenBay(cb_MaSanBayDi.Text, cb_MaSanBayDen.Text);
            TuyenBayBUS tuyenBay = new TuyenBayBUS();    
            string tenTuyenbay = tuyenBay.TaoTenTB(tb2);

            tb = new TuyenBay(tenTuyenbay,tenTuyenbay);
            TuyenBayBUS tbBUS = new TuyenBayBUS();
            tbBUS.ThemTB(tb);
            //MessageBox.Show("Thêm tuyến bay mới thành công!");
            Reset();
            XemTuyenBay();
        }
        private void btn_XoaTB_Click(object sender, EventArgs e)
        {
            TuyenBayBUS tbBUS = new TuyenBayBUS();
            if (txt_MaTuyenBay.Text == "")
            {
                MessageBox.Show("Vui lòng chọn tuyến bay muốn xóa!");
            }
            else
            {
                tbBUS.XoaTB(txt_MaTuyenBay.Text);
                //MessageBox.Show("Xóa sân bay thành công!");
                Reset();
                XemTuyenBay();
            }
        }
        private void btn_TimKiemTB_Click(object sender, EventArgs e)
        {
            if (txt_TimKiemMaTB.Text == "")
            {
                MessageBox.Show("Nhập mã tuyến bay muốn tìm!");
                txt_TimKiemMaTB.Focus();
            }
            else
            {
                TuyenBayBUS tbBUS = new TuyenBayBUS();
                DataTable dt = new DataTable();
                dt = tbBUS.TimTB(txt_TimKiemMaTB.Text);
                txt_TimKiemMaTB.ResetText();
                if (dt.Rows.Count > 0)
                {
                    dgv_TuyenBay.DataSource = dt;
                    dgv_TuyenBay.Columns[0].HeaderText = "Mã tuyến bay";
                    dgv_TuyenBay.Columns[1].HeaderText = "Mã sân bay đi";

                    dgv_TuyenBay.ColumnHeadersHeight = 40;

                    dgv_TuyenBay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    dgv_TuyenBay.AllowUserToResizeColumns = false;
                    dgv_TuyenBay.AllowUserToResizeRows = false;

                    // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
                    foreach (DataGridViewColumn column in dgv_TuyenBay.Columns)
                    {
                        column.Resizable = DataGridViewTriState.False;
                    }

                   
                    dgv_TuyenBay.AllowUserToAddRows = false;
                    dgv_TuyenBay.EditMode = DataGridViewEditMode.EditProgrammatically;
                    MessageBox.Show("Tìm tuyến bay thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tuyến bay!");
                }
            }
        }

        private void txt_TimKiemMaTB_TextChanged(object sender, EventArgs e)
        {
           
                TuyenBayBUS tbBUS = new TuyenBayBUS();
                DataTable dt = new DataTable();
                dt = tbBUS.TimTB(txt_TimKiemMaTB.Text);
               // txt_TimKiemMaTB.ResetText();
                if (dt.Rows.Count > 0)
                {
                    dgv_TuyenBay.DataSource = dt;
                    dgv_TuyenBay.Columns[0].HeaderText = "Mã tuyến bay";
                    dgv_TuyenBay.Columns[1].HeaderText = "Mã sân bay đi";

                    dgv_TuyenBay.ColumnHeadersHeight = 40;

                    dgv_TuyenBay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    dgv_TuyenBay.AllowUserToResizeColumns = false;
                    dgv_TuyenBay.AllowUserToResizeRows = false;

                    // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
                    foreach (DataGridViewColumn column in dgv_TuyenBay.Columns)
                    {
                        column.Resizable = DataGridViewTriState.False;
                    }

                    dgv_TuyenBay.AllowUserToAddRows = false;
                    dgv_TuyenBay.EditMode = DataGridViewEditMode.EditProgrammatically; 
                //MessageBox.Show("Tìm tuyến bay thành công!");
            }
                else if(txt_TimKiemMaTB.Text =="")
                {

                
                XemTuyenBay();
                }
                else
            {
               // MessageBox.Show("Không tìm thấy tuyến bay!");
            }

            
        }

        private void dgv_TuyenBay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_TimKiemMaSB_TextChanged(object sender, EventArgs e)
        {
            SanBayBUS sbBUS = new SanBayBUS();
            DataTable dt = new DataTable();
            dt = sbBUS.TimSB(txt_TimKiemMaSB.Text);
            //txt_TimKiemMaSB.ResetText();
            if (dt.Rows.Count > 0)
            {
                dgv_SanBay.DataSource = dt;
                dgv_SanBay.Columns[0].HeaderText = "Mã sân bay";
                dgv_SanBay.Columns[1].HeaderText = "Tên sân bay";
                dgv_SanBay.Columns[2].HeaderText = "Vị trí";

                dgv_SanBay.ColumnHeadersHeight = 40;

                dgv_SanBay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgv_SanBay.AllowUserToResizeColumns = false;
                dgv_SanBay.AllowUserToResizeRows = false;

                // Lặp qua từng cột và ngăn chặn thay đổi kích thước của cột
                foreach (DataGridViewColumn column in dgv_SanBay.Columns)
                {
                    column.Resizable = DataGridViewTriState.False;
                }

                dgv_SanBay.AllowUserToAddRows = false;
                dgv_SanBay.EditMode = DataGridViewEditMode.EditProgrammatically;
               // MessageBox.Show("Tìm sân bay thành công!");
            }
            else if (txt_TimKiemMaSB.Text == "")
            {
                //MessageBox.Show("Không tìm thấy sân bay!");
                XemSanBay();    
            }
            else
            {
                //MessageBox.Show("Không tìm thấy sân bay!");
            }
        }
    }
    }

