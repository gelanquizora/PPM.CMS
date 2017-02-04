<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NewMasterPage.master" AutoEventWireup="true" CodeFile="ClientGrid.aspx.cs" Inherits="ClientGrid" %>

 
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderHead" Runat="Server">
 
 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPrimary_Nav" Runat="Server">
   <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderLeftSub" Runat="Server">
    <asp:Literal ID="ltPages" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
   <asp:Panel ID="quick_actions" runat="server">
                        <asp:Button ID="btnAddNew"  CssClass="button_big" runat="server" Text="Add New Item" OnClick="createNew_Click" /> 
                    </asp:Panel>
   	<!--One_Wrap-->
 	<div class="one_wrap">
    	<div class="widget">
        	<div class="widget_title"><span class="iconsweet">f</span><h5>Clients</h5></div>
                 <asp:Panel ID="Panel1" runat="server" CssClass="widget_body">
                  
                    <asp:GridView ID="GridView1" OnRowCommand ="GridView1_RowCommand" Width="100%" runat="server" AutoGenerateColumns="False" CssClass="activity_datatable"
                    AllowPaging="True" AllowSorting="True" DataKeyNames="ClientID" DataSourceID="SqlDataSource1"
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Font-Names="helvetica">
                    <Columns>
                        <asp:BoundField DataField="ClientID" HeaderText="ClientID" Visible="False" InsertVisible="False"
                            ReadOnly="True" SortExpression="ClientID" />
                        <asp:BoundField DataField="ClientName" HeaderText="Client Name" InsertVisible="False"
                            SortExpression="ClientName" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                  <a href='Decks.aspx?ClientID=<%# Eval("ClientID") %>'>
                                  <asp:Image ID="Image1" runat="server" ImageUrl="~/images/06-magnify.png"   ToolTip="View Projects"/></a>
                                   <asp:ImageButton ID="lnkView" ToolTip='View' CommandName="view"
                                    CommandArgument='<%# Eval("ClientID") %>'  runat="server" ImageUrl="~/images/pages.png">
                                       </asp:ImageButton>

                                          <asp:ImageButton ID="ImageButton1" ToolTip='View Ipad Users' CommandName="viewUsers"
                                    CommandArgument='<%# Eval("ClientID") %>'  runat="server" ImageUrl="~/images/avatar1.jpg">
                                       </asp:ImageButton>

                                      <asp:ImageButton ID="lnkEdit" ToolTip='Edit' CommandName="edt"
                                    CommandArgument='<%# Eval("ClientID") %>'  runat="server" ImageUrl="~/images/187-pencil.png">
                                         </asp:ImageButton>
                                <asp:ImageButton ID="lnkDelete" ToolTip='Delete' CommandName="del"
                                    CommandArgument='<%# Eval("ClientID") %>' OnClientClick="return UserDeleteConfirmation();" runat="server" ImageUrl="~/images/delete.png">
                                </asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        No Record Found.
                    </EmptyDataTemplate>
                    <HeaderStyle Font-Names="helvetica" ForeColor="Black" />
                </asp:GridView>
                    
                 </asp:Panel>
                 <asp:Panel ID="Panel2" runat="server" CssClass="widget_body"  Visible="false" >
                       <div class="content_pad">
                        <h2>Add New Client</h2>
                        <br />
                        <ul class="form_fields_container">
                            <li><label>Client Name</label> <div class="form_input"><asp:TextBox ID="txtAddName" runat="server" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
              ID="rfvTopic" runat="server" ErrorMessage="*" ControlToValidate ="txtAddName" ValidationGroup ="Add"></asp:RequiredFieldValidator></div></li>
                            <li><label>Description:</label> <div class="form_input">
                                <asp:TextBox ID="txtAddDescription" runat="server" MaxLength="2147483647" TextMode="MultiLine" class="auto" cols="" rows="6"></asp:TextBox>
                            </div></li>
                        </ul>
                        
                        </div>
                        <div class="action_bar">
                            <asp:Button ID="BtnSave" class="button_small whitishBtn" runat="server" Text="Save" onclick="BtnSave_Click" ValidationGroup ="Add" />
                            <asp:Button ID="btnCancelNewItem" class="button_small whitishBtn" runat="server" Text="Cancel" onclick="btnCancelNewItem_Click" CausesValidation ="false" />   
                       </div>
                 </asp:Panel>
                 <asp:Panel ID="Panel4" runat="server" CssClass="widget_body"  Visible="false" >
                       <h3> <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label> </h3>
                                <asp:HiddenField ID="txtID" runat="server" />
                        <br />
                        <table cellpadding="2" border="0">
                            <asp:Label ID="lblClientID" runat="server" style="display:none"/>

                            <tr><td>Client:</td><td  style="width:100px"><asp:TextBox ID="txtClientName" 
                                    runat="server" MaxLength="50"  Width="200px"></asp:TextBox><asp:RequiredFieldValidator
              ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate ="txtClientName" ValidationGroup ="Update"></asp:RequiredFieldValidator>
                            </td>
                            </tr>
                            <tr><td>Description:</td><td  style="width:100px"><asp:TextBox ID="txtDescription" 
                                    runat="server" MaxLength="2147483647"  Width="400px" Height="200px" 
                                    TextMode="MultiLine"></asp:TextBox>
                            </td>
                            </tr>
                             <tr><td>&nbsp;</td><td><asp:Button ID="BtnUpdate" runat="server" Text="Save" onclick="BtnUpdate_Click" ValidationGroup ="Update" Width="64px" />
                             <asp:Button ID="BtnCancel" runat="server" Text="Cancel" onclick="BtnCancelEdit_Click" CausesValidation ="false" /></td></tr></table>  
                     
                 </asp:Panel>
                 <asp:Panel ID="Panel3" runat="server" CssClass="widget_body"  Visible="false" >
                   
                     <iframe id="frmProjects" runat="server" height="500px" width="100%"></iframe>
                 </asp:Panel>
        </div>
    </div>    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectClientGridByCompany" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="CompanyID" SessionField="CompanyID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>



    
     



 