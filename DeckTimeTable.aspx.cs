using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Security;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.Services;

public partial class DeckTimeTable : System.Web.UI.Page
{
    [WebMethod]
    public static string Process(string TimeTablePage, int PresentationID, int TRow, int TCol)
    {

        SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {

            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertTimeTable";
            cmd.Parameters.Add("@TimeTablePage", SqlDbType.Text).Value = TimeTablePage;
            cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = System.Convert.ToInt32(PresentationID);
            cmd.Parameters.Add("@TRow", SqlDbType.Int).Value = System.Convert.ToInt32(TRow);
            cmd.Parameters.Add("@TCol", SqlDbType.Int).Value = System.Convert.ToInt32(TCol);
            cmd.ExecuteNonQuery();

        }
        c.Close();

        string result = "success!";
        return result;
    }
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    string PresentationID = "0";
    string _clientID = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _clientID = Request.QueryString["ClientID"].ToString();
            PresentationID = Request.QueryString["PresentationID"].ToString();
            frmEntry.Attributes["src"] = "TimeTable.aspx?ClientID=" + _clientID + "&PresentationID=" + PresentationID;
            string param = "PresentationID=" + PresentationID.ToString() + "&ClientID=" + _clientID.ToString();
            btnBack.Attributes["href"] = "ProjectInside.aspx?" + param;

           
        }



    }
    
   
}