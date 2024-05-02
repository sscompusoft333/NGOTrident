<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="AddEnquiry_Employee.aspx.cs" Inherits="Admin_AddEnquiry_Employee" %>

<%@ Register Src="~/Admin/UserControls/DTCSS.ascx" TagPrefix="uc1" TagName="DTCSS" %>
<%@ Register Src="~/Admin/UserControls/DTJS.ascx" TagPrefix="uc1" TagName="DTJS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <uc1:DTCSS runat="server" ID="DTCSS" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
    <section class="content-header">
        <h1>Assign Work 
        </h1>
        <ol class="breadcrumb">
            <li><a href="/Admin/Dashboard.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Master</a></li>
            <li><a href="/Admin/AddEnquiry_Employee.aspx" class="active">Assign Work</a></li>
        </ol>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-12">
                <div id="ControlVisible" runat="server" class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <asp:HiddenField ID="hiddenID" runat="server"></asp:HiddenField>
                            <div class="col-md-3">
                                <label>Department</label>
                                <asp:DropDownList ID="drpDept" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="drpDept_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-md-3">
                                <label>Employee</label>
                                <asp:DropDownList ID="drpEmp" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <label>ASSIGN Date</label>
                                <asp:TextBox ID="txtDate" runat="server" placeholder="DD/MM/YYYY" class="form-control datepicker1 Field3"></asp:TextBox>
                            </div>

                            <div class="col-md-2">
                                <label>estimate Date</label>
                                <asp:TextBox ID="txtEDate" runat="server" placeholder="DD/MM/YYYY" class="form-control datepicker1 Field3"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Button ID="btnSave" runat="server" Style="margin-top: 10px;" CssClass="btn btn-primary"
                            Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="Btnback" runat="server" Style="margin-top: 10px;" CssClass="btn btn-danger"
                            Text="Back to list" OnClick="Btnback_Click" />
                        <div class="clearfix">&nbsp;</div>
                    </div>
                </div>
            </div>
        </div>
        <div class="box box-primary">
            <div class="box-body">
                <div class="widget-content nopadding">
                    <div class="table-responsive">
                        <table id="ExportTbl" class="table table-bordered display" style="width: 100%">
                            <thead>
                                <tr>
                                    <th style="text-align: left;">Sr. No.
                                    </th>
                                    <th style="text-align: left;">Customer
                                    </th>
                                    <th style="text-align: left;">ContactNo
                                    </th>
                                    <th style="text-align: left;">Requirements
                                    </th>
                                    <th style="text-align: left;">Type of Construction 
                                    </th>
                                    <th style="text-align: left;">Department 
                                    </th>
                                    <th style="text-align: left;">Employee                                            </th>
                                    <th style="text-align: left;">AssignDate
                                    </th>
                                    <th style="text-align: left;">EstimateDate
                                    </th>
                                    <th style="text-align: left;">Update 
                                    </th>
                                    <th style="text-align: left;">Update Date 
                                    </th>
                                    <th>Action</th>

                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="repEnquiryAssign" runat="server" OnItemCommand="repEnquiryAssign_ItemCommand" OnItemDataBound="repEnquiryAssign_ItemDataBound">
                                    <ItemTemplate>
                                        <tr class="gradeA">
                                            <td>
                                                <%#Container.ItemIndex+1 %>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Customer") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("PhoneNo") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblItem" runat="server" Text='<%#Eval("Requirements") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Type") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("Department") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("Employee") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("AssDate") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("EstDate") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="Label21" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="Label22" runat="server" Text='<%#Eval("RDate") %>'></asp:Label>
                                            </td>

                                            <td style="text-align: left;">

                                                <asp:LinkButton ID="lnkEdit" runat="server" Style="padding: 1px 6px; font-size: 11px;" CommandName="Edit" CssClass="btn btn-small btn-primary rolese" CommandArgument='<%#Eval("ID") %>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                                <asp:LinkButton ID="lnkDelete" runat="server" Style="padding: 1px 6px; font-size: 11px;" OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" CommandName="Delete" CssClass="btn btn-small btn-danger"
                                                    CommandArgument='<%#Eval("ID") %>'><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                <a href="AssignWorkView.aspx?id=<%#Eval("EnqId") %>&uid=<%#Eval("EmpId") %>" style="padding: 1px 6px; font-size: 11px;" class="btn btn-small btn-info abc rolese" aria-label="View"><i class="fa fa-eye"></i></a>
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
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="Server">
    <%--<script>

        $(document).ready(function () {
            $("#Body_txtDate").val($.datepicker.formatDate("dd/mm/yy", new Date()));
        });
    </script> <script>

        $(document).ready(function () {
            $("#Body_txtEDate").val($.datepicker.formatDate("dd/mm/yy", new Date()));
        });
    </script>--%>
    <uc1:DTJS runat="server" ID="DTJS" />
</asp:Content>

