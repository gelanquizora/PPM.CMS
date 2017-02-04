<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="Preview.aspx.cs" Inherits="_Admin_Preivew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<iframe runat="server"  id="frmPage"  frameborder="0" style="height: 768px;width:1024px"  ></iframe>
    <asp:Label ID="Label1" runat="server" Text="No content yet. Please make contact your content editor." Visible="false"></asp:Label>
</asp:Content>

