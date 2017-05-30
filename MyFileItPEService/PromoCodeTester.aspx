<%@ Page Title="" Language="C#" MasterPageFile="~/MyFileItPE.Master" AutoEventWireup="true" CodeBehind="PromoCodeTester.aspx.cs" Inherits="MyFileItPEService.PromoCodeTester" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .message {
            font-size: 16pt;
            color: red;
        }

        td {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Promo Code Tester</h1>
    <p>Enter some information to add test promo codes.</p>
    <div class="message">
        <asp:Label runat="server" ID="lblError"></asp:Label>
    </div>
    <table>
        <tr>
            <td>Organization:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlOrganization" AutoPostBack="false"></asp:DropDownList>
                <asp:Button runat="server" ID="btnViewCodes" Text="View Codes" OnClick="btnViewCodes_Click" />
            </td>
        </tr>
        <tr>
            <td>Sales Rep:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlSalesRep"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Promo Code:</td>
            <td>
                <asp:TextBox runat="server" ID="txtPromoCode"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Number of keys:</td>
            <td>
                <asp:TextBox runat="server" ID="txtNumberKeys"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Promo Image:</td>
            <td>
                <asp:FileUpload runat="server" ID="fuImage" /></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button runat="server" ID="btnGenerateKeys" Text="Generate Keys" OnClick="btnGenerateKeys_Click" />
            </td>
        </tr>
    </table>
    <div class="codes">
        <asp:Literal runat="server" ID="litCodes">

        </asp:Literal>
    </div>
    <h3>Sometimes an organization is missing a user and it won't show up in the list above for promo codes. If this is the case, please add it below.</h3>
    <table>
        <tr>
            <th colspan="2">
                <h3>Add a user to organization</h3>
            </th>
        </tr>
        <tr>
            <td>Add User to Organization:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlAddOrganization"></asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td>Select User to add to Organization:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlAddOrganizationUser"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button runat="server" ID="btnAddUserToOrganization" Text="Add user to Organization" OnClick="btnAddUserToOrganization_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
