using DataAccessLayer;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameOfDevelopersBlog.AdminPanel
{
    public partial class MakaleEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_kategoriler.DataTextField = "Isim";
                ddl_kategoriler.DataValueField = "ID";
                ddl_kategoriler.DataSource = dm.KategoriListele();
                ddl_kategoriler.DataBind();
            }
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddl_kategoriler.SelectedItem.Value) != 0)
            {
                Makale mak = new Makale();
                mak.GoruntulemeSayisi = 0;
                mak.EklemeTarih = DateTime.Now;
                mak.BegeniSayisi = 0;
                mak.Yayinda = cb_yayinda.Checked;
                Yonetici y = (Yonetici)Session["yonetici"];
                mak.Yonetici_ID = y.ID;
                mak.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
                mak.Baslik = tb_baslik.Text;
                mak.Icerik = tb_icerik.Text;
                mak.Ozet = tb_ozet.Text;
                if (fu_resim.HasFile)
                {
                    FileInfo fi = new FileInfo(fu_resim.FileName);
                    if (fi.Extension == ".jpg" || fi.Extension == ".png")
                    {
                        string uzanti = fi.Extension;
                        string isim = Guid.NewGuid().ToString();
                        mak.Resim = isim + uzanti;
                        fu_resim.SaveAs(Server.MapPath("~/MakaleResimleri/" + isim + uzanti));
                        if (dm.MakaleEkle(mak))
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
                            lbl_mesaj.Text = "Makale Ekleme Başarısız";
                        }
                    }
                    else
                    {
                        pnl_basarisiz.Visible = true;
                        pnl_basarili.Visible = false;
                        lbl_mesaj.Text = "Resim uzantısı sadece .jpg veya .png olmalıdır";
                    }
                }
                else
                {
                    mak.Resim = "none.png";
                    if (dm.MakaleEkle(mak))
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
                        lbl_mesaj.Text = "Makale Ekleme Başarısız";
                    }
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text= "Kategori seçimi yapmalısınız";
            }
        }
    }
}