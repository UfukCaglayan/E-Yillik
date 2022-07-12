using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Almanac.Common;

namespace Almanac
{
    public partial class anasay : System.Web.UI.Page
    {
        private void sinifDoldur()
        {
            int sinif = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblSiniflar");
            Common.FormlarArasi.sinifSira = 0;
            for (int i = 0; i < sinif; i++)
            {
                Panel pnl = new Panel();
                pnl.ID = "pnl" + i;
                pnl.Width = 116;
                pnl.Height = 116;
                pnl.Style["float"] = "left";
                pnl.Style["border-radius"] = "10px";
                pnl.Style["margin-left"] = "7px";
                pnl.Style["margin-top"] = "7px";
                pnlSiniflar.Controls.Add(pnl);
            }
            for (int k = 0; k < sinif; k++)
            {
                string Name = "pnl" + k;
                Panel pnlYer = (Panel)pnlSiniflar.FindControl(Name);
                Control PM = LoadControl(@"~/UserControls/ucSinif.ascx") as UserControl;
                pnlYer.Controls.Add(PM);
            }
        }

        private void sonYaziDoldur()
        {
            Common.FormlarArasi.sonYaziSira = 0;
            Common.FormlarArasi.sonYazi = "SonYazi";
            int yazilar = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblProfilMesaj WHERE Onay = 'True'");
            if (yazilar > 4)
            {
                for (int i = 0; i < 5; i++)
                {
                    Panel pnl = new Panel();
                    pnl.ID = "pnlSy" + i;
                    pnl.Width = 490;
                    pnl.Height = 125;
                    Control PM = LoadControl(@"~/UserControls/ucSonYazi.ascx") as UserControl;
                    pnl.Style["margin-top"] = "10px";
                    pnl.Controls.Add(PM);
                    pnlSonYazilar.Controls.Add(pnl);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TcKimlikNo"] == null)
                Response.Redirect("~/giris.aspx");
            else
            {
            sinifDoldur();
            sonYaziDoldur();
            string TcKimlikNo = Session["TcKimlikNo"].ToString();
            string adSoyad = MSSQLDataConnection.SelectStringFromDB("SELECT Ad + ' ' + Soyad FROM tblUyeler WHERE TcKimlikNo ='" + TcKimlikNo + "'");
            spAdSoyad.InnerText = adSoyad;
            }
        }
    }
}