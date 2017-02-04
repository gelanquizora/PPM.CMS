<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="ProjectGrid.aspx.cs" Inherits="ProjectGrid" %>
 
 <asp:Content ID="Content3" ContentPlaceHolderID="head" Runat="Server">
 
</asp:Content>
 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div id="rightColumn" class="right">
               <asp:Button ID="createNew" runat="server" Text="Create New" 
                   onclick="createNew_Click" />
                   <br />
             <div class="left rc_left">
            	<h3>Manage Projects</h3>
           </div>
            <br />
    <asp:GridView ID="GridView1" Font-Names="helvetica" width="80%" runat="server" 
                   AutoGenerateColumns="False"  AllowPaging="True" AllowSorting="True" 
                   DataKeyNames="ProjectID" DataSourceID="SqlDataSource1" 
                   onselectedindexchanged="GridView1_SelectedIndexChanged" OnRowCommand ="GridView1_RowCommand"><Columns>
<asp:BoundField DataField="ProjectID" Visible ="False" HeaderText="ProjectID" InsertVisible="False" ReadOnly="True" SortExpression="ProjectID" />
<asp:BoundField DataField="ProjectName" HeaderText="Project Name" InsertVisible="False" SortExpression="ProjectName" />

 
<asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <a href='PresentationGrid.aspx?id=<%# Eval("ProjectID") %>'>
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/06-magnify.png" /></a>
                        <a href='View_Project.aspx?ProjectID=<%# Eval("ProjectID") %>'>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/pages.png" /></a> 
                            <a href='Edit_Project.aspx?ProjectID=<%# Eval("ProjectID") %>'>
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/images/187-pencil.png" /></a>
                        <asp:ImageButton ID="lnkDelete" ToolTip='<%# Eval("ProjectID") %>' CommandName="del"
                            CommandArgument='<%# Eval("ProjectID") %>' runat="server" OnClientClick="return UserDeleteConfirmation();" ImageUrl="~/images/delete.png">
                        </asp:ImageButton>
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
        ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectProjectGrid" 
        SelectCommandType="StoredProcedure" DeleteCommand="sp_DeleteProject" 
        DeleteCommandType="StoredProcedure">
       <DeleteParameters>
           <asp:Parameter Name="ProjectID" Type="Int32" />
       </DeleteParameters>
       <SelectParameters>
           <asp:QueryStringParameter Name="ClientID" QueryStringField="id" Type="Int32" />
       </SelectParameters>
    </asp:SqlDataSource>
      </div>
</asp:Content>
 
     