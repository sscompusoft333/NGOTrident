using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Odbc;
using System.Data.SqlClient;

/// <summary>
/// Summary description for GetData
/// </summary>
public class GetData
{
    Data data = new Data();
    DataSet ds = new DataSet();
    SqlCommand cmd = new SqlCommand();
    string query = "";

    public void getBOQDetail(string v)
    {
        throw new NotImplementedException();
    }

    public GetData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void FillTypeOfConstruction(ListBox drptypeConst)
    {
        ds = data.getDataSet("select * from Tbl_TypeConst where IsDeleted=0 Order by TypeName");
        drptypeConst.DataSource = ds;
        drptypeConst.DataTextField = "TypeName";
        drptypeConst.DataValueField = "ID";
        drptypeConst.DataBind();
    }   



    public void FillRoomType(ListBox drptypeConst)
    {
        ds = data.getDataSet("select * from Tbl_RoomType where IsDeleted=0 Order by Name");
        drptypeConst.DataSource = ds;
        drptypeConst.DataTextField = "Name";
        drptypeConst.DataValueField = "ID";
        drptypeConst.DataBind();
    }
    public void FillCustomer(DropDownList drptypeConst,string uid)
    {
        if (uid == "1") {
            ds = data.getDataSet("select * from tbl_Enquiry where IsDeleted=0 and UserId = iif(" + uid + "=1,UserId," + uid + ") Order by Name");
        }
        else { 
        ds = data.getDataSet("select distinct ID, Name from( "+
                              "select ID, Name from tbl_Enquiry where userid = "+uid+ "and IsDeleted = 0 "+
                              "union all " +
                              "select E.ID, E.Name from tbl_EnquiryAssign EA "+
                              "left join tbl_Enquiry E on E.ID = EA.EnqId "+
                              "where EA.empID = " + uid + " and EA.IsDeleted = 0) A order by Name ");
        }
        drptypeConst.DataSource = ds;
        drptypeConst.DataTextField = "Name";
        drptypeConst.DataValueField = "ID";
        drptypeConst.DataBind();
        
    }   
    public void FillEnquiryFile(DropDownList drp,string e)
    {
        ds = data.getDataSet("select * from tbl_AssignWorkUpdate where IsDeleted=0 and EnqId ="+ e +" Order by AddedDate");
        drp.DataSource = ds;
        drp.DataTextField = "WorkFile";
        drp.DataValueField = "ID";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("Select", "0"));
    }
    public void FillProduct(DropDownList drpName,string mid,string brndid)
    {
        ds = data.getDataSet("select * from tbl_Product where IsDeleted=0 and MaterialID = '"+mid +"' and BrandID = '"+brndid+"' Order by Name");
        drpName.DataSource = ds;
        drpName.DataTextField = "Name";
        drpName.DataValueField = "ID";
        drpName.DataBind();
        drpName.Items.Insert(0, new ListItem("Select Name", "0")); 
        
    }
    public void FillFinish(DropDownList drpFinish)
    {
        ds = data.getDataSet("select * from Tbl_MaterialType where IsDeleted=0  Order by Name");
        drpFinish.DataSource = ds;
        drpFinish.DataTextField = "Name";
        drpFinish.DataValueField = "ID";
        drpFinish.DataBind();
        drpFinish.Items.Insert(0, new ListItem("Select Item", "0"));
    }
    public void FillUnit(DropDownList drp)
    {
        ds = data.getDataSet("select * from tbl_Unit where IsDeleted=0 Order by Name");
        drp.DataSource = ds;
        drp.DataTextField = "Name";
        drp.DataValueField = "ID";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("Select Unit", "0"));
    }
    public void Fillpack(DropDownList drp)
    {
        ds = data.getDataSet("select * from tbl_Package where IsDeleted=0 Order by Name");
        drp.DataSource = ds;
        drp.DataTextField = "Name";
        drp.DataValueField = "ID";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("Select Unit", "0"));
    }

    public void FillColor(DropDownList drp)
    {
        ds = data.getDataSet("select * from tbl_MaterialColor where IsDeleted=0 Order by Name");
        drp.DataSource = ds;
        drp.DataTextField = "Name";
        drp.DataValueField = "ID";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("Select Color", "0"));
    } 
    public void FillBrand(DropDownList drp)
    {
        ds = data.getDataSet("select * from tbl_Brand where IsDeleted=0 Order by Name");
        drp.DataSource = ds;
        drp.DataTextField = "Name";
        drp.DataValueField = "ID";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("Select Brand", "0"));
    }
}