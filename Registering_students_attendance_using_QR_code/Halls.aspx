<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Halls.aspx.cs" Inherits="Registering_students_attendance_using_QR_code.Groups" %>
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
        .m-2{
            display:inline-flex;
        }

                .add_Hall{
               background:#92c3f7;
    width:600px;
    height:300px;
    position:absolute;
    top:250px;
    right:550px;
    display:none;

        }
                 .Edit_Hall{
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

                    @media  screen and (min-width:801px) and (max-width:1200px) 
                  {
            

                
        .add_Hall
        {
            
                     background:#92c3f7;
                     width:600px;
                     height:300px;
                     position:absolute;
                     top:250px;
                     right:200px;
                     display:none;


        }
          .Edit_Hall
        {
            
                     background:#92c3f7;
                     width:600px;
                     height:300px;
                     position:absolute;
                     top:250px;
                     right:200px;
                     display:none;


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
                .add_teach{

                     background:#92c3f7;
                     width:600px;
                     height:400px;
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



    <div class="container" >
        
                      <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Home_Admin.aspx" CssClass="btn btn-outline-primary mb-3 mt-0"><i class="fa-solid fa-arrow-right fs-4">   الرئيسية</i></asp:LinkButton>

        <div class="div1">
            
            <h3 class="m-2">ادارة القاعات</h3>
            <asp:Button ID="btn_Show_Hall" runat="server" class="btn btn-outline-success btn-lg " Text="إضافة قاعة" OnClick="btn_Show_Hall_Click"  />
        </div>


           <!-- ----------------------------------------------------------- اضافة قاعه---------------------------------------------------- -->
   
            <div runat="server" id="add_Hall" class="d-flex justify-content-center align-items-center border rounded-5 p-3 bg-white shadow add_Hall">
                 
                          <div class=" col-lg-6 col-md-12 right-box">

                       
                      <asp:Button ID="btn_X" runat="server" Text="X" CssClass="btn btn-sm btn-danger" Style="position:absolute;top:0;right:0; width:45px;height:45px; font-size:25px; border-radius:5px;" OnClick="btn_X_Click"   />
                     

                 <div class="row align-items-center">
                     <div class="header-text  mb-1" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>اضافة قاعه </h2>
                     </div>
                  <div class="from-group mb-4">
                         <p style="font-size:20px;">اسم القاعة  :</p> <asp:TextBox ID="txt_name_Hall" runat="server" Enabled="true" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="اسم القاعة " style="display:inline-block;width:95%" MaxLength="15"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*" ControlToValidate="txt_name_Hall" style="color:red;font-size:30px;" ValidationGroup="G1" Display="Static"></asp:RequiredFieldValidator>
                                         </div>

                      <div class=" d-flex justify-content-center align-items-center">
                      <asp:Button ID="btn_add_Hall" runat="server" ValidationGroup="G1" Text="اضافة " CssClass="btn btn-lg btn-primary  fs-6 ms-2"  Style="width:65%" OnClick="btn_add_Hall_Click"  />

                       
                     </div>

                 </div>

            </div>

            </div>
              <!-- ----------------------------------------------------------- نهاية---------------------------------------------------- -->

         <!-- ----------------------------------------------------------- تعديل قاعه---------------------------------------------------- -->
   
            <div runat="server" id="Edit_Hall" class="d-flex justify-content-center align-items-center border rounded-5 p-3 bg-white shadow Edit_Hall">
                 
                          <div class=" col-lg-6 col-md-12 right-box">

                       
                      <asp:Button ID="Button2" runat="server" Text="X" CssClass="btn btn-sm btn-danger" Style="position:absolute;top:0;right:0; width:45px;height:45px; font-size:25px; border-radius:5px;" OnClick="Button2_Click"   />
                     

                 <div class="row align-items-center">
                     <div class="header-text  mb-1" style=" display:flex; justify-content:center; align-items:center;">
                         <h2>اضافة قاعه </h2>
                     </div>
                  <div class="from-group mb-4">
                         <p style="font-size:20px;">تعديل اسم القاعه :</p> <asp:TextBox ID="txt_Edit_nameHall" runat="server" Enabled="true" CssClass="form-control form-control-lg bg-light fs-6 txt1" placeholder="اسم القاعة " style="display:inline-block;width:95%" MaxLength="15"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ControlToValidate="txt_Edit_nameHall" style="color:red;font-size:30px;" ValidationGroup="G2" Display="Static"></asp:RequiredFieldValidator>
                                         </div>
                     <asp:TextBox ID="txt_edit_id" Visible="false" runat="server"></asp:TextBox>

                      <div class=" d-flex justify-content-center align-items-center">
                      <asp:Button ID="Button3" runat="server" ValidationGroup="G2" Text=" تعديل" CssClass="btn btn-lg btn-primary  fs-6 ms-2"  Style="width:65%" OnClick="Button3_Click" />

                       
                     </div>

                 </div>

            </div>

            </div>
              <!-- ----------------------------------------------------------- نهاية---------------------------------------------------- -->



        <div class="div2">

             <div class=" m-2">
            <h4>الكل</h4>
            <input type="checkbox" class="me-3">
             </div>
            
            <div class=" m-2">
            <h4>المعروض</h4>
            <input type="checkbox" class=" me-3">
                </div>


        </div>
        <div class="div3">
            <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="بحث" OnClick="Button1_Click" />
            <asp:TextBox ID="txt_Searsh" runat="server" placeholder="البحث..." class="form-control" Style=" width:60%;" ></asp:TextBox>
        </div>
        <div class="div4">
                        <table class="table table-striped table-hover">

            <asp:Repeater ID="Repeater_Hall" runat="server" OnItemCommand="Repeater_Hall_ItemCommand">
    <HeaderTemplate>
            <tr  Class="table-dark text-center" style="font-size:18pt;font-weight:bold">
                <th>اسم القاعة</th>
                <th>تعديل</th>
                <th>حذف </th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr class="text-center align-middle" style="font-size:15pt; font-weight:bold">
      <td style="display:none;">  <asp:Label ID="Label2" runat="server" Text='<%# Eval("Hall_id") %>'></asp:Label></td>   
    <td >  <asp:Label ID="Label1" runat="server" Text='<%# Eval("Hall_name") %>'></asp:Label></td>

    <td >
        <asp:LinkButton ID="LinkButton1" Class="btn btn-outline-success" style="font-size:15pt;font-weight:bold" CommandName="Edit" runat="server">
            <i class="fa-solid fa-sheet-plastic">&nbsp; تعديل   </i>
        </asp:LinkButton>
    </td>
    <td >
        <asp:LinkButton ID="LinkButton3" Class="btn btn-outline-danger" style="font-size:15pt;font-weight:bold" CommandName="delete" runat="server">
            <i class="fa-solid fa-trash-can">&nbsp; حذف   </i>
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
