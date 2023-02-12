using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameOfDevelopersBlog
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_kategoriler.DataSource = dm.KategoriListele();
            rp_kategoriler.DataBind();
            if (Session["uye"] != null)
            {
                pnl_girisVar.Visible = true;
                pnl_girisyok.Visible = false;
                Uye u = (Uye)Session["uye"];
                lbl_uye.Text = u.KullaniciAdi + "(" + u.Isim + " " + u.Soyisim + ")";
            }
            else
            {
                pnl_girisVar.Visible = false;
                pnl_girisyok.Visible = true;
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["uye"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}