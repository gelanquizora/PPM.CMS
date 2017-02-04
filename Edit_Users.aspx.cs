using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
public partial class Master_Edit_Users : System.Web.UI.Page
{
    private UsersBLL  _usersBLL;
    private UsersEL _usersEL;
   
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    protected void Page_Load(object sender, System.EventArgs e)
    {
        
        if (IsPostBack)
        {
            // If condition is true, execute these statements.
        }
        else
        {
            

            loadUsers();
        }
    }


  

    protected void BtnUpdate_Click(object sender, System.EventArgs e)
    {
       
        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateUsers";
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value =  System.Convert.ToString(txtUserName.Text);
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = System.Convert.ToString(txtPassword.Text);
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = System.Convert.ToString(txtFirstName.Text);
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = System.Convert.ToString(txtLastName.Text);
            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = Convert.ToInt32(ddlRoles.SelectedValue.ToString());
            cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = System.Convert.ToInt32(Session["CompanyID"].ToString());
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(HiddenField1.Value);
            cmd.ExecuteNonQuery();

        }
        c.Close();

        Response.Redirect("UsersGrid.aspx", false);
    }

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("UsersGrid.aspx", false);
    }

    protected void loadUsers()
    {

        int UsersUsersID;
        UsersUsersID = Convert.ToInt32(Request.QueryString.Get("UserID"));


        _usersEL = new UsersEL();
        _usersEL.UserID = UsersUsersID;
        _usersBLL = new UsersBLL(_usersEL);
        _usersEL = _usersBLL.GetUserByID();     

        HiddenField1.Value = _usersEL.UserID.ToString();
        txtUserName.Text = _usersEL.UserName.ToString();
        txtPassword.Text = _usersEL.Password.ToString();
        txtFirstName.Text = _usersEL.FirstName.ToString();
        txtLastName.Text = _usersEL.LastName.ToString();
        ddlRoles.SelectedValue = _usersEL.RoleID.ToString();
        

       

    }
    
  
}