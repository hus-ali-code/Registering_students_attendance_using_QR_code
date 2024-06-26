using QRCoder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Registering_students_attendance_using_QR_code
{
    public partial class create_QR_teacher : System.Web.UI.Page 
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;
        private DateTime? selectedDateTime = null;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               

                PopulateCourseDropDown(DDL_Choose_Course , 2);
                PopulateHallDropDown(DDL_Choose_Hall);

                Div_Choose_Hall.Visible = false;
                Div_Confirm.Visible = false;
                Div_Reg_Static.Visible = false;



            }

            // تحقق من تحميل الصفحة لأول مرة
            if (!IsPostBack)
            {
                // إخفاء لوحة التاريخ والوقت في البداية
                Div_Chose_Time_L.Visible = false;

                // ملء قائمة الساعات والدقائق
                FillHoursAndMinutes();
            }
            if (Page.IsPostBack)
            {
                Label1.Visible = false;
                Label2.Visible = false;
          
            }




        }


    
        protected void Button6_Click(object sender, EventArgs e)
        {

            if (DDL_Choose_Course.SelectedIndex == 0)
            {
                Label1.Visible = true;
            }
            else
            {

                Div_Choose_Course.Visible = false;
                Div_Confirm.Visible = false;
                Div_Reg_Static.Visible = false;

                Div_Choose_Hall.Visible = true;

             //   Repeater_Pagining(DDL_Choose_Course.SelectedValue);


            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_Teacher.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Div_Choose_Course.Visible = true;

            Div_Choose_Hall.Visible = false;

            Div_Confirm.Visible = false;

            Div_Reg_Static.Visible = false;




        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (DDL_Choose_Hall.SelectedIndex == 0)
            {
                Label2.Visible = true;
            }
            else
            {
                Div_Reg_Static.Visible = false;

                Div_Choose_Course.Visible = false;

                Div_Choose_Hall.Visible = false;

                Div_Confirm.Visible = true;

                DateTime dt = DateTime.Now;
                txt_Date.Text = dt.Date.ToString("yyyy-MM-dd");
                txt_Time.Text = dt.ToString("hh:mm tt");
                txt_CF_Cou.Text = DDL_Choose_Course.SelectedItem.Text;
                txt_CF_Hall.Text = DDL_Choose_Hall.SelectedItem.Text;
            }


        }

        protected void Button7_Click(object sender, EventArgs e)
        {

                Div_Reg_Static.Visible = false;

                Div_Choose_Course.Visible = false;

                Div_Choose_Hall.Visible = true;

                Div_Confirm.Visible = false;
            
           
        }

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {

            if (IsLectureExists())
            {
                // استقبال القيم من عناصر التحكم في الصفحة
                string value1 = DDL_Choose_Course.SelectedValue;
                string value2 = DDL_Choose_Hall.SelectedValue;
                string value3 = GetLectureId().ToString();
                
                // إنشاء قيمة لإرسالها إلى الصفحة الأخرى
                string queryString = $"?CourseID={value1}&HallID={value2}&LectureID={value3}";

                // التحويل إلى الصفحة الأخرى مع القيم المرسلة
                Response.Redirect("QR_Code.aspx" + queryString);
            }
            else
            {
                // استقبال القيم من عناصر التحكم في الصفحة
                string value1 = DDL_Choose_Course.SelectedValue;
                string value2 = DDL_Choose_Hall.SelectedValue;
                string value3 = AddLecture().ToString();

                // إنشاء قيمة لإرسالها إلى الصفحة الأخرى
                string queryString = $"?CourseID={value1}&HallID={value2}&LectureID={value3}";

                // التحويل إلى الصفحة الأخرى مع القيم المرسلة
                Response.Redirect("QR_Code.aspx" + queryString);
            }

          


            /* if (IsLectureExists())
             {
                 Div_Choose_Course.Visible = false;

                 Div_Choose_Hall.Visible = false;

                 Div_Confirm.Visible = false;

                 Div_Reg_Static.Visible = true;

                 Image1.Visible = true;

                 def_img.Visible = false;

                 GetLectureId();

                 CreateQR(GetLectureId());
             }
             else
             {

                // Response.Redirect(Request.Url.ToString(), true);


                 int lecID = AddLecture();

                 CreateQR(lecID);

                 ViewState["lecID"]= lecID;

                 ScriptManager.RegisterStartupScript(this, this.GetType(), "dfdf", "swal('نجاح', 'تم التحديث بنجاح!', 'success');", true);

                 Div_Choose_Course.Visible = false;

                 Div_Choose_Hall.Visible = false;

                 Div_Confirm.Visible = false;

                 Div_Reg_Static.Visible = true;

                 Image1.Visible = true;

                 def_img.Visible = false;
             }*/



        }




        public void PopulateCourseDropDown(DropDownList ddl, int teacherId)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                string sql = @"
            SELECT c.Course_id, c.Course_name
            FROM Teacher_Course tc 
            INNER JOIN Courses c ON tc.Course_id = c.Course_id
            INNER JOIN Teachers t ON tc.Teacher_id = t.Teacher_id
            WHERE tc.Teacher_id = @teacherId";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@teacherId", teacherId);

                SqlDataReader reader = cmd.ExecuteReader();

                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("اختر المادة", ""));

                while (reader.Read())
                {
                    ddl.Items.Add(new ListItem(reader["Course_name"].ToString(), reader["Course_id"].ToString()));
                }

                reader.Close();
                conn.Close();
            }
        }
        public void PopulateHallDropDown(DropDownList ddl)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                string sql = "SELECT * FROM Halls";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("اختر القاعة", ""));

                while (reader.Read())
                {
                    ddl.Items.Add(new ListItem(reader["Hall_name"].ToString(), reader["Hall_id"].ToString()));
                }

                reader.Close();
                conn.Close();
            }
        }

        public void PopulateHallDropDownByName(DropDownList ddl, string searchTerm)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                string sql = "SELECT Hall_id, Hall_name FROM Halls WHERE Hall_name LIKE @SearchTerm";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                SqlDataReader reader = cmd.ExecuteReader();

                ddl.Items.Clear();
                ddl.Items.Add(new ListItem("اختر القاعة", ""));

                while (reader.Read())
                {
                    ddl.Items.Add(new ListItem(reader["Hall_name"].ToString(), reader["Hall_id"].ToString()));
                }

                reader.Close();
                conn.Close();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            PopulateHallDropDownByName(DDL_Choose_Hall, txt_Searsh_Hall.Text);
        }


        public void CreateQR(int LecID)
        {
            string LectureID = LecID.ToString();
             // قراءة المحتوى من TextBoxes
            string content1 = DDL_Choose_Course.SelectedValue;
            string content2 = DDL_Choose_Hall.SelectedValue;
            string content3 = LectureID;

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



        /*  protected void PopulateStudentRepeater(string courseId)
          {
              using (SqlConnection conn = new SqlConnection(cs))
              {
                  conn.Open();

                          string query_1 = $" SELECT s.Student_id, s.Student_Fname, s.Student_Sname, s.Student_Lname, s.Photo FROM Students s INNER JOIN Student_Course sc ON s.Student_id = sc.Student_id WHERE sc.Course_id = {courseID} order by Course_id Asc";


                  string sql = @" SELECT s.Student_id, s.Student_Fname, s.Student_Sname, s.Student_Lname, s.Photo
              FROM Students s
              INNER JOIN Student_Course sc ON s.Student_id = sc.Student_id
              WHERE sc.Course_id = @CourseId";

                  SqlCommand cmd = new SqlCommand(sql, conn);
                  cmd.Parameters.AddWithValue("@CourseId", courseId);

                  SqlDataReader reader = cmd.ExecuteReader();

                  Repeater_Stu.DataSource = reader;
                  Repeater_Stu.DataBind();

                  reader.Close();
                  conn.Close();
              }
          } */

        protected void SearchAndPopulateStudentRepeater(string searchText, string courseId)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                string sql = $"SELECT s.Student_id, s.Student_Fname,  s.Student_Sname,  s.Student_Lname, s.Photo FROM Students s INNER JOIN Student_Course sc ON s.Student_id = sc.Student_id WHERE (s.Student_Kaid LIKE '%' + '{searchText}' + '%'  OR s.Student_Fname LIKE '%' + '{searchText}' + '%' OR s.Student_Sname LIKE '%' + '{searchText}' + '%' OR s.Student_Lname LIKE '%' + '{searchText}' + '%') AND sc.Course_id = {courseId} order by Course_id Asc";


                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SearchText", searchText);
                cmd.Parameters.AddWithValue("@CourseId", courseId);

                SqlDataReader reader = cmd.ExecuteReader();

                Repeater_Stu.DataSource = reader;
                Repeater_Stu.DataBind();

                reader.Close();
                conn.Close();
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


        private void BindRepeater()
        {
           //  string fullName = txt_Searsh_Student.Text;
            // fullName = Regex.Replace(fullName, @"[^a-zA-Z0-9\s]", "");

            // استعلام لاسترداد البيانات من جدول الطلاب وجدول المواد
            string query = "SELECT Distinct Students.Photo, Students.Student_Fname, Students.Student_Sname, Students.Student_Lname, Courses.Course_name " +
                           "FROM Students " +
                           "INNER JOIN Student_Course ON Students.Student_id = Student_Course.Student_id " +
                           "INNER JOIN Courses ON Student_Course.Course_id = Courses.Course_id " +
                           "WHERE Student_Course.Course_id = @CourseId AND CONCAT(Students.Student_Fname, ' ', Students.Student_Sname, ' ', Students.Student_Lname) LIKE '%' + @FullName + '%'";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CourseId", DDL_Choose_Course.SelectedValue); 
                    command.Parameters.AddWithValue("@FullName", txt_Searsh_Student.Text); 

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    Repeater_Stu.DataSource = reader;
                    Repeater_Stu.DataBind();

                    reader.Close();
                }
            }
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            // عرض لوحة التاريخ والوقت
            Div_Chose_Time_L.Visible = true;
            Div_Confirm.Visible = false;

            // تحديد القيمة الحالية في التقويم والقائمتين
            if (selectedDateTime.HasValue)
            {
                calDatePicker.SelectedDate = selectedDateTime.Value;
                ddlHours.SelectedValue = selectedDateTime.Value.Hour.ToString();
                ddlMinutes.SelectedValue = selectedDateTime.Value.Minute.ToString();
            }
        }



        private void FillHoursAndMinutes()
        {
            // ملء قائمة الساعات
            for (int i = 0; i < 24; i++)
            {
                ddlHours.Items.Add(new ListItem(i.ToString("D2"), i.ToString()));
            }

            // ملء قائمة الدقائق
            for (int i = 0; i < 60; i += 5)
            {
                ddlMinutes.Items.Add(new ListItem(i.ToString("D2"), i.ToString()));
            }
        }

        protected void btnConfirm_change_Click(object sender, EventArgs e)
        {

            // تحقق من تحديد تاريخ وقت
    if (calDatePicker.SelectedDate == DateTime.MinValue || ddlHours.SelectedValue == "0")
    {
                // عرض رسالة الخطأ
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ff", "swal('قم باختيار التاريخ والوقت', 'خطا  !', 'warning');", true);
                return;
    }
            // الحصول على التاريخ والوقت المحددين
            DateTime selectedDate = calDatePicker.SelectedDate;
            int selectedHour = Convert.ToInt32(ddlHours.SelectedValue);
            int selectedMinute = Convert.ToInt32(ddlMinutes.SelectedValue);

            // تحويل الساعة إلى نظام الـ 12 ساعة
            if (selectedHour > 12)
            {
                selectedHour -= 12;
            }
            else if (selectedHour == 0)
            {
                selectedHour = 12;
            }

            // إنشاء كائن DateTime باستخدام التاريخ والوقت المحددين
            selectedDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, selectedHour, selectedMinute, 0);

            // تحديث قيمة مربع النص
            txt_Time.Text = selectedDateTime.Value.ToString("HH:mm");
            txt_Date.Text = selectedDateTime.Value.ToString("yyyy-MM-dd");

            // إخفاء لوحة التاريخ والوقت
            Div_Chose_Time_L.Visible = false;
            Div_Confirm.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Div_Chose_Time_L.Visible = false;
            Div_Confirm.Visible = true;
        }



        protected int AddLecture()
        {
            string courseId = DDL_Choose_Course.SelectedValue;
            string hallId = DDL_Choose_Hall.SelectedValue;
            //   DateTime dateTime = DateTime.ParseExact(txt_Time.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            string query = "INSERT INTO Lectures (Course_id, Hall_id, Date, Time, Date_Time) VALUES (@CourseId, @HallId, @Date, @Time, GETDATE());SELECT SCOPE_IDENTITY()";
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CourseId", courseId);
                    command.Parameters.AddWithValue("@HallId", hallId);
                    command.Parameters.AddWithValue("@Time", txt_Time.Text);
                    command.Parameters.AddWithValue("@Date", txt_Date.Text);


                    connection.Open();
                    int lectureId = Convert.ToInt32(command.ExecuteScalar());

                     return lectureId;
                }
            }

           
        }

        public bool IsLectureExists()
        {
            using (var connection = new SqlConnection(cs))
            {
                connection.Open();

                var query = @"
            SELECT COUNT(*) 
            FROM Lectures
            WHERE Course_id = @courseId
            AND Time = @Time AND Date = @Date";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@courseId", DDL_Choose_Course.SelectedValue);
                    command.Parameters.AddWithValue("@Time", txt_Time.Text);
                    command.Parameters.AddWithValue("@Date", txt_Date.Text);


                    var count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public int GetLectureId()
        {
            using (var connection = new SqlConnection(cs))
            {
                connection.Open();

                var query = @"
            SELECT Lecture_id
            FROM Lectures
            WHERE Course_id = @courseId
            AND Date = @date AND Time = @time";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@courseId", DDL_Choose_Course.SelectedValue);
                    command.Parameters.AddWithValue("@time", txt_Time.Text);
                    command.Parameters.AddWithValue("@date", txt_Date.Text);


                    var lectureId = (int)command.ExecuteScalar();
                    return lectureId;
                }
            }
        }



    }

}