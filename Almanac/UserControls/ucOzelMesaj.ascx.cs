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
    public partial class ucOzelMesaj : System.Web.UI.UserControl
    {
        private void FormuDoldur()
        {
            string TcKimlikNo = Session["TcKimlikNo"].ToString();
            string gonderen = Common.FormlarArasi.Gonderen;
            string query = "SELECT (U.Ad + ' ' + U.Soyad) AS AdSoyad,OM.Tarih,OM.Mesaj,OM.Gonderen FROM tblOzelMesaj OM " +
                           "INNER JOIN tblUyeler U ON OM.Gonderen = U.TcKimlikNo " +
                            "WHERE OM.Alici='" + TcKimlikNo + "' AND Gonderen ='" + gonderen + "' OR Alici ='" + gonderen + "' AND Gonderen ='" + TcKimlikNo + "' ORDER BY OM.Tarih ASC";
            DataTable dtOM = MSSQLDataConnection.SelectDataFromDB(query);
            int x = Common.FormlarArasi.gonderenSira;
            DateTime zaman = Convert.ToDateTime(dtOM.Rows[x][1].ToString());
            string trh = zaman.ToString("dd/MM/yyyy");
            DateTime tarih = Convert.ToDateTime(trh);
            lbSagTarih.Visible = false;
            lbSolTarih.Visible = false;
            divSol.Visible = true;
            divSolZaman.Visible = true;
            divSag.Visible = true;
            divSagZaman.Visible = true;
            divSol.Style["position"] = "none";
            divSag.Style["position"] = "none";
            divSol.Style["top"] = "0px";
            divSag.Style["top"] = "0px";
            divSolZaman.Style["position"] = "none";
            divSagZaman.Style["position"] = "none";
            divSolZaman.Style["top"] = "0px";
            divSagZaman.Style["top"] = "0px";

            if (dtOM.Rows[x][3].ToString() == TcKimlikNo)
            {
                if (tarih == Common.FormlarArasi.aliciSonTarih)
                    lbSolTarih.Visible = false;
                else
                {
                    lbSolTarih.Visible = true;
                    lbSolTarih.Text = zaman.ToString("dd/MM/yyyy");
                }

                if (Common.FormlarArasi.aliciSonSaat == zaman.ToString("HH:mm") && tarih == Common.FormlarArasi.aliciSonTarih)
                {
                    divSolZaman.Style["position"] = "absolute";
                    divSolZaman.Style["z-index"] = "1";
                    divSolZaman.Style["top"] = "1px";
                    divSolZaman.Visible = false;
                }
                else
                    lbSolSaat.Text = zaman.ToString("HH:mm");
               
               
                lbSolMesaj.Text = dtOM.Rows[x][2].ToString();
                divSag.Style["position"] = "absolute";
                divSag.Style["z-index"] = "1";
                divSag.Style["top"] = "1px";
                divSag.Visible = false;
                Common.FormlarArasi.aliciSonSaat = zaman.ToString("HH:mm");
                Common.FormlarArasi.aliciSonTarih = tarih;
            }
            else
            {
                if (tarih == Common.FormlarArasi.gonderenSonTarih)
                    lbSagTarih.Visible = false;
                else
                {
                    lbSagTarih.Visible = true;
                    lbSagTarih.Text = zaman.ToString("dd/MM/yyyy");
                }
                if (Common.FormlarArasi.gonderenSonSaat == zaman.ToString("HH:mm") && tarih == Common.FormlarArasi.gonderenSonTarih)
                {
                    divSagZaman.Style["position"] = "absolute";
                    divSagZaman.Style["z-index"] = "1";
                    divSagZaman.Style["top"] = "1px";
                    divSagZaman.Visible = false;
                }
                else
                    lbSagSaat.Text = zaman.ToString("HH:mm");
                
                lbSagMesaj.Text = dtOM.Rows[x][2].ToString();
                divSol.Style["position"] = "absolute";
                divSol.Style["z-index"] = "1";
                divSol.Style["top"] = "1px";
                divSol.Visible = false;
                Common.FormlarArasi.gonderenSonSaat = zaman.ToString("HH:mm");
                Common.FormlarArasi.gonderenSonTarih = tarih;
            }
            Common.FormlarArasi.SonGonderen = dtOM.Rows[x][3].ToString();
            Common.FormlarArasi.gonderenSira = x + 1;
        
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            FormuDoldur();
        }
    }
}