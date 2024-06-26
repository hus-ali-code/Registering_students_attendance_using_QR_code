using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Registering_students_attendance_using_QR_code
{
    public partial class admin_admin : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                add_admin.Visible = false;

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            add_admin.Visible = true;

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            add_admin.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {//التأكدمن عدم وجود الفراغات 

                if (Page.IsValid)
                { //التأكد من عدم وجود بيانات مكررة
                    if ((Check_Info()) && (!Check_Email()))
                    {

                        InsRec();
                        txt_Lname.Text = "";
                        txt_Fname.Text = "";
                        txt_Email.Text = "";

                        add_admin.Visible = false;


                    }
                }
            }
            catch//في حال حدوث خطا في إنشاء الحساب
            {


                ScriptManager.RegisterStartupScript(this, this.GetType(), "A", "Error()", true);



            }
        }


        public bool Check_Info()
        {
            try
            { //التأكد  من عدم وجود فراغ
                if (txt_Email.Text != "" )
                {
                    
                    return true;

                }
                //في حال وجود فراغ او غير تطابق في البيانات
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ADa", "Wa1()", true);
                return false;
            }
            catch
            {

                return false;
            }



        }



        public bool Check_Email()
        {
            string Email = txt_Email.Text.Trim();

            try
            {   //التأكد من وجود بريد إلكتروني سابق
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "select * from Admins where Email = @Email";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Awx", "Check_email()", true);

                            return true;
                            
                        }

                    }
                    return false;

                }

            }
            catch
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "B", "Error()", true);

                return false;

            }





        }

        //إرسال رمز التحقق إلى البريد الإلكتروني
        protected string sbtBtn_Click()
        {
             MailMessage mail = new MailMessage();
              mail.To.Add(txt_Email.Text.ToString().Trim());
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
              smtp.Credentials = new System.Net.NetworkCredential("yhyyatlwbh@gmail.com", "rmom ahjg tyso arup");
              smtp.Send(mail);
              

            return code;
        }
        //دالة إنشاء الحساب مبدئيا
        public void InsRec()
        {


            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "insert into Admins (Admin_fname,Admin_lname,Email,Code)values(@fn,@ln,@Em,@Cd)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@fn", txt_Fname.Text.Trim());
                    cmd.Parameters.AddWithValue("@ln", txt_Lname.Text.Trim());
                    cmd.Parameters.AddWithValue("@Em", txt_Email.Text.Trim());
                    cmd.Parameters.AddWithValue("@Cd", sbtBtn_Click().ToString());

                    con.Open();
                    cmd.ExecuteNonQuery();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "K", "regS1()", true);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Bzz", "Error()", true);


            }




        }




    }
}