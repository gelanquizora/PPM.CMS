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

public partial class DeckDirectory : System.Web.UI.Page
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

        DataView dvSql = (DataView)dsDirectory.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView drvSql in dvSql)
        {


            int dID = Convert.ToInt32(drvSql["DirectoryID"].ToString());
            if ((dID == 0))
            {
                   btnSave.Visible = true;
            }
            else
            {

                HiddenFieldDirectoryID.Value = Convert.ToInt32(dID).ToString();

         
                ContentEdit.Visible = false;
                HiddenFieldCoverID.Value = Convert.ToInt32(dID).ToString();
                lnlPreview.Attributes["href"] = "Preview/Directory.aspx?ID=" + dID;
                ContentEdit.Visible = true;
                EditDirectory(Convert.ToInt32(HiddenFieldDirectoryID.Value));
                BtnUpdateEdit.Visible = true;
            
      

           


               
            }

        }
    }
   
    protected void BtnSave_Click(object sender, System.EventArgs e)
    {

        //save
        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
 
        string UserSignature = EditorEdit.Text;

        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertDirectory";
            cmd.Parameters.Add("@DirectoryPage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature);
            cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = PresentationID;
            cmd.ExecuteNonQuery();
        }
        c.Close();






        string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;


        Directory.CreateDirectory(Server.MapPath(pathToCreate));

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "dr01.html";




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
                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Directory</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'></head><body><div class='IpadContent'>{0}</div> </body></html>", EditorEdit.Text));
            }
        }





        loadView();
        btnSave.Visible = false;
        BtnUpdateEdit.Visible = true;
     
    }
     
   
     

    private void EditDirectory(int DirectoryID)
    {

        Directorytbl myDirectory;
        myDirectory = clsDirectory.getDirectory(DirectoryID);


        EditorEdit.Text = HttpUtility.HtmlDecode(myDirectory.DirectoryPage.ToString());


    }

    //for edit
    protected void ClearButtonEdit_Click(object sender, EventArgs e)
    {
        EditorEdit.Text = String.Empty;

       
    }
  
    protected void BtnUpdateEdit_Click(object sender, System.EventArgs e)
    {


        
        string UserSignature = EditorEdit.Text;


 

        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;


        Directory.CreateDirectory(Server.MapPath(pathToCreate));

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "dr01.html";




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
                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Directory</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'></head><body><div class='IpadContent'>{0}</div> </body></html>", EditorEdit.Text));
            }
        }




        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateDirectory";
            cmd.Parameters.Add("@DirectoryPage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature);
            cmd.Parameters.Add("@DirectoryID", SqlDbType.Int).Value = HiddenFieldDirectoryID.Value;
            cmd.ExecuteNonQuery();
        }
        c.Close();
 
        loadView();

        btnSave.Visible = false;
        BtnUpdateEdit.Visible = true;
   
    }
   
}