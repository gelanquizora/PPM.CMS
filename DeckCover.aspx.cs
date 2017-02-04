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

public partial class DeckCover : System.Web.UI.Page
{
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    int PresentationID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

         
            string _presentationID = "0";
            string _clientID = "0";
            if (!string.IsNullOrEmpty(Request.QueryString["ClientID"]))
                _clientID = Request.QueryString["ClientID"].ToString();
            _presentationID = Request.QueryString["PresentationID"].ToString();



            string param = "PresentationID=" + _presentationID.ToString() + "&ClientID=" + _clientID.ToString();
            btnBack.Attributes["href"] = "ProjectInside.aspx?" + param;

         
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));


            loadView();
        }
    }

    private void loadView()
    {
        //for cover
        DataView dvSql = (DataView)dsCover.Select(DataSourceSelectArguments.Empty);
    
        foreach (DataRowView drvSql in dvSql)
        {

            int cID = Convert.ToInt32(drvSql["CoverID"].ToString());


            if ((cID == 0))
            {
                 
                btnSave.Visible = true;
            }
            else
            {

                
                loadCover(cID);
                ContentEdit.Visible = false;
                HiddenFieldCoverID.Value = Convert.ToInt32(cID).ToString();
                lnlPreview.Attributes["href"] = "Preview/Cover.aspx?ID=" + cID;
                ContentEdit.Visible = true;
                EditCover(Convert.ToInt32(HiddenFieldCoverID.Value));
                BtnUpdateEdit.Visible = true;

              
            }
            
          
        }
    }
    private void loadCover(int CoverID)
    {
        Cover myCover;
        myCover = clscover.getCover(CoverID);
      //  DivContent.InnerHtml = HttpUtility.HtmlDecode(myCover.CoverPage.ToString());



    }
   
    //for edit
    protected void ClearButtonEdit_Click(object sender, EventArgs e)
    {
        EditorEdit.Text = String.Empty;
        ContentEdit.Visible = true;

    }


    protected void BtnUpdateEdit_Click(object sender, System.EventArgs e)
    {

      

        string UserSignature = EditorEdit.Text;

 

        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;


        Directory.CreateDirectory(Server.MapPath(pathToCreate));

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "ct01.html";


        //Label1.Text = fileLoc;

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
                //sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Cover</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'><script src='js/jquery-latest.min.js'></script><link rel='stylesheet' href='css/orangebox.css' type='text/css' /></head><body><div id='wrapper'><div id='dt_summ'>{0}</div></div></body></html>", EditorEdit.Text));
                sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Cover</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'></head><body style='padding: 10px;'><div class='IpadContent'>{0}</div> </body></html>", EditorEdit.Text));
            }
        }




        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateCover";
            cmd.Parameters.Add("@CoverPage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature);
            cmd.Parameters.Add("@CoverID", SqlDbType.Int).Value = HiddenFieldCoverID.Value;
            cmd.ExecuteNonQuery();
        }
        c.Close();

        loadView();
        btnSave.Visible = false;
        BtnUpdateEdit.Visible = true;
     

    }
   

   
    


    #region "Add"
    protected void BtnSave_Click(object sender, System.EventArgs e)
    {




        string UserSignature = EditorEdit.Text;



        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        string pathToCreate = "~/" + Session["CompanyID"] + "/" + PresentationID;


        Directory.CreateDirectory(Server.MapPath(pathToCreate));

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "ct01.html";


        //Label1.Text = fileLoc;

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
                 sw.Write(string.Format("<!DOCTYPE HTML><html><head><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'><meta name='viewport' content='width=device-width' /><title>Cover</title><link href='style.css' rel='stylesheet' type='text/css' media='screen'></head><body style='padding: 10px;'><div class='IpadContent'>{0}</div> </body></html>", EditorEdit.Text));
            }
        }


        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertCover";
            cmd.Parameters.Add("@CoverPage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature);
            cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = PresentationID;
            cmd.ExecuteNonQuery();
        }
        c.Close();


        loadView();

        btnSave.Visible = false;
        BtnUpdateEdit.Visible = true;
         
    }

    #endregion


    private void EditCover(int CoverID)
    {

        Cover myCover;
        myCover = clscover.getCover(CoverID);


        EditorEdit.Text = HttpUtility.HtmlDecode(myCover.CoverPage.ToString());


    }
}

