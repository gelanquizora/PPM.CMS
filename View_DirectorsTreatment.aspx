<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="View_DirectorsTreatment.aspx.cs" Inherits="Master_View_DirectorsTreatment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="2" border="0">
    <asp:HiddenField ID="HiddenField1" runat="server" />
             <tr>
            <td>File
            </td>
            <td>
                <asp:Image ID="img" runat="server" AlternateText="No Available Logo" Width="300px"
                        Height="200px" /><br /><asp:Label ID="lblFile" runat="server"></asp:Label>
            </td>
        </tr>

<tr><td>VoiceOver:</td><td  style="width:100px">
    <asp:Label ID="txtVoiceOver" runat="server"></asp:Label>

</td>
</tr>
<tr><td>Description:</td><td  style="width:100px">
    <asp:Label ID="txtDescription" runat="server"></asp:Label>
</td>
</tr>
<tr><td>Rank:</td><td  style="width:100px">
    <asp:Label ID="txtRank" runat="server"></asp:Label>

</td>
</tr>
</table>
</asp:Content>

