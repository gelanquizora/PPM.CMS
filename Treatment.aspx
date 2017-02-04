<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Blank.master" AutoEventWireup="true" CodeFile="Treatment.aspx.cs" Inherits="Treatment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="./css/style.css" rel="stylesheet" type="text/css" media="screen" />
<link rel="stylesheet" href="./css/touchcarousel.css" />
<link rel="stylesheet" href="./css/main.css" />
<link rel="stylesheet" href="./css/minimal-light-skin.css" />
<link rel="stylesheet" href="./css/reset.css" />

<link rel="stylesheet" href="./css/typography.css" />

<script src="./js/jquery.min.js" type="text/javascript"></script>
<script src="./js/jquery.touchcarousel-1.1.js" type="text/javascript"></script>
 
<script type="text/javascript">
     $(document).ready(function () {

         $("#<%= Panel2.ClientID %>").hide();
         $("#<%= Panel3.ClientID %>").hide();
         $("#<%= Panel4.ClientID %>").hide();
     });
    
     function addnew() {

         $("#<%= Panel1.ClientID %>").fadeOut('slow');
         $("#<%= Panel2.ClientID %>").fadeIn('slow');
         $("#quick_actions").fadeOut('slow');

     }

     function edit() {

         $("#<%= Panel1.ClientID %>").fadeOut('slow');
         $("#<%= Panel2.ClientID %>").fadeIn('slow');


     }


     function passcode() {

         $("#<%= Panel1.ClientID %>").fadeOut('slow');
         $("#<%= Panel3.ClientID %>").fadeIn('slow');


     }

     function videos() {

         $("#<%= Panel1.ClientID %>").fadeOut('slow');
         $("#<%= Panel4.ClientID %>").fadeIn('slow');


     }

     function view() {

         location.reload();


     } 
     function back() {

         $("#<%= Panel2.ClientID %>").fadeOut('slow');
         $("#<%= Panel1.ClientID %>").fadeIn('slow');
    }
</script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   

   <asp:Panel ID="Panel1" runat="server"  >
   <div class="action_bar">
        <a class="button_big" href="#" onclick="edit();"><span class="iconsweet">8</span>Edit</a> 
       <a class="button_big" href="#" onclick="videos();"><span class="iconsweet">F</span>Video(s)</a> 
        <a class="button_big" href="#" onclick="passcode();"><span class="iconsweet">y</span>Passcode</a> 
   </div>
   
    	<div id="carousel-single-image" class="touchcarousel   minimal-light">       
	 
              <asp:Repeater ID="Repeater1" runat="server" DataSourceID="dsTreatment" OnItemDataBound="Repeater1_ItemDataBound"  >
                    <HeaderTemplate><ul class="touchcarousel-container"></HeaderTemplate>   
                    <ItemTemplate >
                      <li class="touchcarousel-item">
                       <asp:HiddenField ID="hdnImagePath"  Value='<%#DataBinder.Eval(Container, "DataItem.ImageFile")%>' runat="server" />
                         <asp:Image ID="imgSlide"  runat="server"  AlternateText=""/>
                        <asp:Label runat="server" Text="Label" id="lbl"></asp:Label>
   
			  
                    <span>
   
                    	<strong><%#DataBinder.Eval(Container, "DataItem.VoiceOver")%></strong><br>
                        <em><%#DataBinder.Eval(Container, "DataItem.Description")%></em>
                    </span 
				</li>
                    </ItemTemplate>
                    <FooterTemplate></ul></FooterTemplate>
                   
                    </asp:Repeater>
		</div>
    
    <script type="text/javascript">
        jQuery(function ($) {

            $("#carousel-single-image").touchCarousel({
                pagingNav: true,
                scrollbar: false,
                directionNavAutoHide: false,
                itemsPerMove: 1,
                loopItems: true,
                directionNav: false,
                autoplay: false,
                autoplayDelay: 2000,
                useWebkit3d: true,
                transitionSpeed: 400
            });
            $("#carousel-single-image").bind('touchstart click', function () {
                e.preventDefault();
                $("#carousel-single-image").click(function () {
                    alert("hello");
                    $('span').delay(500).show('slide', { direction: 'up' }, 500);
                })
            });

        });
    </script>  
  
  </asp:Panel>
   <asp:Panel ID="Panel2" runat="server" CssClass="widget_body">
      <div class="action_bar">
          <a class="button_big" href="#" onclick="view();"><span class="iconsweet"></span>View</a> 
      </div>
        <iframe runat="server"  id="frmEntry" width="100%" height="800px"></iframe>
   </asp:Panel>

    <asp:Panel ID="Panel3" runat="server">
      <div class="action_bar">
          <a class="button_big" href="#" onclick="view();"><span class="iconsweet"></span>View</a> 
      </div>
 
<iframe runat="server"  id="frmPasscode" width="100%" height="800px"></iframe>
     
    </asp:Panel>
      <asp:Panel ID="Panel4" runat="server"  >
      <div class="action_bar">
          <a class="button_big" href="#" onclick="view();"><span class="iconsweet"></span>View</a> 
      </div>
            <iframe runat="server"  id="frmVideos" width="100%" height="800px"></iframe>
     
    </asp:Panel>

  <asp:HiddenField ID="HiddenField1" runat="server" />

  <asp:SqlDataSource ID="dsTreatment" runat="server" 
        ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="sp_SelectDirectorsTreatment" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="PresentationID" 
                QueryStringField="PresentationID" Type="Int32" />
        </SelectParameters>
                  </asp:SqlDataSource>
 
  
</asp:Content>

