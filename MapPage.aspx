<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="MapPage.aspx.cs" Inherits="Master_MapPage" %>
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script src="./js/jquery.min.js" type="text/javascript"></script>

<script type="text/javascript">
    $(document).ready(function () {

        $("#<%= Panel2.ClientID %>").hide();
    });
     
    function edit() {

        $("#<%= Panel1.ClientID %>").fadeOut('slow');
        $("#<%= Panel2.ClientID %>").fadeIn('slow');


    }

    function view() {

        $("#<%= Panel1.ClientID %>").fadeIn('slow');
        $("#<%= Panel2.ClientID %>").fadeOut('slow');


    }
    function back() {

        $("#<%= Panel2.ClientID %>").fadeOut('slow');
        $("#<%= Panel1.ClientID %>").fadeIn('slow');
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true" />
      
<asp:SqlDataSource ID="dsMap" runat="server" ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                            SelectCommand="sp_SelectMap" 
                ProviderName="System.Data.SqlClient" 
        SelectCommandType="StoredProcedure">
                 <SelectParameters>
                     <asp:QueryStringParameter Name="PresentationID" 
                         QueryStringField="PresentationID" Type="Int32" />
                 </SelectParameters>
            </asp:SqlDataSource>
<asp:HiddenField ID="HiddenFieldMapID" runat="server" />
  
    <asp:Label ID="lblErrorAdd" runat="server" Font-Bold ="true" ForeColor ="red"></asp:Label>
    <asp:Panel ID="Panel1" runat="server">
        <div class="action_bar">
            <a href="#" onclick="edit();" class="button_small whitishBtn"><span class="iconsweet"></span>Edit</a> 
        </div>
             <table cellpadding="2" border="0">
                <tr>
                    <td>
                        <asp:Image ID="Image1" runat="server" Width ="600px" Height ="768px" /> 
                    </td>
                </tr>
            </table>
    </asp:Panel>
    <asp:HiddenField ID="HiddenFieldViewID" runat="server" />
 
     <asp:Panel ID="Panel2" runat="server">
      <div class="action_bar">
            <a href="#" onclick="view();" class="button_small whitishBtn"><span class="iconsweet"></span>View</a>
      </div>
         <iframe runat="server"  id="frmEntry" width="100%" height="300px" frameborder="0"></iframe>
    </asp:Panel>
 
</asp:Content>

