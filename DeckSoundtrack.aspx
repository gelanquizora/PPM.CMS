<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true"
    CodeFile="DeckSoundtrack.aspx.cs" Inherits="DeckSoundtrack" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript">
        function UserDeleteConfirmation() {
            if (confirm("Are you sure you want to delete this record?"))
                return true;
            else
                return false;
        }

    </script>

    <link rel="stylesheet" href="css/foundation.css" />
<link rel="stylesheet" href="css/mainStyle.css" />
<link rel="stylesheet" href="css/normalize.css" />
<link rel="stylesheet" href="js/vendor/build/mediaelementplayer.min.css" />
<script src="js/vendor/modernizr.js"></script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <ul>
        <li class="blue-box"><a href="#">
            <div class="box-inside">
                <img src="images/thumbnail/soundtrack.png" alt="Soundtrack"  />
            </div>
            
        </a></li>
        <li class="red-box"><a href="#" runat="server" id="btnBack">
            <div class="box-inside">
               <img src="images/thumbnail/back.png" alt="Back"  />
            </div>
          
        </a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main-columns">
         	<div class="container">
                	<div class="top-title">
                    	<h6 class="large-12 medium-12 left">Soundtrack</h6>
                        <dl class="tabs left" data-tab>
                                <dd class="active">
                                    <a href="#panel2-1">
                                        <span class="fontawesome-reorder"></span>
                                    </a>
                          </dd> 
                                <dd>
                                    <a href="#panel2-2">
                                        <span class="fontawesome-th"></span>
                                    </a>  <script src="js/vendor/jquery.js"></script>
    <script src="js/foundation.min.js"></script>	
	<script src="js/vendor/build/mediaelement-and-player.min.js"></script>
	
    <!--<script>
        jQuery.noConflict();
        jQuery(document).ready( function(){
            jQuery('#flip').jcoverflip();       
        });
    </script>-->
	
    <!--<script type="text/javascript" src="js/vendor/main.js"> </script>-->
    
    <script type="text/javascript">
        $(document).foundation();
        $('audio,video').mediaelementplayer();
    </script>
                                </dd> 
                      </dl> 
                </div>
                    <div class="content-container">
                    	
                        <div class="table-container">
                        	
                        	<div class="tabs-content"> 
                            	<div class="content active" id="panel2-1"> 
                                   <asp:HiddenField ID="HiddenFieldSoundID" runat="server" />
                               

                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View4" runat="server">
                                    <asp:Button ID="Button1" runat="server" Text="Add New Item" OnClick="Button1_Click"
                                        CssClass="small radius button" /><br />
                                    <br />
                                    <asp:GridView ID="gvSoundtrack" runat="server" OnRowCommand="gvSoundtrack_RowCommand" OnRowDataBound="gvSoundtrack_RowDataBound"
                                        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" DataSourceID="dsSoundtrack"
                                        DataKeyNames="SoundID, SoundFile, CoverPath">
                                        <Columns>
                                             <asp:TemplateField HeaderText="Cover" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                       
                                                    <asp:Image ID="imgCover" runat="server"  width="100" height="90"/>
                                                    </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="File" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%--       <img src='template/<%#DataBinder.Eval(Container, "DataItem.TemplateID")%>.jpg' width="100" height="90" />--%>
                                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                                  <%--  <audio controls>  <source  src="repository/<%#DataBinder.Eval(Container, "DataItem.SoundFile")%>" type="audio/mpeg"> 	Your browser does not support the audio element. 	</audio>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ACTION" ItemStyle-Width="120px">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="lnkEdit" ToolTip='<%# Eval("SoundID") %>' CommandName="edt"
                                                        CommandArgument='<%# Eval("SoundID") %>' runat="server" ImageUrl="~/images/187-pencil.png">
                                                    </asp:ImageButton>
                                                    <asp:ImageButton ID="lnkDelete" ToolTip='<%# Eval("SoundID") %>' CommandName="del"
                                                        CommandArgument='<%# Eval("SoundID") %>' OnClientClick="return UserDeleteConfirmation();"
                                                        runat="server" ImageUrl="~/images/delete.png"></asp:ImageButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No Record Found
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </asp:View>
                                <asp:View ID="View1" runat="server">
                                    <asp:Label ID="lblErrorAdd" runat="server" Font-Bold="true" ForeColor="red"></asp:Label>
                                    <div class="row">
                                        <div class="large-8 columns">
                                            <label>
                                                File</label>
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                        </div>
                                    </div>
                                     <div class="row">
                                        <div class="large-8 columns">
                                            <label>
                                                Cover</label>
                                            <asp:FileUpload ID="FileUpload3" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-8 columns">
                                            <label>
                                            </label>
                                            <asp:Button ID="BtnSave" CssClass="small radius button" runat="server" Text="Save"
                                                OnClick="BtnSaveSound_Click" />&nbsp;&nbsp;<asp:Button ID="BtnCancel" runat="server"
                                                Text="Cancel" CssClass="small radius button" OnClick="BtnCancel_Click" CausesValidation="false" />
                                        </div>
                                    </div>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <asp:Button ID="btnEdit" CssClass="small radius button" runat="server" Text="Edit"
                                        OnClick="btnEditSound_Click" />
                                    <%--         <asp:Button ID="btnCancelEditMap" runat="server" Text="Back" onclick="btnCancelEditSound_Click" />--%>
                                    <div class="row">
                                        <div class="large-8 columns">
                                            <label>
                                                Image</label>
                                            <asp:Image ID="Image1" runat="server" Width="200px" Height="200px" /><br />
                                            <asp:Label ID="lblFileView" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <asp:HiddenField ID="HiddenFieldViewID" runat="server" />
                                </asp:View>
                                <asp:View ID="View3" runat="server">
                                    <div class="row">
                                        <div class="large-8 columns">
                                            <label>
                                                File</label>
                                            <asp:FileUpload ID="FileUpload2" runat="server" />
                                            <br />
                                            <asp:Label ID="lblFileEdit" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                     <div class="row">
                                        <div class="large-8 columns">
                                            <label>
                                                Cover</label>
                                            <asp:FileUpload ID="FileUpload4" runat="server" /> 
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="large-8 columns">
                                            <label>
                                            </label>
                                            <asp:Button ID="BtnUpdate" CssClass="small radius button" runat="server" Text="Update"
                                                OnClick="BtnUpdateSound_Click" />&nbsp;&nbsp;<asp:Button ID="BtnCancel2" runat="server"
                                                Text="Cancel" CssClass="small radius button" OnClick="BtnCancel2_Click" CausesValidation="false" />
                                        </div>
                                    </div>
                                </asp:View>
                            </asp:MultiView>
                                     
                                </div> 
                                <div class="content" id="panel2-2"> 
                                 
                                
                                   <div class="slider-container"> 
                                   		<div class="medium-12 columns">
                                        	<div class="cover-flip">
                                            	<iframe width="100%" runat="server" id="frmCarousel" height="500" frameborder="0" src="iframe/carousel/carousel.aspx?PresentationID=36"  ></iframe>
                                            </div>
                                        </div>
                                        <br style="clear:both">
                               	   </div>
                                
                            	</div>
                                
                            
                        </div>
                    </div>
                </div>
            </div>
    </div>

      <asp:SqlDataSource ID="dsSound" runat="server" ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                                SelectCommand="sp_SelectSound" ProviderName="System.Data.SqlClient" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="PresentationID" QueryStringField="PresentationID"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                         
                            <asp:SqlDataSource ID="dsSoundtrack" runat="server" ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                                ProviderName="System.Data.SqlClient" SelectCommand="sp_SelectSound" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="PresentationID" QueryStringField="PresentationID"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>

    <script src="js/vendor/jquery.js"></script>
    <script src="js/foundation.min.js"></script>	
	<script src="js/vendor/build/mediaelement-and-player.min.js"></script>
	
    <!--<script>
        jQuery.noConflict();
        jQuery(document).ready( function(){
            jQuery('#flip').jcoverflip();       
        });
    </script>-->
	
    <!--<script type="text/javascript" src="js/vendor/main.js"> </script>-->
    
    <script type="text/javascript">
        $(document).foundation();
        $('audio,video').mediaelementplayer();
    </script>

</asp:Content>
