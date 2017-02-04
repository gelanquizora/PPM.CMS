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

public partial class EditMapPage : System.Web.UI.Page
{
    private string Contents = ConfigurationManager.AppSettings["Contents"].ToString();

    private string repository = ConfigurationManager.AppSettings["repository"].ToString();
    private string URL = ConfigurationManager.AppSettings["URL"].ToString();
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    int PresentationID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //for Attendee
        DataView dvSql = (DataView)dsMap.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView drvSql in dvSql)
        {

            int mID = Convert.ToInt32(drvSql["MapID"].ToString());
            if ((mID == 0))
                HiddenFieldMapID.Value = "0";
            else
              HiddenFieldMapID.Value = Convert.ToInt32(mID).ToString();
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
              
             

        }
    }

    protected void BtnUpdateMap_Click(object sender, EventArgs e)
    {
        if (HiddenFieldMapID.Value == "0")
            AddMap();
        else
            UpdateMap();

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'> window.parent.location.reload();</script>", false); 
    }
    

    private void AddMap()
    {

    

          string strFileNameWithPath = FileUpload2.PostedFile.FileName;
          string rep = Session["CompanyID"] + "/" + PresentationID + "/repository/";

        string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
        if (FileUpload2.HasFile)
        {
            //if (strExtensionName.Equals(".mp4"))
            //{

            //string FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);

            //FileUpload2.SaveAs(repository + FileName);


        

            string FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
            FileInfo fi = new FileInfo(FileName);
            string ext = fi.Extension;
            FileName = Guid.NewGuid().ToString() + ext;


            string pathToCreate1 = "~/" + Session["CompanyID"] + "/" + PresentationID + "/repository";
            string strFile = "";
            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
            Directory.CreateDirectory(Server.MapPath(pathToCreate1));
            FileUpload2.SaveAs(strFile);
            string fullpath = Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName;

            string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;
            Directory.CreateDirectory(Server.MapPath(pathToCreate));
            string fileLoc = Server.MapPath(pathToCreate) + "/" + "mp01.html";

            string ImgFile = "<img src='repository/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName + "' alt=''>";





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
                    sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Map</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'><script src='js/jquery-latest.min.js'></script><link rel='stylesheet' href='css/orangebox.css' type='text/css' /></head><body><div id='wrapper'><div id='dt_summ'>{0}</div></div></body></html>", ImgFile));




                }
            }


                
          c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_InsertMap";
                cmd.Parameters.Add("@MapFile", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
                cmd.Parameters.Add("@MapPath", SqlDbType.VarChar).Value = System.Convert.ToString(rep + FileName);
                cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = Convert.ToInt32(PresentationID);
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
                cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);

                cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
                cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);


                cmd.ExecuteNonQuery();
            }
            c.Close();
        

      
        }
        else
        {
            lblErrorAdd.Text = "Please choose video file to upload";
        }
    }

    private void UpdateMap()
    {
        string strFileNameWithPath = FileUpload2.PostedFile.FileName;

        string rep = Session["CompanyID"] + "/" + PresentationID + "/repository/";


        string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
        if (FileUpload2.HasFile)
        {
            //if (strExtensionName.Equals(".mp4"))
            //{

            ////////string FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);

            ////////FileUpload2.SaveAs(repository + FileName);

            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

            string FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
            FileInfo fi = new FileInfo(FileName);
            string ext = fi.Extension;
            FileName = Guid.NewGuid().ToString() + ext;


            string pathToCreate1 = "~/" + Session["CompanyID"] + "/" + PresentationID + "/repository";
            string strFile = "";
            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
            Directory.CreateDirectory(Server.MapPath(pathToCreate1));
            FileUpload2.SaveAs(strFile);
            string fullpath = Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName;

            string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;
            Directory.CreateDirectory(Server.MapPath(pathToCreate));
            string fileLoc = Server.MapPath(pathToCreate) + "/" + "mp01.html";

            string ImgFile = "<img src='repository/" + FileName + "' alt=''>";





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
                    sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Map</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'><script src='js/jquery-latest.min.js'></script><link rel='stylesheet' href='css/orangebox.css' type='text/css' /></head><body><div id='wrapper'><div id='dt_summ'>{0}</div></div></body></html>", ImgFile));




                }
            }



            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UpdateMap";
                cmd.Parameters.Add("@MapFile", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
                cmd.Parameters.Add("@MapPath", SqlDbType.VarChar).Value = System.Convert.ToString(rep + FileName);
                cmd.Parameters.Add("@MapID", SqlDbType.Int).Value = Convert.ToInt32(HiddenFieldMapID.Value);
                cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
                cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);


                cmd.ExecuteNonQuery();
            }
            c.Close();



            lblErrorAdd.Text = "";

        }
        else
        {
            lblErrorAdd.Text = "Please choose image file to upload";
        }
    }
}