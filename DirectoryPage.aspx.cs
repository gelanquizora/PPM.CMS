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

public partial class Master_DirectoryPage : System.Web.UI.Page
{
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    int PresentationID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            SetDefaultView();
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        }


        DataView dvSql = (DataView)dsDirectory.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView drvSql in dvSql)
        {


            int dID = Convert.ToInt32(drvSql["DirectoryID"].ToString());
            if ((dID == 0))
            {
                MultiView1.ActiveViewIndex = 0;

                
            }
            else
            {

                MultiView1.ActiveViewIndex = 1;



                HiddenFieldDirectoryID.Value = Convert.ToInt32(dID).ToString();

                

                loadDirectory(Convert.ToInt32(HiddenFieldDirectoryID.Value));
            }

        }


    }
    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
      //  Response.Redirect("PresentationMaster.aspx", false);
    }
    protected void BtnSave_Click(object sender, System.EventArgs e)
    {

        //save
        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        PreviewButton_Click(null, EventArgs.Empty);
        string UserSignature = TextPreview.InnerHtml;

        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertDirectory";
            cmd.Parameters.Add("@DirectoryPage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature);
            cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = PresentationID;
            cmd.ExecuteNonQuery();
        }
        c.Close();






        string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;


        Directory.CreateDirectory(Server.MapPath(pathToCreate));

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "dr01.html";




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
                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Directory</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'><script src='js/jquery-latest.min.js'></script><link rel='stylesheet' href='css/orangebox.css' type='text/css' /></head><body><div id='wrapper'><div id='dt_summ'>{0}</div></div></body></html>", TextPreview.InnerText));
            }
        }






     //   Response.Redirect("PresentationMaster.aspx", false);
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
    }
    private void SetDefaultView()
    {
        MultiView1.ActiveViewIndex = 0;
    }
    private void loadDirectory(int DirectoryID)
    {
        Directorytbl myDirectory;
        myDirectory = clsDirectory.getDirectory(DirectoryID);
        DivContent.InnerHtml = HttpUtility.HtmlDecode(myDirectory.DirectoryPage.ToString());

    }
    protected void    btnEditDirectory_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        EditDirectory(Convert.ToInt32(HiddenFieldDirectoryID.Value));
       
    }

    private void EditDirectory(int DirectoryID)
    {

        Directorytbl myDirectory;
        myDirectory = clsDirectory.getDirectory(DirectoryID);


        EditorEdit.Text = HttpUtility.HtmlDecode(myDirectory.DirectoryPage.ToString());


    }

    //for edit
    protected void ClearButtonEdit_Click(object sender, EventArgs e)
    {
        EditorEdit.Text = String.Empty;
       
        MultiView1.ActiveViewIndex = 2;
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

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "dr01.html";




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
                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Directory</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'><script src='js/jquery-latest.min.js'></script><link rel='stylesheet' href='css/orangebox.css' type='text/css' /></head><body><div id='wrapper'><div id='dt_summ'>{0}</div></div></body></html>", TextPreviewEdit.InnerText));
            }
        }

 


        loadDirectory(Convert.ToInt32(HiddenFieldDirectoryID.Value));

       // Response.Redirect("PresentationMaster.aspx", false);
    }
    protected void BtnCancelEdit_Click(object sender, System.EventArgs e)
    {
       // Response.Redirect("PresentationMaster.aspx", false);
    }

    protected void btnCancelEditDirectory_Click(object sender, EventArgs e)
    {
      //  Response.Redirect("PresentationMaster.aspx", false);
    }
}