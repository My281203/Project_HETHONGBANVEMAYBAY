using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public  class BanVe
    {
        private string machuyenbay, soghe, hangghe, makhachhang, mahangve, tennv, mahoadon, maphieudatcho, thanhtien, maphieu;
        private string khoiluonghanhli, s1;
        private string matuyenbay, manhanvien;
        private string noidi, noiden, trangthai;
        private string machuyenbayold;
        private DateTime thoigiandat,ngaydi,ngaylap;
        private string  s2, s3;
        public BanVe() { }
        public BanVe(string maphieudatcho,string thanhtien,DateTime ngaylap,string makhachhang, string manhanvien)
        {
          
            this.Maphieudatcho = maphieudatcho;
            this.ThanhTien = thanhtien;
            this.Ngaylap = ngaylap;
            this.Makhachhang = makhachhang;
            this.Manhanvien = manhanvien;
        }
        public BanVe( DateTime ngaylap, string maphieudatcho, string thanhtien, string makhachhang, string manhanvien,string trangthai)
        {
            this.ThanhTien = thanhtien;
            this.Ngaylap = ngaylap;
            this.Manhanvien = manhanvien;
            this.Makhachhang = makhachhang;
            this.Maphieudatcho=maphieudatcho;
            this.Trangthai = trangthai;
        }
        public  BanVe(string maphieudatcho,DateTime thoigiandat,string machuyenbay,string soghe, string makhachhang)
        {
            //this.maphieu = maphieu;
            this.Maphieudatcho = maphieudatcho;
            this.ThoiGianDat=thoigiandat;
            this.Soghe = soghe;
            this.Machuyenbay = machuyenbay;
            this.Makhachhang = makhachhang;

        }
        public BanVe(DateTime thoigiandat,string machuyenbay, string maghe,string makhachhang,string trangthai)
        {
            //this.maphieu = maphieu;
            this.ThoiGianDat = thoigiandat;
            this.Machuyenbay = machuyenbay;
            this.Soghe = maghe;
            this.Makhachhang = makhachhang;
            this.Trangthai = trangthai;
           
        }
        public BanVe(string mahoadon, DateTime thoigiandat, string thanhtien, string makhachhang, string maNV, string s1, string s2, string s3)
        {
        
            this.ThoiGianDat = thoigiandat;
            this.MaHoaDon = mahoadon;
            this.ThanhTien = thanhtien;
            this.Makhachhang = makhachhang;
            this.Manhanvien = maNV;
            this.s1 = s1;
            this.s2 = s2;
            this.s3 = s3;
                  
        }
        public BanVe(string maphieudatcho, DateTime thoigiandat, string soghe, string hangghe, string machuyenbay, string makhachhang, string mahangve)
        {
            //this.maphieu = maphieu;
            this.maphieudatcho = maphieudatcho;
            this.thoigiandat = thoigiandat;
            this.soghe = soghe;
            this.hangghe = hangghe;
            this.machuyenbay = machuyenbay;
            this.makhachhang = makhachhang;
            this.mahangve = mahangve;
           
         
        }
        public string Noidi { get => noidi; set => noidi = value; } 
        public string Noiden { get => noiden; set => noiden = value; }
        public DateTime Ngaylap { get => ngaylap; set => ngaylap = value; }
     
       /* public BanVe(string machuyenbay,string matuyenbay, string soghe, string hangghe, string makhachhang, string mahangve, string tennv, string mahoadon,string maphieudatcho,string thanhtien,string maphieu,int khoiluonghanhli,DateTime thoigiandat,DateTime ngaydi)
        {
            this.machuyenbay = machuyenbay;
            this.soghe = soghe;
            this.hangghe = hangghe;
            this.makhachhang = makhachhang;
            this.mahangve = mahangve;
            this.tennv = tennv;
            this.mahoadon = mahoadon;
            this.maphieu = maphieu;
            this.maphieudatcho = maphieudatcho;
            this.thanhtien = thanhtien;
            this.khoiluonghanhli = khoiluonghanhli;
            this.ngaydi = ngaydi;
            this.thoigiandat = thoigiandat;
            this.matuyenbay = matuyenbay;
        }
       */
        public string Machuyenbay { get => machuyenbay; set => machuyenbay = value; }

        public string Soghe { get => soghe; set => soghe = value; }
        public string Hangghe { get => hangghe; set => hangghe = value; }
        public string Makhachhang { get => makhachhang; set => makhachhang = value; }
        public string Tennv { get => tennv; set => tennv = value; }

        public string MaHangVe { get => mahangve; set => mahangve = value; }
        public string MaHoaDon { get => mahoadon; set => mahoadon = value; }
        public string Maphieu { get => maphieu; set => maphieu = value; }
        public string Maphieudatcho { get => maphieudatcho;set => maphieudatcho = value; }
        public string ThanhTien { get => thanhtien; set => thanhtien = value; }
        public string KhoiLuongHanhLi { get => khoiluonghanhli; set => khoiluonghanhli = value; }
        public DateTime NgayDi { get => ngaydi; set => ngaydi = value; }
        public DateTime ThoiGianDat { get => thoigiandat;set => thoigiandat = value; }
        public string MaTuyenBay { get => matuyenbay; set => matuyenbay = value; }
        public string Manhanvien { get => manhanvien; set => manhanvien = value; }
        public string Machuyenbayold { get => machuyenbayold; set => machuyenbayold = value; }
        public string Trangthai {  get => trangthai; set => trangthai = value; }
    }
}
