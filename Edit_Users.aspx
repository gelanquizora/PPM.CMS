<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Edit_Users.aspx.cs" Inherits="Master_Edit_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div id="rightColumn" class="right">
        <div class="left rc_left">
            <h3>
                Edit User</h3>
        </div>
  <br />
    <table cellpadding="2" border="0">
<asp:TextBox ID="txtUserID" style="display:none" runat="server" MaxLength="10"  Width="50%"></asp:TextBox>

<tr><td>UserName:</td><td  style="width:100px">
    <asp:TextBox ID="txtUserName" runat="server" MaxLength="50"  Width="200px"></asp:TextBox>
</td>
</tr>
<tr><td>Password:</td><td  style="width:100px">
    <asp:TextBox ID="txtPassword" runat="server" MaxLength="50"  Width="200px"></asp:TextBox>
</td>
</tr>
<tr><td>FirstName:</td><td  style="width:100px">
    <asp:TextBox ID="txtFirstName" runat="server" MaxLength="50"  Width="200px"></asp:TextBox>
</td>
</tr>
<tr><td>LastName:</td><td  style="width:100px">
    <asp:TextBox ID="txtLastName" runat="server" MaxLength="50"  Width="200px"></asp:TextBox>
</td>
</tr>
<tr><td>Role:</td><td  style="width:100px">
    
     <asp:DropDownList ID="ddlRoles" runat="server" DataSourceID="dsRoles" 
        DataTextField="RoleName" DataValueField="RoleID" Width="200px">
    </asp:DropDownList>
    <asp:SqlDataSource ID="dsRoles" runat="server" 
        ConnectionString="Data Source=USER\SQLEXPRESS;Initial Catalog=terrible1;Integrated Security=True" 
        ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectRoles" 
        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</td>
</tr>

<%--     <tr><td>Company Name:</td><td  style="width:100px">
    <asp:DropDownList ID="ddlCompany" runat="server" DataSourceID="dsCompany" 
        DataTextField="CompanyName" DataValueField="CompanyID" Width="200px">
    </asp:DropDownList>
    <asp:SqlDataSource ID="dsCompany" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectCompany" 
        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
  

</td>
</tr>--%>

<tr><td></td><td><asp:Button ID="BtnUpdate" runat="server" Text="Save" onclick="BtnUpdate_Click" Width="64px" /><asp:Button ID="BtnCancel" runat="server" Text="Cancel" onclick="BtnCancel_Click" /></td></tr></table>

       </div>
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>

