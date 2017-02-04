<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true" CodeFile="Project.aspx.cs" Inherits="Project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

<ul class="main-nav">
          <%--      <li class="home">
                    <a href="#">Home</a>
                </li>
                <li class="clients" >
                    <a href="Clients.aspx" >Clients</a>
                </li>--%>
                <li class="clients">
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
                	<a href="#" runat="server" id="lnkCover" title="Cover">
                        <div class="box-inside" >
                        	<%--<span class="fontawesome-briefcase icon-side-bar"></span>--%>
                            <img src="images/thumbnail/cover.png" alt="Cover"/>
                        </div>
                     
                      
                     </a>
                </li>
                <li class="even-box"  >
                	<a href="#" runat="server" id="lnkAttendees" title="Attendees">
                        <div class="box-inside">
                            <img src="images/thumbnail/attendees.png" alt="Attendees" />
                        </div>
                     
                    </a>
                </li>
                <li class="odd-box">
                	<a href="#" runat="server" id="lnkAgenda" title="Agenda">
                        <div class="box-inside" >
                        	     <img src="images/thumbnail/agenda.png"   alt="Agenda" />
                        </div>
                  
                     </a>
                </li>
                  <li class="even-box">
                	<a href="#" runat="server" id="lnkAdvertising" title="Advertising Objectives">
                        <div class="box-inside">
                        	 <img src="images/thumbnail/advertising.png" alt="Advertising Objectives"  />
                        </div>
                       
                       
                    </a>
                </li>
                <li class="odd-box">
                	<a href="#" runat="server" id="lnkTargetMarket" title="Target Market">
                        <div class="box-inside">
                       	 <img src="images/thumbnail/target.png"  alt="Target Market" />
                        </div> 
                     </a>
                </li>
                <li class="even-box">
                	<a href="#" runat="server" id="lnkMoodandTone" title="Mood & Tone">
                        <div class="box-inside">
                          <img src="images/thumbnail/mood.png" alt="Mood & Tone"  />
                        </div>
                     
                    </a>
                </li>
                <li class="odd-box">
                	<a href="#" runat="server" id="lnkAgencyBoard" title="Agency Board">
                        <div class="box-inside">
                            <img src="images/thumbnail/agency.png" alt="Agency Board"  />
                        </div>
                      
                     </a>
                </li>
                <li class="lightblue-box">
                	<a href="#" runat="server" id="lnkDirectorsTreatement" title="Director's Treatment">
                        <div class="box-inside">
                          <img src="images/thumbnail/directors.png" alt="Director's Treatment"  />
                        </div> 
                    </a>
                </li>
             <li class="blue-box">
                	<a id="A1" href="#" runat="server"   title="Notes">
                        <div class="box-inside">
                        	 <img src="images/thumbnail/notes.png" alt="Notes"  />
                        </div>
                        
                     </a>
           </li> 
                <li class="lightblue-box">
                	<a href="#" runat="server" id="lnkProductionDesign" title="Production Design">
                        <div class="box-inside">
                        	 <img src="images/thumbnail/production.png" alt="Production Design"  />
                        </div>
                     
                    </a>
                </li>
                <li class="blue-box">
                	<a href="#" runat="server" id="lnkLocations" title="Locations">
                        <div class="box-inside">
                        	 <img src="images/thumbnail/location.png" alt="Locations"  />
                        </div>
                        
                     </a>
                </li>
                <li class="lightblue-box" >
                	<a href="#" runat="server" id="lnkSoundtrack" title="Soundtrack">
                        <div class="box-inside">
                        	  <img src="images/thumbnail/soundtrack.png" alt="Soundtrack"  />
                        </div>
                      
                    </a>
                </li>
                <li class="blue-box">
                	<a href="#"  runat="server" id="lnkTimetable" title="Timetable">
                        <div class="box-inside">
                        	 <img src="images/thumbnail/timetable.png" alt="Timetable"  />
                        </div>
                        
                     </a>
                </li>
                <li class="lightblue-box">
                	<a href="#" runat="server" id="lnkMaps" title="Maps">
                        <div class="box-inside">
                        	 <img src="images/thumbnail/maps.png" alt="Maps"  />
                        </div>
                      
                    </a>
                </li>
                <li class="lightred-box">
                	<a href="#" runat="server" id="lnkDirectory" title="Directory">
                        <div class="box-inside">
                        	 <img src="images/thumbnail/directory.png" alt="Directory"  />
                        </div>
                   
                     </a>
                </li>
     
                <li class="red-box">
                	<a runat="server" id="btnBack"  title="Back">
                        <div class="box-inside">
                        	 <img src="images/thumbnail/back.png" alt="Back"  />
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
                    <div class="content-container">
                    	  <asp:Label ID="lblPresentationID" runat="server" style="display:none" />
                      <%--    <asp:Button ID="btnEdit" CssClass="small radius button" runat="server" Text="Edit"  OnClick="BtnEdit_Click"/>
                      --%>  <br>
                        <br>
                  
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
                                       <asp:DropDownList ID="ddlClientEdit" runat="server" DataSourceID ="SqlDataSource2" 
                    DataTextField ="ClientName" DataValueField ="ClientID">
                </asp:DropDownList>
                                
                                </div>
                            </div>
                               <div class="row">
                            	<div class="large-8 columns">
                                	<label>Last Build:</label>
                                      
                                        <asp:Label ID="lblBuild" runat="server" Text=""></asp:Label>
                                
                                </div>
                            </div>
                            
                            <div class="row">
                            	<div class="large-8 columns">
                            	  <asp:Button ID="Button1" CssClass="small radius button" runat="server" Text="Generate New Build"  OnClick="btnGenerateBuild_Click"/> </li>
                                

                                         <asp:Button ID="BtnUpdate" class="small radius button" runat="server" Text="Save" onclick="BtnUpdate_Click"  Visible="false"/>
                                       <asp:Button ID="BtnCancel" class="small radius button" runat="server" Text="Cancel" onclick="BtnCancelEdit_Click" Visible="false" />  
                                     

                                </div>
                            </div>
                    
                  	</div>
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