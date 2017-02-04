using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Preview_MoodTone : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] == null)
            return;


        loadModeandTone(Convert.ToInt32(Request.QueryString["ID"].ToString()));
    }

    private void loadModeandTone(int ModeToneID)
    {
        ModeTone myModeTone;
        myModeTone = clsmodeTone.getModeTone(ModeToneID);
        Literal1.Text = HttpUtility.HtmlDecode(myModeTone.ModeTonePage.ToString());

    }
}