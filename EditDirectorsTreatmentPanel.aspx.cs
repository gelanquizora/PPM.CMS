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


public partial class EditDirectorsTreatmentPanel : System.Web.UI.Page
{

    private string Contents = ConfigurationManager.AppSettings["Contents"].ToString();

    private string repository = ConfigurationManager.AppSettings["repository"].ToString();
    private string URL = ConfigurationManager.AppSettings["URL"].ToString();
    int PresentationID = 0;
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int DirectorsTreatmentDTID;
            DirectorsTreatmentDTID = Convert.ToInt32(Request.QueryString.Get("DTID"));
            this.loadDirectorsTreatment();
        }
    }

    private void loadDirectorsTreatment()
    {
        int DirectorsTreatmentDTID;
        DirectorsTreatmentDTID = Convert.ToInt32(Request.QueryString.Get("DTID"));

        DirectorsTreatment myDirectorsTreatment;
        myDirectorsTreatment = clsdirectorsTreatment.getDirectorsTreatment(DirectorsTreatmentDTID);
        HiddenField1.Value = myDirectorsTreatment.DTID.ToString();
        lblFile.Text = myDirectorsTreatment.ImageFile.ToString();
        //txtImagePath.Text = myDirectorsTreatment.ImagePath.ToString();
        txtVoiceOver.Text = myDirectorsTreatment.VoiceOver.ToString();
        txtDescription.Text = myDirectorsTreatment.Description.ToString();
        txtRank.Text = myDirectorsTreatment.Rank.ToString();

    }

    protected void BtnUpdate_Click(object sender, System.EventArgs e)
    {

        //DirectorsTreatment myDirectorsTreatment;
        //myDirectorsTreatment = new DirectorsTreatment();
        //myDirectorsTreatment.DTID = System.Convert.ToInt32(HiddenField1.Value);
        ////myDirectorsTreatment.ImageFile = System.Convert.ToString(txtImageFile.Text);
        ////myDirectorsTreatment.ImagePath = System.Convert.ToString(txtImagePath.Text);
        //myDirectorsTreatment.VoiceOver = System.Convert.ToString(txtVoiceOver.Text);
        //myDirectorsTreatment.Description = System.Convert.ToString(txtDescription.Text);
        //myDirectorsTreatment.Rank = System.Convert.ToInt32(txtRank.Text);
        ////myDirectorsTreatment.CreatedBy = System.Convert.ToString(txtCreatedBy.Text);
        ////myDirectorsTreatment.CreatedDate = System.Convert.ToDateTime(calCreatedDate.SelectedDate);
        //myDirectorsTreatment.ModifiedBy = System.Convert.ToString(Session["Username"].ToString());
        //myDirectorsTreatment.ModifiedDate = System.Convert.ToDateTime(DateTime.Now);
        //clsdirectorsTreatment.Update(myDirectorsTreatment);



        string strFileNameWithPath = FileUpload2.PostedFile.FileName;

        string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
        if (FileUpload2.HasFile)
        {
            //if (strExtensionName.Equals(".mp4"))
            //{

            string FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);

            FileInfo fi = new FileInfo(FileName);
            string ext = fi.Extension;
            FileName = Guid.NewGuid().ToString() + ext;
            
            FileUpload2.SaveAs(repository + FileName);


            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UpdateDirectorsTreatment";
                cmd.Parameters.Add("@ImageFile", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
                cmd.Parameters.Add("@ImagePath", SqlDbType.VarChar).Value = System.Convert.ToString(URL + FileName);
                cmd.Parameters.Add("@DTID", SqlDbType.Int).Value = Convert.ToInt32(HiddenField1.Value);

                cmd.Parameters.Add("@VoiceOver", SqlDbType.VarChar).Value = System.Convert.ToString(txtVoiceOver.Text);
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = System.Convert.ToString(txtDescription.Text);
                cmd.Parameters.Add("@Rank", SqlDbType.Int).Value = System.Convert.ToInt32(txtRank.Text);
                cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = Convert.ToInt32(HiddenField1.Value);
                cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = Convert.ToInt32(HiddenField1.Value);
                cmd.Parameters.Add("@DTID", SqlDbType.Int).Value = Convert.ToInt32(HiddenField1.Value);



                cmd.ExecuteNonQuery();
            }
            c.Close();







            //}
            //else
            //{
            //    lblErrorAdd.Text = "cannot accept this file type";
            //}
        }
        else
        {
            lblErrorAdd.Text = "Please choose file to upload";
        }








        Response.Redirect("Treatment.aspx", false);
    }
}