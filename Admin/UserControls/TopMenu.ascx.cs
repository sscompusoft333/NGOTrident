using System;
using System.Web;

public partial class Admin_UserControls_TopMenu : System.Web.UI.UserControl
{
    HttpCookie Admin;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["Bhikharam"] != null)
            {
                Admin = Request.Cookies["Bhikharam"];
                lblName.Text = Admin.Values["UserName"].ToString();
                profileuser.HRef = "../EmployeeMaster.aspx?id=" + Admin.Values["UserID"] +"&view=true";
            }
        }
    }
}