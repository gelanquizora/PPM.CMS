<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="Agency.aspx.cs" Inherits="Master_Agency" %>
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true" />
   
    <asp:SqlDataSource ID="dsAgency" runat="server" ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                            SelectCommand="sp_SelectAgency" 
                ProviderName="System.Data.SqlClient" 
        SelectCommandType="StoredProcedure">
                 <SelectParameters>
                     <asp:QueryStringParameter Name="PresentationID" 
                         QueryStringField="PresentationID" Type="Int32" />
                 </SelectParameters>
            </asp:SqlDataSource>
    <asp:HiddenField ID="HiddenFieldAgencyID" runat="server" />
    <asp:MultiView ID="MultiView1" runat="server">

<asp:View ID="View1" runat="server">

 

         <asp:Label ID="lblErrorAdd" runat="server" Font-Bold ="true" ForeColor ="red"></asp:Label>
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

<tr>
    <td></td>
            <td>
            <asp:Button ID="BtnSave" runat="server" Text="Save" onclick="BtnSaveAgency_Click"  CssClass="button_small whitishBtn" />
            <asp:Button ID="BtnCancel" runat="server" Text="Cancel" onclick="BtnCancel_Click"  CssClass="button_small whitishBtn" />
        </td>
</tr>
</table>


       





</asp:View>

<asp:View ID="View2" runat="server">
         <div class="action_bar">
            <asp:Button ID="btnEdit" runat="server" Text="Edit" onclick="btnEditAgency_Click" CssClass="button_small whitishBtn" />
         </div>
        
<table cellpadding="2" border="0">
             <tr>
           
            <td>
                <div class="preview">
                    <asp:Image ID="Image1" runat="server" Width ="700px" Height ="768px" /><br />
                    <asp:Label ID="lblFileView" runat="server"></asp:Label>
                </div>
            </td>
        </tr>
</table>
    <asp:HiddenField ID="HiddenFieldViewID" runat="server" />


</asp:View>

<asp:View ID="View3" runat="server">
     
          
<table cellpadding="2" border="0">
             <tr>
           <td>
                <div class="uplaoder_label">File</div>
            </td>
            <td>
                <div class="file_uploader">
                    <asp:FileUpload ID="FileUpload2" runat="server" CssClass="button_small greyishBtn" />
                </div>
            <br />
            <div class="action_bar">
                <asp:Label ID="lblFileEdit" runat="server"></asp:Label>
            </div>
            </td>
        </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <br />
            <asp:Button ID="BtnUpdate" runat="server" Text="Save" onclick="BtnUpdateAgency_Click" CssClass="button_small whitishBtn" />
            <asp:Button ID="btnCancelEdit" runat="server" Text="Cancel" onclick="BtnCancelEdit_Click" CssClass="button_small whitishBtn" />
        </td>
    </tr>
</table>

 

</asp:View>

</asp:MultiView>

<%-- <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
</asp:Content>

