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
    public partial class WebForm4 : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected int UploadImages()
        {
            int result = 0;

            if (FileUpload1.HasFiles)
            {
                foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
                {
                    string fileName = Path.GetFileName(postedFile.FileName);
                    string fileExtension = Path.GetExtension(postedFile.FileName).ToLower();

                    // قم بتعيين الامتدادات المسموح بها
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

                    // قم بالتحقق من امتداد الملف
                    if (allowedExtensions.Contains(fileExtension))
                    {
                        postedFile.SaveAs(Server.MapPath("~/Images_Student/" + fileName));
                        Label1.Text = "تم رفع الصور بنجاح";
                        result = 1;
                    }
                    else
                    {
                        Label1.Text = "امتداد الملف غير مدعوم. يرجى اختيار صورة بامتداد صحيح.";
                        result = -1;
                        break; // قم بإيقاف الحلقة إذا كان هناك ملف غير صحيح
                    }
                }
            }
            else
            {
                Label1.Text = "الرجاء اختيار ملفات للرفع";
                result = -1;
            }

            return result;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int uploadResult = UploadImages();

            if (uploadResult == 1)
            {
                Label1.Text = "Done";
            }
            else if (uploadResult == -1)
            {
                Label1.Text = "Error";
            }
        }

    }
}