<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Contactus.aspx.cs" Inherits="Admin_Contactus" %>

<%@ Register Src="~/Admin/UserControls/DTCSS.ascx" TagPrefix="uc1" TagName="DTCSS" %>
<%@ Register Src="~/Admin/UserControls/DTJS.ascx" TagPrefix="uc1" TagName="DTJS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <uc1:DTCSS runat="server" ID="DTCSS" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
    <section class="content-header" style="height: 2.5em;">
        <h1>Contact Us Massage</h1>
        <ol class="breadcrumb">
            <li><a href="/Admin/Dashboard.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Master</a></li>
            <li><a href="/Admin/Contactus.aspx" class="active">Contact Us List</a></li>
        </ol>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="widget-content nopadding" style="overflow: auto;">
                            <table id="ExportTbl" class="table table-bordered display" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th style="text-align: left;">Sr. No.
                                        </th>
                                        <th style="text-align: left;">Name
                                        </th>
                                         <th style="text-align: left;">Email Id
                                        </th>
                                         <th style="text-align: left;">Subject
                                        </th>
                                         <th style="text-align: left;">Message
                                        </th>
                                        
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rep" runat="server" >
                                        <ItemTemplate>
                                            <tr class="gradeA">
                                                <td>
                                                    <%#Container.ItemIndex+1 %>
                                                </td>

                                                <td style="text-align: left;">
                                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: left;">

                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("Massage") %>'></asp:Label>
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

            $.ajax({
                url: 'Contact Us.aspx/ControlAccess',
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    debugger
                    let text = data.d;
                    const myArray = text.split(",");

                    document.getElementById("Body_lnkAdd").style.display = myArray[0] == "False" ? "none" : "";

                    var elements = document.getElementsByClassName("isEditVisible");
                    Array.prototype.forEach.call(elements, function (element) {
                        element.style.display = myArray[1] == "False" ? "none" : "inline";
                    });
                    var elements1 = document.getElementsByClassName("isDelVisible");
                    Array.prototype.forEach.call(elements1, function (element) {
                        element.style.display = myArray[2] == "False" ? "none" : "inline";
                       
                    });
                    debugger
                    if (myArray[2] == "True") {
                        document.getElementById("Body_rep_lnkDelete_0").style.display = "none";
                        document.getElementById("Body_rep_lnkDelete_1").style.display = "none";
                    }
                    if (myArray[1] == 'False' && myArray[2] == 'False') {
                        document.getElementById("lblAction").innerHTML = "";

                    }
                    document.getElementsByClassName("buttons-excel")[0].style.display = myArray[3] == "False" ? "none" : "";

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

