using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_CoverGrid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        int CoverID = System.Convert.ToInt32(GridView1.SelectedValue);
        Response.Redirect("Edit_Cover.aspx?CoverID=" + CoverID.ToString(), false);
    }
   
}