<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true"
    CodeBehind="uyeonayla.aspx.cs" Inherits="Almanac.WebForm9" %>

<asp:Content ID="Content3" ContentPlaceHolderID="icerik" runat="server">
    <div class="tabs">
        <div id="tab-1" class="tab">
            <article>
							<div class="text-section">
								<h1>Kontrol Paneli</h1>
								<p>İstatiskleri ve göstergeleri buradan takip edebilirsiniz.</p>
							</div>
							<ul class="states">
								<%--buraya bir şeyler buluruz--%>
							</ul>
						</article>
        </div>
        <div id="tab-2" class="tab">
            <article>
							<div class="text-section">
								<h1>Galeriler</h1>
								<p>Devam etmek için öğrenci seçin.</p>
							</div>
							<ul class="states">
								<%--buraya öğrenciler gelicek--%>
							</ul>
						</article>
        </div>
        <div id="tab-3" class="tab">
            <article>
							<div class="text-section">
								<h1>Yazı Kontrol</h1>
								<p>Devam etmek için öğrenci seçin.</p>
							</div>
							<ul class="states">
								<%--buraya öğrenciler gelicek--%>
							</ul>
						</article>
        </div>
        <div id="tab-4" class="tab">
            <article>
							<div class="text-section">
								<h1>Sınıf Düzenleme</h1>
								<p>Eklemek istediğiniz veya düzenlemek istiğiniz sınıfı listeden seçin.</p>
							</div>
							<ul class="states">
								<%--sınıflar buraya getirilcek,sınıf eklencek ve düzenlencek--%>
							</ul>
						</article>
        </div>
        <div id="tab-5" class="tab">
            <article>
							<div class="text-section">
								<h1>Öğrenci Engelleme</h1>
								<p>Engellemek istiğiniz öğrenciyi gerekçesi ve engelleme süresiyle birlikte kaydedin.</p>
							</div>
							<ul class="states">
								<%--öğrenci seçme ekranı gelicek--%>
							</ul>
						</article>
        </div>
        <div id="tab-6" class="tab">
            <article>
							<div class="text-section">
								<h1>Şikayetler</h1>
								<p>Sizinle iletişime geçen kişilere buradan yardım edin.</p>
							</div>
							<ul class="states">
								<%--admine gelen şikayetler listelenecek--%>
							</ul>
						</article>
        </div>
        <div id="tab-7" class="tab">
            <article>
							<div class="text-section">
								<h1>Sayfa Düzenlemeleri</h1>
								<p>Sayfalardaki yazıları,linkleri,resimleri buradan düzenleyebilirsiniz.</p>
							</div>
							<ul class="states">
								<%--Sayfaların linkleri olacak tıklayınca sayfadaki düzenlenebilir etiketler sıralancak.--%>
							</ul>
						</article>
        </div>
        <div id="tab-8" class="tab">
            <article>
							<div class="text-section">
								<h1>Ayarlar</h1>
								<p>Düzenlemek istediğiniz alanlara tıklayın.</p>
							</div>
							<ul class="states">
								<li class="error">Hata : Yaptığınız değişikleri sizin hatanız yüzünden kaydedemedim :(</li>
								<li class="warning">Uyarı : Bu ayarı değiştrmeniz dünyanın yok olmasına sebep olabilir.</li>
								<li class="succes">Başarılı : Her şey iyi gitti ve ayarlarınız sisteme eklendi.</li>
							</ul>
						</article>
        </div>
    </div>
</asp:Content>
