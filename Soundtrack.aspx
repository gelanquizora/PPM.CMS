<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="Soundtrack.aspx.cs" Inherits="Soundtrack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script type="text/javascript" language="javascript">
    function UserDeleteConfirmation() {
        if (confirm("Are you sure you want to delete this record?"))
            return true;
        else
            return false;
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

         <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true" />
        
 
    <asp:SqlDataSource ID="dsSound" runat="server" ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                            SelectCommand="sp_SelectSound" 
                ProviderName="System.Data.SqlClient" 
        SelectCommandType="StoredProcedure">
                 <SelectParameters>
                     <asp:QueryStringParameter Name="PresentationID" 
                         QueryStringField="PresentationID" Type="Int32" />
                 </SelectParameters>
            </asp:SqlDataSource>
    <asp:HiddenField ID="HiddenFieldSoundID" runat="server" />
<asp:MultiView ID="MultiView1" runat="server">
<asp:View ID="View4" runat="server">
  <asp:Button ID="Button1" runat="server" Text="Add New Item" 
        onclick="Button1_Click" />
<asp:GridView ID="gvSoundtrack" runat="server" OnRowCommand ="gvSoundtrack_RowCommand" AutoGenerateColumns="False" AllowPaging="True"
                            AllowSorting="True" DataSourceID="dsSoundtrack" DataKeyNames="SoundID, SoundFile">
                            <Columns>
                     
                             <asp:BoundField DataField="SoundFile" HeaderText="SoundFile" SortExpression="SoundFile" /> 
                                <asp:TemplateField HeaderText="File"  ItemStyle-HorizontalAlign="Center"  >
                                    <ItemTemplate>
                                  <%--       <img src='template/<%#DataBinder.Eval(Container, "DataItem.TemplateID")%>.jpg' width="100" height="90" />--%>
                                   <audio controls>  <source src="repository/<%#DataBinder.Eval(Container, "DataItem.SoundFile")%>" type="audio/mpeg"> 	Your browser does not support the audio element. 	</audio>
                                  </ItemTemplate>
                                </asp:TemplateField>

                                   
                                <asp:TemplateField HeaderText="ACTION" ItemStyle-Width="120px">
                                    <ItemTemplate>
 
                                                               <asp:ImageButton ID="lnkEdit" ToolTip='<%# Eval("SoundID") %>' CommandName="edt"
                            CommandArgument='<%# Eval("SoundID") %>' runat="server" ImageUrl="~/images/187-pencil.png">
                        </asp:ImageButton>

                                               <asp:ImageButton ID="lnkDelete" ToolTip='<%# Eval("SoundID") %>' CommandName="del"
                            CommandArgument='<%# Eval("SoundID") %>' OnClientClick="return UserDeleteConfirmation();" runat="server" ImageUrl="~/images/delete.png">
                        </asp:ImageButton>

                       

                                    </ItemTemplate>
                                </asp:TemplateField>

                         

                            </Columns>
                            <EmptyDataTemplate>
                                No Record Found
                            </EmptyDataTemplate>
                        </asp:GridView>
</asp:View>
<asp:View ID="View1" runat="server">
  
<asp:Label ID="lblErrorAdd" runat="server" Font-Bold ="true" ForeColor ="red"></asp:Label>
<table cellpadding="2" border="0">


             <tr>
            <td>File
            </td>
            <td><asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>




<tr><td></td><td><asp:Button ID="BtnSave" class="button_small whitishBtn" runat="server" Text="Save" onclick="BtnSaveSound_Click" Width="64px" /></td></tr></table>
</asp:View>

<asp:View ID="View2" runat="server">
         <asp:Button ID="btnEdit" class="button_small whitishBtn" runat="server" Text="Edit" onclick="btnEditSound_Click" />
<%--         <asp:Button ID="btnCancelEditMap" runat="server" Text="Back" onclick="btnCancelEditSound_Click" />--%>
<table cellpadding="2" border="0">
             <tr>
            <td>Image
            </td>
            <td>
                <asp:Image ID="Image1" runat="server" Width ="200px" Height ="200px" /><br /><asp:Label ID="lblFileView" runat="server"
                    ></asp:Label>
            </td>
        </tr>
</table>
    <asp:HiddenField ID="HiddenFieldViewID" runat="server" />


</asp:View>

<asp:View ID="View3" runat="server">
<table cellpadding="2" border="0">
             <tr>
            <td>File
            </td>
            <td><asp:FileUpload ID="FileUpload2" runat="server" />
            <br /><asp:Label ID="lblFileEdit" runat="server"
                    ></asp:Label>
            </td>
        </tr>
<tr><td>&nbsp;</td><td><asp:Button ID="BtnUpdate" class="button_small whitishBtn" runat="server" Text="Save" onclick="BtnUpdateSound_Click" Width="64px" /></td></tr></table>


    
       

  



</asp:View>

</asp:MultiView>

 <asp:SqlDataSource ID="dsSoundtrack" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="sp_SelectSound" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="PresentationID" 
                QueryStringField="PresentationID" Type="Int32" />
        </SelectParameters>
                  </asp:SqlDataSource>
</asp:Content>

