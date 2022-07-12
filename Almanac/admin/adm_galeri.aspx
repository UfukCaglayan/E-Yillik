<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="adm_galeri.aspx.cs" Inherits="Almanac.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="icerik" runat="server">
  <div id="tab-2" class="tab">
            <article>
							<div class="text-section">
								<h1>Galeriler</h1>
								<p>Devam etmek için öğrenci seçin.</p>
                                <p>Silmek istediğiniz resimin üstüne tıklayın.</p>
							</div>
							<ul class="states">
                             <asp:Panel ID="pnlSiniflar" runat="server" Width="1300" style="clear:both;"></asp:Panel>

								 <asp:Panel ID="pnlOgrenciler" runat="server" style="float:left; clear:both;  margin-left:50px; margin-top:50px;"></asp:Panel>
                                  <asp:Panel ID="pnlGaleri" style="width:595px; border: 1px solid #C5DADD; float:left; height:487px; margin-left:5px; margin-top:50px;" runat="server">
                                  <asp:ImageButton ImageUrl="~/images/grsarka.png" CssClass="galeriresim" ID="imgGlr1" runat="server" onclick="imgGlr1_Click" />
        <asp:ImageButton ImageUrl="~/images/grsarka.png" CssClass="galeriresim" ID="imgGlr2" runat="server" onclick="imgGlr1_Click" />
        <asp:ImageButton ImageUrl="~/images/grsarka.png" CssClass="galeriresimsag" ID="imgGlr3" runat="server" onclick="imgGlr1_Click" />
        <asp:ImageButton ImageUrl="~/images/grsarka.png" CssClass="galeriresim" ID="imgGlr4" runat="server" onclick="imgGlr1_Click"/>
        <asp:ImageButton ImageUrl="~/images/grsarka.png" CssClass="galeriresim" ID="imgGlr5" runat="server" onclick="imgGlr1_Click"/>
        <asp:ImageButton ImageUrl="~/images/grsarka.png" CssClass="galeriresimsag" ID="imgGlr6" runat="server" onclick="imgGlr1_Click"/>
        <asp:ImageButton ImageUrl="~/images/grsarka.png" CssClass="galeriresim" ID="imgGlr7" runat="server" onclick="imgGlr1_Click" />
        <asp:ImageButton ImageUrl="~/images/grsarka.png" CssClass="galeriresim" ID="imgGlr8" runat="server" onclick="imgGlr1_Click"/>
        <asp:ImageButton ImageUrl="~/images/grsarka.png" CssClass="galeriresimsag" ID="imgGlr9" runat="server" onclick="imgGlr1_Click"/>

                                  </asp:Panel>
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
				<li class="active">
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
				</li>
			</ul>
</asp:Content>