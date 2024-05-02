using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;


public partial class login : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    Data data = new Data();
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext.Current.Response.Cookies["ngojeetart"].Expires = DateTime.Now.AddDays(-1d);
            if (Request.Params["logout"] != null)
            {
                HttpContext.Current.Response.Cookies["ngojeetart"].Expires = DateTime.Now.AddDays(-1d);
            }
        }
    }

    protected void LogBtn_Click(object sender, EventArgs e)
    {
       // string url = System.Configuration.ConfigurationManager.AppSettings["SiteUrl"].ToString();
        if (txtuser.Value.Trim() != "" && txtpass.Value.Trim() != "")
        {
            cmd = new SqlCommand("Sp_Login");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@UserName", txtuser.Value);
            cmd.Parameters.AddWithValue("@Password", txtpass.Value);
            ds = data.getDataSet(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                // string ip = Request.ServerVariables["REMOTE_ADDR"].ToString();
                //SaveLoginLogo(dsA.Tables[0].Rows[0]["username"].ToString(), dsA.Tables[0].Rows[0]["uid"].ToString(), "admin", ip);
                HttpCookie Admin = new HttpCookie("ngojeetart");
                Admin.Expires = DateTime.Now.AddDays(1d);

                Admin.Values.Add("EmailId", ds.Tables[0].Rows[0]["Email"].ToString());
                Admin.Values.Add("UserName", ds.Tables[0].Rows[0]["Name"].ToString());
                Admin.Values.Add("UserId", ds.Tables[0].Rows[0]["ID"].ToString());
                Admin.Values.Add("Type", ds.Tables[0].Rows[0]["Type"].ToString());
                Response.Cookies.Add(Admin);

                if (ds.Tables[0].Rows[0]["Type"].ToString() == "Admin")
                    Response.Redirect("~/Admin/Dashboard.aspx");
                else
                    Response.Redirect("~/Admin/Dashboard.aspx");
            }
            else
            {
                lblMes.Visible = true;
            }
        }
        else
        {
            lblMes.Visible = true;
        }
    }

    public void Login()
    {
        //string url = System.Configuration.ConfigurationManager.AppSettings["SiteUrl"].ToString();
        //if (IsValid)
        //{
        //    Response.Redirect(url + "/Admin/");
        //}
    }

    protected void btnChangePwd_Click(object sender, EventArgs e)
    {
        if (txtcode.Text.Trim() != "")
        {
            if (data.Exist("select * from tbl_Employee WHERE EmpCode='" + txtcode.Text.Trim() + "'"))
            {
                Response.Redirect("ChangePassword.aspx?code="+txtcode.Text.Trim());
            }
          
        }
    }

    protected void txtcode_TextChanged(object sender, EventArgs e)
    {
        
    }
}