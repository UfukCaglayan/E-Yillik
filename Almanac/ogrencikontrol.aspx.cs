using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Almanac.Common;
using System.Data;

namespace Almanac
{
    public partial class ogrencikontrol : System.Web.UI.Page
    {
        static DataTable dtSiniflar;
        private void sinifDoldur()
        {
            dtSiniflar = MSSQLDataConnection.SelectDataFromDB("SELECT Sinif FROM tblSiniflar");
            for (int i = 0; i < dtSiniflar.Rows.Count; i++)
            {
                ImageButton ib = new ImageButton();
                ib.ID = "ib" + dtSiniflar.Rows[i][0].ToString();
                ib.Width = 35;
                ib.Height = 35;
                ib.AlternateText = dtSiniflar.Rows[i][0].ToString();
                ib.Style["margin-left"] = "5px";
                ib.Style["float"] = "left";
                ib.Click += new ImageClickEventHandler(ib_Click);
                pnlSiniflar.Controls.Add(ib);
            
            }
        }

        private void ogrenciDoldur()
        {
            if (sinif != "")
            {
                pnlOgrenciler.Controls.Clear();
                dtOgr = MSSQLDataConnection.SelectDataFromDB("SELECT Ad + ' ' + Soyad,ID,Cinsiyet,TcKimlikNo FROM tblUyeler WHERE Sinif = '" + sinif + "'");
                for (int i = 0; i < dtOgr.Rows.Count; i++)
                {
                    HyperLink hp = new HyperLink();
                    int ID = Convert.ToInt32(dtOgr.Rows[i][1]);
                    hp.NavigateUrl = "ogrencikontrol.aspx?Ogr=" + ID;
                    hp.Style["text-decoration"] = "none";
                    Panel pnl = new Panel();
                    pnl.Attributes.Add("class", "panelYk");
                    Image img = new Image();
                    string cinsiyet = dtOgr.Rows[i][2].ToString();
                    img.ImageUrl = Common.Common.ProfilResmi(ID, Server.MapPath("/"),cinsiyet);
                    img.Attributes.Add("class", "imageYk");
                    pnl.Controls.Add(img);
                    Label lb = new Label();
                    lb.Text = dtOgr.Rows[i][0].ToString();
                    lb.Attributes.Add("class", "labelYk");
                    pnl.Controls.Add(lb);
                    hp.Controls.Add(pnl);
                    pnlOgrenciler.Controls.Add(hp);
                }
            }
        }

        static DataTable dtOgr;
        static string sinif = "";
        static string TcNo = "";
        void ib_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton snd = (ImageButton)sender;
            string name = snd.ID;
            sinif = name.Substring(2);
            ogrenciDoldur();
        }

        private void mesajDoldur()
        {
            if (Request.QueryString["Ogr"] != null)
            {
                pnlYazilar.Controls.Clear();
                string TcNo = MSSQLDataConnection.SelectStringFromDB("SELECT TcKimlikNo FROM tblUyeler WHERE ID = " + Convert.ToInt32(Request.QueryString["Ogr"]));
                int pm = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblProfilMesaj WHERE Gonderen = '" + TcNo + "' AND Onay = 'True'");
                Common.FormlarArasi.sonYaziSira = 0;
                Common.FormlarArasi.sonYazi = "OgrenciKontrol";
                Common.FormlarArasi.ogrenciTc = TcNo;
                for (int i = 0; i < pm; i++)
                {
                    Panel pnl = new Panel();
                    pnl.ID = "pnlSy" + i;
                    pnl.Width = pnlYazilar.Width;
                    Control PM = LoadControl(@"~/UserControls/ucSonYazi.ascx") as UserControl;
                    pnl.Style["margin-top"] = "10px";
                    pnl.Controls.Add(PM);
                    pnlYazilar.Controls.Add(pnl);
                }
            }
        }

        void ibOgr_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton snd = (ImageButton)sender;
            string name = snd.ID;
            int id = Convert.ToInt32(name[2].ToString());
            TcNo = dtOgr.Rows[id][3].ToString();
            mesajDoldur();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            sinifDoldur();
            ogrenciDoldur();
            mesajDoldur();
        }
    }
}