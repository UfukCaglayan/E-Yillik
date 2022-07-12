<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="adm_uyeonaylama.aspx.cs" Inherits="Almanac.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="icerik" runat="server">
 <div id="tab-1" class="tab">
            <article>
							<div class="text-section">
								<h1>Üye Onaylama</h1>
								<p>Üye bilgilerini kontrol ettikten sonra üyeliği onaylayabilir veya iptal edebilirsiniz.</p>
							</div>
                        <ul>
                            <asp:Panel ID="pnlAlan" runat="server" style="margin-left:35px;" Height="100px"></asp:Panel>
                          
								
							</ul>
						</article>
        </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="aktiflik" runat="server">
 <ul class="tabset buttons" style="margin-top:70px;">
				<li class="active">
					<a href="adm_uyeonaylama.aspx" class="ico1"><span>Kontrol Paneli</span><em></em></a>
					<span class="tooltip"><span>Kontrol Paneli</span></span>
				</li>
				<li>
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
				<li>
					<a href="adm_sikayet.aspx" class="ico6">
						<span>Şikayetler</span><em></em>
					</a>
					<span id="spSikayet" runat="server" class="num">105</span>
					<span class="tooltip"><span>Şikayetler</span></span>
			</ul>
</asp:Content>