<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Masterpage.master" AutoEventWireup="true" CodeFile="View_Project.aspx.cs" Inherits="View_Project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div id="rightColumn" class="right">
        <div class="left rc_left">
            <h3>
                View Project</h3>
        </div>
             <br />
    <table cellpadding="2" border="0">
<asp:Label ID="lblProjectID" runat="server" style="display:none" />

<tr><td>ProjectName:</td><td  style="width:100px">
    <asp:Label ID="txtProjectName" runat="server"></asp:Label>
</td>
</tr>
<tr><td>Description:</td><td  style="width:100px">
        <asp:Label ID="txtDescription" runat="server"></asp:Label>
</td>
</tr>
<tr><td>Client Name:</td><td  style="width:100px">    
    <asp:DropDownList ID="ddlClient" runat="server" DataSourceID ="dsClient" 
        DataTextField ="ClientName" DataValueField ="ClientID" Width="200px">
    </asp:DropDownList>   

        <asp:SqlDataSource ID="dsClient" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectClient" 
        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</td>
</tr>
<tr><td>&nbsp;</td><td><asp:Button ID="BtnCancel" runat="server" Text="Cancel" onclick="BtnCancel_Click" /></td></tr></table>

       </div>
</asp:Content>

