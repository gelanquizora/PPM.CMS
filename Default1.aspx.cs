using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.Security;

public partial class Master_Default1 : System.Web.UI.Page
{

    private string repository = ConfigurationManager.AppSettings["repository"].ToString();
    private string URL = ConfigurationManager.AppSettings["URL"].ToString();
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertDirectorsVideos";
            cmd.Parameters.Add("@VideoTitle", SqlDbType.VarChar).Value = System.Convert.ToString("hey");
            cmd.Parameters.Add("@VideoFile", SqlDbType.VarChar).Value = System.Convert.ToString("hey");
            cmd.Parameters.Add("@VideoPath", SqlDbType.VarChar).Value = System.Convert.ToString("hey");
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = System.Convert.ToString("hey");
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"]);
            cmd.Parameters.Add("@BoardID", SqlDbType.Int).Value = Convert.ToInt32(1);
            cmd.Parameters.Add("@Rank", SqlDbType.Int).Value = Convert.ToInt32(1);

            cmd.ExecuteNonQuery();
        }
        c.Close();
    }
}