using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 

public partial class _Admin_Preivew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            string pid = Request.QueryString["PresentationID"].ToString();
            string page = Request.QueryString["PN"].ToString();

            string file = "../"+ Session["CompanyID"].ToString()+"/" + pid + "/"+ page +"01.html";
            if (System.IO.File.Exists(file))
            {
                frmPage.Attributes["src"] = "../"+ Session["CompanyID"].ToString()+"/" + pid + "/" + page + "01.html";
                Label1.Visible = false;
            }
            else 
                Label1.Visible = true;
        }
    }

     
}