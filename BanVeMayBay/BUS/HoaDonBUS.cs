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
    public class HoaDonBUS
    {
        private HoaDonDAO hdDAO;

        public HoaDonBUS()
        {
            hdDAO = new HoaDonDAO();
        }
        public void ThongKe(DateTime d1, DateTime d2, DataTable dt)
        {
            hdDAO.ThongKe(d1, d2,dt);
        }
        public void SuaPhieuDSHoaDon(DanhSachHoaDon hd)
        {
     
            hdDAO.SuaPhieuHoaDon(hd);
        }
        public DataTable SearchPhieuHoaDon(string str)
        {
            return hdDAO.SearchPhieuHoaDon(str);
        }
        //public DataTable HienThiPhieuDatCho()
        //{
        //    return pdc.hienthiPhieuDatCho();
       // }
        public void XoaPhieuHoaDon(string str)
        {
            hdDAO.XoaHoaDon(str);
        }
    }
}
