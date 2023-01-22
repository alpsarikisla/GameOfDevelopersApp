using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfDevelopersBlog.AdminPanel
{
    public class Yardimci
    {
        public string ResimAdiUretici()
        {
            string[] abidikler = { "?", "!", "&", "%", "+", "?*F" };

            Random rnd = new Random();
            string isim = string.Empty;
            isim += "0X";

            isim += rnd.Next(100, 999);
            isim += (char)rnd.Next(65, 90) + (char)rnd.Next(65, 90) + (char)rnd.Next(65, 90);
            isim += abidikler[rnd.Next(0,abidikler.Length)];
            return isim;

        }
    }
}