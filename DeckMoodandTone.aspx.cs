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

public partial class DeckMoodandTone : System.Web.UI.Page
{
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    int PresentationID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
         
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
            string _clientID = "0";
            if (!string.IsNullOrEmpty(Request.QueryString["ClientID"]))
                _clientID = Request.QueryString["ClientID"].ToString();



            string param = "PresentationID=" + PresentationID.ToString() + "&ClientID=" + _clientID.ToString();
            btnBack.Attributes["href"] = "ProjectInside.aspx?" + param;

            loadView();
        }

    
        


    }
    private void loadView()
{
        //for Attendee
        DataView dvSql = (DataView)dsModeAndTone.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView drvSql in dvSql)
        {

            int mID = Convert.ToInt32(drvSql["ModeToneID"].ToString());
            if ((mID == 0))
            {

                btnSave.Visible = true;
            }
            else
            {

                HiddenFieldModeAndToneID.Value = Convert.ToInt32(mID).ToString();
              
                ContentEdit.Visible = false;
                HiddenFieldCoverID.Value = Convert.ToInt32(mID).ToString();
                lnlPreview.Attributes["href"] = "Preview/MoodTone.aspx?ID=" + mID;
                ContentEdit.Visible = true;
                EditModeandTone(Convert.ToInt32(HiddenFieldCoverID.Value));
                BtnUpdateEdit.Visible = true;

              


               
            }
        }
}

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        // Response.Redirect("PresentationMaster.aspx", false);
    }
    protected void BtnSave_Click(object sender, System.EventArgs e)
    {

        //save Attendee
        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

 
        string UserSignature = EditorEdit.Text;

        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertModeTone";
            cmd.Parameters.Add("@ModeTonePage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature);
            cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = PresentationID;
            cmd.ExecuteNonQuery();
        }
        c.Close();


 
        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;


        Directory.CreateDirectory(Server.MapPath(pathToCreate));

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "mt01.html";


        FileStream fs = null;
        if (!File.Exists(fileLoc))
        {
            using (fs = File.Create(fileLoc))
            {

            }
        }

        if (File.Exists(fileLoc))
        {
            using (StreamWriter sw = new StreamWriter(fileLoc))
            {
                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Mood and Tone</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'></head><body><div class='IpadContent'>{0}</div> </body></html>", EditorEdit.Text));
       
            }
        }

        loadView();
        btnSave.Visible = false;
        BtnUpdateEdit.Visible = true;


    }
  
  
   
    protected void btnEditModeAndTone_Click(object sender, EventArgs e)
    {
        
        EditModeandTone(Convert.ToInt32(HiddenFieldModeAndToneID.Value));

    }

    private void EditModeandTone(int ModeToneID)
    {

        ModeTone myModeTone;
        myModeTone = clsmodeTone.getModeTone(ModeToneID);


        EditorEdit.Text = HttpUtility.HtmlDecode(myModeTone.ModeTonePage.ToString());


    }

    //for edit
    protected void ClearButtonEdit_Click(object sender, EventArgs e)
    {
        EditorEdit.Text = String.Empty;

        
    }
    
    protected void BtnUpdateEdit_Click(object sender, System.EventArgs e)
    {



        string UserSignature = EditorEdit.Text;

        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateModeTone";
            cmd.Parameters.Add("@ModeTonePage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature);
            cmd.Parameters.Add("@ModeToneID", SqlDbType.Int).Value = HiddenFieldModeAndToneID.Value;
            cmd.ExecuteNonQuery();
        }
        c.Close();


 


        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;


        Directory.CreateDirectory(Server.MapPath(pathToCreate));

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "mt01.html";




        if (File.Exists(fileLoc))
        {
            using (StreamWriter sw = new StreamWriter(fileLoc))
            {
                 sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Mood and Tone</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'></head><body><div class='IpadContent'>{0}</div> </body></html>", EditorEdit.Text));
            }
        }
        loadView();

        btnSave.Visible = false;
        BtnUpdateEdit.Visible = true;

    }
     
}