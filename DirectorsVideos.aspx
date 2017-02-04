<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="DirectorsVideos.aspx.cs" Inherits="Master_DirectorsVideos" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<script language="javascript" type="text/javascript">
       var size = 2;
       var id = 0;
       function ProgressBarAdd() {

           if (document.getElementById('<%=FileUpload1.ClientID %>').value != "") {
               document.getElementById("MainContent_divProgressAdd").style.display = "block";
               document.getElementById("divUploadAdd").style.display = "block";
               id = setInterval("progressAdd()", 20);
               return true;
           }
           //             else {
           //                 alert("Select a file to upload");
           //                 return false;
           //             }
       }
       function progressAdd() {
           size = size + 1;
           if (size > 299) {
               clearTimeout(id);
           }
           document.getElementById("MainContent_divProgressAdd").style.width = size + "pt";
           document.getElementById("<%=lblPercentageAdd.ClientID %>").firstChild.data = parseInt(size / 3) + "%";
       }
    </script>--%>
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true" />
        <table>
           <tr>
                    <td>
                        Video File 
                    </td>
                    <td>
                    <asp:Label ID="Label2" runat="server" Visible ="false"></asp:Label>
                     <div style="display:none"></div>   
                   <div style="display:none">  <asp:Image ID="Image1" runat="server" AlternateText="No Available Logo" Width ="200px" Height ="200px"/></div><br />
                    
                       
                         <asp:Label ID="Label3" runat="server"></asp:Label>
                        <div style="text-align:left">
        <asp:FileUpload ID="FileUpload1" runat="server" />&nbsp;<br />
        <br />
     
   
    </div>
     
      <div>

        <br />
        <asp:Label ID="lblErrorAdd" runat="server" ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>
        <div id="divUploadAdd" style="display: none">
            <div style="width: 300pt; text-align: center;">
                Uploading...</div>
            <div style="width: 300pt; height: 10px; border: solid 1pt gray">
                <div id="divProgressAdd" runat="server" style="width: 1pt; height: 10px; background-color:Gray;
                    display: none">
                </div>
            </div>
            <div style="width: 300pt; text-align: center;">
                <asp:Label ID="lblPercentageAdd" runat="server" Text="Label"></asp:Label></div>
            <br />
            <asp:Label ID="Label1Add" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </div>
   

  




        
     
                        </td>
                </tr>
             <tr>
                <td>Rank
                </td>
                <td>  
                    <asp:TextBox ID="txtRank" runat="server" ValidationGroup ="Edit"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender
                        ID="ftbe" runat="server" TargetControlID="txtRank" FilterType="Custom, Numbers"
                        ValidChars="+-=/*()." />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup ="Edit" runat="server" ControlToValidate="txtRank"
                        ErrorMessage="*">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr><td></td><td>
                <asp:Button ID="btnSaveVideo" runat="server" Text="Save" 
                    onclick="btnSaveVideo_Click" ValidationGroup ="Edit" />
                <asp:Button ID="btnCancelSaveVideo"
                    runat="server" Text="Cancel" onclick="btnCancelSaveVideo_Click" CausesValidation ="false" /></td></tr>
        </table>

</asp:Content>

