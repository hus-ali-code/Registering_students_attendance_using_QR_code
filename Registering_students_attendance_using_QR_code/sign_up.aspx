<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sign_up.aspx.cs" Inherits="Registering_students_attendance_using_QR_code.sign_up" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/sweetalert.css" rel="stylesheet" />
    <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/JaaAlert.js"></script>
     
    <link href="bootstrap-5.2.3-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="bootstrap-5.2.3-dist/css/all.min.css" rel="stylesheet" />
    

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

         @media only screen and (max-width: 780px)
         {
                .box-area{

                     margin: 0 10px;
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
                 .image2 {
               
             
                  }

              

         }

            .txt1{
                     text-align:center;
                  
            }

            .add_dept{
    background:#92c3f7;
    width:600px;
    height:300px;
    position:absolute;
    top:250px;
    right:550px;
    display:none;
}
 .right-box1{
             padding: 0px 0px 0px 0px;
             height:80%;
             width:80%;
         }
         
            
           
        .auto-style1 {
            direction: ltr;
        }

          @media  screen and (min-width:801px) and (max-width:1200px) 
         {
               .add_dept{

                     background:#92c3f7;
                     width:600px;
                     height:300px;
                     position:absolute;
                     top:250px;
                     right:200px;
                     display:none;

                }
                
    

         }

         
            
           
    </style>
</head>
<body>
    <form id="form1" runat="server">

      <!--___________________________________________صفحة التأكيد حساب مدير النظام_____________________________________________________________-->

        <div runat="server" id="Confirm_admin" class="d-flex justify-content-center align-items-center border rounded-5 p-3 bg-white shadow add_dept">
                 
                          <div class=" col-lg-6 col-md-12 right-box1">                     

                 <div class="row align-items-center">
                     <div class="header-text  mb-2" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>مسؤول</h2>
                     </div>

                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" Text="صيغة البريد خطأ" ControlToValidate="txt_Email_admin_PC" style="color:red;font-size:15px;direction:rtl; " ValidationGroup="G2" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                     <div class="form-group mb-1" >

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Text="*" ControlToValidate="txt_Email_admin_PC" style="color:red;font-size:30px; " ValidationGroup="G2" Display="Static"></asp:RequiredFieldValidator>
                             <asp:TextBox ID="txt_Email_admin_PC" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="البريد الاكتروني " style="display:inline-block;width:95%"></asp:TextBox>
                        
                         </div>
                   
                      <div class="form-group mb-3">
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Text="*" ControlToValidate="txt_Code_admin_PC" style="color:red;font-size:30px; " ValidationGroup="G2" Display="Static"></asp:RequiredFieldValidator>
                    
                          <asp:TextBox ID="txt_Code_admin_PC" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="رقم التحقق " style="display:inline-block;width:95%"   ></asp:TextBox>

                          </div>
                    
                      <div class="mb-2 d-flex justify-content-center align-items-center">
                      <asp:Button ID="Button4" ValidationGroup="G2" runat="server" Text="ارسال" CssClass="btn btn-lg btn-primary  fs-6 ms-2"  Style="width:65%" OnClick="btn_Confirm_admin" />

                       
                     </div>

                 </div>

            </div>

            </div>


       <!--___________________________________________________________________________________________________________________________________-->

           <!--___________________________________________صفحة التأكيد حساب استاذ_____________________________________________________________-->

        
               <div runat="server" id="Confirm_teacher" class="d-flex justify-content-center align-items-center border rounded-5 p-3 bg-white shadow add_dept">
                 
                          <div class=" col-lg-6 col-md-12 right-box1">

                                            

                 <div class="row align-items-center">
                     <div class="header-text  mb-1" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>استاذ</h2>
                     </div>
                     
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator" Text="صيغة البريد خطأ" ControlToValidate="txt_Email_teacer_PC" style="color:red;font-size:15px;direction:rtl; " ValidationGroup="G3" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                     <div class="form-group mb-2">
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Text="*" ControlToValidate="txt_Email_teacer_PC" style="color:red;font-size:30px; " ValidationGroup="G3" Display="Static"></asp:RequiredFieldValidator>
                         <asp:TextBox ID="txt_Email_teacer_PC" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="البريد الاكتروني" style="display:inline-block;width:95%"></asp:TextBox>
                           </div>


                      <div class="form-group mb-3">
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Text="*" ControlToValidate="txt_Code_teacher_PC" style="color:red;font-size:30px; " ValidationGroup="G3" Display="Static"></asp:RequiredFieldValidator>

                         <asp:TextBox ID="txt_Code_teacher_PC" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="رمز التحقق" style="display:inline-block;width:95%"></asp:TextBox>
                     </div>
                    
                  
                      <div class="mb-2 d-flex justify-content-center align-items-center">

                      <asp:Button ID="Button6" runat="server" Text="ارسال" CssClass="btn btn-lg btn-primary  fs-6 ms-2" ValidationGroup="G3"  Style="width:65%" OnClick="Button6_Click" />

                       
                     </div>

                 </div>

            </div>

            </div>



       <!--___________________________________________________________________________________________________________________________________-->


        
     <!--___________________________________________صفحة انشاء حساب خاصه بمدير النظام_____________________________________________________________-->


        <div id="admin" runat="server" >


        <!-----------------------------------main Container ----------------------------------------------->

        <div class="container d-flex justify-content-center align-items-center min-vh-100">

         <!-----------------------------------Login Container ----------------------------------------------->

        <div class="row border rounded-5 p-3 bg-white shadow box-area">

         <!-----------------------------------Leftbox----------------------------------------------->

            <div class="col-md-6 rounded-4 d-flex justify-content-center flex-column left-box align-items-center order-md-2" style="background:#103cbe;">

                <div class="auto-style1">
                    <img src="images/photo.jpg" class="img-fluid" style=" width:250px; height:170px; border-radius:10px;" />
                </div>
           
                 <div class="featured-image mb-3  img2" >
                     <img src="images/12.png" class="img-fluid image2" style=" margin-top:13px; width:300px;height:70PX; border-radius:10px;" />
                </div>

                <p class="text-white fs-2" style="font-family:'Courier New', Courier, monospace; font-weight:600; "> كلية العلوم التقنيه </p>

                <small class="text-white text-wrap text-center" style="width:17rem; font-family:Courier New, Courier, monospace;"> مرحبا بك في كليسة العلوم التقنيه سجل حضورك الان </small> 
              
            </div>
        
        <!-----------------------------------Right box ----------------------------------------------->

             <div class="col-md-6 order-md-1 right-box">

                 <div class="row align-items-center">
                     <div class="header-text  mb-4" style=" display:flex; justify-content:center; align-items:center;">
                         <h2> مسؤول</h2>
                     </div>


                    <div class="form-group mb-3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ControlToValidate="txt_Fname_admin" style="color:red;font-size:30px;" ValidationGroup="G1"></asp:RequiredFieldValidator>
                         <asp:TextBox ID="txt_Fname_admin" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1"   placeholder="الاسم الاول" style="display:inline-block;width:90%"   ></asp:TextBox>
                     </div>


                      <div class="form-group mb-3">
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*" ControlToValidate="txt_Sname_admin" style="color:red;font-size:30px;" ValidationGroup="G1"></asp:RequiredFieldValidator>
                         <asp:TextBox ID="txt_Sname_admin" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="الاسم الثاني" style="display:inline-block;width:90%" ></asp:TextBox>
                     </div>

                      <div class="form-group mb-3">
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="*" ControlToValidate="txt_Phone_admin" style="color:red;font-size:30px;" ValidationGroup="G1"></asp:RequiredFieldValidator>

                         <asp:TextBox ID="txt_Phone_admin" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="رقم الهاتف" style="display:inline-block;width:90%" MaxLength="10" ></asp:TextBox>
                     </div>


                     <div class="form-group mb-3">
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="*" ControlToValidate="txt_Email_admin" style="color:red;font-size:30px;" ValidationGroup="G1"></asp:RequiredFieldValidator>

                         <asp:TextBox ID="txt_Email_admin" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="البريد الالكتروني" style="display:inline-block;width:90%" Enabled="False" ></asp:TextBox>
                     </div>

                     

                     <div class="form-group mb-3">
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Text="*" ControlToValidate="txt_pass_admin" style="color:red;font-size:30px;" ValidationGroup="G1"></asp:RequiredFieldValidator>

                         <asp:TextBox ID="txt_pass_admin" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="كلمة المرور" style="display:inline-block;width:90%" MaxLength="10" TextMode="Password" ></asp:TextBox>
                     </div>
                     
                      <div class="form-group mb-1">
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Text="*" ControlToValidate="txt_Confirm_pass_admin" style="color:red;font-size:30px;" ValidationGroup="G1"></asp:RequiredFieldValidator>
                         <asp:TextBox ID="txt_Confirm_pass_admin" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="تأكيد كلمة المرور" style="display:inline-block;width:90%" ></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="كلمة مرور غير متطابقة" ValidationGroup="G1" ControlToCompare="txt_pass_admin" ControlToValidate="txt_Confirm_pass_admin" style="color:orangered;font-size:14px"></asp:CompareValidator>
                     </div>





                     <div class="input-group mb-5 d-flex justify-content-between">
                       
                          <div class="form-check" style="visibility:hidden;">
                             <label for="formCheck" class="form-check-label text-secondary">تذكرني</label>
                             <asp:CheckBox ID="CheckBox2" runat="server"  />
                         </div>
                         <div class="form-check">
                             <label for="formCheck" class="form-check-label text-secondary">تذكرني</label>
                             <asp:CheckBox ID="CheckBox1" runat="server"  />
                         </div>
                     </div>
                     <div class="input-group mb-3" style="direction: ltr">
                         <asp:Button ID="btn_signup_admin" runat="server" Text="دخول" ValidationGroup="G1" CssClass="btn btn-lg btn-primary w-100 fs-6" OnClick="btn_signup_admin_Click" />
                     </div>
                      <div class="input-group mb-3">
                          <asp:DropDownList ID="DropDownList1" runat="server" CssClass="btn btn-lg btn-light w-100 fs-6">
                              <asp:ListItem Value="0">حدد عضويتك</asp:ListItem>
                              <asp:ListItem Value="1">استاذ</asp:ListItem>
                              <asp:ListItem Value="2">طالب</asp:ListItem>
                              <asp:ListItem Value="3">مسؤول</asp:ListItem>
                          </asp:DropDownList>
                     </div>
                     <div class="row">
                         <small> <a href="Index.aspx">لديك حساب بالفعل ؟ </a></small>
                     </div>

                 </div>

            </div>

           </div>
        </div>


            </div>

  <!--_____________________________________________________________________________________________________________________________________________-->


   <!--___________________________________________صفحة انشاء حساب خاصه بالاستاذ_____________________________________________________________-->


        
        <div id="teacer" runat="server" >


        <!-----------------------------------main Container ----------------------------------------------->

        <div class="container d-flex justify-content-center align-items-center min-vh-100">

         <!-----------------------------------Login Container ----------------------------------------------->

        <div class="row border rounded-5 p-3 bg-white shadow box-area">

         <!-----------------------------------Leftbox----------------------------------------------->

            <div class="col-md-6 rounded-4 d-flex justify-content-center flex-column left-box align-items-center order-md-2" style="background:#103cbe;">

                <div class="featured-image mb-3  img1">
                    <img src="images/photo.jpg" class="img-fluid" style=" width:250px; height:170px; border-radius:10px;" />
                </div>
           
                 <div class="featured-image mb-3  img2" >
                     <img src="images/12.png" class="img-fluid image2" style=" margin-top:13px; width:300px;height:70PX; border-radius:10px;" />
                </div>

                <p class="text-white fs-2" style="font-family:'Courier New', Courier, monospace; font-weight:600; "> كلية العلوم التقنيه </p>

                <small class="text-white text-wrap text-center" style="width:17rem; font-family:Courier New, Courier, monospace;"> مرحبا بك في كليسة العلوم التقنيه سجل حضورك الان </small> 
              
            </div>
        
        <!-----------------------------------Right box ----------------------------------------------->

             <div class="col-md-6 order-md-1 right-box">

                 <div class="row align-items-center">
                     <div class="header-text  mb-4" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>استاذ</h2>
                     </div>
                     <div class="form-group mb-3">
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Text="*" ControlToValidate="txt_Fname_teacher" style="color:red;font-size:30px;" ValidationGroup="G4"></asp:RequiredFieldValidator>
                         <asp:TextBox ID="txt_Fname_teacher" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="الاسم الاول" style="display:inline-block;width:90%"></asp:TextBox>
                     </div>


                      <div class="form-group mb-3">
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" Text="*" ControlToValidate="txt_Sname_teacher" style="color:red;font-size:30px;" ValidationGroup="G4"></asp:RequiredFieldValidator>
                         <asp:TextBox ID="txt_Sname_teacher" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="الاسم الثاني" style="display:inline-block;width:90%"></asp:TextBox>
                     </div>

                      <div class="form-group mb-3">
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" Text="*" ControlToValidate="txt_Phone_teacher" style="color:red;font-size:30px;" ValidationGroup="G4"></asp:RequiredFieldValidator>
                         <asp:TextBox ID="txt_Phone_teacher" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="رقم الهاتف" style="display:inline-block;width:90%"></asp:TextBox>
                     </div>

                     <div class="form-group mb-3">
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" Text="*" ControlToValidate="txt_Email_teacher" style="color:red;font-size:30px;" ValidationGroup="G4"></asp:RequiredFieldValidator>
                         <asp:TextBox ID="txt_Email_teacher" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="البريد الالكتروني" Enabled="False" style="display:inline-block;width:90%"></asp:TextBox>
                     </div>


                     <div class="form-group mb-3">
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" Text="*" ControlToValidate="txt_pass_teacher" style="color:red;font-size:30px;" ValidationGroup="G4"></asp:RequiredFieldValidator>
                         <asp:TextBox ID="txt_pass_teacher" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="كلمة المرور" style="display:inline-block;width:90%" MaxLength="10" TextMode="Password"></asp:TextBox>
                     </div>
                     
                      <div class="form-group mb-1">
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" Text="*" ControlToValidate="txt_Confirm_pass_teacher" style="color:red;font-size:30px;" ValidationGroup="G4"></asp:RequiredFieldValidator>
                         <asp:TextBox ID="txt_Confirm_pass_teacher" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="تأكيد كلمة المرور" style="display:inline-block;width:90%;"></asp:TextBox>
                       
                          <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="كلمة مرور غير متطابقة" ValidationGroup="G4" ControlToCompare="txt_pass_teacher" ControlToValidate="txt_Confirm_pass_teacher" style="color:orangered;font-size:14px"></asp:CompareValidator>                    
                          
                      </div>





                     <div class="input-group mb-5 d-flex justify-content-between">
                       
                          <div class="form-check" style="visibility:hidden;">
                             <label for="formCheck" class="form-check-label text-secondary">تذكرني</label>
                             <asp:CheckBox ID="CheckBox3" runat="server"  />
                         </div>
                         <div class="form-check">
                             <label for="formCheck" class="form-check-label text-secondary">تذكرني</label>
                             <asp:CheckBox ID="CheckBox4" runat="server"  />
                         </div>
                     </div>
                     <div class="input-group mb-3">
                         <asp:Button ID="btn_signup_Teacher" runat="server" Text="دخول" CssClass="btn btn-lg btn-primary w-100 fs-6" ValidationGroup="G4" OnClick="btn_signup_Teacher_Click" />
                     </div>
                      <div class="input-group mb-3">
                          <asp:DropDownList ID="DropDownList2" runat="server" CssClass="btn btn-lg btn-light w-100 fs-6">
                              <asp:ListItem Value="0">حدد عضويتك</asp:ListItem>
                              <asp:ListItem Value="1">استاذ</asp:ListItem>
                              <asp:ListItem Value="2">طالب</asp:ListItem>
                              <asp:ListItem Value="3">مسؤول</asp:ListItem>
                          </asp:DropDownList>
                     </div>
                     <div class="row">
                         <small> <a href="Index.aspx">لديك حساب بالفعل ؟ </a></small>
                     </div>

                 </div>

            </div>

           </div>
        </div>


            </div>

  <!--_____________________________________________________________________________________________________________________________________________-->



    </form>
</body>
</html>
