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

public partial class Master_Edit_DirectorsTreatment : System.Web.UI.Page
{
    private string Contents = ConfigurationManager.AppSettings["Contents"].ToString();

    private string repository = ConfigurationManager.AppSettings["repository"].ToString();
    private string URL = ConfigurationManager.AppSettings["URL"].ToString();
    int PresentationID = 0;
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
   
    string CompanyID = "0";
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["CompanyID"] == null)
                return;


            CompanyID = Session["CompanyID"].ToString();

            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

            pnlVideos.Visible = false;
           
        }
    }

   protected void gvTreatment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {

            int index = Convert.ToInt32(e.CommandArgument);
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
            //Response.Redirect("View_DirectorsTreatment.aspx?DTID=" + index.ToString() + "&PresentationID=" + PresentationID.ToString());

            Panel2.Visible = true;
            Panel1.Visible = false;
            frmEntry.Attributes["src"] = "View_DirectorsTreatment.aspx?DTID=" + index.ToString() + "&PresentationID=" + PresentationID.ToString();

        }


        if (e.CommandName == "edt")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

            Panel2.Visible = true;
            Panel1.Visible = false;
            frmEntry.Attributes["src"] = "EditDirectorsTreatmentPanel.aspx?DTID=" + index.ToString() + "&PresentationID=" + PresentationID.ToString();

            //Response.Redirect("Edit_DirectorsTreatment.aspx?DTID=" + index.ToString() + "&PresentationID=" + PresentationID.ToString());







        }

        if (e.CommandName == "AddVideos")
        {

           HiddenFieldDTID .Value = Convert.ToInt32(e.CommandArgument).ToString ();
            Panel2.Visible = false;
            Panel1.Visible = false;
            pnlVideos.Visible = true;
            pnlVideoGrid.Visible = true;
            pnlVideoEntry.Visible = false;
            gvVideos.DataBind();

        }


        if (e.CommandName == "del")
        {

            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DeleteDirectorsTreatment";
                cmd.Parameters.Add("@DTID", SqlDbType.Int).Value = Convert.ToInt32(e.CommandArgument);
                cmd.ExecuteNonQuery();

            }
            c.Close();

            gvTreatment.DataBind();


        }
    }
   protected void BtnCancel_Click(object sender, System.EventArgs e)
   {
       Panel2.Visible = false;
       Panel1.Visible = true;

       gvTreatment.DataBind();

       
   }
   protected void BtnAddNew_Click(object sender, EventArgs e)
   {



       if (string.IsNullOrEmpty(Request.QueryString["PresentationID"]))
           return;

       frmEntry.Attributes["src"] = "Create_DirectorsTreatment.aspx?PresentationID=" + Request.QueryString["PresentationID"].ToString();
       Panel2.Visible = true;
       Panel1.Visible = false;
   }
   protected void BtnSave_Click(object sender, EventArgs e)
   {
       if (FileUpload1.HasFile)
       {
         

           string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

           FileUpload1.SaveAs(repository + FileName);






           c.Open();
           using (SqlCommand cmd = c.CreateCommand())
           {
               cmd.Parameters.Clear();
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "spInsertVideos";
               cmd.Parameters.Add("@VideoFile", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
               cmd.Parameters.Add("@VideoPath", SqlDbType.VarChar).Value = System.Convert.ToString(URL + FileName);

               cmd.Parameters.Add("@DTID", SqlDbType.Int).Value = Convert.ToInt32(HiddenFieldDTID.Value);


               cmd.ExecuteNonQuery();
           }
           c.Close();

           gvVideos.DataBind();

           Panel2.Visible = false;
           Panel1.Visible = false;
           pnlVideos.Visible = true;
           pnlVideoGrid.Visible = true;
           pnlVideoEntry.Visible = false;

       }
       else
       {
          
       }
   }
   protected void gvVideos_RowCommand(object sender, GridViewCommandEventArgs e)
   {
       if (e.CommandName == "del")
       {

           c.Open();
           using (SqlCommand cmd = c.CreateCommand())
           {
               cmd.Parameters.Clear();
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "spDeleteVideos";
               cmd.Parameters.Add("@DTVideoID", SqlDbType.Int).Value = Convert.ToInt32(e.CommandArgument);
               cmd.ExecuteNonQuery();

           }
           c.Close();

           gvVideos.DataBind();

           Panel2.Visible = false;
           Panel1.Visible = false;
           pnlVideos.Visible = true;
           pnlVideoGrid.Visible = true;
           pnlVideoEntry.Visible = false;
       }
   }
   protected void btnAddVideos_Click(object sender, EventArgs e)
   {
       Panel2.Visible = false;
       Panel1.Visible = false;
       pnlVideos.Visible = true;
       pnlVideoGrid.Visible = false;
       pnlVideoEntry.Visible = true;
   }
   protected void BtnCandelVideo_Click(object sender, EventArgs e)
   {
       Panel2.Visible = false;
       Panel1.Visible = true;
       pnlVideos.Visible = false;

   }
   protected void btnCancelAddVideos_Click(object sender, EventArgs e)
   {
       Panel2.Visible = false;
       Panel1.Visible = true;
       pnlVideos.Visible = false;
   }


   protected void gvTreatment_RowDataBound(Object sender, GridViewRowEventArgs e)
   {

       if (e.Row.RowType == DataControlRowType.DataRow)
       {
           // Display the company name in italics.
           Image img = (Image)e.Row.FindControl("img");
           DataRowView rowView = (DataRowView)e.Row.DataItem;
           string value = rowView["ImageFile"].ToString();
           img.ImageUrl = CompanyID + "/" + PresentationID.ToString() + "/repository/" + value;
           img.AlternateText = CompanyID + "/" + PresentationID.ToString() + "/repository/" + value;

       }

   }

   #region "Generate HTML"
   protected void generate(string template)
   {


       //Label1.Text = "template" + template;

       string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;

       if (!Directory.Exists(Server.MapPath(pathToCreate)))
       {
           Directory.CreateDirectory(Server.MapPath(pathToCreate));
           DirectoryCopy(Server.MapPath("~/_ipad"), Server.MapPath(pathToCreate), true);
       }




       string fileLoc = Server.MapPath(pathToCreate) + "/" + "dt01.html";
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



               sw.Write(string.Format(@"<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' />" +
                                       "<title>Soundtrack</title>" +
                                       "<script src='js/jquery.min.js'></script>" +
                                       "<style type='text/css'> ul{{ list-style-type: none; }}li{{width: 300px;}}</style></head>" +
                                      " <body><div id='wrapper'>" +
                                       "<ul>{0}</ul></div></body></html>", template));







           }
       }
   }
   #endregion

   #region "Copy Directory"
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

   #endregion
}