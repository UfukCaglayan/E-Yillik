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
    public partial class AdminPanel : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] != null)
            {
                string TcKimlikNo = Session["Admin"].ToString();
                DataTable dt = MSSQLDataConnection.SelectDataFromDB("SELECT ID,Ad + ' ' + Soyad,Cinsiyet FROM tblUyeler WHERE TcKimlikNo ='" + TcKimlikNo + "'");
                spAdSoyad.InnerText = dt.Rows[0][1].ToString();
                int ID = Convert.ToInt32(dt.Rows[0][0]);
                string cinsiyet = dt.Rows[0][2].ToString();
                imgPR.Src = Common.Common.ProfilResmi(ID, Server.MapPath("/"), cinsiyet);
            }
            else
                Response.Redirect("giris.aspx");
        }
    }
}