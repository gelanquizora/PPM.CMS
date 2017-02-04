<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Doc.aspx.cs" Inherits="Master_Doc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                  <asp:Button ID="createNew" runat="server" Text="Create New" 
                   onclick="createNew_Click" />
                   <br />
    <div class="left rc_left">
            	<h3>Manage Documents</h3>
            </div>
    <asp:MultiView ID="MultiView1" runat="server">

<asp:View ID="View1" runat="server">
  <asp:GridView ID="gvDocuments" runat="server" OnRowCommand ="GridView1_RowCommand" AutoGenerateColumns="False" AllowPaging="True"
                            AllowSorting="True" DataSourceID="dsCategory" Width="100%" CellSpacing="2">
                            <Columns>
                            <asp:BoundField DataField="DocumentTitle" HeaderText="File Name" />
                             
                                <asp:TemplateField HeaderText="File" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblImageURL" runat="server" ItemStyle-HorizontalAlign="Center" Text='<%# Eval("DocumentPath")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                   
                                <asp:TemplateField HeaderText="ACTION" ItemStyle-Width="120px">
                                    <ItemTemplate>
                                                                                                   <asp:ImageButton ID="ImageButton1" ToolTip='<%# Eval("DocumentID") %>' CommandName="View"
                            CommandArgument='<%# Eval("DocumentID") %>' runat="server" ImageUrl="~/images/pages.png">
                        </asp:ImageButton>

                                                               <asp:ImageButton ID="lnkEdit" ToolTip='<%# Eval("DocumentID") %>' CommandName="edt"
                            CommandArgument='<%# Eval("DocumentID") %>' runat="server" ImageUrl="~/images/187-pencil.png">
                        </asp:ImageButton>

                                               <asp:ImageButton ID="lnkDelete" ToolTip='<%# Eval("DocumentID") %>' CommandName="del"
                            CommandArgument='<%# Eval("DocumentID") %>' OnClientClick="return UserDeleteConfirmation();" runat="server" ImageUrl="~/images/delete.png">
                        </asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                         

                            </Columns>
                            <EmptyDataTemplate>
                                No Record Found
                            </EmptyDataTemplate>
                        </asp:GridView>
    <asp:HiddenField ID="HiddenField1" runat="server" />

    <asp:SqlDataSource ID="dsDocuments" runat="server"></asp:SqlDataSource>
 
 
        
 

       





</asp:View>

<asp:View ID="View2" runat="server">
    <table width ="100%" >
        <tr>
            <td>File Name
            </td>
            <td>
                <asp:TextBox ID="txtFileName" runat="server"></asp:TextBox>
            </td>
        </tr>
             <tr>
            <td>File
            </td>
            <td><asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
             <tr>
            <td>
                
            </td>
            <td>
               <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" /> 
                <asp:Button ID="btnCancelAdd" runat="server" Text="Cancel" 
                    onclick="btnCancelAdd_Click" /><asp:Label ID="lblErrorAdd" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:View>

<asp:View ID="View3" runat="server">

    <table width ="100%" >
        <tr>
            <td>File Name
            </td>
            <td>
                <asp:TextBox ID="txtFileEdit" runat="server"></asp:TextBox>
            </td>
        </tr>
             <tr>
            <td>File
            </td>
            <td><asp:FileUpload ID="FileUpload2" runat="server" /><asp:Label ID="lblFile" runat="server"></asp:Label>
            </td>
        </tr>
             <tr>
            <td>
                
            </td>
            <td>
               <asp:Button ID="btnUpdate" runat="server" Text="Save" /> 
                <asp:Button ID="btnCancelEdit" runat="server" Text="Cancel" 
                    onclick="btnCancelEdit_Click" />
            </td>
        </tr>
    </table>

    
            

  



</asp:View>

</asp:MultiView>

</asp:Content>

