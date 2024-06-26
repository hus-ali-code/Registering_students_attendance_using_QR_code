<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Registering_students_attendance_using_QR_code.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container justify-content-center align-items-center" style="width:700px;height:700px; direction: ltr;">
        <br /><br /><br />

        <br />  <asp:FileUpload ID="FileUpload1" runat="server" /><br />
  <br />  <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /><br />
  <br />  <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
        <br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />

    </div>

</asp:Content>
