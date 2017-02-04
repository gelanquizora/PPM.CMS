using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Create_Page : System.Web.UI.Page
{
    int PresentationID;
    public string htmlCode = string.Empty;
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (IsPostBack)
        {
            PresentationID = Convert.ToInt32(Request.QueryString.Get("id"));
        }
        else
        {
            // Put code to execute for non postback here
        }
    }

    protected void BtnSave_Click(object sender, System.EventArgs e)
    {
        PreviewButton_Click(null, EventArgs.Empty);

        Page pg;
        pg = new Page();
        pg.PageName = System.Convert.ToString(txtPageName.Text);


        string UserSignature = TextPreview.InnerHtml;



        pg.PageContent = HttpUtility.HtmlEncode(UserSignature);//Editor.Text;
        pg.Ordinal = System.Convert.ToInt32(txtOrdinal.Text);
        pg.PresentationID = System.Convert.ToInt32(PresentationID);
        clspage.Insert(pg);
        Response.Redirect("PresentationGridMaster.aspx", false);
    }
    protected void ClearButton_Click(object sender, EventArgs e)
    {
        Editor.Text = String.Empty;
    }
    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("PresentationGridMaster.aspx", false);
    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        DataStore.StoreHtml(Editor.Text);
    }
    protected class DataStore
    {
        public static void StoreHtml(string html)
        {
        }
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
   
   
}