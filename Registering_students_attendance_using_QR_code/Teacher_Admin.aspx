<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Teacher_Admin.aspx.cs" Inherits="Registering_students_attendance_using_QR_code.teacher_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    <link href="Styles/sweetalert.css" rel="stylesheet" />
    <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/JaaAlert.js"></script>
    
    
    <link href="bootstrap-5.2.3-dist/css/bootstrap.min.css" rel="stylesheet" />
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
            margin-bottom: 8px;

        }
        .div3 {
            display: flex;
            justify-content: center;
            align-items: center;
            margin-bottom: 25px;
            margin-top:10px;
        }
        .div3 input[type="text"] {
            margin-right: 10px;
            margin-left: 10px;
        }
        .div4 {
            width: 100%;
        }
        .m-2{
            display:inline-flex;
        }

        .container .btn-conteiner {
  display: flex;
  justify-content:flex-start;
  --color-text: #ffffff;
  --color-background: #92c3f7;
  --color-outline: #92c3f7;
  --color-shadow:#92c3f7;
  height:40px;


}

  .container .btn-content {
  display: flex;
  align-items: center;
  padding: 5px 30px;
  text-decoration: none;
  font-family: 'Poppins', sans-serif;
  font-weight: 600;
  font-size: 30px;
  color: var(--color-text);
  background: var(--color-background);
  transition: 1s;
  border-radius: 100px;
  box-shadow: 0 0 0.2em 0 var(--color-background);

}

  .container .btn-content:hover, .btn-content:focus {
  transition: 0.5s;
  -webkit-animation: btn-content 1s;
  animation: btn-content 1s;
  outline: 0.1em solid transparent;
  outline-offset: 0.2em;
  box-shadow: 0 0 0.4em 0 var(--color-background);
}

  .container .btn-content .icon-arrow {
  transition: 0.5s;
  margin-right: 0px;
  transform: scale(0.6);
}

  .container .btn-content:hover .icon-arrow {
  transition: 0.5s;
  margin-right: 25px;
}

 .container .icon-arrow {
  width: 20px;
  margin-left: 15px;
  position: relative;
  top: 6%;
}
  
/* SVG */
#arrow-icon-one {
  transition: 0.4s;
  transform: translateX(-60%);
}

#arrow-icon-two {
  transition: 0.5s;
  transform: translateX(-30%);
}

  .container .btn-content:hover #arrow-icon-three {
  animation: color_anim 1s infinite 0.2s;
}

  .container .btn-content:hover #arrow-icon-one {
  transform: translateX(0%);
  animation: color_anim 1s infinite 0.6s;
}

.btn-content:hover #arrow-icon-two {
  transform: translateX(0%);
  animation: color_anim 1s infinite 0.4s;
}

/* SVG animations */
@keyframes color_anim {
  0% {
    fill: white;
  }

  50% {
    fill: var(--color-background);
  }

  100% {
    fill: white;
  }
}

/* Button animations */
@-webkit-keyframes btn-content {
  0% {
    outline: 0.2em solid var(--color-background);
    outline-offset: 0;
  }
}

@keyframes btn-content {
  0% {
    outline: 0.2em solid var(--color-background);
    outline-offset: 0;
  }
}

.add_teach{
    background:#92c3f7;
    width:600px;
    height:400px;
    position:absolute;
    top:250px;
    right:550px;
    display:none;
}
.Edit_teach{
    background:#92c3f7;
    width:600px;
    height:450px;
    position:absolute;
    top:250px;
    right:550px;
    display:none;
}

            ::placeholder{
             font-size:16px;
             text-align:center;
         }
  .txt1{
                     text-align:center;
                     margin-bottom:0.5rem;
            }
           

    @media  screen and (min-width:801px) and (max-width:1200px) 
         {
                .add_teach{

                     background:#92c3f7;
                     width:600px;
                     height:400px;
                     position:absolute;
                     top:250px;
                     right:200px;
                     display:none;

                }
                .Edit_teach{
                     background:#92c3f7;
                     width:600px;
                     height:450px;
                     position:absolute;
                     top:250px;
                     right:200px;
                     display:none;
               }

                
    

         }
     .right-box{
             padding: 0px 0px 0px 0px;
             height:80%;
             width:80%;
         }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     
        <div class="container" >

            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Home_Admin.aspx" CssClass="btn btn-outline-primary mb-3 mt-0"><i class="fa-solid fa-arrow-right fs-4">   الرئيسية</i></asp:LinkButton>
        
         <div class="div1">
            
                        <h3 class="m-2"><b>إدارة</b> الاساتذة</h3>
            <asp:Button ID="Button4" runat="server" class="btn btn-success btn-lg " Text="إضافة استاذ" OnClick="Button4_Click"  />


        </div>


<!-----------------------------------------------------------اضافة استاذ----------------------------------------------------------------------------------------------->

            <div runat="server" id="add_teach" class="d-flex justify-content-center align-items-center border rounded-5 p-3 bg-white shadow add_teach">
                 
                          <div class=" col-lg-6 col-md-12 right-box">

                       
                      <asp:Button ID="Button3" runat="server" Text="X" CssClass="btn btn-sm btn-danger" Style="position:absolute;top:0;right:0; width:45px;height:45px; font-size:25px; border-radius:5px;" OnClick="Button3_Click" />
                     

                 <div class="row align-items-center">
                     <div class="header-text  mb-2" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>اضافة استاذ</h2>
                     </div>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" Text="صيغة البريد خطأ" ControlToValidate="txt_Email" style="color:red;font-size:15px;direction:rtl; " ValidationGroup="G1" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                     <div class="from-group mb-2">
                         <asp:TextBox ID="txt_Email" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="ادخل البريد الخاص  بالمسؤول" style="display:inline-block;width:95%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ControlToValidate="txt_Email" style="color:red;font-size:30px; " ValidationGroup="G1" Display="Static"></asp:RequiredFieldValidator>
                     </div>
                      <div class="from-group mb-2">
                      <asp:TextBox ID="txt_Fname" runat="server" Enabled="true" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="اسم الاستاذ " style="display:inline-block;width:95%" MaxLength="15"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*" ControlToValidate="txt_Fname" style="color:red;font-size:30px;" ValidationGroup="G1" Display="Static"></asp:RequiredFieldValidator>
                                         </div>
                     <div class="from-group mb-2">
                      <asp:TextBox ID="txt_Lname" runat="server" Enabled="true" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="اسم الاستاذ " style="display:inline-block;width:95%" MaxLength="15"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="*" ControlToValidate="txt_Lname" style="color:red;font-size:30px;" ValidationGroup="G1" Display="Static"></asp:RequiredFieldValidator>
                                         </div>
                     


                  
                      <div class="from-group mb-2" style=" display:flex; justify-content:center; align-items:center;">
                        <asp:Button ValidationGroup="G1" ID="Button1" runat="server" Text="حفظ" CssClass="btn btn-lg btn-success fs-6" Style="width:50%" OnClick="Button1_Click"  />
                          <!-- <i class="fa-regular icon fa-floppy-disk fs-1" style="width: 100px;"></i>-->
                     </div>

                 </div>

            </div>

            </div>
<!----------------------------------------------------------------------------------------------------------------------------------------------------------------->


<!-----------------------------------------------------------تعديل بيانات الاستاذ----------------------------------------------------------------------------------------------->

              <div runat="server" id="Edit_teach" class="d-flex justify-content-center align-items-center border rounded-5 p-3 bg-white shadow Edit_teach">
                 
                          <div class=" col-lg-6 col-md-12 right-box">

                       
                      <asp:Button ID="btn_Close_Edit_Teacher" runat="server" Text="X" CssClass="btn btn-sm btn-danger" Style="position:absolute;top:0;right:0; width:45px;height:45px; font-size:25px; border-radius:5px;" OnClick="btn_Close_Edit_Teacher_Click"/>
                     

                 <div class="row align-items-center">
                     <div class="header-text  mb-2" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>تعديل بيانات الاستاذ</h2>
                     </div>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator" Text="صيغة البريد خطأ" ControlToValidate="txt_Email_Edit" style="color:red;font-size:15px;direction:rtl; " ValidationGroup="G2" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                     <div class="from-group mb-2">
                         <asp:TextBox ID="txt_Email_Edit" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder=" البريد الالكتروني   " style="display:inline-block;width:95%" ReadOnly="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="*" ControlToValidate="txt_Email_Edit" style="color:red;font-size:30px; " ValidationGroup="G2" Display="Static"></asp:RequiredFieldValidator>
                     </div>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="RegularExpressionValidator" Text="صيغة البريد خطأ" ControlToValidate="txt_Email_Edit_NEW" style="color:red;font-size:15px;direction:rtl; " ValidationGroup="G2" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                      <div class="from-group mb-2">
                         <asp:TextBox ID="txt_Email_Edit_NEW" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="ادخل البريد الجديد  " style="display:inline-block;width:95%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Text="*" ControlToValidate="txt_Email_Edit_NEW" style="color:red;font-size:30px; " ValidationGroup="G2" Display="Static"></asp:RequiredFieldValidator>
                     </div>
                      <div class="from-group mb-2">
                      <asp:TextBox ID="txt_Fname_Edit" runat="server" Enabled="true" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="اسم الاستاذ " style="display:inline-block;width:95%"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Text="*" ControlToValidate="txt_Fname_Edit" style="color:red;font-size:30px;" ValidationGroup="G2" Display="Static"></asp:RequiredFieldValidator>
                                         </div>
                     <div class="from-group mb-2">
                      <asp:TextBox ID="txt_Lname_Edit" runat="server" Enabled="true" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="لقب الاستاذ " style="display:inline-block;width:95%"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Text="*" ControlToValidate="txt_Lname_Edit" style="color:red;font-size:30px;" ValidationGroup="G2" Display="Static"></asp:RequiredFieldValidator>
                                         </div>
                     


                  
                      <div class="from-group mb-2" style=" display:flex; justify-content:center; align-items:center;">
                        <asp:Button ValidationGroup="G2" ID="Button6" runat="server" Text="حفظ التعديلات" CssClass="btn btn-lg btn-success fs-6" Style="width:50%" OnClick="Button6_Click"  />
                          <!-- <i class="fa-regular icon fa-floppy-disk fs-1" style="width: 100px;"></i>-->
                     </div>

                 </div>

            </div>

            </div>

            <!----------------------------------------------------------------------------------------------------------------------------------------------------------------->


        <div class="div2">

                                

             <div class=" m-2">
            <h4> الكل </h4>
            <h4>[ <% = GetRowCount() %> ]</h4>

             </div>
            
            <div class=" m-2">
            <h4>المعروض</h4>
              <h4>[ <% =  myRepeater.Items.Count %> ]</h4>
            </div>

             <div  style="display:inline-flex;float:left;width:70%;">
           
               <asp:LinkButton ID="LinkButton4" runat="server" class="btn btn-outline-primary m-0 "  style="display:inline-block;width:7%;height:45px;border-bottom-right-radius:20px;border-top-right-radius:20px;border-top-left-radius:0;border-bottom-left-radius:0;" OnClick="btnSearch_Click"><i class="fa-solid fa-magnifying-glass" style="font-size:25px;border-rad"></i></asp:LinkButton>
                <asp:TextBox ID="txt_Searsh" runat="server" placeholder="البحث باسم الاستاذ..." class=" btn-outline-primary m-0"  style="display:inline-block;width:50%;height:45px;border-bottom-right-radius:0;border-top-right-radius:0;border-top-left-radius:20px;border-bottom-left-radius:20px;text-align:center;" Font-Bold="True" Font-Size="15"></asp:TextBox>           
                  
                </div>
                    
 
        </div> 

        <div class="div3 container">

          </div>
        <div class="div4">
                  <table class="table table-striped table-hover">

            <asp:Repeater ID="myRepeater" runat="server" OnItemCommand="myRepeater_ItemCommand">
    <HeaderTemplate>
            <tr  Class="table-dark text-center" style="font-size:18pt;font-weight:bold">
                <th>اسم الاستاذ</th>
                <th> البريد الالكتروني</th>
                <th> رقم الهاتف</th>
                <th> ادوات التحكم</th>
                <th>تعديل</th>
                <th>حذف </th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr style="font-size:15pt; font-weight:bold" class="text-center align-middle" >
            <td><%# Eval("Teacher_Fname") %> <%# Eval("Teacher_Lname") %></td>
            <td>  <asp:Label ID="Label1" runat="server"  Text='<%# Eval("Email") %>'></asp:Label></td>
            <td><%# Eval("Phone_number") %></td>
            <td> <asp:LinkButton ID="LinkButton1"  Class="btn btn-outline-success" style="font-size:15pt;font-weight:bold" runat="server" PostBackUrl='<%# "teacher_courses_admin.aspx?Fname=" + Eval("Teacher_Fname") + "&Lname=" + Eval("Teacher_Lname")  + "&teacherID=" + Eval("Teacher_id") %>' >تحديد مواد االاستاذ</asp:LinkButton></td>
             <td> <asp:LinkButton ID="LinkButton2" CommandName="Edit" Class="btn btn-outline-success fa-solid fa-pen" runat="server"></asp:LinkButton></td>
             <td><asp:LinkButton ID="LinkButton3" Class="btn btn-outline-danger fa-solid fa-trash-can"  runat="server"></asp:LinkButton></td>
       

        </tr>
    </ItemTemplate>

</asp:Repeater>
              <tr>
                   <td><div id="pagingDiv" runat="server"></div></td>

                  </tr>

        </table>
                  
                
        

        </div>
    </div>
      
    <!-- 
              <div class="col-6 col-xl-4">
                        <h2><b>إدارة</b> الإعلانات</h2>
                    </div>


                <asp:LinkButton ID="LinkButton20" runat="server" Class="Sec" ><i class="fa fa-search"></i></asp:LinkButton>
-->
</asp:Content>
