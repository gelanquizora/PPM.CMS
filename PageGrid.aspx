<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="PageGrid.aspx.cs" Inherits="PageGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <div id="rightColumn" class="right">
               <asp:Button ID="createNew" runat="server" Text="Create New" 
                   onclick="createNew_Click" />
                   <br />
     <div class="left rc_left">
            	<h3>Manage Pages</h3>
            </div>
            <br />
    <asp:GridView ID="GridView1" Width="80%" runat="server" OnRowCommand="GridView1_RowCommand"
        AutoGenerateColumns="False" Font-Names="helvetica" AllowPaging="True" AllowSorting="True" DataKeyNames="PageID"
        DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="PageID" HeaderText="PageID" InsertVisible="False" Visible="False"
                SortExpression="PageID" />
            <asp:BoundField DataField="PageName" HeaderText="Page Name" InsertVisible="False"
                SortExpression="PageName" />
        <%--    <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:ImageButton ID="lnkEdit" ToolTip='<%# Eval("PageID") %>' CommandName="edt" CommandArgument='<%# Eval("PageID") %>'
                        runat="server" CausesValidation="false" ImageUrl ="~/images/187-pencil.png" ></asp:ImageButton>

                    
                </ItemTemplate>
            </asp:TemplateField>
     
<asp:CommandField ShowDeleteButton ="True"  DeleteImageUrl="images/delete.png" ButtonType="Image" />--%>



<asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                  <%--
                        <a href='View_Page.aspx?PageID=<%# Eval("PageID") %>'>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/pages.png" /></a> --%>
                            <a href='Edit_Page.aspx?PageID=<%# Eval("PageID") %>'>
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/images/187-pencil.png" /></a>
                        <asp:ImageButton ID="lnkDelete" ToolTip='<%# Eval("PageID") %>' CommandName="del"
                            CommandArgument='<%# Eval("PageID") %>' runat="server" ImageUrl="~/images/delete.png">
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
                   SelectCommand="sp_SelectPages" ProviderName="System.Data.SqlClient" 
                   SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:QueryStringParameter Name="PresentationID" 
            QueryStringField="PresentationID" Type="Int32" />
    </SelectParameters>
               </asp:SqlDataSource>
</div>
</asp:Content>

