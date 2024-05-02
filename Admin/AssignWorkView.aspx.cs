using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_AssignWorkView : System.Web.UI.Page
{
    DataSet ds = new DataSet();
   
    Master getdata = new Master();
    HttpCookie Admin;
    string uploadthumburl;
    Data data = new Data();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["ngojeetart"] == null) { Response.Redirect("../Login.aspx"); }

            Admin = Request.Cookies["ngojeetart"];
           

            if (Request.QueryString["id"] != null)
            {
                fillData(Request.QueryString["id"].ToString());
               
            }
        }

    }

  
    public void fillData(string id)
    {
        ds = getdata.getAssignWork(Request.QueryString["id"].ToString(), "", Request.QueryString["uid"].ToString(), Request.QueryString["pid"] == null ? "": Request.QueryString["pid"].ToString()) ;
        // ds = data.getDataSet(cmd);
        repWorkList.DataSource = ds;
        repWorkList.DataBind();
    }
}