﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OzelMesaj.aspx.cs" Inherits="Almanac.OzelMesaj" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 177px">
        &nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbAdSoyad" runat="server" Text="Label"></asp:Label>
        </br>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtMesaj" runat="server" Height="77px" Width="221px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </br>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnGonder" runat="server" Text="Gönder" 
            onclick="btnGonder_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <a id="hrfOzelMesaj" runat="server">Tüm Mesajları Gör</a>
        </br>
    </div>
    </form>
</body>
</html>
