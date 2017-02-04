<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NewMasterPage.master" AutoEventWireup="true" CodeFile="UserManagementGrid.aspx.cs" Inherits="UserManagementGrid" %>

 
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderHead" Runat="Server">
 
 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPrimary_Nav" Runat="Server">
    <ul>
            <li class="nav_dashboard" ><a href="Default.aspx">Dashboard</a></li>
            <li class="nav_clients"><a href="ClientGrid.aspx">Clients</a></li>
            <li class="nav_projects"><a href="Decks.aspx">Projects</a></li>
           <li class="nav_decks active" ><a href="UserManagementGrid.aspx">User Management</a></li>
        </ul>
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
        	<div class="widget_title"><span class="iconsweet">f</span><h5>Users</h5></div>
                 <asp:Panel ID="Panel1" runat="server" CssClass="widget_body">
                  
                    <asp:GridView ID="GridView1" OnRowCommand ="GridView1_RowCommand" Width="100%" runat="server" AutoGenerateColumns="False" CssClass="activity_datatable"
                    AllowPaging="True" AllowSorting="True" DataKeyNames ="UserId" DataSourceID="SqlDataSource1"
                   Font-Names="helvetica" OnRowDataBound ="GridView1_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="User Name" />
                        <asp:BoundField DataField="RoleName" HeaderText="Role Name" />
                          <asp:BoundField DataField="Email" HeaderText="Email" />
                          
                            <asp:BoundField DataField="Password" HeaderText="Password" Visible ="False" />
                             <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />
                   
                      
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Label ID="lblCompanyID" Visible ="False" runat="server" Text='<%# Eval("CompanyID") %>'></asp:Label>
                   
                             

                                
                                      <asp:ImageButton ID="lnkEdit" ToolTip='Edit' CommandName="edt"
                                    CommandArgument='<%# Eval("UserId") %>'  runat="server" ImageUrl="~/images/187-pencil.png">
                                         </asp:ImageButton>
                                <asp:ImageButton ID="lnkDelete" ToolTip='Delete' CommandName="del"
                                    CommandArgument='<%# Eval("UserName") %>' OnClientClick="return UserDeleteConfirmation();" runat="server" ImageUrl="~/images/delete.png">
                                </asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        No Record Found.
                    </EmptyDataTemplate>
                    <HeaderStyle Font-Names="helvetica" ForeColor="Black" />
                </asp:GridView>
                     <asp:HiddenField ID="HiddenField1" runat="server" />
                    <div class="action_bar">
                          <!--- <a class="button_small whitishBtn" href="#"><span class="iconsweet">l</span>Export Table</a> --->
                        </div>
                 </asp:Panel>
                 <asp:Panel ID="Panel2" runat="server" CssClass="widget_body"  Visible="false" >
                       <div class="content_pad">
                        <h2>Add New User</h2>
                        <br />
                        <ul class="form_fields_container">
                            <li><label>UserName</label> <div class="form_input"><asp:TextBox ID="txtUserName" runat="server"/><asp:RequiredFieldValidator ID="rqfUserName" runat="server" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="Required" ForeColor="Red"/>
<asp:RequiredFieldValidator
              ID="rfvTopic" runat="server" ErrorMessage="*" ControlToValidate ="txtUserName" ValidationGroup ="Add"></asp:RequiredFieldValidator></div></li>
                            <li><label>Password:</label> <div class="form_input">
                                <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"/><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd" Display="Dynamic" ErrorMessage="Required" ForeColor="Red"/>
                            </div></li>
                                  <li><label>Confirm Password:</label> <div class="form_input">
                                <asp:TextBox ID="txtCnfPwd" runat="server" TextMode="Password"/><asp:CompareValidator id="PasswordConfirmCompareValidator" runat="server" ControlToValidate="txtCnfPwd" ForeColor="red" Display="Dynamic" ControlToCompare="txtPwd" ErrorMessage="Confirm password must match password." /><asp:RequiredFieldValidator id="PasswordConfirmRequiredValidator" runat="server" ControlToValidate="txtCnfPwd" ForeColor="red" Display="Dynamic" ErrorMessage="Required" />
                            </div></li>

                                 <li><label>E Mail:</label> <div class="form_input">
                                <asp:TextBox ID="txtEmail" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail" Display="Static" ErrorMessage="Required" ForeColor="Red"/>
                            </div></li>

                                     <li><label>User Role:</label> <div class="form_input">
                                <asp:DropDownList ID="lstRoles" runat="server">
    </asp:DropDownList>
                            </div></li>
                                                                 <li><label>Company:</label> <div class="form_input">
                                <asp:DropDownList ID="ddlCompany" DataTextField ="CompanyName" DataValueField ="CompanyID" runat="server" DataSourceID="dsCompany">
                                    
    </asp:DropDownList>
                                                                       <asp:SqlDataSource ID="dsCompany" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" SelectCommand="sp_SelectCompany" 
        SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
                            </div></li>
                            <li><label></label> <div class="form_input">
                                <asp:Label ID="lblResult" runat="server" Font-Bold="true"/>
                            </div></li>
                        </ul>
                        
                        </div>
                        <div class="action_bar">
                            <asp:Button ID="BtnSave" class="button_small whitishBtn" runat="server" Text="Save" onclick="btnSubmit_Click" ValidationGroup ="Add" />
                            <asp:Button ID="btnCancelNewItem" class="button_small whitishBtn" runat="server" Text="Cancel" onclick="btnCancelNewItem_Click" CausesValidation ="false" />   
                       </div>
                 </asp:Panel>
                 <asp:Panel ID="Panel4" runat="server" CssClass="widget_body"  Visible="false" >
                      
                      <div class="content_pad">
                        <h2>Edit User</h2>
                        <br />
                        <ul class="form_fields_container">
                            <li><label>UserName</label> <div class="form_input"><asp:TextBox ID="txtUserNameEdit" runat="server" ValidationGroup ="edit"/><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup ="edit" runat="server" ControlToValidate="txtUserNameEdit" Display="Dynamic" ErrorMessage="Required" ForeColor="Red"/>
</div></li>
                        <%--      <li><label>Old Password:</label> <div class="form_input">
                                <asp:TextBox ID="txtOldPassword" runat="server" ValidationGroup ="edit"/><asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup ="edit" runat="server" ControlToValidate="txtOldPassword" Display="Dynamic" ErrorMessage="Required" ForeColor="Red"/>
                            </div></li>--%>
                            <li><label>New Password:</label> <div class="form_input">
                                <asp:TextBox ID="txtPasswordEdit" runat="server" ValidationGroup ="edit" TextMode="Password"/><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup ="edit" ControlToValidate="txtPasswordEdit" Display="Dynamic" ErrorMessage="Required" ForeColor="Red"/>
                            </div></li>
                                  <li><label>Confirm New Password:</label> <div class="form_input">
                                <asp:TextBox ID="txtConfirmPasswordEdit" ValidationGroup ="edit" runat="server" TextMode="Password"/><asp:CompareValidator id="CompareValidator1" ValidationGroup ="edit" runat="server" ControlToValidate="txtConfirmPasswordEdit" ForeColor="red" Display="Dynamic" ControlToCompare="txtPasswordEdit" ErrorMessage="Confirm password must match password." /><asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ControlToValidate="txtConfirmPasswordEdit" ForeColor="red" Display="Dynamic" ValidationGroup ="edit" ErrorMessage="Required" />
                            </div></li>

                                 <li><label>E Mail:</label> <div class="form_input">
                                <asp:TextBox ID="txtEmailEdit" runat="server" ValidationGroup ="edit"/><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmailEdit" ValidationGroup ="edit" Display="Static" ErrorMessage="Required" ForeColor="Red"/>
                            </div></li>

                                     <li><label>User Role:</label> <div class="form_input">
                                <asp:DropDownList ID="lstRolesEdit" runat="server">
    </asp:DropDownList>
                            </div></li>
                            <li><label>Company:</label> <div class="form_input">
                                <asp:DropDownList ID="ddlCompanyEdit" DataTextField ="CompanyName" DataValueField ="CompanyID" runat="server" DataSourceID="dsCompany">
                                    
    </asp:DropDownList>
                                                                       <asp:SqlDataSource ID="dsCompanyEdit" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" SelectCommand="sp_SelectCompany" 
        SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
                            </div></li>
                     
                        </ul>
                        
                        </div>
                        <div class="action_bar">
                            <asp:Button ID="BtnUpdate" class="button_small whitishBtn" ValidationGroup ="edit" runat="server" Text="Save" onclick="BtnUpdate_Click" />
                            <asp:Button ID="BtnCancel" class="button_small whitishBtn" runat="server" Text="Cancel" onclick="BtnCancelEdit_Click" CausesValidation ="false" />   
                       </div>

                 </asp:Panel>
                <%-- <asp:Panel ID="Panel3" runat="server" CssClass="widget_body"  Visible="false" >
                   
                     <iframe id="frmProjects" runat="server" height="500px" width="100%"></iframe>
                 </asp:Panel>--%>
        </div>
    </div>    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="sp_CMSUser" 
        SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
</asp:Content>



    
     



 