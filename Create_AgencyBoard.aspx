<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="Create_AgencyBoard.aspx.cs" Inherits="Master_Create_AgencyBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblErrorAdd" runat="server" Font-Bold ="true" ForeColor ="red"></asp:Label>
<table cellpadding="2" border="0">


             <tr>
            <td>File
            </td>
            <td><asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>




<tr><td></td><td><asp:Button ID="BtnSave" runat="server" Text="Save" onclick="BtnSave_Click" Width="64px" /><asp:Button ID="BtnCancel" runat="server" Text="Cancel" onclick="BtnCancel_Click" /></td></tr></table>
</asp:Content>

