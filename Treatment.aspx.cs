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

public partial class Treatment : System.Web.UI.Page
{


    private string Contents = ConfigurationManager.AppSettings["Contents"].ToString();

    private string repository = ConfigurationManager.AppSettings["repository"].ToString();
    private string URL = ConfigurationManager.AppSettings["URL"].ToString();
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    int PresentationID = 0;
    string CompanyID = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Session["CompanyID"] == null)
                return;


            CompanyID = Session["CompanyID"].ToString();

            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

            frmEntry.Attributes["src"] = "Edit_DirectorsTreatment.aspx?PresentationID=" + PresentationID;

            frmPasscode.Attributes["src"] = "Passcode.aspx?PresentationID=" + PresentationID;
            frmVideos.Attributes["src"] = "DirectorsTreatmentVideos.aspx?PresentationID=" + PresentationID;


        } 

    }


    private void loadDocuments()
    {


    }
    protected void gvTreatment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {

            int index = Convert.ToInt32(e.CommandArgument);
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
            Response.Redirect("View_DirectorsTreatment.aspx?DTID=" + index.ToString() + "&PresentationID=" + PresentationID.ToString());
        }


        if (e.CommandName == "edt")
        { 
            int index = Convert.ToInt32(e.CommandArgument);
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
            Response.Redirect("Edit_DirectorsTreatment.aspx?DTID=" + index.ToString() + "&PresentationID=" + PresentationID.ToString());
 


        }


        if (e.CommandName == "del")
        {

            c.Open();
            using (SqlCommand cmd = c.CreateCommand())
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DeleteDirectorsTreatment";
                cmd.Parameters.Add("@DTID", SqlDbType.Int).Value = Convert.ToInt32(e.CommandArgument);
                cmd.ExecuteNonQuery();

            }
            c.Close();

            //gvTreatment.DataBind();


        }
    }

    protected void createNew_Click(object sender, EventArgs e)
    {

        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        Response.Redirect("Create_DirectorsTreatment.aspx?PresentationID=" + PresentationID.ToString());


    }


    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //{
        //    //if (Repeater1.Items.Count > 0)
        //    // {

        //        RepeaterItem item = Repeater1.Items[e.Item.ItemIndex-1 ];
        //        string value = ((HiddenField)item.FindControl("hdnImagePath")).Value;
        //        Image img = ((Image)item.FindControl("imgSlide"));
        //        img.ImageUrl = CompanyID + "/" + PresentationID.ToString() +"/repository/"+value ;
        //        img.AlternateText = CompanyID + "/" + PresentationID.ToString() + "/repository/" + value;


             
        //    //}
        //}

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string value = ((HiddenField)e.Item.FindControl("hdnImagePath")).Value;
                   Image img = ((Image)e.Item.FindControl("imgSlide"));
                   img.ImageUrl = CompanyID + "/" + PresentationID.ToString() +"/repository/"+value ;
                 img.AlternateText = CompanyID + "/" + PresentationID.ToString() + "/repository/" + value;
        }

    }

   
}