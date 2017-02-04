using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
public partial class ClientGrid : System.Web.UI.Page
{
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //navigator
            if (string.IsNullOrEmpty(Session["RoleID"].ToString()))
                return;

            Literal1.Text = "<ul><li class='nav_dashboard'><a href='Default.aspx'>Dashboard</a></li> ";
            Literal1.Text += " <li class='nav_clients active'><a href='ClientGrid.aspx'>Clients</a></li>";
            Literal1.Text += "<li class='nav_projects'><a href='Decks.aspx'>Projects</a></li>";
            //<%--    <li class="nav_decks active" ><a href="Decks.aspx">Decks</a></li>--%>

            string roleid = Session["RoleID"].ToString();
            if (roleid == "64ddaa33-9300-4db2-832e-b15a7d922132" || roleid == "393b0494-5da5-40b4-b424-494a0387655c")
                Literal1.Text += "<li class='nav_decks' ><a href='UserManagementGrid.aspx'>User Management</a></li>";

            Literal1.Text += " </ul>";
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        int ClientID = System.Convert.ToInt32(GridView1.SelectedValue);
        loadClient(ClientID);
        Panel4.Visible = true;
        Panel1.Visible = false;
    }
    protected void createNew_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
        btnAddNew.Visible = false;
      
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    { 

        if (e.CommandName == "del")
        {        

            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DeleteClient";
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = Convert.ToInt32(e.CommandArgument);
                cmd.ExecuteNonQuery();

            }
            c.Close();

            GridView1.DataBind();


        }
        else if (e.CommandName == "edt")
        {

            int ClientID = Convert.ToInt32(e.CommandArgument);
            loadClient(ClientID);
            Panel4.Visible = true;
            Panel1.Visible = false;
            viewMode(false,"Edit");
            txtID.Value = ClientID.ToString();

        }
        else if (e.CommandName == "view")
        {

            int ClientID = Convert.ToInt32(e.CommandArgument);
            loadClient(ClientID);
            Panel4.Visible = true;
            Panel1.Visible = false;
            viewMode(true, "");
            


        }

        else if (e.CommandName == "projects")
        {

            int ClientID = Convert.ToInt32(e.CommandArgument);
            frmProjects.Attributes["src"] = "ProjectGrid.aspx?ClientID=" + ClientID;
            Panel3.Visible = true;
            Panel1.Visible = false;
            btnAddNew.Visible = false;


        }

        else if (e.CommandName == "viewUsers")
        {

            int ClientID = Convert.ToInt32(e.CommandArgument);
            frmProjects.Attributes["src"] = "ClientUsers.aspx?ClientID=" + ClientID;
           
            Panel3.Visible = true;
            Panel1.Visible = false;
            btnAddNew.Visible = false;


        }
    }

    #region "Edit"
    protected void BtnUpdate_Click(object sender, System.EventArgs e)
    {

        if (Page.IsValid)
        {
            int ClientClientID;
            ClientClientID = Convert.ToInt32(txtID.Value);
            Client myClient;
            myClient = new Client();
            myClient.ClientID = ClientClientID.ToString();
            myClient.ClientName = System.Convert.ToString(txtClientName.Text);
            myClient.Description = System.Convert.ToString(txtDescription.Text);
            myClient.CompanyID = System.Convert.ToInt32(Session["CompanyID"].ToString());
            clsclient.Update(myClient);


            Panel4.Visible = false;
            Panel1.Visible = true;
            btnAddNew.Visible = true;
            GridView1.DataBind();
        }
      
    }

    protected void BtnCancelEdit_Click(object sender, System.EventArgs e)
    {
        Panel1.Visible = true;
        Panel4.Visible = false;
        btnAddNew.Visible = true;
    }
    private void loadClient(int ClientClientID)
    {

        Client myClient;
        myClient = clsclient.getClient(ClientClientID);
        lblClientID.Text = ClientClientID.ToString();
        txtClientName.Text = myClient.ClientName.ToString();
        txtDescription.Text =  myClient.Description.ToString();
        // ddlCompany.SelectedValue = myClient.CompanyID.ToString();
    }
    #endregion
    #region "Add New "
    protected void BtnSave_Click(object sender, System.EventArgs e)
    {

        if (Page.IsValid)
        {
            Client myClient;
            myClient = new Client();
            myClient.ClientName = System.Convert.ToString(txtAddName.Text);
            myClient.Description = System.Convert.ToString(txtAddDescription.Text);
            myClient.CompanyID = System.Convert.ToInt32(Session["CompanyID"].ToString());//System.Convert.ToInt32(ddlCompany.SelectedValue );
            clsclient.Insert(myClient);
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>top.back();</script>", false);
            GridView1.DataBind();
            Panel1.Visible = true;
            Panel2.Visible = false;

            btnAddNew.Visible = true;
        
        }

      
    }

    protected void btnCancelNewItem_Click(object sender, System.EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        btnAddNew.Visible = true;
    }
    #endregion

    private void viewMode(bool bl, string title){
        txtClientName.ReadOnly = bl;
        txtDescription.ReadOnly = bl;
        BtnUpdate.Visible = !bl;
        lblTitle.Text = title;
        btnAddNew.Visible = false;
    }
}