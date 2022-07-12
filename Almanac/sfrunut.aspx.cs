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
    public partial class sfrunut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private string RandomCreate()
        {
            String returnValue = null;
            Random rndChar = new Random();
            Random rndNum = new Random();
            for (int i = 0; i < 15; i++)
            {
                if (i == 2 || i == 4 || i == 5)
                    returnValue += Convert.ToChar(rndChar.Next(65, 90));

                else if (i == 8 || i == 11 || i == 13 || i == 0 || i == 9 || i == 10)
                    returnValue += Convert.ToChar(rndChar.Next(48, 57));

                if (i == 1 || i == 3 || i == 6 || i == 12 || i == 14 || i == 7)
                    returnValue += Convert.ToChar(rndNum.Next(97, 122));

            }
            return returnValue;
        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            if (txtEmail.Value != "")
            {
                int Count;
                string Aktivasyon;
                DataTable dtEmail = MSSQLDataConnection.SelectDataFromDB("SELECT COUNT(*) FROM tblUyeler WHERE Email='" + txtEmail.Value + "'");
                int CountEmail = Convert.ToInt32(dtEmail.Rows[0][0].ToString());
                if (CountEmail != 0)
                {
                    do
                    {
                        Aktivasyon = RandomCreate();
                        DataTable dt = MSSQLDataConnection.SelectDataFromDB("SELECT COUNT(*) FROM tblSifreDegisimi WHERE Aktivasyon='" + Aktivasyon + "'");
                        Count = Convert.ToInt32(dt.Rows[0][0].ToString());
                    }
                    while (Count != 0);
                    string Sil = "DELETE FROM tblSifreDegisimi WHERE Email='" + txtEmail.Value + "'";
                    MSSQLDataConnection.DeleteDataFromDB(Sil);
                    string Kaydet = "INSERT INTO tblSifreDegisimi (Email,Aktivasyon) VALUES ('" + txtEmail.Value + "','" + Aktivasyon + "')";
                    MSSQLDataConnection.InsertDataToDB(Kaydet);
                    string Konu = "Şifre Değiştirme";
                    string MailIcerik = "Şifrenizi değiştirmek için " + "<a href=\"" + "http://localhost:9999/SifreDegistirme.aspx" + "\">" + " tıklayınız" + "</a>" + "<br><br>Aktivasyon kodunuz = " + Aktivasyon;
                    Common.Common.MailGonder("75dmoyillik@gmail.com", txtEmail.Value, Konu, MailIcerik);
                    //Bildirim: Mail adresinize mailiniz gönderildi
                }
                else
                {
                    //Hata: "Email adresi bulunamadı.";
                }
            }
            else
            {
                //Hata: Email boş girildi;
            }
        }

    }
}