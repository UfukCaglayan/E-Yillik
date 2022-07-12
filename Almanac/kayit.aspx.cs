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
    public partial class WebForm4 : System.Web.UI.Page
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
            DataTable dtSinif = MSSQLDataConnection.SelectDataFromDB("SELECT Sinif FROM tblSiniflar");
            for (int i = 0; i < dtSinif.Rows.Count; i++)
            {
                string sinif = dtSinif.Rows[i][0].ToString();
                string ysinif = sinif[3].ToString() + " Şubesi";
                ddlSinif.Items.Add(ysinif);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                comboDoldur();
            
        }

        protected void btnKayitOl_Click(object sender, EventArgs e)
        {
            int TcCount = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(TcKimlikNo) FROM tblUyeler WHERE TcKimlikNo ='" + txtTcKimlikNo.Text + "'");
            int mailCount = MSSQLDataConnection.SelectIntFromDB("SELECT COUNT(Email) FROM tblUyeler WHERE Email ='" + txtEmail.Text + "'");
            string DogumTarihi = ddlGun.SelectedItem.Value.ToString() + "." + ddlAy.SelectedIndex.ToString() + "." + ddlYil.SelectedItem.Value.ToString();
            Common.Common.Password(txtSifre.Text);
            string sinif = ddlSinif.SelectedItem.Value.ToString();
            string ysinif = "12/" + sinif[0].ToString();
            string Kaydet = "INSERT INTO tblUyeler (Ad,Soyad,DogumTarihi,TcKimlikNo,Sifre,Email,Cinsiyet,MezuniyetYili,AdminKontrol,Sinif,Konum,Onay) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "'," + "CONVERT(Date,'" + DogumTarihi + "', 103)" + ",'" + txtTcKimlikNo.Text + "','" + Common.Common.ySifre.Replace("'", "''") + "','" + txtEmail.Text + "','" + ddlCinsiyet.SelectedItem.Value.ToString() + "'," + ddlMezuniyet.SelectedItem.Value.ToString() + ",'False','" + ysinif + "','" + ddlKonum.SelectedValue.ToString() + "','False')";
            if (cbSozlesme.Checked == false)
            {
                //Hata: Sözleşme kabul edilmedi.
            }
            else
            {
                if (txtAd.Text == "" || txtSoyad.Text == "" || ddlGun.SelectedItem.Value.ToString() == "Gün" || ddlAy.SelectedItem.Value.ToString() == "Ay" || ddlAy.SelectedItem.Value.ToString() == "Yıl" || txtTcKimlikNo.Text == "" || txtSifre.Text == "" || txtSifreTekrar.Text == "" || txtEmail.Text == "" || ddlMezuniyet.SelectedItem.Value.ToString() == "Mezuniyet Yılı" || ddlCinsiyet.SelectedItem.Value.ToString() == "Cinsiyet" || ddlCinsiyet.SelectedItem.Value.ToString() == "Seç" || ddlSinif.SelectedItem.Value.ToString() == "Seç" || ddlKonum.SelectedItem.Value.ToString() == "Konum")
            {
                //Hata: Bilgiler eksik girildi.
            }
            else
            {
                if (txtSifre.Text != txtSifreTekrar.Text)
                {
                    //Hata: Şifreler aynı değil
                }
                else
                {
                    if (!Common.Common.IsEmail(txtEmail.Text))
                    { 
                        //Hata:E Mail adresini kontrol ediniz
                    }
                    else
                    {
                        if (!Common.Common.IsTcKimlikNo(txtTcKimlikNo.Text))
                        {
                            //Hata: TcKimlik Numarasını kontrol ediniz
                        }
                        else
                        {
                            if (TcCount != 0)
                            {
                                //Hata: TC kimlik no başkası tarafından kullanılıyor
                            }
                            else
                            {
                                if (mailCount != 0)
                                {
                                    //Hata: Email başkası tarafından kullanılıyor
                                }
                                else
                                MSSQLDataConnection.InsertDataToDB(Kaydet);
                            }

                        }
                    }
                }
            }
            }
        }

    }
}