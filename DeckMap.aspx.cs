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

public partial class DeckMap : System.Web.UI.Page
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
            string _clientID = "0";
            if (!string.IsNullOrEmpty(Request.QueryString["ClientID"]))
                _clientID = Request.QueryString["ClientID"].ToString();


            string param = "PresentationID=" + PresentationID.ToString() + "&ClientID=" + _clientID.ToString();
            btnBack.Attributes["href"] = "ProjectInside.aspx?" + param;
        }

        //for Attendee
        DataView dvSql = (DataView)dsMap.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView drvSql in dvSql)
        {

            int aID = Convert.ToInt32(drvSql["MapID"].ToString());

           
            if ((aID == 0))
            {

                MultiView1.ActiveViewIndex = 0;

            }
            else
            {

                MultiView1.ActiveViewIndex = 0;



                HiddenFieldMapID.Value = Convert.ToInt32(aID).ToString();



                loadMap(Convert.ToInt32(HiddenFieldMapID.Value));
            }

        }


    }
    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        // Response.Redirect("PresentationMaster.aspx", false);
    }


  
    protected void BtnSaveAgency_Click(object sender, System.EventArgs e)
    {


        string strFileNameWithPath = FileUpload2.PostedFile.FileName;

        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
        string rep = Session["CompanyID"] + "/" + PresentationID + "/repository/";

        string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
        if (FileUpload2.HasFile)
        {
       


            string FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
            FileInfo fi = new FileInfo(FileName);
            string ext = fi.Extension;
            FileName = Guid.NewGuid().ToString() + ext;


            string pathToCreate1 = "~/" + Session["CompanyID"] + "/" + PresentationID + "/repository";
            string strFile = "";
            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
            Directory.CreateDirectory(Server.MapPath(pathToCreate1));
            FileUpload2.SaveAs(strFile);
            string fullpath = Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName;

            string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;
            Directory.CreateDirectory(Server.MapPath(pathToCreate));
            string fileLoc = Server.MapPath(pathToCreate) + "/" + "mp01.html";


       



            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                

                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_InsertMap";
                cmd.Parameters.Add("@MapFile", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
                cmd.Parameters.Add("@MapPath", SqlDbType.VarChar).Value = System.Convert.ToString(rep + FileName);
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

                HiddenFieldMapID.Value = cmd.Parameters["@ID"].Value.ToString();


            }
            c.Close();

            string template = "";
            //Bind
            DataView dvSql = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            foreach (DataRowView drvSql in dvSql)
            {

                template += "<li class='touchcarousel-item'><div class='at_container'><img  id='" + drvSql["MapID"].ToString() + "' src='repository/" + drvSql["MapFile"].ToString() + "' alt=''></div></li>";
            }





            FileStream fs = null;
            if (!File.Exists(fileLoc))
            {
                using (fs = File.Create(fileLoc))
                {

                }
            }

            string js = "<script type='text/javascript'> jQuery(function ($) { $('#carousel-single-image').touchCarousel({ pagingNav: true, scrollbar: false, directionNavAutoHide: false, itemsPerMove: 1, loopItems: true, directionNav: false, autoplay: false, autoplayDelay: 2000, useWebkit3d: true, transitionSpeed: 400 }); $('#carousel-single-image').bind('touchstart click', function () { e.preventDefault(); $('#carousel-single-image').click(function () { alert('hello'); $('span').delay(500).show('slide', { direction: 'up' }, 500); }) }); });</script>";
            string style = "<style type='text/css'>.at_container{display:block;  width:1024px;   height:768px;    overflow:hidden;   padding: 10px;}</style>";
            if (File.Exists(fileLoc))
            {
                using (StreamWriter sw = new StreamWriter(fileLoc))
                {
                    sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><meta name='viewport' content='width=device-width' /><title>Maps</title><link href='prodstyle.css' rel='stylesheet' type='text/css' media='screen' /><link rel='stylesheet' href='css/touchcarousel.css' /><link rel='stylesheet' href='css/prod-light-skin.css'/><script src='js/jquery.min.js'></script><script src='js/jquery.touchcarousel-1.1.js'  ></script>{0}</head><body><div id='wrapper'><div id='carousel-single-image' class='touchcarousel   minimal-light'><ul class='touchcarousel-container'>{1}</ul></div></div>{2}</body></html>", style, template, js));
                }
            }



            MultiView1.ActiveViewIndex = 0;
            Repeater1.DataBind();
            // loadMap(Convert.ToInt32(this.HiddenFieldMapID.Value));

        }
        else
        {
            lblErrorAdd.Text = "Please choose video file to upload";
        }
    }

    private void SetDefaultView()
    {
        MultiView1.ActiveViewIndex = 0;
    }
    private void loadMap(int MapID)
    {
        Map myMap;
        myMap = clsmap.getMap(MapID);
        HiddenFieldMapID.Value = myMap.MapID.ToString();






        //if (String.IsNullOrEmpty(myMap.MapFile.ToString()))
        //{
        //    Image1.ImageUrl = "";

        //}
        //else
        //{
        //    Image1.ImageUrl = myMap.MapPath.ToString();
        //}

    }
    protected void btnEditAgency_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    

    }

    private void EditAgency(int AgencyID)
    {




       
        Map myMap;
        myMap = clsmap.getMap(AgencyID);
        HiddenFieldMapID.Value = myMap.MapID.ToString();
        lblFileEdit.Text = myMap.MapFile.ToString();



    }


 
    protected void BtnCancelEdit_Click(object sender, System.EventArgs e)
    {
        // Response.Redirect("PresentationMaster.aspx", false);

        MultiView1.ActiveViewIndex = 0;
    }

    


    protected void BtnUpdateAgency_Click(object sender, EventArgs e)
    {

        string strFileNameWithPath = FileUpload2.PostedFile.FileName;

   


        string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
        if (FileUpload2.HasFile)
        {
            //if (strExtensionName.Equals(".mp4"))
            //{

            ////////string FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);

            ////////FileUpload2.SaveAs(repository + FileName);

            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
            string rep = Session["CompanyID"] + "/" + PresentationID + "/repository/";

            string FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
            FileInfo fi = new FileInfo(FileName);
            string ext = fi.Extension;
            FileName = Guid.NewGuid().ToString() + ext;


            string pathToCreate1 = "~/" + Session["CompanyID"] + "/" + PresentationID + "/repository";
            string strFile = "";
            strFile = System.Web.Hosting.HostingEnvironment.MapPath("~/" + Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName);
            Directory.CreateDirectory(Server.MapPath(pathToCreate1));
            FileUpload2.SaveAs(strFile);
            string fullpath = Session["CompanyID"] + "/" + PresentationID + "/repository/" + FileName;

            string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;
            Directory.CreateDirectory(Server.MapPath(pathToCreate));
            string fileLoc = Server.MapPath(pathToCreate) + "/" + "mp01.html";

            string ImgFile = "<img src='repository/" + FileName + "' alt=''>";



            string template = "";
            //Bind
            DataView dvSql = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            foreach (DataRowView drvSql in dvSql)
            {

                template += "<li class='touchcarousel-item'><div class='at_container'><img  id='" + drvSql["MapID"].ToString() + "' src='repository/" + drvSql["MapPath"].ToString() + "' alt=''></div></li>";
            }
 



            FileStream fs = null;
            if (!File.Exists(fileLoc))
            {
                using (fs = File.Create(fileLoc))
                {

                }
            }

            string js = "<script type='text/javascript'> jQuery(function ($) { $('#carousel-single-image').touchCarousel({ pagingNav: true, scrollbar: false, directionNavAutoHide: false, itemsPerMove: 1, loopItems: true, directionNav: false, autoplay: false, autoplayDelay: 2000, useWebkit3d: true, transitionSpeed: 400 }); $('#carousel-single-image').bind('touchstart click', function () { e.preventDefault(); $('#carousel-single-image').click(function () { alert('hello'); $('span').delay(500).show('slide', { direction: 'up' }, 500); }) }); });</script>";
            string style = "<style type='text/css'>.at_container{display:block;  width:1024px;   height:768px;    overflow:hidden;   padding: 10px;}</style>";
            if (File.Exists(fileLoc))
            {
                using (StreamWriter sw = new StreamWriter(fileLoc))
                {
                    sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><meta name='viewport' content='width=device-width' /><title>Maps</title><link href='prodstyle.css' rel='stylesheet' type='text/css' media='screen' /><link rel='stylesheet' href='css/touchcarousel.css' /><link rel='stylesheet' href='css/prod-light-skin.css'/><script src='js/jquery.min.js'></script><script src='js/jquery.touchcarousel-1.1.js'  ></script>{0}</head><body><div id='wrapper'><div id='carousel-single-image' class='touchcarousel   minimal-light'><ul class='touchcarousel-container'>{1}</ul></div></div>{2}</body></html>", style, template, js));
                }
            }



            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {


                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_InsertMap";
                cmd.Parameters.Add("@MapFile", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
                cmd.Parameters.Add("@MapPath", SqlDbType.VarChar).Value = System.Convert.ToString(rep + FileName);
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

                HiddenFieldMapID.Value = cmd.Parameters["@ID"].Value.ToString();


            }
            c.Close();

            MultiView1.ActiveViewIndex = 1;
            loadMap(Convert.ToInt32(this.HiddenFieldMapID.Value));

            lblErrorAdd.Text = "";

        }
        else
        {
            lblErrorAdd.Text = "Please choose image file to upload";
        }
    }

    #region "Delete"
    protected void Repeater1_OnItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("Delete"))
        {

            //Get the reference of the clicked button.
            LinkButton button = (LinkButton)e.CommandSource;



            string[] ar = button.CommandArgument.ToString().Split(',');
            int mapid = Convert.ToInt32(ar[0]);
            if (ar[1] == String.Empty || ar[1] == "")
                return;

            string mapfile = Server.MapPath("~/" + ar[1]);




            bool directoryExists = File.Exists(mapfile);

            if (clsmap.Delete(mapid) == true)
            {
                File.Delete(mapfile);
              

                PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
                string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;
                Directory.CreateDirectory(Server.MapPath(pathToCreate));
                string fileLoc = Server.MapPath(pathToCreate) + "/" + "mp01.html";
            


 



                string template = "";
                //Bind
                DataView dvSql = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
                foreach (DataRowView drvSql in dvSql)
                {
                
                    template += "<li class='touchcarousel-item'><div class='at_container'><img  id='" + drvSql["MapID"].ToString() + "' src='repository/" + drvSql["MapFile"].ToString() + "' alt=''></div></li>";
                }


 
                FileStream fs = null;
                if (!File.Exists(fileLoc))
                {
                    using (fs = File.Create(fileLoc))
                    {

                    }
                }

                string js = "<script type='text/javascript'> jQuery(function ($) { $('#carousel-single-image').touchCarousel({ pagingNav: true, scrollbar: false, directionNavAutoHide: false, itemsPerMove: 1, loopItems: true, directionNav: false, autoplay: false, autoplayDelay: 2000, useWebkit3d: true, transitionSpeed: 400 }); $('#carousel-single-image').bind('touchstart click', function () { e.preventDefault(); $('#carousel-single-image').click(function () { alert('hello'); $('span').delay(500).show('slide', { direction: 'up' }, 500); }) }); });</script>";
                string style = "<style type='text/css'>.at_container{display:block;  width:1024px;   height:768px;    overflow:hidden;   padding: 10px;}</style>";
                if (File.Exists(fileLoc))
                {
                    using (StreamWriter sw = new StreamWriter(fileLoc))
                    {

                        sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><meta name='viewport' content='width=device-width' /><title>Maps</title><link href='prodstyle.css' rel='stylesheet' type='text/css' media='screen' /><link rel='stylesheet' href='css/touchcarousel.css' /><link rel='stylesheet' href='css/prod-light-skin.css'/><script src='js/jquery.min.js'></script><script src='js/jquery.touchcarousel-1.1.js'  ></script>{0}</head><body><div id='wrapper'><div id='carousel-single-image' class='touchcarousel   minimal-light'><ul class='touchcarousel-container'>{1}</ul></div></div>{2}</body></html>", style, template, js));
                    }


                }

                Repeater1.DataBind();

            }


        }
    }
    #endregion
}