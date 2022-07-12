<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="adm_engelle.aspx.cs" Inherits="Almanac.WebForm14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="icerik" runat="server">
<div id="tab-5" class="tab">
            
            <article>
							<div class="text-section">
								<h1>Öğrenci Engelleme</h1>
								<p>Engellemek istiğiniz öğrenciyi engelleme süresiyle birlikte kaydedin.</p>
							</div>
							<ul class="states">
                            <asp:Panel ID="pnlSiniflar" runat="server" Width="1300" style="clear:both;"></asp:Panel>

                            <asp:Panel ID="pnlEngelliUyeler" style="margin-left:20px; clear:both;" runat="server">
                          
								<div style="border:1px solid #C5DADD; width:290px; height:110px; margin-left:10px; margin-top:20px; float:left;">
                                <img src="images/yeni.png" width="70" height="80" style="margin-top:5px; margin-left:5px;float:left; border:1px solid #C5DADD;"/>
                                <div style="float:left;color:#8A8A8A; margin-left:5px; margin-top:3px; font-family:Calibri; font-size:15px;">
                                <div>TC:</div>
                                <div>ADI:</div>
                                <div>SOYADI:</div>
                                <div>MEZUN TARİHİ:</div>
                                </div>
                                <div style="float:left; margin-top:20px; margin-left:10px;"><input type="text" value="Sınırsız"/><input type="button" value="Engelle"/> </div>
                                </div>
                                <div style="border:1px solid #C5DADD; width:290px; height:110px; margin-left:10px; margin-top:20px; float:left;">
                                <img src="images/yeni.png" width="70" height="80" style="margin-top:5px; margin-left:5px;float:left; border:1px solid #C5DADD;"/>
                                <div style="float:left;color:#8A8A8A; margin-left:5px; margin-top:3px; font-family:Calibri; font-size:15px;">
                                <div>TC:</div>
                                <div>ADI:</div>
                                <div>SOYADI:</div>
                                <div>MEZUN TARİHİ:</div>
                                </div>
                                <div style="float:left; margin-top:20px; margin-left:10px;"><input type="text" value="Sınırsız"/><input type="button" value="Engelle"/> </div>
                                </div>
                                <div style="border:1px solid #C5DADD; width:290px; height:110px; margin-left:10px; margin-top:20px; float:left;">
                                <img src="images/yeni.png" width="70" height="80" style="margin-top:5px; margin-left:5px;float:left; border:1px solid #C5DADD;"/>
                                <div style="float:left;color:#8A8A8A; margin-left:5px; margin-top:3px; font-family:Calibri; font-size:15px;">
                                <div>TC:</div>
                                <div>ADI:</div>
                                <div>SOYADI:</div>
                                <div>MEZUN TARİHİ:</div>
                                </div>
                                <div style="float:left; margin-top:20px; margin-left:10px;"><input type="text" value="Sınırsız"/><input type="button" value="Engelle"/> </div>
                                </div>
                                 <div style="border:1px solid #C5DADD; width:290px; height:110px; margin-left:10px; margin-top:20px; float:left;">
                                <img src="images/yeni.png" width="70" height="80" style="margin-top:5px; margin-left:5px;float:left; border:1px solid #C5DADD;"/>
                                <div style="float:left;color:#8A8A8A; margin-left:5px; margin-top:3px; font-family:Calibri; font-size:15px;">
                                <div>TC:</div>
                                <div>ADI:</div>
                                <div>SOYADI:</div>
                                <div>MEZUN TARİHİ:</div>
                                </div>
                                <div style="float:left; margin-top:20px; margin-left:10px;"><input type="text" value="Sınırsız"/><input type="button" value="Engelle"/> </div>
                                </div>
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
				<li class="active">
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
