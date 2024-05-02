using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Category : System.Web.UI.Page
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

            if (Request.QueryString["id"] != null)
            {
                fillData(Request.QueryString["id"].ToString());
                btnSaveExit.Text = "Update";
            }
            fileupload1();
        }
    }
    public void fillData(string id)
    {
        ds = emp.getCategory("SELECT", "","", id);
        txtPackName.Text = ds.Tables[0].Rows[0]["categoryName"].ToString();
        Label1.Text = ds.Tables[0].Rows[0]["Image"].ToString();
    }

    public void fileupload3()
    {
        if (Label1.Text == "")
        {
            Label1.Text = FileUpload1.FileName;
        }
    }
    public void fileupload1()
    {
        if (Label1.Text == "")
        {
            Label1.Visible = false;
            Button1.Visible = false;
            FileUpload1.Visible = true;
        }
        else
        {
            FileUpload1.Visible = false;
            Label1.Visible = true;
            Button1.Visible = true;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "";
        fileupload1();
    }

    public void Save()
    {

        if (FileUpload1.HasFile)
        {
            string fileName = Path.GetFileName(FileUpload1.FileName);
            string filePath = Server.MapPath("~/Uploads/") + fileName;
            FileUpload1.SaveAs(filePath);

            // Save the file path to the database

        }

        fileupload3();
        string action = "SAVE", Gstid = "";
        if (Request.QueryString["id"] != null)
        {
            action = "UPDATE";
            Gstid = Request.QueryString["id"].ToString();
        }
        emp.getCategory(action, txtPackName.Text.Trim(), Label1.Text, Gstid);
        Response.Redirect("Categoryadd.aspx");
    }

    protected void btnSaveExit_Click(object sender, EventArgs e)
    {
        Save();
    }


}