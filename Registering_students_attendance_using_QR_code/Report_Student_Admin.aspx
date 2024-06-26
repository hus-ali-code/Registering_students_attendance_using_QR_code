<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Report_Student_Admin.aspx.cs" Inherits="Registering_students_attendance_using_QR_code.Report_Student_Admin" %>
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
       
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Report_Admin.aspx" CssClass="btn btn-outline-primary mb-3 mt-0"><i class="fa-solid fa-arrow-right fs-4">   رجوع</i></asp:LinkButton>

        <div class="div1">
            
            <h3 class="m-2">  <b>التقارير</b></h3>
             <div class="btn1">
             <asp:LinkButton ID="LBtn_Import_Courses" runat="server" CssClass="btn btn-outline-success btn-lg ms-2 " ><i class="fa-solid fa-file-arrow-up fs-5">  طباعة التقرير </i></asp:LinkButton>
             </div>
        </div>


        <div class="div2">
            <!--    ___________________________________________________________________________________________________________   -->
      

            <div class="m-2">
                <% %>
             </div>
            <div class="m-2">
                <% %>
                </div>
             <div class="m-2">
                <% %>
                </div>

            <!-- __________________________________________________________________________________________________________________ -->


        </div>

            <!-- __________________________________________________________________________________________________________________ -->
            <!-- __________________________________________________________________________________________________________________ -->
            <!-- __________________________________________________________________________________________________________________ -->

                    
        <div class="div3" runat="server" id="Div_Searsh_Stu">
        


        </div>

            <div class="Stu" runat="server" id ="Div_tbl_Stu">

                        

               <table class="table table-striped table-hover" >

            <asp:Repeater ID="Repeater1" runat="server"   >
    <HeaderTemplate>
            <tr  Class="table-dark text-center" style="font-size:18pt;font-weight:bold;height:35px;">
                <th>المادة</th>
                 <th>ايام الحضور </th>
                 <th>ايام الغياب </th>
                 <th>نسبة الحضور </th>
               
            </tr>
    </HeaderTemplate>
 <ItemTemplate>
        <tr style="font-size:15pt; font-weight:bold" class="text-center align-middle">
            <td><%# Eval("Course_name") %></td>

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
