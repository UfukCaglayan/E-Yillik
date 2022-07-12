using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Almanac.Common;

namespace Almanac
{
    public partial class onayIptal : System.Web.UI.Page
    {
        private void bildirimOnay()
        {
            int MesajID = Convert.ToInt32(Request.QueryString["MesajOnayID"].ToString());
            string Guncelle = "UPDATE tblProfilMesaj SET Onay ='True' WHERE ID=" + MesajID;
            MSSQLDataConnection.UpdateDataToDB(Guncelle);
            Response.Redirect("bildirimler.aspx");
        }

        private void bildirimIptal()
        {
            int MesajID = Convert.ToInt32(Request.QueryString["MesajIptalID"].ToString());
            string Sil = "DELETE FROM tblProfilMesaj WHERE ID=" + MesajID;
            MSSQLDataConnection.DeleteDataFromDB(Sil);
            Response.Redirect("bildirimler.aspx");
        }

        private void mesajSil()
        {
            int MesajID = Convert.ToInt32(Request.QueryString["MesajSilID"].ToString());
            string Sil = "DELETE FROM tblProfilMesaj WHERE ID=" + MesajID;
            MSSQLDataConnection.DeleteDataFromDB(Sil);
            Response.Redirect("mypage.aspx");
        }

        private void uyeOnay()
        {
            int uyeOnayID = Convert.ToInt32(Request.QueryString["uyeOnayID"]);
            string update = "UPDATE tblUyeler SET Onay = 'True' WHERE ID =" + uyeOnayID;
            MSSQLDataConnection.UpdateDataToDB(update);
            Response.Redirect("adm_uyeonaylama.aspx");
        }


        private void uyeIptal()
        {
            int uyeIptalID = Convert.ToInt32(Request.QueryString["uyeIptalID"]);
            string sil = "DELETE FROM tblUyeler WHERE ID =" + uyeIptalID;
            MSSQLDataConnection.DeleteDataFromDB(sil);
            Response.Redirect("adm_uyeonaylama.aspx");
        }

        private void adminMesajSil()
        {
            int MesajID = Convert.ToInt32(Request.QueryString["admMesajSilID"].ToString());
            string sil = "DELETE FROM tblProfilMesaj WHERE ID=" + MesajID;
            MSSQLDataConnection.DeleteDataFromDB(sil);
            int ogrID = MSSQLDataConnection.SelectIntFromDB("SELECT ID FROM tblUyeler WHERE TcKimlikNo ='" + Common.FormlarArasi.ogrenciTc + "'");
            Response.Redirect("~/adm_yazikontrol.aspx?Ogr=" + ogrID);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["MesajOnayID"] != null)
                bildirimOnay();
            else if (Request.QueryString["MesajIptalID"] != null)
                bildirimIptal();
            else if (Request.QueryString["MesajSilID"] != null)
                mesajSil();
            else if (Request.QueryString["uyeOnayID"] != null)
                uyeOnay();
            else if (Request.QueryString["uyeIptalID"] != null)
                uyeIptal();
            else if (Request.QueryString["admMesajSilID"] != null)
                adminMesajSil();
            else
                Response.Redirect("~/giris.aspx");
        }
    }
}