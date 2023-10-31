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
    public class ChuyenBayDAO : DBConnection
    {
        public ChuyenBayDAO() : base() { }

        public void ThemCB(ChuyenBay cb)
        {
            const string sql = "ThemChuyenBay1";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@NgayBay", SqlDbType.Date);
            sqlParameters[0].Value = Convert.ToString(cb.Ngaybay);
            sqlParameters[1] = new SqlParameter("@GioKhoiHanh", SqlDbType.Time);
            sqlParameters[1].Value = Convert.ToString(cb.Giokhoihanh);
            sqlParameters[2] = new SqlParameter("@ThoiGianBay", SqlDbType.Time);
            sqlParameters[2].Value = Convert.ToString(cb.Thoigianbay);
            sqlParameters[3] = new SqlParameter("@ThoiGianDenDuKien", SqlDbType.Time);
            sqlParameters[3].Value = Convert.ToString(cb.Thoigianden);
            sqlParameters[4] = new SqlParameter("@MaTuyenBay", SqlDbType.VarChar);
            sqlParameters[4].Value = Convert.ToString(cb.Matuyenbay);
            sqlParameters[5] = new SqlParameter("@MaMayBay", SqlDbType.VarChar);
            sqlParameters[5].Value = Convert.ToString(cb.Mamaybay);

            executeInsertQuery(sql, sqlParameters);
        }
        public void XoaCB(String maCB)
        {
            const string sql = "XoaChuyenBay";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaChuyenBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(maCB);

            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public void SuaCB(ChuyenBay cb)
        {
            const string sql = "SuaChuyenBay";
            SqlParameter[] sqlParameters = new SqlParameter[7];
            sqlParameters[0] = new SqlParameter("@MaChuyenBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(cb.Machuyenbay);
            sqlParameters[1] = new SqlParameter("@NgayBay", SqlDbType.Date);
            sqlParameters[1].Value = Convert.ToDateTime(cb.Ngaybay);
            sqlParameters[2] = new SqlParameter("@ThoiGianBay", SqlDbType.Time);
            sqlParameters[2].Value = Convert.ToDateTime(cb.Thoigianbay);
            sqlParameters[3] = new SqlParameter("@ThoiGianDenDuKien", SqlDbType.Time);
            sqlParameters[3].Value = Convert.ToDateTime(cb.Thoigianden);
            sqlParameters[4] = new SqlParameter("@GioKhoiHanh", SqlDbType.Time);
            sqlParameters[4].Value = Convert.ToDateTime(cb.Giokhoihanh);
            sqlParameters[5] = new SqlParameter("@MaTuyenBay", SqlDbType.VarChar);
            sqlParameters[5].Value = Convert.ToString(cb.Matuyenbay);
            sqlParameters[6] = new SqlParameter("@MaMayBay", SqlDbType.VarChar);
            sqlParameters[6].Value = Convert.ToString(cb.Mamaybay);

            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public DataTable HienThi()
        {
            const string sql = "select * from XemChuyenBay";
            return executeDisplayQuery(sql);
        }
   
        public DataTable TimCB(String maCB)
        {
            const string sql = "TimChuyenBay @MaChuyenBay";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaChuyenBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(maCB);

            return executeSearchQuery(sql, sqlParameters);
        }
    }
}
