<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoList.aspx.cs" Inherits="SuperControlTest.Views.ToDoList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>This is a test about various things:</p>
            <ul>
                <li>CRUD for MVPVM</li>
                <li>ViewModel persisted on ViewState. This way, every postback doesn't require ask again for data</li>
            </ul>
            <div>
                <asp:TextBox runat="server" ID="tbxAdd" Text="" />
                <asp:Button runat="server" Text="Add" OnClick="Unnamed_Click" />
            </div>
    <asp:Repeater runat="server" ID="rptToDoList" DataSource="<%# ViewModel.Items %>" OnItemCommand="rptToDoList_ItemCommand" ItemType="SuperControlTest.ViewModels.ToDoListItem" OnPreRender="ControlDataBind">
        <ItemTemplate>
            <div>
            <asp:TextBox runat="server" ID="tbxEdit" Text="<%# Item.Text %>" />
            <asp:Button runat="server" Text="Save" CommandName="Save" />
            <asp:Button runat="server" Text="Delete" CommandName="Delete" />
                </div>
        </ItemTemplate>
    </asp:Repeater>
            </div>
    </form>
</body>
</html>
