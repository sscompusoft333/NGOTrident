<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="AddProductMaster.aspx.cs" Inherits="Admin_AddProductMaster" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <script src="https://cdn.ckeditor.com/4.16.2/standard/ckeditor.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
    <section class="content-header">
        <label style="background-color: steelblue; color: white; padding: 10px; border-radius: 5px;">Step 1: Order Booking Voucher</label>
        <label style="background-color: gainsboro; padding: 10px; border-radius: 5px;">Step 2: Order Booking Details</label>

        <ol class="breadcrumb">
            <li><a href="/Admin/Dashboard.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Master</a></li>
            <li><a href="/Admin/OrderBookingMaster.aspx" class="active">Book new Order</a></li>
        </ol>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="clearfix">&nbsp;</div>
                         <div class="col-md-8">
                      
                        <div class="col-md-3">
                            <label>Date <span style="color:red">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                Font-Bod="true" ForeColor="Red" Font-Size="Large" ValidationGroup="vid" ControlToValidate="txtOrdDate"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtOrdDate" runat="server" ReadOnly="true"  CssClass="form-control "></asp:TextBox>
                        </div>
                             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                             <asp:HiddenField ID="hddid" runat="server" />
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                   <div class="col-md-3">
                                        <label for="category" >SKU</label> 
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                Font-Bod="true" ForeColor="Red" Font-Size="Large" ValidationGroup="vid" ControlToValidate="txttitle"></asp:RequiredFieldValidator>
                                         <asp:TextBox ID="TXTSKU" width="100%" Height="35px" runat="server"></asp:TextBox>
                                       </div><div class="col-md-6">
                                        <label for="category" >Product Category</label>
                                        <asp:DropDownList   ID="drpcategory" CssClass="form-control select2" runat="server">
                                          
                                        </asp:DropDownList>                                        
                                    </div> 
                                     <div class="col-md-12">  
                                <label>Product Name <span style="color:red">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                Font-Bod="true" ForeColor="Red" Font-Size="Large" ValidationGroup="vid" ControlToValidate="txttitle"></asp:RequiredFieldValidator>
                                         <asp:TextBox ID="txttitle" width="100%" Height="35px" runat="server"></asp:TextBox>
                                         </div>



                                 <div class="col-md-3">  
                                <label>Discount Price <span style="color:red">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                Font-Bod="true" ForeColor="Red" Font-Size="Large" ValidationGroup="vid" ControlToValidate="Txtdiscountprice"></asp:RequiredFieldValidator>
                                         <asp:TextBox ID="Txtdiscountprice" width="100%" Height="35px" runat="server"></asp:TextBox>
                                         </div>  
                                <div class="col-md-3">  
                                <label>Price <span style="color:red">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                Font-Bod="true" ForeColor="Red" Font-Size="Large" ValidationGroup="vid" ControlToValidate="Txtprice"></asp:RequiredFieldValidator>
                                         <asp:TextBox ID="txtprice" width="100%" Height="35px" runat="server"></asp:TextBox>
                                         </div>
                                      
                                <div class="col-md-3">  
                                <label>Color<span style="color:red">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*"
                                Font-Bod="true" ForeColor="Red" Font-Size="Large" ValidationGroup="vid"  ControlToValidate="txtcolor"></asp:RequiredFieldValidator>
                                         <asp:TextBox ID="txtcolor" width="100%" Height="35px" runat="server"></asp:TextBox>
                                         </div>

                                <div class="col-md-3">  
                                <label>Stock QTY<span style="color:red">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                                Font-Bod="true" ForeColor="Red" Font-Size="Large" ValidationGroup="vid"  ControlToValidate="Txtstock"></asp:RequiredFieldValidator>
                                         <asp:TextBox ID="Txtstock" width="100%" Height="35px" runat="server"></asp:TextBox>
                                         </div>
                              
							
						
                            <div class="col-md-12">
                                <label>Description</label> 
                          
                    <asp:TextBox ID="ckeditorTextbox" runat="server"  TextMode="MultiLine" Rows="10" Columns="80" placeholder="Enter your article here..."></asp:TextBox>
<script>
    CKEDITOR.replace('<%= ckeditorTextbox.ClientID %>', {
        // CKEditor configuration options, if needed
    });
</script>
     

                                </div>

                                 <div class="col-md-12">
                                <label>ADDITIONAL INFORMATION</label> 
                          
                    <asp:TextBox ID="TxtADDITIONAL" runat="server"  TextMode="MultiLine" Rows="10" Columns="80" placeholder="Enter your article here..."></asp:TextBox>
<script>
    CKEDITOR.replace('<%= TxtADDITIONAL.ClientID %>', {
        // CKEditor configuration options, if needed
    });
</script>
     

                                </div>

                                  <div class="col-md-12">
                                <label>SEO Short Description </label> 
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"
                                    Font-Bold="true" ForeColor="Red" Font-Size="Large" ValidationGroup="vid"  ControlToValidate="Txtshort"></asp:RequiredFieldValidator>
                             <asp:TextBox ID="Txtshort" Height="100px" Width="100%" textmode="MultiLine" placeholder="Write Blog description"   runat="server"></asp:TextBox>  
                        </div>

                        
                        <div class="clearfix">&nbsp;</div>
                                	<div class="col-md-12">
                                <label>SEO Keywords </label> 
                        
                             <asp:TextBox ID="txtkeywords" Height="80px" Width="100%" textmode="MultiLine" placeholder="Write Blog keywords"   runat="server"></asp:TextBox>  
                        </div>
							
                          

                     
                                 </ContentTemplate>
                            </asp:UpdatePanel>
                        <div class="clearfix">&nbsp;</div>
                        <div class="clearfix">&nbsp;</div>
</div>
                        <div class="col-md-4">
                                 <div class="col-md-12">
                                <label> Upload Image</label>                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                    Font-Bold="true" ForeColor="Red" Font-Size="Large" ValidationGroup="vid"  ControlToValidate="FileUpload1"></asp:RequiredFieldValidator>
                                        <asp:FileUpload ID="FileUpload1"  runat="server" />
								 <asp:Label ID="Label1" runat="server" Text=""></asp:Label><asp:Button ID="Button1" Visible="false" CssClass="btn btn-wrong"  runat="server" Text="X" />
                            </div><div class="col-md-8"></div>
                               <div class="col-md-2">
                                 <div class="clearfix">&nbsp;</div>
                        <asp:LinkButton ID="btnadd" runat="server" CssClass="btn btn-sm btn-info" OnClick="btnadd_Click" ValidationGroup="ValidAdd"><i class="fa fa-plus" aria-hidden="true"></i>Add Image</asp:LinkButton>
                                  </div>
                     <div class="clearfix">&nbsp;</div>
                        <div class="clearfix">&nbsp;</div>
                             <table id="ExportTbl1" class="table table-bordered display table-striped">
                                    <thead>
                                        <tr>
                                            <th style="text-align: left;">SrNo</th>
                                            <th style="text-align: left;">Image</th>                                          

                                            <th>
                                                <label id="lblAction1">Action</label></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rep" runat="server" OnItemCommand="rep_ItemCommand">
                                            <ItemTemplate>
                                                <tr class="gradeA">
                                                    <td >
                                                        <%#Container.ItemIndex+1 %>
                                                    </td>    
                                                    <td><img src='<%# "../Uploads/" + Eval("image") %>' style="width:100px; height:100px;"  /></td>
                                                    
                                                    <td>
                                                    
                                                        <div class="isDelVisible" style="display: inline;">
                                                            <asp:LinkButton ID="lnkDelete" runat="server" Style="padding: 1px 6px; font-size: 11px;" OnClientClick="javascript:return confirm('Are you sure you want to delete ?');"  CommandName="Delete" CssClass="btn btn-small btn-danger"
                                                                CommandArgument='<%#Eval("ID") %>'><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                            
                                                        </div>
                                                         
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>


                                    </tbody>
                                </table>
                        
                           
                           

                            </div>
                      
                    </div>
               

                    <div class="box box-primary hidden">
                        <div class="box-body">
                            <div class="widget-content">
                                <div class="table-responsive">
                                    <table id="ExportTbl" class="table table-bordered display table-striped">
                                        <thead>
                                            <tr>
                                                <th style="text-align: left;">Unit</th>
                                                <th style="text-align: left;">BatchNo</th>
                                                <th style="text-align: left;">Product Name</th>
                                                <th style="text-align: left;">Company</th>
                                                <th style="text-align: left;">Packing Type</th>
                                                <th style="text-align: left;">Carton</th>
                                                <th style="text-align: left;">Carton Qty</th>
                                                <th style="text-align: left;">tot kg</th>
                                                <th style="text-align: left;">LooseQty</th>
                                                <th style="text-align: left;">Free Pack</th>
                                                <th style="text-align: left;">Free Carton Qty</th>
                                                <th style="text-align: left;">Free Qty</th>
                                                <th style="text-align: left;">Delivery Date</th>
                                                <th style="text-align: left;">Remark</th>
                                                <th>
                                                    <label id="lblAction">Action</label></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="box-body">


                        <%--    <div class="col-md-3">
                            <label>Note</label>
                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control select2"></asp:DropDownList>

                        </div>
                        <div class="col-md-2">
                            <label>Total Carton</label>
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control datepicker"></asp:TextBox>
                        </div>--%>
                              
                        <div class="col-md-12" style="text-align: center;">
                            <div class="box-footer">
                                <div class="col-md-12">
                                        
                        
                                    <asp:Button ID="btnSaveExit" runat="server" OnClick="btnSaveExit_Click"    CssClass="btn btn-primary" Text="Save & Next"
                                       />
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-success" CausesValidation="false"
                                        Text="Back To List"  />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </section>

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

