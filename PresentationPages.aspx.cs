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
public partial class Master_PresentationPages : System.Web.UI.Page
{
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    int PresentationID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        //for cover
        DataView dvSql = (DataView)dsCover.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView drvSql in dvSql)
        {

            int cID = Convert.ToInt32(drvSql["CoverID"].ToString());
         

            if ((cID == 0))
            {
                Content.Visible = true;
                ViewContent.Visible = false;
                ContentEdit.Visible = false;
                //lblPresentation.Text = drvSql["Title"].ToString();
                //lblAction.Text = "New Cover";
            }
            else
            {

                Content.Visible = false;
                ViewContent.Visible = true;
                loadCover(cID);
                ContentEdit.Visible = false;
                HiddenFieldCoverID.Value = Convert.ToInt32 (cID).ToString();

                //lblPresentation.Text = drvSql["Title"].ToString();
                //lblAction.Text = "View Cover";
            }
           
        }
        if (!IsPostBack)
        {
            SetDefaultView();
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));        

        }

    }
    private void loadCover(int CoverID)
    {       
        Cover myCover;
        myCover = clscover.getCover(CoverID);
        DivContent.InnerHtml = HttpUtility.HtmlDecode(myCover.CoverPage.ToString());    
               
    }
    private void SetDefaultView()
    {
        MultiView1.ActiveViewIndex = 0;
    }

    //protected void lnkTab1_Click(object sender, EventArgs e)
    //{
    //    MultiView1.ActiveViewIndex = 0;
    //}
    //protected void lnkTab2_Click(object sender, EventArgs e)
    //{
    //    MultiView1.ActiveViewIndex = 1;
    //}
    //protected void lnkTab3_Click(object sender, EventArgs e)
    //{
    //    MultiView1.ActiveViewIndex = 2;
    //}

    protected void BtnSave_Click(object sender, System.EventArgs e)
    {



        //save Cover
        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        PreviewButton_Click(null, EventArgs.Empty);
        string UserSignature = TextPreview.InnerHtml;

        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertCover";
            cmd.Parameters.Add("@CoverPage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature);
            cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = PresentationID;
            cmd.ExecuteNonQuery();
        }
        c.Close();


     


        //string pathToCreate = "~/CoverPages/" + PresentationID;


        //Directory.CreateDirectory(Server.MapPath(pathToCreate));

        //string fileLoc = Server.MapPath(pathToCreate) + "/" + "1.html";




        //FileStream fs = null;
        //if (!File.Exists(fileLoc))
        //{
        //    using (fs = File.Create(fileLoc))
        //    {

        //    }
        //}

        

        string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;


        Directory.CreateDirectory(Server.MapPath(pathToCreate));

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "ct01.html";


    

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
                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Cover</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'><script src='js/jquery-latest.min.js'></script><link rel='stylesheet' href='css/orangebox.css' type='text/css' /></head><body><div id='wrapper'><div id='dt_summ'>{0}</div></div></body></html>", TextPreview.InnerText));
            }
        }


        
    } 

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect(Request.Url.Query, false);
    }
    protected void PreviewButton_Click(object sender, EventArgs e)
    {
        switch (Selections.SelectedValue)
        {
            case "Formatted":
                TextPreview.InnerHtml = Editor.Text;
                break;
            case "Html":
                TextPreview.InnerText = Editor.Text;
                break;
            default:
                break;
        }
    }
    protected void ClearButton_Click(object sender, EventArgs e)
    {
        Editor.Text = String.Empty;
        Content.Visible = true;
        ViewContent.Visible = false;
        ContentEdit.Visible = false;
    }
    
    //for edit
    protected void ClearButtonEdit_Click(object sender, EventArgs e)
    {
        EditorEdit.Text = String.Empty;

        Content.Visible = false;
        ViewContent.Visible = false;       
        ContentEdit.Visible = true;
 
    }
    protected void PreviewButtonEdit_Click(object sender, EventArgs e)
    {
        switch (SelectionsEdit.SelectedValue)
        {
            case "Formatted":
                TextPreviewEdit.InnerHtml = EditorEdit.Text;
                break;
            case "Html":
                TextPreviewEdit.InnerText = EditorEdit.Text;
                break;
            default:
                break;
        }
    }
    protected void BtnUpdateEdit_Click(object sender, System.EventArgs e)
    {
        //Cover myCover;
        //myCover = new Cover();
        //myCover.CoverID = System.Convert.ToInt32(txtCoverID.Text);
        //myCover.CoverTitle = System.Convert.ToString(txtCoverTitle.Text);
        //myCover.CoverPage = System.Convert.ToString(txtCoverPage.Text);
        //myCover.CoverFileName = System.Convert.ToString(txtCoverFileName.Text);
        //myCover.CreatedBy = System.Convert.ToString(txtCreatedBy.Text);
        //myCover.CreatedDate = System.Convert.ToDateTime(calCreatedDate.SelectedDate);
        //myCover.ModifiedBy = System.Convert.ToString(txtModifiedBy.Text);
        //myCover.ModifiedDate = System.Convert.ToDateTime(calModifiedDate.SelectedDate);
        //clscover.Update(myCover);
        //Response.Redirect("CoverGrid.aspx", false);
   

        PreviewButtonEdit_Click(null, EventArgs.Empty);
        string UserSignature = TextPreviewEdit.InnerHtml;




        //string pathToCreate = "~/CoverPages/" + PresentationID;


        //Directory.CreateDirectory(Server.MapPath(pathToCreate));

        //string fileLoc = Server.MapPath(pathToCreate) + "/" + "1.html";


        //if (File.Exists(fileLoc))
        //{
        //    File.Delete(fileLoc);
        //}


        //FileStream fs = null;
        //if (!File.Exists(fileLoc))
        //{
        //    using (fs = File.Create(fileLoc))
        //    {

        //    }
        //}

        //FileInfo f = new FileInfo(fileLoc);
        //TextWriter tw = f.CreateText();

        //tw.Write(string.Format("<head><title></title></head><body >{0}</body></html>", TextPreviewEdit.InnerText));
        //tw.Flush();
        //tw.Close();

        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;


        Directory.CreateDirectory(Server.MapPath(pathToCreate));

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "ct01.html";


        Label1.Text = fileLoc;

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
                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Cover</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'><script src='js/jquery-latest.min.js'></script><link rel='stylesheet' href='css/orangebox.css' type='text/css' /></head><body><div id='wrapper'><div id='dt_summ'>{0}</div></div></body></html>", TextPreviewEdit.InnerText));
            }
        }




        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateCover";
            cmd.Parameters.Add("@CoverPage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature); 
            cmd.Parameters.Add("@CoverID", SqlDbType.Int).Value = HiddenFieldCoverID.Value;
            cmd.ExecuteNonQuery();
        }
        c.Close();




        //string fileLoc = @"c:\terrible1\CoverPages\" + PresentationID + "\" + 1.html";

        ////FileStream fs = null;
        ////if (!File.Exists(fileLoc))
        ////{
        //    //using (fs = File.Create(fileLoc))
        //    //{
        //        if (File.Exists(fileLoc))
        //        {
        //            using (StreamWriter sw = new StreamWriter(fileLoc))
        //            {
        //                sw.Write(string.Format("<head><title></title></head><body >{0}</body></html>", TextPreviewEdit.InnerHtml));
        //            }
        //        }
        //    //}
        ////}








    //    Response.Redirect(Request.Url.Query, false);

        loadCover(Convert.ToInt32(HiddenFieldCoverID.Value));

    }
    protected void BtnCancelEdit_Click(object sender, System.EventArgs e)
    {
        // Response.Redirect(Request.Url.Query,false);

    }
  
    
    
    protected void btnEditCover_Click(object sender, EventArgs e)
    {
        ContentEdit.Visible = true;
        ViewContent.Visible = false;
        Content.Visible = false;
        EditCover(Convert.ToInt32(HiddenFieldCoverID.Value));
     
    }

    private void EditCover(int CoverID)
    {

        Cover myCover;
        myCover = clscover.getCover(CoverID);


        EditorEdit.Text = HttpUtility.HtmlDecode(myCover.CoverPage.ToString());


    }
    protected void btnCancelEditCover_Click(object sender, EventArgs e)
    {
       // Response.Redirect(Request.Url.Query, false);
        //Panel panel = (Panel)this.Parent.FindControl("Panel2");
        //panel.Visible = false;

        //lblPresentation.Text = this.Parent.ID;

    }
}