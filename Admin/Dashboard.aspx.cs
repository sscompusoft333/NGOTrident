using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Dashboard : System.Web.UI.Page
{
    private HttpCookie Admin;
    Master getdata = new Master();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["ngojeetart"] == null) { Response.Redirect("../Login.aspx"); }

            Admin = Request.Cookies["ngojeetart"];
            //FillDetails(Admin["UserId"]);
            
            //if (Session["CheckInId"] != null)
            //{
               
            //        linkloc.InnerText = "CheckOUT";
            //}
            //else linkloc.InnerText = "CheckIN";


        }
        
    }

    //private void FillDetails(string v)
    //{
    //    DataTable tbl = getdata.AccessRights("BOQ.aspx", Admin["UserId"]).Tables[0];
    //    DataTable dt = new DataTable();
    //    if (tbl.Rows.Count > 0)
    //    {
    //       dt = getdata.getBOQList("", Convert.ToBoolean(tbl.Rows[0]["AssignAllStatus"]) ? "1" : Admin["UserId"],"").Tables[0];
    //        Ttlboq.InnerHtml = dt.Rows.Count.ToString();
    //        Ttlcmp.InnerHtml = dt.Select("Status='Complete'").Length.ToString();
    //    }
    //    tbl = getdata.AccessRights("Enquiry.aspx", Admin["UserId"]).Tables[0];
    //    if (tbl.Rows.Count > 0) { 
    //    dt = getdata.getEnquiryList("", "", Convert.ToBoolean(tbl.Rows[0]["AssignAllStatus"]) ? "1" : Admin["UserId"]).Tables[0];
    //    Ttlenq.InnerHtml = dt.Rows.Count.ToString();
    //    Ttlcnf.InnerHtml = dt.Select("Status='Confirm'").Length.ToString(); 
    //}
    //}
}