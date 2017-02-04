<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="DirectorsTreatmentVideos.aspx.cs" Inherits="DirectorsTreatmentVideos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <!-- Chang URLs to wherever Video.js files will be hosted -->
  <link href="video/video-js.css" rel="stylesheet" type="text/css">
  <!-- video.js must be in the <head> for older IEs to work. -->
  <script src="video/video.js"></script>

  <!-- Unless using the CDN hosted version, update the URL to the Flash SWF -->
  <script>
      videojs.options.flash.swf = "video-js.swf";
  </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    
    <asp:Panel ID="Panel1" runat="server">
    <asp:Button ID="btnEdit" runat="server" Text="Add New" onclick="btnEdit_Click" />
        <asp:GridView ID="gvTreatment"  Width ="100%" runat="server" OnRowCommand ="gvTreatment_RowCommand" AutoGenerateColumns="False" AllowPaging="True" CssClass="activity_datatable"
                                    AllowSorting="True" DataSourceID="dsTreatment" Visible="true"  OnRowDataBound="gvTreatment_RowDataBound" DataKeyNames="DTVideoID, Path">
                                    <Columns>
                                    <asp:BoundField DataField="Rank" HeaderText="Rank"   SortExpression="Rank" />
                                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                                    <asp:TemplateField HeaderText="ACTION" ItemStyle-Width="120px">
                                       <ItemTemplate>
                                               <asp:ImageButton ID="lnkEdit" ToolTip='<%# Eval("DTVideoID") %>' CommandName="edt"
                                    CommandArgument= "<%# ((GridViewRow) Container).RowIndex %>"  runat="server" ImageUrl="~/images/187-pencil.png">
                                </asp:ImageButton>
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
    </asp:Panel>
     <asp:Panel ID="Panel2" runat="server" Visible="false">
         <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <table cellpadding="2" border="0">
        <tr>
            <td>File
            </td>
            <td>
                 <div class="file_uploader">
                	<asp:FileUpload ID="FileUpload1" runat="server" />  
                </div>
                
            </td>
        </tr>
        <tr><td>Rank:</td><td  style="width:100px"><asp:TextBox ID="txtRank" runat="server" MaxLength="10"  Width="50%"></asp:TextBox><asp:RangeValidator ID="rvRank" runat="server" ControlToValidate="txtRank" ErrorMessage="Not Valid" MaximumValue="2147483647" MinimumValue="-2147483648" SetFocusOnError="True" Type="Integer" ValidationGroup="Add"></asp:RangeValidator>
   <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="123456789"
                                    TargetControlID="txtRank">
                                </asp:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator
              ID="rfvTopic" runat="server" ErrorMessage="*" ControlToValidate ="txtRank" ValidationGroup="Add"></asp:RequiredFieldValidator>
</td>
</tr>

<tr>
            <td>Title
            </td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                  <asp:RequiredFieldValidator
              ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate ="txtTitle" ValidationGroup="Add"></asp:RequiredFieldValidator>
            </td>
        </tr>
    <tr>
    <td></td>
            <td>
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>
        </td>
</tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="BtnSave" runat="server" CssClass="button_small whitishBtn" 
                        onclick="BtnSaveVideo_Click" Text="Save" ValidationGroup="Add" />
                    <asp:Button ID="BtnCancel" runat="server" CssClass="button_small whitishBtn" 
                        onclick="BtnSaveCancel_Click" Text="Cancel" />
                </td>
            </tr>
</table>
    </asp:Panel>
      <asp:Panel ID="Panel3" runat="server" Visible="false">
         <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <table cellpadding="2" border="0">
        <tr>
            <td>File
            </td>
            <td>
                 <div class="file_uploader">
                	<asp:FileUpload ID="FileUpload2" runat="server" />  

                    
                     <asp:HiddenField ID="HiddenField1" runat="server" />
             <video width="100%" height="240" controls>
                        <source src="1/32/repository/oceans-clip.mp4" type="video/mp4">
   Your browser does not support the video tag.
                </video>

             <%-- <video id="example_video_1" class="video-js vjs-default-skin" controls preload="none" width="100%" height="264"
      poster="http://video-js.zencoder.com/oceans-clip.png"
      data-setup="{}">
 <%--   <source  src="http://video-js.zencoder.com/oceans-clip.mp4" type='video/mp4' />
--%>
      <source  src="http://localhost:1902/terrible1/1/32/repository/50f57054-9392-4b85-b370-341ffca07bde.mp4" type='video/mp4' />

<%--    <source src="http://video-js.zencoder.com/oceans-clip.webm" type='video/webm' />
    <source src="http://video-js.zencoder.com/oceans-clip.ogv" type='video/ogg' />
    <track kind="captions" src="/video/demo.captions.vtt" srclang="en" label="English"></track><!-- Tracks need an ending tag thanks to IE9 -->
    <track kind="subtitles" src="/video/demo.captions.vtt" srclang="en" label="English"></track><!-- Tracks need an ending tag thanks to IE9 -->--%>
  </video>--%>


                </div>
                
            </td>
        </tr>
        <tr><td>Rank:</td><td  style="width:100px"><asp:TextBox ID="txtEditRank" runat="server" MaxLength="10"  Width="50%"></asp:TextBox><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtRank" ErrorMessage="Not Valid" MaximumValue="2147483647" MinimumValue="-2147483648" SetFocusOnError="True" Type="Integer" ValidationGroup="Edit"></asp:RangeValidator>
   <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" ValidChars="123456789"
                                    TargetControlID="txtRank">
                                </asp:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator
              ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate ="txtEditRank" ValidationGroup="Edit"></asp:RequiredFieldValidator>
</td>
</tr>

<tr>
            <td>Title
            </td>
            <td>
                <asp:TextBox ID="txtEditTitle" runat="server"></asp:TextBox>
                  <asp:RequiredFieldValidator
              ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate ="txtEditTitle" ValidationGroup="Edit"></asp:RequiredFieldValidator>
            </td>
        </tr>
    <tr>
    <td></td>
            <td>
                <asp:Label ID="lblEditError" runat="server" ForeColor="Red" Text=""></asp:Label>
        </td>
</tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnUpdate" runat="server" CssClass="button_small whitishBtn" 
                        onclick="BtnUpdateVideo_Click" Text="Update" ValidationGroup="Edit" />
                    <asp:Button ID="Button2" runat="server" CssClass="button_small whitishBtn" 
                        onclick="BtnCancel_Click" Text="Cancel" />
                </td>
            </tr>
</table>
    </asp:Panel>
    <!-- SQL Datasource -->

     <asp:SqlDataSource ID="dsTreatment" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="sp_SelectDirectorsTreatmentVideoByPresentationID" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="PresentationID" 
                QueryStringField="PresentationID" Type="Int32" />
        </SelectParameters>
                  </asp:SqlDataSource>

<!--- end SQL DataSoure -->
</asp:Content>

