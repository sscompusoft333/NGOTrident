<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="SubcategoryMaster.aspx.cs" Inherits="Admin_SubcategoryMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
    <section class="content-header">
        <h1> Category 
        </h1>
        <ol class="breadcrumb">
            <li><a href="/Admin/Dashboard.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Master</a></li>
            <li><a href="/Admin/PackingMaster.aspx" class="active">Add Category </a></li>
        </ol>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="clearfix">&nbsp;</div>

                       
                        <div class="clearfix">&nbsp;</div>
                          <div class="col-md-4">
                            <label>Select Category</label>
                             <asp:DropDownList ID="drpGst" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                Font-Bold="true" ForeColor="Red" Font-Size="Large" ControlToValidate="drpGst"></asp:RequiredFieldValidator>
                        </div>  

                        <div class="col-md-4">
                            <label>Sub Category  NAME</label>
                            <asp:TextBox ID="txtPackName" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                Font-Bold="true" ForeColor="Red" Font-Size="Large" ControlToValidate="txtPackName"></asp:RequiredFieldValidator>
                        </div>                     
                        </div>
                   

                    <div class="box-body">

                        <div class="clearfix">&nbsp;</div>

                        <div class="col-md-12" style="text-align: center;">
                            <div class="box-footer">

                           <asp:Button ID="btnSaveExit" runat="server" CssClass="btn btn-primary" Text="Save & Exit" OnClick="btnSaveExit_Click"                           />
                              <%--  <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-success" CausesValidation="false"
                                    Text="Back To List" OnClick="btnCancel_Click" />--%>

                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        
    </section>
    <div class="col-md-2 col-xs-4">
        <asp:Image ID="imagE1" runat="server" Height="40px" Width="40px" Visible="false" />
        <asp:Image ID="imagAdhar" runat="server" Height="40px" Width="40px" Visible="false" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="Server">
    <script>
        function myFunction() {
            /* Get the text field */
            var copyText = document.getElementById("Body_txtContactInfo");

            /* Select the text field */
            copyText.select();
            copyText.setSelectionRange(0, 99999); /* For mobile devices */

            /* Copy the text inside the text field */
            navigator.clipboard.writeText(copyText.value);

            /* Alert the copied text */
            // alert("Copied the text: " + copyText.value);
        }
        function RelativeContact() {
            /* Get the text field */
            var copyText = document.getElementById("Body_txtRelativeContactNo");

            /* Select the text field */
            copyText.select();
            copyText.setSelectionRange(0, 99999); /* For mobile devices */

            /* Copy the text inside the text field */
            navigator.clipboard.writeText(copyText.value);

            /* Alert the copied text */
            // alert("Copied the text: " + copyText.value);
        }
    </script>
</asp:Content>

