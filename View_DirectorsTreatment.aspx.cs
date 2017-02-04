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

public partial class Master_View_DirectorsTreatment : System.Web.UI.Page
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
        HiddenField1.Value  = myDirectorsTreatment.DTID.ToString();
        lblFile.Text = myDirectorsTreatment.ImageFile.ToString();


        img.ImageUrl = Contents + myDirectorsTreatment.ImageFile.ToString();

        //txtImagePath.Text = myDirectorsTreatment.ImagePath.ToString();
        txtVoiceOver.Text = myDirectorsTreatment.VoiceOver.ToString();
        txtDescription.Text = myDirectorsTreatment.Description.ToString();
        txtRank.Text = myDirectorsTreatment.Rank.ToString();
       
    }

   

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("Treatment.aspx", false);
    }
}