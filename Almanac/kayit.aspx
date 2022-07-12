<%@ Page Title="" Language="C#" MasterPageFile="~/giris.Master" AutoEventWireup="true"
    CodeBehind="kayit.aspx.cs" Inherits="Almanac.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Arkaplan" runat="server">
    <div id="bg">
        kk<img src="images/b7sd.jpg" alt="">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="orta" runat="server">
    <div id="ortalaAlan2">
        <div class="giris" style="float: left; height: 205px; background-image: url('../images/kytarka.png');">
            <div style="font-family: Calibri; color: #6d7179; margin-top: 10px; margin-left: 19px;">
                <b>KİŞİSEL BİLGİLER</b></div>
            <hr size="1" color="#7e828a" width="285px;" style="position: absolute; margin-left: 19px;" />
            <div id="tc">
                Adınız:<asp:TextBox CssClass="textvb" Style="margin-left: 32px;" ID="txtAd" runat="server"></asp:TextBox></div>
            <div id="sifre" style="margin-top: 10px;">
                Soyadınız:<asp:TextBox CssClass="textvb" Style="margin-left: 12px;" ID="txtSoyad"
                    runat="server"></asp:TextBox></div>
            <div id="gunler" class="yazilar" style="margin-top: 10px;">
                D. Tarihi:
                <asp:DropDownList ID="ddlGun" runat="server" maxlength="30" CssClass="textvb" Style="width: 50px;
                    height: 20px; margin-left: 15px;">
                    <asp:ListItem>Gün</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlAy" runat="server" maxlength="30" CssClass="textvb" Style="width: 74px;
                    height: 20px; margin-left: 2px;">
                    <asp:ListItem>Ay</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlYil" runat="server" maxlength="30" CssClass="textvb" Style="width: 60px;
                    height: 20px; margin-left: 2px;">
                    <asp:ListItem>Yıl</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div id="cinsiyet" class="yazilar" style="margin-top: 10px;">
                Cinsiyet:
                <asp:DropDownList ID="ddlCinsiyet" runat="server" maxlength="30" CssClass="textvb"
                    Style="width: 85px; height: 20px; margin-left: 16px;">
                    <asp:ListItem>Seç</asp:ListItem>
                    <asp:ListItem>Bay</asp:ListItem>
                    <asp:ListItem>Bayan</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlMezuniyet" runat="server" maxlength="30" CssClass="textvb"
                    Style="width: 101px; height: 20px; margin-left: 5px;">
                    <asp:ListItem>Mezuniyet Yılı</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="yazilar" style="margin-top: 10px;">
                Sınıf:
                <asp:DropDownList ID="ddlSinif" runat="server" maxlength="30" CssClass="textvb"
                    Style="width: 85px; height: 20px; margin-left: 40px;">
                    <asp:ListItem>Seç</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlKonum" runat="server" maxlength="30" CssClass="textvb"
                    Style="width: 101px; height: 20px; margin-left: 5px;">
                    <asp:ListItem>Konum</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="giris2" style="float: left; height: 205px; background: url('../images/kytarka.png');">
            <div style="font-family: Calibri; color: #6d7179; margin-top: 10px; margin-left: 19px;">
                <b>GİRİŞ BİLGİLERİ</b></div>
            <hr size="1" color="#7e828a" width="285px;" style="position: absolute; margin-left: 19px;" />
            <div id="tckmklk" class="yazilar">
                TC Kimlik No:<asp:TextBox CssClass="textvb" Style="margin-left: 7px;" ID="txtTcKimlikNo"
                    MaxLength="11" runat="server"></asp:TextBox></div>
            <div id="kytsfr" class="yazilar" style="margin-top: 10px;">
                Şifre:<asp:TextBox CssClass="textvb" TextMode="Password" Style="margin-left: 56px;"
                    ID="txtSifre" runat="server"></asp:TextBox></div>
            <div id="kytsfrtk" class="yazilar" style="margin-top: 10px;">
                Şifre(tekrar):<asp:TextBox CssClass="textvb" TextMode="Password" Style="margin-left: 9px;"
                    ID="txtSifreTekrar" runat="server"></asp:TextBox></div>
            <div id="Div1" class="yazilar" style="margin-top: 10px; float: left;">
                E-Mail:<asp:TextBox CssClass="textvb" Style="margin-left: 46px; width: 190px;" ID="txtEmail"
                    runat="server"></asp:TextBox></div>
            <div><div class="yazilar" style="margin-top:10px; margin-left:15px; float:left;"> 
                <asp:CheckBox style="position:absolute;"  ID="cbSozlesme" runat="server" />
       <span style="margin-left:20px;"><a class="kytlink" href="#">Sözleşmeyi</a> Kabul Ediyorum</span></div>
                <asp:Button Style="height: 25px; margin-right: 29px; margin-top: 5px; float: right;"
                    ID="Button1" runat="server" Text="Kayıt Ol" OnClick="btnKayitOl_Click" />
                    </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="linkler" runat="server">
    <a href="giris.aspx" class="butonlar">GİRİŞ YAP</a>
</asp:Content>
