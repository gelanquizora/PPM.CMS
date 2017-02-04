<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SiteAdmin.master" AutoEventWireup="true" CodeFile="ProjectInside.aspx.cs" Inherits="_Admin_ProjectInside" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

<ul class="main-nav">
                <li class="home">
                    <a href="#">Home</a>
                </li>
                <li class="clients" >
                    <a href="Clients.aspx" >Clients</a>
                </li>
               <li class="projects">
                    <a href="#" class="selected" >Projects</a>
                </li> 
                <%--  <li class="deck">
                    <a href="#" class="selected">Deck</a>
                </li>--%>

            </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
	<ul>
            	<li class="odd-box">
                	<a href="#" runat="server" id="lnkCover" title="Cover" onclick="window.open(this.href, 'mywin','left=0,top=0,width=1024,height=768,toolbar=1,resizable=0'); return false;">
                        <div class="box-inside" >
                        	<%--<span class="fontawesome-briefcase icon-side-bar"></span>--%>
                            <img src="../images/thumbnail/cover.png" alt="Cover"/>
                        </div>
                     
                      
                     </a>
                </li>
                <li class="even-box"  >
                	<a href="#" runat="server" id="lnkAttendees" title="Attendees" onclick="window.open(this.href, 'mywin','left=0,top=0,width=1024,height=768,toolbar=1,resizable=0'); return false;">
                        <div class="box-inside">
                            <img src="../images/thumbnail/attendees.png" alt="Attendees" />
                        </div>
                     
                    </a>
                </li>
                <li class="odd-box">
                	<a href="#" runat="server" id="lnkAgenda" title="Agenda" onclick="window.open(this.href, 'mywin','left=0,top=0,width=1024,height=768,toolbar=1,resizable=0'); return false;"> 
                        <div class="box-inside" >
                        	     <img src="../images/thumbnail/agenda.png"   alt="Agenda" />
                        </div>
                  
                     </a>
                </li>
                  <li class="even-box">
                	<a href="#" runat="server" id="lnkAdvertising" title="Advertising Objectives" onclick="window.open(this.href, 'mywin','left=0,top=0,width=1024,height=768,toolbar=1,resizable=0'); return false;">
                        <div class="box-inside">
                        	 <img src="../images/thumbnail/advertising.png" alt="Advertising Objectives"  />
                        </div>
                       
                       
                    </a>
                </li>
                <li class="odd-box">
                	<a href="#" runat="server" id="lnkTargetMarket" title="Target Market" onclick="window.open(this.href, 'mywin','left=0,top=0,width=1024,height=768,toolbar=1,resizable=0'); return false;">
                        <div class="box-inside">
                       	 <img src="../images/thumbnail/target.png"  alt="Target Market" />
                        </div> 
                     </a>
                </li>
                <li class="even-box">
                	<a href="#" runat="server" id="lnkMoodandTone" title="Mood & Tone" onclick="window.open(this.href, 'mywin','left=0,top=0,width=1024,height=768,toolbar=1,resizable=0'); return false;">
                        <div class="box-inside">
                          <img src="../images/thumbnail/mood.png" alt="Mood & Tone"  />
                        </div>
                     
                    </a>
                </li>
                <li class="odd-box">
                	<a href="#" runat="server" id="lnkAgencyBoard" title="Agency Board" onclick="window.open(this.href, 'mywin','left=0,top=0,width=1024,height=768,toolbar=1,resizable=0'); return false;">
                        <div class="box-inside">
                            <img src="../images/thumbnail/agency.png" alt="Agency Board"  />
                        </div>
                      
                     </a>
                </li>
                <li class="lightblue-box">
                	<a href="#" runat="server" id="lnkDirectorsTreatement" title="Director's Treatment" onclick="window.open(this.href, 'mywin','left=0,top=0,width=1024,height=768,toolbar=1,resizable=0'); return false;">
                        <div class="box-inside">
                          <img src="../images/thumbnail/directors.png" alt="Director's Treatment"  />
                        </div> 
                    </a>
                </li>
             <li class="blue-box">
                	<a id="A1" href="#" runat="server"   title="Notes" >
                        <div class="box-inside">
                        	 <img src="../images/thumbnail/notes.png" alt="Notes"  />
                        </div>
                        
                     </a>
           </li> 
                <li class="lightblue-box">
                	<a href="#" runat="server" id="lnkProductionDesign" title="Production Design" onclick="window.open(this.href, 'mywin','left=0,top=0,width=1024,height=768,toolbar=1,resizable=0'); return false;">
                        <div class="box-inside">
                        	 <img src="../images/thumbnail/production.png" alt="Production Design"  />
                        </div>
                     
                    </a>
                </li>
                <li class="blue-box">
                	<a href="#" runat="server" id="lnkLocations" title="Locations" onclick="window.open(this.href, 'mywin','left=0,top=0,width=1024,height=768,toolbar=1,resizable=0'); return false;">
                        <div class="box-inside">
                        	 <img src="../images/thumbnail/location.png" alt="Locations"  />
                        </div>
                        
                     </a>
                </li>
                <li class="lightblue-box" >
                	<a href="#" runat="server" id="lnkSoundtrack" title="Soundtrack" onclick="window.open(this.href, 'mywin','left=0,top=0,width=1024,height=768,toolbar=1,resizable=0'); return false;">
                        <div class="box-inside">
                        	  <img src="../images/thumbnail/soundtrack.png" alt="Soundtrack"  />
                        </div>
                      
                    </a>
                </li>
                <li class="blue-box">
                	<a href="#"  runat="server" id="lnkTimetable" title="Timetable" onclick="window.open(this.href, 'mywin','left=0,top=0,width=1024,height=768,toolbar=1,resizable=0'); return false;">
                        <div class="box-inside">
                        	 <img src="../images/thumbnail/timetable.png" alt="Timetable"  />
                        </div>
                        
                     </a>
                </li>
                <li class="lightblue-box">
                	<a href="#" runat="server" id="lnkMaps" title="Maps" onclick="window.open(this.href, 'mywin','left=0,top=0,width=1024,height=768,toolbar=1,resizable=0'); return false;">
                        <div class="box-inside">
                        	 <img src="../images/thumbnail/maps.png" alt="Maps"  />
                        </div>
                      
                    </a>
                </li>
                <li class="lightred-box">
                	<a href="#" runat="server" id="lnkDirectory" title="Directory" onclick="window.open(this.href, 'mywin','left=0,top=0,width=1024,height=768,toolbar=1,resizable=0'); return false;">
                        <div class="box-inside">
                        	 <img src="../images/thumbnail/directory.png" alt="Directory"  />
                        </div>
                   
                     </a>
                </li>
     
                <li class="red-box">
                	<a runat="server" id="btnBack"  title="Back">
                        <div class="box-inside">
                        	 <img src="../images/thumbnail/back.png" alt="Back"  />
                        </div>
                       
                         
                                     
                    </a>
                </li>          
            </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	<div class="main-columns">
            	<div class="container">
                	<div class="top-title">
                    	<h6>  
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></h6>
                    </div>

        <asp:Panel ID="Panel1" runat="server"  CssClass="content-container">
         
                    	  <asp:Label ID="lblPresentationID" runat="server" style="display:none" />
                          <asp:Button ID="btnEdit" CssClass="small radius button" runat="server" Text="Edit"  OnClick="BtnEdit_Click"/>
                          <asp:Button ID="btnCEAccess" CssClass="small radius button" runat="server" Text="Content Editor Access"  OnClick="BtnCEAccess_Click"/>
                         <asp:Button ID="btnIPadAccess" CssClass="small radius button" runat="server" Text="IPad Access"  OnClick="btnIPadAccess_Click"/>
                          <asp:Button ID="btnLockProject" CssClass="small radius button" runat="server" Text="Lock"  OnClick="btnLockProject_Click"/>
                           <asp:Button ID="btnGeneratePDF" CssClass="small radius button" runat="server" Text="Generate PDF File"   />
                        <br/>
                        <br/>
                  
                        	<div class="row">
                            	<div class="large-8 columns">
                                	<label>Title</label>
                                
                                    <asp:TextBox ID="txtEditTitle" runat="server" MaxLength="50" placeholder="Title" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="large-8 columns">
                                	<label>Description</label>
                                 
                                      <asp:TextBox ID="txtEditDescription" runat="server" MaxLength="2147483647" placeholder="Description"   TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                            	<div class="large-8 columns">
                                	<label>Project</label>
                                       <asp:DropDownList ID="ddlClientEdit" runat="server" DataSourceID ="SqlDataSource2"      DataTextField ="ClientName" DataValueField ="ClientID">
                </asp:DropDownList>
                                
                                </div>
                            </div>
                              
                            
                            <div class="row">
                            	<div class="large-8 columns">
                            	       <asp:Button ID="BtnUpdate" class="small radius button" runat="server" Text="Save" onclick="BtnUpdate_Click"  Visible="false"/>
                                       <asp:Button ID="BtnCancel" class="small radius button" runat="server" Text="Cancel" onclick="BtnCancelEdit_Click" Visible="false" />  
                                     

                                </div>
                            </div>
                    
                 
        </asp:Panel>
          <asp:Panel ID="Panel2" runat="server"  Visible="false" CssClass="content-container">
        	                <div class="row">
                            	<div class="large-8 columns">
                                	<h6>Content Editor Access</h6>
                                
                                 
                                </div>
                            </div>
                            
                        	<div class="row">
                            	<div class="large-8 columns">
                                	<label>Project Code</label>
                                    <asp:TextBox ID="txtCEUsername" runat="server" MaxLength="50"   ></asp:TextBox>
                                  <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtCEUsername" ForeColor="red" Display="Dynamic" ErrorMessage="Required"  ValidationGroup="AddContentEditorAccess"/>
                                </div>
                            </div>
                            <div class="row" runat="server" id="editCEPasscode">
                            	<div class="large-8 columns">
                            
                                 
                             
                           
                                <asp:Button ID="lnkEditCEPasscode" runat="server" Text="[Edit Passcode]" onclick="lnkEditCEPasscode_Click" />
                          </div>
                              <br />     <br /> 
                            </div>
                            <div class="row" runat="server" id="cepassword">
                            	<div class="large-8 columns">
                                	<label>Passcode</label>
                                 
                                      <asp:TextBox ID="txtCEPassCode" runat="server" MaxLength="50"  TextMode="Password"   ></asp:TextBox>
                                      <asp:RequiredFieldValidator id="PasswordConfirmRequiredValidator" runat="server" ControlToValidate="txtCEPassCode" ForeColor="red" Display="Dynamic" ErrorMessage="Required"  ValidationGroup="AddContentEditorAccess"/>
                                </div>
                            </div>
                            <div class="row" runat="server" id="ceconfirmpassword">
                            	<div class="large-8 columns">
                                	<label>Confirm Passcode</label>
                                 
                                      <asp:TextBox ID="txtCEConfirmPasscode" runat="server" MaxLength="50"  TextMode="Password" ></asp:TextBox>
                                      <asp:CompareValidator id="PasswordConfirmCompareValidator" runat="server" ControlToValidate="txtCEConfirmPasscode" ForeColor="red" Display="Dynamic" ControlToCompare="txtCEPassCode"  ValidationGroup="AddContentEditorAccess" ErrorMessage="Confirm passcode must match passcode." />
                                </div>
                            </div>
                            <div class="row">
                            	<div class="large-8 columns">
                            	  

                                         <asp:Button ID="btnSaveCEAccess" class="small radius button" runat="server" Text="Save" onclick="btnSaveCEAccess_Click"   ValidationGroup="AddContentEditorAccess" />
                                             <asp:Button ID="btnUpdateCEAccess" class="small radius button" runat="server" Text="Save" onclick="btnUpdateCEAccess_Click"    ValidationGroup="AddContentEditorAccess" />
                                       <asp:Button ID="btnCancelCEAccess" class="small radius button" runat="server" Text="Cancel" onclick="btnCancelCEAccess_Click"   />  
                                     

                                </div>
                            </div>
                    
                 
        
           <br />

               
        </asp:Panel>     

         <asp:Panel ID="Panel3" runat="server"  Visible="false" CssClass="content-container">
        	                <div class="row">
                            	<div class="large-8 columns">
                                	<h6>iPad Access</h6>
                                
                                 
                                </div>
                            </div>
                            
                        	<div class="row">
                            	<div class="large-8 columns">
                                	<label>Username</label>
                                    <asp:TextBox ID="txtIPadUsername" runat="server" MaxLength="50"   ></asp:TextBox>
                                  <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtIPadUsername" ForeColor="red" Display="Dynamic" ErrorMessage="Required"  ValidationGroup="AddiPadAccess"/>
                                </div>
                            </div>
                           
                            <div class="row" runat="server" id="Div2">
                            	<div class="large-8 columns">
                                	<label>Passcode</label>
                                 
                                      <asp:TextBox ID="txtIPadPassword" runat="server" MaxLength="50"    ></asp:TextBox>
                                      <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtIPadPassword" ForeColor="red" Display="Dynamic" ErrorMessage="Required"  ValidationGroup="AddiPadAccess"/>
                                </div>
                            </div>
                          
                            <div class="row">
                            	<div class="large-8 columns">
                            	  

                                         <asp:Button ID="btnIPadAccessSave" class="small radius button" runat="server" Text="Save" onclick="btnIPadAccessSave_Click"   ValidationGroup="AddiPadAccess" />
                                             <asp:Button ID="btnIPadAccessUpdate" class="small radius button" runat="server" Text="Update" onclick="btnIPadAccessUpdate_Click"    ValidationGroup="AddiPadAccess" />
                                       <asp:Button ID="Button4" class="small radius button" runat="server" Text="Cancel" onclick="btnCancelCEAccess_Click"   />  
                                     

                                </div>
                            </div>
                    
                    <br />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>


               
        </asp:Panel> 
        
            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
            <br />
          </div>
 </div>




                <!-- DataSource -->
  
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                    ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectClientGridByCompany" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="CompanyID" SessionField="CompanyID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>


                         <asp:SqlDataSource ID="dsProject" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                    ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectProject" 
                    SelectCommandType="StoredProcedure"></asp:SqlDataSource>
 <!-- end DataSource -->

</asp:Content>
