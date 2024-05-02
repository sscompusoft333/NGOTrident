using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddEnquiry_Employee : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    Data data = new Data();
    string query;
    SqlCommand cmd = new SqlCommand();
    Master getdata = new Master();
    HttpCookie Admin;
    //FlurinaAPI flurinaAPI = new FlurinaAPI();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["ngojeetart"] == null) { Response.Redirect("../Login.aspx"); }
            Admin = Request.Cookies["ngojeetart"];
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy").Replace('-', '/');
            txtEDate.Text = DateTime.Now.ToString("dd/MM/yyyy").Replace('-', '/');
            BindDrpDepartment();
            Filldata();
          //  flurinaAPI.GetProduct();
            if (Request.QueryString["id"] == null)
            {
                ControlVisible.Visible = false;
            }
        }
    }


    private void Filldata()
    {
        SqlCommand cmd = new SqlCommand("sp_GetEnquiryAssignList");
        cmd.CommandType = CommandType.StoredProcedure;

        if (Admin["Type"] == "Admin")
        {
            if (Request.QueryString["id"] != null)
                cmd.Parameters.AddWithValue("@enqid", Request.QueryString["id"].ToString());
            else
                cmd.Parameters.AddWithValue("@enqid", 0);
            cmd.Parameters.AddWithValue("@usrid", Admin["UserId"]);
        }
        else
        {
            cmd.Parameters.AddWithValue("@enqid", Request.QueryString["id"].ToString());
            cmd.Parameters.AddWithValue("@usrid", 0);
        }
        ds = data.getDataSet(cmd);
        repEnquiryAssign.DataSource = ds;
        repEnquiryAssign.DataBind();
    }

    private void BindDrpDepartment()
    {
        ds.Clear();
        ds = getdata.getdepartment();
        drpDept.DataSource = ds;
        drpDept.DataValueField = "ID";
        drpDept.DataTextField = "Name";
        drpDept.DataBind();
        drpDept.Items.Insert(0, new ListItem("Select", "0"));
    }

    private void FillEnquiry_Employee(String Id)
    {
        hiddenID.Value = Id;
        ds1 = getdata.EditAssignEnquiry(Id, Request.QueryString["id"].ToString());
        drpDept.SelectedValue = ds1.Tables[0].Rows[0]["DeptId"].ToString();
        FillEmp();
        drpEmp.SelectedValue = ds1.Tables[0].Rows[0]["EmpId"].ToString();
        txtDate.Text = ds1.Tables[0].Rows[0]["AssDate"].ToString();
        txtEDate.Text = ds1.Tables[0].Rows[0]["EstDate"].ToString();
        if (drpEmp.SelectedValue != "0" || drpDept.SelectedValue != "0")
        {
            btnSave.Text = "Update";
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        Admin = Request.Cookies["ngojeetart"];
        if (drpDept.Text != "")
        {
            cmd = new SqlCommand("Sp_EmpAssign");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("deptid", drpDept.SelectedValue);
            cmd.Parameters.AddWithValue("empid", drpEmp.SelectedValue);
            cmd.Parameters.AddWithValue("AssignDt", data.YYYYMMDD(txtDate.Text).ToString());
            cmd.Parameters.AddWithValue("EstimateDt", data.YYYYMMDD(txtEDate.Text).ToString());
            cmd.Parameters.AddWithValue("usrId", Admin["UserId"]);
            cmd.Parameters.AddWithValue("enqid", Request.QueryString["id"]);
            cmd.Parameters.AddWithValue("asgid", hiddenID.Value);
            ds = data.getDataSet(cmd);
            Response.Redirect("AddEnquiry_Employee.aspx?id=" + Request.QueryString["id"].ToString());
        }

    }

    protected void Btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Enquiry.aspx");
    }

    protected void drpDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillEmp();
    }

    private void FillEmp()
    {
        ds.Clear();
        ds = getdata.getEmployee();
        DataTable dt = ds.Tables[0];
        DataView dv = dt.DefaultView;
        dv.RowFilter = "DepId=" + drpDept.SelectedValue;
        dv.Sort = "Name";
        drpEmp.DataSource = dv;
        drpEmp.DataValueField = "ID";
        drpEmp.DataTextField = "Name";
        drpEmp.DataBind();
        drpEmp.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void repEnquiryAssign_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            FillEnquiry_Employee(e.CommandArgument.ToString());
        }
        if (e.CommandName == "Delete")
        {
            query = query + " update tbl_EnquiryAssign set IsDeleted = 1  where ID=" + e.CommandArgument + " and  EnqId = " + Request.QueryString["id"].ToString();
            data.executeCommand(query);
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record Deleted Successfully......')", true);
            Filldata();
        }
    }


    protected void repEnquiryAssign_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lnkEdit = (LinkButton)e.Item.FindControl("lnkEdit");
            LinkButton lnkDelete = (LinkButton)e.Item.FindControl("lnkDelete");
            lnkEdit.Visible = (Request.QueryString["id"] == null) ? false : true;
            lnkDelete.Visible = (Request.QueryString["id"] == null) ? false : true;
        }
    }
}