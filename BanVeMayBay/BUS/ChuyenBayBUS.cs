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
    public class ChuyenBayBUS
    {
        ChuyenBayDAO cbDAO;
        public ChuyenBayBUS()
        {
            cbDAO = new ChuyenBayDAO();
        }
        public void ThemCB(ChuyenBay cb)
        {
            cbDAO.ThemCB(cb);
        }
        public void XoaCB(String MaCB)
        {
            cbDAO.XoaCB(MaCB);
        }
        public void SuaCB(ChuyenBay cb)
        {
            cbDAO.SuaCB(cb);
        }
        public DataTable HienThi()
        {
            return cbDAO.HienThi();
        }
        public DataTable TimCB(String MaCB)
        {
            return cbDAO.TimCB(MaCB);
        }
        
    }
}
