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
    public partial class Groups : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                add_Hall.Visible = false;
                Edit_Hall.Visible = false;

                Fill_Repeater_Halls();
            }
        }

        protected void btn_X_Click(object sender, EventArgs e)
        {
            add_Hall.Visible = false;
        }

        protected void btn_Show_Hall_Click(object sender, EventArgs e)
        {
            
            add_Hall.Visible = true;

        }

        protected void btn_add_Hall_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (IsHallExists(txt_name_Hall.Text.Trim()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "dfdf", "swal('خطأ', 'بالفعل توجد قاعه بهذا الاسم   !', 'warning');", true);

                }
                else
                {
                    AddHall(txt_name_Hall.Text.Trim());
                    txt_name_Hall.Text = "";
                    add_Hall.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "dfdf", "swal('نجاح', 'تم اضافة القاعة بنجاح!', 'success');", true);
                    Fill_Repeater_Halls();
                    add_Hall.Visible = false;

                }

            }
        }

        public void AddHall(string hallName)
        {
            // استعلام لإضافة قاعة جديدة
            string query = $"INSERT INTO Halls (Hall_name) VALUES ('{hallName}')";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool IsHallExists(string hallName)
        {
            // استعلام للتحقق من وجود القاعة
            string query = $"SELECT COUNT(*) FROM Halls WHERE Hall_name = '{hallName}'";

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
        public void Fill_Repeater_Halls()
        {
            // استعلام لجلب بيانات القاعات
            string query = "SELECT * FROM Halls";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    // تعبئة عنصر Repeater من بيانات القاعات
                    Repeater_Hall.DataSource = reader;
                    Repeater_Hall.DataBind();
                }
            }
        }

        public void SearchAndBindHallsToRepeater(Repeater repeater, string searchTerm)
        {
            // استعلام للبحث عن القاعات
            string query = $"SELECT * FROM Halls WHERE Hall_name LIKE '%{searchTerm}%'";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    // تعبئة عنصر Repeater من بيانات القاعات المفلترة
                    repeater.DataSource = reader;
                    repeater.DataBind();
                }
            }
        }

        public void UpdateHall(string hallId, string newHallName)
        {
            // استعلام لتحديث بيانات القاعة
            string query = $"UPDATE Halls SET Hall_name = '{newHallName}' WHERE Hall_id = {hallId}";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SearchAndBindHallsToRepeater(Repeater_Hall,txt_Searsh.Text.Trim());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Edit_Hall.Visible = false;
        }

        protected void Repeater_Hall_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
            if (e.CommandName == "Edit")
            {
                Edit_Hall.Visible = true;
                int index = e.Item.ItemIndex;
                Label Hall_name = (Label)e.Item.FindControl("Label1");
                Label Hall_id = (Label)e.Item.FindControl("Label2");
                txt_Edit_nameHall.Text = Hall_name.Text;
                txt_edit_id.Text = Hall_id.Text;

            }
            if (e.CommandName == "delete")
            {
                try
                {
                    int index = e.Item.ItemIndex;
                    Label Hall_id = (Label)e.Item.FindControl("Label2");
                    DeleteHall(Hall_id.Text);
                    Fill_Repeater_Halls();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "dfdf", "swal('نجاح', 'تم الحذف بنجاح!', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "dfdf", "swal('لا يمكن الحذف !', 'warning');", true);

                }

            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (IsHallExists(txt_Edit_nameHall.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "dfdf", "swal('خطأ', 'بالفعل توجد قاعه بهذا الاسم   !', 'warning');", true);

            }
            else
            {
                UpdateHall(txt_edit_id.Text, txt_Edit_nameHall.Text);
                Fill_Repeater_Halls();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "dfdf", "swal('نجاح', 'تم تعديل اسم القاعة بنجاح!', 'success');", true);
                Edit_Hall.Visible = false;
            }
        }

        public void DeleteHall(string hallId)
        {
            // استعلام لحذف القاعة
            string query = $"DELETE FROM Halls WHERE Hall_id = {hallId}";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}