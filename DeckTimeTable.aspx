<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true"
    CodeFile="DeckTimeTable.aspx.cs" Inherits="DeckTimeTable" %>

<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
    <link rel="stylesheet" href="/terrible1/js/vendor/cl_editor/jquery.cleditor.css" />
    <script src="./js/jquery.min.js" type="text/javascript"></script>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <ul>
        <li class="blue-box"><a href="#">
            <div class="box-inside">
                <span class="iconicfill-movie icon-side-bar"></span>
            </div>
            <div class="box-title">
                Timetable</div>
        </a></li>
        <li class="red-box"><a href="#" runat="server" id="btnBack">
            <div class="box-inside">
                <span class="fontawesome-circle-arrow-left icon-side-bar"></span>
            </div>
            <div class="box-title">
                back</div>
        </a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main-columns">
        <div class="container">
            <div class="top-title">
                <h6>
                    Timetable</h6>
            </div>
            <div class="content-container">
                <div class="table-container">
                    <div class="tabs-content">
                        <div class="content active" id="panel2-1">
                            <iframe runat="server" id="frmEntry" width="100%" height="898" frameborder="0">
                            </iframe>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
