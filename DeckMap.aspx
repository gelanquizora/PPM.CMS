<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true" CodeFile="DeckMap.aspx.cs" Inherits="DeckMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
        .gallerycontainer{
        position: absolute;
        /*Add a height attribute and set to largest image's height to prevent overlaying*/
        }

        .thumbnail img{
        border: 1px solid white;
        margin: 0 5px 5px 0;
        }

        .thumbnail:hover{
        background-color: transparent;
        }

        .thumbnail:hover img{
        border: 1px solid grey;
        }

        .thumbnail span{ /*CSS for enlarged image*/
        position: absolute;
        background-color: #000000;
        padding: 5px;
        left: 300px;
        border: none;
        display: none; /* Changed this */
        color: black;
        text-decoration: none;
        top: 0;
        left: 300px; /*position where enlarged image should offset horizontally */
        z-index: 50;

        }

        .thumbnail span img{ /*CSS for enlarged image*/
        border-width: 0;
        padding: 2px;
        }

</style>
<%--<script>
    $('.thumbnail').each(function () {
        $(this).click(function () {
            $('.thumbnail span').hide();
            $(this).find('span').show('slow');
        });
    });
</script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<ul>
            	  <li class="odd-box">
                	<a href="#">
                        <div class="box-inside">
                        	<img src="images/icons/icon-maps.png" alt="Maps">
                        </div>
                        <div class="box-title">Map</div>
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

    <!--<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>-->
<asp:SqlDataSource ID="dsMap" runat="server" ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                            SelectCommand="sp_SelectMap" 
                ProviderName="System.Data.SqlClient" 
        SelectCommandType="StoredProcedure">
                 <SelectParameters>
                     <asp:QueryStringParameter Name="PresentationID" 
                         QueryStringField="PresentationID" Type="Int32" />
                 </SelectParameters>
            </asp:SqlDataSource>
<asp:HiddenField ID="HiddenFieldMapID" runat="server"  Value="0"/>
    <!--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>-->


    <div class="main-columns">
            	<div class="container">
                	<div class="top-title">
                    	<h6>Maps</h6>
                    </div>
                    <div class="content-container" style="height: 700px;">
                    	   <asp:MultiView ID="MultiView1" runat="server">

                             

                <asp:View ID="View2" runat="server">
 
        
                            <div class="action_bar">
                            <asp:Button ID="btnEdit" runat="server" Text="Add New" onclick="btnEditAgency_Click" CssClass="small radius button" />
                            </div>
                            <br />
                            <br />
 
							<div class="row">
                            
                                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1"  OnItemCommand="Repeater1_OnItemCommand">
                                        <HeaderTemplate>
                                           	<div class="gallerycontainer" style="width: 925px;">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                           <asp:LinkButton ID="lnkDelete" runat="server"  CssClass="fontawesome-remove icon-actions" style="position: absolute;"  CommandName="Delete" ToolTip="Delete"
                                         CommandArgument='<%# Eval("MapID") + "," + Eval("MapPath") %>' OnClientClick="return confirm('Are you sure you want to delete this item?');" ></asp:LinkButton>
                                        <a class="thumbnail" href="#thumb">
                                           <img src='<%#DataBinder.Eval(Container, "DataItem.MapPath")%>' width="300px" height="300px" border="0" />
                                         </a>
                                     
                                              
                                         
                                        </ItemTemplate>
                                       
                                        <FooterTemplate>
                                   </div></FooterTemplate>
                                  
                                    </asp:Repeater>
                               

   
   
<br />

</div>
                          

                    <asp:HiddenField ID="HiddenFieldViewID" runat="server" />
                    <br />
                       <asp:Label ID="lblErrorAdd" runat="server" Text=""></asp:Label>

                </asp:View>

                <asp:View ID="View3" runat="server">
     
          
                                <div class="row">
                            	<div class="large-2 medium-2 columns">
                                	<label class="left">File</label>
                                </div>
                                <div class="large-11 medium-11 columns">
                                	<div class="custom-file-upload">
                                        <asp:FileUpload ID="FileUpload2" runat="server" CssClass="button_small greyishBtn" name="myfiles[]" multiple />
                                    </div>
                                    <br />
                                    <br />
                                    <div class="large-11 medium-11">
                                    	<asp:Label ID="lblFileEdit" runat="server" CssClass="previewBox"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div class="row">
                            	<div class="large-11 medium-11 columns">
                                 <asp:Button ID="BtnSave" runat="server" Text="SaveNew" onclick="BtnSaveAgency_Click"  CssClass="small radius button" />
                                    <asp:Button ID="btnCancelEdit" runat="server" Text="Cancel" onclick="BtnCancelEdit_Click" CssClass="small radius button" />
                                </div>
                            </div>

 

                </asp:View>

</asp:MultiView>
                    </div>
                </div>
           
   
 
  

   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                            SelectCommand="sp_SelectMapGallery" 
                ProviderName="System.Data.SqlClient" 
        SelectCommandType="StoredProcedure">
                 <SelectParameters>
                     <asp:QueryStringParameter Name="PresentationID" 
                         QueryStringField="PresentationID" Type="Int32" />
                 </SelectParameters>
            </asp:SqlDataSource>
</asp:Content>

