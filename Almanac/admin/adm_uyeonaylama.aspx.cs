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
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Common.FormlarArasi.uyeOnaySira = 0;
            int uyeSayisi = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblUyeler WHERE Onay = 'False'");
            int sikayet = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblSikayetler WHERE Onay = 'False'");
            spSikayet.InnerText = sikayet.ToString();
            for (int i = 0; i < uyeSayisi; i++)
            {
                Panel pnl = new Panel();
                pnl.ID = "pnl" + i;
                pnl.Width = 300;
                pnl.Height = 130;
                pnl.Style["float"] = "left";
                pnl.Style["border-radius"] = "10px";
                pnl.Style["margin-left"] = "7px";
                pnl.Style["margin-top"] = "7px";
                Control UO = LoadControl(@"~/UserControls/ucUyeOnay.ascx") as UserControl;
                pnl.Controls.Add(UO);
                pnlAlan.Controls.Add(pnl);
                 
            }
        }
    }
}