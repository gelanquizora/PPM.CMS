using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

public partial class _SA_Company : System.Web.UI.Page
{
   
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    private string repository = ConfigurationManager.AppSettings["repository"].ToString();
    private string URL = ConfigurationManager.AppSettings["URL"].ToString();
    private string Contents = ConfigurationManager.AppSettings["Contents"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        int CompanyID = System.Convert.ToInt32(GridView1.SelectedValue);
        Response.Redirect("Edit_Company.aspx?CompanyID=" + CompanyID.ToString(), false);
    }
    protected void createNew_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
        btnAddNew.Visible = false;

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


            DataView dvSql = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
            foreach (DataRowView drvSql in dvSql)
            {
                HiddenFieldID.Value = drvSql["cID"].ToString();
            }


          

          //  string FileName = Path.GetFileName(FileUploadControl.PostedFile.FileName);
            string extension = Path.GetExtension(FileUploadControl.PostedFile.FileName);
            string FileName = HiddenFieldID.Value + extension;
            FileUploadControl.SaveAs(repository + FileName);


            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UpdateCompanyLogo";
                cmd.Parameters.Add("@Logo ", SqlDbType.VarChar).Value = FileName;
                cmd.Parameters.Add("@URL", SqlDbType.VarChar).Value = "/repository/" + FileName;
                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = HiddenFieldID.Value;

                cmd.ExecuteNonQuery();

            }
            c.Close();

        }

        createFolder(HiddenFieldID.Value);
        GridView1.DataBind();
        Panel1.Visible = true;
        Panel2.Visible = false;
        btnAddNew.Visible = true;
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "del")
        {
            int index = Convert.ToInt32(e.CommandArgument);


            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UpdateCompany_Deactivate";
                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = System.Convert.ToInt32(index);
                cmd.ExecuteNonQuery();

            }
            c.Close();

            GridView1.DataBind();

        }
        else if (e.CommandName == "edt")
        {

            int companyID = Convert.ToInt32(e.CommandArgument);
            loadCompany(companyID);
            Panel4.Visible = true;
            Panel1.Visible = false;
            btnAddNew.Visible = false;
            viewMode(true);
            txtID.Value = companyID.ToString();

        }
        else if (e.CommandName == "view")
        {

            int companyID = Convert.ToInt32(e.CommandArgument);
            loadCompany(companyID);
            Panel4.Visible = true;
            Panel1.Visible = false;
            btnAddNew.Visible = false;
            viewMode(false);
            txtID.Value = companyID.ToString();

        }
        else if (e.CommandName == "changelogo")
        {

            int companyID = Convert.ToInt32(e.CommandArgument);
            loadCompany(companyID);
            Panel5.Visible = true;
            Panel1.Visible = false;
            btnAddNew.Visible = false;
            viewMode(true);
            txtID.Value = companyID.ToString();

        }
    }


    #region "Edit"
    private void loadCompany(int companyID)
    {
        
        Company myCompany;
        myCompany = clscompany.getCompany(companyID);
       // lblCompanyID.Text = CompanyCompanyID.ToString();
        txtEditCompanyName.Text = myCompany.CompanyName.ToString();
        txtEditDescription.Text = myCompany.Description.ToString();

     
        if (string.IsNullOrEmpty(myCompany.Logo.ToString()))
        {
            img.ImageUrl = "";
        }
        else
        {
            img.ImageUrl = Contents + myCompany.Logo.ToString();
        }


    }
    private void viewMode(bool Editable)
    {
        txtEditCompanyName.Enabled = Editable;
        txtEditDescription.Enabled = Editable;
        BtnUpdate.Visible = Editable;
 

    }
    #endregion
    protected void btnCancelNewItem_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        btnAddNew.Visible = false;
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel4.Visible = false;
        Panel5.Visible = false;
        btnAddNew.Visible = false;
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
         
        int CompanyCompanyID;
        CompanyCompanyID = Convert.ToInt32(txtID.Value);
        Company myCompany;
        myCompany = new Company();
        myCompany.CompanyID = CompanyCompanyID.ToString();
        myCompany.CompanyName = System.Convert.ToString(txtEditCompanyName.Text);
        myCompany.Description = System.Convert.ToString(txtEditDescription.Text);

        HiddenField1.Value = CompanyCompanyID.ToString();
        
        clscompany.Update(myCompany);

        GridView1.DataBind();
    }
    protected void BtnUpdateLogo_Click(object sender, EventArgs e)
    {

        if (FileUploadEdit.HasFile)
        {

           // string FileName = Path.GetFileName(FileUploadEdit.PostedFile.FileName);

            string extension = Path.GetExtension(FileUploadEdit.PostedFile.FileName);
            string FileName = txtID.Value + extension;
            FileUploadEdit.SaveAs(repository + FileName);

          


            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UpdateCompanyLogo";
                cmd.Parameters.Add("@Logo ", SqlDbType.VarChar).Value = FileName;
                cmd.Parameters.Add("@URL", SqlDbType.VarChar).Value = "/repository/" + FileName;
                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = txtID.Value;

                cmd.ExecuteNonQuery();

            }
            c.Close();


            Panel5.Visible = false;
            Panel1.Visible = true;
            btnAddNew.Visible = true;
        }

    }

    private void createFolder(string cid)
    {
        try
        {

            string pathToCreate = "~/" + cid;


            Directory.CreateDirectory(Server.MapPath(pathToCreate));

            // Determine whether the directory exists. 
            if (Directory.Exists(pathToCreate))
            {
                Console.WriteLine("That path exists already.");
                return;
            }

            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(pathToCreate);
            //Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(pathToCreate));

         
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        finally { }
    }
}
