<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="Edit_LocationPanel.aspx.cs" Inherits="Edit_LocationPanel" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<table cellpadding="2" border="0">
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <tr><td>Choose Template</td><td>
       
    <asp:DropDownList ID="ddlTemplate" runat="server" AutoPostBack ="true" 
        onselectedindexchanged="ddlTemplate_SelectedIndexChanged">
        <asp:ListItem Text="-Select-" Value="0" />
    <asp:ListItem Text="1" Value="~/locationImages/1.jpg" />
    <asp:ListItem Text="2" Value="~/locationImages/2.jpg" />
     <asp:ListItem Text="3" Value="~/locationImages/3.jpg" />

      <asp:ListItem Text="4" Value="~/locationImages/4.jpg" />
    <asp:ListItem Text="5" Value="~/locationImages/5.jpg" />
     <asp:ListItem Text="6" Value="~/locationImages/6.jpg" />
      <asp:ListItem Text="7" Value="~/locationImages/7.jpg" />
    <asp:ListItem Text="8" Value="~/locationImages/8.jpg" />
     <asp:ListItem Text="9" Value="~/locationImages/9.jpg" />
      <asp:ListItem Text="10" Value="~/locationImages/10.jpg" />
    <asp:ListItem Text="11" Value="~/locationImages/11.jpg" />
     <asp:ListItem Text="12" Value="~/locationImages/12.jpg" />
      <asp:ListItem Text="13" Value="~/locationImages/13.jpg" />
    <asp:ListItem Text="14" Value="~/locationImages/14.jpg" />
     <asp:ListItem Text="15" Value="~/locationImages/15.jpg" />

     <asp:ListItem Text="16" Value="~/locationImages/16.jpg" />
    <asp:ListItem Text="17" Value="~/locationImages/17.jpg" />
     <asp:ListItem Text="18" Value="~/locationImages/18.jpg" />
       <asp:ListItem Text="19" Value="~/locationImages/19.jpg" />
    <asp:ListItem Text="20" Value="~/locationImages/20.jpg" />
     <asp:ListItem Text="21" Value="~/locationImages/21.jpg" />
      <asp:ListItem Text="22" Value="~/locationImages/22.jpg" />
    </asp:DropDownList><br />
    <asp:Image ID="imgTemplate" runat="server" Width ="250px" Height ="200px" />
</td></tr>

  <asp:Panel ID="pnlTitle" runat="server">
    <tr><td>Title 1</td><td>
        <asp:TextBox ID="txtTitle1" runat="server"></asp:TextBox></td></tr>
    </asp:Panel>

      <asp:Panel ID="pnlTitle2" runat="server">
    <tr><td>Title 2</td><td>
        <asp:TextBox ID="txtTitle2" runat="server"></asp:TextBox></td></tr>
    </asp:Panel>
    <tr>
        
             <td>
            ImageFile(s):
        </td>
        <td style="width: 100px">
        <asp:Panel ID="pnlImg1" runat="server">
            <asp:Image ID="Image1" runat="server" />
            <asp:FileUpload ID="FileUpload2" runat="server" /><asp:Label ID="lblFile" runat="server"></asp:Label><asp:Label
                ID="ImagePath" runat="server" Visible ="false"></asp:Label>
              </asp:Panel>
                      <asp:Panel ID="pnlImg2" runat="server">
                         <asp:Image ID="Image2" runat="server" />
                <asp:FileUpload ID="FileUpload22" runat="server" /><asp:Label ID="lblFile22" runat="server"></asp:Label><asp:Label
                ID="ImagePath22" runat="server" Visible ="false"></asp:Label>
      
          </asp:Panel>
            <asp:Panel ID="pnlImg3" runat="server">
               <asp:Image ID="Image3" runat="server" />
           <asp:FileUpload ID="FileUpload23" runat="server" /><asp:Label ID="lblFile23" runat="server"></asp:Label><asp:Label
                ID="ImagePath23" runat="server" Visible ="false"></asp:Label>
                  </asp:Panel>
        </td>
      
      
 
   
    </tr>


</td>
</tr>
<tr><td>Rank:</td><td  style="width:100px"><asp:TextBox ID="txtRank" runat="server" MaxLength="10"  Width="50%"></asp:TextBox><asp:RangeValidator ID="rvRank" runat="server" ControlToValidate="txtRank" ErrorMessage="Not Valid" MaximumValue="2147483647" MinimumValue="-2147483648" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
   <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="123456789"
                                    TargetControlID="txtRank">
                                </asp:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator
              ID="rfvTopic" runat="server" ErrorMessage="*" ControlToValidate ="txtRank"></asp:RequiredFieldValidator>
</td>
</tr>




<tr><td>
  <asp:Label ID="lblErrorAdd" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label>  </td><td>
        <asp:Button ID="BtnUpdate" runat="server" Text="Save" onclick="BtnUpdate_Click" Width="64px" /><asp:Button ID="BtnCancel" runat="server" Text="Cancel" onclick="BtnCancel_Click" CausesValidation ="false" /></td></tr></table>
 
 
</asp:Content>

