using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.IO;

namespace Almanac.Common
{
    public class Common
    {
        public static void MailGonder(string from, string to, string subject, string body)
        {
            MailMessage mailObj = new MailMessage();
            MailAddress fromAd = new MailAddress(from, "Dmo Yıllık");
            mailObj.From = fromAd;

            foreach (string mail in to.Split(','))
                mailObj.To.Add(new MailAddress(mail));

            mailObj.Subject = subject;
            mailObj.Body = body;
            mailObj.Priority = MailPriority.High;
            mailObj.IsBodyHtml = true;
            SmtpClient SMTPServer = new SmtpClient();
            SMTPServer.EnableSsl = true;
            SMTPServer.Send(mailObj);
        }

        public static string dosyaKaydet(FileUpload fileGroup, string Yol, string Isim)
        {
            string filename = "";
            HttpPostedFile postedFile = fileGroup.PostedFile;
            if (postedFile != null && postedFile.ContentLength > 0)
            {
                string filePath = postedFile.FileName;
                FileInfo clientFileInfo = new FileInfo(filePath);
                string dosyaAdi = clientFileInfo.Name;
                if (Yol != "Şikayetler")
                    filename = Isim + dosyaAdi.Remove(0, dosyaAdi.Length - 4);
                else
                    filename = Isim + ".jpg";

                string servePath = HttpContext.Current.Server.MapPath(".");
                string yeniPath = servePath + "/" + Yol + "/" + filename;
                postedFile.SaveAs(yeniPath);
            }
            return filename;
        }

        public static string galeriDoldur(string Path,int resimID,int kisiID,string image)
        {
            string[] Uzantilar = new string[] { ".jpg", ".bmp", ".png", ".gif", ".tiff" };
            string Sonuc = "";
            foreach (string Uzanti in Uzantilar)
            {
                string pt = Path + "/" + resimID.ToString() + Uzanti;;
                bool ResimKontrol = File.Exists(pt);
                if (ResimKontrol == true)
                {
                    Sonuc = "Galeri/" + kisiID.ToString() + "/" + resimID.ToString() + Uzanti;
                    break;
                }
                else
                {
                    if(image == "artı")
                        Sonuc = "images/artı.png";
                    else if(image == "bos")
                        Sonuc = "images/grsarka.png";
                }
            }
            return Sonuc;
        }

        public static string ySifre;
        public static void PasswordChange(int x)
        {
            int k = 0;
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                    k = x - 3;
                else if (i == 1)
                    k = x - 7;
                else if (i == 2)
                    k = x - 9;

                ySifre += ((char)k).ToString();
            }
        }
        public static void Password(string Sifre)
        {
            ySifre = "";
            int KarakterSayisi = Sifre.Length;
            for (int i = 0; i < KarakterSayisi; i++)
            {
                int ascii;
                string a = Sifre[i].ToString();
                char karakter = Convert.ToChar(a);
                ascii = (int)(karakter);
                PasswordChange(ascii);
            }
        }

        public static bool IsTcKimlikNo(string s)
        {
            var regex = new Regex(@"^[1-9]{1}[0-9]{9}[0,2,4,6,8]{1}$");
            return regex.IsMatch(s);
        }

        public static bool IsEmail(string s)
        {
            var regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            return regex.IsMatch(s);
        }

        public static string HtmlTagEdit(string text)
        {
            return text.Replace("\r\n", "<br/>");
        }

        public static string dosyaSil(int ID,string Path)
        {
            string[] Uzantilar = new string[] { ".jpg", ".bmp", ".png", ".gif", ".tiff" };
            string silinecek = "";
            foreach (string Uzanti in Uzantilar)
            {
                silinecek = Path + "/" + ID.ToString() + Uzanti;
                bool ResimKontrol = File.Exists(silinecek);
                if (ResimKontrol == true)
                {
                File.Delete(silinecek);
                break;
                }
            }
            return silinecek;
        }

        public static string ProfilResmi(int ID, string Path,string Cinsiyet)
        {
            string[] Uzantilar = new string[] { ".jpg", ".bmp", ".png", ".gif", ".tiff" };
            string Sonuc = "";
            foreach (string Uzanti in Uzantilar)
            {
                string imgUrl = "ProfilResimleri/" + ID.ToString() + Uzanti;
                string pt = Path + imgUrl;
                bool ResimKontrol = File.Exists(pt);
                if (ResimKontrol == true)
                {
                    Sonuc = imgUrl;
                    break;
                }
                else
                {
                    if (Cinsiyet == "Bay")
                        Sonuc = "ProfilResimleri/male.png";
                    else if (Cinsiyet == "Bayan")
                        Sonuc = "ProfilResimleri/female.png";
                }
            }
            return Sonuc;
        }
    }
}