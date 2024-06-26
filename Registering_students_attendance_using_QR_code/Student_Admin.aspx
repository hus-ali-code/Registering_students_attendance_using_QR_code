<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Student_Admin.aspx.cs" Inherits="Registering_students_attendance_using_QR_code.student_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <link href="bootstrap-5.2.3-dist/css/all.min.css" rel="stylesheet" />
    <link href="bootstrap-5.1.3-dist/css/all.min.css" rel="stylesheet" />
   
 <style>
        /* تخصيص الأنماط الإضافية */
        .container {
            margin-top: 50px;
        }
        .div1 {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 20px;
             box-shadow: 1px 1px 1px #444;

        }
        .div2 {
            display:inline;
            justify-content: flex-start;
            align-items: center;
            margin-bottom: 20px;

        }
        .div3 {
            display: flex;
            justify-content: center;
            align-items: center;
            margin-bottom: 20px;
        }
        .div3 input[type="text"] {
            margin-right: 10px;
            margin-left: 10px;
        }
        .div4 {
            width: 100%;
        }

        .div1 .btn1 {
            display: flex;
            justify-content:flex-end;

        }

        .m-2{
            display:inline-flex;
        }

        .add_Student{
    background:#92c3f7;
    width:600px;
    height:350px;
    position:absolute;
    top:250px;
    right:550px;
    display:none;
}

        .add_Img_Student{
               background:#92c3f7;
    width:600px;
    height:300px;
    position:absolute;
    top:250px;
    right:550px;
    display:none;

        }
 .right-box{
            padding: 0px 0px 0px 0px;
             height:80%;
             width:80%;

         }
            ::placeholder{
             font-size:16px;
             text-align:center;
         }
  .txt1{
                     text-align:center;
                     margin-bottom:0.5rem;
            }

  ::Placeholder{
      text-align:center;
      font-size:20px;
  }

  
    @media  screen and (min-width:801px) and (max-width:1200px) 
    {
                .add_Student{

                     background:#92c3f7;
                     width:600px;
                     height:350px;
                     position:absolute;
                     top:250px;
                     right:200px;
                     display:none;

                }

                
        .add_Img_Student
        {
            
                     background:#92c3f7;
                     width:600px;
                     height:300px;
                     position:absolute;
                     top:250px;
                     right:200px;
                     display:none;


        }


                

    }

           
     .auto-style1 {
         direction: ltr;
     }

           
     </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" container" >
   
   
   
                 <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Home_Admin.aspx" CssClass="btn btn-outline-primary mb-3 mt-0"><i class="fa-solid fa-arrow-right fs-4">   الرئيسية</i></asp:LinkButton>

        <div class="div1">
            
            <h3 class="m-2">  <b>إدارة</b> الطلبة  </h3>
            <div class="btn1">
            <asp:Button ID="Button4" runat="server" class="btn btn-outline-success btn-lg ms-2" Font-Bold="true" Text="تحديث بيانات الطلبة" OnClick="Button4_Click" />
            <asp:Button ID="Button2" runat="server" class="btn btn-outline-success btn-lg" Font-Bold="true" Text="رفع صور الطلبة" OnClick="Button2_Click" />
            </div>
        </div>

          <!-- -----------------------------------------------------------  استيراد بيانات الطلبة---------------------------------------------------- -->
   
            <div runat="server" id="add_Student" class="d-flex justify-content-center align-items-center border rounded-5 p-3 bg-white shadow add_Student">
                 
                          <div class=" col-lg-6 col-md-12 right-box">

                       
                      <asp:Button ID="btn_X_Import_Stu" runat="server" Text="X" CssClass="btn btn-sm btn-danger" Style="position:absolute;top:0;right:0; width:45px;height:45px; font-size:25px; border-radius:5px;" OnClick="btn_X_Import_Stu_Click" />
                     

                 <div class="row align-items-center">
                     <div class="header-text  mb-2" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>استيراد بيانات الطلبة</h2>
                     </div>
                  <div class="from-group mb-2">
                         <h5 class="mb-0">ملف بيانات الطلبة :</h5> <asp:FileUpload ID="file_up_Stu" runat="server" CssClass="form-control form-control-lg bg-light fs-6  txt1" style="display:inline-block;width:92%" />  
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Text="*" ControlToValidate="file_up_Stu" style="color:red;font-size:30px;" ValidationGroup="G1" Display="Static"></asp:RequiredFieldValidator>
                     </div>

                     <div class="from-group mb-2">
                         <h5 class="mb-0">ملف موادالطلبة :</h5> <asp:FileUpload ID="file_up_Stu_Cou" runat="server" CssClass="form-control form-control-lg bg-light fs-6  txt1" style="display:inline-block;width:92%" />  
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*" ControlToValidate="file_up_Stu_Cou" style="color:red;font-size:30px;" ValidationGroup="G1" Display="Static"></asp:RequiredFieldValidator>
                     </div>

                      <div class="mb-2 d-flex justify-content-center align-items-center">
                      <asp:Button ID="btn_add_Stu" runat="server" ValidationGroup="G1" Text="تحديث " CssClass="btn btn-lg btn-primary  fs-6 ms-2"  Style="width:65%" OnClick="btn_add_Stu_Click"  />

                       
                     </div>

                 </div>

            </div>

            </div>
              <!-- ----------------------------------------------------------- نهاية---------------------------------------------------- -->

              <!-- -----------------------------------------------------------  استيراد صور الطلبة---------------------------------------------------- -->
   
            <div runat="server" id="add_Img_Student" class="d-flex justify-content-center align-items-center border rounded-5 p-3 bg-white shadow add_Img_Student">
                 
                          <div class=" col-lg-6 col-md-12 right-box">

                       
                      <asp:Button ID="btn_X_Import_Img_Stu" runat="server" Text="X" CssClass="btn btn-sm btn-danger" Style="position:absolute;top:0;right:0; width:45px;height:45px; font-size:25px; border-radius:5px;" OnClick="btn_X_Import_Img_Stu_Click"  />
                     

                 <div class="row align-items-center">
                     <div class="header-text  mb-2" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>رفع صور الطلبة</h2>
                     </div>
               
                    
                     <div class="from-group mb-2">
                         <h5 class="mb-0">ملف صورالطلبة :</h5> <asp:FileUpload ID="file_up_Stu_img" runat="server" CssClass="form-control form-control-lg bg-light fs-6  txt1" AllowMultiple="true" style="display:inline-block;width:92%" />  
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ControlToValidate="file_up_Stu_img" style="color:red;font-size:30px;" ValidationGroup="G2" Display="Static"></asp:RequiredFieldValidator>
                     </div>

                   
                      <div class="mb-2 d-flex justify-content-center align-items-center">
                      <asp:Button ID="btnFileImg" runat="server" ValidationGroup="G2" Text="تحديث " CssClass="btn btn-lg btn-primary  fs-6 ms-2"  Style="width:65%" OnClick="btnFileImg_Click"  />

                       
                     </div>

                 </div>

            </div>

            </div>
              <!-- ----------------------------------------------------------- نهاية---------------------------------------------------- -->


          <div class="div2">

             <div class=" m-2">
            <h4 class="auto-style1"> الكل </h4>
            <h4>[ <% =  myRepeater.Items.Count %> ]</h4>

             </div>
            
            <div class=" m-2">
            <h4>المعروض</h4>
              <h4>[ <% =  myRepeater.Items.Count %> ]</h4>
            </div>

             <div  style="display:inline-flex;float:left;width:70%;">
           
                 <asp:LinkButton ID="LinkButton2" runat="server"  OnClick="btn_Searsh_Click" class="btn btn-outline-primary m-0 "  style="display:inline-block;width:7%;height:45px;border-bottom-right-radius:20px;border-top-right-radius:20px;border-top-left-radius:0;border-bottom-left-radius:0;"><i class="fa-solid fa-magnifying-glass" style="font-size:25px;border-rad"></i></asp:LinkButton>
                  <asp:TextBox ID="TextBox1" runat="server"  placeholder="بحث باسم الطالب او رقم القيد او الرقم الوطني" class="btn-outline-primary m-0 txt1"  style="display:inline-block;width:50%;height:45px;border-bottom-right-radius:0;border-top-right-radius:0;border-top-left-radius:20px;border-bottom-left-radius:20px;text-align:center;border-right:0;" Font-Bold="True" Font-Size="13"></asp:TextBox>

                </div>
                    
 
        </div> 

     

        <div class="div3">
           
                    </div>
        <div class="div4">
             <table class="table table-striped table-hover">

            <asp:Repeater ID="myRepeater" runat="server">
    <HeaderTemplate>
            <tr  Class="table-dark text-center" style="font-size:18pt;font-weight:bold">
                <th>صورة الطالب</th>
                <th>اسم الطالب</th>
                <th>رقم القيد</th>
                <th> رقم الوطني</th>
                <th>التقرير</th>
                <th>حذف </th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr class="text-center align-middle" style="font-size:15pt; font-weight:bold">
    <td class="m-0 p-0 text-center">
        <img src='<%# Eval("Photo") %>' style="width:100px; height:120px;" />
    </td>
    <td ><%# Eval("Student_Fname") %> <%# Eval("Student_Sname") %> <%# Eval("Student_Lname") %> </td>
    <td ><%# Eval("Student_Kaid") %></td>
    <td ><%# Eval("Student_NAT") %></td>
    <td >
        <asp:LinkButton ID="LinkButton1" Class="btn btn-outline-success" style="font-size:15pt;font-weight:bold" runat="server" PostBackUrl="#">
            <i class="fa-solid fa-sheet-plastic">&nbsp; سجل الطالب </i>
        </asp:LinkButton>
    </td>
    <td >
        <asp:LinkButton ID="LinkButton3" Class="btn btn-outline-danger" style="font-size:15pt;font-weight:bold" runat="server">
            <i class="fa-solid fa-trash-can">&nbsp; حذف جهاز الطالب </i>
        </asp:LinkButton>
    </td>
</tr>
    </ItemTemplate>

</asp:Repeater>
              <tr>
                   <td><div id="pagingDiv" runat="server"></div></td>

                  </tr>

        </table>
                  
        </div>
    </div>

</asp:Content>
