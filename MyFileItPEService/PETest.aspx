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
            <table>
                <tr>
                    <td>User:</td>
                    <td>
                        <asp:TextBox runat="server" ID="username"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Pass:</td>
                    <td>
                        <asp:TextBox runat="server" ID="password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button runat="server" ID="btnLogin" Text="Login" OnClick="btnLogin_Click" /></td>
                </tr>
            </table>
            <asp:Button runat="server" ID="btnGetAppUserDocuments" Text="Get App User Docs" OnClick="btnGetAppUserDocuments_Click" />
            <asp:Button runat="server" ID="btnAssociate" Text="Share Doc" OnClick="btnAssociate_Click" />
            
        </div>
        <div>
            <h1>Document Types</h1>
            <asp:Button runat="server" ID="btnGetAllDocTypes" Text="Get Document Types" OnClick="btnGetAllDocTypes_Click" />
             <table>
                <tr>
                    <td>User Id:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtAppUserId"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>New Document Type:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDocumentType"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button runat="server" ID="btnAddDocumentType" Text="Add Document Type" OnClick="btnAddDocumentType_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
