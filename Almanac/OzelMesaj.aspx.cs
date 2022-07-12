using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Almanac.Common;

namespace Almanac
{
    public partial class OzelMesaj : System.Web.UI.Page
    {
        static string Alici;
        static int ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                ID = Convert.ToInt32(Request.QueryString["ID"].ToString());
                Alici = MSSQLDataConnection.SelectStringFromDB("SELECT TcKimlikNo FROM tblUyeler WHERE ID =" + ID);
                lbAdSoyad.Text = MSSQLDataConnection.SelectStringFromDB("SELECT Ad + ' ' + Soyad FROM tblUyeler WHERE ID =" + ID);
                hrfOzelMesaj.HRef = ("ozelmesajlar.aspx?Alici=" + ID);
            }
        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            string TcKimlikNo = Session["TcKimlikNo"].ToString();
            if (txtMesaj.Text == "")
            {
                //Hata : Mesaj girilmedi.
            }
            else
            {
                string insert = "INSERT INTO tblOzelMesaj (Gonderen,Alici,Mesaj,Tarih) VALUES ('" + TcKimlikNo + "','" + Alici + "','" + txtMesaj.Text + "',GETDATE())";
                MSSQLDataConnection.InsertDataToDB(insert);
                txtMesaj.Text = "";
                Response.Redirect("profil.aspx?ID=" + ID);
            }
        }
    }
}