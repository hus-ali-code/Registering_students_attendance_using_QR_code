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
    public partial class Report_Course_Admin : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeater();

            }
        }

        private void BindRepeater()
        {
            //  string fullName = txt_Searsh_Student.Text;
            // fullName = Regex.Replace(fullName, @"[^a-zA-Z0-9\s]", "");

            string query = "SELECT Distinct Students.Student_id, Students.Student_Kaid, Students.Photo, Students.Student_Fname, Students.Student_Sname, Students.Student_Lname, Courses.Course_name " +
                 "FROM Students " +
                 "INNER JOIN Student_Course ON Students.Student_id = Student_Course.Student_id " +
                 "INNER JOIN Courses ON Student_Course.Course_id = Courses.Course_id " +
                 "WHERE Student_Course.Course_id = @CourseId AND (CONCAT(Students.Student_Fname, ' ', Students.Student_Sname, ' ', Students.Student_Lname) LIKE '%' + @FullName + '%' OR Students.Student_Kaid = @FullName)";
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CourseId", Request.QueryString["CourseID"]);
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
            if (txt_Searsh_Stu.Text.Trim() == "")
            {
                Repeater1.DataSource = "";
                Repeater1.DataBind();
            }
            else
            {
                BindRepeater();

            }
        }

        public int Get_Lectures_Attended_ByStudent(int studentId)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                string query = @"
            SELECT COUNT(*)
            FROM Student_Lecture sl
            INNER JOIN Lectures l ON sl.Lecture_id = l.Lecture_id
            WHERE sl.Student_id = @StudentId AND l.Course_id = @CourseId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentId", studentId);
                command.Parameters.AddWithValue("@CourseId", Request.QueryString["CourseID"]);

                int lecturesAttended = (int)command.ExecuteScalar();

                return lecturesAttended;
            }
        }

        public int Get_Lectures_ForCourse()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Lectures WHERE Course_id = @CourseId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseId", Request.QueryString["CourseID"]);

                int lectureCount = (int)command.ExecuteScalar();

                return lectureCount;
            }
        }


        public string Get_Divsion(int courseId)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                // Build the query
                string query = @"
            SELECT 
                d.Dept_name, 
                di.Division_name
            FROM Courses c
            JOIN Division di ON c.Division_id = di.Division_id
            JOIN Department d ON di.Dept_id = d.Dept_id
            WHERE c.Course_id = @courseId";

                // Execute the query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@courseId", courseId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string departmentName = reader.GetString(0);
                            string divisionName = reader.GetString(1);

                            return divisionName;
                        }
                    }
                }
            }

            // If no results found, return an error message
            return "No department or division found for the given course ID.";
        }

        public string Get_Dept(int courseId)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                // Build the query
                string query = @"
            SELECT 
                d.Dept_name, 
                di.Division_name
            FROM Courses c
            JOIN Division di ON c.Division_id = di.Division_id
            JOIN Department d ON di.Dept_id = d.Dept_id
            WHERE c.Course_id = @courseId";

                // Execute the query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@courseId", courseId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string departmentName = reader.GetString(0);
                            string divisionName = reader.GetString(1);
                            return departmentName;
                        }
                    }
                }
            }

            // If no results found, return an error message
            return "No department or division found for the given course ID.";
        }



        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
           
        }
    }
}