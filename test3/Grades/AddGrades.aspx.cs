using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;

namespace test3.Grades
{
    public partial class AddGrades : System.Web.UI.Page
    {
        static String back_url = "";
        static String course_name = "";
        static String course_id = "";
        static int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["url"] != null)
                    back_url = Session["url"].ToString();
                if (Session["name"] != null)
                    course_name = Session["name"].ToString();

                this.name.Text = course_name;

                DataSet ds = Util.GetTableDataSet("Course", "name", course_name);
                course_id = ds.Tables[0].Rows[0]["id"].ToString();
                init();
            }
        }

        void init()
        {
            tip.Text = "\t";
            student_id.Text = "";
            score.Text = "";
        }

        protected void save_Click(object sender, EventArgs e)
        {
            String student_id = this.student_id.Text;
            String score = this.score.Text;
            String id = student_id + course_id;

            if(student_id=="" || score == "")
            {
                tip.Text = "输入栏不能为空";
                return;
            }

            if (!Util.IsIdExist("Student", student_id))
            {
                tip.Text = "学号不存在";
                return;
            }

            if (Util.IsIdExist("Grade", id))
            {
                tip.Text = "该学生成绩已存在";
                return;
            }

            int a;
            try
            {
                a = Convert.ToInt32(score);
            }
            catch
            {
                tip.Text = "成绩无效";
                return;
            }

            if (a > 100 || a < 0)
            {
                tip.Text = "成绩无效";
                return;
            }

            count++;
            tip.Text = "成功录入" + count + "个成绩";
            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic.Add("id", id);
            dic.Add("student_id", student_id);
            dic.Add("student_name", Util.GetTableDataSet("Student","id",student_id).Tables[0].Rows[0]["name"].ToString());

            dic.Add("course_id", course_id);
            dic.Add("course_name",course_name);
            dic.Add("score",""+a);
            dic.Add("credit", Util.GetTableDataSet("Course", "id", course_id).Tables[0].Rows[0]["credit"].ToString());
            Util.Insert("Grade", dic);
            init();
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect(back_url);
        }
    }
}