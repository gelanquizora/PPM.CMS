using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Master_Documents : System.Web.UI.Page
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
    protected void createNew_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //c.Open();
        //using (SqlCommand cmd = c.CreateCommand())
        //{
        //    cmd.Parameters.Clear();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "sp_InsertDocuments";
        //    cmd.Parameters.Add("@DocumentTitle", SqlDbType.VarChar).Value = Convert.ToInt32(e.CommandArgument);
        //    cmd.Parameters.Add("@DocumentPath", SqlDbType.VarChar).Value = Convert.ToInt32(e.CommandArgument);
        //    cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = Convert.ToInt32(e.CommandArgument);
        //    cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime ).Value = Convert.ToInt32(e.CommandArgument);
        //    cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar ).Value = Convert.ToInt32(e.CommandArgument);
        //    cmd.ExecuteNonQuery();

        //}
        //c.Close();
    }
}