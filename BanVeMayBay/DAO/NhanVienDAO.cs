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
    public class NhanVienDAO : DBConnection
    {
        public NhanVienDAO() : base() { }
        public void ThemNV(NhanVien nv)
        {
            const string sql = "ThemNV";
            SqlParameter[] sqlParameters = new SqlParameter[6];
     
            sqlParameters[0] = new SqlParameter("@CCCD", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(nv.Cmnd);
            sqlParameters[1] = new SqlParameter("@TenNV", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(nv.Tennv);
            sqlParameters[2] = new SqlParameter("@NgaySinh", SqlDbType.Date);
            sqlParameters[2].Value = Convert.ToString(nv.Ngaysinh);
            sqlParameters[3] = new SqlParameter("@GioiTinh", SqlDbType.NVarChar);
            sqlParameters[3].Value = Convert.ToString(nv.Gioitinh);
            sqlParameters[4] = new SqlParameter("@SDT", SqlDbType.NVarChar);
            sqlParameters[4].Value = Convert.ToString(nv.Sdt);
            sqlParameters[5] = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            sqlParameters[5].Value = Convert.ToString(nv.Diachi);
            executeInsertQuery(sql, sqlParameters);
        }
        public void XoaNV(String maNV)
        {
            const string sql = "XoaNV";
            const String sql2 = "XoaPhanQuyenNhanVien";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaNV", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(maNV);
            executeUpdateOrDeleteQuery(sql, sqlParameters);
            executeUpdateOrDeleteQuery(sql2, sqlParameters);
        }
        public void SuaNV(NhanVien nv)
        {
            const string sql = "SuaNV";
            SqlParameter[] sqlParameters = new SqlParameter[7];
            sqlParameters[0] = new SqlParameter("@MaNV", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(nv.Manv);
            sqlParameters[1] = new SqlParameter("@CCCD", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(nv.Cmnd);
            sqlParameters[2] = new SqlParameter("@TenNV", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(nv.Tennv);
            sqlParameters[3] = new SqlParameter("@NgaySinh", SqlDbType.Date);
            sqlParameters[3].Value = Convert.ToDateTime(nv.Ngaysinh);
            sqlParameters[4] = new SqlParameter("@GioiTinh", SqlDbType.NVarChar);
            sqlParameters[4].Value = Convert.ToString(nv.Gioitinh);
            sqlParameters[5] = new SqlParameter("@SDT", SqlDbType.VarChar);
            sqlParameters[5].Value = Convert.ToString(nv.Sdt);
            sqlParameters[6] = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            sqlParameters[6].Value = Convert.ToString(nv.Diachi);
            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public DataTable HienThi()
        {
            const string sql = "select * from XemNV";
            return executeDisplayQuery(sql);
        }
        public DataTable Search(string str)
        {
            string sql = "select * from TimKiem_NV(@str)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str);
            return executeSearchQuery(sql,sqlParameters);
        }

        public string GetNextMaNV()
        {
            string nextMaNV = null;
            // Định nghĩa câu truy vấn SQL để lấy mã nhân viên tiếp theo từ cơ sở dữ liệu.
            string sql = "SELECT dbo.GetNextMaNV() AS NextMaNV";

            using (SqlCommand sqlCommand = new SqlCommand(sql, openConnection()))
            {
                nextMaNV = sqlCommand.ExecuteScalar() as string;
            }
            return nextMaNV;
        }
    }
}