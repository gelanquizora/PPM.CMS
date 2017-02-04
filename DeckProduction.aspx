<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true"
    CodeFile="DeckProduction.aspx.cs" Inherits="DeckProduction" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="/terrible1/js/vendor/cl_editor/jquery.cleditor.css" />
    <%--<link rel="stylesheet" href="/terrible1/css/touchcarousel.css" />--%>
    <link rel="stylesheet" href="/terrible1/css/minimal-light-skin.css" />
    <link href="./css/prodstyle.css" rel="stylesheet" type="text/css" media="screen">
    <link rel="stylesheet" href="./css/touchcarousel.css" />
    <link rel="stylesheet" href="./css/prod-light-skin.css" />
    <script src="./js/jquery.min.js" type="text/javascript"></script>
    <script src="./js/jquery.touchcarousel-1.1.js" type="text/javascript"></script>
    <%--<style type="text/css">
        /*.tc-paging-container{
		display:none;
	}*/.touchcarousel .tc-paging-item
        {
            float: left;
            cursor: pointer;
            position: relative;
            display: block;
            text-indent: inherit;
            color: white;
            background: none !important;
        }
        .touchcarousel.minimal-light .tc-paging-item
        {
            width: 0;
            height: 0;
            -moz-opacity: 0.8;
            -webkit-opacity: 0.8;
            opacity: 0.8;
            color: #242021;
        }
        .touchcarousel.minimal-light .tc-paging-item.current
        {
            color: white;
            text-decoration: none;
            font-size: 16px;
            width: 22px;
            height: 22px;
        }
        .touchcarousel.minimal-light .tc-paging-item:hover
        {
        }
        #carousel-single-image .tc-paging-container
        {
            width: auto;
            margin-top: -89px;
            margin-left: 10px;
        }
        #carousel-single-image .touchcarousel-item span
        {
            display: none;
        }
    </style>--%>
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <ul>
        <li class="blue-box">
        	<a href="#">
              <div class="box-inside">
                  <img src="images/icons/icon-production-design.png" alt="Production Design">
              </div>
        
        	</a>
        </li>
        <li class="red-box">
        	<a href="#" runat="server" id="btnBack">
                <div class="box-inside">
                    <img src="images/icons/icon-back.png" alt="Back">
                </div>
            
        	</a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main-columns">
        <div class="container" style="padding: 0px !important; width: 1030px;" >
            <div class="large-12 medium-12 top-title">
                <h6>Production Design</h6>
                <%--<dl class="tabs left" data-tab>
                        <dd class="active">
                            <a href="#panel2-1"><span class="fontawesome-reorder"></span></a>
                        </dd>
                        <dd>
                            <a href="#panel2-2"><span class="fontawesome-th"></span></a>
                        </dd>
                    </dl>--%>
            </div>
            <div class="content-container" style="padding: 0px !important;">
                <div class="table-container">
                    <div class="tabs-content">
                        <div class="content active" id="panel2-1">
                            <asp:Panel ID="Panel1" runat="server">
                             
                                <asp:Label ID="lblPresentationID" runat="server" Style="display: none" />
                               
                                <asp:Button ID="btnEdit" CssClass="small radius button" runat="server" Text="Edit"
                                    OnClick="BtnEdit_Click" />
                            
                                <br />
                                <br />
                                <div id="carousel-single-image" class="touchcarousel minimal-light">
                                    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="dsProduction">
                                        <HeaderTemplate>
                                            <ul class="touchcarousel-container">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal ID="Literal1" Text='<%#DataBinder.Eval(Container, "DataItem.TemplateCMS")%>'
                                                runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </ul></FooterTemplate>
                                    </asp:Repeater>
                                </div>
                                <%--          <iframe id="frmView" runat="server" width="90%" height="900px"  frameborder="0" ></iframe>--%>
                            </asp:Panel>
                            <asp:Panel ID="Panel2" runat="server" CssClass="widget_body">
                                <div id="action_bar">
                                    <a class="button_big" href="#" onclick="view();"><span class="iconsweet"></span>View</a>
                                </div>
                                <iframe runat="server" id="frmEntry" width="100%" height="500px" frameborder="0">
                                </iframe>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
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
