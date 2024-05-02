<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
* {
  box-sizing: border-box;
}

/* Add a gray background color with some padding */
.body1 {
  font-family: Arial;
  padding: 20px;
 
}

/* Header/Blog Title */
.header {
  padding: 30px;
  font-size: 40px;
  text-align: center;
  background: white;
}

/* Create two unequal columns that floats next to each other */
/* Left column */
.leftcolumn {   
  float: left;
  width: 75%;
}

/* Right column */
.rightcolumn {
  float: left;
  width: 25%;
  padding-left: 20px;
}

/* Fake image */
.fakeimg {
  background-color: #aaa;
  width: 100%;
  padding: 20px;
}

/* Add a card effect for articles */
.card {
   background-color: white;
   padding: 20px;
   margin-top: 20px;
}

/* Clear floats after the columns */
.row:after {
  content: "";
  display: table;
  clear: both;
}

/* Footer */
.footer {
  padding: 20px;
  text-align: center;
  background: #ddd;
  margin-top: 20px;
}

/* Responsive layout - when the screen is less than 800px wide, make the two columns stack on top of each other instead of next to each other */
@media screen and (max-width: 800px) {
  .leftcolumn, .rightcolumn {   
    width: 100%;
    padding: 0;
  }
}
	 
</style>
<style>
	
	
	
.card1 {
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
  max-width: 700px;
  margin: auto;
  text-align: center;
  font-family: arial;
}

.title {
  color: grey;
  font-size: 18px;
}

.button1 {
  border: none;
  outline: 0;
  display: inline-block;
  padding: 8px;
  color: white;
  background-color: #786D5F;
  text-align: center;
  cursor: pointer;
  width: 40%;
  font-size: 18px;
}



button:hover, a:hover {
  opacity: 0.7;
}
</style>
	
	<style>
		
		
		
		
		* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}



.container {
  height: 100%;
  width: 100%;
}

.p {
  position: absolute;
  font-size: 2rem;
  font-family: sans-serif;
  font-weight: bold;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  white-space: nowrap;
}

@media only screen and (min-width: 500px) {
  .p {
    font-size: 3rem;
  }
}

@media only screen and (min-width: 700px) {
  .p {
    font-size: 5rem;
  }
}

.p1 {
  text-shadow: 1px 1px 1px black, -1px -1px 1px black;
  color: cyan;
}

.p2 {
  color: red;
  clip-path: polygon(0 0, 100% 0, 100% 100%, 0% 100%);
  animation: text-animation 3s ease-in-out forwards alternate infinite;
  text-shadow: 1px 1px 1px black, -1px -1px 1px black;
}

.p3 {
  height: 20%;
  color: transparent;
}

@keyframes text-animation {
  from {
    clip-path: polygon(0 0, 100% 0, 100% 100%, 0% 100%);
  }
  to {
    clip-path: polygon(0 0, 0% 1%, 0% 100%, 0% 100%);
  }
}

.cursor {
  position: absolute;
  top: 50%;
  height: 100%;
  width: 100%;
  transform: translate(0, -50%);
  border-right: 2px solid red;
  animation: cursor-animation 3s ease-in-out forwards alternate infinite;
}

@keyframes cursor-animation {
  from {
    width: 100%;
  }
  to {
    width: 0;
  }
}


	</style>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="body1">
    <div class="row">
  <div class="leftcolumn">
    <div class="card">   
		<div class="input-group"> 
        <%--      <asp:DropDownList ID="drpUser" runat="server" CssClass="form-control select2"  AutoPostBack="true">
                                </asp:DropDownList> --%>
			<asp:TextBox ID="TextBox1"  class="form-control" OnTextChanged="TextBox1_TextChanged" placeholder="search..........." runat="server"> </asp:TextBox>
			
			 <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TextBox1" Enabled="true" EnableCaching="false" CompletionInterval="100" CompletionSetCount ="2" MinimumPrefixLength="1" ServiceMethod="GetItemList" ></ajaxToolkit:AutoCompleteExtender>
              <span class="input-group-btn">
                <button type="submit" name="search" style="background-color:powderblue;" id="search-btn" class="btn btn-flat"><i class="fa fa-search"></i>
                </button>
              </span>
        
                </div>
 
                           <h2>New Post</h2>
                      
         <asp:Repeater ID="Repeater1" runat="server">
                 <ItemTemplate>
        <div style="float: left; padding:10px;">            
				<div class="row">
					<div class="col-md-4 col-sm-6 col-xs-12">
						 <a href="view.aspx?eoid=<%#Eval("id") %>&<%# Eval("Title").ToString().Replace(" ", "-") %>">
			   <asp:Image ID="Image1" runat="server"  ImageUrl='<%# "Uploads/" & Eval("Image1")%>' Height="200" Width="100%"   />
						</a>
				</div>
					<div class="col-md-8 col-sm-6 col-xs-12">
						<h1 style="font-family: 'Arial Black'; font-size: medium"><b><%# Eval("Title")%></b>                        
					                            </h1>
						<asp:Label ID="Label6" runat="server" style="color:red;" Text='<%#Convert.ToDateTime (Eval("Date")).ToString("dd/MM/yyyy") %>'></asp:Label> <br>
				<small> <%# Eval("descr")%></small>
						
               <br />
				 <asp:Label ID="Label9" runat="server" Text='<%# Eval("content")%>' Visible="False"></asp:Label>
          <asp:Label ID="Label5" runat="server" Text='<%# Eval("id")%>' Visible="False"></asp:Label>                                     
						
						<a href="view.aspx?eoid=<%#Eval("id") %>&<%# Eval("title").ToString().Replace(" ", "-").ToLower() %>" class="button1">Read More</a>					
						<br>
						
        
				</div>
				</div>
                                                                  
          </div> 
          
 </ItemTemplate>
            </asp:Repeater>
	  </div></div>
              <div class="rightcolumn">
    <div class="card">
      <h2>Tranding</h2>
                      <asp:DataList ID="DataList1" runat="server">
                          <ItemTemplate>
							  
                    <a href="view.aspx?eoid=<%#Eval("id") %>&<%# Eval("title").ToString().Replace(" ", "-") %>">
			   <asp:Image ID="Image1" runat="server"  ImageUrl='<%# "Uploads/" & Eval("Image1")%>' Height="50px" Width="50px"   />
						</a>
                     <asp:LinkButton ID="LinkButton1"  runat="server" Text='<%# Eval("title") %>'></asp:LinkButton>                 
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("id")%>' Visible="False"></asp:Label>                                                      <hr>
                          </ItemTemplate>
                      </asp:DataList>                                        
                      


              </div> 
				   <div class="card">
					   <!-- attra2 -->

				  </div>
				     <div class="card">
      <h2>Tags</h2>
                <p> </p>

              </div> 
            </div>
          </div>
		  </div>
</asp:Content>

