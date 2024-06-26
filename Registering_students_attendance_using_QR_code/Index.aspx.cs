using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Registering_students_attendance_using_QR_code
{
    public partial class login : System.Web.UI.Page
    {

        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                admin.Visible = true;
                teacher.Visible = false;
                student.Visible = false;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedValue == "1")
            {
                admin.Visible = true;
                teacher.Visible = false;
                student.Visible = false;
                DropDownList1.SelectedValue = "0";


            }
            if (DropDownList1.SelectedValue == "2")
            {
                admin.Visible = false;
                teacher.Visible = true;
                student.Visible = false;

                DropDownList1.SelectedValue = "0";

            }
            if (DropDownList1.SelectedValue == "3")
            {
                admin.Visible = false;
                teacher.Visible = false;
                student.Visible = true;
                DropDownList1.SelectedValue = "0";

            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue == "1")
            {
                admin.Visible = true;
                teacher.Visible = false;
                student.Visible = false;

                DropDownList2.SelectedValue = "0";

            }
            if (DropDownList2.SelectedValue == "2")
            {
                admin.Visible = false;
                teacher.Visible = true;
                student.Visible = false;
                DropDownList2.SelectedValue = "0";

            }
            if (DropDownList2.SelectedValue == "3")
            {
                admin.Visible = false;
                teacher.Visible = false;
                student.Visible = true;
                DropDownList2.SelectedValue = "0";

            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedValue == "1")
            {
                admin.Visible = true;
                teacher.Visible = false;
                student.Visible = false;

                DropDownList3.SelectedValue = "0";



            }
            if (DropDownList3.SelectedValue == "2")
            {
                admin.Visible = false;
                teacher.Visible = true;
                student.Visible = false;

                DropDownList3.SelectedValue = "0";

            }
            if (DropDownList3.SelectedValue == "3")
            {
                admin.Visible = false;
                teacher.Visible = false;
                student.Visible = true;

                DropDownList3.SelectedValue = "0";

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/sign_up.aspx?name=1");

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/sign_up.aspx?name=2");

        }
        //       الاكواد الخاصه بتجيل دخول المسؤول في الاسفل  الاكواد الخاصه بتجيل دخول المسؤول في الاسفل  
        //       الاكواد الخاصه بتجيل دخول المسؤول في الاسفل  الاكواد الخاصه بتجيل دخول المسؤول في الاسفل  
        //       الاكواد الخاصه بتجيل دخول المسؤول في الاسفل  الاكواد الخاصه بتجيل دخول المسؤول في الاسفل  
        //       الاكواد الخاصه بتجيل دخول المسؤول في الاسفل  الاكواد الخاصه بتجيل دخول المسؤول في الاسفل  


        protected void Btn_Login_Admin_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {

                //يتم التأكد من معلومات الحساب
                if ((Check_Info()))
                {

                    Session["adminID"] = GetAdminID(txt_Email_Admin.Text);
                    Response.Redirect("home_admin.aspx");
            
                }
                else//خطا في البيانات، او معلومات الحساب
                {
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Errlog1()", true);

                }


            }
            else//تم إدخال معلومات خاطئة
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "C1", "Error()", true);

            }


        }
        //التأكد من وجود الإميل
        public bool Check_Info()
        {


            try
            {   //تأكد من معلومات الحساب
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "select * from Admins where Email = @Email and Pass = @Pass";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Email", txt_Email_Admin.Text.Trim());
                    cmd.Parameters.AddWithValue("@Pass", txt_pass_Admin.Text.Trim());
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {

                            return true;
                        }

                    }
                    return false;

                }

            }
            catch
            {
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "Bzz", "Error()", true);

                return false;

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

        //       الاكواد الخاصه بتجيل دخول الاستاذ في الاسفل  الاكواد الخاصه بتجيل دخول الاستاذ في الاسفل  
        //       الاكواد الخاصه بتجيل دخول الاستاذ في الاسفل  الاكواد الخاصه بتجيل دخول الاستاذ في الاسفل  
        //       الاكواد الخاصه بتجيل دخول الاستاذ في الاسفل  الاكواد الخاصه بتجيل دخول الاستاذ في الاسفل  
        //       الاكواد الخاصه بتجيل دخول الاستاذ في الاسفل  الاكواد الخاصه بتجيل دخول الاستاذ في الاسفل  

        protected void Btn_Login_Teacher_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                //يتم التأكد من معلومات الحساب
                if (Check_Info_Teacher())
                {

                    Session["teacherID"] = GetTeacherID(txt_Email_Teacher.Text);
                    Response.Redirect("home_Teacher.aspx");

                }
                else//خطا في البيانات، او معلومات الحساب
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Errlog1()", true);

                }


            }
            else//تم إدخال معلومات خاطئة
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "C1", "Error()", true);

            }

        }


        public bool Check_Info_Teacher()
        {


            try
            {   //تأكد من معلومات الحساب
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "select * from Teachers where Email = @Email and Pass = @Pass";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Email", txt_Email_Teacher.Text.Trim());
                    cmd.Parameters.AddWithValue("@Pass", txt_Pass_Teacher.Text.Trim());
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {

                            return true;
                        }

                    }
                    return false;

                }

            }
            catch
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Bzz", "Error()", true);

                return false;

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




        //       الاكواد الخاصه بتجيل دخول الطالب في الاسفل  الاكواد الخاصه بتجيل دخول الطالب في الاسفل  
        //       الاكواد الخاصه بتجيل دخول الطالب في الاسفل  الاكواد الخاصه بتجيل دخول الطالب في الاسفل  
        //       الاكواد الخاصه بتجيل دخول الطالب في الاسفل  الاكواد الخاصه بتجيل دخول الطالب في الاسفل  
        //       الاكواد الخاصه بتجيل دخول الطالب في الاسفل  الاكواد الخاصه بتجيل دخول الطالب في الاسفل  


        protected void Btn_Login_Student_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                //يتم التأكد من معلومات الحساب
                if (Check_Info_Student())
                {

                    Session["studentID"] = txt_Number_Student.Text; ;
                    Response.Redirect("home_Student.aspx");

                }
                else//خطا في البيانات، او معلومات الحساب
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "Errlog1()", true);

                }


            }
            else//تم إدخال معلومات خاطئة
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "C1", "Error()", true);

            }
        }


        public bool Check_Info_Student()
        {


            try
            {   //تأكد من معلومات الحساب
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "select * from Students where Student_NAT = @NAT and Student_id = @ID";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@NAT", txt_NAT_Student.Text.Trim());
                    cmd.Parameters.AddWithValue("@ID", txt_Number_Student.Text.Trim());
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {

                            return true;
                        }

                    }
                    return false;

                }

            }
            catch
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Bzz", "Error()", true);

                return false;

            }

        }

    }

}