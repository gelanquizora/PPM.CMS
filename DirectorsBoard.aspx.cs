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

public partial class Master_DirectorsBoard : System.Web.UI.Page
{
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());


    private string Contents = ConfigurationManager.AppSettings["Contents"].ToString();

    private string repository = ConfigurationManager.AppSettings["repository"].ToString();
    private string URL = ConfigurationManager.AppSettings["URL"].ToString();

    int PresentationID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            SetDefaultView();
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        }

        //for DirectorsBoard
        DataView dvSql = (DataView)dsDirectorsBoard.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView drvSql in dvSql)
        {

            int bID = Convert.ToInt32(drvSql["BoardID"].ToString());
            if ((bID == 0))
            {
                MultiView1.ActiveViewIndex = 0;

                lblPresentation.Text = drvSql["Title"].ToString();
                lblAction.Text = "New Director's Treatment Board";
            }
            else
            {

                MultiView1.ActiveViewIndex = 1;



                HiddenFieldDirectorsBoardID.Value = Convert.ToInt32(bID).ToString();

                lblPresentation.Text = drvSql["Title"].ToString();
                lblAction.Text = "View Director's Treatment Board";

                loadDirectorBoard(Convert.ToInt32(HiddenFieldDirectorsBoardID.Value));
            }

        }


    }
    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        //Response.Redirect("PresentationMaster.aspx", false);
    }
    protected void BtnSave_Click(object sender, System.EventArgs e)
    {

        //save Director
        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        PreviewButton_Click(null, EventArgs.Empty);
        string UserSignature = TextPreview.InnerHtml;

   

        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertDirectorsBoard";
            cmd.Parameters.Add("@BoardPage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature);           
            cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = PresentationID;
            cmd.ExecuteNonQuery();
        }
        c.Close();



        //FileInfo f = new FileInfo(MapPath("~/") + "2.html");
        //TextWriter tw = f.CreateText();
        //tw.Write(string.Format("<head><title></title></head><body >{0}</body></html>", TextPreview.InnerHtml));
        //tw.Close();

        string pathToCreate = "~/BoardPages/" + PresentationID;


        Directory.CreateDirectory(Server.MapPath(pathToCreate));

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "4.html";




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
                sw.Write(string.Format("<head><title></title></head><body >{0}</body></html>", TextPreview.InnerText));
            }
        }




      //  Response.Redirect("PresentationGridMaster.aspx", false);
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




    private void loadDirectorBoard(int BoardID)
    {
        DirectorsBoard myDirectorsBoard;
        myDirectorsBoard = clsdirectorsBoard.getDirectorsBoard(BoardID);
        DivContent.InnerHtml = HttpUtility.HtmlDecode(myDirectorsBoard.BoardPage.ToString());

    }
    protected void btnEditDirectorsBoard_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        EditDirectorBoard(Convert.ToInt32(HiddenFieldDirectorsBoardID.Value));
        lblAction.Text = "Edit Director's Board";

    
    }

    private void EditDirectorBoard(int BoardID)
    {

        DirectorsBoard myDirectorsBoard;
        myDirectorsBoard = clsdirectorsBoard.getDirectorsBoard(BoardID);


        EditorEdit.Text = HttpUtility.HtmlDecode(myDirectorsBoard.BoardPage.ToString());


    }

    //for edit
    protected void ClearButtonEdit_Click(object sender, EventArgs e)
    {
        EditorEdit.Text = String.Empty;
        lblAction.Text = "Edit Director's Board";
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
        string BoardDescription = txtBoardDescriptionEdit.Text;

        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateDirectorsBoard";
            cmd.Parameters.Add("@BoardPage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature);
            cmd.Parameters.Add("@BoardDescription", SqlDbType.VarChar).Value = System.Convert.ToString(BoardDescription);
            cmd.Parameters.Add("@BoardID", SqlDbType.Int).Value = HiddenFieldDirectorsBoardID.Value;
            cmd.ExecuteNonQuery();
        }
        c.Close();



        //FileInfo f = new FileInfo(MapPath("~/") + "2.html");
        //TextWriter tw = f.CreateText();
        //tw.Write(string.Format("<head><title></title></head><body >{0}</body></html>", TextPreviewEdit.InnerHtml));
        //tw.Close();


        string pathToCreate = "~/BoardPages/" + PresentationID;


        //Directory.CreateDirectory(Server.MapPath(pathToCreate));

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "4.html";




        if (File.Exists(fileLoc))
        {
            using (StreamWriter sw = new StreamWriter(fileLoc))
            {
                sw.Flush();
                sw.Write(string.Format("<head><title></title></head><body >{0}</body></html>", TextPreviewEdit.InnerText));
            }
        }

     //   Response.Redirect("PresentationMaster.aspx", false);
    }
    protected void BtnCancelEdit_Click(object sender, System.EventArgs e)
    {
       // Response.Redirect("PresentationMaster.aspx", false);
    }

    protected void btnCancelEditDirectorsBoard_Click(object sender, EventArgs e)
    {
      //  Response.Redirect("PresentationMaster.aspx", false);
    }

    protected void UploadNew_Click(object sender, EventArgs e)
    {


        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        int BoardID = System.Convert.ToInt32(HiddenFieldDirectorsBoardID.Value);
        Response.Redirect("DirectorsVideos.aspx?BoardID=" + BoardID.ToString() + "&PresentationID=" + PresentationID.ToString(), false);


    }
}