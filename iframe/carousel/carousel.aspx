<%@ Page Language="C#" AutoEventWireup="true" CodeFile="carousel.aspx.cs" Inherits="iframe_carousel_carousel" %>

<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Carousel</title>
<link rel="stylesheet" href="jquery-ui-1.7.2.custom.css" type="text/css" media="all" />
<script src="jquery-1.js" type="text/javascript"></script>
<script type="text/javascript" src="jquery-ui-1.js"></script>
<script type="text/javascript" src="jquery.coverflip.js"></script>
 
    
    <script>
        jQuery(document).ready(function () {
            jQuery('#flip').jcoverflip({
                current: 2,
                beforeCss: function (el, container, offset) {
                    return [
				$.jcoverflip.animationElement(el, { left: (container.width() / 2 - 210 - 110 * offset + 20 * offset) + 'px', bottom: '20px' }, {}),
				$.jcoverflip.animationElement(el.find('img'), { width: Math.max(10, 100 - 20 * offset * offset) + 'px' }, {})
				];
                },
                afterCss: function (el, container, offset) {
                    return [
				$.jcoverflip.animationElement(el, { left: (container.width() / 2 + 110 + 110 * offset) + 'px', bottom: '20px' }, {}),
				$.jcoverflip.animationElement(el.find('img'), { width: Math.max(10, 100 - 20 * offset * offset) + 'px' }, {})
				];
                },
                currentCss: function (el, container) {
                    return [
				$.jcoverflip.animationElement(el, { left: (container.width() / 2 - 100) + 'px', bottom: 0 }, {}),
				$.jcoverflip.animationElement(el.find('img'), { width: '200px' }, {})
				];
                },
                change: function (event, ui) {
                    jQuery('#scrollbar').slider('value', ui.to * 25);
                }
            });

            jQuery('#scrollbar').slider({
                value: 50,
                stop: function (event, ui) {
                    if (event.originalEvent) {
                        var newVal = Math.round(ui.value / 25);
                        jQuery('#flip').jcoverflip('current', newVal);
                        jQuery('#scrollbar').slider('value', newVal * 25);
                    }
                }
            });
        }); 
      
      
    </script>
<style type="text/css">
      /* Basic jCoverflip CSS */
	  .ui-jcoverflip {
        position: relative;
      }
      
      .ui-jcoverflip--item {
        position: absolute;
        display: block;
      }
      
      /* Basic sample CSS */
      #flip {
        height: 200px;
        width: 100%;
        margin-bottom: 50px;
      }
      
      #flip .ui-jcoverflip--title {
        position: absolute;
        bottom: -30px;
        width: 100%;
        text-align: center;
        color: #555;
      }
      
      #flip img {
        display: block;
        border: 0;
        outline: none;
      }
      
      #flip a {
        outline: none;
      }
      
      
      #wrapper {
        height: 300px;
        width: 100%;
        overflow: hidden;
        position: relative;
      }
      
      .ui-jcoverflip--item {
        cursor: pointer;
      }

      body {
        width:800px;
        padding: 0;
        margin: 0;
      }
      
      ul,
      ul li {
        margin: 0;
        padding: 0;
        display: block;
        list-style-type: none;
      }
      
      #scrollbar {
        position: absolute;
        left: 20px;
        right: 20px;
        
      }
</style>
</head>
<body>
    <form id="form1" runat="server">
 <div id="wrapper" style ="height: 500px;">
       
      
         <asp:Repeater ID="Repeater1" runat="server" DataSourceID="dsSound"  >
                    <HeaderTemplate> <ul id="flip" style="height: 300px;">
                    </HeaderTemplate>   
                    <ItemTemplate >
              <li>
                <span class="title">
                  <audio controls>  <source src="../../<%= Session["CompanyID"] %>/<%= Request.QueryString["PresentationID"] %>/SoundTrackFile/<%#DataBinder.Eval(Container, "DataItem.SoundFile")%>" type="audio/mpeg"> 	Your browser does not support the audio element. 	</audio>
                </span>
                <img src='../../<%= Session["CompanyID"] %>/<%= Request.QueryString["PresentationID"] %>/<%# Eval("ImagePath") %>' alt=""/>
          
            </li>


              

                    </ItemTemplate>
                    <FooterTemplate></ul></FooterTemplate>
                   
                    </asp:Repeater>

       



    </div>

     <asp:SqlDataSource ID="dsSound" runat="server" ConnectionString="<%$ ConnectionStrings:terrible1ConnectionString %>"
                                SelectCommand="sp_SelectSound" ProviderName="System.Data.SqlClient" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="PresentationID" QueryStringField="PresentationID"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
    </form>
    
</body>
</html>
