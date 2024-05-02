using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_AddProductMaster : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    Master master = new Master();
    HttpCookie Admin;
   Data data = new Data();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Request.Cookies["Bhikharam"] == null) { Response.Redirect("../Login.aspx"); }
            //Admin = Request.Cookies["Bhikharam"];

            ////Session["AccessRigthsSet"] = emp.AccessRights("Employee.aspx", Admin["UserId"]).Tables[0];
            ////master.PartyCatgDrp(drpCustCatg); 
            //master.PartyDrp(drpCustName);
            //master.TransporterDrp(Drptran);
            //txtOrder.Text = getAutoNum();
            master.drpCategory(drpcategory);
            txtOrdDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            //drpMfgMonth.SelectedValue = DateTime.Now.ToString("MMM").ToUpper(); 

            if (ViewState["tbl"] == null)
            {
                DataTable tbl = new DataTable();
                tbl.Columns.Add("Id", typeof(Int32));

                tbl.Columns.Add("image", typeof(string));

                ViewState["tbl"] = tbl;
            }

            if (Request.QueryString["id"] != null)
            {
                fillData(Request.QueryString["id"].ToString());
                btnSaveExit.Text = "Update & Next";
                // btnSaveAnother.Visible = false;
            }



            

        }
        //drpyear.SelectedValue = "2024";
        //Panel1.Visible = false;

    }


    private string getAutoNum()
    {
        return data.getDataSet("Select isnull(max(OrderNo)+1,1) from BookingOrder").Tables[0].Rows[0][0].ToString();
    }
    public void fillData(string id)
    {
        ds = data.getDataSet(" select * from vw_Product where id = " + id  + " ORDER BY ID desc ");
       txttitle.Text = ds.Tables[0].Rows[0]["productName"].ToString();
        txtprice.Text = ds.Tables[0].Rows[0]["price"].ToString();
        Txtshort.Text = ds.Tables[0].Rows[0]["shortdesc"].ToString();
        Txtdiscountprice.Text = ds.Tables[0].Rows[0]["discount"].ToString();
        ckeditorTextbox.Text = ds.Tables[0].Rows[0]["longdesc"].ToString();
        txtkeywords.Text = ds.Tables[0].Rows[0]["keywords"].ToString();
        txtcolor.Text = ds.Tables[0].Rows[0]["color"].ToString();
        Txtstock.Text = ds.Tables[0].Rows[0]["stock"].ToString();
        TXTSKU.Text = ds.Tables[0].Rows[0]["SKU"].ToString();
        TxtADDITIONAL.Text = ds.Tables[0].Rows[0]["addinfo"].ToString();
    
        drpcategory.SelectedValue = ds.Tables[0].Rows[0]["Categoryid"].ToString();


        ds = data.getDataSet(" select * from tbl_image where Productid = " + id + " ORDER BY ID desc ");
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable tbl = (DataTable)ViewState["tbl"];
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DataRow rw = tbl.NewRow();

                rw["image"] = dr["image"];

                rw["Id"] = tbl.Rows.Count + 1;
                tbl.Rows.Add(rw);
            }
            ViewState["tbl"] = tbl;
            rep.DataSource = ViewState["tbl"];
            rep.DataBind();
        }
    }

    public void Save()
    {

        string action = "SAVE", oid = "";
        if (Request.QueryString["id"] != null)
        {
            action = "UPDATE";
            oid = Request.QueryString["id"].ToString();
        }
        SqlCommand cmd = new SqlCommand("PROC_Product");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@action", action);
        cmd.Parameters.AddWithValue("@productName", txttitle.Text);
        cmd.Parameters.AddWithValue("@longdesc", ckeditorTextbox.Text);
        cmd.Parameters.AddWithValue("@categoryid", drpcategory.SelectedValue);
        cmd.Parameters.AddWithValue("@discount", Txtdiscountprice.Text.Trim());
        cmd.Parameters.AddWithValue("@Price", txtprice.Text.Trim());
        cmd.Parameters.AddWithValue("@color", txtcolor.Text.Trim());
        cmd.Parameters.AddWithValue("@stock", Txtstock.Text.Trim());
        cmd.Parameters.AddWithValue("@shortdesc", Txtshort.Text.Trim());
        cmd.Parameters.AddWithValue("@keywords", txtkeywords.Text);
        cmd.Parameters.AddWithValue("@addinfo", TxtADDITIONAL.Text);
        cmd.Parameters.AddWithValue("@SKU", TXTSKU.Text);
        cmd.Parameters.AddWithValue("@Id", oid);

        ds = data.getDataSet(cmd);

        if (ds.Tables[0].Rows[0]["STATUS"].ToString() == "1")
        {
            string id = "";

            if (Request.QueryString["id"] != null)
            {
                id = Request.QueryString["id"].ToString();
            }
            else
            {
                id = ds.Tables[0].Rows[0]["RESULT"].ToString();
            }


            DataTable dtbl = (DataTable)ViewState["tbl"];
            DataTable dt = new DataTable();
            //Add columns  PurchaseType,POID,MaterialId,PackId,Qty,UnitId,Price
            dt.Columns.Add(new DataColumn("ProductId", typeof(string)));
            dt.Columns.Add(new DataColumn("Image", typeof(string)));

            //Add rows  

            foreach (DataRow dr in dtbl.Rows)
            {
                dt.Rows.Add(id, dr["Image"]);
            }

            // Use the SqlConnection constructor to specify the connection string
            SqlCommand sqlcom = new SqlCommand("sp_ImgaeSubmit");
            sqlcom.Parameters.Clear();
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Parameters.AddWithValue("@tabledetail", dt);
            data.executeCommand(sqlcom);







        }
    }





    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderBooking.aspx");
    }
    [WebMethod]
    public static string ControlAccess()
    {
        DataTable tbl1 = (DataTable)HttpContext.Current.Session["AccessRigthsSet"];
        return tbl1.Rows[0]["AddStatus"].ToString() + "," + tbl1.Rows[0]["EditStatus"].ToString() + "," + tbl1.Rows[0]["DeleteStatus"].ToString() + "," + tbl1.Rows[0]["ViewP"].ToString();
    }


   
    
    private void fieldsSet(string arg)
    {
        DataTable tbl = (DataTable)ViewState["tbl"];
        DataRow[] dr = tbl.Select("ID = " + arg);
        for (int i = 0; i < dr.Length; i++)
        {
            hddid.Value = dr[i]["Id"].ToString();
            //drpComp.SelectedValue = dr[i]["CompanyId"].ToString();


        }
    }
        protected void btnadd_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string fileName = Path.GetFileName(FileUpload1.FileName);
            string filePath = Server.MapPath("~/Uploads/") + fileName;
            FileUpload1.SaveAs(filePath);

            // Save the file path to the database

        }

        DataTable tbl = (DataTable)ViewState["tbl"];
        DataRow rw = tbl.NewRow();

        if (hddid.Value != "")
        {
            rw = tbl.Select("Id=" + hddid.Value)[0];
            rw["Id"] = hddid.Value;
        }

      
            
            rw["image"] = FileUpload1.FileName;
            

            if (hddid.Value == "")
            {
                rw["Id"] = tbl.Rows.Count + 1;
                tbl.Rows.Add(rw);
            }

            ViewState["tbl"] = tbl;
            rep.DataSource = ViewState["tbl"];
            rep.DataBind();
       
    }



    protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            fieldsSet(e.CommandArgument.ToString());
        }
        if (e.CommandName == "Delete")
        {
            DataTable tbl = (DataTable)ViewState["tbl"];
            DataRow dr = tbl.Select("ID=" + e.CommandArgument.ToString())[0];
            tbl.Rows.Remove(dr);
            ViewState["tbl"] = tbl;
            rep.DataSource = ViewState["tbl"];
            rep.DataBind();
        }

    }




    protected void btnSaveExit_Click(object sender, EventArgs e)
    {
        Save();
        Response.Redirect("Addproductlist.aspx");
    }

  

   
}