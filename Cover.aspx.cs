using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Security;


public partial class Master_Cover : System.Web.UI.Page
{
    private CoverBLL _coverBLL;
    private CoverEL _coverEL;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        divvalue.InnerHtml = Editor1.Content;
       // Editor1.Content = "";

        FileInfo f = new FileInfo(MapPath("~/") + "File.html");
        TextWriter tw = f.CreateText();
        tw.Write(string.Format("<head><title></title></head><body >{0}</body></html>", Editor1.Content));
        tw.Close();


        //

        try
        {
            _coverEL = new CoverEL();
          //  _coverEL.ID = Convert.ToInt32(hdnSMSID.Value);
            _coverEL.CoverTitle = "";
            _coverEL.CoverPage = Editor1.Content;
            _coverEL.CreatedBy = Membership.GetUser().UserName;
            _coverEL.ModifiedBy = Membership.GetUser().UserName;


          

            _coverBLL = new CoverBLL(_coverEL);
            _coverBLL.SaveCover();
           



           
        }
        catch (Exception ex)
        {
            //Label1.Text = "Error: " + ex.Message;
        }
    }
}