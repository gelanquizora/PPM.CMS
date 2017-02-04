<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true" CodeFile="Clients.aspx.cs" Inherits="Clients" %>

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
                    <a href="Clients.aspx" class="selected">Clients</a>
                </li>
                <li class="projects">
                    <a href="#">Projects</a>
                </li>
            </ul>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    	<div class="main-columns">
        	<div class="container">
               <div class="top-title">
                    	    <h6 class="large-12 medium-12 left">Client</h6>
                        </div>
               <div class="content-container">
                    	 
                            <asp:Button ID="btnAddNew"  CssClass="small radius button" runat="server" Text="Add New Item" OnClick="createNew_Click" /> 
                            <br>
                            <br>
                        
                        	 <asp:Panel ID="Panel1" runat="server" CssClass="table-container">
                  
                        <asp:GridView ID="GridView1" OnRowCommand ="GridView1_RowCommand" 
                        	Width="100%" runat="server" 
                            AutoGenerateColumns="False" 
                        	AllowPaging="True" 
                            AllowSorting="True" 
                            DataKeyNames="ClientID" 
                            DataSourceID="SqlDataSource1"
                        	OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="ClientID" HeaderText="ClientID" Visible="False" InsertVisible="False" ReadOnly="True" SortExpression="ClientID" />
                            <asp:BoundField DataField="ClientName" HeaderText="Client Name" InsertVisible="False" SortExpression="ClientName" />
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <a href='Decks.aspx?ClientID=<%# Eval("ClientID") %>'>
                                   
                                    <asp:LinkButton ID="lnkView" runat="server"  CssClass="fontawesome-search icon-actions"  CommandName="view" ToolTip="View Details"
                                        CommandArgument='<%# Eval("ClientID") %>'  ></asp:LinkButton>
                                  <asp:LinkButton ID="lnkProjects" runat="server"  CssClass="fontawesome-book icon-actions"  CommandName="projects" ToolTip="View Projects"
                                        CommandArgument='<%# Eval("ClientID") %>'  ></asp:LinkButton>
                                     <asp:LinkButton ID="lnkEdit" runat="server"  CssClass="fontawesome-pencil icon-actions"  CommandName="edt" ToolTip="Edit Details"
                                        CommandArgument='<%# Eval("ClientID") %>'  ></asp:LinkButton>
                                              <asp:LinkButton ID="lnkDelete" runat="server"  CssClass="fontawesome-remove icon-actions"  CommandName="del" ToolTip="Delete"
                                        CommandArgument='<%# Eval("ClientID") %>'  OnClientClick="return confirm('Are you sure you want to delete this porject?');" ></asp:LinkButton>
                                              
                                <%--              
                                               <asp:LinkButton ID="lnkIpadUsers" runat="server"  CssClass="fontawesome-tablet icon-actions"  CommandName="viewUsers" ToolTip="View Ipad Users"
                                        CommandArgument='<%# Eval("ClientID") %>'    ></asp:LinkButton>
                                              
                                               <asp:LinkButton ID="lnkCMSUsers" runat="server"  CssClass="fontawesome-user icon-actions"  CommandName="viewCMSUsers" ToolTip="View CMS Users"
                                        CommandArgument='<%# Eval("ClientID") %>'  ></asp:LinkButton>--%>
                                              
  
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle HorizontalAlign = "Right" CssClass="GridPager" />
                        <EmptyDataTemplate>
                            No Record Found.
                        </EmptyDataTemplate>
                        <HeaderStyle ForeColor="Black" />
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
                             
                                        <asp:Button ID="BtnSave" class="small radius button" runat="server" Text="Save" onclick="BtnSave_Click" ValidationGroup ="Add" />
                            <asp:Button ID="btnCancelNewItem" class="small radius button" runat="server" Text="Cancel" onclick="btnCancelNewItem_Click" CausesValidation ="false" />   
                      
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
                                 
                     <asp:Button ID="BtnUpdate" runat="server" Text="Save" onclick="BtnUpdate_Click" ValidationGroup ="Update" Width="64px"  CssClass="small radius button"/>
                             <asp:Button ID="BtnCancel" runat="server" Text="Cancel" onclick="BtnCancelEdit_Click" CausesValidation ="false" CssClass="small radius button" /> 

 
                      
                                </div>
                            </div>

                       <%--<h3> <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label> </h3>--%>
                                <asp:HiddenField ID="txtID" runat="server" />
                       
               
                     
                 </asp:Panel>
                     <asp:Panel ID="Panel3" runat="server"  Visible="false" CssClass="table-container" >
                   
                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="small radius button" 
                             onclick="btnBack_Click"/>
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
        ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectClientGridByCompany" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="CompanyID" SessionField="CompanyID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
<!-- end SQL DataSource --->
</asp:Content>

