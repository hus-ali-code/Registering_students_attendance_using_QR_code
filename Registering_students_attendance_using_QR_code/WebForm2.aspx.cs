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
    public partial class WebForm2 : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected int checkCountFile(string oldcon)
        {
            //متغير لحفظ عدد الصفوف
            int rowsCount = 0;
            using (OleDbConnection mycon = new OleDbConnection(oldcon))
            {
                mycon.Open();
                //الحصول ع اسم الورقة داخل ملف الإكسيل
                DataTable schemaTable = mycon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = schemaTable.Rows[0]["TABLE_NAME"].ToString();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheetName + "]", mycon);
                OleDbDataReader dr = cmd.ExecuteReader();
                //عداد لمعرفة الأسطر
                while (dr.Read())
                {

                    rowsCount++;

                }


            }//في حالة كانت الأسطر تساوي صفر، فيعني انه فارغ
            if (rowsCount != 0)
            {
                return rowsCount;
            }

            return 0;



        }

        //عملية حفظ البيانات من الإكسيل الي القاعدة
        private int savedata(String id, String NAT, String name)
        {
           
                String query = "insert into Students (Student_id,Student_NAT,Student_name) values(@id,@NAT,@name)";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@NAT", NAT);
                cmd.Parameters.AddWithValue("@name", name);

            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {



                    cmd.CommandText = query;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    //تم الإضافة بنجاح
                    return 1;
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", " swal('نجاح',' تم تحديث بيانات الطلبة بنجاح    ','success');", true);
                    return -1;

                }
            }


        }



        protected int CheckDataInDB(string oldcon)
        {

          

                //متغير لحفظ عمليات التي تم حفظها في قاعدة البيانات بنجاح
                int CountSave = 0;

                using (OleDbConnection mycon = new OleDbConnection(oldcon))
                {
                    mycon.Open();

                    //الحصول ع اسم الورقة داخل ملف الإكسيل
                    DataTable schemaTable = mycon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string sheetName = schemaTable.Rows[0]["TABLE_NAME"].ToString();
                    //تصفح كل بيانات الجدول
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheetName + "]", mycon);
                    OleDbDataReader dr = cmd.ExecuteReader();

                    //يتم التحقق من جميع البيانات
                    while (dr.Read())
                    {
                       
                            int Result = savedata(dr[0].ToString().Trim(), dr[1].ToString().Trim(), dr[2].ToString().Trim());
                            //في حالة كان الصف كل بيانات صحيحة
                            if (Result == 1)

                                CountSave++;//تمت الإضافة بنجاح

                            //فشل عملية الإضافة
                            else
                                return -1;
                    }


                    return CountSave;
                }


           

        }



        public void btnAddFile()
        {
           
                   

                        string path = Path.GetFileName(FileUpload1.FileName);
                        path = path.Replace(" ", "");
                        FileUpload1.SaveAs(Server.MapPath("~/upload/") + path);
                        String ExcelPath = Server.MapPath("~/upload/") + path;

                        //جملةالإتصال
                        string oldcon = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties = 'Excel 12.0;HDR=YES;IMEX=1;'";
                        //فتح الإتصال مع ملف الإكسيل

                        //عد صفوف الملف
                        int CountFile = checkCountFile(oldcon);

                        if (CountFile != 0)
                        {


                            int CountSuccData = CheckDataInDB(oldcon);
                            if (CountSuccData >= 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "AddFile()", true);

                                Label2.Text = "تمت إضافة بنجاح " + CountSuccData + "   صفوف، من أصل " + CountFile + " صفوف ";


                            }
                            else if (CountSuccData == 0)
                            {

                                ScriptManager.RegisterStartupScript(this, this.GetType(), "dff", "CheckFileRowsEnter()", true);

                                Label2.Text = "تمت إضافة بنجاح " + CountSuccData + "   صفوف، من أصل " + CountFile + " صفوف ";

                            }

                            else//وجود خطا في النظام
                            {
                                Response.Write("Err IS: Else Errrr");
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

                            }

                        }
                        else//ملف فارغ
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "cc", "checkFileRows()", true);

                        }



                    
                  

             
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                //التأكد من انه تم رفع الملف
                if (FileUpload1.HasFile)
                {
                    Delete();
                    btnAddFile();
                    DeleteStudentNationalId();
                        UpdateStudentNationalId();

                }
                else//حالة لم يقم بإدخال ملف
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "regS()", true);

                }
            }
        }

        public void UpdateStudentNationalId()
        {
            string query = "UPDATE Students SET Student_NAT = @New_Student_NAT WHERE Student_NAT = @Student_NAT";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@New_Student_NAT", "وافد");
                    command.Parameters.AddWithValue("@Student_NAT","");

                    con.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    con.Close();

                   
                }
            }
        }
        public void DeleteStudentNationalId()
        {

            string query = "Delete From Students where Student_NAT = '' and Student_name = ''";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    con.Close();


                }
            }
        }

        public void Delete()
        {

            string query = "Delete From Students";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    con.Close();


                }
            }
        }



    }
}