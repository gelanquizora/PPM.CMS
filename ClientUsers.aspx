<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SiteBlank.master" AutoEventWireup="true" CodeFile="ClientUsers.aspx.cs" Inherits="ClientUsers" %>

 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
          <asp:Button ID="btnAddNew"  CssClass="small radius button"  runat="server" Text="Add New Item" OnClick="createNew_Click" /> 
   
  
 
              	 <asp:Panel ID="Panel1" runat="server" CssClass="table-container">
                
                    <asp:GridView ID="GridView1" OnRowCommand ="GridView1_RowCommand"     width="100%" 
                         runat="server" AutoGenerateColumns="False"  
                    AllowPaging="True" AllowSorting="True" DataKeyNames ="ID, ClientID, Username, Password, DeckID" DataSourceID="SqlDataSource1"
                   Font-Names="helvetica" OnRowDataBound ="GridView1_RowDataBound" >
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="User Name" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                              
                                      <asp:ImageButton ID="lnkEdit" ToolTip='Edit' CommandName="edt"
                                    CommandArgument='<%# Eval("ID") %>'  runat="server" ImageUrl="~/images/187-pencil.png">
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

                             <%--    <li><label>E Mail:</label> <div class="form_input">
                                <asp:TextBox ID="txtEmail" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail" Display="Static" ErrorMessage="Required" ForeColor="Red"/>
                            </div></li>
--%> <li><label>Active Deck</label> <div class="form_input">
                                       <asp:DropDownList ID="drpDecks" runat="server" DataSourceID="SqlDataSource2" 
                                           DataTextField="Title" DataValueField="PresentationID">
                                       </asp:DropDownList>
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
                           <%-- <li><label>New Password:</label> <div class="form_input">
                                <asp:TextBox ID="txtPasswordEdit" runat="server" ValidationGroup ="edit" TextMode="Password"/><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup ="edit" ControlToValidate="txtPasswordEdit" Display="Dynamic" ErrorMessage="Required" ForeColor="Red"/>
                            </div></li>
                                  <li><label>Confirm New Password:</label> <div class="form_input">
                                <asp:TextBox ID="txtConfirmPasswordEdit" ValidationGroup ="edit" runat="server" TextMode="Password"/><asp:CompareValidator id="CompareValidator1" ValidationGroup ="edit" runat="server" ControlToValidate="txtConfirmPasswordEdit" ForeColor="red" Display="Dynamic" ControlToCompare="txtPasswordEdit" ErrorMessage="Confirm password must match password." /><asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ControlToValidate="txtConfirmPasswordEdit" ForeColor="red" Display="Dynamic" ValidationGroup ="edit" ErrorMessage="Required" />
                            </div></li>

                                 <li><label>E Mail:</label> <div class="form_input">
                                <asp:TextBox ID="txtEmailEdit" runat="server" ValidationGroup ="edit"/><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmailEdit" ValidationGroup ="edit" Display="Static" ErrorMessage="Required" ForeColor="Red"/>
                            </div></li>--%>
                                   <li><label>Active Deck</label> <div class="form_input">
                                       <asp:DropDownList ID="drpDecksEdit" runat="server" DataSourceID="SqlDataSource2" 
                                           DataTextField="Title" DataValueField="PresentationID">
                                       </asp:DropDownList>
                            </div></li>
                                     
                        </ul>
                        
                        </div>
                        <div class="action_bar">
                            <asp:Button ID="BtnUpdate" class="button_small whitishBtn" ValidationGroup ="edit" runat="server" Text="Save" onclick="BtnUpdate_Click" />
                            <asp:Button ID="BtnCancel" class="button_small whitishBtn" runat="server" Text="Cancel" onclick="BtnCancelEdit_Click" CausesValidation ="false" />   
                       </div>

                 </asp:Panel>
          
 
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectDeviceUsersByClient" 
        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                     <%--   <asp:SessionParameter Name="ClientID" SessionField="ClientID" Type="Int32"  DefaultValue="0"/>--%>
                     <asp:QueryStringParameter  Name="ClientID" QueryStringField="ClientID" Type="Int32"   />
                    </SelectParameters>
    </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectPresentationByClient" 
        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                           <asp:QueryStringParameter  Name="ClientID" QueryStringField="ClientID" Type="Int32"   />
                    </SelectParameters>
    </asp:SqlDataSource>

    
 </asp:Content>
 
