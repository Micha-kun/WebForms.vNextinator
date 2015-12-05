<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoList.aspx.cs" Inherits="SuperControlTest.Views.ToDoList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    <asp:Repeater runat="server" ID="rptToDoList" DataSource="<%# ViewModel.Items %>" OnItemCommand="rptToDoList_ItemCommand" ItemType="SuperControlTest.ViewModels.ToDoListItem" OnPreRender="ControlDataBind">
        <ItemTemplate>
            <div>
            <asp:TextBox runat="server" Text="<%# Item.Text %>" />
            <asp:Button runat="server" Text="Save" CommandName="Save" />
            <asp:Button runat="server" Text="Delete" CommandName="Delete" />
                </div>
        </ItemTemplate>
    </asp:Repeater>
            </div>
    </form>
</body>
</html>
