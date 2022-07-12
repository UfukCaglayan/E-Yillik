using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Almanac.Common;
using System.Data;
using System.Web.UI.HtmlControls;

namespace Almanac
{
    public partial class WebForm15 : System.Web.UI.Page
    {
        private void gridDoldur()
        {
            string query = "SELECT S.ID,U.Ad + ' ' + U.Soyad AS AdSoyad,S.KonuBasligi,S.SikayetSebebi,S.Onay FROM tblUyeler U INNER JOIN tblSikayetler S ON U.TcKimlikNo = S.Gonderen AND S.Onay = 'False'";
            rptSikayetler.DataSource = MSSQLDataConnection.SelectDataFromDB(query);
            rptSikayetler.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridDoldur();
                int sikayet = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblSikayetler WHERE Onay = 'False'");
                spSikayet.InnerText = sikayet.ToString();
            }
        }

        protected void rptSikayetler_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string arg = e.CommandArgument.ToString();
            string update = "UPDATE tblSikayetler SET Onay = 'True' WHERE ID =" + arg;
            MSSQLDataConnection.UpdateDataToDB(update);
            gridDoldur();
        }


        protected void rptSikayetler_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = e.Item.DataItem as DataRowView;
                int id = Convert.ToInt32(drv.Row[0]);
                HtmlAnchor ha = (HtmlAnchor)e.Item.FindControl("hrfResim");
                ha.HRef = "Sikayetler/" + id + ".jpg";
            }

        }
    }
}