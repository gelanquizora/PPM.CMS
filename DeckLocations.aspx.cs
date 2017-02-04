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
using Ionic.Zip;

public partial class DeckLocations : System.Web.UI.Page
{
    private string Contents = ConfigurationManager.AppSettings["Contents"].ToString();

    private string repository = ConfigurationManager.AppSettings["repository"].ToString();
    private string URL = ConfigurationManager.AppSettings["URL"].ToString();
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    int PresentationID = 0;

    string _presentationID = "0";
    string _clientID = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

            //frmEntry.Attributes["src"] = "Edit_ProductionDesign.aspx?PresentationID=" + PresentationID;
            //    frmView.Attributes["src"] = Session["CompanyID"].ToString() + "/" + PresentationID + "/pd01.html";

            if (!string.IsNullOrEmpty(Request.QueryString["ClientID"]))
                _clientID = Request.QueryString["ClientID"].ToString();
            _presentationID = Request.QueryString["PresentationID"].ToString();

            loadPresentation(Convert.ToInt32(_presentationID));

            //txtEditTitle.ReadOnly = true;
            //txtEditDescription.ReadOnly = true;
            //ddlClientEdit.Enabled = false;

           
            string param = "PresentationID=" + _presentationID.ToString() + "&ClientID=" + _clientID.ToString();
            btnBack.Attributes["href"] = "ProjectInside.aspx?" + param;


            Panel1.Visible = true;
            Panel2.Visible = false;
            //lnkAgencyBoard.Attributes["href"] = "DeckAgencyBoard.aspx?" + param;
            //lnkDirectorsTreatement.Attributes["href"] = "DeckDirectorsTreatment.aspx?" + param;


            //lnkCover.Attributes["href"] = "DeckCover.aspx?" + param;
            //lnkAgenda.Attributes["href"] = "DeckAgenda.aspx?" + param;
            //lnkAttendees.Attributes["href"] = "DeckAttendees.aspx?" + param;
            //lnkAdvertising.Attributes["href"] = "DeckAdvertising.aspx?" + param;
            //lnkTargetMarket.Attributes["href"] = "DeckTargetMarket.aspx?" + param;
            //lnkMoodandTone.Attributes["href"] = "DeckMoodandTone.aspx?" + param;
            //lnkMaps.Attributes["href"] = "DeckMap.aspx?" + param;

            //lnkDirectory.Attributes["href"] = "DeckDirectory.aspx?" + param;

        }
    }

    protected void BtnEdit_Click(object sender, System.EventArgs e)
    {
        _clientID = Request.QueryString["ClientID"].ToString();
        _presentationID = Request.QueryString["PresentationID"].ToString();

        Response.Redirect("DeckLocations_Edit.aspx?ClientID=" + _clientID + "&PresentationID=" + _presentationID + "");

        Panel1.Visible = false;
        Panel2.Visible = true;
    }

    private void loadPresentation(int PresentationPresentationID)
    {

        Presentation myPresentation;
        myPresentation = clspresentation.getPresentation(PresentationPresentationID);
        lblPresentationID.Text = PresentationPresentationID.ToString();
        //txtEditTitle.Text = myPresentation.Title.ToString();
        //Label1.Text = myPresentation.Title.ToString();
        //txtEditDescription.Text = myPresentation.Description.ToString();
        //ddlClientEdit.SelectedValue = myPresentation.ClientID.ToString();
    }

}