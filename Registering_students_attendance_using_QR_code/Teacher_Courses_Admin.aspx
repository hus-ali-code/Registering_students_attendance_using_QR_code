<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="Teacher_Courses_Admin.aspx.cs" Inherits="Registering_students_attendance_using_QR_code.teacher_courses_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <link href="bootstrap-5.2.3-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="bootstrap-5.2.3-dist/css/all.min.css" rel="stylesheet" />
    <link href="bootstrap-5.1.3-dist/css/all.min.css" rel="stylesheet" />

     <style>

 
    .pagination {
        text-align: center;
        margin-top: 10px;
    }
    
    .prevButton,
    .nextButton {
        padding: 5px 10px;
        margin: 0 5px;
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
            margin-bottom: 10px;

        }
        .div3 {
            display: flex;
            justify-content:flex-start;
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
         .ddd{
            background-color:#c3e9f3;
            width:50%;
            border:solid 2px #444;
            overflow:auto;
            height:400px;
            margin-bottom:10px;
        }
       
        .m-2{
            display:inline-flex;
        }
         .mm{

             display:inline-flex;
             float:left;
             margin-left:25px;
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

.div4 label {
    margin-right: 10px; /* تعديل هامش الكلمة عن يمينها */
    margin-bottom: 5px; /* تعديل هامش الكلمة عن الأسفل */
}

.div4 input[type="checkbox"] {
    margin-right: 5px; /* تعديل هامش مربع الاختيار عن يساره */
}
.btn1{
    position:relative;
    top:130px;
    right:80px;
    margin:20px;
    width:130px;
    height:70px;
}
         .auto-style1 {
             direction: ltr;
         }

         #pagingDiv , #pagingDiv span, #pagingDiv a{
             margin:10px;
         }
        

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container">

           <div class="auto-style1">

           <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Home_Admin.aspx" CssClass="btn btn-outline-primary mb-3 mt-0"><i class="fa-solid fa-arrow-right fs-4">   الرئيسية</i></asp:LinkButton>

           </div>

        <div class="div1">
           
            <h3 class="m-2">مواد الاساتذة</h3>
 <div class="me-2 mm" style="display:inline-flex;float:left;">
             
           <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-outline-primary mb-2" style="width:70px;" OnClick="LinkButton1_Click"><i class="fa-regular icon fa-floppy-disk fs-1"> </i>حفظ</asp:LinkButton>
         
           </div>
        </div>
        <div class="div2">

             <div class=" m-2">
            <h4><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h4>
                 <asp:Label ID="teacherID" Visible="false" runat="server" Text="Label"></asp:Label>
             </div>
            
            <div class=" m-2">
            <h4 class="ms-2">مواد بلا استاذ</h4>
            <label class="C1">
          <asp:CheckBox ID="CheckBox2" runat="server"  />
  <svg viewBox="0 0 64 64" height="1.5em" width="1.5em">
    <path d="M 0 16 V 56 A 8 8 90 0 0 8 64 H 56 A 8 8 90 0 0 64 56 V 8 A 8 8 90 0 0 56 0 H 8 A 8 8 90 0 0 0 8 V 16 L 32 48 L 64 16 V 8 A 8 8 90 0 0 56 0 H 8 A 8 8 90 0 0 0 8 V 56 A 8 8 90 0 0 8 64 H 56 A 8 8 90 0 0 64 56 V 16" pathLength="575.0541381835938" class="path"></path>
  </svg>
</label>
                </div>

        </div>
        <div class="div3">
            <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="بحث" OnClick="Button1_Click" />
          <asp:TextBox ID="TextBox1" runat="server" placeholder="البحث..." class="form-control" Style="width:27%;"></asp:TextBox>
          
            <h4 class="me-3 ms-3">بحث متقدم</h4>
 <label class="C1">
          <asp:CheckBox ID="ckb_Advanced_Search" runat="server"  />
  <svg viewBox="0 0 64 64" height="1.5em" width="1.5em">
    <path d="M 0 16 V 56 A 8 8 90 0 0 8 64 H 56 A 8 8 90 0 0 64 56 V 8 A 8 8 90 0 0 56 0 H 8 A 8 8 90 0 0 0 8 V 16 L 32 48 L 64 16 V 8 A 8 8 90 0 0 56 0 H 8 A 8 8 90 0 0 0 8 V 56 A 8 8 90 0 0 8 64 H 56 A 8 8 90 0 0 64 56 V 16" pathLength="575.0541381835938" class="path"></path>
  </svg>
</label>       
            
            <asp:DropDownList ID="DDL_dept" runat="server" placeholder="البحث..." class="form-control ms-3 me-3"  Style="width:25%;" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Dept_name" DataValueField="Dept_id"></asp:DropDownList>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:QR_Code_CollegConnectionString %>" SelectCommand="SELECT * FROM [Department]"></asp:SqlDataSource>
            <asp:DropDownList ID="DDL_Div" runat="server" placeholder="البحث..." class="form-control"  Style="width:25%;" DataSourceID="SqlDataSource2" DataTextField="Division_name" DataValueField="Division_id" AutoPostBack="True"></asp:DropDownList>
           
             <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:QR_Code_CollegConnectionString %>" SelectCommand="SELECT DISTINCT [Division_name], [Division_id] FROM [Division] WHERE ([Dept_id] = @Dept_id)">
                 <SelectParameters>
                     <asp:ControlParameter ControlID="DDL_dept" Name="Dept_id" PropertyName="SelectedValue" Type="Int32" />
                 </SelectParameters>
             </asp:SqlDataSource>

                
        </div>
              <div class="div4">
            <table class="table table-striped table-hover">
<asp:Repeater ID="myRepeater" runat="server">
    <HeaderTemplate>
      
            <tr  Class="table-dark" style="font-size:18pt;font-weight:bold">
                <th>القسم </th>
                <th>الشعبة</th>
                <th> المادة</th>
                <th> اختر المادة</th>

            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr style="font-size:15pt; font-weight:bold">

           <td><%# Eval("Dept_name") %></td>
            <td><%# Eval("Division_name") %></td> 

            <td><%# Eval("Course_name") %></td>
            <asp:Label ID="CourseID" runat="server" Visible="false" Text='<%# Eval("Course_id") %>'></asp:Label>

          


            <td>
             <label class="C1">
          <asp:CheckBox ID="CheckBox1" runat="server"    />
  <svg viewBox="0 0 64 64" height="1.5em" width="1.5em">
    <path d="M 0 16 V 56 A 8 8 90 0 0 8 64 H 56 A 8 8 90 0 0 64 56 V 8 A 8 8 90 0 0 56 0 H 8 A 8 8 90 0 0 0 8 V 16 L 32 48 L 64 16 V 8 A 8 8 90 0 0 56 0 H 8 A 8 8 90 0 0 0 8 V 56 A 8 8 90 0 0 8 64 H 56 A 8 8 90 0 0 64 56 V 16" pathLength="575.0541381835938" class="path"></path>
  </svg>
</label>
</td>

        </tr>
    </ItemTemplate>
    <FooterTemplate>


       
    </FooterTemplate>

</asp:Repeater>

                  <tr>
                   <td><div id="pagingDiv" runat="server"></div></td>

                  </tr>

        </table>
                  






        </div>
        </div>
   

</asp:Content>
