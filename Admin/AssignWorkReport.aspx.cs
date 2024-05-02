using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AssignWorkReport : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    Master getdata = new Master();
    Data data = new Data();
    HttpCookie Admin;
    private DataTable dtPdf = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["ngojeetart"] == null) { Response.Redirect("../Login.aspx"); }

            Admin = Request.Cookies["ngojeetart"];
            Session["AccessRigthsSet"] = getdata.EditEmployee(Admin["UserId"]).Tables[0].Rows[0]["DepId"].ToString() == "1" ? "True" : "False";
            Filldata();
            if (Admin["Type"].ToString() == "Admin")
            {
                Response.Redirect("AddEnquiry_Employee.aspx");
            }
        }
    }

    private void Filldata()
    {
        SqlCommand cmd = new SqlCommand("sp_GetEnquiryAssignList");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@enqid", 0);
        cmd.Parameters.AddWithValue("@usrid", Admin["UserId"]);
        ds = data.getDataSet(cmd);
        repAssign.DataSource = ds;
        repAssign.DataBind();
    }


    protected void repAssign_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "BOQ")
        {
            GeneratePDF(getdata.getBOQDetail(e.CommandArgument.ToString()), false);
            // ExportToPdf(getdata.getBOQDetail(e.CommandArgument.ToString()));
        }
    }
    public void CreateTable()
    {
        dtPdf.Columns.AddRange(new DataColumn[11] {
                            new DataColumn("Room", typeof(string)),
                            new DataColumn("Name", typeof(string)),
                            new DataColumn("Code", typeof(string)),
                            new DataColumn("Item", typeof(string)),
                            new DataColumn("Description", typeof(string)),
                            new DataColumn("Brand", typeof(string)),
                            new DataColumn("Image/Color/Core Material", typeof(string)),
                            new DataColumn("Unit", typeof(string)),
                            new DataColumn("Qty", typeof(string)),
                            new DataColumn("Dimension", typeof(string)),
                            //new DataColumn("Total Price", typeof(string)),
                            new DataColumn("Remark", typeof(string))});
    }
    public void GeneratePDF(DataSet dataset, Boolean isPdf)
    {

        if (dataset != null)
        {
            CreateTable();
            StringBuilder sb = new StringBuilder();
            //string[] SplitValue = _OrderId.Split(',');
            sb.Append("<style>");
            sb.Append("\n @media print {");
            sb.Append("\n footer {page-break-after: always;}");
            sb.Append("\n }</style>");

            //  string ss = "Sp_OrderPrint " + SplitValue[_Count];
            //    DataSet dsGet = gData.GCNoteRpt(SplitValue[_Count], "", "");
            DataSet dsGet = dataset;
            dtPdf.Rows.Clear();
            //foreach (DataRow drr in dsGet.Tables[3].Rows)
            //{

            //    dtPdf.Rows.Add(drr["Product"].ToString(), drr["Product_Code"].ToString(), drr["Material_Finish"].ToString(), drr["Description"].ToString(), drr["Brand"].ToString(), drr["Material_Color"].ToString(), drr["Unit"].ToString(), drr["Qty"].ToString(), drr["Dimension"].ToString(), drr["Remark"].ToString());
            //}

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {

                    sb.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'>");
                    sb.Append("<tr>");
                    sb.Append("<td align='center'>");
                    sb.Append("<table width='900' border='0' cellspacing='0' cellpadding='0'>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("<table width='100%' border='0' bordercolor='#D5D5D5' cellspacing='0' cellpadding='5'>");
                    sb.Append("<tr>");
                    sb.Append("<td align='center'>");
                    sb.Append("<p Style='font-size:22px; color:#000; font-weight:bold; padding:5px; margin:0px;'>BUILT-IN MODULAR (OPC) PRIVATE LIMITED</p>");
                    sb.Append("<p style='font-size: 12px;padding: 5px; margin: 0px;'>");
                    sb.Append("IT-2011, SITAPURA INDUSTRIAL AREA, PHASE-4, JAIPUR<br />");
                    sb.Append("<strong>GST NO :</strong>08AAKCB0699R1ZR<br />");
                    sb.Append("<strong>(M) :</strong>  78910-69600, <strong>(E) :</strong> A2ACRMMODULAR@GMAIL.COM<br />");
                    sb.Append("</p>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("</table>");
                    //sb.Append("</td>");
                    //sb.Append("</tr>");
                    //sb.Append("</table>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("<table width='100%' border='0' style='margin-top:-2px;' cellspacing='0' cellpadding='0'>");
                    sb.Append("<tr>");
                    sb.Append("<td width='32.5%'>&nbsp;</td>");
                    sb.Append("<td width='30%' align='center'>");

                    sb.Append("</td>");
                    sb.Append("<td width='10%'>&nbsp;</td>");
                    sb.Append("<td width='35%'>");
                    sb.Append("<table width='100%' border='1' bordercolor='#D5D5D5' cellspacing='0' cellpadding='0'>");
                    sb.Append("<tr><td>");
                    sb.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'>");
                    sb.Append("<tr>");
                    sb.Append("<td><strong>PROJECT NO : </strong></td>");
                    sb.Append("<td><strong>" + dsGet.Tables[0].Rows[0]["BOQNo"] + "</strong></td>");
                    sb.Append("</tr>");
                    sb.Append("</table>");
                    sb.Append("</td></tr></table>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("</table>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("<table width='100%' border='0' cellspacing='0' cellpadding='5'>");
                    sb.Append("<tr>");
                    sb.Append("<td valign='top' width='50%'>");
                    sb.Append("<table width='100%' border='0' cellspacing='0' cellpadding='2'>");
                    sb.Append("<tr>");
                    sb.Append("<td valign='top' width='30%'><strong>Client:</strong></td>");
                    sb.Append("<td valign='top' style='font-size: 14px;'>" + dsGet.Tables[0].Rows[0]["customer"].ToString() + "</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td valign='top'><strong>Date:</strong></td>");
                    sb.Append("<td valign='top' style='font-size: 14px;'>" + dsGet.Tables[1].Rows[0]["AddedDate"].ToString() + "</td>");
                    sb.Append("</tr>");
                    sb.Append("</table>");
                    sb.Append("</td>");
                    sb.Append("<td valign='top' width='50%'>");
                    sb.Append("<table width='100%' border='0' cellspacing='0' cellpadding='2'>");
                    sb.Append("<tr>");
                    sb.Append("<td valign='top' width='45%'><strong>No of Rooms:</strong></td>");
                    sb.Append("<td valign='top' style='font-size: 14px;'>" + dsGet.Tables[1].Rows.Count.ToString() + "</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td valign='top'><strong>Total No of Items:</strong></td>");
                    sb.Append("<td valign='top' style='font-size: 14px;'>" + dsGet.Tables[2].Rows.Count.ToString() + "</td>");
                    sb.Append("</tr>");
                    sb.Append("</table>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("</table>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>&nbsp;</td>");
                    sb.Append("</tr>");

                    /*-------------------Multi Record------------------*/
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("<table width='100%' border='1px' bordercolor='#D5D5D5' cellspacing='0' cellpadding='0'>");
                    sb.Append("<tr>");
                    foreach (DataColumn column in dtPdf.Columns)
                    {
                        sb.Append("<th align='left'>");
                        sb.Append(column.ColumnName);
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                    foreach (DataRow row in dsGet.Tables[3].Rows)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td style='font-size: 14px;'>");
                        sb.Append(row["Room"]);
                        sb.Append("<br />&nbsp;</td>");
                        sb.Append("<td style='font-size: 14px;'>");
                        sb.Append(row["Product"]);
                        sb.Append("<br />&nbsp;</td>");
                        sb.Append("<td style='font-size: 14px;'>");
                        sb.Append(row["Product_Code"]);
                        sb.Append("<br />&nbsp;</td>");
                        sb.Append("<td style='font-size: 14px;'>");
                        sb.Append(row["Material_Finish"]);
                        sb.Append("<br />&nbsp;</td>");
                        sb.Append("<td style='font-size: 14px;'>");
                        sb.Append(row["Description"]);
                        sb.Append("<br />&nbsp;</td>");
                        sb.Append("<td style='font-size: 14px;'>");
                        sb.Append(row["Brand"]);
                        sb.Append("<br />&nbsp;</td>");
                        sb.Append("<td valign='top' style='font-size: 14px;'>");
                        sb.Append("<img src='" + row["PImage"] + "' height='30' width= '30'/>" + row["Material_Color"]);
                        sb.Append("<br />&nbsp;</td>");
                        sb.Append("<td style='font-size: 14px;'>");
                        sb.Append(row["Unit"]);
                        sb.Append("<br />&nbsp;</td>");
                        sb.Append("<td style='font-size: 14px;'>");
                        sb.Append(row["Qty"]);
                        sb.Append("<br />&nbsp;</td>");
                        sb.Append("<td style='font-size: 14px;'>");
                        sb.Append(row["Dimension"]);
                        sb.Append("<br />&nbsp;</td>");
                        sb.Append("<td style='font-size: 14px;'>");
                        sb.Append(row["Remark"]);
                        sb.Append("<br />&nbsp;</td>");
                        sb.Append("</tr>");
                    }

                    sb.Append("</table>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("<table width='100%' border='0' cellspacing='0' cellpadding='2'>");
                    sb.Append("<tr><td>&nbsp;<br/></td></tr>");
                    sb.Append("<tr>");
                    sb.Append("<td><Strong>Remark :</Strong</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td style='font-size: 12px;'><p>" + dsGet.Tables[0].Rows[0]["Remark"].ToString() + "</p></td>");
                    sb.Append("</tr>");
                    //sb.Append("<tr>");
                    //sb.Append("<td style='font-size: 12px;'>");

                    //sb.Append("</td>");
                    //sb.Append("</tr>");
                    sb.Append("</table>");
                    sb.Append("<table width='100%' border='0' cellspacing='0' cellpadding='5'>");
                    sb.Append("<tr>");
                    sb.Append("<td><Strong>Terms & Conditons :</Strong>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("<p style='font-size:12px;'>ngojeetart guarantees the prices in this proposal till 20 days. Prices may vary when booked be are applicable for this proposal only.any modifications may result in a change of prices.");
                    sb.Append("<br/>Your order will be delivered on or before the assured delivery date. Changing an order or unforces delivery time.");
                    sb.Append("<br/>ngojeetart is able to process your final order and start production only post a 50% payment.");
                    sb.Append("<br/>Invoicing of the overall project will be done in 80% - 20% ratio split as Products and Services done by our authorized reseller and Services Invoicing will be done by our group company.");
                    sb.Append("<br/>ngojeetart only facilitates financial loans and services. Approvals, processing and terms are at the entity.");
                    sb.Append("<br/>Any non-manufacturing defects and damages post receiving delivery are not valid for returns order furniture pieces, purchased from ngojeetart, cannot be returned or exchanged.</p>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("</table>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("</table>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("</table>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr height='100px;'><td>&nbsp;</td></tr>");

                    sb.Append("</table>");
                    sb.Append("<footer></footer>");
                }
            }

            //if (isPdf)
            //{
            //    string  pdfname = ExporttoPDF(sb);
            //    Response.Write("<script>window.open('../PDF/"+ pdfname + ".pdf','_blank');</script>");
            //}
            //else
            //{
            //Export HTML String as PDF.
            StringReader sr = new StringReader(sb.ToString());
            Session["InvPrint"] = sb.ToString();
            Response.Write("<script>window.open('BOQPrint.aspx','_blank');</script>");
            //}
        }

    }

    //public void ExportToPdf(DataSet myData)
    //{
    //    DataTable dt = myData.Tables[3];
    //    Document pdfDoc = new Document(PageSize.A4.Rotate(), 10, 10, 20, 10);
    //    Font font8 = FontFactory.GetFont("CALIBRI", 8);
    //    Font font9 = FontFactory.GetFont("CALIBRI", 9);
    //    Font font11 = FontFactory.GetFont("CALIBRI", 11);
    //    try
    //    {
    //        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);
    //        pdfDoc.Open();

    //        if (dt.Rows.Count > 0)
    //        {
    //            PdfPTable PdfTable = new PdfPTable(1);
    //            PdfTable.TotalWidth = 500f;
    //            PdfTable.LockedWidth = true;

    //            PdfPCell PdfPCell = new PdfPCell(new Phrase(new Chunk("BUILT-IN MODULAR (OPC) PRIVATE LIMITED", font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
    //            PdfTable.AddCell(PdfPCell);


    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("IT-2011, SITAPURA INDUSTRIAL AREA, PHASE-4, JAIPUR", font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
    //            PdfTable.AddCell(PdfPCell);

    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("GST NO.- 08AAKCB0699R1ZR", font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
    //            PdfTable.AddCell(PdfPCell);

    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("(M) : 78910-69600, (E) : A2ACRMMODULAR@GMAIL.COM ", font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
    //            PdfTable.AddCell(PdfPCell);

    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("BOQ NO : " + myData.Tables[0].Rows[0]["BOQNo"].ToString(), font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
    //            PdfTable.AddCell(PdfPCell);

    //            pdfDoc.Add(PdfTable);

    //            PdfTable = new PdfPTable(7);
    //            PdfTable.TotalWidth = 780f;
    //            PdfTable.SpacingBefore = 20f;
    //            PdfTable.LockedWidth = true;
    //            PdfPCell = new PdfPCell(new Phrase());
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("Client", font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk(myData.Tables[0].Rows[0]["Customer"].ToString(), font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase());
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("No. of Rooms", font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk(myData.Tables[1].Rows.Count.ToString(), font9)));//myData.Tables[1].Rows[0]["AddedDate"].ToString()
    //            PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase());
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);

    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("", font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("Date", font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk(myData.Tables[1].Rows[0]["AddedDate"].ToString(), font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase());
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("Total No. of Items", font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk(myData.Tables[2].Rows.Count.ToString(), font9)));
    //            PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase());
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);

    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase());
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);


    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("BOQ Details(" + myData.Tables[0].Rows[0]["Room"].ToString() + ")", font11)));
    //            PdfPCell.PaddingTop = 20f;
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
    //            PdfTable.AddCell(PdfPCell);

    //            pdfDoc.Add(PdfTable);
    //            DrawLine(writer, 25f, PdfTable.TotalHeight - 20f, pdfDoc.PageSize.Width - 25f, PdfTable.TotalHeight - 20f, new BaseColor(System.Drawing.Color.Red));
    //            PdfTable = new PdfPTable(dt.Columns.Count - 2);
    //            PdfTable.TotalWidth = 780f;
    //            PdfTable.LockedWidth = true;
    //            PdfTable.SpacingBefore = 20f;
    //            PdfTable.AddCell(new Phrase(new Chunk("S.No.", font9)));
    //            PdfTable.AddCell(new Phrase(new Chunk("Image", font9)));
    //            PdfTable.AddCell(new Phrase(new Chunk("Room", font9)));
    //            PdfTable.AddCell(new Phrase(new Chunk("Product", font9)));
    //            PdfTable.AddCell(new Phrase(new Chunk("Product Code", font9)));
    //            PdfTable.AddCell(new Phrase(new Chunk("Material", font9)));
    //            PdfTable.AddCell(new Phrase(new Chunk("Material Color", font9)));
    //            PdfTable.AddCell(new Phrase(new Chunk("Unit", font9)));
    //            PdfTable.AddCell(new Phrase(new Chunk("Price Per Unit", font9)));
    //            PdfTable.AddCell(new Phrase(new Chunk("Qty", font9)));
    //            PdfTable.AddCell(new Phrase(new Chunk("Dimension", font9)));
    //            PdfTable.AddCell(new Phrase(new Chunk("Total Price", font9)));
    //            PdfTable.AddCell(new Phrase(new Chunk("Remark", font9)));

    //            for (int rows = 0; rows <= dt.Rows.Count - 1; rows++)
    //            {
    //                for (int column = 0; column <= dt.Columns.Count - 1; column++)
    //                {
    //                    if (column == 1)
    //                    {
    //                        if (dt.Rows[rows][column].ToString() != "")
    //                        {
    //                            iTextSharp.text.Image myImage = iTextSharp.text.Image.GetInstance(Path.GetDirectoryName(Server.MapPath(".")) + dt.Rows[rows][column]);
    //                            myImage.ScaleAbsoluteHeight(30);
    //                            myImage.ScaleAbsoluteWidth(30);
    //                            myImage.Alignment = Element.ALIGN_CENTER;
    //                            PdfPCell cell = new PdfPCell(myImage);
    //                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
    //                            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
    //                            PdfTable.AddCell(cell);
    //                        }
    //                        else { PdfTable.AddCell(new PdfPCell()); }
    //                    }
    //                    else
    //                    {
    //                        if (column != 8 && column != 11)
    //                        {
    //                            PdfPCell = new PdfPCell(new Phrase(new Chunk(dt.Rows[rows][column].ToString(), font8)));
    //                            PdfTable.AddCell(PdfPCell);
    //                        }
    //                    }
    //                }
    //            }
    //            pdfDoc.Add(PdfTable);
    //            PdfTable = new PdfPTable(2);
    //            PdfTable.TotalWidth = 780f;
    //            PdfTable.LockedWidth = true;
    //            PdfTable.SpacingBefore = 40f;

    //            PdfPTable PdfTable1 = new PdfPTable(1);
    //            PdfTable1.TotalWidth = 390f;
    //            PdfTable1.LockedWidth = true;

    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("Remark : ", font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable1.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk(myData.Tables[0].Rows[0]["Remark"].ToString(), font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable1.AddCell(PdfPCell);

    //            PdfPCell = new PdfPCell(PdfTable1);
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);

    //            PdfPTable PdfTable2 = new PdfPTable(4);
    //            PdfTable2.TotalWidth = 390f;
    //            PdfTable2.LockedWidth = true;

    //            PdfPCell = new PdfPCell(new Phrase());
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable2.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase());
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable2.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("", font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable2.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("", font9)));
    //            PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable2.AddCell(PdfPCell);

    //            PdfPCell = new PdfPCell(new Phrase());
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable2.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase());
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable2.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk(" ", font9)));
    //            PdfPCell.PaddingBottom = 5;
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable2.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("", font9))); PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable2.AddCell(PdfPCell);

    //            PdfPCell = new PdfPCell(new Phrase());
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable2.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase());
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable2.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("", font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfPCell.PaddingBottom = 5;
    //            PdfTable2.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("", font9)));
    //            PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable2.AddCell(PdfPCell);

    //            PdfPCell = new PdfPCell(PdfTable2);
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);
    //            pdfDoc.Add(PdfTable);

    //            PdfTable = new PdfPTable(1);
    //            PdfTable.TotalWidth = 780f;
    //            PdfTable.SpacingBefore = 20f;
    //            PdfTable.LockedWidth = true;

    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("Terms and Conditions : ", font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("ngojeetart guarantees the prices in this proposal till 20 days. Prices may vary when booked be are applicable for this proposal only.any modifications may result in a change of prices.", font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("Your order will be delivered on or before the assured delivery date. Changing an order or unforces delivery time.", font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("ngojeetart is able to process your final order and start production only post a 50% payment.", font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("Invoicing of the overall project will be done in 80% - 20% ratio split as Products and Services done by our authorized reseller and Services Invoicing will be done by our group company.", font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);

    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("ngojeetart only facilitates financial loans and services. Approvals, processing and terms are at the entity.", font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);
    //            PdfPCell = new PdfPCell(new Phrase(new Chunk("Any non-manufacturing defects and damages post receiving delivery are not valid for returns order furniture pieces, purchased from ngojeetart, cannot be returned or exchanged.", font9)));
    //            PdfPCell.Border = Rectangle.NO_BORDER;
    //            PdfTable.AddCell(PdfPCell);

    //            pdfDoc.Add(PdfTable);
    //        }
    //        pdfDoc.Close();
    //        Response.ContentType = "application/pdf";
    //        Response.AddHeader("content-disposition", "attachment; filename=BOQReport_" + DateTime.Now.Date.Day.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Year.ToString() + DateTime.Now.Date.Hour.ToString() + DateTime.Now.Date.Minute.ToString() + DateTime.Now.Date.Second.ToString() + DateTime.Now.Date.Millisecond.ToString() + ".pdf");
    //        System.Web.HttpContext.Current.Response.Write(pdfDoc);
    //        Response.Flush();
    //        Response.End();
    //    }
    //     System.Web.HttpContext.Current.Response.Write(ioEx.Message)
    //    catch (Exception ex)
    //    {
    //        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert(" + ex.ToString() + ")", true);
    //    }
    //}
    private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, BaseColor color)
    {
        PdfContentByte contentByte = writer.DirectContent;
        contentByte.SetColorStroke(color);
        contentByte.MoveTo(x1, y1);
        contentByte.LineTo(x2, y2);
        contentByte.Stroke();
    }
    [WebMethod]
    public static string ControlAccess()
    {
        return (string)HttpContext.Current.Session["AccessRigthsSet"];
    }
}