<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Cover.aspx.cs" Inherits="Master_Cover" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="custom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
  
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> <asp:Button ID="Button1" runat="server" Text="Done" onclick="Button1_Click" />
   
    <custom:Editor ID="Editor1" runat="server"  Width ="500px" Height ="500px"/>
    
  <div id="divvalue" runat="server"></div>

</asp:Content>

