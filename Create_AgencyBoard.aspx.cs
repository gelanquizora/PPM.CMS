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

public partial class Master_Create_AgencyBoard : System.Web.UI.Page
{
    private string Contents = ConfigurationManager.AppSettings["Contents"].ToString();

    private string repository = ConfigurationManager.AppSettings["repository"].ToString();
    private string URL = ConfigurationManager.AppSettings["URL"].ToString();
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (IsPostBack)
        {
            // If this is a Postback, execute these statements.
        }
        else
        {
            // Put code to execute for non postback here
        }
    }

    protected void BtnSave_Click(object sender, System.EventArgs e)
    {
        

        string strFileNameWithPath = FileUpload1.PostedFile.FileName;

        string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
        if (FileUpload1.HasFile)
        {
            //if (strExtensionName.Equals(".mp4"))
            //{

            string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

            FileUpload1.SaveAs(repository + FileName);



            AgencyBoard myAgencyBoard;
            myAgencyBoard = new AgencyBoard();
            //myAgencyBoard.AgencyID = System.Convert.ToInt32(txtAgencyID.Text);
            myAgencyBoard.ImageFile = System.Convert.ToString(FileName);
            myAgencyBoard.ImagePath = System.Convert.ToString(URL + FileName);
            myAgencyBoard.CreatedBy = System.Convert.ToString(Session["Username"]);
            myAgencyBoard.CreatedDate = System.Convert.ToDateTime(DateTime.Now);
            myAgencyBoard.ModifiedBy = System.Convert.ToString(Session["Username"]);
            myAgencyBoard.ModifiedDate = System.Convert.ToDateTime(DateTime.Now);
            clsagencyBoard.Insert(myAgencyBoard);
            Response.Redirect("AgencyBoardGrid.aspx", false);

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

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("AgencyBoardGrid.aspx", false);
    }
}