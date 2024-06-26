using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Registering_students_attendance_using_QR_code
{
    public partial class dept_div_admin : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                add_dept.Visible = false;
                add_div.Visible = false;
                Edit_dept.Visible = false;
                Edit_Division.Visible = false;
                add_Course.Visible = false;

                tbl_dept.Visible = false;
                tbl_dept_search.Visible = false;

                tbl_div.Visible = false;
                tbl_div_search.Visible = false;

                FillRepeater();
                FillRepeater1();
                FillRepeater_Courses();

            }



            Repeater_Courses_Pagining();




        }

        protected void LBtn_Import_Dept_Click(object sender, EventArgs e)
        {
            add_dept.Visible = true;
            add_div.Visible = false;
            add_Course.Visible = false;

        }

        protected void LBtn_Import_Div_Click(object sender, EventArgs e)
        {
            add_div.Visible = true;
            add_dept.Visible = false;
            add_Course.Visible = false;

        }

        protected void LBtn_Import_Courses_Click(object sender, EventArgs e)
        {
            add_Course.Visible = true;
            add_dept.Visible = false;
            add_div.Visible = false;

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            add_dept.Visible = false;

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            add_div.Visible = false;

        }



        /*    //دالة لاضافة قسم
            public void AddDepartment()
            {

                try
                {
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        con.Open();

                        // إنشاء كائن SqlCommand لتنفيذ الاستعلام
                        SqlCommand command = new SqlCommand("INSERT INTO Department (Dept_name) VALUES (@DepartmentName)", con);

                        // إضافة معلمة للاستعلام
                        command.Parameters.AddWithValue("@DepartmentName", txt_add_dept.Text.Trim());

                        // تنفيذ الاستعلام
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    // يتم التعامل مع الاستثناء وفقًا لاحتياجات التطبيق الخاص بك
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Bzz", " swal('خط في الادخال!',' حدث خطأ في قاعدة البيانات  ','error');", true);

                }

                catch (Exception ex)
                {
                    // يتم التعامل مع الاستثناء وفقًا لاحتياجات التطبيق الخاص بك
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Bzz", " swal('خط !',' حدث خطأ غير متوقع  ','error');", true);

                }
            }

            //دالة لاضافة شعبة
            public void AddDivision()
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        con.Open();

                        // إنشاء كائن SqlCommand لتنفيذ الاستعلام
                        SqlCommand command = new SqlCommand("INSERT INTO Division (Division_name, Dept_id) VALUES (@DivisionName, @DeptId)", con);

                        // إضافة معلمات للاستعلام
                        command.Parameters.AddWithValue("@DivisionName", txt_add_div.Text.Trim());
                        command.Parameters.AddWithValue("@DeptId", DropDownList1.SelectedValue);

                        // تنفيذ الاستعلام
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    // يتم التعامل مع الاستثناء وفقًا لاحتياجات التطبيق الخاص بك
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Bzz", " swal('خط في الادخال!', ' حدث خطأ في قاعدة البيانات  ','error');", true);
                }
                catch (Exception ex)
                {
                    // يتم التعامل مع الاستثناء وفقًا لاحتياجات التطبيق الخاص بك
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Bzz", " swal('خط !',' حدث خطأ غير متوقع  ','error');", true);
                }
            } */



        //مكرر الشعب
        public void FillRepeater()
        {
            // استعلام لاسترداد الأقسام والشعب
            string query = "SELECT Division.Division_id, Division.Division_name, Department.Dept_id, Department.Dept_name FROM Division INNER JOIN Department ON Division.Dept_id = Department.Dept_id";


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
            myRepeater.DataSource = dt;
            myRepeater.DataBind();
        }

        //مكرر الاقسام
        public void FillRepeater1()
        {
            // استعلام لاسترداد الأقسام 
            string query = "select * from Department";

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



        protected void Rbtn_dept_CheckedChanged(object sender, EventArgs e)
        {
            tbl_dept.Visible = true;
            tbl_dept_search.Visible = true;

            tbl_div.Visible = false;
            tbl_div_search.Visible = false;

            tbl_Cou_search.Visible = false;
            tbl_Course.Visible = false;
        }

        protected void Rbtn_division_CheckedChanged(object sender, EventArgs e)
        {
            tbl_Cou_search.Visible = false;
            tbl_Course.Visible = false;



            tbl_dept.Visible = false;
            tbl_dept_search.Visible = false;

            tbl_div.Visible = true;
            tbl_div_search.Visible = true;

        }
        protected void Rbtn_Courses_CheckedChanged(object sender, EventArgs e)
        {
            tbl_dept.Visible = false;
            tbl_dept_search.Visible = false;


            tbl_div.Visible = false;
            tbl_div_search.Visible = false;

            tbl_Cou_search.Visible = true;
            tbl_Course.Visible = true;


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Edit_dept.Visible = false;
        }

        //مكرر الأقسام
        public void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "Edit")
            {
                Edit_dept.Visible = true;
                int index = e.Item.ItemIndex;
                Label Dept_id = (Label)e.Item.FindControl("Label1");
                Label Dept_name = (Label)e.Item.FindControl("Label2");
                txt_Edit_dept_name.Text = Dept_name.Text;
                txt_Edit_dept_id.Text = Dept_id.Text;


            }

            if (e.CommandName == "Delete")
            {
                Label Dept_id = (Label)e.Item.FindControl("Label1");
                DeleteDepartment_BY_ID(Dept_id.Text);
                Edit_dept.Visible = false;
                FillRepeater1();

            }
        }

        //دالة للتعديل اسم القسم
        public void UpdateDepartmentName(string department_Id, string newDepartment_Name)
        {

            string query = "UPDATE Department SET Dept_name = @New_Dept_name WHERE Dept_id = @Dept_id";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@New_Dept_name", newDepartment_Name.Trim());
                    command.Parameters.AddWithValue("@Dept_id", department_Id.Trim());

                    con.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    con.Close();

                    if (rowsAffected > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Bzz", " swal('نجاح',' تم تحديث اسم القسم بنجاح  ','success');", true);
                    }

                }
            }
        }

        protected void btn_Save_Edit_Click(object sender, EventArgs e)
        {


            UpdateDepartmentName(txt_Edit_dept_id.Text.Trim(), txt_Edit_dept_name.Text.Trim());
            FillRepeater1();


        }
        //دالة لحذف قسم
        public void DeleteDepartment_BY_ID(string department_Id)
        {
            string checkQuery = "SELECT COUNT(*) FROM Division WHERE Dept_id = @Dept_id";
            string deleteQuery = "DELETE FROM Department WHERE Dept_id = @Dept_id";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                // فحص القسم هل يوجد به شعبة
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, con))
                {
                    checkCommand.Parameters.AddWithValue("@Dept_id", department_Id.Trim());
                    int subDepartmentCount = (int)checkCommand.ExecuteScalar();

                    if (subDepartmentCount > 0)
                    {
                        // 

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Bz", " swal('لا يمكن الحذف',' يوجد شعبة في هذا القسم  ','warning');", true);


                    }
                    else
                    {
                        // لا يوجد شعبة في القسم، يمكن حذفه
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, con))
                        {
                            deleteCommand.Parameters.AddWithValue("@Dept_id", department_Id.Trim());
                            int rowsAffected = deleteCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {

                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Bz2", " swal('نجاح',' تم حذف القسم بنجاح  ','success');", true);

                            }
                        }
                    }
                }

                con.Close();
            }
        }

        // مكرر الشعبة
        protected void myRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Edit_Division.Visible = true;
                int index = e.Item.ItemIndex;
                Label Div_id = (Label)e.Item.FindControl("Label1");
                Label Div_name = (Label)e.Item.FindControl("Label2");
                Label dept_id = (Label)e.Item.FindControl("Label3");
                txt__Edit_Division_ID.Text = Div_id.Text;
                txt__Edit_Division_name.Text = Div_name.Text;
                DDL_Edit_Div.SelectedValue = dept_id.Text;


            }
            if (e.CommandName == "Delete")
            {
                int index = e.Item.ItemIndex;
                Label Div_id = (Label)e.Item.FindControl("Label1");

                string divisionId = Div_id.Text; // معرف الشعبة المراد حذفها أو فحصها

                bool hasCourses = CheckIfDivisionHasCourses(Div_id.Text);
                if (hasCourses)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Bz2", " swal('خطأ',' لايمكن حذف هذه الشعبة !! يوجد بها مواد  ','warning');", true);
                }
                else
                {
                    DeleteDivision(divisionId);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Bz2", " swal('نجاح',' تم حذف الشعبة بنجاح  ','success');", true);
                    FillRepeater();

                }

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Edit_Division.Visible = false;
        }


        // دالة للتعديل اسم الشعبة 
        public void UpdateDivisionhName(string Id, string Name)
        {
            string query = "UPDATE Division SET Division_name = @Name , dept_id = @dept_id WHERE Division_id = @Id";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@dept_id", DDL_Edit_Div.SelectedValue);

                    con.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    con.Close();


                }
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                UpdateDivisionhName(txt__Edit_Division_ID.Text, txt__Edit_Division_name.Text);
                Edit_Division.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Bz2", " swal('نجاح',' تم التحديث بنجاح  ','success');", true);
                FillRepeater();
            }
        }
        //دالة للحذف شعبة
        public void DeleteDivision(string divisionId)
        {
            string deleteQuery = "DELETE FROM Division WHERE Division_id = @DivisionId";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand(deleteQuery, con))
                {
                    command.Parameters.AddWithValue("@DivisionId", divisionId);

                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();

                }
            }
        }

        //دالة للتحقق من وجود مواد في الشعبة
        public bool CheckIfDivisionHasCourses(String divisionId)
        {
            string selectQuery = "SELECT COUNT(*) FROM Courses WHERE Division_id = @DivisionId";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand(selectQuery, con))
                {
                    command.Parameters.AddWithValue("@DivisionId", divisionId);

                    con.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    con.Close();

                    return count > 0;
                }
            }
        }

        // دالة بحث تقوم بتعبئة المكرر الخاص بالاقسام
        private void Repeater_Search_Dept()
        {

            string query = "SELECT * FROM Department WHERE dept_name LIKE '%' + @deptName + '%'";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@deptName", txt_Searsh_Name_Dept.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    Repeater1.DataSource = dataTable;
                    Repeater1.DataBind();
                }
                else
                {
                    // التعامل مع حالة عدم وجود بيانات مطابقة
                    Repeater1.DataSource = "";
                    Repeater1.DataBind();
                }
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Repeater_Search_Dept();
        }

        // دالة بحث تقوم بتعبئة المكرر الخاص بالشعب
        private void Repeater_Search_Divsion()
        {
            string query = "SELECT Division.Division_id, Division.Division_name, Department.Dept_id, Department.Dept_name FROM Division INNER JOIN Department ON Division.Dept_id = Department.Dept_id WHERE Division.Division_name LIKE '%' + @divName + '%'";

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@divName", txt_Searsh_Name_Division.Text);
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
        }

        // دالة بحث متقدم تقوم بتعبئة المكرر الخاص بالشعب
        private void Repeater_Search_Divsion_Advanced()
        {
            string query = "SELECT Division.Division_id, Division.Division_name, Department.Dept_id, Department.Dept_name FROM Division INNER JOIN Department ON Division.Dept_id = Department.Dept_id WHERE Department.Dept_id = @deptValue AND Division.Division_name LIKE '%' + @DivisionName + '%'";


            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@DivisionName", txt_Searsh_Name_Division.Text);
                command.Parameters.AddWithValue("@deptValue", DDL_Searsh_Division.SelectedValue);
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
        }


        protected void Button9_Click(object sender, EventArgs e)
        {
            if (ckb_Advanced_Search.Checked)
            {
                Repeater_Search_Divsion_Advanced();
            }
            else
            {
                Repeater_Search_Divsion();

            }


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

        protected void Btn_Searsh_cou_name_Click(object sender, EventArgs e)
        {
            if (CheckBox_Courses.Checked)
            {

                Search_Advanced_FillRepeater_Courses(txt_Searsh_cou_name.Text, DDL_Searsh_Div_Cou.SelectedValue);


            }
            else
            {
                Search_FillRepeater_Courses(txt_Searsh_cou_name.Text);

            }
        }





        protected void btn_X_Import_Cou_Click(object sender, EventArgs e)
        {
            add_Course.Visible = false;
        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //   اكواد رفع المواد
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //دالة رفع ملف الإكسيل والتأكد من معلوماته
        public void AddFile_Courses()
        {
                try
                {
                    //التأكد من انه تم رفع الملف
                    if (file_up_Courses.HasFile)
                    {

                        //التحقق من صيغة الملف وحجمه
                        if (checkTypFile(file_up_Courses))
                        {

                            string path = Path.GetFileName(file_up_Courses.FileName);
                            path = path.Replace(" ", "");
                            file_up_Courses.SaveAs(Server.MapPath("~/upload_Courses/") + path);
                            String ExcelPath = Server.MapPath("~/upload_Courses/") + path;

                            //جملةالإتصال
                            string oldcon = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties = 'Excel 12.0;HDR=YES;IMEX=1;'";
                            //فتح الإتصال مع ملف الإكسيل

                            int CountSuccData = CheckDataInDB(oldcon);
                            if (CountSuccData >= 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "swal('نجاح!', 'تم تحديث بيانات المواد بنجاح', 'success');", true);

                              //  Label2.Text = "تمت إضافة بنجاح " + CountSuccData;

                            }
                            else if (CountSuccData == -2)
                            {

                                ScriptManager.RegisterStartupScript(this, this.GetType(), "dff", "swal('يجب ادخال بيانات التخصص اولا اولا', 'خطا في الإدخال!', 'warning');", true);

                              //  Label2.Text = "تمت إضافة بنجاح " + CountSuccData;

                            }
                            else if(CountSuccData == 0)
                            {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "dff", "swal('ملف الاكسيل فارغ', 'خطا في الإدخال!', 'warning');", true);

                            }

                           else//وجود خطا في النظام
                            {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "swal('البيانات المراد ادخلبها خاطئة', 'خطا في الإدخال!', 'error');", true);

                            }





                    }
                        else//حالة الصغية غير صحيحة
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "cc", "checkFiletype()", true);

                        }


                    }
                    else//حالة لم يقم بإدخال ملف
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "regS()", true);

                    }
                }
                catch (Exception ex)//في حالة خطا في النظام
                {
                    Response.Write("Err IS: " + ex);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "aa1", "swal('خطا في النظام!','قم بإعادة المحاولة مرة أخرى', 'error')", true);


                }
        }
        //دالة التأكد من صيغة الملف
        protected bool checkTypFile(FileUpload f)
        {
            try
            {

                //استخراج الصيغة الموجودة
                string FileExt = Path.GetExtension(f.FileName);
                //التأكد من صيغة الملف
                FileExt = FileExt.ToLower();
                if (FileExt == ".xlsx" || FileExt == ".xls")
                {
                    return true;
                }

                else
                {
                    return false;
                }

            }
            catch
            {

                return false;
            }


        }

        //دالة للتحقق من سلامة البيانات الموجودة في الجدول
        protected int CheckDataInDB(string oldcon)
        {
            try
            {
                int CountSave = 0; // عدد البيانات التي تم حفظها بنجاح

                using (OleDbConnection mycon = new OleDbConnection(oldcon))
                {
                    mycon.Open();

                    DataTable schemaTable = mycon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string sheetName = schemaTable.Rows[0]["TABLE_NAME"].ToString();

                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheetName + "]", mycon);
                    OleDbDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {



                        // التحقق من صحة البيانات قبل حفظها
                        if (!string.IsNullOrEmpty(dr[0].ToString().Trim()) && !string.IsNullOrEmpty(dr[1].ToString().Trim()) && !string.IsNullOrEmpty(dr[2].ToString().Trim()))
                        {



                            int Result = savedata(dr[0].ToString().Trim(), dr[1].ToString().Trim(), dr[2].ToString().Trim());

                            if (Result == 1)
                                CountSave++;
                            else if(Result == -2)
                                CountSave=-2;
                            else if (!dr.HasRows)   // التحقق من انتهاء البيانات في ملف Excel

                                break;

                        }
                    }

                    
                    return CountSave;
                }
            }
            catch
            {
                return -1;
            }
        }

        //عملية حفظ البيانات من الإكسيل الي القاعدة
        private int savedata(String id, String name, String Div_id)
        {
            if (!DoesDivisionExist())
            {
                return -2;
            }
            else
            {


                try
                {
                    String query = "insert into Courses (Course_id,Course_name,Division_id) values (@id,@name,@Div_id)";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@Div_id", Div_id);


                    using (SqlConnection con = new SqlConnection(cs))
                    {


                        cmd.CommandText = query;
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        //تم الإضافة بنجاح
                        return 1;
                    }


                }
                catch//خطا ف النظام
                {
                    return -1;

                }




            }
            }
        public void DeleteAllCourses()
        {
            // استعلام لحذف جميع بيانات المواد
            string query = "DELETE FROM Courses";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool DoesDivisionExist()
        {

            // استعلام لفحص وجود شعبة
            string query = "SELECT COUNT(*) FROM Division";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }


        protected void btn_add_Course_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DeleteAllCourses();
                AddFile_Courses();

                FillRepeater_Courses();

                add_Course.Visible = false;

                tbl_dept.Visible = false;
                tbl_dept_search.Visible = false;

                tbl_div.Visible = false;
                tbl_div_search.Visible = false;

                tbl_Cou_search.Visible = true;
                tbl_Course.Visible = true;
            }
        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //   النهاية
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //   اكواد رفع االتخصصات
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //دالة رفع ملف الإكسيل والتأكد من معلوماته
        public void AddFile_Division()
        {



            if (Page.IsValid)
                try
                {
                    //التأكد من انه تم رفع الملف
                    if (FileUpload_Division.HasFile)
                    {

                        //التحقق من صيغة الملف وحجمه
                        if (checkTypFile(FileUpload_Division))
                        {

                            string path = Path.GetFileName(FileUpload_Division.FileName);
                            path = path.Replace(" ", "");
                            FileUpload_Division.SaveAs(Server.MapPath("~/upload_Division/") + path);
                            String ExcelPath = Server.MapPath("~/upload_Division/") + path;

                            //جملةالإتصال
                            string oldcon = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties = 'Excel 12.0;HDR=YES;IMEX=1;'";
                            //فتح الإتصال مع ملف الإكسيل

                            int CountSuccData = CheckDataInDB_Division(oldcon);
                            if (CountSuccData >= 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "AddFile()", true);


                            }
                            else if (CountSuccData == -2)
                            {

                                ScriptManager.RegisterStartupScript(this, this.GetType(), "dff", "swal('يجب ادخال بيانات القسم  اولا', 'خطا في الإدخال!', 'warning');", true);

                                //  Label2.Text = "تمت إضافة بنجاح " + CountSuccData;

                            }
                            else if (CountSuccData == 0)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "dff", "swal('ملف الاكسيل فارغ', 'خطا في الإدخال!', 'warning');", true);

                            }
                            else//وجود خطا في النظام
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "swal('البيانات المراد ادخلبها خاطئة', 'خطا في الإدخال!', 'error');", true);

                            }





                        }
                        else//حالة الصغية غير صحيحة
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "cc", "checkFiletype()", true);

                        }


                    }
                    else//حالة لم يقم بإدخال ملف
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "regS()", true);

                    }
                }
                catch (Exception ex)//في حالة خطا في النظام
                {
                    Response.Write("Err IS: " + ex);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);


                }
        }


        //دالة للتحقق من سلامة البيانات الموجودة في الجدول
        protected int CheckDataInDB_Division(string oldcon)
        {
            try
            {
                int CountSave = 0; // عدد البيانات التي تم حفظها بنجاح

                using (OleDbConnection mycon = new OleDbConnection(oldcon))
                {
                    mycon.Open();

                    DataTable schemaTable = mycon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string sheetName = schemaTable.Rows[0]["TABLE_NAME"].ToString();

                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheetName + "]", mycon);
                    OleDbDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {



                        // التحقق من صحة البيانات قبل حفظها
                        if (!string.IsNullOrEmpty(dr[0].ToString().Trim()) && !string.IsNullOrEmpty(dr[1].ToString().Trim()) && !string.IsNullOrEmpty(dr[2].ToString().Trim()))
                        {



                            int Result = savedata_Division(dr[0].ToString().Trim(), dr[1].ToString().Trim(), dr[2].ToString().Trim());

                            if (Result == 1)
                                CountSave++;
                            else if (Result == -2)
                                CountSave = -2;
                            else if (!dr.HasRows)   // التحقق من انتهاء البيانات في ملف Excel

                                break;


                        }
                    }


                    return CountSave;
                }
            }
            catch
            {
                return -1;
            }
        }

        //عملية حفظ البيانات من الإكسيل الي القاعدة
        private int savedata_Division(String id, String name, String Dept_id)
        {
            if (!DoesDepartmentExist())
            {
                return -2;
            }
            else
            {



                try
                {
                    String query = "insert into Division (Division_id,Division_name,Dept_id) values(@id,@name,@Dept_id)";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@Dept_id", Dept_id);



                    using (SqlConnection con = new SqlConnection(cs))
                    {


                        cmd.CommandText = query;
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        //تم الإضافة بنجاح
                        return 1;
                    }


                }
                catch//خطا ف النظام
                {
                    return -1;

                }
            }



        }

        public void DeleteAllDivisions()
        {
            // استعلام لحذف جميع بيانات الشعبة
            string query = "DELETE FROM Division";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool DoesDepartmentExist()
        {
            // استعلام لفحص وجود قسم
            string query = "SELECT COUNT(*) FROM Department";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
             {
                DeleteAllDivisions();
                AddFile_Division();

                add_div.Visible = false;

                tbl_Cou_search.Visible = false;
                tbl_Course.Visible = false;



                tbl_dept.Visible = false;
                tbl_dept_search.Visible = false;

                tbl_div.Visible = true;
                tbl_div_search.Visible = true;
                FillRepeater();
            }
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //   النهاية
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //   اكواد رفع الاقسام
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


        //دالة رفع ملف الإكسيل والتأكد من معلوماته
        public void btnAddFile_Dept()
        {



         
                try
                {
                    //التأكد من انه تم رفع الملف
                    if (FileUpload_Dept.HasFile)
                    {

                        //التحقق من صيغة الملف وحجمه
                        if (checkTypFile(FileUpload_Dept))
                        {

                            string path = Path.GetFileName(FileUpload_Dept.FileName);
                            path = path.Replace(" ", "");
                            FileUpload_Dept.SaveAs(Server.MapPath("~/upload_Dept/") + path);
                            String ExcelPath = Server.MapPath("~/upload_Dept/") + path;

                            //جملةالإتصال
                            string oldcon = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties = 'Excel 12.0;HDR=YES;IMEX=1;'";
                            //فتح الإتصال مع ملف الإكسيل

                            int CountSuccData = CheckDataInDB_Dept(oldcon);
                            if (CountSuccData >= 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "swal('نجاح !', 'تم تحديث بيانات الاقسام بنجاح!', 'success');", true);


                            }
                            else if (CountSuccData == 0)
                            {

                                ScriptManager.RegisterStartupScript(this, this.GetType(), "dff", "CheckFileRowsEnter()", true);


                            }

                            else//وجود خطا في النظام
                            {
                                Response.Write("Err IS: Else Errrr");
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

                            }





                        }
                        else//حالة الصغية غير صحيحة
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "cc", "checkFiletype()", true);

                        }


                    }
                    else//حالة لم يقم بإدخال ملف
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "regS()", true);

                    }
                }
                catch (Exception ex)//في حالة خطا في النظام
                {
                    Response.Write("Err IS: " + ex);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);


                }
        }


        //دالة للتحقق من سلامة البيانات الموجودة في الجدول
        protected int CheckDataInDB_Dept(string oldcon)
        {
            try
            {
                int CountSave = 0; // عدد البيانات التي تم حفظها بنجاح

                using (OleDbConnection mycon = new OleDbConnection(oldcon))
                {
                    mycon.Open();

                    DataTable schemaTable = mycon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string sheetName = schemaTable.Rows[0]["TABLE_NAME"].ToString();

                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheetName + "]", mycon);
                    OleDbDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {



                        // التحقق من صحة البيانات قبل حفظها
                        if (!string.IsNullOrEmpty(dr[0].ToString().Trim()) && !string.IsNullOrEmpty(dr[1].ToString().Trim()))
                        {



                            int Result = savedata_Dept(dr[0].ToString().Trim(), dr[1].ToString().Trim());

                            if (Result == 1)
                                CountSave++;
                            else if (!dr.HasRows)   // التحقق من انتهاء البيانات في ملف Excel

                                break;

                        }
                    }


                    return CountSave;
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);
                return -1;
            }
        }

        //عملية حفظ البيانات من الإكسيل الي القاعدة
        private int savedata_Dept(String id, String name)
        {

            try
            {
                String query = "insert into Department (Dept_id,Dept_name) values(@id,@name)";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);


                using (SqlConnection con = new SqlConnection(cs))
                {


                    cmd.CommandText = query;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    //تم الإضافة بنجاح
                    return 1;
                }


            }
            catch//خطا ف النظام
            {
                return -1;

            }



        }

        public void DeleteAllDepartments()
        {
            // استعلام لحذف جميع بيانات القسم
            string query = "DELETE FROM Department";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DeleteAllDepartments();
            btnAddFile_Dept();
            add_dept.Visible = false;

            tbl_dept.Visible = true;
            tbl_dept_search.Visible = true;

            tbl_div.Visible = false;
            tbl_div_search.Visible = false;

            tbl_Cou_search.Visible = false;
            tbl_Course.Visible = false;

            FillRepeater1();
        }




        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //   النهاية
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


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

        private void Repeater_Courses_Pagining()
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

            string query_1 = "SELECT Division.Division_name, Division.Division_id, Department.Dept_name, Department.Dept_id, Courses.Course_name, Courses.Course_id " +
                             "FROM Department " +
                             "INNER JOIN Division ON Department.Dept_id = Division.Dept_id " +
                             "INNER JOIN Courses ON Division.Division_id = Courses.Division_id ORDER BY Course_id ASC";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmdRepeater = new SqlCommand(query_1 + pagequery, con);  //Select the records
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmdRepeater);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                Repeater_Courses.DataSource = ds;
                Repeater_Courses.DataBind();  //Bind the repeater
                cmdRepeater = new SqlCommand("select COUNT(*) from Courses", con);  //Count the total records
                con.Open();
                int count = (int)cmdRepeater.ExecuteScalar();
                con.Close();

                var uri = new Uri(Request.Url.AbsoluteUri);
                var query = HttpUtility.ParseQueryString(uri.Query); //Get the query strings from the url
                query.Remove("pn"); //Remove the query string [pn] to avoid repetation
                string link = HttpContext.Current.Request.Url.AbsolutePath + "?" + query;
                paging_Courses.InnerHtml = Set_Paging(page, pagesize, count, "activeLink", link, "disableLink");  //Fill the pagination in the div tag
            }






        }

      
    }
}