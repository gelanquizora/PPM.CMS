﻿using System;
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

public partial class Soundtrack : System.Web.UI.Page
{
    private string Contents = ConfigurationManager.AppSettings["Contents"].ToString();

    private string repository = ConfigurationManager.AppSettings["repository"].ToString();
    private string URL = ConfigurationManager.AppSettings["URL"].ToString();
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    int PresentationID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            SetDefaultView();
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        }

        ////for Attendee
        //DataView dvSql = (DataView)dsSound.Select(DataSourceSelectArguments.Empty);
        //foreach (DataRowView drvSql in dvSql)
        //{

        //    int sID = Convert.ToInt32(drvSql["SoundID"].ToString());
        //    if ((sID == 0))
        //    {
        //        MultiView1.ActiveViewIndex = 0;

              
                
        //    }
        //    else
        //    {

        //        MultiView1.ActiveViewIndex = 1;



        //        HiddenFieldSoundID.Value = Convert.ToInt32(sID).ToString();

             

        //        loadSound(Convert.ToInt32(HiddenFieldSoundID.Value));
        //    }

        //}


    }
    //protected void BtnCancel_Click(object sender, System.EventArgs e)
    //{
    //    Response.Redirect("PresentationMaster.aspx", false);
    //}



    protected void BtnSaveSound_Click(object sender, System.EventArgs e)
    {


        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        string strFileNameWithPath = FileUpload1.PostedFile.FileName;

        string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
        if (FileUpload1.HasFile)
        {
            //if (strExtensionName.Equals(".mp4"))
            //{

            //string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

            //

            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

            string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);


            FileInfo   fi = new FileInfo(FileName);
            string ext = fi.Extension;
            FileName = Guid.NewGuid().ToString() + ext;

            string pathToCreate1 = "~/" + Session["CompanyID"] + "/" + PresentationID + "/SoundTrackFile";
            string strFile = "";
            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/SoundTrackFile/" + FileName);
            Directory.CreateDirectory(Server.MapPath(pathToCreate1));
            FileUpload1.SaveAs(strFile);


            string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;
            Directory.CreateDirectory(Server.MapPath(pathToCreate));
            string fileLoc = Server.MapPath(pathToCreate) + "/" + "st01.html";

            string ImgFile = "<img src='SoundTrackFile/" + FileName + "' alt=''>";
            FileUpload1.SaveAs(repository + FileName);



            FileStream fs = null;
            if (!File.Exists(fileLoc))
            {
                using (fs = File.Create(fileLoc))
                {

                }
            }



          



            //if (File.Exists(fileLoc))
            //{
            //    using (StreamWriter sw = new StreamWriter(fileLoc))
            //    {
            //        sw.Flush();
            //        sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Director's Treatment Summary</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'><script src='js/jquery-latest.min.js'></script><link rel='stylesheet' href='css/orangebox.css' type='text/css' /></head><body><div id='wrapper'><div id='dt_summ'>{0}</div></div></body></html>", ImgFile));
            //    }
            //}






            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_InsertSound";
                cmd.Parameters.Add("@SoundFile", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
                cmd.Parameters.Add("@SoundPath", SqlDbType.VarChar).Value = System.Convert.ToString(URL + FileName);
                cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = Convert.ToInt32(PresentationID);
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
                cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);

                cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
                cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);


                cmd.ExecuteNonQuery();
            }
            c.Close();


            MultiView1.ActiveViewIndex = 0;
            gvSoundtrack.DataBind();

            //}
            //else
            //{
            //    lblErrorAdd.Text = "cannot accept this file type";
            //}

        //    Response.Redirect("PresentationMaster.aspx", false);
            //loop through mp3s
            string list = "";
            for (int i = 0; i < gvSoundtrack.Rows.Count; i++)
            {

                string soundfile = gvSoundtrack.DataKeys[i][1].ToString();


            list += " <li> " ;
              list += "  <span class='title'><audio id='player2' src=" + "SoundTrackFile/" + soundfile + "' type='audio/mp3' controls='controls'></audio></span>";
                 list +=  "<img src='images/3.png' />   </li> " ;
            
            }

            //generate
            if (gvSoundtrack.Rows.Count > 0)
            {
                generate(list);
            }

        }
        else
        {
            lblErrorAdd.Text = "Please choose audio file to upload";
        }
    }

    private void SetDefaultView()
    {
        MultiView1.ActiveViewIndex = 0;
    }
    private void loadSound(int SoundID)
    {
        Sound mySound;
        mySound = clssound.getSound(SoundID);
        HiddenFieldSoundID.Value = mySound.SoundID.ToString();



        lblFileView.Text = mySound.SoundFile.ToString();


        if (String.IsNullOrEmpty(mySound.SoundFile.ToString()))
        {
            Image1.ImageUrl = "";
            lblFileView.Text = "";
        }
        else
        {
            Image1.ImageUrl = Contents + mySound.SoundFile.ToString();
        }

    }


    private void EditSound(int SoundID)
    {






        Sound mySound;
        mySound = clssound.getSound(SoundID);

        HiddenFieldSoundID.Value = mySound.SoundID.ToString();
        lblFileEdit.Text = mySound.SoundFile.ToString();


    }



    protected void BtnUpdateEdit_Click(object sender, System.EventArgs e)
    {







      //  Response.Redirect("PresentationMaster.aspx", false);
    }
    //protected void BtnCancelEdit_Click(object sender, System.EventArgs e)
    //{
    //    Response.Redirect("PresentationMaster.aspx", false);
    //}

    //protected void btnCancelEditSound_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("PresentationMaster.aspx", false);
    //}




    protected void BtnUpdateSound_Click(object sender, EventArgs e)
    {
        string strFileNameWithPath = FileUpload2.PostedFile.FileName;

        string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
        if (FileUpload2.HasFile)
        {
            //if (strExtensionName.Equals(".mp4"))
            //{

            //string FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);




            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

            string FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);

            FileInfo fi = new FileInfo(FileName);
            string ext = fi.Extension;
            FileName = Guid.NewGuid().ToString() + ext;


            string pathToCreate1 = "~/" + Session["CompanyID"] + "/" + PresentationID + "/SoundTrackFile";
            string strFile = "";
            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/SoundTrackFile/" + FileName);
            Directory.CreateDirectory(Server.MapPath(pathToCreate1));
            FileUpload2.SaveAs(strFile);


            string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;
            Directory.CreateDirectory(Server.MapPath(pathToCreate));
            string fileLoc = Server.MapPath(pathToCreate) + "/" + "st01.html";

            string ImgFile = "<img src='SoundTrackFile/" + FileName + "' alt=''>";

            FileUpload2.SaveAs(repository + FileName);


            System.IO.File.Delete(fileLoc);

            FileStream fs = null;
            if (!File.Exists(fileLoc))
            {
                using (fs = File.Create(fileLoc))
                {

                }
            }

            MultiView1.ActiveViewIndex = 0;
            gvSoundtrack.DataBind();

            //loop through mp3s
            string list = "";
            for (int i = 0; i < gvSoundtrack.Rows.Count; i++)
            {

                string soundfile = gvSoundtrack.DataKeys[i][1].ToString();


                list += "<li><div align='center'> ";
                list += "<a href='#' id='aud2' class='lnkAudio' ><img src='images/audio.png' alt='images/audio.png'/></a></div> ";
                list += "<div id='divaud2' class='divAudio'><audio controls><source src='" + "SoundTrackFile/" + soundfile + "' type='audio/mpeg'> Your browser does not support the audio element.</audio></div></li>";
            }






            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UpdateSound";
                cmd.Parameters.Add("@SoundFile", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
                cmd.Parameters.Add("@SoundPath", SqlDbType.VarChar).Value = System.Convert.ToString(URL + FileName);
                cmd.Parameters.Add("@SoundID", SqlDbType.Int).Value = Convert.ToInt32(HiddenFieldSoundID.Value);
                cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
                cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);


                cmd.ExecuteNonQuery();
            }
            c.Close();




          //  Response.Redirect("PresentationMaster.aspx", false);

            //}
            //else
            //{
            //    lblErrorAdd.Text = "cannot accept this file type";
            //}

            //generate
            if (gvSoundtrack.Rows.Count > 0)
            {
                generate(list);
            }
        }
        else
        {
            lblErrorAdd.Text = "Please choose audio file to upload";
        }
    }
    protected void btnEditSound_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        EditSound(Convert.ToInt32(HiddenFieldSoundID.Value));
        
    }


    protected void gvSoundtrack_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {

            int index = Convert.ToInt32(e.CommandArgument);
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
         }


        if (e.CommandName == "edt")
        {

            int index = Convert.ToInt32(e.CommandArgument);
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

            HiddenFieldSoundID.Value = index.ToString();

            MultiView1.ActiveViewIndex = 3;



        }


        if (e.CommandName == "del")
        {

            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DeleteSoundtrack";
                cmd.Parameters.Add("@SoundID", SqlDbType.Int).Value = Convert.ToInt32(e.CommandArgument);
                cmd.ExecuteNonQuery();

            }
            c.Close();

            gvSoundtrack.DataBind();


        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
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




        string fileLoc = Server.MapPath(pathToCreate) + "/" + "st01.html";
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
                                        "<link rel='stylesheet' href='css/foundation.css' /> <link rel='stylesheet' href='css/style-ipad.css' />" +
                                        "<link rel='stylesheet' href='css/normalize.css' /><link rel='stylesheet' href='css/jquery-ui-1.7.2.custom.css' type='text/css' media='all' />" +
                                        "</head>" + 
                                       " <body>" +
                                       "<div id='canvas-wrap'> " +
                                      "  <div id='content-container-ipad'> " +
            "<div class='slider-container'>  " +
             "   <div class='medium-12 columns'> " +
                   " <div class='cover-flip'> " +
                        "<div id='wrapper'>" +
                                 "<div id='flip'><ul>{0}</ul></div>"+
                                "  <div id='scrollbar'></div> " +
                                "</div>  " +
                 " </div> </div>  <br style='clear:both'>  </div>    </div>    </div> " +
                              
      "<script src='js/jquery-1.js' type='text/javascript'></script> " +
	                                    "<script type='text/javascript'src='js/jquery-ui-1.js'></script> " +
                                        "<script type='text/javascript' src='js/cover.flip.js'></script> " +
	                                    "<script type='text/javascript' src='js/jquery.coverflip.js'></script></body>" + 
                                        "</html>", template));







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