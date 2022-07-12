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
    public partial class WebForm8 : System.Web.UI.Page
    {
        static string TcKimlikNo;
        static string Alici;
        static int ID;

        private void MesajlariCek()
        {
            string gonderen = Alici;
            string adSoyad = MSSQLDataConnection.SelectStringFromDB("SELECT Ad + ' ' + Soyad FROM tblUyeler WHERE TcKimlikNo ='" + Alici + "'");
            lbKarsidaki.Text = adSoyad;
            lbBen.Text = "Ben";
            int ozelMesaj = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblOzelMesaj WHERE Alici = '" + TcKimlikNo + "' AND Gonderen ='" + gonderen + "' OR Alici ='" + gonderen + "' AND Gonderen ='" + TcKimlikNo + "'");
            Common.FormlarArasi.Gonderen = gonderen;
            Common.FormlarArasi.gonderenSira = 0;
            Common.FormlarArasi.aliciSonTarih = Convert.ToDateTime("01.01.2000");
            Common.FormlarArasi.gonderenSonTarih = Convert.ToDateTime("01.01.2000");
            Common.FormlarArasi.aliciSonSaat = "";
            Common.FormlarArasi.gonderenSonSaat = "";
            Common.FormlarArasi.SonGonderen = "";
            for (int i = 0; i < ozelMesaj; i++)
            {
                Panel pnl = new Panel();
                pnl.ID = "pnl" + i;
                pnl.Style["margin-top"] = "0px";
                pnl.Width = pnlAlan.Width;
                Control OM = LoadControl(@"~/UserControls/ucOzelMesaj.ascx") as UserControl;
                pnl.Controls.Add(OM);
                pnlAlan.Controls.Add(pnl);
            }
        }

        private void ResimleriCek()
        {
            for (int i = 0; i < TcNo.Count; i++)
            {
                Panel pnl = new Panel();
                pnl.ID = "pnlPR" + i;
                pnl.Width = 70;
                pnl.Height = 90;
                pnl.Style["border"] = "1px solid #C5DADD";
                pnl.Style["border-radius"] = "3px";
                pnl.Style["position"] = "relative";
                pnl.Style["top"] = "-1px";
                pnl.Style["left"] = "-1px";
                pnlProfilResimleri.Controls.Add(pnl);
            }
            for (int k = 0; k < TcNo.Count; k++)
            {
                string Name = "pnlPR" + k;
                Panel pnlYer = (Panel)pnlAlan.FindControl(Name);
                ImageButton ib = new ImageButton();
                ib.ID = "imgPR" + k;
                ib.CssClass = "imagebutton";
                int id = MSSQLDataConnection.SelectIntFromDB("SELECT ID FROM tblUyeler WHERE TcKimlikNo ='" + TcNo[k] + "'");
                string cinsiyet = MSSQLDataConnection.SelectStringFromDB("SELECT Cinsiyet FROM tblUyeler WHERE TcKimlikNo ='" + TcNo[k] + "'");
                string adSoyad = MSSQLDataConnection.SelectStringFromDB("SELECT Ad + ' ' + Soyad FROM tblUyeler WHERE TcKimlikNo ='" + TcNo[k] + "'");
                ib.ImageUrl = Common.Common.ProfilResmi(id, Server.MapPath("/"), cinsiyet);
                ib.Attributes.Add("title", adSoyad);
                ib.Click += new ImageClickEventHandler(ib_Click);
                ib.Style["opacity"] = "0.4";
                if(k == 0)
                {
                if (Request.QueryString["Alici"] != null)
                    ib.Style["opacity"] = "1";
                }
                pnlYer.Controls.Add(ib);
            }
        }

        private void opacity()
        {
            for (int i = 0; i < TcNo.Count; i++)
            {
                string name = "imgPR" + i;
                ImageButton img = (ImageButton)pnlProfilResimleri.FindControl(name);
                img.Style["opacity"] = "0.4";
            }
        }

        void ib_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton ib = (ImageButton)sender;
                
                string name = ib.ID;
                int id = Convert.ToInt32(name[5].ToString());
                opacity();
                ib.Style["opacity"] = "1";
                Alici = TcNo[id];
                MesajlariCek();
            }
            catch { }
        }
        static List<string> TcNo = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TcKimlikNo"] == null)
                    Response.Redirect("~/giris.aspx");
                else
                {
                    int x = 0;
                    TcKimlikNo = Session["TcKimlikNo"].ToString();
                    Session["Alici"] = null;
                    int Bildirim = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblProfilMesaj WHERE Alici = '" + TcKimlikNo + "' AND Onay = 'False'");
                    int OzelMesaj = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblOzelMesaj OM INNER JOIN tblMesajlaraGiris MG ON OM.Alici = MG.TcKimlikNo WHERE OM.Alici ='" + TcKimlikNo + "' AND OM.Tarih > MG.Tarih");
                    spBldrm.InnerText = Bildirim.ToString();
                    spMsg.InnerText = OzelMesaj.ToString();
                    lbBen.Text = "";
                    lbKarsidaki.Text = "";
                    int cnt = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblMesajlaraGiris WHERE TcKimlikNo ='" + TcKimlikNo + "'");
                    if (cnt == 0)
                    {
                        string insert = "INSERT INTO tblMesajlaraGiris (TcKimlikNo,Tarih) VALUES ('" + TcKimlikNo + "',GETDATE())";
                        MSSQLDataConnection.InsertDataToDB(insert);
                    }
                    else if (cnt > 0)
                    {
                        string update = "UPDATE tblMesajlaraGiris SET Tarih = GETDATE() WHERE TcKimlikNo ='" + TcKimlikNo + "'";
                        MSSQLDataConnection.UpdateDataToDB(update);
                    }

                    ID = MSSQLDataConnection.SelectIntFromDB("SELECT ID FROM tblUyeler WHERE TcKimlikNo ='" + TcKimlikNo + "'");
                    string cinsiyet = MSSQLDataConnection.SelectStringFromDB("SELECT Cinsiyet FROM tblUyeler WHERE TcKimlikNo ='" + TcKimlikNo + "'");
                    imgPR.ImageUrl = Common.Common.ProfilResmi(ID, Server.MapPath("/"),cinsiyet);
                    string isimSoyisim = MSSQLDataConnection.SelectStringFromDB("SELECT Ad + ' ' + Soyad FROM tblUyeler WHERE TcKimlikNo = '" + TcKimlikNo + "'");
                    lbAdSoyad.Text = isimSoyisim + " - Özel Mesajlar";
                    DataTable dtGonderen = MSSQLDataConnection.SelectDataFromDB("SELECT Gonderen,MAX(Tarih) FROM tblOzelMesaj WHERE Alici = '" + TcKimlikNo + "' GROUP BY Gonderen");
                    DataTable dtAlici = MSSQLDataConnection.SelectDataFromDB("SELECT Alici,MAX(Tarih) FROM tblOzelMesaj WHERE Gonderen = '" + TcKimlikNo + "' GROUP BY Alici");
                    x = dtGonderen.Rows.Count + dtAlici.Rows.Count;
                    List<string> Zaman = new List<string>();
                    TcNo.Clear();
                    if (Request.QueryString["Alici"] != null)
                    {
                        Alici = MSSQLDataConnection.SelectStringFromDB("SELECT TcKimlikNo FROM tblUyeler WHERE ID =" + Convert.ToInt32(Request.QueryString["Alici"].ToString()));
                        TcNo.Add(Alici);
                        MesajlariCek();
                    }
                    int i = 0;
                    if (dtGonderen.Rows.Count != 0)
                        for (i = 0; i < dtGonderen.Rows.Count; i++)
                        {
                            DateTime zmn = Convert.ToDateTime(dtGonderen.Rows[i][1]);
                            string zaman = zmn.ToString("yyyy-MM-dd HH:mm:ss.fff");
                            Zaman.Add(zaman);
                        }
                    for (int k = 0; k < dtAlici.Rows.Count; k++)
                    {
                        DateTime zmn = Convert.ToDateTime(dtAlici.Rows[k][1]);
                        string zaman = zmn.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        Zaman.Add(zaman);
                    }
                    if (Zaman.Count > 0)
                    {
                        Zaman.Sort();
                        Zaman.Reverse();
                        for (int m = 0; m < Zaman.Count; m++)
                        {
                            string Tc;
                            string zaman = Zaman[m];
                            string Alici = MSSQLDataConnection.SelectStringFromDB("SELECT Alici FROM tblOzelMesaj WHERE Tarih = CONVERT(datetime, '" + zaman + "', 121)");
                            string Gonderen = MSSQLDataConnection.SelectStringFromDB("SELECT Gonderen FROM tblOzelMesaj WHERE Tarih = CONVERT(datetime, '" + zaman + "', 121)");
                            if (Alici == TcKimlikNo)
                                Tc = Gonderen;
                            else
                                Tc = Alici;

                            if (!TcNo.Contains(Tc))
                                TcNo.Add(Tc);
                        }
                    }
                }
            }
            ResimleriCek();
        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            if (Alici == "")
            {
                //Hata : Mesaj gönderilecek kişi seçilmedi.
            }
            else
            {
                if (txtMesaj.Text == "")
                {
                    //Hata : Mesaj girilmedi.
                }
                else
                {
                    string insert = "INSERT INTO tblOzelMesaj (Gonderen,Alici,Mesaj,Tarih) VALUES ('" + TcKimlikNo + "','" + Alici + "','" + txtMesaj.Text + "',GETDATE())";
                    MSSQLDataConnection.InsertDataToDB(insert);
                    MesajlariCek();
                    txtMesaj.Text = "";
                }
            }
        }

        protected void tmrYenile_Tick(object sender, EventArgs e)
        {
            MesajlariCek();
        }
    }
      
}