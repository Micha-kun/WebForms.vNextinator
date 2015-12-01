<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample3.aspx.cs" Inherits="SuperControlTest.Views.Sample3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%= ViewModel.Title %></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        ViewModel binding inside aspx. The current date time is <%= ViewModel.CurrentDateTime.ToString() %><br />
        <asp:Literal runat="server" Text="<%# ViewModel.CurrentDateTime.ToString() %>" OnPreRender="ControlDataBind"/><br />
        <asp:Literal runat="server" Text="<%# ViewModel.LabelToShow %>" OnPreRender="ControlDataBind"/><br />
       Set a new title (leave blank for default or type "#" to see cascade dependecy betwen values): <asp:TextBox EnableViewState="false" ID="txbNewTitle" runat="server" Text="<%# ViewModel.Title %>" OnPreRender="ControlDataBind"/><br />
         Set a new label to show (leave blank for default): <asp:TextBox EnableViewState="false" ID="txbNewLabelToShow" runat="server" Text="<%# ViewModel.LabelToShow %>" OnPreRender="ControlDataBind"/><br />
        <asp:Button ID="btnSetNewValues" runat="server" Text="Set New Values" UseSubmitBehavior="true" />
    </div>
    </form>
</body>
</html>