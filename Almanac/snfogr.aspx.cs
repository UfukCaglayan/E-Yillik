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
    public partial class anasayfa : System.Web.UI.Page
    {
        static string sinif;
        static DataTable dtOgr;
        static string TcKimlikNo;
        private void ogrenciDoldur()
        {
            DataTable dt = MSSQLDataConnection.SelectDataFromDB("SELECT MezuniyetYili FROM tblUyeler WHERE Sinif ='" + sinif + "' GROUP BY MezuniyetYili  ORDER BY MezuniyetYili DESC");
            dtOgr = MSSQLDataConnection.SelectDataFromDB("SELECT ID,Ad + ' ' + Soyad,TcKimlikNo,Cinsiyet FROM tblUyeler WHERE Sinif ='" + sinif + "' ORDER BY MezuniyetYili DESC");
            int x = 0;
            if(dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Panel pnl = new Panel();
                    pnl.ID = "pnlYil" + i;
                    pnl.Width = pnlYillar.Width;
                    if (i == 0)
                        pnl.Style["margin-top"] = "5px";
                    else
                        pnl.Style["margin-top"] = "15px";
                     

                    pnl.Style["float"] = "left";
                    Panel pnlYil = new Panel();
                    pnlYil.Style["border-bottom"] = "1px solid #274268";
                    pnlYil.Style["color"] = "#274268";
                    pnlYil.Style["font-family"] = "Calibri";
                    pnlYil.Style["font-size"] = "20px";
                    pnlYil.Width = 1100;
                    Label lb = new Label();
                    lb.Text = dt.Rows[i][0].ToString();
                    pnlYil.Controls.Add(lb);
                    pnl.Controls.Add(pnlYil);
                    int ogr = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblUyeler WHERE MezuniyetYili =" + dt.Rows[i][0].ToString() + " AND Sinif ='" + sinif + "'");
                    int k = 0;
                    for (k = 0; k < ogr; k++)
                    {
                        Panel pnlOgr = new Panel();
                        pnlOgr.Width = 102;
                        pnlOgr.Height = 119;
                        pnlOgr.Style["float"] = "left";
                        pnlOgr.Style["margin-left"] = "5px";
                        pnlOgr.Style["margin-bottom"] = "8px";
                        ImageButton ib = new ImageButton();
                        ib.ID = "ibOgr" + (k + x).ToString();
                        int ID = Convert.ToInt32(dtOgr.Rows[k + x][0]);
                        string cinsiyet = dtOgr.Rows[k + x][3].ToString();
                        ib.ImageUrl = Common.Common.ProfilResmi(ID, Server.MapPath("/"), cinsiyet);
                        ib.Attributes.Add("class", "img");
                        ib.Click += new ImageClickEventHandler(ib_Click);
                        pnlOgr.Controls.Add(ib);
                        Panel pnlAlt = new Panel();
                        pnlAlt.Attributes.Add("class", "panel");
                        Label lbl = new Label();
                        lbl.Text = dtOgr.Rows[k + x][1].ToString();
                        pnlAlt.BackImageUrl = "images/altsaydam.png";
                        pnlAlt.Controls.Add(lbl);
                        pnlOgr.Controls.Add(pnlAlt);
                        pnl.Controls.Add(pnlOgr);
                    }
                    x = x + 1;
                    pnlYillar.Controls.Add(pnl);
                }
            }
        }

        void ib_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ib = (ImageButton)sender;
            string name = ib.ID;
            int id = Convert.ToInt32(name.Substring(5));
            int pID = Convert.ToInt32(dtOgr.Rows[id][0]);
            string TcNo = dtOgr.Rows[id][2].ToString();
            if (TcNo != TcKimlikNo)
                Response.Redirect("profil.aspx?ID=" + pID);
            else
                Response.Redirect("mypage.aspx");
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["SinifID"] != null)
            {
                TcKimlikNo = Session["TcKimlikNo"].ToString();
                string adSoyad = MSSQLDataConnection.SelectStringFromDB("SELECT Ad + ' ' + Soyad FROM tblUyeler WHERE TcKimlikNo ='" + TcKimlikNo + "'");
                lbAdSoyad.Text = adSoyad;
                int SinifID = Convert.ToInt32(Request.QueryString["SinifID"].ToString());
                DataTable dt = MSSQLDataConnection.SelectDataFromDB("SELECT Sinif,Renk,Renk2 FROM tblSiniflar WHERE ID=" + SinifID);
                if (dt.Rows.Count > 0)
                {
                    sinif = dt.Rows[0][0].ToString();
                    spSinif.InnerText = sinif;
                    string renk1 = dt.Rows[0][1].ToString();
                    string renk2 = dt.Rows[0][2].ToString();
                    divKutu.Style["background-color"] = renk1;
                    int yillikYazisi = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblUyeler U INNER JOIN tblProfilMesaj PM ON U.TcKimlikNo = PM.Gonderen WHERE U.Sinif ='" + sinif + "' AND PM.Onay = 'True'");
                    int uyeSayisi = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblUyeler WHERE Sinif ='" + sinif + "'");
                    spYy.InnerText = yillikYazisi.ToString() + " YILLIK YAZISI";
                    spIst.InnerText = uyeSayisi.ToString() + " ÖĞRENCİ";
                    divKutu.Attributes.Add("onmouseover", "this.style.backgroundColor='" + renk2 + "'");
                    divKutu.Attributes.Add("onMouseOut", "this.style.backgroundColor='" + renk1 + "'");
                    Common.FormlarArasi.ogrenciSinif = sinif;
                    ogrenciDoldur();
                }
            }
            else
                Response.Redirect("giris.aspx");
        }
    }
}