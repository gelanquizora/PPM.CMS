using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class View_Project : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (IsPostBack)
        {
            // If condition is true, execute these statements.
        }
        else
        {
            int ProjectProjectID;
            ProjectProjectID = Convert.ToInt32(Request.QueryString.Get("ProjectID"));
            this.loadProject();
        }
    }

    private void loadProject()
    {
        int ProjectProjectID;
        ProjectProjectID = Convert.ToInt32(Request.QueryString.Get("ProjectID"));
        Project myProject;
        myProject = clsproject.getProject(ProjectProjectID);
        lblProjectID.Text = ProjectProjectID.ToString();
        txtProjectName.Text = myProject.ProjectName.ToString();
        txtDescription.Text = myProject.Description.ToString();
        ddlClient.SelectedValue  = myProject.ClientID.ToString();
    }

    //protected void BtnUpdate_Click(object sender, System.EventArgs e)
    //{
    //    int ProjectProjectID;
    //    ProjectProjectID = Convert.ToInt32(Request.QueryString.Get("ProjectID"));
    //    Project myProject;
    //    myProject = new Project();
    //    myProject.ProjectID = ProjectProjectID.ToString();
    //    myProject.ProjectName = System.Convert.ToString(txtProjectName.Text);
    //    myProject.Description = System.Convert.ToString(txtDescription.Text);
    //    myProject.ClientID = System.Convert.ToInt32(ddlClient.SelectedValue);
    //    clsproject.Update(myProject);
    //    Response.Redirect("ProjectGridMaster.aspx", false);
    //}

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("ProjectGridMaster.aspx", false);
    }
}