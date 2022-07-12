using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Almanac.Common;
using System.Reflection; 

namespace Almanac
{
    public partial class ucUyeOnay : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = MSSQLDataConnection.SelectDataFromDB("SELECT ID,TcKimlikNo,Email,CONVERT(VARCHAR,DogumTarihi,104),Cinsiyet,MezuniyetYili,Sinif,Konum FROM tblUyeler WHERE Onay = 'False'");
            int sira = Common.FormlarArasi.uyeOnaySira;
            lbTcNo.Text = dt.Rows[sira][1].ToString();
            lbEmail.Text = dt.Rows[sira][2].ToString();
            lbDogumTarihi.Text = dt.Rows[sira][3].ToString();
            lbCinsiyet.Text = dt.Rows[sira][4].ToString();
            lbMezuniyet.Text = dt.Rows[sira][5].ToString();
            lbSinif.Text = dt.Rows[sira][6].ToString();
            lbKonum.Text = dt.Rows[sira][7].ToString();
            onayHref.HRef = "~/islemler.aspx?uyeOnayID=" + dt.Rows[sira][0].ToString();
            iptalHref.HRef = "~/islemler.aspx?uyeIptalID=" + dt.Rows[sira][0].ToString();
            Common.FormlarArasi.uyeOnaySira = sira + 1;
        }
    }
}