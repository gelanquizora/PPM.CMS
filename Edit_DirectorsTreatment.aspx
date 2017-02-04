<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="Edit_DirectorsTreatment.aspx.cs" Inherits="Master_Edit_DirectorsTreatment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
 <script src="./js/jquery.min.js" type="text/javascript"></script>
<script src="./js/jquery.touchcarousel-1.1.js" type="text/javascript"></script>
 
<script type="text/javascript">
    
     $(document).ready(function () {

   
     });

   function addnew() {

       $("#<%= Panel1.ClientID %>").hide();
       $("#<%= Panel2.ClientID %>").show();


   }

 
    function UserDeleteConfirmation() {
        if (confirm("Are you sure you want to delete this record?"))
            return true;
        else
            return false;
    }
     
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel ID="Panel1" runat="server">
    
     
        <asp:GridView ID="gvTreatment"  Width ="100%" runat="server" OnRowCommand ="gvTreatment_RowCommand" AutoGenerateColumns="False" AllowPaging="True" CssClass="activity_datatable"
                                    AllowSorting="True" DataSourceID="dsTreatment" Visible="true"  OnRowDataBound="gvTreatment_RowDataBound" DataKeyNames="ImageFile">
                                    <Columns>
                                 <%--  <asp:ImageField DataImageUrlField="ImageFile" DataImageUrlFormatString="~/repository/{0}"  ControlStyle-Width="100"  ControlStyle-Height="100"  >
                
                                   </asp:ImageField>--%>

                                   <asp:TemplateField>
                                   <ItemTemplate>
                                    <%-- <img src='repository/<%#DataBinder.Eval(Container, "DataItem.ImageFile")%>' width="100" height="100" /> --%>
                                       <asp:Image ID="img" runat="server"   Width="100" Height="100"/>
                                   </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:BoundField DataField="VoiceOver" HeaderText="Voice Over" SortExpression="VoiceOver" />
                                    <asp:BoundField DataField="Rank" HeaderText="Panel No"   SortExpression="Rank" />
                   
                                   
                                        <asp:TemplateField HeaderText="ACTION" ItemStyle-Width="120px">
                                            <ItemTemplate>
                                               

                                                                       <asp:ImageButton ID="lnkEdit" ToolTip='<%# Eval("DTID") %>' CommandName="edt"
                                    CommandArgument='<%# Eval("DTID") %>' runat="server" ImageUrl="~/images/187-pencil.png">
                                </asp:ImageButton>

                                                       <asp:ImageButton ID="lnkDelete" ToolTip='<%# Eval("DTID") %>' CommandName="del"
                                    CommandArgument='<%# Eval("DTID") %>' OnClientClick="return UserDeleteConfirmation();" runat="server" ImageUrl="~/images/delete.png">
                                </asp:ImageButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                         

                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Found
                                    </EmptyDataTemplate>
                                </asp:GridView>
      
      <asp:Button ID="btnAdd" runat="server" Text="Add New Panel" 
            CssClass="button_big" onclick="BtnAddNew_Click" />    
 
</asp:Panel>
<asp:Panel ID="Panel2" runat="server" Visible="false">
  <asp:Button ID="btnCancel" runat="server" Text="Back" onclick="BtnCancel_Click" Width="64px" /> 

 
    <iframe id="frmEntry"  width="100%" height="500px"     runat="server"></iframe>
   
 

</asp:Panel>


<!-- DataSource -->
   <asp:SqlDataSource ID="dsTreatment" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="sp_SelectDirectorsTreatment" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="PresentationID" 
                QueryStringField="PresentationID" Type="Int32" />
        </SelectParameters>
                  </asp:SqlDataSource>
 
 
<!-- end DataSource -->
    <asp:Panel ID="pnlVideos" runat="server">
        <asp:Panel ID="pnlVideoGrid" runat="server">
            <asp:Button ID="btnAddVideos" runat="server" Text="AddVideos" 
                onclick="btnAddVideos_Click" class="button_small whitishBtn" /><asp:Button ID="btnCancelAddVideos" 
                runat="server" Text="Back" onclick="btnCancelAddVideos_Click" class="button_small whitishBtn" />
                <br />
                <br />
            <asp:GridView ID="gvVideos" runat="server" CssClass="activity_datatable" AutoGenerateColumns="False" 
                DataSourceID="dsVideos" OnRowCommand ="gvVideos_RowCommand">
                <Columns>
                   
                    <asp:BoundField DataField="ImageFile" HeaderText="VIDEO FILE" 
                        SortExpression="ImageFile" />
                          <asp:TemplateField HeaderText="ACTION" ItemStyle-Width="120px">
                                            <ItemTemplate>
                           <asp:ImageButton ID="lnkDelete" ToolTip='<%# Eval("DTVideoID") %>' CommandName="del"
                                    CommandArgument='<%# Eval("DTVideoID") %>' OnClientClick="return UserDeleteConfirmation();" runat="server" ImageUrl="~/images/delete.png">
                                </asp:ImageButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                 
                </Columns>
                  <EmptyDataTemplate>
                                        No Record Found
                                    </EmptyDataTemplate>
            </asp:GridView>
      
               <asp:SqlDataSource ID="dsVideos" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="sp_SelectDirectorsTreatmentVideo" 
                SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="HiddenFieldDTID" Name="DTID" 
                PropertyName="Value" Type="Int32" />
        </SelectParameters>
                  </asp:SqlDataSource>
            <asp:HiddenField ID="HiddenFieldDTID" runat="server" />
        </asp:Panel>

        <asp:Panel ID="pnlVideoEntry" runat="server" CssClass="widget_body">
            
            <table>
                <tr>
                    <td>Video File
                    </td>
                    <td><asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
                     <tr><td></td><td><asp:Button ID="BtnSaveVideo" class="button_small whitishBtn" runat="server" Text="Save" onclick="BtnSave_Click" />
                         <asp:Button ID="BtnCandelVideo" runat="server" Text="Cancel" 
                             onclick="BtnCandelVideo_Click" class="button_small whitishBtn" /></td></tr>
            </table>

        </asp:Panel>

    </asp:Panel>
</asp:Content>

