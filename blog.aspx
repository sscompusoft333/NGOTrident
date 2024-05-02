<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="blog.aspx.cs" Inherits="blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section class="page-header" data-stellar-background-ratio="0.1">

        <div class="container">

            <div class="row">

                <div class="col-sm-12 text-center">


                    <h3>Blog Posts
                    </h3>

                    <p class="page-breadcrumb">
                        <a href="#">Home</a> / Blog
                    </p>


                </div>

            </div>
            <!-- end .row  -->

        </div>
        <!-- end .container  -->

    </section>
    <!-- end .page-header  -->

    <!--  MAIN CONTENT  -->

    <section class="main-content">

        <div class="container">

            <div class="row">

                <div class="col-md-8 col-sm-12">
                    <asp:Repeater ID="rpt" runat="server">
                        <ItemTemplate>
                            <article class="post single-post">

                                <div class="single-post-content">

                                    <a title="" href="#">
                                        <img alt="" src='<%# "images/"+Eval("image1") %>' />
                                    </a>

                                </div>
                                <!-- end .bd-view  -->

                                <div class="single-post-title">

                                    <h2>
                                        <a href='<%#Eval("SEO_Friendly_URL") %>'><%#Eval("Title") %>
                                        </a>
                                    </h2>
                                    <!--  end blog-post-title  -->

                                    <p class="single-post-meta">

                                        <%--                                    <i class="fa fa-user"></i>
                                    &nbsp;Deborah Beck

                                    &nbsp;<i class="fa fa-book"></i>
                                    &nbsp;<a title="View all posts" href="#"> Repair </a>&nbsp;--%>

                                        <i class="fa fa-calendar"></i>
                                        &nbsp;<%#Eval("Date") %>

                                    </p>

                                    <%#Eval("content") %>


                                </div>
                                <!-- end col-sm-8  -->

                            </article>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%--<article class="post single-post">

                        <div class="single-post-content">

                            <a title="" href="#">
                                <img alt="" src="images/blog_2.jpg" />
                            </a>

                        </div>
                        <!-- end .bd-view  -->

                        <div class="single-post-title">

                            <h2>
                                <a href="#">The innovative organisation – promoting a culture of creativity
                                </a>
                            </h2>
                            <!--  end blog-post-title  -->

                            <p class="single-post-meta">

                                <i class="fa fa-user"></i>
                                &nbsp;Deborah Beck

                                    &nbsp;<i class="fa fa-book"></i>
                                &nbsp;<a title="View all posts" href="#"> Bicycle </a>

                                &nbsp;<i class="fa fa-calendar"></i>
                                &nbsp;January 19, 2016

                            </p>

                            <p>
                                Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullam corper. ipsum dolor sit amet diam brute integre eapri per fugitzril apeirian cumea. 
                            </p>


                        </div>
                        <!-- end col-sm-8  -->

                    </article>

                    <article class="post single-post">

                        <div class="single-post-content">

                            <a title="" href="#">
                                <img alt="" src="images/blog_3.jpg" />
                            </a>

                        </div>
                        <!-- end .bd-view  -->

                        <div class="single-post-title">

                            <h2>
                                <a href="#">Communicating your charity’s impact
                                </a>
                            </h2>
                            <!--  end blog-post-title  -->

                            <p class="single-post-meta">

                                <i class="fa fa-user"></i>
                                &nbsp;Deborah Beck

                                    &nbsp;<i class="fa fa-book"></i>
                                &nbsp;<a title="View all posts" href="#"> Bike Ride </a>

                                &nbsp;<i class="fa fa-calendar"></i>
                                &nbsp;January 19, 2016

                            </p>

                            <p>
                                wheel spokes go into a hole in the hub flange and held there by a head. Spokes usually have a 90 degree bend at the head-end but some hubs are designed for straight spokes. If you are replacing a spoke it needs to match the others in shape and length.      
                            </p>


                        </div>
                        <!-- end col-sm-8  -->

                    </article>
--%>

                    <div class="blog-pagination text-center clearfix">

                        <ul class="pagination">

                            <li><a href="#" class="prev page-numbers"><i class="fa fa-caret-left"></i></a></li>
                            <li><a href="#" class="page-numbers">1</a></li>
                            <li><a href="#" class="page-numbers current">2</a></li>
                            <li><a href="#" class="page-numbers">3</a></li>
                            <li><a href="#" class="next page-numbers"><i class="fa fa-caret-right"></i></a></li>

                        </ul>
                        <!-- end pagination  -->

                    </div>
                    <!--  end blog-pagination -->

                </div>
                <!--  end col-sm-8 -->


                <div class="col-md-4 col-sm-12">

                    <div class="widget site-sidebar">

                        <h2 class="widget-title">Search</h2>

                        <form action="index.html" id="search-form" class="search-form" role="form" method="get">

                            <div class="input-group">
                                <input type="text" class="form-control" placeholder="Search....">
                                <span class="input-group-addon"><i class="fa fa-search"></i></span>
                            </div>

                            <input type="hidden" value="submit" />

                        </form>
                        <!-- end #search-form  -->

                    </div>
                    <!--  end .widget -->


                    <div class="widget site-sidebar">

                        <h2 class="widget-title">Categories</h2>

                        <ul class="widget-post-category clearfix">
                            <li>
                                <a title="View all posts filed under Environment" href="#">Child Education</a>
                                <span class="pull-right badge">42</span>
                            </li>
                            <li>
                                <a title="View all posts filed under Technology" href="#">Happy Family</a>
                                <span class="pull-right badge">40</span>
                            </li>
                            <li>
                                <a title="View all posts filed under Health" href="#">Helpless Shelter</a>
                                <span class="pull-right badge">32</span>
                            </li>
                            <li>
                                <a title="View all posts filed under Disaster" href="#">Fundraising </a>
                                <span class="pull-right badge">26</span>
                            </li>
                            <li>
                                <a title="View all posts filed under Environment Right" href="#">Direct Donation</a>
                                <span class="pull-right badge">18</span>
                            </li>
                            <li>
                                <a title="View all posts filed under Education" href="#">Join Now</a>
                                <span class="pull-right badge">12</span>
                            </li>
                        </ul>

                    </div>
                    <!--  end .widget -->

                    <div class="widget site-sidebar">

                        <h2 class="widget-title">Recent Posts</h2>

                        <div class="single-recent-post">
                            <a href="#">Zomato Commits to Making Food Delivery</a>
                            <span><i class="fa fa-calendar"></i>&nbsp; April 19, 2017</span>
                        </div>

                        <div class="single-recent-post">
                            <a href="#">Make Kalam's House A Knowledge Centre</a>
                            <span><i class="fa fa-calendar"></i>&nbsp; April 18, 2017</span>
                        </div>

                        <div class="single-recent-post">
                            <a href="#">Central Government Retracts Proposal</a>
                            <span><i class="fa fa-calendar"></i>&nbsp; April 17, 2017</span>
                        </div>

                    </div>
                    <!--  end .widget -->

                    <div class="widget site-sidebar">

                        <h2 class="widget-title">Tags</h2>

                        <ul class="widget-recent-tags clearfix">

                            <li>
                                <a href="" title="">claycold</a>
                            </li>

                            <li>
                                <a href="" title="">crushing</a>
                            </li>

                            <li>
                                <a href="" title="">chattels</a>
                            </li>

                            <li>
                                <a href="" title="">dinarchy</a>
                            </li>

                            <li>
                                <a href="" title="">cienaga</a>
                            </li>

                            <li>
                                <a href="" title="">doolie</a>
                            </li>

                        </ul>
                        <!--  end .widget-recent-tags -->

                    </div>
                    <!--  end .widget -->

                </div>
                <!-- end .col-sm-4  -->

            </div>
            <!--  end row  -->

        </div>
        <!--  end container -->

    </section>
    <!-- end .main-content  -->


</asp:Content>

