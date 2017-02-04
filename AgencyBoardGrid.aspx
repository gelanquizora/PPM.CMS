<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="AgencyBoardGrid.aspx.cs" Inherits="Master_AgencyBoardGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="./js/jquery.min.js" type="text/javascript"></script>

<script type="text/javascript">
    $(document).ready(function () {

        $("#<%= Panel2.ClientID %>").hide();
    });

    function edit() {

        $("#<%= Panel1.ClientID %>").fadeOut('slow');
        $("#<%= Panel2.ClientID %>").fadeIn('slow');


    }

    function view() {

        $("#<%= Panel1.ClientID %>").fadeIn('slow');
        $("#<%= Panel2.ClientID %>").fadeOut('slow');


    }
    function back() {

        $("#<%= Panel2.ClientID %>").fadeOut('slow');
        $("#<%= Panel1.ClientID %>").fadeIn('slow');
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  

 <asp:Panel ID="Panel1" runat="server">
     <div id="Div1"><a class="button_big" href="#" onclick="edit();"><span class="iconsweet"></span>Edit</a> </div>

<asp:GridView ID="GridView1" runat="server" OnRowCommand ="GridView1_RowCommand" AutoGenerateColumns="False"   BorderWidth="0"  AllowPaging="True" AllowSorting="True" DataKeyNames="AgencyID" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"><Columns>
<asp:BoundField DataField="AgencyID" Visible ="false" InsertVisible="False" />
    <asp:ImageField DataImageUrlField="ImageFile" DataImageUrlFormatString="~/repository/{0}"></asp:ImageField>
 
</Columns>
</asp:GridView>
</asp:Panel>
<asp:Panel ID="Panel2" runat="server">
  <div id="Div2"><a class="button_big" href="#" onclick="view();"><span class="iconsweet"></span>View</a> </div>
         <iframe runat="server"  id="frmEntry" width="100%" height="130px"></iframe>
</asp:Panel>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" 
        SelectCommand="sp_SelectAgencyBoard" ProviderName="System.Data.SqlClient" 
        SelectCommandType="StoredProcedure"></asp:SqlDataSource>

       
</asp:Content>

