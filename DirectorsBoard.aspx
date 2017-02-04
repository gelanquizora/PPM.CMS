<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="DirectorsBoard.aspx.cs" Inherits="Master_DirectorsBoard" %>
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  
         <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true" />
        
          <div class="left rc_left">
            	<h3>
     <asp:Label ID="lblPresentation" runat="server"></asp:Label>
     <br />
     <asp:Label ID="lblAction" runat="server"></asp:Label></h3>
            </div>
            <br />
    <asp:SqlDataSource ID="dsDirectorsBoard" runat="server" ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                            SelectCommand="sp_SelectDirectorsBoard" 
                ProviderName="System.Data.SqlClient" 
        SelectCommandType="StoredProcedure">
                 <SelectParameters>
                     <asp:QueryStringParameter Name="PresentationID" 
                         QueryStringField="PresentationID" Type="Int32" />
                 </SelectParameters>
            </asp:SqlDataSource>
    <asp:HiddenField ID="HiddenFieldDirectorsBoardID" runat="server" />
    <asp:MultiView ID="MultiView1" runat="server">

<asp:View ID="View1" runat="server">

   <table id="DemoTable" border="0" cellpadding="0" cellspacing="0">
            
                <tr>
                
                    <td id="EditorCell">

                        <div id="EditorPanel">

                      
                       
                                
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <Triggers></Triggers>
                                        <ContentTemplate>
                                          <cc:HtmlEditor ID="Editor" runat="server" Height="600px" Width="600px" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                              
                            <br />
                            <div id="DemoControls">
                            
                        
                             <asp:Button ID="BtnSave" CausesValidation ="false" runat="server" Text="Save" onclick="BtnSave_Click" Width="64px" /><asp:Button ID="BtnCancel" CausesValidation ="false" runat="server" Text="Cancel" onclick="BtnCancel_Click" />   <asp:Button ID="ClearButton" runat="server" Text="Clear" OnClick="ClearButton_Click" CssClass="button" CausesValidation ="false" ToolTip="Clear the text in the editor above" />
                              
                               
                                
                            </div>
                            
                            <div id="Preview">
                            
                                <div id="PreviewHeading" runat="server" style="display:none" class="demoHeading">Preview</div>
                                
                                <div id="PreviewControls" style="display:none">

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
 

</asp:View>

<asp:View ID="View2" runat="server">
         <asp:Button ID="btnEdit" runat="server" Text="Edit" CausesValidation ="false" onclick="btnEditDirectorsBoard_Click" />
          <input type="button"   value="Back" onclick="top.back();"/>
   <table cellpadding="2" border="2" width ="600px" height="600px">

   <tr><td>   <div id="DivContent" runat="server" class="preview"></div></td></tr>
   </table>


</asp:View>

<asp:View ID="View3" runat="server">


           
                <table id="DemoTableEdit" border="0" cellpadding="0" cellspacing="0">
            
                <tr>
                
                    <td id="EditorCellEdit">

                        <div id="EditorPanelEdit">

                      
                       
                                
                                <asp:UpdatePanel ID="UpdatePanel1Edit" runat="server" UpdateMode="Conditional">
                                        <Triggers></Triggers>
                                        <ContentTemplate>
                                          <cc:HtmlEditor ID="EditorEdit" runat="server" Height="800px" Width="800px" InitialMode="Html" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                              
                            <br />
                             Description: <br />
                <asp:TextBox ID="txtBoardDescriptionEdit" runat="server" Height="200px" 
                    TextMode="MultiLine" Width="400px"></asp:TextBox>
                    <br />
                        <asp:Panel ID="pnlGrid" runat="server">
         <asp:Button ID="createNew" runat="server" Text="Upload New Video" 
                   onclick="UploadNew_Click" CausesValidation ="false" />
    <asp:GridView ID="gvVideos" runat="server" AutoGenerateColumns="False" 
             DataSourceID="dsVideos" Width ="100%">
        <Columns>
            <asp:BoundField DataField="VideoID" Visible ="false" HeaderText="VideoID" InsertVisible="False" 
                ReadOnly="True" SortExpression="VideoID" />
            <asp:BoundField DataField="VideoTitle" HeaderText="VideoTitle" 
                SortExpression="VideoTitle" />
        

                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                       <asp:ImageButton ID="lnkEdit" ToolTip='<%# Eval("VideoID") %>' CommandName="edt"
                            CommandArgument='<%# Eval("VideoID") %>' runat="server" ImageUrl="~/images/187-pencil.png">
                        </asp:ImageButton>
                        <asp:ImageButton ID="lnkDelete" ToolTip='<%# Eval("VideoID") %>' CommandName="del"
                            CommandArgument='<%# Eval("VideoID") %>' OnClientClick="return UserDeleteConfirmation();" runat="server" ImageUrl="~/images/delete.png">
                        </asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
        </Columns>
    </asp:GridView>
  <asp:SqlDataSource ID="dsVideos" runat="server" 
             ConnectionString="Data Source=USER\SQLEXPRESS;Initial Catalog=terrible1;Integrated Security=True" 
             ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectDirectorsVideos" 
             SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="HiddenFieldDirectorsBoardID" Name="BoardID" 
                PropertyName="Value" Type="Int32" />
        </SelectParameters>
         </asp:SqlDataSource>
    </asp:Panel>




                            <div id="DemoControlsEdit">
                            
                        
                             <asp:Button ID="BtnUpdateEdit" runat="server" Text="Save" onclick="BtnUpdateEdit_Click" Width="64px" />  <asp:Button ID="Button1" CausesValidation ="false" runat="server" Text="Cancel" onclick="BtnCancelEdit_Click" /> <asp:Button ID="ClearButtonEdit" runat="server" Text="Clear" OnClick="ClearButtonEdit_Click" CssClass="button" CausesValidation ="false" ToolTip="Clear the text in the editor above" />
                              
                               
                                
                            </div>
                            
                            <div id="PreviewEdit">
                            
                                
                                
                                <div id="PreviewControlsEdit" style="display:none" >

                                    <asp:Button ID="PreviewButtonEdit" runat="server" Text="Preview" OnClick="PreviewButtonEdit_Click" CssClass="previewButton button" ToolTip="Display the current saved editor text as either formatted or Html below" />
                                    <asp:RadioButtonList ID="SelectionsEdit" CssClass="radiobuttonList button" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" >
                                        <asp:ListItem Text="Formatted" Value="Formatted" ></asp:ListItem>
                                        <asp:ListItem Text="Html" Value="Html" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>

                                </div>
                                
                                <div id="PreviewTextEdit" >
                                
                                    <asp:UpdatePanel ID="UpdatePanel3Edit" runat="server" UpdateMode="Conditional" >
                                        <Triggers><asp:AsyncPostBackTrigger ControlID="PreviewButtonEdit" EventName="Click" /></Triggers>
                                        <ContentTemplate>
                                            <div id="TextPreviewEdit" runat="server" class="preview"></div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>

                            </div>
                    
                 
                    
                        </div>

                    </td>
                
               

                </tr>
            
            </table>

      
    
        

  



</asp:View>

</asp:MultiView>





</asp:Content>

