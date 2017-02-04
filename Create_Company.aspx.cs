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

public partial class Create_Company : System.Web.UI.Page
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
        Company myCompany;
        myCompany = new Company();
        myCompany.CompanyName = System.Convert.ToString(txtCompanyName.Text);
        myCompany.Description = System.Convert.ToString(txtDescription.Text);
        clscompany.Insert(myCompany);


        if (FileUploadControl.HasFile)
        {


            DataView dvSql = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            foreach (DataRowView drvSql in dvSql)
            {
                HiddenFieldID.Value = drvSql["cID"].ToString();
            }


            string FileName = Path.GetFileName(FileUploadControl.PostedFile.FileName);

            FileUploadControl.SaveAs(repository + FileName);
   

        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateCompanyLogo";
            cmd.Parameters.Add("@Logo ", SqlDbType.VarChar).Value = FileName;
            cmd.Parameters.Add("@URL", SqlDbType.VarChar).Value = URL + FileName;
            cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = HiddenFieldID.Value;
          
            cmd.ExecuteNonQuery();        
            
        }
        c.Close();

        }

        Response.Redirect("CompanyGrid.aspx", false);
    }

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("CompanyGrid.aspx", false);
    }
}