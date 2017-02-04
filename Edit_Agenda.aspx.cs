using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_Edit_Agenda : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (IsPostBack)
        {
            // If condition is true, execute these statements.
        }
        else
        {
           // this.loadAgenda();
        }
    }

    //private void loadAgenda()
    //{
    //    Agenda myAgenda;
    //    myAgenda = clsAgenda.getAgenda();
       
    //    txtAgendaPage.Text = myAgenda.AgendaPage.ToString();
       
    //}

    protected void BtnUpdate_Click(object sender, System.EventArgs e)
    {
        Agenda myAgenda;
        myAgenda = new Agenda();
        myAgenda.AgendaID = System.Convert.ToInt32(txtAgendaID.Text);
        myAgenda.AgendaTitle = System.Convert.ToString(txtAgendaTitle.Text);
        myAgenda.AgendaPage = System.Convert.ToString(txtAgendaPage.Text);
        myAgenda.AgendaFileName = System.Convert.ToString(txtAgendaFileName.Text);
        myAgenda.CreatedBy = System.Convert.ToString(txtCreatedBy.Text);
        myAgenda.CreatedDate = System.Convert.ToDateTime(calCreatedDate.SelectedDate);
        myAgenda.ModifiedBy = System.Convert.ToString(txtModifiedBy.Text);
        myAgenda.ModifiedDate = System.Convert.ToDateTime(calModifiedDate.SelectedDate);
        clsAgenda.Update(myAgenda);
        Response.Redirect("AgendaGrid.aspx", false);
    }

    protected void BtnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("AgendaGrid.aspx", false);
    }
}