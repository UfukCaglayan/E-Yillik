<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="adm_sikayet.aspx.cs" Inherits="Almanac.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="icerik" runat="server">
<div id="tab-6" class="tab">
            <article>
							<div class="text-section">
								<h1>Şikayetler</h1>
								<p>Sizinle iletişime geçen kişilere buradan yardım edin.</br>
                                İşlem yaptığınız şikayeti onaylayın.</p>
							</div>
							
                            <asp:Repeater ID="rptSikayetler" runat="server" 
           OnItemCommand="rptSikayetler_ItemCommand"
           OnItemDataBound="rptSikayetler_ItemDataBound">
            <HeaderTemplate>
            <center>
            <table id="rounded-corner" summary="">
            <thead>
            <tr>
                <th scope="col" class="rounded-company">Gönderen Kişi</th>
                <th scope="col" class="rounded">Konu Başlığı</th>
                 <th scope="col" class="rounded">Şikayet Sebebi</th>
                  <th scope="col" class="rounded">İçerik</th>
                  <th scope="col" class="rounded">Resim</th>
                <th scope="col" class="rounded">Onay</th>
                </tr>
            </thead>
            <tbody>
            </HeaderTemplate>
            <ItemTemplate>
            <tr>
                <td class="<%# Eval("Onay")%>"><%# Eval("AdSoyad")%></td>
                <td class="<%# Eval("Onay")%>"><%# Eval("KonuBasligi")%></td>
                <td class="<%# Eval("Onay")%>"><%# Eval("SikayetSebebi")%></td>
                <td class="<%# Eval("Onay")%>"><a id="hrfSikayet" class="group1" href="sikayeticerik.aspx?ID=<%# Eval("ID")%>" class="group1"><asp:ImageButton id="imgIcerik" runat="server" src="images/icerik.png" width="24" height="24" alt="" title="Şikayet İçeriği" border="0" /></a></td>
                <td class="<%# Eval("Onay")%>"><a id="hrfResim" runat="server" href="#" class="group1"><img src="images/sikayet.png" width="24" height="24" alt="" title="" border="0" /></a>
                <td class="<%# Eval("Onay")%>"><asp:ImageButton id="imgOnay" runat="server" CommandArgument='<%# Eval("ID")%>' src="images/accepted.png" width="24" height="24" alt="" title="Şikayeti Onayla" border="0" /></td>
            </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
           <tr>
                <td class="<%# Eval("Onay")%>"><%# Eval("AdSoyad")%></td>
                <td class="<%# Eval("Onay")%>"><%# Eval("KonuBasligi")%></td>
                <td class="<%# Eval("Onay")%>"><%# Eval("SikayetSebebi")%></td>
                <td class="<%# Eval("Onay")%>"><a id="hrfSikayet" class="group1" href="sikayeticerik.aspx?ID=<%# Eval("ID")%>" class="group1"><asp:ImageButton id="imgIcerik" runat="server" src="images/icerik.png" width="24" height="24" alt="" title="Şikayet İçeriği" border="0" /></a></td>
                <td class="<%# Eval("Onay")%>"><a id="hrfResim" runat="server" href="#" class="group1"><img src="images/sikayet.png" width="24" height="24" alt="" title="" border="0" /></a>
                <td class="<%# Eval("Onay")%>"><asp:ImageButton id="imgOnay" runat="server" CommandArgument='<%# Eval("ID")%>' src="images/accepted.png" width="24" height="24" alt="" title="Şikayeti Onayla" border="0" /></td>
            </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
            </tbody>
            </table>
            </center>
            </FooterTemplate>
            </asp:Repeater> 
							</ul>
						</article>
        </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="aktiflik" runat="server">
<ul class="tabset buttons" style="margin-top:70px;">
				<li>
					<a href="adm_uyeonaylama.aspx" class="ico1"><span>Kontrol Paneli</span><em></em></a>
					<span class="tooltip"><span>Kontrol Paneli</span></span>
				</li>
				<li >
					<a href="adm_galeri.aspx" class="ico2"><span>Galeriler</span><em></em></a>
					<span class="tooltip"><span>Galeriler</span></span>
				</li>
				<li>
					<a href="adm_yazikontrol.aspx" class="ico3"><span>Yazı Kontrol</span><em></em></a>
					<span class="tooltip"><span>Yazı Kontrol</span></span>
				</li>
				<li>
					<a href="adm_siniflar.aspx" class="ico4"><span>Sınıflar</span><em></em></a>
					<span class="tooltip"><span>Sınıflar</span></span>
				</li>
				<li>
					<a href="adm_engelle.aspx" id="tabEngelle" runat="server" class="ico5"><span>Öğrenci Engelleme</span><em></em></a>
					<span class="tooltip"><span>Öğrenci Engelleme</span></span>
				</li>
				<li class="active">
					<a href="adm_sikayet.aspx" class="ico6">
						<span>Şikayetler</span><em></em>
					</a>
					<span id="spSikayet" runat="server" class="num">105</span>
					<span class="tooltip"><span>Şikayetler</span></span>
			</ul>
</asp:Content>
