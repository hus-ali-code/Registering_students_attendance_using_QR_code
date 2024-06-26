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
    public partial class Confirm_Scan : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                  // دالة للتحقق ان الطالب بالفعل يدرس في المادة
                  if (IsStudentEnrolledInCourse(1818, Request.QueryString["CourseID"]))
                  {
                      // دالة للتحقق من ان الطالب سجل حضوره
                      if (!IsStudentAttendedLecture(1818, Request.QueryString["LectureID"]))
                      {

                          if (Session["random_Number"].ToString() == Request.QueryString["Random"].ToString())
                          {
                              // دالة للتسجيل حضور الطالب      
                              AddStudentLectureAttendance(1818, Request.QueryString["LectureID"]);
                              ScriptManager.RegisterStartupScript(this, this.GetType(), "dfdf", "swal('نجاح', 'تم تسجيل حضورك في المحاضرة!', 'success');", true);
                              

                          }
                          else
                          {
                              
                              ScriptManager.RegisterStartupScript(this, this.GetType(), "ffff", "swal('من فضلك قم باعادة المحاولة', '!!!', 'warning');", true);
                          }

                      }
                      else
                      {
                          ScriptManager.RegisterStartupScript(this, this.GetType(), "fff", "swal('بالفعل لقد قمت بالتسجيل حضورك', '!!!', 'warning');", true);
                      }

                  }
                  else // في حال الطالب لا يدرس في المادة
                  {
                      ScriptManager.RegisterStartupScript(this, this.GetType(), "ff", "swal('هذه المادة ليست من مقرراتك', '!!!', 'warning');", true);

                  }




            }
        }



        // دالة للتحقق ان الطالب بالفعل يدرس في المادة
        public bool IsStudentEnrolledInCourse(int studentId, string courseId)
        {
            using (var connection = new SqlConnection(cs))
            {
                connection.Open();

                var query = @"
            SELECT COUNT(*) 
            FROM Student_Course
            WHERE Student_id = @studentId 
            AND Course_id = @courseId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    command.Parameters.AddWithValue("@courseId", courseId);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // دالة للتحقق من ان الطالب سجل حضوره
        public bool IsStudentAttendedLecture(int studentId, string lectureId)
        {
            using (var connection = new SqlConnection(cs))
            {
                connection.Open();

                var query = @"
            SELECT COUNT(*)
            FROM Student_Lecture
            WHERE Student_id = @studentId
            AND Lecture_id = @lectureId ";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    command.Parameters.AddWithValue("@lectureId", lectureId);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // دالة للتسجيل حضور الطالب      
        public void AddStudentLectureAttendance(int studentId, string lectureId)
        {
            using (var connection = new SqlConnection(cs)) // 
            {
                connection.Open();

                var query = @"
            INSERT INTO Student_Lecture (Student_id, Lecture_id, Time_Scan)
            VALUES (@studentId, @lectureId, @timeScan)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    command.Parameters.AddWithValue("@lectureId", lectureId);
                    command.Parameters.AddWithValue("@timeScan", DateTime.Now.TimeOfDay);

                    command.ExecuteNonQuery();
                }
            }
        }


      

          
        
    }
}