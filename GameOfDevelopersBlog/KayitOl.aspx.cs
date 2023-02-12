using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameOfDevelopersBlog
{
    public partial class KayitOl : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_kayit_Click(object sender, EventArgs e)
        {
            Uye u = new Uye();
            u.Isim = tb_isim.Text;
            u.Soyisim = tb_soyisim.Text;
            u.Mail = tb_mail.Text;
            u.Durum = true;
            u.Sifre = tb_sifre.Text;
            u.KullaniciAdi = tb_kullaniciAdi.Text;

            if (dm.UyeEkle(u))
            {
                lbl_mesaj.Text = "Başarılı";
            }
            else
            {
                lbl_mesaj.Text = "Başarısız";
            }
        }
    }
}