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
    public class MayBayDAO : DBConnection
    {
        public MayBayDAO() : base() { }
        public void ThemMB(MayBay mb)
        {
            const string sql = "ThemMayBay4";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@LoaiMayBay", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(mb.Tenmaybay);
            sqlParameters[1] = new SqlParameter("@SoGheLoaiA", SqlDbType.Int);
            sqlParameters[1].Value = Convert.ToString(mb.Soghe);
            sqlParameters[2] = new SqlParameter("@SoGheLoaiB", SqlDbType.Int);
            sqlParameters[2].Value = Convert.ToString(mb.SogheB);

            executeInsertQuery(sql, sqlParameters);
        }
        public void XoaMB(String maMB)
        {
            const string sql = "XoaMayBay";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaMayBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(maMB);

            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public void SuaMB(MayBay mb)
        {
            const string sql = "SuaMayBay";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@MaMayBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(mb.Mamaybay);
            sqlParameters[1] = new SqlParameter("@LoaiMayBay", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(mb.Tenmaybay);
            sqlParameters[2] = new SqlParameter("@SoGheLoaiA", SqlDbType.Int);
            sqlParameters[2].Value = Convert.ToString(mb.Soghe);
            sqlParameters[3] = new SqlParameter("@SoGheLoaiB", SqlDbType.Int);
            sqlParameters[3].Value = Convert.ToString(mb.SogheB);

            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public DataTable HienThi()
        {
            const string sql = "select * from XemMayBay";
            return executeDisplayQuery(sql);
        }
        public DataTable HienThi1()
        {
            const string sql = "select * from XemMayBay1";
            return executeDisplayQuery(sql);
        }
        public DataTable TimMB(String maMB)
        {
            const string sql = "TimMayBay @MaMayBay";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaMayBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(maMB);
            return executeSearchQuery(sql, sqlParameters);
        }
    }
}
