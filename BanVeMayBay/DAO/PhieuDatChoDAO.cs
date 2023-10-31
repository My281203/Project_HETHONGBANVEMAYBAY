using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BanVeMayBay.DAO
{
   public class PhieuDatChoDAO : DBConnection
    {
        public PhieuDatChoDAO() : base() { }
        public DataTable LayChuyenBay(string str)
        {
            string sql = "select * from LayChuyenBay_1(@str1)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str1", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(str);

            return executeSearchQuery(sql, sqlParameters);

        }
        public DataTable LayChuyenBay1()
        {
            string sql = "select * from CHUYENBAY";
            return executeDisplayQuery(sql);
        }
        public DataTable LayChuyenBay2(DateTime str1,string str2)
        {
            string sql = "select * from HienThiChuyenBay(@ngaybay,@matuyenbay)";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@ngaybay", SqlDbType.Date);
            sqlParameters[0].Value = str1;
            sqlParameters[1] = new SqlParameter("matuyenbay", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(str2);
            return executeSearchQuery(sql, sqlParameters);
        }
        public DataTable LayChoNgoi(string str1)
        {
            string sql = "select * from [dbo].[XemChoNgoiMayBay](@mamaybay1)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
        
            sqlParameters[0] = new SqlParameter("@mamaybay1", SqlDbType.VarChar);
            sqlParameters[0].Value = str1;
            return executeSearchQuery(sql, sqlParameters);
        }
        public void ThemPhieuDatCho(DanhSachPhieuDatCho bv)
        {
            //@MaPhieu,@ThoiGianDat,@Soghe,@HangGhe,@MaChuyenBay,@CMND,@MaHangVe,@KhoiLuongHanhLi
            string sql = "ThemPhieuDatCho";
            SqlParameter[] sqlParameters = new SqlParameter[8];
            sqlParameters[0] = new SqlParameter("@MaPhieu", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(bv.Maphieu);
            sqlParameters[1] = new SqlParameter("@ThoiGianDat", SqlDbType.DateTime);
            sqlParameters[1].Value = Convert.ToDateTime(bv.NgayDat);
            sqlParameters[2] = new SqlParameter("@Soghe", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(bv.Soghe);
            sqlParameters[3] = new SqlParameter("@HangGhe", SqlDbType.NVarChar);
            sqlParameters[3].Value = Convert.ToString(bv.Hangghe);
            sqlParameters[4] = new SqlParameter("@MaChuyenBay", SqlDbType.VarChar);
            sqlParameters[4].Value = Convert.ToString(bv.Machuyenbay);
            sqlParameters[5] = new SqlParameter("CMND", SqlDbType.NVarChar);
            sqlParameters[5].Value = Convert.ToString(bv.Makhachhang);
            sqlParameters[6] = new SqlParameter("@MaHangVe", SqlDbType.NVarChar);
            sqlParameters[6].Value = Convert.ToString(bv.MaHangVe);


            executeInsertQuery(sql, sqlParameters);
        }
        public void SuaPhieuDatCho(DanhSachPhieuDatCho bv)
        {
            string sql = "SuaThongTinGiaoDich";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@MaGiaoDich", SqlDbType.Char);
            sqlParameters[0].Value = Convert.ToString(bv.Maphieu);
            sqlParameters[1] = new SqlParameter("@NgayDat", SqlDbType.DateTime);
            sqlParameters[1].Value = Convert.ToDateTime(bv.NgayDat);
            sqlParameters[2] = new SqlParameter("@MaChuyenBay", SqlDbType.Char);
            sqlParameters[2].Value = Convert.ToString(bv.Machuyenbay);
            sqlParameters[3] = new SqlParameter("@MaGhe", SqlDbType.Char);
            sqlParameters[3].Value = Convert.ToString(bv.Soghe);
            sqlParameters[4] = new SqlParameter("@CCCD", SqlDbType.Char);
            sqlParameters[4].Value = Convert.ToString(bv.Makhachhang);
            
            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public void XoaPhieuDatCho(string str)
        {
            string sql = "XoaThongTinGiaoDich";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaGiaoDich", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str);
      

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
        public DataTable hienthiPhieuDatCho()
        {
            const string sql = "select * from THONGTINGIAODICH";
            return executeDisplayQuery(sql);
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
    }
}
