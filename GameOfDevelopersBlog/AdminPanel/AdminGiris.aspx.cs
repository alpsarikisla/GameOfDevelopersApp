using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameOfDevelopersBlog.AdminPanel
{
    public partial class AdminGiris : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_giris_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_mail.Text) && !string.IsNullOrEmpty(tb_sifre.Text))
            {
                Yonetici y = dm.AdminGiris(tb_mail.Text, tb_sifre.Text);
                if (y != null)
                {
                    if (y.Durum)
                    {
                        Session["yonetici"] = y;
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        pnl_hata.Visible = true;
                        lbl_hata.Text = "Kullanıcı Hesabınız Aktif değil";
                    }
                }
                else
                {
                    pnl_hata.Visible = true;
                    lbl_hata.Text = "Kullanıcı Bulunamadı";
                }
            }
            else
            {
                pnl_hata.Visible = true;
                lbl_hata.Text = "Kullanıcı Adı ve Şifre Boş olamaz";
            }
        }
    }
}