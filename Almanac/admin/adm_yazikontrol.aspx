<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="adm_yazikontrol.aspx.cs" Inherits="Almanac.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="icerik" runat="server">
    <div id="tab-3" class="tab">
            <article>
							<div class="text-section">
								<h1>Yazı Kontrol</h1>
								<p>Devam etmek için öğrenci seçin.</br>Mesajı silmek için çarpıya basınız.</p>
							</div>
							<ul class="states">
                            <div style="margin-left:auto; margin-right:auto; height:100%;">
                              <asp:Panel ID="pnlSiniflar" runat="server" Width="1300" style="clear:both;"></asp:Panel>
								 <asp:Panel ID="pnlOgrenciler" runat="server" style="float:left; clear:both;  margin-left:50px; margin-top:50px;"></asp:Panel>
                                <asp:Panel ID="pnlYazilar" style="width:500px; border: 1px solid #C5DADD; float:left; height:650px; margin-left:5px; margin-top:50px;" runat="server"></asp:Panel>
							</div>
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
				<li>
					<a href="adm_galeri.aspx" class="ico2"><span>Galeriler</span><em></em></a>
					<span class="tooltip"><span>Galeriler</span></span>
				</li>
				<li class="active">
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
				<li>
					<a href="adm_sikayet.aspx" class="ico6">
						<span>Şikayetler</span><em></em>
					</a>
					<span id="spSikayet" runat="server" class="num">105</span>
					<span class="tooltip"><span>Şikayetler</span></span>
			</ul>
</asp:Content>