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


public partial class DeckAgenda : System.Web.UI.Page
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

            loadView();
        }

       

    }

    private void loadView()
    {
         //for Agenda
        DataView dvSql = (DataView)dsAgenda.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView drvSql in dvSql)
        {

            int aID = Convert.ToInt32(drvSql["AgendaID"].ToString());
            if ((aID == 0))
            {

                btnSave.Visible = true;

            }
            else
            {

               HiddenFieldAgendaID.Value = Convert.ToInt32(aID).ToString();

            
                ContentEdit.Visible = false;
                HiddenFieldCoverID.Value = Convert.ToInt32(aID).ToString();
                lnlPreview.Attributes["href"] = "Preview/Agenda.aspx?ID=" + aID;
                ContentEdit.Visible = true;
                EditAgenda(Convert.ToInt32(HiddenFieldCoverID.Value));
                BtnUpdateEdit.Visible = true;

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


        string UserSignature = EditorEdit.Text;

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
                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Agenda</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'></head><body><div class='IpadContent'>{0}</div> </body></html>", EditorEdit.Text));
            }
        }


        loadView();
        btnSave.Visible = false;
        BtnUpdateEdit.Visible = true;
    }

   
 


   
    protected void btnEditAgenda_Click(object sender, EventArgs e)
    {
      
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

        
    }
   
    protected void BtnUpdateEdit_Click(object sender, System.EventArgs e)
    {

        string UserSignature = EditorEdit.Text;

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
                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Cover</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'></head><body><div class='IpadContent'>{0}</div> </body></html>", EditorEdit.Text));
            }
        }

        loadView();
   
    }
    

    
}