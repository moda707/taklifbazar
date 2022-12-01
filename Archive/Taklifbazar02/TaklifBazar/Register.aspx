<%@ Page Title="تکلیف بازار - عضویت" Language="C#" MasterPageFile="~/Class.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register"%>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../js/jquery.maskedinput.min.js"></script>
    <script>
        jQuery(function ($) {
            $("#ContentPlaceHolder1_txtCardnumber").mask("9999-9999-9999-9999");
            $("#ContentPlaceHolder1_txtMobile").mask("999999999");
            $("#ContentPlaceHolder1_txtVerificationCode").mask("9999");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><br /><br />
    <div class="container" align="center" style="text-align:center; width:60%;">
        <% if (String.IsNullOrEmpty(Request.QueryString[0].ToString()))
           {
               Response.Redirect("/Register/Form");
           }
           else
           {
               string q = Request.QueryString[""].ToString();
               if(q=="Form"){%>

        <div class="row placeholders">
            <div class="col-xs-12 col-sm-12 placeholder">
                <div class="panel panel-default">
                  <div class="panel-heading">مشخصات فردی</div>
                  <table class="table">
                      <tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">نام : </span></h5>
                          </td>
                          <td style="text-align:right;width:300px;" >
                              <input type="text" class="form-control" runat="server" id="txtFFName"/>                                  
                          </td>
                          <td style="text-align:right;">
                              <asp:RequiredFieldValidator ForeColor="Red" ControlToValidate="txtFFName" ID="RFVFFName" runat="server" ErrorMessage="این فیلد ضروریست" Text="*"></asp:RequiredFieldValidator>
                          </td>
                      </tr>
                      <tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">نام خانوادگی : </span></h5>
                          </td>
                          <td style="text-align:right;width:300px;" >
                              <input type="text" class="form-control" runat="server" id="txtFLName"/>                                  
                          </td>
                          <td style="text-align:right;">
                              <asp:RequiredFieldValidator ForeColor="Red" ControlToValidate="txtFLName" ID="RFVFLName" runat="server" ErrorMessage="این فیلد ضروریست" Text="*"></asp:RequiredFieldValidator>
                          </td>
                      </tr>
                      <tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">نام (انگلیسی) : </span></h5>
                          </td>
                          <td style="width:300px;" >
                              <input style="text-align:left;" type="text" class="form-control" runat="server" id="txtEFName"/>                                  
                          </td>
                          <td style="text-align:right;">
                              <asp:RequiredFieldValidator ForeColor="Red" ControlToValidate="txtEFName" ID="RFVEFName" runat="server" ErrorMessage="این فیلد ضروریست" Text="*"></asp:RequiredFieldValidator>
                          </td>
                      </tr>
                      <tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">نام خانوادگی (انگلیسی) : </span></h5>
                          </td>
                          <td style="width:300px;" >
                              <input style="text-align:left;" type="text" class="form-control" runat="server" id="txtELName"/>                                  
                          </td>
                          <td style="text-align:right;">
                              <asp:RequiredFieldValidator ForeColor="Red" ControlToValidate="txtELName" ID="RFVELName" runat="server" ErrorMessage="این فیلد ضروریست" Text="*"></asp:RequiredFieldValidator>
                          </td>
                      </tr>
                    </table>
                </div>
            </div>

            <div class="col-xs-12 col-sm-12 placeholder">
                <div class="panel panel-default">
                  <div class="panel-heading">اطلاعات تماس</div>
                  <table class="table">
                      <%--<tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">استان : </span></h5>
                          </td>
                          <td style="text-align:right;width:300px;" >
                              <select style="font-size:9pt;" class="form-control" id="Ostan" runat="server" onchange="ProvinceLoader(this.value)">
                                    <option value=""></option>
                                    <option value="  ,آذرشهر ,اسکو ,اهر ,بستان‌آباد ,بناب ,تبریز ,جلفا ,چاراویماق ,سراب ,شبستر ,عجب‌شیر ,کلیبر ,مراغه ,مرند ,ملکان ,میانه ,ورزقان ,هریس ,هشترود">آذربایجان شرقی</option>
                                    <option value="  ,ارومیه ,اشنویه ,بوکان ,پیرانشهر ,تکاب ,چالدران ,خوی ,سردشت ,سلماس ,شاهین‌دژ ,ماکو ,مهاباد ,میاندوآب ,نقده">آذربایجان غربی</option>
                                    <option value="  ,اردبیل ,بیله‌سوار ,پارس‌آباد ,خلخال ,کوثر ,گِرمی ,مِشگین‌شهر ,نَمین ,نیر">اردبیل</option>
                                    <option value="  ,آران و بیدگل ,اردستان ,اصفهان ,برخوار و میمه ,تیران و کرون ,چادگان ,خمینی‌شهر ,خوانسار ,سمیرم ,شهرضا ,سمیرم سفلی ,فریدن ,فریدون‌شهر ,فلاورجان ,کاشان ,گلپایگان ,لنجان ,مبارکه ,نائین ,نجف‌آباد ,نطنز">اصفهان</option>
                                    <option value="  ,آبدانان ,ایلام ,ایوان ,دره‌شهر ,دهلران ,شیروان و چرداول ,مهران">ایلام</option>
                                    <option value="  ,بوشهر ,تنگستان ,جم ,دشتستان ,دشتی,دیر ,دیلم ,کنگان ,گناوه">بوشهر</option>
                                    <option value="  ,اسلام‌شهر ,پاکدشت ,تهران ,دماوند ,رباط‌کریم ,ری ,ساوجبلاغ ,شمیرانات ,شهریار ,فیروزکوه ,کرج ,نظرآباد ,ورامین">تهران</option>
                                    <option value="  ,اردل ,بروجن ,شهرکرد ,فارسان ,کوهرنگ ,لردگان">چهارمحال و بختیاری</option>
                                    <option value="  ,بیرجند ,درمیان ,سرایان ,سربیشه ,فردوس ,قائنات,نهبندان">خراسان جنوبی</option>
                                    <option value="  ,بردسکن ,تایباد ,تربت جام ,تربت حیدریه ,چناران ,خلیل‌آباد ,خواف ,درگز ,رشتخوار ,سبزوار ,سرخس ,فریمان ,قوچان ,کاشمر ,کلات ,گناباد ,مشهد ,مه ولات ,نیشابور">خراسان رضوی</option>
                                    <option value="  ,اسفراین ,بجنورد ,جاجرم ,شیروان ,فاروج ,مانه و سملقان">خراسان شمالی</option>
                                    <option value="  ,آبادان ,امیدیه ,اندیمشک ,اهواز ,ایذه ,باغ‌ملک ,بندر ماهشهر ,بهبهان ,خرمشهر ,دزفول ,دشت آزادگان ,رامشیر ,رامهرمز ,شادگان ,شوش ,شوشتر ,گتوند ,لالی ,مسجد سلیمان,هندیجان ">خوزستان</option>
                                    <option value="  ,ابهر ,ایجرود ,خدابنده ,خرمدره ,زنجان ,طارم ,ماه‌نشان">زنجان</option>
                                    <option value="  ,دامغان ,سمنان ,شاهرود ,گرمسار ,مهدی‌شهر">سمنان</option>
                                    <option value="  ,ایرانشهر ,چابهار ,خاش ,دلگان ,زابل ,زاهدان ,زهک ,سراوان ,سرباز ,کنارک ,نیک‌شهر">سیستان و بلوچستان</option>
                                    <option value="  ,آباده ,ارسنجان ,استهبان ,اقلید ,بوانات ,پاسارگاد ,جهرم ,خرم‌بید ,خنج ,داراب ,زرین‌دشت ,سپیدان ,شیراز ,فراشبند ,فسا ,فیروزآباد ,قیر و کارزین ,کازرون ,لارستان ,لامِرد ,مرودشت ,ممسنی ,مهر ,نی‌ریز">فارس</option>
                                    <option value="  ,آبیک ,البرز ,بوئین‌زهرا ,تاکستان ,قزوین">قزوین</option>
                                    <option value="  ,قم">قم</option>
                                    <option value="  ,بانه ,بیجار ,دیواندره ,سروآباد ,سقز ,سنندج ,قروه ,کامیاران ,مریوان">کردستان</option>
                                    <option value="  ,بافت ,بردسیر ,بم ,جیرفت ,راور ,رفسنجان ,رودبار جنوب ,زرند ,سیرجان ,شهر بابک ,عنبرآباد ,قلعه گنج ,کرمان ,کوهبنان ,کهنوج ,منوجان">کرمان</option>
                                    <option value="  ,اسلام‌آباد غرب ,پاوه ,ثلاث باباجانی ,جوانرود ,دالاهو ,روانسر ,سرپل ذهاب ,سنقر ,صحنه ,قصر شیرین ,کرمانشاه ,کنگاور ,گیلان غرب ,هرسین">کرمانشاه</option>
                                    <option value="  ,بویراحمد ,بهمئی ,دنا ,کهگیلویه ,گچساران">کهگیلویه و بویراحمد</option>
                                    <option value="  ,آزادشهر ,آق‌قلا ,بندر گز ,ترکمن ,رامیان ,علی‌آباد ,کردکوی ,کلاله ,گرگان ,گنبد کاووس ,مراوه‌تپه ,مینودشت">گلستان</option>
                                    <option value="  ,آستارا ,آستانه اشرفیه ,اَملَش ,بندر انزلی ,رشت ,رضوانشهر ,رودبار ,رودسر ,سیاهکل ,شَفت ,صومعه‌سرا ,طوالش ,فومَن ,لاهیجان ,لنگرود ,ماسال">گیلان</option>
                                    <option value="  ,ازنا ,الیگودرز ,بروجرد ,پل‌دختر ,خرم‌آباد ,دورود ,دلفان ,سلسله ,کوهدشت">لرستان</option>
                                    <option value="  ,آمل ,بابل ,بابلسر ,بهشهر ,تنکابن ,جویبار ,چالوس ,رامسر ,ساری ,سوادکوه ,قائم‌شهر ,گلوگاه ,محمودآباد ,نکا ,نور ,نوشهر">مازندران</option>
                                    <option value="  ,آشتیان ,اراک ,تفرش ,خمین ,دلیجان ,زرندیه ,ساوه ,شازند ,کمیجان ,محلات">مرکزی</option>
                                    <option value="  ,ابوموسی ,بستک ,بندر عباس ,بندر لنگه ,جاسک ,حاجی‌آباد ,شهرستان خمیر ,رودان  ,قشم ,گاوبندی ,میناب">هرمزگان</option>
                                    <option value="  ,اسدآباد ,بهار ,تویسرکان ,رزن ,کبودرآهنگ ,ملایر ,نهاوند ,همدان">همدان</option>
                                    <option value="  ,ابرکوه ,اردکان ,بافق ,تفت ,خاتم ,صدوق ,طبس ,مهریز ,مِیبُد ,یزد">یزد</option>
                                </select>
                          </td>
                          <td style="text-align:right;">
                              توضیحات
                          </td>
                      </tr>
                      <tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">شهر : </span></h5>
                          </td>
                          <td style="text-align:right;width:300px;" >
                              <select style="font-size:9pt;" class="form-control" id="Shahrestan" runat="server" >
                              </select>
                          </td>
                          <td style="text-align:right;">
                              توضیحات
                          </td>
                      </tr>
                      <tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">آدرس : </span></h5>
                          </td>
                          <td style="text-align:right;width:300px;" >
                              <input type="text" class="form-control" runat="server" id="txtAddress">                                  
                          </td>
                          <td style="text-align:right;">
                              توضیحات
                          </td>
                      </tr>
                      <tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">تلفن ثابت : </span></h5>
                          </td>
                          <td style="width:300px;" >
                              <input style="text-align:left;" type="text" class="form-control" runat="server" id="txtPhone">                                  
                          </td>
                          <td style="text-align:right;">
                              توضیحات
                          </td>
                      </tr>--%>
                      <tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">تلفن همراه : </span></h5>
                          </td>
                          <td style="width:300px;" >
                              <div class="input-group">
                              <input style="direction:ltr;" type="text" class="form-control" runat="server" id="txtMobile"/>                                  
                                  <span style="direction:ltr;" class="input-group-addon">+98-9</span>
                                  </div>
                          </td>
                          <td style="text-align:right;">
                              <asp:RequiredFieldValidator ForeColor="Red" ControlToValidate="txtMobile" ID="RFVMobile" runat="server" ErrorMessage="این فیلد ضروریست" Text="*"></asp:RequiredFieldValidator>
                          </td>
                      </tr>
                    </table>
                </div>
            </div>

            <%--<div class="col-xs-12 col-sm-12 placeholder">
                <div class="panel panel-default">
                  <div class="panel-heading">اطلاعات تحصیلی شغلی</div>
                  <table class="table">
                      <tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">تحصیلات : </span></h5>
                          </td>
                          <td style="width:300px;" >
                              <select style="font-size:9pt;" class="form-control" runat="server" id="optEducation">
                                  <option>انتخاب کنید</option>
                                  <option value="0">راهنمایی</option>
                                  <option value="1">دبیرستان</option>
                                  <option value="2">دیپلم</option>
                                  <option value="3">فوق دیپلم</option>
                                  <option value="4">لیسانس</option>
                                  <option value="5">فوق لیسانس</option>
                                  <option value="6">دکتری</option>
                                  <option value="7">دکتری حرفه ای</option>                                  
                              </select>
                          </td>
                          <td style="text-align:right;">
                              توضیحات
                          </td>
                      </tr>
                      <tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">رشته تحصیلی : </span></h5>
                          </td>
                          <td style="width:300px;" >
                              <select style="font-size:9pt;" class="form-control" runat="server" id="optField">
                                  <option>انتخاب کنید</option>
                                  <option value="1">ملت</option>
                                  <option value="2">ملی</option>
                                  <option value="3">تجارت</option>
                                  <option value="4">پارسیان</option>
                                  <option value="5">پاسارگاد</option>                                  
                              </select>                                 
                          </td>
                          <td style="text-align:right;">
                              توضیحات
                          </td>
                      </tr>
                      <tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">شغل : </span></h5>
                          </td>
                          <td style="text-align:right;width:300px;" >
                              <select style="font-size:9pt;" class="form-control" runat="server" id="optJob">
                                  <option>انتخاب کنید</option>
                                  <option value="0">دانشجو</option>
                                  <option value="1">دانش آموز</option>
                                  <option value="2">کارمند</option>
                                  <option value="3">پژوهشگر</option>
                                  <option value="4">بیکار</option>                                  
                              </select>                               
                          </td>
                          <td style="text-align:right;">
                              توضیحات
                          </td>
                      </tr>                      
                    </table>
                </div>
            </div>--%>

            <div class="col-xs-12 col-sm-12 placeholder">
                <div class="panel panel-default">
                  <div class="panel-heading">اطلاعات کاربری</div>
                  <table class="table">
                      <tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">نام کاربری : </span></h5>
                          </td>
                          <td style="width:300px;" >
                              <div class="input-group" style="width:200px;">                                  
                                  <input style="direction:ltr;text-align:left;" type="text" class="form-control" runat="server" id="txtUsername"/>
                                  <span class="input-group-addon"><i class="glyphicon glyphicon-ok"></i></span>
                              </div>
                          </td>
                          <td style="text-align:right;">
                              <asp:RequiredFieldValidator ForeColor="Red" ControlToValidate="txtUsername" ID="RFVUsername" runat="server" ValidationGroup="vgUsername" ErrorMessage="این فیلد ضروریست"></asp:RequiredFieldValidator><br />
                              <asp:RegularExpressionValidator ControlToValidate="txtUsername" ValidationExpression="^[a-zA-Z0-9]([._](?![._])|[a-zA-Z0-9]){6,18}[a-zA-Z0-9]$" runat="server" ID="REVUsername" ValidationGroup="vgUsername" Font-Size="9pt" ErrorMessage="نام کاربری معتبر انتخاب کنید. میبایست بین 6 تا 18 کاراکتر باشد و با «.» یا «_» شروع نشود" ForeColor="Red"></asp:RegularExpressionValidator>
                          </td>
                      </tr>
                      <tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">Email : </span></h5>
                          </td>
                          <td style="width:300px;" >
                              <input style="text-align:left;" type="text" class="form-control" runat="server" id="txtEmail"/>                                  
                          </td>
                          <td style="text-align:right;">
                              <asp:RequiredFieldValidator ControlToValidate="txtEmail" ForeColor="Red" ID="RFVEmail" runat="server" ValidationGroup="vgEmail" ErrorMessage="این فیلد ضروریست" Text="*"></asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ID="REVEmail" ValidationGroup="vgEmail" ErrorMessage="ایمیل معتبر وارد کنید" ForeColor="Red"></asp:RegularExpressionValidator>
                          </td>
                      </tr>
                      <tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">رمز عبور : </span></h5>
                          </td>
                          <td style="width:300px;" >
                              <input style="text-align:left;" type="password" class="form-control" runat="server" id="txtPass"/>                                  
                          </td>
                          <td style="text-align:right;">
                              <asp:RequiredFieldValidator ControlToValidate="txtPass" ForeColor="Red" ID="RFVPass" runat="server" ValidationGroup="vgPass" ErrorMessage="این فیلد ضروریست" Text="*"></asp:RequiredFieldValidator><br />
                              <asp:RegularExpressionValidator ControlToValidate="txtPass" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" runat="server" ID="REVPass" ValidationGroup="vgPass" ErrorMessage="رمز عبور معتبر وارد کنید. حداقل 8 کاراکتر شامل حداقل یک حرف و یک عدد" ForeColor="Red"></asp:RegularExpressionValidator>
                          </td>
                      </tr>
                      <tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">تکرار رمز عبور : </span></h5>
                          </td>
                          <td style="width:300px;" >
                              <input style="text-align:left;" type="password" class="form-control" runat="server" id="txtRePass"/>                                  
                          </td>
                          <td style="text-align:right;">
                             <asp:RequiredFieldValidator id="RFVRepass"
                                  runat="server" 
                                  ControlToValidate="txtRePass"
                                  ErrorMessage="تائید رمز عبور الزامیست"
                                  SetFocusOnError="True" 
                                  Display="Dynamic" ForeColor="Red" />
                              <asp:CompareValidator id="CVRepass" 
                                  runat="server"
                                  ControlToCompare="txtPass"
                                  ControlToValidate="txtRePass"
                                  ErrorMessage="تکرار رمز با اصل آن همخوانی ندارد"
                                  Display="Dynamic" ForeColor="Red" />
                          </td>
                      </tr>
                      <tr>
                            <td colspan="2">
                                <hr />
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" checked="checked" runat="server" id="chkMail1"/> دریافت ایمیل صورت حساب ماهیانه
                                    </label>
                                </div>
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" checked="checked" runat="server" id="chkSMS1"/> دریافت پیامک صورت حساب ماهیانه
                                    </label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <div class="col-xs-12 col-sm-12 placeholder">
                <div class="panel panel-default">
                  <div class="panel-heading">
                      اطلاعات حساب بانکی
                      
                  </div>
                    
                      <div class="alert alert-info">
                          تکمیل اطلاعات این بخش برای کاربرانی که قصد فروش تکلیفی در «تکلیف بازار» دارند <i>اجباری</i> می باشد.
                      </div>
                  <table class="table">
                      <tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">شماره حساب : </span></h5>
                          </td>
                          <td style="width:300px;" >
                              <div class="input-group" style="width:200px;">                                  
                                  <input style="text-align:left;" type="text" class="form-control" runat="server" id="txtAccount"/>                                  
                              </div>
                          </td>
                          <td style="text-align:right;">
                              
                          </td>
                      </tr>
                      <tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">شماره کارت : </span></h5>
                          </td>
                          <td style="width:300px;" >
                              <input style="direction:ltr;" type="text" class="form-control" runat="server" id="txtCardnumber"/>                                  
                          </td>
                          <td style="text-align:right;">
                              
                          </td>
                      </tr>
                      <tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">نام بانک : </span></h5>
                          </td>
                          <td style="text-align:right;width:300px;" >
                              <select style="font-size:9pt;" class="form-control" runat="server" id="optBankName">
                                  <option>انتخاب کنید</option>
                                  <option value="0">ملت</option>
                                  <option value="1">ملی</option>
                                  <option value="2">تجارت</option>
                                  <option value="3">پارسیان</option>
                                  <option value="4">پاسارگاد</option>                                  
                              </select> 
                          </td>
                          <td style="text-align:right;">
                              
                          </td>
                      </tr>
                      <tr>
                          <td style="width:110px;">
                              <h5><span class="text-left">نام صاحب حساب : </span></h5>
                          </td>
                          <td style="text-align:right;width:300px;" >
                              <div class="input-group">
                                  <span class="input-group-addon"">
                                      <input type="checkbox" onchange="javascript:AccOwner(this.checked);" id="chkAccOwner"/> خودم
                                  </span>
                                  <input runat="server" type="text" class="form-control" id="txtAccOwner"/>
                              </div>                                 
                          </td>
                          <td style="text-align:right;">
                              
                          </td>
                      </tr>
                      <tr>
                          <td>
                                <span class="text-right">تسویه حساب : </span>
                            </td>
                            <td>
                                <select style="font-size:9pt;" class="form-control" id="optSettlement" runat="server">
                                    <option value="0" selected="selected">ماهیانه</option>
                                    <option value="1">نیمه ماه (کسر 1%)</option>
                                    <option value="2">هفتگی (کسر 2%)</option>
                                    <option value="3">روزانه (کسر 5%)</option>                                    
                                  </select>                                
                            </td>
                      </tr>
                    </table>
                </div>
            </div>
            <div style="direction:ltr;" align="center">
                <recaptcha:RecaptchaControl ID="recaptcha" runat="server" PublicKey="6Lef3_sSAAAAAEPhGAILrefk5-NyuPixmOzyATo4" PrivateKey="6Lef3_sSAAAAAH1UIAaC63w082pLd9R1K31WoQ9q"/>
            </div><br />
            <div style="text-align:center;">
                <asp:Button runat="server" CssClass="btn btn-default" ID="btnSave" Text="ثبت نام" OnClick="btnSave_Click" />                
            </div>
        </div>        

        <%      }
                else if ((Encryption.Decrypt((q).Replace(' ', '+'), SharedDataInfo.SecurityKey)).Split('&')[0] == "FormSent"){ %>
                <div class="row placeholders">
                    <div class="col-xs-12 col-sm-12 placeholder">                
                        <div class="panel panel-default">
                            <div class="panel-heading">تکمیل گام نخست</div>
                            <div class="panel-body" style="text-align:center;">
                                <span class="label label-success">اطلاعات شما با موفقیت ثبت شد و ایمیلی حاوی لینک فعالسازی برای شما ارسال شده است.<br /> لطفا ادامه ی فرایند عضویت را از طریق آن لینک انجام دهید.</span>
                            </div>
                        </div>
                    </div>
                </div>

            <%  }
                else if ((Encryption.Decrypt((q).Replace(' ', '+'), SharedDataInfo.SecurityKey)).Split('&')[0] == "EmailVerified")
                { %>
        <div class="row placeholders">
            <div class="col-xs-12 col-sm-12 placeholder">                
                <div class="panel panel-default" align="center">
                    <div class="panel-heading">اعتبارسنجی شماره همراه</div>
                    <table class="table" style="width:400px;">
                        <tr>
                            <td style="text-align:center;">
                                <span class="label label-success">آدرس ایمیل شما تائید شد.</span>
                                <hr/>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align:middle;">
                                <span class="label label-info" id="lblInfo">در صورت صحت شماره همراه، آنرا تائید کنید.</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <div class="input-group" style="width:160px;">
                                    <input type="text" class="form-control" style="direction:ltr;" id="txtMobileVerification" value="<% = StrMobileNumber %>"/>
                                    <div class="input-group-btn">
                                        <button class="btn btn-default" type="button" onclick="javascript: MobileVerification();" id="btnEditNumber"><i class="glyphicon glyphicon-ok"></i></button>
                                    </div>
                                </div>
                                <hr />
                            </td>
                        </tr>                        
                        <tr>
                            <td align="center">
                                <div id="SVC">
                                <table style="width:300px;">
                                    <tr>
                                        <td>
                                            <input type="text" class="form-control" runat="server" style="direction:ltr; width:80px; height:50px; font-size:18pt;" id="txtVerificationCode"/>                                    
                                        </td>
                                        <td>
                                            <asp:Button CssClass="btn btn-success" Text="تائید" runat="server" ID="btnSubmitVerificationCode" OnClick="btnSubmitVerificationCode_Click" />
                                        </td>
                                    </tr>
                                </table>
                                </div>
                            </td>                            
                        </tr>
                    </table>
                </div>            
            </div>
        </div>
        <%      }
                else if ((Encryption.Decrypt((q).Replace(' ', '+'), SharedDataInfo.SecurityKey)).Split('&')[0] == "MobileVerified"){ %>
        <div class="row placeholders">
            <div class="col-xs-12 col-sm-12 placeholder">                
                <div class="panel panel-default">
                    <div class="panel-heading">اتمام فرایند عضویت</div>
                    <div class="panel-body" style="text-align:center;">
                        <span class="label label-success">فرایند عضویت با موفقیت به پایان رسید. <br /> تا لحظاتی دیگر بصورت خودکار وارد سیستم می شوید. در غیر اینصورت از <a href="../User/Dashboard">اینجا</a> وارد ناحیه کاربری خود شوید.</span>
                    </div>
                </div>
            </div>                    
        </div>
        <%      }
            } %>

    </div>
    <div id="mmct" runat="server" style="display:none;"><% =mmc %></div>
</asp:Content>