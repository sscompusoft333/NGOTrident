using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Contactus : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    Master getdata = new Master();
    Data data = new Data();
    private HttpCookie Admin;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["ngojeetart"] == null) { Response.Redirect("../Login.aspx"); }

            Admin = Request.Cookies["ngojeetart"];
            Session["AccessRigthsSet"] = getdata.AccessRights("Contactus.aspx", Admin["UserId"]).Tables[0];
            Filldata();
        }
    }

    public void Filldata()
    {
        ds = getdata.getcontactus();
        rep.DataSource = ds;
        rep.DataBind();
    }
}