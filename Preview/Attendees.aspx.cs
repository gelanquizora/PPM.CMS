using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Preview_Attendees : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] == null)
            return;


        loadCover(Convert.ToInt32(Request.QueryString["ID"].ToString()));
    }

    private void loadCover(int id)
    {
        Attendees myAttendees;
        myAttendees = clsattendees.getAttendees(id);
        Literal1.Text = HttpUtility.HtmlDecode(myAttendees.AttendeePage.ToString());



    }
}