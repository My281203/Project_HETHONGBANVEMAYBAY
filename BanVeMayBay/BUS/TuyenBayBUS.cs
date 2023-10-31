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
    public class TuyenBayBUS
    {
        private TuyenBayDAO tbDAO;
        public TuyenBayBUS()
        {
            tbDAO = new TuyenBayDAO();
        }
        public void ThemTB(TuyenBay tb)
        {
            tbDAO.ThemTB(tb);
        }
        public void XoaTB(String MaTB)
        {
            tbDAO.XoaTB(MaTB);
        }
        public DataTable HienThi()
        {
            return tbDAO.HienThi();
        }
        public DataTable TimTB(String MaTB)
        {
            return tbDAO.TimTB(MaTB);
        }
        public string TaoTenTB(TuyenBay tb2)
        {
            return tbDAO.TaoTenTuyenBay(tb2.Masanbaydi, tb2.Masanbayden);
        }
    }
}
