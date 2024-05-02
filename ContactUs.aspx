<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--  PAGE HEADING -->

    <section class="page-header" data-stellar-background-ratio="0.1">

        <div class="container">

            <div class="row">

                <div class="col-sm-12 text-center">


                    <h3>Contact Us
                    </h3>

                    <p class="page-breadcrumb">
                        <a href="defaut.aspx">Home</a> / Contact
                     
                    </p>


                </div>

            </div>
            <!-- end .row  -->

        </div>
        <!-- end .container  -->

    </section>
    <!-- end .page-header  -->


    <section class="section-content-block section-contact-block">

        <div class="container">

            <div class="row">

                <div class="col-sm-6 wow fadeInLeft">

                    <div class="contact-form-block">

                        <h2 class="contact-title">Say hello to us</h2>
                        <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard </p>

                        <div class="form-group">
                            <input type="text" runat="server" class="form-control" id="user_name" name="user_name" placeholder="Name" data-msg="Please Write Your Name" />
                        </div>

                        <div class="form-group">
                            <input type="text" runat="server" class="form-control" id="user_email" name="user_email" placeholder="Email" data-msg="Please Write Your Valid Email" />
                        </div>
                        <div class="form-group">
                            <input type="text" runat="server" class="form-control" id="user_Phone" name="user_Phone" placeholder="Phone No" data-msg="Please Write Your Phone No" onkeypress="return IsNumericKey(event);" />
                        </div>
                        <div class="form-group">
                            <input type="text" runat="server" class="form-control" id="email_subject" name="email_subject" placeholder="Subject" data-msg="Please Write Your Message Subject" />
                        </div>

                        <div class="form-group">
                            <textarea class="form-control" runat="server" rows="5" name="email_message" id="email_message" placeholder="Message" data-msg="Please Write Your Message"></textarea>
                        </div>

                        <div class="form-group">
                            <asp:Button ID="btnEnquiry" runat="server" CssClass="btn btn-custom" OnClick="btnEnquiry_Click" Text="Send Now" />
                        </div>

                    </div>
                    <!-- end .contact-form-block  -->

                </div>
                <!--  end col-sm-6  -->

                <div class="col-sm-6 wow fadeInRight">

                    <div class="col-md-12">
                        <h2 class="contact-title">Contact us</h2>
                        <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard </p>
                    </div>

                    <div class="col-md-12">

                        <ul class="contact-info">
                            <li>
                                <span class="icon-container"><i class="fa fa-home"></i></span>
                                <address>
                                    Bulldog House, Reading Road, Wokingham, Berkshire,
                                    <br />
                                    RG41 5AB
                                </address>
                            </li>

                            <li>
                                <span class="icon-container"><i class="fa fa-phone"></i></span>
                                <address><a href="#">+012 345 67890</a></address>
                            </li>

                            <li>
                                <span class="icon-container"><i class="fa fa-envelope"></i></span>
                                <address><a href="mailto:">info@the-whf.com</a></address>
                            </li>

                            <li>
                                <span class="icon-container"><i class="fa fa-globe"></i></span>
                                <address><a href="#">www.ngotrident.jeetart.com/</a></address>
                            </li>

                        </ul>

                    </div>

                </div>
                <!--  end col-sm-6  -->

            </div>
            <!-- end row  -->

        </div>
        <!--  end .container -->

    </section>
    <!-- end .section-content-block  -->



    <!--  MAIN CONTENT  -->
    <section class="section-contact-block">

        <div class="row">

            <div class="col-md-12">

                <div class="section-google-map-block wow fadeInUp">

                    <%--<div id="map_canvas"></div>--%>
                    <iframe class=""
                        src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2487.8475886391184!2d-0.8692503243489368!3d51.42422631677731!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x487683f69bf78aef%3A0x215ec1de4ab276e1!2sBulldog%20House%2C%20Reading%20Rd%2C%20Winnersh%2C%20Wokingham%20RG41%205AB%2C%20UK!5e0!3m2!1sen!2sin!4v1707990856692!5m2!1sen!2sin"
                        frameborder="0" style="min-height: 400px; width: 100%; border: 0;" allowfullscreen="" aria-hidden="false"
                        tabindex="0"></iframe>

                </div>
                <!-- end .section-content-block  -->

            </div>

        </div>

    </section>

</asp:Content>

