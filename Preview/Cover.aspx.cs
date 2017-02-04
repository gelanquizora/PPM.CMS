using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Preview_Cover : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] == null)
            return;


        loadCover(Convert.ToInt32(Request.QueryString["ID"].ToString()));
    }

    private void loadCover(int CoverID)
    {
        Cover myCover;
        myCover = clscover.getCover(CoverID);
       Literal1.Text = HttpUtility.HtmlDecode(myCover.CoverPage.ToString());



    }
}