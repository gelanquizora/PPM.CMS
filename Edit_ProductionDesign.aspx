﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="Edit_ProductionDesign.aspx.cs" Inherits="Edit_ProductionDesign" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" language="javascript">
    function UserDeleteConfirmation() {
        if (confirm("Are you sure you want to delete this record?"))
            return true;
        else
            return false;
    }

</script>
<style type="text/css" >
.pd_container img
{
    width:100px;
    height:auto;
 
}

.pd_container h2
{
    width:30%;
}



</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

<asp:Panel runat="server" ID="Panel1">
    
         <asp:Button ID="createNew" class="button_small whitishBtn" runat="server" Text="Create New" 
                   onclick="createNew_Click" />
                   <br />
                   <br />
<asp:GridView ID="gvProduction" runat="server" OnRowCommand ="gvProduction_RowCommand" AutoGenerateColumns="False" AllowPaging="True"
                            AllowSorting="True" DataSourceID="dsProduction">
                            <Columns>
                      <%--        <asp:ImageField DataImageUrlField="ImageFile" DataImageUrlFormatString="~/repository/{0}"  ControlStyle-Width="100"  ControlStyle-Height="100"  >
                                </asp:ImageField>--%>
                              <asp:BoundField DataField="Rank" HeaderText="Rank" SortExpression="Rank" />
                                <asp:TemplateField HeaderText="File"  ItemStyle-HorizontalAlign="Center"  >
                                    <ItemTemplate>
                                 <%--       <asp:Literal runat="server"  Text='<ul><%# Eval("Template") %></ul>'></asp:Literal>--%>
                                            <img src='template/<%#DataBinder.Eval(Container, "DataItem.TemplateID")%>.jpg' width="100" height="90" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                   
                                <asp:TemplateField HeaderText="ACTION" ItemStyle-Width="120px">
                                    <ItemTemplate>
 
                                                               <asp:ImageButton ID="lnkEdit" ToolTip='<%# Eval("ProductionID") %>' CommandName="edt"
                            CommandArgument='<%# Eval("ProductionID") %>' runat="server" ImageUrl="~/images/187-pencil.png">
                        </asp:ImageButton>

                                               <asp:ImageButton ID="lnkDelete" ToolTip='<%# Eval("ProductionID") %>' CommandName="del"
                            CommandArgument='<%# Eval("ProductionID") %>' OnClientClick="return UserDeleteConfirmation();" runat="server" ImageUrl="~/images/delete.png">
                        </asp:ImageButton>

                         <asp:Label ID="lblTemplate" runat="server" Visible ="false" Text='<%# Eval("Template")%>'></asp:Label>

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
  

        

<table cellpadding="2" border="0">
<tr><td>Choose Template</td><td>
    <asp:DropDownList ID="ddlTemplate" runat="server" AutoPostBack ="true" 
        onselectedindexchanged="ddlTemplate_SelectedIndexChanged">
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
            <asp:FileUpload ID="FileUpload2" runat="server" /><asp:Label ID="lblFile" runat="server"></asp:Label>
              </asp:Panel>
                      <asp:Panel ID="pnlImg2" runat="server">
                <asp:FileUpload ID="FileUpload22" runat="server" /><asp:Label ID="lblFile22" runat="server"></asp:Label>
      
          </asp:Panel>
            <asp:Panel ID="pnlImg3" runat="server">
           <asp:FileUpload ID="FileUpload23" runat="server" /><asp:Label ID="lblFile23" runat="server"></asp:Label>
                  </asp:Panel>
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




<tr><td><asp:Label ID="lblErrorAdd" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label></td><td><asp:Button ID="BtnSave" class="button_small whitishBtn" runat="server" Text="Save" onclick="BtnSave_Click" Width="64px" /><asp:Button ID="BtnCancel" runat="server" Text="Cancel" class="button_small whitishBtn" onclick="BtnCancel_Click" CausesValidation ="false" /></td></tr></table>
</asp:Panel>
    <asp:SqlDataSource ID="dsProduction" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="sp_SelectProduction" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="PresentationID" 
                QueryStringField="PresentationID" Type="Int32" />
        </SelectParameters>
                  </asp:SqlDataSource>
 
 
</asp:Content>

