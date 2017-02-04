using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Ionic.Zip;

public partial class ProjectInside : System.Web.UI.Page
{

    string _presentationID = "0";
    string _clientID = "0";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ClientID"]))
                    _clientID = Request.QueryString["ClientID"].ToString();

                _presentationID = Request.QueryString["PresentationID"].ToString();


                loadPresentation(Convert.ToInt32(_presentationID));

                txtEditTitle.ReadOnly = true;
                txtEditDescription.ReadOnly = true;
                ddlClientEdit.Enabled = false;

                btnBack.Attributes["href"] = "Projects.aspx?ClientID=" + _clientID.ToString();
                string param = "PresentationID=" + _presentationID.ToString() + "&ClientID=" + _clientID.ToString();


                lnkAgencyBoard.Attributes["href"] = "DeckAgencyBoard.aspx?" + param;
                lnkDirectorsTreatement.Attributes["href"] = "DeckDirectorsTreatment.aspx?" + param;


                lnkCover.Attributes["href"] = "DeckCover.aspx?" + param;
                lnkAgenda.Attributes["href"] = "DeckAgenda.aspx?" + param;
                lnkAttendees.Attributes["href"] = "DeckAttendees.aspx?" + param;
                lnkAdvertising.Attributes["href"] = "DeckAdvertising.aspx?" + param;
                lnkTargetMarket.Attributes["href"] = "DeckTargetMarket.aspx?" + param;
                lnkMoodandTone.Attributes["href"] = "DeckMoodandTone.aspx?" + param;
                lnkMaps.Attributes["href"] = "DeckMap.aspx?" + param;

                lnkDirectory.Attributes["href"] = "DeckDirectory.aspx?" + param;

                // BY JOHN
                lnkProductionDesign.Attributes["href"] = "DeckProduction.aspx?" + param;
                lnkLocations.Attributes["href"] = "DeckLocations.aspx?" + param;
                lnkTimetable.Attributes["href"] = "DeckTimeTable.aspx?" + param;
                lnkSoundtrack.Attributes["href"] = "DeckSoundtrack.aspx?" + param;


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }

    #region "Edit Item"
    private void loadPresentation(int PresentationPresentationID)
    {

        Presentation myPresentation;
        myPresentation = clspresentation.getPresentation(PresentationPresentationID);
        lblPresentationID.Text = PresentationPresentationID.ToString();
        txtEditTitle.Text = myPresentation.Title.ToString();
        Label1.Text = myPresentation.Title.ToString();
        txtEditDescription.Text = myPresentation.Description.ToString();
       // ddlClientEdit.SelectedValue = myPresentation.ClientID.ToString();
        ddlClientEdit.DataBind();
    }


    protected void ddlClientEdit_DataBound(object sender, EventArgs e)
    {
        DropDownList list = sender as DropDownList;
         if (list != null)
             ddlClientEdit.SelectedValue = Request.QueryString["ClientID"].ToString();
    }

    protected void BtnUpdate_Click(object sender, System.EventArgs e)
    {
        int PresentationPresentationID;
        PresentationPresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
        Presentation myPresentation;
        myPresentation = new Presentation();
        myPresentation.PresentationID = PresentationPresentationID.ToString();
        myPresentation.Title = System.Convert.ToString(txtEditTitle.Text);
        myPresentation.Description = System.Convert.ToString(txtEditDescription.Text);
        myPresentation.ClientID = System.Convert.ToInt32(ddlClientEdit.SelectedValue);
        clspresentation.Update(myPresentation);

        BtnUpdate.Visible = false;
        txtEditTitle.ReadOnly = true;
        txtEditDescription.ReadOnly = true;
       // btnEdit.Visible = true;
        //Repeater1.DataBind();

    }

    protected void BtnCancelEdit_Click(object sender, System.EventArgs e)
    {


        if (string.IsNullOrEmpty(Request.QueryString["PresentationID"]))
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ClientID"]))
                _clientID = Request.QueryString["ClientID"].ToString();

            Response.Redirect("Decks.aspx?ClientID=" + _clientID);
            return;
        }

        _presentationID = Request.QueryString["PresentationID"].ToString();
        loadPresentation(Convert.ToInt32(_presentationID));
        BtnUpdate.Visible = false;
        txtEditTitle.ReadOnly = true;
        txtEditDescription.ReadOnly = true;
     //  btnEdit.Visible = true;
        BtnCancel.Visible = false;
        ddlClientEdit.Enabled = false;
    }


    protected void BtnEdit_Click(object sender, System.EventArgs e)
    {
      //  btnEdit.Visible = false;
        BtnUpdate.Visible = true;
        txtEditTitle.ReadOnly = false;
        txtEditDescription.ReadOnly = false;
        BtnCancel.Visible = true;
        ddlClientEdit.Enabled = true;
    }
    #endregion


    protected void btnGenerateBuild_Click(object sender, EventArgs e)
    {
        try
        {

            _presentationID = Request.QueryString["PresentationID"].ToString();
            string cid = Session["CompanyID"].ToString();
            string pathToCreate = Server.MapPath("~/" + cid + "/" + _presentationID);

            generate(pathToCreate);
            //string fileName = Path.GetFileName(uploadCreateZip.PostedFile.FileName);
            //string fileLocation = Server.MapPath("~/UploadedFiles/" + fileName);
            //uploadCreateZip.SaveAs(fileLocation);

            // ZipFile createZipFile = new ZipFile();
            // createZipFile.AddFile(pathToCreate, string.Empty);
            //   Response.Write("path to create " + pathToCreate);
            //  createZipFile.Save(pathToCreate + ".zip");

            using (ZipFile zip = new ZipFile())
            {
                // zip.AlternateEncodingUsage = true;  // utf-8
                zip.AddDirectory(pathToCreate);
                zip.Comment = "This zip was created at " + System.DateTime.Now.ToString("G");
                zip.Save(pathToCreate + ".zip");
                lblBuild.Text = "This build was created at " + System.DateTime.Now.ToString("G");
                
            }

        DirectorsTreatmentPasscode _passcode = new DirectorsTreatmentPasscode();
         _passcode.PresentationID = _presentationID;



         if (_passcode.Get() == String.Empty)
             generateNew();

        }
        catch (Exception ex)
        {
            lblBuild.Text = "Unable to generate new build." + ex.Message;
        }

    }

    private void generateNew()
    {
      
        DirectorsTreatmentPasscode _passcode = new DirectorsTreatmentPasscode();
        _passcode.PresentationID = Request.QueryString["PresentationID"].ToString();
        _passcode.Passcode = System.Web.Security.Membership.GeneratePassword(4, 0);
        _passcode.Update();
    }

    private void generate(string pathToCreate)
    {





        try
        {
            if (!Directory.Exists(pathToCreate))
            {

                Directory.CreateDirectory(Server.MapPath(pathToCreate));
            }

            if (Directory.Exists(Server.MapPath("~/_ipad")))
            {
                DirectoryCopy(Server.MapPath("~/_ipad"), pathToCreate, true);

              //  lblBuild.Text = "COPY";
            }


        }
        catch (Exception ex)
        {
            lblBuild.Text = "Error: " + ex.Message;
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
            file.CopyTo(temppath, true);
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