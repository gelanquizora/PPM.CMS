<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" ValidateRequest="false"
    AutoEventWireup="true" CodeFile="TimeTable.aspx.cs" Inherits="TimeTable" %>

<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<link rel="stylesheet" href="/terrible1/js/vendor/cl_editor/jquery.cleditor.css" />
 
    <!--[if lt IE 9]>
    <script src="js/html5.js"></script>
    <![endif]-->
    <!--Javascript-->
    <script type="text/javascript" src="./js/jquery.min.js"> </script>
    <script type="text/javascript" src="./js/jquery.tipsy.js"> </script>
    <script type="text/javascript" src="./js/highlight.js"></script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--One_Wrap-->
    <div class="one_wrap">
        <div class="widget">
   
            <div class="widget_body">
                <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
                </asp:ScriptManager>
              
        
              
                <asp:HiddenField ID="HiddenFieldTimeTableID" runat="server" />
              <%--  <asp:Panel ID="pnlAdd" runat="server">
                    <table>
                       <tr>
                            <td>
                            </td>
                            <td>

                                <div id="TextPreview" runat="server" contenteditable="true" style="display: none">
                                </div>
                                <eo:Editor ID="Editor1" runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                    Font-Strikeout="False" Font-Underline="False" Height="350px" HighlightColor="255, 255, 192"  Width="900px">
                                    <HeaderStyle CssText="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; border-bottom: gray 1px" />
                                    <EditAreaStyle CssText="border-right: gray 1px solid; padding-right: 0px; border-top: gray 1px solid; padding-left: 0px; padding-bottom: 0px; border-left: gray 1px solid; padding-top: 0px; border-bottom: gray 1px solid" />
                                    <FooterStyle CssText="border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa" />
                                    <TabButtonStyles>
                                        <NormalStyle CssText="border-right: #335ea8 1px; padding-right: 7px; border-top: #335ea8 1px; padding-left: 7px; font-size: 12px; padding-bottom: 3px; border-left: #335ea8 1px; padding-top: 3px; border-bottom: #335ea8 1px; font-family: tahoma; background-color: white" />
                                        <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 6px; border-top: #335ea8 1px solid; padding-left: 6px; font-size: 12px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; font-family: tahoma; background-color: #c2cfe5" />
                                        <SelectedStyle CssText="border-right: #335ea8 1px solid; padding-right: 6px; border-top: #335ea8 1px solid; padding-left: 6px; font-size: 12px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; font-family: tahoma; background-color: white" />
                                    </TabButtonStyles>
                                    <BreadcrumbLabelStyle CssText="padding-right: 6px; padding-left: 6px; font-size: 12px; padding-top: 1px; font-family: tahoma" />
                                    <BreadcrumbItemStyle CssText="border-right: darkgray 1px solid; padding-right: 3px; border-top: darkgray 1px solid; margin-top: 1px; padding-left: 3px; font-size: 12px; padding-bottom: 1px; border-left: darkgray 1px solid; padding-top: 1px; border-bottom: darkgray 1px solid; font-family: tahoma" />
                                    <BreadcrumbItemHoverStyle CssText="border-right: darkgray 1px solid; padding-right: 3px; border-top: darkgray 1px solid; margin-top: 1px; padding-left: 3px; font-size: 12px; padding-bottom: 1px; border-left: darkgray 1px solid; padding-top: 1px; border-bottom: darkgray 1px solid; font-family: tahoma; background-color:#e0e0e0;" />
                                    <BreadcrumbItemSeparatorStyle CssText="width: 3px; height: 10px" />
                                    <EmoticonDropDownStyle CssText="border-top: gray 1px solid; border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa" />
                                    <BreadcrumbDropDownStyle CssText="border-top: gray 1px solid; border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa" />
                                    <EmoticonStyle CssText="background-color:white;border-bottom-color:#c5d3ed;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#c5d3ed;border-left-style:solid;border-left-width:1px;border-right-color:#c5d3ed;border-right-style:solid;border-right-width:1px;border-top-color:#c5d3ed;border-top-style:solid;border-top-width:1px;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;" />
                                </eo:Editor>
                                <asp:RadioButtonList ID="Selections" runat="server" Style="display: none">
                                    <asp:ListItem Text="Formatted" Value="Formatted"></asp:ListItem>
                                    <asp:ListItem Text="Html" Value="Html" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                          
                                         </td>
                        </tr>
                    </table>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </asp:Panel>--%>
           
                       <asp:Button ID="btnSaveEdit" runat="server" Text="Save"
                                    OnClick="btnUpdate_Click" CssClass="small radius button" />
                                  <asp:Button ID="btnCreateAccount" runat="server" Text="submit" Style="display: none"
                                    OnClientClick="HandleIT(); return false;" CssClass="small radius button" />
                                <asp:Button ID="btnSave" runat="server" CssClass="small radius button" Text="Save add"
                                    OnClick="btnSave_Click" />
                                    <br />
                
                <table>
 
                        <tr>
                           
                            <td>
                             
                                <div id="Content">
                              
                                    <asp:RadioButtonList ID="SelectionsEdit" runat="server" Style="display: none">
                                        <asp:ListItem Text="Formatted" Value="Formatted"></asp:ListItem>
                                        <asp:ListItem Text="Html" Value="Html" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>
                                    <eo:Editor ID="Editor2" runat="server" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                        Font-Strikeout="False" Font-Underline="False" Height="848px" HighlightColor="255, 255, 192"  Width="900px">
                                        <HeaderStyle CssText="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; border-bottom: gray 1px" />
                                        <EditAreaStyle CssText="border-right: gray 1px solid; padding-right: 0px; border-top: gray 1px solid; padding-left: 0px; padding-bottom: 0px; border-left: gray 1px solid; padding-top: 0px; border-bottom: gray 1px solid" />
                                        <FooterStyle CssText="border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa" />
                                        <TabButtonStyles>
                                            <NormalStyle CssText="border-right: #335ea8 1px; padding-right: 7px; border-top: #335ea8 1px; padding-left: 7px; font-size: 12px; padding-bottom: 3px; border-left: #335ea8 1px; padding-top: 3px; border-bottom: #335ea8 1px; font-family: tahoma; background-color: white" />
                                            <HoverStyle CssText="border-right: #335ea8 1px solid; padding-right: 6px; border-top: #335ea8 1px solid; padding-left: 6px; font-size: 12px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; font-family: tahoma; background-color: #c2cfe5" />
                                            <SelectedStyle CssText="border-right: #335ea8 1px solid; padding-right: 6px; border-top: #335ea8 1px solid; padding-left: 6px; font-size: 12px; padding-bottom: 2px; border-left: #335ea8 1px solid; padding-top: 2px; border-bottom: #335ea8 1px solid; font-family: tahoma; background-color: white" />
                                        </TabButtonStyles>
                                        <BreadcrumbLabelStyle CssText="padding-right: 6px; padding-left: 6px; font-size: 12px; padding-top: 1px; font-family: tahoma" />
                                        <BreadcrumbItemStyle CssText="border-right: darkgray 1px solid; padding-right: 3px; border-top: darkgray 1px solid; margin-top: 1px; padding-left: 3px; font-size: 12px; padding-bottom: 1px; border-left: darkgray 1px solid; padding-top: 1px; border-bottom: darkgray 1px solid; font-family: tahoma" />
                                        <BreadcrumbItemHoverStyle CssText="border-right: darkgray 1px solid; padding-right: 3px; border-top: darkgray 1px solid; margin-top: 1px; padding-left: 3px; font-size: 12px; padding-bottom: 1px; border-left: darkgray 1px solid; padding-top: 1px; border-bottom: darkgray 1px solid; font-family: tahoma; background-color:#e0e0e0;" />
                                        <BreadcrumbItemSeparatorStyle CssText="width: 3px; height: 10px" />
                                        <EmoticonDropDownStyle CssText="border-top: gray 1px solid; border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa" />
                                        <BreadcrumbDropDownStyle CssText="border-top: gray 1px solid; border-right: gray 1px solid; padding-right: 2px; border-top: gray 1px; padding-left: 2px; padding-bottom: 2px; border-left: gray 1px solid; padding-top: 2px; border-bottom: gray 1px solid; background-color: #fafafa" />
                                        <EmoticonStyle CssText="background-color:white;border-bottom-color:#c5d3ed;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#c5d3ed;border-left-style:solid;border-left-width:1px;border-right-color:#c5d3ed;border-right-style:solid;border-right-width:1px;border-top-color:#c5d3ed;border-top-style:solid;border-top-width:1px;padding-bottom:2px;padding-left:2px;padding-right:2px;padding-top:2px;" />
                                    </eo:Editor>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                          
                        </tr>
                    </table>
                    <div id="TextPreviewEdit" runat="server" style="display: none" contenteditable="true">
                    </div>
             
            </div>
        </div>
    </div>

      <asp:SqlDataSource ID="dsTimeTable" runat="server" ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                    SelectCommand="sp_SelectTimeTable" ProviderName="System.Data.SqlClient" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="PresentationID" QueryStringField="PresentationID"
                            Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
</asp:Content>
