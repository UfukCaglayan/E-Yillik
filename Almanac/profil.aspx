<%@ Page Title="" Language="C#" MasterPageFile="~/Profil.Master" AutoEventWireup="true"
    CodeBehind="profil.aspx.cs" Inherits="Almanac.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="IsimSoyisim" runat="server">
    <asp:Label ID="lbAdSoyad" runat="server" Text="Ad Soyad"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Profilresmi" runat="server">
    <asp:Image ID="imgPR" runat="server" ImageUrl="~/images/yeni.png" Style="width: 200px;
        height: 230px;" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="kutular" runat="server">
 <a id="hrfOzelMesaj" runat="server" href="ozelmesaj.aspx" class="group4" title="Özel Mesaj">
                        Özel Mesaj Yaz..</a>
    <style>
    .txtozel
    {
        width:195px;height:30px;margin-top:15px;font-family:Calibri;
    }
    </style>

    <div style="height: 60px; width: 300px; margin-top: 15px; margin-left: 4px;">
        <div class="box msg effect kutular" onclick="" style="margin-right: 13px;
            width: 60px; height: 60px;cursor:pointer;">
            <a href="#" id="hrfFace" runat="server" target="_blank"><img id="imgFace" runat="server" style="margin:10px;" src="images/facelogosiyah.png" /></a>
            <div class="clr">
            </div>
        </div>
        <a href="#" id="hrfTwitter" runat="server" target="_blank"><div id="divv" runat="server" class="box noti effect kutular" style="margin-right: 13px;cursor:pointer;" onclick="">
             <img id="imgTwitter" runat="server" style="margin:10px;" src="images/twitlogosiyah.png" />
            <div class="clr">
            </div>
        </div></a>
        <div class="littlebar" onclick="" style="cursor:pointer;">
            <div class="box settings effect kutular" >

                    <img style="margin-top: 10px;" src="images/emaillogo.png" /></div>
        
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="yaziyaz" runat="server">
<textarea ID="txtDusunce" runat="server" class="textarea"
        onclick="javascript: temizle(this);" onkeyup="textCounter(this, this.form.remLen, 300);"></textarea>
    <div class="gonder">
        <asp:Button ID="btnGonder" CssClass="buttonGonder" runat="server" Text="Gönder" OnClick="btnGonder_Click" /><input
            style="background-color: transparent; border: none;" class="labelSayac" readonly="readonly"
            name="remLen" readonly="readonly" type="text" value="300" />
    </div>
    <script type="text/javascript">
        var i = 0;
        var k = 0;
        function temizle(txt) {
            if (i == 0) {
                txt.value = "";
                i = 2;
            }
        }
        function temizle2(txt) {
            if (k == 0) {
                txt.value = "";
                k = 2;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="panel" runat="server">
    <asp:Panel ID="pnlAlan" runat="server">
    </asp:Panel>
</asp:Content>

