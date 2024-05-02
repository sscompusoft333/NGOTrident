using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;


public class Master
{
    DataSet ds = new DataSet();
    Data data = new Data();
    SqlCommand cmd = new SqlCommand();
    string query = "";
    string SessionID = "";
    int res = 0;
    HttpCookie Admin;
    string userid = "";

    public Master()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public DataSet getEmployee()
    {
        query = "select * from tbl_Employee where IsDeleted=0  order by Name asc";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getPaymentVoucherList(string v)
    {
        cmd = new SqlCommand("sp_GetVoucherList");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", v);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public object AccessRights(string v, object p)
    {
        throw new NotImplementedException();
    }

    public DataSet AccessRights(string v, string userid)
    {
        cmd = new SqlCommand("Sp_UserAccess");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@pagelink", v);
        cmd.Parameters.AddWithValue("@uid", userid);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet getEmpList(string e, string dep)
    {
        cmd = new SqlCommand("sp_GetEmployeeList");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@emp", e);
        cmd.Parameters.AddWithValue("@dep", dep);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet getAttendance(string ACTION, string id, string EMPID,string DEPTID,string LATITUDEIN,string LONGITUDEIN)
    {
        cmd = new SqlCommand("sp_AttendanceRpt");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACTION", ACTION);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@EMPID", EMPID);
        cmd.Parameters.AddWithValue("@DEPTID", DEPTID);
        cmd.Parameters.AddWithValue("@LATITUDEIN", LATITUDEIN);
        cmd.Parameters.AddWithValue("@LONGITUDEIN", LONGITUDEIN);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet getBOQList(string bdate, string uid,string sts)
    {
        cmd = new SqlCommand("sp_GetBOQList");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@dt", bdate);
        cmd.Parameters.AddWithValue("@usrid", uid);
        cmd.Parameters.AddWithValue("@sts", sts);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet getBOQDetail(string id)
    {
        cmd = new SqlCommand("sp_GetBOQDetail");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@boq", id);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet getProdList(string pd, string br, string ct)
    {
        cmd = new SqlCommand("sp_GetProductList");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@prod", pd);
        cmd.Parameters.AddWithValue("@brand", br);
        cmd.Parameters.AddWithValue("@catg", ct);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet getEnquiryList(string n, string m, string uid)
    {
        cmd = new SqlCommand("sp_GetEnquiryList");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@pname", n);
        cmd.Parameters.AddWithValue("@mail", m);
        cmd.Parameters.AddWithValue("@usrid", uid);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public void EmployeeDrop(DropDownList drp)
    {
        //    select distinct  E.*,D.Name As Department
        //from tbl_Employee E

        //Left Join tbl_Department D on D.ID = E.DepId

        //where E.IsDeleted = 0  and E.ID <> 1

        //and E.ID = iif(@emp = 0, E.ID, @emp) and D.ID = iif(@dep = 0, d.Id, @dep)  order by E.Name asc

        string query = "SELECT E.* " +
                       "FROM tbl_Employee E " +
                       "LEFT JOIN tbl_Department D ON D.ID = E.DepId " +
                       "WHERE E.IsDeleted = 0 AND E.ID <> 1 " +
                       "ORDER BY Name";

         // assuming ID 1 is the employee to exclude

        ds = data.getDataSet(query);
        drp.DataSource = ds;
        drp.DataTextField = "Name";
        drp.DataValueField = "ID";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("Select", "0"));

    }

    public DataSet getCategory(string action, string BrandName,string image1, string id)
    {
        cmd = new SqlCommand("PROC_Category");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACTION", action);
        cmd.Parameters.AddWithValue("@BrandName", BrandName);
		cmd.Parameters.AddWithValue("@image", image1);
        cmd.Parameters.AddWithValue("@ID", id);
        ds = data.getDataSet(cmd);
        return ds;
    }

	 public DataSet getphone(string action, string phone)
    {
        cmd = new SqlCommand("PROC_user");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACTION", action);
        cmd.Parameters.AddWithValue("@Phone", phone);
	    ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet getSubCategory(string action, string CategoryId, string SubName, string id)
    {
        cmd = new SqlCommand("PROC_SubCategory");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACTION", action);
        cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
        cmd.Parameters.AddWithValue("@SubName", SubName);
        cmd.Parameters.AddWithValue("@ID", id);
        ds = data.getDataSet(cmd);
        return ds;
    }



    public void EnquiryDrop1(DropDownList drp)
    {
        query = "select * from tbl_Enquiry1 where IsDeleted=0 and ID<>1 order by Name";
        ds = data.getDataSet(query);
        drp.DataSource = ds;
        drp.DataTextField = "Name";
        drp.DataValueField = "ID";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("Select", "0"));
    }
    public void ConfirmBOQDrop(DropDownList drp)
    {
        query = "Select BOQID,BOQNo from tbl_BOQMain where  Status like 'Confirm'";
        ds = data.getDataSet(query);
        drp.DataSource = ds;
        drp.DataTextField = "BOQNo";
        drp.DataValueField = "BOQID";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("Select", "0"));
    }

    public void FillDrop(DropDownList drp, String tbl)
    {
        query = "select * from " + tbl + " where IsDeleted=0 order by Name ";
        ds = data.getDataSet(query);
        drp.DataSource = ds;
        drp.DataTextField = "Name";
        drp.DataValueField = "ID";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("Select", "0"));
    }
    public void FillEnqDrop(DropDownList drp, string uid)
    {
        query = "select * from tbl_Enquiry where IsDeleted=0 and UserId = iif(" + uid + " =1,UserId," + uid + ") order by Name ";
        ds = data.getDataSet(query);
        drp.DataSource = ds;
        drp.DataTextField = "Name";
        drp.DataValueField = "ID";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("Select", "0"));
    }
    public void drpCategory(DropDownList drp)
    {
        query = "Select * from tbl_Category where IsDeleted=0 Order by categoryName";
        ds = data.getDataSet(query);
        drp.DataSource = ds;
        drp.DataTextField = "categoryName";
        drp.DataValueField = "Id";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("Select", "0"));
    }

    public void drpadd(DropDownList drp,string id)
    {
        query = "Select id,Address from tbl_shiping where user = '" + id + "' Order by id";
        ds = data.getDataSet(query);
        drp.DataSource = ds;
        drp.DataTextField = "Address";
        drp.DataValueField = "Id";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("Select", "0"));
    }
    public void drpSubCategory(DropDownList drp)
    {
        query = "Select * from tbl_SubCategory Order by SubcategoryName";
        ds = data.getDataSet(query);
        drp.DataSource = ds;
        drp.DataTextField = "SubName";
        drp.DataValueField = "Id";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("Select", "0"));
    }
    public void FillBOQDrop(DropDownList drp)
    {
        query = "select * from tbl_BOQMain where IsDeleted=0 order by BOQNo ";
        ds = data.getDataSet(query);
        drp.DataSource = ds;
        drp.DataTextField = "BOQNo";
        drp.DataValueField = "BOQID";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("Select", "0"));
    }

    public DataSet EditEmployee(string id)
    {
        query = "select * from tbl_Employee where IsDeleted=0 and ID='" + id + "'";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getSettings()
    {
        query = "select * from tbl_Settings";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet EditProduct(string id)
    {
        query = "select * from tbl_Product where IsDeleted=0 and ID='" + id + "'";
        query += "select tbl_ProductImage_Color.*,tbl_MaterialColor.Name as Color from tbl_ProductImage_Color left join tbl_MaterialColor on  tbl_MaterialColor.ID = tbl_ProductImage_Color.ColorId where tbl_ProductImage_Color.isDeleted=0 and tbl_ProductImage_Color.ProdId= '" + id + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet EditEnquiry(string id)
    {
      
        query = "select E.*,E1.Name as Emp,S1.Name as Emp1,D.Name as Dept ,E2.PuchaseCost,E2.SaleCost,E2.Recevied,E2.Pending_A  from tbl_Enquiry1 E " +
            " left join tbl_Package D on D.ID = E.PackId" +
            " left join tbl_Employee E1 on E1.ID = E.Submittedid" +
            " left join tbl_Employee S1 on S1.ID = E.Workid" +
            " left join tbl_EnquiryAmount E2 on E2.Eid = E.Eid" +
            " where E.IsDeleted = 0  and E.ID='" + id + "'";
        
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet GetEnquiryDiscuss(string id)
    {
        query = "select * from tbl_EnquiryDiscussion " +
            " where EnqID='" + id + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet EditAssignEnquiry(string id, string eid)
    {
        query = "select *,convert(nvarchar(100),AssignDate,103) as AssDate,convert(nvarchar(100),EstimatedDate,103) as EstDate from tbl_EnquiryAssign where IsDeleted=0 and ID='" + id + "' and EnqId = '" + eid + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet EditAssignWork(string id, string eid)
    {
        query = "select *,Convert(nvarchar(10),FinishDate,103) as FinishDt,Convert(nvarchar(10),RDate,103) as AssDt from tbl_AssignWorkUpdate where IsDeleted=0 and ID='" + id + "' and EnqId = '" + eid + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getAssignWork(string id, string bid, string uid, string pid)
    {
        if (bid != "")
        {
            query = " Select ASG.*,P.Name as Product, R.Name as Room,convert(varchar, RDate, 103) as UDate,case when IsFinish=1 then convert(varchar,FinishDate, 103)  end as FinishDt from tbl_AssignWorkUpdate ASG " +
"left join tbl_BOQ B on B.ID = ASG.ProductBOQ " +
"left join tbl_Product P on P.ID = B.ProdId " +
"left join tbl_RoomType R on R.ID = B.RoomId " +
                " where ASG.IsDeleted = 0 and EnqId = '" + id + "' and UserId = '" + uid + "' and ASG.BOQID = iif('" + bid + "' = '',ASG.BOQID,'" + bid + "') and P.name is not null";
        }
        else
        {
            query = " Select ASG.*,P.Name as Product,R.Name as Room, convert(varchar, RDate, 103) as UDate,case when IsFinish=1 then convert(varchar,FinishDate, 103)  end as FinishDt from tbl_AssignWorkUpdate ASG " +
" left join tbl_BOQ B on B.ID = ASG.ProductBOQ " +
" left join tbl_Product P on P.ID = B.ProdId " +
"left join tbl_RoomType R on R.ID = B.RoomId " +
" where ASG.IsDeleted = 0 and EnqId = '" + id + "' and UserId = '" + uid + "' and ProductBOQ = iif('" + pid + "' = '', ProductBOQ, '" + pid + "')";
        }
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet Instate(string Stataname, string std, string id)
    {
        cmd = new SqlCommand("Sp_state");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("State", Stataname);
        cmd.Parameters.AddWithValue("@stdcode", std);
        cmd.Parameters.AddWithValue("@id", id);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public bool getUnitDimension(string id)
    {
        ds = data.getDataSet("select IsDimension from tbl_Unit where IsDeleted=0 and ID='" + id + "'");
        return Convert.ToBoolean(ds.Tables[0].Rows[0][0]);
    }

    public DataSet InCity(string Cityname, string Statename, string dist, string id)
    {
        cmd = new SqlCommand("Sp_City");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("State", Statename);
        cmd.Parameters.AddWithValue("City", Cityname);
        cmd.Parameters.AddWithValue("@distFromCFA", dist);
        cmd.Parameters.AddWithValue("@id", id);
        ds = data.getDataSet(cmd);
        return ds;

    }

    public DataSet getCity(string c, string s)
    {

        cmd = new SqlCommand("Sp_Getcity");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@state", s);
        cmd.Parameters.AddWithValue("@city", c);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet EditCity(string Id)
    {
        query = "select * from tbl_city where IsDeleted=0 and ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }

    public string ConvertDDMMYYYY(string d)
    {
        string dat = d;
        string[] aa = dat.Split('/');
        dat = aa[1] + "/" + aa[0] + "/" + aa[2];
        return dat;
    }



    public int InsertEmployee(string empid, string employee, string address, string contact, string adharno, string dbo, string fathername, string salary, string ac,
        string bank, string branch, string adharDoc, string bankDoc, string acType, string ifsc, string userid, string password, string jDate, string adharBack,
        string DesignationId, string Granter, string Photo, string Title, string Relation, string RelativeContactNo, string Dose1Certificates, string Dose2Certificates,
        string Dose1Date, string Dose2Date, string DocumentId, string DocumentNo, string EmailId, string IdCard, string Documents, string pincod)
    {
        int aa = 0;
        cmd = new SqlCommand("Sp_InsEmployee");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@EmployeeName", employee);
        cmd.Parameters.AddWithValue("@Address", address);
        cmd.Parameters.AddWithValue("@ContactInfo", contact);
        cmd.Parameters.AddWithValue("@AdharNo", adharno);
        cmd.Parameters.AddWithValue("@AdharDoc", adharDoc);
        if (dbo != "")
            cmd.Parameters.AddWithValue("@DBO", ConvertDDMMYYYY(dbo));
        else
            cmd.Parameters.AddWithValue("@DBO", DBNull.Value);
        cmd.Parameters.AddWithValue("@FathersName", fathername);
        if (salary != "")
            cmd.Parameters.AddWithValue("@Salary", salary);
        else
            cmd.Parameters.AddWithValue("@Salary", "0");
        cmd.Parameters.AddWithValue("@BankName", bank);
        cmd.Parameters.AddWithValue("@AcountNo", ac);
        cmd.Parameters.AddWithValue("@Branch", branch);
        cmd.Parameters.AddWithValue("@BankDoc", bankDoc);
        cmd.Parameters.AddWithValue("@EmpId", empid);
        cmd.Parameters.AddWithValue("@AcType", acType);
        cmd.Parameters.AddWithValue("@IFSCCode", ifsc);

        cmd.Parameters.AddWithValue("@UserId", userid);
        cmd.Parameters.AddWithValue("@Password", password);
        if (jDate != "")
            cmd.Parameters.AddWithValue("@JoinDate", ConvertDDMMYYYY(jDate));
        else
            cmd.Parameters.AddWithValue("@JoinDate", DBNull.Value);

        cmd.Parameters.AddWithValue("@AdharBack", adharBack);
        cmd.Parameters.AddWithValue("@DesignationId", DesignationId);
        cmd.Parameters.AddWithValue("@GranterId", Granter);
        cmd.Parameters.AddWithValue("@Photo", Photo);
        cmd.Parameters.AddWithValue("@Title", Title);
        cmd.Parameters.AddWithValue("@Relation", Relation);
        cmd.Parameters.AddWithValue("@RelativeContactNo", RelativeContactNo);

        cmd.Parameters.AddWithValue("@Dose1Certificates", Dose1Certificates);
        cmd.Parameters.AddWithValue("@Dose2Certificates", Dose2Certificates);
        cmd.Parameters.AddWithValue("@Dose1Date", Dose1Date != "" ? ConvertDDMMYYYY(Dose1Date) : DBNull.Value.ToString());
        cmd.Parameters.AddWithValue("@Dose2Date", Dose2Date != "" ? ConvertDDMMYYYY(Dose2Date) : DBNull.Value.ToString());
        cmd.Parameters.AddWithValue("@DocumentId", DocumentId);
        cmd.Parameters.AddWithValue("@DocumentNo", DocumentNo);
        cmd.Parameters.AddWithValue("@EmailId", EmailId);
        cmd.Parameters.AddWithValue("@IdCard", IdCard);
        //cmd.Parameters.AddWithValue("@EmpCode", EmpCode);
        cmd.Parameters.AddWithValue("@Documents", Documents);
        cmd.Parameters.AddWithValue("@pin", pincod);
        ds = data.getDataSet(cmd);
        return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
    }
    public int InsertEmpCompany(string EmpId, string CompanyId)
    {
        int aa = 0;
        cmd = new SqlCommand("Usp_EmpCompanyIns");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@EmpId", EmpId);
        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
        return data.executeCommand(cmd);
    }

    public int InsertEnqConstType(string EnqId, string TypeId)
    {
        cmd = new SqlCommand("sp_EnquiryConstType");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@enqId", EnqId);
        cmd.Parameters.AddWithValue("@typeId", TypeId);
        return data.executeCommand(cmd);
    }

    public int InsertEmpFirm(string EmpId, string CompanyId)
    {
        int aa = 0;
        cmd = new SqlCommand("Usp_EmpFirmIns");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@EmpId", EmpId);
        cmd.Parameters.AddWithValue("@FirmId", CompanyId);
        return data.executeCommand(cmd);
    }
    public int VendorSave(string Action, string VendorID, string VenderType, string VendorName, string Address,
       string City, string State, string Mobileno, string V_GSTType, string V_GSTNo, string Email, string Email2, string V_BankName,
    string V_BranchName, string V_BankAcNo, string V_IFSCCODE, string V_RefrenceDetails,
    string V_BankName2, string V_BranchName2, string V_BankAcNo2, string V_IFSCCODE2, string Landlineno, string ContactPerson, string Country,
    string Data_Add_by,
    string DrCr)
    {

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_InsertVendor";
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@VendorID", VendorID);
        cmd.Parameters.AddWithValue("@VenderType", VenderType);
        cmd.Parameters.AddWithValue("@VendorName", VendorName);
        cmd.Parameters.AddWithValue("@Address", Address);
        cmd.Parameters.AddWithValue("@V_GSTType", V_GSTType);
        cmd.Parameters.AddWithValue("@V_GSTNo", V_GSTNo);
        cmd.Parameters.AddWithValue("@City", City);
        cmd.Parameters.AddWithValue("@State", State);
        cmd.Parameters.AddWithValue("@Mobileno", Mobileno);
        cmd.Parameters.AddWithValue("@Email", Email);
        cmd.Parameters.AddWithValue("@Email2", Email2);
        cmd.Parameters.AddWithValue("@V_BankName", V_BankName);
        cmd.Parameters.AddWithValue("@V_BranchName", V_BranchName);
        cmd.Parameters.AddWithValue("@V_BankAcNo", V_BankAcNo);
        cmd.Parameters.AddWithValue("@V_IFSCCODE", V_IFSCCODE);
        cmd.Parameters.AddWithValue("@V_RefrenceDetails", V_RefrenceDetails);
        cmd.Parameters.AddWithValue("@V_BankName2", V_BankName2);
        cmd.Parameters.AddWithValue("@V_BranchName2", V_BranchName2);
        cmd.Parameters.AddWithValue("@V_BankAcNo2", V_BankAcNo2);
        cmd.Parameters.AddWithValue("@V_IFSCCODE2", V_IFSCCODE2);
        cmd.Parameters.AddWithValue("@ContactPerson", ContactPerson);
        cmd.Parameters.AddWithValue("@Landlineno", Landlineno);
        cmd.Parameters.AddWithValue("@Country", Country);
        cmd.Parameters.AddWithValue("@Data_Add_by", Data_Add_by);
        cmd.Parameters.AddWithValue("@DrCr", DrCr);

        return data.executeCommand(cmd);

    }

    public int InsertCompany(string Action, string id, string parent, string FirmName, string FK_AdminID, string ContactPerson, string OffAddress, string Mobile, string AcNo, string BankName,
string BankAddress, string IFSCCode, string City, string State, string Country, string tinNo, string PanNo, string VMob,
           string landline, string AcNo2, string BankName2, string BankAddress2, string IFSCCode2, string TDS,
 string Type, string GstType, string pin, string Companydivision = null)
    {
        int aa = 0;
        cmd = new SqlCommand("Usp_CompanyIns");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@ID", id);
        cmd.Parameters.AddWithValue("@ParentID", parent);

        cmd.Parameters.AddWithValue("@Company_division", Companydivision);
        cmd.Parameters.AddWithValue("@FirmName", FirmName);
        cmd.Parameters.AddWithValue("@adminid", FK_AdminID);
        cmd.Parameters.AddWithValue("@ContactPerson", ContactPerson);
        cmd.Parameters.AddWithValue("@OffAddress", OffAddress);
        cmd.Parameters.AddWithValue("@Mobile", Mobile);
        cmd.Parameters.AddWithValue("@AcNo", AcNo);
        cmd.Parameters.AddWithValue("@BankName", BankName);
        cmd.Parameters.AddWithValue("@BankAddress", BankAddress);
        cmd.Parameters.AddWithValue("@ifsc", IFSCCode);
        cmd.Parameters.AddWithValue("@City", City);
        cmd.Parameters.AddWithValue("@State", State);
        cmd.Parameters.AddWithValue("@Country", Country);
        cmd.Parameters.AddWithValue("@tinNo", tinNo);
        cmd.Parameters.AddWithValue("@PanNo", PanNo);
        cmd.Parameters.AddWithValue("@VMob", VMob);
        cmd.Parameters.AddWithValue("@phone", landline);
        cmd.Parameters.AddWithValue("@AcNo2", AcNo2);
        cmd.Parameters.AddWithValue("@BankName2", BankName2);
        cmd.Parameters.AddWithValue("@BankAddress2", BankAddress2);
        cmd.Parameters.AddWithValue("@ifsc2", IFSCCode2);
        cmd.Parameters.AddWithValue("@TDS", TDS != "" ? TDS : "0");
        ///////  cmd.Parameters.AddWithValue("@CreditLimit", CreditLimit);
        cmd.Parameters.AddWithValue("@Type", Type);
        cmd.Parameters.AddWithValue("@pin", pin);
        cmd.Parameters.AddWithValue("@GstType", GstType);

        ds = data.getDataSet(cmd);
        aa = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

        return aa;
    }

    public int insertCompPersonDetail(string Action, string id, string type, string compId, string person_name, string empid, string mobno, string mailid, string HOaddr, string dep, string desig, string division, string persontype, string no)
    {
        cmd = new SqlCommand("sp_InserCompContactPerson");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@action", Action);
        cmd.Parameters.AddWithValue("@type", type);
        cmd.Parameters.AddWithValue("@compID", compId);
        cmd.Parameters.AddWithValue("@personname", person_name);
        cmd.Parameters.AddWithValue("@empID", empid);
        cmd.Parameters.AddWithValue("@cnctno", mobno);
        cmd.Parameters.AddWithValue("@mailID", mailid);
        cmd.Parameters.AddWithValue("@PersonType", persontype);
        cmd.Parameters.AddWithValue("@dep", dep);
        cmd.Parameters.AddWithValue("@desig", desig);
        cmd.Parameters.AddWithValue("@div", division);
        cmd.Parameters.AddWithValue("@HOAddr", HOaddr);
        cmd.Parameters.AddWithValue("@personNo", no);

        int aa = 0;
        ds = data.getDataSet(cmd);
        aa = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        return aa;
    }

    public int insertStockistCnctPerson(string Action, string id, string type, string stockistId, string name, string cnctno, string no, string desig)
    {
        cmd = new SqlCommand("sp_InsertStockistContactPerson");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@action", Action);
        cmd.Parameters.AddWithValue("@type", type);
        cmd.Parameters.AddWithValue("@compID", stockistId);
        cmd.Parameters.AddWithValue("@personname", name);
        cmd.Parameters.AddWithValue("@cnctno", cnctno);
        cmd.Parameters.AddWithValue("@CnctDesig", desig);
        cmd.Parameters.AddWithValue("@personNo", no);

        int aa = 0;
        ds = data.getDataSet(cmd);
        aa = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        return aa;
    }
    public int InsertStockistCompany(string stockistID, string CompID, string stockistName, string compName)
    {
        cmd = new SqlCommand("sp_InsertStockistCompany");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@StockistId", stockistID);
        cmd.Parameters.AddWithValue("@compId", CompID);
        cmd.Parameters.AddWithValue("@DistName", stockistName);
        cmd.Parameters.AddWithValue("@compName", compName);
        return data.executeCommand(cmd);
    }
    public DataSet GetTransport()
    {

        cmd = new SqlCommand("Usp_Gettransportlist");
        cmd.CommandType = CommandType.StoredProcedure;
        // cmd.Parameters.AddWithValue("@ID", ID);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet EditTransport(string id)
    {

        query = "select * from Tbl_Transport where IsDeleted=0 and id='" + id + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getCompanyReport()
    {
        query = "select CONVERT(CHAR(11),Firmname,103) as FirmName,* from tbl_Company where IsDeleted=0";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet EditCompany(string Id)
    {
        query = "select * from tbl_Company where IsDeleted=0 and ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet Editstate(string Id)
    {
        query = "select * from Tbl_state where IsDeleted=0 and ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getstate(string s)
    {
        query = "select * from Tbl_state where IsDeleted=0 and ID like '" + s + "' Order by State";
        ds = data.getDataSet(query);
        return ds;
    }

    public int Intransport(string ID, string Action, string TranName, string trantype, string L_Address, string M_Addr, string gstno, string gsttyp, string pan, string phone)
    {
        int aa = 0;
        cmd = new SqlCommand("Sp_Transport");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@Id", ID);
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@TransportName", TranName);
        cmd.Parameters.AddWithValue("@TranType", trantype);
        cmd.Parameters.AddWithValue("@LocalAddr", L_Address);
        cmd.Parameters.AddWithValue("@MainAddr", M_Addr);
        cmd.Parameters.AddWithValue("@Gst", gstno);
        cmd.Parameters.AddWithValue("@gstType", gsttyp);
        cmd.Parameters.AddWithValue("@pan", pan);
        cmd.Parameters.AddWithValue("@phone", phone);
        ds = data.getDataSet(cmd);
        aa = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

        return aa;
    }

    //Transport_ID,CityID,PersonName,OfficeAddress, ContactNo,Email_ID,Pincode
    public int insertTranContact(string ID, string TranID, string city, string name, string O_Address, string cnct, string email, string pin, string desig)
    {
        int aa = 0;
        //@transID,@city,@name,@addr,@contactno,@Email,@pincode
        cmd = new SqlCommand("sp_InsertTransportContact");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@Id", ID);

        cmd.Parameters.AddWithValue("@transID", TranID);
        cmd.Parameters.AddWithValue("@city", city);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@addr", O_Address);
        cmd.Parameters.AddWithValue("@contactno", cnct);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@pincode", pin);
        cmd.Parameters.AddWithValue("@Desig", desig);
        ds = data.getDataSet(cmd);
        aa = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

        return aa;
    }

    public DataSet get_TransContacts(string id)
    {

        cmd = new SqlCommand("sp_GetTransportContacts");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@id", id);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet GetSession(string Session)
    {

        string query = "select * from Tbl_Session";
        if (SessionID != "")
            query += " where SessionID=" + SessionID;
        query += " order by Session";
        DataSet ds = data.getDataSet(query);
        return ds;
    }
    public DataSet EditSession(string SessionID)
    {
        string query = "select * from Tbl_Session";
        if (SessionID != "")
            query += " where SessionID=" + SessionID;
        query += " order by Session";
        DataSet ds = data.getDataSet(query);
        return ds;
    }
    public int SessionSave(string Action, string SessionID, string Session, string Remarks, string StartDate, string EndDate)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.CommandText = "sp_InsertSession";

        cmd.Parameters.AddWithValue("@Session", Session);
        cmd.Parameters.AddWithValue("@Remarks", Remarks);
        if (StartDate != "")
            cmd.Parameters.AddWithValue("@StartDate", ConvertDDMMYYYY(StartDate));
        else
            cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
        if (EndDate != "")
            cmd.Parameters.AddWithValue("@EndDate", ConvertDDMMYYYY(EndDate));
        else
            cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);
        cmd.Parameters.AddWithValue("@id", SessionID);
        cmd.Parameters.AddWithValue("@Action", Action);
        return data.executeCommand(cmd);
    }

    public int Incompanydivision(string Action, string ID, string Companydivision)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "[Sp_Companydivision]";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@Company_division", Companydivision);
        res = data.executeCommand(cmd);
        return res;
    }

    public DataSet divisionGetData()
    {
        cmd = new SqlCommand("select * from Tbl_Companydivision where IsDeleted=0 ");
        cmd.CommandType = CommandType.Text;
        // cmd.Parameters.AddWithValue("@ID", ID);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet getDivision(DropDownList drp)
    {
        cmd = new SqlCommand("sp_GetDivisionList");
        cmd.CommandType = CommandType.StoredProcedure;
        ds = data.getDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            drp.DataSource = ds;
            drp.DataTextField = "Division";
            drp.DataValueField = "Id";
            drp.DataBind();
            drp.Items.Insert(0, new ListItem("Select ", "0"));
        }
        return ds;
    }
    public DataSet DivisionEditData(string Id)
    {
        cmd = new SqlCommand("select * from Tbl_Companydivision where IsDeleted=0 ");
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@Id", Id);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet getRequestconfirmation()
    {
        cmd = new SqlCommand("Sp_GetRequestConfirmation");
        cmd.CommandType = CommandType.StoredProcedure;
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet getRequestList(string reqBy, string frmDt, string ToDt)
    {
        cmd = new SqlCommand("Sp_GetRequestList");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        // @RequestBy nvarchar(max),@RFDate datetime,@RToDate datetime 
        cmd.Parameters.AddWithValue("@RequestBy", reqBy);
        if (frmDt != "")
            cmd.Parameters.AddWithValue("@RFDate", ConvertDDMMYYYY(frmDt));
        else
            cmd.Parameters.AddWithValue("@RFDate", DBNull.Value);
        if (ToDt != "")
            cmd.Parameters.AddWithValue("@RToDate", ConvertDDMMYYYY(ToDt));
        else
            cmd.Parameters.AddWithValue("@RToDate", DBNull.Value);

        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet getRequestconfirmationR(string RequestBy, string IssueBy, string RFDate, string RToDate, string IFDate, string IToDate)
    {
        string dd2 = DateTime.Now.ToString("yyyy-M-d");
        cmd = new SqlCommand("Sp_GetRequestConfirmationR");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@RequestBy", RequestBy != "0" ? RequestBy : "%");
        cmd.Parameters.AddWithValue("@IssueBy", IssueBy != "0" ? IssueBy : "%");
        cmd.Parameters.AddWithValue("@RFDate", RFDate != "" ? ConvertDDMMYYYY(RFDate) : "1900-01-01");
        cmd.Parameters.AddWithValue("@RToDate", RToDate != "" ? ConvertDDMMYYYY(RToDate) : dd2);
        cmd.Parameters.AddWithValue("@IFDate", IFDate != "" ? ConvertDDMMYYYY(IFDate) : "1900-01-01");
        cmd.Parameters.AddWithValue("@IToDate", IToDate != "" ? ConvertDDMMYYYY(IToDate) : dd2);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet Editdesignation(string ID)
    {
        query = "select * from Tbl_Designation where IsDeleted=0 and ID='" + ID + "'";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet Indesignation(string Action, string ID, string designation)
    {
        cmd = new SqlCommand("Sp_Designation");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("Designation", designation);
        ds = data.getDataSet(cmd);
        return ds;
    }


    public void DesignationDrp(DropDownList drp)
    {

        query = "select * from Tbl_Designation where IsDeleted=0 Order by Designation";
        ds = data.getDataSet(query);
        drp.DataSource = ds;
        drp.DataTextField = "Designation";
        drp.DataValueField = "ID";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("Select", "0"));

    }

    public void DepartmentDrp(DropDownList drp)
    {

        query = "Select * from tbl_Department D WHERE D.IsDeleted=0 Order by Name";
        ds = data.getDataSet(query);
        drp.DataSource = ds;
        drp.DataTextField = "Name";
        drp.DataValueField = "ID";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("Select", "0"));
    }

    public void CreditPolicyDrp(DropDownList drp)
    {
        query = "SELECT * FROM tbl_CreditPolicy";
        ds = data.getDataSet(query);
        drp.DataSource = ds;
        drp.DataTextField = "PolicyFor";
        drp.DataValueField = "ID";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("Select", "0"));
    }
    public void FillCity(DropDownList drp)
    {

        cmd = new SqlCommand("Sp_Getcity");
        cmd.CommandType = CommandType.StoredProcedure;
        // cmd.Parameters.AddWithValue("@City", City);
        cmd.Parameters.AddWithValue("@state", "%");
        cmd.Parameters.AddWithValue("@city", "%");
        ds = data.getDataSet(cmd);
        drp.DataSource = ds;
        drp.DataTextField = "city";
        drp.DataValueField = "ID";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("SELECT CITY", "0"));
    }
    public void FillComapny(DropDownList drp)
    {

        cmd = new SqlCommand("Select * from tbl_Company where IsDeleted=0 and Type='Company' order by FirmName");
        cmd.CommandType = CommandType.Text;
        // cmd.Parameters.AddWithValue("@City", City);
        ds = data.getDataSet(cmd);
        drp.DataSource = ds;
        drp.DataTextField = "FirmName";
        drp.DataValueField = "ID";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("Select", "0"));
    }

    public void CompanyTbl(DropDownList drp, string Type)
    {

        cmd = new SqlCommand("Select * from tbl_Company where IsDeleted=0 and Type='" + Type + "' order by FirmName");
        cmd.CommandType = CommandType.Text;
        // cmd.Parameters.AddWithValue("@City", City);
        ds = data.getDataSet(cmd);
        drp.DataSource = ds;
        drp.DataTextField = "FirmName";
        drp.DataValueField = "ID";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("SELECT ", "0"));
    }
    public DataSet CompanyList(string Comptype)
    {
        cmd = new SqlCommand("Select FirmName,ID from tbl_Company where IsDeleted=0 and Type='" + Comptype + "' order by FirmName");
        cmd.CommandType = CommandType.Text;
        ds = data.getDataSet(cmd);

        return ds;
    }
    public void FillTransportname(DropDownList drp)
    {

        cmd = new SqlCommand("Select * from Tbl_Transport where IsDeleted=0 ");
        cmd.CommandType = CommandType.Text;
        // cmd.Parameters.AddWithValue("@City", City);
        ds = data.getDataSet(cmd);
        drp.DataSource = ds;
        drp.DataTextField = "TransportName";
        drp.DataValueField = "ID";
        drp.DataBind();
        drp.Items.Insert(0, new ListItem("Select", "0"));
    }
    public DataSet GetTransporter(string c, string t, string trantype, string gst_type)
    {
        cmd = new SqlCommand("sp_GetTransport");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();

        cmd.Parameters.AddWithValue("@city", c);
        cmd.Parameters.AddWithValue("@transport", t);
        cmd.Parameters.AddWithValue("@TranType", trantype);
        cmd.Parameters.AddWithValue("@gstType", gst_type);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public int IntransportRate(string ID, string Action, string Tr_ID, string compid, string Cityid, string TrType,
         string grcharges, string D_charges, string LTripRate, string LCartoonRate, string LWeightRate, string OutTripRate, string OutCartoonRate, string OutWeightRate, string R)
    {
        cmd = new SqlCommand("Sp_TransportRate");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@TransportID", Tr_ID);
        cmd.Parameters.AddWithValue("@CompID", compid);
        cmd.Parameters.AddWithValue("@CityID", Cityid);
        cmd.Parameters.AddWithValue("@TransportType", TrType);
        cmd.Parameters.AddWithValue("@GRCharges", grcharges);
        cmd.Parameters.AddWithValue("@DoorDeliveryCharges", D_charges);
        cmd.Parameters.AddWithValue("@LocalRatePerTrip", LTripRate);
        cmd.Parameters.AddWithValue("@LocalRatePerCartoon", LCartoonRate);
        cmd.Parameters.AddWithValue("@LocalRatePerWeight", LWeightRate);
        cmd.Parameters.AddWithValue("@OutTownRatePerTrip", OutTripRate);
        cmd.Parameters.AddWithValue("@OutTownRatePerCartoon", OutCartoonRate);
        cmd.Parameters.AddWithValue("@OutTownRatePerWeight", OutWeightRate);
        cmd.Parameters.AddWithValue("@Remarks", R);

        res = data.executeCommand(cmd);
        return res;
    }
    protected void insertTranRateCompany(string trateID, string CompID, string stockistId)
    {

        cmd = new SqlCommand("sp_InsertTranRateCompany");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TranRateID", trateID);
        cmd.Parameters.AddWithValue("@ComID", CompID);
        cmd.Parameters.AddWithValue("@DistID", stockistId);
        res = data.executeCommand(cmd);

    }

    public DataSet get_TransportRateList(string city_id, string comp_id, string trans_type, string tran_id)
    {
        ds.Clear();
        cmd = new SqlCommand("TRate");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@cityid", city_id);
        cmd.Parameters.AddWithValue("@compid", comp_id);
        cmd.Parameters.AddWithValue("@type", trans_type);
        cmd.Parameters.AddWithValue("@transid", tran_id);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public int CartingAgent(string ID, string Action, string Name, string Phone, string comp, string Cartingagentrate, string cartingagentrateOut, string rpt, string rptl)
    {
        cmd = new SqlCommand("[Sp_CartingAgent]");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@Id", ID);
        cmd.Parameters.AddWithValue("@Name", Name);
        cmd.Parameters.AddWithValue("@Phone", Phone);
        cmd.Parameters.AddWithValue("@comp", comp);
        cmd.Parameters.AddWithValue("@Cartingagentrate", Cartingagentrate);
        cmd.Parameters.AddWithValue("@cartingagentrateOut", cartingagentrateOut);
        cmd.Parameters.AddWithValue("@rpt", rpt);
        cmd.Parameters.AddWithValue("@rptl", rptl);
        res = data.executeCommand(cmd);
        return res;
    }

    public DataSet getCreditPolicy(string comp)
    {
        cmd = new SqlCommand("sp_GetCreditPolicy");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@compid", comp);
        ds = data.getDataSet(cmd);
        return ds;
    }


    public DataSet FillTransportRates(string comp, string cityid, string transID, string transtype)
    {
        cmd = new SqlCommand("sp_FillTransporterRate");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Comp", comp);
        cmd.Parameters.AddWithValue("@city", cityid);
        cmd.Parameters.AddWithValue("@TrID", transID);
        cmd.Parameters.AddWithValue("@Tr_Type", transtype);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet FillStockistTransportRates(string distID, string comp, string cityid, string transID, string transtype)
    {
        cmd = new SqlCommand("sp_FillstockistTransportRate");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@stockist", distID);
        cmd.Parameters.AddWithValue("@Comp", comp);
        cmd.Parameters.AddWithValue("@city", cityid);
        cmd.Parameters.AddWithValue("@TrID", transID);
        cmd.Parameters.AddWithValue("@Tr_Type", transtype);
        ds = data.getDataSet(cmd);
        return ds;
    }
    public int InsertStockistTransportRate(string ID, string DistributorID, string Tr_ID, string compid, string Cityid, string TrType, string grcharges, string D_charges, string LTripRate, string LCartoonRate, string LWeightRate, string OutTripRate, string OutCartoonRate, string OutWeightRate)
    {
        /*  @ID bigint, @Action nvarchar(50), @stockistId nvarchar(50) , @TransportID nvarchar(max),@CityID nvarchar(max) ,@CompID nvarchar(max),
  @TransportType nvarchar(max),@GRCharges NVARCHAR(MAX) , @DoorDeliveryCharges nvarchar(100), 
  @LocalRatePerTrip nvarchar(100), @LocalRatePerCartoon nvarchar(100), @LocalRatePerWeight nvarchar(100), 
  @OutTownRatePerTrip nvarchar(100) ,@OutTownRatePerCartoon nvarchar(100) ,@OutTownRatePerWeight nvarchar(100) */
        cmd = new SqlCommand("sp_StockistTransportRate");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@stockistId", DistributorID);
        cmd.Parameters.AddWithValue("@TransportID", Tr_ID);
        cmd.Parameters.AddWithValue("@CityID", Cityid);
        cmd.Parameters.AddWithValue("@CompID", compid);
        cmd.Parameters.AddWithValue("@TransportType", TrType);
        cmd.Parameters.AddWithValue("@GRCharges", grcharges);
        cmd.Parameters.AddWithValue("@DoorDeliveryCharges", D_charges);
        cmd.Parameters.AddWithValue("@LocalRatePerTrip", LTripRate);
        cmd.Parameters.AddWithValue("@LocalRatePerCartoon", LCartoonRate);
        cmd.Parameters.AddWithValue("@LocalRatePerWeight", LWeightRate);
        cmd.Parameters.AddWithValue("@OutTownRatePerTrip", OutTripRate);
        cmd.Parameters.AddWithValue("@OutTownRatePerCartoon", OutCartoonRate);
        cmd.Parameters.AddWithValue("@OutTownRatePerWeight", OutWeightRate);


        res = data.executeCommand(cmd);
        return res;
    }
    public DataSet Editdepartment(string Id)
    {
        query = "select * from Tbl_Department where IsDeleted=0 and ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet Edit_city(string Id)
    {
        query = "select * from Tbl_City where IsDeleted=0 and ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet Edityoutube(string Id)
    {
        query = "select * from Tbl_youtube where  ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet Editnews(string Id)
    {
        query = "select * from News where  ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet Editpage(string Id)
    {
        query = "select * from page where  ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet Editoverview(string Id)
    {
        query = "select * from Overview where  ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet Editlogo(string Id)
    {
        query = "select * from tbl_logo where  ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet Editgallery(string Id)
    {
        query = "select * from Overview where  ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet EditPackage(string Id)
    {
        query = "select * from Tbl_Package where IsDeleted=0 and ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet EditAsset(string Id)
    {
        query = "select * from Tbl_Asset where IsDeleted=0 and ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet EditConstructionType(string Id)
    {
        query = "select * from Tbl_TypeConst where IsDeleted=0 and ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet Editbrand(string Id)
    {
        query = "select * from tbl_Brand where IsDeleted=0 and ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet EditUnit(string Id)
    {
        query = "select * from tbl_Unit where IsDeleted=0 and ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet EditRoomType(string Id)
    {
        query = "select * from tbl_RoomType where IsDeleted=0 and ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet EditMaterialColor(string Id)
    {
        query = "select * from tbl_MaterialColor where IsDeleted=0 and ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet EditMaterialFinish(string Id)
    {
        query = "select * from tbl_MaterialType where IsDeleted=0 and ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet Editcategory(string Id)
    {
        query = "select * from tbl_Category where IsDeleted=0 and ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getdepartment()
    {
        query = "select * from tbl_Department where IsDeleted=0";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getpage()
    {
        query = "select * from page P left outer join tbl_Subcategory S on S.id = P.SubCategoryid ";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getoverview()
    {
        query = "select * from OverView";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getsev1(string Id)
    {
        query = "select Top 4 * from OverView where Category='" + Id + "'  ";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getNews2()
    {
        query = "select Top 3 * from News  order by id desc";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getNews4()
    {
        query = "select Top 5 * from News  order by id desc";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getsev()
    {
        query = "select * from Overview  order by id desc";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getFAQ()
    {
        query = "select * from Tbl_fq O left outer join tbl_Subcategory S on S.id = O.SubCategoryid ";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getsubCategory()
    {
        query = "select * from tbl_Subcategory where DELID=0";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getinfromation()
    {
        query = "select * from tbl_City ";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getcity()
    {
        query = "select * from tbl_city ";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getcontactus()
    {
        query = "select * from tbl_contactus where IsDeleted=0";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getyoutube()
    {
        query = "select * from tbl_youtube ";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getlogo()
    {
        query = "select * from tbl_logo order by id desc";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getlogo1()
    {
        query = "select * from tbl_logo where category ='gallery' order by id desc";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getlogo2(string Id)
    {
        query = "select * from tbl_logo where  category ='" + Id + "' order by id desc";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getgiwa()
    {
        query = "select * from tbl_information where agreement ='Accepted' order by id desc";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getRagistration()
    {
        query = "select * from tbl_information where agreement ='Registration_Accepted' order by id desc";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getNews()
    {
        query = "select * from News  order by id desc";
        ds = data.getDataSet(query);
        return ds;
    }
	
    public DataSet getoverview1()
    {
        query = "select * from overview  order by id desc";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getgallery1()
    {
        query = "select * from tbl_gallery where category = 'Our Events'  order by id desc";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getgallery2()
    {
        query = "select * from tbl_gallery where category = 'Guest of Honour'  order by id desc";
        ds = data.getDataSet(query);
        return ds;
    }
  
    public DataSet getNews3()
    {
        query = "select * from News where category ='News_pdf' order by id desc";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getNews1()
    {
        query = "select top 4 * from News where category NOT LIKE 'News_pdf' order by id desc";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getads()
    {
        query = "select top 1 * from tbl_ads ORDER BY id desc ";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getenquri()
    {
        
     query = "select E.*,E1.Name as Emp,S1.Name as Emp1,D.Name as Dept, E2.PuchaseCost as puCost,E2.SaleCost,E2.Recevied,E2.Pending_A, E2.PuchaseCost from tbl_Enquiry1 E " +
            " left join tbl_Package D on D.ID = E.PackId" +
            " left join tbl_Employee E1 on E1.ID = E.Submittedid" +
            " left join tbl_Employee S1 on S1.ID = E.Workid" +
            " left join tbl_EnquiryAmount E2 on E2.Eid = E.Eid" +
            " where E.IsDeleted = 0 ";


        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getPackage()
    {
        query = "select * from tbl_Package where IsDeleted=0";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getAsset()
    {
        query = "select tbl_Asset.*,E.ID as EmpID,E.Name as Employee from tbl_Asset " +
"left join(SELECT ID, Name, value  as aid "+
"FROM tbl_Employee "+
   " CROSS APPLY[dbo].[Split](AssetID) ) E on tbl_Asset.ID = E.aid "+
"where tbl_Asset.IsDeleted = 0 order by tbl_Asset.Name ";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getConstructionType()
    {
        query = "select * from tbl_TypeConst where IsDeleted=0";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getbrand()
    {
        query = "select * from tbl_Brand where IsDeleted=0";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getRoomType()
    {
        query = "select * from tbl_RoomType where IsDeleted=0";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getMaterialFinish()
    {
        query = "select * from tbl_MaterialFinish where IsDeleted=0";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getUnit()
    {
        query = "select * from tbl_Unit where IsDeleted=0";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getcategory()
    {
        query = "select * from tbl_Category where IsDeleted=0";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getMaterialType()
    {
        query = "select * from Tbl_MaterialType where IsDeleted = 0 ";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet getMaterialColor()
    {
        query = "select * from tbl_MaterialColor  where IsDeleted=0";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet EditFile(string Id)
    {
        query = "select * from tbl_File where IsDeleted=0 and ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getnews4(string Id)
    {
        query = "select * from News where  ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getpage1(string Id)
    {
        query = "select * from page where SubcategoryId='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getoverview(string Id)
    {
        query = "select * from Overview where SubcategoryId='" + Id + "' order by id asc";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet getSubC(string Id)
    {
        query = "select top 10 * from tbl_SubCategory where categoryId='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }


    public DataSet InsFile(string Action, string ID, string File, string CompanyId)
    {
        cmd = new SqlCommand("Sp_File");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@File", File);
        cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet getFile()
    {
        query = "select * from tbl_File where IsDeleted=0";
        ds = data.getDataSet(query);
        return ds;
    }
    public DataSet EditIdCard(string Id)
    {
        query = "select * from tbl_IdCard where IsDeleted=0 and ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }


    public DataSet InsIdCard(string Action, string ID, string IdCard)
    {
        cmd = new SqlCommand("Sp_IdCard");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@IdCard", IdCard);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet getIdCard()
    {
        query = "select * from tbl_IdCard where IsDeleted=0";
        ds = data.getDataSet(query);
        return ds;
    }

    public DataSet EditGst(string Id)
    {
        query = "select * from tbl_Gst where IsDeleted=0 and ID='" + Id + "'";
        ds = data.getDataSet(query);
        return ds;
    }


    public DataSet InsGst(string Action, string ID, string Gst, string GstType)
    {
        cmd = new SqlCommand("Sp_Gst");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@Gst", Gst);
        cmd.Parameters.AddWithValue("@GstType", GstType);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet getGst()
    {
        query = "select * from tbl_Gst where IsDeleted=0 ";
        ds = data.getDataSet(query);
        return ds;
    }

    //Action, id, "Vendor", "0", FirmName, FK_AdminID, Vendortype, OffAddress, txtPincode.Text, City, State, Country, Mobile, txtlandline.Text, txtEmailId.Text,  PanNo,  GstType, tinNo, AcNo, BankName, BankAddress, IFSCCode,

    public int InsertVendor(string Action, string id, string Type, string parent, string FirmName, string FK_AdminID, string vendortype, string OffAddress, string pin, string City, string State, string Country, string Mobile, string landline, string Email, string PanNo, string GstType, string tinNo, string AcNo, string BankName,
string BankAddress, string IFSCCode, string TDS)
    {
        int aa = 0;
        cmd = new SqlCommand("Usp_VendorIns");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@ID", id);
        cmd.Parameters.AddWithValue("@Type", Type);
        cmd.Parameters.AddWithValue("@ParentID", parent);
        cmd.Parameters.AddWithValue("@FirmName", FirmName);
        cmd.Parameters.AddWithValue("@adminid", FK_AdminID);
        cmd.Parameters.AddWithValue("@Vendtype", vendortype);
        cmd.Parameters.AddWithValue("@OffAddress", OffAddress);
        cmd.Parameters.AddWithValue("@pin", pin);
        cmd.Parameters.AddWithValue("@City", City);
        cmd.Parameters.AddWithValue("@State", State);
        cmd.Parameters.AddWithValue("@Country", Country);
        cmd.Parameters.AddWithValue("@Mobile", Mobile);
        cmd.Parameters.AddWithValue("@landline", landline);
        cmd.Parameters.AddWithValue("@mail", Email);
        cmd.Parameters.AddWithValue("@PanNo", PanNo);
        cmd.Parameters.AddWithValue("@GstType", GstType);
        cmd.Parameters.AddWithValue("@tinNo", tinNo);
        cmd.Parameters.AddWithValue("@AcNo", AcNo);
        cmd.Parameters.AddWithValue("@BankName", BankName);
        cmd.Parameters.AddWithValue("@BankAddress", BankAddress);
        cmd.Parameters.AddWithValue("@ifsc", IFSCCode);
        cmd.Parameters.AddWithValue("@TDS", TDS != "" ? TDS : "0");
        ds = data.getDataSet(cmd);
        aa = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

        return aa;
    }
    public int insertVendorCnctPerson(string Action, string id, string type, string stockistId, string name, string cnctno, string l_no, string no, string desig)
    {
        cmd = new SqlCommand("sp_InsertVendorContactPerson");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@action", Action);
        cmd.Parameters.AddWithValue("@type", type);
        cmd.Parameters.AddWithValue("@compID", stockistId);
        cmd.Parameters.AddWithValue("@personname", name);
        cmd.Parameters.AddWithValue("@cnctno", cnctno);
        cmd.Parameters.AddWithValue("@l", l_no);
        cmd.Parameters.AddWithValue("@CnctDesig", desig);
        cmd.Parameters.AddWithValue("@personNo", no);

        int aa = 0;
        ds = data.getDataSet(cmd);
        aa = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        return aa;
    }
    // Action, id, "0", FK_AdminID, "Distributor", FirmName, OffAddress, pin, City, State, Country, Mobile, PanNo, GstType, //GST, dueDays, creditPeriod, CPValid, drpTransport.SelectedValue, drpCartingAgent.SelectedValue, AcNo, BankName, //BankAddress, IFSCCode
    public int InsertStockist(string Action, string id, string parent, string FK_AdminID, string type, string FirmName, string OffAddress, string pin, string City, string State, string Country, string Mobile, string PanNo, string GstType, string GSTNo, string AcNo, string BankName, string BankAddress, string IFSCCode)
    {
        int aa = 0;
        cmd = new SqlCommand("sp_InsertStockist");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Action", Action);
        cmd.Parameters.AddWithValue("@ID", id);
        cmd.Parameters.AddWithValue("@ParentID", parent);
        cmd.Parameters.AddWithValue("@adminid", FK_AdminID);
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@FirmName", FirmName);
        cmd.Parameters.AddWithValue("@OffAddress", OffAddress);
        cmd.Parameters.AddWithValue("@pin", pin);
        cmd.Parameters.AddWithValue("@City", City);
        cmd.Parameters.AddWithValue("@State", State);
        cmd.Parameters.AddWithValue("@Country", Country);
        cmd.Parameters.AddWithValue("@Mobile", Mobile);
        cmd.Parameters.AddWithValue("@PanNo", PanNo);
        cmd.Parameters.AddWithValue("@GstType", GstType);
        cmd.Parameters.AddWithValue("@tinNo", GSTNo);

        cmd.Parameters.AddWithValue("@AcNo", AcNo);
        cmd.Parameters.AddWithValue("@BankName", BankName);
        cmd.Parameters.AddWithValue("@BankAddress", BankAddress);
        cmd.Parameters.AddWithValue("@ifsc", IFSCCode);
        cmd.Parameters.AddWithValue("@TDS", "0");

        ds = data.getDataSet(cmd);
        aa = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

        return aa;
    }
    public void VisitorEntry(string comp, string visitor, string mobileno, string address, string purpose, string person, string VisitDate, string intime, string outtime, string empID, string idd, string PID)
    {
        if (HttpContext.Current.Request.Cookies["Bagai"] != null)
        {
            Admin = HttpContext.Current.Request.Cookies["Bagai"];

            userid = Admin.Values["UserId"].ToString();

        }
        else
        {
            userid = "";
        }

        cmd = new SqlCommand("sp_InsertVisitor");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@CompID", comp);
        cmd.Parameters.AddWithValue("@VisitorName", visitor);
        cmd.Parameters.AddWithValue("@VisitorMobileNo", mobileno);
        cmd.Parameters.AddWithValue("@VisitorAddress", address);
        cmd.Parameters.AddWithValue("@VisitPurpose", purpose);
        cmd.Parameters.AddWithValue("@PersonToMeet", person);
        cmd.Parameters.AddWithValue("@VisitingDate", VisitDate != "" ? ConvertDDMMYYYY(VisitDate) : "");
        cmd.Parameters.AddWithValue("@InTime", intime);
        cmd.Parameters.AddWithValue("@OutTime", outtime);
        cmd.Parameters.AddWithValue("@EmpID", empID);
        cmd.Parameters.AddWithValue("@MeetPersonID", PID);
        cmd.Parameters.AddWithValue("@ID", idd);
        cmd.Parameters.AddWithValue("@entryby", userid);
        data.executeCommand(cmd);
    }

    public DataSet getVisitorList(string comp, string fromDt, string uptoDt, string v)
    {
        cmd = new SqlCommand("sp_GetVisitorList");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@compid", comp);
        cmd.Parameters.AddWithValue("@fromDate", fromDt != "" ? ConvertDDMMYYYY(fromDt) : "");
        cmd.Parameters.AddWithValue("@todate", uptoDt != "" ? ConvertDDMMYYYY(uptoDt) : "");
        cmd.Parameters.AddWithValue("@visitor", v);

        ds = data.getDataSet(cmd);
        return ds;
    }
    public DataSet getVisitorDetail(string id, string DataFor)
    {
        cmd = new SqlCommand("sp_getVisitorDetail");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@dataFor", DataFor);
        ds = data.getDataSet(cmd);
        return ds;
    }


    public DataSet insertWorkPermit(string id, string compid, string permitDt, string workarea, string providername,
        string name, string mobileno, string empid, string workdesc, string instruction, string fromdt, string fromtime,
        string tilldt, string tilltime, string status)
    {

        if (HttpContext.Current.Request.Cookies["Bagai"] != null)
        {
            Admin = HttpContext.Current.Request.Cookies["Bagai"];

            userid = Admin.Values["UserId"].ToString();
        }
        else
        {
            userid = "";
        }
        cmd = new SqlCommand("sp_InsertWorkPermit");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@ID", id);

        cmd.Parameters.AddWithValue("@compID", compid);
        cmd.Parameters.AddWithValue("@PermitDt", ConvertDDMMYYYY(permitDt));
        cmd.Parameters.AddWithValue("@WorkArea", workarea);
        cmd.Parameters.AddWithValue("@SProvider", providername);
        cmd.Parameters.AddWithValue("@SPName", name);
        cmd.Parameters.AddWithValue("@cnctno", mobileno);
        cmd.Parameters.AddWithValue("@AccPerson", empid);
        cmd.Parameters.AddWithValue("@WorkDesc", workdesc);
        cmd.Parameters.AddWithValue("@instructions", instruction);
        cmd.Parameters.AddWithValue("@validFrm", fromdt != "" ? ConvertDDMMYYYY(fromdt) : DBNull.Value.ToString());
        cmd.Parameters.AddWithValue("@validFrmTime", fromtime);
        cmd.Parameters.AddWithValue("@validupto", tilldt != "" ? ConvertDDMMYYYY(tilldt) : DBNull.Value.ToString());
        cmd.Parameters.AddWithValue("@validuptoTime", tilltime);
        cmd.Parameters.AddWithValue("@workStatus", status);
        cmd.Parameters.AddWithValue("@entryby", userid);
        string completiondays = "0";
        if (fromdt != "")
        {
            if (tilldt != "")
            {
                DateTime dt1 = Convert.ToDateTime(ConvertDDMMYYYY(fromdt));
                DateTime dt2 = Convert.ToDateTime(ConvertDDMMYYYY(tilldt));

                if (dt2.Date == dt1.Date)
                    completiondays = dt2.Subtract(dt1).Hours.ToString();
                else
                    completiondays = dt2.Subtract(dt1).Days.ToString();

            }

        }

        cmd.Parameters.AddWithValue("@completiondays", completiondays);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet GetWorkPermitDetail(string Pid, string DataFor)
    {
        cmd = new SqlCommand("sp_GetWorkPermitDetails");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id", Pid);
        cmd.Parameters.AddWithValue("@dataFor", DataFor);
        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet getWorkPermitList(string comp, string fromDt, string uptoDt)
    {
        cmd = new SqlCommand("sp_GetWorkPermitList");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@compid", comp);
        cmd.Parameters.AddWithValue("@fromDate", fromDt != "" ? ConvertDDMMYYYY(fromDt) : "");
        cmd.Parameters.AddWithValue("@todate", uptoDt != "" ? ConvertDDMMYYYY(uptoDt) : "");

        ds = data.getDataSet(cmd);
        return ds;
    }

    public DataSet insertGatePass(string id, string firmid, string compid, string gatepassno, string alloted, string cnctno, string dt,
        string frm, string upto, string Itemin, string Itemout)
    {

        if (HttpContext.Current.Request.Cookies["Bagai"] != null)
        {
            Admin = HttpContext.Current.Request.Cookies["Bagai"];

            userid = Admin.Values["UserId"].ToString();

        }
        else
        {
            userid = "";
        }
        cmd = new SqlCommand("sp_InsertGatePass");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@ID", id);
        cmd.Parameters.AddWithValue("@FirmID", firmid);
        cmd.Parameters.AddWithValue("@CompanyID", compid);
        cmd.Parameters.AddWithValue("@GatePassNo", gatepassno);
        cmd.Parameters.AddWithValue("@AllotedTo", alloted);
        cmd.Parameters.AddWithValue("@ContactNo", cnctno);
        cmd.Parameters.AddWithValue("@AllotedDate", dt != "" ? ConvertDDMMYYYY(dt) : "");
        cmd.Parameters.AddWithValue("@ValidFrom", frm != "" ? ConvertDDMMYYYY(frm) : "");
        cmd.Parameters.AddWithValue("@ValidUpto", upto != "" ? ConvertDDMMYYYY(upto) : "");
        cmd.Parameters.AddWithValue("@ItemIn", Itemin);
        cmd.Parameters.AddWithValue("@ItemOut", Itemout);
        cmd.Parameters.AddWithValue("@entryby", userid);
        ds = data.getDataSet(cmd);
        return ds;
    }

    /* @ID nvarchar(10), @GatePassID nvarchar(10), @ItemDescription nvarchar(max), @Qty nvarchar(50), @Remarks nvarchar(max)*/

    public void insertGatePassItem(string id, string passID, string desc, string qty, string remarks)
    {
        cmd = new SqlCommand("sp_InsertItemListOfGatePass");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@ID", id);
        cmd.Parameters.AddWithValue("@GatePassID", passID);
        cmd.Parameters.AddWithValue("@ItemDescription", desc);
        cmd.Parameters.AddWithValue("@Qty", qty);
        cmd.Parameters.AddWithValue("@Remarks", remarks);
        ds = data.getDataSet(cmd);

    }

    public DataSet getGatePassList(string firm, string comp, string fromDt, string uptoDt)
    {
        cmd = new SqlCommand("sp_getGatePassList");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@firmid", firm);
        cmd.Parameters.AddWithValue("@compid", comp);
        cmd.Parameters.AddWithValue("@frmdt", fromDt != "" ? ConvertDDMMYYYY(fromDt) : "");
        cmd.Parameters.AddWithValue("@uptodt", uptoDt != "" ? ConvertDDMMYYYY(uptoDt) : "");

        ds = data.getDataSet(cmd);
        return ds;
    }
    //sp_GetGatePassDetail

    public DataSet GetGatePassDetail(string Pid, string DataFor)
    {
        cmd = new SqlCommand("sp_GetGatePassDetail");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@id", Pid);
        cmd.Parameters.AddWithValue("@dataFor", DataFor);
        ds = data.getDataSet(cmd);
        return ds;
    }
}
