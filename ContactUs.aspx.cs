using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class ContactUs : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    Data data = new Data();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

        }
    }

    protected void btnEnquiry_Click(object sender, EventArgs e)
    {
        //SqlCommand cmd = new SqlCommand("Sp_contactus");
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Clear();
        //cmd.Parameters.AddWithValue("@Name", user_name.Value);
        //cmd.Parameters.AddWithValue("@Subject", email_subject.Value);
        //cmd.Parameters.AddWithValue("@ContactInfo", user_Phone.Value);
        //cmd.Parameters.AddWithValue("@Massage", email_message.Value);
        //cmd.Parameters.AddWithValue("@EmailId", user_email.Value);

        //ds = data.getDataSet(cmd);

        //MailMessage msgs = new MailMessage();
        //msgs.To.Add("kuldeepchaurasia4656@gmail.com");
        //MailAddress address = new MailAddress("info@khalo.in", "SM Hotel & Resort");
        //msgs.From = address;
        //msgs.Subject = "Congratulations, New inquiry";
        //string body = "<h1>Hello,<b> Admin</b></h1>,";
        //body += "<h4><b>New inquiry</b></h4>";
        //body += "<br />User Information";
        //body += "<br /><b>Name:-</b> " + user_name.Value + ",";
        //body += "<br /><b>EmailId:-</b> " + user_email.Value + ", ";
        //body += "<br /><b>ContactInfo:-</b> " + user_Phone.Value + ",";
        //body += "<br /><b>Massage:-</b> " + email_message.Value + ", ";
        //body += "<br /><br /><img src='' style='width:300px; height:150px'/>";
        //body += "<br /><br />Thanks";
        //msgs.Body = body;
        //msgs.IsBodyHtml = true;
        //SmtpClient client = new SmtpClient();
        //client.Host = "mail.khalo.in"; // Replace with your full SMTP server address
        //client.Port = 587; // Replace with the appropriate port (587 is common for secure connections)
        //client.UseDefaultCredentials = false;
        //client.Credentials = new NetworkCredential("info@khalo.in", "Khalo@12345");
        //client.EnableSsl = false;
        //client.Send(msgs);


        ////if (ds.Tables[0].Rows.Count > 0)
        ////{
        ////    Response.Redirect("Employee.aspx");
        ////}

        ////Display success message.
        ////string message = "Your details have been Send successfully.";
        ////string script = "window.onload = function(){ alert('";
        ////script += message;
        ////script += "')};";
        ////ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
        //ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Enquiry Send Successfully') ; window.location = 'Default.aspx'", true);
    }
}