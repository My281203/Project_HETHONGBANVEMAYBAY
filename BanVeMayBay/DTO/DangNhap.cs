using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DangNhap
    {
        private string TaiKhoan, MatKhau, MaNV;
        private bool UyQuyen;

        public DangNhap() { }

        public DangNhap(string maNV, string taiKhoan, string matKhau, bool uyQuyen)
        {
            MaNV = maNV;
            TaiKhoan = taiKhoan;
            MatKhau = matKhau;
            UyQuyen = uyQuyen;
        }
        public string maNV { get => MaNV; set => MaNV = value; }
        public string taiKhoan { get => TaiKhoan; set => TaiKhoan = value; }
        public string matKhau { get => MatKhau; set => MatKhau = value; }
        public bool uyQuyen { get => UyQuyen; set => UyQuyen = value; }


    }
}