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
public partial class Master_Agenda : System.Web.UI.Page
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

        //for Agenda
        DataView dvSql = (DataView)dsAgenda.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView drvSql in dvSql)
        {

            int aID = Convert.ToInt32(drvSql["AgendaID"].ToString());
            if ((aID == 0))
            {
                MultiView1.ActiveViewIndex = 0;

                
            }
            else
            {

                MultiView1.ActiveViewIndex = 1;


                loadAgenda(aID);
                HiddenFieldAgendaID.Value = Convert.ToInt32(aID).ToString();
 
            }

        }

       
    }
    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        //Response.Redirect("PresentationMaster.aspx", false);
    }
    protected void BtnSave_Click(object sender, System.EventArgs e)
    {

        //save Agenda
        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        PreviewButton_Click(null, EventArgs.Empty);
        string UserSignature = TextPreview.InnerHtml;

        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertAgenda";
            cmd.Parameters.Add("@AgendaPage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature);
            cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = PresentationID;
            cmd.ExecuteNonQuery();
        }
        c.Close();



        //FileInfo f = new FileInfo(MapPath("~/") + "2.html");
        //TextWriter tw = f.CreateText();
        //tw.Write(string.Format("<head><title></title></head><body >{0}</body></html>", TextPreview.InnerHtml));
        //tw.Close();

        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;


        Directory.CreateDirectory(Server.MapPath(pathToCreate));

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "ag01.html";




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
                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Agenda</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'><script src='js/jquery-latest.min.js'></script><link rel='stylesheet' href='css/orangebox.css' type='text/css' /></head><body><div id='wrapper'><div id='dt_summ'>{0}</div></div></body></html>", TextPreview.InnerText));
            }
        }



      //  Response.Redirect("PresentationMaster.aspx", false);
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

   

    //private void loadCover(int CoverID)
    //{
    //    Cover myCover;
    //    myCover = clscover.getCover(CoverID);
    //    DivContent.InnerHtml = HttpUtility.HtmlDecode(myCover.CoverPage.ToString());

    //}

    private void loadAgenda(int AgendaID)
    {
        Agenda myAgenda;
        myAgenda = clsAgenda.getAgenda(AgendaID);
        DivContent.InnerHtml = HttpUtility.HtmlDecode(myAgenda.AgendaPage.ToString());

    }
    protected void btnEditAgenda_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        EditAgenda(Convert.ToInt32(HiddenFieldAgendaID.Value));
       
    }

    private void EditAgenda(int AgendaID)
    {

        Agenda myAgenda;
        myAgenda = clsAgenda.getAgenda(AgendaID);


        EditorEdit.Text = HttpUtility.HtmlDecode(myAgenda.AgendaPage.ToString());


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

        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateAgenda";
            cmd.Parameters.Add("@AgendaPage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature);
            cmd.Parameters.Add("@AgendaID", SqlDbType.Int).Value = HiddenFieldAgendaID.Value;
            cmd.ExecuteNonQuery();
        }
        c.Close();

        

        //FileInfo f = new FileInfo(MapPath("~/") + "2.html");
        //TextWriter tw = f.CreateText();
        //tw.Write(string.Format("<head><title></title></head><body >{0}</body></html>", TextPreviewEdit.InnerHtml));
        //tw.Close();


        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;


        Directory.CreateDirectory(Server.MapPath(pathToCreate));

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "ag01.html";




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
                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Agenda</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'><script src='js/jquery-latest.min.js'></script><link rel='stylesheet' href='css/orangebox.css' type='text/css' /></head><body><div id='wrapper'><div id='dt_summ'>{0}</div></div></body></html>", TextPreviewEdit.InnerText));
            }
        }


       // Response.Redirect("PresentationMaster.aspx", false);
    }
    protected void BtnCancelEdit_Click(object sender, System.EventArgs e)
    {
        //Response.Redirect("PresentationMaster.aspx", false);
    }

    protected void btnCancelEditAgenda_Click(object sender, EventArgs e)
    {
        //Response.Redirect("PresentationMaster.aspx", false);
    }
}