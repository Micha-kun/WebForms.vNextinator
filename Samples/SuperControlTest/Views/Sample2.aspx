<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample2.aspx.cs" Inherits="SuperControlTest.Views.Sample2"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%= ViewModel.Title %></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        ViewModel binding inside aspx. The current date time is <%= ViewModel.CurrentDateTime.ToString() %><br />
        <asp:Literal runat="server" Text="<%# ViewModel.CurrentDateTime.ToString() %>" OnPreRender="ControlDataBind"/>
    </div>
    </form>
</body>
</html>
