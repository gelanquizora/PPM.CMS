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

public partial class MoodandTone : System.Web.UI.Page
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

        //for Attendee
        DataView dvSql = (DataView)dsModeAndTone.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView drvSql in dvSql)
        {

            int mID = Convert.ToInt32(drvSql["ModeToneID"].ToString());
            if ((mID == 0))
            {
                MultiView1.ActiveViewIndex = 0;
 
            }
            else
            {

                MultiView1.ActiveViewIndex = 1;



                HiddenFieldModeAndToneID.Value = Convert.ToInt32(mID).ToString();
 

                loadModeandTone(Convert.ToInt32(HiddenFieldModeAndToneID.Value));
            }

        }


    }
    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
       // Response.Redirect("PresentationMaster.aspx", false);
    }
    protected void BtnSave_Click(object sender, System.EventArgs e)
    {

        //save Attendee
        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        PreviewButton_Click(null, EventArgs.Empty);
        string UserSignature = TextPreview.InnerHtml;

        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertModeTone";
            cmd.Parameters.Add("@ModeTonePage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature);
            cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = PresentationID;
            cmd.ExecuteNonQuery();
        }
        c.Close();



        //FileInfo f = new FileInfo(MapPath("~/") + "2.html");
        //TextWriter tw = f.CreateText();
        //tw.Write(string.Format("<head><title></title></head><body >{0}</body></html>", TextPreview.InnerHtml));
        //tw.Close();

        //string pathToCreate = "~/ModeTonePages/" + PresentationID;


        //Directory.CreateDirectory(Server.MapPath(pathToCreate));

        //string fileLoc = Server.MapPath(pathToCreate) + "/" + "3.html";

        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;


        Directory.CreateDirectory(Server.MapPath(pathToCreate));

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "mt01.html";


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
                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Director's Treatment Summary</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'><script src='js/jquery-latest.min.js'></script><link rel='stylesheet' href='css/orangebox.css' type='text/css' /></head><body><div id='wrapper'><div id='dt_summ'>{0}</div></div></body></html>", TextPreview.InnerText));
            }
        }




       
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
    private void loadModeandTone(int ModeToneID)
    {
        ModeTone myModeTone;
        myModeTone = clsmodeTone.getModeTone(ModeToneID);
        DivContent.InnerHtml = HttpUtility.HtmlDecode(myModeTone.ModeTonePage.ToString());

    }
    protected void btnEditModeAndTone_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        EditModeandTone(Convert.ToInt32(HiddenFieldModeAndToneID.Value));
         
    }

    private void EditModeandTone(int ModeToneID)
    {

        ModeTone myModeTone;
        myModeTone = clsmodeTone.getModeTone(ModeToneID);


        EditorEdit.Text = HttpUtility.HtmlDecode(myModeTone.ModeTonePage.ToString());


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
            cmd.CommandText = "sp_UpdateModeTone";
            cmd.Parameters.Add("@ModeTonePage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature);
            cmd.Parameters.Add("@ModeToneID", SqlDbType.Int).Value = HiddenFieldModeAndToneID.Value;
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

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "mt01.html";




        if (File.Exists(fileLoc))
        {
            using (StreamWriter sw = new StreamWriter(fileLoc))
            {
                sw.Flush();
                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Director's Treatment Summary</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'><script src='js/jquery-latest.min.js'></script><link rel='stylesheet' href='css/orangebox.css' type='text/css' /></head><body><div id='wrapper'><div id='dt_summ'>{0}</div></div></body></html>", TextPreviewEdit.InnerText));
            }
        }

 
    }
    protected void BtnCancelEdit_Click(object sender, System.EventArgs e)
    {
        //Response.Redirect("PresentationMaster.aspx", false);
    }

    protected void btnCancelEditModeAndTone_Click(object sender, EventArgs e)
    {
      //  Response.Redirect("PresentationMaster.aspx", false);
    }
}