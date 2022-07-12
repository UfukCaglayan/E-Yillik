using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Almanac
{
    public partial class cikis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TcKimlikNo"] != null)
            {
                Session["TcKimlikNo"] = null;
                Response.Redirect("giris.aspx");
            }
            else
               Response.Redirect("giris.aspx");
        }
    }
}