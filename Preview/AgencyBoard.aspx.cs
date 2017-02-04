using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Preview_AgencyBoard : System.Web.UI.Page
{
    private string URLBasic = ConfigurationManager.AppSettings["URLBasic"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] == null)
            return;


        loadAgency(Convert.ToInt32(Request.QueryString["ID"].ToString()));
    }

    private void loadAgency(int AgencyID)
    {
        AgencyBoard myAgencyBoard;
        myAgencyBoard = clsagencyBoard.getAgencyBoard(AgencyID);
        
      


        if (String.IsNullOrEmpty(myAgencyBoard.ImageFile.ToString()))
        {
            //Literal1.Text = "<h3>No Image Available. </h3>";
        }
        else
        {
           string filpath =  System.Web.Hosting.HostingEnvironment.MapPath("~/" + myAgencyBoard.ImagePath.ToString());
           System.Drawing.Image objImage = System.Drawing.Image.FromFile(filpath);



           string ImgFile = "<img src='../" + myAgencyBoard.ImagePath.ToString() + "' alt=''   style='margin: auto;position: absolute;top: 0; left: 0; bottom: 0; right: 0;' /> ";
          
     
           int width = objImage.Width;
           int height = objImage.Height;

           if (height > 1020 || width > 768)
           {
               ImgFile = "<img src='../" + myAgencyBoard.ImagePath.ToString() + "' alt=''   /> ";
               Literal1.Text = string.Format("<div class='DivToScroll'  ><div class='DivWithScroll'  >{0}</div></div>", ImgFile);


           }
           else
               Literal1.Text = ImgFile;


          //  Literal1.Text = "<img src='" + URLBasic + "/" + myAgencyBoard.ImagePath.ToString() + "' alt=''   style='margin: auto;position: absolute;top: 0; left: 0; bottom: 0; right: 0;' /> ";
            
            
            //Image1.AlternateText = URLBasic + "/" + myAgencyBoard.ImagePath.ToString();
        }

    }
}