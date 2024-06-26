<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="Home_Student.aspx.cs" Inherits="Registering_students_attendance_using_QR_code.Home_Student" %>
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
            width:100%;
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
               display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  width: 100%;
  margin: 250px 0;
  position: absolute;
  top: auto;
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
                 width: 65%;
                 box-sizing: border-box;
                 float:right;
                 margin-bottom:70px;
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
                  
             <asp:ImageButton ID="ImageButton1" runat="server" src="images/photo_2024-04-25_11-00-43.jpg" PostBackUrl="~/Scan_QRCode_Student.aspx" class="img1" />
           <asp:Button ID="Button2" CssClass="bay" runat="server" PostBackUrl="~/Scan_QRCode_Student.aspx" Text="سجل حضورك " />

        </div> 

         <div class="content">
        
                     <asp:ImageButton ID="ImageButton2" runat="server" src="images/png-clipart-education-a-la-carte-choosing-the-best-schooling-options-for-your-child-text-book-infographic-book-infographic-text.png" PostBackUrl="#" class="img1" />
           <asp:Button ID="Button1" CssClass="bay" runat="server" Text="المسؤولون " PostBackUrl="#" />

        </div>

    </div>

</asp:Content>
