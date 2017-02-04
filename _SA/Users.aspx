<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SiteSuperAdmin.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="_SA_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

<ul class="main-nav">
               <li class="home">
                    <a href="Company.aspx">Company</a>
                </li>
                <li class="clients">
                    <a href="#" class="selected">Users</a>
                </li>
              
            </ul>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    	<div class="main-columns">
        	<div class="container">
               <div class="top-title">
                    	    <h6 class="large-12 medium-12 left">CMS Users</h6>
                        </div>
               <div class="content-container">
                    	 
                            <asp:Button ID="btnAddNew"  CssClass="small radius button" runat="server" Text="Add New Item" OnClick="createNew_Click" /> 
                            <br>
                            <br>
                        
                        	 <asp:Panel ID="Panel1" runat="server" CssClass="table-container">
                               <asp:HiddenField ID="HiddenField1" runat="server" />
                     <asp:GridView ID="GridView1" OnRowCommand ="GridView1_RowCommand" Width="100%" runat="server" AutoGenerateColumns="False" CssClass="activity_datatable"
                    AllowPaging="True" AllowSorting="True" DataKeyNames ="UserId, RoleID" DataSourceID="SqlDataSource1" SelectedRowStyle-BackColor="Cyan" PageSize="15"
                   Font-Names="helvetica" OnRowDataBound ="GridView1_RowDataBound" EnablePersistedSelection="true">
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="UserName" />
                        <asp:BoundField DataField="RoleName" HeaderText="Role Name"  SortExpression="RoleName"/>
                            <asp:BoundField DataField="CompanyName" HeaderText="Company"  SortExpression="CompanyName" />
                          <asp:BoundField DataField="Email" HeaderText="Email"  SortExpression="Email" />
                          

                            <asp:BoundField DataField="Password" HeaderText="Password" Visible ="False" />
                         <%--    <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />--%>
                   
                      
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Label ID="lblCompanyID" Visible ="False" runat="server" Text='<%# Eval("CompanyID") %>'></asp:Label>
                   
                              <asp:ImageButton ID="lnkEdit" ToolTip='Edit' CommandName="edt"
                                    CommandArgument='<%# Eval("UserId") %>'  runat="server" ImageUrl="~/images/187-pencil.png">
                                         </asp:ImageButton>
                                <asp:ImageButton ID="lnkDelete" ToolTip='Delete' CommandName="del"
                                    CommandArgument='<%# Eval("UserName") %>' OnClientClick="return confirm('Are you certain you want to delete this user?');" runat="server" ImageUrl="~/images/delete.png">
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
                             <asp:Panel ID="Panel2" runat="server"  Visible="false" >
                              	<div class="row">
                            	<div class="large-8 columns">
                                	<label>Username</label>
                                    <asp:TextBox ID="txtUserName" runat="server"/><asp:RequiredFieldValidator ID="rqfUserName" runat="server" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="Required" ForeColor="Red"/>
                                <asp:RequiredFieldValidator   ID="rfvTopic" runat="server" ErrorMessage="*" ControlToValidate ="txtUserName" ValidationGroup ="Add"></asp:RequiredFieldValidator>
                                 </div>
                            </div>
                            <div class="row">
                            	<div class="large-8 columns">
                                	<label>Password</label>
                                   <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"/><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd" Display="Dynamic" ErrorMessage="Required" ForeColor="Red"/>
                                 </div>
                            </div>
                            <div class="row">
                            	<div class="large-8 columns">
                                	<label>Confirm Password</label>
                                      <asp:TextBox ID="txtCnfPwd" runat="server" TextMode="Password"/><asp:CompareValidator id="PasswordConfirmCompareValidator" runat="server" ControlToValidate="txtCnfPwd" ForeColor="red" Display="Dynamic" ControlToCompare="txtPwd" ErrorMessage="Confirm password must match password." /><asp:RequiredFieldValidator id="PasswordConfirmRequiredValidator" runat="server" ControlToValidate="txtCnfPwd" ForeColor="red" Display="Dynamic" ErrorMessage="Required" />
                                 </div>
                            </div>
                              <div class="row">
                            	<div class="large-8 columns">
                                	<label>E-mail</label>
                                    <asp:TextBox ID="txtEmail" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail" Display="Static" ErrorMessage="Required" ForeColor="Red"/>
                                 </div>
                            </div>
                                <div class="row">
                            	<div class="large-8 columns">
                                	<label>User role</label>
                                  <asp:DropDownList ID="lstRoles" runat="server" 
                                        onselectedindexchanged="lstRoles_SelectedIndexChanged" AutoPostBack="true"> </asp:DropDownList>
                                 </div>
                            </div>
                              <div class="row">
                            	<div class="large-8 columns">
                                	<label>Company</label>
                                  <asp:DropDownList ID="ddlCompany" runat="server" DataSourceID="SqlDataSource2" 
                                        DataTextField="CompanyName" DataValueField="CompanyID" AppendDataBoundItems="true"> <asp:ListItem Value="0" Text="All"> </asp:ListItem> </asp:DropDownList>
                                 </div>
                            </div>
                            <div class="row">
                            	<div class="large-8 columns">
                                 <asp:Button ID="BtnSave" class="button_small whitishBtn" runat="server" Text="Save" onclick="btnSubmit_Click" ValidationGroup ="Add" />
                            <asp:Button ID="btnCancelNewItem" class="button_small whitishBtn" runat="server" Text="Cancel" onclick="btnCancelNewItem_Click" CausesValidation ="false" />   
                       
                            

                                </div>
                            </div>

                                 <asp:Label ID="lblResult" runat="server" Font-Bold="true"/>
                         </asp:Panel>
                              
                             <!--- View --> 
                             <asp:Panel ID="Panel4" runat="server"   Visible="false" >
                              
                             <h6>Edit User</h6>
                         	<div class="row">
                            	<div class="large-8 columns">
                                	<label>Username</label>
                                  <asp:TextBox ID="txtUserNameEdit" runat="server" ValidationGroup ="edit" Enabled="false"/><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup ="edit" runat="server" ControlToValidate="txtUserNameEdit" Display="Dynamic" ErrorMessage="Required" ForeColor="Red"/>
                                    </div>
                            </div>
                            <div class="row">
                            	<div class="large-8 columns">
                                	<label>Password</label>
                                  <asp:TextBox ID="txtPasswordEdit" runat="server" ValidationGroup ="edit" TextMode="Password"/><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup ="edit" ControlToValidate="txtPasswordEdit" Display="Dynamic" ErrorMessage="Required" ForeColor="Red"/>
                                  </div>
                            </div>
                            <div class="row">
                            	<div class="large-8 columns">
                                	<label>Confirm Password</label>
                                   <asp:TextBox ID="txtConfirmPasswordEdit" ValidationGroup ="edit" runat="server" TextMode="Password"/><asp:CompareValidator id="CompareValidator1" ValidationGroup ="edit" runat="server" ControlToValidate="txtConfirmPasswordEdit" ForeColor="red" Display="Dynamic" ControlToCompare="txtPasswordEdit" ErrorMessage="Confirm password must match password." /><asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ControlToValidate="txtConfirmPasswordEdit" ForeColor="red" Display="Dynamic" ValidationGroup ="edit" ErrorMessage="Required" />
                                 </div>
                            </div>
                              <div class="row">
                            	<div class="large-8 columns">
                                	<label>E-mail</label>
                                      <asp:TextBox ID="txtEmailEdit" runat="server" ValidationGroup ="edit"/><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmailEdit" ValidationGroup ="edit" Display="Static" ErrorMessage="Required" ForeColor="Red"/>
                          
                                 </div>
                            </div>
                                <div class="row">
                            	<div class="large-8 columns">
                                	<label>User role</label>
                                <asp:DropDownList ID="lstRolesEdit" runat="server">  </asp:DropDownList>
                                 </div>
                            </div>

                               <div class="row">
                            	<div class="large-8 columns">
                                	<label>Company</label>
                                  <asp:DropDownList ID="ddlCompanyEdit" runat="server" DataSourceID="SqlDataSource2" 
                                        DataTextField="CompanyName" DataValueField="CompanyID" OnDataBound="ddlCompanyEdit_Databound" 
                                        AppendDataBoundItems="true"  > <asp:ListItem Value="0" Text="All"> </asp:ListItem> </asp:DropDownList>
                                 </div>
                            </div>
                      <asp:HiddenField ID="txtID" runat="server" />

                            <div class="row">
                            	<div class="large-8 columns">
                         
                                <asp:Button ID="BtnUpdate" class="button_small whitishBtn" ValidationGroup ="edit" runat="server" Text="Save" onclick="BtnUpdate_Click" />
                            <asp:Button ID="BtnCancel" class="button_small whitishBtn" runat="server" Text="Cancel" onclick="BtnCancelEdit_Click" CausesValidation ="false" />   
                            </div>
                            </div>
                           
                               

                     
                       
               
                     
                 </asp:Panel>
                     <asp:Panel ID="Panel3" runat="server"  Visible="false" CssClass="table-container" >
                   
                     <iframe id="frmProjects" runat="server" height="500px" width="100%"  style="border:0;"></iframe>
                 </asp:Panel>           
             
              </div>
                    
                    
                    
                    
                    
                    
          </div>
    
    <div style="display:none">  
                          <asp:Label ID="Label1" runat="server" Text="0"></asp:Label>
                                </div>
                                                                       <asp:SqlDataSource ID="dsCompany" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" SelectCommand="sp_SelectCompany" 
        SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>

      <asp:SqlDataSource ID="dsCompanyEdit" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" SelectCommand="sp_SelectCompany" 
        SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
</ContentTemplate>
 </asp:UpdatePanel>    
                
              
              
              


<!-- SQL DataSource --->
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="sp_CMSUser" 
        SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
       <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
        ProviderName="System.Data.SqlClient"   SelectCommand="SELECT [CompanyID],[CompanyName] FROM Company WHERE Active = 1" >
    </asp:SqlDataSource>

<!-- end SQL DataSource --->
</asp:Content>
