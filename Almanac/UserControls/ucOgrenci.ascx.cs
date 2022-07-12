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
    public partial class ucOgrenci : System.Web.UI.UserControl
    {
        private void formuDoldur()
        {
            DataTable dt = MSSQLDataConnection.SelectDataFromDB("SELECT ID,Ad + ' ' + Soyad,TcKimlikNo,Cinsiyet FROM tblUyeler WHERE Sinif ='" + Common.FormlarArasi.ogrenciSinif + "' ORDER BY MezuniyetYili DESC");
            if (dt.Rows.Count > 0)
            {
                string TcKimlikNo = Session["TcKimlikNo"].ToString();
                int x = Common.FormlarArasi.ogrenciSira;
                int ID = Convert.ToInt32(dt.Rows[x][0].ToString());
                string cinsiyet = dt.Rows[x][3].ToString();
                imgOgrenci.ImageUrl = "~/" + Common.Common.ProfilResmi(ID, Server.MapPath("/"),cinsiyet);
                if(dt.Rows[x][2].ToString() == TcKimlikNo)
                    hrfOgrenci.HRef = "~/mypage.aspx";
                else
                    hrfOgrenci.HRef = "~/profil.aspx?ID=" + ID;

                lbOgrenci.Text = dt.Rows[x][1].ToString();
                Common.FormlarArasi.ogrenciSira = x + 1;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                formuDoldur();
        }
    }
}