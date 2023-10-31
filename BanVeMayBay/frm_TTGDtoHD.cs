using BanVeMayBay.BUS;
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
    public partial class frm_TTGDtoHD : Form
    {
        public frm_TTGDtoHD()
        {
            InitializeComponent();
        }
        private bool check = false;
        public frm_TTGDtoHD(string machuyenbay) : this()
        {
            
        }
        public static string NumberToText(double inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "Không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };
            string[] placeValues = new string[] { "", "Nghìn", "Triệu", "Tỷ" };
            bool isNegative = false;

            // -12345678.3445435 => "-12345678"
            string sNumber = inputNumber.ToString("#");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }


            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "Một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "Lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "Lẻ " + result;
                        if (tens == 1) result = "Mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " Mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " Trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            return result + (suffix ? " Đồng" : "");
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
        // hàm dùng để tắt đóng form 
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
        private void frm_TTGDtoHD_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra tổ hợp phím Alt + F4
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                e.Handled = true; // Ngăn chặn sự kiện đóng form
            }
        }
        public void loadThongTinGiaoDich()
        {
            BanVeBUS nvBUS = new BanVeBUS();
            DataTable dt = new DataTable();
            DataTable dt1= new DataTable();
            DataTable dt2 = new DataTable();
            dt = nvBUS.layTTGDtoHoaDon();
            
            string ngaydat = dt.Rows[0].ItemArray[1].ToString();
            string magiaodich = dt.Rows[0].ItemArray[0].ToString();
            string cccd = dt.Rows[0].ItemArray[4].ToString();
            string maghe = dt.Rows[0].ItemArray[3].ToString();
            string machuyenbay = dt.Rows[0].ItemArray[2].ToString();

            lbthongtingiaodich.Text = magiaodich;

            lbngaydat.Text = Convert.ToDateTime(dt.Rows[0].ItemArray[1]).ToString("dd/MM/yyyy");

            KhachHangBUS khachHangBUS = new KhachHangBUS();
            dt1 = khachHangBUS.Search(cccd);
            // thong tin khachang
            txtcmnd.Text = dt1.Rows[0].ItemArray[0].ToString();
            txthoten.Text = dt1.Rows[0].ItemArray[1].ToString();
            txtsdt.Text = dt1.Rows[0].ItemArray[3].ToString();
           

            // thong tin chuyenbay 
            dt2 = nvBUS.LayNguocHBay(machuyenbay);
            txtchuyenbay.Text = dt2.Rows[0].ItemArray[6].ToString();
            dtpngaybay.Value = Convert.ToDateTime(dt2.Rows[0].ItemArray[5].ToString());
            txtgioikhoihanh.Text = dt2.Rows[0].ItemArray[0].ToString();
            // lay thong tin noi di noi den 
            BanVeBUS bv = new BanVeBUS();
            string noidi = dt2.Rows[0].ItemArray[2].ToString();
            string noiden = dt2.Rows[0].ItemArray[3].ToString();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            dt4 = bv.LayNguocTenDenVaDI(noidi);
            dt5 = bv.LayNguocTenDenVaDI(noiden);
            txtnoidi.Text = dt4.Rows[0].ItemArray[0].ToString();
            txtnoiden.Text = dt5.Rows[0].ItemArray[0].ToString();
            // thong tin soghe va gia ve
            DataTable dt6 = new DataTable();
           dt6 = bv.LayChoNgoi(maghe);
            txtsoghe.Text = dt6.Rows[0].ItemArray[0].ToString();
            txtgiaghe.Text = dt6.Rows[0].ItemArray[3].ToString();
            txttongtien.Text = txtgiaghe.Text;





        }

        
        private void frm_TTGDtoHD_Load(object sender, EventArgs e)
        {
        loadThongTinGiaoDich();
          
        }
    

        private void rbtnthe_CheckedChanged(object sender, EventArgs e)
        {
            txtkhachdua.Text = txttongtien.Text;
            txthoantien.Text = "0";
            txtkhachdua.Enabled = false;
        }

        private void rbtntienmat_CheckedChanged(object sender, EventArgs e)
        {
            txtkhachdua.Enabled = true;
            txtkhachdua.Focus();
        }

        private void btntinh_Click(object sender, EventArgs e)
        {
            bool isNum = true;
            if (txttongtien.Text != "" && isNum && txtkhachdua.Text != "")
            {
                txthoantien.Text = (Convert.ToInt32(txtkhachdua.Text) - Convert.ToInt32(txttongtien.Text)).ToString();
            }
        }

        private void btnthanhtoan_Click(object sender, EventArgs e)
        {

         

            DialogResult result = MessageBox.Show("Vui lòng thanh toán hóa đơn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                BanVeBUS bv = new BanVeBUS();
                string mnv = "NV001";
                HoaDon banVe = new HoaDon(Convert.ToDateTime(DateTime.Now), lbthongtingiaodich.Text, txtgiaghe.Text, txtcmnd.Text, mnv, "0", "1");
                bv.ThemHoaDon(banVe);
                this.Close();

            }
            else if (result == DialogResult.No)
            {


                BanVeBUS nvBUS = new BanVeBUS();
                DataTable dt = new DataTable();

                dt = nvBUS.layTTGDtoHoaDon();


                string magiaodich = dt.Rows[0].ItemArray[0].ToString();

                PhieuDatChoBUS ttgd = new PhieuDatChoBUS();
                ttgd.XoaPhieuDatCho(magiaodich);
                MessageBox.Show("Thông tin giao dịch bị xóa ");
                this.Close();
               
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            BanVeBUS nvBUS = new BanVeBUS();
            DataTable dt = new DataTable();

            dt = nvBUS.layTTGDtoHoaDon();


            string magiaodich = dt.Rows[0].ItemArray[0].ToString();

            PhieuDatChoBUS ttgd = new PhieuDatChoBUS();
            ttgd.XoaPhieuDatCho(magiaodich);
            MessageBox.Show("Thông tin giao dịch bị xóa ");
            this.Close();
        }

        private void frm_TTGDtoHD_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        private void frm_TTGDtoHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
