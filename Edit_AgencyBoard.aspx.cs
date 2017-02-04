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

public partial class Master_Edit_AgencyBoard : System.Web.UI.Page
{
    private string Contents = ConfigurationManager.AppSettings["Contents"].ToString();

    private string repository = ConfigurationManager.AppSettings["repository"].ToString();
    private string URL = ConfigurationManager.AppSettings["URL"].ToString();
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());

    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (IsPostBack)
        {
            // If condition is true, execute these statements.
        }
        else
        {
            int AgencyBoardAgencyID;
            AgencyBoardAgencyID = Convert.ToInt32(Request.QueryString.Get("AgencyID"));
            this.loadAgencyBoard();
        }
    }

    private void loadAgencyBoard()
    {
        AgencyBoard myAgencyBoard;
        //myAgencyBoard = clsagencyBoard.getAgencyBoard();
        //HiddenField1.Value = myAgencyBoard.AgencyID.ToString();
        //lblFile.Text = myAgencyBoard.ImageFile.ToString();
       
    }

    protected void BtnUpdate_Click(object sender, System.EventArgs e)
    {
    
        string strFileNameWithPath = FileUpload1.PostedFile.FileName;

        string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
        if (FileUpload1.HasFile)
        {
            //if (strExtensionName.Equals(".mp4"))
            //{

            string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileInfo fi = new FileInfo(FileName);
            string ext = fi.Extension;
            FileName = repository + Guid.NewGuid().ToString() + ext;




            FileUpload1.SaveAs(repository + FileName);

            int AgencyBoardAgencyID;
            AgencyBoardAgencyID = Convert.ToInt32(Request.QueryString.Get("AgencyID"));

            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UpdateAgencyBoardFile";
                cmd.Parameters.Add("@ImageFile", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
                cmd.Parameters.Add("@ImagePath", SqlDbType.VarChar).Value = System.Convert.ToString( FileName);
                cmd.Parameters.Add("@AgencyID", SqlDbType.Int).Value = Convert.ToInt32(AgencyBoardAgencyID);
                cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
                cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);


                cmd.ExecuteNonQuery();
            }
            c.Close();




           // Response.Redirect("AgencyBoardGrid.aspx", false);

            //}
            //else
            //{
            //    lblErrorAdd.Text = "cannot accept this file type";
            //}
        }
        else
        {
            lblErrorAdd.Text = "Please choose image file to upload";
        }

    }

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("AgencyBoardGrid.aspx", false);
    }
}