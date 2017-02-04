using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class CompanyGrid : System.Web.UI.Page
{
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());

    protected void Page_Load(object sender, System.EventArgs e)
    {
    }

    protected void GridView1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        int CompanyID = System.Convert.ToInt32(GridView1.SelectedValue);
        Response.Redirect("Edit_Company.aspx?CompanyID=" + CompanyID.ToString(), false);
    }
    protected void createNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("Create_Company.aspx", false);
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

       
        

        
        if (e.CommandName == "del")
        {
            int index = Convert.ToInt32(e.CommandArgument);
          

            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DeleteCompany";
                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = System.Convert.ToInt32(index);           
                cmd.ExecuteNonQuery();

            }
            c.Close();


        }
    }

}