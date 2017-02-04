<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NewMasterPage.master" AutoEventWireup="true" CodeFile="Decks.aspx.cs" Inherits="Decks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" Runat="Server">


<script src="./js/jquery.min.js" type="text/javascript"></script>
<script type="text/javascript">
//    $(document).ready(function () {

////        $("#<%= Panel3.ClientID %>").hide();
////        $("#<%= Panel2.ClientID %>").hide();
//    });
    function back() {

        $("#<%= Panel2.ClientID %>").show();
        $("#<%= Panel1.ClientID %>").show();
        $("#<%= Panel3.ClientID %>").hide();
       
    }
    function pageselected() {

    
        $("#<%= Panel1.ClientID %>").hide();
        $("#<%= Panel2.ClientID %>").show();
        $("#<%= Panel3.ClientID %>").hide();
       
    }

    function edititem() {
        $("#<%= Panel3.ClientID %>").show();
        $("#<%= Panel2.ClientID %>").hide();
        $("#<%= Panel1.ClientID %>").hide();
 
       
    }

   

    function viewitem() {


        $("#<%= Panel3.ClientID %>").hide();
        $("#<%= Panel2.ClientID %>").show();
        $("#<%= Panel1.ClientID %>").hide();
    }


     

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrimary_Nav" Runat="Server">
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeftSub" Runat="Server">
     <asp:Literal ID="ltPages" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
 

      <asp:Panel ID="quick_actions" runat="server">
                        <asp:Button ID="btnAddNew"  CssClass="button_big" runat="server" Text="Add New Item" OnClick="createNew_Click" /> 
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server">
  
	  <!--One_Wrap-->
      <div class="one_wrap">
            <div class="widget">
                 <div class="widget_title"><span class="iconsweet">H</span><h5>Projects</h5></div>
                  <div class="widget_body">
            	<div class="project_sort">
                	<ul class="filter_project">
                    	<li class="segment  selected"><a class="all"  >All  <asp:Label ID="lblAllCount" CssClass="count" runat="server" Text="0"></asp:Label> </a></li>
                     <%--   <li class="segment"><a class="incomplete" href="#">New<span class="count">3</span></a></li>
                        <li class="segment"><a class="Resolved" href="#">Incomplete<span class="count">3</span></a></li>--%>
                     </ul>
                    

                    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" >
                    <HeaderTemplate><ul class="project_list"></HeaderTemplate>   
                    <ItemTemplate>
                        <li data-id="id-1" data-type="incomplete">
                        	<span class="project_badge red iconsweet">
                            4
                            </span>
                            <br />
                        
                           <a class="project_title" href='Decks.aspx?PresentationID=<%# Eval("PresentationID") %>&ClientID=<%# Eval("ClientID") %>'><%#DataBinder.Eval(Container, "DataItem.Title")%> </a>
                            <a href="#" class="assigned_user">
                            	<span class="iconsweet">a</span>Author
                            </a>   
                             <span style="visibility:hidden"><%#DataBinder.Eval(Container, "DataItem.PresentationID")%></span></li>
                    </ItemTemplate>
                    <FooterTemplate></ul></FooterTemplate>
                   
                    </asp:Repeater>

                </div>
            </div>
           </div>
      </div>
      </asp:Panel>

    <asp:Panel ID="Panel2" runat="server"  Visible="false" >
    
	  <!--One_Wrap-->
      <div class="one_wrap">
            <div class="widget">
                <div class="widget_body">
                    <iframe runat="server"  id="frmPage" width="100%" height="800px"></iframe>
                    
     </div>
       </div>
      </div>
 </asp:Panel>
    <asp:Panel ID="Panel3" runat="server"  Visible="false">
  <%--   <div id="quick_back"><a class="button_big" href="#" onclick="viewitem();"><span class="iconsweet">8</span>View</a> </div>--%>

             <iframe id="frmEntry" width="100%" height="800px"   runat="server"></iframe>
    </asp:Panel>
    <asp:Panel ID="Panel5" runat="server" CssClass="widget_body" Visible="false">
        <div class="one_wrap">
            <div class="widget">
                <div class="widget">
            <div class="widget_title"><span class="iconsweet">|</span>
                <h5>Add Project</h5>
            </div>
                <div class="widget_body">
                     <div class="content_pad">
                        <ul class="form_fields_container">
                            <li><label>Title</label> <div class="form_input"><asp:TextBox ID="txtTitle" runat="server" MaxLength="50" ></asp:TextBox></div></li>
                            <li><label>Description:</label> <div class="form_input">
                                <asp:TextBox ID="txtDescription" runat="server" MaxLength="2147483647"  
                    Width="400px" Height="200px" TextMode="MultiLine"></asp:TextBox>
                            </div></li>
                            <li><label>Select</label> <div class="form_input">
                           <asp:DropDownList ID="ddlClient" runat="server" DataSourceID ="SqlDataSource2" 
                    DataTextField ="ClientName" DataValueField ="ClientID">
                </asp:DropDownList>
                                
                        
                            </li>
                              <li>
                           <asp:Label ID="lblBuild" runat="server" Text="dsd"></asp:Label>
                      </li>
                                <li> 
                                   
                                  <asp:Button ID="btnGenerateBuild" CssClass="button_small whitishBtn" runat="server" Text="Generate New Build"  OnClick="btnGenerateBuild_Click"/> </li>
                    
                        </ul>
                </div>
                 <div class="action_bar">
                      <asp:Button ID="BtnSave" class="button_small whitishBtn" runat="server" Text="Save" onclick="BtnSave_Click" />
                      <asp:Button ID="btnCancelNewItem" class="button_small whitishBtn" runat="server" Text="Cancel" onclick="btnCancelNewItem_Click" />   
                 </div>
</div>
</div>
</div>
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



