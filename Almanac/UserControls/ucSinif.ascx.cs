using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Almanac.Common;

namespace Almanac
{
    public partial class ucSinif : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = MSSQLDataConnection.SelectDataFromDB("SELECT Sinif,Renk,Renk2,ID FROM tblSiniflar");
            if (dt.Rows.Count > 0)
            {
                int x = Common.FormlarArasi.sinifSira;
                string sinif = dt.Rows[x][0].ToString();
                spSinif.InnerText = sinif;
                string renk1 = dt.Rows[x][1].ToString();
                string renk2 = dt.Rows[x][2].ToString();
                divKutu.Style["background-color"] = renk1;
                int yillikYazisi = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblUyeler U INNER JOIN tblProfilMesaj PM ON U.TcKimlikNo = PM.Alici WHERE U.Sinif ='" + sinif + "' AND PM.Onay = 'True'");
                int uyeSayisi = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblUyeler WHERE Sinif ='" + sinif + "'");
                spYy.InnerText = yillikYazisi.ToString() + " YILLIK YAZISI";
                spIst.InnerText = uyeSayisi.ToString() + " ÖĞRENCİ";
                hrfSnf.HRef = "~/snfogr.aspx?SinifID=" + dt.Rows[x][3].ToString();
                divKutu.Attributes.Add("onmouseover", "this.style.backgroundColor='" + renk2 + "'");
                divKutu.Attributes.Add("onMouseOut", "this.style.backgroundColor='" + renk1 + "'");
                Common.FormlarArasi.sinifSira = x + 1;
            }
        }
    }
}