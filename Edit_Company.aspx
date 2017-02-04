<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Masterpage.master" AutoEventWireup="true" CodeFile="Edit_Company.aspx.cs" Inherits="Edit_Company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="rightColumn" class="right">
        <div class="left rc_left">
            <h3>
                Edit Company</h3>
        </div>
       <br />
    <table cellpadding="2" border="0">
<asp:Label ID="lblCompanyID" runat="server" style="display:none"/>

<tr><td>CompanyName:</td><td  style="width:100px"><asp:TextBox ID="txtCompanyName" 
        runat="server" MaxLength="50"  Width="200px"></asp:TextBox>
</td>
</tr>
<tr><td>Description:</td><td  style="width:100px"><asp:TextBox ID="txtDescription" 
        runat="server" MaxLength="2147483647"  Width="400px" Height="200px" 
        TextMode="MultiLine"></asp:TextBox>
</td>
</tr>
        <tr><td>Logo</td><td>
                           
                              <asp:Image ID="img" runat="server" AlternateText="No Available Logo" Width="300px"
                        Height="200px" /><br />
                           <asp:FileUpload ID="FileUploadEdit" runat="server" /><asp:HiddenField ID="HiddenField1"
                               runat="server" />
        </td></tr>
<tr><td>&nbsp;</td><td><asp:Button ID="BtnUpdate" runat="server" Text="Save" onclick="BtnUpdate_Click" Width="64px" /><asp:Button ID="BtnCancel" runat="server" Text="Cancel" onclick="BtnCancel_Click" /></td></tr></table>

 </div>
</asp:Content>

