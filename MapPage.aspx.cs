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
public partial class Master_MapPage : System.Web.UI.Page
{
    private string Contents = ConfigurationManager.AppSettings["Contents"].ToString();

    private string repository = ConfigurationManager.AppSettings["repository"].ToString();
    private string URL = ConfigurationManager.AppSettings["URL"].ToString();
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    int PresentationID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
           // SetDefaultView();
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
            frmEntry.Attributes["src"] = "EditMapPage.aspx?PresentationID=" + PresentationID;
        }

        //for Attendee
        DataView dvSql = (DataView)dsMap.Select(DataSourceSelectArguments.Empty);




        foreach (DataRowView drvSql in dvSql)
        {

            int mID = Convert.ToInt32(drvSql["MapID"].ToString());
       
            if ((mID == 0))
            {
              

              //  lblPresentation.Text = drvSql["Title"].ToString();
               // lblAction.Text = "New MAP";
            }
            else
            {

              

                HiddenFieldMapID.Value = Convert.ToInt32(mID).ToString();

               // lblPresentation.Text = drvSql["Title"].ToString();
                //lblAction.Text = "View MAP";

                loadMap(Convert.ToInt32(HiddenFieldMapID.Value));
            }

        }


    }
    //protected void BtnCancel_Click(object sender, System.EventArgs e)
    //{
    // //   Response.Redirect("PresentationMaster.aspx", false);
    //}



    //protected void BtnSaveMap_Click(object sender, System.EventArgs e)
    //{


    //    PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

    //    string strFileNameWithPath = FileUpload1.PostedFile.FileName;

    //    string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
    //    if (FileUpload1.HasFile)
    //    {
    //        //if (strExtensionName.Equals(".mp4"))
    //        //{

    //        string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

    //        FileUpload1.SaveAs(repository + FileName);




    //             c.Open();
    //        using (SqlCommand cmd = c.CreateCommand())
    //        {
    //            cmd.Parameters.Clear();
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cmd.CommandText = "sp_InsertMap";
    //            cmd.Parameters.Add("@MapFile", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
    //            cmd.Parameters.Add("@MapPath", SqlDbType.VarChar).Value = System.Convert.ToString(URL + FileName);
    //            cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = Convert.ToInt32(PresentationID);
    //            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
    //            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);

    //            cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
    //            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);


    //            cmd.ExecuteNonQuery();
    //        }
    //        c.Close();
        

            

    //        //}
    //        //else
    //        //{
    //        //    lblErrorAdd.Text = "cannot accept this file type";
    //        //}

    //        Response.Redirect("PresentationMaster.aspx", false);
    //    }
    //    else
    //    {
    //        lblErrorAdd.Text = "Please choose video file to upload";
    //    }
    //}
 
    //private void SetDefaultView()
    //{
       
    //}
    private void loadMap(int MapID)
    {
        Map myMap;
        myMap = clsmap.getMap(MapID);
        HiddenFieldMapID.Value = myMap.MapID.ToString();



    


        if (String.IsNullOrEmpty(myMap.MapFile.ToString()))
        {
            Image1.ImageUrl = "";
         
        }
        else
        {
            Image1.ImageUrl =  myMap.MapPath.ToString();
        }

    }
  

    //private void EditMap(int MapID)
    //{

       


    

    //    Map myMap;
    //    myMap = clsmap.getMap(MapID);

    //    HiddenFieldMapID.Value = myMap.MapID.ToString();
    //    lblFileEdit.Text = myMap.MapFile.ToString();


    //}

   
   
    //protected void BtnUpdateEdit_Click(object sender, System.EventArgs e)
    //{
       
         
    //}
    //protected void BtnCancelEdit_Click(object sender, System.EventArgs e)
    //{
    //    Response.Redirect("PresentationMaster.aspx", false);
    //}

    //protected void btnCancelEditMap_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("PresentationMaster.aspx", false);
    //}

  

   
    //protected void BtnUpdateMap_Click(object sender, EventArgs e)
    //{
    //    string strFileNameWithPath = FileUpload2.PostedFile.FileName;

    //    string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
    //    if (FileUpload2.HasFile)
    //    {
    //        //if (strExtensionName.Equals(".mp4"))
    //        //{

    //        string FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);

    //        FileUpload1.SaveAs(repository + FileName);

 

    //        c.Open();
    //        using (SqlCommand cmd = c.CreateCommand())
    //        {
    //            cmd.Parameters.Clear();
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cmd.CommandText = "sp_UpdateMap";
    //            cmd.Parameters.Add("@MapFile", SqlDbType.VarChar).Value = System.Convert.ToString(FileName);
    //            cmd.Parameters.Add("@MapPath", SqlDbType.VarChar).Value = System.Convert.ToString(URL + FileName);
    //            cmd.Parameters.Add("@MapID", SqlDbType.Int).Value = Convert.ToInt32(HiddenFieldMapID.Value);
    //            cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = System.Convert.ToString(Session["Username"].ToString());
    //            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = System.Convert.ToDateTime(DateTime.Now);


    //            cmd.ExecuteNonQuery();
    //        }
    //        c.Close();




    //        Response.Redirect("PresentationMaster.aspx", false);

    //        //}
    //        //else
    //        //{
    //        //    lblErrorAdd.Text = "cannot accept this file type";
    //        //}
    //    }
    //    else
    //    {
    //        lblErrorAdd.Text = "Please choose video file to upload";
    //    }
    //}
    //protected void btnEditMap_Click(object sender, EventArgs e)
    //{
    //    //MultiView1.ActiveViewIndex = 2;
    //    EditMap(Convert.ToInt32(HiddenFieldMapID.Value));
    //  //  lblAction.Text = "Edit Map";
    //}
}