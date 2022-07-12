using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Almanac.Common;
using System.IO;
using System.Web.UI.HtmlControls;

namespace Almanac
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        static int ID;

        private void galeriDoldur()
        {
            for (int i = 0; i < 9; i++)
            {
                string name = "imgGlr" + (i + 1).ToString();
                ImageButton img = (ImageButton)UpdatePanel1.FindControl(name);
                img.ImageUrl = Common.Common.galeriDoldur(Server.MapPath("/Galeri/" + ID.ToString()), i + 1, ID,"artı");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                FileUpload fu = new FileUpload();
                fu.Attributes.Add("runat", "server");
                fu.ID = "fuGaleri" + (i + 1).ToString();
                fu.Style["margin-top"] = "1px";
                fu.Style["z-index"] = "1";
                fu.Style["position"] = "absolute";
                fu.Height = 1;
                fu.Width = 1;
                pnlFileUpload.Controls.Add(fu);
            }
            if (!IsPostBack)
            {
                if (Session["TcKimlikNo"] == null)
                    Response.Redirect("~/giris.aspx");
                else
                {
                    string TcKimlikNo = Session["TcKimlikNo"].ToString();
                    Session["Alici"] = null;
                    ID = MSSQLDataConnection.SelectIntFromDB("SELECT ID FROM tblUyeler WHERE TcKimlikNo ='" + TcKimlikNo + "'");
                    string adSoyad = MSSQLDataConnection.SelectStringFromDB("SELECT Ad + ' ' + Soyad FROM tblUyeler WHERE TcKimlikNo ='" + TcKimlikNo + "'");
                    string cinsiyet = MSSQLDataConnection.SelectStringFromDB("SELECT Cinsiyet FROM tblUyeler WHERE TcKimlikNo ='" + TcKimlikNo + "'");
                    imgPR.ImageUrl = Common.Common.ProfilResmi(ID, Server.MapPath("/"),cinsiyet);
                    lbAdSoyad.Text = adSoyad + " - Galeri";
                    int Bildirim = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblProfilMesaj WHERE Alici = '" + TcKimlikNo + "' AND Onay = 'False'");
                    int OzelMesaj = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblOzelMesaj OM INNER JOIN tblMesajlaraGiris MG ON OM.Alici = MG.TcKimlikNo WHERE OM.Alici ='" + TcKimlikNo + "' AND OM.Tarih > MG.Tarih");
                    spBldrm.InnerText = Bildirim.ToString();
                    spMsg.InnerText = OzelMesaj.ToString();
                    galeriDoldur();
                    for (int i = 0; i < 9; i++)
                    {
                        string fname = "fuGaleri" + (i + 1).ToString();
                        string iname = "imgGlr" + (i + 1).ToString();
                        FileUpload fu = (FileUpload)pnlFileUpload.FindControl(fname);
                        ImageButton img = (ImageButton)UpdatePanel1.FindControl(iname);
                        img.Attributes.Add("onclick", "document.getElementById('" + fu.ClientID + "').click()");
                    }
                }
            }
        }

        private void resimEkle(string fu)
        {
            FileUpload flu = (FileUpload)pnlFileUpload.FindControl(fu);
            string name = flu.ID;
            int id = Convert.ToInt32(name[8].ToString());
            if (!Directory.Exists(Server.MapPath("/Galeri/" + ID.ToString())))
            {
                Directory.CreateDirectory(Server.MapPath("/Galeri/" + ID.ToString()));
                Common.Common.dosyaSil(id, Server.MapPath("/Galeri/" + ID.ToString()));
                Common.Common.dosyaKaydet(flu, "Galeri/" + ID.ToString(), id.ToString());
            }
            else
            {
                Common.Common.dosyaSil(id, Server.MapPath("/Galeri/" + ID.ToString()));
                Common.Common.dosyaKaydet(flu, "Galeri/" + ID.ToString(), id.ToString());
            }
        }

        private void gecici(string fu)
        {
            FileUpload flu = (FileUpload)pnlFileUpload.FindControl(fu);
            string name = flu.ID;
            int id = Convert.ToInt32(name[8].ToString());
            string iname = "imgGlr" + id;

            if (!Directory.Exists(Server.MapPath("/GeciciGaleri/" + ID.ToString())))
            {
                Directory.CreateDirectory(Server.MapPath("/GeciciGaleri/" + ID.ToString()));
                Common.Common.dosyaKaydet(flu, "GeciciGaleri/" + ID.ToString(), Path.GetFileNameWithoutExtension(flu.FileName));
                ImageButton img = (ImageButton)UpdatePanel1.FindControl(iname);
                img.ImageUrl = "GeciciGaleri/" + ID.ToString() + "/" + flu.FileName;
            }
            else
            {
                Common.Common.dosyaKaydet(flu, "GeciciGaleri/" + ID.ToString(), Path.GetFileNameWithoutExtension(flu.FileName));
                ImageButton img = (ImageButton)UpdatePanel1.FindControl(iname);
                img.ImageUrl = "GeciciGaleri/" + ID.ToString() + "/" + flu.FileName;
            }

        }

       static List<string> fileUpload = new List<string>();

        protected void imgGlr1_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ib = (ImageButton)sender;
            string name = ib.ID;
            int id = Convert.ToInt32(name[6].ToString());
            string fname = "fuGaleri" + id;
            FileUpload fu = (FileUpload)pnlFileUpload.FindControl(fname);
            ib.Attributes.Add("onclick", "document.getElementById('" + fu.ClientID + "').click()");
            if (!fileUpload.Contains(fname))
                fileUpload.Add(fname);
        }

        protected void btnTamam_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < fileUpload.Count; i++)
            {
                resimEkle(fileUpload[i].ToString());
            }
            galeriDoldur();
            fileUpload.Clear();
        }

        protected void btnYenile_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                string name = "fuGaleri" + (i + 1).ToString();
                FileUpload fu = (FileUpload)pnlFileUpload.FindControl(name);
                if (fu.FileName != "")
                    gecici(name);
            }
        }
    }
}