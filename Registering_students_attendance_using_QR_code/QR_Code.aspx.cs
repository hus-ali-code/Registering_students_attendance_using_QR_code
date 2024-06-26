using QRCoder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Registering_students_attendance_using_QR_code
{
    public partial class QR_Code : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // استقبال القيم المرسلة من الصفحة الأخرى
                string value1 = Request.QueryString["CourseID"];
                string value2 = Request.QueryString["HallID"];
                string value3 = Request.QueryString["LectureID"];
                CreateQR(value1, value2, value3);

            }



        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            // استقبال القيم المرسلة من الصفحة الأخرى
            string value1 = Request.QueryString["CourseID"];
            string value2 = Request.QueryString["HallID"];
            string value3 = Request.QueryString["LectureID"];
            CreateQR(value1, value2, value3);
        }



        public void CreateQR(string Course,string Hall, String Lecture)
        {
            // قراءة المحتوى من TextBoxes
            string content1 = Course;
            string content2 = Hall;
            string content3 = Lecture;

            // توليد الرقم العشوائي
            Random random = new Random();
            int randomNumber = random.Next(1000, 9999); // توليد رقم عشوائي بين 1000 و 9999

            Session["random_Number"] = randomNumber;

            // توليد النص النهائي
            string finalText = $"{content1} - {content2} - {content3}  - {randomNumber}";

            // إنشاء رمز QR جديد
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(finalText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            // تحويل رمز QR إلى صورة
            Bitmap qrCodeImage = qrCode.GetGraphic(10);

            // حفظ صورة رمز QR في الذاكرة وعرضها في عنصر الصورة في الصفحة
            using (MemoryStream ms = new MemoryStream())
            {
                qrCodeImage.Save(ms, ImageFormat.Png);
                byte[] qrCodeBytes = ms.ToArray();
                string base64Image = Convert.ToBase64String(qrCodeBytes);
                Image1.ImageUrl = "data:image/png;base64," + base64Image;
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
                    command.Parameters.AddWithValue("@FullName", txt_Searsh_Student.Text);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    Repeater_Stu.DataSource = reader;
                    Repeater_Stu.DataBind();

                    reader.Close();
                }
            }
        }


        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (txt_Searsh_Student.Text.Trim() == "")
            {
                Repeater_Stu.DataSource = "";
                Repeater_Stu.DataBind();
            }
            else
            {
                BindRepeater();

            }

        }

        protected void Repeater_Stu_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "reg")
            {
                int index = e.Item.ItemIndex;
                Label Student_id = (Label)e.Item.FindControl("Label1");

                // دالة للتحقق من ان الطالب سجل حضوره
                if (!IsStudentAttendedLecture(Student_id.Text, Request.QueryString["LectureID"]))
                {
                      // دالة للتسجيل حضور الطالب      
                        AddStudentLectureAttendance(Student_id.Text, Request.QueryString["LectureID"]);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "dfdf", "swal('نجاح', 'تم تسجيل حضور الطالب في المحاضرة!', 'success');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "fff", "swal('بالفعل الطالب مسجل', '!!!', 'warning');", true);
                }
            }
            if (e.CommandName == "cancel_reg")
            {
                int index = e.Item.ItemIndex;
                Label Student_id = (Label)e.Item.FindControl("Label1");

                // دالة للتحقق من ان الطالب سجل حضوره
                if (IsStudentAttendedLecture(Student_id.Text, Request.QueryString["LectureID"]))
                {
                    // دالة للتسجيل حضور الطالب      
                    cancelStudentLectureAttendance(Student_id.Text, Request.QueryString["LectureID"]);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "dfdf", "swal('نجاح', 'تم الغاء حضور الطالب!', 'success');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "fff", "swal('الطالب لم يسجل حضوره', '!!!', 'warning');", true);
                }
            }
        }

        // دالة للتحقق من ان الطالب سجل حضوره
        public bool IsStudentAttendedLecture(string studentId, string lectureId)
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
        public void AddStudentLectureAttendance(string studentId, string lectureId)
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

        // دالة لالغاء  حضور الطالب      
        public void cancelStudentLectureAttendance(string studentId, string lectureId)
        {
            using (var connection = new SqlConnection(cs)) // 
            {
                connection.Open();

                var query = @"delete from Student_Lecture where Student_id = @studentId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    command.ExecuteNonQuery();
                }
            }
        }



    }
}