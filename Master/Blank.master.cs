using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;
public partial class Master_Blank : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((Session["Username"] != null))
            {



             //   lblUsername.Text = Session["Username"].ToString();

                DataView dvSql = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
                foreach (DataRowView drvSql in dvSql)
                {


                    //int uRole = Convert.ToInt32(drvSql["RoleID"].ToString());
                    //if ((uRole == 1))
                    //{
                    //   // admin.Visible = true;
                    //}
                    //else
                    //{
                    //   // admin.Visible = false;
                    //}
                }

                DataView dvSql1 = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
                foreach (DataRowView drvSql1 in dvSql1)
                {
                    Session["CompanyID"] = Convert.ToInt32(drvSql1["CompanyID"].ToString());
                }

                loadCompany();
            }

            else
            {
                Response.Redirect("../terrible1/Login.aspx");
            }


        }
        else
        {
            if ((Session["Username"] == null))
            {
                Session.RemoveAll();
                Response.Redirect("../terrible1/Login.aspx");
            }
        }
    }
    private void loadCompany()
    {
        //int CompanyCompanyID = Convert.ToInt32(Session["CompanyID"]); ;

        //Company myCompany;
        //myCompany = clscompany.getCompany(CompanyCompanyID);


        //if (string.IsNullOrEmpty(myCompany.Logo.ToString()))
        //{
        //    imgCompanyLogo.ImageUrl = "../repository/AlbumArt_{00000000-0000-0000-0000-000000000000}_Small.jpg";

        //}
        //else
        //{
        //    imgCompanyLogo.ImageUrl = Contents + myCompany.Logo.ToString();
        //}


    }
}
