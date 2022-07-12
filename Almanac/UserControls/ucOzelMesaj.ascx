<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucOzelMesaj.ascx.cs" Inherits="Almanac.ucOzelMesaj" %>
<div id="divSag" runat="server" style="width:340px;margin-top:10px;float:right;">
   <div id="divSagZaman" runat="server"  runat="server" style="width:320px;height:20px;">
      <img src="images/sagkenar.png" style="float:right;"/> <asp:Label ID="lbSagSaat" CssClass="labelsagtarih" runat="server" Text="00.00"></asp:Label><asp:Label ID="lbSagTarih" CssClass="labelsagtarih" runat="server" Text="00/00/0000"></asp:Label>
      </div>
      <div style="margin-left:15px;float:right;margin-right:25px;">
          <asp:Label ID="lbSagMesaj" runat="server" Text="Label"></asp:Label>
      </div>

   </div>

   <div id="divSol" runat="server" style="width:340px;margin-top:10px;margin-left:10px;float:left;">
   <div id="divSolZaman" runat="server" style="width:300px;height:20px;">
      <img src="images/solkenar.png" style="float:left;"/> <asp:Label ID="lbSolSaat" CssClass="labelsoltarih" runat="server" Text="00.00"></asp:Label><asp:Label ID="lbSolTarih" CssClass="labelsoltarih" runat="server" Text="00/00/0000"></asp:Label>
      </div>
      <div style="margin-left:15px;">
          <asp:Label ID="lbSolMesaj" runat="server" Text="Label"></asp:Label>
      </div>
      </div>
<style>
.labelsoltarih
{
    float:left;margin-left:5px;
}
.labelsagtarih
{
    float:right;margin-right:5px;
}       
</style>
