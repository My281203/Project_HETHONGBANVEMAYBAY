using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class DanhSachHoaDon
    {
        public DanhSachHoaDon() { }
        private string mahoadon, maphieudatcho, manhanvien, makhachhang, thanhtien;
        DateTime ngaylap;
        public DanhSachHoaDon(string mahoadon,DateTime ngaylap,string maphieudatcho,string manhanvien,string makhachhang,string thanhtien)       
        {
            this.mahoadon = mahoadon;
            this.makhachhang = makhachhang;
            this.maphieudatcho = maphieudatcho;
            this.ngaylap = ngaylap;
            this.manhanvien = manhanvien;
            this.thanhtien = thanhtien;
        }
        public DanhSachHoaDon(string mahoadon, DateTime ngaylap,  string manhanvien, string makhachhang, string thanhtien)
        {
            this.mahoadon = mahoadon;
            this.makhachhang = makhachhang;
            this.ngaylap = ngaylap;
            this.manhanvien = manhanvien;
            this.thanhtien = thanhtien;
        }

        public string Makhachhang { get => makhachhang; set => makhachhang = value; }
        public DateTime Ngaylap { get => ngaylap; set => ngaylap = value; }
        public string MaHoaDon { get => mahoadon; set => mahoadon = value; }
        public string Maphieudatcho { get => maphieudatcho; set => maphieudatcho = value; }
        public string ThanhTien { get => thanhtien; set => thanhtien = value; }
        public string Manhanvien { get => manhanvien; set => manhanvien = value; }
    }
}
