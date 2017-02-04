using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Preview_Directory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] == null)
            return;


        loadDirectory(Convert.ToInt32(Request.QueryString["ID"].ToString()));
    }

    private void loadDirectory(int DirectoryID)
    {
        Directorytbl myDirectory;
        myDirectory = clsDirectory.getDirectory(DirectoryID);
        Literal1.Text = HttpUtility.HtmlDecode(myDirectory.DirectoryPage.ToString());

    }
}