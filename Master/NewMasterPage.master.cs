﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

public partial class Master_NewMasterPage : System.Web.UI.MasterPage
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
            if ((Session["Username"] != null))
            {
            



                lblUsername.Text = Session["Username"].ToString();

                DataView dvSql = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
                foreach (DataRowView drvSql in dvSql)
                {


                    int uRole = Convert.ToInt32(drvSql["Role"].ToString());

                    Session["Role"] = uRole;
        
               
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
        int CompanyCompanyID = Convert.ToInt32(Session["CompanyID"]); ;

        Company myCompany;
        myCompany = clscompany.getCompany(CompanyCompanyID);


        if (string.IsNullOrEmpty(myCompany.Logo.ToString()))
        {
            imgCompanyLogo.ImageUrl = "../repository/companylogo.png";

        }
        else
        {
           imgCompanyLogo.ImageUrl = Contents + myCompany.Logo.ToString();
        }


    }
    protected void lnkBtnLogOut_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Session["Username"] = string.Empty;
        Response.Redirect("Login.aspx");
    }
}
