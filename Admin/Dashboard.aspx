<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Admin_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <style>
        #Body_linkloc {
            color: whitesmoke;
        }

            #Body_linkloc:hover {
                color: white;
            }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>Dashboard
            <small>Over Views</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active"><a href="#">Dashboard</a></li>
        </ol>
       <%-- <div class="small-box bg-aqua">
            &nbsp; <i class="fa fa-map-marker"></i>&nbsp;
                  <p id="demo" style="display: inline;"></p>
            <asp:HiddenField ID="hddLnL" runat="server"/>
            <p class="small-box-footer">
                <a id="linkloc" runat="server" href="javascript:;" class="abc">CheckIN</a> <i class="fa fa-arrow-circle-up"></i>
            </p>
        </div>--%>
    </section>
    
    <!-- Main content -->



    <!-- small box -->



 

    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-lg-3 col-xs-6">
                <!-- small box -->
              
                <div class="small-box bg-purple">
                    <div class="inner">
                        <h4>Total Enquiry : <b id="Ttlenq" runat="server"></b></h4>
                        <p>&nbsp;<b id="Newttl" runat="server">&nbsp;</b></p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-person-add"></i>
                    </div>
                    <a href="Enquiry.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <%--<!-- ./col -->
            <div class="col-lg-3 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-green">
                    <div class="inner">
                        <h4>Total BOQ : <b id="Ttlboq" runat="server">12</b></h4>
                        <p>&nbsp; <b>&nbsp;</b></p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-stats-bars"></i>
                    </div>
                    <a href="Boq.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <!-- ./col -->
            <div class="col-lg-3 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-yellow">
                    <div class="inner">
                        <h4>Total Confirm
                        </h4>
                        <h4>Project : <b id="Ttlcnf" runat="server">5</b></h4>
                    </div>
                    <div class="icon">
                        <i class="ion-ios-checkmark"></i>
                    </div>
                    <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <!-- ./col -->
            <div class="col-lg-3 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-red">
                    <div class="inner">
                        <h4>Total Complete  </h4>

                        <h4>Project : <b id="Ttlcmp" runat="server">2</b></h4>
                    </div>
                    <div class="icon">
                        <i class="ion-android-done-all"></i>
                    </div>
                    <a href="BOQ.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>--%>
            <!-- ./col -->
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="Server">
<%--    <script type="text/javascript">  
        function getLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(showPosition);
            }
            else { document.getElementById("demo").innerHTML = "Geolocation is not supported by this browser."; }
        }


        function showPosition(position) {
          
            var latvalue = position.coords.latitude;
            var longvalue = position.coords.longitude;

            getcityname(latvalue, longvalue);

        }
    </script>
    <script type="text/javascript">  
        function getcityname(latvalue, longvalue) {
            debugger
            var geocoder;
            geocoder = new google.maps.Geocoder();
            var latlng = new google.maps.LatLng(latvalue, longvalue);
            document.getElementById("Body_hddLnL").value = latlng
          
            geocoder.geocode(
                { 'latLng': latlng },
                function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        if (results[0]) {
                            var add = results[0].formatted_address;
                            var value = add.split(",");

                            count = value.length;
                            var places = "";
                            for (var i = 0; i < count; i++) {
                                places = places + value[i];
                            }
                            
                            document.getElementById('demo').innerHTML = places;
                            country = value[count - 1];
                            state = value[count - 2];
                            city = value[count - 3];
                        }
                        else {
                           
                        }
                    }
                    else {
                        
                    }
                }
            );
        }
    </script>
    <script type="text/javascript"> 
        $("#Body_linkloc").click(function () {
            debugger
            if (document.getElementById('demo').innerHTML == "") {
                alert("This site has been blocked from accessing your location \n Please Turn on!!!");
                this.removeAttribute("class");
            } else {
               
                this.href = 'checkInOut.aspx?loc=' + document.getElementById('demo').innerHTML + '&lnl=' + document.getElementById("Body_hddLnL").value
                
            }
        });
    </script>--%>
</asp:Content>


