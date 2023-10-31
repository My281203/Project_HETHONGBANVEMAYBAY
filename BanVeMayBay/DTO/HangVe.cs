using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HangVe
    {
        private string mahangve,s1, tenhangve,mahoadon, machuyenbay, trangthai;
        private int khoiluongtoida, dongia;
        private DateTime ngaydat;
        public HangVe() { }
        public HangVe(string mahangve, string tenhangve, string machuyenbay, int khoiluongtoida, int dongia)
        {
            this.Mahangve = mahangve;
            this.Tenhangve = tenhangve;
            this.Machuyenbay = machuyenbay;
            this.Khoiluongtoida = khoiluongtoida;
            this.Dongia = dongia;
        }
        public HangVe(DateTime ngaydat, string mahoadon,string trangthia, string s1)
        {
            this.Ngaydat = ngaydat;
            this.Mahoadon = mahoadon;
            this.Trangthai = trangthia;
            this.s1 = s1;
        }
        public HangVe(string mahangve,DateTime ngaydat, string mahoadon,string s1,string s2)
        {
            this.Mahangve= mahangve;
            this.Ngaydat = ngaydat;
            this.Mahoadon = mahoadon;
            this.s1 = s1;
            this.s1 = s1;
        }

        public string Mahangve { get => mahangve; set => mahangve = value; }
        public string Tenhangve { get => tenhangve; set => tenhangve = value; }
        public string Machuyenbay { get => machuyenbay; set => machuyenbay = value; }
        public int Khoiluongtoida { get => khoiluongtoida; set => khoiluongtoida = value; }
        public int Dongia { get => dongia; set => dongia = value; }
        public string Mahoadon { get => mahoadon; set => mahoadon = value;}
        public DateTime Ngaydat {  get => ngaydat; set => ngaydat = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
    }
}
