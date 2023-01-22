﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameOfDevelopersBlog.AdminPanel
{
    public partial class KategoriEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text.Trim()))
            {
                if (dm.VeriControl("Kategoriler", "Isim", tb_isim.Text.Trim()))
                {
                    Kategori k = new Kategori();
                    k.Isim = tb_isim.Text;
                    k.Silinmis = false;
                    if (dm.KategoriEkle(k))
                    {
                        pnl_basarili.Visible = true;
                        pnl_basarisiz.Visible = false;
                        tb_isim.Text = "";
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Kategori eklenirken bir hata oluştu";
                    }
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Kategori Daha Önce Eklenmiş";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Kategori Adı boş bırakılamaz";
            }
        }
    }
}