<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SiteAdmin.master" AutoEventWireup="true" CodeFile="Company.aspx.cs" Inherits="_Admin_Company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

<ul class="main-nav">
                <li class="home">
                    <a href="#">Home</a>
                </li>
                <li class="clients" >
                    <a href="../_Admin/Clients.aspx" class="selected">Clients</a>
                </li>
                <li class="projects">
                    <a href="#"  >Projects</a>
                </li> 
            </ul>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    	<div class="main-columns">
        	<div class="container">
               <div class="top-title">
                    	    <h6 class="large-12 medium-12 left">Clients</h6>
                        </div>
               <div class="content-container">
                    	 
                            <asp:Button ID="btnAddNew"  CssClass="small radius button" runat="server" Text="Add New Item"   /> 
                            <br>
                            <br>
                        
                        	 <asp:Panel ID="Panel1" runat="server" CssClass="table-container">
                  
                           <asp:GridView ID="GridView1" Font-Names="helvetica" Width="80%" runat="server" AutoGenerateColumns="False"
                   AllowPaging="True" AllowSorting="True" DataKeyNames="CompanyID" DataSourceID="SqlDataSource1"
                   OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                   <Columns>
                       <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" InsertVisible="False"
                           Visible="false" ReadOnly="True" SortExpression="CompanyID" />
                       <asp:BoundField DataField="CompanyName" HeaderText="Company Name" InsertVisible="False"
                           SortExpression="CompanyName" />
                       <%--<asp:CommandField ShowSelectButton="True" SelectText="<img src='images/187-pencil.png' border='0'>" />--%>
                       <%--<asp:CommandField ShowDeleteButton ="True"  DeleteImageUrl="images/delete.png" ButtonType="Image" />--%>
                       <asp:TemplateField HeaderText="Actions">
                           <ItemTemplate>
                               <a href='View_Company.aspx?CompanyID=<%# Eval("CompanyID") %>'>
                                   <asp:Image ID="Image2" runat="server" ImageUrl="~/images/pages.png" /></a> <a href='Edit_Company.aspx?CompanyID=<%# Eval("CompanyID") %>'>
                                       <asp:Image ID="Image3" runat="server" ImageUrl="~/images/187-pencil.png" /></a>
                               <asp:ImageButton ID="lnkDelete" ToolTip='<%# Eval("CompanyID") %>' CommandName="del"
                                   CommandArgument='<%# Eval("CompanyID") %>' runat="server" ImageUrl="~/images/delete.png"
                                   CausesValidation="false"></asp:ImageButton>
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
                                	<label>Title</label>
                                    
                                    <asp:TextBox ID="txtAddName" runat="server" MaxLength="50" placeholder="Title"></asp:TextBox><asp:RequiredFieldValidator ID="rfvTopic" runat="server" ErrorMessage="*" ControlToValidate ="txtAddName" ValidationGroup ="Add"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="large-8 columns">
                                	<label>Description</label>
                                  
                                         <asp:TextBox ID="txtAddDescription" placeholder="Description" runat="server" MaxLength="2147483647" TextMode="MultiLine" class="auto" cols="" rows="6"></asp:TextBox>
                                </div>
                            </div>
                          
                            <div class="row">
                            	<div class="large-8 columns">
                             
                                        <asp:Button ID="BtnSave" class="small radius button" runat="server" Text="Save"   ValidationGroup ="Add" />
                            <asp:Button ID="btnCancelNewItem" class="small radius button" runat="server" Text="Cancel"   CausesValidation ="false" />   
                      
                                </div>
                            </div>
                    
                      
                        
                      
                            </asp:Panel>
                              
                             <!--- View --> 
                             <asp:Panel ID="Panel4" runat="server"   Visible="false" >
                             <div class="row">
                            	<div class="large-8 columns">
                                	<label>Title</label>
                                    <asp:TextBox ID="txtClientName" runat="server" MaxLength="50"  Width="200px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate ="txtClientName" ValidationGroup ="Update"></asp:RequiredFieldValidator>
                                 </div>
                            </div>
                            <div class="row">
                            	<div class="large-8 columns">
                                	<label>Description</label>
                                   <asp:TextBox ID="txtDescription"     runat="server" MaxLength="2147483647"  Width="400px" Height="200px"     TextMode="MultiLine"></asp:TextBox>
                                 </div>
                            </div>
                          
                            <div class="row">
                            	<div class="large-8 columns">
                                 
                     <asp:Button ID="BtnUpdate" runat="server" Text="Save"  ValidationGroup ="Update" Width="64px"  CssClass="small radius button"/>
                             <asp:Button ID="BtnCancel" runat="server" Text="Cancel"   CausesValidation ="false" CssClass="small radius button" /> 

 
                      
                                </div>
                            </div>

                       <%--<h3> <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label> </h3>--%>
                                <asp:HiddenField ID="txtID" runat="server" />
                       
               
                     
                 </asp:Panel>
                     <asp:Panel ID="Panel3" runat="server"  Visible="false" CssClass="table-container" >
                   
                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="small radius button"  />
                     <iframe id="frmProjects" runat="server" height="500px" width="100%"  style="border:0;"></iframe>
                 </asp:Panel>           
             
              </div>
                    
                    
                    
                    
                    
                    
          </div>
    
    </div>
</ContentTemplate>
 </asp:UpdatePanel>    
                
              
              
              


<!-- SQL DataSource --->
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" 
    SelectCommand="SELECT [CompanyID],[CompanyName],[Description] FROM Company" 
    DeleteCommand="sp_DeleteCompany" DeleteCommandType="StoredProcedure" 
    ProviderName="System.Data.SqlClient">
    <DeleteParameters>
        <asp:Parameter Name="CompanyID" Type="Int32" />
    </DeleteParameters>
</asp:SqlDataSource>
<!-- end SQL DataSource --->
</asp:Content>

