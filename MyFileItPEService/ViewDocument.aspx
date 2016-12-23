<%@ Page Title="" Language="C#" MasterPageFile="~/MyFileItPE.Master" AutoEventWireup="true" CodeBehind="ViewDocument.aspx.cs" Inherits="MyFileItPEService.ViewDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <asp:Label ID="lblDocumentInfo" runat="server"></asp:Label>
        <asp:Image ID="imgMain" runat="server" />
    </div>
</asp:Content>
