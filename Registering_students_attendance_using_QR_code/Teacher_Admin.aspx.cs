using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Registering_students_attendance_using_QR_code
{
    public partial class teacher_admin : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                add_teach.Visible = false;
                Edit_teach.Visible = false;
              
               FillRepeater(myRepeater);
                

            }
            if (Page.IsPostBack)
            {
                FillRepeater(myRepeater);

            }

            Repeater_Pagining();


        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            add_teach.Visible = true;

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            add_teach.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {//التأكدمن عدم وجود الفراغات 

                if (Page.IsValid)
                { //التأكد من عدم وجود بيانات مكررة
                    if ((Check_Info()) && (!Check_Email()))
                    {

                        InsRec();
                        txt_Lname.Text = "";
                        txt_Fname.Text = "";
                        txt_Email.Text = "";
                        add_teach.Visible = false;


                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "A", "Error()", true);

                }
            }
            catch//في حال حدوث خطا في إنشاء الحساب
            {


                ScriptManager.RegisterStartupScript(this, this.GetType(), "A", "Error()", true);



            }

        }
       

        public bool Check_Info()
        {
            try
            { //التأكد  من عدم وجود فراغ
                if (txt_Email.Text != "")
                {

                    return true;

                }
                //في حال وجود فراغ او غير تطابق في البيانات
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ADa", "Wa1()", true);
                return false;
            }
            catch
            {

                return false;
            }



        }



        public bool Check_Email()
        {
            string Email = txt_Email.Text.Trim();

            try
            {   //التأكد من وجود بريد إلكتروني سابق
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "select * from Teachers where Email = @Email";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Awx", "Check_email()", true);

                            return true;

                        }

                    }
                    return false;

                }

            }
            catch
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "B", "Error()", true);

                return false;

            }





        }

        //إرسال رمز التحقق إلى البريد الإلكتروني
        protected string sbtBtn_Click()
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(txt_Email.Text.ToString().Trim());
            mail.From = new MailAddress("yhyyatlwbh@gmail.com");
            mail.Subject = "تأكيد بريدك الإلكتروني في موقع تسجيل الحضور بكلية العلوم التقنية ";

            Random random = new Random();
            string code = random.Next(100000, 999999).ToString("D6");

            string Msg = @"<div style='background:#F2F2F2; padding: 30px;'> <div style='text-align: center;'> <img src='https://i.postimg.cc/j5ZCg3w8/5156366.jpg' style='width: 150px;'> <h1 style='font-size: 24px; color: #1A237E;'>أهلاً بكم في موقعنا </h1> </div> <div style='font-size: 18px;'> <p style='color: #333;text-align:right'>نرحب بكم ونشكركم على تسجيلكم معنا. من فضلك قم بتأكيد بريدك الإلكتروني.</p> </div> <div style='text-align: center; font-size:20px;'> <a href='#' style='background-color: #20B2AA; color: white; padding: 10px 30px; text-decoration: none;text-align:right;direction:rtl;color:White; font-weight: 700;' > " + code + @": رمز التحقق هو </a> </div> </div>";

            mail.Body = Msg;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587; // 25 465
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("yhyyatlwbh@gmail.com", "rmom ahjg tyso arup");
            smtp.Send(mail);


            return code;
        }
        //دالة إنشاء الحساب مبدئيا
        public void InsRec()
        {


            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "insert into Teachers (Teacher_Fname,Teacher_Lname,Email,Code)values(@fn,@ln,@Em,@Cd)";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@fn", txt_Fname.Text.Trim());
                    cmd.Parameters.AddWithValue("@ln",txt_Lname.Text.Trim());
                    cmd.Parameters.AddWithValue("@Em", txt_Email.Text.Trim());
                    cmd.Parameters.AddWithValue("@Cd", sbtBtn_Click().ToString());


                    con.Open();
                    cmd.ExecuteNonQuery();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "K", "regS1()", true);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Bzz", "Error()", true);


            }




        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (CheckEmailExists(txt_Email_Edit_NEW.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "KK1", "Check_email()", true);

                }
                else
                {
                    UpdateTeacherInformation(txt_Email_Edit.Text, txt_Fname_Edit.Text, txt_Lname_Edit.Text, txt_Email_Edit_NEW.Text);
                    Edit_teach.Visible = false;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Bzz", "Error()", true);

            }



        }

      
/*
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            Edit_teach.Visible = true;


                if (e.CommandName == "Edit")
                {

                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                txt_Email_Edit.Text = row.Cells[2].Text;

  
                }


        }*/


        protected void btn_Close_Edit_Teacher_Click(object sender, EventArgs e)
        {
            Edit_teach.Visible = false;

        }

        protected void myRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Edit_teach.Visible = true;
                int index = e.Item.ItemIndex;
                Label Teacher_Email = (Label)e.Item.FindControl("Label1");
                txt_Email_Edit.Text = Teacher_Email.Text;
                txt_Fname_Edit.Text = GetTeacherFname(Teacher_Email.Text);
                txt_Lname_Edit.Text = GetTeacherLname(Teacher_Email.Text);

            }
        
        }
        public string GetTeacherFname(string email)
        {

            string TeacherFname = "";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string query = "SELECT Teacher_Fname FROM Teachers WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TeacherFname = reader["Teacher_Fname"].ToString();
                }

                reader.Close();
            }

            return TeacherFname;
        }
        public string GetTeacherLname(string email)
        {

            string TeacherLname = "";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string query = "SELECT Teacher_Lname FROM Teachers WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TeacherLname = reader["Teacher_Lname"].ToString();
                }

                reader.Close();
            }

            return TeacherLname;
        }

        //دالة تقوم بتعديل بيانات الاستاذ
          public void UpdateTeacherInformation(string email, string firstName, string lastName, string newEmail)
          {
             string updateQuery = "UPDATE Teachers SET Teacher_Fname = @FirstName, Teacher_Lname = @LastName, Code=@Code_NEW, Email = @NewEmail WHERE Email = @Email";

            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {

                    SqlCommand command = new SqlCommand(updateQuery, con);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@NewEmail", newEmail);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Code_NEW", sbtBtn_Click_Edit().ToString());


             
                    con.Open();
                    command.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "KK1", "Update()", true);

                }

                catch (Exception ex)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "kk3", "Error()", true);


                }


            }

          }

        public bool CheckEmailExists(string email)
        {
            string selectQuery = "SELECT COUNT(*) FROM Teachers WHERE Email = @Email";

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(selectQuery, con);
                command.Parameters.AddWithValue("@Email", email);

                try
                {
                    con.Open();
                    int count = (int)command.ExecuteScalar();
                    return (count > 0);
                }
                catch (Exception ex)
                { 
                    return false;
                }
            }
        }

        public void FillRepeater(Repeater repeaterControl)
        {
            string selectQuery = "SELECT * FROM Teachers";

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
        //إرسال رمز التحقق إلى البريد الإلكتروني
        protected string sbtBtn_Click_Edit()
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(txt_Email_Edit_NEW.Text.ToString().Trim());
            mail.From = new MailAddress("yhyyatlwbh@gmail.com");
            mail.Subject = "تأكيد بريدك الإلكتروني في موقع تسجيل الحضور بكلية العلوم التقنية ";

            Random random = new Random();
            string code = random.Next(100000, 999999).ToString("D6");

            string Msg = @"<div style='background:#F2F2F2; padding: 30px;'> <div style='text-align: center;'> <img src='https://i.postimg.cc/j5ZCg3w8/5156366.jpg' style='width: 150px;'> <h1 style='font-size: 24px; color: #1A237E;'>أهلاً بكم في موقعنا </h1> </div> <div style='font-size: 18px;'> <p style='color: #333;text-align:right'>نرحب بكم ونشكركم على تسجيلكم معنا. من فضلك قم بتأكيد بريدك الإلكتروني.</p> </div> <div style='text-align: center; font-size:20px;'> <a href='#' style='background-color: #20B2AA; color: white; padding: 10px 30px; text-decoration: none;text-align:right;direction:rtl;color:White; font-weight: 700;' > " + code + @": رمز التحقق هو </a> </div> </div>";

            mail.Body = Msg;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587; // 25 465
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("yhyyatlwbh@gmail.com", "rmom ahjg tyso arup");
            smtp.Send(mail);


            return code;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txt_Searsh.Text.Trim();

            // قم بتنفيذ استعلام البحث واسترداد النتائج
            DataTable searchResults = SearchInDatabase(searchQuery);

            // قم بتعيين النتائج كمصدر لبيانات Repeater وتعبئته
            myRepeater.DataSource = searchResults;
            myRepeater.DataBind();
        }

       

        private DataTable SearchInDatabase(string searchQuery)
        {
            // قم بتنفيذ استعلام البحث في قاعدة البيانات واسترداد النتائج
            // يمكنك استخدام استعلام SQL لتنفيذ البحث أو استخدام ORM مثل Entity Framework

            // على سبيل المثال، يمكنك استخدام استعلام SQL مثل التالي:

            string selectQuery = "SELECT * FROM Teachers WHERE Teacher_Fname LIKE @SearchQuery OR Teacher_Lname LIKE @SearchQuery ";

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


            string query_1 = "SELECT * from Teachers order by Teacher_id Asc";


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
                cmdRepeater = new SqlCommand("select COUNT(*) from Teachers", con);  //Count the total records
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

        public int GetRowCount()
        {
            int rowCount = 0;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string query = $"SELECT COUNT(*) FROM Teachers";
                SqlCommand command = new SqlCommand(query, con);

                rowCount = (int)command.ExecuteScalar();
            }

            return rowCount;
        }





    }
}