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
public partial class Master_DirectorsVideos : System.Web.UI.Page
{
    private string Contents = ConfigurationManager.AppSettings["Contents"].ToString();

    private string repository = ConfigurationManager.AppSettings["repository"].ToString();
    private string URL = ConfigurationManager.AppSettings["URL"].ToString();
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    int BoardID = 0;
    int PresentationID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            // If condition is true, execute these statements.
        }
        else
        {

            BoardID = Convert.ToInt32(Request.QueryString.Get("BoardID"));
          
        }
    }
    protected void btnSaveVideo_Click(object sender, EventArgs e)
    {
        string strFileNameWithPath = FileUpload1.PostedFile.FileName;

        string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
        if (FileUpload1.HasFile)
        {
            //if (strExtensionName.Equals(".mp4"))
            //{

                string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

                FileUpload1.SaveAs(repository + FileName);

                DirectorsVideos myDirectorsVideos;
                myDirectorsVideos = new DirectorsVideos();
                myDirectorsVideos.VideoTitle = System.Convert.ToString(FileName);
                myDirectorsVideos.VideoFile = System.Convert.ToString(FileName);
                myDirectorsVideos.VideoPath = System.Convert.ToString(URL + FileName);
                myDirectorsVideos.CreatedBy = System.Convert.ToString(Session["Username"]);
                myDirectorsVideos.CreatedDate = System.Convert.ToDateTime(DateTime.Now);
                myDirectorsVideos.ModifiedBy = System.Convert.ToString(Session["Username"]);
                myDirectorsVideos.ModifiedDate = System.Convert.ToDateTime(DateTime.Now);
                myDirectorsVideos.BoardID = System.Convert.ToInt32(BoardID);
                myDirectorsVideos.Rank = System.Convert.ToInt32(txtRank.Text);
                clsdirectorsVideos.Insert(myDirectorsVideos);


                //c.Open();
                //using (SqlCommand cmd = c.CreateCommand())
                //{
                //    cmd.Parameters.Clear();
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.CommandText = "sp_InsertDirectorsVideos";
                //    cmd.Parameters.Add("@VideoTitle", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
                //    cmd.Parameters.Add("@VideoFile", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
                //    cmd.Parameters.Add("@VideoPath", SqlDbType.VarChar).Value = System.Convert.ToString(URL + FileName);
                //    cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"]);
                //    cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"]);
                //    cmd.Parameters.Add("@BoardID", SqlDbType.Int).Value = Convert.ToInt32(BoardID);
                //    cmd.Parameters.Add("@Rank", SqlDbType.Int).Value = Convert.ToInt32(txtRank.Text);
                  
                //    cmd.ExecuteNonQuery();
                //}
                //c.Close();

                PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
                Response.Redirect("DirectorsBoard.aspx?PresentationID=" + PresentationID.ToString(), false);
         
            //}
            //else
            //{
            //    lblErrorAdd.Text = "cannot accept this file type";
            //}
        }
        else
        {
            lblErrorAdd.Text = "Please choose video file to upload";
        }








    }
    protected void btnCancelSaveVideo_Click(object sender, EventArgs e)
    {
        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
        Response.Redirect("DirectorsBoard.aspx?PresentationID=" + PresentationID.ToString(), false);
    }
}