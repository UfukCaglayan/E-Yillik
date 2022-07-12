<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="Almanac.anasay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/anasayfa.css" rel="Stylesheet" />
    <link href="Styles/jquery-ui-1.10.0.custom.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.9.0.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.10.0.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $.ajax({
                type: "POST",
                url: "Arama.aspx/TumUrunleriGetir",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                cache: false,
                success: function (msg) {

                    $('#txtAramaAlani').autocomplete({
                        minLength: 3,
                        source: msg.d,
                        select: function (event, ui) {
                            $('#txtAramaAlani').val(ui.item.value);
                            var id = ui.item.ID;
                            window.parent.location = ("profil.aspx?ID=" + id + "");
                            return false;
                        }
                    })
	.data("autocomplete")._renderItem = function (ul, item) {
	    return $("<li></li>")
	        .data("item.autocomplete", item)
	.append("<a>" + item.value + "</a>")
	.appendTo(ul);
	};
                }
            })
        });
	 
    </script>
    <script type="text/javascript">
        function clearTextBox(textBoxID) {
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="ust">
        <div class="ust">
            <center>
                <div class="logodiv">
                    <a href="anasayfa.aspx">
                        <img class="logo" src="images/logo2.png" /></a>
                    <div class="ustbosluk">
                    </div>
                    <div class="ustlink" onclick="location.href='cikis.aspx'">
                        Çıkış</div>
                        <span style="color: White; float: right; margin-right: 10px; margin-top: 10px;">|</span>
                    <div class="ustlink" style="margin-right: 10px;" onclick="location.href='sikayet.aspx'">
                        Şikayet</div>
                    <span style="color: White; float: right; margin-right: 10px; margin-top: 10px;">|</span>
                    <div class="ustlink" style="margin-right: 10px;" onclick="location.href='mypage.aspx'">
                        Profilim</div>
                    <span style="color: White; float: right; margin-right: 10px; margin-top: 10px;">|</span>
                    <div class="ustlink" style="margin-right: 10px;" onclick="location.href='anasayfa.aspx'">
                        Ana Sayfa</div>
                </div>
            </center>
        </div>
    </div>
    <div class="ust2">
        <div class="uss">
            <center>
                <div class="isimsoyisim">
                   <span id="spAdSoyad" runat="server">Ad Soyad</span>
                </div>
                <div class="textbox">
                    <div style="width: 210px; height: 22px; background-color: White; border-radius: 4px;
                        margin-top: 2px;">
                        <asp:TextBox CssClass="aramaozellik" Value="Arkadaş Ara" onfocus="if(this.beenchanged!=true){ this.value = ''}"
                            onblur="if(this.beenchanged!=true) { this.value='Arkadaş Ara' }" onchange="this.beenchanged = true;"
                            ID="txtAramaAlani" Width="200" Style="color: #8891A4; padding-left: 5px; border: none;"
                            runat="server"></asp:TextBox></div>
                </div>
            </center>
        </div>
    </div>
    <div class="genel">
        <!–- Sol Bölüm -–>
        <div class="solbolum">
            <div class="soldiv">
                <div class="baslik">
                    SINIFLAR</div>
                <div id="sinifkutu">
                    <asp:Panel ID="pnlSiniflar" runat="server">
                    </asp:Panel>
                </div>
            </div>
        </div>
        <!–- Orta Bölüm -–>
        <div class="ortabolum">
            <div class="orta">
                <div class="baslik">
                    SON YAZILAR</div>
                <asp:Panel ID="pnlSonYazilar" runat="server">
                </asp:Panel>
            </div>
        </div>
        <!–- Sağ Bölüm -–>
        <div class="sagbolum">
            <div class="sag">
                <div class="baslik">
                    ORTAKLIK</div>
                    <div><img src="images/erdal.jpg" alt="Çay Erdal Bakkal'da İçilir" width="257px" height="257px"/></div>
                <a href="ortaklik.html" style="text-decoration: none;">
                    <div class="reklam">
                        <center>
                          <span class="reklamyazi">Buraya reklam verebilirsiniz</span></center>
                    </div>
                </a>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
