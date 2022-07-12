using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Almanac.Common;
using System.Data;

namespace Almanac.UserControls
{
    public partial class ucPM : System.Web.UI.UserControl
    {
        public static string Kontrol;
        public void mpgFormuDoldur()
        {
            try
            {
                string TcKimlikNo = Session["TcKimlikNo"].ToString();
                string query = "SELECT (U.Ad + ' ' + U.Soyad) AS AdSoyad,CONVERT(VARCHAR,PM.Tarih,104) AS Tarih,PM.Mesaj,PM.Onay,Pm.Gonderen,PM.ID FROM tblProfilMesaj PM " +
                               "INNER JOIN tblUyeler U ON PM.Gonderen = U.TcKimlikNo " +
                                "WHERE PM.Alici='" + TcKimlikNo + "' AND PM.Onay = 'True' ORDER BY PM.Tarih DESC";
                int x = Common.FormlarArasi.Sira;
                DataTable dtPM = MSSQLDataConnection.SelectDataFromDB(query);
                lbGonderen.Text = dtPM.Rows[x][0].ToString();
                lbTarih.Text = dtPM.Rows[x][1].ToString();
                lbMesaj.Text = dtPM.Rows[x][2].ToString();
                int ID = MSSQLDataConnection.SelectIntFromDB("SELECT ID FROM tblUyeler WHERE TcKimlikNo ='" + dtPM.Rows[x][4].ToString() + "'");
                string cinsiyet = MSSQLDataConnection.SelectStringFromDB("SELECT Cinsiyet FROM tblUyeler WHERE TcKimlikNo ='" + dtPM.Rows[x][4].ToString() + "'");
                imgPR.ImageUrl = "~/" + Common.Common.ProfilResmi(ID, Server.MapPath("/"),cinsiyet);
                Common.FormlarArasi.Sira = x + 1;
            }
            catch
            {
            }
        }
        static int MesajID;
        public void bldrFormuDoldur()
        {
            string TcKimlikNo = Session["TcKimlikNo"].ToString();
            string query = "SELECT (U.Ad + ' ' + U.Soyad) AS AdSoyad,CONVERT(VARCHAR,PM.Tarih,104) AS Tarih,PM.Mesaj,PM.ID,PM.Gonderen,U.Cinsiyet FROM tblProfilMesaj PM " +
                           "INNER JOIN tblUyeler U ON PM.Gonderen = U.TcKimlikNo " +
                            "WHERE PM.Alici='" + TcKimlikNo + "' AND PM.Onay = 'False' ORDER BY PM.Tarih DESC";
            int x = Common.FormlarArasi.Sira;
            DataTable dtPM = MSSQLDataConnection.SelectDataFromDB(query);
            int prID = MSSQLDataConnection.SelectIntFromDB("SELECT ID FROM tblUyeler WHERE TcKimlikNo ='" + dtPM.Rows[x][4].ToString() + "'");
            lbGonderen.Text = dtPM.Rows[x][0].ToString();
            lbTarih.Text = dtPM.Rows[x][1].ToString();
            lbMesaj.Text = dtPM.Rows[x][2].ToString();
            int ID = Convert.ToInt32(dtPM.Rows[x][3].ToString());
            hrfOnay.HRef = "~/islemler.aspx?MesajOnayID=" + ID;
            hrfIptal.HRef = "~/islemler.aspx?MesajIptalID=" + ID;
            Common.FormlarArasi.Sira = x + 1;
            string cinsiyet = dtPM.Rows[x][5].ToString();
            imgPR.ImageUrl = "~/" + Common.Common.ProfilResmi(prID, Server.MapPath("/"),cinsiyet);
            
        }

        public void prfFormuDoldur()
        {
            try
            {

                string TcKimlikNo = Session["Alici"].ToString();
                string query = "SELECT (U.Ad + ' ' + U.Soyad) AS AdSoyad,CONVERT(VARCHAR,PM.Tarih,104) AS Tarih,PM.Mesaj,PM.Onay,PM.Gonderen FROM tblProfilMesaj PM " +
                               "INNER JOIN tblUyeler U ON PM.Gonderen = U.TcKimlikNo " +
                                "WHERE PM.Alici='" + TcKimlikNo + "' AND PM.Onay = 'True' ORDER BY PM.Tarih DESC";
                int x = Common.FormlarArasi.Sira;
                DataTable dtPM = MSSQLDataConnection.SelectDataFromDB(query);
                lbGonderen.Text = dtPM.Rows[x][0].ToString();
                lbTarih.Text = dtPM.Rows[x][1].ToString();
                lbMesaj.Text = dtPM.Rows[x][2].ToString();
                Common.FormlarArasi.Sira = x + 1;
                int ID = MSSQLDataConnection.SelectIntFromDB("SELECT ID FROM tblUyeler WHERE TcKimlikNo ='" + dtPM.Rows[x][4].ToString() + "'");
                string cinsiyet = MSSQLDataConnection.SelectStringFromDB("SELECT Cinsiyet FROM tblUyeler WHERE TcKimlikNo ='" + dtPM.Rows[x][4].ToString() + "'");
                imgPR.ImageUrl = "~/" + Common.Common.ProfilResmi(ID, Server.MapPath("/"),cinsiyet);
            }
            catch
            {
            }
        }   

        
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                imgOnay.Visible = false;
                imgIptal.Visible = false;
                hrfOnay.HRef = "";
                hrfIptal.HRef = "";
                hrfIptal.Style["margin-right"] = "-1px";
                if (Common.FormlarArasi.ProfilMesaj == "MyPage")
                    mpgFormuDoldur();
                else if (Common.FormlarArasi.ProfilMesaj == "Profil")
                    prfFormuDoldur();
                else if (Common.FormlarArasi.ProfilMesaj == "Bildirimler")
                {
                    imgOnay.Visible = true;
                    imgIptal.Visible = true;
                    bldrFormuDoldur();
                }
            //}
        }
    }
}