<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;" />
<title>PPM CMS</title>
 
<meta charset="UTF-8" /> 

<link rel="stylesheet" href="css/foundation.css" />
<link rel="stylesheet" href="css/mainStyle.css" />
 

</head>
<body  id="login_container">
    <form id="form1" runat="server">
 
 
 
     
     

<div id="login-container">
    	<div class="frm-container">
         
            	<div class="row">
            	 
                       <asp:TextBox ID="txtUserName" runat="server" placeholder="Username"></asp:TextBox>
                </div>
                <div class="row">
            	 
                         <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"  placeholder="Password" ></asp:TextBox>
                </div>
                <div class="left">
                <%--	<a href="#" class="small button">SUBMIT</a>--%>
                       <asp:Button ID="btnLogin" runat="server" Text="Login" onclick="btnLogin_Click" CssClass="small button" /> 
                    <br/>
                </div>
                <div class="right"> </div>
                <span class="clearfix"></span>
             <br />
             <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </div>

     
     
                  
          
            
            
          
    </form>
</body>
</html>
