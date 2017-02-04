<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

<ul class="main-nav">
                <li class="home">
                    <a href="#" class="selected">Home</a>
                </li>
                <li class="clients">
                    <a href="Clients.aspx">Clients</a>
                </li>
                <li class="projects">
                    <a href="#">Projects</a>
                </li>
            </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <div class="main-columns">
            	<div class="container">
                	<div class="top-title">
                    	<h6>welcome to ppm site!</h6>
                    </div>
                    <div class="content-container"></div>
                </div>
            </div>
</asp:Content>

