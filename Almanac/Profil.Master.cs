using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Almanac.Common;
using System.Data;
using System.IO;

namespace Almanac
{
    public partial class Profil : System.Web.UI.MasterPage
    {
        static string Alici = "";
        static string TcKimlikNo;

        private void hakkindaDoldur()
        {
            string TcNo = "";
            if (Alici != "")
                TcNo = Alici;
            else
                TcNo = TcKimlikNo;

            DataTable dt = MSSQLDataConnection.SelectDataFromDB("SELECT MezuniyetYili,Sinif,CONVERT(datetime,DogumTarihi, 104),Konum,Cinsiyet FROM tblUyeler WHERE TcKimlikNo ='" + TcNo + "'");
            spMezuniyet.InnerText = dt.Rows[0][0].ToString();
            string sinif = dt.Rows[0][1].ToString();
            spSinif.InnerText = sinif[3].ToString() + " Sınıfı";
            DateTime dogumTarihi = Convert.ToDateTime(dt.Rows[0][2].ToString());
            spDogumTarihi.InnerText = dogumTarihi.ToString("dd.MM.yyyy");
            spKonum.InnerText = dt.Rows[0][3].ToString();
            spCinsiyet.InnerText = dt.Rows[0][4].ToString();
        }

        private void galeriDoldur()
        {
            List<string> Resimler = new List<string>();
            List<int> Rnd = new List<int>();
            string TcNo = "";
            if (Alici != "")
                TcNo = Alici;
            else
                TcNo = TcKimlikNo;

            int ID = MSSQLDataConnection.SelectIntFromDB("SELECT ID FROM tblUyeler WHERE TcKimlikNo ='" + TcNo + "'");
            if (Directory.Exists(Server.MapPath("/Galeri/" + ID.ToString())))
            {
                int x;
                DirectoryInfo klasor = new DirectoryInfo(Server.MapPath("/Galeri/") + ID.ToString());
                FileInfo[] fi = klasor.GetFiles();
                foreach (FileInfo dosyalar in fi)
                {
                   Resimler.Add(dosyalar.Name);
                }
                Resimler.Remove("Thumbs.db");
                Random rnd = new Random();
                int son = 0;
                if (Resimler.Count > 3)
                    son = 4;
                else
                    son = Resimler.Count;

                for (int k = 0; k < son; k++)
                {
                    do
                    {
                        x = rnd.Next(0, Resimler.Count);
                    }
                    while (Rnd.Contains(x));
                    string hrfName = "hrfUnt" + (k + 1).ToString();
                    string imgName = "imgUnt" + (k + 1).ToString();
                    HtmlAnchor hrfLnk = (HtmlAnchor)this.FindControl(hrfName);
                    HtmlImage imgUnt = (HtmlImage)this.FindControl(imgName);
                    hrfLnk.HRef = "Galeri/" + ID.ToString() + "/" + Resimler[x].ToString();
                    imgUnt.Src = "Galeri/" + ID.ToString() + "/" + Resimler[x].ToString();
                    Rnd.Add(x);
                }
            }
        }

        private void onadaYazDoldur()
        {
            try
            {
                List<int> ID = new List<int>();
                List<int> Rnd = new List<int>();
                int x;
                DataTable dtTc = MSSQLDataConnection.SelectDataFromDB("SELECT TcKimlikNo,ID FROM tblUyeler WHERE AdminKontrol = 'False' AND TcKimlikNo != '" + TcKimlikNo + "' AND TcKimlikNo != '" + Alici + "'");
                for (int i = 0; i < dtTc.Rows.Count; i++)
                {
                    int Count = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblProfilMesaj WHERE Gonderen ='" + TcKimlikNo + "' AND Alici ='" + dtTc.Rows[i][0].ToString() + "'");
                    if (Count == 0)
                        ID.Add(Convert.ToInt32(dtTc.Rows[i][1].ToString()));
                }
                Random rnd = new Random();
                for (int i = 1; i < 5; i++)
                {
                    do
                    {
                        x = rnd.Next(0, ID.Count);
                        if (i == ID.Count)
                            break;
                    }
                    while (Rnd.Contains(x));
                    string asName = "spAdSoyad" + i;
                    string hrfName = "hrefYba" + i;
                    string imgName = "imgPR" + i;
                    HtmlGenericControl spAs = (HtmlGenericControl)this.FindControl(asName);
                    HtmlAnchor hrfLnk = (HtmlAnchor)this.FindControl(hrfName);
                    HtmlImage imgPR = (HtmlImage)this.FindControl(imgName);
                    spAs.InnerText = MSSQLDataConnection.SelectStringFromDB("SELECT Ad + ' ' + Soyad FROM tblUyeler WHERE ID = " + ID[x]);
                    hrfLnk.HRef = "profil.aspx?ID=" + ID[x].ToString();
                    string cinsiyet = MSSQLDataConnection.SelectStringFromDB("SELECT Cinsiyet FROM tblUyeler WHERE ID = " + ID[x]);
                    imgPR.Src = (Common.Common.ProfilResmi(ID[x], Server.MapPath("/"), cinsiyet));
                    Rnd.Add(x);
                }
            }
            catch { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Alici = "";
            TcKimlikNo = Session["TcKimlikNo"].ToString();
            if (Session["Alici"] != null)
                Alici = Session["Alici"].ToString();

            divBildirim.Visible = false;
            onadaYazDoldur();
            galeriDoldur();
            hakkindaDoldur();
        }
    }
}