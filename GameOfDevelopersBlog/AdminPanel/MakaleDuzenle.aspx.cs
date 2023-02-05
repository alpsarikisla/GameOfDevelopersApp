using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
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
                if (!IsPostBack)
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
                    img_resim.ImageUrl = "../MakaleResimleri/" + m.Resim;
                    cb_yayinda.Checked = m.Yayinda;
                }
            }
            else
            {
                Response.Redirect("MakaleListele.aspx");
            }
        }

        protected void lbtn_duzenle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["mid"]);
            Makale m = dm.MakaleGetir(id);
            m.Baslik = tb_baslik.Text;
            m.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
            m.Icerik = tb_icerik.Text;
            m.Ozet = tb_ozet.Text;
            m.Yayinda = cb_yayinda.Checked;
            if (fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".png")
                {
                    string uzanti = fi.Extension;
                    string isim = Guid.NewGuid().ToString();
                    m.Resim = isim + uzanti;
                    fu_resim.SaveAs(Server.MapPath("~/MakaleResimleri/" + isim + uzanti));
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_mesaj.Text = "Resim uzantısı sadece .jpg veya .png olmalıdır";
                }
            }
            if (dm.MakaleDuzenle(m))
            {
                pnl_basarisiz.Visible = false;
                pnl_basarili.Visible = true;
                tb_baslik.Text = tb_icerik.Text = tb_ozet.Text = "";
                cb_yayinda.Checked = false;
                ddl_kategoriler.SelectedValue = "0";
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Makale Düzenleme Başarısız";
            }
        }
    }
}