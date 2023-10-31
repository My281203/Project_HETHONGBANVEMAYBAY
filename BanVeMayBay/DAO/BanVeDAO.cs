using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DTO;
using BanVeMayBay;
using System.Security.Cryptography;
using System.Net.NetworkInformation;

namespace DAO
{
    public class BanVeDAO : DBConnection
    {
        public BanVeDAO() : base() { }

        public DataTable hienthiNoiBay()
        {
            const string sql = "select ViTri from SANBAY";
            return executeDisplayQuery(sql);
        }
        // public DataTable LayTuyenBay()
        //  {
        //     const string sql = "";
        //  }

        public DataTable hienthiKhachHang()
        {
            const string sql = "select * from KHACHHANG";
            return executeDisplayQuery(sql);
        }
        public DataTable hienthiPhieuDatCho()
        {
            const string sql = "select * from THONGTINGIAODICH ";
            return executeDisplayQuery(sql);
        }
        public DataTable hienthiPhieuHoaDon()
        {
            const string sql = "select * from HOADON ";
            return executeDisplayQuery(sql);
        }
        public DataTable TimKiemTuyenBay(string str, string str2)
        {
            string sql = "select * from TimKiem_TuyenBay(@str,@str2)";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@str", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(str);
            sqlParameters[1] = new SqlParameter("@str2", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(str2);
            // sqlParameters[2] = new SqlParameter("@ngaybay", SqlDbType.DateTime);
            // sqlParameters[1].Value = Convert.ToDateTime(date);

            return executeSearchQuery(sql, sqlParameters);
        }
        public DataTable TimKiemGioBay2(string str, DateTime date)
        {
            string sql = "select * from TimKiemKhungGioBay(@ngaybay,@matuyenbay)";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@ngaybay", SqlDbType.Date);
            sqlParameters[0].Value = date;
            sqlParameters[1] = new SqlParameter("@matuyenbay", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(str);

            return executeSearchQuery(sql, sqlParameters);

        }
        public DataTable SearchSoGhe(string str, DateTime date, string time)
        {
            string sql = "select * from LaySoGhe4(@ngaybay,@matuyenbay,@giokhoihanh)";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@ngaybay", SqlDbType.Date);
            sqlParameters[0].Value = date;
            sqlParameters[1] = new SqlParameter("@matuyenbay", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(str);
            sqlParameters[2] = new SqlParameter("@giokhoihanh", DbType.Time);
            sqlParameters[2].Value = Convert.ToString(time);
            return executeSearchQuery(sql, sqlParameters);
        }
        public DataTable LayGhe(int soghe1)
        {
            string sql = "LayGhe3 @soghe";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@soghe", SqlDbType.Int);
            sqlParameters[0].Value = soghe1;

            return executeSearchQuery(sql, sqlParameters);
        }
        public DataTable LayHangVe(string str1)
        {
            string sql = "select * from LayHangVe_15(@str1)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str1", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str1);

            return executeSearchQuery(sql, sqlParameters);
        }
        public DataTable LayNguocGioMayBayvaMaSanBay(string str)
        {
            string sql = "select * from LayNguocGioBayvaMaSanBay(@str1)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str1", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str);

            return executeSearchQuery(sql, sqlParameters);
        }
        public DataTable LayChoNgoi(string str)
        {
            string sql = "select * from LayChoNgoi(@str1)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str1", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str);

            return executeSearchQuery(sql, sqlParameters);
        }
        public DataTable LayNguocGioKhoiHanh_1(string str)
        {
            string sql = "select * from LayNguocGioKhoiHanh_1(@str1)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str1", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str);

            return executeSearchQuery(sql, sqlParameters);
        }
        public void ThemPhieuDatCho(BanVe bv)
        {
            //@MaPhieu,@ThoiGianDat,@Soghe,@HangGhe,@MaChuyenBay,@CMND,@MaHangVe,@KhoiLuongHanhLi
            string sql = "ThemGiaoDich";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@NgayDat", SqlDbType.DateTime);
            sqlParameters[0].Value = Convert.ToDateTime(bv.ThoiGianDat);
            sqlParameters[1] = new SqlParameter("@MaChuyenBay", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(bv.Machuyenbay);
            sqlParameters[2] = new SqlParameter("@MaGhe", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(bv.Soghe);
            sqlParameters[3] = new SqlParameter("@CCCD", SqlDbType.NVarChar);
            sqlParameters[3].Value = Convert.ToString(bv.Makhachhang);
            sqlParameters[4] = new SqlParameter("@is_deleted", SqlDbType.Bit);
            sqlParameters[4].Value = Convert.ToSByte(bv.Trangthai);


            executeInsertQuery(sql, sqlParameters);
        }
        public DataTable LayMaGDtoHD()
        {
            string sql = "GetMaGiaoDichCuoi1";
            return executeDisplayQuery(sql);
        }
        public DataTable LayThongTinVeByMaVe(string str)
        {
            string sql = "select * from  GetThongTinVeByMaVe(@str)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str);
            return executeSearchQuery(sql, sqlParameters);
        }
        public void SuaPhieuDatCho(BanVe bv)
        {
            string sql = "SuaThongTinGiaoDich";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@MaGiaoDich", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(bv.Maphieudatcho);
            sqlParameters[1] = new SqlParameter("@NgayDat", SqlDbType.Date);
            sqlParameters[1].Value = Convert.ToDateTime(bv.ThoiGianDat);
            sqlParameters[2] = new SqlParameter("@MaChuyenBay", SqlDbType.Char);
            sqlParameters[2].Value = Convert.ToString(bv.Machuyenbay);
            sqlParameters[3] = new SqlParameter("@MaGhe", SqlDbType.Char);
            sqlParameters[3].Value = Convert.ToString(bv.Soghe);
            sqlParameters[4] = new SqlParameter("@CCCD", SqlDbType.Char);
            sqlParameters[4].Value = Convert.ToString(bv.Makhachhang);
          
            
            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public DataTable SearchPhieuDatCho(string str)
        {
            string sql = "select * from  TimKiemTTGD(@str)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str);

            return executeSearchQuery(sql, sqlParameters);
        }
      
        public DataTable HuyVe(string str)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(BanVeMayBay.Properties.Resources.cnnstr))
            {
                using (SqlCommand command = new SqlCommand("HuyVe", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the parameter
                    command.Parameters.Add("@MaVe", SqlDbType.VarChar).Value = str;

                    connection.Open();

                    // Execute the command
                    SqlDataReader reader = command.ExecuteReader();

                    // Load the data into a DataTable
                    dt.Load(reader);
                }
            }

            return dt;
        }
        public DataTable DoiVe(string str,string str1,string str2,string str3,string str4)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(BanVeMayBay.Properties.Resources.cnnstr))
            {
                using (SqlCommand command = new SqlCommand("DoiVe", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the parameter
                    command.Parameters.Add("@MaVe", SqlDbType.VarChar).Value = str;
                    command.Parameters.Add("@MaChuyenBaynew", SqlDbType.VarChar).Value = str1;
                    command.Parameters.Add("@MaTuyenBaynew", SqlDbType.VarChar).Value = str2;
                    command.Parameters.Add("@MaGhenew", SqlDbType.VarChar).Value = str3;
                    command.Parameters.Add("@GiaGhenew", SqlDbType.Int).Value = int.Parse(str4);

                    connection.Open();

                    // Execute the command
                    SqlDataReader reader = command.ExecuteReader();

                    // Load the data into a DataTable
                    dt.Load(reader);
                }
            }

            return dt;
        }
        public DataTable LayPhieuDatChotoHoaDon()
        {
            string sql = "select * from LayPhieuDatCho()";
            return executeDisplayQuery(sql);
        }
        public DataTable LayThongTinTruyVanChoHoaDon(string str)
        {
            string sql = "select * from  LayThongTinTruyVanchoHoaDon(@str1)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str1", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str);

            return executeSearchQuery(sql, sqlParameters);
        }
        public DataTable LayThongTinGiaTienHoaDon(string str)
        {
            string sql = "select * from  LayThongTinGiaTienHoaDon(@str)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str);

            return executeSearchQuery(sql, sqlParameters);
        }
        public void ThemHoaDon(HoaDon bv)
        {
            string sql = "ThemHoaDon";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@MaGiaoDich", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(bv.MaPhieuDatCho);
            sqlParameters[1] = new SqlParameter("@NgayLap", SqlDbType.DateTime);
            sqlParameters[1].Value = Convert.ToDateTime(bv.NgayLap);
            sqlParameters[2] = new SqlParameter("@ThanhTien", SqlDbType.Int);
            sqlParameters[2].Value = Convert.ToString(bv.Giaghe);
            sqlParameters[3] = new SqlParameter("@CCCD", SqlDbType.VarChar);
            sqlParameters[3].Value = Convert.ToString(bv.KhachHang_CMND);
            sqlParameters[4] = new SqlParameter("@MaNV", SqlDbType.VarChar);
            sqlParameters[4].Value = Convert.ToString(bv.NhanVien_maNV);
            sqlParameters[5] = new SqlParameter("@is_deleted", SqlDbType.Bit);
            sqlParameters[5].Value = Convert.ToSByte(bv.TrangThai);

            executeInsertQuery(sql, sqlParameters);
        }
        public void CapNhatHoaDon(BanVe bv)
        {
            string sql = "SuaHoaDon";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@MaHoaDon", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(bv.MaHoaDon);
            sqlParameters[1] = new SqlParameter("@NgayLap", SqlDbType.DateTime);
            sqlParameters[1].Value = Convert.ToDateTime(bv.ThoiGianDat);
            sqlParameters[2] = new SqlParameter("@ThanhTien", SqlDbType.Int);
            sqlParameters[2].Value = Convert.ToString(bv.ThanhTien);
            sqlParameters[3] = new SqlParameter("@CCCD", SqlDbType.VarChar);
            sqlParameters[3].Value = Convert.ToString(bv.Makhachhang);
            sqlParameters[4] = new SqlParameter("@MaNV", SqlDbType.VarChar);
            sqlParameters[4].Value = Convert.ToString(bv.Manhanvien);
            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
    }

}
