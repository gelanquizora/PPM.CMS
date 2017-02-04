<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true"
    CodeFile="DeckLocations_Edit.aspx.cs" Inherits="DeckLocations_Edit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="/terrible1/js/vendor/cl_editor/jquery.cleditor.css" />
    <link rel="stylesheet" href="/terrible1/css/touchcarousel.css" />
    <link rel="stylesheet" href="/terrible1/css/minimal-light-skin.css" />
    <link href="./css/prodstyle.css" rel="stylesheet" type="text/css" media="screen">
    <link rel="stylesheet" href="./css/touchcarousel.css" />
    <link rel="stylesheet" href="./css/prod-light-skin.css" />
    <script src="./js/jquery.min.js" type="text/javascript"></script>
    <script src="./js/jquery.touchcarousel-1.1.js" type="text/javascript"></script>
    <style type="text/css">
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
    </style>
    <script type="text/javascript" language="javascript">
        function UserDeleteConfirmation() {
            if (confirm("Are you sure you want to delete this record?"))
                return true;
            else
                return false;
        }

    </script>
    <style type="text/css">
        .pd_container img
        {
            width: 100px;
            height: auto;
        }
        
        .pd_container h2
        {
            width: 30%;
        }
    </style>
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
                Production Design</div>
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
                    Locations</h6>
                <%--<dl class="tabs left" data-tab>
                        <dd class="active">
                            <a href="#panel2-1"><span class="fontawesome-reorder"></span></a>
                        </dd>
                        <dd>
                            <a href="#panel2-2"><span class="fontawesome-th"></span></a>
                        </dd>
                    </dl>--%>
            </div>
            <div class="content-container">
                <div class="table-container">
                    <div class="tabs-content">
                        <div class="content active" id="panel2-1">
                            <asp:Panel runat="server" ID="Panel1">
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                <asp:Button ID="createNew" CssClass="small radius button" runat="server" Text="Create New"
                                    OnClick="createNew_Click" />
                                    <asp:Button ID="btnBackPreview" CssClass="small radius button" runat="server" Text="Back"
                                    OnClick="btnBackPreview_Click" />
                                <br />
                                <br />
                                <asp:GridView ID="gvLocation" runat="server" OnRowCommand="gvLocation_RowCommand"
                                    AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" DataSourceID="dsLocation" Width="600px">
                                    <Columns>
                                        <%--        <asp:ImageField DataImageUrlField="ImageFile" DataImageUrlFormatString="~/repository/{0}"  ControlStyle-Width="100"  ControlStyle-Height="100"  >
                                </asp:ImageField>--%>
                                        <asp:BoundField DataField="Rank" HeaderText="Rank" SortExpression="Rank" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField HeaderText="File" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%--       <asp:Literal runat="server"  Text='<ul><%# Eval("Template") %></ul>'></asp:Literal>--%>
                                                    <img src='template/<%#DataBinder.Eval(Container, "DataItem.TemplateID")%>.jpg' width="200"
                                                    height="180" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ACTION" ItemStyle-Width="120px">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="lnkEdit" ToolTip='<%# Eval("LocationID") %>' CommandName="edt"
                                                    CommandArgument='<%# Eval("LocationID") %>' runat="server" ImageUrl="~/images/187-pencil.png">
                                                </asp:ImageButton>
                                                <asp:ImageButton ID="lnkDelete" ToolTip='<%# Eval("LocationID") %>' CommandName="del"
                                                    CommandArgument='<%# Eval("LocationID") %>' OnClientClick="return UserDeleteConfirmation();"
                                                    runat="server" ImageUrl="~/images/delete.png"></asp:ImageButton>
                                                <asp:Label ID="lblTemplate" runat="server" Visible="false" Text='<%# Eval("Template")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Found
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                            </asp:Panel>
                            <asp:Panel runat="server" ID="Panel2" Visible="false">
                                <div class="row">
                                    <div class="large-8 columns">
                                        <label>
                                            Choose Template</label>
                                        <asp:DropDownList ID="ddlTemplate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTemplate_SelectedIndexChanged">
                                            <asp:ListItem Text="-Select-" Value="0" />
                                            <asp:ListItem Text="1" Value="~/Template/1.jpg" />
                                            <asp:ListItem Text="2" Value="~/Template/2.jpg" />
                                            <asp:ListItem Text="3" Value="~/Template/3.jpg" />
                                            <asp:ListItem Text="4" Value="~/Template/4.jpg" />
                                            <asp:ListItem Text="5" Value="~/Template/5.jpg" />
                                            <asp:ListItem Text="6" Value="~/Template/6.jpg" />
                                            <asp:ListItem Text="7" Value="~/Template/7.jpg" />
                                            <asp:ListItem Text="8" Value="~/Template/8.jpg" />
                                            <asp:ListItem Text="9" Value="~/Template/9.jpg" />
                                            <asp:ListItem Text="10" Value="~/Template/10.jpg" />
                                            <asp:ListItem Text="11" Value="~/Template/11.jpg" />
                                            <asp:ListItem Text="12" Value="~/Template/12.jpg" />
                                            <asp:ListItem Text="13" Value="~/Template/13.jpg" />
                                            <asp:ListItem Text="14" Value="~/Template/14.jpg" />
                                            <asp:ListItem Text="15" Value="~/Template/15.jpg" />
                                            <asp:ListItem Text="16" Value="~/Template/16.jpg" />
                                            <asp:ListItem Text="17" Value="~/Template/17.jpg" />
                                            <asp:ListItem Text="18" Value="~/Template/18.jpg" />
                                            <asp:ListItem Text="19" Value="~/Template/19.jpg" />
                                            <asp:ListItem Text="20" Value="~/Template/20.jpg" />
                                            <asp:ListItem Text="21" Value="~/Template/21.jpg" />
                                            <asp:ListItem Text="22" Value="~/Template/22.jpg" />
                                        </asp:DropDownList>
                                        <br />
                                        <asp:Image ID="imgTemplate" runat="server" Width="250px" Height="200px" />
                                    </div>
                                </div>
                                <asp:Panel ID="pnlTitle" runat="server">
                                    <div class="row">
                                        <div class="large-8 columns">
                                            <label>
                                                Title 1</label>
                                            <asp:TextBox ID="txtTitle1" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="pnlTitle2" runat="server">
                                    <div class="row">
                                        <div class="large-8 columns">
                                            <label>
                                                Title 1</label>
                                            <asp:TextBox ID="txtTitle2" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <div class="row">
                                    <div class="large-8 columns">
                                        <label>
                                            ImageFile(s):</label>
                                        <asp:Panel ID="pnlImg1" runat="server">
                                            <asp:FileUpload ID="FileUpload2" runat="server" /><asp:Label ID="lblFile" runat="server"></asp:Label>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlImg2" runat="server">
                                            <asp:FileUpload ID="FileUpload22" runat="server" /><asp:Label ID="lblFile22" runat="server"></asp:Label>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlImg3" runat="server">
                                            <asp:FileUpload ID="FileUpload23" runat="server" /><asp:Label ID="lblFile23" runat="server"></asp:Label>
                                        </asp:Panel>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="large-8 columns">
                                        <label>
                                            Rank:</label>
                                        <asp:TextBox ID="txtRank" runat="server" MaxLength="10" Width="50%"></asp:TextBox><asp:RangeValidator
                                            ID="rvRank" runat="server" ControlToValidate="txtRank" ErrorMessage="Not Valid"
                                            MaximumValue="2147483647" MinimumValue="-2147483648" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="123456789"
                                            TargetControlID="txtRank">
                                        </asp:FilteredTextBoxExtender>
                                        <asp:RequiredFieldValidator ID="rfvTopic" runat="server" ErrorMessage="*" ControlToValidate="txtRank"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="large-8 columns">
                                        <label>
                                            <asp:Label ID="lblErrorAdd" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label>
                                        </label>
                                        <asp:Button ID="BtnSave" CssClass="small radius button" runat="server" Text="Save"
                                            OnClick="BtnSave_Click" />&nbsp;&nbsp;<asp:Button ID="BtnCancel" runat="server" Text="Cancel"
                                                CssClass="small radius button" OnClick="BtnCancel_Click" CausesValidation="false" />
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <asp:SqlDataSource ID="dsLocation" runat="server" ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectLocation" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="PresentationID" QueryStringField="PresentationID"
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
