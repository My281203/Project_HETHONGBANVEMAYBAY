using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
    public class Bientoancuc
    {
        public static string soghe = "";
        public static string matuyenbay = "";
        public static string machuyenbay = "";
        public static DateTime ngaybay;
        public static DateTime gioikhoihanh;
        public static string mamaybay = "";
        public static string manhanvien;
        public static bool check = false;
        public static string connection;
        public static string giaghe;
    }
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_DangNhap());
        }
    }
}
