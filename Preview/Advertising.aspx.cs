using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Preview_Advertising : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] == null)
            return;


        loadAttendee(Convert.ToInt32(Request.QueryString["ID"].ToString()));
    }

    private void loadAttendee(int AdvertisingObjectivesID)
    {
        AdvertisingObjectives myAdvertisingObjectives;
        myAdvertisingObjectives = clsadvertisingObjectives.getAdvertisingObjectives(AdvertisingObjectivesID);
        Literal1.Text = HttpUtility.HtmlDecode(myAdvertisingObjectives.AdvertisingObjectivesPage.ToString());

    }
}