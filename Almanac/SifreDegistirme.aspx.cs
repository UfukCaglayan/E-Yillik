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
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTamam_Click(object sender, EventArgs e)
        {
            if (txtYeniSifre.Value != txtSifreTekrar.Value)
            {
                //Hata: Şifreler aynı değil
            }
            {
                string Aktivasyon = txtAktivasyon.Value;
                DataTable dt = MSSQLDataConnection.SelectDataFromDB("SELECT COUNT(*) FROM tblSifreDegisimi WHERE Aktivasyon='" + Aktivasyon + "'");
                int Count = Convert.ToInt32(dt.Rows[0][0].ToString());
                if (Count == 0)
                {
                    //Hata: Böyle bir aktivasyon kodu bulunamadı
                }
                else
                {
                    DataTable dtEmail = MSSQLDataConnection.SelectDataFromDB("SELECT Email,Aktivasyon FROM tblSifreDegisimi WHERE Aktivasyon='" + Aktivasyon + "'");
                    string Email = dtEmail.Rows[0][0].ToString();
                    string Guncelle = "UPDATE tblUyeler SET Sifre = '" + txtYeniSifre.Value + "' WHERE Email ='" + Email + "'";
                    MSSQLDataConnection.UpdateDataToDB(Guncelle);
                    string Sil = "DELETE FROM tblSifreDegisimi WHERE Aktivasyon='" + txtAktivasyon.Value + "'";
                    MSSQLDataConnection.DeleteDataFromDB(Sil);
                    //Bildirim: Şifreniz değiştirildi;
                }
            }
        }
    }
}