using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Almanac.Common;
using System.Threading;

namespace Almanac
{
    public partial class WebForm7 : System.Web.UI.Page
    {

        private void comboDoldur()
        {
            DataTable dt = MSSQLDataConnection.SelectDataFromDB("SELECT TarihGun,TarihAy,TarihYil,Mezuniyet,Konum FROM tblSayfaDuzeni");
            string[] gunParcala = dt.Rows[0][0].ToString().Split(',');
            string[] ayParcala = dt.Rows[0][1].ToString().Split(',');
            string[] yilParcala = dt.Rows[0][2].ToString().Split(',');
            string[] mezuniyetParcala = dt.Rows[0][3].ToString().Split(',');
            string[] konumParcala = dt.Rows[0][4].ToString().Split(',');
            for (int i = 0; i < gunParcala.Length; i++)
            { ddlGun.Items.Add(gunParcala[i].ToString()); }
            for (int k = 0; k < ayParcala.Length; k++)
            { ddlAy.Items.Add(ayParcala[k].ToString()); }
            for (int l = 0; l < yilParcala.Length; l++)
            { ddlYil.Items.Add(yilParcala[l].ToString()); }
            for (int m = 0; m < mezuniyetParcala.Length; m++)
            { ddlMezuniyet.Items.Add(mezuniyetParcala[m].ToString()); }
            for (int n = 0; n < konumParcala.Length; n++)
            { ddlKonum.Items.Add(konumParcala[n].ToString()); }
        }



        private void FormuDoldur()
        {
            imgPR.ImageUrl = Common.Common.ProfilResmi(ID, Server.MapPath("/"),cinsiyet);
            DataTable dt = MSSQLDataConnection.SelectDataFromDB("SELECT Ad,Soyad,DogumTarihi,Cinsiyet,MezuniyetYili,Konum,TcKimlikNo,Sifre,Email,FacebookAdres,TwitterAdres FROM tblUyeler WHERE TcKimlikNo ='" + TcKimlikNo + "'");
            if (dt.Rows.Count > 0)
            {
                lbAdSoyad.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString() + " - Ayarlar";
                txtAd.Text = dt.Rows[0][0].ToString();
                txtSoyad.Text = dt.Rows[0][1].ToString();
                DateTime tarih = Convert.ToDateTime(dt.Rows[0][2].ToString());
                ddlGun.Text = tarih.ToString("dd");
                ddlAy.SelectedIndex = tarih.Month;
                ddlYil.Text = tarih.Year.ToString();
                ddlCinsiyet.Text = dt.Rows[0][3].ToString();
                ddlMezuniyet.Text = dt.Rows[0][4].ToString();
                ddlKonum.Text = dt.Rows[0][5].ToString();
                txtTcKimlikNo.Text = dt.Rows[0][6].ToString();
                Sifre = dt.Rows[0][7].ToString();
                txtEmail.Text = dt.Rows[0][8].ToString();
                txtFacebook.Text = dt.Rows[0][9].ToString();
                txtTwitter.Text = dt.Rows[0][10].ToString();
                imgPRF.ImageUrl = Common.Common.ProfilResmi(ID, Server.MapPath("/"),cinsiyet);
                profilResmi = Common.Common.ProfilResmi(ID, Server.MapPath("/"),cinsiyet);
            }
        }

        static string TcKimlikNo;
        static string profilResmi;
        static int ID;
        static string cinsiyet;
        static string Sifre;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TcKimlikNo"] == null)
                    Response.Redirect("~/giris.aspx");
                else
                {
                    comboDoldur();
                    TcKimlikNo = Session["TcKimlikNo"].ToString();
                    int Bildirim = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblProfilMesaj WHERE Alici = '" + TcKimlikNo + "' AND Onay = 'False'");
                    int OzelMesaj = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(*) FROM tblOzelMesaj OM INNER JOIN tblMesajlaraGiris MG ON OM.Alici = MG.TcKimlikNo WHERE OM.Alici ='" + TcKimlikNo + "' AND OM.Tarih > MG.Tarih");
                    spBldrm.InnerText = Bildirim.ToString();
                    spMsg.InnerText = OzelMesaj.ToString();
                    ID = MSSQLDataConnection.SelectIntFromDB("SELECT ID FROM tblUyeler WHERE TcKimlikNo ='" + TcKimlikNo + "'");
                    cinsiyet = MSSQLDataConnection.SelectStringFromDB("SELECT Cinsiyet FROM tblUyeler WHERE TcKimlikNo ='" + TcKimlikNo + "'");
                    Session["Alici"] = null;
                    FormuDoldur();
                }
            }
            imgPRF.Attributes.Add("onclick", "document.getElementById('" + fuProfilResmi.ClientID + "').click()");
        }


        protected void btnTamam_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "" || txtSoyad.Text == "" || ddlGun.SelectedItem.Value.ToString() == "Gün" || ddlAy.SelectedItem.Value.ToString() == "Ay" || ddlAy.SelectedItem.Value.ToString() == "Yıl" || txtTcKimlikNo.Text == "" || txtEmail.Text == "" || ddlMezuniyet.SelectedItem.Value.ToString() == "Mezuniyet Yılı")
            {
                //Hata: Bilgiler eksik girildi.
            }
            else
            {
                if (!Common.Common.IsTcKimlikNo(txtTcKimlikNo.Text))
                {
                    //Hata: TcKimlikNo yanlış girildi.
                }
                else
                {
                    if (!Common.Common.IsEmail(txtEmail.Text))
                    {
                        //Hata: Email yanlış girildi.
                    }
                    else
                    {
                        if (fuProfilResmi.FileName != "")
                        {
                            Common.Common.dosyaSil(ID, Server.MapPath("/ProfilResimleri"));
                            Common.Common.dosyaKaydet(fuProfilResmi, "ProfilResimleri", ID.ToString());
                            profilResmi = Common.Common.ProfilResmi(ID, Server.MapPath("/"),cinsiyet);
                            imgPR.ImageUrl = profilResmi;
                            imgPRF.ImageUrl = profilResmi;
                        }

                        string DogumTarihi = ddlAy.SelectedIndex.ToString() + "." + ddlGun.SelectedItem.Value.ToString() + "." + ddlYil.SelectedItem.Value.ToString();
                        string update = "UPDATE tblUyeler SET Ad ='" + txtAd.Text + "',Soyad='" + txtSoyad.Text + "',DogumTarihi='" + DogumTarihi +
                                        "',Cinsiyet='" + ddlCinsiyet.SelectedItem.Value.ToString() + "',MezuniyetYili=" + ddlMezuniyet.SelectedItem.Value.ToString() +
                                        ",Konum='" + ddlKonum.SelectedItem.Value.ToString() + "',Email='" + txtEmail.Text +
                                         "',FacebookAdres='" + txtFacebook.Text + "',TwitterAdres='" + txtTwitter.Text + "' WHERE TcKimlikNo='" + TcKimlikNo + "'";
                        MSSQLDataConnection.UpdateDataToDB(update);
                        Common.Common.Password(txtEskiSifre.Text);
                        if (txtYeniSifre.Text != "")
                        {
                            if (Common.Common.ySifre != Sifre)
                            {
                                //Eski şifre yanlış girildi
                            }
                            else
                            {
                                if (txtYeniSifre.Text != txtSifreTekrar.Text)
                                {
                                    //Yeni şifre ile şifre tekrar aynı değil.
                                }
                                else
                                {
                                    Common.Common.Password(txtYeniSifre.Text);
                                    string updateSifre = "UPDATE tblUyeler SET Sifre ='" + Common.Common.ySifre + "' WHERE TcKimlikNo='" + TcKimlikNo + "'";
                                    MSSQLDataConnection.UpdateDataToDB(updateSifre);
                                    txtEskiSifre.Text = "";
                                    txtYeniSifre.Text = "";
                                    txtSifreTekrar.Text = "";
                                }
                            }
                        }

                    }
                }
            }
        }

        protected void imgPRF_Click(object sender, ImageClickEventArgs e)
        {
            imgPRF.Attributes.Add("onclick", "document.getElementById('" + fuProfilResmi.ClientID + "').click()");
            //string yol;
            //if (fuProfilResmi.FileName != "")
            //    yol = fuProfilResmi.PostedFile.FileName.ToString();

            //   imgPRF.ImageUrl = fuProfilResmi.PostedFile.FileName
        }
    }
}