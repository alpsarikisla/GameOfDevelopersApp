using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region Yonetici Metotları

        public Yonetici AdminGiris(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Mail = @mail AND Sifre = @sifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());

                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT Y.ID, Y.YoneticiTur_ID,Y.Isim, Y.Soyisim,Y.KullaniciAdi, Y.Sifre,Y.Mail,Y.Durum, YT.Isim FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YoneticiTur_ID = YT.ID WHERE Y.Mail = @mail AND Y.Sifre = @sifre";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@sifre", sifre);
                    //con.Open();//SAKIN YAPMA
                    SqlDataReader reader = cmd.ExecuteReader();
                    Yonetici y = new Yonetici();
                    while (reader.Read())
                    {
                        y.ID = reader.GetInt32(0);
                        y.YoneticiTur_ID = reader.GetInt32(1);
                        y.Isim = reader.GetString(2);
                        y.Soyisim = reader.GetString(3);
                        y.KullaniciAdi = reader.GetString(4);
                        y.Sifre = reader.GetString(5);
                        y.Mail = reader.GetString(6);
                        y.Durum = reader.GetBoolean(7);
                        y.YoneticiTur = reader.GetString(8);
                    }
                    return y;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }

        #endregion

        #region Kategori İşlemleri

        public bool KategoriKontrol(string isim)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Kategoriler WHERE Isim = @isim";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", isim);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally { con.Close(); }
        }

        public bool KategoriEkle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(Isim) VALUES(@isim)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", kat.Isim);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            { return false; }
            finally { con.Close(); }
        }

        public List<Kategori> KategoriListele()
        {
            List<Kategori> kategoriler = new List<Kategori>();
            try
            {
                cmd.CommandText = "SELECT * FROM Kategoriler WHERE Silinmis = 0";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori k = new Kategori();
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    k.Silinmis = reader.GetBoolean(2);
                    kategoriler.Add(k);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }

        public bool KategoriGuncelle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Isim = @isim WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", kat.ID);
                cmd.Parameters.AddWithValue("@isim", kat.Isim);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }

        //public void KategoriSil(int id)
        //{
        //    try
        //    {
        //        cmd.CommandText = "DELETE FROM Kategoriler WHERE ID=@id";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@id", id);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    finally { con.Close(); }
        //}
        public void KategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Silinmis = 1 WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally { con.Close(); }
        }

        public Kategori KategoriGetir(int id)
        {
            try
            {
                Kategori k = new Kategori();
                cmd.CommandText = "SELECT * FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    k.Silinmis = reader.GetBoolean(2);
                }
                return k;
            }
            catch
            { return null; }
            finally { con.Close(); }
        }
        #endregion

        #region Makale Metotları

        public bool MakaleEkle(Makale mak)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Makaleler(Kategori_ID, Yonetici_ID, Baslik, Ozet, Icerik, Resim, GoruntulemeSayisi, EklemeTarihi, BegeniSayisi, Yayinda) VALUES(@kategori_ID, @yonetici_ID, @baslik, @ozet, @icerik, @resim, @goruntulemeSayisi, @eklemeTarihi, @begeniSayisi, @yayinda)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategori_ID", mak.Kategori_ID);
                cmd.Parameters.AddWithValue("@yonetici_ID", mak.Yonetici_ID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@resim", mak.Resim);
                cmd.Parameters.AddWithValue("@goruntulemeSayisi", mak.GoruntulemeSayisi);
                cmd.Parameters.AddWithValue("@eklemeTarihi", mak.EklemeTarih);
                cmd.Parameters.AddWithValue("@begeniSayisi", mak.BegeniSayisi);
                cmd.Parameters.AddWithValue("@yayinda", mak.Yayinda);
                con.Open();
                cmd.ExecuteReader();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
       
        public List<Makale> MakaleListele()
        {
            try
            {
                List<Makale> Makaleler = new List<Makale>();
                cmd.CommandText = "SELECT M.ID, M.Kategori_ID, K.Isim, M.Yonetici_ID, Y.KullaniciAdi, M.Baslik, M.Ozet, M.Icerik, M.Resim, M.GoruntulemeSayisi, M.EklemeTarihi, M.BegeniSayisi, M.Yayinda FROM Makaleler AS M JOIN Kategoriler AS K ON M.Kategori_ID = K.ID JOIN Yoneticiler AS Y ON M.Yonetici_ID = Y.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Makale m = new Makale();
                    m.ID = reader.GetInt32(0);
                    m.Kategori_ID = reader.GetInt32(1);
                    m.Kategori = reader.GetString(2);
                    m.Yonetici_ID = reader.GetInt32(3);
                    m.Yonetici = reader.GetString(4);
                    m.Baslik = reader.GetString(5);
                    m.Ozet = reader.GetString(6);
                    m.Icerik = reader.GetString(7);
                    m.Resim = reader.GetString(8);
                    m.GoruntulemeSayisi = reader.GetInt32(9);
                    m.EklemeTarih = reader.GetDateTime(10);
                    m.EklemeTarihStr = reader.GetDateTime(10).ToShortDateString();
                    m.BegeniSayisi = reader.GetInt32(11);
                    m.Yayinda = reader.GetBoolean(12);
                    m.YayindaStr = reader.GetBoolean(12) ? "<label style='color:green'>Aktif</label>" : "<label style='color:gray'>Pasif</label>";
                    Makaleler.Add(m);
                }
                return Makaleler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Makale MakaleGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT M.ID, M.Kategori_ID, K.Isim, M.Yonetici_ID, Y.KullaniciAdi, M.Baslik, M.Ozet, M.Icerik, M.Resim, M.GoruntulemeSayisi, M.EklemeTarihi, M.BegeniSayisi, M.Yayinda FROM Makaleler AS M JOIN Kategoriler AS K ON M.Kategori_ID = K.ID JOIN Yoneticiler AS Y ON M.Yonetici_ID = Y.ID WHERE M.ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                Makale m = new Makale();
                while (reader.Read())
                {
                    m.ID = reader.GetInt32(0);
                    m.Kategori_ID = reader.GetInt32(1);
                    m.Kategori = reader.GetString(2);
                    m.Yonetici_ID = reader.GetInt32(3);
                    m.Yonetici = reader.GetString(4);
                    m.Baslik = reader.GetString(5);
                    m.Ozet = reader.GetString(6);
                    m.Icerik = reader.GetString(7);
                    m.Resim = reader.GetString(8);
                    m.GoruntulemeSayisi = reader.GetInt32(9);
                    m.EklemeTarih = reader.GetDateTime(10);
                    m.EklemeTarihStr = reader.GetDateTime(10).ToShortDateString();
                    m.BegeniSayisi = reader.GetInt32(11);
                    m.Yayinda = reader.GetBoolean(12);
                    m.YayindaStr = reader.GetBoolean(12) ? "<label style='color:green'>Aktif</label>" : "<label style='color:gray'>Pasif</label>";
                }
                return m;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool MakaleDuzenle(Makale m)
        {
            try
            {
                cmd.CommandText = "UPDATE Makaleler SET Baslik = @baslik, Kategori_ID=kategori_ID, Ozet=@ozet, Icerik=@icerik, Resim=@resim, Yayinda=@yayinda WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", m.ID);
                cmd.Parameters.AddWithValue("@baslik", m.Baslik);
                cmd.Parameters.AddWithValue("@kategori_ID", m.Kategori_ID);
                cmd.Parameters.AddWithValue("@ozet", m.Ozet);
                cmd.Parameters.AddWithValue("@icerik", m.Icerik);
                cmd.Parameters.AddWithValue("@resim", m.Resim);
                cmd.Parameters.AddWithValue("@yayinda", m.Yayinda);

                con.Open();

                cmd.ExecuteNonQuery();
                return true;
             
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool MakaleSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE Yorumlar WHERE Makale_ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE Makaleler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Yorum Metotları

        public List<Yorum> YorumlariListele()
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.Makale_ID, M.Baslik, Y.Yonetici_ID, YY.KullaniciAdi, Y.Uye_ID, U.KullaniciAdi, U.Isim +' '+ U.Soyisim, Y.Icerik, Y.Onay FROM Yorumlar AS Y JOIN Makaleler AS M ON Y.Makale_ID = M.ID JOIN Yoneticiler AS YY ON Y.Yonetici_ID = YY.ID JOIN Uyeler AS U ON Y.Uye_ID = U.ID";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader= cmd.ExecuteReader();
                while (reader.Read())
                {
                    yorumlar.Add(new Yorum()
                    {
                        ID = reader.GetInt32(0),
                        Makale_ID = reader.GetInt32(1),
                        Makale = reader.GetString(2),
                        Yonetici_ID = reader.GetInt32(3),
                        Yonetici = reader.GetString(4),
                        Uye_ID = reader.GetInt32(5),
                        Uye = reader.GetString(7) + "(" + reader.GetString(6) + ")",
                        Icerik = reader.GetString(8),
                        Onay = reader.GetBoolean(9)
                    });
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Yardımcılar

        public bool VeriControl(string tablo, string kolon, string veri)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM " + tablo + " WHERE " + kolon + " = @isim";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", veri);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally { con.Close(); }
        }

        #endregion
    }
}
