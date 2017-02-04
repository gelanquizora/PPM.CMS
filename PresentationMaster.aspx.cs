using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
public partial class PresentationMaster : System.Web.UI.Page
{
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    protected void Page_Load(object sender, System.EventArgs e)
    {
    }

    protected void GridView1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        int PresentationID = System.Convert.ToInt32(GridView1.SelectedValue);
        Response.Redirect("Edit_Presentation.aspx?PresentationID=" + PresentationID.ToString(), false);
      
    }
    protected void createNew_Click(object sender, EventArgs e)
    {

        Response.Redirect("Create_Presentation.aspx", false);

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {

            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DeletePresentation";
                cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = Convert.ToInt32(e.CommandArgument);
                cmd.ExecuteNonQuery();

            }
            c.Close();

            GridView1.DataBind();


        }
    }
}