using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Master_Create_Users : System.Web.UI.Page
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
        if (Page.IsValid)
        {
            MembershipCreateStatus createStatus;
            MembershipUser newUser = Membership.CreateUser(txtUserName.Text, txtPassword.Text, txtEmail.Text, "", "", true, out createStatus);

            switch (createStatus)
            {
                case MembershipCreateStatus.Success:
                    CreateAccountResults.Text = "The user account was successfully created!";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    CreateAccountResults.Text = "There already exists a user with this username.";
                    break;

                case MembershipCreateStatus.DuplicateEmail:
                    CreateAccountResults.Text = "There already exists a user with this email address.";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    CreateAccountResults.Text = "There email address you provided in invalid.";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    CreateAccountResults.Text = "There security answer was invalid.";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    CreateAccountResults.Text = "The password you provided is invalid. It must be seven characters long and have at least one non-alphanumeric character.";

                    break;
                default:
                    CreateAccountResults.Text = "There was an unknown error; the user account was NOT created.";
                    break;
            }

            Users myUsers;
            myUsers = new Users();
            // myUsers.UserID = System.Convert.ToInt32(txtUserID.Text);
            myUsers.UserName = System.Convert.ToString(txtUserName.Text);
            myUsers.Password = System.Convert.ToString(txtPassword.Text);
            myUsers.FirstName = System.Convert.ToString(txtFirstName.Text);
            myUsers.LastName = System.Convert.ToString(txtLastName.Text);
            myUsers.RoleID = System.Convert.ToInt32(ddlRoles.SelectedValue);
            myUsers.CompanyID = System.Convert.ToInt32(Session["CompanyID"].ToString());
            clsusers.Insert(myUsers);

            Response.Redirect("UsersGrid.aspx", false);
        
        }


        

        

    }

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("UsersGrid.aspx", false);
    }
}