using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Almanac.Common;

namespace Almanac
{
    public partial class sikayeticerik : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                lbIcerik.Style["color"] = "blue";
                lbIcerik.Font.Size = 12;
                lbIcerik.Text = MSSQLDataConnection.SelectStringFromDB("SELECT Icerik FROM tblSikayetler WHERE ID=" + Request.QueryString["ID"].ToString());                
                
            }
        }
    }
}