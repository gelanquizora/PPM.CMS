using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresentationGrid : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
    }

    protected void GridView1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        int PresentationID = System.Convert.ToInt32(GridView1.SelectedValue);
        Response.Redirect("Edit_Presentation.aspx?PresentationID=" + PresentationID.ToString(), false);
    }
    protected void createNew_Click(object sender, EventArgs e)
    {

        Response.Redirect("Create_Presentation.aspx", false);

    }
}