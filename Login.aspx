<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
    <link href="/content/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="/content/dist/css/ace.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
    <link href="/content/plugins/bootstrap-toastr/toastr.css" rel="stylesheet" />
</head>
<body class="login-layout">
    <form id="form1" runat="server">

        <div class="main-container">
            <div class="main-content">
                <div class="row">
                    <div class="col-sm-10 col-sm-offset-1">
                        <div class="login-container">
                            <div class="center">
                                <h1>
                                    <span class="red">Admin Login</span>
                                </h1>
                                <h4 class="blue" id="id-company-text">&copy;Jeetart.com</h4>
                            </div>

                            <div class="space-6"></div>

                            <div class="position-relative">
                                <div id="loginbox" runat="server" class="login-box visible widget-box no-border">
                                    <div class="widget-body">
                                        <div class="widget-main">
                                            <h4 class="header blue lighter bigger">
                                                <i class="ace-icon fa fa-leaf green"></i>
                                                Please Enter Your Information
                                            </h4>

                                            <div class="space-6"></div>
                                            <fieldset>
                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <input type="text" id="txtuser" runat="server" class="form-control" placeholder="Enter your registered User Name" />
                                                        <i class="ace-icon fa fa-user"></i>
                                                    </span>
                                                    <span>
                                                        <asp:RequiredFieldValidator ID="Txtuser_V" runat="server" ControlToValidate="txtuser" ForeColor="IndianRed" ErrorMessage="Required" ValidationGroup="Log_G" SetFocusOnError="true"></asp:RequiredFieldValidator></span>
                                                </label>

                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">

                                                        <input type="password" id="txtpass" runat="server" class="form-control pass" placeholder="Password" />
                                                        <span class="ace-icon view-password"><i class="fa fa-eye"></i></span>
                                                        <%--   <i class="ace-icon fa fa-lock" ></i>--%>
                                                    </span>
                                                    <span>
                                                        <asp:RequiredFieldValidator ID="TxtPass_V" runat="server" ControlToValidate="txtpass" ForeColor="IndianRed" ErrorMessage="Required" ValidationGroup="Log_G" SetFocusOnError="true"></asp:RequiredFieldValidator></span>
                                                </label>

                                                <div class="clearfix">
                                                    <asp:Label ID="lblMes" runat="server" Style="color: red" Visible="false">Invalid User Name & Password.</asp:Label>
                                            <asp:Button ID="LogBtn" runat="server" OnClick="LogBtn_Click" ValidationGroup="Log_G" CssClass="width-35 pull-right btn btn-sm btn-primary" Text="Login" />
                                                </div>
                                            </fieldset>
                                        </div>
                                        <!-- /.widget-main -->

                                        <div class="toolbar clearfix text-center">
                                            <div style="float: none; text-align: center;">
                                                <a href="#" data-target="#forgotbox" class="forgot-password-link">
                                                    <i class="ace-icon fa fa-arrow-left"></i>
                                                    Change password
                                                </a>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                                <div id="changebox" runat="server"  class="change-box widget-box no-border">
                                    <div class="widget-body">
                                        <div class="widget-main">
                                            <h4 class="header blue lighter bigger">
                                                <i class="ace-icon fa fa-leaf green"></i>
                                                Please Enter New password
                                            </h4>

                                            <div class="space-6"></div>
                                            <fieldset>
                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <input type="password" id="txtpwd" runat="server" class="form-control" placeholder="Enter New Password" />
                                                        <i class="ace-icon fa fa-key"></i>
                                                    </span>
                                                    <span>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtuser" ForeColor="IndianRed" ErrorMessage="Required" ValidationGroup="Log_G" SetFocusOnError="true"></asp:RequiredFieldValidator></span>
                                                </label>

                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">

                                                        <input type="password" id="Password1" runat="server" class="form-control pass" placeholder="Password" />
                                                        <span class="ace-icon view-password"><i class="fa fa-eye"></i></span>
                                                        <%--   <i class="ace-icon fa fa-lock" ></i>--%>
                                                    </span>
                                                    <span>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpass" ForeColor="IndianRed" ErrorMessage="Required" ValidationGroup="Log_G" SetFocusOnError="true"></asp:RequiredFieldValidator></span>
                                                </label>

                                                <div class="clearfix">
                                                    <asp:Label ID="Label1" runat="server" Style="color: red" Visible="false">Invalid User Name & Password.</asp:Label>
                                                    <asp:LinkButton ID="btnChange" runat="server"   ValidationGroup="Log_G" CssClass="width-35 pull-right btn btn-sm btn-primary">
                                                           <i class="ace-icon fa fa-key"></i>
															<span class="bigger-110">Login</span>
                                                    </asp:LinkButton>
                                                </div>
                                            </fieldset>
                                        </div>
                                        <!-- /.widget-main -->

                                        <div class="toolbar clearfix text-center">
                                            <div style="float: none; text-align: center;">
                                                <a href="#" data-target="#forgotbox" class="forgot-password-link">
                                                    <i class="ace-icon fa fa-arrow-left"></i>
                                                    Change password
                                                </a>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                                <div id="forgotbox" runat="server" class="forgot-box widget-box no-border">
                                    <div class="widget-body">
                                        <div class="widget-main">
                                            <h4 class="header red lighter bigger">
                                                <i class="ace-icon fa fa-key"></i>
                                                Set New Password
                                            </h4>

                                            <div class="space-6"></div>
                                            <p>
                                                Enter your Code
                                            </p>
                                            <fieldset>
                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <asp:TextBox ID="txtcode" runat="server" class="form-control"></asp:TextBox>
                                                        <i class="ace-icon fa fa-key"></i>
                                                    </span>
                                                </label>

                                                <div class="clearfix">
                                                    <asp:Button ID="btnChangePwd" runat="server" CssClass="width-35 pull-right btn btn-sm btn-danger ace-icon fa fa-lightbulb-o" Text="click!" OnClick="btnChangePwd_Click">
                                                        <%-- <i class="ace-icon fa fa-lightbulb-o"></i>
                                                        <span class="bigger-110">click!</span>--%>
                                                    </asp:Button>
                                                </div>
                                            </fieldset>
                                        </div>
                                        <!-- /.widget-main -->

                                        <div class="toolbar center">
                                            <a href="#" data-target="#loginbox" class="back-to-login-link">Back to login
												<i class="ace-icon fa fa-arrow-right"></i>
                                            </a>
                                        </div>
                                    </div>
                                    <!-- /.widget-body -->
                                </div>
                                <!-- /.forgot-box -->
                            </div>
                            <!-- /.position-relative -->

                            <div class="navbar-fixed-top align-right">
                                <br />
                                &nbsp;
								<a id="btn-login-dark" href="#">Dark</a>
                                &nbsp;
								<span class="blue">/</span>
                                &nbsp;
								<a id="btn-login-blur" href="#">Blur</a>
                                &nbsp;
								<span class="blue">/</span>
                                &nbsp;
								<a id="btn-login-light" href="#">Light</a>
                                &nbsp; &nbsp; &nbsp;
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script src="/content/plugins/jQuery/jquery.js"></script>
        <script src="/content/plugins/bootstrap-toastr/toastr.js"></script>
        <script type="text/javascript"> 
            if ('ontouchstart' in document.documentElement) document.write("<script src='content/dist/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
        </script>
        <!-- inline scripts related to this page -->
        <script type="text/javascript">
            jQuery(function ($) {
                $(document).on('click', '.toolbar a[data-target]', function (e) {
                    e.preventDefault();
                    var target = $(this).data('target');
                    $('.widget-box.visible').removeClass('visible');//hide others
                    $(target).addClass('visible');//show target
                });
            });
            //you don't need this, just used for changing background
            jQuery(function ($) {
                $('#btn-login-dark').on('click', function (e) {
                    $('body').attr('class', 'login-layout');
                    $('#id-text2').attr('class', 'white');
                    $('#id-company-text').attr('class', 'blue');

                    e.preventDefault();
                });
                $('#btn-login-light').on('click', function (e) {
                    $('body').attr('class', 'login-layout light-login');
                    $('#id-text2').attr('class', 'grey');
                    $('#id-company-text').attr('class', 'blue');

                    e.preventDefault();
                });
                $('#btn-login-blur').on('click', function (e) {
                    $('body').attr('class', 'login-layout blur-login');
                    $('#id-text2').attr('class', 'white');
                    $('#id-company-text').attr('class', 'light-blue');
                    e.preventDefault();
                });
            });
        </script>

        <script type='text/javascript'>
            function Pass() {
                debugger
                if ($('txtpass').attr('type', 'text'));
                $('txtpass').attr('type', 'text')
            }
            $('.view-password').on('click', function () {
                let input = $(this).parent().find(".pass");
                input.attr('type', input.attr('type') === 'password' ? 'text' : 'password');
            });
            $(document).ready(function () {
                $('#check').click(function () {
                    if ($('txtpass').attr('type', 'text'));
                });
            });
        </script>
    </form>
</body>
</html>
