<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="Passcode.aspx.cs" Inherits="Passcode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  Passcode:  <asp:TextBox ID="txtPasscode" runat="server" ReadOnly="true" Font-Bold="true" Font-Size="X-Large"></asp:TextBox>
 
        <asp:Button ID="btnGenerate" runat="server" Text="Generate New" 
            onclick="btnGenerate_Click" />
</asp:Content>

