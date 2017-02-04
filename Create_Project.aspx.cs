using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Create_Project : System.Web.UI.Page
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
        //Project myProject;
        //myProject = new Project();
        //myProject.ProjectName = System.Convert.ToString(txtProjectName.Text);
        //myProject.Description = System.Convert.ToString(txtDescription.Text);
        //myProject.ClientID = System.Convert.ToInt32(ddlClient.SelectedValue);
        //clsproject.Insert(myProject);
        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>top.back();</script>", false); 
       
       // Response.Redirect("ProjectGridMaster.aspx", false);
    }

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("ProjectGridMaster.aspx", false);
    }
}