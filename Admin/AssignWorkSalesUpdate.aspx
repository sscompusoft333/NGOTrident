<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="AssignWorkSalesUpdate.aspx.cs" Inherits="Admin_AssignWorkSalesUpdate" %>

<%@ Register Src="~/Admin/UserControls/DTCSS.ascx" TagPrefix="uc1" TagName="DTCSS" %>
<%@ Register Src="~/Admin/UserControls/DTJS.ascx" TagPrefix="uc1" TagName="DTJS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <uc1:DTCSS runat="server" ID="DTCSS" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
    <section class="content-header">
        <h1>Assign Work Update
        </h1>
        <ol class="breadcrumb">
            <li><a href="/Admin/Dashboard.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Master</a></li>
            <li><a href="#" class="active">Assign Work Update</a></li>
        </ol>
    </section>
    <section class="content">
        <asp:ScriptManager ID="scrpt" runat="server">
        </asp:ScriptManager>
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-body" style="padding: 5px;">
                        <div class="form-group">
                            <asp:HiddenField ID="hiddenID" runat="server"></asp:HiddenField>
                            <div class="col-md-2">
                                <label>Date</label>
                                <asp:TextBox ID="txtDate" runat="server" placeholder="DD/MM/YYYY" class="form-control datepicker Field3"></asp:TextBox>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="form-group">
                            <div class="col-md-6">
                                <label>Detail Description</label>
                                <asp:TextBox ID="txtDetDesc" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6 isdesigner">
                                <label>Upload File</label>
                                <asp:FileUpload ID="flp" runat="server" CssClass="Form-control" />
                            </div>
                        </div>
                        <div class="clearfix"></div>
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                        <div class="col-md-4" style="text-align: left;">

                            <asp:CheckBox ID="ischkFinish" runat="server" OnCheckedChanged="ischkFinish_CheckedChanged" AutoPostBack="true"/>&nbsp; Is Work Finish
                            <asp:TextBox ID="txtFinishDate" runat="server" placeholder="DD/MM/YYYY" class="datepicker Field3" Visible="false"></asp:TextBox>
                            </div>
                                    </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ischkFinish" EventName="CheckedChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        <div class="col-md-8" style="text-align: left;">
                            <asp:Button ID="btnSave" runat="server" Style="margin-top: 10px;" CssClass="btn btn-primary"
                                Text="Save" OnClick="btnSave_Click"  ValidationGroup="validsave"/>
                            <asp:Button ID="Btnback" runat="server" Style="margin-top: 10px;" CssClass="btn btn-danger"
                                Text="Back to list" OnClick="Btnback_Click" />
                        </div>
                        </div>
                </div>
            </div>
        </div>
        <div class="box box-primary">
            <div class="box-body">
                <div class="widget-content nopadding">
                    <table id="ExportTbl" class="table table-bordered display" style="width: 100%">
                        <thead>
                            <tr>
                                <th style="text-align: left;">Sr. No.
                                </th>
                                <th style="text-align: left;">Date
                                </th>
                          <%--      <th style="text-align: left;">Room
                                </th>
                                <th style="text-align: left;">Product
                                </th>--%>
                                <th style="text-align: left;">Description 
                                </th>
                                <th style="text-align: left;" class="isdesigner">File 
                                </th>
                                <th style="text-align: left;" class="isdesigner">Lock 
                                </th>  
                                <th style="text-align: left;">Finish Date 
                                </th>
                                <th>Action</th>

                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repEnquiryAssign" runat="server" OnItemCommand="repEnquiryAssign_ItemCommand">
                                <ItemTemplate>
                                    <tr class="gradeA">
                                        <td>
                                            <%#Container.ItemIndex+1 %>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:Label ID="lblItem" runat="server" Text='<%#Eval("UDate") %>'></asp:Label>
                                        </td>
                                       <%-- <td style="text-align: left;">
                                            <asp:Label ID="lblR" runat="server" Text='<%#Eval("Room") %>'></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:Label ID="lblP" runat="server" Text='<%#Eval("Product") %>'></asp:Label>
                                        </td>--%>
                                        <td style="text-align: left;">
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                                        </td>
                                        <td style="text-align: left;" class="isdesigner">
                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("WorkFile") %>'></asp:Label>
                                        </td>
                                        <td class="isdesigner">
                                            <asp:LinkButton ID="lnkActive" runat="server" CommandName="IsActive" CommandArgument='<%#Eval("ID") %>'>
                                        <%# bool.Parse(Eval("isLock").ToString())==false ? "<img src='../images/hide.gif' title='Active This' border='0'/>": "<img src='../images/show.gif' title='Deactive This' border='0'/>" %>
                                            </asp:LinkButton>
                                        </td>
                                        
                                        <td style="text-align: left;">
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("IsFinish").ToString() == "False"? "": Eval("FinishDt").ToString() %>'></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:LinkButton ID="lnkEdit" runat="server" Style="padding: 1px 6px; font-size: 11px;" CommandName="Edit" CssClass="btn btn-small btn-primary rolese" CommandArgument='<%#Eval("ID") %>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                            <asp:LinkButton ID="lnkDelete" runat="server" Style="padding: 1px 6px; font-size: 11px;" OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" CommandName="Delete" CssClass="btn btn-small btn-danger"
                                                CommandArgument='<%#Eval("ID") %>'><i class="fa fa-trash-o"></i></asp:LinkButton>
                                        </td>


                                    </tr>
                                </ItemTemplate>

                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="Server">
    <script>
        $(document).ready(function () {
           // $("#Body_txtDate").val($.datepicker.formatDate("dd/mm/yy", new Date()));

            $.ajax({
                url: 'AssignWorkReportUpdate.aspx/ControlAccess',
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    let text = data.d;
                    var elements1 = document.getElementsByClassName("isdesigner");
                    Array.prototype.forEach.call(elements1, function (element) {
                        element.style.display = data.d == "False" ? "none" : "";
                    });
                },
                error: function (response) {
                },
                failure: function (response) {
                }
            });

        });
    </script>
    <uc1:DTJS runat="server" ID="DTJS" />
</asp:Content>

