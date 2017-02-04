<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.master" AutoEventWireup="true" CodeFile="DeckDirectorsTreatment.aspx.cs" Inherits="DeckDirectorsTreatment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" href="/js/vendor/cl_editor/jquery.cleditor.css" />
<link rel="stylesheet" href="/css/touchcarousel.css" />
<link rel="stylesheet" href="/css/minimal-light-skin.css" />


<style type="text/css">
	/*.tc-paging-container{
		display:none;
	}*/
	.touchcarousel .tc-paging-item {			
	float:left;	
	cursor:pointer;		
	position:relative;
	display:block;	
	text-indent: inherit;
	color:white;
	background:none !important;	
}
.touchcarousel.minimal-light .tc-paging-item {
	width:0;
	height:0;	
	-moz-opacity: 0.8;	
	-webkit-opacity: 0.8;	
	opacity: 0.8;
	color:#242021;	
}
.touchcarousel.minimal-light .tc-paging-item.current {	
	color:white;
	text-decoration:none;
	font-size:16px;
	width: 22px;
	height: 22px;	
	
}
.touchcarousel.minimal-light .tc-paging-item:hover {		
			
}
#carousel-single-image .tc-paging-container{
	width:auto;
	margin-top:-89px;
	margin-left:10px;
}
#carousel-single-image .touchcarousel-item span{
	display:none;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<ul>
            <li class="blue-box">
                	<a href="#">
                        <div class="box-inside">
                          <img src="images/thumbnail/directors.png" alt="Director's Treatment"  />
                        </div>
                       
                     </a>
                </li>
                <li class="red-box">
                	<a href="#" runat="server" id="btnBack">
                        <div class="box-inside">
                         <img src="images/thumbnail/back.png" alt="Back"  />
                        </div>
                       
                    </a>
                </li>
            </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="main-columns">
            	<div class="container">
                	<div class="top-title">
                    	<h6 class="large-12 medium-12 left">Director's Treatment</h6>
                        <dl class="tabs left" data-tab>
                                <dd class="active">
                                    <a href="#panel2-1">
                                        <span class="fontawesome-reorder"></span>
                                    </a>
                                </dd> 
                                <dd>
                                    <a href="#panel2-2">
                                        <span class="fontawesome-th"></span>
                                    </a>
                                </dd> 
                        	</dl> 
                    </div>
                    <div class="content-container">
                    	
                        <div class="table-container">
                        	
                        	<div class="tabs-content"> 
                            	<div class="content active" id="panel2-1"> 
                                	 
                                        <asp:Panel ID="Panel1" runat="server">
                                         <asp:Button ID="btnAdd" runat="server" Text="Add New Panel" CssClass="small radius button" onclick="BtnAddNew_Click" /> 
                                          <asp:Button ID="btnVideos" runat="server" Text="Videos" CssClass="small radius button"  OnClick="btnVideos_Click"/>
                                         <asp:Button ID="btnPassode" runat="server" Text="Passcode" CssClass="small radius button"  OnClick="btnPasscode_Click"/>
                                      
                                    <br>
                                    <br>
                                                 <asp:GridView ID="gvTreatment"  Width ="100%" runat="server" OnRowCommand ="gvTreatment_RowCommand" AutoGenerateColumns="False" AllowPaging="True" 
                                    AllowSorting="True" DataSourceID="dsTreatment" Visible="true"  OnRowDataBound="gvTreatment_RowDataBound" DataKeyNames="ImageFile">
                                    <Columns>
                                 <%--  <asp:ImageField DataImageUrlField="ImageFile" DataImageUrlFormatString="~/repository/{0}"  ControlStyle-Width="100"  ControlStyle-Height="100"  >
                
                                   </asp:ImageField>--%>

                                   <asp:TemplateField>
                                   <ItemTemplate>
                                    <%-- <img src='repository/<%#DataBinder.Eval(Container, "DataItem.ImageFile")%>' width="100" height="100" /> --%>
                                       <asp:Image ID="img" runat="server"   Width="100" Height="100"/>
                                   </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:BoundField DataField="VoiceOver" HeaderText="Voice Over" SortExpression="VoiceOver" />
                                    <asp:BoundField DataField="Rank" HeaderText="Panel No"   SortExpression="Rank" />
                   
                                   
                                        <asp:TemplateField HeaderText="ACTION" ItemStyle-Width="120px">
                                            <ItemTemplate>
                                               
                                      <asp:LinkButton ID="LinkButton1" runat="server" CssClass="fontawesome-pencil icon-actions" CommandName="edt" ToolTip="Edit Details"
                                        CommandArgument='<%# Eval("DTID") %>'  ></asp:LinkButton>
                                              <asp:LinkButton ID="LinkButton2" runat="server"  CssClass="fontawesome-remove icon-actions"  CommandName="del" ToolTip="Delete"
                                        CommandArgument='<%# Eval("DTID") %>'  OnClientClick="return confirm('Are you sure you want to delete this panel?');" ></asp:LinkButton>


                                
                                            </ItemTemplate>
                                        </asp:TemplateField>

                         

                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record Found
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                    <br>
                                    <br>
                                      
 
                                </asp:Panel>
                              <asp:Panel ID="pnlVideos" runat="server" Visible="false">

   
                                          <asp:Panel ID="pnlVideoGrid" runat="server">
                                        <asp:Button ID="btnVideoEdit" runat="server" Text="Add New"  OnClick="btnVideoAddNew_Click"  />
                                            <asp:GridView ID="gvVideos"  Width ="100%" runat="server"  AutoGenerateColumns="False" AllowPaging="True" CssClass="activity_datatable"
                                                                        AllowSorting="True" DataSourceID="dsVideos" Visible="true"   DataKeyNames="DTVideoID, Path, Title, Rank"  PageSize="1"  OnRowCommand="gvVideos_RowCommand">
                                                                        <Columns>
                                                                        <asp:BoundField DataField="Rank" HeaderText="Rank"   SortExpression="Rank" />
                                                                         <asp:BoundField DataField="Title" HeaderText="Title"   SortExpression="Title" />
                                                                        <asp:TemplateField >
                                                                        <ItemTemplate>
                                                                      <%--  <%# Eval("Path") %>
                                                                        <br />--%>
                                                                        <video width="320" height="240" controls>
                                                                          <source src='<%# Eval("Path") %>' type="video/mp4">
                                                                           
                                                                          Your browser does not support the video tag.
                                                                        </video>
                                                                        </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="ACTION" ItemStyle-Width="120px">
                                                                           <ItemTemplate>
                                                                                   <asp:ImageButton ID="lnkEdit" ToolTip='<%# Eval("DTVideoID") %>' CommandName="edt"
                                                                        CommandArgument= "<%# ((GridViewRow) Container).RowIndex %>"  runat="server" ImageUrl="~/images/187-pencil.png">
                                                                    </asp:ImageButton>
                                                                     <asp:ImageButton ID="lnkDelete" ToolTip='<%# Eval("DTVideoID") %>' CommandName="del"
                                                                        CommandArgument='<%# Eval("DTVideoID") %>'   OnClientClick="if ( ! confirm('Are you sure you want to delete this video?')) return false;" runat="server" ImageUrl="~/images/delete.png">
                                                                    </asp:ImageButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                         
                                                                        </Columns>
                                                                        <EmptyDataTemplate>
                                                                            No Record Found
                                                                        </EmptyDataTemplate>
                                                                    </asp:GridView>
                                        </asp:Panel>
                                         <asp:Panel ID="pnlVideoEntry" runat="server" Visible="false">
                                          <%--   <asp:Label ID="Label1" runat="server" Text=""></asp:Label>--%>
                                            <div class="row">
                            	                <div class="large-8 columns">
                                	            <label style="color: Red">*Must be .mp4
                                                <br /> *Maximum file size 100MB
                                                </label>
                                                           
                                                     </div>
                                                 </div>
                                               <div class="row">
                            	                <div class="large-8 columns">
                                	            <label>File</label>
                                                             <asp:FileUpload ID="FileUpload1" runat="server" />  
                                                     </div>
                                                 </div>

                                              <div class="row">
                            	                <div class="large-8 columns">
                                	            <label>Rank</label>
                                                            <asp:TextBox ID="TextBox1" runat="server" MaxLength="10"  Width="50%"></asp:TextBox><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtRank" ErrorMessage="Not Valid" MaximumValue="2147483647" MinimumValue="-2147483648" SetFocusOnError="True" Type="Integer" ValidationGroup="Add"></asp:RangeValidator>
                                       <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" ValidChars="123456789"
                                                                        TargetControlID="txtRank">
                                                                    </asp:FilteredTextBoxExtender>
                                                                    <asp:RequiredFieldValidator
                                                  ID="rfvTopic" runat="server" ErrorMessage="*" ControlToValidate ="txtRank" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                  
                                                     </div>
                                                 </div>
                                                    <div class="row">
                            	                <div class="large-8 columns">
                                	            <label>Title</label>
                                                                   <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                                                      <asp:RequiredFieldValidator
                                                  ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate ="txtTitle" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                              
                                                     </div>
                                                 </div>

                                                    <div class="row">
                            	                <div class="large-8 columns">
                                	            <label> </label>
                                                              <asp:Button ID="Button1" runat="server" CssClass="button_small whitishBtn" 
                                                            onclick="BtnSaveVideo_Click" Text="Save"   />
                                                        <asp:Button ID="Button2" runat="server" CssClass="button_small whitishBtn" 
                                                            onclick="btnVideoSaveCancel_Click" Text="Cancel" />
                                                               <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>
                                                     </div>
                                                 </div>
                                                  
                                   
                                        </asp:Panel>
                                          <asp:Panel ID="pnlVideoEdit" runat="server" Visible="false">
                                                 
                                          <div class="row">
                            	                <div class="large-8 columns">
                                	            <label>Rank</label>
                                                          <asp:TextBox ID="txtEditRank" runat="server" MaxLength="10"  Width="50%"></asp:TextBox><asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtRank" ErrorMessage="Not Valid" MaximumValue="2147483647" MinimumValue="-2147483648" SetFocusOnError="True" Type="Integer" ValidationGroup="Edit"></asp:RangeValidator>
                                       <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" ValidChars="123456789"
                                                                        TargetControlID="txtRank">
                                                                    </asp:FilteredTextBoxExtender>
                                                                    <asp:RequiredFieldValidator
                                                  ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate ="txtEditRank" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                     </div>
                                                 </div>
                                                    <div class="row">
                            	                <div class="large-8 columns">
                                	            <label>Title</label>
                                                         <asp:TextBox ID="txtEditTitle" runat="server"></asp:TextBox>
                                                      <asp:RequiredFieldValidator
                                                  ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate ="txtEditTitle" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                     </div>
                                                 </div>

                                                    <div class="row">
                            	                <div class="large-8 columns">
                                	            <label> </label>
                                                     <asp:Label ID="lblEditError" runat="server" ForeColor="Red" Text=""></asp:Label>
                                           
                                                        <asp:Button ID="btnUpdate" runat="server" CssClass="button_small whitishBtn" 
                                                            onclick="BtnUpdateVideo_Click" Text="Update" ValidationGroup="Edit" />
                                                        <asp:Button ID="Button3" runat="server" CssClass="button_small whitishBtn" 
                                                            onclick="BtnCancelVideo_Click" Text="Cancel" />    
                                                     </div>
                                                 </div>
                                    
                                          </asp:Panel>
                                     
                          
                                    </asp:Panel>     
                                 
                                         <asp:Panel ID="pnlPasscode" runat="server" Visible="false">
                                             <asp:Button ID="btnBackPasscode" runat="server" Text="Back"    onclick="btnBackPasscode_Click" />
                                             <br />
                                             <br />
                                              Passcode:  <asp:TextBox ID="txtPasscode" runat="server" ReadOnly="true" Font-Bold="true" Font-Size="X-Large"></asp:TextBox>
 
                                              <asp:Button ID="btnGenerate" runat="server" Text="Generate New"    onclick="btnGenerate_Click" />
                              </asp:Panel>
                                </div> 
                                <div class="content" id="panel2-2"> 
                               
                                
                                   <div class="slider-container"> 

              <asp:Repeater ID="Repeater1" runat="server" DataSourceID="dsTreatment" OnItemDataBound="Repeater1_ItemDataBound"  >
                    <HeaderTemplate><ul class="example-orbit swipe-next" data-options="animation:slide;    pause_on_hover:false;
                  animation_speed:400;  navigation_arrows:true;  bullets:true;"  data-orbit></HeaderTemplate>   
                    <ItemTemplate >
            

                <li  > 
                    <asp:HiddenField ID="hdnImagePath"  Value='<%#DataBinder.Eval(Container, "DataItem.ImageFile")%>' runat="server" />
                     <asp:Image ID="imgSlide"  runat="server"  AlternateText="" />
                       <!--<asp:Label runat="server" Text="Label" id="lbl"></asp:Label>-->
                    <div class="orbit-caption"> 
                           <%#DataBinder.Eval(Container, "DataItem.VoiceOver")%> <br>
                            <%#DataBinder.Eval(Container, "DataItem.Description")%> 
                             </div> 
                 </li> 


                    </ItemTemplate>
                    <FooterTemplate></ul></FooterTemplate>
                   
                    </asp:Repeater>

                   </div>

                     
                                
                            </div>
                            
                        </div>
                    </div>

                       <asp:Panel ID="Panel2" runat="server" Visible="false">
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                          <div class="row">
                            	<div class="large-8 columns">
                                <asp:Button ID="btnCancel" runat="server" Text="Back" onclick="BtnCancel_Click" Width="94px" CssClass="small radius button"  /> 
                                </div> 
                            </div>
                            <br />
                            
                              <div class="row">
                            	<div class="large-8 columns">
                                    *Use image with 1024px X 668px size for best result. <br />
                                </div> 
                            </div>
                            <br />
                        <div class="row">
                            	<div class="large-8 columns">
                                	<label>Image File</label>
                                         <asp:FileUpload ID="FileUpload2" runat="server" />
                                        </div>
                            </div>
                             <div class="row">
                            	<div class="large-8 columns">
                                	<label> </label>
                                         <asp:Label ID="lblFile" runat="server"></asp:Label>  
                                   </div>
                            </div>
                            <div class="row">
                            	<div class="large-8 columns">
                                	<label>Voice Over</label>
                                    <asp:TextBox ID="txtVoiceOver" runat="server" MaxLength="50"  Width="200px" ></asp:TextBox>
                                 </div>
                            </div>
                               <div class="row">
                            	<div class="large-8 columns">
                                	<label>Description</label>
                                  <asp:TextBox ID="txtDescription"     runat="server" MaxLength="2147483647"  Width="400px" Height="200px"   TextMode="MultiLine"></asp:TextBox>
                                  </div>
                            </div>

                               <div class="row">
                            	<div class="large-8 columns">
                                	<label>Panel</label>
                                           <asp:TextBox ID="txtRank" runat="server" MaxLength="10"  Width="50%"></asp:TextBox><asp:RangeValidator ID="rvRank" runat="server" ControlToValidate="txtRank" ErrorMessage="Not Valid" MaximumValue="2147483647" MinimumValue="-2147483648" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="123456789"    TargetControlID="txtRank">
                                                </asp:FilteredTextBoxExtender>
                                    </div>
                            </div>


                             <div class="row">
                            	<div class="large-8 columns">
                              
                                    <asp:Button ID="BtnSave" runat="server" Text="Save" onclick="BtnSave_Click" Width="94px" CssClass="small radius button" />
                                     <asp:Button ID="btnUpdateDT" runat="server" Visible="false" Text="Save" onclick="BtnUpdate_Click" Width="94px" CssClass="small radius button"   />
                                </div> 
                            </div>
                                 <asp:Label ID="lblErrorAdd" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label> 

                    </asp:Panel>
                </div>
            </div>
        </div>

    



<!-- DataSource -->
   <asp:SqlDataSource ID="dsTreatment" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="sp_SelectDirectorsTreatment" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="PresentationID" 
                QueryStringField="PresentationID" Type="Int32" />
        </SelectParameters>
                  </asp:SqlDataSource>
 
 
<!-- end DataSource -->
    


     

    <!---- SQL DataSoure ----->
       <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="sp_SelectDirectorsTreatmentVideoByPresentationID" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="PresentationID" 
                QueryStringField="PresentationID" Type="Int32" />
        </SelectParameters>
                  </asp:SqlDataSource>


                  <asp:SqlDataSource ID="dsNewVideos" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="sp_SelectDirectorsTreatmentVideoByPresentationID" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="PresentationID"   QueryStringField="PresentationID" Type="Int32" />
        </SelectParameters>
                  </asp:SqlDataSource>

                       <asp:SqlDataSource ID="dsVideos" runat="server" 
         ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="sp_SelectDirectorsTreatmentVideoByPresentationID" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="PresentationID" 
                QueryStringField="PresentationID" Type="Int32" />
        </SelectParameters>
                  </asp:SqlDataSource>
    <!---- end ------------->
</asp:Content>

