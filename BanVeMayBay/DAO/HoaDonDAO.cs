using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DTO;

namespace DAO
{
    public class HoaDonDAO:DBConnection
    {
        public void ThongKe(DateTime d1, DateTime d2, DataTable dt)
        {
            const string sql = "THONGKE";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@d1", SqlDbType.Date);
            sqlParameters[0].Value = Convert.ToDateTime(d1);
            sqlParameters[1] = new SqlParameter("@d2", SqlDbType.Date);
            sqlParameters[1].Value = Convert.ToDateTime(d2);
            executeThongKeQuery(sql, sqlParameters, dt);
        }
        public void SuaPhieuHoaDon(DanhSachHoaDon hd)
        {
            string sql = "SuaHoaDon";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@MaHoaDon", SqlDbType.Char);
            sqlParameters[0].Value = Convert.ToString(hd.MaHoaDon);
            sqlParameters[1] = new SqlParameter("@NgayLap", SqlDbType.DateTime);
            sqlParameters[1].Value = Convert.ToDateTime(hd.Ngaylap);
            sqlParameters[2] = new SqlParameter("@ThanhTien", SqlDbType.Char);
            sqlParameters[2].Value = Convert.ToString(hd.ThanhTien);
            sqlParameters[3] = new SqlParameter("@CCCD", SqlDbType.Char);
            sqlParameters[3].Value = Convert.ToString(hd.Makhachhang);
            sqlParameters[4] = new SqlParameter("@MaNV", SqlDbType.Char);
            sqlParameters[4].Value = Convert.ToString(hd.Manhanvien);

            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public void XoaHoaDon(string str)
        {
            string sql = "XoaHoaDon";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaHoaDon", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str);
            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public DataTable SearchPhieuHoaDon(string str)
        {
            string sql = "select * from  TimKiemTTHD(@str)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str);

            return executeSearchQuery(sql, sqlParameters);
        }
    }
}
