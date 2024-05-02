using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NewsAdd : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    Master emp = new Master();
    HttpCookie Admin;
    Data data = new Data();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request.Cookies["ngojeetart"] == null) { Response.Redirect("../Login.aspx"); }

            Admin = Request.Cookies["ngojeetart"];
        }
        Filldata();
    }

    public void Filldata()
    {
        ds = emp.getNews();
        rep.DataSource = ds;
        rep.DataBind();
    }
    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("logo.aspx?id=" + e.CommandArgument + "");
        }
        if (e.CommandName == "Delete")
        {
            string query = "DELETE FROM News where ID=" + e.CommandArgument + "";
            data.executeCommand(query);
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record Deleted Successfully......')", true);
            Filldata();
        }

    }
}