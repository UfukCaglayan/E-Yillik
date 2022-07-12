using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Almanac.Common;

namespace Almanac
{
    public partial class giris1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tmrBildirim.Enabled = false;
                divBildirim.Visible = false;
            }
        }
        static int sayac = 0;
        protected void tmrBildirim_Tick(object sender, EventArgs e)
        {
            divBildirim.Visible = true;
            sayac++;
            divBildirim.Attributes.Add("class", FormlarArasi.div);
            spBildirim.InnerText = FormlarArasi.mesaj;
            if (sayac > 3)
            {
                divBildirim.Visible = false;
                tmrBildirim.Enabled = false;
                sayac = 0;
            }
        }
    }
}