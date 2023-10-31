using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HangVeDAO : DBConnection
    {
        public HangVeDAO() : base() { }
        public void ThemHV(HangVe hv)
        {
            const string sql = "ThemVeChuyenBay";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@NgayTaoVe", SqlDbType.DateTime);
            sqlParameters[0].Value = Convert.ToString(hv.Ngaydat);
            sqlParameters[1] = new SqlParameter("@MaHoaDon", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(hv.Mahoadon);
            sqlParameters[2] = new SqlParameter("@is_deleted", SqlDbType.Bit);
            sqlParameters[2].Value = Convert.ToSByte(hv.Trangthai);


            executeInsertQuery(sql, sqlParameters);
        }
        public void XoaHV(String maHV)
        {
            const string sql = "XoaVeChuyenBay";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaVe", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(maHV);
            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public void SuaHV(HangVe hv)
        {
            const string sql = "SuaHangVe";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@MaHangVe", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(hv.Mahangve);
            sqlParameters[1] = new SqlParameter("@KhoiLuongToiDa", SqlDbType.Int);
            sqlParameters[1].Value = Convert.ToString(hv.Khoiluongtoida);
            sqlParameters[2] = new SqlParameter("@DonGia", SqlDbType.Money);
            sqlParameters[2].Value = Convert.ToString(hv.Dongia);

            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public DataTable HienThi()
        {
            const string sql = "select * from XemVeChuyenBay";
            return executeDisplayQuery(sql);
        }
        public DataTable TimHV(String maHV)
        {
            const string sql = "TimHangVe @MaVe";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaVe", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(maHV);

            return executeSearchQuery(sql, sqlParameters);
        }
    }
}
