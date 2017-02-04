<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="Create_Client.aspx.cs" Inherits="Create_Client" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    	  <h3>Edit Client</h3>
      
            <br />
               
                 
    <table cellpadding="2" border="0">

<tr><td>Client Name:</td><td  style="width:100px"><asp:TextBox ID="txtClientName" runat="server" MaxLength="50"  Width="200px"></asp:TextBox>

</tr>
<tr><td>Description:</td><td  style="width:100px"><asp:TextBox ID="txtDescription" 
        runat="server" MaxLength="2147483647"  Width="400px" Height="100px" 
        TextMode="MultiLine"></asp:TextBox>
</td>
</tr>
<%--<tr><td>Company Name:</td><td  style="width:100px">
    <asp:DropDownList ID="ddlCompany" runat="server" DataSourceID="dsCompany" 
        DataTextField="CompanyName" DataValueField="CompanyID" Width="200px">
    </asp:DropDownList>
    <asp:SqlDataSource ID="dsCompany" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectCompany" 
        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
  

</td>
</tr>--%>
<tr><td>&nbsp;</td><td><asp:Button ID="BtnSave" runat="server" Text="Save" onclick="BtnSave_Click" Width="64px" />
   <input type="button"   value="Cancel" onclick="top.back();"/>

</td></tr></table>

</div>
</asp:Content>

