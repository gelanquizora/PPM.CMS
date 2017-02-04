using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

public partial class DeckAgencyBoard : System.Web.UI.Page
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

            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
            string _clientID = "0";
            if (!string.IsNullOrEmpty(Request.QueryString["ClientID"]))
                _clientID = Request.QueryString["ClientID"].ToString();


            string param = "PresentationID=" + PresentationID.ToString() + "&ClientID=" + _clientID.ToString();
            btnBack.Attributes["href"] = "ProjectInside.aspx?" + param;
        }




        //for Attendee
        DataView dvSql = (DataView)dsAgency.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView drvSql in dvSql)
        {

            int aID = Convert.ToInt32(drvSql["AgencyID"].ToString());
            if ((aID == 0))
            {
                btnSave.Visible = true;
                lblErrorAdd.Text = "No image found.";
            }
            else
            {
                lblErrorAdd.Text = "";
                BtnUpdate.Visible = true;
                HiddenFieldAgencyID.Value = Convert.ToInt32(aID).ToString();
                lnlPreview.Attributes["href"] = "Preview/AgencyBoard.aspx?ID=" + aID;

                EditAgency(Convert.ToInt32(HiddenFieldAgencyID.Value));
                loadAgency(Convert.ToInt32(HiddenFieldAgencyID.Value));
            }

        }


    }




    protected void BtnSaveAgency_Click(object sender, System.EventArgs e)
    {

        if (!FileUpload2.HasFile)
        {
            lblErrorAdd.Text = "Please choose image file to upload";
            return;
        }

        try
        {
            string strFileNameWithPath = FileUpload2.PostedFile.FileName;

            string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);

            //if (strExtensionName.Equals(".mp4"))
            //{
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

            string FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);

            FileInfo fi = new FileInfo(FileName);
            string ext = fi.Extension;
            FileName = Guid.NewGuid().ToString() + ext;



            string pathToCreate1 = "~/" + Session["CompanyID"] + "/" + PresentationID + "/AgengyBoardFile";
            string strFile = "";
            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/AgengyBoardFile/" + FileName);
            Directory.CreateDirectory(Server.MapPath(pathToCreate1));
            FileUpload2.SaveAs(strFile);

            string ImgFile = "<img src='AgengyBoardFile/" + FileName + "' alt=''   style='margin: auto;position: absolute;top: 0; left: 0; bottom: 0; right: 0;' /> ";
            string html = string.Format("<!DOCTYPE html><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><meta name='viewport' content='width=device-width' /><title>Agency Board</title></head><body>{0}</body></html>", ImgFile);

            System.Drawing.Image objImage = System.Drawing.Image.FromFile(strFile);
            int width = objImage.Width;
            int height = objImage.Height; 

            if (height > 1020 || width > 768)
            {
                ImgFile = "<img src='AgengyBoardFile/" + FileName + "' alt=''  /> ";
                html = string.Format("<!DOCTYPE html><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><meta name='viewport' content='width=device-width' /><title>Agency Board</title><link href='style.css' rel='stylesheet' type='text/css' media='screen' /></head><body><div class='DivToScroll'  ><div class='DivWithScroll'  >{0}</div></div></body></html>", ImgFile);
                

            }
       



            string fullpath = Session["CompanyID"] + "/" + PresentationID + "/AgengyBoardFile/" + FileName;

            string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;
            Directory.CreateDirectory(Server.MapPath(pathToCreate));
            string fileLoc = Server.MapPath(pathToCreate) + "/" + "ab01.html";

         

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
                    sw.Write(html);




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





            loadAgency(Convert.ToInt32(HiddenFieldAgencyID.Value));
            btnSave.Visible = false;
            BtnUpdate.Visible = true;
        }
        catch (Exception ex)
        {
        }



    }


    private void loadAgency(int AgencyID)
    {
        AgencyBoard myAgencyBoard;
        myAgencyBoard = clsagencyBoard.getAgencyBoard(AgencyID);
        HiddenFieldAgencyID.Value = myAgencyBoard.AgencyID.ToString();
       // lblFileView.Text = myAgencyBoard.ImageFile.ToString();


        if (String.IsNullOrEmpty(myAgencyBoard.ImageFile.ToString()))
        {
            Image1.ImageUrl = "";
          
            lblErrorAdd.Text = "No image found.";
        }
        else
        {
            lblErrorAdd.Text = "";
             Image1.ImageUrl = URLBasic + "/" + myAgencyBoard.ImagePath.ToString();
            Image1.AlternateText = URLBasic + "/" + myAgencyBoard.ImagePath.ToString();
        }

        lnlPreview.Attributes["href"] = "Preview/AgencyBoard.aspx?ID=" + HiddenFieldAgencyID.Value;

    }


    private void EditAgency(int AgencyID)
    {




        AgencyBoard myAgencyBoard;
        myAgencyBoard = clsagencyBoard.getAgencyBoard(AgencyID);



        HiddenFieldAgencyID.Value = myAgencyBoard.AgencyID.ToString();
        lblFileEdit.Text = myAgencyBoard.ImageFile.ToString();


    }







    protected void BtnUpdateAgency_Click(object sender, EventArgs e)
    {

        if (!FileUpload2.HasFile)
        {
            lblErrorAdd.Text = "Please choose image file to upload";
            return;
        }


        try
        {
            string strFileNameWithPath = FileUpload2.PostedFile.FileName;

            string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);




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


            //Get Image Size

            System.Drawing.Image objImage = System.Drawing.Image.FromFile(strFile);
            int width = objImage.Width;
            int height = objImage.Height;


            string ImgFile = "<img src='AgengyBoardFile/" + FileName + "' alt=''   style='margin: auto;position: absolute;top: 0; left: 0; bottom: 0; right: 0;' /> ";
            string html = string.Format("<!DOCTYPE html><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><meta name='viewport' content='width=device-width' /><title>Agency Board</title></head><body>{0}</body></html>", ImgFile);

            if (height > 1020 || width > 768)
            {
                ImgFile = "<img src='AgengyBoardFile/" + FileName + "' alt=''  /> ";
                //html =  string.Format("<!DOCTYPE html><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><meta name='viewport' content='width=device-width' /><title>Agency Board</title><style>.DivToScroll{padding: 10px 7px 5px;} .DivWithScroll{height:768px;overflow:scroll;}</style></head><body><div class='DivToScroll'  ><div class='DivWithScroll'  >{0}</div></div></body></html>", ImgFile);
                html = string.Format("<!DOCTYPE html><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><meta name='viewport' content='width=device-width' /><title>Agency Board</title><link href='style.css' rel='stylesheet' type='text/css' media='screen' /></head><body><div class='DivToScroll'  ><div class='DivWithScroll'  >{0}</div></div></body></html>", ImgFile);
                lblErrorAdd.Text = html;

            }
       
            string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;
            Directory.CreateDirectory(Server.MapPath(pathToCreate));
            string fileLoc = Server.MapPath(pathToCreate) + "/" + "ab01.html";

         

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
                    sw.Write(html);

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


            loadAgency(Convert.ToInt32(HiddenFieldAgencyID.Value));
            btnSave.Visible = false;
            BtnUpdate.Visible = true;
        }
        catch (Exception ex)
        {
            lblErrorAdd.Text = ex.Message;
        }

    }
}