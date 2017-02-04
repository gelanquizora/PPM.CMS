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

public partial class Master_KeyMessage : System.Web.UI.Page
{
    SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
    int PresentationID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            SetDefaultView();
            PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        }


        DataView dvSql = (DataView)dsKeyMessage.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView drvSql in dvSql)
        {


            int kID = Convert.ToInt32(drvSql["KeyID"].ToString());
            if ((kID == 0))
            {
                MultiView1.ActiveViewIndex = 0;

                lblPresentation.Text = drvSql["Title"].ToString();
                lblAction.Text = "New Key Message";
            }
            else
            {

                MultiView1.ActiveViewIndex = 1;



                HiddenFieldKeyID.Value = Convert.ToInt32(kID).ToString();

                lblPresentation.Text = drvSql["Title"].ToString();
                lblAction.Text = "View Key Message";

                loadKeyMessage(Convert.ToInt32(HiddenFieldKeyID.Value));
            }

        }


    }
    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("PresentationMaster.aspx", false);
    }
    protected void BtnSave_Click(object sender, System.EventArgs e)
    {

        //save
        PresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));

        PreviewButton_Click(null, EventArgs.Empty);
        string UserSignature = TextPreview.InnerHtml;

        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertKeyMessage";
            cmd.Parameters.Add("@KeyPage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature);
            cmd.Parameters.Add("@PresentationID", SqlDbType.Int).Value = PresentationID;
            cmd.ExecuteNonQuery();
        }
        c.Close();





        string pathToCreate = "~/KeyMessagePages/" + PresentationID;


        Directory.CreateDirectory(Server.MapPath(pathToCreate));

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "3.html";




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
                sw.Write(string.Format("<head><title></title></head><body >{0}</body></html>", TextPreview.InnerText));
            }
        }




        Response.Redirect("PresentationMaster.aspx", false);
    }
    protected void PreviewButton_Click(object sender, EventArgs e)
    {
        switch (Selections.SelectedValue)
        {
            case "Formatted":
                TextPreview.InnerHtml = Editor.Text;
                break;
            case "Html":
                TextPreview.InnerText = Editor.Text;
                break;
            default:
                break;
        }
    }
    protected void ClearButton_Click(object sender, EventArgs e)
    {
        Editor.Text = String.Empty;
    }
    private void SetDefaultView()
    {
        MultiView1.ActiveViewIndex = 0;
    }
    private void loadKeyMessage(int KeyMessageID)
    {
        KeyMessage myKeyMessage;
        myKeyMessage = clskeyMessage.getKeyMessage(KeyMessageID);
        DivContent.InnerHtml = HttpUtility.HtmlDecode(myKeyMessage.KeyPage.ToString());

    }
    protected void btnEditKeyMessage_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        EditKeyMessage(Convert.ToInt32(HiddenFieldKeyID.Value));
        lblAction.Text = "Edit Key Message";
    }

    private void EditKeyMessage(int KeyID)
    {

        KeyMessage myKeyMessage;
        myKeyMessage = clskeyMessage.getKeyMessage(KeyID);


        EditorEdit.Text = HttpUtility.HtmlDecode(myKeyMessage.KeyPage.ToString());


    }

    //for edit
    protected void ClearButtonEdit_Click(object sender, EventArgs e)
    {
        EditorEdit.Text = String.Empty;
        lblAction.Text = "Edit Key Message";
        MultiView1.ActiveViewIndex = 2;
    }
    protected void PreviewButtonEdit_Click(object sender, EventArgs e)
    {
        switch (SelectionsEdit.SelectedValue)
        {
            case "Formatted":
                TextPreviewEdit.InnerHtml = EditorEdit.Text;
                break;
            case "Html":
                TextPreviewEdit.InnerText = EditorEdit.Text;
                break;
            default:
                break;
        }
    }
    protected void BtnUpdateEdit_Click(object sender, System.EventArgs e)
    {
       


        PreviewButtonEdit_Click(null, EventArgs.Empty);
        string UserSignature = TextPreviewEdit.InnerHtml;

        c.Open();
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UpdateKeyMessage";
            cmd.Parameters.Add("@KeyPage", SqlDbType.NVarChar).Value = System.Convert.ToString(UserSignature);
            cmd.Parameters.Add("@KeyID", SqlDbType.Int).Value = HiddenFieldKeyID.Value;
            cmd.ExecuteNonQuery();
        }
        c.Close();






        string pathToCreate = "~/KeyMessagePages/" + PresentationID;


       

        string fileLoc = Server.MapPath(pathToCreate) + "/" + "3.html";




        if (File.Exists(fileLoc))
        {
            using (StreamWriter sw = new StreamWriter(fileLoc))
            {
                sw.Flush();
                sw.Write(string.Format("<head><title></title></head><body >{0}</body></html>", TextPreviewEdit.InnerText));
            }
        }

        Response.Redirect("PresentationMaster.aspx", false);
    }
    protected void BtnCancelEdit_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("PresentationMaster.aspx", false);
    }

    protected void btnCancelEditKeyMessage_Click(object sender, EventArgs e)
    {
        Response.Redirect("PresentationMaster.aspx", false);
    }
}