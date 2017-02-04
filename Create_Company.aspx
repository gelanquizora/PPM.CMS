<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Masterpage.master" AutoEventWireup="true" CodeFile="Create_Company.aspx.cs" Inherits="Create_Company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       		   <div id="rightColumn" class="right">
        	
            	
               
            <div class="left rc_left">
            	<h3>Add New Company</h3>
            </div>
        <br />
    <table>

<tr><td>Company Name:</td><td  style="width:100px"><asp:TextBox ID="txtCompanyName" 
        runat="server" MaxLength="50"  Width="200px"></asp:TextBox>
</td>
</tr>
<tr><td>Description:</td><td style="width:50px"><asp:TextBox ID="txtDescription" 
        runat="server" MaxLength="2147483647"  Width="400px" Height="200px" 
        TextMode="MultiLine"></asp:TextBox>
   </td>
</tr>
  <tr>
                <td>
                    Logo:
                </td>
                <td>
                  

                 <asp:FileUpload ID="FileUploadControl" runat="server" />
                    <asp:HiddenField ID="HiddenFieldID" runat="server" />
                       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                            SelectCommand="SELECT MAX(CompanyID) as cID FROM Company"></asp:SqlDataSource>
                </td>
            </tr>
<tr><td>&nbsp;</td><td><asp:Button ID="BtnSave" runat="server" Text="Save" onclick="BtnSave_Click" Width="64px" /><asp:Button ID="BtnCancel" runat="server" Text="Cancel" onclick="BtnCancel_Click" /></td></tr></table>
            </div>

</asp:Content>

