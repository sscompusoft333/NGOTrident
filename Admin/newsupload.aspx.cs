using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_newsupload : System.Web.UI.Page
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

            if (Request.QueryString["Id"] != null)
            {

                Filldepartment(Request.QueryString["id"].ToString());
                Btnsave.Text = "Update";
            }
			   fileupload1();

        }
    }
private void Filldepartment(string Id)
{
	
	  // Get the content you want to fill in the CKEditor textarea
        string contentToFill = "This is the content to fill in the CKEditor textarea.";

        // Call a method to set the content in the CKEditor
        SetCKEditorContent(contentToFill);
	
    ds = emp.Editnews(Id);
    Drpcate.Text = ds.Tables[0].Rows[0]["category"].ToString();
    Txttitle.Text = ds.Tables[0].Rows[0]["Title"].ToString();
    TextBox1.Text = ds.Tables[0].Rows[0]["descr"].ToString();
    TextBox3.Text = ds.Tables[0].Rows[0]["keywords"].ToString();
    Label1.Text = ds.Tables[0].Rows[0]["Image1"].ToString();
	ckeditorTextbox.Text = ds.Tables[0].Rows[0]["content"].ToString();
		

   }

private void SetCKEditorContent(string content)
{
    // RegisterStartupScript is used to execute JavaScript code on the client side
 ScriptManager.RegisterStartupScript(this, GetType(), "SetCKEditorContent", "SetCKEditorContent('" + content + "');", true);

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

    protected void Btnsave_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string fileName = Path.GetFileName(FileUpload1.FileName);
            string filePath = Server.MapPath("~/Uploads/") + fileName;
            FileUpload1.SaveAs(filePath);

            // Save the file path to the database

        }
		
		 fileupload3();
		
	// Get the content from the CKEditor textarea
            string editorContent = Request.Form["ckeditorTextarea"];

            // Encode the content to prevent potential security issues
            string encodedContent = Server.HtmlEncode(editorContent);

		

        SqlCommand cmd = new SqlCommand("Sp_News");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@Image1", Label1.Text);
        cmd.Parameters.AddWithValue("@category", Drpcate.Text);
        cmd.Parameters.AddWithValue("@Title", Txttitle.Text);
        cmd.Parameters.AddWithValue("@content", ckeditorTextbox.Text);
        cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
        cmd.Parameters.AddWithValue("@EmpId", Request.QueryString["id"]);
        cmd.Parameters.AddWithValue("@descr", TextBox1.Text);
		 cmd.Parameters.AddWithValue("@newseo", Txttitle.Text);
		 cmd.Parameters.AddWithValue("@keywords", TextBox3.Text);

        ds = data.getDataSet(cmd);

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    Response.Redirect("newsadd.aspx");
        //}

        //Display success message.
        string message = "Your Articals have been successfully uploaded.";
        string script = "window.onload = function(){ alert('";
        script += message;
        script += "')};";
        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
        Response.Redirect("NewsAdd.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewsAdd.aspx");
    }
}