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
    public class SanBayBUS
    {
        private SanBayDAO sbDAO;
        public SanBayBUS()
        {
            sbDAO = new SanBayDAO();
        }
        public void ThemSB(SanBay sb)
        {
            sbDAO.ThemSB(sb);
        }
        public void XoaSB(String MaSB)
        {
            sbDAO.XoaSB(MaSB);
        }
        public void SuaSB(SanBay sb)
        {
            sbDAO.SuaSB(sb);
        }
        public DataTable HienThi()
        {
            return sbDAO.HienThi();
        }
        public DataTable TimSB(String MaSB)
        {
            return sbDAO.TimSanBay(MaSB);
        }
    }
}
