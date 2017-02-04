using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



using System.Drawing;
using System.Web.Security;


using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    //private UsersBLL _usersBLL;
    //private UsersEL _usersEL;
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    SqlHelper _helper;

    protected void Page_Load(object sender, EventArgs e)
    {
       
        
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ValidateCredentials";

            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtUserName.Text;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = txtPassword.Text;

            SqlParameter param = new SqlParameter("@returnvalue", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);




            SqlParameter retval = cmd.Parameters.Add("@returnvalue", SqlDbType.Int);
            retval.Direction = ParameterDirection.ReturnValue;


            cmd.ExecuteNonQuery();
            int returnVal = 0;


            returnVal = Convert.ToInt32(cmd.Parameters["@returnvalue"].Value);

            c.Close();

         
            if (returnVal == 1)
            {
                // return true;
                Session["Username"] = txtUserName.Text;
                Session["RoleID"] = getRoleID(txtUserName.Text);


                Session["CompanyID"] = getCompanyID();
                redirect();

                Label1.Text = Session["CompanyID"]  + " " + Session["Username"].ToString();
              
            }
            else
            {
                // return false;

               // Response.Write("Invalid Credentials");
                Label1.Text = "*Invalid Credentials";
            }

        } 
    }

    


    public string getRoleID(string UserName)
    {

        _helper = new SqlHelper();

        DataTable dt = new DataTable();
        string roleid = null;
        try
        {

            if (_helper.CreateConnection())
            {
                _helper.BeginTransaction();
                _helper.CreateCommand("sp_SelectRoleByUserID", true);
                _helper.AddParameter("@UserName", UserName, DbType.String, ParameterDirection.Input);

                _helper.ExecuteDataTable();
                dt = _helper.DataTable;

                if (dt.Rows.Count > 0)
                    roleid = dt.Rows[0][0].ToString();

                _helper.ClearCommandParameters();


            }


        }
        catch (Exception ex)
        {

            _helper.RollbackTransaction();
            ErrorHandler.Handle(ex);


        }
        finally
        {
            _helper.CloseConnection();

        }


        return roleid;

    }

    public string getCompanyID()
    {
        _helper = new SqlHelper();

        DataTable dt = new DataTable();
        string cid = "0";

        _helper.CloseConnection();
        _helper.CreateCommand("sp_SelectCompanyByUserName", false);
        _helper.AddParameter("@UserName", Session["Username"].ToString(), DbType.String, ParameterDirection.Input);
        _helper.ExecuteDataTable();
        dt = _helper.DataTable;

        _helper.CloseConnection();

        if (dt.Rows.Count > 0)
        {
            cid = dt.Rows[0]["CompanyID"].ToString();
            Session["CompanyLogo"] = dt.Rows[0]["CompanyLogo"].ToString();
        }
        return  cid;
    }
    private void redirect()
    {
        switch (Session["RoleID"].ToString().ToUpper())
        {
            case "64DDAA33-9300-4DB2-832E-B15A7D922132":
                Response.Redirect("~/_Admin/Clients.aspx");
                break;
            case "393B0494-5DA5-40B4-B424-494A0387655C":
                Response.Redirect("~/_SA/Users.aspx");
                break;
            case "B981893A-EBA8-41E9-B663-861F1248247A":
                {
                    Response.Redirect("~/ProjectInside.aspx?" + clsusers.GetDeckByUsername(txtUserName.Text));

                }
                break;
            default:
                break;
        }
    }
}