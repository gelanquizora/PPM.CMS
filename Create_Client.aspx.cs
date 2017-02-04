using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Create_Client : System.Web.UI.Page
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
        Client myClient;
        myClient = new Client();
        myClient.ClientName = System.Convert.ToString(txtClientName.Text);
        myClient.Description = System.Convert.ToString(txtDescription.Text);
        myClient.CompanyID = System.Convert.ToInt32(Session["CompanyID"].ToString());//System.Convert.ToInt32(ddlCompany.SelectedValue );
        clsclient.Insert(myClient);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>top.back();</script>", false); 
    }

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("ClientGrid.aspx", false);
    }
}