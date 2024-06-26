<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="Report_Admin.aspx.cs" Inherits="Registering_students_attendance_using_QR_code.Report_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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





.Stu {

            width: 100%;
            border:solid 2px #444;
            overflow:auto;
            height:900px;
            margin-bottom:10px;
                        
     }  

.Cou{

    
            width: 100%;
            border:solid 2px #444;
            overflow:auto;
            height:900px;
            margin-bottom:10px;

}







    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

        <div class="container" >
       
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Home_Admin.aspx" CssClass="btn btn-outline-primary mb-3 mt-0"><i class="fa-solid fa-arrow-right fs-4">   الرئيسية</i></asp:LinkButton>

        <div class="div1">
            
            <h3 class="m-2">  <b>التقارير</b></h3>
             <div class="btn1">
             <asp:LinkButton ID="LBtn_Import_Courses" runat="server" CssClass="btn btn-outline-success btn-lg ms-2 " ><i class="fa-solid fa-file-arrow-up fs-5">  طاعة التقرير </i></asp:LinkButton>
             </div>
        </div>


        <div class="div2">
            <!--    ___________________________________________________________________________________________________________   -->
      

            <div class=" m-2">
                 <asp:RadioButton ID="Rbtn_Stu" Text="الطلاب" class="radio-button_dept ms-3 " runat="server" GroupName="a1" AutoPostBack="True" OnCheckedChanged="Rbtn_Stu_CheckedChanged"  />
             </div>
            
            <div class=" mb-4 m-2">
                 <asp:RadioButton ID="Rbtn_Cou" Text="المواد" class="radio-button_div" runat="server" GroupName="a1" AutoPostBack="True" OnCheckedChanged="Rbtn_Cou_CheckedChanged" />
                </div>


            <!-- __________________________________________________________________________________________________________________ -->


        </div>

            
        <div class="div3" runat="server" id="Div_Cou_search">
        

             <asp:Button ID="Btn_Searsh_cou" runat="server" class="btn btn-primary me-4" style="width:5%;" Text="بحث" OnClick="Btn_Searsh_cou_Click" />
                 <asp:TextBox ID="txt_Searsh_cou" runat="server"  placeholder="بحث باسم المادة" style="width:50%;" class="form-control ms-4" ></asp:TextBox>


             <label class="C1">
          <asp:CheckBox ID="CheckBox_Courses" runat="server"  />
  <svg viewBox="0 0 64 64" height="1.5em" width="1.5em">
    <path d="M 0 16 V 56 A 8 8 90 0 0 8 64 H 56 A 8 8 90 0 0 64 56 V 8 A 8 8 90 0 0 56 0 H 8 A 8 8 90 0 0 0 8 V 16 L 32 48 L 64 16 V 8 A 8 8 90 0 0 56 0 H 8 A 8 8 90 0 0 0 8 V 56 A 8 8 90 0 0 8 64 H 56 A 8 8 90 0 0 64 56 V 16" pathLength="575.0541381835938" class="path"></path>
  </svg>
</label>   

          
            <asp:DropDownList ID="DDL_Searsh_Dept_Cou" style="width:20%; float:right" runat="server" class="form-control me-2" DataSourceID="SqlDataSource1" DataTextField="Dept_name" DataValueField="Dept_id" AutoPostBack="True"></asp:DropDownList>
           
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:QR_Code_CollegConnectionString %>" SelectCommand="SELECT * FROM [Department]"></asp:SqlDataSource>
           

               <asp:DropDownList ID="DDL_Searsh_Div_Cou" style="width:20%; float:right" runat="server" class="form-control me-2" AutoPostBack="True" DataSourceID="SqlDataSource4" DataTextField="Division_name" DataValueField="Division_id"></asp:DropDownList>
           
           
             <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:QR_Code_CollegConnectionString %>" SelectCommand="SELECT * FROM [Division] WHERE ([Dept_id] = @Dept_id)">
                 <SelectParameters>
                     <asp:ControlParameter ControlID="DDL_Searsh_Dept_Cou" Name="Dept_id" PropertyName="SelectedValue" Type="Int32" />
                 </SelectParameters>
             </asp:SqlDataSource>
           
           
        </div>

            <div class="Cou" runat="server" id ="Div_tbl_Course">

                        

               <table class="table table-striped table-hover" >

            <asp:Repeater ID="Repeater_Courses" runat="server" OnItemCommand="Repeater_Courses_ItemCommand" >
    <HeaderTemplate>
            <tr  Class="table-dark text-center" style="font-size:18pt;font-weight:bold;height:35px;">
                <th> المادة </th>
                <th>سجلات حضور الطلاب في هذه المادة </th>
               
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
           
            <td style="display:none;" ><asp:Label ID="Label1" runat="server" Text='<%# Eval("Course_id") %>'></asp:Label></td>
             
             <td><asp:LinkButton ID="LinkButton2" CommandName="Show"  Class="btn btn-outline-success"  runat="server"><i class="fa-solid fa-file-lines fs-4"></i></asp:LinkButton></td>
            

        </tr>
    </ItemTemplate>

</asp:Repeater>
              <tr>
                   <td><div id="paging_Courses" runat="server"></div></td>

                  </tr>

        </table>
       
       
        </div>

            <!-- __________________________________________________________________________________________________________________ -->
            <!-- __________________________________________________________________________________________________________________ -->
            <!-- __________________________________________________________________________________________________________________ -->

                    
        <div class="div3" runat="server" id="Div_Searsh_Stu">
        

             <asp:Button ID="btn_Searsh_Stu" runat="server" class="btn btn-primary me-4" style="width:5%;" Text="بحث" OnClick="btn_Searsh_Stu_Click" />
                 <asp:TextBox ID="txt_Searsh_Stu" runat="server"  placeholder="بحث باسم الطالب" style="width:50%;" class="form-control ms-4" ></asp:TextBox>


        </div>

            <div class="Stu" runat="server" id ="Div_tbl_Stu">

                        

               <table class="table table-striped table-hover" >

            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
    <HeaderTemplate>
            <tr  Class="table-dark text-center" style="font-size:18pt;font-weight:bold;height:35px;">
                <th> الصورة  </th>
                <th>الاسم</th>
                 <th>رقم القيد </th>
                <th>سجل حضور الطالب </th>
               
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr style="font-size:15pt; font-weight:bold" class="text-center align-middle">
           
           <td > <asp:Image ID="Image1" runat="server" style="width:100px; height:120px;" ImageUrl='<%# Eval("Photo") %>' /></td>
            <td ><%# Eval("Student_Fname") %> <%# Eval("Student_Sname") %> <%# Eval("Student_Lname") %> </td>
    <td ><%# Eval("Student_Kaid") %></td>
                 <td style="display:none;"><asp:Label ID="Label1" runat="server" Text='<%# Eval("Student_id") %>'></asp:Label></td>
             <td><asp:LinkButton ID="LinkButton2"  Class="btn btn-outline-success" PostBackUrl='<%# "Report_Student_Admin?Stu_ID=" + Eval("Student_id") %>'  runat="server"> <i class="fa-solid fa-sheet-plastic">&nbsp; سجل حضور الطالب </i></asp:LinkButton></td>


        </tr>
    </ItemTemplate>

</asp:Repeater>
              <tr>
                   <td><div id="Div3" runat="server"></div></td>

                  </tr>

        </table>
       
       
        </div>


    </div>
   
</asp:Content>
