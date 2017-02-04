using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_View_Cover : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (IsPostBack)
        {
            // If condition is true, execute these statements.
        }
        else
        {
           // this.loadCover();
        }
    }

    //private void loadCover()
    //{
    //    Cover myCover;
    //    myCover = clscover.getCover();
    //    txtCoverID.Text = myCover.CoverID.ToString();
    //    txtCoverTitle.Text = myCover.CoverTitle.ToString();
    //    txtCoverPage.Text = myCover.CoverPage.ToString();
    //    txtCoverFileName.Text = myCover.CoverFileName.ToString();
    //    txtCreatedBy.Text = myCover.CreatedBy.ToString();
    //    calCreatedDate.SelectedDate = myCover.CreatedDate;
    //    txtModifiedBy.Text = myCover.ModifiedBy.ToString();
    //    calModifiedDate.SelectedDate = myCover.ModifiedDate;
    //}

    protected void BtnUpdate_Click(object sender, System.EventArgs e)
    {
        //Cover myCover;
        //myCover = new Cover();
        //myCover.CoverID = System.Convert.ToInt32(txtCoverID.Text);
        //myCover.CoverTitle = System.Convert.ToString(txtCoverTitle.Text);
        //myCover.CoverPage = System.Convert.ToString(txtCoverPage.Text);
        //myCover.CoverFileName = System.Convert.ToString(txtCoverFileName.Text);
        //myCover.CreatedBy = System.Convert.ToString(txtCreatedBy.Text);
        //myCover.CreatedDate = System.Convert.ToDateTime(calCreatedDate.SelectedDate);
        //myCover.ModifiedBy = System.Convert.ToString(txtModifiedBy.Text);
        //myCover.ModifiedDate = System.Convert.ToDateTime(calModifiedDate.SelectedDate);
        //clscover.Update(myCover);
        //Response.Redirect("CoverGrid.aspx", false);
    }

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("CoverGrid.aspx", false);
    }
}