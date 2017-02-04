using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Master_SiteAdmin : System.Web.UI.MasterPage
{
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    private string Contents = ConfigurationManager.AppSettings["Contents"].ToString();
    // string user = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (!IsPostBack)
        //{
        //    user = Membership.GetUser().ToString();
        //    if (user != null)
        //    { 

        //    }
        //}
        //else
        //{

        //    if ((Session["Username"] == null))
        //    {
        //        Session.RemoveAll();

        //    }


        //}

        if (!IsPostBack)
        {

            if ((Session["Username"] == null))
            {
                Session.RemoveAll();
                Response.Redirect("~/Login.aspx");
                return;

            }



            //Response.Redirect("Default.aspx");
            switch (Session["RoleID"].ToString().ToUpper())
            {
                case "393B0494-5DA5-40B4-B424-494A0387655C":
                case "B981893A-EBA8-41E9-B663-861F1248247A":
                    Response.Redirect("../Login.aspx");
                    break;
             
                    
                default:
                    break;
            }


            lblUsername.Text = Session["Username"].ToString();

            //DataView dvSql = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            //foreach (DataRowView drvSql in dvSql)
            //{


            //    int uRole = Convert.ToInt32(drvSql["Role"].ToString());

            //    Session["Role"] = uRole;


            //}

            DataView dvSql1 = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
            foreach (DataRowView drvSql1 in dvSql1)
            {
                Session["CompanyID"] = Convert.ToInt32(drvSql1["CompanyID"].ToString());
            }

            loadCompany();





        }



    }
    private void loadCompany()
    {
        int CompanyCompanyID = Convert.ToInt32(Session["CompanyID"]); ;

        Company myCompany;
        myCompany = clscompany.getCompany(CompanyCompanyID);


        if (string.IsNullOrEmpty(myCompany.Logo.ToString()))
        {
            // imgCompanyLogo.ImageUrl = "../repository/companylogo.png";
            //Image1.ImageUrl = Contents + myCompany.Logo.ToString();
        }
        else
        {
            // imgCompanyLogo.ImageUrl = Contents + myCompany.Logo.ToString();
            Image1.ImageUrl = Contents + myCompany.Logo.ToString();
        }


    }
    protected void lnkBtnLogOut_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Session["Username"] = string.Empty;
        Response.Redirect("~/Login.aspx");
    }
}
