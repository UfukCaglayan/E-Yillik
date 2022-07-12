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
    public partial class ucSonYazi : System.Web.UI.UserControl
    {

        private void sonYazi()
        {
            imgIptal.Visible = false;
            string query = "SELECT (U.Ad + ' ' + U.Soyad) AS AdSoyad,CONVERT(VARCHAR,PM.Tarih,104) AS Tarih,PM.Mesaj,PM.Onay,PM.Gonderen FROM tblProfilMesaj PM " +
                           "INNER JOIN tblUyeler U ON PM.Alici = U.TcKimlikNo " +
                           "WHERE PM.Onay = 'True' ORDER BY PM.Tarih DESC";
            int x = Common.FormlarArasi.sonYaziSira;
            DataTable dtSn = MSSQLDataConnection.SelectDataFromDB(query);
            if (dtSn.Rows.Count > 0)
            {
                DataTable dtGonderen = MSSQLDataConnection.SelectDataFromDB("SELECT ID,Ad + ' ' + Soyad,Cinsiyet FROM tblUyeler WHERE TcKimlikNo ='" + dtSn.Rows[x][4].ToString() + "'");
                int ID = Convert.ToInt32(dtGonderen.Rows[0][0].ToString());
                string cinsiyet = dtGonderen.Rows[0][2].ToString();
                lbGonderilen.Text = "Gönderilen kişi : " + dtSn.Rows[x][0].ToString();
                lbTarih.Text = dtSn.Rows[x][1].ToString();
                lbMesaj.Text = dtSn.Rows[x][2].ToString();
                Common.FormlarArasi.sonYaziSira = x + 1;
                imgPR.ImageUrl = "~/" + Common.Common.ProfilResmi(ID, Server.MapPath("/"), cinsiyet);
            }
        }

        private void ogrenciKontrol()
        {
            string query = "SELECT (U.Ad + ' ' + U.Soyad) AS AdSoyad,CONVERT(VARCHAR,PM.Tarih,104) AS Tarih,PM.Mesaj,PM.ID FROM tblProfilMesaj PM " +
                            "INNER JOIN tblUyeler U ON PM.Alici = U.TcKimlikNo " +
                            "WHERE PM.Gonderen = '" + Common.FormlarArasi.ogrenciTc + "' ORDER BY PM.Tarih DESC";
            DataTable dtOk = MSSQLDataConnection.SelectDataFromDB(query);
            int x = Common.FormlarArasi.sonYaziSira;
            if (dtOk.Rows.Count > 0)
            {
                DataTable dtGonderen = MSSQLDataConnection.SelectDataFromDB("SELECT ID,Cinsiyet FROM tblUyeler WHERE TcKimlikNo ='" + Common.FormlarArasi.ogrenciTc + "'");
                int ID = Convert.ToInt16(dtGonderen.Rows[0][0]);
                string cinsiyet = dtGonderen.Rows[0][1].ToString();
                imgPR.ImageUrl = "~/" + Common.Common.ProfilResmi(ID, Server.MapPath("/"), cinsiyet);
                lbGonderilen.Text = "Gönderilen kişi : " + dtOk.Rows[x][0].ToString();
                lbTarih.Text = dtOk.Rows[x][1].ToString();
                lbMesaj.Text = dtOk.Rows[x][2].ToString();
                hrfSil.HRef = "~/islemler.aspx?admMesajSilID=" + dtOk.Rows[x][3].ToString();
                Common.FormlarArasi.sonYaziSira = x + 1;
              
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (FormlarArasi.sonYazi == "SonYazi")
                sonYazi();
            else if (FormlarArasi.sonYazi == "OgrenciKontrol")
                ogrenciKontrol();
        }
    }
}