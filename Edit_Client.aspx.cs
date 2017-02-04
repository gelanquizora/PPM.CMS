using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class Edit_Client : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (IsPostBack)
        {
            // If condition is true, execute these statements.
        }
        else
        {
            int ClientClientID;
            ClientClientID = Convert.ToInt32(Request.QueryString.Get("ClientID"));
            this.loadClient();
        }
    }

    private void loadClient()
    {
        int ClientClientID;
        ClientClientID = Convert.ToInt32(Request.QueryString.Get("ClientID"));
        Client myClient;
        myClient = clsclient.getClient(ClientClientID);
        lblClientID.Text = ClientClientID.ToString();
        txtClientName.Text = myClient.ClientName.ToString();
        txtDescription.Text = myClient.Description.ToString();
       // ddlCompany.SelectedValue = myClient.CompanyID.ToString();
    }

    protected void BtnUpdate_Click(object sender, System.EventArgs e)
    {
        int ClientClientID;
        ClientClientID = Convert.ToInt32(Request.QueryString.Get("ClientID"));
        Client myClient;
        myClient = new Client();
        myClient.ClientID = ClientClientID.ToString();
        myClient.ClientName = System.Convert.ToString(txtClientName.Text);
        myClient.Description = System.Convert.ToString(txtDescription.Text);
        myClient.CompanyID = System.Convert.ToInt32(Session["CompanyID"].ToString());
        clsclient.Update(myClient);
        Response.Redirect("ClientGrid.aspx", false);
    }

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("ClientGrid.aspx", false);
    }
}