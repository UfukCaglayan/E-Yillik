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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TcKimlikNo"] == null)
                    Response.Redirect("~/giris.aspx");
                else
                {
                    string TcKimlikNo = Session["TcKimlikNo"].ToString();
                    DataTable dt = MSSQLDataConnection.SelectDataFromDB("SELECT ID,Ad + ' ' + Soyad,Cinsiyet FROM tblUyeler WHERE TcKimlikNo = '" + TcKimlikNo + "'");
                    int ID = Convert.ToInt32(dt.Rows[0][0].ToString());
                    string cinsiyet = dt.Rows[0][2].ToString();
                    int Bildirim = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblProfilMesaj WHERE Alici = '" + TcKimlikNo + "' AND Onay = 'False'");
                    int OzelMesaj = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblOzelMesaj OM INNER JOIN tblMesajlaraGiris MG ON OM.Alici = MG.TcKimlikNo WHERE OM.Alici ='" + TcKimlikNo + "' AND OM.Tarih > MG.Tarih");
                    int ProfilMesaj = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblProfilMesaj WHERE Alici = '" + TcKimlikNo + "' AND Onay = 'True'");
                    spBldrm.InnerText = Bildirim.ToString();
                    spMsg.InnerText = OzelMesaj.ToString();
                    lbAdSoyad.Text = dt.Rows[0][1].ToString();
                    imgPR.ImageUrl = Common.Common.ProfilResmi(ID, Server.MapPath("/"),cinsiyet);
                    Common.FormlarArasi.omAlici = "";
                    Session["Alici"] = null;
                    Common.FormlarArasi.Sira = 0;
                    Common.FormlarArasi.ProfilMesaj = "MyPage";
                    for (int i = 0; i < ProfilMesaj; i++)
                    {
                        Panel pnl = new Panel();
                        pnl.ID = "pnl" + i;
                        pnl.Style["margin-top"] = "0px";
                        pnl.Width = pnlAlan.Width;
                        pnl.Height = 120;
                        Control PM = LoadControl(@"~/UserControls/ucPM.ascx") as UserControl;
                        pnl.Controls.Add(PM);
                        pnlAlan.Controls.Add(pnl);
                    }
                }
            }
        }
    }
}