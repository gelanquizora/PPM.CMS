<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="UsersGrid.aspx.cs" Inherits="Master_UsersGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div id="rightColumn" class="right">
               <asp:Button ID="createNew" runat="server" Text="Create New" 
                   onclick="createNew_Click" />
                   <br />
     <div class="left rc_left">
            	<h3>Manage Users</h3>
            </div>
    <br />
    <asp:GridView ID="GridView1" Font-Names="helvetica" OnRowCommand ="GridView1_RowCommand" width="80%" runat="server" AutoGenerateColumns="False"  AllowPaging="True" AllowSorting="True" DataKeyNames="UserID" DataSourceID="SqlDataSource1" onselectedindexchanged="GridView1_SelectedIndexChanged"><Columns>
<asp:BoundField DataField="UserID" HeaderText="UserID" Visible ="false" InsertVisible="False" SortExpression="UserID" />
<asp:BoundField DataField="UserName" HeaderText="UserName" InsertVisible="False" SortExpression="UserName" />
<asp:BoundField DataField="Password" HeaderText="Password" InsertVisible="False" SortExpression="Password" />
<asp:BoundField DataField="FirstName" HeaderText="First Name" InsertVisible="False" SortExpression="FirstName" />
<asp:BoundField DataField="LastName" HeaderText="Last Name" InsertVisible="False" SortExpression="LastName" />
<asp:BoundField DataField="RoleName" HeaderText="Role Name" InsertVisible="False" SortExpression="RoleName" />
<asp:BoundField DataField="CompanyName" HeaderText="Company Name" InsertVisible="False" SortExpression="CompanyName" />
      <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:ImageButton ID="lnkEdit" ToolTip='<%# Eval("UserID") %>' CommandName="edt" CommandArgument='<%# Eval("UserID") %>'
                        runat="server" ImageUrl ="~/images/187-pencil.png"  CausesValidation="false"></asp:ImageButton>
                  
                </ItemTemplate>
            </asp:TemplateField>
      <asp:CommandField ShowDeleteButton ="True"  DeleteImageUrl="images/delete.png" ButtonType="Image" />
            
</Columns>
                                                        <EmptyDataTemplate>
No Record Found.
</EmptyDataTemplate>
 <HeaderStyle Font-Names="helvetica" ForeColor="Black" />
</asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" 
        SelectCommand="sp_SelectUsers" ProviderName="System.Data.SqlClient" 
        SelectCommandType="StoredProcedure" DeleteCommand="sp_DeleteUsers" 
                   DeleteCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="UserID" Type="Int32" />
        </DeleteParameters>
               </asp:SqlDataSource>
        </div>
</asp:Content>

