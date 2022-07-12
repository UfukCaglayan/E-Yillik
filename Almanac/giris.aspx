<%@ Page Title="" Language="C#" MasterPageFile="~/giris.Master" AutoEventWireup="true"
    CodeBehind="giris.aspx.cs" Inherits="Almanac.WebForm3" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Arkaplan" runat="server">
    <div id="bg">
        <img src="images/b7.jpg" alt="">
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="orta" runat="server">
  
    <div id="ortalaAlan">
        <div class="giris" style="float: left; background: url('images/grsarka.png');">
            <div style="font-family: Calibri; color: #6d7179; margin-top: 20px; margin-left: 19px;">
                <b>HEMEN HESABINLA OTURUM AÇ</b></div>
            <hr size="1" color="#7e828a" width="285px;" style="position: absolute; margin-left: 19px;" />
            <div id="tc">
                TC Kimlik No:<asp:TextBox MaxLength="11" Style="margin-left: 8px; width: 190px; color: #6d7179;
                    height: 13px;" ID="txtTcKimlikNo" runat="server"></asp:TextBox></div>
            <div id="sifre">
                Şifre:<asp:TextBox TextMode="Password" Style="margin-left: 57px; color: #6d7179;
                    width: 190px; height: 13px;" ID="txtSifre" runat="server"></asp:TextBox></div>
            <a class="sfrunutlink" href="sfrunut.aspx" id="sfrunut" style="color:#6d7179;margin-left: 20px;
                margin-top: 13px; float: left; font-size: 8pt;">Şifremi Unuttum</a>
            <asp:Button Style="float: right; height: 25px; margin-right: 28px; margin-top: 5px;"
                ID="btnGiris" runat="server" Text="Giriş Yap" OnClick="btnGiris_Click" />
        </div>
    </div>
    <div  id="footer" style="color:White;">
        <span style="font-family:Calibri; font-size:10pt;">Copyright © 2013 D.M.O
            <span style="color:White;margin-left: 20px;"><a class="sfrunutlink" href="#">Hakkımızda</a> - <a class="sfrunutlink"
                href="hakkimizda.html">Geliştiriciler</a> - <a class="sfrunutlink" href="rehber.html">Rehber</a> - <a class="sfrunutlink"
                    href="http://75dmoeml.meb.k12.tr/" target="_blank">Okul Web Sitesi</a> - <a class="sfrunutlink" href="ortaklik.html">Ortaklık</a></span></span>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="linkler" runat="server">
    <a href="kayit.aspx" class="butonlar">KAYIT OL</a>
</asp:Content>
