<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Masterpage.master" AutoEventWireup="true" CodeFile="Edit_Presentation.aspx.cs" Inherits="Edit_Presentation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
      <div id="rightColumn" class="right">
        <div class="left rc_left">
            <h3>
                Edit Presentation</h3>
        </div>
             <br />
    <table>
    
<asp:Label ID="lblPresentationID" runat="server" style="display:none" />


<tr><td>Title:</td><td  style="width:100px"><asp:TextBox ID="txtTitle" 
        runat="server" MaxLength="50"  Width="200px"></asp:TextBox>
</td>
</tr>
<tr><td>Description:</td><td  style="width:100px"><asp:TextBox ID="txtDescription" 
        runat="server" MaxLength="2147483647"  Width="400px" Height="200px"></asp:TextBox>
</td>
</tr>
<tr><td>Project:</td><td  style="width:100px">    
    <asp:DropDownList ID="ddlProject" runat="server" DataSourceID ="dsProject" 
        DataTextField ="ProjectName" DataValueField ="ProjectID" Width="200px">
    </asp:DropDownList>   

        <asp:SqlDataSource ID="dsProject" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectProject" 
        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</td>
</tr>
<tr><td>&nbsp;</td><td><asp:Button ID="BtnUpdate" runat="server" Text="Save" onclick="BtnUpdate_Click" Width="64px" /><asp:Button ID="BtnCancel" runat="server" Text="Cancel" onclick="BtnCancel_Click" /></td></tr></table>

  </div>
</asp:Content>

