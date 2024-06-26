<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="Dept_Div_Courses_admin.aspx.cs" Inherits="Registering_students_attendance_using_QR_code.dept_div_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="bootstrap-5.2.3-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="bootstrap-5.2.3-dist/css/all.min.css" rel="stylesheet" />
    <link href="bootstrap-5.1.3-dist/css/all.min.css" rel="stylesheet" />
   
 <style>

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
         .div1 .btn1 {
            display: flex;
            justify-content:flex-end;

        }
        .div2 {
            display:inline;
            justify-content: flex-start;
            align-items: center;
            margin-bottom: 35px;

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
            display:inline-flex;
        }
        .m-2{
            display:inline-flex;
        }

.add_Course{
    background:#92c3f7;
    width:600px;
    height:300px;
    position:absolute;
    top:250px;
    right:550px;
    display:none;
}
.Edit_Course{
    background:#92c3f7;
    width:600px;
    height:300px;
    position:absolute;
    top:250px;
    right:550px;
    display:none;
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
.Edit_dept{
    background:#92c3f7;
    width:600px;
    height:300px;
    position:absolute;
    top:250px;
    right:550px;
    display:none;
}


.add_div{
    background:#92c3f7;
    width:600px;
    height:300px;
    position:absolute;
    top:250px;
    right:550px;
    display:none;
}
.Edit_Division{
     background:#92c3f7;
    width:600px;
    height:380px;
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

                  .Edit_dept{

                     background:#92c3f7;
                     width:600px;
                     height:300px;
                     position:absolute;
                     top:250px;
                     right:200px;
                     display:none;

                }



                .add_div{

                   

                }
                .Edit_Division{
                      background:#92c3f7;
                     width:600px;
                     height:380px;
                     position:absolute;
                     top:250px;
                     right:200px;
                     display:none;
                }


                
    

         }


    






.radio-button_dept {
  transform: scale(1.2);
  border-color: #4c8bf5;
  margin-right:10px;
  margin-bottom:0;
}

.radio-button_dept:hover  {
  transform: scale(1.3);
    color:cornflowerblue;
      transition: all 0.3s ease;


 
}

.radio-button_div {
  transform: scale(1.2);
  border-color: #4c8bf5;
  margin-right:10px;
  margin-bottom:0;
}

.radio-button_div:hover  {
  transform: scale(1.3);
  color:cornflowerblue;
   transition: all 0.3s ease;
 
}













    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

        <div class="container" >
       
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Home_Admin.aspx" CssClass="btn btn-outline-primary mb-3 mt-0"><i class="fa-solid fa-arrow-right fs-4">   الرئيسية</i></asp:LinkButton>

        <div class="div1">
            
            <h3 class="m-2">  <b>إدارة</b> الاقسام والشعب والمواد</h3>
             <div class="btn1">
             <asp:LinkButton ID="LBtn_Import_Courses" runat="server" CssClass="btn btn-outline-success btn-lg ms-2 " OnClick="LBtn_Import_Courses_Click"><i class="fa-solid fa-file-arrow-up fs-5">  استراد المواد من ملف اكسيل </i></asp:LinkButton>
             <asp:LinkButton ID="LBtn_Import_Dept" runat="server" CssClass="btn btn-outline-success btn-lg ms-2 " OnClick="LBtn_Import_Dept_Click"><i class="fa-solid fa-file-arrow-up fs-5 " >  استراد الاقسام من ملف اكسيل </i></asp:LinkButton>
              <asp:LinkButton ID="LBtn_Import_Div" runat="server" CssClass="btn btn-outline-success btn-lg ms-2 " OnClick="LBtn_Import_Div_Click"><i class="fa-solid fa-file-arrow-up fs-5 " >  استراد التخصصات من ملف اكسيل </i></asp:LinkButton>


             </div>
        </div>
               <!-- ----------------------------------------------------------- اضافة مادة---------------------------------------------------- -->
   
            <div runat="server" id="add_Course" class="d-flex justify-content-center align-items-center border rounded-5 p-3 bg-white shadow add_Course">
                 
                          <div class=" col-lg-6 col-md-12 right-box">

                       
                      <asp:Button ID="btn_X_Import_Cou" runat="server" Text="X" CssClass="btn btn-sm btn-danger" Style="position:absolute;top:0;right:0; width:45px;height:45px; font-size:25px; border-radius:5px;" OnClick="btn_X_Import_Cou_Click"  />
                     

                 <div class="row align-items-center">
                     <div class="header-text  mb-1" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>استيراد المواد</h2>
                     </div>
                  <div class="from-group mb-2">
                         <p>ملف المواد :</p> <asp:FileUpload ID="file_up_Courses" runat="server" CssClass="form-control form-control-lg bg-light fs-6  txt1" style="display:inline-block;width:92%" />  
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Text="*" ControlToValidate="file_up_Courses" style="color:red;font-size:30px;" ValidationGroup="G1" Display="Static"></asp:RequiredFieldValidator>
                     </div>

                      <div class="mb-2 d-flex justify-content-center align-items-center">
                      <asp:Button ID="btn_add_Course" runat="server" ValidationGroup="G1" Text="تحديث " CssClass="btn btn-lg btn-primary  fs-6 ms-2"  Style="width:65%" OnClick="btn_add_Course_Click" />

                       
                     </div>

                 </div>

            </div>

            </div>
              <!-- ----------------------------------------------------------- نهاية---------------------------------------------------- -->



            <!-- ----------------------------------------------------------- اضافة قسم---------------------------------------------------- -->
   
            <div runat="server" id="add_dept" class="d-flex justify-content-center align-items-center border rounded-5 p-3 bg-white shadow add_dept">
                 
                          <div class=" col-lg-6 col-md-12 right-box">

                       
                      <asp:Button ID="Button3" runat="server" Text="X" CssClass="btn btn-sm btn-danger" Style="position:absolute;top:0;right:0; width:45px;height:45px; font-size:25px; border-radius:5px;" OnClick="Button3_Click"  />
                     

                 <div class="row align-items-center">
                        <div class="header-text  mb-1" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>استيراد الاقسام</h2>
                     </div>
                  <div class="from-group mb-2">
                         <p>ملف الاقسام :</p> <asp:FileUpload ID="FileUpload_Dept" runat="server" CssClass="form-control form-control-lg bg-light fs-6  txt1" style="display:inline-block;width:92%" />  
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*" ControlToValidate="FileUpload_Dept" style="color:red;font-size:30px;" ValidationGroup="G2" Display="Static"></asp:RequiredFieldValidator>
                     </div>

                     
                      <div class="mb-2 d-flex justify-content-center align-items-center">
                      <asp:Button ID="Button2" runat="server" ValidationGroup="G2" Text="تحديث" CssClass="btn btn-lg btn-primary  fs-6 ms-2"  Style="width:65%" OnClick="Button2_Click" />

                       
                     </div>

                 </div>

            </div>

            </div>
              <!-- ----------------------------------------------------------- نهاية---------------------------------------------------- -->

               <!-- ----------------------------------------------------------- تعديل القسم---------------------------------------------------- -->
            <div runat="server" id="Edit_dept" class="d-flex justify-content-center align-items-center border rounded-5 p-3 bg-white shadow Edit_dept">
                 
                          <div class=" col-lg-6 col-md-12 right-box">

                       
                      <asp:Button ID="Button1" runat="server" Text="X" CssClass="btn btn-sm btn-danger" Style="position:absolute;top:0;right:0; width:45px;height:45px; font-size:25px; border-radius:5px;" OnClick="Button1_Click"  />
                     

                 <div class="row align-items-center">
                     <div class="header-text  mb-3" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>تعديل القسم</h2>
                     </div>
                  <div class="from-group mb-2">
                          <asp:TextBox ID="txt_Edit_dept_id" runat="server" Visible="false"></asp:TextBox>
                         <asp:TextBox ID="txt_Edit_dept_name" runat="server" CssClass="form-control form-control-lg bg-light fs-6 txt1" style="display:inline-block;width:95%" placeholder="ادخل اسم القسم"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="*" ControlToValidate="txt_Edit_dept_name" style="color:red;font-size:30px;" ValidationGroup="G3" Display="Static"></asp:RequiredFieldValidator>
                     </div>
                    
                  
                      <div class="mb-2 d-flex justify-content-center align-items-center">
                      <asp:Button ID="btn_Save_Edit" runat="server" ValidationGroup="G3" Text="حفظ" CssClass="btn btn-lg btn-primary  fs-6 ms-2"  Style="width:65%" OnClick="btn_Save_Edit_Click"  />

                       
                     </div>

                 </div>

            </div>

            </div>
              <!-- ----------------------------------------------------------- نهاية---------------------------------------------------- -->


              <!-- ----------------------------------------------------------- اضافة شعبة---------------------------------------------------- -->

            
            <div runat="server" id="add_div" class="d-flex justify-content-center align-items-center border rounded-5 p-3 bg-white shadow add_div">
                 
                          <div class=" col-lg-6 col-md-12 right-box">

                       
                      <asp:Button ID="Button5" runat="server" Text="X" CssClass="btn btn-sm btn-danger" Style="position:absolute;top:0;right:0; width:45px;height:45px; font-size:25px; border-radius:5px;" OnClick="Button5_Click" />
                     

                 <div class="row align-items-center">
                     <div class="header-text  mb-1" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>استيراد التخصصات</h2>
                     </div>
                  <div class="from-group mb-2">
                         <p>ملف التخصصات :</p> <asp:FileUpload ID="FileUpload_Division" runat="server" CssClass="form-control form-control-lg bg-light fs-6  txt1" style="display:inline-block;width:92%" />  
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ControlToValidate="FileUpload_Division" style="color:red;font-size:30px;" ValidationGroup="G4" Display="Static"></asp:RequiredFieldValidator>
                     </div>
                     
                      <div class="mb-2 d-flex justify-content-center align-items-center">
                      <asp:Button ID="Button6" ValidationGroup="G4" runat="server" Text="تحديث" CssClass="btn btn-lg btn-primary  fs-6 ms-2"  Style="width:65%" OnClick="Button6_Click" />

                        
                     </div>

                 </div>

            </div>

            </div>

             <!-- ----------------------------------------------------------- نهاية------------------------------------------------------------- -->

               <!-- ----------------------------------------------------------- تعديل الشعبة---------------------------------------------------- -->
            <div runat="server" id="Edit_Division" class="d-flex justify-content-center align-items-center border rounded-5 p-3 bg-white shadow Edit_Division">
                 
                          <div class=" col-lg-6 col-md-12 right-box">

                       
                      <asp:Button ID="Button4" runat="server" Text="X" CssClass="btn btn-sm btn-danger" Style="position:absolute;top:0;right:0; width:45px;height:45px; font-size:25px; border-radius:5px;" OnClick="Button4_Click"   />
                     

                 <div class="row align-items-center">
                     <div class="header-text  mb-1" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>تعديل الشعبة</h2>
                     </div>
                  <div class="from-group mb-2">
                          <asp:TextBox ID="txt__Edit_Division_ID" runat="server" Visible="false"></asp:TextBox>
                         <p>اسم الشعبة :</p>   <asp:TextBox ID="txt__Edit_Division_name" runat="server" CssClass="form-control form-control-lg bg-light fs-6  txt1" style="display:inline-block;width:92%" placeholder="ادخل اسم الشعبة"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="*" ControlToValidate="txt__Edit_Division_name" style="color:red;font-size:30px;" ValidationGroup="G5" Display="Static"></asp:RequiredFieldValidator>
                     </div>

                       <div class="from-group mb-2">

                  <p>الأقسام :</p>     <asp:DropDownList ID="DDL_Edit_Div" runat="server"  CssClass="form-control form-control-lg bg-light fs-6 me-2 txt1" style="display:inline-block;width:90%" DataSourceID="SqlDataSource2" DataTextField="Dept_name" DataValueField="Dept_id" ></asp:DropDownList>
                           <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:QR_Code_CollegConnectionString %>" SelectCommand="SELECT * FROM [Department]"></asp:SqlDataSource>
                                          
                           </div>
                    
                    
                  
                      <div class="mb-2 d-flex justify-content-center align-items-center">
                      <asp:Button ID="Button7" runat="server" ValidationGroup="G5" Text="حفظ" CssClass="btn btn-lg btn-primary  fs-6 ms-2"  Style="width:50%" OnClick="Button7_Click"  />

                       
                     </div>

                 </div>

            </div>

            </div>
              <!-- ----------------------------------------------------------- نهاية---------------------------------------------------- -->










        <div class="div2">
            <!--    ___________________________________________________________________________________________________________   -->
      

            <div class="m-2">
                 <asp:RadioButton ID="Rbtn_dept" Text="الاقسام" class="radio-button_dept ms-3 " runat="server" GroupName="a1" AutoPostBack="True" OnCheckedChanged="Rbtn_dept_CheckedChanged" />
             </div>
            
            <div class="m-2">
                 <asp:RadioButton ID="Rbtn_division" Text="التخصصات" class="radio-button_div" runat="server" GroupName="a1" AutoPostBack="True" OnCheckedChanged="Rbtn_division_CheckedChanged" />
                </div>

            <div class="m-2">
                 <asp:RadioButton ID="Rbtn_Courses" Text="المواد" class="radio-button_div" runat="server" GroupName="a1" AutoPostBack="True" OnCheckedChanged="Rbtn_Courses_CheckedChanged"/>
                </div>

            <!-- __________________________________________________________________________________________________________________ -->


        </div>

            
        <div class="div3" runat="server" id="tbl_Cou_search">
        

             <asp:Button ID="Btn_Searsh_cou_name" runat="server" class="btn btn-primary me-4" style="width:5%;" Text="بحث" OnClick="Btn_Searsh_cou_name_Click" />
                 <asp:TextBox ID="txt_Searsh_cou_name" runat="server"  placeholder="بحث باسم المادة" style="width:50%;" class="form-control ms-4" ></asp:TextBox>


             <label class="C1">
          <asp:CheckBox ID="CheckBox_Courses" runat="server"  />
  <svg viewBox="0 0 64 64" height="1.5em" width="1.5em">
    <path d="M 0 16 V 56 A 8 8 90 0 0 8 64 H 56 A 8 8 90 0 0 64 56 V 8 A 8 8 90 0 0 56 0 H 8 A 8 8 90 0 0 0 8 V 16 L 32 48 L 64 16 V 8 A 8 8 90 0 0 56 0 H 8 A 8 8 90 0 0 0 8 V 56 A 8 8 90 0 0 8 64 H 56 A 8 8 90 0 0 64 56 V 16" pathLength="575.0541381835938" class="path"></path>
  </svg>
</label>   

          
            <asp:DropDownList ID="DDL_Searsh_Dept_Cou" style="width:20%; float:right" runat="server" class="form-control me-2" DataSourceID="SqlDataSource3" DataTextField="Dept_name" DataValueField="Dept_id" AutoPostBack="True"></asp:DropDownList>
           
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:QR_Code_CollegConnectionString %>" SelectCommand="SELECT * FROM [Department]"></asp:SqlDataSource>
           

               <asp:DropDownList ID="DDL_Searsh_Div_Cou" style="width:20%; float:right" runat="server" class="form-control me-2" AutoPostBack="True" DataSourceID="SqlDataSource4" DataTextField="Division_name" DataValueField="Division_id"></asp:DropDownList>
           
           
             <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:QR_Code_CollegConnectionString %>" SelectCommand="SELECT * FROM [Division] WHERE ([Dept_id] = @Dept_id)">
                 <SelectParameters>
                     <asp:ControlParameter ControlID="DDL_Searsh_Dept_Cou" Name="Dept_id" PropertyName="SelectedValue" Type="Int32" />
                 </SelectParameters>
             </asp:SqlDataSource>
           
           
        </div>

        <div class="div3" runat="server" id="tbl_div_search">
         

             <asp:Button ID="Button9" runat="server" class="btn btn-primary me-4" style="width:5%;" Text="بحث" OnClick="Button9_Click" />
                 <asp:TextBox ID="txt_Searsh_Name_Division" runat="server"  placeholder="بحث باسم الشعبة" style="width:50%;" class="form-control ms-4" ></asp:TextBox>


             <label class="C1">
          <asp:CheckBox ID="ckb_Advanced_Search" runat="server"  />
  <svg viewBox="0 0 64 64" height="1.5em" width="1.5em">
    <path d="M 0 16 V 56 A 8 8 90 0 0 8 64 H 56 A 8 8 90 0 0 64 56 V 8 A 8 8 90 0 0 56 0 H 8 A 8 8 90 0 0 0 8 V 16 L 32 48 L 64 16 V 8 A 8 8 90 0 0 56 0 H 8 A 8 8 90 0 0 0 8 V 56 A 8 8 90 0 0 8 64 H 56 A 8 8 90 0 0 64 56 V 16" pathLength="575.0541381835938" class="path"></path>
  </svg>
</label>   

          
            <asp:DropDownList ID="DDL_Searsh_Division" style="width:20%; float:right" runat="server" class="form-control me-2" DataSourceID="SqlDataSource3" DataTextField="Dept_name" DataValueField="Dept_id"></asp:DropDownList>
           
             <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:QR_Code_CollegConnectionString %>" SelectCommand="SELECT * FROM [Department]"></asp:SqlDataSource>
           
        </div>

             <div class="div3" runat="server" id="tbl_dept_search">
        

                 <asp:Button ID="Button8" runat="server" class="btn btn-primary me-4" style="width:5%;" Text="بحث" OnClick="Button8_Click" />
                 <asp:TextBox ID="txt_Searsh_Name_Dept" runat="server"  placeholder="بحث باسم القسم " style="width:50%;" class="form-control" ></asp:TextBox>

           
        </div>

        <div class="div4" runat="server" id="tbl_dept">

            
            <table class="table table-striped table-hover" >

            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
    <HeaderTemplate>
            <tr  Class="table-dark text-center" style="font-size:18pt;font-weight:bold;height:35px;">
                <th>القسم</th>
                <th> تعديل </th>
                <th>حذف </th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr style="font-size:15pt; font-weight:bold" class="text-center align-middle">
             <td> <asp:Label ID="Label2" runat="server" Text='<%# Eval("Dept_name") %>'></asp:Label></td>
             <td style="display:none;"><asp:Label ID="Label1" runat="server"  Text='<%# Eval("Dept_id") %>'></asp:Label></td>
             <td><asp:LinkButton ID="LinkButton2" CommandName="Edit"  Class="btn btn-outline-success fa-solid fa-pen"  runat="server"></asp:LinkButton></td>
             <td><asp:LinkButton ID="LinkButton3" CommandName="Delete" Class="btn btn-outline-danger fa-solid fa-trash-can"  runat="server"></asp:LinkButton></td>
       

        </tr>
    </ItemTemplate>

</asp:Repeater>
              <tr>
                   <td><div id="Div1" runat="server"></div></td>

                  </tr>

        </table>
                          
       
        </div>
                    <div class="div4" runat="server" id ="tbl_div">

                        

               <table class="table table-striped table-hover" >

            <asp:Repeater ID="myRepeater" runat="server" OnItemCommand="myRepeater_ItemCommand">
    <HeaderTemplate>
            <tr  Class="table-dark text-center" style="font-size:18pt;font-weight:bold;height:35px;">
                <th> الشعبة </th>
                <th>تعديل </th>
                <th>حذف </th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr style="font-size:15pt; font-weight:bold" class="text-center align-middle">
            <td style="display:none;"> <asp:Label ID="Label1" runat="server" Text='<%# Eval("Division_id") %>'></asp:Label></td>
           
            <td>
             <asp:Label ID="Label2" runat="server" Text='<%# Eval("Division_name") %>'></asp:Label><br />
             <p style="font-size:small;">  (<%# Eval("Dept_name") %>)</p> 
            </td>
           
            <td style="display:none;" ><asp:Label ID="Label3" runat="server" Text='<%# Eval("Dept_id") %>'></asp:Label></td>
             
             <td><asp:LinkButton ID="LinkButton2" CommandName="Edit"  Class="btn btn-outline-success fa-solid fa-pen"  runat="server"></asp:LinkButton></td>
             <td><asp:LinkButton ID="LinkButton3" CommandName="Delete" Class="btn btn-outline-danger fa-solid fa-trash-can"  runat="server"></asp:LinkButton></td>


        </tr>
    </ItemTemplate>

</asp:Repeater>
              <tr>
                   <td><div id="pagingDiv" runat="server"></div></td>

                  </tr>

        </table>
       
       
        </div>

            <div class="div4" runat="server" id ="tbl_Course">

                        

               <table class="table table-striped table-hover" >

            <asp:Repeater ID="Repeater_Courses" runat="server" >
    <HeaderTemplate>
            <tr  Class="table-dark text-center" style="font-size:18pt;font-weight:bold;height:35px;">
                <th> المادة </th>
                <th>تعديل </th>
                <th>حذف </th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr style="font-size:15pt; font-weight:bold" class="text-center align-middle">
           
            <td>
             <asp:Label ID="Label2" runat="server" Text='<%# Eval("Course_name") %>'></asp:Label>
              <br />
              <a style="font-size:small;">(<%# Eval("Dept_name") %>) </a>  
                <br />
                <a style="font-size:small;">  (<%# Eval("Division_name") %>)</a> 


            </td>
           
            <td style="display:none;" ><asp:Label ID="Label3" runat="server" Text='<%# Eval("Dept_id") %>'></asp:Label></td>
             
             <td><asp:LinkButton ID="LinkButton2" CommandName="Edit"  Class="btn btn-outline-success fa-solid fa-pen"  runat="server"></asp:LinkButton></td>
             <td><asp:LinkButton ID="LinkButton3" CommandName="Delete" Class="btn btn-outline-danger fa-solid fa-trash-can"  runat="server"></asp:LinkButton></td>


        </tr>
    </ItemTemplate>

</asp:Repeater>
              <tr>
                   <td><div id="paging_Courses" runat="server"></div></td>

                  </tr>

        </table>
       
       
        </div>

    </div>
   
</asp:Content>
