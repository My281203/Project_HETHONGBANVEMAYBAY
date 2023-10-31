using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanVeMayBay.DTO
{
    internal class ChoNgoi
    {
        private string maghe, loaighe, giaghe, mamaybay;
        private int tinhtrang;
        public ChoNgoi() { }

        public ChoNgoi(string maghe, string loaighe, string giaghe, string mamaybay,int tinhtrang)
        {
            this.MaGhe = maghe;
            this.LoaiGhe = loaighe;
            this.GiaGhe = giaghe;
            this.MaMayBay = mamaybay;
            this.TinhTrang = tinhtrang;
        }
        public ChoNgoi(string loaighe, string giaghe, string mamaybay, int tinhtrang)
        {
          
            this.LoaiGhe = loaighe;
            this.GiaGhe = giaghe;
            this.MaMayBay = mamaybay;
            this.TinhTrang = tinhtrang;
        }
        public string MaGhe
        {
            get { return maghe; }
            set { maghe = value; }
        }

        // Property cho loaighe
        public string LoaiGhe
        {
            get { return loaighe; }
            set { loaighe = value; }
        }

        // Property cho giaghe
        public string GiaGhe
        {
            get { return giaghe; }
            set { giaghe = value; }
        }

        // Property cho mamaybay
        public string MaMayBay
        {
            get { return mamaybay; }
            set { mamaybay = value; }
        }

        // Property cho tinhtrang
        public int TinhTrang
        {
            get { return tinhtrang; }
            set { tinhtrang = value; }
        }
    }
}
