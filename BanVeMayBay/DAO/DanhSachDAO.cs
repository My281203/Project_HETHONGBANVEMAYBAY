using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public  class DanhSachDAO : DBConnection
    {
        public DanhSachDAO() : base() { }
        public void ThemPhieuDatCho(BanVe bv)
        {
            //@MaPhieu,@ThoiGianDat,@Soghe,@HangGhe,@MaChuyenBay,@CMND,@MaHangVe,@KhoiLuongHanhLi
            string sql = "ThemPhieuDatCho3";
            SqlParameter[] sqlParameters = new SqlParameter[8];
            sqlParameters[0] = new SqlParameter("@MaPhieu", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(bv.Maphieudatcho);
            sqlParameters[1] = new SqlParameter("@ThoiGianDat", SqlDbType.DateTime);
            sqlParameters[1].Value = Convert.ToDateTime(bv.ThoiGianDat);
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
            sqlParameters[7] = new SqlParameter("@KhoiLuongHanhLi", SqlDbType.Int);
            sqlParameters[7].Value = Convert.ToInt32(bv.KhoiLuongHanhLi);

            executeInsertQuery(sql, sqlParameters);
        }
        public void SuaPhieuDatCho(BanVe bv)
        {
            string sql = "SuaPhieuDatCho";
            SqlParameter[] sqlParameters = new SqlParameter[8];
            sqlParameters[0] = new SqlParameter("@MaPhieu", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(bv.Maphieudatcho);
            sqlParameters[1] = new SqlParameter("@ThoiGianDat", SqlDbType.DateTime);
            sqlParameters[1].Value = Convert.ToDateTime(bv.ThoiGianDat);
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
            sqlParameters[7] = new SqlParameter("@KhoiLuongHanhLi", SqlDbType.Int);
            sqlParameters[7].Value = Convert.ToInt32(bv.KhoiLuongHanhLi);
            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public DataTable SearchPhieuDatCho(string str)
        {
            string sql = "select * from  SearchPhieuDatCho(@str1)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str1", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str);

            return executeSearchQuery(sql, sqlParameters);
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
        public void ThemHoaDon(BanVe bv)
        {
            string sql = "ThemHoaDon_1";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@MaHoaDon", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(bv.MaHoaDon);
            sqlParameters[1] = new SqlParameter("@MaPhieuDatCho", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(bv.Maphieudatcho);
            sqlParameters[2] = new SqlParameter("@ThanhTien", SqlDbType.Money);
            sqlParameters[2].Value = Convert.ToDecimal(bv.ThanhTien);
            sqlParameters[3] = new SqlParameter("@NgayLap", SqlDbType.DateTime);
            sqlParameters[3].Value = Convert.ToString(bv.Ngaylap);
            sqlParameters[4] = new SqlParameter("@MaNhanVien", SqlDbType.VarChar);
            sqlParameters[4].Value = Convert.ToString(bv.Manhanvien);
            sqlParameters[5] = new SqlParameter("CMND", SqlDbType.NVarChar);
            sqlParameters[5].Value = Convert.ToString(bv.Makhachhang);
            executeInsertQuery(sql, sqlParameters);
        }
        public void CapNhatHoaDon(BanVe bv)
        {
            string sql = "SuaHoaDon_1";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@MaHD", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(bv.MaHoaDon);
            sqlParameters[1] = new SqlParameter("@MaPhieuDatCho", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(bv.Maphieudatcho);
            sqlParameters[2] = new SqlParameter("@ThanhTien", SqlDbType.Money);
            sqlParameters[2].Value = Convert.ToDecimal(bv.ThanhTien);
            sqlParameters[3] = new SqlParameter("@NgayLap", SqlDbType.DateTime);
            sqlParameters[3].Value = Convert.ToDateTime(bv.Ngaylap);
            sqlParameters[4] = new SqlParameter("@MaNhanVien", SqlDbType.VarChar);
            sqlParameters[4].Value = Convert.ToString(bv.Manhanvien);
            sqlParameters[5] = new SqlParameter("CMND", SqlDbType.NVarChar);
            sqlParameters[5].Value = Convert.ToString(bv.Makhachhang);
            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
    }
}
