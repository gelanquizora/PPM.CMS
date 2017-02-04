<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="Edit_Location.aspx.cs" Inherits="Edit_Location" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:Panel runat="server" ID="Panel1">
         <asp:Button ID="createNew" runat="server" class="button_small whitishBtn" Text="Create New" 
                   onclick="createNew_Click" />
                   <br />
                   <br />
<asp:GridView ID="gvLocation" runat="server" OnRowCommand ="gvLocation_RowCommand" AutoGenerateColumns="False" AllowPaging="True"
                            AllowSorting="True" DataSourceID="dsLocation">
                             <Columns>
                      <%--        <asp:ImageField DataImageUrlField="ImageFile" DataImageUrlFormatString="~/repository/{0}"  ControlStyle-Width="100"  ControlStyle-Height="100"  >
                                </asp:ImageField>--%>
                              <asp:BoundField DataField="Rank" HeaderText="Rank" SortExpression="Rank" />
                                <asp:TemplateField HeaderText="File"  ItemStyle-HorizontalAlign="Center"  >
                                    <ItemTemplate>
                                 <%--       <asp:Literal runat="server"  Text='<ul><%# Eval("Template") %></ul>'></asp:Literal>--%>\
                                            <img src='template/<%#DataBinder.Eval(Container, "DataItem.TemplateID")%>.jpg' width="100" height="90" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                   
                                <asp:TemplateField HeaderText="ACTION" ItemStyle-Width="120px">
                                    <ItemTemplate>
 
                                                               <asp:ImageButton ID="lnkEdit" ToolTip='<%# Eval("LocationID") %>' CommandName="edt"
                            CommandArgument='<%# Eval("LocationID") %>' runat="server" ImageUrl="~/images/187-pencil.png">
                        </asp:ImageButton>

                                               <asp:ImageButton ID="lnkDelete" ToolTip='<%# Eval("LocationID") %>' CommandName="del"
                            CommandArgument='<%# Eval("LocationID") %>' OnClientClick="return UserDeleteConfirmation();" runat="server" ImageUrl="~/images/delete.png">
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




<tr><td><asp:Label ID="lblErrorAdd" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label></td><td><asp:Button ID="BtnSave" class="button_small whitishBtn" runat="server" Text="Save" onclick="BtnSave_Click" Width="64px" /><asp:Button ID="BtnCancel" class="button_small whitishBtn" runat="server" Text="Cancel" onclick="BtnCancel_Click" CausesValidation ="false" /></td></tr></table>
</asp:Panel>
    <asp:SqlDataSource ID="dsLocation" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="sp_SelectLocation" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="PresentationID" 
                QueryStringField="PresentationID" Type="Int32" />
        </SelectParameters>
                  </asp:SqlDataSource>
 
 
</asp:Content>

