function ProvinceLoader(Shahrestanha) {
    var _Shahrestan = document.getElementById("ContentPlaceHolder1_Shahrestan");
    _Shahrestan.options.length = 0;
    if (Shahrestanha != "") {
        var arr = Shahrestanha.split(",");
        for (i = 0; i < arr.length; i++) {
            if (arr[i] != "") {
                _Shahrestan.options[_Shahrestan.options.length] = new Option(arr[i], arr[i]);
            }
        }
    }
}function Toggle_DisEn(Item) {
    var T = document.getElementById(Item);    if (T.disabled) {
        T.disabled = false;
    } else        T.disabled = true;}function AccOwner(Me) {
    var T = document.getElementById('ContentPlaceHolder1_txtAccOwner');
    if (Me == true) {
        T.disabled = true;                        T.value = document.getElementById('ContentPlaceHolder1_txtFFName').value + ' ' + document.getElementById('ContentPlaceHolder1_txtFLName').value;
    } else {
        T.disabled = false;        T.value = '';    }}function MobileVerification() {
    var N = document.getElementById("txtMobileVerification");    N.disabled = true;                //Send Code via SMS Ajax    var url = "DoAction1.aspx?Action=SendSMS&Mode=Verification&Rc=" + N.value;
    
    var xmlhttp;    
    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            var K = xmlhttp.responseText.split('</CATALOG>')[0];
            var s = StrTOXml(K);
            var state = s.getElementsByTagName("STATE")[0].firstChild.nodeValue;

            
            if (state == "ارسال با موفقیت انجام شده است") {
                document.getElementById("lblInfo").innerHTML = "کدی 4 رقمی برای شماره همره شما ارسال شده است. لطفا آنرا در زیر وارد کنید";
                document.getElementById("SVC").style.display = "block";

            } else {
                document.getElementById("lblInfo").innerHTML = "مشکلی در ارسال پیام برای گوشی همراه شما وجود دارد. لطفا بعدا مجددا فرایند را ادامه دهید.";
            }
            
        }
    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();}function AjaxOrder(url) {
    var xmlhttp;
    var txt, xx, x, i;
    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            x = xmlhttp.responseText;
            return x;
            
        }
    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}

function AddNewProject() {
    document.getElementById('AddNewPanel').style.display = '';
    
    var y = document.getElementById('NewProPanel');    
    
    var yPo = (y.offsetTop - y.scrollTop + y.clientTop-30);
    window.scrollTo(0, yPo);
}

function AddNewFile(num) {

    var t = "<div id='FU_" + num + "' class='panel panel-default'><div class='panel-heading'>فایل شماره " + num + " </div><table class='table'><tr><td style='width:20%; vertical-align:middle;'><asp:FileUpload runat='server' ID='FileUploader_" + num + "' /></td><td style='width:65%; vertical-align:middle;'><input type='text' runat='server' class='form-control' id='FDesc_" + num + "' /></td><td style='width:15%; vertical-align:middle;'><a href='javascript:RemoveThis(" + num + ");' ><img src='images/Close-icon.png' class='img-circle' style='max-width:25px;' /></a></td></tr></table></div>";

    var v = document.getElementById("FUPlace");
    v.innerHTML = v.innerHTML + t;


}

function ElFo(t, v) {
    var y = t.value.trim();
    if (y == '' || y == v) {
        t.value = '';
        t.style.color = 'black';
    }
}

function ElBl(t, v) {
    var y = t.value.trim();
    if (y == '') {
        t.value = v;
        t.style.color = 'gray';
    }
}

function UPAddField() {
    
    var t = document.getElementById("txtfilterterm").value;
    alert(t);
    var c = document.getElementById("SelectedFields").innerHTML;
    alert(c);
    var k = document.getElementById("ContentPlaceHolder1_txtSelectedFields").innerHTML;
    alert(k);
    var n = k.split('!');
    alert(n.length);
    k += "!" + t;
    c += "<div class='input-group' style='display:inline-block;width:20%;' id='SF_" + n.length + "'><div class='input-group-btn'><button class='btn btn-primary' type='button' onclick='javascript:RemoveField(" + n.length + ")'><i class='glyphicon glyphicon-remove-circle'></i></button></div><span class='input-group-addon' style='width:100%;'>" + t + "</span></div>";
    document.getElementById("SelectedFields").innerHTML = c;
    document.getElementById("ContentPlaceHolder1_txtSelectedFields").innerHTML = k;
}

function AddField(t, v) {
    WFFToggle("FullPanel");
    var url = "DoAction1.aspx?Action=AddField&Code=" + t + "!" + v;
    var xmlhttp;
    var txt, xx, x, i;
    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            var K = xmlhttp.responseText.split('</CATALOG>')[0];
            var s = StrTOXml(K);
           
            var state = s.getElementsByTagName("STATE")[0].firstChild.nodeValue;
            
            var k = document.getElementById("ContentPlaceHolder1_SelectedFields").innerHTML;
           
            if (state == "true") {                
                k += "<div class='input-group' style='display:inline-block;width:20%;' id='SF_" + t + "'><div class='input-group-btn'><button class='btn btn-primary' type='button' onclick='javascript:RemoveField(" + t + ")'><i class='glyphicon glyphicon-remove-circle'></i></button></div><span class='input-group-addon' style='width:100%;'>" + v + "</span></div>";                
                document.getElementById("ContentPlaceHolder1_SelectedFields").innerHTML = k;
            }
            WFFToggle("FullPanel");
        }
    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}

function RemoveField(t) {
    WFFToggle("FullPanel");
    var url = "DoAction1.aspx?Action=RemoveField&Code=" + t;
    var xmlhttp;
    var txt, xx, x, i;
    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            var K = xmlhttp.responseText.split('</CATALOG>')[0];
            var s = StrTOXml(K);

            var state = s.getElementsByTagName("STATE")[0].firstChild.nodeValue;
            
            if (state == "true") {
                var elem = document.getElementById("SF_" + t);
                elem.parentElement.removeChild(elem);
            }
            WFFToggle("FullPanel");
        }
    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}

function StrTOXml(oString) {
    if (window.ActiveXObject) {
        var oXML = new ActiveXObject("Microsoft.XMLDOM"); oXML.loadXML(oString);
        return oXML;
    }
        // code for Chrome, Safari, Firefox, Opera, etc. 
    else {
        return (new DOMParser()).parseFromString(oString, "text/xml");
    }
}

function SearchTagAdd() {
    
    //Do Search
    var xmlhttp;
    //var txt, xx, x, i;
    WFFToggle("FullPanel");
    var t = document.getElementById("ContentPlaceHolder1_AllTags").innerHTML;
    t += document.getElementById("txtfilterterm").value + "!";
    document.getElementById("ContentPlaceHolder1_AllTags").innerHTML = t;
    
    

    //LoadSearch()
    var xmlhttp;

    var t = document.getElementById("ContentPlaceHolder1_AllTags").innerHTML;

    var c = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;

    var url = "DoAction1.aspx?Action=SearchHW&Value=" + t + "&Count=" + c;

    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    
    xmlhttp.onreadystatechange = function () {

        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

            var K = xmlhttp.responseText.split('</CATALOG>')[0];

            var s = StrTOXml(K);


            HomeWorks = s.getElementsByTagName("Homework");


            if (HomeWorks.length > 0) {
                var C = "<table class=\"table table-striped\"><thead><tr><th>#</th><th>عنوان</th><th>توضیحات</th><th>قیمت</th><th>فروش</th><th></th><th></th></tr></thead><tbody>";
                for (i = 0; i < HomeWorks.length; i++) {
                    C += "<tr><td>" + HomeWorks[i].getElementsByTagName("RN")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("TF_Name")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("P_Desc")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("Price")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("Download_C")[0].firstChild.nodeValue + "</td><td><button type=\"button\" class=\"btn btn-link\" id=\"HWDet_" + HomeWorks[i].getElementsByTagName("RN")[0].firstChild.nodeValue + "\" onclick=\"javascript:ShowHWDet('" + HomeWorks[i].getElementsByTagName("Paper_Code")[0].firstChild.nodeValue + "');\">جزئیات</button></td><td><button type=\"button\" class=\"btn btn-link\" id=\"btnRemoveHW('" + HomeWorks[i].getElementsByTagName("Paper_Code")[0].firstChild.nodeValue + "')\" >حذف</button></td></tr>";
                }
                C += "</tbody></table>";

            } else {
                C += "موردی یافت نشد.";
            }

            document.getElementById('ContentPlaceHolder1_TblCnt').innerHTML = C;
            
            Pagination = s.getElementsByTagName("Pagination");
            var TC = Pagination[0].getElementsByTagName("Count")[0].firstChild.nodeValue;
            var P = Pagination[0].getElementsByTagName("Page")[0].firstChild.nodeValue;
            
            var w = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].text;
            var PG = "<ul class=\"pagination\">";

            if (P == "1") {
                PG += "<li class=\"disabled\"><a href=\"#\">»</a></li>";
            } else {
                PG += "<li><a href=\"javascript:Proj_Pagination('" + w + "','" + (P - 1) + "');\">»</a></li>";
            }
            for (var i = 1; i <= TC; i++) {
                if (i == P) {
                    PG += "<li class=\"active\"><a href=\"#\">" + i + " <span class=\"sr-only\">(current)</span></a></li>";
                } else {
                    PG += "<li><a href=\"javascript:Proj_Pagination('" + w + "','" + i + "');\">" + i + "</a></li>";
                }
            }
            if (P == TC) {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            } else {
                PG += "<li><a href=\"javascript:Proj_Pagination('" + w + "','" + (P + 1) + "');\">«</a></li>";
            }

            document.getElementById('ContentPlaceHolder1_PaginationPanel').innerHTML = PG;

            // Add Tag to list

            var k = document.getElementById("SelectedTags").innerHTML;
            var f = document.getElementById("ContentPlaceHolder1_AllTags").innerHTML;
            var w = document.getElementById("txtfilterterm").value;
            
            var q = f.split('!');
           
            k += "<div class=\"input-group\" style=\"width:100px;\" id=\"TagGroup_" + (q.length - 1) + "\"><div class=\"input-group-btn\"><button class=\"btn btn-primary\" type=\"button\" id=\"btnRemoveTag\" onclick=\"javascript:SearchTagRemove('" + (q.length - 1) + "','" + w + "')\"><i class=\"glyphicon glyphicon-remove-circle\"></i></button></div><span class=\"input-group-addon\" style=\"width:100%;\">" + w + "</span></div>";

            document.getElementById("SelectedTags").innerHTML = k;
            document.getElementById("txtfilterterm").value = "";
            WFFToggle("FullPanel");
        }

    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();


    

}

function LoadSearch() {
    var xmlhttp;
    WFFToggle("FullPanel");
    var t = document.getElementById("ContentPlaceHolder1_AllTags").innerHTML;
    
    var c = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].text;
    var url = "DoAction1.aspx?Action=SearchHW&Value=" + t + "&Count=" + c;
    
    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    
    xmlhttp.onreadystatechange = function () {
        
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            
            var K = xmlhttp.responseText.split('</CATALOG>')[0];
            
            var s = StrTOXml(K);

            
            HomeWorks = s.getElementsByTagName("Homework");

            
            if (HomeWorks.length > 0) {
                var C = "<table class=\"table table-striped\"><thead><tr><th>#</th><th>عنوان</th><th>توضیحات</th><th>قیمت</th><th>فروش</th><th></th><th></th></tr></thead><tbody>";
                for (i = 0; i < HomeWorks.length; i++) {
                    C += "<tr><td>" + HomeWorks[i].getElementsByTagName("RN")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("TF_Name")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("P_Desc")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("Price")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("Download_C")[0].firstChild.nodeValue + "</td><td><button type=\"button\" class=\"btn btn-link\" id=\"HWDet_" + HomeWorks[i].getElementsByTagName("RN")[0].firstChild.nodeValue + "\" onclick=\"javascript:ShowHWDet('" + HomeWorks[i].getElementsByTagName("Paper_Code")[0].firstChild.nodeValue + "');\">جزئیات</button></td><td><button type=\"button\" class=\"btn btn-link\" id=\"btnRemoveHW('" + HomeWorks[i].getElementsByTagName("Paper_Code")[0].firstChild.nodeValue + "')\" >حذف</button></td></tr>";
                }
                C += "</tbody></table>";

            } else {
                C += "موردی یافت نشد.";
            }
            
            document.getElementById('ContentPlaceHolder1_TblCnt').innerHTML = C;
            WFFToggle("FullPanel");
        }
        
    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}

function SearchTagRemove(t,w) {
    WFFToggle("FullPanel");
    //Show Waiting Page
    var k = document.getElementById("ContentPlaceHolder1_AllTags").innerHTML;
    k = k.replace(w + "!", "");

    document.getElementById("ContentPlaceHolder1_AllTags").innerHTML = k;

    var xmlhttp;

    
    var c = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;
    var url = "DoAction1.aspx?Action=SearchHW&Value=" + k + "&Count=" + c;

    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {

        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

            var K = xmlhttp.responseText.split('</CATALOG>')[0];

            var s = StrTOXml(K);


            HomeWorks = s.getElementsByTagName("Homework");


            if (HomeWorks.length > 0) {
                var C = "<table class=\"table table-striped\"><thead><tr><th>#</th><th>عنوان</th><th>توضیحات</th><th>قیمت</th><th>فروش</th><th></th><th></th></tr></thead><tbody>";
                for (i = 0; i < HomeWorks.length; i++) {
                    C += "<tr><td>" + HomeWorks[i].getElementsByTagName("RN")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("TF_Name")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("P_Desc")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("Price")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("Download_C")[0].firstChild.nodeValue + "</td><td><button type=\"button\" class=\"btn btn-link\" id=\"HWDet_" + HomeWorks[i].getElementsByTagName("RN")[0].firstChild.nodeValue + "\" onclick=\"javascript:ShowHWDet('" + HomeWorks[i].getElementsByTagName("Paper_Code")[0].firstChild.nodeValue + "');\">جزئیات</button></td><td><button type=\"button\" class=\"btn btn-link\" id=\"btnRemoveHW('" + HomeWorks[i].getElementsByTagName("Paper_Code")[0].firstChild.nodeValue + "')\" >حذف</button></td></tr>";
                }
                C += "</tbody></table>";

            } else {
                C += "موردی یافت نشد.";
            }

            document.getElementById('ContentPlaceHolder1_TblCnt').innerHTML = C;

            Pagination = s.getElementsByTagName("Pagination");
            var TC = Pagination[0].getElementsByTagName("Count")[0].firstChild.nodeValue;
            var P = Pagination[0].getElementsByTagName("Page")[0].firstChild.nodeValue;
            
            var w = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].text;
            var PG = "<ul class=\"pagination\">";

            if (P == "1") {
                PG += "<li class=\"disabled\"><a href=\"#\">»</a></li>";
            } else {
                PG += "<li><a href=\"javascript:Proj_Pagination('" + w + "','" + (P - 1) + "');\">»</a></li>";
            }
            for (var i = 1; i <= TC; i++) {
                if (i == P) {
                    PG += "<li class=\"active\"><a href=\"#\">" + i + " <span class=\"sr-only\">(current)</span></a></li>";
                } else {
                    PG += "<li><a href=\"javascript:Proj_Pagination('" + w + "','" + i + "');\">" + i + "</a></li>";
                }
            }
            if (P == TC) {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            } else {
                PG += "<li><a href=\"javascript:Proj_Pagination('" + w + "','" + (P + 1) + "');\">«</a></li>";
            }

            document.getElementById('ContentPlaceHolder1_PaginationPanel').innerHTML = PG;

            var elem = document.getElementById("TagGroup_" + t);
            elem.parentElement.removeChild(elem);
            WFFToggle("FullPanel");
        }

    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
    

}

function searchKeyPress(e) {
    // look for window.event in case event isn't passed in
    if (typeof e == 'undefined' && window.event) { e = window.event; }
    if (e.keyCode == 13) {        
        SearchTagAdd();
    }
}

//Paginations
//UProject
function UP_Search(p) {
    var xmlhttp;
    
    WFFToggle("FullPanel","WFF");
    var c = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;

    var url = "DoAction1.aspx?Action=UP_Search&C=" + c + "&P=" + p;

    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {

        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

            var K = xmlhttp.responseText.split('</CATALOG>')[0];

            var s = StrTOXml(K);


            HomeWorks = s.getElementsByTagName("Homework");

            
            if (HomeWorks.length > 0) {
                var C = "<table class=\"table table-striped\"><thead><tr><th>#</th><th>عنوان</th><th>توضیحات</th><th>قیمت</th><th>فروش</th><th></th><th></th></tr></thead><tbody>";
                for (i = 0; i < HomeWorks.length; i++) {
                    var Description = HomeWorks[i].getElementsByTagName("P_Desc")[0].firstChild.nodeValue;
                    if (Description.length > 50) {
                        Description = Description.substring(0, 50) + "...";
                    }
                    C += "<tr><td>" + HomeWorks[i].getElementsByTagName("RN")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("TF_Name")[0].firstChild.nodeValue + "</td><td>" + Description + "</td><td>" + HomeWorks[i].getElementsByTagName("Price")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("Download_C")[0].firstChild.nodeValue + "</td><td><button type=\"button\" class=\"btn btn-link\" onclick=\"javascript:HWDet('" + HomeWorks[i].getElementsByTagName("Paper_Code")[0].firstChild.nodeValue + "');\">جزئیات</button></td><td><button type=\"button\" class=\"btn btn-link\" id=\"btnRemoveHW('" + HomeWorks[i].getElementsByTagName("Paper_Code")[0].firstChild.nodeValue + "')\" >حذف</button></td></tr>";
                }
                C += "</tbody></table>";

            } else {
                C += "موردی یافت نشد.";
            }

            document.getElementById('ContentPlaceHolder1_TblCnt').innerHTML = C;

            Pagination = s.getElementsByTagName("Pagination");
            var TC = Pagination[0].getElementsByTagName("Count")[0].firstChild.nodeValue;
            var P = Pagination[0].getElementsByTagName("Page")[0].firstChild.nodeValue;
            var w = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;
            var PG = "<ul class=\"pagination\">";

            if (P == "1") {
                PG += "<li class=\"disabled\"><a href=\"#\">»</a></li>";
            } else {
                PG += "<li><a href=\"javascript:UP_Search('" + (P - 1) + "');\">»</a></li>";
            }
            for (var i = 1; i <= TC; i++) {
                if (i == P) {
                    PG += "<li class=\"active\"><a href=\"#\">" + i + " <span class=\"sr-only\">(current)</span></a></li>";
                } else {
                    PG += "<li><a href=\"javascript:UP_Search('" + i + "');\">" + i + "</a></li>";
                }
            }
            if (P == TC) {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            } else {
                var e = parseInt(P);
                PG += "<li><a href=\"javascript:UP_Search('" + (e + 1) + "');\">«</a></li>";
            }

            document.getElementById('ContentPlaceHolder1_PaginationPanel').innerHTML = PG;
            WFFToggle("FullPanel", "WFF");
        }

    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}

//UBuy
function UB_Search(p) {
    var xmlhttp;
    WFFToggle("FullPanel", "WFF");
    var c = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;

    var url = "DoAction1.aspx?Action=UB_Search&C=" + c + "&P=" + p;

    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {

        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

            var K = xmlhttp.responseText.split('</CATALOG>')[0];

            var s = StrTOXml(K);


            HomeWorks = s.getElementsByTagName("Homework");


            if (HomeWorks.length > 0) {
                var C = "<table class=\"table table-striped\"><thead><tr><th>#</th><th>عنوان</th><th style=\"width:70px;\">قیمت</th><th style=\"width:40px;\"></th></tr></thead><tbody>";
                for (i = 0; i < HomeWorks.length; i++) {
                    var Name = HomeWorks[i].getElementsByTagName("TF_Name")[0].firstChild.nodeValue;
                    if (Name.trim() == "") Name = HomeWorks[i].getElementsByTagName("TE_Name")[0].firstChild.nodeValue;
                    C += "<tr><td>" + HomeWorks[i].getElementsByTagName("RN")[0].firstChild.nodeValue + "</td><td>" + Name + "</td><td>" + HomeWorks[i].getElementsByTagName("Price")[0].firstChild.nodeValue + "</td><td><button type=\"button\" class=\"btn btn-link\" id=\"HWDet_" + HomeWorks[i].getElementsByTagName("RN")[0].firstChild.nodeValue + "\" onclick=\"javascript:UB_ShowHWDet('" + HomeWorks[i].getElementsByTagName("Paper_Code")[0].firstChild.nodeValue + "');\">جزئیات</button></td></tr>";
                }
                C += "</tbody></table>";

            } else {
                C += "موردی یافت نشد.";
            }

            document.getElementById('ContentPlaceHolder1_TblCnt').innerHTML = C;

            Pagination = s.getElementsByTagName("Pagination");
            var TC = Pagination[0].getElementsByTagName("Count")[0].firstChild.nodeValue;
            var P = Pagination[0].getElementsByTagName("Page")[0].firstChild.nodeValue;
            var w = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;
            var PG = "<ul class=\"pagination\">";

            if (P == "1") {
                PG += "<li class=\"disabled\"><a href=\"#\">»</a></li>";
            } else {
                PG += "<li><a href=\"javascript:UB_Search('" + (P - 1) + "');\">»</a></li>";
            }
            for (var i = 1; i <= TC; i++) {
                if (i == P) {
                    PG += "<li class=\"active\"><a href=\"#\">" + i + " <span class=\"sr-only\">(current)</span></a></li>";
                } else {
                    PG += "<li><a href=\"javascript:UB_Search('" + i + "');\">" + i + "</a></li>";
                }
            }
            if (P == TC) {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            } else {
                var e = parseInt(P);
                PG += "<li><a href=\"javascript:UB_Search('" + (e + 1) + "');\">«</a></li>";
            }

            document.getElementById('ContentPlaceHolder1_PaginationPanel').innerHTML = PG;
            WFFToggle("FullPanel", "WFF");
        }

    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}

//UAccount
function UA_Search(p) {
    var xmlhttp;
    WFFToggle("FullPanel", "WFF");
    var c = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;
    
    var url = "DoAction1.aspx?Action=UA_Search&C=" + c + "&P=" + p;

    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    
    xmlhttp.onreadystatechange = function () {

        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

            var K = xmlhttp.responseText.split('</CATALOG>')[0];

            var s = StrTOXml(K);

            
            var Transactions = s.getElementsByTagName("Transaction");
            

            if (Transactions.length > 0) {
                var C = "<table class=\"table table-striped\"><thead><tr><th style=\"width:30px;\">#</th><th style=\"width:80px;\">تاریخ</th><th style=\"width:80px;\">زمان</th><th>شرح</th><th style=\"width:100px;\">مبلغ گردش</th><th style=\"width:100px;\">مانده</th></tr></thead><tbody>";
                for (i = 0; i < Transactions.length; i++) {
                    var Am;

                    if (Transactions[i].getElementsByTagName("InOut")[0].firstChild.nodeValue == "1")
                    {
                        Am = "<span class=\"text-success\">" + Transactions[i].getElementsByTagName("Amount")[0].firstChild.nodeValue + "+</span>";
                    }
                    else
                    {
                        Am = "<span class=\"text-danger\">" + Transactions[i].getElementsByTagName("Amount")[0].firstChild.nodeValue + "-</span>";
                    }
                    
                    C += "<tr><td><h6>" + Transactions[i].getElementsByTagName("RN")[0].firstChild.nodeValue + "</h6></td><td><h6>" + Transactions[i].getElementsByTagName("Tarikh")[0].firstChild.nodeValue + "</h6></td><td><h6>" + Transactions[i].getElementsByTagName("Saat")[0].firstChild.nodeValue + "</h6></td><td><h6>" + Transactions[i].getElementsByTagName("Trans_Subject")[0].firstChild.nodeValue + "</h6></td><td><h6>" + Am + "</h6></td><td><h6>" + Transactions[i].getElementsByTagName("AccBalance")[0].firstChild.nodeValue + "</h6></td></tr>";
                   
                }
                C += "</tbody></table>";

            } else {
                C += "موردی یافت نشد.";
            }
            
            document.getElementById('ContentPlaceHolder1_TblCnt').innerHTML = C;

            Pagination = s.getElementsByTagName("Pagination");
            var TC = Pagination[0].getElementsByTagName("Count")[0].firstChild.nodeValue;
            var P = Pagination[0].getElementsByTagName("Page")[0].firstChild.nodeValue;
            var w = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;
            var PG = "<ul class=\"pagination\">";

            if (P == "1") {
                PG += "<li class=\"disabled\"><a href=\"#\">»</a></li>";
            } else {
                PG += "<li><a href=\"javascript:UA_Search('" + (P - 1) + "');\">»</a></li>";
            }
            for (var i = 1; i <= TC; i++) {
                if (i == P) {
                    PG += "<li class=\"active\"><a href=\"#\">" + i + " <span class=\"sr-only\">(current)</span></a></li>";
                } else {
                    PG += "<li><a href=\"javascript:UA_Search('" + i + "');\">" + i + "</a></li>";
                }
            }
            if (P == TC) {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            } else {
                var e = parseInt(P);
                PG += "<li><a href=\"javascript:UA_Search('" + (e + 1) + "');\">«</a></li>";
            }

            document.getElementById('ContentPlaceHolder1_PaginationPanel').innerHTML = PG;
            WFFToggle("FullPanel", "WFF");
        }

    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}

//UAccount Settlement Request
function UASR_Search(p) {
    var xmlhttp;
    WFFToggle("FullPanel1", "WFF1");
    var c = document.getElementById("ContentPlaceHolder1_SearchShowCount2").options[document.getElementById('ContentPlaceHolder1_SearchShowCount2').selectedIndex].value;

    var url = "DoAction1.aspx?Action=UASR_Search&C=" + c + "&P=" + p;

    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {

        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

            var K = xmlhttp.responseText.split('</CATALOG>')[0];

            var s = StrTOXml(K);


            var SRS = s.getElementsByTagName("SR");
            
            
            if (SRS.length > 0) {
                C = "<table class=\"table table-striped\"><thead><tr><th style=\"width:30px;\">#</th><th style=\"width:80px;\">تاریخ</th><th style=\"width:80px;\">زمان</th><th>شرح</th><th style=\"width:110px;\">وضعیت</th><th style=\"width:30px;\"></th></tr></thead><tbody>";
                
                for (i = 0; i < SRS.length; i++) {

                    C += "<tr><td>" + SRS[i].getElementsByTagName("Pre_Req_Code")[0].firstChild.nodeValue + "</td><td>" + SRS[i].getElementsByTagName("Tarikh")[0].firstChild.nodeValue + "</td><td>" + SRS[i].getElementsByTagName("Saat")[0].firstChild.nodeValue + "</td><td>" + SRS[i].getElementsByTagName("Subject")[0].firstChild.nodeValue + "</td><td><span" + SRS[i].getElementsByTagName("Status")[0].firstChild.nodeValue + "</span></td><td><button type=\"button\" class=\"btn btn-link\" onclick=\"javascript:RemoveSR('SReq_" + SRS[i].getElementsByTagName("RN")[0].firstChild.nodeValue + "')\">لغو</button></td></tr>";
                    
                }
                C += "</tbody></table>";

            } else {
                C += "موردی یافت نشد.";
            }
            
            document.getElementById('ContentPlaceHolder1_TblCnt2').innerHTML = C;

            Pagination = s.getElementsByTagName("Pagination");
            var TC = Pagination[0].getElementsByTagName("Count")[0].firstChild.nodeValue;
            var P = Pagination[0].getElementsByTagName("Page")[0].firstChild.nodeValue;
            var w = document.getElementById("ContentPlaceHolder1_SearchShowCount2").options[document.getElementById('ContentPlaceHolder1_SearchShowCount2').selectedIndex].value;
            var PG = "<ul class=\"pagination\">";

            if (P == "1") {
                PG += "<li class=\"disabled\"><a href=\"#\">»</a></li>";
            } else {
                PG += "<li><a href=\"javascript:UASR_Search('" + (P - 1) + "');\">»</a></li>";
            }
            for (var i = 1; i <= TC; i++) {
                if (i == P) {
                    PG += "<li class=\"active\"><a href=\"#\">" + i + " <span class=\"sr-only\">(current)</span></a></li>";
                } else {
                    PG += "<li><a href=\"javascript:UASR_Search('" + i + "');\">" + i + "</a></li>";
                }
            }
            if (P == TC) {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            } else {
                var e = parseInt(P);
                PG += "<li><a href=\"javascript:UASR_Search('" + (e + 1) + "');\">«</a></li>";
            }

            document.getElementById('ContentPlaceHolder1_PaginationPanel2').innerHTML = PG;
            WFFToggle("FullPanel1", "WFF1");
        }

    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}

//USupport
function US_Search(p) {
    var xmlhttp;
    WFFToggle("FullPanel", "WFF");
    var c = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;

    var url = "DoAction1.aspx?Action=US_Search&C=" + c + "&P=" + p;

    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {

        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

            var K = xmlhttp.responseText.split('</CATALOG>')[0];

            var s = StrTOXml(K);


            var Supports = s.getElementsByTagName("SU");


            if (Supports.length > 0) {
                var C = "<table class=\"table table-striped\"><thead><tr><th style=\"width:30px;\">#</th><th style=\"width:80px;\">تاریخ</th><th style=\"width:80px;\">ساعت</th><th>عنوان</th><th style=\"width:110px;\">دسته</th><th style=\"width:100px;\">ضرورت</th><th style=\"width:120px;\">وضعیت</th><th style=\"width:50px;\"></th></tr></thead><tbody>";
                for (i = 0; i < Supports.length; i++) {                    
                    C += "<tr><td>" + Supports[i].getElementsByTagName("Pre_Support_Code")[0].firstChild.nodeValue + "</td><td>" + Supports[i].getElementsByTagName("Tarikh")[0].firstChild.nodeValue + "</td><td>" + Supports[i].getElementsByTagName("Saat")[0].firstChild.nodeValue + "</td><td>" + Supports[i].getElementsByTagName("Subject")[0].firstChild.nodeValue + "</td><td>" + Supports[i].getElementsByTagName("Field")[0].firstChild.nodeValue + "</td><td>" + Supports[i].getElementsByTagName("Priority")[0].firstChild.nodeValue + "</td><td><span" + Supports[i].getElementsByTagName("Status")[0].firstChild.nodeValue + "</td><td><button type=\"button\" class=\"btn btn-link\" onclick=\"javascript:SupportDet('" + Supports[i].getElementsByTagName("Support_Code")[0].firstChild.nodeValue + "')\">نمایش</button></td></tr>";

                }
                C += "</tbody></table>";

            } else {
                C += "موردی یافت نشد.";
            }

            document.getElementById('ContentPlaceHolder1_TblCnt').innerHTML = C;

            Pagination = s.getElementsByTagName("Pagination");
            var TC = Pagination[0].getElementsByTagName("Count")[0].firstChild.nodeValue;
            var P = Pagination[0].getElementsByTagName("Page")[0].firstChild.nodeValue;
            var w = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;
            var PG = "<ul class=\"pagination\">";

            if (P == "1") {
                PG += "<li class=\"disabled\"><a href=\"#\">»</a></li>";
            } else {
                PG += "<li><a href=\"javascript:US_Search('" + (P - 1) + "');\">»</a></li>";
            }
            for (var i = 1; i <= TC; i++) {
                if (i == P) {
                    PG += "<li class=\"active\"><a href=\"#\">" + i + " <span class=\"sr-only\">(current)</span></a></li>";
                } else {
                    PG += "<li><a href=\"javascript:US_Search('" + i + "');\">" + i + "</a></li>";
                }
            }
            if (P == TC) {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            } else {
                var e = parseInt(P);
                PG += "<li><a href=\"javascript:US_Search('" + (e + 1) + "');\">«</a></li>";
            }

            document.getElementById('ContentPlaceHolder1_PaginationPanel').innerHTML = PG;
            WFFToggle("FullPanel", "WFF");
        }

    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}

//Settlement for Admin
function Ad_SL_SetType(t) {
    document.getElementById("RType").innerHTML = t;
    for (i = 0; i < 6; i++) {
        document.getElementById("OptAdSU_" + i).removeAttribute("Class");
    }

    document.getElementById("OptAdSU_" + t).setAttribute("Class", "active");

    Ad_SL_Search('1');
}

function Ad_SL_Search(p) {
    var xmlhttp;    
    WFFToggle("FullPanel", "WFF");
    var rt = document.getElementById("RType").innerHTML;
    var ct = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;

    var url = "../DoAction1.aspx?Action=Ad_SL_Search&rt=" + rt + "&P=" + p + "&C=" + ct;
    
    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {

        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

            var K = xmlhttp.responseText.split('</CATALOG>')[0];

            var s = StrTOXml(K);


            var Requests = s.getElementsByTagName("SR");


            if (Requests.length > 0) {
                var C = "<table class=\"table table-striped\"><thead><tr><th>کد</th><th>تاریخ</th><th>ساعت</th><th>کاربر</th><th>عنوان</th><th>مقدار</th><th>وضعیت</th><th></th></tr></thead><tbody>";
                for (i = 0; i < Requests.length; i++) {
                    C += "<tr><td>" + Requests[i].getElementsByTagName("Pre_Req_Code")[0].firstChild.nodeValue + "</td><td>" + Requests[i].getElementsByTagName("Tarikh")[0].firstChild.nodeValue + "</td><td>" + Requests[i].getElementsByTagName("Saat")[0].firstChild.nodeValue + "</td><td><a href=\"#\" class=\"btn btn-link\" onclick=\"javascript:UserDetAd('" + Requests[i].getElementsByTagName("User_Code")[0].firstChild.nodeValue + "')\">" + Requests[i].getElementsByTagName("User_Name")[0].firstChild.nodeValue + "</a></td><td>" + Requests[i].getElementsByTagName("Subject")[0].firstChild.nodeValue + "</td><td>" + Requests[i].getElementsByTagName("Amount")[0].firstChild.nodeValue + "</td><td><span" + Requests[i].getElementsByTagName("Status")[0].firstChild.nodeValue + "</span></td><td><button type=\"button\" class=\"btn btn-link\" onclick=\"javascript:SettleDetAd('" + Requests[i].getElementsByTagName("Req_Code")[0].firstChild.nodeValue + "')\">بررسی</button></td></tr>";

                }
                C += "</tbody></table>";

            } else {
                C += "موردی یافت نشد.";
            }

            document.getElementById('ContentPlaceHolder1_TblCnt').innerHTML = C;

            Pagination = s.getElementsByTagName("Pagination");
            var TC = Pagination[0].getElementsByTagName("Count")[0].firstChild.nodeValue;
            var P = Pagination[0].getElementsByTagName("Page")[0].firstChild.nodeValue;
            var w = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;
            var PG = "<ul class=\"pagination\">";

            if (P == "1") {
                PG += "<li class=\"disabled\"><a href=\"#\">»</a></li>";
            } else {
                PG += "<li><a href=\"javascript:Ad_SL_Search('" + (P - 1) + "');\">»</a></li>";
            }
            for (var i = 1; i <= TC; i++) {
                if (i == P) {
                    PG += "<li class=\"active\"><a href=\"#\">" + i + " <span class=\"sr-only\">(current)</span></a></li>";
                } else {
                    PG += "<li><a href=\"javascript:Ad_SL_Search('" + i + "');\">" + i + "</a></li>";
                }
            }
            if (P == TC) {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            } else {
                var e = parseInt(P);
                PG += "<li><a href=\"javascript:Ad_SL_Search('" + (e + 1) + "');\">«</a></li>";
            }

            document.getElementById('ContentPlaceHolder1_PaginationPanel').innerHTML = PG;
            WFFToggle("FullPanel", "WFF");
        }

    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}

//Projects for Admin
function Ad_P_SetOrders(b, t) {
    
    if (b != -1)
        document.getElementById("OB").innerHTML = b;    

    if (t != -1)
        document.getElementById("OT").innerHTML = t;
        
}

function Ad_P_Search(p) {
    
    var xmlhttp;
    WFFToggle("FullPanel", "WFF");
    var b = document.getElementById("OB").innerHTML;
    var t = document.getElementById("OT").innerHTML;
    var ct = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;
    
    var Tags = "";
    
    var url = "../DoAction1.aspx?Action=Ad_P_Search&Tags=" + Tags + "&ob=" + b + "&ot=" + t + "&P=" + p + "&C=" + ct;

    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {

        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

            var K = xmlhttp.responseText.split('</CATALOG>')[0];

            var s = StrTOXml(K);


            HomeWorks = s.getElementsByTagName("APC");
            
            var C;
            if (HomeWorks.length > 0) {
                C = "<table class=\"table table-striped\"><thead><tr><th>#</th><th>عنوان</th><th>فروشنده</th><th>امتیاز</th><th>فروش</th><th>قیمت</th><th></th></tr></thead><tbody>";
                for (i = 0; i < HomeWorks.length; i++) {                    
                    C += "<tr><td>" + HomeWorks[i].getElementsByTagName("Pre_Paper_Code")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("TitleName")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("Owner_Name")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("Paper_Rate")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("Download_C")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("Price")[0].firstChild.nodeValue + "</td><td><button type=\"button\" class=\"btn btn-link\" id=\"HWDet_" + HomeWorks[i].getElementsByTagName("RN")[0].firstChild.nodeValue + "\" onclick=\"javascript:ShowHWDet('" + HomeWorks[i].getElementsByTagName("Paper_Code")[0].firstChild.nodeValue + "');\">جزئیات</button></td></tr>";
                }
                C += "</tbody></table>";

            } else {
                C += "موردی یافت نشد.";
            }
            
            document.getElementById('ContentPlaceHolder1_TblCnt').innerHTML = C;

            Pagination = s.getElementsByTagName("Pagination");
            var TC = Pagination[0].getElementsByTagName("Count")[0].firstChild.nodeValue;
            var P = Pagination[0].getElementsByTagName("Page")[0].firstChild.nodeValue;
            var w = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;
            var PG = "<ul class=\"pagination\">";
            
            if (P == "1") {
                PG += "<li class=\"disabled\"><a href=\"#\">»</a></li>";
            } else {
                PG += "<li><a href=\"javascript:Ad_P_Search('" + (P - 1) + "');\">»</a></li>";
            }
            for (var i = 1; i <= TC; i++) {
                if (i == P) {
                    PG += "<li class=\"active\"><a href=\"#\">" + i + " <span class=\"sr-only\">(current)</span></a></li>";
                } else {
                    PG += "<li><a href=\"javascript:Ad_P_Search('" + i + "');\">" + i + "</a></li>";
                }
            }
            
            if (P == TC) {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            } else {
                var e = parseInt(P);
                PG += "<li><a href=\"javascript:Ad_P_Search('" + (e + 1) + "');\">«</a></li>";
            }

            
            document.getElementById('ContentPlaceHolder1_PaginationPanel').innerHTML = PG;
            WFFToggle("FullPanel", "WFF");
        }

    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}

//Users for Admin
function Ad_U_Search(p) {
    var xmlhttp;
    WFFToggle("FullPanel", "WFF");
    var b = document.getElementById("OB").innerHTML;
    var t = document.getElementById("OT").innerHTML;
    var ct = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;

    var Tags = document.getElementById("AllTags").innerHTML;

    var url = "../DoAction1.aspx?Action=Ad_U_Search&Tags=" + Tags + "&ob=" + b + "&ot=" + t + "&P=" + p + "&C=" + ct;

    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {

        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

            var K = xmlhttp.responseText.split('</CATALOG>')[0];

            var s = StrTOXml(K);


            var AUC = s.getElementsByTagName("AUC");


            if (AUC.length > 0) {
                C = "<table class=\"table table-striped\"><thead><tr><th style=\"width:30px;\">#</th><th>نام</th><th style=\"width:90px;\">تعداد تکلیف</th><th style=\"width:90px;\">فروش</th><th style=\"width:90px;\">خرید</th><th style=\"width:90px;\">موجودی</th><th style=\"width:40px;\"></th></tr></thead><tbody>";

                for (i = 0; i < AUC.length; i++) {

                    C += "<tr><td>" + AUC[i].getElementsByTagName("RN")[0].firstChild.nodeValue + "</td><td>" + AUC[i].getElementsByTagName("Name")[0].firstChild.nodeValue + "</td><td>" + AUC[i].getElementsByTagName("HW_Count")[0].firstChild.nodeValue + "</td><td>" + AUC[i].getElementsByTagName("HW_Sell")[0].firstChild.nodeValue + "</td><td>" + AUC[i].getElementsByTagName("HW_Buy")[0].firstChild.nodeValue + "</td><td>" + AUC[i].getElementsByTagName("HW_AccBal")[0].firstChild.nodeValue + "</td><td><button type=\"button\" class=\"btn btn-link\" onclick=\"javascript:UserDetAd('" + AUC[i].getElementsByTagName("User_Code")[0].firstChild.nodeValue + "')\">جزئیات</button></td></tr>";

                }
                C += "</tbody></table>";

            } else {
                C += "موردی یافت نشد.";
            }

            document.getElementById('ContentPlaceHolder1_TblCnt').innerHTML = C;

            Pagination = s.getElementsByTagName("Pagination");
            var TC = Pagination[0].getElementsByTagName("Count")[0].firstChild.nodeValue;
            var P = Pagination[0].getElementsByTagName("Page")[0].firstChild.nodeValue;
            var w = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;
            var PG = "<ul class=\"pagination\">";

            if (P == "1") {
                PG += "<li class=\"disabled\"><a href=\"#\">»</a></li>";
            } else {
                PG += "<li><a href=\"javascript:Ad_U_Search('" + (P - 1) + "');\">»</a></li>";
            }
            for (var i = 1; i <= TC; i++) {
                if (i == P) {
                    PG += "<li class=\"active\"><a href=\"#\">" + i + " <span class=\"sr-only\">(current)</span></a></li>";
                } else {
                    PG += "<li><a href=\"javascript:Ad_U_Search('" + i + "');\">" + i + "</a></li>";
                }
            }
            if (P == TC) {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            } else {
                var e = parseInt(P);
                PG += "<li><a href=\"javascript:Ad_U_Search('" + (e + 1) + "');\">«</a></li>";
            }

            document.getElementById('ContentPlaceHolder1_PaginationPanel').innerHTML = PG;
            WFFToggle("FullPanel", "WFF");
        }

    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}

//Trades for Admin
function Ad_TD_Search(p) {
    var xmlhttp;
    WFFToggle("FullPanel", "WFF");
    var Seller = document.getElementById('txtSeller').value;
    var Buyer = document.getElementById('txtBuyer').value;
    var c = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;

    var url = "../DoAction1.aspx?Action=Ad_TD_Search&Seller=" + Seller + "&Buyer=" + Buyer + "&P=" + p + "&C=" + c;

    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {

        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

            var K = xmlhttp.responseText.split('</CATALOG>')[0];

            var s = StrTOXml(K);


            HomeWorks = s.getElementsByTagName("APC");


            if (HomeWorks.length > 0) {
                var C = "<table class=\"table table-striped\"><thead><tr><th>تاریخ</th><th>ساعت</th><th>تکلیف</th><th>فروشنده</th><th>خریدار</th><th>قیمت</th><th></th></tr></thead><tbody>";
                for (i = 0; i < HomeWorks.length; i++) {
                    C += "<tr><td>" + HomeWorks[i].getElementsByTagName("Tarikh")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("Saat")[0].firstChild.nodeValue + "</td><td><a href=\"#\" class=\"btn btn-link\" onclick=\"javascript:HWDetAd('" + HomeWorks[i].getElementsByTagName("Paper_Code")[0].firstChild.nodeValue + "');\">" + HomeWorks[i].getElementsByTagName("Pre_Paper_Code")[0].firstChild.nodeValue + "</a></td><td><a href=\"#\" class=\"btn btn-link\" onclick=\"javascript:UserDetAd('" + HomeWorks[i].getElementsByTagName("Seller_Code")[0].firstChild.nodeValue + "');\">" + HomeWorks[i].getElementsByTagName("Seller_Name")[0].firstChild.nodeValue + "</a></td><td><a href=\"#\" class=\"btn btn-link\" onclick=\"javascript:UserDetAd('" + HomeWorks[i].getElementsByTagName("Buyer_Code")[0].firstChild.nodeValue + "');\">" + HomeWorks[i].getElementsByTagName("Buyer_Name")[0].firstChild.nodeValue + "</a></td><td>" + HomeWorks[i].getElementsByTagName("Price")[0].firstChild.nodeValue + "</td><td><button type=\"button\" class=\"btn btn-link\" onclick=\"javascript:ShowTDDet('" + HomeWorks[i].getElementsByTagName("Paper_Code")[0].firstChild.nodeValue + "');\">جزئیات</button></td></tr>";
                }
                C += "</tbody></table>";

            } else {
                C = "موردی یافت نشد.";
            }

            document.getElementById('ContentPlaceHolder1_TblCnt').innerHTML = C;

            Pagination = s.getElementsByTagName("Pagination");
            var TC = Pagination[0].getElementsByTagName("Count")[0].firstChild.nodeValue;
            var P = Pagination[0].getElementsByTagName("Page")[0].firstChild.nodeValue;
            var w = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;
            var PG = "<ul class=\"pagination\">";

            if (P == "1") {
                PG += "<li class=\"disabled\"><a href=\"#\">»</a></li>";
            } else {
                PG += "<li><a href=\"javascript:Ad_TD_Search('" + (P - 1) + "');\">»</a></li>";
            }
            for (var i = 1; i <= TC; i++) {
                if (i == P) {
                    PG += "<li class=\"active\"><a href=\"#\">" + i + " <span class=\"sr-only\">(current)</span></a></li>";
                } else {
                    PG += "<li><a href=\"javascript:Ad_TD_Search('" + i + "');\">" + i + "</a></li>";
                }
            }
            if (P == TC) {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            } else {
                var e = parseInt(P);
                PG += "<li><a href=\"javascript:Ad_TD_Search('" + (e + 1) + "');\">«</a></li>";
            }

            document.getElementById('ContentPlaceHolder1_PaginationPanel').innerHTML = PG;
            WFFToggle("FullPanel", "WFF");
        }

    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}

//Transactions for Admin
function Ad_TN_SetType(t) {
    
    document.getElementById("RType").innerHTML = t;   
    for (i = 0; i < 3; i++) {
        document.getElementById("OptAdSU_" + i).removeAttribute("Class");
    }

    document.getElementById("OptAdSU_" + t).setAttribute("Class", "active");

    Ad_TN_Search('1');
}

function Ad_TN_Search(p) {
    var xmlhttp;
    WFFToggle("FullPanel", "WFF");
    var rt = document.getElementById("RType").innerHTML;
    var ct = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;

    var ucode = document.getElementById("UCode").value.trim();

    var url = "../DoAction1.aspx?Action=Ad_TN_Search&UCode=" + ucode + "&rt=" + rt + "&P=" + p + "&C=" + ct;
    
    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {

        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            
            var K = xmlhttp.responseText.split('</CATALOG>')[0];

            var s = StrTOXml(K);


            HomeWorks = s.getElementsByTagName("APC");


            if (HomeWorks.length > 0) {
                var C = "<table class=\"table table-striped\"><thead><tr><th>کاربر</th><th>تاریخ</th><th>ساعت</th><th>موضوع</th><th>از/به</th><th>مقدار</th><th></th></tr></thead><tbody>";
                for (i = 0; i < HomeWorks.length; i++) {
                    C += "<tr><td><a href=\"#\" class=\"btn btn-link\" onclick=\"javascript:UserDetAd('" + HomeWorks[i].getElementsByTagName("User_Code")[0].firstChild.nodeValue + "')\">" + HomeWorks[i].getElementsByTagName("User_Name")[0].firstChild.nodeValue + "</a></td><td>" + HomeWorks[i].getElementsByTagName("Tarikh")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("Saat")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("Subject")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("FromTo")[0].firstChild.nodeValue + "</td><td>" + HomeWorks[i].getElementsByTagName("Amount")[0].firstChild.nodeValue + "</td><td><button type=\"button\" class=\"btn btn-link\" id=\"HWDet_" + HomeWorks[i].getElementsByTagName("Transaction_Code")[0].firstChild.nodeValue + "\" onclick=\"javascript:ShowHWDet('" + HomeWorks[i].getElementsByTagName("Transaction_Code")[0].firstChild.nodeValue + "');\">جزئیات</button></td></tr>";
                }
                C += "</tbody></table>";

            } else {
                C = "موردی یافت نشد.";
            }

            document.getElementById('ContentPlaceHolder1_TblCnt').innerHTML = C;

            Pagination = s.getElementsByTagName("Pagination");
            var TC = Pagination[0].getElementsByTagName("Count")[0].firstChild.nodeValue;
            var P = Pagination[0].getElementsByTagName("Page")[0].firstChild.nodeValue;
            var w = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;
            var PG = "<ul class=\"pagination\">";

            if (P == "1") {
                PG += "<li class=\"disabled\"><a href=\"#\">»</a></li>";
            } else {
                PG += "<li><a href=\"javascript:Ad_TN_Search('" + (P - 1) + "');\">»</a></li>";
            }
            for (var i = 1; i <= TC; i++) {
                if (i == P) {
                    PG += "<li class=\"active\"><a href=\"#\">" + i + " <span class=\"sr-only\">(current)</span></a></li>";
                } else {
                    PG += "<li><a href=\"javascript:Ad_TN_Search('" + i + "');\">" + i + "</a></li>";
                }
            }
            if (P == TC) {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            } else {
                var e = parseInt(P) + 1;
                PG += "<li><a href=\"javascript:Ad_TN_Search('" + (e) + "');\">«</a></li>";
            }

            document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex = 0;

            document.getElementById('ContentPlaceHolder1_PaginationPanel').innerHTML = PG;
            WFFToggle("FullPanel", "WFF");
        }

    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}

//Support for Admin
function Ad_SU_SetType(t) {
    document.getElementById("RType").innerHTML = t;
    for (i = 0; i < 5; i++) {
        document.getElementById("OptAdSU_" + i).removeAttribute("Class");
    }

    document.getElementById("OptAdSU_" + t).setAttribute("Class", "active");

    Ad_SU_Search('1');
}

function Ad_SU_Search(p) {
    WFFToggle("FullPanel", "WFF");
    var rt = document.getElementById("RType").innerHTML;
    var ct = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;
    
    var url = "../DoAction1.aspx?Action=Ad_SU_Search&rt=" + rt + "&P=" + p + "&C=" + ct;
    
    var xmlhttp;

    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {

        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

            var K = xmlhttp.responseText.split('</CATALOG>')[0];

            var s = StrTOXml(K);


            var Supports = s.getElementsByTagName("SU");


            if (Supports.length > 0) {
                var C = "<table class=\"table table-striped\"><thead><tr><th>کد</th><th>تاریخ</th><th>ساعت</th><th>کاربر</th><th>عنوان</th><th>دسته</th><th>اولویت</th><th>وضعیت</th><th></th></tr></thead><tbody>";
                for (i = 0; i < Supports.length; i++) {
                    C += "<tr><td>" + Supports[i].getElementsByTagName("Pre_Support_Code")[0].firstChild.nodeValue + "</td><td>" + Supports[i].getElementsByTagName("Tarikh")[0].firstChild.nodeValue + "</td><td>" + Supports[i].getElementsByTagName("Saat")[0].firstChild.nodeValue + "</td><td><a href=\"#\" class=\"btn btn-link\" onclick=\"javascript:UserDetAd('" + Supports[i].getElementsByTagName("User_Code")[0].firstChild.nodeValue + "');\">" + Supports[i].getElementsByTagName("User_Name")[0].firstChild.nodeValue + "</a></td><td>" + Supports[i].getElementsByTagName("Subject")[0].firstChild.nodeValue + "</td><td>" + Supports[i].getElementsByTagName("Field")[0].firstChild.nodeValue + "</td><td>" + Supports[i].getElementsByTagName("Priority")[0].firstChild.nodeValue + "</td><td><span" + Supports[i].getElementsByTagName("Status")[0].firstChild.nodeValue + "</td><td><button type=\"button\" class=\"btn btn-link\" onclick=\"javascript:ResponseSU('" + Supports[i].getElementsByTagName("Support_Code")[0].firstChild.nodeValue + "')\">نمایش</button></td></tr>";

                }
                C += "</tbody></table>";

            } else {
                C += "موردی یافت نشد.";
            }

            document.getElementById('ContentPlaceHolder1_TblCnt').innerHTML = C;

            Pagination = s.getElementsByTagName("Pagination");
            var TC = Pagination[0].getElementsByTagName("Count")[0].firstChild.nodeValue;
            var P = Pagination[0].getElementsByTagName("Page")[0].firstChild.nodeValue;
            var w = document.getElementById("ContentPlaceHolder1_SearchShowCount").options[document.getElementById('ContentPlaceHolder1_SearchShowCount').selectedIndex].value;
            var PG = "<ul class=\"pagination\">";

            if (P == "1") {
                PG += "<li class=\"disabled\"><a href=\"#\">»</a></li>";
            } else {
                PG += "<li><a href=\"javascript:Ad_SU_Search('" + (P - 1) + "');\">»</a></li>";
            }
            for (var i = 1; i <= TC; i++) {
                if (i == P) {
                    PG += "<li class=\"active\"><a href=\"#\">" + i + " <span class=\"sr-only\">(current)</span></a></li>";
                } else {
                    PG += "<li><a href=\"javascript:Ad_SU_Search('" + i + "');\">" + i + "</a></li>";
                }
            }
            if (P == TC) {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            } else {
                var e = parseInt(P);
                PG += "<li><a href=\"javascript:Ad_SU_Search('" + (e + 1) + "');\">«</a></li>";
            }
            
            document.getElementById('ContentPlaceHolder1_PaginationPanel').innerHTML = PG;
            WFFToggle("FullPanel", "WFF");
        }

    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}

function WFFToggle(v,t) {
    
    var d = document.getElementById(v);
    var m = document.getElementById(t);
    if (m.style.display == "" || m.style.display == "block") {
        
        m.style.display = "none";
    } else {
        var k = d.getBoundingClientRect();        
        m.style.left = 0 + "px";
        m.style.top = 70 + "px";
        m.style.right = 0 + "px";
        //m.style.right = parseInt(k.right, 10) + "px";
        m.style.bottom = (0 - k.bottom) + "px";
        //m.style.bottom = parseInt(k.bottom, 10) + "px";
                       
        m.style.display = "";
    }
}

function RedirectDownload(t) {    
    var url = "Download.aspx?=" + t;
    window.open(url, "_blank");

}

function DoSearch() {
    var t = document.getElementById("srchterm").value;
    t = t.replace('+', ' ').replace('-', ' ');

    if (t.trim() != "") {
        t = t.replace(' ', '+');
        location.href = "GroupView.aspx?m=-1&t=" + t;
    }
}

function ShowMore(t,v,s) {
    
    var xmlhttp;

    //var c = document.getElementById("SearchShowCount").options[document.getElementById('SearchShowCount').selectedIndex].text;

    var url = "DoAction1.aspx?Action=ShowMore&t=" + t + "&v=" + v + "&s=" + s;

    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {

        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

            var K = xmlhttp.responseText.split('</CATALOG>')[0];

            var s = StrTOXml(K);


            HomeWorks = s.getElementsByTagName("Homework");
            var C = document.getElementById('ContentPlaceHolder1_txtGV').innerHTML;
            
            if (HomeWorks.length > 0) {
                
                for (i = 0; i < HomeWorks.length; i++) {
                    C += "<div class=\"col-xs-6 col-sm-3\"><div class=\"thumbnail\" align=\"center\"><img src=\"images/MS-Word-icon.png\" class=\"img-thumbnail\" /><div class=\"caption text-right\"><div style=\"height:60px;\"><h3>" + HomeWorks[i].getElementsByTagName("TF_Name")[0].firstChild.nodeValue + "</h3>";
                    C += "</div><div class=\"scrollbar\" style=\"height:100px;\"><p>" + HomeWorks[i].getElementsByTagName("P_Desc")[0].firstChild.nodeValue + "</p></div></div><p><a href=\"#\" class=\"btn btn-primary\">خرید</a> <a href=\"ProjView.aspx?=" + HomeWorks[i].getElementsByTagName("Paper_Code")[0].firstChild.nodeValue + "\" class=\"btn btn-default\">مشاهده</a></p></div></div>";                    
                }                

            } else {                
            }
            
            document.getElementById('ContentPlaceHolder1_txtGV').innerHTML = C;

            Pagination = s.getElementsByTagName("Pagination");
            var TC = Pagination[0].getElementsByTagName("Count")[0].firstChild.nodeValue;
            if (TC != "All") {
                document.getElementById("ContentPlaceHolder1_morebtn").innerHTML = "<input style=\"width:100%;\" type=\"button\" id=\"btnMore\" class=\"btn btn-default\" value=\"نمایش بیشتر\" onclick=\"javascript: ShowMore();\" />";
            } else {
                document.getElementById("ContentPlaceHolder1_morebtn").innerHTML = "";
            }

        }

    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();

}

function GV_Order(v) {
    WFFToggle("FullPanel", "WFF");

    for (i = 0; i < 4; i++) {
        document.getElementById("option" + i).removeAttribute("checked");
    }

    document.getElementById("option" + v).setAttribute("checked", "checked");

    var xmlhttp;

    //var c = document.getElementById("SearchShowCount").options[document.getElementById('SearchShowCount').selectedIndex].text;
    var t = document.getElementById("ContentPlaceHolder1_AllTags").innerHTML;
    var url = "DoAction1.aspx?Action=GV_Order&t=" + t + "&v=" + v;

    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {

        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

            var K = xmlhttp.responseText.split('</CATALOG>')[0];

            var s = StrTOXml(K);


            HomeWorks = s.getElementsByTagName("Homework");
            var C = "";

            if (HomeWorks.length > 0) {

                for (i = 0; i < HomeWorks.length; i++) {
                    C += "<div class=\"col-xs-6 col-sm-3\"><div class=\"thumbnail\" align=\"center\"><img src=\"images/MS-Word-icon.png\" class=\"img-thumbnail\" /><div class=\"caption text-right\"><div style=\"height:60px;\"><h3>" + HomeWorks[i].getElementsByTagName("TF_Name")[0].firstChild.nodeValue + "</h3>";
                    C += "</div><div class=\"scrollbar\" style=\"height:100px;\"><p>" + HomeWorks[i].getElementsByTagName("P_Desc")[0].firstChild.nodeValue + "</p></div></div><p><a href=\"#\" class=\"btn btn-primary\">خرید</a> <a href=\"ProjView.aspx?=" + HomeWorks[i].getElementsByTagName("Paper_Code")[0].firstChild.nodeValue + "\" class=\"btn btn-default\">مشاهده</a></p></div></div>";
                }

            } else {
                C += "موردی یافت نشد.";
            }

            document.getElementById('ContentPlaceHolder1_txtGV').innerHTML = C;

            Pagination = s.getElementsByTagName("Pagination");
            var TC = Pagination[0].getElementsByTagName("Count")[0].firstChild.nodeValue;
            if (TC != "All") {
                document.getElementById("ContentPlaceHolder1_morebtn").innerHTML = "<input style=\"width:100%;\" type=\"button\" id=\"btnMore\" class=\"btn btn-default\" value=\"نمایش بیشتر\" onclick=\"javascript: ShowMore();\" />";
            } else {
                document.getElementById("ContentPlaceHolder1_morebtn").innerHTML = "";
            }

            WFFToggle("FullPanel", "WFF");
        }

    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();

}

function SettlementRequest() {
    var xmlhttp;
    
    var RP = document.getElementById("ContentPlaceHolder1_slcPercent").options[document.getElementById('ContentPlaceHolder1_slcPercent').selectedIndex].value;
    var RD = document.getElementById("ContentPlaceHolder1_slcSettlDate").options[document.getElementById('ContentPlaceHolder1_slcSettlDate').selectedIndex].value;
    var AB = document.getElementById("ContentPlaceHolder1_txtAccBal").innerHTML;
    
    var url = "DoAction1.aspx?Action=SettlementRequest&AB=" + AB +  "&RP=" + RP + "&RD=" + RD;

    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {

        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

            var K = xmlhttp.responseText.split('</CATALOG>')[0];

            var s = StrTOXml(K);

            
            var SettlementRequest = s.getElementsByTagName("SR");
            

            if (SettlementRequest.length > 0) {

                for (i = 0; i < SettlementRequest.length; i++) {                    
                    document.getElementById("ContentPlaceHolder1_txtMainTitle").innerHTML = SettlementRequest[i].getElementsByTagName("MT")[0].firstChild.nodeValue;
                    document.getElementById("ContentPlaceHolder1_txtMainAmount").innerHTML = SettlementRequest[i].getElementsByTagName("MA")[0].firstChild.nodeValue;
                    document.getElementById("ContentPlaceHolder1_txtTB_RateTitle").innerHTML = SettlementRequest[i].getElementsByTagName("TBT")[0].firstChild.nodeValue;
                    document.getElementById("ContentPlaceHolder1_txtTB_RateAmount").innerHTML = SettlementRequest[i].getElementsByTagName("TBA")[0].firstChild.nodeValue;
                    document.getElementById("ContentPlaceHolder1_txtTotalAmount").innerHTML = SettlementRequest[i].getElementsByTagName("TA")[0].firstChild.nodeValue;
                }

            } else {
                C += "موردی یافت نشد.";
            }
        }

    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}

function UserDet(v) {
    window.open("UserView.aspx?=" + v, '_blank');
}

function UserDetAd(v) {
    window.open("../UserView.aspx?=" + v, '_blank');
}

function SupportDet(v) {    
    $('#myModal').modal('show');
    //document.getElementById("myModal").modal('show');
    var ifr = document.getElementById("DetFrame");
    ifr.setAttribute("src", "SupportView.aspx?=" + v);
    
}

function ResponseSU(v) {
    $('#myModal').modal('show');
    //document.getElementById("myModal").modal('show');
    var ifr = document.getElementById("DetFrame");
    ifr.setAttribute("src", "../SupportView.aspx?=" + v);
}

function HWDet(v) {
    window.open("ProjView.aspx?=" + v, "_blank");
}

function HWDetAd(v) {
    window.open("../ProjView.aspx?=" + v, "_blank");
}

function CloseModal(v) {
    $(v).modal('hide');
}

function HWRM(v) { //Show Modal to Remove HW
    
    document.getElementById("code").innerHTML = v;
    document.getElementById("ModalMessage").innerHTML = "با حذف این تکلیف، تمامی فایل های مرتبط با آن نیز از تکلیف بازار حذف خواهند شد.<br /> آیا مایل به حذف این تکلیف می باشید؟";
    
    $("#myModal").modal('show');
}

function RemoveHW() {
    $("#btnRNo").attr("disabled", "disabled");
    $("#btnRYes").attr("disabled", "disabled");
    
    document.getElementById("ModalMessage").innerHTML = "لطفا منتظر باشید";

    var v = document.getElementById("code").innerHTML;
    var url = "DoAction1.aspx?Action=RemoveHW&Code=" + v;
    var xmlhttp;
    var txt, xx, x, i;
    //sending input data az url and the url will respond the out put as xml
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }

    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            var K = xmlhttp.responseText.split('</CATALOG>')[0];
            var s = StrTOXml(K);

            var state = s.getElementsByTagName("STATE")[0].firstChild.nodeValue;
            
            if (state == "true") {
                document.getElementById("ModalMessage").innerHTML = "تکلیف مورد نظر با موفقیت حذف شد.";
            } else {
                document.getElementById("ModalMessage").innerHTML = "مشکلی در حذف این تکلیف بوجود آمده است، لطفا مورد را از قسمت پشتیبانی به مدیریت بازار اطلاع دهید.";
            }
            setTimeout(function () { $("#myModal").modal('hide');}, 2000);
            
            
        }
    }

    xmlhttp.open("GET", url, true);
    xmlhttp.send();

    window.location.href = "UProjects.aspx";
}

function SettleDetAd(v) {
    
    $('#myModal').modal('show');
    //document.getElementById("myModal").modal('show');
    var ifr = document.getElementById("DetFrame");
    ifr.setAttribute("src", "../SettlementView.aspx?=" + v);
    
}

function PrintContent(c) {
    var panel = document.getElementById("ContentPlaceHolder1_" + c);
   
    var printWindow = window.open('', '', 'height=400,width=800');
    printWindow.document.write('<html><head><link href="css/bootstrap.min.css" rel="stylesheet"/><link href="rtl/css/bootstrap-rtl.min.css" rel="stylesheet"/><title>نسخه چاپی</title>');
    printWindow.document.write('</head><body style="direction:rtl;" >');
    printWindow.document.write(panel.innerHTML);
    printWindow.document.write('</body></html>');
    printWindow.document.close();
    setTimeout(function () {
        printWindow.print();
    }, 500);
    return false;
}