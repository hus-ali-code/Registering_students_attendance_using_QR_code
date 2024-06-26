<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="QR_Code.aspx.cs" Inherits="Registering_students_attendance_using_QR_code.QR_Code" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
         .Reg_S {
        border:solid 2px #444;
            overflow:auto;
            height:620px;
            margin-bottom:10px;
            
            
            
     } 
         .border0{

                     border:solid 2px #444;
         }
    </style>

</asp:Content>

 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

       <div id="Div1" runat="server" class="row">
    <div class="col-12">
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Home_Teacher.aspx" style="width:15%;" CssClass="btn btn-outline-danger  mb-1 mt-1"><i class="fa-solid fa-arrow-right fs-4">   انهاء التسجيل</i></asp:LinkButton>
    </div>
</div>

     <div id="Div_QR_Code_Page" runat="server" class="row QR">
          <div id="qrCodeContainer" runat="server" class="col-sm-12 col-lg-5 border0">
                          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
                  <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick">
                  </asp:Timer>
                         
            <h3 style="display:flex; justify-content:center; align-items:center;">مسح الرمز للحضور</h3>
            <p style="display:flex; justify-content:center; align-items:center;" class="align-middle">
                <asp:Image ID="Image1" runat="server" style="width:360px;height:310px;"/>
            </p>
              </ContentTemplate>
      </asp:UpdatePanel>
        </div>

        <!-- تسجيل الحضور يدوي -->
        <div class="col-sm-12 col-lg-7 container Reg_S"  runat="server" onscroll="scr()" id="Div_Reg_Static">
            <h3 class="d-flex justify-content-center align-content-center">تسجيل الحضور يدوي</h3>
            <div style="display:inline-flex;float:left;width:70%; margin-bottom:8PX; margin-top:8PX;">
                <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-outline-primary m-0 " style="display:inline-block;width:9%;height:36px;border-bottom-right-radius:20px;border-top-right-radius:20px;border-top-left-radius:0;border-bottom-left-radius:0;" OnClick="LinkButton2_Click"><i class="fa-solid fa-magnifying-glass" style="font-size:18px;border-rad"></i></asp:LinkButton>
                <asp:TextBox ID="txt_Searsh_Student" runat="server" placeholder="بحث بالاسم او رقم القيد" class="form-control form-control-sm sm-light border-primary m-0  txt1" style="display:inline-block;width:50%;height:35px;border-bottom-right-radius:0;border-top-right-radius:0;border-top-left-radius:20px;border-bottom-left-radius:20px;text-align:center;border-right:0;" Font-Bold="false" Font-Size="13"></asp:TextBox>
            </div>
            <table class="table table-striped table-hover">
                <asp:Repeater ID="Repeater_Stu" runat="server" OnItemCommand="Repeater_Stu_ItemCommand">
                    <HeaderTemplate>
                        <tr Class="table-dark text-center" style="font-size:12pt;font-weight:bold">
                            <th> الصورة </th>
                            <th>الاسم</th>
                             <th>رقم القيد</th>
                            <th>تسجيل الحضور</th>
                            <th>الغاء الحضور</th>
                            <th>سجل الطالب</th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="text-center align-middle" style="font-size:15pt; font-weight:bold">
                            <td class="m-0 p-0 text-center">
                                <img src='<%# Eval("Photo") %>' style="width:100px; height:120px;" />
                            </td>
                            <asp:Label ID="Label1" Visible="false" runat="server" Text='<%# Eval("Student_id") %>'></asp:Label>
                            <td><%# Eval("Student_Fname") %> <%# Eval("Student_Sname") %> <%# Eval("Student_Lname") %></td>
                             <td><%# Eval("Student_Kaid") %></td>

                            <td>
                                <asp:LinkButton ID="LinkButton3" Class="btn btn-outline-success" CommandName="reg" style="font-size:12pt;font-weight:bold" runat="server" >
                                    <i class="fa-solid fa-check"> </i>
                                </asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton4" Class="btn btn-outline-danger" CommandName="cancel_reg" style="font-size:11pt;font-weight:bold" runat="server" >
                                    <i  class="fa-solid fa-xmark"> </i>
                                </asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton1" Class="btn btn-outline-primary" style="font-size:12pt;font-weight:bold" runat="server" PostBackUrl="#">
                                    <i class="fa-solid fa-sheet-plastic"></i>
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td><div id="pagingDiv" runat="server"></div></td>
                </tr>
            </table>
            <p runat="server" class="text-center align-middle" id="P_Searsh" style="font-size:x-large">تسجيل يدوي !! ابحث عن الطالب ؟</p>
        </div>
    </div>


    

</asp:Content>
