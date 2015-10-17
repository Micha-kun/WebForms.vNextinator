<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SuperControlTest.Default" %>

<%@ Register Src="~/Controls/SuperControl.ascx" TagPrefix="uc1" TagName="SuperControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" ng-app="app">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Hello World!</h1>
        </div>
        <uc1:SuperControl runat="server" ID="SuperControl" />
        <uc1:SuperControl runat="server" ID="SuperControl2" />

        <asp:ScriptManager runat="server" AjaxFrameworkMode="Disabled">
            <Scripts>
                <asp:ScriptReference Path="~/Scripts/jquery-1.11.3.min.js" />
                <asp:ScriptReference Path="~/Scripts/angular.min.js" />
            </Scripts>
        </asp:ScriptManager>
    </form>
</body>
</html>
