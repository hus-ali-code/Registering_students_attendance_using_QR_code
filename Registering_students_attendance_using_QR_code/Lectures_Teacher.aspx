<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="Lectures_Teacher.aspx.cs" Inherits="Registering_students_attendance_using_QR_code.Lectures_Teacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
            height:620px;
            margin-bottom:10px;
                        
     }  
     .border0{
                 border:solid 2px #444;

     }


  </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
       <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div id="Div1" runat="server" class="row">
    <div class="col-12">
        <asp:LinkButton ID="LinkButton1" runat="server" Visible="false" PostBackUrl="~/Home_Teacher.aspx" style="width:15%;" CssClass="btn btn-outline-danger  mb-1 mt-1"><i class="fa-solid fa-arrow-right fs-4">   انهاء التسجيل</i></asp:LinkButton>
    </div>
</div>


      

    <div id="Div_QR_Code_Page" runat="server" class="row QR">

  <!-------------------------------------------------------------------------------------------------------------------------------------------------------- -->

           <div id="qrCodeContainer" runat="server" class="col-sm-12 col-lg-5 border0">
                          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
                  <asp:Timer ID="Timer1" runat="server" Interval="5000"  OnTick="Timer1_Tick" >
                  </asp:Timer>
                         
            <h3 style="display:flex; justify-content:center; align-items:center;">مسح الرمز للحضور</h3>
            <p style="display:flex; justify-content:center; align-items:center;" class="align-middle">
                <asp:Image ID="Image2" runat="server" style="width:360px;height:310px;"/>
            </p>
              </ContentTemplate>
      </asp:UpdatePanel>
        </div>

        <!-- تسجيل الحضور يدوي -->
        <div class="col-sm-12 col-lg-7 container Reg_S"  runat="server" id="Reg_S">
            <h3 class="d-flex justify-content-center align-content-center">تسجيل الحضور يدوي</h3>
            <div style="display:inline-flex;float:left;width:70%; margin-bottom:8PX; margin-top:8PX;">
                <asp:LinkButton ID="LinkButton9" runat="server" class="btn btn-outline-primary m-0 " style="display:inline-block;width:9%;height:36px;border-bottom-right-radius:20px;border-top-right-radius:20px;border-top-left-radius:0;border-bottom-left-radius:0;" OnClick="LinkButton2_Click"><i class="fa-solid fa-magnifying-glass" style="font-size:18px;border-rad"></i></asp:LinkButton>
                <asp:TextBox ID="txt_Searsh_Student" runat="server" placeholder="بحث بالاسم او رقم القيد" class="form-control form-control-sm sm-light border-primary m-0  txt1" style="display:inline-block;width:50%;height:35px;border-bottom-right-radius:0;border-top-right-radius:0;border-top-left-radius:20px;border-bottom-left-radius:20px;text-align:center;border-right:0;" Font-Bold="false" Font-Size="13"></asp:TextBox>
            </div>
            <table class="table table-striped table-hover">
                <asp:Repeater ID="Repeater_Stu" runat="server" OnItemCommand="Repeater_Stu_ItemCommand">
                    <HeaderTemplate>
                        <tr Class="table-dark text-center" style="font-size:12pt;font-weight:bold">
                            <th> الصورة </th>
                            <th>الاسم</th>
                            <th>تسجيل الحضور</th>
                            <th>الغاء الحضور</th>
                            <th>سجل الطالب</th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="text-center align-middle" style="font-size:15pt; font-weight:bold">
                            <td class="m-0 p-0 text-center">
                                <img src='<%# Eval("Photo") %>' style="width:100px; height:120px;" />
                            </td>
                            <asp:Label ID="Label1" Visible="false" runat="server" Text='<%# Eval("Student_id") %>'></asp:Label>
                            <td><%# Eval("Student_Fname") %> <%# Eval("Student_Sname") %> <%# Eval("Student_Lname") %></td>
                            <td>
                                <asp:LinkButton ID="LinkButton3" Class="btn btn-outline-success" CommandName="reg" style="font-size:12pt;font-weight:bold" runat="server" >
                                    <i class="fa-solid fa-check"> </i>
                                </asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton4" Class="btn btn-outline-danger" CommandName="cancel_reg" style="font-size:11pt;font-weight:bold" runat="server" >
                                    <i  class="fa-solid fa-xmark"> </i>
                                </asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton1" Class="btn btn-outline-primary" style="font-size:12pt;font-weight:bold" runat="server" PostBackUrl="#">
                                    <i class="fa-solid fa-sheet-plastic"></i>
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td><div id="Div5" runat="server"></div></td>
                </tr>
            </table>
            <p runat="server" class="text-center align-middle" id="P1" style="font-size:x-large">تسجيل يدوي !! ابحث عن الطالب ؟</p>
        </div>
        
            <!-----------------------------------------------------------   اختر المادة  ----------------------------------------------------------------------------------------------->

              <div runat="server" id="Div_Choose_Course" style="height:300px;" class="col-sm-12 col-lg-12 d-flex justify-content-center align-items-center border   p-3 bg-white shadow Choose_Course">
                 
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

                      <div class="from-group mb-2" style=" display:flex; justify-content:center; align-items:center; direction: ltr;">
                       
                         <asp:LinkButton ID="LinkButton8" CssClass="btn btn-lg btn-outline-success fs-6 ms-2" style="width:20%"  runat="server" OnClick="LinkButton8_Click" >&nbsp; التالي <i class="fa-solid fa-circle-chevron-left" style="font-size:20px;font-weight:bold;"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton7" CssClass="btn btn-lg btn-outline-success fs-6 ms-2" style="width:20%"  runat="server" PostBackUrl="~/Home_Teacher.aspx"> <i class="fa-solid fa-circle-chevron-right" style="font-size:20px;font-weight:bold;">&nbsp; السابق</i></asp:LinkButton>

                          
                      
                      </div>

                 </div>

            </div>

        
            <!----------------------------------------------------------------------------------------------------------------------------------------------------------------->

          <!-----------------------------------------------------------   اختر المحاضرة  ----------------------------------------------------------------------------------------------->

              <div runat="server" id="Div_Choose_Lecture" style="height:300px;" class="col-sm-12 col-lg-12 d-flex justify-content-center align-items-center border rounded-5 p-3 bg-white shadow Choose_Hall">
                 
                          <div class=" col-lg-6 col-md-12 right-box">

                  
                 <div class="row align-items-center">

                     <div class="header-text  mb-2" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>اختر التاريخ التي تمت فيه المحاضرة</h2>
                     </div>

                     <div class="from-group mb-3" style=" display:flex; justify-content:center; align-items:center;">
                          <asp:DropDownList ID="DDL_Choose_Lecture"  CssClass="form-control-lg bg-light ms-2 fs-6 txt1" style="display:inline-block;width:60%" AutoPostBack="false" runat="server"></asp:DropDownList>
                                                         <asp:Label ID="Label2" runat="server" Style="color:red;font-size:35px;" Visible="false"  Text="*"></asp:Label>

                         </div>


                 </div>

                      <div class="from-group mb-2" style=" display:flex; justify-content:center; align-items:center;">
              
                         <asp:LinkButton ID="LinkButton5" CssClass="btn btn-lg btn-outline-success fs-6 ms-2" style="width:20%"  runat="server" OnClick="LinkButton5_Click"> <i class="fa-solid fa-circle-chevron-right" style="font-size:20px;font-weight:bold;">&nbsp; </i>السابق</asp:LinkButton>
                         <asp:LinkButton ID="LinkButton6" CssClass="btn btn-lg btn-outline-success fs-6 ms-2" style="width:20%"  runat="server" OnClick="LinkButton6_Click">&nbsp; التالي <i class="fa-solid fa-circle-chevron-left" style="font-size:20px;font-weight:bold;"></i></asp:LinkButton>

                      
                      </div>

                 </div>

            </div>


            <!----------------------------------------------------------------------------------------------------------------------------------------------------------------->

       
    




</div>


        

</asp:Content>

