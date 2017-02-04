<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="View_Cover.aspx.cs" Inherits="Master_View_Cover" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />
 
<table cellpadding="2" border="0">

<tr><td>&nbsp;</td><td>&nbsp;</td><td><asp:Button ID="BtnUpdate" runat="server" Text="Save" onclick="BtnUpdate_Click" Width="64px" /></td><td><asp:Button ID="BtnCancel" runat="server" Text="Cancel" onclick="BtnCancel_Click" /></td><td></td></tr></table>
</asp:Content>

