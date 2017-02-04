<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SiteSuperAdmin.master" AutoEventWireup="true" CodeFile="Company.aspx.cs" Inherits="_SA_Company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

<ul class="main-nav">
                <li class="home">
                  <a href="Company.aspx" class="selected">Companies</a>
                </li>
                <li class="clients" >
                    <a href="Users.aspx"  >Users</a>
                </li>
               
            </ul>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
    	<div class="main-columns">
        	<div class="container">
               <div class="top-title">
                    	    <h6 class="large-12 medium-12 left">Companies</h6>
                        </div>
               <div class="content-container">
                    	 
                            <asp:Button ID="btnAddNew"  CssClass="small radius button" runat="server" Text="Add New Item" OnClick="createNew_Click"   /> 
                            <br>
                            <br>
                        
                        	 <asp:Panel ID="Panel1" runat="server" CssClass="table-container">
                  
                           <asp:GridView ID="GridView1" Font-Names="helvetica" Width="80%" runat="server" AutoGenerateColumns="False"
                   AllowPaging="True" AllowSorting="True" DataKeyNames="CompanyID" DataSourceID="SqlDataSource1"
                   OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand ="GridView1_RowCommand" >
                   <Columns>
                       <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" InsertVisible="False"
                           Visible="false" ReadOnly="True" SortExpression="CompanyID" />
                       <asp:BoundField DataField="CompanyName" HeaderText="Company Name" InsertVisible="False"
                           SortExpression="CompanyName" />
                 
                       <asp:TemplateField HeaderText="Actions">
                           <ItemTemplate>
                                 <asp:ImageButton ID="ImageButton1" ToolTip='View Details' CommandName="view"
                                    CommandArgument='<%# Eval("CompanyID") %>'  runat="server" ImageUrl="~/images/pages.png">
                                         </asp:ImageButton>
                                      <asp:ImageButton ID="lnkEdit" ToolTip='Edit' CommandName="edt"
                                    CommandArgument='<%# Eval("CompanyID") %>'  runat="server" ImageUrl="~/images/187-pencil.png">
                                         </asp:ImageButton>

                                           <asp:ImageButton ID="ImageButton2" ToolTip='Change Logo' CommandName="changelogo"
                                    CommandArgument='<%# Eval("CompanyID") %>'  runat="server" ImageUrl="~/images/drawing.png">    </asp:ImageButton>
                               <asp:ImageButton ID="lnkDelete" ToolTip='<%# Eval("CompanyID") %>' CommandName="del"
                                   CommandArgument='<%# Eval("CompanyID") %>' runat="server" ImageUrl="~/images/delete.png"
                                   CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this company?');"></asp:ImageButton>
                         
                                     
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
                                	<label>Company Name</label>
                                    
                                    <asp:TextBox ID="txtCompanyName" runat="server" MaxLength="50" placeholder="Company Name"></asp:TextBox><asp:RequiredFieldValidator ID="rfvTopic" runat="server" ErrorMessage="*" ControlToValidate ="txtCompanyName" ValidationGroup ="Add"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="large-8 columns">
                                	<label>Description</label>
                                  
                                         <asp:TextBox ID="txtDescription" placeholder="Description" runat="server" MaxLength="2147483647" TextMode="MultiLine" class="auto" cols="" rows="6"></asp:TextBox>
                                </div>
                            </div>
                             <div class="row">
                            	<div class="large-8 columns">
                                	<label>Logo</label>
                                  
                                          <asp:FileUpload ID="FileUploadControl" runat="server" />
                    <asp:HiddenField ID="HiddenFieldID" runat="server" />
                       <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                            SelectCommand="SELECT MAX(CompanyID) as cID FROM Company"></asp:SqlDataSource>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="large-8 columns">
                             
                                        <asp:Button ID="BtnSave" class="small radius button" runat="server" Text="Save"   ValidationGroup ="Add"  OnClick="BtnSave_Click" />
                            <asp:Button ID="btnCancelNewItem" class="small radius button" runat="server" 
                                            Text="Cancel"   CausesValidation ="false" onclick="btnCancelNewItem_Click" />   
                      
                                </div>
                            </div>
                    
                      
                        
                      
                            </asp:Panel>
                              
                             <!--- View --> 
                             <asp:Panel ID="Panel4" runat="server"   Visible="false" >
                             <div class="row">
                            	<div class="large-8 columns">
                                	<label>Company Name</label>
                                    <asp:TextBox ID="txtEditCompanyName" runat="server" MaxLength="50"  Width="200px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate ="txtEditCompanyName" ValidationGroup ="Update"></asp:RequiredFieldValidator>
                                 </div>
                            </div>
                            <div class="row">
                            	<div class="large-8 columns">
                                	<label>Description</label>
                                   <asp:TextBox ID="txtEditDescription"     runat="server" MaxLength="2147483647"  Width="400px" Height="200px"     TextMode="MultiLine"></asp:TextBox>
                                 </div>
                            </div>
                         
                            <div class="row">
                            	<div class="large-8 columns">
                                 <br />
                     <asp:Button ID="BtnUpdate" runat="server" Text="Save"  ValidationGroup ="Update" Width="64px"  
                                        CssClass="small radius button" onclick="BtnUpdate_Click"/>
                             <asp:Button ID="BtnCancel" runat="server" Text="Cancel"   CausesValidation ="false" 
                                        CssClass="small radius button" onclick="BtnCancel_Click" /> 

 
                      
                                </div>
                            </div> 
                                <asp:HiddenField ID="txtID" runat="server" />
                       
               
                     
                 </asp:Panel>
                     <asp:Panel ID="Panel3" runat="server"  Visible="false" CssClass="table-container" >
                   
                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="small radius button"  />
                     <iframe id="frmProjects" runat="server" height="500px" width="100%"  style="border:0;"></iframe>
                 </asp:Panel>           
                <asp:Panel ID="Panel5" runat="server"   Visible="false" >
                        <div class="row">
                            	<div class="large-8 columns">
                                	<label>Logo</label>
                                  <asp:Image ID="img" runat="server" AlternateText="No Available Logo" Width="300px"
                        Height="200px" /><br />
                           <asp:FileUpload ID="FileUploadEdit" runat="server" /><asp:HiddenField ID="HiddenField1"
                               runat="server" />
                                 </div>
                            </div>
                       <div class="row">
                            	<div class="large-8 columns">
                                 <br />
                     <asp:Button ID="Button1" runat="server" Text="Save"  ValidationGroup ="Update" Width="64px"  
                                        CssClass="small radius button" onclick="BtnUpdateLogo_Click"/>
                             <asp:Button ID="Button2" runat="server" Text="Cancel"   CausesValidation ="false" 
                                        CssClass="small radius button" onclick="BtnCancel_Click" /> 

 
                      
                                </div>
                            </div>
                 </asp:Panel>
              </div>
                    
                    
                    
                    
                    
                    
          </div>
    
    </div>
<%--</ContentTemplate>
 </asp:UpdatePanel>    --%>
                
              
              
              


<!-- SQL DataSource --->
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" 
    SelectCommand="SELECT [CompanyID],[CompanyName],[Description] FROM Company WHERE Active = 1" 
    DeleteCommand="sp_DeleteCompany" DeleteCommandType="StoredProcedure" 
    ProviderName="System.Data.SqlClient">
    <DeleteParameters>
        <asp:Parameter Name="CompanyID" Type="Int32" />
    </DeleteParameters>
</asp:SqlDataSource>
<!-- end SQL DataSource --->
</asp:Content>
