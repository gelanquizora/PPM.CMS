<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Masterpage.master" AutoEventWireup="true" CodeFile="CompanyGrid.aspx.cs" Inherits="CompanyGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
           <div id="rightColumn" class="right">
        	
            	
               <asp:Button ID="createNew" runat="server" Text="Create New" 
                   onclick="createNew_Click" />
                   <br />
            <div class="left rc_left">
            	<h3>Manage Company</h3>
            </div>
            <br />
               <asp:GridView ID="GridView1" Font-Names="helvetica" Width="80%" runat="server" AutoGenerateColumns="False"
                   AllowPaging="True" AllowSorting="True" DataKeyNames="CompanyID" DataSourceID="SqlDataSource1"
                   OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                   <Columns>
                       <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" InsertVisible="False"
                           Visible="false" ReadOnly="True" SortExpression="CompanyID" />
                       <asp:BoundField DataField="CompanyName" HeaderText="Company Name" InsertVisible="False"
                           SortExpression="CompanyName" />
                       <%--<asp:CommandField ShowSelectButton="True" SelectText="<img src='images/187-pencil.png' border='0'>" />--%>
                       <%--<asp:CommandField ShowDeleteButton ="True"  DeleteImageUrl="images/delete.png" ButtonType="Image" />--%>
                       <asp:TemplateField HeaderText="Actions">
                           <ItemTemplate>
                               <a href='View_Company.aspx?CompanyID=<%# Eval("CompanyID") %>'>
                                   <asp:Image ID="Image2" runat="server" ImageUrl="~/images/pages.png" /></a> <a href='Edit_Company.aspx?CompanyID=<%# Eval("CompanyID") %>'>
                                       <asp:Image ID="Image3" runat="server" ImageUrl="~/images/187-pencil.png" /></a>
                               <asp:ImageButton ID="lnkDelete" ToolTip='<%# Eval("CompanyID") %>' CommandName="del"
                                   CommandArgument='<%# Eval("CompanyID") %>' runat="server" ImageUrl="~/images/delete.png"
                                   CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this company?');"> </asp:ImageButton>
                           </ItemTemplate>
                       </asp:TemplateField>
                   </Columns>
                   <EmptyDataTemplate>
                       No Record Found.
                   </EmptyDataTemplate>
                   <HeaderStyle Font-Names="helvetica" ForeColor="Black" />
               </asp:GridView>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" 
    SelectCommand="SELECT [CompanyID],[CompanyName],[Description] FROM Company" 
    DeleteCommand="sp_DeleteCompany" DeleteCommandType="StoredProcedure" 
    ProviderName="System.Data.SqlClient">
    <DeleteParameters>
        <asp:Parameter Name="CompanyID" Type="Int32" />
    </DeleteParameters>
</asp:SqlDataSource>

</div>
</asp:Content>

