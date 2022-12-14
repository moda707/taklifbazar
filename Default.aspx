<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>
<!DOCTYPE html>
<html lang="en">
	<head>
        <title>تکلیف بازار</title>
		
	<link href="css/full-slider.css" rel="stylesheet"/>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
	<meta charset="utf-8"/>
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>
	<link href="css/bootstrap.min.css" rel="stylesheet"/>
	<link href="rtl/css/bootstrap-rtl.min.css" rel="stylesheet"/>
    <link href="http://fonts.googleapis.com/earlyaccess/droidarabicnaskh.css" rel="stylesheet" />
    
    <script src="js/jquery.min.js"></script>       
	
	<script src="js/bootstrap.min.js"></script>
    <script src="js/MJScript.js"></script>
    <script src="js/docs.min.js"></script> 
    <script>
        $('.carousel').carousel({
            interval: 5000 //changes the speed
        })
	</script>
    

    
    <link href="css/Scrollbar.css" rel="stylesheet" />
	<link href="css/styles.css" rel="stylesheet"/>
	</head>

	<body>
        <div class="navbar navbar-inverse navbar-fixed-top" role="navigation" style="vertical-align:middle;">	
	        <div class="navbar-header">
		        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
		            <span class="sr-only">Toggle navigation</span>
		            <span class="icon-bar"></span>
		            <span class="icon-bar"></span>
		            <span class="icon-bar"></span>
		        </button>
		        <a class="navbar-brand" rel="home" href="Default.aspx">تکلیف بازار</a>
	        </div>		
		    <div class="collapse navbar-collapse pull-left">		
		        <ul class="nav navbar-nav">			
			        <li class="dropdown">
                      <a href="#" class="dropdown-toggle" data-toggle="dropdown">دسته بندی موضوعی <b class="caret"></b></a>
                      <ul class="dropdown-menu">
                        <li><a href="#">Action</a></li>
                        <li><a href="#">Another action</a></li>
                        <li class="divider"></li>
                        <li><a href="#">Separated link</a></li>
                        <li class="divider"></li>
                        <li><a href="#">One more separated link</a></li>
                      </ul>
                    </li>
                    <li class="dropdown" id="menuLogin">
                        <a class="dropdown-toggle" href="#" data-toggle="dropdown" id="navLogin">ورود <b class="caret"></b></a>
                        <div class="dropdown-menu pull-left fluid" style="padding:17px;">              
              	            <div class="form-group">
                                <input class="form-control" id="user_username" style="margin-bottom: 15px;" type="text" name="user[username]" size="30" />
                                <input class="form-control" id="user_password" style="margin-bottom: 15px;width:200px;" type="password" name="user[password]" size="30" />
                                <input id="user_remember_me" style="float: right; margin-right: 10px;" type="checkbox" name="user[remember_me]" value="1" />
                                <label class="optional" for="user_remember_me"> بخاطر بسپار </label>
  				                <br/>
                                <button type="button" id="btnLogin" class="btn" onclick="javascript: location.href='\UserPortal.aspx'">ورود</button>
                                <button type="button" id="btnSignup" class="btn" onclick="javascript: location.href='Register.aspx?=<% = Encryption.Encrypt("State=Form", SharedDataInfo.SecurityKey) %>'">عضویت</button>
                            </div>
                        </div>
                    </li>         
		        </ul>
	        </div>
	        <div class="col-sm-6 col-md-6" style="margin-top:8px;">
                <!--<div class="navbar-text">Text</div> -->		    
		        <div class="input-group" style="vertical-align:middle;">
			        <input type="text" class="form-control" id="srchterm" onkeyup="if (event.keyCode == 13) document.getElementById('btnSearch').click()" runat="server"/>                    
			        <div class="input-group-btn">
				        <button id="btnSearch" class="btn btn-default" type="button" onclick="javascript:DoSearch();"><i class="glyphicon glyphicon-search"></i></button>
			        </div>
		        </div>
		    </div>	
        </div>

    <div id="myCarousel" class="carousel slide" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
        <li data-target="#myCarousel" data-slide-to="1"></li>
        <li data-target="#myCarousel" data-slide-to="2"></li>
    </ol>

    <!-- Wrapper for Slides -->
    <div class="carousel-inner">
        <div class="item active">
            <!-- Set the first background image using inline CSS below. -->
            <div class="fill" style="background-image:url('images/BookStore.jpg');"></div>
            <div class="carousel-caption">
                <h2>Caption 1</h2>
            </div>
        </div>
        <div class="item">
            <!-- Set the second background image using inline CSS below. -->
            <div class="fill" style="background-image:url('images/Stock.jpg');"></div>
            <div class="carousel-caption">
                <h2>Caption 2</h2>
            </div>
        </div>
        <div class="item">
            <!-- Set the third background image using inline CSS below. -->
            <div class="fill" style="background-image:url('images/HW1.jpg');"></div>
            <div class="carousel-caption">
                <h2>Caption 3</h2>
            </div>
        </div>
    </div>

    <!-- Controls -->
    <a class="right carousel-control" href="#myCarousel" data-slide="prev">
        <span class="icon-prev"></span>
    </a>
    <a class="left carousel-control" href="#myCarousel" data-slide="next">
        <span class="icon-next"></span>
    </a>
</div>
    
<br />
<div class="container">
    <!-- News -->
    <div class="row">
        <div class="col-lg-12">
            <h3 style="font-family:'Droid Arabic Naskh', serif;">جدیدترین ها</h3>
        </div>
    </div>
    <!-- /.row -->
    <div id="myCarouselNews" class="carousel slide">
        <!-- Page Features -->
        <div class="carousel-inner" style="vertical-align:middle;">
            <% = StrNews %>                
        </div>
        <a class="right carousel-control" href="#myCarouselNews" data-slide="prev">‹</a>
        <a class="left carousel-control" href="#myCarouselNews" data-slide="next">›</a>
        <!-- /.row -->
    </div>
    <hr/>

    <!-- Adv -->
    <div align="center">
	    <img src="http://placehold.it/600x120" alt="Image" class="img-responsive"/>
    </div>
    <hr/>

    <!-- Bests -->
    <div class="row">
        <div class="col-lg-12">
            <h3 style="font-family:'Droid Arabic Naskh', serif;">برترین ها</h3>
        </div>
    </div>
    <!-- /.row -->
    <div id="myCarouselBests" class="carousel slide">
        <!-- Page Features -->
        <div class="carousel-inner">
            <% = StrBests %>                
        </div>
        <a class="right carousel-control" href="#myCarouselBests" data-slide="prev">‹</a>
        <a class="left carousel-control" href="#myCarouselBests" data-slide="next">›</a>
        <!-- /.row -->
    </div>
    <hr>
    
    <!-- Adv -->
    <div align="center">
	    <img src="http://placehold.it/600x120" alt="Image" class="img-responsive">
    </div>
    <hr>

    <!-- Hottests -->
    <div class="row">
        <div class="col-lg-12">
            <h3 style="font-family:'Droid Arabic Naskh', serif;">داغ ترین ها</h3>
        </div>
    </div>
    <!-- /.row -->
    <div id="myCarouselHottests" class="carousel slide">
        <!-- Page Features -->
        <div class="carousel-inner">
            <% = StrHottests %>                
        </div>
        <a class="right carousel-control" href="#myCarouselHottests" data-slide="prev">‹</a>
        <a class="left carousel-control" href="#myCarouselHottests" data-slide="next">›</a>
        <!-- /.row -->
    </div>
    <hr>
    
    <!-- Adv -->
    <div align="center">
	    <img src="http://placehold.it/600x120" alt="Image" class="img-responsive">
    </div>
    <hr>

    <!-- Frees -->
    <div class="row">
        <div class="col-lg-12">
            <h3 style="font-family:'Droid Arabic Naskh', serif;">رایگان ها</h3>
        </div>
    </div>
    <!-- /.row -->
    <div id="myCarouselFrees" class="carousel slide">
        <!-- Page Features -->
        <div class="carousel-inner">
            <% = StrFrees %>                
        </div>
        <a class="right carousel-control" href="#myCarouselFrees" data-slide="prev">‹</a>
        <a class="left carousel-control" href="#myCarouselFrees" data-slide="next">›</a>
        <!-- /.row -->
    </div>
    <hr>
    
    <!-- Adv -->
    <div align="center">
	    <img src="http://placehold.it/600x120" alt="Image" class="img-responsive">
    </div>
    <hr>

    <!-- BestsofWeek -->
    <div class="row">
        <div class="col-lg-12">
            <h3 style="font-family:'Droid Arabic Naskh', serif;">برترین های هفته</h3>
        </div>
    </div>
    <!-- /.row -->
    <div id="myCarouselBestsofWeek" class="carousel slide">
        <!-- Page Features -->
        <div class="carousel-inner">
            <% = StrBestsofWeek %>                
        </div>
        <a class="right carousel-control" href="#myCarouselBestsofWeek" data-slide="prev">‹</a>
        <a class="left carousel-control" href="#myCarouselBestsofWeek" data-slide="next">›</a>
        <!-- /.row -->
    </div>
    <hr>

    <!-- BestsofMonth -->
    <div class="row">
        <div class="col-lg-12">
            <h3 style="font-family:'Droid Arabic Naskh', serif;">برترین های ماه</h3>
        </div>
    </div>
    <!-- /.row -->
    <div id="myCarouselBestsofMonth" class="carousel slide">
        <!-- Page Features -->
        <div class="carousel-inner">
            <% = StrBestsofMonth %>                
        </div>
        <a class="right carousel-control" href="#myCarouselBestsofMonth" data-slide="prev">‹</a>
        <a class="left carousel-control" href="#myCarouselBestsofMonth" data-slide="next">›</a>
        <!-- /.row -->
    </div>
    <hr>
    
    <!-- Adv -->
    <div align="center">
	    <img src="http://placehold.it/600x120" alt="Image" class="img-responsive">
    </div>
    <hr/>

    <!-- HottestsofWeek -->
    <div class="row">
        <div class="col-lg-12">
            <h3 style="font-family:'Droid Arabic Naskh', serif;">داغ ترین های هفته</h3>
        </div>
    </div>
    <!-- /.row -->
    <div id="myCarouselHottestsofWeek" class="carousel slide">
        <!-- Page Features -->
        <div class="carousel-inner">
            <% = StrHottestsofWeek %>                
        </div>
        <a class="right carousel-control" href="#myCarouselHottestsofWeek" data-slide="prev">‹</a>
        <a class="left carousel-control" href="#myCarouselHottestsofWeek" data-slide="next">›</a>
        <!-- /.row -->
    </div>
    <hr/>
    
    <!-- HottestsofMonth -->
    <div class="row">
        <div class="col-lg-12">
            <h3 style="font-family:'Droid Arabic Naskh', serif;">داغ ترین های ماه</h3>
        </div>
    </div>
    <!-- /.row -->
    <div id="myCarouselHottestsofMonth" class="carousel slide">
        <!-- Page Features -->
        <div class="carousel-inner">
            <% = StrHottestsofMonth %>                
        </div>
        <a class="right carousel-control" href="#myCarouselHottestsofMonth" data-slide="prev">‹</a>
        <a class="left carousel-control" href="#myCarouselHottestsofMonth" data-slide="next">›</a>
        <!-- /.row -->
    </div>
    <hr>

    <!-- Footer -->
    <div class="footer" style="background-color:#BBBBBB;">
        <div class="row">
            <div class="col-sm-3">
                <ul class="list-unstyled">
                    <li><a href="#">Link</a></li>
                    <li><a href="#">Link</a></li>
                    <li><a href="#">Link</a></li>
                    <li><a href="#">Link</a></li>
                    <li><a href="#">Link</a></li>
                </ul>
            </div>
            <div class="col-sm-3">
                <ul class="list-unstyled">
                    <li><a href="#">Link</a></li>
                    <li><a href="#">Link</a></li>
                    <li><a href="#">Link</a></li>
                    <li><a href="#">Link</a></li>
                </ul>
            </div>
            <div class="col-sm-6">
                <ul class="list-unstyled">
                    <li class="tal-cent"><img height="75" alt="Logo goes here" src="logo"/></li>
                    <li id="footer-copy">Copyright.All right reserved. &copy;&rlm; 2014</li>
                </ul>
            </div>
        </div>
    </div>
  
</div><!-- /.container -->
   
</body>
    </html>


	
            
	
