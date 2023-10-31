using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        private string manv, cmnd, tennv, gioitinh, sdt, diachi;
        private DateTime ngaysinh;
        public NhanVien() { }
        public NhanVien(string manv, string cmnd, string tennv, string gioitinh, string sdt, string diachi, DateTime ngaysinh)
        {
            this.Manv = manv;
            this.Cmnd = cmnd;
            this.Tennv = tennv;
            this.Gioitinh = gioitinh;
            this.Sdt = sdt;
            this.Diachi = diachi;
            this.Ngaysinh = ngaysinh;
        }
        public NhanVien( string cmnd, string tennv, string gioitinh, string sdt, string diachi, DateTime ngaysinh)
        {
        
            this.Cmnd = cmnd;
            this.Tennv = tennv;
            this.Gioitinh = gioitinh;
            this.Sdt = sdt;
            this.Diachi = diachi;
            this.Ngaysinh = ngaysinh;
        }
        public string Manv { get => manv; set => manv = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        public string Tennv { get => tennv; set => tennv = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
    }
}
