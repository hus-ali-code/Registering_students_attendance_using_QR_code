using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Registering_students_attendance_using_QR_code
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*      private bool IsRealEmail(string email)
              {
                  string accessKey = "4dd236d3ae5ac6c26d1a95ca84844bdd3719416d";
                  string apiUrl = $"https://api.hunter.io/v2/email-verifier?email={email}&api_key=4dd236d3ae5ac6c26d1a95ca84844bdd3719416d";
                  using (var client = new WebClient())
                  {
                      var response = client.DownloadString(apiUrl);
                      dynamic result = JsonConvert.DeserializeObject(response);
                      bool isValid = Convert.ToBoolean(result.mx_found);
                      return isValid;
                  }
              }
              
        protected void Button1_Click(object sender, EventArgs e)
        {
             if (IsRealEmail(TextBox1.Text))
            {
                Label1.Text = "موجود";
            }
            else
            {
                Label1.Text = "موجود غير";

            } 

            sbtBtn_Click();

    }  */


        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text.ToString().Trim();

            if (string.IsNullOrEmpty(email))
            {
                // يمكنك استبدال هذه الرسالة بأي نص تريده
                Response.Write("<script>alert('لم يتم العثور على عنوان البريد الإلكتروني.');</script>");
                return;
            }

            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress("yhyyatlwbh@gmail.com");
            mail.Subject = "تأكيد بريدك الإلكتروني في موقع تسجيل الحضور بكلية العلوم التقنية ";

            Random random = new Random();
            string code = random.Next(100000, 999999).ToString("D6");

            string Msg = @"<div style='background:#F2F2F2; padding: 30px;'> <div style='text-align: center;'> <img src='https://i.postimg.cc/j5ZCg3w8/5156366.jpg' style='width: 150px;'> <h1 style='font-size: 24px; color: #1A237E;'>أهلاً بكم في موقعنا </h1> </div> <div style='font-size: 18px;'> <p style='color: #333;text-align:right'>نرحب بكم ونشكركم على تسجيلكم معنا. من فضلك قم بتأكيد بريدك الإلكتروني.</p> </div> <div style='text-align: center; font-size:20px;'> <a href='#' style='background-color: #20B2AA; color: white; padding: 10px 30px; text-decoration: none;text-align:right;direction:rtl;color:White; font-weight: 700;' > " + code + @": رمز التحقق هو </a> </div> </div>";

            mail.Body = Msg;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587; // 25 465
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new NetworkCredential("yhyyatlwbh@gmail.com", "rmom ahjg tyso arup");

            smtp.Send(mail);
        }



    }
}