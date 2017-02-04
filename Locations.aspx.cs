using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Locations : System.Web.UI.Page
{
    int PresentationID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

            frmEntry.Attributes["src"] = "Edit_Location.aspx?PresentationID=" + PresentationID;
        }
    }
}