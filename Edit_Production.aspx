<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true"
    CodeFile="Edit_Production.aspx.cs" Inherits="Edit_Production" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table cellpadding="2" border="0">
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <tr>
            <td>
                Choose Template
            </td>
            <td>
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
            </td>
        </tr>
        <asp:Panel ID="pnlTitle" runat="server">
            <tr>
                <td>
                    Title 1
                </td>
                <td>
                    <asp:TextBox ID="txtTitle1" runat="server"></asp:TextBox>
                </td>
            </tr>
        </asp:Panel>
        <asp:Panel ID="pnlTitle2" runat="server">
            <tr>
                <td>
                    Title 2
                </td>
                <td>
                    <asp:TextBox ID="txtTitle2" runat="server"></asp:TextBox>
                </td>
            </tr>
        </asp:Panel>
        <tr>
            <td>
                ImageFile(s):
            </td>
            <td style="width: 100px">
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
            </td>
        </tr>
        <tr>
            <td>
                Rank:
            </td>
            <td style="width: 100px">
                <asp:TextBox ID="txtRank" runat="server" MaxLength="10" Width="50%"></asp:TextBox><asp:RangeValidator
                    ID="rvRank" runat="server" ControlToValidate="txtRank" ErrorMessage="Not Valid"
                    MaximumValue="2147483647" MinimumValue="-2147483648" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="123456789"
                    TargetControlID="txtRank">
                </asp:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="rfvTopic" runat="server" ErrorMessage="*" ControlToValidate="txtRank"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblErrorAdd" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Button ID="BtnUpdate" runat="server" Text="Save" class="button_small whitishBtn"
                    OnClick="BtnUpdate_Click" Width="64px" /><asp:Button ID="BtnCancel" class="button_small whitishBtn"
                        runat="server" Text="Cancel" OnClick="BtnCancel_Click" CausesValidation="false" />
            </td>
        </tr>
    </table>
</asp:Content>
