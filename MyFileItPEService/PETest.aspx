<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PETest.aspx.cs" Inherits="MyFileItPEService.PETest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        div {
            margin-bottom: 2em;
        }
    </style>
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
        <div>
            <h1>INIT CHECK</h1>
            <asp:Button runat="server" ID="btnInitServices" Text="Call Init Method" OnClick="btnInitServices_Click" />
            <asp:Button runat="server" ID="btnSendReminders" Text="Send Reminders" OnClick="btnSendReminders_Click" />
        </div>
        <div>
            <h1>REFERRALS</h1>
            <div>
                <asp:Button runat="server" ID="AddReferral" Text="Add Referral Method" OnClick="AddReferral_Click" />
                <asp:Button runat="server" ID="GetReferrals" Text="Get Referrals Method" OnClick="GetReferrals_Click" />
                <asp:Button runat="server" ID="UpdateReferral" Text="Update Referral Method" OnClick="UpdateReferral_Click" />
                <asp:Button runat="server" ID="LoginReferral" Text="Login Referral Transaction Method" OnClick="LoginReferral_Click" />
            </div>
            <div>
                Referral ID:
                <asp:TextBox ID="txtReferralId" runat="server" Text="1"></asp:TextBox>
                <asp:Button runat="server" ID="GetReferral" Text="Get Referral Method" OnClick="GetReferral_Click" />
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </div>
            <div>
                Referral Code:
                <asp:TextBox ID="txtReferralCode" runat="server" Text="RRrR"></asp:TextBox>
                <asp:Button runat="server" ID="CheckReferralCode" Text="Check Referral Code Method" OnClick="CheckReferralCode_Click" />
            </div>
            <div>
                <asp:Button runat="server" ID="AddReferralTransaction" Text="Add Referral Transaction Method" OnClick="AddReferralTransaction_Click" />
                <asp:Button runat="server" ID="PayReferralTransaction" Text="Pay Referral Transaction Method" OnClick="PayReferralTransaction_Click" />
            </div>
        </div>
    </form>
</body>
</html>
