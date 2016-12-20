<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PETest.aspx.cs" Inherits="MyFileItPEService.PETest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label runat="server" ID="lblError"></asp:Label>
        <div>
    <h1>User</h1>
            <asp:Button runat="server" ID="btnAddUser" Text="Add User" OnClick="btnAddUser_Click" />

    </div>
    </form>
</body>
</html>
