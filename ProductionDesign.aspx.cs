using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.Security;

public partial class ProductionDesign : System.Web.UI.Page
{
    private string Contents = ConfigurationManager.AppSettings["Contents"].ToString();

    private string repository = ConfigurationManager.AppSettings["repository"].ToString();
    private string URL = ConfigurationManager.AppSettings["URL"].ToString();
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    int PresentationID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

            frmEntry.Attributes["src"] = "Edit_ProductionDesign.aspx?PresentationID=" + PresentationID;
        //    frmView.Attributes["src"] = Session["CompanyID"].ToString() + "/" + PresentationID + "/pd01.html";

        
        }
    }

}