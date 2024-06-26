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

    public partial class WebForm3 : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //دالة رفع ملف الإكسيل والتأكد من معلوماته
        public void btnAddFile_Click()
        {



            if (Page.IsValid)
                try
                {
                    //التأكد من انه تم رفع الملف
                    if (FileUpload1.HasFile)
                    {

                        //التحقق من صيغة الملف وحجمه
                        if (checkTypFile(FileUpload1))
                        {

                            string path = Path.GetFileName(FileUpload1.FileName);
                            path = path.Replace(" ", "");
                            FileUpload1.SaveAs(Server.MapPath("~/upload_Cou_Stu/") + path);
                            String ExcelPath = Server.MapPath("~/upload_Cou_Stu/") + path;

                            //جملةالإتصال
                            string oldcon = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties = 'Excel 12.0;HDR=YES;IMEX=1;'";
                            //فتح الإتصال مع ملف الإكسيل
  
                                        int CountSuccData = CheckDataInDB(oldcon);
                                        if (CountSuccData >= 1)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "AddFile()", true);

                                            Label2.Text = "تمت إضافة بنجاح " + CountSuccData;
                                         
                                        }
                                        else if (CountSuccData == 0)
                                        {

                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "dff", "CheckFileRowsEnter()", true);

                                            Label2.Text = "تمت إضافة بنجاح " + CountSuccData;
                                     
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
        //دالة التأكد من صيغة الملف
        protected bool checkTypFile(FileUpload f)
        {
            try
            {

                //استخراج الصيغة الموجودة
                string FileExt = Path.GetExtension(f.FileName);
                //التأكد من صيغة الملف
                FileExt = FileExt.ToLower();
                if (FileExt == ".xlsx" || FileExt == ".xls" )
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
                        if (!string.IsNullOrEmpty(dr[0].ToString().Trim()) && !string.IsNullOrEmpty(dr[1].ToString().Trim()))
                        {



                            int Result = savedata(dr[0].ToString().Trim(), dr[1].ToString().Trim());

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
        private int savedata(String id_Stu, String id_Cou)
        {
            
            try
            {
                    String query = "insert into Student_COurse (Student_id ,Course_id ) values(@id_Stu,@id_Cou)";
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

        public void UpdateStudentNationalId()
        {
            string query = "UPDATE Students SET Student_NAT = @New_Student_NAT WHERE Student_NAT = @Student_NAT";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@New_Student_NAT", "وافد");
                    command.Parameters.AddWithValue("@Student_NAT", "");

                    con.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    con.Close();


                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            btnAddFile_Click();
        }
    }
}