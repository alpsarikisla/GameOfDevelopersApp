using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameOfDevelopersBlog.AdminPanel
{
    public partial class MakaleDuzenle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["mid"]);
                ddl_kategoriler.DataTextField = "Isim";
                ddl_kategoriler.DataValueField = "ID";
                ddl_kategoriler.DataSource = dm.KategoriListele();
                ddl_kategoriler.DataBind();

                Makale m = dm.MakaleGetir(id);

                ddl_kategoriler.SelectedValue = m.Kategori_ID.ToString();
                tb_baslik.Text = m.Baslik;
                tb_icerik.Text = m.Icerik;
                tb_ozet.Text = m.Ozet;
                img_resim.ImageUrl = "../MakaleResimleri/"+m.Resim;
                cb_yayinda.Checked = m.Yayinda;
            }
            else
            {
                Response.Redirect("MakaleListele.aspx");
            }
        }

        protected void lbtn_duzenle_Click(object sender, EventArgs e)
        {

        }
    }
}