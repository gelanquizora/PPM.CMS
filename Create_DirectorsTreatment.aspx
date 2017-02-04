<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="Create_DirectorsTreatment.aspx.cs" Inherits="Create_DirectorsTreatment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<table cellpadding="2" border="0">

<tr><td>ImageFile:</td><td  style="width:100px"><asp:FileUpload ID="FileUpload2" runat="server" /><asp:Label ID="lblFile" runat="server"></asp:Label>
</td>
</tr>

<tr><td>VoiceOver:</td><td  style="width:100px"><asp:TextBox ID="txtVoiceOver" 
        runat="server" MaxLength="50"  Width="200px" ></asp:TextBox>
</td>
</tr>
<tr><td>Description:</td><td  style="width:100px"><asp:TextBox ID="txtDescription" 
        runat="server" MaxLength="2147483647"  Width="400px" Height="200px"   
        TextMode="MultiLine"></asp:TextBox>
</td>
</tr>
<tr><td>Panel No:</td><td  style="width:100px"><asp:TextBox ID="txtRank" runat="server" MaxLength="10"  Width="50%"></asp:TextBox><asp:RangeValidator ID="rvRank" runat="server" ControlToValidate="txtRank" ErrorMessage="Not Valid" MaximumValue="2147483647" MinimumValue="-2147483648" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
   <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="123456789"
                                    TargetControlID="txtRank">
                                </asp:FilteredTextBoxExtender>

</td>
</tr>




<tr><td><asp:Label ID="lblErrorAdd" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label></td><td><asp:Button ID="BtnSave" runat="server" Text="Save" onclick="BtnSave_Click" Width="64px" /></td></tr></table>

</asp:Content>

