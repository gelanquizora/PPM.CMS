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

public partial class Master_AgencyBoardGrid : System.Web.UI.Page
{

    private string Contents = ConfigurationManager.AppSettings["Contents"].ToString();

    private string repository = ConfigurationManager.AppSettings["repository"].ToString();
    private string URL = ConfigurationManager.AppSettings["URL"].ToString();
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            // SetDefaultView();
          int  PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
          frmEntry.Attributes["src"] = "Edit_AgencyBoard.aspx?PresentationID=" + PresentationID + "&AgencyID=1";
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
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
                cmd.CommandText = "sp_DeleteAgencyBoard";
                cmd.Parameters.Add("@AgencyID", SqlDbType.Int).Value = Convert.ToInt32(e.CommandArgument);
                cmd.ExecuteNonQuery();

            }
            c.Close();

            GridView1.DataBind();


        }
    }
}