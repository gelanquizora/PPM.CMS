<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="Locations.aspx.cs" Inherits="Locations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="./css/prodstyle.css" rel="stylesheet" type="text/css" media="screen">
<link rel="stylesheet" href="./css/touchcarousel.css" />
<link rel="stylesheet" href="./css/prod-light-skin.css" />
<script src="./js/jquery.min.js"></script>
<script src="./js/jquery.touchcarousel-1.1.js"></script>
<script type="text/javascript">
    $(document).ready(function () {

        $("#<%= Panel2.ClientID %>").hide();
    });

    function addnew() {

        $("#<%= Panel1.ClientID %>").fadeOut('slow');
        $("#<%= Panel2.ClientID %>").fadeIn('slow');
        $("#quick_actions").fadeOut('slow');

    }

    function edit() {

        $("#<%= Panel1.ClientID %>").fadeOut('slow');
        $("#<%= Panel2.ClientID %>").fadeIn('slow');


    }

    function view() {

        location.reload();


    }
    function back() {

        $("#<%= Panel2.ClientID %>").fadeOut('slow');
        $("#<%= Panel1.ClientID %>").fadeIn('slow');
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:Panel ID="Panel1" runat="server"  >
  <div id="action_bar">
        <a class="button_big" href="#" onclick="edit();"><span class="iconsweet"></span>Edit</a>
   </div>
<div id="wrapper">
    	<div id="carousel-single-image" class="touchcarousel   minimal-light">       
		<%--  <asp:Repeater ID="Repeater1" runat="server" DataSourceID="dsLocation" >
                    <HeaderTemplate><ul class="touchcarousel-container"></HeaderTemplate>   
                    <ItemTemplate>
                      <li class="touchcarousel-item">
			         <img src='repository/<%#DataBinder.Eval(Container, "DataItem.ImageFile")%>' width="800" height="600" />
                    <span>
                    	<strong><%#DataBinder.Eval(Container, "DataItem.VoiceOver")%></strong><br>
                        <em><%#DataBinder.Eval(Container, "DataItem.Description")%></em>
                    </span>
				</li>
                    </ItemTemplate>
                    <FooterTemplate></ul></FooterTemplate>
                   
                    </asp:Repeater>--%>

                  
                  <asp:Repeater ID="Repeater1" runat="server" DataSourceID="dsLocation" >
                    <HeaderTemplate><ul class="touchcarousel-container"></HeaderTemplate>   
                    <ItemTemplate>
                     
			    
                 <asp:Literal ID="Literal1" Text='<%#DataBinder.Eval(Container, "DataItem.TemplateCMS")%>' runat="server"></asp:Literal>  
				     
                    </ItemTemplate>
                    <FooterTemplate></ul></FooterTemplate>
                   
                    </asp:Repeater> 
                   
                  
          

		</div>
    </div>
    </asp:Panel>
    <script type="text/javascript">
        jQuery(function ($) {

            $("#carousel-single-image").touchCarousel({
                pagingNav: true,
                scrollbar: false,
                directionNavAutoHide: false,
                itemsPerMove: 1,
                loopItems: true,
                directionNav: false,
                autoplay: false,
                autoplayDelay: 2000,
                useWebkit3d: true,
                transitionSpeed: 400
            });
            $("#carousel-single-image").bind('touchstart click', function () {
                e.preventDefault();
                $("#carousel-single-image").click(function () {
                    alert("hello");
                    $('span').delay(500).show('slide', { direction: 'up' }, 500);
                })
            });

        });
    </script>
     <asp:Panel ID="Panel2" runat="server" CssClass="widget_body">
      <div id="action_bar">
         <a class="button_big" href="#" onclick="view();"><span class="iconsweet"></span>View</a> 
      </div>
         <iframe runat="server"  id="frmEntry" width="100%" height="500px"  frameborder="0"></iframe>
   </asp:Panel>

       <asp:SqlDataSource ID="dsLocation" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="sp_SelectLocation" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="PresentationID" 
                QueryStringField="PresentationID" Type="Int32" />
        </SelectParameters>
                  </asp:SqlDataSource>
 
</asp:Content>

