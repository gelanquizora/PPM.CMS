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
public partial class Edit_Company : System.Web.UI.Page
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
            int CompanyCompanyID;
            CompanyCompanyID = Convert.ToInt32(Request.QueryString.Get("CompanyID"));
            this.loadCompany();
        }
    }

    private void loadCompany()
    {
        int CompanyCompanyID;
        CompanyCompanyID = Convert.ToInt32(Request.QueryString.Get("CompanyID"));
        Company myCompany;
        myCompany = clscompany.getCompany(CompanyCompanyID);
        lblCompanyID.Text = CompanyCompanyID.ToString();
        txtCompanyName.Text = myCompany.CompanyName.ToString();
        txtDescription.Text = myCompany.Description.ToString();



        if (string.IsNullOrEmpty(myCompany.Logo.ToString()))
        {
            img.ImageUrl = "";
        }
        else
        {
            img.ImageUrl = Contents + myCompany.Logo.ToString();
        }


    }

    protected void BtnUpdate_Click(object sender, System.EventArgs e)
    {
        int CompanyCompanyID;
        CompanyCompanyID = Convert.ToInt32(Request.QueryString.Get("CompanyID"));
        Company myCompany;
        myCompany = new Company();
        myCompany.CompanyID = CompanyCompanyID.ToString();
        myCompany.CompanyName = System.Convert.ToString(txtCompanyName.Text);
        myCompany.Description = System.Convert.ToString(txtDescription.Text);

        HiddenField1.Value = CompanyCompanyID.ToString();
        
        clscompany.Update(myCompany);

        if (FileUploadEdit.HasFile)
        {





            string FileName = Path.GetFileName(FileUploadEdit.PostedFile.FileName);

            FileUploadEdit.SaveAs(repository + FileName);


            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UpdateCompanyLogo";
                cmd.Parameters.Add("@Logo ", SqlDbType.VarChar).Value = FileName;
                cmd.Parameters.Add("@URL", SqlDbType.VarChar).Value = URL + FileName;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = HiddenField1.Value;

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