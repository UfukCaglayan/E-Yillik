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
    public partial class WebForm11 : System.Web.UI.Page
    {
        static string sinif;
        static DataTable dtOgr;
        static int ID;

        static DataTable dtSiniflar;
        private void sinifDoldur()
        {
            dtSiniflar = MSSQLDataConnection.SelectDataFromDB("SELECT Sinif FROM tblSiniflar");
            for (int i = 0; i < dtSiniflar.Rows.Count; i++)
            {
                Panel pnl = new Panel();
                pnl.Style["float"] = "left";
                pnl.Style["margin-left"] = "5px";
                pnl.Width = 50;
                pnl.Height = 50;
                ImageButton ib = new ImageButton();
                ib.ID = "ib" + dtSiniflar.Rows[i][0].ToString();
                ib.ImageUrl = "~/images/sinifkutu.jpg";
                ib.Width = 50;
                ib.Height = 50;
                ib.Style["margin-left"] = "5px";
                ib.Style["float"] = "left";
                ib.Click += new ImageClickEventHandler(ib_Click);
                pnl.Controls.Add(ib);
                Panel pnlLabel = new Panel();
                pnlLabel.Style["float"] = "left";
                pnlLabel.Style["margin-left"] = "5px";
                pnlLabel.Style["margin-top"] = "-30px";
                Label lb = new Label();
                lb.Text = dtSiniflar.Rows[i][0].ToString();
                lb.Font.Size = 13;
                lb.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575757");
                pnlLabel.Controls.Add(lb);
                pnl.Controls.Add(pnlLabel);
                pnlSiniflar.Controls.Add(pnl);
            }
        }

        void ib_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton snd = (ImageButton)sender;
            string name = snd.ID;
            sinif = name.Substring(2);
            ogrenciDoldur();
        }

        private void ogrenciDoldur()
        {
            if (sinif != "")
            {
                pnlOgrenciler.Controls.Clear();
                dtOgr = MSSQLDataConnection.SelectDataFromDB("SELECT Ad + ' ' + Soyad,ID,Cinsiyet,TcKimlikNo FROM tblUyeler WHERE Sinif = '" + sinif + "' AND AdminKontrol = 'False'");
                for (int i = 0; i < dtOgr.Rows.Count; i++)
                {
                    HyperLink hp = new HyperLink();
                    int ID = Convert.ToInt32(dtOgr.Rows[i][1]);
                    string cinsiyet = dtOgr.Rows[i][2].ToString();
                    hp.NavigateUrl = "adm_galeri.aspx?Ogr=" + ID;
                    hp.Style["text-decoration"] = "none";
                    Panel pnl = new Panel();
                    pnl.Attributes.Add("class", "panelYk");
                    Image img = new Image();
                    img.ImageUrl = Common.Common.ProfilResmi(ID, Server.MapPath("/"), cinsiyet);
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

        private void galeriDoldur()
        {
            if (Request.QueryString["Ogr"] != null)
            {
                ID = Convert.ToInt32(Request.QueryString["Ogr"]);
                pnlGaleri.Visible = true;
                for (int i = 0; i < 9; i++)
                {
                    string name = "imgGlr" + (i + 1).ToString();
                    ImageButton img = (ImageButton)pnlGaleri.FindControl(name);
                    img.ImageUrl = Common.Common.galeriDoldur(Server.MapPath("/Galeri/" + ID.ToString()), i + 1, ID,"bos");
                }
            }
        }


        protected void imgGlr1_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ib = (ImageButton)sender;
            string name = ib.ID;
            int id = Convert.ToInt32(name[6].ToString());
            Common.Common.dosyaSil(id, Server.MapPath("/Galeri/" + ID.ToString()));
            galeriDoldur();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlGaleri.Visible = false;
                int sikayet = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblSikayetler WHERE Onay = 'False'");
                spSikayet.InnerText = sikayet.ToString();
                sinif = "";
            }
            sinifDoldur();
            ogrenciDoldur();
            galeriDoldur();

        }
    }
}