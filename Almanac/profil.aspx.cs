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
    public partial class WebForm1 : System.Web.UI.Page
    {
        static string Alici, Gezen;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int ID = Convert.ToInt32(Request.QueryString["ID"].ToString());
                    Gezen = Session["TcKimlikNo"].ToString();
                    DataTable dt = MSSQLDataConnection.SelectDataFromDB("SELECT Ad + ' ' + Soyad,TcKimlikNo,Email,FacebookAdres,TwitterAdres,Cinsiyet FROM tblUyeler WHERE ID = " + ID);
                    txtDusunce.Value = dt.Rows[0][0].ToString() + " Hakkında Ne Düşünüyorsun?";
                    Alici = dt.Rows[0][1].ToString();
                    Session["Alici"] = Alici;
                    string face = dt.Rows[0][3].ToString();
                    string twitter = dt.Rows[0][4].ToString();
                    string email = dt.Rows[0][2].ToString();
                    string cinsiyet = dt.Rows[0][5].ToString();
                    if (face == "")
                        imgFace.Src = "images/facelogosiyah.png";
                    else
                    {
                        hrfFace.HRef = "https://www.facebook.com/" + face;
                        imgFace.Src = "images/facelogorenkli.png";
                    }
                    if (twitter == "")
                        imgTwitter.Src = "images/twitlogosiyah.png";
                    else
                    {
                        hrfTwitter.HRef = "https://twitter.com/" + twitter;
                        imgTwitter.Src = "images/twitlogorenkli.png";
                    }
                    hrfOzelMesaj.HRef = "ozelmesaj.aspx?ID=" + ID;


                    int ProfilMesaj = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblProfilMesaj WHERE Alici = '" + Alici + "' AND Onay = 'True'");
                    imgPR.ImageUrl = Common.Common.ProfilResmi(ID, Server.MapPath("/"),cinsiyet);
                    lbAdSoyad.Text = dt.Rows[0][0].ToString();;
                    Common.FormlarArasi.Sira = 0;
                    Common.FormlarArasi.ProfilMesaj = "Profil";
                   
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
                else
                    Response.Redirect("~/giris.aspx");
            }

        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            string Mesaj = Common.Common.HtmlTagEdit(txtDusunce.Value);
            string Kaydet = "INSERT INTO tblProfilMesaj (Alici,Gonderen,Mesaj,Tarih,Onay) VALUES ('" + Alici + "','" + Gezen + "','" + Mesaj.Replace("'", "''") + "', GETDATE(),'False')";
            MSSQLDataConnection.InsertDataToDB(Kaydet);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
            
        }

        protected void btnMesajGonder_Click(object sender, EventArgs e)
        {
            Common.FormlarArasi.omAlici = Alici;
            Response.Redirect("OzelMesaj.aspx");
        }
    }
}