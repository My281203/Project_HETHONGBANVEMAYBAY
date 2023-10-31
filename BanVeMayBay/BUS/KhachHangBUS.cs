using BanVeMayBay.DAO;
using BanVeMayBay.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanVeMayBay.BUS
{
    internal class KhachHangBUS
    {
        private KhachHangDAO khDAO;
        public KhachHangBUS()
        {
            khDAO = new KhachHangDAO();
        }
        public void ThemKH(KhachHang kh)
        {
            khDAO.ThemKH(kh);
        }
        public DataTable HienThi() {
            return khDAO.HienThi();
        }
        public void XoaKH(KhachHang kh)
        {
            khDAO.XoaKH(kh);
        }
        public void SuaKH(KhachHang kh, string str_cmnd) 
        { 
            khDAO.SuaKH(kh, str_cmnd);
        }
        public DataTable Search(string str) 
        {
            return khDAO.Search(str);       
        }
    }
}
