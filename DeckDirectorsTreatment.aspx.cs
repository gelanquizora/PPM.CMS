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


public partial class DeckDirectorsTreatment : System.Web.UI.Page
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
            string _clientID = "0";
            if (!string.IsNullOrEmpty(Request.QueryString["ClientID"]))
                _clientID = Request.QueryString["ClientID"].ToString();
            string param = "PresentationID=" + PresentationID.ToString() + "&ClientID=" + _clientID.ToString();
            btnBack.Attributes["href"] = "ProjectInside.aspx?" + param;

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
            //frmEntry.Attributes["src"] = "View_DirectorsTreatment.aspx?DTID=" + index.ToString() + "&PresentationID=" + PresentationID.ToString();

        }


        if (e.CommandName == "edt")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

            Panel2.Visible = true;
            Panel1.Visible = false;
            //frmEntry.Attributes["src"] = "EditDirectorsTreatmentPanel.aspx?DTID=" + index.ToString() + "&PresentationID=" + PresentationID.ToString();

            //Response.Redirect("Edit_DirectorsTreatment.aspx?DTID=" + index.ToString() + "&PresentationID=" + PresentationID.ToString());

            HiddenField1.Value = index.ToString();
            this.loadDirectorsTreatment();

            lblErrorAdd.Text = "";

            btnUpdateDT.Visible = true;
            BtnSave.Visible = false;

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
            Repeater1.DataBind();


        }
    }
    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Panel2.Visible = false;
        Panel1.Visible = true;

         gvTreatment.DataBind();

         btnUpdateDT.Visible = false;
         BtnSave.Visible = true;
         Repeater1.DataBind();

    }
    protected void BtnCancelVideo_Click(object sender, System.EventArgs e)
    {
        pnlVideoEdit.Visible = false;
    }
    protected void BtnAddNew_Click(object sender, EventArgs e)
    {



        if (string.IsNullOrEmpty(Request.QueryString["PresentationID"]))
            return;

       // frmEntry.Attributes["src"] = "Create_DirectorsTreatment.aspx?PresentationID=" + Request.QueryString["PresentationID"].ToString();
        Panel2.Visible = true;
        Panel1.Visible = false;
    }
   
    protected void gvVideos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            ImageButton button = (ImageButton)e.CommandSource;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            gvVideos.SelectedIndex = row.RowIndex;
            
          
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

            string file = Server.MapPath("~/" + gvVideos.SelectedDataKey.Values[1].ToString());
            File.Delete(file);
            gvVideos.DataBind();

            
        }

        if (e.CommandName == "edt")
        {

            int rowindex = Convert.ToInt32(e.CommandArgument.ToString());
            gvVideos.SelectedIndex = rowindex;

            pnlVideoEdit.Visible = true;
            pnlVideoGrid.Visible = false;
            Panel2.Visible = false;
            Panel1.Visible = false;
       
            pnlVideoGrid.Visible = true;
            pnlVideoEntry.Visible = false;

            txtEditRank.Text = gvVideos.SelectedDataKey.Values["Rank"].ToString();
            txtEditTitle.Text = gvVideos.SelectedDataKey.Values["Title"].ToString();

        }
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
            CompanyID = Session["CompanyID"].ToString();

            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

         


            // Display the company name in italics.
            Image img = (Image)e.Row.FindControl("img");
            DataRowView rowView = (DataRowView)e.Row.DataItem;
            string value = rowView["ImageFile"].ToString();
            img.ImageUrl = CompanyID + "/" + PresentationID.ToString() + "/repository/" + value;
            img.AlternateText = CompanyID + "/" + PresentationID.ToString() + "/repository/" + value;

        }

    }


    protected void BtnSave_Click(object sender, System.EventArgs e)
    {



        if (txtRank.Text == string.Empty)
            txtRank.Text = (gvTreatment.Rows.Count + 1).ToString();

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

            DataTable dt = clsdirectorsTreatment.getDirectorsTreatmentByPresentation(PresentationID);
            string li = "<li> <img src='repository/{0}'  alt='slide {1}'  width='100%' style='height: 667px !important;' /><div class='orbit-caption' style='bottom: 0px !important;'> <p>{2}<br>{3}<br></p></div> </li>";
          
           

           // string lisummary = " <li>  <p>{0}</p><div class='imgContainer'> <img src='repository/{1}' width='150' height='90' alt=''></div></li>";

            string lisummary = "<li>  <p>{0}</p>   <div class='imgContainer'>   <img src='repository/{1}' width='150' height='90' alt=''>  </div>    </li>";



            string content = "";
            string summarylist = "";
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                content += string.Format(li, row["ImageFile"].ToString(), i, row["VoiceOver"].ToString(), row["Description"].ToString());
                summarylist += string.Format(lisummary, i, row["ImageFile"].ToString());

                i++;
            }

            generate(content, summarylist);

            lblErrorAdd.Text = "Successfully added.";
        }
        else
        {
            lblErrorAdd.Text = "Please choose file to upload";
        }





    }


    #region "Carousel"

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string value = ((HiddenField)e.Item.FindControl("hdnImagePath")).Value;
            Image img = ((Image)e.Item.FindControl("imgSlide"));
            img.ImageUrl = CompanyID + "/" + PresentationID.ToString() + "/repository/" + value;
            img.AlternateText = CompanyID + "/" + PresentationID.ToString() + "/repository/" + value;
        }

    }

    #endregion


    #region "Edit"

    private void loadDirectorsTreatment()
    {
        
        DirectorsTreatment myDirectorsTreatment;
        myDirectorsTreatment = clsdirectorsTreatment.getDirectorsTreatment(Convert.ToInt32(HiddenField1.Value));
        HiddenField1.Value = myDirectorsTreatment.DTID.ToString();
        lblFile.Text = myDirectorsTreatment.ImageFile.ToString();
        //txtImagePath.Text = myDirectorsTreatment.ImagePath.ToString();
        txtVoiceOver.Text = myDirectorsTreatment.VoiceOver.ToString();
        txtDescription.Text = myDirectorsTreatment.Description.ToString();
        txtRank.Text = myDirectorsTreatment.Rank.ToString();

    }

    protected void BtnUpdate_Click(object sender, System.EventArgs e)
    {

        if (txtRank.Text == string.Empty)
            txtRank.Text = (gvTreatment.Rows.Count + 1).ToString();

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
                cmd.CommandText = "sp_UpdateDirectorsTreatmentFile";
                cmd.Parameters.Add("@ImageFile", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
                cmd.Parameters.Add("@ImagePath", SqlDbType.VarChar).Value = System.Convert.ToString(URL + FileName);
                cmd.Parameters.Add("@DTID", SqlDbType.Int).Value = Convert.ToInt32(HiddenField1.Value);





                cmd.ExecuteNonQuery();
            }
            c.Close();

            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));



            txtVoiceOver.Text = "";
            txtDescription.Text = "";
            txtRank.Text = "";
            

            //Generate Page

            DataTable dt = clsdirectorsTreatment.getDirectorsTreatmentByPresentation(PresentationID);
            string li = "<li> <img src='repository/{0}'  alt='slide {1}'  width='100%'  style='height: 667px !important;'  /><div class='orbit-caption' style='bottom: 0px !important;'> <p>{2}<br>{3}<br></p></div> </li>";

            string lisummary = "<li>  <p>{0}</p>   <div class='imgContainer'>   <img src='repository/{1}' width='150' height='90' alt=''>  </div>    </li>";



            string content = "";
            string summarylist = "";
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                content += string.Format(li, row["ImageFile"].ToString(), i, row["VoiceOver"].ToString(), row["Description"].ToString());
                summarylist += string.Format(lisummary, i, row["ImageFile"].ToString());

                i++;
            }

            generate(content, summarylist);

            lblErrorAdd.Text = "Successfully added.";
        }
        else
        {
            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UpdateDirectorsTreatment";

                cmd.Parameters.Add("@DTID", SqlDbType.Int).Value = Convert.ToInt32(HiddenField1.Value);

                cmd.Parameters.Add("@VoiceOver", SqlDbType.VarChar).Value = System.Convert.ToString(txtVoiceOver.Text);
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = System.Convert.ToString(txtDescription.Text);
                cmd.Parameters.Add("@Rank", SqlDbType.Int).Value = System.Convert.ToInt32(txtRank.Text);
                cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
                cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);
       



                cmd.ExecuteNonQuery();
            }
            c.Close();
        }

        Panel2.Visible = false;
        Panel1.Visible = true;

        gvTreatment.DataBind();

        btnUpdateDT.Visible = false;
        BtnSave.Visible = true;
        Repeater1.DataBind();

    }

    #endregion

    #region "Videos"
     protected void btnVideos_Click(object sender, EventArgs e)
    {
        
            Panel2.Visible = false;
            Panel1.Visible = false;
            pnlVideos.Visible = true;
            pnlVideoGrid.Visible = true;
            pnlVideoEntry.Visible = false;
            gvVideos.DataBind();

       
    }

     protected void btnAddVideos_Click(object sender, EventArgs e)
     {
         Panel2.Visible = false;
         Panel1.Visible = false;
         pnlVideos.Visible = true;
         pnlVideoGrid.Visible = false;
         pnlVideoEntry.Visible = true;
     }

     protected void BtnSaveVideo_Click(object sender, EventArgs e)
     {

         if (Request.QueryString["PresentationID"] == null)
             return;

         if (Session["Username"] == null)
             return;
         string _presentationID = Request.QueryString["PresentationID"].ToString();

         DirectorTreatmentVideo _video = new DirectorTreatmentVideo();


         string strFileNameWithPath = FileUpload1.PostedFile.FileName;
         string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
         string FileName = "";

         if (FileUpload1.HasFile)
         {
             //if (strExtensionName.Equals(".mp4"))
             //{

             try
             {

                 FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

                 FileInfo fi = new FileInfo(FileName);
                 string ext = fi.Extension;
                 FileName = Guid.NewGuid().ToString() + ext;



                 string pathToCreate1 = "~/" + Session["CompanyID"] + "/" + _presentationID + "/repository";
                 string strFile = "";
                 strFile = System.Web.Hosting.HostingEnvironment.MapPath(pathToCreate1 + "/" + FileName);
                 Directory.CreateDirectory(Server.MapPath(pathToCreate1));
                 FileUpload1.SaveAs(strFile);
               

             }
             catch (Exception ex)
             {
                 lblError.Text = ex.Message;
             }

         }
         else
         {
             lblError.Text = "Please choose a file to upload.";

             return;
         }
     
         
         _presentationID = Request.QueryString["PresentationID"].ToString();
         _video.PresentationID = Convert.ToInt32(_presentationID);
         _video.CreatedBy = Session["Username"].ToString();
         _video.Path = Session["CompanyID"] + "/" + _presentationID + "/repository/" + FileName;
         _video.Rank = Convert.ToInt32(TextBox1.Text);
         _video.Title = txtTitle.Text;
         _video.Filename = FileName;



         if (_video.Insert() == true)
         {

             gvVideos.DataBind();


             Panel2.Visible = false;
             Panel1.Visible = false;
             pnlVideos.Visible = true;
             pnlVideoGrid.Visible = true;
             pnlVideoEntry.Visible = false;

         }
         else
             lblError.Text = "Error while saving.";



     }
     protected void BtnUpdateVideo_Click(object sender, EventArgs e)
     {
         if (Request.QueryString["PresentationID"] == null)
             return;

         if (Session["Username"] == null)
             return;

         lblEditError.Text = "";

         string _presentationID = Request.QueryString["PresentationID"].ToString();
         DirectorTreatmentVideo _video = new DirectorTreatmentVideo();

         _video.ID = Convert.ToInt32(gvVideos.SelectedDataKey.Values[0].ToString());
         //string strFileNameWithPath = FileUpload2.PostedFile.FileName;
         //string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
         //string FileName = "";

         //if (FileUpload2.HasFile)
         //{


         //    FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);

         //    FileInfo fi = new FileInfo(FileName);
         //    string ext = fi.Extension;
         //    FileName = Guid.NewGuid().ToString() + ext;

         //    string pathToCreate1 = "~/" + FileName;
         //    string strFile = "";
         //    strFile = System.Web.Hosting.HostingEnvironment.MapPath(pathToCreate1 + "/" + FileName);


         //    //lblEditError.Text = strFile;

         //    //return;

         //    Directory.CreateDirectory(Server.MapPath(pathToCreate1));
         //    FileUpload1.SaveAs(strFile);



             //_video.PresentationID = Convert.ToInt32(_presentationID);
             //_video.ModifiedBy = Session["Username"].ToString();
             //_video.Path = Session["CompanyID"] + "/" + _presentationID + "/repository/" + FileName;
             //_video.Rank = Convert.ToInt32(txtEditRank.Text);
             //_video.Title = txtEditTitle.Text;


         //    if (_video.Update() == true)
         //    {
         //        pnlVideoGrid.Visible = true;
         //        pnlVideoEdit.Visible = false;
         //        gvVideos.DataBind();

         //    }
         //    else
         //        lblEditError.Text = "Error while saving.";



         //}
         //else
         //{

             _video.PresentationID = Convert.ToInt32(_presentationID);
             _video.ModifiedBy = Session["Username"].ToString();
             _video.Rank = Convert.ToInt32(txtEditRank.Text);
             _video.Title = txtEditTitle.Text;


             //  lblEditError.Text = "PresentationID " + _video.PresentationID + " Title " + _video.Title + " _video " + _video;
             if (_video.UpdateWithoutVideo() == true)
             {
                 pnlVideoGrid.Visible = true;
                 pnlVideoEdit.Visible = false;
                 gvVideos.DataBind();
             }
             else
                 lblEditError.Text = "Error while saving.";


         //    return;
         //}

     }

     protected void btnVideoSaveCancel_Click(object sender, EventArgs e)
     {
         pnlVideoGrid.Visible = true;
         pnlVideoEntry.Visible = false; 
     }


    #endregion

     #region "Passcode"
     protected void btnPasscode_Click(object sender, EventArgs e)
     {

         Panel2.Visible = false;
         Panel1.Visible = false;
         pnlPasscode.Visible = true;

         DirectorsTreatmentPasscode _passcode = new DirectorsTreatmentPasscode();
         _passcode.PresentationID = Request.QueryString["PresentationID"].ToString();



         if (_passcode.Get() == String.Empty)
             generateNew();
         else
             txtPasscode.Text = _passcode.Get();

     }

     protected void btnGenerate_Click(object sender, EventArgs e)
     {
         generateNew();

     }
     private void generateNew()
     {
         txtPasscode.Text = Membership.GeneratePassword(4, 0);
         DirectorsTreatmentPasscode _passcode = new DirectorsTreatmentPasscode();
         _passcode.PresentationID = Request.QueryString["PresentationID"].ToString();
         _passcode.Passcode = txtPasscode.Text;
         _passcode.Update();
     }
     protected void btnBackPasscode_Click(object sender, EventArgs e)
     {

      
         Panel1.Visible = true;
         pnlPasscode.Visible = false;
     }
     protected void btnVideoAddNew_Click(object sender, EventArgs e)
     {

      
         pnlVideoGrid.Visible = false;
         pnlVideoEntry.Visible = true;
     }

    
     #endregion

    #region "Generate HTML"
     protected void generate(string template, string summarylist)
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
 
                 sw.Write(string.Format(@"<!DOCTYPE HTML><html>" +
                                       "<head> <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'> <meta name='viewport' content='width=device-width, initial-scale=1.0'>" +
                                       "<title>PPM DECK - Director's Treatment</title><link rel='stylesheet' href='css/foundation.css' /><link rel='stylesheet' href='css/style-ipad.css'/> " +
                                     "<link rel='stylesheet' href='css/normalize.css' /><link rel='stylesheet' href='js/vendor/cl_editor/jquery.cleditor.css' /> " +
                                   "<link rel='stylesheet' href='css/touchcarousel.css' /> " +
                                  "<link rel='stylesheet' href='css/minimal-light-skin.css'/> " +
                                  "<script src='js/vendor/modernizr.js'></script></head>" +
                                  "<body> " +
                         "  <div id='canvas-wrap'> " +
    " <div id='content-container-ipad'> " +
         "  <div class='slider-container'> " +
              " <ul class='example-orbit swipe-next' data-options='animation:slide; pause_on_hover:false; animation_speed:500; navigation_arrows:true;bullets:true;'  data-orbit>  " +
              "{0}   <li> <div class='dt_summ'>    <ul class='dt_list'>   {1}" +
             "            </ul>  </div> </li>  </ul>  </div>   </div>   </div> "+
           
               "<script src='js/vendor/jquery.js'></script><script type='text/javascript' src='js/main.js'> </script> " +
                         "<script src='js/foundation.min.js'></script><script> " +
                                   " $(document).foundation();  </script></body></html>", template, summarylist));



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