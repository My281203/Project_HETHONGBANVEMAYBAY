using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanBay
    {
        private string masanbay, tensanbay, vitri;
        public SanBay() { }
        public SanBay(string masanbay, string tensanbay, string vitri)
        {
            this.MaSanBay = masanbay;
            this.TenSanBay = tensanbay;
            this.ViTri = vitri;
        }

        public string MaSanBay { get => masanbay; set => masanbay = value; }
        public string TenSanBay { get => tensanbay; set => tensanbay = value; }
        public string ViTri { get => vitri; set => vitri = value; }
    }
}
