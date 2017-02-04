using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
public partial class Edit_Page : System.Web.UI.Page
{
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (IsPostBack)
        {
            // If condition is true, execute these statements.
        }
        else
        {
            this.loadPage();
        }
    }

    private void loadPage()
    {




        int PagePageID;
        PagePageID = Convert.ToInt32(Request.QueryString.Get("PageID"));
        Page myPage;
        myPage = clspage.getPage(PagePageID);
        txtPageID.Text = PagePageID.ToString();
        txtPageName.Text = myPage.PageName.ToString();
       // UserSignature.Label = HttpUtility.HtmlDecode(UserSignature)

        Editor.Text = myPage.PageContent.ToString();

       // txtPageContent.Text = 
        txtOrdinal.Text = myPage.Ordinal.ToString();
        txtPresentationID.Text = myPage.PresentationID.ToString();
    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        DataStore.StoreHtml(Editor.Text);
    }
    protected class DataStore
    {
        public static void StoreHtml(string html)
        {
        }
    }
    protected void ClearButton_Click(object sender, EventArgs e)
    {
        Editor.Text = String.Empty;
    }
    protected void PreviewButton_Click(object sender, EventArgs e)
    {
        switch (Selections.SelectedValue)
        {
            case "Formatted":
                TextPreview.InnerHtml = Editor.Text;
                break;
            case "Html":
                TextPreview.InnerText = Editor.Text;
                break;
            default:
                break;
        }
    }
    protected void BtnUpdate_Click(object sender, System.EventArgs e)
    {
      

        PreviewButton_Click(null, EventArgs.Empty);
     string UserSignature = TextPreview.InnerHtml;

       

        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdatePage";
            cmd.Parameters.Add("@PageName", SqlDbType.VarChar).Value = txtPageName.Text;
            cmd.Parameters.Add("@PageContent", SqlDbType.VarChar).Value = HttpUtility.HtmlEncode(UserSignature);
            cmd.Parameters.Add("@Ordinal", SqlDbType.Int).Value = txtOrdinal.Text;
            cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = txtPresentationID.Text;
            cmd.Parameters.Add("@PageID", SqlDbType.Int).Value = txtPageID.Text;
          
            cmd.ExecuteNonQuery();        
            
        }
        c.Close();

        Response.Redirect("PresentationGridMaster.aspx", false);
    }

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("PresentationGridMaster.aspx", false);
    }
}