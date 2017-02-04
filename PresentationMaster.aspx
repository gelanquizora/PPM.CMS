<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Masterpage.master" AutoEventWireup="true" CodeFile="PresentationMaster.aspx.cs" Inherits="PresentationMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="rightColumn" class="right">
               <asp:Button ID="createNew" runat="server" Text="Create New" 
                   onclick="createNew_Click" />
                   <br />
     <div class="left rc_left">
            	<h3>Manage Presentations</h3>
            </div>
            <br />
<asp:GridView ID="GridView1" Font-Names="helvetica" OnRowCommand ="GridView1_RowCommand" width="80%" runat="server" AutoGenerateColumns="False"  AllowPaging="True" AllowSorting="True" DataKeyNames="PresentationID" DataSourceID="SqlDataSource1" onselectedindexchanged="GridView1_SelectedIndexChanged"><Columns>
<asp:BoundField DataField="PresentationID" Visible ="False" HeaderText="PresentationID" InsertVisible="False" ReadOnly="True" SortExpression="PresentationID" />
<asp:BoundField DataField="Title" HeaderText="Presentation Name" InsertVisible="False" SortExpression="Title" />

<%--<asp:TemplateField >
            <ItemTemplate>
                <a href='PageGrid.aspx?id=<%# Eval("PresentationID") %>'>Pages</a>
            </ItemTemplate>
        </asp:TemplateField>
<asp:CommandField ShowSelectButton="True" SelectText="Edit" />
<asp:CommandField ShowDeleteButton ="True" SelectText="Delete" />
<asp:CommandField ShowSelectButton="True" SelectText="<img src='images/187-pencil.png' border='0'>" />
<asp:CommandField ShowDeleteButton ="True"  DeleteImageUrl="images/delete.png" ButtonType="Image" />--%>

<asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <a href='PresentationPages.aspx?PresentationID=<%# Eval("PresentationID") %>'>Cover
                            <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/images/06-magnify.png" />--%></a>
                        <a href='Attendee.aspx?PresentationID=<%# Eval("PresentationID") %>'>Attendees
                            <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/images/06-magnify.png" />--%></a>
                        <a href='Agenda.aspx?PresentationID=<%# Eval("PresentationID") %>'>Agenda
                            <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/images/06-magnify.png" />--%></a>
                             <a href='DirectorsBoard.aspx?PresentationID=<%# Eval("PresentationID") %>'>Director's Board
                            <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/images/06-magnify.png" />--%></a>
                               <a href='KeyMessage.aspx?PresentationID=<%# Eval("PresentationID") %>'>Key Message
                            <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/images/06-magnify.png" />--%></a>
                                 <a href='DirectoryPage.aspx?PresentationID=<%# Eval("PresentationID") %>'>Directory
                            <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/images/06-magnify.png" />--%></a>

                        <a href='View_Presentation.aspx?PresentationID=<%# Eval("PresentationID") %>'>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/pages.png" /></a> 
                            <a href='Edit_Presentation.aspx?PresentationID=<%# Eval("PresentationID") %>'>
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/images/187-pencil.png" /></a>
                        <asp:ImageButton ID="lnkDelete" ToolTip='<%# Eval("PresentationID") %>' CommandName="del"
                            CommandArgument='<%# Eval("PresentationID") %>' OnClientClick="return UserDeleteConfirmation();" runat="server" ImageUrl="~/images/delete.png">
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
        ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectPresentationMaster" 
        SelectCommandType="StoredProcedure" DeleteCommand="sp_DeletePresentation" 
        DeleteCommandType="StoredProcedure">
       <DeleteParameters>
           <asp:Parameter Name="PresentationID" Type="Int32" />
       </DeleteParameters>
    </asp:SqlDataSource>
        </div>

</asp:Content>

