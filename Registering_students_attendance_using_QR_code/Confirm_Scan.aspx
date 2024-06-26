<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirm_Scan.aspx.cs" Inherits="Registering_students_attendance_using_QR_code.Confirm_Scan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="Styles/sweetalert.css" rel="stylesheet" />
    <script src="Scripts/sweetalert.min.js"></script>
    <link href="bootstrap-5.2.3-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="bootstrap-5.2.3-dist/css/all.min.css" rel="stylesheet" />
    <link href="bootstrap-5.1.3-dist/css/all.min.css" rel="stylesheet" />

       <style>
       
      @import url('https://fonts.googleapis.com/css2?family=Tajawal:wght@200;300;400;500;700;800;900&display=swap');
 
   body{
       direction:rtl;
       font-family:"Tajawal",sans-serif;
       text-align:right;
   }
   .navbar{
       box-shadow: 1px 2px 5px #444;
        background-color:#071c33;
            color:#fff;
   }
        footer{
          
                 background-color: #071c33;
                 color: #fff;
                 clear: both;
                 position:absolute;
                 right:0;
                 left:0;
                 bottom:0;
            

        }

        footer h3 {
            background:#fff;
            color:#222;
            display:inline-block;
            font-size:16px;
            margin: 0 0 10px;
            padding: 10px 20px;
            text-transform: uppercase;
        }
                    .footer .contact ul svg
            {
                width:20px;
                height:20px;
            }
            footer .facebook {
                background-color: #1877f2;
            }
            footer .twitter {
                background-color: #1da1f2;
            }
            footer .location {
                background-color: #fff;
                color:#25d366
            }
            footer .whatsapp {
                background-color: #25d366;
            }
            footer .telegram {
                background-color: #0088cc;
            }
             .footer .contact ul svg
            {
                width:20px;
                height:20px;
            }
             footer ul li a:hover
             ,.a1:hover{
                 border:2px solid #fff;
                 border-radius:5px;
                 
             }

             h3{
           text-align:center;
           font-size:30px;
           margin:0;
           padding-top:10px;

       }
       a{
           text-decoration:none;

       }
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


              .cont{
  display: flex;
  justify-content: center;
  align-items: center;
  height: 75vh; /* استخدام طول الشاشة الكامل */
}

                      .cont1{
  display: flex;
  justify-content: center;
  align-items: center;
  width:800px; 
  height:500;
}

#reader {
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}

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



        .cont {
  display: flex;
  justify-content: center;
  align-items: center;
}

        .cont1{
  display: flex;
  justify-content: center;
  align-items: center;
  width:600px; 
  height:500;
  margin:10px;
}

#reader {
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}
 

              </style>


</head>
<body>
    <form id="form1" runat="server">


        
        <nav class=" navbar navbar-expand-lg navbar-light">
  <div class="container-fluid">

       <img src="images/photo.jpg" style="border-radius:10px; width:144px;height:110px;" />
    <img   src="images/photo.jpg" style=" width:150px;height:120px;"  class="navbar-toggler" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
     
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
          <h1> كلية العلوم التقنية </h1>
      </ul>
        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
            
            <a class="navbar-brand" style=" background-color:#071c33;color:#fff;" href="#">حساب المستخدم</a>

       </ul> 
      
    </div>
  </div>
</nav>
        
       <!-- _________________________________________________هذا الجزء خاص بفتح الكامرا_________________________________________________________________ -->


      
    </form>
</body>
</html>
