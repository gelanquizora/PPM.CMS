using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ApplicationServices;
using System.Security;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ClientUsers : System.Web.UI.Page
{
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindRoles();
            Panel1.Visible = true;

        }

    }
    protected void createNew_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
        btnAddNew.Visible = false;

    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }


    }
    public void BindRoles()
    {
        ////SqlDataAdapter da = new SqlDataAdapter("select RoleName,RoleId from aspnet_Roles", c);
        ////DataSet ds = new DataSet();
        ////da.Fill(ds, "Roles");
      

 
    }
    protected void GridView1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        string UserName = System.Convert.ToString(GridView1.SelectedValue);
        loadUser(UserName);
        Panel4.Visible = true;
        Panel1.Visible = false;
    }
   
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {



        if (e.CommandName == "del")
        {
            string UserName = e.CommandArgument.ToString();


            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DeleteCMSUser";
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
                cmd.ExecuteNonQuery();

            }
            c.Close();

            Membership.DeleteUser(UserName);

            GridView1.DataBind();




        }
        else if (e.CommandName == "edt")
        {



            string UserId = e.CommandArgument.ToString();





            //   MembershipUser mu = Membership.GetUser(UserId);         

            //txtUserNameEdit.Text = mu.UserName;



            //////GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            //////HiddenField1.Value = row.Cells[0].Text;
            //////txtUserNameEdit.Text = row.Cells[0].Text;
            //////txtPasswordEdit.Text = row.Cells[3].Text;
            //////txtConfirmPasswordEdit.Text = row.Cells[3].Text;
 
            //////txtEmailEdit.Text = row.Cells[2].Text;
            //////// ddlCompanyEdit.SelectedItem.Text = row.Cells[4].Text;

            //////System.Web.UI.WebControls.Label lblCompanyID = row.FindControl("lblCompanyID") as System.Web.UI.WebControls.Label;


            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

            txtUserNameEdit.Text = GridView1.DataKeys[row.RowIndex]["Username"].ToString();
            ////txtPasswordEdit.Text = GridView1.DataKeys[row.RowIndex]["Password"].ToString();
            ////txtConfirmPasswordEdit.Text = GridView1.DataKeys[row.RowIndex]["Password"].ToString();
            drpDecksEdit.SelectedValue = GridView1.DataKeys[row.RowIndex]["DeckID"].ToString();


            Panel4.Visible = true;
            Panel1.Visible = false;
            viewMode(false, "Edit");
            // txtID.Value = UserId.ToString();

        }
        else if (e.CommandName == "view")
        {
            string UserName = e.CommandArgument.ToString();

            loadUser(UserName);

            Panel4.Visible = true;
            Panel1.Visible = false;
            viewMode(true, "");



        }

        else if (e.CommandName == "projects")
        {

            int ClientID = Convert.ToInt32(e.CommandArgument);
            //frmProjects.Attributes["src"] = "ProjectGrid.aspx?ClientID=" + ClientID;
            //Panel3.Visible = true;
            Panel1.Visible = false;
            btnAddNew.Visible = false;


        }
    }

    #region "Edit"
    protected void BtnUpdate_Click(object sender, System.EventArgs e)
    {

        if (Session["CompanyID"] == null)
            return;
        int CompanyID = Convert.ToInt32(Session["CompanyID"].ToString());
        if (Page.IsValid)
        {
//////            MembershipUser u = Membership.GetUser(HiddenField1.Value);

//////            //bool val = false;

//////            //    if (u.ChangePassword(txtOldPassword.Text, txtPasswordEdit.Text))
//////            //    {
//////            //        val = true;
//////            //    }
//////            //    else
//////            //    {
//////            //        val = false;
//////            //    }
//////            //    if (val == true)

//////            //    {

//////            c.Open();
//////            using (SqlCommand cmd = c.CreateCommand())
//////            {
//////                cmd.Parameters.Clear();
//////                cmd.CommandType = CommandType.StoredProcedure;
//////                cmd.CommandText = "sp_UpdateCMSUser";
//////                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = HiddenField1.Value;
//////                cmd.Parameters.Add("@NewUserName", SqlDbType.VarChar).Value = txtUserNameEdit.Text;
//////                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = txtPasswordEdit.Text;
//////                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmailEdit.Text;
////////cmd.Parameters.Add("@RoleID", SqlDbType.VarChar).Value = "74d2222e-60b0-4689-aa15-562d114ce53b";
//////               cmd.Parameters.Add("@Role", SqlDbType.Int).Value = 2;
//////                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
//////                cmd.ExecuteNonQuery();

//////            }
//////            c.Close();
            //}



            DeviceUser _user = new DeviceUser();
            _user.UserName = txtUserNameEdit.Text;
             
            _user.DeckID = Convert.ToInt32(drpDecksEdit.SelectedValue.ToString());


            _user.Update();


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
    private void loadUser(string UserName)
    {

        //int UsersUsersID;
        //UsersUsersID = Convert.ToInt32(Request.QueryString.Get("UserID"));


        //_usersEL = new UsersEL();
        //_usersEL.UserID = UsersUsersID;
        //_usersBLL = new UsersBLL(_usersEL);
        //_usersEL = _usersBLL.GetUserByID();


        //txtUserName.Text = _usersEL.UserName.ToString();
        //txtPassword.Text = _usersEL.Password.ToString();
        //txtFirstName.Text = _usersEL.FirstName.ToString();
        //txtLastName.Text = _usersEL.LastName.ToString();
        //ddlRoles.SelectedValue = _usersEL.RoleID.ToString();
    }
    #endregion
    #region "Add New "
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if (txtUserName.Text == null)
            return;

        if (txtPwd.Text == null)
            return;


         if (Page.IsValid== true)
         {

            if (Request.QueryString["ClientID"] == null)
            {
                lblResult.Text = "Unable to save. Please choose Client.";
                return;
            }
            if (txtPwd.Text != txtCnfPwd.Text)
            {
                lblResult.Text = "Password doesn't match.";
                return;
            }

            DeviceUser _user = new DeviceUser();
            _user.UserName = txtUserName.Text;
            _user.Password = txtPwd.Text;
            _user.ClientID = Convert.ToInt32(Request.QueryString["ClientID"].ToString());
            _user.DeckID = Convert.ToInt32(drpDecks.SelectedValue.ToString());
            //Check if Existing
            if (_user.GetByUsername().Rows.Count > 0)
            {
                lblResult.Text = "Username already exist.";
                return;
            }

            if (_user.Insert() == false)
            {
                lblResult.Text = "Error in saving.";
                return;
            }




            Panel1.Visible = true;
            Panel2.Visible = false;

            btnAddNew.Visible = true;
            GridView1.DataBind();
         }
        
    }

    protected void btnCancelNewItem_Click(object sender, System.EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        btnAddNew.Visible = true;
    }
    #endregion

    private void viewMode(bool bl, string title)
    {
        //txtClientName.ReadOnly = bl;
        //txtDescription.ReadOnly = bl;
        BtnUpdate.Visible = !bl;
        //lblTitle.Text = title;
        btnAddNew.Visible = false;
    }

    
}