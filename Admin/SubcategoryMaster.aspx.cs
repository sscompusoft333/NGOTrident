using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Admin_SubcategoryMaster : System.Web.UI.Page
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

            //Session["AccessRigthsSet"] = emp.AccessRights("Category.aspx", Admin["UserId"]).Tables[0];


            if (Request.QueryString["view"] != null)
            {
                btnSaveExit.Visible = false;
                //  btnCancel.Visible = false;
            }

            emp.drpCategory(drpGst);

            if (Request.QueryString["id"] != null)
            {
                fillData(Request.QueryString["id"].ToString());
                btnSaveExit.Text = "Update";
            }
        }
    }

    public void fillData(string id)
    {
        ds = emp.getSubCategory("SELECT", "","", id);
        drpGst.SelectedValue = ds.Tables[0].Rows[0]["CategoryId"].ToString();
        txtPackName.Text = ds.Tables[0].Rows[0]["SubcategoryName"].ToString();

    }

    public void Save()
    {
        string action = "SAVE", Gstid = "";
        if (Request.QueryString["id"] != null)
        {
            action = "UPDATE";
            Gstid = Request.QueryString["id"].ToString();
        }
        emp.getSubCategory(action,drpGst.SelectedValue, txtPackName.Text.Trim(), Gstid);
       Response.Redirect("subcategory.aspx");
    }

    protected void btnSaveExit_Click(object sender, EventArgs e)
    {
        Save();
    }

}