<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucUyeOnay.ascx.cs" Inherits="Almanac.ucUyeOnay" %>
<div style="width: 300px; background-color:#e4e7f2; height: 130px;">
TC Kimlik No:<asp:Label ID="lbTcNo" runat="server" Text="Label"></asp:Label></br>
E-Mail: <asp:Label ID="lbEmail" runat="server" Text="Label"></asp:Label></br>
Doğum Tarihi:<asp:Label ID="lbDogumTarihi" runat="server" Text="Label"></asp:Label></br>
Cinsiyet:<asp:Label ID="lbCinsiyet" runat="server" Text="Label"></asp:Label> </br>
Mezuniyet yılı:<asp:Label ID="lbMezuniyet" runat="server" Text="Label"></asp:Label></br>
Sınıf: <asp:Label ID="lbSinif" runat="server" Text="Label"></asp:Label></br>
Konum:<asp:Label ID="lbKonum" runat="server" Text="Label"></asp:Label>
    <br />
    </br>
            <div style="float:right; margin-right:5px; margin-top:-15px;">
        <a href="#" runat="server" id="onayHref">
            <img alt="Üyeliği Onayla" src="~/images/accepted.png" width="24" height="24" 
             border="0" runat="server" id="imgOnay" /></a>
        <a href="#" runat="server" id="iptalHref">
            <img alt="Üyeliği İptal Et" src="~/images/cancel.png" width="24" height="24" 
             border="0" runat="server" id="imgIptal" /></a></div>
</div>
 

