using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Passcode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DirectorsTreatmentPasscode _passcode = new DirectorsTreatmentPasscode();
            _passcode.PresentationID = Request.QueryString["PresentationID"].ToString();

            txtPasscode.Text = _passcode.Get();
        }
    }

    #region "Passcode"
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        txtPasscode.Text = Membership.GeneratePassword(4, 0);
        DirectorsTreatmentPasscode _passcode = new DirectorsTreatmentPasscode();
        _passcode.PresentationID = Request.QueryString["PresentationID"].ToString();
        _passcode.Passcode = txtPasscode.Text;
        _passcode.Update();

    }
    #endregion
}