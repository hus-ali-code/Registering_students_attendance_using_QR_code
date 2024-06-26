<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true"  CodeBehind="Create_QR_Teacher.aspx.cs" Inherits="Registering_students_attendance_using_QR_code.create_QR_teacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="bootstrap-5.2.3-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="bootstrap-5.2.3-dist/css/all.min.css" rel="stylesheet" />
    <link href="bootstrap-5.1.3-dist/css/all.min.css" rel="stylesheet" />

 <style>


      @media  screen and (min-width:801px) and (max-width:1200px) 
         {
                .Choose_Course{

                     background:#92c3f7;
                     width:600px;
                     height:300px;
                     position:relative;
                     top:150px;
                     right:200px;
                     display:none;

                }
                .Choose_Hall{
                     background:#92c3f7;
                     width:600px;
                     height:350px;
                      position:relative;
                     top:150px;
                     right:200px;
                     display:none;
               }

                .Confirm{

                     background:#92c3f7;
                     width:600px;
                     height:450px;
                      position:relative;
                     top:150px;
                     right:200px;
                     display:none;

                }
                .Choose_Time_L{

                     background:#92c3f7;
                     width:600px;
                     height:500px;
                      position:relative;
                     top:150px;
                     right:200px;
                     display:none;

                
                }
               .QR{

                    width: 100%;
  margin: 85px 0;
  position: absolute;
  top: auto;

                }

                .pre{

                    width:20%;

                } 
                  .right-box{
            padding: 0px 0px 0px 0px;
             height:80%;
             width:80%;

         }

                
    

         }



       .Choose_Time_L{

                    
                     height:500px;
                     

                
                }
     


 .right-box{
            padding: 0px 0px 0px 0px;
             height:80%;
             width:80%;

         }

 
         .C1 {
  cursor: pointer;
}

.C1 input {
  display: none;
}

.C1 svg {
  overflow: visible;
}

.path {
  fill: none;
  stroke:black;
  stroke-width: 6;
  stroke-linecap: round;
  stroke-linejoin: round;
  transition: stroke-dasharray 0.5s ease, stroke-dashoffset 0.5s ease;
  stroke-dasharray: 241 9999999;
  stroke-dashoffset: 0;
}

.C1 input:checked ~ svg .path {
  stroke-dasharray: 70.5096664428711 9999999;
  stroke-dashoffset: -262.2723388671875;
}

#pagingDiv , #pagingDiv span, #pagingDiv a{
    margin:10px;
}

     .Reg_S {
        border:solid 2px #444;
            overflow:auto;
            height:700px;
            margin-bottom:10px;
                        
     }       


  </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="Div_QR_Code_Page" runat="server" class="row QR">
  <div id="qrCodeContainer" class="col-sm-12 col-lg-5 border">
    <h3 style=" display:flex; justify-content:center; align-items:center;" >مسح الرمز للحضور</h3>
      <p style=" display:flex; justify-content:center; align-items:center;" class="align-middle">
          <asp:Image ID="Image1" runat="server"  Visible="false" style="width:360px;height:310px;" />
          <img src="images/QR_Collge.jpeg" id="def_img" runat="server"  style="width:310px;height:280px;" />

     </p>
  </div>

  <!-------------------------------------------------------------------------------------------------------------------------------------------------------- -->

         
      <!--------------------------------------------------------------------------------تسجيل الحضور يدوي---------------------------------------------- -->

      <div class="col-sm-12 col-lg-6 Reg_S" runat="server" id="Div_Reg_Static">
        <h3 class="d-flex justify-content-center align-content-center">تسجيل الحضور يدوي</h3>
      
         <div  style="display:inline-flex;float:left;width:70%; margin-bottom:8PX; margin-top:8PX;">
           
                     <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-outline-primary m-0 "  style="display:inline-block;width:9%;height:36px;border-bottom-right-radius:20px;border-top-right-radius:20px;border-top-left-radius:0;border-bottom-left-radius:0;" OnClick="LinkButton2_Click"><i class="fa-solid fa-magnifying-glass" style="font-size:18px;border-rad"></i></asp:LinkButton>
                      <asp:TextBox ID="txt_Searsh_Student" runat="server"  placeholder="بحث بالاسم او رقم القيد" class="form-control form-control-sm sm-light border-primary m-0  txt1"  style="display:inline-block;width:50%;height:35px;border-bottom-right-radius:0;border-top-right-radius:0;border-top-left-radius:20px;border-bottom-left-radius:20px;text-align:center;border-right:0;" Font-Bold="false" Font-Size="13"></asp:TextBox>

                    </div>
          <table class="table table-striped table-hover">
           
                <asp:Repeater ID="Repeater_Stu" runat="server">
        <HeaderTemplate>
                <tr  Class="table-dark text-center" style="font-size:18pt;font-weight:bold">
                    <th> الصورة </th>
                    <th>الاسم</th>
                     <th>تسجيل الحضور</th>
                    <th>سجل الطالب</th>
                
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
          <tr class="text-center align-middle" style="font-size:15pt; font-weight:bold">
        <td class="m-0 p-0 text-center">
            <img src='<%# Eval("Photo") %>' style="width:100px; height:120px;" />
        </td>
        <td ><%# Eval("Student_Fname") %> <%# Eval("Student_Sname") %> <%# Eval("Student_Lname") %> </td>


                <td>
                 <label class="C1">
              <asp:CheckBox ID="CheckBox1" runat="server"    />
      <svg viewBox="0 0 64 64" height="1.5em" width="1.5em">
        <path d="M 0 16 V 56 A 8 8 90 0 0 8 64 H 56 A 8 8 90 0 0 64 56 V 8 A 8 8 90 0 0 56 0 H 8 A 8 8 90 0 0 0 8 V 16 L 32 48 L 64 16 V 8 A 8 8 90 0 0 56 0 H 8 A 8 8 90 0 0 0 8 V 56 A 8 8 90 0 0 8 64 H 56 A 8 8 90 0 0 64 56 V 16" pathLength="575.0541381835938" class="path"></path>
      </svg>
    </label>
    </td>

   
        <td >
            <asp:LinkButton ID="LinkButton1" Class="btn btn-outline-success" style="font-size:15pt;font-weight:bold" runat="server" PostBackUrl="#">
                <i class="fa-solid fa-sheet-plastic">&nbsp; سجل الطالب </i>
            </asp:LinkButton>
        </td>

    </tr>
        </ItemTemplate>

    </asp:Repeater>
                  <tr>
                       <td><div id="pagingDiv" runat="server"></div></td>

                      </tr>

            </table>

          <p runat="server" class="text-center align-middle" id="P_Searsh" style="font-size:x-large">تسجيل يدوي !! ابحث عن الطالب ؟</p>
         
      </div>

              <!------------------------------------------------------------------------------------------------------------------------------------------ -->

            <!-----------------------------------------------------------   اختر المادة  ----------------------------------------------------------------------------------------------->

              <div runat="server" id="Div_Choose_Course" class="col-sm-12 col-lg-7 d-flex justify-content-center align-items-center border  p-3 bg-white shadow Choose_Course">
                 
                          <div class=" col-lg-6 col-md-12 right-box">

                  
                 <div class="row align-items-center">

                     <div class="header-text  mb-2" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>اختر المادة</h2>
                     </div>
                    
                     <div class="from-group mb-3 mt-2"  style=" display:flex; justify-content:center; align-items:center;">
                          <asp:DropDownList ID="DDL_Choose_Course"  CssClass="form-control-lg bg-light fs-6 ms-2 txt1" style="display:inline-block;width:60%" runat="server" AutoPostBack="false"></asp:DropDownList>
                                           <asp:Label ID="Label1" runat="server" Style="color:red;font-size:35px;" Visible="false"  Text="*"></asp:Label>

                    </div>


                 </div>

                      <div class="from-group mb-2" style=" display:flex; justify-content:center; align-items:center;">
                       
                          <asp:LinkButton ID="LinkButton7" CssClass="btn btn-lg btn-outline-success fs-6 ms-2" style="width:20%"  runat="server" OnClick="Button1_Click"> <i class="fa-solid fa-circle-chevron-right" style="font-size:20px;font-weight:bold;">&nbsp; السابق</i></asp:LinkButton>
                         <asp:LinkButton ID="LinkButton8" CssClass="btn btn-lg btn-outline-success fs-6 ms-2" style="width:20%"  runat="server" OnClick="Button6_Click">&nbsp; التالي <i class="fa-solid fa-circle-chevron-left" style="font-size:20px;font-weight:bold;"></i></asp:LinkButton>

                          
                      
                      </div>

                 </div>

            </div>

        
            <!----------------------------------------------------------------------------------------------------------------------------------------------------------------->

          <!-----------------------------------------------------------   اختر القاعة  ----------------------------------------------------------------------------------------------->

              <div runat="server" id="Div_Choose_Hall" class="col-sm-12 col-lg-7 d-flex justify-content-center align-items-center border rounded-5 p-3 bg-white shadow Choose_Hall">
                 
                          <div class=" col-lg-6 col-md-12 right-box">

                  
                 <div class="row align-items-center">

                     <div class="header-text  mb-2" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>اختر القاعة</h2>
                     </div>

                      <div class="from-group mb-2" style=" display:flex; justify-content:center; align-items:center;">
                          <asp:Button ID="Button4" runat="server" Text="بحث" CssClass="btn btn-lg btn-success fs-6 ms-2" Style="width:13%" OnClick="Button4_Click" />
                          <asp:TextBox ID="txt_Searsh_Hall" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" Placeholder="بحث..." style="display:inline-block;width:30%"></asp:TextBox>
                     </div>


                     <div class="from-group mb-3" style=" display:flex; justify-content:center; align-items:center;">
                          <asp:DropDownList ID="DDL_Choose_Hall"  CssClass="form-control-lg bg-light ms-2 fs-6 txt1" style="display:inline-block;width:60%" runat="server"></asp:DropDownList>
                                                         <asp:Label ID="Label2" runat="server" Style="color:red;font-size:35px;" Visible="false"  Text="*"></asp:Label>

                         </div>


                 </div>

                      <div class="from-group mb-2" style=" display:flex; justify-content:center; align-items:center;">
              
                         <asp:LinkButton ID="LinkButton5" CssClass="btn btn-lg btn-outline-success fs-6 ms-2" style="width:20%"  runat="server" OnClick="Button2_Click"> <i class="fa-solid fa-circle-chevron-right" style="font-size:20px;font-weight:bold;">&nbsp; السابق</i></asp:LinkButton>
                         <asp:LinkButton ID="LinkButton6" CssClass="btn btn-lg btn-outline-success fs-6 ms-2" style="width:20%"  runat="server" OnClick="Button3_Click">&nbsp; التالي <i class="fa-solid fa-circle-chevron-left" style="font-size:20px;font-weight:bold;"></i></asp:LinkButton>

                      
                      </div>

                 </div>

            </div>


            <!----------------------------------------------------------------------------------------------------------------------------------------------------------------->

         <!-----------------------------------------------------------  QR تأكيد بيانات ال   ----------------------------------------------------------------------------------------------->

              <div runat="server" id="Div_Confirm" class="col-sm-12 col-lg-7 d-flex justify-content-center align-items-center border rounded-5 p-3 bg-white shadow Confirm">
                 
                          <div class=" col-lg-6 col-md-12 right-box">

                 <div class="row align-items-center" runat="server">

                     

                     <div class="header-text  mb-2" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>تأكيد البيانات</h2>
                     </div>

                      <div class="from-group mb-2" style=" display:flex; justify-content:center; align-items:center;">
                          <h5 class="mb-0" style="display:inline-block;width:20%; ">المادة :</h5>  <asp:TextBox ID="txt_CF_Cou" runat="server" ReadOnly="true" CssClass="form-control form-control-lg bg-light fs-6 txt1" style="display:inline-block;width:45%"></asp:TextBox>
                     </div>


                     <div class="from-group mb-2" style=" display:flex; justify-content:center; align-items:center;">
                          <h5 class="mb-0" style="display:inline-block;width:20%">القاعة : </h5>  <asp:TextBox ID="txt_CF_Hall" runat="server" ReadOnly="true" CssClass="form-control form-control-lg bg-light fs-6 txt1" style="display:inline-block;width:45%"></asp:TextBox>
                     </div>

                     <div class="from-group mb-3" style=" display:flex; justify-content:center; align-items:center;">
                         <h5 class="mb-0" style="display:inline-block;width:20%">وقت وتاريخ المحاضرة :</h5> 
                         <asp:TextBox ID="txt_Date" runat="server" Enabled="false" CssClass="form-control form-control-lg bg-light fs-6 txt1" style="display:inline-block;width:22.5%"></asp:TextBox>
                         <asp:TextBox ID="txt_Time" runat="server" Enabled="false" CssClass="form-control form-control-lg bg-light fs-6 me-2 txt1" style="display:inline-block;width:22.5%"></asp:TextBox>

                     </div>



                 </div>

                      <div class="from-group mb-2" style=" display:flex; justify-content:center; align-items:center;">
                            <asp:LinkButton ID="LinkButton4" CssClass="btn btn-lg btn-outline-success fs-6 ms-2" style="width:19%"  runat="server" OnClick="Button7_Click"> <i class="fa-solid fa-circle-chevron-right" style="font-size:20px;font-weight:bold;">&nbsp; السابق</i></asp:LinkButton>
                           <asp:LinkButton ID="LinkButton3" CssClass="btn btn-lg btn-outline-success fs-6 ms-2" style="width:33%"  runat="server" OnClick="LinkButton3_Click"> <i class="fa-solid fa-calendar-days" style="font-size:20px;font-weight:bold;">&nbsp; تغيير الوقت والتريخ</i></asp:LinkButton>
                           <asp:LinkButton ID="btn_Confirm" CssClass="btn btn-lg btn-outline-success fs-6 ms-2" style="width:19%"  runat="server" OnClick="btn_Confirm_Click" > <i class="fa-regular fa-circle-check" style="font-size:20px;font-weight:bold;">&nbsp; تأكيد</i></asp:LinkButton>
                        

                      
                     </div>

                 </div>

            </div>
     

            <!----------------------------------------------------------------------------------------------------------------------------------------------------------------->

             <!-----------------------------------------------------------  ختيار موعد المحاضرة  ----------------------------------------------------------------------------------------------->

              <div runat="server" id="Div_Chose_Time_L" visible="false" class="col-sm-12 col-lg-7 d-flex justify-content-center align-items-center border rounded-5 p-3 bg-white shadow Choose_Time_L">
                 
                          <div class=" col-lg-6 col-md-12 right-box">

                 <div class="row text-center align-middle" runat="server" id="div2">

                     

                     <div class="header-text  mb-2" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>اختيار موعد المحاضرة</h2>
                     </div>

                          <div class="text-center align-middle"  runat="server">

                <asp:Calendar ID="calDatePicker" runat="server" Style="position:relative;right:33%;"  ></asp:Calendar>
                <br />
                  <asp:DropDownList ID="ddlMinutes" runat="server"></asp:DropDownList>
                :
                  <asp:DropDownList ID="ddlHours" runat="server"></asp:DropDownList>

                     </div>



                 </div>

                      <div class="from-group mb-2 mt-4" style=" display:flex; justify-content:center; align-items:center;">
                        
                           <asp:LinkButton ID="btnCancel" CssClass="btn btn-lg btn-outline-danger fs-6 ms-2" style="width:20%"  runat="server" OnClick="btnCancel_Click"> <i class="fa-solid fa-circle-chevron-right" style="font-size:20px;font-weight:bold;">&nbsp; الغاء</i></asp:LinkButton>
                         <asp:LinkButton ID="btnConfirm_change" CssClass="btn btn-lg btn-outline-success fs-6 ms-2" style="width:20%"  runat="server" OnClick="btnConfirm_change_Click"><i class="fa-solid fa-retweet" style="font-size:20px;font-weight:bold;">&nbsp; تغيير الموعد </i></asp:LinkButton>


                     </div>

                 </div>

            </div>
     

            <!----------------------------------------------------------------------------------------------------------------------------------------------------------------->





</div>



        

</asp:Content>
