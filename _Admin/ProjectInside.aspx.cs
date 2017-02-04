using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Ionic.Zip;
using System.Web.Security;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class _Admin_ProjectInside : System.Web.UI.Page
{
    string _presentationID = "0";
    string _clientID = "0";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (!string.IsNullOrEmpty(Request.QueryString["ClientID"]))
                _clientID = Request.QueryString["ClientID"].ToString();
            _presentationID = Request.QueryString["PresentationID"].ToString();

            loadPresentation(Convert.ToInt32(_presentationID));

            txtEditTitle.ReadOnly = true;
            txtEditDescription.ReadOnly = true;
            ddlClientEdit.Enabled = false;

            btnBack.Attributes["href"] = "Projects.aspx?ClientID=" + _clientID.ToString();
            string param = "PresentationID=" + _presentationID.ToString() + "&ClientID=" + _clientID.ToString();


            lnkAgencyBoard.Attributes["href"] = "Preview.aspx?PN=ab&" + param;
            lnkDirectorsTreatement.Attributes["href"] = "Preview.aspx?PN=dt&" + param;


            lnkCover.Attributes["href"] = "Preview.aspx?PN=ct&" + param;
            lnkAgenda.Attributes["href"] = "Preview.aspx?PN=ag&" + param;
            lnkAttendees.Attributes["href"] = "Preview.aspx?PN=at&" + param;
            lnkAdvertising.Attributes["href"] = "Preview.aspx?PN=ao&" + param;
            lnkTargetMarket.Attributes["href"] = "Preview.aspx?PN=tm&" + param;
            lnkMoodandTone.Attributes["href"] = "Preview.aspx?PN=mt&" + param;
            lnkMaps.Attributes["href"] = "Preview.aspx?PN=mp&" + param;

            lnkDirectory.Attributes["href"] = "Preview.aspx?PN=dr&" + param;

            //BY JOHN
            lnkProductionDesign.Attributes["href"] = "Preview.aspx?PN=pd&" + param;
            lnkLocations.Attributes["href"] = "Preview.aspx?PN=ln&" + param;
            lnkTimetable.Attributes["href"] = "Preview.aspx?PN=tt&" + param;
            lnkSoundtrack.Attributes["href"] = "Preview.aspx?PN=st&" + param;

        }
    }

    #region "Edit Item"
    private void loadPresentation(int PresentationPresentationID)
    {

        Presentation myPresentation;
        myPresentation = clspresentation.getPresentation(PresentationPresentationID);
        lblPresentationID.Text = PresentationPresentationID.ToString();
        txtEditTitle.Text = myPresentation.Title.ToString();
        Label1.Text = myPresentation.Title.ToString();
        txtEditDescription.Text = myPresentation.Description.ToString();
        ddlClientEdit.SelectedValue = myPresentation.ClientID.ToString();

        setLockButton(PresentationPresentationID);
    }

    protected void BtnUpdate_Click(object sender, System.EventArgs e)
    {
        int PresentationPresentationID;
        PresentationPresentationID = Convert.ToInt32(Request.QueryString.Get("PresentationID"));
        Presentation myPresentation;
        myPresentation = new Presentation();
        myPresentation.PresentationID = PresentationPresentationID.ToString();
        myPresentation.Title = System.Convert.ToString(txtEditTitle.Text);
        myPresentation.Description = System.Convert.ToString(txtEditDescription.Text);
        myPresentation.ClientID = System.Convert.ToInt32(ddlClientEdit.SelectedValue);
        clspresentation.Update(myPresentation);

        BtnUpdate.Visible = false;
        txtEditTitle.ReadOnly = true;
        txtEditDescription.ReadOnly = true;
        btnEdit.Visible = true;
        //Repeater1.DataBind();

    }

    protected void BtnCancelEdit_Click(object sender, System.EventArgs e)
    {


        if (string.IsNullOrEmpty(Request.QueryString["PresentationID"]))
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ClientID"]))
                _clientID = Request.QueryString["ClientID"].ToString();

            Response.Redirect("Decks.aspx?ClientID=" + _clientID);
            return;
        }

        _presentationID = Request.QueryString["PresentationID"].ToString();
        loadPresentation(Convert.ToInt32(_presentationID));
        BtnUpdate.Visible = false;
        txtEditTitle.ReadOnly = true;
        txtEditDescription.ReadOnly = true;
        btnEdit.Visible = true;
        BtnCancel.Visible = false;
        ddlClientEdit.Enabled = false;
    }


    protected void BtnEdit_Click(object sender, System.EventArgs e)
    {
        btnEdit.Visible = false;
        BtnUpdate.Visible = true;
        txtEditTitle.ReadOnly = false;
        txtEditDescription.ReadOnly = false;
        BtnCancel.Visible = true;
        ddlClientEdit.Enabled = true;
    }
    #endregion



    #region "Content Editor Access"

    protected void BtnCEAccess_Click(object sender, System.EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;

        string username;
        username = clsusers.GetContentEditor(Convert.ToInt32(Request.QueryString["PresentationID"].ToString()));
        if (username != String.Empty)
        {
            txtCEUsername.Text = username;
            txtCEUsername.Enabled = false;
            ceconfirmpassword.Visible = false;
             cepassword.Visible = false;
             editCEPasscode.Visible = true;

             btnSaveCEAccess.Visible = false;
             btnUpdateCEAccess.Visible = false;
             lnkEditCEPasscode.Visible = true;
        }
        else
        {
            txtCEUsername.Text = "";
            txtCEUsername.Enabled = true;
            ceconfirmpassword.Visible = true;
            cepassword.Visible = true;
            editCEPasscode.Visible = false;
            btnSaveCEAccess.Visible = true;
            btnUpdateCEAccess.Visible = false;
            lnkEditCEPasscode.Visible = false;
        }

      
    }

    protected void btnSaveCEAccess_Click(object sender, System.EventArgs e)
    {
        AddContentEditor();
    }
    protected void btnUpdateCEAccess_Click(object sender, System.EventArgs e)
    {
        if (updatePasscode() > 0)
            lblResult.Text = "Passcode successfully changed!";
       
    }
    protected void btnCancelCEAccess_Click(object sender, System.EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;

        Panel3.Visible = false;
        lblResult.Text = "";
    }


    private bool AddContentEditor()
    {
        string cid = "";
        if (Session["CompanyID"] == null)
            return false;
        else
            cid = Session["CompanyID"].ToString();


        bool valid = false;
        MembershipCreateStatus createStatus;
        MembershipUser user = Membership.CreateUser(txtCEUsername.Text, txtCEPassCode.Text, "testc@gmail.com", "sample", "sample", true, out createStatus);
        switch (createStatus)
        {
            //This Case Occured whenver User Created Successfully in database
            case MembershipCreateStatus.Success:
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "The content editor account was successfully created";
                valid = true;
                //txtUserName.Text = string.Empty;
                //txtEmail.Text = string.Empty;
                Roles.AddUserToRole(txtCEUsername.Text, "Content Editor");
                break;
            // This Case Occured whenver we send duplicate UserName
            case MembershipCreateStatus.DuplicateUserName:
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "The user with the same UserName already exists!";
                valid = false;
                break;
            //This Case Occured whenver we give duplicate mail id
            case MembershipCreateStatus.DuplicateEmail:
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "The user with the same email address already exists!";
                valid = false;
                break;
            //This Case Occured whenver we send invalid mail format
            case MembershipCreateStatus.InvalidEmail:
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "The email address you provided is invalid.";
                valid = false;
                break;
            //This Case Occured whenver we send empty data or Invalid Data
            case MembershipCreateStatus.InvalidAnswer:
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "The security answer was invalid.";
                valid = false;
                break;
            // This Case Occured whenver we supplied weak password
            case MembershipCreateStatus.InvalidPassword:
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "The password you provided is invalid. It must be 7 characters long and have at least 1 special character.";
                valid = false;
                break;
            default:
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "There was an unknown error; the user account was NOT created.";
                valid = false;
                break;
        }

        if (valid == true)
        {



            Users myUsers;
            myUsers = new Users();
            // myUsers.UserID = System.Convert.ToInt32(txtUserID.Text);
            myUsers.UserName = System.Convert.ToString(txtCEUsername.Text);
            myUsers.Password = System.Convert.ToString(txtCEPassCode.Text);
            myUsers.RoleID = "b981893a-eba8-41e9-b663-861f1248247a";
            myUsers.CompanyID = Session["CompanyID"].ToString();
            myUsers.Role = 1;
            int deck = Convert.ToInt32(Request.QueryString["PresentationID"].ToString());
            clsusers.InsertwithDeck(myUsers, deck );




        }
        return valid;

    }


    protected void lnkEditCEPasscode_Click(object sender, EventArgs e)
    {

        btnSaveCEAccess.Visible = false;
        btnUpdateCEAccess.Visible = true;

        ceconfirmpassword.Visible = true;
        cepassword.Visible = true;

        lnkEditCEPasscode.Visible = false;
    }

    private int updatePasscode()
    {
        SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["terrible1ConnectionString"].ToString());
        c.Open();
        int result = 0;
        using (SqlCommand cmd = c.CreateCommand())
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_Users_UpdatePassword";
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtCEUsername.Text; 
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = txtCEPassCode.Text;
      
            result = cmd.ExecuteNonQuery();



        }
        c.Close();

        return result;
    }
    #endregion


    #region "iPad Access"
    protected void btnIPadAccess_Click(object sender, System.EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = true;
        lblResult.Text = "";

        string deckid =  Request.QueryString["PresentationID"].ToString();
        DeviceUser _user = new DeviceUser();
        _user.DeckID = Convert.ToInt32(deckid);

        _user.GetIPadAccess();

        
        if (_user.UserName != string.Empty || _user.UserName != "")
        {

            txtIPadUsername.Text = _user.UserName;
            txtIPadPassword.Text = _user.Password;
            btnIPadAccessSave.Visible = false;
            btnIPadAccessUpdate.Visible = true;
        }
        else
        {
            btnIPadAccessSave.Visible = true;
            btnIPadAccessUpdate.Visible = false;
        }

    }

    private void saveIPadAccess(int deckid)
    {
        lblResult.Text = "";
        DeviceUser _user = new DeviceUser();
        _user.UserName = txtIPadUsername.Text;
        _user.Password = txtIPadPassword.Text ;
        _user.ClientID = Convert.ToInt32(Request.QueryString["ClientID"].ToString());
        _user.DeckID = deckid;
       
        ////Check if Existing
        //if (_user.GetByUsername().Rows.Count > 0)
        //{
        //    lblResult.Text = "Username already exist.";
        //    return;
        //}


        if (_user.GetByUsernameDeck().Rows.Count > 0)
        {
            lblResult.Text = "Other project is using this username. Please re-type your username.";
            return;
        }


        if (_user.Insert() == false)
        {
            lblResult.Text = "Error in saving.";
            return;
        }

        lblResult.Text = "Ipad access successfully created!";
    }


    protected void btnIPadAccessSave_Click(object sender, System.EventArgs e)
    {
           string deckid =  Request.QueryString["PresentationID"].ToString();
           saveIPadAccess( Convert.ToInt32(deckid));
    }

    protected void btnIPadAccessUpdate_Click(object sender, System.EventArgs e)
    {

        lblResult.Text = "";
        DeviceUser _user = new DeviceUser();
        _user.UserName = txtIPadUsername.Text;
        _user.Password = txtIPadPassword.Text;
     
        string deckid = Request.QueryString["PresentationID"].ToString();
        _user.DeckID = Convert.ToInt32(deckid);

        if (_user.GetByUsernameDeck().Rows.Count > 0)
        {
            lblResult.Text = "Other project is using this username. Please re-type your username.";
            return;
        }

        if (_user.UpdateIPadAccess() == true)
            lblResult.Text = "Access successfully changed!";
        else
            lblResult.Text = "";

    }
    #endregion



    #region "Lock Project"
    protected void btnLockProject_Click(object sender, System.EventArgs e)
    {
        

        string deckid = Request.QueryString["PresentationID"].ToString();
        if (btnLockProject.Text == "Unlock")
        {
            if(Lock(false, Convert.ToInt32(deckid)))
                     btnLockProject.Text = "Lock"; // The project is successfully unlocked
        }
        else
        {
                if(Lock(true, Convert.ToInt32(deckid)))
                    btnLockProject.Text = "Unlock"; // The project is successfully locked
        }

    }

    private bool Lock(bool locked, int deckid)
    {
        int id = 0;
        bool isSaved = false;
        SqlHelper _helper = new SqlHelper();

        try
        {
            if (_helper.CreateConnection())
            {
                _helper.BeginTransaction();
                _helper.CreateCommand("sp_PresentationLock", true);

                _helper.AddParameter("@DeckID", deckid , DbType.Int32, ParameterDirection.Input);
                _helper.AddParameter("@IsLocked", locked, DbType.Boolean, ParameterDirection.Input);



                isSaved = _helper.ExecuteNonQuery();

                
                _helper.ClearCommandParameters();

                if (isSaved)
                {
                    _helper.CommitTransaction();
                }

            }
        }
        catch (Exception ex)
        {
            _helper.RollbackTransaction();

        }
        finally
        {
            _helper.CloseConnection();

        }

        return isSaved;
    }

    private void setLockButton(int deckID)
    {
        bool locked = false;
   
       SqlHelper _helper = new SqlHelper();

        DataTable dt = new DataTable();


        _helper.CloseConnection();
        _helper.CreateCommand("sp_PresentationIsLocked", false);
        _helper.AddParameter("@DeckID", deckID, DbType.Int32, ParameterDirection.Input);
        _helper.ExecuteDataTable();
        dt = _helper.DataTable;

        _helper.CloseConnection();


        if (dt.Rows.Count > 0)
        {
            locked = Convert.ToBoolean(dt.Rows[0][0].ToString());
            btnLockProject.Text = locked == true ? "Unlock" : "Lock";
        }
      
    }
    #endregion

}