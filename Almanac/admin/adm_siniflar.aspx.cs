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
    public partial class WebForm13 : System.Web.UI.Page
    {
        static DataTable dtSiniflar;
        static int sinifSayisi;

        private void sinifDoldur()
        {
            pnlSiniflar.Controls.Clear();
            for (int i = 0; i < sinifSayisi; i++)
            {
                Panel pnl = new Panel();
                pnl.Width = 300;
                pnl.Height = 130;
                pnl.Style["border"] = " 1px solid #C5DADD;";
                pnl.Style["margin-top"] = "10px";
                pnl.Style["margin-left"] = "10px";
                pnl.Style["float"] = "left";
                Panel pnlKutu = new Panel();
                pnlKutu.Attributes.Add("class", "pnlSinif");
                Label lbSinif = new Label();
                lbSinif.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                lbSinif.Font.Size = 15;
                lbSinif.Style["margin-left"] = "25px";
                lbSinif.Style["margin-top"] = "5px";
                lbSinif.Text = "Sınıf";
                try
                {
                    lbSinif.Text = dtSiniflar.Rows[i][1].ToString();
                    string renk1 = dtSiniflar.Rows[i][2].ToString();
                    string renk2 = dtSiniflar.Rows[i][3].ToString();
                    pnlKutu.Style["background-color"] = renk1;
                    pnlKutu.Attributes.Add("onmouseover", "this.style.backgroundColor='" + renk2 + "'");
                    pnlKutu.Attributes.Add("onMouseOut", "this.style.backgroundColor='" + renk1 + "'");
                }
                catch { }
                pnlKutu.Controls.Add(lbSinif);
                pnl.Controls.Add(pnlKutu);
                Panel pnlIc = new Panel();
                pnlIc.Style["margin-top"] = "9px";
                Label lbSube = new Label();
                lbSube.Style["margin-left"] = "5px";
                lbSube.Text = "Şubeyi Yazınız";
                pnlIc.Controls.Add(lbSube);
                TextBox txtSube = new TextBox();
                txtSube.Style["margin-left"] = "5px";
                txtSube.Style["margin-top"] = "5px";
                txtSube.Width = 150;
                txtSube.ID = "txtSube" + i;
                try
                { txtSube.Text = dtSiniflar.Rows[i][1].ToString().Substring(3); }
                catch { }
                pnlIc.Controls.Add(txtSube);
                pnlIc.Controls.Add(new LiteralControl("<br />"));
                Label lbRenk = new Label();
                lbRenk.Text = "Renk Seçiniz";
                lbRenk.Style["margin-left"] = "5px";
                lbRenk.Style["margin-top"] = "5px";
                pnlIc.Controls.Add(lbRenk);
                TextBox txtRenk = new TextBox();
                txtRenk.Style["margin-left"] = "5px";
                txtRenk.Style["margin-top"] = "5px";
                txtRenk.Width = 150;
                txtRenk.ID = "txtRenk" + i;
                try
                { txtRenk.Text = dtSiniflar.Rows[i][2].ToString(); }
                catch { }
                pnlIc.Controls.Add(txtRenk);
                pnlIc.Controls.Add(new LiteralControl("<br />"));
                Button btnOnayla = new Button();
                btnOnayla.ID = "btnOnayla" + i;
                btnOnayla.Text = "Onayla";
                btnOnayla.Click += new EventHandler(btnOnayla_Click);
                btnOnayla.Style["float"] = "right";
                btnOnayla.Style["margin-right"] = "17px";
                btnOnayla.Style["margin-top"] = "5px";
                pnlIc.Controls.Add(btnOnayla);
                pnl.Controls.Add(pnlIc);
                pnlSiniflar.Controls.Add(pnl);
            }
        }

        void btnOnayla_Click(object sender, EventArgs e)
        {
            Button ib = (Button)sender;
            string name = ib.ID;
            int index = Convert.ToInt32(name[9].ToString());
            TextBox txtSube = (TextBox)pnlSiniflar.FindControl("txtSube" + index);
            string sube = "12/" + txtSube.Text;
            TextBox txtRenk = (TextBox)pnlSiniflar.FindControl("txtRenk" + index);
            try
            {
                int id = Convert.ToInt32(dtSiniflar.Rows[index][0]);
                string update = "UPDATE tblSiniflar SET Sinif='" + sube + "',Renk='" + txtRenk.Text + "' WHERE ID=" + id;
                MSSQLDataConnection.SelectDataFromDB(update);
            }
            catch
            {
                string insert = "INSERT INTO tblSiniflar (Sinif,Renk,Renk2) VALUES ('" + sube + "','" + txtRenk.Text + "','" + txtRenk.Text + "')";
                MSSQLDataConnection.InsertDataToDB(insert);
            }
            sinifDoldur();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dtSiniflar = MSSQLDataConnection.SelectDataFromDB("SELECT ID,Sinif,Renk,Renk2 FROM tblSiniflar");
                sinifSayisi = dtSiniflar.Rows.Count;
                txtSinifSayisi.Text = sinifSayisi.ToString();
                int sikayet = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblSikayetler WHERE Onay = 'False'");
                spSikayet.InnerText = sikayet.ToString();
            }
            sinifDoldur();
        }

        protected void txtSinifSayisi_TextChanged(object sender, EventArgs e)
        {
            sinifSayisi = Convert.ToInt32(txtSinifSayisi.Text);
            sinifDoldur();
        }
    }
}