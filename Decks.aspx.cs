using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Ionic.Zip;


public partial class Decks : System.Web.UI.Page
{

    string _presentationID = "0";
    string _clientID = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            //navigator
            if (string.IsNullOrEmpty(Session["RoleID"].ToString()))
                return;

            Literal1.Text = "<ul><li class='nav_dashboard'><a href='Default.aspx'>Dashboard</a></li> " ;
            Literal1.Text += " <li class='nav_clients'><a href='ClientGrid.aspx'>Clients</a></li>" ;
            Literal1.Text += "<li class='nav_projects active'><a href='Decks.aspx'>Projects</a></li>";
        //<%--    <li class="nav_decks active" ><a href="Decks.aspx">Decks</a></li>--%>

            string roleid = Session["RoleID"].ToString();
            if (roleid == "64ddaa33-9300-4db2-832e-b15a7d922132" || roleid == "393b0494-5da5-40b4-b424-494a0387655c")
                Literal1.Text += "<li class='nav_decks' ><a href='UserManagementGrid.aspx'>User Management</a></li>";

            Literal1.Text +=" </ul>";
   



            if (string.IsNullOrEmpty(Request.QueryString["PresentationID"]))
                return;

            _presentationID = Request.QueryString["PresentationID"].ToString();

            if (!string.IsNullOrEmpty(Request.QueryString["ClientID"]))
                _clientID = Request.QueryString["ClientID"].ToString();

            if (string.IsNullOrEmpty(Request.QueryString["Selected"]))
            {

             

                ltPages.Text = "<ul>";
                ltPages.Text += "<li><a href='?ClientID=" + _clientID  + "&PresentationID=" + _presentationID + "&Page=PresentationPages.aspx&Selected=Cover' >Cover</a></li>";
                ltPages.Text += "<li><a href='?ClientID=" + _clientID + "&PresentationID=" + _presentationID + "&Page=Attendee.aspx&Selected=Attendees'>Attendees</a></li>";
                ltPages.Text += "<li><a href='?ClientID=" + _clientID + "&PresentationID=" + _presentationID + "&Page=Agenda.aspx&Selected=Agenda'>Agenda</a></li>";
                ltPages.Text += "<li><a href='?ClientID=" + _clientID + "&PresentationID=" + _presentationID + "&Page=Advertising.aspx&Selected=Advertising Objectives'>Advertising Objectives</a></li>";
                ltPages.Text += "<li><a href='?ClientID=" + _clientID + "&PresentationID=" + _presentationID + "&Page=MoodandTone.aspx&Selected=Mood and Tone'>Mood and Tone</a></li>";
                ltPages.Text += "<li><a href='?ClientID=" + _clientID + "&PresentationID=" + _presentationID + "&Page=TargetMarket.aspx&Selected=Target Market'>Target Market</a></li>";
                ltPages.Text += "<li><a href='?ClientID=" + _clientID + "&PresentationID=" + _presentationID + "&Page=Agency.aspx&Selected=Agency Board'>Agency Board</a></li>";
                ltPages.Text += "<li><a href='?ClientID=" + _clientID + "&PresentationID=" + _presentationID + "&Page=Treatment.aspx&Selected=Directors Treatment'>Director's Treatment</a></li>";
                ltPages.Text += "<li><a href='?ClientID=" + _clientID + "&PresentationID=" + _presentationID + "&Page=ProductionDesign.aspx&Selected=Production Design'>Production Design</a></li>";
                ltPages.Text += "<li><a href='?ClientID=" + _clientID + "&PresentationID=" + _presentationID + "&Page=Locations.aspx&Selected=Locations'>Locations</a></li>";
                ltPages.Text += "<li><a href='?ClientID=" + _clientID + "&PresentationID=" + _presentationID + "&Page=Soundtrack.aspx&Selected=Soundtrack''>Soundtrack</a></li>";
                ltPages.Text += "<li><a href='?ClientID=" + _clientID + "&PresentationID=" + _presentationID + "&Page=Timetable.aspx&Selected=Timetable'>Timetable</a></li>";
                ltPages.Text += "<li><a href='?ClientID=" + _clientID + "&PresentationID=" + _presentationID + "&Page=MapPage.aspx&Selected=Map'>Map</a></li>";
                ltPages.Text += "<li><a href='?ClientID=" + _clientID + "&PresentationID=" + _presentationID + "&Page=DirectoryPage.aspx&Selected=Directory'>Directory</a></li>";
                ltPages.Text += "<li>";
                ltPages.Text += "<a href='Decks.aspx?ClientID=" + _clientID + "'>Back</a>";
                ltPages.Text += "</li>";
                
                ltPages.Text += "</ul>";

                Panel1.Visible = false;
                quick_actions.Visible = false;
                Panel6.Visible = true;
                loadPresentation(Convert.ToInt32(_presentationID));

                BtnUpdate.Visible = false;
                txtEditTitle.ReadOnly = true;
                txtDescription.ReadOnly = true;
                btnEdit.Visible = true;
                BtnCancel.Visible = false;
            }
            else
            {
                ltPages.Text = "<h2>";
                ltPages.Text += Request.QueryString["Selected"].ToString(); 
                ltPages.Text += "</h2>";
                ltPages.Text += "<ul>";
                ltPages.Text += "<li>";
                ltPages.Text += "<a href='Decks.aspx?ClientID=" + _clientID + "&PresentationID=" + _presentationID + "'>Back</a>";
                ltPages.Text += "</li>";
                ltPages.Text += "</ul>";

                Panel1.Visible = false;
                Panel2.Visible = true;
                Panel3.Visible = true;
                Panel5.Visible = false;
                quick_actions.Visible = false;
            }


            if (!string.IsNullOrEmpty(Request.QueryString["Page"]))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>pageselected();</script>", false);
                frmPage.Attributes["src"] = Request.QueryString["Page"].ToString() + "?PresentationID=" + _presentationID;

               // frmEntry.Attributes["src"] = getPage( Request.QueryString["Page"].ToString()) + "?PresentationID=" + _presentationID;

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>back();</script>", false); 
                frmPage.Attributes["src"] = "";
              
            }

          
        }
    }

    protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        lblAllCount.Text = e.AffectedRows.ToString();
    }

    private string getPage(string page)
    {
        
        switch(page){
            case "Treatment.aspx":
                page = "Edit_DirectorsTreatment.aspx";
                break;

            case "MapPage.aspx":
                page = "EditMapPage.aspx";
                break;

        }

            return page;
    }


    protected void createNew_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel5.Visible = true;
        quick_actions.Visible = false;


        if (Request.QueryString["ClientID"] != null)
            ddlClient.SelectedValue = Request.QueryString["ClientID"].ToString(); 
    }


    #region "Add New Item"
    protected void BtnSave_Click(object sender, System.EventArgs e)
    {



        if (string.IsNullOrEmpty(txtTitle.Text))
            return;

        if (string.IsNullOrEmpty(txtDescription.Text))
            return;



        Presentation myPresentation;
        myPresentation = new Presentation();
        myPresentation.Title = System.Convert.ToString(txtTitle.Text);
        myPresentation.Description = System.Convert.ToString(txtDescription.Text);
        myPresentation.ClientID = System.Convert.ToInt32(ddlClient.SelectedValue);
        clspresentation.Insert(myPresentation);

        Panel1.Visible = true;
        Panel5.Visible = false;
        quick_actions.Visible = true;

        Repeater1.DataBind();
      
    }

    protected void btnCancelNewItem_Click(object sender, System.EventArgs e)
    {
        Panel1.Visible = true;
        Panel5.Visible = false;
        quick_actions.Visible = true;
    }
    #endregion

    #region "Edit Item"
    private void loadPresentation(int PresentationPresentationID)
    {
         
        Presentation myPresentation;
        myPresentation = clspresentation.getPresentation(PresentationPresentationID);
        lblPresentationID.Text = PresentationPresentationID.ToString();
        txtEditTitle.Text = myPresentation.Title.ToString();
        txtEditDescription.Text = myPresentation.Description.ToString();
        ddlClientEdit.SelectedValue = myPresentation.ClientID.ToString();
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
        txtDescription.ReadOnly = true;
        btnEdit.Visible = true;
        Repeater1.DataBind();
      
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
        txtDescription.ReadOnly = true;
        btnEdit.Visible = true;
        BtnCancel.Visible = false;
    }


    protected void BtnEdit_Click(object sender, System.EventArgs e)
    {
        btnEdit.Visible = false;
        BtnUpdate.Visible = true;
        txtEditTitle.ReadOnly = false;
        txtDescription.ReadOnly = false;
        BtnCancel.Visible = true;
  
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
                lblGenerateBuildAdd.Text = lblBuild.Text;
            }
        }
        catch (Exception ex)
        {
            lblBuild.Text = "Unable to generate new build.";
        }

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
                DirectoryCopy(Server.MapPath("~/_ipad"),  pathToCreate, true);

              
            }
            

        }
        catch (Exception ex)
        {
             
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