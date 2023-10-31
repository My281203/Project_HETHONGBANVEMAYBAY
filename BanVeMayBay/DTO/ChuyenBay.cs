using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChuyenBay
    {
        private string machuyenbay, matuyenbay, mamaybay, thoigianbay, giokhoihanh, thoigianden;
        private DateTime ngaybay;
        private int soghehang1, soghehang2;
        public ChuyenBay() { }
        public ChuyenBay(string matuyenbay, string mamaybay, DateTime ngaybay, string giokhoihanh, string thoigianbay, string thoigianden)
        {
           
            this.Matuyenbay = matuyenbay;
            this.Mamaybay = mamaybay;
            this.Ngaybay = ngaybay;
            this.Giokhoihanh = giokhoihanh;
            this.Thoigianbay = thoigianbay;
            this.Thoigianden = thoigianden;
          
        }
        public ChuyenBay(string machuyenbay,string matuyenbay, string mamaybay, DateTime ngaybay, string giokhoihanh, string thoigianbay, string thoigianden)
        {
            this.Machuyenbay = machuyenbay;
            this.Matuyenbay = matuyenbay;
            this.Mamaybay = mamaybay;
            this.Ngaybay = ngaybay;
            this.Giokhoihanh = giokhoihanh;
            this.Thoigianbay = thoigianbay;
            this.Thoigianden = thoigianden;

        }


        public string Machuyenbay { get => machuyenbay; set => machuyenbay = value; }
        public string Matuyenbay { get => matuyenbay; set => matuyenbay = value; }
        public string Mamaybay { get => mamaybay; set => mamaybay = value; }
        public DateTime Ngaybay { get => ngaybay; set => ngaybay = value; }
        public string Giokhoihanh { get => giokhoihanh; set => giokhoihanh = value; }
        public string Thoigianbay { get => thoigianbay; set => thoigianbay = value; }
        public string Thoigianden { get => thoigianden; set => thoigianden = value; }
        public int Soghehang1 { get => soghehang1; set => soghehang1 = value; }
        public int Soghehang2 { get => soghehang2; set => soghehang2 = value; }
    }
}
