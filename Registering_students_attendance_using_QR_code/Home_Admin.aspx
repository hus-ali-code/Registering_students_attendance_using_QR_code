<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Home_Admin.aspx.cs" Inherits="Registering_students_attendance_using_QR_code.Admin_Pages.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


       <style> 
        
         .gallery{
           display:flex;
          flex-wrap:wrap;
           width:100%;
           justify-content:center;
           align-items:center;
           margin: 50px 0;

           
       }
       .content{
           width:30%;
           margin: 15px;
           box-sizing:border-box;
           float:left;
           text-align:center;
           border-radius:20px;
           cursor:pointer;
           padding-top: 10px;
           box-shadow: 0 14px 28px rgba(0,0,0,0.25), 0 10px 10px rgba(0,0,0,0.22);
           transition:.4s;
           background:#f2f2f2;
            min-height:15px;


       }
        .content:hover{
         box-shadow: 0 14px 28px rgba(0,0,0,0.16), 0 10px 10px rgba(0,0,0,0.23);
         transform: translate(0PX, -8PX);

        }
        .img1{
            width:200px;
            margin:15px;
            height:200px;
            text-align:center;
            margin: 0 auto;
            display: block;

        }

        
         
         .bay{
             text-align:center;
             font-size:24px;
             color:#fff;
             width:100%;
             padding:15px;
             border:0;
             outline:none;
             cursor:pointer;
             margin-top:5px;
             border-bottom-right-radius:20px;
             border-bottom-left-radius:20px;
             background:#2183a2;

         }
         .bay-3{
             background:#2183a2;

         }
         .bay-4{
             background:#3b3e6e;

         }

           

            

             @media only screen and (max-width:780px){


             body{
                 min-height:100vh;
                 display:flex;
                 flex-direction:column;

             }
                .gallery
               {
           display:inline;
           flex-wrap:wrap;
           width:100%;
           justify-content:center;
           align-items:center;
           margin: 50px 0;
               }

                footer
                {
                background-color:#071c33;
                color:#fff;
                padding-top:30px; 
                position:absolute;
                right:0;
                left:0;
                bottom:0;
           
        
                }
            .content
            {
           width:70%;
           
           box-sizing:border-box;
           margin:15px 15% 15%;
           text-align:center;
           border-radius:20px;
           cursor:pointer;
           padding-top: 10px;
           box-shadow: 0 14px 28px rgba(0,0,0,0.25), 0 10px 10px rgba(0,0,0,0.22);
           transition:.4s;
           background:#f2f2f2;
           min-height:3px;


            }
            
                     

             }

         @media  screen and (min-width:801px) and (max-width:1200px) {

             .gallery {
                 display: inline;
                 flex-wrap: wrap;
                 width: 100%;
                 justify-content: center;
                 align-items: center;
                 margin: 50px 0;
                 position:absolute;
                 top:auto;
             }

             footer {
                 background-color: #071c33;
                 color: #fff;
                 padding-top: 30px;
                 clear: both;
                 position:absolute;
                 right:0;
                 left:0;
                 bottom:0;
             }

             .content {
                 width: 46%;
                 box-sizing: border-box;
                 float:right;
                 margin:15px 10% 10% 10px 10px;
                 text-align: center;
                 border-radius: 20px;
                 cursor: pointer;
                 padding-top: 10px;
                 box-shadow: 0 14px 28px rgba(0,0,0,0.25), 0 10px 10px rgba(0,0,0,0.22);
                 transition: .4s;
                 background: #f2f2f2;
                 min-height: 15px;
             }
         }

 
    </style> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="gallery">
       
         <div class="content">
                  
             <asp:ImageButton ID="ImageButton1" runat="server" src="images/edit.png" PostBackUrl="~/Teacher_Admin.aspx" class="img1" />
           <asp:Button ID="Button2" CssClass="bay" runat="server" PostBackUrl="~/Teacher_Admin.aspx" Text="الاساتذة" />
        </div> 

         <div class="content">
           
                     <asp:ImageButton ID="ImageButton2" runat="server" src="images/WhatsApp%20Image%202024-05-07%20at%208.46.53%20PM%20(1).jpeg" PostBackUrl="~/Admin_Admin.aspx" class="img1" />
           <asp:Button ID="Button1" CssClass="bay" runat="server" Text="المسؤولون " PostBackUrl="~/Admin_Admin.aspx" />

        </div>

         <div class="content">
        
             <asp:ImageButton ID="ImageButton3" runat="server" PostBackUrl="~/Student_Admin.aspx"  class="img1" src="images/611f4fc2-621c-4649-891d-ee859d6ca4d5-image.jpg"/>
           <asp:Button ID="Button3" CssClass="bay" runat="server" Text="الطلبة" PostBackUrl="~/Student_Admin.aspx" />

        </div> 
         
         <div class="content">

             <asp:ImageButton ID="ImageButton4" PostBackUrl="~/Dept_Div_Courses_admin.aspx" runat="server" src="images/png-clipart-education-a-la-carte-choosing-the-best-schooling-options-for-your-child-text-book-infographic-book-infographic-text.png"  class="img1"  />
           <asp:Button ID="Button4" CssClass="bay"  PostBackUrl="~/Dept_Div_Courses_admin.aspx" runat="server" Text="الاقسام والشعب و المواد" />

</div> 
         
         <div class="content">
        
             <asp:ImageButton ID="ImageButton5" PostBackUrl="~/Halls.aspx" runat="server" src="images/img5.png" class="img1"  />
           <asp:Button ID="Button5"  PostBackUrl="~/Halls.aspx" CssClass="bay" runat="server" Text="القاعات" />

        </div> 
         
         <div class="content">
             <asp:ImageButton  ID="ImageButton6" runat="server" PostBackUrl="#"  src="images/png-clipart-learning-educational-technology-distance-education-pedagogy-teacher-text-logo.png" class="img1" />
           <asp:Button ID="Button6" CssClass="bay" runat="server" Text="التقارير" />

        </div>

    </div>

</asp:Content>
