<%@ Page Title="" Language="C#" MasterPageFile="~/Profil.Master" AutoEventWireup="true" CodeBehind="Ayarlar.aspx.cs" Inherits="Almanac.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="IsimSoyisim" runat="server">
<asp:Label ID="lbAdSoyad" runat="server" Text="Ad Soyad"></asp:Label>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Profilresmi" runat="server">
<asp:Image ID="imgPR" runat="server" ImageUrl="~/images/yeni.png" style="width:200px;height:230px;" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="kutular" runat="server">
<div style="height:60px;width:300px;margin-top:15px;margin-left:4px;">
    <div class="box msg effect kutular" style="margin-right: 13px;cursor:pointer;" onclick="location.href='bildirimler.aspx'">
<img style="margin-top: 13px;" src="images/lightbulb32.png" /><span style="font-size: 12pt;
            position: absolute; color: #484848; margin-top: 2px;" id="spBldrm" runat="server">
            0</span>
        <div class="clr">
        </div>
    </div>
    <div class="box noti effect kutular" style="margin-right: 13px;cursor:pointer;" onclick="location.href='ozelmesajlar.aspx'">
        <img style="margin-top: 13px;" src="images/commentblack32.png" /><span style="font-size: 12pt;
            position: absolute; color: #484848; margin-top: 2px;" id="spMsg" runat="server">
            0</span>
        <div class="clr">
        </div>
    </div>
    <div class="littlebar" style="cursor:pointer;" onclick="location.href='Ayarlar.aspx'">
        <div class="box settings effect kutular" onclick="location.href='Ayarlar.aspx'">
            <img style="margin-top: 12px;" src="images/gear32.png" /></div>
    </div>
    </div>
</asp:Content>


<asp:Content ID="Content5" ContentPlaceHolderID="yaziyaz" runat="server">
<div class="ayarlarustgenel">
<div class="ayarlarustsolbolum">
<div class="ayarlarprofilresmi">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

    <ContentTemplate>
        <asp:ImageButton ID="imgPRF" CssClass="ayarlarprofilresim" runat="server" 
            onclick="imgPRF_Click"/>
        
    </ContentTemplate>

    </asp:UpdatePanel>
  
    <asp:FileUpload ID="fuProfilResmi" CssClass="ayarlarfileupload" runat="server" />
</div>
<img class="kenaryatay" src="images/kenaryatay.png"/>
<span class="fotodegismemetin"><center>Fotoğrafınızı değiştirmek için tıklayınız.</center></span>

</div>

<div class="ayarlarustsagbolum">
<div class="kisiselbilgiler"><center>Kişisel Bilgiler</center> </div>
<div class="sagkucukdiv"><div class="adsoyadyazi">Ad: </div> 
    <div style="width:300px;"><asp:TextBox ID="txtAd" CssClass="ayarlartextbox" runat="server"></asp:TextBox></div>
</div>
<div class="sagkucukdiv"><div class="adsoyadyazi">Soyad: </div> 
    <div style="width:300px;"><asp:TextBox ID="txtSoyad" CssClass="ayarlartextbox" runat="server"></asp:TextBox></div>
</div>
<div class="sagkucukdiv"">
<div>
    <div class="dogumcinsiyetmezuniyetkonumyazi">Doğum Tarihi: </div> 
    <div class="dogumcinsiyetmezuniyetkonumyazi" style="margin-left:63px;">Cinsiyet: </div> 
</div>
<div>
    <div class="dogumtarihidropdiv">
        <asp:DropDownList ID="ddlGun" runat="server" ><asp:ListItem>Gün</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlAy" runat="server"><asp:ListItem>Ay</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlYil" runat="server"><asp:ListItem>Yıl</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="cinsiyetdropdiv">
        <asp:DropDownList ID="ddlCinsiyet" runat="server"><asp:ListItem>Cinsiyet</asp:ListItem><asp:ListItem>Bay</asp:ListItem><asp:ListItem>Bayan</asp:ListItem>
        </asp:DropDownList>
    </div>
    </div>
    </div>
    <div style="width:320px;margin-left:25px;margin-top:10px;">
    
    <div class="dogumcinsiyetmezuniyetkonumyazi" style="margin-top:10px;">Mezuniyet Yılı: </div> <div class="dogumcinsiyetmezuniyetkonumyazi" style="margin-top:10px;margin-left:13px;">Konum: </div>
    
        <div style="float:left;"><asp:DropDownList ID="ddlMezuniyet" runat="server"><asp:ListItem>Mezuniyet Yılı</asp:ListItem>
        </asp:DropDownList></div>
        <div style="float:left;margin-left:48px;"><asp:DropDownList ID="ddlKonum" runat="server" CssClass="konumdrop"><asp:ListItem>Konum</asp:ListItem><asp:ListItem>İstanbul</asp:ListItem>
        </asp:DropDownList></div>
     </div>
</div>

</div>

<div class="ayarlarortadiv">
    <div class="girisbilgileri"><center>Giriş Bilgileri</center> </div>
    <div class="ortakucukdiv"><div class="ortadivyazi">Tc Kimlik Numarası: </div> 
    <div style="width:300px;"><asp:TextBox CssClass="ayarlartextbox" ID="txtTcKimlikNo" 
            runat="server" Enabled="False"></asp:TextBox></div></div>
     <div  class="ortakucukdiv"><div class="ortadivyazi">Eski Şifre: </div> 
    <div style="width:300px;"><asp:TextBox CssClass="ayarlartextbox" ID="txtEskiSifre" runat="server"></asp:TextBox></div></div>
     <div  class="ortakucukdiv"><div class="ortadivyazi">Yeni Şifre: </div> 
    <div style="width:300px;"><asp:TextBox CssClass="ayarlartextbox" ID="txtYeniSifre" runat="server"></asp:TextBox></div></div>
     <div  class="ortakucukdiv"><div class="ortadivyazi">Şifre Tekrar: </div> 
    <div style="width:300px;"><asp:TextBox CssClass="ayarlartextbox" ID="txtSifreTekrar" runat="server"></asp:TextBox></div></div>
    <div  class="ortakucukdiv"><div class="ortadivyazi">E-mail Adresi: </div> 
    <div style="width:300px;"><asp:TextBox CssClass="ayarlartextbox" ID="txtEmail" runat="server"></asp:TextBox></div></div>
</div>

<div class="ayarlaraltdiv">
     <div class="digerbilgiler"><center>Diğer Bilgiler</center> </div>
    
    <div class="altbolumdiv">

    <img class="altbolumlogo" src="images/facelogo.png" />
    <div style="float:left;"> 
    <div style="font-size:20px;color:#274268;">facebook.com / <asp:TextBox CssClass="ayarlartextbox" Width="150" ID="txtFacebook" runat="server"></asp:TextBox></div></div>
    </div>

    <div class="altbolumdiv">

    <img class="altbolumlogo" src="images/twitlogo.png" />
    <div style="font-size:20px;color:#274268;">twitter.com / <asp:TextBox CssClass="ayarlartextbox" Width="169" ID="txtTwitter" runat="server"></asp:TextBox></div>
    </div>
    <asp:Button ID="btnTamam" runat="server" Text="Tamam" onclick="btnTamam_Click" />
    </div>

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="panel" runat="server">



</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="galeri" runat="server">
   +
</asp:Content>
