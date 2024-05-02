using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class blog : System.Web.UI.Page
{
    Data data = new Data();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = data.getDataSet("Select * from [dbo].[View_BLOG]");
        rpt.DataSource = ds;
        rpt.DataBind();
    }
}