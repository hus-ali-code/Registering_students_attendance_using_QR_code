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
    public partial class Report_Student_Admin : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindRepeaterByStudentId(int.Parse(Request.QueryString["Stu_ID"]));

            }

        }

        private void BindRepeaterByStudentId(int studentId)
        {
            string query = "SELECT DISTINCT Courses.Course_name " +
                           "FROM Student_Course " +
                           "INNER JOIN Courses ON Student_Course.Course_id = Courses.Course_id " +
                           "WHERE Student_Course.Student_id = @StudentId";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", studentId);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();

                    reader.Close();
                }
            }
        }

      
    }
}