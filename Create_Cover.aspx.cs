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
public partial class Master_Create_Cover : System.Web.UI.Page
{
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



        PreviewButton_Click(null, EventArgs.Empty);
        string UserSignature = TextPreview.InnerHtml;

        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertCover";
            cmd.Parameters.Add("@CoverPage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature);           
            cmd.ExecuteNonQuery();

        }
        c.Close();

     //   Cover myCover;
     //   myCover = new Cover();

     //   string UserSignature = TextPreview.InnerHtml;
     ////   lblHTML.Text = HttpUtility.HtmlEncode(UserSignature);


     //   myCover.CoverTitle = System.Convert.ToString("1");
     //   myCover.CoverPage = Server.HtmlEncode(UserSignature); ;
     //   myCover.CoverFileName = System.Convert.ToString("1.html");
     //   myCover.CreatedBy = System.Convert.ToString("");
     //   myCover.CreatedDate = System.Convert.ToDateTime(DateTime.Now);
     //   myCover.ModifiedBy = System.Convert.ToString("");
     //   myCover.ModifiedDate = System.Convert.ToDateTime(DateTime.Now);


     //   clscover.Insert(myCover);


     //   FileInfo f = new FileInfo(MapPath("~/") + "1.html");
     //   TextWriter tw = f.CreateText();
     //   tw.Write(string.Format("<head><title></title></head><body >{0}</body></html>", TextPreview.InnerHtml));
     //   tw.Close();

        Response.Redirect("CoverGrid.aspx", false);
    }

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("CoverGrid.aspx", false);
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
    protected void ClearButton_Click(object sender, EventArgs e)
    {
        Editor.Text = String.Empty;
    }
}