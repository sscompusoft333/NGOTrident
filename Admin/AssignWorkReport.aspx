<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="AssignWorkReport.aspx.cs" Inherits="Admin_AssignWorkReport" %>

<%@ Register Src="~/Admin/UserControls/DTCSS.ascx" TagPrefix="uc1" TagName="DTCSS" %>
<%@ Register Src="~/Admin/UserControls/DTJS.ascx" TagPrefix="uc1" TagName="DTJS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <uc1:DTCSS runat="server" ID="DTCSS" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
    <section class="content-header">
        <h1><a href="/Admin/EnquiryMaster.aspx" class="active">Assign Work</a>
        </h1>
        <ol class="breadcrumb">
            <li><a href="/Admin/Dashboard.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
            <li>Report</li>
            <li><a href="#" class="active">Assign Work</a></li>
        </ol>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="widget-content nopadding table-responsive">
                            <table id="ExportTbl" class="table table-bordered display" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th style="text-align: left;">Sr. No.
                                        </th>
                                        <th style="text-align: left;">Assign Date 
                                        </th> <th style="text-align: left;">Estimated Date 
                                        </th>
                                        <th style="text-align: left;">Customer
                                        </th>
                                        <th style="text-align: left;" class="issalesperson">Contact No
                                        </th>
                                        <th style="text-align: left;">Project No
                                        </th>
                                        <th style="text-align: left;">Requirements
                                        </th>
                                        <th style="text-align: left;">Type of Construction 
                                        </th>


                                        <th>Update</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="repAssign" runat="server" OnItemCommand="repAssign_ItemCommand">
                                        <ItemTemplate>
                                            <tr class="gradeA">
                                                <td>
                                                    <%#Container.ItemIndex+1 %>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("AssDate") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("EstDate") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Customer") %>'></asp:Label>

                                                </td>
                                                <td style="text-align: left;" class="issalesperson">
                                                    <asp:Label ID="LabelNo" runat="server" Text='<%#Eval("PhoneNo") %>'></asp:Label>
                                                    <a href="EnquiryMaster.aspx?id=<%#Eval("EnqId") %>&assuser='true'" style="font-size: 11px;" aria-label="Edit" rel="lightbox"><i class="fa fa-pencil-square-o"></i></a>
                                                </td>
                                                <td style="text-align: left;">

                                                    <asp:LinkButton ID="lnkBoq" runat="server" CommandName="BOQ" CommandArgument='<%#Eval("BOQID") %>' Text='<%#Eval("BOQNo") %>'></asp:LinkButton>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lblItem" runat="server" Text='<%#Eval("Requirements") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("Type") %>'></asp:Label>
                                                </td>


                                                <td style="text-align: center;">
                                                    <a href="AssignWorkReportUpdate.aspx?id=<%#Eval("EnqID") %>&id1=<%#Eval("BOQID") %>" class="btn btn-small btn-primary">Update</a>
                                                </td>

                                            </tr>
                                        </ItemTemplate>

                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            debugger
            $.ajax({
                url: 'AssignWorkReport.aspx/ControlAccess',
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    let text = data.d;
                    var elements1 = document.getElementsByClassName("issalesperson");
                    Array.prototype.forEach.call(elements1, function (element) {
                        element.style.display = data.d == "False" ? "none" : "";
                    });
                },
                error: function (response) {
                },
                failure: function (response) {
                }
            });
        })

    </script>
    <uc1:DTJS runat="server" ID="DTJS" />
</asp:Content>

