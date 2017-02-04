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
public partial class Master_Agency : System.Web.UI.Page
{
    private string Contents = ConfigurationManager.AppSettings["Contents"].ToString();

    private string repository = ConfigurationManager.AppSettings["repository"].ToString();
    private string URL = ConfigurationManager.AppSettings["URL"].ToString();
    private string URLBasic = ConfigurationManager.AppSettings["URLBasic"].ToString();

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
        DataView dvSql = (DataView)dsAgency.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView drvSql in dvSql)
        {

            int aID = Convert.ToInt32(drvSql["AgencyID"].ToString());
            if ((aID == 0))
            {
                MultiView1.ActiveViewIndex = 0;
            
            }
            else
            {

                MultiView1.ActiveViewIndex = 1;



                HiddenFieldAgencyID.Value = Convert.ToInt32(aID).ToString();

             

                loadAgency(Convert.ToInt32(HiddenFieldAgencyID.Value));
            }

        }


    }
    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
       // Response.Redirect("PresentationMaster.aspx", false);
    }


    //protected void PreviewButton_Click(object sender, EventArgs e)
    //{
    //    switch (Selections.SelectedValue)
    //    {
    //        case "Formatted":
    //            TextPreview.InnerHtml = Editor.Text;
    //            break;
    //        case "Html":
    //            TextPreview.InnerText = Editor.Text;
    //            break;
    //        default:
    //            break;
    //    }
    //}
    protected void BtnSaveAgency_Click(object sender, System.EventArgs e)
    {

         string strFileNameWithPath = FileUpload1.PostedFile.FileName;

        string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
        if (FileUpload1.HasFile)
        {
            //if (strExtensionName.Equals(".mp4"))
            //{
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));  

              string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

              FileInfo fi = new FileInfo(FileName);
              string ext = fi.Extension;
              FileName =  Guid.NewGuid().ToString() + ext;



              string pathToCreate1 = "~/" + Session["CompanyID"] + "/"+ PresentationID + "/AgengyBoardFile";
              string strFile = "";
              strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/"+ PresentationID + "/AgengyBoardFile/" + FileName);
              Directory.CreateDirectory(Server.MapPath(pathToCreate1));
              FileUpload1.SaveAs(strFile);
              string fullpath = Session["CompanyID"] + "/" + PresentationID + "/AgengyBoardFile/" + FileName;
           
            string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;
            Directory.CreateDirectory(Server.MapPath(pathToCreate));
            string fileLoc = Server.MapPath(pathToCreate) + "/" + "ab01.html";

        string ImgFile = "<img src='AgengyBoardFile/" + FileName + "' alt=''>";


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
                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Director's Treatment Summary</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'><script src='js/jquery-latest.min.js'></script><link rel='stylesheet' href='css/orangebox.css' type='text/css' /></head><body><div id='wrapper'><div id='dt_summ'>{0}</div></div></body></html>", ImgFile));
           
            
            
            
            }
        }

     

            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_InsertAgencyBoard";
                cmd.Parameters.Add("@ImageFile", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
                cmd.Parameters.Add("@ImagePath", SqlDbType.VarChar).Value = System.Convert.ToString(fullpath);
                cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = Convert.ToInt32(PresentationID);
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
                cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);

                cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
                cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);

                //cmd.Parameters.Add("@ID");
                //cmd.Parameters["@ID"].Direction = ParameterDirection.Output;

                var outParameter = new SqlParameter();

                outParameter.ParameterName = "@ID"; 

                outParameter.Direction = ParameterDirection.Output;

                outParameter.DbType = DbType.Int32; //DbType.Int32;

                outParameter.Size = 2000;

                cmd.Parameters.Add(outParameter);




                cmd.ExecuteNonQuery();

                HiddenFieldAgencyID.Value = cmd.Parameters["@ID"].Value.ToString(); 
            }
            c.Close();
        

            

            //}
            //else
            //{
            //    lblErrorAdd.Text = "cannot accept this file type";
            //}

         //   Response.Redirect("PresentationMaster.aspx", false);
            MultiView1.ActiveViewIndex = 1;
            loadAgency(Convert.ToInt32(HiddenFieldAgencyID.Value));
        }
        else
        {
            lblErrorAdd.Text = "Please choose image file to upload";
        }
    }
 
    private void SetDefaultView()
    {
        MultiView1.ActiveViewIndex = 0;
    }
    private void loadAgency(int AgencyID)
    {
        AgencyBoard myAgencyBoard;
        myAgencyBoard = clsagencyBoard.getAgencyBoard(AgencyID);
        HiddenFieldAgencyID.Value = myAgencyBoard.AgencyID.ToString();
        lblFileView.Text = myAgencyBoard.ImageFile.ToString();


        if (String.IsNullOrEmpty(myAgencyBoard.ImageFile.ToString()))
        {
            Image1.ImageUrl = "";
            lblFileView.Text = "";
        }
        else
        {
            Image1.ImageUrl = URLBasic + "/" + myAgencyBoard.ImagePath.ToString();
            Image1.AlternateText = URLBasic +"/"+ myAgencyBoard.ImagePath.ToString();
        }

    }
    protected void btnEditAgency_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        EditAgency(Convert.ToInt32(HiddenFieldAgencyID.Value));
       
    }

    private void EditAgency(int AgencyID)
    {

       


        AgencyBoard myAgencyBoard;
        myAgencyBoard = clsagencyBoard.getAgencyBoard(AgencyID);



        HiddenFieldAgencyID.Value = myAgencyBoard.AgencyID.ToString();
        lblFileEdit.Text = myAgencyBoard.ImageFile.ToString();


    }

   
   
    protected void BtnUpdateEdit_Click(object sender, System.EventArgs e)
    {
       


     

       

       // Response.Redirect("PresentationMaster.aspx", false);
    }
    protected void BtnCancelEdit_Click(object sender, System.EventArgs e)
    {
       // Response.Redirect("PresentationMaster.aspx", false);
    }

    protected void btnCancelEditAttendee_Click(object sender, EventArgs e)
    {
       // Response.Redirect("PresentationMaster.aspx", false);
    }

    protected void btnCancelEditAgency_Click(object sender, EventArgs e)
    {
       // Response.Redirect("PresentationMaster.aspx", false);
    }

   
    protected void BtnUpdateAgency_Click(object sender, EventArgs e)
    {
        string strFileNameWithPath = FileUpload2.PostedFile.FileName;

        string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
        if (FileUpload2.HasFile)
        {
            //if (strExtensionName.Equals(".mp4"))
            //{
            //PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

            //string FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);

            //string pathToCreate1 = "~/" + Session["CompanyID"] + "/" + PresentationID + "/AgengyBoardFile";
            //string strFile = "";
            //strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/AgengyBoardFile/" + FileName);
            //Directory.CreateDirectory(Server.MapPath(pathToCreate1));

            //string fullpath = Session["CompanyID"] + "/" + PresentationID + "/AgengyBoardFile/" + FileName;
            //FileUpload1.SaveAs(strFile);



            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

            string FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
            FileInfo fi = new FileInfo(FileName);
            string ext = fi.Extension;
            FileName = Guid.NewGuid().ToString() + ext;
             
            string pathToCreate1 = "~/" + Session["CompanyID"] + "/" + PresentationID + "/AgengyBoardFile";
            string strFile = "";
            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/AgengyBoardFile/" + FileName);
            Directory.CreateDirectory(Server.MapPath(pathToCreate1));
            string fullpath = Session["CompanyID"] + "/" + PresentationID + "/AgengyBoardFile/" + FileName;

            FileUpload2.SaveAs(strFile);


         

            string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;
            Directory.CreateDirectory(Server.MapPath(pathToCreate));
            string fileLoc = Server.MapPath(pathToCreate) + "/" + "ab01.html";

            string ImgFile = "<img src='AgengyBoardFile/" + FileName + "' alt=''>";

            System.IO.File.Delete(fileLoc);


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
                    sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Director's Treatment Summary</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'><script src='js/jquery-latest.min.js'></script><link rel='stylesheet' href='css/orangebox.css' type='text/css' /></head><body><div id='wrapper'><div id='dt_summ'>{0}</div></div></body></html>", ImgFile));
                }
            }
 

            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UpdateAgencyBoardFile";
                cmd.Parameters.Add("@ImageFile", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
                cmd.Parameters.Add("@ImagePath", SqlDbType.VarChar).Value = System.Convert.ToString(fullpath);
                cmd.Parameters.Add("@AgencyID", SqlDbType.Int).Value = Convert.ToInt32(HiddenFieldAgencyID.Value);
                cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
                cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);


                cmd.ExecuteNonQuery();
            }
            c.Close();




          //  Response.Redirect("PresentationMaster.aspx", false);

            //}
            //else
            //{
            //    lblErrorAdd.Text = "cannot accept this file type";
            //}
            loadAgency(Convert.ToInt32(HiddenFieldAgencyID.Value));
        }
        else
        {
            lblErrorAdd.Text = "Please choose video file to upload";
        }
    }
}