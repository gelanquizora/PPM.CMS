<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Create_Users.aspx.cs" Inherits="Master_Create_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="rightColumn" class="right">
        <div class="left rc_left">
            <h3>
                Add New User</h3>
        </div>
             <br />
        <table cellpadding="2" border="0">
            <tr>
                <td>
                    UserName:
                </td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtUserName" runat="server" MaxLength="50" Width="200px"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate ="txtUserName" ValidationGroup ="add"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Password:
                </td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="50" Width="200px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate ="txtPassword" ValidationGroup ="add"></asp:RequiredFieldValidator>
                </td>
            </tr>
                        <tr>
                <td>
                    Email:
                </td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate ="txtEmail" ValidationGroup ="add"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    FirstName:
                </td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtFirstName" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    LastName:
                </td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Role:
                </td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddlRoles" runat="server" DataSourceID="dsRoles" DataTextField="RoleName"
                        DataValueField="RoleID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="dsRoles" runat="server" ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                        ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectRoles" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                </td>
            </tr>


            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="BtnSave" runat="server" ValidationGroup ="add" Text="Save" OnClick="BtnSave_Click" Width="64px" /><asp:Button
                        ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" CausesValidation ="false" />
                </td>
            </tr>
        </table>
        <asp:Label ID="CreateAccountResults" runat="server"></asp:Label>
    </div>
</asp:Content>

