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

public partial class _SA_Users : System.Web.UI.Page
{
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindRoles();
        }

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }


    }
    public void BindRoles()
    {
        SqlDataAdapter da = new SqlDataAdapter("select RoleName, RoleId from aspnet_Roles WHERE RoleID != 'B981893A-EBA8-41E9-B663-861F1248247A'", c);
        DataSet ds = new DataSet();
        da.Fill(ds, "Roles");
        lstRoles.DataSource = ds;
        lstRoles.DataTextField = "RoleName";
        lstRoles.DataValueField = "RoleId";
        lstRoles.DataBind();


        lstRolesEdit.DataSource = ds;
        lstRolesEdit.DataTextField = "RoleName";
        lstRolesEdit.DataValueField = "RoleId";
        lstRolesEdit.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        string UserName = System.Convert.ToString(GridView1.SelectedValue);
        loadUser(UserName);
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

            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            GridView1.SelectedIndex = row.RowIndex;

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



            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            GridView1.SelectedIndex = row.RowIndex;
            HiddenField1.Value = row.Cells[0].Text;
            txtUserNameEdit.Text = row.Cells[0].Text;
            txtPasswordEdit.Text = row.Cells[3].Text;
            txtConfirmPasswordEdit.Text = row.Cells[3].Text;
            lstRolesEdit.SelectedValue  = GridView1.SelectedDataKey.Values[1].ToString();
            txtEmailEdit.Text = row.Cells[2].Text;
            // ddlCompanyEdit.SelectedItem.Text = row.Cells[4].Text;

            System.Web.UI.WebControls.Label lblCompanyID = row.FindControl("lblCompanyID") as System.Web.UI.WebControls.Label;

            Label1.Text = lblCompanyID.Text;
            
         
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

        if (Page.IsValid)
        {
            MembershipUser u = Membership.GetUser(HiddenField1.Value);

            //bool val = false;

            //    if (u.ChangePassword(txtOldPassword.Text, txtPasswordEdit.Text))
            //    {
            //        val = true;
            //    }
            //    else
            //    {
            //        val = false;
            //    }
            //    if (val == true)

            //    {

            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UpdateCMSUser";
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = HiddenField1.Value;
                cmd.Parameters.Add("@NewUserName", SqlDbType.VarChar).Value = txtUserNameEdit.Text;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = txtPasswordEdit.Text;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmailEdit.Text;
                cmd.Parameters.Add("@RoleID", SqlDbType.VarChar).Value = lstRolesEdit.SelectedValue;
                cmd.Parameters.Add("@Role", SqlDbType.Int).Value = lstRolesEdit.SelectedIndex;
                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = ddlCompanyEdit.SelectedValue;
                cmd.ExecuteNonQuery();

            }
            c.Close();
            //}

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
        bool valid = false;
        MembershipCreateStatus createStatus;
        MembershipUser user = Membership.CreateUser(txtUserName.Text, txtPwd.Text, txtEmail.Text, "sample", "sample", true, out createStatus);
        switch (createStatus)
        {
            //This Case Occured whenver User Created Successfully in database
            case MembershipCreateStatus.Success:
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "The user account was successfully created";
                valid = true;
                //txtUserName.Text = string.Empty;
                //txtEmail.Text = string.Empty;
                Roles.AddUserToRole(txtUserName.Text, lstRoles.SelectedItem.Text);
                break;
            // This Case Occured whenver we send duplicate UserName
            case MembershipCreateStatus.DuplicateUserName:
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "The user with the same UserName already exists!";
                valid = false;
                break;
            //This Case Occured whenver we give duplicate mail id
            case MembershipCreateStatus.DuplicateEmail:
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "The user with the same email address already exists!";
                valid = false;
                break;
            //This Case Occured whenver we send invalid mail format
            case MembershipCreateStatus.InvalidEmail:
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "The email address you provided is invalid.";
                valid = false;
                break;
            //This Case Occured whenver we send empty data or Invalid Data
            case MembershipCreateStatus.InvalidAnswer:
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "The security answer was invalid.";
                valid = false;
                break;
            // This Case Occured whenver we supplied weak password
            case MembershipCreateStatus.InvalidPassword:
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "The password you provided is invalid. It must be 7 characters long and have at least 1 special character.";
                valid = false;
                break;
            default:
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "There was an unknown error; the user account was NOT created.";
                valid = false;
                break;
        }

        if (valid == true)
        {



            Users myUsers;
            myUsers = new Users();
            // myUsers.UserID = System.Convert.ToInt32(txtUserID.Text);
            myUsers.UserName = System.Convert.ToString(txtUserName.Text);
            myUsers.Password = System.Convert.ToString(txtPwd.Text);
            ////myUsers.FirstName = System.Convert.ToString(txtFirstName.Text);
            ////myUsers.LastName = System.Convert.ToString(txtLastName.Text);
            myUsers.RoleID = System.Convert.ToString(lstRoles.SelectedValue);
            myUsers.CompanyID = System.Convert.ToInt32(ddlCompany.SelectedValue); //System.Convert.ToInt32(Session["CompanyID"].ToString());
            myUsers.Email = System.Convert.ToString(txtEmail.Text);
            myUsers.Role = System.Convert.ToInt32(lstRoles.SelectedIndex);
            clsusers.Insert(myUsers);

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
    protected void lstRoles_SelectedIndexChanged(object sender, EventArgs e)
    {
       

        if (lstRoles.SelectedValue.ToUpper() == "393B0494-5DA5-40B4-B424-494A0387655C")
        {
            ddlCompany.AppendDataBoundItems = true;
           
            ddlCompany.SelectedIndex = 0;
            ddlCompany.Enabled = false;
 
       
        }
        else
        {
            ddlCompany.AppendDataBoundItems = false;
            ddlCompany.Enabled = true;
      
        }
    }

    protected void lstRolesEdit_SelectedIndexChanged(object sender, EventArgs e)
    {


        if (lstRolesEdit.SelectedValue.ToUpper() == "393B0494-5DA5-40B4-B424-494A0387655C")
        {
            ddlCompanyEdit.AppendDataBoundItems = true;

            ddlCompanyEdit.SelectedIndex = 0;
            ddlCompanyEdit.Enabled = false;


        }
        else
        {
            ddlCompanyEdit.AppendDataBoundItems = false;
            ddlCompanyEdit.Enabled = true;

        }
    }
    protected void ddlCompanyEdit_Databound(object sender, EventArgs e)
    {
        ddlCompanyEdit.SelectedValue = Label1.Text;
            
    }
}