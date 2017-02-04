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
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.Services;

public partial class TimeTable : System.Web.UI.Page
{
    [WebMethod]
    public static string Process(string TimeTablePage, int PresentationID, int TRow, int TCol)
    {

        SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {

            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertTimeTable";
            cmd.Parameters.Add("@TimeTablePage", SqlDbType.Text).Value = TimeTablePage;
            cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = System.Convert.ToInt32(PresentationID);
            cmd.Parameters.Add("@TRow", SqlDbType.Int).Value = System.Convert.ToInt32(TRow);
            cmd.Parameters.Add("@TCol", SqlDbType.Int).Value = System.Convert.ToInt32(TCol);
            cmd.ExecuteNonQuery();

        }
        c.Close();

        string result = "success!";
        return result;
    }
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    int PresentationID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
            DataView dvSql = (DataView)dsTimeTable.Select(DataSourceSelectArguments.Empty);
            foreach (DataRowView drvSql in dvSql)
            {

                int tID = Convert.ToInt32(drvSql["TimeTableID"].ToString());
                if ((tID == 0))
                {
                 

                    btnSave.Visible = true;
                    btnSaveEdit.Visible = false;
                  
                }
                else
                {

                    btnSave.Visible = false;
                    btnSaveEdit.Visible = true;


                    loadTimeTable(tID);
                    HiddenFieldTimeTableID.Value = Convert.ToInt32(tID).ToString();

                
                }

            }
        }


       
    }
    private void loadTimeTable(int TimeTableID)
    {
        TimeTableclass myTimeTable;
        myTimeTable = clstimeTable.getTimeTable(TimeTableID);
        HiddenFieldTimeTableID.Value = myTimeTable.TimeTableID.ToString();
     //   //txtDefaultHtmlAreaEdit.InnerHtml = myTimeTable.TimeTablePage.ToString();
     ////   HtmlEditorEdit.Text = myTimeTable.TimeTablePage.ToString();
     //   TextPreviewEdit.InnerHtml = myTimeTable.TimeTablePage.ToString();
     //   txtRowEdit.Text = myTimeTable.TRow.ToString();
     //   txtColumnEdit.Text = myTimeTable.TCol.ToString();
     //   // Editor.Text = myTimeTable.TimeTablePage.ToString();

        Editor2.Html = myTimeTable.TimeTablePage.ToString();

    }

   
    protected void btnSave_Click(object sender, EventArgs e)
    {


          //  PreviewButton_Click(null, EventArgs.Empty);

        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;
        Directory.CreateDirectory(Server.MapPath(pathToCreate));
        string fileLoc = Server.MapPath(pathToCreate) + "/" + "tt01.html";





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


                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Timetable</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'></head><body><div class='IpadContent'>{0}</div> </body></html>", Editor2.Html));



            }
        }







       PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));



        //Literal1.Text  = TextPreview.InnerHtml;

        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {



            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertTimeTable";
            cmd.Parameters.Add("@TimeTablePage", SqlDbType.Text).Value = Editor2.Html;
            cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = System.Convert.ToInt32(PresentationID);
            cmd.Parameters.Add("@TRow", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@TCol", SqlDbType.Int).Value = 0;
            cmd.ExecuteNonQuery();

        }
        c.Close();

     


    }
    //protected void btnCancel_Click(object sender, EventArgs e)
    //{
    //    //Response.Redirect("PresentationMaster.aspx", false);
    //}
    protected void btnUpdate_Click(object sender, EventArgs e)
    {




        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));




        //PreviewButtonEdit_Click(null, EventArgs.Empty);




        string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;
        Directory.CreateDirectory(Server.MapPath(pathToCreate));
        string fileLoc = Server.MapPath(pathToCreate) + "/" + "tt01.html";


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


                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Timetable</title><link href='prodstyle.css' rel='stylesheet' type='text/css' media='screen'></head><body><div id='wrapper'><div id='tableContainer'>{0}</div></div></body></html>", Editor2.Html));



            }
        }

    //    Label1.Text = fileLoc;


        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateTimeTable";


            cmd.Parameters.Add("@TimeTablePage", SqlDbType.VarChar).Value = Editor2.Html;

            cmd.Parameters.Add("@TRow", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@TCol", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@TimeTableID", SqlDbType.Int).Value = HiddenFieldTimeTableID.Value;
            cmd.ExecuteNonQuery();
        }
        c.Close();

   


   

       // Response.Redirect("PresentationMaster.aspx", false);
    }
    //protected void btnCancelEdit_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("PresentationMaster.aspx", false);
    //}
    protected void btnInsertEdit_Click(object sender, EventArgs e)
    {
        //int RowCount = Convert.ToInt32(txtRowEdit.Text);//dt.Rows.Count;
        //int ColCount = Convert.ToInt32(txtColumnEdit.Text); //dt.Columns.Count;





        //System.Web.UI.HtmlControls.HtmlTable tbl = new System.Web.UI.HtmlControls.HtmlTable();
        //tbl.Border = 1;
        //tbl.Width = "100%";
        //tbl.Height = "100%";




        //System.Web.UI.HtmlControls.HtmlTableRow tr = new System.Web.UI.HtmlControls.HtmlTableRow();



        //for (int i = 0; i < RowCount; i++)
        //{
        //    tr = new System.Web.UI.HtmlControls.HtmlTableRow();
        //    for (int j = 0; j < ColCount; j++)

        //        tr.Cells.Add(new HtmlTableCell());

        //    tbl.Rows.Add(tr);
        //}


        //string smsg = "";



        //using (System.IO.StringWriter writer = new System.IO.StringWriter())
        //{
        //    using (HtmlTextWriter html = new HtmlTextWriter(writer))
        //        tbl.RenderControl(html);


        //    smsg = writer.ToString();
        //}

        ////HtmlEditorEdit.HtmlModeEditable = true;
        ////HtmlEditorEdit.Text = "<tbody>" + smsg + "</tbody>";


        //TextPreviewEdit.InnerHtml = "<table class='activity_datatable' width='100%' border='2px' cellspacing='0' cellpadding='8'><tr><th width='55%'>Title</th><th width='23%'>Name</th></tr>" + smsg + "</table>";

    }
    protected void btnInsertAdd_Click(object sender, EventArgs e)
    {
        //int RowCount = Convert.ToInt32(txtRow.Text);//dt.Rows.Count;
        //int ColCount = Convert.ToInt32(txtColumn.Text); //dt.Columns.Count;





        //System.Web.UI.HtmlControls.HtmlTable tbl = new System.Web.UI.HtmlControls.HtmlTable();
        //tbl.Border = 1;
        //tbl.Width = "100%";
        //tbl.Height = "100%";



        //System.Web.UI.HtmlControls.HtmlTableRow tr = new System.Web.UI.HtmlControls.HtmlTableRow();





        //// create the data rows
        //for (int i = 0; i < RowCount; i++)
        //{
        //    tr = new System.Web.UI.HtmlControls.HtmlTableRow();
        //    for (int j = 0; j < ColCount; j++)

        //        tr.Cells.Add(new HtmlTableCell());

        //    tbl.Rows.Add(tr);
        //}


        //string smsg = "";



        //using (System.IO.StringWriter writer = new System.IO.StringWriter())
        //{
        //    using (HtmlTextWriter html = new HtmlTextWriter(writer))
        //        tbl.RenderControl(html);


        //    smsg = writer.ToString();
        //}




        ////PreviewButton_Click(null, EventArgs.Empty);

        ////Editor.HtmlModeEditable = true;
        ////Editor.Text = "<tbody>" + smsg + "</tbody>";


        //TextPreview.InnerHtml = "<table class='activity_datatable' width='100%' border='2px' cellspacing='0' cellpadding='8'><tr><th width='55%'>Title</th><th width='23%'>Name</th></tr>" + smsg  + "</table>";

      
    }
   
    
    
}
