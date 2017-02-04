using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class View_Presentation : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (IsPostBack)
        {
            // If condition is true, execute these statements.
        }
        else
        {
            int PresentationPresentationID;
            PresentationPresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
            this.loadPresentation();
        }
    }

    private void loadPresentation()
    {
        int PresentationPresentationID;
        PresentationPresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
        Presentation myPresentation;
        myPresentation = clspresentation.getPresentation(PresentationPresentationID);
        lblPresentationID.Text = PresentationPresentationID.ToString();
        txtTitle.Text = myPresentation.Title.ToString();
        txtDescription.Text = myPresentation.Description.ToString();
        ddlProject.SelectedValue = myPresentation.ClientID.ToString();
    }

    protected void BtnUpdate_Click(object sender, System.EventArgs e)
    {
        int PresentationPresentationID;
        PresentationPresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
        Presentation myPresentation;
        myPresentation = new Presentation();
        myPresentation.PresentationID = PresentationPresentationID.ToString();
        myPresentation.Title = System.Convert.ToString(txtTitle.Text);
        myPresentation.Description = System.Convert.ToString(txtDescription.Text);
        myPresentation.ClientID = System.Convert.ToInt32(ddlProject.SelectedValue);
        clspresentation.Update(myPresentation);
        Response.Redirect("PresentationGridMaster.aspx", false);
    }

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("PresentationGridMaster.aspx", false);
    }
}