<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true" CodeFile="DeckAgencyBoard.aspx.cs" Inherits="DeckAgencyBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<ul>
            	  <li class="odd-box">
                	<a href="#">
                        <div class="box-inside">
                        	<span class="fontawesome-th icon-side-bar"></span>
                        </div>
                        <div class="box-title">Agency Brd</div>
                     </a>
                </li>
                <li class="red-box">
                	<a href="#" runat="server" id="btnBack">
                        <div class="box-inside">
                        	<span class="fontawesome-circle-arrow-left icon-side-bar"></span>
                        </div>
                        <div class="box-title">back</div>
                    </a>
                </li>
            </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <div class="main-columns">
            	<div class="container">
                	<div class="large-12 medium-12 top-title">
                    	<h6>Agency Board</h6>
                    </div>
                    <div class="content-container">
                    	  <a href='Preview/AgencyBoard.aspx' runat="server" id="lnlPreview"    onclick="window.open(this.href, 'mywin','left=0,top=0,width=1024,height=768,toolbar=1,resizable=0'); return false;">View in Actual Size</a>
     
     <br />
     <br />
                        <div class="row">
                            	<div class="large-2 medium-2 columns">
                                	<label class="left">File</label>
                                </div>
                                <div class="large-11 medium-11 columns">
                                	<div class="custom-file-upload">
                                        <asp:FileUpload ID="FileUpload2" runat="server" CssClass="button_small greyishBtn" name="myfiles[]" multiple />
                                     
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div class="row">
                            	<div class="large-8 columns">
                                 
                                    <asp:Button ID="BtnUpdate" runat="server" Text="Save" onclick="BtnUpdateAgency_Click" CssClass="small radius button"  Visible="false"/>
                                    <asp:Button ID="btnSave" runat="server" Text="Add" onclick="BtnSaveAgency_Click" CssClass="small radius button" Visible="false"/>
                                </div>
                            </div>
                                
                            <br />
                             <div class="row">
                            	<div class="large-8 columns">
                                         <asp:Label ID="lblErrorAdd" runat="server" Text=""></asp:Label>
                                       
 
                            
                               </div>

                             
                                <asp:Image ID="Image1" runat="server"    />

                            </div>

                                
                   
  
                    </div>
    
  </div>
   
 
  
  <asp:Label ID="lblFileEdit" runat="server" style="display: none;"></asp:Label>
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

</asp:Content>

