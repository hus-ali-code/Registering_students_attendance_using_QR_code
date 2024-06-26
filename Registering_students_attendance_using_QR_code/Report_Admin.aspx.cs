using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Registering_students_attendance_using_QR_code
{
    public partial class Report_Admin : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Div_Searsh_Stu.Visible = false;
                Div_tbl_Stu.Visible = false;
                FillRepeater_Courses();

            }


            FillRepeater_Stu();
        }

        protected void Rbtn_Stu_CheckedChanged(object sender, EventArgs e)
        {
            Div_Searsh_Stu.Visible = true;
            Div_tbl_Stu.Visible = true;
            Div_tbl_Course.Visible = false;
            Div_Cou_search.Visible = false;

        }

        protected void Rbtn_Cou_CheckedChanged(object sender, EventArgs e)
        {
            Div_Searsh_Stu.Visible = false;
            Div_tbl_Stu.Visible = false;
            Div_tbl_Course.Visible = true;
            Div_Cou_search.Visible = true;
        }

       

        public void FillRepeater_Courses()
        {
            // استعلام لاسترداد البيانات المطلوبة من الجداول
            string query = "SELECT Division.Division_name, Division.Division_id, Department.Dept_name, Department.Dept_id, Courses.Course_name, Courses.Course_id " +
                           "FROM Department " +
                           "INNER JOIN Division ON Department.Dept_id = Division.Dept_id " +
                           "INNER JOIN Courses ON Division.Division_id = Courses.Division_id";

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            // تعيين البيانات للـ Repeater
            Repeater_Courses.DataSource = dt;
            Repeater_Courses.DataBind();
        }

        public void FillRepeater_Stu()
        {
            // استعلام لاسترداد الأقسام 
            string query = "select * from Students";

            // تنفيذ الاستعلام واسترداد البيانات
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            // تعيين البيانات للـ Repeater
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        public void Search_Advanced_FillRepeater_Courses(string courseName, string divisionName)
        {
            // استعلام للبحث عن المواد بناءً على اسم المادة واسم الشعبة
            string query = "SELECT Division.Division_name, Division.Division_id, Department.Dept_name, Department.Dept_id, Courses.Course_name, Courses.Course_id " +
                           "FROM Department " +
                           "INNER JOIN Division ON Department.Dept_id = Division.Dept_id " +
                           "INNER JOIN Courses ON Division.Division_id = Courses.Division_id " +
                           "WHERE Courses.Course_name LIKE '%' + @CourseName + '%' AND Division.Division_id LIKE '%' + @Division_id + '%'";

            // تنفيذ الاستعلام واسترداد البيانات
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CourseName", courseName);
                    cmd.Parameters.AddWithValue("@Division_id", divisionName);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            // تعيين البيانات للـ Repeater
            Repeater_Courses.DataSource = dt;
            Repeater_Courses.DataBind();
        }
        public void Search_FillRepeater_Courses(string courseName)
        {
            // استعلام للبحث عن المواد بناءً على اسم المادة
            string query = "SELECT Division.Division_name, Division.Division_id, Department.Dept_name, Department.Dept_id, Courses.Course_name, Courses.Course_id " +
                           "FROM Department " +
                           "INNER JOIN Division ON Department.Dept_id = Division.Dept_id " +
                           "INNER JOIN Courses ON Division.Division_id = Courses.Division_id " +
                           "WHERE Courses.Course_name LIKE '%' + @CourseName + '%'";

            // تنفيذ الاستعلام واسترداد البيانات
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CourseName", courseName);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            // تعيين البيانات للـ Repeater
            Repeater_Courses.DataSource = dt;
            Repeater_Courses.DataBind();
        }

        protected void Btn_Searsh_cou_Click(object sender, EventArgs e)
        {
            if (CheckBox_Courses.Checked)
            {

                Search_Advanced_FillRepeater_Courses(txt_Searsh_cou.Text, DDL_Searsh_Div_Cou.SelectedValue);


            }
            else
            {
                Search_FillRepeater_Courses(txt_Searsh_cou.Text);

            }
        }


        private void Repeater_Searsh_Stu()
        {
            //  string fullName = txt_Searsh_Student.Text;
            // fullName = Regex.Replace(fullName, @"[^a-zA-Z0-9\s]", "");
            string query = "SELECT Distinct Students.Student_id, Students.Student_Kaid, Students.Photo, Students.Student_Fname, Students.Student_Sname, Students.Student_Lname " +
                          "FROM Students " +
                          "INNER JOIN Student_Course ON Students.Student_id = Student_Course.Student_id " +
                          "WHERE  (CONCAT(Students.Student_Fname, ' ', Students.Student_Sname, ' ', Students.Student_Lname) LIKE '%' + @FullName + '%' OR Students.Student_Kaid = @FullName)";
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", txt_Searsh_Stu.Text);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();

                    reader.Close();
                }
            }
        }

        protected void btn_Searsh_Stu_Click(object sender, EventArgs e)
        {
            Repeater_Searsh_Stu();
        }

        protected void Repeater_Courses_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Show")
            {
                int index = e.Item.ItemIndex;
                Label Cou_id = (Label)e.Item.FindControl("Label1");
                Label Cou_Name = (Label)e.Item.FindControl("Label2");


                // إنشاء قيمة لإرسالها إلى الصفحة الأخرى
                string queryString = $"?CourseID={Cou_id.Text}&Cou_Name={Cou_Name.Text}";

                // التحويل إلى الصفحة الأخرى مع القيم المرسلة
                Response.Redirect("Report_Course_Admin.aspx" + queryString);
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Show")
            {
                int index = e.Item.ItemIndex;
                Label Stu_id = (Label)e.Item.FindControl("Label1");


                // إنشاء قيمة لإرسالها إلى الصفحة الأخرى
                string queryString = $"?Stu_id={Stu_id.Text}";

                // التحويل إلى الصفحة الأخرى مع القيم المرسلة
                Response.Redirect("Report_Student_Admin.aspx" + queryString);
            }
        }
    }
}