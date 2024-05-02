using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddEnquiry_Employee : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    Data data = new Data();
    SqlCommand cmd = new SqlCommand();
    Master getdata = new Master();
    HttpCookie Admin;
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (!IsPostBack)
        {
            if (Request.Cookies["ngojeetart"] == null) { Response.Redirect("../Login.aspx"); }
            
            Admin = Request.Cookies["ngojeetart"];
            if (Request.QueryString["id1"].ToString() == "")
            {
                if(getdata.EditEmployee(Admin["UserId"]).Tables[0].Rows[0]["DepId"].ToString() == "1")
                {
                    Response.Redirect("AssignWorkSalesUpdate.aspx?id=" + Request.QueryString["id"].ToString());
                }
                else
                {
                    Response.Redirect("assignworkreport.aspx");
                }
            }
            Session["AccessRigthsSet"] = getdata.EditEmployee(Admin["UserId"]).Tables[0].Rows[0]["DepId"].ToString() == "2" ? "True" : "False";
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy").Replace('-','/');
            BindDrp();
            Filldata();
        }
    }

    private void BindDrp()
    {
        string query = "Select distinct RoomID,R.Name  from tbl_BOQ B inner join tbl_RoomType R on R.ID = B.RoomId left join tbl_BOQMain BM on BM.BOQID = B.BOQID where BM.CustomerID = " + Request.QueryString["id"] +" and B.BOQID = " + Request.QueryString["id1"].ToString();
        ds = data.getDataSet(query);
        drpRType.DataSource = ds;
        drpRType.DataTextField = "Name";
        drpRType.DataValueField = "RoomID";
        drpRType.DataBind();
        drpRType.Items.Insert(0, new ListItem("Select", "0"));
        drpPRod.Items.Insert(0, new ListItem("Select", "0"));
    }

    private void Filldata()
    {
        Admin = Request.Cookies["ngojeetart"];
        ds = getdata.getAssignWork(Request.QueryString["id"].ToString(),Request.QueryString["id1"].ToString(), Admin["UserId"].ToString(),"");
       // ds = data.getDataSet(cmd);
        repEnquiryAssign.DataSource = ds;
        repEnquiryAssign.DataBind();
    }



    private void FillEnquiry_Employee(String Id)
    {
        hiddenID.Value = Id;
        ds = getdata.EditAssignWork(Id, Request.QueryString["id"].ToString());
        txtDetDesc.Text = ds.Tables[0].Rows[0]["Description"].ToString();
        txtDate.Text = ds.Tables[0].Rows[0]["AssDt"].ToString();
        txtFinishDate.Text = ds.Tables[0].Rows[0]["FinishDt"].ToString();
        drpRType.SelectedValue = ds.Tables[0].Rows[0]["RoomID"].ToString();
        FillProduct();
        drpPRod.SelectedValue = ds.Tables[0].Rows[0]["ProductBOQ"].ToString();
        ischkFinish.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsFinish"].ToString());
        if (txtDetDesc.Text != "")
        {
            btnSave.Text = "Update";
        }
        if (ischkFinish.Checked)
        {
            txtFinishDate.Visible = true;
        }
        else { txtFinishDate.Visible = false; }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (flp.HasFile)
        {    flp.PostedFile.SaveAs(Server.MapPath("../Upload/Enquiry/" + flp.FileName));    }
        Admin = Request.Cookies["ngojeetart"];
        if (txtDate.Text.Trim() != "")
        {   cmd = new SqlCommand("Sp_AssignUpdate");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("descr", txtDetDesc.Text);
            cmd.Parameters.AddWithValue("Dt",data.YYYYMMDD(txtDate.Text));
            cmd.Parameters.AddWithValue("usrId", Admin["UserId"]);
            cmd.Parameters.AddWithValue("enqid", Request.QueryString["id"]);
            cmd.Parameters.AddWithValue("asgid", hiddenID.Value);
            cmd.Parameters.AddWithValue("@file", flp.FileName);
            cmd.Parameters.AddWithValue("@boqid", Request.QueryString["id1"]);
            cmd.Parameters.AddWithValue("@room", drpRType.SelectedValue);
            cmd.Parameters.AddWithValue("@prod", drpPRod.SelectedValue);
            cmd.Parameters.AddWithValue("@FinishDt", ischkFinish.Checked ? data.YYYYMMDD(txtFinishDate.Text):"") ;
            cmd.Parameters.AddWithValue("@finish", ischkFinish.Checked);
            ds = data.getDataSet(cmd);
            reset();
 

            Filldata();
        }

    }

    private void reset()
    {
        txtDetDesc.Text = "";
        txtFinishDate.Text = "";
        drpPRod.SelectedValue = "0";
        drpRType.SelectedValue = "0";
        ischkFinish.Checked = false;
        txtFinishDate.Visible = false;
        btnSave.Text = "Save";
        hiddenID.Value = "0";
        txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy").Replace('-','/');
    }

    protected void Btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssignWorkReport.aspx");
    }



    protected void repEnquiryAssign_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            FillEnquiry_Employee(e.CommandArgument.ToString());
        }
        if (e.CommandName == "Delete")
        {
            Admin = Request.Cookies["ngojeetart"];
            string query = " update tbl_AssignWorkUpdate set IsDeleted = 1  where ID=" + e.CommandArgument + " and  EnqId = " + Request.QueryString["id"].ToString() + " and UserId = " +Admin["UserId"];
            data.executeCommand(query);
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record Deleted Successfully......')", true);
            Filldata();
        }
        if (e.CommandName == "IsActive")
        {
            data.executeCommand("update tbl_AssignWorkUpdate set isLock = (case when isLock=1 then 0 else 1 end) where ID=" + e.CommandArgument + "");

            Filldata();
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Update Successfully......')", true);
        }
    }
    [WebMethod]
    public static string ControlAccess()
    {
        return (string)HttpContext.Current.Session["AccessRigthsSet"];
    }

    protected void drpRType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillProduct();  
    }

    private void FillProduct()
    {
        string query = "Select  B.ID,P.name  from tbl_BOQ B left join tbl_Product P on P.ID = B.ProdId " +
           "left join tbl_BOQMain BM on BM.BOQID = B.BOQID " +
           "where BM.CustomerID = " + Request.QueryString["id"].ToString() + " and RoomId = " + drpRType.SelectedValue + "and B.BOQID=" + Request.QueryString["id1"].ToString();
         DataSet ds1 = data.getDataSet(query);
        drpPRod.DataSource = ds1;
        drpPRod.DataTextField = "Name";
        drpPRod.DataValueField = "ID";
        drpPRod.DataBind();
        drpPRod.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void ischkFinish_CheckedChanged(object sender, EventArgs e)
    {
        if (ischkFinish.Checked)
        {
            txtFinishDate.Visible = true;
            txtFinishDate.Text = DateTime.Now.ToString("dd/MM/yyyy").Replace('-', '/');
        }
        else { txtFinishDate.Visible = false; }
    }
}