<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NewMasterpage.master" AutoEventWireup="true" CodeFile="ProjectGridMaster.aspx.cs" Inherits="ProjectGridMaster" %>
 
 
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderHead" Runat="Server">
 <script type="text/javascript">

     function defaultview() {
         $("#<%= Panel2.ClientID %>").hide();
     }
     function addnew() {

         $("#<%= Panel1.ClientID %>").hide();
         $("#<%= Panel2.ClientID %>").show();
         $("#quick_actions").hide();

     }

     function back() {

         $("#<%= Panel2.ClientID %>").hide();
         $("#<%= Panel1.ClientID %>").show();

         $("#quick_actions").show();


     }
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderPrimary_Nav" Runat="Server">
  <ul>
            <li class="nav_dashboard" ><a href="Default.aspx">Dashboard</a></li>
            <li class="nav_clients"><a href="ClientGrid.aspx">Clients</a></li>
            <li class="nav_projects active"><a href="">Projects</a></li>
            <li class="nav_decks" ><a href="Decks.aspx">Decks</a></li>
        </ul>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderLeftSub" Runat="Server">
    <asp:Literal ID="ltPages" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">

     <!--Quick Actions-->
        <div id="quick_actions">
        	<a class="button_big" href="#" onclick="addnew();"><span class="iconsweet">+</span>Add new Project</a>
            <!--<a class="button_big btn_grey" href="#"><span class="iconsweet">f</span>Manage Projects</a>-->
        </div>
	 
	   
	<!--One_Wrap-->
 	<div class="one_wrap">
    	<div class="widget">
        	<div class="widget_title"><span class="iconsweet">f</span><h5>Projects</h5></div>
        
            	 
         <asp:Panel ID="Panel1" runat="server" CssClass="widget_body">
         	<asp:GridView ID="GridView1" width="100%" runat="server" AutoGenerateColumns="False"   CssClass="activity_datatable"  
                   AllowPaging="True" AllowSorting="True" DataKeyNames="ProjectID" 
                   DataSourceID="SqlDataSource1" 
                   onselectedindexchanged="GridView1_SelectedIndexChanged" OnRowCommand ="GridView1_RowCommand"><Columns>
                    <asp:BoundField DataField="ProjectID" Visible ="False" HeaderText="ProjectID" InsertVisible="False" ReadOnly="True" SortExpression="ProjectID" />
                    <asp:BoundField DataField="ProjectName" HeaderText="Project Name" InsertVisible="False" SortExpression="ProjectName" />

                    <asp:TemplateField HeaderText="Actions">
                                        <ItemTemplate>
                                            <a href='PresentationGridMaster.aspx?id=<%# Eval("ProjectID") %>'>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/06-magnify.png" /></a>
                                            <a href='View_Project.aspx?ProjectID=<%# Eval("ProjectID") %>'>
                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/pages.png" /></a> 
                                                <a href='Edit_Project.aspx?ProjectID=<%# Eval("ProjectID") %>'>
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/187-pencil.png" /></a>
                                            <asp:ImageButton ID="lnkDelete" ToolTip='<%# Eval("ProjectID") %>' CommandName="del"
                                                CommandArgument='<%# Eval("ProjectID") %>' OnClientClick="return UserDeleteConfirmation();" runat="server" ImageUrl="~/images/delete.png">
                                            </asp:ImageButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>  No Record Found.</EmptyDataTemplate>
             <HeaderStyle Font-Names="helvetica" ForeColor="Black" />
            </asp:GridView>
            <div class="action_bar">
                  <!--- <a class="button_small whitishBtn" href="#"><span class="iconsweet">l</span>Export Table</a> --->
                </div>
         </asp:Panel>
         <asp:Panel ID="Panel2" runat="server" CssClass="widget_body">
                    <iframe id="frmEntry" width="100%" height="800px" src="Create_Project.aspx"></iframe>
         </asp:Panel>
        
        </div>
    </div>    
    
   

     

   <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectProjectGridMaster" 
        SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
 
</asp:Content>



 

