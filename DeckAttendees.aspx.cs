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


public partial class DeckAttendees : System.Web.UI.Page
{
  
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

            bindPagesWith(0);
             loadView();
        
        }

      


    }

    private void bindPagesWith(int selectedIndex)
    {
         DataView dvSql = (DataView)dsAttendee.Select(DataSourceSelectArguments.Empty);

        drpPages.Items.Clear();

        if (dvSql.Count == 0)
        {
            drpPages.Items.Add(new ListItem("Page: 1","1"));
            btnSave.Visible = true;
        }
        
        for(int i = 1; dvSql.Count >= i; i++)
        {
        
       
            drpPages.Items.Add(new ListItem("Page: " + i.ToString(), i.ToString()));
        }

        drpPages.SelectedIndex = selectedIndex;


    }
    protected void drpPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadView();
    }

 
    private void loadView()
    {
        //for Attendee
        DataView dvSql = (DataView)dsAttendee.Select(DataSourceSelectArguments.Empty);

     


        foreach (DataRowView drvSql in dvSql)
        {

            int aID = Convert.ToInt32(drvSql["AttendeeID"].ToString());
            if ((aID == 0))
            {
                btnSave.Visible = true;
           
            }
            else
            {



                if (drvSql["Ordinal"].ToString() == drpPages.SelectedValue.ToString())
                {
                    HiddenFieldAttendeeID.Value = Convert.ToInt32(aID).ToString();
                    lnlPreview.Attributes["href"] = "Preview/Attendees.aspx?ID=" + aID ;
                    ContentEdit.Visible = true;
                    BtnUpdateEdit.Visible = true;
                    EditAttendee(Convert.ToInt32(HiddenFieldAttendeeID.Value));
                }
            
            }

        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        loadView();
    }

    protected void btnAddNewPage_Click(object sender, EventArgs e)
    {
        EditorEdit.Text = String.Empty;
        ContentEdit.Visible = true;
        int newnumber = drpPages.Items.Count + 1;
        drpPages.Items.Add(new ListItem("Page " + newnumber.ToString(), newnumber.ToString()));
        drpPages.SelectedIndex = newnumber - 1;
        btnAddNewPage.Enabled = false;
        btnSave.Visible = true;
        BtnUpdateEdit.Visible = false;


    }
    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        //Response.Redirect("PresentationMaster.aspx", false);
    }
    protected void BtnSave_Click(object sender, System.EventArgs e)
    {

        //save Attendee
        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        string UserSignature = EditorEdit.Text;


        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertAttendees";
            cmd.Parameters.Add("@AttendeePage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature);
            cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = PresentationID;
            cmd.Parameters.Add("@Ordinal", SqlDbType.Int).Value = drpPages.SelectedValue.ToString();
            cmd.ExecuteNonQuery();
        }
        c.Close();

 

        string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;


        Directory.CreateDirectory(Server.MapPath(pathToCreate));

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "at01.html";




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
                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Attendees</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'></head><body><div class='IpadContent'>{0}</div> </body></html>", EditorEdit.Text));
          
            }
        }



        btnSave.Visible = false;
        BtnUpdateEdit.Visible = true;
        btnAddNewPage.Enabled = true;
        loadView();
      
    }
  
   

    private void EditAttendee(int AttendeeID)
    {

        Attendees myAttendees;
        myAttendees = clsattendees.getAttendees(AttendeeID);


        EditorEdit.Text = HttpUtility.HtmlDecode(myAttendees.AttendeePage.ToString());


    }

    //for edit
    protected void ClearButtonEdit_Click(object sender, EventArgs e)
    {
        EditorEdit.Text = String.Empty;
       
       
    }
    
  
    protected void BtnUpdateEdit_Click(object sender, System.EventArgs e)
    {


        string UserSignature = EditorEdit.Text;

        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateAttendees";
            cmd.Parameters.Add("@AttendeePage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature);
            cmd.Parameters.Add("@AttendeeID", SqlDbType.Int).Value = HiddenFieldAttendeeID.Value;
            cmd.ExecuteNonQuery();
        }
        c.Close();

        string template = "";
        //Bind
        DataView dvSql = (DataView)dsAttendee.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView drvSql in dvSql)
        {

            template += "<li class='touchcarousel-item'><div class='at_container'>" + drvSql["AttendeePage"].ToString()  + "</div></li>";
        }
 

        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;


        Directory.CreateDirectory(Server.MapPath(pathToCreate));

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "at01.html";




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
                //sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Cover</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'></head><body><div class='IpadContent'>{0}</div> </body></html>", EditorEdit.Text));

                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><meta name='viewport' content='width=device-width' /><title>Attendees</title><link href='prodstyle.css' rel='stylesheet' type='text/css' media='screen' /><link rel='stylesheet' href='css/touchcarousel.css' /><link rel='stylesheet' href='css/prod-light-skin.css'/><script src='js/jquery.min.js'></script><script src='js/jquery.touchcarousel-1.1.js'  ></script>{0}</head><body><div id='wrapper'><div id='carousel-single-image' class='touchcarousel   minimal-light'><ul class='touchcarousel-container'>{1}</ul></div></div>{2}</body></html>", style, template, js));
            }
        }

        btnSave.Visible = false;
        BtnUpdateEdit.Visible = true;
        btnAddNewPage.Enabled = true;
        loadView();
    }
     
}

 