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
    public class HangVeBUS
    {
        HangVeDAO hvDAO;
        public HangVeBUS()
        {
            hvDAO = new HangVeDAO();
        }
        public void ThemHV(HangVe hv)
        {
            hvDAO.ThemHV(hv);
        }
        public void XoaHV(String MaHV)
        {
            hvDAO.XoaHV(MaHV);
        }
        public void SuaHV(HangVe hv)
        {
            hvDAO.SuaHV(hv);
        }
        public DataTable HienThi()
        {
            return hvDAO.HienThi();
        }
        public DataTable TimHV(String MaHV)
        {
            return hvDAO.TimHV(MaHV);
        }
    }
}
