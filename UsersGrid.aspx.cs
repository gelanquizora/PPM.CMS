using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_UsersGrid : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
    }

    protected void GridView1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        int UserID = System.Convert.ToInt32(GridView1.SelectedValue);
        Response.Redirect("Edit_Users.aspx?UserID=" + UserID.ToString(), false);
    }
    protected void createNew_Click(object sender, EventArgs e)
    {

        Response.Redirect("Create_Users.aspx", false);       



    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("Edit_Users.aspx?UserID=" + index.ToString(), false);

            
        }
    }
}