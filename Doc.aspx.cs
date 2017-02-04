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

public partial class Master_Doc : System.Web.UI.Page
{
    private string Contents = ConfigurationManager.AppSettings["Contents"].ToString();

    private string repository = ConfigurationManager.AppSettings["repository"].ToString();
    private string URL = ConfigurationManager.AppSettings["URL"].ToString();
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetDefaultView();


        }
    }
    private void SetDefaultView()
    {
        MultiView1.ActiveViewIndex = 0;
    }


    private void loadDocuments()
    {


    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {



        }


        if (e.CommandName == "edt")
        {

            MultiView1.ActiveViewIndex = 2;
            int DocumentDocumentID;
            DocumentDocumentID = Convert.ToInt32(e.CommandArgument);
            Documents myDocuments;
            myDocuments = clsdocuments.getDocuments(DocumentDocumentID);
            HiddenField1.Value = myDocuments.DocumentID.ToString();
            txtFileEdit.Text = myDocuments.DocumentTitle.ToString();
            lblFile.Text = myDocuments.DocumentPath.ToString();


        }


        if (e.CommandName == "del")
        {

            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DeleteDocuments";
                cmd.Parameters.Add("@DocumentID", SqlDbType.Int).Value = Convert.ToInt32(e.CommandArgument);
                cmd.ExecuteNonQuery();

            }
            c.Close();

            gvDocuments.DataBind();


        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strFileNameWithPath = FileUpload1.PostedFile.FileName;

        string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
        if (FileUpload1.HasFile)
        {
            //if (strExtensionName.Equals(".mp4"))
            //{

            string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

            FileUpload1.SaveAs(repository + FileName);

            Documents myDocuments;
            myDocuments = new Documents();
          
            myDocuments.DocumentTitle = System.Convert.ToString(FileName);
            myDocuments.DocumentPath = System.Convert.ToString(URL + FileName);
            myDocuments.CreatedBy = System.Convert.ToString(Session["Username"]);
            myDocuments.CreatedDate = System.Convert.ToDateTime(DateTime.Now);
            myDocuments.ModifiedBy = System.Convert.ToString(Session["Username"]);
            myDocuments.ModifiedDate = System.Convert.ToDateTime(DateTime.Now);
            clsdocuments.Insert(myDocuments);

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
    protected void btnCancelAdd_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void btnCancelEdit_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void createNew_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
}