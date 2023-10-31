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
    public class MayBayBUS
    {
        MayBayDAO mbDAO;
        public MayBayBUS()
        {
            mbDAO = new MayBayDAO();
        }
        public void ThemMB(MayBay mb)
        {
            mbDAO.ThemMB(mb);
        }
        public void XoaMB(String MaMB)
        {
            mbDAO.XoaMB(MaMB);
        }
        public void SuaMB(MayBay mb)
        {
            mbDAO.SuaMB(mb);
        }
        public DataTable HienThi()
        {
            return mbDAO.HienThi();
        }
        public DataTable HienThi1()
        {
            return mbDAO.HienThi1();
        }
        public DataTable TimMB(String MaMB)
        {
            return mbDAO.TimMB(MaMB);
        }
    }
}
