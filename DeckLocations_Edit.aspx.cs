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

public partial class DeckLocations_Edit : System.Web.UI.Page
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

            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

            //string temp = "";

            //for (int i = 0; i < gvLocation.Rows.Count; i++)
            //{
            //    Label lbl = gvLocation.Rows[i].FindControl("lblTemplate") as Label;
            //    temp += lbl.Text;

            //}

            //if (gvLocation.Rows.Count != 0)
            //{
            //    generate(temp);
            //}

 
            string _clientID = "" ;
            if (!string.IsNullOrEmpty(Request.QueryString["ClientID"]))
                 _clientID = Request.QueryString["ClientID"].ToString();



          
            string param = "PresentationID=" + PresentationID.ToString() + "&ClientID=" + _clientID;
            btnBack.Attributes["href"] = "DeckLocations.aspx?" + param;
        }

        if (ddlTemplate.SelectedItem.Text != "-Select-")
        {
            int t = 0;


            t = Convert.ToInt32(ddlTemplate.SelectedItem.Text);


            switch (t)
            {
                case 1:
                case 4:
                case 5:
                case 12:
                case 14:
                    {
                        pnlImg1.Visible = true;
                        pnlImg2.Visible = false;
                        pnlImg3.Visible = false;
                        break;
                    }


                case 2:
                case 3:
                case 6:
                case 10:
                case 11:
                case 13:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                    {

                        pnlImg1.Visible = true;
                        pnlImg2.Visible = true;
                        pnlImg3.Visible = false;
                        break;
                    }



                case 7:
                case 8:
                case 9:
                case 16:
                    {
                        pnlImg1.Visible = true;
                        pnlImg2.Visible = true;
                        pnlImg3.Visible = true;
                        break;
                    }


            }
        }

        else
        {

            pnlImg1.Visible = true;
            pnlImg2.Visible = false;
            pnlImg3.Visible = false;

            pnlTitle.Visible = true;
            pnlTitle2.Visible = false;
        }
    }




    protected void gvLocation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {

            int index = Convert.ToInt32(e.CommandArgument);
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
            Response.Redirect("View_Location.aspx?LocationID=" + index.ToString() + "&PresentationID=" + PresentationID.ToString());
        }


        if (e.CommandName == "edt")
        {






            int index = Convert.ToInt32(e.CommandArgument);
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
            string _clientID = "0";
            _clientID = Request.QueryString["ClientID"].ToString();
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
            Response.Redirect("DeckLocations_Editgv.aspx?ClientID=" + _clientID.ToString() + "&LocationID=" + index.ToString() + "&PresentationID=" + PresentationID.ToString());


        }


        if (e.CommandName == "del")
        {

            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DeleteLocation";
                cmd.Parameters.Add("@LocationID", SqlDbType.Int).Value = Convert.ToInt32(e.CommandArgument);
                cmd.ExecuteNonQuery();

            }
            c.Close();

            gvLocation.DataBind();

            string temp = "";

            for (int i = 0; i < gvLocation.Rows.Count; i++)
            {
                Label lbl = gvLocation.Rows[i].FindControl("lblTemplate") as Label;
                temp += lbl.Text;

            }

            generate(temp);
            

        }
    }

    protected void createNew_Click(object sender, EventArgs e)
    {

        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        Panel1.Visible = false;
        Panel2.Visible = true;


    }

    protected void btnBackPreview_Click(object sender, EventArgs e)
    {
        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
      string  _clientID = Request.QueryString["ClientID"].ToString();

        Response.Redirect("DeckLocations.aspx?ClientID=" + _clientID + "&PresentationID=" + PresentationID.ToString());
    }

    protected void generate(string template)
    {



        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
        string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;
        Directory.CreateDirectory(Server.MapPath(pathToCreate));
        string fileLoc = Server.MapPath(pathToCreate) + "/" + "ln01.html";
         
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
 "<title>Production Design</title><link href='prodstyle.css' rel='stylesheet' type='text/css' media='screen'><link rel='stylesheet' href='css/touchcarousel.css' />" +
 "<link rel='stylesheet' href='css/prod-light-skin.css'/><script src='js/jquery.min.js'></script>" +
"<script src='js/jquery.touchcarousel-1.1.js'></script><style type='text/css'></style></head>" +
"<body><div id='wrapper'><div id='carousel-single-image' class='touchcarousel   minimal-light'> " +
"<ul class='touchcarousel-container'>{0}</ul></div></div>{1}</body></html>", template, js));







            }
        }
    }


    #region "Add New Item"
    //protected void BtnSave_Click(object sender, System.EventArgs e)
    //{




    //    if (Page.IsValid)
    //    {
    //        bool valid = false;
    //        string ImgFile1 = "";
    //        string ImgFile2 = "";
    //        string ImgFile3 = "";
    //        int t = 0;
    //        string template = "";



    //        t = Convert.ToInt32(ddlTemplate.SelectedItem.Text);


    //        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

    //        string FileName, FileName2, FileName3 = "";
    //        string pathToCreate1 = "~/" + Session["CompanyID"] + "/" + PresentationID + "/repository";
    //        Directory.CreateDirectory(Server.MapPath(pathToCreate1));
    //        string strFile, strFile2, strFile3 = "";

    //        string title, title2 = "";

    //        string rep = Session["CompanyID"] + "/" + PresentationID + "/repository/";


    //        switch (t)
    //        {
    //            case 1:
    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                title = txtTitle1.Text;
    //                ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
    //                template = T1("<img src='repository/" + FileName + "' alt=''>", title);
    //                //template = T1("<img src='" + rep + FileName + "' alt=''>", title);


    //                if (FileUpload2.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);


    //                    FileUpload2.SaveAs(strFile);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;
    //            case 2:
    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);

    //                ImgFile1 = "<img src='repository/" + FileName + "' width='600' height='475' alt=''>";
    //                ImgFile2 = "<img src='repository/" + FileName2 + "'  alt=''>";

    //                title = txtTitle1.Text;
    //                title2 = txtTitle2.Text;
    //                template = T2(ImgFile1, ImgFile2, title, title2);


    //                ImgFile1 = "<img src='" + rep + FileName + "' width='600' height='475' alt=''>";
    //                ImgFile2 = "<img src='" + rep + FileName2 + "'  alt=''>";





    //                if (FileUpload2.HasFile && FileUpload22.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);

    //                    strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
    //                    FileUpload22.SaveAs(strFile2);

    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";

    //                    valid = false;
    //                }

    //                break;
    //            case 3:


    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);

    //                ImgFile1 = "<img src='repository/" + FileName + "' width='733' height='450' alt=''>";
    //                ImgFile2 = "<img src='repository/" + FileName2 + "' width='250' height='150'  alt=''>";

    //                title = txtTitle1.Text;
    //                template = T3(ImgFile1, ImgFile2, title);


    //                ImgFile1 = "<img src='" + rep + FileName + "' width='733' height='450' alt=''>";
    //                ImgFile2 = "<img src='" + rep + FileName2 + "' width='250' height='150'  alt=''>";


    //                if (FileUpload2.HasFile && FileUpload22.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);

    //                    strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
    //                    FileUpload22.SaveAs(strFile2);

    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;


    //            case 4:

    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                ImgFile1 = "<img src='repository/" + FileName + "' width='733' height='550' alt=''>";
    //                title = txtTitle1.Text;

    //                template = T4(ImgFile1, title);
    //                ImgFile1 = "<img src='" + rep + FileName + "' width='733' height='550' alt=''>";


    //                if (FileUpload2.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;


    //            case 5:
    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                ImgFile1 = "<img src='repository/" + FileName + "' width='900' height='550' alt=''>";

    //                template = T5(ImgFile1);
    //                ImgFile1 = "<img src='" + rep + FileName + "' width='900' height='550' alt=''>";



    //                if (FileUpload2.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;
    //            case 6:


    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);

    //                ImgFile1 = "<img src='repository/" + FileName + "' width='350' height='350' alt=''>";
    //                ImgFile2 = "<img src='repository/" + FileName2 + "' width='600' height='550' alt=''>";
    //                template = T6(ImgFile1, ImgFile2);

    //                ImgFile1 = "<img src='" + rep + FileName + "' width='350' height='350' alt=''>";
    //                ImgFile2 = "<img src='" + rep + FileName2 + "' width='600' height='550' alt=''>";


    //                if (FileUpload2.HasFile && FileUpload22.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);

    //                    strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
    //                    FileUpload22.SaveAs(strFile2);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;
    //            case 7:




    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
    //                FileName3 = Path.GetFileName(FileUpload23.PostedFile.FileName);

    //                ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='repository/" + FileName2 + "' alt=''>";
    //                ImgFile3 = "<img src='repository/" + FileName3 + "' alt=''>";

    //                title = txtTitle1.Text;

    //                template = T7(ImgFile1, ImgFile2, ImgFile3, title);


    //                ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";
    //                ImgFile3 = "<img src='" + rep + FileName3 + "' alt=''>";



    //                if (FileUpload2.HasFile && FileUpload22.HasFile && FileUpload23.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);

    //                    strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
    //                    FileUpload22.SaveAs(strFile2);

    //                    strFile3 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName3);
    //                    FileUpload23.SaveAs(strFile3);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;
    //            case 8:


    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
    //                FileName3 = Path.GetFileName(FileUpload23.PostedFile.FileName);

    //                ImgFile1 = "<img src='repository/" + FileName + "' width='320' height='550' alt=''>";
    //                ImgFile2 = "<img src='repository/" + FileName + "' width='320' height='550' alt=''>";
    //                ImgFile3 = "<img src='repository/" + FileName + "' width='320' height='550' alt=''>";
    //                template = T8(ImgFile1, ImgFile2, ImgFile3);

    //                ImgFile1 = "<img src='" + rep + FileName + "' width='320' height='550' alt=''>";
    //                ImgFile2 = "<img src='" + rep + FileName2 + "' width='320' height='550' alt=''>";
    //                ImgFile3 = "<img src='" + rep + FileName3 + "' width='320' height='550' alt=''>";


    //                if (FileUpload2.HasFile && FileUpload22.HasFile && FileUpload23.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);

    //                    strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
    //                    FileUpload22.SaveAs(strFile2);

    //                    strFile3 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName3);
    //                    FileUpload23.SaveAs(strFile3);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;
    //            case 9:



    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
    //                FileName3 = Path.GetFileName(FileUpload23.PostedFile.FileName);

    //                ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='repository/" + FileName + "' alt=''>";
    //                ImgFile3 = "<img src='repository/" + FileName + "' alt=''>";
    //                template = T9(ImgFile1, ImgFile2, ImgFile3);

    //                ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";
    //                ImgFile3 = "<img src='" + rep + FileName3 + "' alt=''>";

    //                if (FileUpload2.HasFile && FileUpload22.HasFile && FileUpload23.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);

    //                    strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
    //                    FileUpload22.SaveAs(strFile2);

    //                    strFile3 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName3);
    //                    FileUpload23.SaveAs(strFile3);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;
    //            case 10:


    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);

    //                ImgFile1 = "<img src='repository/" + FileName + "' width='480' height='550' alt=''>";
    //                ImgFile2 = "<img src='repository/" + FileName + "' width='480' height='550' alt=''>";

    //                title = txtTitle1.Text;

    //                template = T10(ImgFile1, ImgFile2, title);
    //                ImgFile1 = "<img src='" + rep + FileName + "' width='480' height='550' alt=''>";
    //                ImgFile2 = "<img src='" + rep + FileName2 + "' width='480' height='550' alt=''>";



    //                if (FileUpload2.HasFile && FileUpload22.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);

    //                    strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
    //                    FileUpload22.SaveAs(strFile2);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;
    //            case 11:



    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);

    //                ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='repository/" + FileName + "' alt=''>";

    //                title = txtTitle1.Text;

    //                template = T11(ImgFile1, ImgFile2, title);
    //                ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";




    //                if (FileUpload2.HasFile && FileUpload22.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);

    //                    strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
    //                    FileUpload22.SaveAs(strFile2);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;
    //            case 12:




    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";

    //                title = txtTitle1.Text;

    //                template = T12(ImgFile1, title);
    //                ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";


    //                if (FileUpload2.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;
    //            case 13:



    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
    //                FileName3 = Path.GetFileName(FileUpload23.PostedFile.FileName);

    //                ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='repository/" + FileName2 + "' alt=''>";
    //                ImgFile3 = "<img src='repository/" + FileName3 + "' alt=''>";
    //                template = T13(ImgFile1, ImgFile2, ImgFile3);

    //                ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";
    //                ImgFile3 = "<img src='" + rep + FileName3 + "' alt=''>";



    //                if (FileUpload2.HasFile && FileUpload22.HasFile && FileUpload23.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);

    //                    strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
    //                    FileUpload22.SaveAs(strFile2);

    //                    strFile3 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName3);
    //                    FileUpload23.SaveAs(strFile3);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;
    //            case 14:



    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";

    //                title = txtTitle1.Text;

    //                template = T12(ImgFile1, title);
    //                ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";


    //                if (FileUpload2.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;
    //            case 15:


    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";

    //                title = txtTitle1.Text;

    //                template = T12(ImgFile1, title);
    //                ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";


    //                if (FileUpload2.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;
    //            case 16:


    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
    //                FileName3 = Path.GetFileName(FileUpload23.PostedFile.FileName);

    //                ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='repository/" + FileName2 + "' alt=''>";
    //                ImgFile3 = "<img src='repository/" + FileName3 + "' alt=''>";

    //                title = txtTitle1.Text;

    //                template = T16(ImgFile1, ImgFile2, ImgFile3, title);
    //                ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";
    //                ImgFile3 = "<img src='" + rep + FileName3 + "' alt=''>";


    //                if (FileUpload2.HasFile && FileUpload22.HasFile && FileUpload23.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);

    //                    strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
    //                    FileUpload22.SaveAs(strFile2);

    //                    strFile3 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName3);
    //                    FileUpload23.SaveAs(strFile3);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;
    //            case 17:

    //                //break;

    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);

    //                ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='repository/" + FileName2 + "' alt=''>";

    //                title = txtTitle1.Text;

    //                template = T17(ImgFile1, ImgFile2, title);
    //                ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";


    //                if (FileUpload2.HasFile && FileUpload22.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);

    //                    strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
    //                    FileUpload22.SaveAs(strFile2);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;
    //            case 18:


    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);

    //                ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='repository/" + FileName2 + "' alt=''>";

    //                title = txtTitle1.Text;

    //                template = T18(ImgFile1, ImgFile2, title);
    //                ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";


    //                if (FileUpload2.HasFile && FileUpload22.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);

    //                    strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
    //                    FileUpload22.SaveAs(strFile2);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;
    //            case 19:


    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);

    //                ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='repository/" + FileName2 + "' alt=''>";

    //                template = T19(ImgFile1, ImgFile2);
    //                ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";


    //                if (FileUpload2.HasFile && FileUpload22.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);

    //                    strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
    //                    FileUpload22.SaveAs(strFile2);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;
    //            case 20:

    //                //break;

    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);

    //                ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='repository/" + FileName2 + "' alt=''>";

    //                template = T20(ImgFile1, ImgFile2);
    //                ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";


    //                if (FileUpload2.HasFile && FileUpload22.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);

    //                    strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
    //                    FileUpload22.SaveAs(strFile2);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;
    //            case 21:


    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);

    //                ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='repository/" + FileName2 + "' alt=''>";

    //                template = T21(ImgFile1, ImgFile2);
    //                ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";


    //                if (FileUpload2.HasFile && FileUpload22.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);

    //                    strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
    //                    FileUpload22.SaveAs(strFile2);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;
    //            case 22:

    //                //break;
    //                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);

    //                ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='repository/" + FileName2 + "' alt=''>";

    //                template = T22(ImgFile1, ImgFile2);
    //                ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
    //                ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";


    //                if (FileUpload2.HasFile && FileUpload22.HasFile)
    //                {
    //                    strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
    //                    FileUpload2.SaveAs(strFile);

    //                    strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
    //                    FileUpload22.SaveAs(strFile2);
    //                    valid = true;
    //                }
    //                else
    //                {
    //                    lblErrorAdd.Text = "Please choose file to upload";
    //                    valid = false;
    //                }

    //                break;
    //        }







    //        if (valid == true)
    //        {


    //            c.Open();
    //            using (SqlCommand cmd = c.CreateCommand())
    //            {



    //                cmd.Parameters.Clear();
    //                cmd.CommandType = CommandType.StoredProcedure;
    //                cmd.CommandText = "sp_InsertLocation";
    //                if (FileUpload2.HasFile)
    //                {
    //                    FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
    //                    cmd.Parameters.Add("@ImageFile", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
    //                    cmd.Parameters.Add("@ImagePath", SqlDbType.VarChar).Value = System.Convert.ToString(URL + FileName);
    //                    FileUpload2.SaveAs(repository + FileName);
    //                }
    //                if (FileUpload22.HasFile)
    //                {
    //                    FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
    //                    cmd.Parameters.Add("@ImageFile2", SqlDbType.VarChar).Value = System.Convert.ToString(FileName2);
    //                    cmd.Parameters.Add("@ImagePath2", SqlDbType.VarChar).Value = System.Convert.ToString(URL + FileName2);
    //                    FileUpload22.SaveAs(repository + FileName2);
    //                }
    //                else
    //                {

    //                    cmd.Parameters.Add("@ImageFile2", SqlDbType.VarChar).Value = "";
    //                    cmd.Parameters.Add("@ImagePath2", SqlDbType.VarChar).Value = "";
    //                }
    //                if (FileUpload23.HasFile)
    //                {
    //                    FileName3 = Path.GetFileName(FileUpload23.PostedFile.FileName);
    //                    cmd.Parameters.Add("@ImageFile3", SqlDbType.VarChar).Value = System.Convert.ToString(FileName3);
    //                    cmd.Parameters.Add("@ImagePath3", SqlDbType.VarChar).Value = System.Convert.ToString(URL + FileName3);
    //                    FileUpload23.SaveAs(repository + FileName3);
    //                }
    //                else
    //                {
    //                    cmd.Parameters.Add("@ImageFile3", SqlDbType.VarChar).Value = "";
    //                    cmd.Parameters.Add("@ImagePath3", SqlDbType.VarChar).Value = "";
    //                }

    //                cmd.Parameters.Add("@Title1", SqlDbType.VarChar).Value = System.Convert.ToString(txtTitle1.Text);
    //                cmd.Parameters.Add("@Title2", SqlDbType.VarChar).Value = System.Convert.ToString(txtTitle2.Text);

    //                cmd.Parameters.Add("@Rank", SqlDbType.Int).Value = System.Convert.ToInt32(txtRank.Text);
    //                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
    //                cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);
    //                cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
    //                cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);
    //                cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = System.Convert.ToInt32(PresentationID);
    //                cmd.Parameters.Add("@Template", SqlDbType.NVarChar).Value = System.Convert.ToString(template);
    //                cmd.Parameters.Add("@TemplateID", SqlDbType.Int).Value = System.Convert.ToInt32(ddlTemplate.SelectedItem.Text);
    //                cmd.ExecuteNonQuery();

    //            }
    //            c.Close();

    //            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

    //            Panel2.Visible = false;
    //            Panel1.Visible = true;
    //           // Response.Redirect("ProductionDesign.aspx?PresentationID=" + PresentationID.ToString());
    //            gvLocation.DataBind();
    //        }



    //    }

    //}

    protected void BtnSave_Click(object sender, System.EventArgs e)
    {



        if (ddlTemplate.SelectedIndex == 0)
            return;
        if (txtRank.Text == string.Empty)
            txtRank.Text = (gvLocation.Rows.Count + 1).ToString();

        if (Page.IsValid)
        {
            bool valid = false;
            string ImgFile1 = "";
            string ImgFile2 = "";
            string ImgFile3 = "";
            int t = 0;
            string template = "";
            string templateCMS = "";
            if (Session["CompanyID"] == null)
                return;



            t = Convert.ToInt32(ddlTemplate.SelectedItem.Text);


            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));



            //Create Default Files
            string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;
            if (!Directory.Exists(Server.MapPath(pathToCreate)))
            {
                Directory.CreateDirectory(Server.MapPath(pathToCreate));
                DirectoryCopy(Server.MapPath("~/_ipad"), Server.MapPath(pathToCreate), true);

            }




            string FileName, FileName2, FileName3 = "";
            string pathToCreate1 = "~/" + Session["CompanyID"] + "/" + PresentationID + "/repository";


            Directory.CreateDirectory(Server.MapPath(pathToCreate1));

            string strFile, strFile2, strFile3 = "";

            string title, title2 = "";
            FileInfo fi;
            string ext;

            string rep = Session["CompanyID"] + "/" + PresentationID + "/repository/";
            try
            {


                switch (t)
                {
                    case 1:
                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;


                        title = txtTitle1.Text;
                        ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
                        template = T1("<img src='repository/" + FileName + "' alt=''>", title);


                        templateCMS = T1("<img src='" + rep + FileName + "' alt=''>", title);



                        if (FileUpload2.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);


                            FileUpload2.SaveAs(strFile);
                            valid = true;


                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }


                        break;
                    case 2:
                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;

                        FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
                        fi = new FileInfo(FileName2);
                        ext = fi.Extension;
                        FileName2 = Guid.NewGuid().ToString() + ext;


                        ImgFile1 = "<img src='repository/" + FileName + "' width='600' height='475' alt=''>";
                        ImgFile2 = "<img src='repository/" + FileName2 + "'  alt=''>";

                        title = txtTitle1.Text;
                        title2 = txtTitle2.Text;
                        template = T2(ImgFile1, ImgFile2, title, title2);


                        ImgFile1 = "<img src='" + rep + FileName + "' width='600' height='475' alt=''>";
                        ImgFile2 = "<img src='" + rep + FileName2 + "'  alt=''>";
                        templateCMS = T2(ImgFile1, ImgFile2, title, title2);




                        if (FileUpload2.HasFile && FileUpload22.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);

                            strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
                            FileUpload22.SaveAs(strFile2);

                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";

                            valid = false;
                        }

                        break;
                    case 3:


                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;


                        FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
                        fi = new FileInfo(FileName2);
                        ext = fi.Extension;
                        FileName2 = Guid.NewGuid().ToString() + ext;


                        ImgFile1 = "<img src='repository/" + FileName + "' width='733' height='450' alt=''>";
                        ImgFile2 = "<img src='repository/" + FileName2 + "' width='250' height='150'  alt=''>";

                        title = txtTitle1.Text;
                        template = T3(ImgFile1, ImgFile2, title);


                        ImgFile1 = "<img src='" + rep + FileName + "' width='733' height='450' alt=''>";
                        ImgFile2 = "<img src='" + rep + FileName2 + "' width='250' height='150'  alt=''>";
                        templateCMS = T3(ImgFile1, ImgFile2, title);

                        if (FileUpload2.HasFile && FileUpload22.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);

                            strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
                            FileUpload22.SaveAs(strFile2);

                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;


                    case 4:

                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;


                        ImgFile1 = "<img src='repository/" + FileName + "' width='733' height='550' alt=''>";
                        title = txtTitle1.Text;

                        template = T4(ImgFile1, title);

                        ImgFile1 = "<img src='" + rep + FileName + "' width='733' height='550' alt=''>";
                        templateCMS = T3(ImgFile1, ImgFile2, title);

                        if (FileUpload2.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);
                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;


                    case 5:
                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;

                        ImgFile1 = "<img src='repository/" + FileName + "' width='900' height='550' alt=''>";

                        template = T5(ImgFile1);
                        ImgFile1 = "<img src='" + rep + FileName + "' width='900' height='550' alt=''>";

                        templateCMS = T5(ImgFile1);

                        if (FileUpload2.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);
                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;
                    case 6:


                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;

                        FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
                        fi = new FileInfo(FileName2);
                        ext = fi.Extension;
                        FileName2 = Guid.NewGuid().ToString() + ext;

                        ImgFile1 = "<img src='repository/" + FileName + "' width='350' height='350' alt=''>";
                        ImgFile2 = "<img src='repository/" + FileName2 + "' width='600' height='550' alt=''>";
                        template = T6(ImgFile1, ImgFile2);

                        ImgFile1 = "<img src='" + rep + FileName + "' width='350' height='350' alt=''>";
                        ImgFile2 = "<img src='" + rep + FileName2 + "' width='600' height='550' alt=''>";



                        templateCMS = T6(ImgFile1, ImgFile2);

                        if (FileUpload2.HasFile && FileUpload22.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);

                            strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
                            FileUpload22.SaveAs(strFile2);
                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;
                    case 7:




                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;


                        FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
                        fi = new FileInfo(FileName2);
                        ext = fi.Extension;
                        FileName2 = Guid.NewGuid().ToString() + ext;

                        FileName3 = Path.GetFileName(FileUpload23.PostedFile.FileName);
                        fi = new FileInfo(FileName3);
                        ext = fi.Extension;
                        FileName3 = Guid.NewGuid().ToString() + ext;

                        ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
                        ImgFile2 = "<img src='repository/" + FileName2 + "' alt=''>";
                        ImgFile3 = "<img src='repository/" + FileName3 + "' alt=''>";

                        title = txtTitle1.Text;

                        template = T7(ImgFile1, ImgFile2, ImgFile3, title);


                        ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
                        ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";
                        ImgFile3 = "<img src='" + rep + FileName3 + "' alt=''>";
                        templateCMS = T7(ImgFile1, ImgFile2, ImgFile3, title);


                        if (FileUpload2.HasFile && FileUpload22.HasFile && FileUpload23.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);

                            strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
                            FileUpload22.SaveAs(strFile2);

                            strFile3 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName3);
                            FileUpload23.SaveAs(strFile3);
                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;
                    case 8:


                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;

                        FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
                        fi = new FileInfo(FileName2);
                        ext = fi.Extension;
                        FileName2 = Guid.NewGuid().ToString() + ext;

                        FileName3 = Path.GetFileName(FileUpload23.PostedFile.FileName);
                        fi = new FileInfo(FileName3);
                        ext = fi.Extension;
                        FileName3 = Guid.NewGuid().ToString() + ext;

                        ImgFile1 = "<img src='repository/" + FileName + "' width='320' height='550' alt=''>";
                        ImgFile2 = "<img src='repository/" + FileName2 + "' width='320' height='550' alt=''>";
                        ImgFile3 = "<img src='repository/" + FileName3 + "' width='320' height='550' alt=''>";
                        template = T8(ImgFile1, ImgFile2, ImgFile3);

                        ImgFile1 = "<img src='" + rep + FileName + "' width='320' height='550' alt=''>";
                        ImgFile2 = "<img src='" + rep + FileName2 + "' width='320' height='550' alt=''>";
                        ImgFile3 = "<img src='" + rep + FileName3 + "' width='320' height='550' alt=''>";
                        templateCMS = T8(ImgFile1, ImgFile2, ImgFile3);

                        if (FileUpload2.HasFile && FileUpload22.HasFile && FileUpload23.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);

                            strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
                            FileUpload22.SaveAs(strFile2);

                            strFile3 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName3);
                            FileUpload23.SaveAs(strFile3);
                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;
                    case 9:



                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;

                        FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
                        fi = new FileInfo(FileName2);
                        ext = fi.Extension;
                        FileName2 = Guid.NewGuid().ToString() + ext;

                        FileName3 = Path.GetFileName(FileUpload23.PostedFile.FileName);
                        fi = new FileInfo(FileName3);
                        ext = fi.Extension;
                        FileName3 = Guid.NewGuid().ToString() + ext;

                        ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
                        ImgFile2 = "<img src='repository/" + FileName2 + "' alt=''>";
                        ImgFile3 = "<img src='repository/" + FileName3 + "' alt=''>";
                        template = T9(ImgFile1, ImgFile2, ImgFile3);

                        ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
                        ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";
                        ImgFile3 = "<img src='" + rep + FileName3 + "' alt=''>";

                        templateCMS = T8(ImgFile1, ImgFile2, ImgFile3);

                        if (FileUpload2.HasFile && FileUpload22.HasFile && FileUpload23.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);

                            strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
                            FileUpload22.SaveAs(strFile2);

                            strFile3 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName3);
                            FileUpload23.SaveAs(strFile3);
                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;
                    case 10:


                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;

                        FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
                        fi = new FileInfo(FileName2);
                        ext = fi.Extension;
                        FileName2 = Guid.NewGuid().ToString() + ext;


                        ImgFile1 = "<img src='repository/" + FileName + "' width='480' height='550' alt=''>";
                        ImgFile2 = "<img src='repository/" + FileName2 + "' width='480' height='550' alt=''>";

                        title = txtTitle1.Text;

                        template = T10(ImgFile1, ImgFile2, title);
                        ImgFile1 = "<img src='" + rep + FileName + "' width='480' height='550' alt=''>";
                        ImgFile2 = "<img src='" + rep + FileName2 + "' width='480' height='550' alt=''>";

                        templateCMS = T10(ImgFile1, ImgFile2, title);

                        if (FileUpload2.HasFile && FileUpload22.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);

                            strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
                            FileUpload22.SaveAs(strFile2);
                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;
                    case 11:



                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;


                        FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
                        fi = new FileInfo(FileName2);
                        ext = fi.Extension;
                        FileName2 = Guid.NewGuid().ToString() + ext;


                        ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
                        ImgFile2 = "<img src='repository/" + FileName2 + "' alt=''>";

                        title = txtTitle1.Text;

                        template = T11(ImgFile1, ImgFile2, title);
                        ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
                        ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";

                        templateCMS = T11(ImgFile1, ImgFile2, title);


                        if (FileUpload2.HasFile && FileUpload22.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);

                            strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
                            FileUpload22.SaveAs(strFile2);
                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;
                    case 12:




                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;


                        ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";

                        title = txtTitle1.Text;

                        template = T12(ImgFile1, title);
                        ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";

                        templateCMS = T12(ImgFile1, title);


                        if (FileUpload2.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);
                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;
                    case 13:



                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;

                        FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
                        fi = new FileInfo(FileName2);
                        ext = fi.Extension;
                        FileName2 = Guid.NewGuid().ToString() + ext;

                        FileName3 = Path.GetFileName(FileUpload23.PostedFile.FileName);
                        fi = new FileInfo(FileName3);
                        ext = fi.Extension;
                        FileName3 = Guid.NewGuid().ToString() + ext;


                        ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
                        ImgFile2 = "<img src='repository/" + FileName2 + "' alt=''>";
                        ImgFile3 = "<img src='repository/" + FileName3 + "' alt=''>";
                        template = T13(ImgFile1, ImgFile2, ImgFile3);

                        ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
                        ImgFile2 = "<img src='" + rep + FileName + "' alt=''>";
                        ImgFile3 = "<img src='" + rep + FileName + "' alt=''>";


                        templateCMS = T13(ImgFile1, ImgFile2, ImgFile3);


                        if (FileUpload2.HasFile && FileUpload22.HasFile && FileUpload23.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);

                            strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
                            FileUpload22.SaveAs(strFile2);

                            strFile3 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName3);
                            FileUpload23.SaveAs(strFile3);
                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;
                    case 14:



                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;

                        ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";

                        title = txtTitle1.Text;

                        template = T12(ImgFile1, title);
                        ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";


                        templateCMS = T12(ImgFile1, title);

                        if (FileUpload2.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);
                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;
                    case 15:


                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;


                        ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";

                        title = txtTitle1.Text;

                        template = T12(ImgFile1, title);
                        ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";

                        templateCMS = T12(ImgFile1, title);


                        if (FileUpload2.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);
                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;
                    case 16:


                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;


                        FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
                        fi = new FileInfo(FileName2);
                        ext = fi.Extension;
                        FileName2 = Guid.NewGuid().ToString() + ext;


                        FileName3 = Path.GetFileName(FileUpload23.PostedFile.FileName);
                        fi = new FileInfo(FileName3);
                        ext = fi.Extension;
                        FileName3 = Guid.NewGuid().ToString() + ext;


                        ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
                        ImgFile2 = "<img src='repository/" + FileName2 + "' alt=''>";
                        ImgFile3 = "<img src='repository/" + FileName3 + "' alt=''>";

                        title = txtTitle1.Text;

                        template = T16(ImgFile1, ImgFile2, ImgFile3, title);
                        ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
                        ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";
                        ImgFile3 = "<img src='" + rep + FileName3 + "' alt=''>";


                        templateCMS = T16(ImgFile1, ImgFile2, ImgFile3, title);


                        if (FileUpload2.HasFile && FileUpload22.HasFile && FileUpload23.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);

                            strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
                            FileUpload22.SaveAs(strFile2);

                            strFile3 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName3);
                            FileUpload23.SaveAs(strFile3);
                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;
                    case 17:

                        //break;

                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;


                        FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
                        fi = new FileInfo(FileName2);
                        ext = fi.Extension;
                        FileName2 = Guid.NewGuid().ToString() + ext;

                        ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
                        ImgFile2 = "<img src='repository/" + FileName2 + "' alt=''>";

                        title = txtTitle1.Text;

                        template = T17(ImgFile1, ImgFile2, title);
                        ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
                        ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";


                        templateCMS = T17(ImgFile1, ImgFile2, title);


                        if (FileUpload2.HasFile && FileUpload22.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);

                            strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
                            FileUpload22.SaveAs(strFile2);
                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;
                    case 18:


                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;


                        FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
                        fi = new FileInfo(FileName2);
                        ext = fi.Extension;
                        FileName2 = Guid.NewGuid().ToString() + ext;

                        ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
                        ImgFile2 = "<img src='repository/" + FileName2 + "' alt=''>";

                        title = txtTitle1.Text;

                        template = T18(ImgFile1, ImgFile2, title);
                        ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
                        ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";

                        templateCMS = T18(ImgFile1, ImgFile2, title);

                        if (FileUpload2.HasFile && FileUpload22.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);

                            strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
                            FileUpload22.SaveAs(strFile2);
                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;
                    case 19:


                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;


                        FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
                        fi = new FileInfo(FileName2);
                        ext = fi.Extension;
                        FileName2 = Guid.NewGuid().ToString() + ext;

                        ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
                        ImgFile2 = "<img src='repository/" + FileName + "' alt=''>";

                        template = T19(ImgFile1, ImgFile2);
                        ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
                        ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";

                        templateCMS = T19(ImgFile1, ImgFile2);

                        if (FileUpload2.HasFile && FileUpload22.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);

                            strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
                            FileUpload22.SaveAs(strFile2);
                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;
                    case 20:

                        //break;

                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;


                        FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
                        fi = new FileInfo(FileName2);
                        ext = fi.Extension;
                        FileName2 = Guid.NewGuid().ToString() + ext;

                        ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
                        ImgFile2 = "<img src='repository/" + FileName2 + "' alt=''>";

                        template = T20(ImgFile1, ImgFile2);
                        ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
                        ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";

                        templateCMS = T20(ImgFile1, ImgFile2);

                        if (FileUpload2.HasFile && FileUpload22.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);

                            strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
                            FileUpload22.SaveAs(strFile2);
                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;
                    case 21:


                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;


                        FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
                        fi = new FileInfo(FileName2);
                        ext = fi.Extension;
                        FileName2 = Guid.NewGuid().ToString() + ext;

                        ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
                        ImgFile2 = "<img src='repository/" + FileName2 + "' alt=''>";

                        template = T21(ImgFile1, ImgFile2);
                        ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
                        ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";

                        templateCMS = T21(ImgFile1, ImgFile2);

                        if (FileUpload2.HasFile && FileUpload22.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);

                            strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
                            FileUpload22.SaveAs(strFile2);
                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;
                    case 22:

                        //break;
                        FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                        fi = new FileInfo(FileName);
                        ext = fi.Extension;
                        FileName = Guid.NewGuid().ToString() + ext;


                        FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
                        fi = new FileInfo(FileName2);
                        ext = fi.Extension;
                        FileName2 = Guid.NewGuid().ToString() + ext;

                        ImgFile1 = "<img src='repository/" + FileName + "' alt=''>";
                        ImgFile2 = "<img src='repository/" + FileName2 + "' alt=''>";

                        template = T22(ImgFile1, ImgFile2);
                        ImgFile1 = "<img src='" + rep + FileName + "' alt=''>";
                        ImgFile2 = "<img src='" + rep + FileName2 + "' alt=''>";

                        templateCMS = T22(ImgFile1, ImgFile2);



                        if (FileUpload2.HasFile && FileUpload22.HasFile)
                        {
                            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
                            FileUpload2.SaveAs(strFile);

                            strFile2 = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName2);
                            FileUpload22.SaveAs(strFile2);
                            valid = true;
                        }
                        else
                        {
                            lblErrorAdd.Text = "Please choose file to upload";
                            valid = false;
                        }

                        break;
                }


            }
            catch(Exception ex)
            {
                lblErrorAdd.Text = "Unable to save. Make sure you have uploaded the image/s properly.";
                return;
            }



            if (valid == true)
            {

                try
                {

                    c.Open();
                    using (SqlCommand cmd = c.CreateCommand())
                    {



                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_InsertLocation";
                        if (FileUpload2.HasFile)
                        {
                            FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                            cmd.Parameters.Add("@ImageFile", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
                            cmd.Parameters.Add("@ImagePath", SqlDbType.VarChar).Value = System.Convert.ToString(rep + FileName);
                          //  FileUpload2.SaveAs(repository + FileName);



                        }
                        if (FileUpload22.HasFile)
                        {
                            FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
                            cmd.Parameters.Add("@ImageFile2", SqlDbType.VarChar).Value = System.Convert.ToString(FileName2);
                            cmd.Parameters.Add("@ImagePath2", SqlDbType.VarChar).Value = System.Convert.ToString(rep + FileName2);
                          //  FileUpload22.SaveAs(repository + FileName2);


                        }
                        else
                        {

                            cmd.Parameters.Add("@ImageFile2", SqlDbType.VarChar).Value = "";
                            cmd.Parameters.Add("@ImagePath2", SqlDbType.VarChar).Value = "";
                        }
                        if (FileUpload23.HasFile)
                        {
                            FileName3 = Path.GetFileName(FileUpload23.PostedFile.FileName);
                            cmd.Parameters.Add("@ImageFile3", SqlDbType.VarChar).Value = System.Convert.ToString(FileName3);
                            cmd.Parameters.Add("@ImagePath3", SqlDbType.VarChar).Value = System.Convert.ToString(rep + FileName3);
                          //  FileUpload23.SaveAs(repository + FileName3);


                        }
                        else
                        {
                            cmd.Parameters.Add("@ImageFile3", SqlDbType.VarChar).Value = "";
                            cmd.Parameters.Add("@ImagePath3", SqlDbType.VarChar).Value = "";
                        }

                        cmd.Parameters.Add("@Title1", SqlDbType.VarChar).Value = System.Convert.ToString(txtTitle1.Text);
                        cmd.Parameters.Add("@Title2", SqlDbType.VarChar).Value = System.Convert.ToString(txtTitle2.Text);

                        cmd.Parameters.Add("@Rank", SqlDbType.Int).Value = System.Convert.ToInt32(txtRank.Text);
                        cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);
                        cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
                        cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);
                        cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = System.Convert.ToInt32(PresentationID);
                        cmd.Parameters.Add("@Template", SqlDbType.NVarChar).Value = System.Convert.ToString(template);
                        cmd.Parameters.Add("@TemplateCMS", SqlDbType.NVarChar).Value = System.Convert.ToString(templateCMS);
                        cmd.Parameters.Add("@TemplateID", SqlDbType.Int).Value = System.Convert.ToInt32(ddlTemplate.SelectedItem.Text);
                        cmd.ExecuteNonQuery();




                    }
                    c.Close();


                }
                catch (Exception ex)
                {
                    //  Label1.Text = "ERROR " + ex.Message;
                }

            }




            Panel2.Visible = false;
            Panel1.Visible = true;
            // Response.Redirect("ProductionDesign.aspx?PresentationID=" + PresentationID.ToString());
            // Response.Redirect("ProductionDesign.aspx?PresentationID=" + PresentationID.ToString());
            gvLocation.DataBind();




            //Generate HTML file
            string temp = "";
            for (int i = 0; i < gvLocation.Rows.Count; i++)
            {
                Label lbl = gvLocation.Rows[i].FindControl("lblTemplate") as Label;
                temp += lbl.Text;

            }

            if (gvLocation.Rows.Count > 0)
            {
                generate(temp);
            }

        }

    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel1.Visible = true;
    }


    private string T1(string img, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><h4 class='temp1_title'>" + title + "</h4><div class='temp1'>" + img + "</div></div></li>";
        return t;
    }
    private string T2(string img, string img2, string title, string title2)
    {
        string t = " <li class='touchcarousel-item'><div class='pd_container'><div class='temp2'><div class='leftImg'><h4>" + title + "</h4>" + img + "<p>1</p></div><div class='rightImg'>" + img2 + "<h4>" + title2 + "</h4></div></div></div></li>";
        return t;
    }
    private string T3(string img, string img2, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp3'><div>" + img + "<h4>" + title + "</h4></div><span class='span'>" + img2 + "</span></div></div></li>";
        return t;
    }
    private string T4(string img, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp4'><h4>" + title + "</h4><span class='span'>1</span><div>" + img + "</div></div></div></li>";
        return t;
    }
    private string T5(string img)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp5'><p>2</p><div>" + img + "</div></div></div></li>";
        return t;
    }
    private string T6(string img, string img2)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp6'><div class='leftCol'><p>3</p>" + img + "</div><div class='rightCol'>" + img2 + "</div></div></div></li>";
        return t;
    }
    private string T7(string img, string img2, string img3, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp7'><h4>" + title + "</h4><div class='topImg'><p>1</p>" + img + "</div><div class='leftCol7'>" + img2 + "</div><div class='rightCol7'>" + img3 + "</div></div></div></li>";
        return t;
    }
    private string T8(string img, string img2, string img3)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp8'><p>2</p><div class='leftCol8'>" + img + "</div><div class='middCol8'>" + img2 + "</div><div class='rightCol8'>" + img3 + "</div></div></div></li>";
        return t;
    }
    private string T9(string img, string img2, string img3)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp9'><p>3</p><div class='leftCol9'>" + img + "</div><div class='middCol9'>" + img2 + "</div><div class='rightCol9'>" + img3 + "</div></div></div></li>";
        return t;
    }
    private string T10(string img, string img2, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp10'><h4>" + title + "</h4><div class='leftCol10'><p>1</p>" + img + "</div><div class='rightCol10'><p>2</p>" + img2 + "</div></div></div></li>";
        return t;
    }
    private string T11(string img, string img2, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp11'><h4>" + title + "</h4><div class='leftCol11'>" + img + "</div><div class='rightCol11'>" + img2 + "<p>1</p></div></div></div></li>";
        return t;
    }
    private string T12(string img, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp12'><h4>" + title + "</h4><div>" + img + "</div></div></div></li>";
        return t;
    }
    private string T13(string img, string img2, string img3)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp13'><p>2</p><div class='leftCol13'><div class='leftTop'>" + img + "</div><div class='leftBottom'>" + img2 + "</div></div><div class='rightCol13'>" + img3 + "</div></div></div></li>";
        return t;
    }
    private string T14(string img, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp14'><h4>" + title + "</h4><p>1</p><div>" + img + "</div></div></div></li>";
        return t;
    }
    private string T15(string img)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp15'><p>2</p><div>" + img + "</div></div></div></li>";
        return t;
    }
    private string T16(string img, string img2, string img3, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp16'><h4>" + title + "</h4><div class='leftCol16'>" + img + "<p>1</p></div><div class='middCol16'>" + img2 + "<p>2</p></div><div class='rightCol16'>" + img3 + "<p>3</p></div></div></div></li>";
        return t;
    }
    private string T17(string img, string img2, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp17'><h4>" + title + "</h4><div>" + img + "<div>" + img2 + "</div></div></div></div></li>";
        return t;
    }
    private string T18(string img, string img2, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp18'><h4>" + title + "</h4><div class='leftCol18'><p>1</p>" + img + "</div><div class='rightCol18'><p>2</p>" + img2 + "</div></div></div></li>";
        return t;
    }
    private string T19(string img, string img2)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp19'><div class='leftCol19'><p>3</p>" + img + "</div><div class='rightCol19'><p>4</p>" + img2 + "</div></div></div></li>";
        return t;
    }
    private string T20(string img, string img2)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp20'><p>1</p><div class='leftCol20'>" + img + "</div><div class='rightCol20'>" + img2 + "</div></div></div></li>";
        return t;
    }
    private string T21(string img, string img2)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp21'><p>2</p><div class='leftCol21'>" + img + "</div><div class='rightCol21'>" + img2 + "</div></div></div></li>";
        return t;
    }
    private string T22(string img, string img2)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp22'><p>2</p><div class='leftCol22'>" + img + "</div><div class='rightCol22'>" + img2 + "</div></div></div></li>";
        return t;
    }
    protected void ddlTemplate_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlTemplate.SelectedIndex == 0)
            return;

        imgTemplate.ImageUrl = ddlTemplate.SelectedValue;
        int t = 0;
        int title = 0;

        t = Convert.ToInt32(ddlTemplate.SelectedItem.Text);
        title = Convert.ToInt32(ddlTemplate.SelectedItem.Text);

        switch (title)
        {
            case 5:
            case 6:
            case 8:
            case 9:
            case 13:
            case 15:
            case 19:
            case 20:
            case 21:
            case 22:
                {
                    pnlTitle.Visible = false;
                    pnlTitle2.Visible = false;
                    break;
                }

            case 1:
            case 3:
            case 4:
            case 7:
            case 10:
            case 11:
            case 12:
            case 14:
            case 16:
            case 17:
            case 18:
                {
                    pnlTitle.Visible = true;
                    pnlTitle2.Visible = false;
                    break;
                }

            case 2:
                {
                    pnlTitle.Visible = true;
                    pnlTitle2.Visible = true;
                    break;
                }
        }

        switch (t)
        {


            case 1:
            case 4:
            case 5:
            case 12:
            case 14:
                {
                    pnlImg1.Visible = true;
                    pnlImg2.Visible = false;
                    pnlImg3.Visible = false;
                    break;
                }


            case 2:
            case 3:
            case 6:
            case 10:
            case 11:
            case 13:
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
                {

                    pnlImg1.Visible = true;
                    pnlImg2.Visible = true;
                    pnlImg3.Visible = false;
                    break;
                }



            case 7:
            case 8:
            case 9:
            case 16:
                {
                    pnlImg1.Visible = true;
                    pnlImg2.Visible = true;
                    pnlImg3.Visible = true;
                    break;
                }


        }
    }
    #endregion


    #region "Directory"
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