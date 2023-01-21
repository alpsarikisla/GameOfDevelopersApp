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
                        y.Mail= reader.GetString(6);
                        y.Durum = reader.GetBoolean(7);
                        y.YoneticiTur = reader.GetString(8);
                    }
                    return y;
                }
                else
                {
                    return null ;
                }

            }
            catch {
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

        #endregion


        #region Yardımcılar

        public bool VeriControl(string tablo, string kolon, string veri)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM " + tablo+ " WHERE "+kolon+" = @isim";
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
