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
    public partial class Arama : System.Web.UI.Page
    {
        [System.Web.Services.WebMethod]
        public static List<OtmTamamlama> TumUrunleriGetir()
        {

            DataTable dt = MSSQLDataConnection.SelectDataFromDB("SELECT (Ad + ' ' + Soyad) AS AdSoyad,ID FROM tblUyeler WHERE TcKimlikNo != '" + Common.FormlarArasi.aramaTc + "' AND Onay = 'True' AND AdminKontrol = 'False'");
            List<OtmTamamlama> Dondurulecek = new List<OtmTamamlama>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                OtmTamamlama Tamamla = new OtmTamamlama();
                Tamamla.value = dt.Rows[i][0].ToString();
                Tamamla.ID = dt.Rows[i][1].ToString();
                Dondurulecek.Add(Tamamla);
            }
            return Dondurulecek;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}