<%@ Page Title="" Language="C#" MasterPageFile="~/giris.Master" AutoEventWireup="true" CodeBehind="SifreDegistirme.aspx.cs" Inherits="Almanac.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Arkaplan" runat="server">
    <div id="bg">
        <img src="images/b7.jpg" alt="">
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="linkler" runat="server">
    <a style="margin-left:10px;" href="kayit.aspx" class="butonlar">KAYIT OL</a>
     <a href="giris.aspx" class="butonlar">GİRİŞ</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="orta" runat="server">
     <div id="ortalaAlan">
        <div class="giris" style="float: left; height:250px; background: url('../images/sfrarka.png');">
        <div style="font-family: Calibri; color: #6d7179; margin-top: 20px; margin-left: 19px;">
                <b>AKTİVASYON KODUYLA ŞİFRENİ DEĞİŞTİR</b></div>
            <hr size="1" color="#7e828a" width="285px;" style="position: absolute; margin-left: 19px;" />
       <div style="margin-top:3%;margin-left:5%"><span style="font-size:8pt; color:#92acb6; font-family:Segoe UI;">Yeni Şifre:</span></div>
         <input style="width:250px; height:10%; margin:1% 1% 1% 5%; color:#afaeae; border-radius:5px; font-size:20px; background-color:#ddd;" 
      runat="server"  id="txtYeniSifre" maxlength="30" value=" **********" 
        onfocus="if(this.beenchanged!=true){ this.value = ''}" 
        onblur="if(this.beenchanged!=true) { this.value =' **********' }" 
        onchange="this.beenchanged = true;"/>

       <div style="margin-top:1%;margin-left:5%"><span style="font-size:8pt; color:#92acb6; font-family:Segoe UI;">Yeni Şifre(Tekrar):</span></div>
         <input style="width:250px; height:10%; margin:1% 1% 1% 5%; color:#afaeae; border-radius:5px; font-size:20px; background-color:#ddd;" 
      runat="server"  id="txtSifreTekrar" maxlength="30" value=" **********" 
        onfocus="if(this.beenchanged!=true){ this.value = ''}" 
        onblur="if(this.beenchanged!=true) { this.value =' **********' }" 
        onchange="this.beenchanged = true;"/>

       <div style="margin-top:1%;margin-left:5%"><span style="font-size:8pt; color:#92acb6; font-family:Segoe UI;">E-Mail adresinize gelen aktivasyon kodu:</span></div>
         <input style="width:250px; height:10%; margin:1% 1% 1% 5%; color:#afaeae; border-radius:5px; font-size:20px; background-color:#ddd;" 
      runat="server"  id="txtAktivasyon" maxlength="30" value=" --------------" 
        onfocus="if(this.beenchanged!=true){ this.value = ''}" 
        onblur="if(this.beenchanged!=true) { this.value =' -------------' }" 
        onchange="this.beenchanged = true;"/>
             
             <asp:Button ID="btnDegistir" runat="server" Text="Tamam" onclick="btnTamam_Click" style="background-color:#e8e8e8; float:right; color:White; width:80px; height:30px; border-radius:5px; font-size:20px; color:#484848; margin-right:63px; margin-top:2px; right:5;" />
        </div>
         </div>
</asp:Content>
