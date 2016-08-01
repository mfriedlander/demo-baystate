<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="BaystateHealth.FormsWebsite.Controls.Menu1" %>

<ul>
<asp:Repeater ID="rptTimes" runat="server" OnItemDataBound="rptTimes_ItemDataBound">
    <ItemTemplate>
        <li><asp:Literal ID="litTime" runat="server" /></li>
    </ItemTemplate>
</asp:Repeater>
</ul>