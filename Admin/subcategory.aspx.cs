using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_subcategory : System.Web.UI.Page
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
            //Session["AccessRigthsSet"] = getdata.AccessRights("Department.aspx", Admin["UserId"]).Tables[0];
            Filldata();
        }
    }

    public void Filldata()
    {
        ds = getdata.getSubCategory("SELECT", "","","");
        rep.DataSource = ds;
        rep.DataBind();
    }



    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("SubcategoryMaster.aspx?id=" + e.CommandArgument + "");
        }
        if (e.CommandName == "Delete")
        {
            string query = "update tbl_SubCategory set ISDeleted=1   where ID=" + e.CommandArgument + "";
            data.executeCommand(query);
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record Deleted Successfully......')", true);
            Filldata();
        }

    }
}