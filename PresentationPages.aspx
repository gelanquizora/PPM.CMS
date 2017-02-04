<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" ValidateRequest="true" AutoEventWireup="true" CodeFile="PresentationPages.aspx.cs" Inherits="Master_PresentationPages" %>
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true" />
<%--     <asp:Label ID="Label1" runat="server"></asp:Label>
     <asp:Label ID="lblCID" runat="server"></asp:Label>--%>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
     
<asp:MultiView ID="MultiView1" runat="server">
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td>
<asp:View ID="View1" runat="server">

  <asp:SqlDataSource ID="dsCover" runat="server" ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                            SelectCommand="sp_SelectCover" 
                ProviderName="System.Data.SqlClient" 
        SelectCommandType="StoredProcedure">
                 <SelectParameters>
                     <asp:QueryStringParameter Name="PresentationID" 
                         QueryStringField="PresentationID" Type="Int32" />
                 </SelectParameters>
            </asp:SqlDataSource>
    <div id="Content" runat ="server">   
    <asp:Label ID="lblHTML" runat="server"></asp:Label>
 
        
            <table id="DemoTable" border="0" cellpadding="0" cellspacing="0">
            
                <tr>
                
                    <td id="EditorCell" style="height:780px;">

                        <div id="EditorPanel" style="height:700px;">

                      
                       
                                
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <Triggers></Triggers>
                                        <ContentTemplate>
                                          <cc:HtmlEditor ID="Editor" runat="server" Height="680px" Width="650px" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                              
                            <br />
                            <div id="DemoControls">
                            
                        
                             <asp:Button ID="BtnSave" runat="server" Text="Save" onclick="BtnSave_Click" Width="64px" />
                             <asp:Button ID="BtnCancel" runat="server" Text="Cancel" onclick="BtnCancel_Click" />   
                             <asp:Button ID="ClearButton" runat="server" Text="Clear" OnClick="ClearButton_Click" CssClass="button" ToolTip="Clear the text in the editor above" />
                              
                               
                                
                            </div>
                            
                            <div id="Preview">
                            
                                <div id="PreviewHeading" runat="server" style="display:none" class="demoHeading">Preview</div>
                              
                                <div id="PreviewControls" style="display:none" >

                                    <asp:Button ID="PreviewButton" runat="server" Text="Preview" OnClick="PreviewButton_Click" CssClass="previewButton button" ToolTip="Display the current saved editor text as either formatted or Html below" />
                                    <asp:RadioButtonList ID="Selections" CssClass="radiobuttonList button" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" >
                                        <asp:ListItem Text="Formatted" Value="Formatted" ></asp:ListItem>
                                        <asp:ListItem Text="Html" Value="Html" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>

                                </div>
                                
                                <div id="PreviewText" >
                                
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" >
                                        <Triggers><asp:AsyncPostBackTrigger ControlID="PreviewButton" EventName="Click" /></Triggers>
                                        <ContentTemplate>
                                            <div id="TextPreview" runat="server" class="preview"></div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>

                            </div>
                    
                 
                    
                        </div>

                    </td>
                
               

                </tr>
            
            </table>

       



 </div>
 
   <div id="ViewContent" runat ="server">
         <asp:Button ID="btnEdit" runat="server" Text="Edit" onclick="btnEditCover_Click" CssClass="button_small whitishBtn" /> 
          <br />
          <table cellpadding="2" border="2" width ="100%" height="700px">
 
   <tr><td>   <div id="DivContent" runat="server" class="preview"></div></td></tr>
   </table>
 
   
   </div>
<div id="ContentEdit" runat ="server">

    <asp:HiddenField ID="HiddenFieldCoverID" runat="server" />
            <table id="DemoTableEdit" border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
            
                <tr>
                
                    <td id="EditorCellEdit" style="height:780px;">

                        <div id="EditorPanelEdit" style="height:700px;">

                      
                       
                                
                                <asp:UpdatePanel ID="UpdatePanel1Edit" runat="server" UpdateMode="Conditional">
                                        <Triggers></Triggers>
                                        <ContentTemplate>
                                          <cc:HtmlEditor ID="EditorEdit" runat="server" Height="680px" Width="650px" InitialMode="Html" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                              
                            <br />
                            <div id="DemoControlsEdit">
                            
                        
                             <asp:Button ID="BtnUpdateEdit" runat="server" Text="Save" onclick="BtnUpdateEdit_Click" CssClass="button_small whitishBtn" />  
                             <asp:Button ID="BtnCancelEdit" runat="server" Text="Cancel" onclick="BtnCancelEdit_Click" CssClass="button_small whitishBtn" /> 
                             <asp:Button ID="ClearButtonEdit" runat="server" Text="Clear" OnClick="ClearButtonEdit_Click" CssClass="button_small whitishBtn" ToolTip="Clear the text in the editor above" />
                              
                               
                                
                            </div>
                            
                            <div id="PreviewEdit">
                            
                              
                                
                                <div id="PreviewControlsEdit"  style="display:none">

                                    <asp:Button ID="PreviewButtonEdit" runat="server" Text="Preview" OnClick="PreviewButtonEdit_Click" CssClass="previewButton button" ToolTip="Display the current saved editor text as either formatted or Html below" />
                                    <asp:RadioButtonList ID="SelectionsEdit" CssClass="radiobuttonList button" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" >
                                        <asp:ListItem Text="Formatted" Value="Formatted" ></asp:ListItem>
                                        <asp:ListItem Text="Html" Value="Html" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>

                                </div>
                                
                                <div id="PreviewTextEdit" >
                                
                                  <%--  <asp:UpdatePanel ID="UpdatePanel3Edit" runat="server" UpdateMode="Conditional" >
                                        <Triggers><asp:AsyncPostBackTrigger ControlID="PreviewButtonEdit" EventName="Click" /></Triggers>
                                        <ContentTemplate>--%>
                                           
                                          
                                            <div id="TextPreviewEdit" runat="server" class="preview"></div>
                                    <%--    </ContentTemplate>
                                    </asp:UpdatePanel>--%>

                                </div>

                            </div>
                    
                 
                    
                        </div>

                    </td>
                
               

                </tr>
            
            </table>

  


      </div>

</asp:View>
</td>

</tr>
</table>
</asp:MultiView>

</asp:Content>

