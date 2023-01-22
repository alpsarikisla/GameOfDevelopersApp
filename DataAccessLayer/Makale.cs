using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Makale
    {
        public int ID { get; set; }
        public int Kategori_ID { get; set; }
        public string Kategori { get; set; }
        public int Yonetici_ID { get; set; }
        public string Yonetici { get; set; }
        public string Baslik { get; set; }
        public string Ozet { get; set; }
        public string Icerik { get; set; }
        public string Resim { get; set; }
        public int GoruntulemeSayisi { get; set; }
        public DateTime EklemeTarih { get; set; }
        public int BegeniSayisi { get; set; }
        public bool Yayinda { get; set; }

    }
}
