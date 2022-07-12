<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sikayeticerik.aspx.cs" Inherits="Almanac.sikayeticerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 172px; width: 466px">
    <div style="margin-left:10px; margin-top:10px;">
        <asp:Label ID="lbBaslik" runat="server" Text="Şikayet İçeriği" Font-Size="17pt" 
            ForeColor="#666666"></asp:Label>
        <br />
        <asp:Label ID="lbIcerik" runat="server" style="max-width:450px;" Text="Label"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
