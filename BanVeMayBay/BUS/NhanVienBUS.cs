using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhanVienBUS
    {
        private NhanVienDAO nvDAO;
        public NhanVienBUS()
        {
            nvDAO = new NhanVienDAO();
        }
        public void ThemNV(NhanVien nv)
        {
            nvDAO.ThemNV(nv);
        }
        public void XoaNV(String MaNV)
        {
            nvDAO.XoaNV(MaNV);
        }
        public void SuaNV(NhanVien nv)
        {
            nvDAO.SuaNV(nv);
        }
        public DataTable HienThi()
        {
            return nvDAO.HienThi();
        }
        public DataTable Search(string str)
        {
            return nvDAO.Search(str);
        }
    }
}
