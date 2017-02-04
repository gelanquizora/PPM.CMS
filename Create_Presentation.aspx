<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="Create_Presentation.aspx.cs" Inherits="Create_Presentation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
          		   <div id="rightColumn" class="right">
        	 <div class="left rc_left">
            	<h3>Add New Presentation</h3>
            </div>
                 <br />
    <table cellpadding="2" border="0">

<tr><td>Title:</td><td  style="width:100px">
    <asp:TextBox ID="txtTitle" runat="server" MaxLength="50"  Width="200px"></asp:TextBox>
</td>
</tr>
<tr><td>Description:</td><td  style="width:100px">
    <asp:TextBox ID="txtDescription" runat="server" MaxLength="2147483647"  
        Width="400px" Height="200px" TextMode="MultiLine"></asp:TextBox>
</td>
</tr>
<tr><td>Project Name:</td><td  style="width:100px">
    <asp:DropDownList ID="ddlProject" runat="server" DataSourceID ="SqlDataSource1" 
        DataTextField ="ClientName" DataValueField ="ClientID" Width="200px">
    </asp:DropDownList>   

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectClientGridByCompany" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="CompanyID" SessionField="CompanyID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

</td>
</tr>
<tr><td>&nbsp;</td><td><asp:Button ID="BtnSave" runat="server" Text="Save" onclick="BtnSave_Click" Width="64px" />
      <input type="button"   value="Cancel" onclick="top.back();"/>
</td></tr></table>

  </div>
</asp:Content>

