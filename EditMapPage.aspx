<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="EditMapPage.aspx.cs" Inherits="EditMapPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblErrorAdd" runat="server" Font-Bold ="true" ForeColor ="red"></asp:Label>

    <table cellpadding="2" border="0">
                         <tr>
                        <td>File
                        </td>
                        <td><asp:FileUpload ID="FileUpload2" runat="server" />
                        <br /><asp:Label ID="lblFileEdit" runat="server"
                                ></asp:Label>
                        </td>
                    </tr>
            <tr><td>&nbsp;</td><td> </td></tr></table>

             <asp:HiddenField ID="HiddenFieldViewID" runat="server" />
             <asp:HiddenField ID="HiddenFieldMapID" runat="server" />
          <%--  <table cellpadding="2" border="0">


                         <tr>
                        <td>File
                        </td>
                        <td><asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                    </tr>

             <tr><td></td><td> 
             </td></tr></table>--%>
    <asp:Button ID="Button1" runat="server" Text="Save" onclick="BtnUpdateMap_Click" />
                   
<asp:SqlDataSource ID="dsMap" runat="server" ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                            SelectCommand="sp_SelectMap" 
                ProviderName="System.Data.SqlClient" 
        SelectCommandType="StoredProcedure">
                 <SelectParameters>
                     <asp:QueryStringParameter Name="PresentationID" 
                         QueryStringField="PresentationID" Type="Int32" />
                 </SelectParameters>
            </asp:SqlDataSource>
</asp:Content>

