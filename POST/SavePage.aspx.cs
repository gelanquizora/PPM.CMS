using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class POST_SavePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static string DisplayData()
    {

        
        return DateTime.Now.ToString();
    }

    public static string SaveTimetable(string htmlstring)
    {


        return htmlstring;
    }
}