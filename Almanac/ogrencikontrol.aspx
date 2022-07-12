<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ogrencikontrol.aspx.cs" Inherits="Almanac.ogrencikontrol" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
     .panelYk
 {
 margin-top:5px; 
 width:350px; 
 border: 1px solid #C5DADD;  
 height:50px;	
 }
 
 .imageYk
 {
 margin-left:5px; 
 margin-top:5px; 
 float:left; 
 height:40px;
 width:40px;	
 }
 
 .labelYk
 {
 float:left;
 font-size:20px;
 font-family:Calibri; 
 margin-left:5px; 
 margin-top:15px;	
 }
      
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <article>
     <asp:Panel ID="pnlSiniflar" runat="server"></asp:Panel>
							<div class="text-section">
								<h1>Yazı Kontrol</h1>
								<p>Devam etmek için öğrenci seçin.</p>
							</div>
							<ul class="states">
                            <div style="margin-left:auto; margin-right:auto; height:100%;">
                            <asp:Panel ID="pnlOgrenciler" runat="server" style="float:left; border: 1px solid #C5DADD;  margin-left:50px; margin-top:50px;"></asp:Panel>
                                <asp:Panel ID="pnlYazilar" style="width:495px; border: 1px solid #C5DADD; float:left; height:650px; margin-left:5px; margin-top:50px;" runat="server"></asp:Panel>
							</div>
                            </ul>
						</article>
    </div>
    </form>
</body>
</html>
