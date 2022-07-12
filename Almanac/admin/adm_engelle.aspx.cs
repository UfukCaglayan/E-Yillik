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
    public partial class WebForm14 : System.Web.UI.Page
    {
        static string sinif;
        static DataTable dtOgr;

        static DataTable dtSiniflar;
        private void sinifDoldur()
        {
            dtSiniflar = MSSQLDataConnection.SelectDataFromDB("SELECT Sinif FROM tblSiniflar");
            for (int i = 0; i < dtSiniflar.Rows.Count; i++)
            {
                Panel pnl = new Panel();
                pnl.Style["float"] = "left";
                pnl.Style["margin-left"] = "5px";
                pnl.Width = 50;
                pnl.Height = 50;
                ImageButton ib = new ImageButton();
                ib.ID = "ib" + dtSiniflar.Rows[i][0].ToString();
                ib.ImageUrl = "~/images/sinifkutu.jpg";
                ib.Width = 50;
                ib.Height = 50;
                ib.Style["margin-left"] = "5px";
                ib.Style["float"] = "left";
                ib.Click += new ImageClickEventHandler(ib_Click);
                pnl.Controls.Add(ib);
                Panel pnlLabel = new Panel();
                pnlLabel.Style["float"] = "left";
                pnlLabel.Style["margin-left"] = "5px";
                pnlLabel.Style["margin-top"] = "-30px";
                Label lb = new Label();
                lb.Text = dtSiniflar.Rows[i][0].ToString();
                lb.Font.Size = 13;
                lb.ForeColor = System.Drawing.ColorTranslator.FromHtml("#575757");
                pnlLabel.Controls.Add(lb);
                pnl.Controls.Add(pnlLabel);
                pnlSiniflar.Controls.Add(pnl);
            }
        }

        void ib_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton snd = (ImageButton)sender;
            string name = snd.ID;
            sinif = name.Substring(2);
            engelliDoldur();
        }

        private void engelliDoldur()
        {
            if (sinif != "")
            {
                pnlEngelliUyeler.Controls.Clear();
                dtOgr = MSSQLDataConnection.SelectDataFromDB("SELECT Ad,Soyad,ID,Cinsiyet,TcKimlikNo,MezuniyetYili FROM tblUyeler WHERE Sinif = '" + sinif + "' AND AdminKontrol = 'False'");
                for (int i = 0; i < dtOgr.Rows.Count; i++)
                {
                    Panel pnl = new Panel();
                    pnl.Width = 330;
                    pnl.Attributes.Add("class", "panelEngel");
                    Image img = new Image();
                    img.ImageUrl = "images/yeni.png";
                    img.Width = 70;
                    img.Height = 80;
                    img.Attributes.Add("class", "imgEngel");
                    int ID = Convert.ToInt32(dtOgr.Rows[i][2]);
                    string cinsiyet = dtOgr.Rows[i][3].ToString();
                    img.ImageUrl = Common.Common.ProfilResmi(ID, Server.MapPath("/"), cinsiyet);
                    pnl.Controls.Add(img);
                    Panel pnlBilgiler = new Panel();
                    pnlBilgiler.Attributes.Add("class", "panelIcEngel");
                    Panel pnlTc = new Panel();
                    Label lbTc = new Label();
                    lbTc.Text = "TC Kimlik No : " + dtOgr.Rows[i][4].ToString();
                    pnlTc.Controls.Add(lbTc);
                    pnlBilgiler.Controls.Add(pnlTc);
                    Panel pnlAd = new Panel();
                    Label lbAd = new Label();
                    lbAd.Text = "Ad : " + dtOgr.Rows[i][0].ToString();
                    pnlAd.Controls.Add(lbAd);
                    pnlBilgiler.Controls.Add(pnlAd);
                    Panel pnlSoyad = new Panel();
                    Label lbSoyad = new Label();
                    lbSoyad.Text = "Soyad : " + dtOgr.Rows[i][1].ToString();
                    pnlSoyad.Controls.Add(lbSoyad);
                    pnlBilgiler.Controls.Add(pnlSoyad);
                    Panel pnlTarih = new Panel();
                    Label lbTarih = new Label();
                    lbTarih.Text = "Mezun. Tarihi : " + dtOgr.Rows[i][5].ToString();
                    pnlTarih.Controls.Add(lbTarih);
                    pnlBilgiler.Controls.Add(pnlTarih);
                    pnl.Controls.Add(pnlBilgiler);
                    Panel pnlEngelle = new Panel();
                    pnlEngelle.Width = 235;
                    pnlEngelle.Style["float"] = "left";
                    pnlEngelle.Style["margin-top"] = "5px";
                    pnlEngelle.Style["margin-left"] = "5px";
                    Button btnEngelle = new Button();
                    btnEngelle.ID = "btnEngelle" + i;
                    int count = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblEngelliUyeler WHERE TcKimlikNo = '" + dtOgr.Rows[i][4].ToString() + "' AND Durum ='True'");
                    if (count == 0)
                    {
                        Label lbSure = new Label();
                        lbSure.Text = "Süre : ";
                        lbSure.Style["font-family"] = "Calibri"; 
                        lbSure.Style["font-size"] = "15px";
                        pnlEngelle.Controls.Add(lbSure);
                        DropDownList ddl = new DropDownList();
                        ddl.ID = "ddlSure" + i;
                        ddl.Items.Add("1 Gün");
                        ddl.Items.Add("1 Hafta");
                        ddl.Items.Add("1 Ay");
                        ddl.Items.Add("3 Ay");
                        ddl.Items.Add("1 Yıl");
                        ddl.Items.Add("Sınırsız");
                        pnlEngelle.Controls.Add(ddl);
                        btnEngelle.Text = "Engelle";
                    }
                    else
                    {
                        Label lbBitisTarihi = new Label();
                        string bitisTarihi = MSSQLDataConnection.SelectStringFromDB("SELECT CONVERT(VARCHAR,BitisTarihi,104) FROM tblEngelliUyeler WHERE TcKimlikNo = '" + dtOgr.Rows[i][4].ToString() + "' AND Durum ='True'");
                        lbBitisTarihi.Text = "Bitiş Tarihi : " + bitisTarihi;
                        pnlEngelle.Controls.Add(lbBitisTarihi);
                        btnEngelle.Text = "Engeli Kaldır";
                    }
                    btnEngelle.Click += new EventHandler(btnEngelle_Click);
                    pnlEngelle.Controls.Add(btnEngelle);
                    pnl.Controls.Add(pnlEngelle);
                    pnlEngelliUyeler.Controls.Add(pnl);
                }
            }

        }

        void btnEngelle_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string name = btn.ID;
            int id = Convert.ToInt32(name[10].ToString());
            string TcNo = dtOgr.Rows[id][4].ToString();
            if (btn.Text == "Engelle")
            {
                string ddlName = "ddlSure" + id;
                DropDownList ddl = (DropDownList)pnlEngelliUyeler.FindControl(ddlName);
                string sure = ddl.SelectedItem.Value.ToString();
                string dateadd = "";
                if (sure == "1 Gün")
                    dateadd = "',DATEADD(DAY, 1, GETDATE()";
                else if (sure == "1 Hafta")
                    dateadd = "',DATEADD(DAY, 7, GETDATE())";
                else if (sure == "1 Ay")
                    dateadd = "',DATEADD(MONTH, 1, GETDATE())";
                else if (sure == "3 Ay")
                    dateadd = "',DATEADD(MONTH, 3, GETDATE())";
                else if (sure == "1 Yıl")
                    dateadd = "',DATEADD(YEAR, 1, GETDATE())";
                else if (sure == "Sınırsız")
                    dateadd = "','01-01.3000')";

                string query = "INSERT INTO tblEngelliUyeler (TcKimlikNo,BitisTarihi,Durum,Sure,EngellemeTarihi) VALUES ('" + TcNo + dateadd + ",'True','" + sure + "',GETDATE())";
                MSSQLDataConnection.InsertDataToDB(query);
            }
            else if (btn.Text == "Engeli Kaldır")
            {
                string update = "UPDATE tblEngelliUyeler SET Durum = 'False' WHERE TcKimlikNo = '" + TcNo + "' AND Durum ='True'";
                MSSQLDataConnection.UpdateDataToDB(update);
            }
            engelliDoldur();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            sinifDoldur();
            engelliDoldur();
            if (!IsPostBack)
            {
                int sikayet = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblSikayetler WHERE Onay = 'False'");
                spSikayet.InnerText = sikayet.ToString();
                sinif = "";
            }
        }

    }
}