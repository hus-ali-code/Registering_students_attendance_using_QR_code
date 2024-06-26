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
    public partial class student_admin : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                FillRepeater(myRepeater);

                add_Student.Visible =false;
                add_Img_Student.Visible = false;
            }
        }

        public void FillRepeater(Repeater repeaterControl)
        {
            string selectQuery = "SELECT * FROM Students";

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(selectQuery, con);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    con.Open();
                    adapter.Fill(dataTable);

                    repeaterControl.DataSource = dataTable;
                    repeaterControl.DataBind();
                }
                catch (Exception ex)
                {
                    // يمكنك التعامل مع الخطأ هنا
                }
            }
        }

        private DataTable SearchInDatabase(string searchQuery)
        {
            // قم بتنفيذ استعلام البحث في قاعدة البيانات واسترداد النتائج
            // يمكنك استخدام استعلام SQL لتنفيذ البحث أو استخدام ORM مثل Entity Framework

            // على سبيل المثال، يمكنك استخدام استعلام SQL مثل التالي:

            string selectQuery = "SELECT * FROM Students WHERE Student_Fname LIKE '%' + @SearchQuery + '%' OR Student_Sname LIKE '%' + @SearchQuery + '%' OR Student_Lname LIKE '%' + @SearchQuery + '%' OR Student_Kaid LIKE '%' + @SearchQuery + '%' OR Student_NAT LIKE '%' + @SearchQuery + '%' ;";

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(selectQuery, con);
                command.Parameters.AddWithValue("@SearchQuery", "%" + searchQuery + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    con.Open();
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    // يمكنك التعامل مع الخطأ هنا
                }

                return dataTable;
            }
        }

        protected void btn_Searsh_Click(object sender, EventArgs e)
        {
            string searchQuery = TextBox1.Text.Trim();

            // قم بتنفيذ استعلام البحث واسترداد النتائج
            DataTable searchResults = SearchInDatabase(searchQuery);

            // قم بتعيين النتائج كمصدر لبيانات Repeater وتعبئته
            myRepeater.DataSource = searchResults;
            myRepeater.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            add_Student.Visible = true;
        }

        protected void btn_X_Import_Stu_Click(object sender, EventArgs e)
        {
            add_Student.Visible = false;

        }

        //____________________________________________________________________________________________________________________________________
        //______________________________________________________________اكواد استيراد بيانات الطلبة______________________________________________________________________
        //____________________________________________________________________________________________________________________________________

        //دالة رفع ملف الإكسيل والتأكد من معلوماته
        public int btnAddFile_Click()
        {

                try
                {
                    
                        //التحقق من صيغة الملف وحجمه
                        if (checkTypFile(file_up_Stu))
                        {

                            string path = Path.GetFileName(file_up_Stu.FileName);
                            path = path.Replace(" ", "");
                            file_up_Stu.SaveAs(Server.MapPath("~/upload_Student/") + path);
                            String ExcelPath = Server.MapPath("~/upload_Student/") + path;

                            //جملةالإتصال
                            string oldcon = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties = 'Excel 12.0;HDR=YES;IMEX=1;'";
                            //فتح الإتصال مع ملف الإكسيل

                            int CountSuccData = CheckDataInDB(oldcon);
                            if (CountSuccData >= 1)
                            {
                                return CountSuccData;

                            }
                            else if (CountSuccData == 0)
                            {
                               return CountSuccData;
                            }

                            else//وجود خطا في النظام
                            {
                               
                                 return -1;
                            }

                        }
                        else//حالة الصغية غير صحيحة
                        {
                             return -2;

                        }
   

            
                }
                catch (Exception ex)//في حالة خطا في النظام
                {
                    Response.Write("Err IS: " + ex);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);
                     return -3;


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
                        if (!string.IsNullOrEmpty(dr[0].ToString().Trim()) && !string.IsNullOrEmpty(dr[1].ToString().Trim()) && !string.IsNullOrEmpty(dr[2].ToString().Trim()) && !string.IsNullOrEmpty(dr[3].ToString().Trim()) && !string.IsNullOrEmpty(dr[4].ToString().Trim()))
                        {

                            int Result = savedata(dr[0].ToString().Trim(), dr[1].ToString().Trim(), dr[2].ToString().Trim(), dr[3].ToString().Trim(), dr[4].ToString().Trim(), dr[5].ToString().Trim(), dr[6].ToString().Trim());

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
                return -1;
            }
        }

        //عملية حفظ البيانات من الإكسيل الي القاعدة
        private int savedata(String id, String Kaid, String Fname, String Sname, String Lname, String NAT, String Photo)
        {

            try
            {
                String query = "insert into Students (Student_id ,Student_Kaid ,Student_Fname ,Student_Sname ,Student_Lname ,Student_NAT ,Photo) values(@id ,@Kaid ,@Fname,@Sname,@Lname,@NAT,@Photo)";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Kaid", Kaid);
                cmd.Parameters.AddWithValue("@Fname", Fname);
                cmd.Parameters.AddWithValue("@Sname", Sname);
                cmd.Parameters.AddWithValue("@Lname", Lname);
                cmd.Parameters.AddWithValue("@NAT", NAT);
                cmd.Parameters.AddWithValue("@Photo", Photo);




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

        public void DeleteAllStudents()
        {
            // استعلام لحذف جميع بيانات المواد
            string query = "DELETE FROM Students";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void btn_add_Stu_Click(object sender, EventArgs e)
        {



            DeleteAll_Cou_Stu();
            DeleteAllStudents();
            int Count_Stud = btnAddFile_Click();
            int Count_Cou_Stu = btnAddFile_Cou_Stu();

            if (Page.IsValid)
            {
                if(Count_Cou_Stu == -3)
                {
                   
                }
                else if (Count_Stud >= 1 && Count_Cou_Stu>=1)
                {

                    btnAddFile_Click();
                    btnAddFile_Cou_Stu();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "dfdf", "swal('نجاح', 'تم التحديث بنجاح!', 'success');", true);

                    FillRepeater(myRepeater);

                    add_Student.Visible = false;

                }
                else if (Count_Stud == 0 || Count_Cou_Stu == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ddff", "swal('احد الملفات فارغ ', 'خطا في الإدخال!', 'warning');", true);

                }
                else if (Count_Stud == -1 || Count_Cou_Stu == -1)
                {
                    Response.Write("Err IS: Else CheckDataInDB(oldcon);");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "aadd", "swal('خطا في النظام!', 'قم بإعادة المحاولة مرة أخرى', 'error');", true);
                }
                else if (Count_Stud == -2 || Count_Cou_Stu == -2)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ccss", "swal('صيغة احد الملفات غير صحيحة ', 'خطا في الإدخال!', 'warning');", true);

                }
                else if (Count_Stud == -3 || Count_Cou_Stu == -3)
                {
                    Response.Write("Err IS: btnAddFile_Click() ");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "aaee", "swal('خطا في النظام!', 'قم بإعادة المحاولة مرة أخرى', 'error');", true);
                }

            }
        }

        //____________________________________________________________________________________________________________________________________
        //______________________________________________________________اكواد استيراد مواد الطلبة______________________________________________________________________
        //____________________________________________________________________________________________________________________________________

        //دالة رفع ملف الإكسيل والتأكد من معلوماته
        public int btnAddFile_Cou_Stu()
        {

                try
                {
                   
                        //التحقق من صيغة الملف وحجمه
                        if (checkTypFile(file_up_Stu_Cou))
                        {

                            string path = Path.GetFileName(file_up_Stu_Cou.FileName);
                            path = path.Replace(" ", "");
                            file_up_Stu_Cou.SaveAs(Server.MapPath("~/upload_Cou_Stu/") + path);
                            String ExcelPath = Server.MapPath("~/upload_Cou_Stu/") + path;

                            //جملةالإتصال
                            string oldcon = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties = 'Excel 12.0;HDR=YES;IMEX=1;'";
                            //فتح الإتصال مع ملف الإكسيل

                            int CountSuccData = CheckDataInDB_Cou_Stu(oldcon);
                            if (CountSuccData >= 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "AddFile()", true);
                            return CountSuccData;

                            }
                            else if (CountSuccData == 0)
                            {

                                ScriptManager.RegisterStartupScript(this, this.GetType(), "dff1", "CheckFileRowsEnter()", true);
                            return CountSuccData;

                            }
                            else if (CountSuccData == -3)
                            {

                            return CountSuccData;
                            }

                        else//وجود خطا في النظام
                            {
                               
                            return -1;

                            }


                        }
                        else//حالة الصغية غير صحيحة
                        {

                            return -2;

                        }


                }
                catch (Exception ex)//في حالة خطا في النظام
                {
                   
                return -4;

                }
        }

        //دالة للتحقق من سلامة البيانات الموجودة في الجدول
        protected int CheckDataInDB_Cou_Stu(string oldcon)
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



                            int Result = savedata_Cou_Stu(dr[0].ToString().Trim(), dr[1].ToString().Trim());

                            if (Result == 1)
                                CountSave++;
                            else if(Result == -2)
                                CountSave =-2;
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
        private int savedata_Cou_Stu(String id_Stu, String id_Cou)
        {
            if (!DoesCoursesExist())
            {
                return -3;
            }
            else
            {

                try
                {
                    String query = "insert into Student_Course (Student_id ,Course_id ) values(@id_Stu,@id_Cou)";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Parameters.AddWithValue("@id_Stu", id_Stu);
                    cmd.Parameters.AddWithValue("@id_Cou", id_Cou);

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
        public void DeleteAll_Cou_Stu()
        {
            // استعلام لحذف جميع بيانات المواد
            string query = "DELETE FROM Student_Course";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool DoesCoursesExist()
        {

            // استعلام لفحص وجود شعبة
            string query = "SELECT COUNT(*) FROM Courses";

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


        //____________________________________________________________________________________________________________________________________
        //______________________________________________________________اكواد استيراد صور الطلبة______________________________________________________________________
        //____________________________________________________________________________________________________________________________________
        //
        protected int UploadImages()
        {
            int result = 0;

            if (file_up_Stu_img.HasFiles)
            {
                foreach (HttpPostedFile postedFile in file_up_Stu_img.PostedFiles)
                {
                    string fileName = Path.GetFileName(postedFile.FileName);
                    string fileExtension = Path.GetExtension(postedFile.FileName).ToLower();

                    // قم بتعيين الامتدادات المسموح بها
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

                    // قم بالتحقق من امتداد الملف
                    if (allowedExtensions.Contains(fileExtension))
                    {
                        postedFile.SaveAs(Server.MapPath("~/Images_Student/" + fileName));
                        result = 1;
                    }
                    else
                    {
                        result = -1;
                        break; // قم بإيقاف الحلقة إذا كان هناك ملف غير صحيح
                    }
                }
            }
            else
            {
                result = -1;
            }

            return result;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            add_Img_Student.Visible = true;
        }

        protected void btn_X_Import_Img_Stu_Click(object sender, EventArgs e)
        {
            add_Img_Student.Visible = false;
        }

        protected void btnFileImg_Click(object sender, EventArgs e)
        {
            int uploadResult = UploadImages();

            if (uploadResult == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "dfff", "swal('نجاح', 'تم رفع الصور بنجاح!', 'success');", true);

                add_Img_Student.Visible = false;
            }
            else if (uploadResult == -1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "cccc", "swal('امتداد الملف غير مدعوم. يرجى اختيار صورة بامتداد صحيح. ', 'خطا في الإدخال!', 'warning');", true);
            }
        }
    }
}