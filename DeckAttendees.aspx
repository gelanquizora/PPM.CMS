﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true" CodeFile="DeckAttendees.aspx.cs" Inherits="DeckAttendees" %>
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
	
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
	<ul>
            	<li class="odd-box">
                	<a href="#">
                         <div class="box-inside">
                        	<img src="images/icons/icon-attendees.png" alt="Attendees">
                        </div>
                        <div class="box-title">Attendees</div>
                     </a>
                </li>
                <li class="red-box">
                	<a href="#" runat="server" id="btnBack">
                        <div class="box-inside">
                        	<img src="images/icons/icon-back.png" alt="Back">
                        </div>
                        <div class="box-title">back</div>
                    </a>
                </li>
            </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:SqlDataSource ID="dsAttendee" runat="server" ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                            SelectCommand="sp_SelectAttendees" 
                ProviderName="System.Data.SqlClient" 
        SelectCommandType="StoredProcedure">
                 <SelectParameters>
                     <asp:QueryStringParameter Name="PresentationID" 
                         QueryStringField="PresentationID" Type="Int32" />
                    <%--     <asp:ControlParameter ControlID="drpPages" DefaultValue="0"  Type="Int32"   Name="Ordinal" /> --%>
                 </SelectParameters>
            </asp:SqlDataSource>
    <asp:HiddenField ID="HiddenFieldAttendeeID" runat="server" />
    
    <div class="container" style="width: 1024px;"> 
      <div >
               
<div id="ContentEdit" runat ="server" class="html-container"> 

<div id="left">  
    <asp:DropDownList ID="drpPages" runat="server" style="height: 30px; padding: 0px;" height="30"  AutoPostBack="true" OnSelectedIndexChanged="drpPages_SelectedIndexChanged" >
    </asp:DropDownList></div>


    <asp:Panel ID="Panel1" runat="server" CssClass="DemoControlsEdit">
       <a href='IpadViewer.aspx' runat="server" id="lnlPreview"    onclick="window.open(this.href, 'mywin','left=0,top=0,width=1024,height=768,toolbar=1,resizable=0'); return false;">View in Actual Size</a>
     
                             <asp:Button ID="BtnUpdateEdit" runat="server" Text="Save" onclick="BtnUpdateEdit_Click"   Visible="false"/>  
                                <asp:Button ID="btnSave" runat="server" Text="Save" onclick="BtnSave_Click" Visible="false"    />  
                             <asp:Button ID="ClearButtonEdit" runat="server" Text="Clear" OnClick="ClearButtonEdit_Click"  ToolTip="Clear the text in the editor above" />
                              <asp:Button ID="btnResets" runat="server" Text="Reset" OnClick="btnReset_Click"  ToolTip="Reset" />
      <asp:Button ID="btnAddNewPage" runat="server" Text="Add new page" OnClick="btnAddNewPage_Click"  ToolTip="Add new page" />
      
   </asp:Panel>             
    <asp:HiddenField ID="HiddenFieldCoverID" runat="server" />
             
               
                                
                                <asp:UpdatePanel ID="UpdatePanel1Edit" runat="server" UpdateMode="Conditional">
                                        <Triggers></Triggers>
                                        <ContentTemplate>
                                          <cc:HtmlEditor ID="EditorEdit" runat="server" Height="863px" Width="1024px"   />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                              
                     
                        

                    
            

  


      </div>

 </div>
 </div>
</asp:Content>

