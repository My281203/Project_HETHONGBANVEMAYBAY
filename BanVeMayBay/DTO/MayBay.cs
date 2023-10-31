using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MayBay
    {
        private String mamaybay, tenmaybay;
        private int soghe, sogheb;
        public MayBay() { }
        public MayBay(string tenmaybay, int soghe, int soghe2)
        {
            
            this.Tenmaybay = tenmaybay;
            this.Soghe = soghe;
            this.SogheB = soghe2;
        }
        public MayBay(string mamaybay, string tenmaybay, int soghe, int soghe2)
        {
            this.Mamaybay = mamaybay;
            this.Tenmaybay = tenmaybay;
            this.Soghe = soghe;
            this.SogheB= soghe2;
        }

        public string Mamaybay { get => mamaybay; set => mamaybay = value; }
        public string Tenmaybay { get => tenmaybay; set => tenmaybay = value; }
        public int Soghe { get => soghe; set => soghe = value; }
        public int SogheB { get => sogheb; set => sogheb = value; }
    }
}
