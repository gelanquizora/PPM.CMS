<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true"
    CodeFile="ProductionDesign.aspx.cs" Inherits="ProductionDesign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="./css/prodstyle.css" rel="stylesheet" type="text/css" media="screen">
    <link rel="stylesheet" href="./css/touchcarousel.css" />
    <link rel="stylesheet" href="./css/prod-light-skin.css" />
    <script src="./js/jquery.min.js" type="text/javascript"></script>
    <script src="./js/jquery.touchcarousel-1.1.js" type="text/javascript"></script>
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel1" runat="server">
        <div id="action_bar">
            <a class="button_big" href="#" onclick="edit();"><span class="iconsweet"></span>Edit</a>
        </div>
        <div id="carousel-single-image" class="touchcarousel   minimal-light">
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="dsProduction">
                <HeaderTemplate>
                    <ul class="touchcarousel-container">
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Literal Text='<%#DataBinder.Eval(Container, "DataItem.TemplateCMS")%>' runat="server"></asp:Literal>
                </ItemTemplate>
                <FooterTemplate>
                    </ul></FooterTemplate>
            </asp:Repeater>
        </div>
        <%--          <iframe id="frmView" runat="server" width="90%" height="900px"  frameborder="0" ></iframe>--%>
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
        <iframe runat="server" id="frmEntry" width="100%" height="500px" frameborder="0">
        </iframe>
    </asp:Panel>
    <!-- SQL DataSource --->
    <asp:SqlDataSource ID="dsProduction" runat="server" ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectProduction" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="PresentationID" QueryStringField="PresentationID"
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <!--end SQL DataSource --->
</asp:Content>
