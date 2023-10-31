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
    public class TaiKhoanDAO : DBConnection
    {
        public void DoiMatKhau(DangNhap tk, string matKhauMoi, string matKhauMoiNL)
        {
            const string sql = "DOIMATKHAU";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@taiKhoan", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(tk.taiKhoan);
            sqlParameters[1] = new SqlParameter("@matKhau", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(tk.matKhau);

            sqlParameters[2] = new SqlParameter("@matKhauMoi", SqlDbType.VarChar);
            sqlParameters[2].Value = Convert.ToString(matKhauMoi);
            sqlParameters[3] = new SqlParameter("@matKhauMoiNL", SqlDbType.VarChar);
            sqlParameters[3].Value = Convert.ToString(matKhauMoiNL);
            executeDMKQuery(sql, sqlParameters);
        }
        public DataTable DoiMatKhau(string str)
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
        public void showInformation(DangNhap tk, DataTable dt)
        {
            const string sql = "SHOWINFORMATION";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@TaiKhoan", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(tk.taiKhoan);

            executeShowInformation(sql, sqlParameters, dt);
        }
        public DataTable Login(DangNhap tk)
        {
            string sql = "select * from Dang_Nhap(@Username,@Password)";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@Username", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(tk.taiKhoan);
            sqlParameters[1] = new SqlParameter("@Password", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(tk.matKhau);

            return executeSearchQuery(sql, sqlParameters);
        }
    }
}