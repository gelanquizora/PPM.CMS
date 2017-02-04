<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true" CodeFile="Projects.aspx.cs" Inherits="Projects" %>

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
                    <a href="Clients.aspx" >Clients</a>
                </li>
                <li class="projects">
                    <a href="#" class="selected">Projects</a>
                </li>
            </ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="main-columns">
            	<div class="container">
                	<div class="top-title">
                    	<h6>Projects</h6>
                    </div>
                    <div class="content-container">
                     
                          <asp:Button ID="btnAddNew"  CssClass="small radius button" runat="server" Text="Add New Item" OnClick="createNew_Click" /> 
                        <br />
                        <br />
    
                           <asp:Panel ID="Panel1" runat="server" CssClass="project_sort">
                        
                            <ul class="filter_project">
                                <li class="segment  selected"><a class="all" href="Clients.aspx">All   <asp:Label ID="lblAllCount" runat="server" Text="0" CssClass="count"></asp:Label></a></li>
                               
                             </ul>
                                 <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" >
                    <HeaderTemplate><ul class="project_list"></HeaderTemplate>   
                    <ItemTemplate>
                     <li data-id="id-1" data-type="incomplete">
                                    <div class="project_badge red"><span class="icon-box entypo-mic"></span></div>
                                 

                                      <a class="project_title" href='ProjectInside.aspx?PresentationID=<%# Eval("PresentationID") %>&ClientID=<%# Eval("ClientID") %>'><%#DataBinder.Eval(Container, "DataItem.Title")%> </a>
                                      <a href="#" class="assigned_user">
                                        <span class="fontawesome-user icon-box-name"></span>Author
                                    </a>  
                                    <span style="visibility:hidden"><%#DataBinder.Eval(Container, "DataItem.PresentationID")%></span>                      
                      </li>
     
                         
                    </ItemTemplate>
                    <FooterTemplate></ul></FooterTemplate>
                   
                    </asp:Repeater>
            
	 
                        </asp:Panel>

                           <asp:Panel ID="Panel2" runat="server"  Visible="false" >
                                
                         <iframe runat="server"  id="frmPage" width="100%" height="800px"></iframe>
                        </asp:Panel>
                       <asp:Panel ID="Panel5" runat="server"  Visible="false" >
                              <div class="row">
                            	<div class="large-8 columns">
                                	<label>Title</label>
                                      <asp:TextBox ID="txtTitle" runat="server" MaxLength="50" ></asp:TextBox><asp:RequiredFieldValidator ID="rfvTopic" runat="server" ErrorMessage="*" ControlToValidate ="txtTitle" ValidationGroup ="Add"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="large-8 columns">
                                	<label>Description</label>
                                    <asp:TextBox ID="txtDescription" runat="server" MaxLength="2147483647"      Width="400px" Height="200px" TextMode="MultiLine"></asp:TextBox>
                                 </div>
                            </div>
                               <div class="row">
                            	<div class="large-8 columns">
                                	<label>Select</label>
                                  <asp:DropDownList ID="ddlClient" runat="server" DataSourceID ="SqlDataSource2"     DataTextField ="ClientName" DataValueField ="ClientID">
                                     </asp:DropDownList>
                                  </div>
                            </div>

                               <div class="row">
                            	<div class="large-8 columns">
                                	<label>Last build</label>
                                          <asp:Label ID="lblBuild" runat="server" Text=""></asp:Label>
                                 </div>
                            </div>

                            <div class="row">
                            	<div class="large-8 columns">
                                    <asp:Button ID="BtnSave" class="small radius button" runat="server" Text="Save" onclick="BtnSave_Click"  ValidationGroup ="Add"/>
                                    <asp:Button ID="btnCancelNewItem" class="small radius button" runat="server" Text="Cancel" onclick="btnCancelNewItem_Click" />   
                                 <%--   <asp:Button ID="btnGenerateBuild" class="small radius button" runat="server" Text="Generate New Build"  OnClick="btnGenerateBuild_Click"/>  
    --%>
                                </div> 
                            </div>
                    
                      
                        
                      
                            </asp:Panel>

            </div>
      </div>
</div>
 
 
 

   
 
    <asp:Panel ID="Panel3" runat="server"  Visible="false">
  <%--   <div id="quick_back"><a class="button_big" href="#" onclick="viewitem();"><span class="iconsweet">8</span>View</a> </div>--%>

             <iframe id="frmEntry" width="100%" height="800px"   runat="server"></iframe>
    </asp:Panel>
 

   <asp:Panel runat="server" ID="Panel6" Visible="false">
    <asp:Button ID="btnEdit" CssClass="button_big" runat="server" Text="Edit"  OnClick="BtnEdit_Click"/>
    <div class="one_wrap">
            <div class="widget">
                <div class="widget">
            <div class="widget_title"><span class="iconsweet">n</span>
                <h5>Projects</h5>
            </div>
                <div class="widget_body">
                     <div class="content_pad">
                     <asp:Label ID="lblPresentationID" runat="server" style="display:none" />
                        <ul class="form_fields_container">
                            <li><label>Title</label> <div class="form_input"><asp:TextBox ID="txtEditTitle" runat="server" MaxLength="50" ></asp:TextBox></div></li>
                            <li><label>Description:</label> <div class="form_input">
                                <asp:TextBox ID="txtEditDescription" runat="server" MaxLength="2147483647"  
                    TextMode="MultiLine"></asp:TextBox>
                            </div></li>
                            <li><label>Project</label> <div class="form_input">
                           <asp:DropDownList ID="ddlClientEdit" runat="server" DataSourceID ="SqlDataSource2" 
                    DataTextField ="ClientName" DataValueField ="ClientID">
                </asp:DropDownList>
                                
</li>

                    <li> 
                           
                                  <asp:Button ID="Button1" CssClass="button_small whitishBtn" runat="server" Text="Generate New Build"  OnClick="btnGenerateBuild_Click"/> </li>
                      <li>
                                      <asp:Label ID="lblGenerateBuildAdd" runat="server" Text=""></asp:Label>
                            </li>
                        </ul>
   </div>
                        <div class="action_bar">
                      <asp:Button ID="BtnUpdate" class="button_small whitishBtn" runat="server" Text="Save" onclick="BtnUpdate_Click" />
                      <asp:Button ID="BtnCancel" class="button_small whitishBtn" runat="server" Text="Cancel" onclick="BtnCancelEdit_Click" />   
                    </div>             
   </div>
            
   </div>
   </div>
   </div>
   </asp:Panel>
    <!-- DataSource -->
   <asp:SqlDataSource ID="SqlDataSource3" runat="server" OnSelected="SqlDataSource1_Selected" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectPresentationMasterByClient" 
        SelectCommandType="StoredProcedure" DeleteCommand="sp_DeletePresentation" 
        DeleteCommandType="StoredProcedure">
       <DeleteParameters>
           <asp:Parameter Name="PresentationID" Type="Int32" />
       </DeleteParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="ClientID"  Type="Int32" DefaultValue="0" 
                QueryStringField="ClientID"   />
         <asp:SessionParameter Name="CompanyID" SessionField="CompanyID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
 <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                    ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectClientGridByCompany" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="CompanyID" SessionField="CompanyID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>

   <!-- end DataSource -->
   <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                    ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectProject" 
                    SelectCommandType="StoredProcedure"></asp:SqlDataSource>




 
     <!-- DataSource -->
   <asp:SqlDataSource ID="SqlDataSource1" runat="server" OnSelected="SqlDataSource1_Selected" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectPresentationMasterByClient" 
        SelectCommandType="StoredProcedure" DeleteCommand="sp_DeletePresentation" 
        DeleteCommandType="StoredProcedure">
       <DeleteParameters>
           <asp:Parameter Name="PresentationID" Type="Int32" />
       </DeleteParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="ClientID"  Type="Int32" DefaultValue="0" 
                QueryStringField="ClientID"   />
         <asp:SessionParameter Name="CompanyID" SessionField="CompanyID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                    ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectClientGridByCompany" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="CompanyID" SessionField="CompanyID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>

   <!-- end DataSource -->
                         <asp:SqlDataSource ID="dsProject" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                    ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectProject" 
                    SelectCommandType="StoredProcedure"></asp:SqlDataSource>
         
</asp:Content>

