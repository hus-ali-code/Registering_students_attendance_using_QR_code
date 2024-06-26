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
    public partial class sign_up : System.Web.UI.Page
    {

        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["name"] == "1")
                {
                    Confirm_admin.Visible = true;
                    Confirm_teacher.Visible = false;
                    teacer.Visible = false;
                    admin.Visible = false;


                }
                else if (Request.QueryString["name"] == "2")
                {
                    Confirm_admin.Visible = false;
                    Confirm_teacher.Visible = true;
                    teacer.Visible = false;
                    admin.Visible = false;
                }

            }

            txt_Email_admin.Text = txt_Email_admin_PC.Text;
            txt_Fname_admin.Text = GetAdminFname(txt_Email_admin_PC.Text);
            txt_Sname_admin.Text = GetAdminLname(txt_Email_admin_PC.Text);


            txt_Email_teacher.Text = txt_Email_teacer_PC.Text;
            txt_Fname_teacher.Text = GetTeacherFname(txt_Email_teacer_PC.Text);
            txt_Sname_teacher.Text = GetTeacherLname(txt_Email_teacer_PC.Text);


        }

      

        protected void btn_Confirm_admin(object sender, EventArgs e)
        {


            try
            {//التأكدمن عدم وجود الفراغات وتطابق كلمة المرور ورقم القيد

                if (Page.IsValid)
                { //التأكد من عدم وجود بيانات مكررة
                    if ((Check_Info2()) && (Check_Email() && Check_Code_Admin()))
                    {

                        Confirm_admin.Visible = false;
                        Confirm_teacher.Visible = false;
                        teacer.Visible = false;
                        admin.Visible = true;

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "A", "Error()", true);

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
                if (txt_Fname_admin.Text != "" && txt_Sname_admin.Text != "" && txt_Email_admin.Text != "" && txt_Phone_admin.Text != "" && txt_pass_admin.Text != ""
                && txt_Confirm_pass_admin.Text != "")
                {
                    //التأكد من تطابق كلمة المرور
                    if (txt_pass_admin.Text.Trim() != txt_Confirm_pass_admin.Text.Trim())
                    {
                        //في حال وجود فراغ او غير تطابق في البيانات
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ADw", "Wa()", true);
                        return false;
                    }

                    return true;

                }
                //في حال وجود فراغ او غير تطابق في البيانات
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ADa", "Wa()", true);
                return false;
            }
            catch
            {

                return false;
            }



        }


        public bool Check_PH()
        {
            string PH = txt_Phone_admin.Text.Trim();

            try
            {   //التأكد من وجود رقم هاتف سابق
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "select * from Admins where Phone_number = @PH";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@PH", PH);
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "csaa", "ChPh()", true);

                            return true;
                        }

                    }
                    return false;

                }

            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Bz", "Error()", true);


                return false;
            }




        }



        // دالة إنشاء الحساب المسؤول
        public void InsRec()
        {
            try

            { 
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "UPDATE Admins set Admin_fname=@Fn,Admin_lname=@Ln,pass=@Pas,Phone_number=@Ph where Email= '" + txt_Email_admin.Text+ "'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Fn", txt_Fname_admin.Text.Trim());
                    cmd.Parameters.AddWithValue("@Ln", txt_Sname_admin.Text.Trim());
                    cmd.Parameters.AddWithValue("@Pas", txt_pass_admin.Text.Trim());
                    cmd.Parameters.AddWithValue("@Ph", txt_Phone_admin.Text.Trim());

                    con.Open();
                    cmd.ExecuteNonQuery();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "K", "regS1()", true);

                    Session["adminID"] = GetAdminID(txt_Email_admin.Text);
                    DeleteAdmoinCode(txt_Email_admin.Text);
                   // Response.Redirect("login.aspx");

                }

             }
           catch (Exception ex)
             {
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "B5", "Error()", true);


             }




        }

        //دالة تقوم بجلب رقم المسؤول لوضعه في سيشن 
        public string GetAdminID(string email)
        {

            string adminID = "";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string query = "SELECT Admin_id FROM Admins WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    adminID = reader["Admin_id"].ToString();
                }

                reader.Close();
            }

            return adminID;
        }
        public string GetAdminFname(string email)
        {

            string AdminFname = "";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string query = "SELECT Admin_fname FROM Admins WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    AdminFname = reader["Admin_fname"].ToString();
                }

                reader.Close();
            }

            return AdminFname;
        }
        public string GetAdminLname(string email)
        {

            string AdminLname = "";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string query = "SELECT Admin_lname FROM Admins WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    AdminLname = reader["Admin_lname"].ToString();
                }

                reader.Close();
            }

            return AdminLname;
        }

        // دالة تحذف الرقم السري بعد اتمام انشاء الحساب المسؤول
        public void DeleteAdmoinCode(string email)
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string query = "UPDATE Admins SET Code = NULL WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Email", email);

                command.ExecuteNonQuery();
            }
        }

        //   إنشاء الحساب المسؤول
        protected void btn_signup_admin_Click(object sender, EventArgs e)
        {


            try
            {//التأكدمن عدم وجود الفراغات وتطابق كلمة المرور ورقم القيد

                if (Page.IsValid)
                { //التأكد من عدم وجود بيانات مكررة
                    if ((Check_Info()) && (!Check_PH()))
                    {

                        InsRec();


                    }
                }
            }
            catch//في حال حدوث خطا في إنشاء الحساب
            {


                ScriptManager.RegisterStartupScript(this, this.GetType(), "A", "Error()", true);


            }



        }

        public bool Check_Info2()
        {
            try
            { //التأكد  من عدم وجود فراغ
                if (txt_Code_admin_PC.Text != "" && txt_Email_admin_PC.Text != "")
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
            string Email = txt_Email_admin_PC.Text.Trim();


            try
            {   //التأكد من وجود بريد إلكتروني سابق
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "select * from Admins where Email = @Email  ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            return true;
                        }

                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Awx", "Check_email2()", true);

                    return false;

                }

            }
            catch
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "B", "Error()", true);

                return false;

            }





        }

        public bool Check_Code_Admin ()
        {
            string Email = txt_Email_admin_PC.Text.Trim();
            string Code = txt_Code_admin_PC.Text.Trim();


            try
            {   //التأكد من  رمز التحقق التابع للاميل المدخل 
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "select * from Admins where Email = @Email and Code = @Code ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Code", Code);
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            return true;
                        }

                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "k1", "Check_Code()", true);

                    return false;

                }

            }
            catch
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "B", "Error()", true);

                return false;

            }

          
        }





        /*
                               الاكواد الخاص بالاساتذه في الاسفل   
                               الاكواد الخاص بالاساتذه في الاسفل
                               الاكواد الخاص بالاساتذه في الاسفل
                               الاكواد الخاص بالاساتذه في الاسفل
                                الاكواد الخاص بالاساتذه في الاسفل   
                               الاكواد الخاص بالاساتذه في الاسفل
                               الاكواد الخاص بالاساتذه في الاسفل
                               الاكواد الخاص بالاساتذه في الاسفل
         */


        protected void Button6_Click(object sender, EventArgs e)
        {
            try
            {//التأكدمن عدم وجود الفراغات وتطابق كلمة المرور ورقم القيد

                if (Page.IsValid)
                { //التأكد من عدم وجود بيانات مكررة
                    if ((Check_Email_Teacher() && Check_Code_Teacher()))
                    {
                        Confirm_admin.Visible = false;
                        Confirm_teacher.Visible = false;
                        teacer.Visible = true;
                        admin.Visible = false;

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "A", "Error()", true);

                }
            }
            catch//في حال حدوث خطا في إنشاء الحساب
            {


                ScriptManager.RegisterStartupScript(this, this.GetType(), "A", "Error()", true);


            }



        }


        public bool Check_Email_Teacher()
        {
            string Email = txt_Email_teacer_PC.Text.Trim();


            try
            {   //التأكد من وجود بريد إلكتروني سابق
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "select * from Teachers where Email = @Email  ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            return true;
                        }

                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Awx", "Check_email2()", true);

                    return false;

                }

            }
            catch
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "B", "Error()", true);

                return false;

            }





        }

        public bool Check_Code_Teacher()
        {
            string Email = txt_Email_teacer_PC.Text.Trim();
            string Code = txt_Code_teacher_PC.Text.Trim();


            try
            {   //التأكد من  رمز التحقق التابع للاميل المدخل   
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "select * from Teachers where Email = @Email and Code = @Code ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Code", Code);
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            return true;
                        }

                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "k1", "Check_Code()", true);

                    return false;

                }

            }
            catch
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "B", "Error()", true);

                return false;

            }


        }


        public bool Check_PH_Teacher_()
        {
            string PH = txt_Phone_teacher.Text.Trim();

            try
            {   //التأكد من وجود رقم هاتف سابق
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "select * from Teachers where Phone_number = @PH";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@PH", PH);
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "csaa", "ChPh()", true);

                            return true;
                        }

                    }
                    return false;

                }

            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Bz", "Error()", true);


                return false;
            }




        }
        // دالة إنشاء الحساب الاستاذ
        public void InsRec_Teacher()
        {
            try

            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "UPDATE Teachers set Teacher_Fname=@Fn,Teacher_Lname=@Ln,pass=@Pas,Phone_number=@Ph where Email= '" + txt_Email_teacher.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Fn", txt_Fname_teacher.Text.Trim());
                    cmd.Parameters.AddWithValue("@Ln", txt_Sname_teacher.Text.Trim());
                    cmd.Parameters.AddWithValue("@Pas", txt_pass_teacher.Text.Trim());
                    cmd.Parameters.AddWithValue("@Ph", txt_Phone_teacher.Text.Trim());

                    con.Open();
                    cmd.ExecuteNonQuery();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "K", "regS1()", true);

                    Session["teacherID"] = GetTeacherID(txt_Email_teacher.Text);
                    DeleteTeacherCode(txt_Email_teacher.Text);
                    // Response.Redirect("login.aspx");

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "B5", "Error()", true);


            }




        }

        // دالة تحذف الرقم السري بعد اتمام انشاء الحساب الاستاذ
        public void DeleteTeacherCode(string email)
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string query = "UPDATE Teachers SET Code = NULL WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Email", email);

                command.ExecuteNonQuery();
            }
        }

        //دالة تقوم بجلب رقم الاستاذ لوضعه في سيشن 
        public string GetTeacherID(string email)
        {

            string teacherID = "";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string query = "SELECT Teacher_id FROM Teachers WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    teacherID = reader["Teacher_id"].ToString();
                }

                reader.Close();
            }

            return teacherID;
        }
        public string GetTeacherFname(string email)
        {

            string TeacherFname = "";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string query = "SELECT Teacher_Fname FROM Teachers WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TeacherFname = reader["Teacher_Fname"].ToString();
                }

                reader.Close();
            }

            return TeacherFname;
        }
        public string GetTeacherLname(string email)
        {

            string TeacherLname = "";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string query = "SELECT Teacher_Lname FROM Teachers WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TeacherLname = reader["Teacher_Lname"].ToString();
                }

                reader.Close();
            }

            return TeacherLname;
        }


        //   إنشاء الحساب الاستاذ

        protected void btn_signup_Teacher_Click(object sender, EventArgs e)
        {
            try
            {//التأكدمن عدم وجود الفراغات وتطابق كلمة المرور ورقم القيد

                if (Page.IsValid)
                { //التأكد من عدم وجود بيانات مكررة
                    if ((!Check_PH_Teacher_()))
                    {

                        InsRec_Teacher();


                    }
                }
            }
            catch//في حال حدوث خطا في إنشاء الحساب
            {


                ScriptManager.RegisterStartupScript(this, this.GetType(), "A", "Error()", true);


            }

        }
    }
}