<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Masterpage.master" AutoEventWireup="true" CodeFile="View_Company.aspx.cs" Inherits="View_Company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="rightColumn" class="right">
        <div class="left rc_left">
            <h3>
                View Company</h3>
        </div>
       <br />
    <table cellpadding="2" border="0">
<asp:Label ID="lblCompanyID" runat="server" style="display:none"/>

<tr><td>CompanyName:</td><td  style="width:100px"><asp:Label ID="txtCompanyName"
            runat="server"></asp:Label>
</td>
</tr>
<tr><td>Description:</td><td  style="width:100px">
        <asp:Label ID="txtDescription"
            runat="server"></asp:Label>
</td>
</tr>
        <tr><td>Logo</td><td>
                           
                              <asp:Image ID="img" runat="server" AlternateText="No Available Logo" Width="300px"
                        Height="200px" />
        </td></tr>
<tr><td>&nbsp;</td><td><asp:Button ID="BtnCancel" runat="server" Text="Back" onclick="BtnCancel_Click" /></td></tr></table>

 </div>
</asp:Content>

