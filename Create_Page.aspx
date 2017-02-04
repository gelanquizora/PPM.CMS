<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Masterpage.master" AutoEventWireup="true" CodeFile="Create_Page.aspx.cs" Inherits="Create_Page" %>
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
  
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />

       		   <div id="rightColumn" class="right">
        	
            	
               
            <div class="left rc_left">
            	<h3>Add New Page</h3>
            </div>
                 <br />
<table cellpadding="2" border="0">


<tr><td>Page Name:</td><td  style="width:100px"><asp:TextBox ID="txtPageName" 
        runat="server" MaxLength="50"  Width="200px"></asp:TextBox>
</td>
</tr>
<tr><td>Page Content:</td><td  style="width:100px">  
   

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
                                          <cc:HtmlEditor ID="Editor" runat="server" Height="800px" Width="800px" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                              
                            <br />
                            <div id="DemoControls">
                            
                                <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click" CssClass="button" ToolTip="Save the current editor text" />
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
</td>
</tr>
<tr><td>Ordinal:</td><td style="width:50px"><asp:TextBox ID="txtOrdinal" runat="server" MaxLength="10"  Width="50%"></asp:TextBox>
   </td>

</tr>

<tr><td>&nbsp;</td><td><asp:Button ID="BtnSave" runat="server" Text="Save" onclick="BtnSave_Click" Width="64px" /><asp:Button ID="BtnCancel" runat="server" Text="Cancel" onclick="BtnCancel_Click" /></td></tr></table>
       </div>
</asp:Content>

