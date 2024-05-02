<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" c AutoEventWireup="true" CodeFile="newsupload.aspx.cs" Inherits="Admin_newsupload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	 <script src="https://cdn.ckeditor.com/4.16.2/standard/ckeditor.js"></script>
	


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">
    <section class="content-header">
        <h1>Upload  Blog
        </h1>
        <ol class="breadcrumb">
            <li><a href="/Admin/Dashboard.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
             <li><a href="#">Master</a></li>
            <li><a href="/Admin/Ads.aspx" class="active">Upload  Blog </a></li>
        </ol>
    </section>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <section class="content">
        <div class="row">
            <div class="col-md-12">
                <div style="text-align:right">
                     <asp:Button ID="Btnsave" runat="server" onclick="Btnsave_Click"  Style="margin-top: 10px;" CssClass="btn btn-primary"
                            Text="Submit"  />
                        <asp:Button ID="Button2" runat="server" Style="margin-top: 10px;" CssClass="btn btn-danger"
                            Text="Back to list" onclick="Button2_Click" />
                        <div class="clearfix">&nbsp;</div>
                </div>
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <div class="col-md-4">
                                <label> Category</label>
                            
                                <asp:DropDownList ID="Drpcate" width="100%" height="38px" runat="server">
									    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
    <asp:ListItem Text="DIY Tech" Value="DIY-Tech"></asp:ListItem>
    <asp:ListItem Text="Fitness Fun" Value="Fitness-Fun"></asp:ListItem>
    <asp:ListItem Text="Dreamy Destination " Value="Dreamy Destination"></asp:ListItem>
		<asp:ListItem Text="Travel Tales" Value="Travel-Tales"></asp:ListItem>
    
    <asp:ListItem Text="Bookworm Corner" Value="Bookworm-Corner"></asp:ListItem>
	 <asp:ListItem Text="Pet Pal" Value="Pet-Pal"></asp:ListItem>
									<asp:ListItem Text="Cooking Quest" Value="Cooking-Quest"></asp:ListItem>
									<asp:ListItem Text="STEAM Learning Adventures" Value="STEAM-Learning-Adventures"></asp:ListItem>
</asp:DropDownList>



                                </div><div class="clearfix">&nbsp;</div>
                            <div class="col-md-4">
                                <label> Upload Image</label>                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                    Font-Bold="true" ForeColor="Red" Font-Size="Large" ControlToValidate="FileUpload1"></asp:RequiredFieldValidator>
                                        <asp:FileUpload ID="FileUpload1"  runat="server" />
								 <asp:Label ID="Label1" runat="server" Text=""></asp:Label><asp:Button ID="Button1" CssClass="btn btn-wrong" OnClick="Button1_Click" runat="server" Text="X" />
                            </div>
                            <br />
                             
                            <div class="clearfix">&nbsp;</div>
                            <div class="col-md-12">
                                <label> Title </label> 
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    Font-Bold="true" ForeColor="Red" Font-Size="Large" ControlToValidate="Txttitle"></asp:RequiredFieldValidator>
                             <asp:TextBox ID="Txttitle" Height="50px" Width="100%" placeholder="Write Blog title"   runat="server"></asp:TextBox>  
                        </div>
                                 <div class="col-md-12">
                                <label> Short Description </label> 
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    Font-Bold="true" ForeColor="Red" Font-Size="Large" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                             <asp:TextBox ID="TextBox1" Height="100px" Width="100%" textmode="MultiLine" placeholder="Write Blog description"   runat="server"></asp:TextBox>  
                        </div>
							
							<div class="col-md-12">
                                <label>Keywords </label> 
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*"
                                    Font-Bold="true" ForeColor="Red" Font-Size="Large" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                             <asp:TextBox ID="TextBox3" Height="80px" Width="100%" textmode="MultiLine" placeholder="Write Blog keywords"   runat="server"></asp:TextBox>  
                        </div>
							
                            <div class="clearfix">&nbsp;</div>
                            <div class="col-md-12">
                                <label> Content</label> 
                          
                    <asp:TextBox ID="ckeditorTextbox" runat="server"  TextMode="MultiLine" Rows="10" Columns="80" placeholder="Enter your article here..."></asp:TextBox>
<script>
    CKEDITOR.replace('<%= ckeditorTextbox.ClientID %>', {
        // CKEditor configuration options, if needed
    });
</script>
    
         
           

						
		

           
            
                                </div>


                        
                        <div class="clearfix">&nbsp;</div>
                    </div>
                </div>
            </div>
            </div></div>
        </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" Runat="Server">
	
</asp:Content>

