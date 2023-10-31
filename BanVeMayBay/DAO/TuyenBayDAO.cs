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
    public class TuyenBayDAO : DBConnection
    {
        public TuyenBayDAO() : base() { }
        public void ThemTB(TuyenBay tb)
        {
            String sql;
            SqlParameter[] sqlParameters;
            sql = "TaoTenTuyenBay";
            sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@MaSanBayKhoiHanh", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(tb.Masanbaydi);
            sqlParameters[1] = new SqlParameter("@MaSanBayDen", SqlDbType.VarChar);
            executeInsertQuery(sql, sqlParameters);
        }
        public void XoaTB(String maTB)
        {
            const string sql = "XoaTuyenBay";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaTuyenBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(maTB);

            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public DataTable HienThi()
        {
            const string sql = "select * from TUYENBAY";
            return executeDisplayQuery(sql);
        }
        public DataTable TimTB(String maTB)
        {
            const string sql = "TimTuyenBay @MaTuyenBay";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaTuyenBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(maTB);

            return executeSearchQuery(sql, sqlParameters);
        }
        public string TaoTenTuyenBay(string maSanBayKhoiHanh, string maSanBayDen)
        {
            // Chuỗi kết nối đến cơ sở dữ liệu của bạn
            string connectionString = "Data Source=LAPTOP-T8IH679N\\GIAHAN;Initial Catalog=HETHONGBANVEMAYBAY;User ID=sa;Password=05092003";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("TaoTenTuyenBay", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure; // Đặt kiểu lệnh là StoredProcedure

                    // Thêm tham số đầu vào
                    cmd.Parameters.Add(new SqlParameter("@MaSanBayKhoiHanh", SqlDbType.VarChar, 15));
                    cmd.Parameters["@MaSanBayKhoiHanh"].Value = maSanBayKhoiHanh;

                    cmd.Parameters.Add(new SqlParameter("@MaSanBayDen", SqlDbType.VarChar, 15));
                    cmd.Parameters["@MaSanBayDen"].Value = maSanBayDen;

                    // Thêm tham số đầu ra
                    cmd.Parameters.Add(new SqlParameter("@TenTB", SqlDbType.NVarChar, 50));
                    cmd.Parameters["@TenTB"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    // Lấy kết quả từ tham số đầu ra
                    string tenTuyenBay = cmd.Parameters["@TenTB"].Value.ToString();
                    return tenTuyenBay;
                }
            }
        }

    }
}
