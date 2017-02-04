using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Create_Presentation : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (IsPostBack)
        {
            // If this is a Postback, execute these statements.
        }
        else
        {
            // Put code to execute for non postback here
        }
    }

    protected void BtnSave_Click(object sender, System.EventArgs e)
    {

        if(string.IsNullOrEmpty(txtTitle.Text))
            return;

        if (string.IsNullOrEmpty(txtDescription.Text))
            return;

        Presentation myPresentation;
        myPresentation = new Presentation();
        myPresentation.Title = System.Convert.ToString(txtTitle.Text);
        myPresentation.Description = System.Convert.ToString(txtDescription.Text);
        myPresentation.ClientID = System.Convert.ToInt32(ddlProject.SelectedValue);
        clspresentation.Insert (myPresentation);
     //   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>top.back();</script>", false); 
       // Response.Redirect("PresentationGridMaster.aspx", false);
    }

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
       // Response.Redirect("PresentationGridMaster.aspx", false);
    }
}