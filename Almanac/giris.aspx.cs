using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Almanac.Common;
using System.Web.UI.HtmlControls;

namespace Almanac
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TcKimlikNo"] != null)
                    Response.Redirect("anasayfa.aspx");
            }
            txtTcKimlikNo.MaxLength = 11;
        }

        static string engelliTarih = "";
        private static bool engelliKontrol()
        {
            bool kontrol = false;
            engelliTarih = MSSQLDataConnection.SelectStringFromDB("SELECT CONVERT(VARCHAR,BitisTarihi,104) FROM tblEngelliUyeler WHERE TcKimlikNo = '" + TcKimlikNo + "' AND Durum = 'True' AND CONVERT(DATE,GETDATE(),104) < BitisTarihi");
            if (engelliTarih != "")
                kontrol = true;
            else
                kontrol = false;

            return kontrol;
        }

        private static bool onayKontrol()
        {
            bool kontrol = false;
            string onay = MSSQLDataConnection.SelectStringFromDB("SELECT Onay FROM tblUyeler WHERE TcKimlikNo = '" + TcKimlikNo + "'");
            if (onay == "True")
                kontrol = true;
            else
                kontrol = false;

            return kontrol;

        }
        static string TcKimlikNo;

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            System.Web.UI.Page page = (System.Web.UI.Page)this.Page;
            giris1 grs = (giris1)page.Master;
            Timer tmr = (Timer)grs.FindControl("tmrBildirim");
            tmr.Enabled = true;
            TcKimlikNo = txtTcKimlikNo.Text;
            string Sifre = txtSifre.Text;
            Common.Common.Password(Sifre);
            DataTable dt = MSSQLDataConnection.SelectDataFromDB("SELECT TcKimlikNo,Sifre,AdminKontrol FROM tblUyeler WHERE TcKimlikNo = '" + txtTcKimlikNo.Text + "'");
            if (txtTcKimlikNo.Text != "" && txtSifre.Text != "")
            {
                if (!Common.Common.IsTcKimlikNo(txtTcKimlikNo.Text))
                {
                    FormlarArasi.div = "ikaz";
                    FormlarArasi.mesaj = "TC Kimlik Numarasını kontrol ediniz";
                }
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (Common.Common.ySifre == dt.Rows[0][1].ToString())
                        {
                            FormlarArasi.div = "bilgi";
                            FormlarArasi.mesaj = "Başarıyla giriş yaptınız.Anasayfaya yönlendiriliyorsunuz.";
                            if (dt.Rows[0][2].ToString() == "True")
                            {
                                Session["Admin"] = dt.Rows[0][0].ToString();
                                Session["Tip"] = "Admin";
                                Response.Redirect("adm_uyeonaylama.aspx");
                            }
                            else if (dt.Rows[0][2].ToString() == "False")
                            {
                                bool onay = onayKontrol();
                                if (onay == false)
                                {
                                    FormlarArasi.div = "bilgi";
                                    FormlarArasi.mesaj = "Üyeliğiniz onay aşamasındadır.";
                                }
                                else
                                {
                                    bool engelkontrol = engelliKontrol();
                                    if (engelkontrol == true)
                                    {
                                        FormlarArasi.div = "ikaz";
                                        FormlarArasi.mesaj = engelliTarih + " tarihine kadar engellisiniz";
                                    }
                                    else
                                    {
                                        Session["TcKimlikNo"] = dt.Rows[0][0].ToString();
                                        Session["Tip"] = "Uye";
                                        Common.FormlarArasi.aramaTc = dt.Rows[0][0].ToString();
                                        Response.Redirect("anasayfa.aspx");
                                    }
                                }
                            }
                        }
                        else
                        {
                            FormlarArasi.div = "hata";
                            FormlarArasi.mesaj = "TC Kimlik No veya Şifre hatalı girildi.";
                        }
                    }
                    else
                    {
                        FormlarArasi.div = "hata";
                        FormlarArasi.mesaj = "TC Kimlik No bulunamadı.";
                    }
                }
            }
            else
            {
                FormlarArasi.div = "ikaz";
                FormlarArasi.mesaj = "TC Kimlik No ve Şifreyi boş girmeyiniz.";
            }
        }
    }

}