<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPM.ascx.cs" Inherits="Almanac.UserControls.ucPM" %>

<div id="div" runat="server" style="margin-left: 15px; width: 595px; float: left;">
    <div style="float: left;">
        <asp:Image ID="imgPR" Style="border: 1px solid #C5DADD; border-radius: 3px; width: 120px;
            height: 140px;" runat="server"></asp:Image>
        <div style="bottom: 20px; width: 119px; border-radius: 0px 0px 3px 3px; position: relative;
            background: url('images/altsaydam.png') repeat; height: 20px; font-size: 11pt;
            padding-left: 2px; color: White; text-align: center;">
            <asp:Label ID="lbGonderen" runat="server" Text="Label"></asp:Label></div>
    </div>
    <img src="../images/kenar.PNG" style="float: left;" />
    <div id="div2" runat="server" style="float: left; border-radius: 3px; border: 1px solid #C5DADD; width: 459px;
        height: 141px;">
        <div style="height: 15px;">
            <asp:Label ID="lbTarih" runat="server" Text="23.12.2013 23.23" Style="float: right;
                font-size: 10pt; color: #8891A4; font-family: Calibri;"></asp:Label></div>
        <asp:Label ID="lbMesaj" runat="server" Text="Label" Style="font-size: 12pt; color: #8891A4;
            font-family: Calibri; margin-left:5px;"></asp:Label></div>
     <div style="float:right; margin-right:5px; margin-top:-30px;">
        <a href="#" runat="server" id="hrfOnay">
            <img alt="Yazıyı Onayla" src="~/images/accepted.png" width="24" height="24" 
             border="0" runat="server" id="imgOnay" /></a>
        <a href="#" runat="server" id="hrfIptal" style="margin-right:-1px">
            <img alt="Yazıyı İptal Et" src="~/images/cancel.png" width="24" height="24" 
             border="0" runat="server" id="imgIptal" /></a>
             </div>

</div>

