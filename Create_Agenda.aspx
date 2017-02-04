<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Create_Agenda.aspx.cs" Inherits="Master_Create_Agenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="2" border="0">
<tr><td>AgendaID:</td><td style="width:50px"><span style="color:white;">*</span></td><td  style="width:100px"><asp:TextBox ID="txtAgendaID" runat="server" MaxLength="10"  Width="50%"></asp:TextBox>
</td><td><asp:RangeValidator ID="rvAgendaID" runat="server" ControlToValidate="txtAgendaID" ErrorMessage="Not Valid" MaximumValue="2147483647" MinimumValue="-2147483648" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
</td><td><asp:RequiredFieldValidator ID="RfvAgendaID" ControlToValidate="txtAgendaID" ErrorMessage="AgendaID is required." Display="Dynamic" runat="server" />
</td>
</tr>
<tr><td>AgendaTitle:</td><td style="width:50px"><span style="color:white;">*</span></td><td  style="width:100px"><asp:TextBox ID="txtAgendaTitle" runat="server" MaxLength="50"  Width="80%"></asp:TextBox>
</td><td></td>
</tr>
<tr><td>AgendaPage:</td><td style="width:50px"><span style="color:white;">*</span></td><td  style="width:100px"><asp:TextBox ID="txtAgendaPage" runat="server" MaxLength="2147483647"  Width="80%"></asp:TextBox>
</td><td></td>
</tr>
<tr><td>AgendaFileName:</td><td style="width:50px"><span style="color:white;">*</span></td><td  style="width:100px"><asp:TextBox ID="txtAgendaFileName" runat="server" MaxLength="50"  Width="80%"></asp:TextBox>
</td><td></td>
</tr>
<tr><td>CreatedBy:</td><td style="width:50px"><span style="color:white;">*</span></td><td  style="width:100px"><asp:TextBox ID="txtCreatedBy" runat="server" MaxLength="50"  Width="80%"></asp:TextBox>
</td><td></td>
</tr>
<tr><td>CreatedDate:</td><td style="width:50px"><span style="color:white;">*</span></td><td  style="width:100px"><asp:Calendar ID="calCreatedDate" runat="server"></asp:Calendar>
</td><td></td><td></td>
</tr>
<tr><td>ModifiedBy:</td><td style="width:50px"><span style="color:white;">*</span></td><td  style="width:100px"><asp:TextBox ID="txtModifiedBy" runat="server" MaxLength="50"  Width="80%"></asp:TextBox>
</td><td></td>
</tr>
<tr><td>ModifiedDate:</td><td style="width:50px"><span style="color:white;">*</span></td><td  style="width:100px"><asp:Calendar ID="calModifiedDate" runat="server"></asp:Calendar>
</td><td></td><td></td>
</tr>
<tr><td>&nbsp;</td><td><asp:Button ID="BtnSave" runat="server" Text="Save" onclick="BtnSave_Click" Width="64px" /><asp:Button ID="BtnCancel" runat="server" Text="Cancel" onclick="BtnCancel_Click" /></td></tr></table>
</asp:Content>

