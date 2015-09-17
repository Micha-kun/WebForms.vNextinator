<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuperControl.ascx.cs" Inherits="SuperControlTest.Controls.SuperControl" %>
<div ng-controller="SuperControl">
    <div>
        <input type="text" runat="server" ng-model="text" placeholder="Escribe cualquier cosilla" />
    </div>
    
    <div>
        <input type="button" runat="server" ng-click="sendToServer()" value="Click Me!" />
    </div>
    <p runat="server" ng-bind="serverResult"></p>
</div>