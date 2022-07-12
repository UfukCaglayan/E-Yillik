<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sfrunut.aspx.cs" Inherits="Almanac.sfrunut" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #conten
        {
            position: relative;
            z-index: 1;
            height: 84%;
            min-height: 504px;
            min-width: 883px;
            width: 100%;
        }
        
    </style>
</head>
<body>
    <body style="background-image: url('images/b7sd.jpg');">
    <form id="form1" runat="server">
    <div id="conten" style="width: 5px;">
        <img src="images/sif.png" width="100px" height="100px" style="float: left; margin-top: 5px;
            margin-left: 5px;" />
        <input style="float: left; width: 270px; height: 30px; margin-top: 10px; margin-left: 8px;
            color: #afaeae; border-radius: 5px; font-size: 20px; background-color: #ddd;"
            runat="server" id="txtEmail" maxlength="30" value=" E-mail Adresinizi Giriniz"
            onfocus="if(this.beenchanged!=true){ this.value = ''}" onblur="if(this.beenchanged!=true) { this.value =' E-mail Adresinizi Giriniz' }"
            onchange="this.beenchanged = true;" />
        <asp:Button ID="btnGonder" runat="server" Text="Gönder" 
            Style="color: White; height: 40px;
            border-radius: 5px; font-size: 20px; color: #484848; margin-top: 50px; margin-left: -87px;" 
            onclick="btnGonder_Click" />
        <br />
        <br />
        <span style="color: White; font-family: Segoe UI; font-size: 10pt;">&nbsp;&nbsp; *E-mail
            adresinize bir aktivasyon mail'i gelecektir.<br />
            &nbsp;&nbsp; *Bağlantıyı izleyerek şifrenizi değiştirebilirsiniz.
            <br />
            &nbsp;&nbsp; *Eğer E-mail gelmediyse buraya tıklayın.<br />
            &nbsp;&nbsp; *E-mail servisinizin spam klasörüne bakmayı unutmayın. </span>
    </div>
    </form>
</body>
</body>
</html>
