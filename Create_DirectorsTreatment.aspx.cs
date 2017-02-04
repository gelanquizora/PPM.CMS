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




public partial class Create_DirectorsTreatment : System.Web.UI.Page
{
    private string Contents = ConfigurationManager.AppSettings["Contents"].ToString();

    private string repository = ConfigurationManager.AppSettings["repository"].ToString();
    private string URL = ConfigurationManager.AppSettings["URL"].ToString();
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    int PresentationID = 0;


 
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (IsPostBack)
        {
            // If this is a Postback, execute these statements.
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
        }
        //else
        //{
        //    // Put code to execute for non postback here
        //    //BindGrid();
        //}
    }


    protected void BtnSave_Click(object sender, System.EventArgs e)
    {

     


        string strFileNameWithPath = FileUpload2.PostedFile.FileName;

        string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
        if (FileUpload2.HasFile)
        {
            //if (strExtensionName.Equals(".mp4"))
            //{


            //Physical File
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

            string fullpath = "";
            string FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
            FileInfo fi = new FileInfo(FileName);
            string ext = fi.Extension;
            FileName = Guid.NewGuid().ToString() + ext;
           
            string pathToCreate1 = "~/" + Session["CompanyID"] + "/" + PresentationID + "/repository";


            Directory.CreateDirectory(Server.MapPath(pathToCreate1));
           


            fullpath = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);


            FileUpload2.SaveAs(fullpath);


            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_InsertDirectorsTreatment";
                cmd.Parameters.Add("@ImageFile", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
                cmd.Parameters.Add("@ImagePath", SqlDbType.VarChar).Value = System.Convert.ToString(URL + FileName);
                cmd.Parameters.Add("@VoiceOver", SqlDbType.VarChar).Value = System.Convert.ToString(txtVoiceOver.Text);
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = System.Convert.ToString(txtDescription.Text);
                cmd.Parameters.Add("@Rank", SqlDbType.Int).Value = System.Convert.ToInt32(txtRank.Text);
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
                cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);
                cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
                cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);
                cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = System.Convert.ToInt32(PresentationID);
                cmd.ExecuteNonQuery();

            }
            c.Close();

            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));


           
            txtVoiceOver.Text = "";
            txtDescription.Text = "";
            txtRank.Text = (Convert.ToInt32(txtRank.Text) + 1).ToString();

            
            //Generate Page
           
            DataTable dt =   clsdirectorsTreatment.getDirectorsTreatmentByPresentation(PresentationID);
            string li = "<li class='touchcarousel-item'> <img src='repository/{0}' width='800' height='600' /> <span> <strong>{1}</strong><br><em>{2}</em> </span> </li>";
            string lisummary = " <li>  <p>{0}</p><div class='imgContainer'> <img src='repository/{1}' width='150' height='90' alt=''></div></li>";

            string content = "";
            string summarylist = "";
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                content += string.Format(li, row["ImageFile"].ToString(), row["VoiceOver"].ToString(), row["Description"].ToString());
                summarylist += string.Format(lisummary, i, row["ImageFile"].ToString());

                i++;
            }

            generate(content, summarylist);
        }
        else
        {
            lblErrorAdd.Text = "Please choose file to upload";
        }





    }

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
       // Response.Redirect("Treatment.aspx", false);
    }


    protected void generate(string template,string summarylist )
    {


        //Label1.Text = "template" + template;

        string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;

        if (!Directory.Exists(Server.MapPath(pathToCreate)))
        {
            Directory.CreateDirectory(Server.MapPath(pathToCreate));
          
        }


        if (!Directory.Exists(Server.MapPath(pathToCreate + "/js")))
        {
            DirectoryCopy(Server.MapPath("~/_ipad"), Server.MapPath(pathToCreate), true);




        }


      


        string fileLoc = Server.MapPath(pathToCreate) + "/" + "dt01.html";
        //
        {

            System.IO.File.Delete(fileLoc);

        }


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

                string js = "<script type='text/javascript'>jQuery(function($) {$('#carousel-single-image').touchCarousel({pagingNav: true,scrollbar: false,directionNavAutoHide: false," +
                    "itemsPerMove: 1,loopItems: true,directionNav: false,autoplay: false,autoplayDelay: 2000,useWebkit3d: true," +
                    "transitionSpeed: 400});" +
                    "$('#carousel-single-image').bind('touchstart click', 	function(){e.preventDefault(); $('#carousel-single-image').click(function() { " +
                    "alert('hello');	$('span').delay(500).show('slide', { direction: 'up' }, 500);})});});" +
                    "</script>";

                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' />" +
 "<title>Director's Treatment</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'><link rel='stylesheet' href='css/touchcarousel.css' /><link rel='stylesheet' href='css/minimal-light-skin.css' /> " +
"<script src='js/jquery.min.js'></script>" +
"<script src='js/jquery.touchcarousel-1.1.js'></script></head>" +
"<body><div id='wrapper'><div id='carousel-single-image' class='touchcarousel   minimal-light'> " +
"<ul class='touchcarousel-container'>{0}<li class='touchcarousel-item'><div class='dt_summ'> <h2>DIRECTORS TREATMENT BOARD</h2>  <ul class='dt_list'>{1}</ul></div></li></ul></div></div>{2}</body></html>", template,summarylist, js));


            }
        }
    }

    private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
        // Get the subdirectories for the specified directory.
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);
        DirectoryInfo[] dirs = dir.GetDirectories();

        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }

        // If the destination directory doesn't exist, create it. 
        if (!Directory.Exists(destDirName))
        {
            Directory.CreateDirectory(destDirName);
        }

        // Get the files in the directory and copy them to the new location.
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string temppath = Path.Combine(destDirName, file.Name);
            file.CopyTo(temppath, false);
        }

        // If copying subdirectories, copy them and their contents to new location. 
        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath, copySubDirs);
            }
        }
    }

}