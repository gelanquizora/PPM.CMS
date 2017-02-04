using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageGrid : System.Web.UI.Page
{
    int PresentationID;
    protected void Page_Load(object sender, System.EventArgs e)
    {

        PresentationID = Convert.ToInt32(Request.QueryString.Get("id"));
    }

    protected void GridView1_SelectedIndexChanged(object sender)
    {
        int PageID = System.Convert.ToInt32(GridView1.SelectedValue);
        Response.Redirect("Edit_Page.aspx?PageID=" + PageID.ToString(), false);
    }
    protected void lbCreate_Click(object sender, EventArgs e)
    {
        Response.Redirect("Create_Page.aspx?id=" + PresentationID.ToString(), false);
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {

           int index = Convert.ToInt32(e.CommandArgument);
           Response.Redirect("Edit_Page.aspx?PageID=" + index, false);
        }

    }
    protected void createNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("Create_Page.aspx", false);
    }
}