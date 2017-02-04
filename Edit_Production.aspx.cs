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

public partial class Edit_Production : System.Web.UI.Page
{
    private string Contents = ConfigurationManager.AppSettings["Contents"].ToString();

    private string repository = ConfigurationManager.AppSettings["repository"].ToString();
    private string URL = ConfigurationManager.AppSettings["URL"].ToString();
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    int PresentationID;
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (IsPostBack)
        {
            // If condition is true, execute these statements.
        }
        else
        {
            int ProductionID;
            ProductionID = Convert.ToInt32(Request.QueryString.Get("ProductionID"));
            this.loadDProduction();

            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
        }
    }

    private void loadDProduction()
    {
        int ProductionID;
        ProductionID = Convert.ToInt32(Request.QueryString.Get("ProductionID"));

        Production myProduction;
        myProduction = clsproduction.getProduction(ProductionID);
        HiddenField1.Value = myProduction.ProductionID.ToString();




        ddlTemplate.SelectedItem.Text = myProduction.TemplateID.ToString();
        imgTemplate.ImageUrl = ddlTemplate.SelectedValue;
        //txtImagePath.Text = myDirectorsTreatment.ImagePath.ToString();

        if (String.IsNullOrEmpty(myProduction.ImageFile.ToString()))
        {
            Image1.ImageUrl = "";

        }
        else
        {
            Image1.ImageUrl = Contents + myProduction.ImageFile.ToString();
            lblFile.Text = myProduction.ImageFile.ToString();

            lblImagePath.Text = myProduction.ImagePath.ToString();
        }

        if (String.IsNullOrEmpty(myProduction.ImageFile2.ToString()))
        {
            Image2.ImageUrl = "";

        }
        else
        {
            Image2.ImageUrl = Contents + myProduction.ImageFile2.ToString();
            lblFile22.Text = myProduction.ImageFile2.ToString();
            lblImagePath22.Text = myProduction.ImagePath2.ToString();
        }


        if (String.IsNullOrEmpty(myProduction.ImageFile3.ToString()))
        {
            Image3.ImageUrl = "";

        }
        else
        {


            Image3.ImageUrl = Contents + myProduction.ImageFile3.ToString();
            lblFile23.Text = myProduction.ImageFile3.ToString();
            lblImagePath23.Text = myProduction.ImagePath3.ToString();
        }


        //txtVoiceOver.Text = myProduction.VoiceOver.ToString();
        //txtDescription.Text = myProduction.Description.ToString();
        txtRank.Text = myProduction.Rank.ToString();
        txtTitle1.Text = myProduction.Title1.ToString();
        txtTitle2.Text = myProduction.Title2.ToString();
        int title = 0;
        int t = Convert.ToInt32(myProduction.TemplateID.ToString());

        if (ddlTemplate.SelectedItem.Text != "-Select-")
        {


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





    }

    protected void BtnUpdate_Click(object sender, System.EventArgs e)
    {



        if (Page.IsValid)
        {
            bool valid = false;
            string ImgFile1 = "";
            string ImgFile2 = "";
            string ImgFile3 = "";
            int t = 0;
            string template = "";



            FileInfo fi;
            string ext;


            t = Convert.ToInt32(ddlTemplate.SelectedItem.Text);


            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

            string rep = Session["CompanyID"] + "/" + PresentationID + "/repository/";

            string FileName, FileName2, FileName3 = "";
            //string pathToCreate1 = "~/" + Session["CompanyID"] + "/" + PresentationID + "/ProductionFiles";
            //Directory.CreateDirectory(Server.MapPath(pathToCreate1));
            string strFile, strFile2, strFile3 = "";
            string title, title2, templateCMS = "";
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





            //if (valid == true)
            //{


            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {



                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UpdateProduction";
                if (FileUpload2.HasFile)
                {
                    FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                    cmd.Parameters.Add("@ImageFile", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
                    cmd.Parameters.Add("@ImagePath", SqlDbType.VarChar).Value = System.Convert.ToString(rep + FileName);
                    FileUpload2.SaveAs(repository + FileName);
                }
                else
                {

                    cmd.Parameters.Add("@ImageFile", SqlDbType.VarChar).Value = lblFile.Text;
                    cmd.Parameters.Add("@ImagePath", SqlDbType.VarChar).Value = lblImagePath.Text;

                }
                if (FileUpload22.HasFile)
                {
                    FileName2 = Path.GetFileName(FileUpload22.PostedFile.FileName);
                    cmd.Parameters.Add("@ImageFile2", SqlDbType.VarChar).Value = System.Convert.ToString(FileName2);
                    cmd.Parameters.Add("@ImagePath2", SqlDbType.VarChar).Value = System.Convert.ToString(rep + FileName2);
                    FileUpload22.SaveAs(repository + FileName2);
                }
                else
                {

                    cmd.Parameters.Add("@ImageFile2", SqlDbType.VarChar).Value = lblFile22.Text;
                    cmd.Parameters.Add("@ImagePath2", SqlDbType.VarChar).Value = lblImagePath22.Text;

                }
                if (FileUpload23.HasFile)
                {
                    FileName3 = Path.GetFileName(FileUpload23.PostedFile.FileName);
                    cmd.Parameters.Add("@ImageFile3", SqlDbType.VarChar).Value = System.Convert.ToString(FileName3);
                    cmd.Parameters.Add("@ImagePath3", SqlDbType.VarChar).Value = System.Convert.ToString(rep + FileName3);
                    FileUpload23.SaveAs(repository + FileName3);
                }
                else
                {
                    cmd.Parameters.Add("@ImageFile3", SqlDbType.VarChar).Value = lblFile23.Text;
                    cmd.Parameters.Add("@ImagePath3", SqlDbType.VarChar).Value = lblImagePath23.Text;
                }

                cmd.Parameters.Add("@Title1", SqlDbType.VarChar).Value = System.Convert.ToString(txtTitle1.Text);
                cmd.Parameters.Add("@Title2", SqlDbType.VarChar).Value = System.Convert.ToString(txtTitle2.Text);
                cmd.Parameters.Add("@Rank", SqlDbType.Int).Value = System.Convert.ToInt32(txtRank.Text);

                cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
                cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);
                cmd.Parameters.Add("@Template", SqlDbType.NVarChar).Value = System.Convert.ToString(template);
                cmd.Parameters.Add("@TemplateID", SqlDbType.Int).Value = System.Convert.ToInt32(ddlTemplate.SelectedItem.Text);
                cmd.Parameters.Add("@ProductionID", SqlDbType.Int).Value = System.Convert.ToInt32(HiddenField1.Value);
                cmd.Parameters.Add("@TemplateCMS", SqlDbType.NVarChar).Value = System.Convert.ToString(templateCMS);
                cmd.ExecuteNonQuery();

            }
            c.Close();






            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));


             Response.Redirect("ProductionDesign.aspx?PresentationID=" + PresentationID.ToString());

            //}



        }



    }

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        //Response.Redirect("Treatment.aspx", false);
        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
        Response.Redirect("ProductionDesign.aspx?PresentationID=" + PresentationID.ToString());
    }
    protected void ddlTemplate_SelectedIndexChanged(object sender, EventArgs e)
    {
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

    private string T1(string img, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><h2 class='temp1_title'>" + title + "</h2><div class='temp1'>" + img + "</div></div></li>";
        return t;
    }
    private string T2(string img, string img2, string title, string title2)
    {
        string t = " <li class='touchcarousel-item'><div class='pd_container'><div class='temp2'><div class='leftImg'><h2>" + title + "</h2>" + img + "<p>1</p></div><div class='rightImg'>" + img2 + "<h2>" + title2 + "</h2></div></div></div></li>";
        return t;
    }
    private string T3(string img, string img2, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp3'><div>" + img + "<h2>" + title + "</h2></div><span>" + img2 + "</span></div></div></li>";
        return t;
    }
    private string T4(string img, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp4'><h2>" + title + "</h2><span>1</span><div>" + img + "</div></div></div></li>";
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
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp7'><h2>" + title + "</h2><div class='topImg'><p>1</p>" + img + "</div><div class='leftCol7'>" + img2 + "</div><div class='rightCol7'>" + img3 + "</div></div></div></li>";
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
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp10'><h2>" + title + "</h2><div class='leftCol10'><p>1</p>" + img + "</div><div class='rightCol10'><p>2</p>" + img2 + "</div></div></div></li>";
        return t;
    }
    private string T11(string img, string img2, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp11'><h2>" + title + "</h2><div class='leftCol11'>" + img + "</div><div class='rightCol11'>" + img2 + "<p>1</p></div></div></div></li>";
        return t;
    }
    private string T12(string img, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp12'><h2>" + title + "</h2><div>" + img + "</div></div></div></li>";
        return t;
    }
    private string T13(string img, string img2, string img3)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp13'><p>2</p><div class='leftCol13'><div class='leftTop'>" + img + "</div><div class='leftBottom'>" + img2 + "</div></div><div class='rightCol13'>" + img3 + "</div></div></div></li>";
        return t;
    }
    private string T14(string img, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp14'><h2>" + title + "</h2><p>1</p><div>" + img + "</div></div></div></li>";
        return t;
    }
    private string T15(string img)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp15'><p>2</p><div>" + img + "</div></div></div></li>";
        return t;
    }
    private string T16(string img, string img2, string img3, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp16'><h2>" + title + "</h2><div class='leftCol16'>" + img + "<p>1</p></div><div class='middCol16'>" + img2 + "<p>2</p></div><div class='rightCol16'>" + img3 + "<p>3</p></div></div></div></li>";
        return t;
    }
    private string T17(string img, string img2, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp17'><h2>" + title + "</h2><div>" + img + "<div>" + img2 + "</div></div></div></div></li>";
        return t;
    }
    private string T18(string img, string img2, string title)
    {
        string t = "<li class='touchcarousel-item'><div class='pd_container'><div class='temp18'><h2>" + title + "</h2><div class='leftCol18'><p>1</p>" + img + "</div><div class='rightCol18'><p>2</p>" + img2 + "</div></div></div></li>";
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
}