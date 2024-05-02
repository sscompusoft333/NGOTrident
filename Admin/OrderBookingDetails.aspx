<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderBookingDetails.aspx.cs" Inherits="Admin_OrderBookingDetails" %>

<%@ Register Src="~/Admin/UserControls/DTCSS.ascx" TagPrefix="uc1" TagName="DTCSS" %>
<%@ Register Src="~/Admin/UserControls/DTJS.ascx" TagPrefix="uc1" TagName="DTJS" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <uc1:DTCSS runat="server" ID="DTCSS" />

    <link href="../content/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
    <!-- Theme style -->
    <link href="../content/dist/css/AdminLTE.css" rel="stylesheet" />
    <link href="../content/dist/css/skins/skin-purple.css" rel="stylesheet" />
    <link href="../content/plugins/select2/select2.css" rel="stylesheet" />
    <link href="../content/plugins/highslide/highslide.css" rel="stylesheet" />
    <link href="../content/plugins/highslide/highslide-ie6.css" rel="stylesheet" />
    <link href="../content/plugins/datepicker/datepicker3.css" rel="stylesheet" />
    <link href="../content/plugins/jQueryUI/jquery-ui.css" rel="stylesheet" />
    <link href="../content/plugins/Toster/jquery.toast.css" rel="stylesheet" />
    <link href="../content/plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" />
    <script src="../content/plugins/jQuery/jquery.js"></script>
    <script src="../content/plugins/jQueryUI/jquery-ui.min.js"></script>
      <script type="text/javascript">
          function clearTextBoxValue(textBoxId) {
              var textBox = document.getElementById(textBoxId);
              textBox.value = '';
          }

          function setDefaultIfEmpty(textBox) {
              if (textBox.value === '') {
                  textBox.value = '0';
              }
          }
      </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <section class="content-header">
            <label style="background-color: gainsboro; padding: 10px; border-radius: 5px;">Step 1: Order Booking Voucher</label>
            <label style="background-color: steelblue; color: white; padding: 10px; border-radius: 5px;">Step 2: Order Booking Details</label>
        </section>

        <section class="content">
            <div class="box box-primary">                
                <div class="box-body" style="background-color: ghostwhite;">

                    <div class="clearfix">&nbsp;</div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                         <label>  Order No : <asp:Label ID="Lblorderno" runat="server"  ></asp:Label>&nbsp;&nbsp;&nbsp;
                            Customer Name: <asp:Label ID="lblcust" runat="server"  ></asp:Label></label>
                        <div class="clearfix">&nbsp;</div>
                   

                            <div class="col-md-2">
                                <label>Company <span style="color:red">*</span></label>
                                <asp:HiddenField ID="hddid" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    Font-Bod="true" ForeColor="Red" Font-Size="Large" ControlToValidate="drpComp" InitialValue="0" ValidationGroup="ValidAdd"></asp:RequiredFieldValidator>
                                <asp:DropDownList ID="drpComp" runat="server" CssClass="form-control select2" OnSelectedIndexChanged="drpComp_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <label>Product Category</label>
                                <asp:DropDownList ID="drpPCtg" OnSelectedIndexChanged="drpPCtg_SelectedIndexChanged" onchange="adjustDropDownPosition(this)" AutoPostBack="true"  runat="server" CssClass="dropdown-adjust form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <label>Product Name <span style="color:red">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    Font-Bod="true" ForeColor="Red" Font-Size="Large" ControlToValidate="drpProd" ValidationGroup="ValidAdd" InitialValue="0"></asp:RequiredFieldValidator>
                                <asp:DropDownList ID="drpProd" runat="server" onchange="adjustDropDownPosition(this)"  CssClass="dropdown-adjust form-control select2" OnSelectedIndexChanged="drpProd_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <label>Packing Name <span style="color:red">*</span></label>
                                <asp:DropDownList ID="drpPackType" AutoPostBack="true" OnSelectedIndexChanged="drpPackType_SelectedIndexChanged" onchange="adjustDropDownPosition(this)"  runat="server" CssClass="dropdown-adjust form-control select2"></asp:DropDownList>
                            </div>
                           
                    <div class="col-md-2">
                        <label>C/S <span style="color:red">*</span></label>
                        <asp:DropDownList ID="drpCs" Enabled="false" runat="server" CssClass="form-control select2"></asp:DropDownList>

                    </div>
                    <div class="col-md-1">
                        <label>C/S Qty<span style="color:red">*</span></label>
                        <asp:TextBox ID="txtCsQty" runat="server" CssClass="form-control"  TextMode="Number" onblur="setDefaultIfEmpty(this);" onfocus="clearTextBoxValue(this.id)"  Text="0"></asp:TextBox>
                       
                    </div>
                    <div class="col-md-1" runat="server" visible="false">
                        <label>Loose Qty<span style="color:red">*</span></label>
                        <asp:TextBox ID="txtLQty" runat="server" CssClass="form-control" TextMode="Number" Text="0"></asp:TextBox>
                      
                    </div>
                    <div class="col-md-1">
                        <label>Load Type<span style="color:red">*</span></label>
                        <asp:DropDownList ID="drpLoadType" runat="server" CssClass="form-control select2">
                            <asp:ListItem Value="PTL">PTL</asp:ListItem>
                            <asp:ListItem Value="FTL">FTL</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                           <asp:Panel ID="pnl1" Visible="false"  runat="server">
                    <div class="clearfix">&nbsp;</div>
                    <div class="col-md-2">
                        <label>Free Packing Type <span style="color:red">*</span></label>
                        <asp:DropDownList ID="drpFreePackType" AutoPostBack="true"  OnSelectedIndexChanged="drpFreePackType_SelectedIndexChanged"  runat="server"  CssClass="form-control select2"></asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <label>C/S </label>
                        <asp:DropDownList ID="drpFreeCs" runat="server" CssClass="form-control select2"></asp:DropDownList>
                    </div>
                    <div class="col-md-1">
                        <label style="font-size: 13.5px;">Free Carton Qty</label>
                        <asp:TextBox ID="txtFreeCsQty" runat="server" CssClass="form-control" onkeypress="return IsNumeric(event, 2);" TextMode="Number" Text="0"></asp:TextBox>
                        <span class="numerror" style="color: Red; display: none">*Numeric[0-9]</span>
                    </div>
                    <div class="col-md-1" >
                        <label>Free Loose Qty</label>
                        <asp:TextBox ID="txtFreeLQty" runat="server" CssClass="form-control" onkeypress="return IsNumeric(event, 3);" TextMode="Number" Text="0"></asp:TextBox>
                        <span class="numerror" style="color: Red; display: none">*Numeric[0-9]</span>

                            </div>
                                    
                   </asp:Panel>
                
 
                    <div class="clearfix">&nbsp;</div>
                    <div class="clearfix">&nbsp;</div>
                </ContentTemplate>
                    </asp:UpdatePanel>
                    <div runat="server" visible="false" class="col-md-2">
                        <label>Delivery Date <span style="color:red">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                            Font-Bod="true" ForeColor="Red" Font-Size="Large" ControlToValidate="txtDelDate" ValidationGroup="ValidAdd"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtDelDate" runat="server" CssClass="form-control datepicker"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <label>Remark</label>
                        <asp:TextBox TextMode="MultiLine" ID="txtRemark" runat="server" CssClass="form-control" Height="33px"></asp:TextBox>
                    </div>
                    <div class="col-md-1" style="padding-top: 8px;">
                        <div class="clearfix">&nbsp;</div>
                        <asp:LinkButton ID="btnadd" runat="server" CssClass="btn btn-sm btn-info" OnClick="btnadd_Click" ValidationGroup="ValidAdd"><i class="fa fa-plus" aria-hidden="true"></i></asp:LinkButton>
                        <asp:LinkButton ID="btnReset" runat="server" CssClass="btn btn-sm btn-success" OnClick="btnReset_Click"><i class="fa fa-refresh" aria-hidden="true" ></i></asp:LinkButton>
                    </div>
                 

                    <div class="clearfix">&nbsp;</div>
                    <div class="clearfix">&nbsp;</div>

                </div>

                <div class="box box-primary">
                    <div class="box-body">
                        <div class="widget-content">
                            <div class="table-responsive">
                                <table id="ExportTbl" class="table table-bordered display table-striped">
                                    <thead>
                                        <tr>
                                            <th style="text-align: left;">SrNo</th>
                                            <th style="text-align: left;">Company</th>
                                            <th style="text-align: left;">Product Name</th>
                                            
                                            <th style="text-align: left;">Packing Name</th>
                                          <%--  <th style="text-align: left;">Carton</th>--%>
                                            <th style="text-align: left;">Carton Qty</th>
                                            <%--<th style="text-align: left;">LooseQty</th>--%>
                                            <th style="text-align: left;">LoadType</th>
                                           <%-- <th style="text-align: left;">Free Pack</th>
                                            <th style="text-align: left;">Free Carton</th>
                                            <th style="text-align: left;">Free Carton Qty</th>
                                            <th style="text-align: left;">Free Qty</th>--%>
                                           
                                            <th style="text-align: left;">Remark</th>

                                            <th>
                                                <label id="lblAction">Action</label></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rep" runat="server" OnItemCommand="rep_ItemCommand">
                                            <ItemTemplate>
                                                <tr class="gradeA">
                                                    <td >
                                                        <%#Container.ItemIndex+1 %>
                                                    </td>    
                                                    <td><%#Eval("Company") %></td>
                                                    <td><%#Eval("Product") %></td>                                            
                                                    <td><%#Eval("PackingType") %></td>
                                                   <%-- <td><%#Eval("Cartoon") %></td>--%>
                                                    <td><%#Eval("CsQty") %></td>
                                                   <%-- <td><%#Eval("LooseQty") %></td>--%>
                                                    <td><%#Eval("LoadType") %></td>
                                                                                                      
                                                    <td><%#Eval("Remark") %></td>
                                                    <td style="text-align: left;">

                                                        <div class="isEditVisible" style="display: inline;">
                                                            <asp:LinkButton ID="lnkEdit" runat="server" Style="padding: 1px 6px; font-size: 11px;" CssClass="btn btn-small btn-primary rolese" aria-label="Edit" rel="lightbox" CommandName="Edit" CommandArgument='<%#Eval("ID") %>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                                        </div>
                                                        <div class="isDelVisible" style="display: inline;">
                                                            <asp:LinkButton ID="lnkDelete" runat="server" Style="padding: 1px 6px; font-size: 11px;" OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" CommandName="Delete" CssClass="btn btn-small btn-danger"
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
                    </div>
                </div>

                <div class="box-body">


                    <div class="col-md-12" style="text-align: center;">
                        <div class="box-footer">

                            <asp:Button ID="btnSaveExit" runat="server" CssClass="btn btn-primary" Text="Save & Exit"
                                OnClick="btnSaveExit_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-success" CausesValidation="false"
                                Text="Back To List" OnClick="btnCancel_Click" />

                        </div>
                    </div>

                </div>
    
            
        </section>

        <script src="../content/bootstrap/js/bootstrap.min.js"></script>
        <script src="../content/plugins/datatables/jquery.dataTables.min.js"></script>
        <script src="../content/plugins/datatables/dataTables.bootstrap.min.js"></script>
        <!-- SlimScroll -->
        <script src="../content/plugins/slimScroll/jquery.slimscroll.js"></script>
        <!-- FastClick -->
        <script src="../content/plugins/fastclick/fastclick.js"></script>
        <script src="../content/plugins/select2/select2.full.js"></script>
        <script src="../content/dist/MenuScript.js"></script>
        <script src="../content/bootstrap/sweetalert.js"></script>
        <script src="../content/plugins/highslide/highslide-full.js"></script>
        <!-- AdminLTE App -->
        <script src="../content/dist/js/app.js"></script>
        <script src="../content/plugins/datepicker/bootstrap-datepicker.js"></script>
        <script src="../content/plugins/Toster/jquery.toaster.js"></script>
        <script type="text/javascript">
            $(window).load(function () {
                $(".se-pre-con").fadeOut("slow");;
            });
            $(window).scroll(function () {
                if ($(window).scrollTop() > 200) {
                    $("#back-top").fadeIn(200)
                } else {
                    $("#back-top").fadeOut(200)
                }
            });
            $("#back-top").click(function () {
                $("html, body").stop().animate({
                    scrollTop: 0
                }, "easeInOutExpo")
            });
            $('.select2').select2();
            hs.graphicsDir = '/Admin/plugins/highslide/graphics/';
            hs.wrapperClassName = 'draggable-header';
            hs.outlineType = 'rounded-white';
            hs.align = 'center';
            hs.dimmingOpacity = 0.75;
            hs.Expander.prototype.onAfterClose = function () {
                window.location.reload();
            };
            $('.Hs').click(function () {
                return hs.htmlExpand(this, { objectType: 'iframe' })
            });
        </script>
        <script type="text/javascript">  
            var specialKeys = new Array();
            specialKeys.push(8);
            function IsNumeric(e, i) {
                debugger
                var keyCode = e.which ? e.which : e.keyCode
                var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
                document.getElementsByClassName("numerror")[i].style.display = ret ? "none" : "inline";
                return ret;
            }
            function IsDecimal(e, i) {
                debugger
                var keyCode = e.which ? e.which : e.keyCode
                var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1 || keyCode == 46 || keyCode == 8);
                document.getElementsByClassName('error')[i].style.display = ret ? "none" : "inline";
                return ret;
            }

        </script>
        <script type="text/javascript"> 
            $('.datepicker').datepicker({
                format: 'dd/mm/yyyy',
                timePicker: true,
                todayHighlight: true,
                autoclose: true,
                //  endDate: new Date(),
            });
        </script>
  <script>
      function handleDropDownChange() {
          var textBox = document.getElementById('<%= txtCsQty.ClientID %>');
          textBox.focus();
          textBox.setSelectionRange(textBox.value.length, textBox.value.length);
      }
  </script>
            <script>
                function disableAutocomplete() {
                    var textboxes = document.getElementsByClassName('no-autocomplete');
                    for (var i = 0; i < textboxes.length; i++) {
                        textboxes[i].setAttribute("autocomplete", "off");
                    }
                }
            </script>
        <script type="text/javascript">
            function adjustDropDownPosition(dropdown) {
                var dropdownRect = dropdown.getBoundingClientRect();
                var windowHeight = window.innerHeight;

                if ((dropdownRect.top + dropdownRect.height) > windowHeight) {
                    dropdown.style.top = (windowHeight - dropdownRect.height) + 'px';
                } else {
                    dropdown.style.top = '';
                }
            }

            // Add event listeners for each dropdown with the "dropdown-adjust" class
            document.addEventListener('DOMContentLoaded', function () {
                var dropdowns = document.querySelectorAll('.dropdown-adjust');
                dropdowns.forEach(function (dropdown) {
                    dropdown.addEventListener('change', function () {
                        adjustDropDownPosition(dropdown);
                    });
                });
            });
        </script>


    </form>

</body>
<uc1:DTJS runat="server" ID="DTJS" />
</html>
