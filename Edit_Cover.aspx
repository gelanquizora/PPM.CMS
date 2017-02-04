<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Edit_Cover.aspx.cs" Inherits="Master_Default" %>
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
   
    <asp:Literal ID="lblHTML" runat="server" Mode="PassThrough"></asp:Literal>

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />
     <div id="Content">
        
            <table id="DemoTable" border="0" cellpadding="0" cellspacing="0">
            
                <tr>
                
                    <td id="EditorCell">

                        <div id="EditorPanel">

                      
                       
                                
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <Triggers>
                                            <%--          <asp:AsyncPostBackTrigger ControlID="UpdateButton" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="ToggleModeRadioButtonList" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ColorSchemeRadioButtonList" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="NoToolstripBackgroundImageBox" EventName="CheckedChanged" />--%>
                                        </Triggers>
                                        <ContentTemplate>
                                          <cc:HtmlEditor ID="Editor" runat="server" Height="800px" Width="800px" InitialMode="Html" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                              
                            <br />
                            <div id="DemoControls">
                            
                        
                                <asp:Button ID="ClearButton" runat="server" Text="Clear" OnClick="ClearButton_Click" CssClass="button" ToolTip="Clear the text in the editor above" />
                              
                               
                                
                            </div>
                            
                            <div id="Preview">
                            
                                <div id="PreviewHeading" runat="server" class="demoHeading">Preview</div>
                                
                                <div id="PreviewControls">

                                    <asp:Button ID="PreviewButton" runat="server" Text="Preview" OnClick="PreviewButton_Click" CssClass="previewButton button" ToolTip="Display the current saved editor text as either formatted or Html below" />
                                    <asp:RadioButtonList ID="Selections" CssClass="radiobuttonList button" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" >
                                        <asp:ListItem Text="Formatted" Value="Formatted" ></asp:ListItem>
                                        <asp:ListItem Text="Html" Value="Html" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>

                                </div>
                                
                                <div id="PreviewText" >
                                
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" >
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="PreviewButton" EventName="Click" />
                                        </Triggers>
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
<table cellpadding="2" border="0">

<tr><td>&nbsp;</td><td>&nbsp;</td><td><asp:Button ID="BtnUpdate" runat="server" Text="Save" onclick="BtnUpdate_Click" Width="64px" /></td><td><asp:Button ID="BtnCancel" runat="server" Text="Cancel" onclick="BtnCancel_Click" /></td><td></td></tr></table>
</asp:Content>

