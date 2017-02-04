<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="Edit_Client.aspx.cs" Inherits="Edit_Client" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div id="rightColumn" class="right">
        <div class="left rc_left">
            <h3>
                Edit Client</h3>
        </div>
             <br />
    <table cellpadding="2" border="0">
<asp:Label ID="lblClientID" runat="server" style="display:none"/>

<tr><td>ClientName:</td><td  style="width:100px"><asp:TextBox ID="txtClientName" 
        runat="server" MaxLength="50"  Width="200px"></asp:TextBox>
</td>
</tr>
<tr><td>Description:</td><td  style="width:100px"><asp:TextBox ID="txtDescription" 
        runat="server" MaxLength="2147483647"  Width="400px" Height="200px" 
        TextMode="MultiLine"></asp:TextBox>
</td>
</tr>
<%--<tr><td>CompanyID:</td><td  style="width:100px">

  <asp:DropDownList ID="ddlCompany" runat="server" DataSourceID="dsCompany" 
        DataTextField="CompanyName" DataValueField="CompanyID" Width="200px">
    </asp:DropDownList>
    <asp:SqlDataSource ID="dsCompany" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectCompany" 
        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</td>
</tr>--%>
<tr><td>&nbsp;</td><td><asp:Button ID="BtnUpdate" runat="server" Text="Save" onclick="BtnUpdate_Click" Width="64px" /><asp:Button ID="BtnCancel" runat="server" Text="Cancel" onclick="BtnCancel_Click" /></td></tr></table>
</div>
</asp:Content>

