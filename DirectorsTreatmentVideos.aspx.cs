using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class DirectorsTreatmentVideos : System.Web.UI.Page
{
    private string _presentationID;
    private string _companyID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["CompanyID"] == null)
                return;


            _companyID = Session["CompanyID"].ToString();

            _presentationID =  Request.QueryString.Get("PresentationID");

         

        }
    }
    protected void BtnSaveVideo_Click(object sender, EventArgs e)
    {

        if(Request.QueryString["PresentationID"] == null)
            return;

          if( Session["Username"] == null)
            return;
          _presentationID = Request.QueryString["PresentationID"].ToString();
        
        DirectorTreatmentVideo _video = new DirectorTreatmentVideo();

        
        string strFileNameWithPath = FileUpload1.PostedFile.FileName;
        string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
        string FileName ="";

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
               // lblError.Text = "PATH " + strFile;

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
        _presentationID =  Request.QueryString["PresentationID"].ToString();
        _video.PresentationID = Convert.ToInt32(_presentationID);
        _video.CreatedBy = Session["Username"].ToString();
        _video.Path = Session["CompanyID"] + "/" + _presentationID + "/repository/" + FileName;
        _video.Rank = Convert.ToInt32(txtRank.Text);
        _video.Title = txtTitle.Text;

      

        if (_video.Insert() == true)
        {
           Panel1.Visible = true;
            Panel2.Visible = false;
            gvTreatment.DataBind();
        }else
            lblError.Text = "Error while saving.";



    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        Panel1.Visible = true;
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Panel1.Visible = false;
    }



    #region "Select"

    protected void gvTreatment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {

       

        }


        if (e.CommandName == "edt")
        {
            int index = Convert.ToInt32(e.CommandArgument);
           // DirectorTreatmentVideo _video = new DirectorTreatmentVideo();
           // _video.ID = id;
           //DataTable dt =  _video.GetByID();
           //if (dt.Rows.Count > 0)
           //{
           //    txtEditRank.Text = _video.Rank.ToString();
           //    txtEditTitle.Text = _video.Title.ToString();
               
           //}
            Panel1.Visible = false;
            Panel3.Visible = true;

            GridViewRow row = gvTreatment.Rows[index];
            string path = (string)this.gvTreatment.DataKeys[row.RowIndex]["Path"];
            HiddenField1.Value  = (string)this.gvTreatment.DataKeys[row.RowIndex]["DTVideoID"].ToString();
            
            txtEditRank.Text = row.Cells[0].Text;
            txtEditTitle.Text = row.Cells[1].Text;
        }

        if (e.CommandName == "AddVideos")
        {

         

        }


        if (e.CommandName == "del")
        {

            


        }
    }

    protected void gvTreatment_RowDataBound(Object sender, GridViewRowEventArgs e)
    {

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    // Display the company name in italics.
        //    Image img = (Image)e.Row.FindControl("img");
        //    DataRowView rowView = (DataRowView)e.Row.DataItem;
        //    string value = rowView["ImageFile"].ToString();
        //    img.ImageUrl = _companyID + "/" + _presentationID + "/repository/" + value;
        //    img.AlternateText = img.ImageUrl;

        //}

    }
    #endregion
    protected void BtnUpdateVideo_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["PresentationID"] == null)
            return;

        if (Session["Username"] == null)
            return;

        lblEditError.Text = "";

        _presentationID = Request.QueryString["PresentationID"].ToString();
        DirectorTreatmentVideo _video = new DirectorTreatmentVideo();

        _video.ID = Convert.ToInt32(HiddenField1.Value);
        string strFileNameWithPath = FileUpload2.PostedFile.FileName;
        string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
        string FileName = "";

        if (FileUpload2.HasFile)
        {
            

            FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);

            FileInfo fi = new FileInfo(FileName);
            string ext = fi.Extension;
            FileName = Guid.NewGuid().ToString() + ext;

            string pathToCreate1 = "~/" + FileName;
            string strFile = "";
            strFile = System.Web.Hosting.HostingEnvironment.MapPath(pathToCreate1 + "/" + FileName);
          

            //lblEditError.Text = strFile;

            //return;

            Directory.CreateDirectory(Server.MapPath(pathToCreate1));
            FileUpload1.SaveAs(strFile);



            _video.PresentationID = Convert.ToInt32(_presentationID);
            _video.ModifiedBy= Session["Username"].ToString();
            _video.Path = Session["CompanyID"] + "/" + _presentationID + "/repository/" + FileName;
            _video.Rank = Convert.ToInt32(txtEditRank.Text);
            _video.Title = txtEditTitle.Text;


            if (_video.Update() == true)
            {
                Panel1.Visible = true;
                Panel3.Visible = false;
                gvTreatment.DataBind();
            
            }
            else
                lblEditError.Text = "Error while saving.";
         


        }
        else
        {

            _video.PresentationID = Convert.ToInt32(_presentationID);
            _video.ModifiedBy = Session["Username"].ToString();
            _video.Rank = Convert.ToInt32(txtEditRank.Text);
            _video.Title = txtEditTitle.Text;


          //  lblEditError.Text = "PresentationID " + _video.PresentationID + " Title " + _video.Title + " _video " + _video;
            if (_video.UpdateWithoutVideo() == true)
            {
                Panel1.Visible = true;
                Panel3.Visible = false;
                gvTreatment.DataBind();
            }
            else
                lblEditError.Text = "Error while saving.";
         

            return;
        }

    }
    protected void BtnSaveCancel_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel1.Visible = true;
    }
}