<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="Edit_AgencyBoard.aspx.cs" Inherits="Master_Edit_AgencyBoard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Label ID="lblErrorAdd" runat="server" Font-Bold ="true" ForeColor ="red"></asp:Label>
<table cellpadding="2" border="0">
             <tr>
            <td>File
            </td>
            <td><asp:FileUpload ID="FileUpload1" runat="server" />
            <br /><asp:Label ID="lblFile" runat="server"
                    ></asp:Label>
            </td>
        </tr>
<tr><td>&nbsp;</td><td><asp:Button ID="BtnUpdate" runat="server" Text="Save" onclick="BtnUpdate_Click" Width="64px" /><asp:Button ID="BtnCancel" runat="server" Text="Cancel" onclick="BtnCancel_Click" /></td></tr></table>
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>

