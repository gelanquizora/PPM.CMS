using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string test = "hey";

        //string formatted = System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(test);

        //Label1.Text = formatted;
        if (!Page.IsPostBack)
        {
            ////navigator
            //if (string.IsNullOrEmpty(Session["RoleID"].ToString()))
            //    return;

            //Literal1.Text = "<ul><li class='nav_dashboard active'><a href='Default.aspx'>Dashboard</a></li> ";
            //Literal1.Text += " <li class='nav_clients'><a href='ClientGrid.aspx'>Clients</a></li>";
            //Literal1.Text += "<li class='nav_projects'><a href='Decks.aspx'>Projects</a></li>";
            ////<%--    <li class="nav_decks active" ><a href="Decks.aspx">Decks</a></li>--%>

            //string roleid = Session["RoleID"].ToString();
            //if (roleid == "64ddaa33-9300-4db2-832e-b15a7d922132" || roleid == "393b0494-5da5-40b4-b424-494a0387655c")
            //    Literal1.Text += "<li class='nav_decks' ><a href='UserManagementGrid.aspx'>User Management</a></li>";

            //Literal1.Text += " </ul>";
        }

    }
}