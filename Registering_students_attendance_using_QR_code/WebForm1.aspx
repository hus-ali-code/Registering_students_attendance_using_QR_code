<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Registering_students_attendance_using_QR_code.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            direction: ltr;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        <p>

        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        </p>
        <p class="auto-style1">

        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </p>
    </form>
</body>
</html>
