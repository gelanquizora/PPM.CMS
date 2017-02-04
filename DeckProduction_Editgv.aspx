<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true"
    CodeFile="DeckProduction_Editgv.aspx.cs" Inherits="DeckProduction_Editgv" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
    <asp:HiddenField ID="HiddenField3" runat="server" />
    <div class="main-columns">
        <div class="container">
            <div class="top-title">
                <h6>
                    Production Design</h6>
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
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
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
                                            Title 2</label>
                                        <asp:TextBox ID="txtTitle2" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </asp:Panel>
                            <div class="row">
                                <div class="large-8 columns">
                                    <label>
                                        ImageFile(s):</label>
                                    <asp:Panel ID="pnlImg1" runat="server">
                                        <asp:Image ID="Image1" runat="server" Width="150px" />
                                        <asp:FileUpload ID="FileUpload2" runat="server" /><asp:Label ID="lblFile" runat="server"></asp:Label><asp:Label
                                            ID="lblImagePath" runat="server" Visible="false"></asp:Label>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlImg2" runat="server">
                                        <asp:Image ID="Image2" runat="server" Width="150px" />
                                        <asp:FileUpload ID="FileUpload22" runat="server" /><asp:Label ID="lblFile22" runat="server"></asp:Label><asp:Label
                                            ID="lblImagePath22" runat="server" Visible="false"></asp:Label>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlImg3" runat="server">
                                        <asp:Image ID="Image3" runat="server" Width="150px" />
                                        <asp:FileUpload ID="FileUpload23" runat="server" /><asp:Label ID="lblFile23" runat="server"></asp:Label><asp:Label
                                            ID="lblImagePath23" runat="server" Visible="false"></asp:Label>
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
                                        <asp:Label ID="lblErrorAdd" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label></label>
                                    <asp:Button ID="BtnUpdate" runat="server" Text="Save" CssClass="small radius button"
                                        OnClick="BtnUpdate_Click"/>&nbsp;&nbsp;<asp:Button ID="BtnCancel" CssClass="small radius button"
                                            runat="server" Text="Cancel" OnClick="BtnCancel_Click" CausesValidation="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
