<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Registering_students_attendance_using_QR_code.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

        <link href="Styles/sweetalert.css" rel="stylesheet" />
        <script src="Scripts/sweetalert.min.js"></script>
         <script src="Scripts/JaaAlert.js"></script>

     <link href="bootstrap-5.2.3-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="bootstrap-5.2.3-dist/css/all.min.css" rel="stylesheet" />
    <link href="bootstrap-5.1.3-dist/css/all.min.css" rel="stylesheet" />

    <style>

        body{
            background:#ececec;

        }
         .img2{
                    visibility:hidden;
                    height:0;
                }
        /*--------------------------------------Login container-----------------------------------*/
        .box-area
        {
            width:930px;
        }

         /*--------------------------------------Right box------------------------------------------*/

         .right-box{
             padding: 40px 30px 40px 40px;
         }
         
         /*--------------------------------------Left box--------------------------------------------*/


        
         
         /*--------------------------------------Custom Placeholder-----------------------------------*/
         
         ::placeholder{
             font-size:16px;
             text-align:center;
         }

         /*--------------------------------------for small screens----------------------------------*/

         @media  screen and (min-width:801px) and (max-width:1200px) 
         {
                .box-area{

                     margin: 0 10px;
                     width:80%;
                     height:700px;
                }
                
                .left-box{
                    height:100px;
                    overflow:hidden;

                }
                .right-box{
                    padding: 20px;
                }
                .img1{
                    visibility:hidden;
                }
                 .img2{
                    visibility:visible;
                    position:absolute;
              
                    display:flex;
                    justify-content:center;
                    align-items:center;

                    
               
                }
                 h2 {
               margin-bottom:0.5rem;
             
                  }

              

         }

            .txt1{
                     text-align:center;
                     margin-bottom:0.5rem;
            }
           
            
           
    </style>
</head>
<body>
    <form id="form1" runat="server">



       
    <!--_____________________________________________________________ صفحة تسجيل  الخاصه بمدير النظام______________________________________________________________________________________-->
        

        <div id="admin" runat="server">
        <!-----------------------------------main Container ----------------------------------------------->

        <div class="container d-flex justify-content-center align-items-center min-vh-100 " >

         <!-----------------------------------Login Container ----------------------------------------------->

        <div class="row border rounded-5 p-3 bg-white shadow box-area">

         <!-----------------------------------Leftbox----------------------------------------------->

            <div class=" col-lg-6 col-md-12 rounded-4 d-flex justify-content-center flex-column left-box align-items-center" style="background:#103cbe;">

                <div class="featured-image mb-3  img1">
                    <img  src="images/photo.jpg" class="img-fluid" style=" width:250px; height:170px; border-radius:10px;" />
                </div>
              
                 <div class="featured-image mb-3  img2" >
                     <img src="images/12.png" class="img-fluid image2" style=" margin-top:13px; width:300px;height:70PX; border-radius:10px;" />
                </div>

                <p class="text-white fs-2" style="font-family:'Courier New', Courier, monospace; font-weight:600; "> كلية العلوم التقنيه </p>

                <small class="text-white text-wrap text-center" style="width:17rem; font-family:Courier New, Courier, monospace;"> مرحبا بك في كليسة العلوم التقنيه سجل حضورك الان </small> 
              
            </div>
        
        <!-----------------------------------Right box ----------------------------------------------->

             <div class=" col-lg-6 col-md-12 right-box">

                 <div class="row align-items-center">
                     <div class="header-text  mb-4" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>مدير النظام</h2>
                     </div>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator" Text="صيغة البريد خطأ" ControlToValidate="txt_Email_Admin" style="color:red;font-size:15px;direction:rtl; " ValidationGroup="G1" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                     <div class="form-group mb-3">     
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Text="*" ControlToValidate="txt_Email_Admin" style="color:red;font-size:30px;" ValidationGroup="G1"></asp:RequiredFieldValidator>
                         <asp:TextBox ID="txt_Email_Admin" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder=" البريد الالكتروني" style="display:inline-block;width:95%"></asp:TextBox>
                     </div>
                      <div class="form-group mb-1">
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ControlToValidate="txt_pass_Admin" style="color:red;font-size:30px;" ValidationGroup="G1"></asp:RequiredFieldValidator>

                         <asp:TextBox ID="txt_pass_Admin" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="  كلمة المرور" style="display:inline-block;width:95%"></asp:TextBox>
                     </div>
                     <div class="input-group mb-5 d-flex justify-content-between">
                         
                         <div class="forgot">
                             <small><a href="#"> هل نسيت كلمة السر</a></small>
                         </div>
                         <div class="input-check">
                             <label for="formCheck" class="form-check-label text-secondary">تذكرني</label>
                             <asp:CheckBox ID="CheckBox1" runat="server"  />
                         </div>
                     </div>
                     <div class="input-group mb-3">
                         <asp:Button ID="Btn_Login_Admin" runat="server" Text="دخول" CssClass="btn btn-lg btn-primary w-100 fs-6" OnClick="Btn_Login_Admin_Click" ValidationGroup="G1"  />
                     </div>
                      <div class="input-group mb-3">
                          <asp:DropDownList ID="DropDownList1" runat="server" CssClass="btn btn-lg btn-light w-100 fs-6" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                              <asp:ListItem Value="0">حدد عضويتك</asp:ListItem>
                              <asp:ListItem Value="1"> مسؤول </asp:ListItem>
                              <asp:ListItem Value="2"> استاذ</asp:ListItem>
                              <asp:ListItem Value="3">طالب</asp:ListItem>
                          </asp:DropDownList>
                     </div>
                     <div class="row">
                        <small> <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">ليس لديك حساب ؟</asp:LinkButton></small>
                     </div>

                 </div>

            </div>

           </div>
        </div>
        </div>
        <!--_________________________________________________________________________________________________________________________________________________________________-->


        <!--_____________________________________________________________ صفحة تسجيل  الخاصه الاستاذ______________________________________________________________________________________-->

        
        <div id="teacher" runat="server">
        <!-----------------------------------main Container ----------------------------------------------->

        <div class="container d-flex justify-content-center align-items-center min-vh-100 " >

         <!-----------------------------------Login Container ----------------------------------------------->

        <div class="row border rounded-5 p-3 bg-white shadow box-area">

         <!-----------------------------------Leftbox----------------------------------------------->

            <div class=" col-lg-6 col-md-12 rounded-4 d-flex justify-content-center flex-column left-box align-items-center" style="background:#103cbe;">

                <div class="featured-image mb-3  img1">
                    <img  src="images/photo.jpg" class="img-fluid" style=" width:250px; height:170px; border-radius:10px;" />
                </div>
              
                 <div class="featured-image mb-3  img2" >
                     <img src="images/12.png" class="img-fluid image2" style=" margin-top:13px; width:300px;height:70PX; border-radius:10px;" />
                </div>

                <p class="text-white fs-2" style="font-family:'Courier New', Courier, monospace; font-weight:600; "> كلية العلوم التقنيه </p>

                <small class="text-white text-wrap text-center" style="width:17rem; font-family:Courier New, Courier, monospace;"> مرحبا بك في كليسة العلوم التقنيه سجل حضورك الان </small> 
              
            </div>
        
        <!-----------------------------------Right box ----------------------------------------------->

             <div class=" col-lg-6 col-md-12 right-box">

                 <div class="row align-items-center">
                     <div class="header-text  mb-4" style=" display:flex; justify-content:center; align-items:center;">
                         <h2> الاستاذ </h2>
                     </div>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" Text="صيغة البريد خطأ" ControlToValidate="txt_Email_Teacher" style="color:red;font-size:15px;direction:rtl; " ValidationGroup="G2" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                     <div class="form-group mb-3">
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*" ControlToValidate="txt_Email_Teacher" style="color:red;font-size:30px;" ValidationGroup="G2"></asp:RequiredFieldValidator>
                         <asp:TextBox ID="txt_Email_Teacher" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="البريد الالكتروني" style="display:inline-block;width:95%"></asp:TextBox>
                     </div>
                      <div class="form-group mb-1">
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="*" ControlToValidate="txt_Pass_teacher" style="color:red;font-size:30px;" ValidationGroup="G2"></asp:RequiredFieldValidator>

                         <asp:TextBox ID="txt_Pass_Teacher" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="كلمة المرور"  style="display:inline-block;width:95%"></asp:TextBox>
                     </div>
                     <div class="input-group mb-5 d-flex justify-content-between">
                         
                         <div class="forgot">
                             <small><a href="#"> هل نسيت كلمة السر</a></small>
                         </div>
                         <div class="form-check">
                             <label for="formCheck" class="form-check-label text-secondary">تذكرني</label>
                             <asp:CheckBox ID="CheckBox2" runat="server"  />
                         </div>
                     </div>
                     <div class="input-group mb-3">
                         <asp:Button ID="Btn_Login_Teacher" runat="server" Text="دخول" CssClass="btn btn-lg btn-primary w-100 fs-6" ValidationGroup="G2" OnClick="Btn_Login_Teacher_Click"  />
                     </div>
                      <div class="input-group mb-3">

                          <asp:DropDownList ID="DropDownList2" runat="server" CssClass="btn btn-lg btn-light w-100 fs-6" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True" >
                              <asp:ListItem Value="0">حدد عضويتك</asp:ListItem>
                              <asp:ListItem Value="1">مسؤول</asp:ListItem>
                              <asp:ListItem Value="2"> استاذ</asp:ListItem>
                              <asp:ListItem Value="3">طالب</asp:ListItem>
                          </asp:DropDownList>
                     </div>
                     <div class="row">
                       <small><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">ليس لديك حساب ؟</asp:LinkButton></small>
                     </div>

                 </div>

            </div>

           </div>
        </div>
        </div>
        <!--_________________________________________________________________________________________________________________________________________________________________-->

         <!--_____________________________________________________________ صفحة تسجيل  الخاصه الطالب______________________________________________________________________________________-->

        
        <div id="student" runat="server">
        <!-----------------------------------main Container ----------------------------------------------->

        <div class="container d-flex justify-content-center align-items-center min-vh-100 " >

         <!-----------------------------------Login Container ----------------------------------------------->

        <div class="row border rounded-5 p-3 bg-white shadow box-area">

         <!-----------------------------------Leftbox----------------------------------------------->

            <div class=" col-lg-6 col-md-12 rounded-4 d-flex justify-content-center flex-column left-box align-items-center" style="background:#103cbe;">

                <div class="featured-image mb-3  img1">
                    <img  src="images/photo.jpg" class="img-fluid" style=" width:250px; height:170px; border-radius:10px;" />
                </div>
              
                 <div class="featured-image mb-3  img2" >
                     <img src="images/12.png" class="img-fluid image2" style=" margin-top:13px; width:300px;height:70PX; border-radius:10px;" />
                </div>

                <p class="text-white fs-2" style="font-family:'Courier New', Courier, monospace; font-weight:600; "> كلية العلوم التقنيه </p>

                <small class="text-white text-wrap text-center" style="width:17rem; font-family:Courier New, Courier, monospace;"> مرحبا بك في كليسة العلوم التقنيه سجل حضورك الان </small> 
              
            </div>
        
        <!-----------------------------------Right box ----------------------------------------------->

             <div class=" col-lg-6 col-md-12 right-box">

                 <div class="row align-items-center">
                     <div class="header-text  mb-4" style=" display:flex; justify-content:center; align-items:center;">
                         <h2> الطالب</h2>
                     </div>
                     <div class="from-group mb-3">
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="*" ControlToValidate="txt_Number_Student" style="color:red;font-size:30px;" ValidationGroup="G3"></asp:RequiredFieldValidator>
                         <asp:TextBox ID="txt_Number_Student" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="ادخل رقم القيد"  style="display:inline-block;width:95%"></asp:TextBox>
                     </div>
                      <div class="from-group mb-1">
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Text="*" ControlToValidate="txt_NAT_Student" style="color:red;font-size:30px;" ValidationGroup="G3"></asp:RequiredFieldValidator>
                         <asp:TextBox ID="txt_NAT_Student" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="ادخل رقم الوطني"  style="display:inline-block;width:95%"></asp:TextBox>
                     </div>
                     <div class="input-group mb-5 d-flex justify-content-between">
                         
                         <div class="forgot" style="visibility:hidden;">
                             <small><a href="#"> هل نسيت كلمة السر</a></small>
                         </div>
                         <div class="form-check">
                             <label for="formCheck" class="form-check-label text-secondary">تذكرني</label>
                             <asp:CheckBox ID="CheckBox3" runat="server"  />
                         </div>
                     </div>
                     <div class="input-group mb-3">
                         <asp:Button ID="Btn_Login_Student" ValidationGroup="G3" runat="server" Text="دخول" CssClass="btn btn-lg btn-primary w-100 fs-6"  />
                     </div>
                      <div class="input-group mb-3">
                          <asp:DropDownList ID="DropDownList3" runat="server" CssClass="btn btn-lg btn-light w-100 fs-6" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="True">
                              <asp:ListItem Value="0">حدد عضويتك</asp:ListItem>
                              <asp:ListItem Value="1"> مسؤول</asp:ListItem>
                              <asp:ListItem Value="2"> استاذ</asp:ListItem>
                              <asp:ListItem Value="3">طالب</asp:ListItem>
                          </asp:DropDownList>
                     </div>
                   

                 </div>

            </div>

           </div>
        </div>
        </div>
        <!--_________________________________________________________________________________________________________________________________________________________________-->
        
    </form>
</body>
</html>
