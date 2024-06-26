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

    public partial class teacher_courses_admin : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                BindRepeater();

                //PostBackUrl استقبال القيم المرسلة عبر الـ 
                Label1.Text ="الاستاذ : "  + Request.QueryString["Fname"]+" "+ Request.QueryString["Lname"]+"//";
                teacherID.Text = Request.QueryString["teacherID"];


                //Repeater-عرض البيانات في اكثر من صفحة في اداة ال  
                Repeater_Pagining();

            }
            Button1.Click += Button1_Click;

            




        }


        //-Repeater- دالة تعرض البيانات في اكثر من صفحة في اداة      
             public string Set_Paging(Int32 PageNumber, int PageSize, Int64 TotalRecords, string ClassName, string PageUrl, string DisableClassName)
             {
                 string ReturnValue = "";
                 try
                 {
                     Int64 TotalPages = Convert.ToInt64(Math.Ceiling((double)TotalRecords / PageSize));
                     if (PageNumber > 1)
                     {
                         if (PageNumber == 2)
                             ReturnValue = ReturnValue + "<a href='" + PageUrl.Trim() + "?pn=" + Convert.ToString(PageNumber - 1) + "' class='" + ClassName + "'> السابق </a>&nbsp;&nbsp;&nbsp;";
                         else
                         {
                             ReturnValue = ReturnValue + "<a href='" + PageUrl.Trim();
                             if (PageUrl.Contains("?"))
                                 ReturnValue = ReturnValue + "&";
                             else
                                 ReturnValue = ReturnValue + "?";
                             ReturnValue = ReturnValue + "pn=" + Convert.ToString(PageNumber - 1) + "' class='" + ClassName + "'>  </a>&nbsp;&nbsp;&nbsp;";
                         }
                     }
                     else
                         ReturnValue = ReturnValue + "<span class='" + DisableClassName + "'> السابق </span>&nbsp;&nbsp;&nbsp;";
                     if ((PageNumber - 4) > 1)
                         ReturnValue = ReturnValue + "<a href='" + PageUrl.Trim() + "' class='" + ClassName + "'>1</a>&nbsp;.....&nbsp;&nbsp;";
                     for (int i = PageNumber - 3; i <= PageNumber; i++)
                         if (i >= 1)
                         {
                             if (PageNumber != i)
                             {
                                 ReturnValue = ReturnValue + "<a href='" + PageUrl.Trim();
                                 if (PageUrl.Contains("?"))
                                     ReturnValue = ReturnValue + "&";
                                 else
                                     ReturnValue = ReturnValue + "?";
                                 ReturnValue = ReturnValue + "pn=" + i.ToString() + "' class='" + ClassName + "'>" + i.ToString() + "</a>";
                             }
                             else
                             {
                                 ReturnValue = ReturnValue + "<span style='font-weight: bold; background-color: #ff0600; color: #fff; padding: 5px; border-radius: 3px;'>" + i + "</span>";
                             }
                         }
                     for (int i = PageNumber + 1; i <= PageNumber + 4; i++)
                         if (i <= TotalPages)
                         {
                             if (PageNumber != i)
                             {
                                 ReturnValue = ReturnValue + "<a href='" + PageUrl.Trim();
                                 if (PageUrl.Contains("?"))
                                     ReturnValue = ReturnValue + "&";
                                 else
                                     ReturnValue = ReturnValue + "?";
                                 ReturnValue = ReturnValue + "pn=" + i.ToString() + "' class='" + ClassName + "'>" + i.ToString() + "</a>";
                             }
                             else
                             {
                                 ReturnValue = ReturnValue + "<span style='font-weight:bold;'>" + i + "</span>";
                             }
                         }
                     if ((PageNumber + 3) < TotalPages)
                     {
                         ReturnValue = ReturnValue + ".....&nbsp;<a href='" + PageUrl.Trim();
                         if (PageUrl.Contains("?"))
                             ReturnValue = ReturnValue + "&";
                         else
                             ReturnValue = ReturnValue + "?";
                         ReturnValue = ReturnValue + "pn=" + TotalPages.ToString() + "' class='" + ClassName + "'>" + TotalPages.ToString() + "</a>";
                     }
                     if (PageNumber < TotalPages)
                     {
                         ReturnValue = ReturnValue + "<a href='" + PageUrl.Trim();
                         if (PageUrl.Contains("?"))
                             ReturnValue = ReturnValue + "&";
                         else
                             ReturnValue = ReturnValue + "?";
                         ReturnValue = ReturnValue + "pn=" + Convert.ToString(PageNumber + 1) + "' class='" + ClassName + "'> التالي </a>";
                     }
                     else
                         ReturnValue = ReturnValue + "<span class='" + DisableClassName + "'> التالي </span>";
                 }
                 catch (Exception ex)
                 {
                 }
                 return (ReturnValue);
             }






        private void Repeater_Pagining()
        {

            string pagequery = " offset 0 rows FETCH NEXT 10 rows only﻿";  //Initially fetch the first 10 rows
            int page = 1; //Initialize page no 1
            int rowRemove = 10; // Rows to remove for next paging
            int pagesize = 10; //No of rows in a page

            if (!string.IsNullOrEmpty(Request.QueryString["pn"]))  //checks if query string [pn] is empty or no
            {
                page = Request.QueryString["pn"] == null ? 1 : Convert.ToInt32(Request.QueryString["pn"]);  //if not empty assign page=[pn]
                rowRemove = (rowRemove * Convert.ToInt32(page)) - 10; //calculate on removing the no of rows from the record
                pagequery = " offset " + rowRemove + " rows FETCH NEXT 10 rows only﻿"; //Fetch the next 10 rows after removing
            }


            string query_1 = "SELECT Dept_name, Division_name, Course_name ,Course_id " +
                           "FROM Department d " +
                           "INNER JOIN Division dv ON d.Dept_id = dv.Dept_id " +
                           "INNER JOIN Courses c ON dv.Division_id = c.Division_id order by Course_id Asc";


            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmdRepeater = new SqlCommand(query_1 + pagequery, con);  //Select the records
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmdRepeater);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                myRepeater.DataSource = ds;
                myRepeater.DataBind();  //Bind the repeater
                cmdRepeater = new SqlCommand("select COUNT(*) from Courses", con);  //Count the total records
                con.Open();
                int count = (int)cmdRepeater.ExecuteScalar();
                con.Close();

                var uri = new Uri(Request.Url.AbsoluteUri);
                var query = HttpUtility.ParseQueryString(uri.Query); //Get the query strings from the url
                query.Remove("pn"); //Remove the query string [pn] to avoid repetation
                string link = HttpContext.Current.Request.Url.AbsolutePath + "?" + query;
                pagingDiv.InnerHtml = Set_Paging(page, pagesize, count, "activeLink", link, "disableLink");  //Fill the pagination in the div tag
            }






        }



        private void BindRepeater()
        {
            string query = "SELECT Dept_name, Division_name, Course_name ,Course_id " +
                           "FROM Department d " +
                           "INNER JOIN Division dv ON d.Dept_id = dv.Dept_id " +
                           "INNER JOIN Courses c ON dv.Division_id = c.Division_id";

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    myRepeater.DataSource = dataTable;
                    myRepeater.DataBind();
                }
                else
                {
                    // Handle case when no data is returned from the query
                }
            }

        }
       

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            // احتفظ بالمواد المحددة في قائمة
            List<string> selectedCourses = new List<string>();

            foreach (RepeaterItem item in myRepeater.Items)
            {
                CheckBox checkBox = (CheckBox)item.FindControl("CheckBox1");
                if (checkBox.Checked)
                {
                    Label courseLabel = (Label)item.FindControl("CourseID");
                    string courseId = courseLabel.Text;

                    selectedCourses.Add(courseId);

                    // التحقق مما إذا كانت البيانات موجودة بالفعل في جدول Teacher_Course
                    bool isAlreadyAssigned = CheckIfCourseAssigned(courseId, teacherID.Text);

                    if (!isAlreadyAssigned)
                    {
                        using (SqlConnection con = new SqlConnection(cs))
                        {
                            string query = "INSERT INTO Teacher_Course (Course_id, Teacher_id) VALUES (@CourseId, @TeacherId)";
                            SqlCommand command = new SqlCommand(query, con);
                            command.Parameters.AddWithValue("@CourseId", courseId);
                            command.Parameters.AddWithValue("@TeacherId", teacherID.Text);

                            con.Open();
                            command.ExecuteNonQuery();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "k22", "regS2()", true);
                            con.Close();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "c2", "check_teachCourse()", true);

                    }
                }
            }
        }

        // الدالة للتحقق مما إذا كانت البيانات موجودة بالفعل في جدول Teacher_Course
        private bool CheckIfCourseAssigned(string courseId, string teacherId)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT COUNT(*) FROM Teacher_Course WHERE Course_id = @CourseId AND Teacher_id = @TeacherId";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@CourseId", courseId);
                command.Parameters.AddWithValue("@TeacherId", teacherId);

                con.Open();
                int count = (int)command.ExecuteScalar();
                con.Close();

                return count > 0;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string courseName = TextBox1.Text.Trim(); // قيمة المقرر من مربع النص
            int divisionValue = int.Parse(DDL_Div.SelectedValue); // قيمة رقم الشعبة من عنصر القائمة
            if (ckb_Advanced_Search.Checked)
            {

                BindRepeater_Advanced_Search(courseName, divisionValue);

            }
            else
            {
                BindRepeater_Searsh(courseName);

            }
        }

     /* private void BindRepeater_Advanced_Search(string courseName, int divisionValue)
        {

            string query = "SELECT Dept_name, Division_name, Course_name, Course_id " +
               "FROM Department d " +
               "INNER JOIN Division dv ON d.Dept_id = dv.Dept_id " +
               "INNER JOIN Courses c ON dv.Division_id = c.Division_id " +
               "WHERE Course_name LIKE '%' + @CourseName + '%' AND dv.Division_id = @DivisionValue";

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@CourseName", courseName);
                command.Parameters.AddWithValue("@DivisionValue", divisionValue);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    myRepeater.DataSource = dataTable;
                    myRepeater.DataBind();

                }
                else
                {
                    // التعامل مع حالة عدم وجود بيانات مطابقة
                    myRepeater.DataSource = "";
                    myRepeater.DataBind();
                }
            }
        }*/

     /*   private void BindRepeater(string courseName)
        {

            string query = "SELECT Dept_name, Division_name, Course_name, Course_id " +
               "FROM Department d " +
               "INNER JOIN Division dv ON d.Dept_id = dv.Dept_id " +
               "INNER JOIN Courses c ON dv.Division_id = c.Division_id " +
               "WHERE Course_name LIKE '%' + @CourseName + '%'";

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@CourseName", courseName);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    myRepeater.DataSource = dataTable;
                    myRepeater.DataBind();
                }
                else
                {
                    // التعامل مع حالة عدم وجود بيانات مطابقة
                    myRepeater.DataSource = "";
                    myRepeater.DataBind();
                }
            }
        } */

        private void BindRepeater_Advanced_Search(string courseName, int divisionValue)
        {

            string pagequery = " offset 0 rows FETCH NEXT 10 rows only﻿";  //Initially fetch the first 10 rows
            int page = 1; //Initialize page no 1
            int rowRemove = 10; // Rows to remove for next paging
            int pagesize = 10; //No of rows in a page

            if (!string.IsNullOrEmpty(Request.QueryString["pn"]))  //checks if query string [pn] is empty or no
            {
                page = Request.QueryString["pn"] == null ? 1 : Convert.ToInt32(Request.QueryString["pn"]);  //if not empty assign page=[pn]
                rowRemove = (rowRemove * Convert.ToInt32(page)) - 10; //calculate on removing the no of rows from the record
                pagequery = " offset " + rowRemove + " rows FETCH NEXT 10 rows only﻿"; //Fetch the next 10 rows after removing
            }

          
             string query_1 = $"SELECT Dept_name, Division_name, Course_name, Course_id FROM Department d INNER JOIN Division dv ON d.Dept_id = dv.Dept_id INNER JOIN Courses c ON dv.Division_id = c.Division_id WHERE Course_name LIKE '%' + '{courseName}' + '%' AND dv.Division_id = {divisionValue} order by Course_id Asc";


            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmdRepeater = new SqlCommand(query_1 + pagequery, con);  //Select the records
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmdRepeater);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                myRepeater.DataSource = ds;
                myRepeater.DataBind();  //Bind the repeater
                cmdRepeater = new SqlCommand("select COUNT(*) from Courses", con);  //Count the total records
                con.Open();
                int count = (int)cmdRepeater.ExecuteScalar();
                con.Close();

                var uri = new Uri(Request.Url.AbsoluteUri);
                var query = HttpUtility.ParseQueryString(uri.Query); //Get the query strings from the url
                query.Remove("pn"); //Remove the query string [pn] to avoid repetation
                string link = HttpContext.Current.Request.Url.AbsolutePath + "?" + query;
                pagingDiv.InnerHtml = Set_Paging(page, pagesize, count, "activeLink", link, "disableLink");  //Fill the pagination in the div tag
            }






        }

        private void BindRepeater_Searsh(string courseName)
        {

            string pagequery = " offset 0 rows FETCH NEXT 10 rows only﻿";  //Initially fetch the first 10 rows
            int page = 1; //Initialize page no 1
            int rowRemove = 10; // Rows to remove for next paging
            int pagesize = 10; //No of rows in a page

            if (!string.IsNullOrEmpty(Request.QueryString["pn"]))  //checks if query string [pn] is empty or no
            {
                page = Request.QueryString["pn"] == null ? 1 : Convert.ToInt32(Request.QueryString["pn"]);  //if not empty assign page=[pn]
                rowRemove = (rowRemove * Convert.ToInt32(page)) - 10; //calculate on removing the no of rows from the record
                pagequery = " offset " + rowRemove + " rows FETCH NEXT 10 rows only﻿"; //Fetch the next 10 rows after removing
            }


            string query_1 = $"SELECT Dept_name, Division_name, Course_name, Course_id FROM Department d INNER JOIN Division dv ON d.Dept_id = dv.Dept_id INNER JOIN Courses c ON dv.Division_id = c.Division_id WHERE Course_name LIKE '%' + '{courseName}' + '%' order by Course_id Asc";
          
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmdRepeater = new SqlCommand(query_1 + pagequery, con);  //Select the records
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmdRepeater);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                myRepeater.DataSource = ds;
                myRepeater.DataBind();  //Bind the repeater
                cmdRepeater = new SqlCommand("select COUNT(*) from Courses", con);  //Count the total records
                con.Open();
                int count = (int)cmdRepeater.ExecuteScalar();
                con.Close();

                var uri = new Uri(Request.Url.AbsoluteUri);
                var query = HttpUtility.ParseQueryString(uri.Query); //Get the query strings from the url
                query.Remove("pn"); //Remove the query string [pn] to avoid repetation
                string link = HttpContext.Current.Request.Url.AbsolutePath + "?" + query;
                pagingDiv.InnerHtml = Set_Paging(page, pagesize, count, "activeLink", link, "disableLink");  //Fill the pagination in the div tag
            }






        }



    }
}