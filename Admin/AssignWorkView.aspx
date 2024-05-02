<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssignWorkView.aspx.cs" Inherits="Admin_AssignWorkView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
</head>
<body>
    <form id="form1" runat="server">
        <section class="content-header">
            <h1>Assign Work View
            </h1>

        </section>
        <section class="content">
            <div class="box box-primary">
                <div class="box-body">
                    <div class="widget-content nopadding" style="overflow: auto;">
                        <table id="example1" class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th style="text-align: left;">Sr No.
                                    </th>
                                    <th style="text-align: left;">Date
                                    </th> <th style="text-align: left;">Room
                                    </th>
                                    <th style="text-align: left;">Product
                                    </th>
                                    <th style="text-align: left;">Work Description
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="repWorkList" runat="server">
                                    <ItemTemplate>
                                        <tr class="gradeA">
                                            <td>
                                                <%#Container.ItemIndex+1 %>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblDate" runat="server" Text='<%#Eval("UDate") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblRoom" runat="server" Text='<%#Eval("Room") %>'></asp:Label>
                                            </td>  <td style="text-align: left;">
                                                <asp:Label ID="lblProd" runat="server" Text='<%#Eval("Product") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
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
    </form>
</body>
</html>
