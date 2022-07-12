using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Almanac.Common;

namespace Almanac
{
    public partial class sikayet : System.Web.UI.Page
    {
        static string TcKimlikNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            TcKimlikNo = Session["TcKimlikNo"].ToString();
            string adSoyad = MSSQLDataConnection.SelectStringFromDB("SELECT Ad + ' ' + Soyad FROM tblUyeler WHERE TcKimlikNo ='" + TcKimlikNo + "'");
            spAdSoyad.InnerText = adSoyad;
        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            int resimID = MSSQLDataConnection.SelectIntFromDB("SELECT IDENT_CURRENT('tblSikayetler')");
            string icerik = Common.Common.HtmlTagEdit(txtIcerik.Text);
            string fileName = "";
            if (fuSikayet.FileName != "")
                fileName = fuSikayet.FileName;

            string kaydet = "INSERT INTO tblSikayetler (Gonderen,KonuBasligi,SikayetSebebi,Icerik,Resim,Onay,Tarih) VALUES ('" + TcKimlikNo + "','" + txtKonuBasligi.Text + "','" + ddlSebep.SelectedItem.Value.ToString() + "','" + icerik.Replace("'", "''") + "','" + fileName + "','False',GETDATE())";
            MSSQLDataConnection.SelectStringFromDB(kaydet);
            if(fuSikayet.FileName != "")
                Common.Common.dosyaKaydet(fuSikayet, "Sikayetler", resimID.ToString());
        }
    }
}