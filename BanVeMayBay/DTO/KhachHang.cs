using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanVeMayBay.DTO
{
    internal class KhachHang
    {
        private string CMND, TenKH, SDT, GioiTinh, DiaChi;
        private DateTime NgaySinh;

        public KhachHang() { }
        public KhachHang(string cMND, string tenKH, string sDT, string gioiTinh, string diaChi, DateTime ngaySinh)
        {
            CMND = cMND;
            TenKH = tenKH;
            SDT = sDT;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
            NgaySinh = ngaySinh;
        }
        public string cMND { get => CMND; set => CMND = value; }
        public string tenKH { get => TenKH; set => TenKH = value; }
        public string sDT { get => SDT; set => SDT = value; }
        public string gioiTinh { get => GioiTinh; set => GioiTinh = value; }
        public string diaChi { get => DiaChi; set => DiaChi = value; }
        public DateTime ngaySinh { get => NgaySinh; set => NgaySinh = value; }

    }
}
