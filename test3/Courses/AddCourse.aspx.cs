using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;

namespace test3.Courses
{
    public partial class AddCourse : System.Web.UI.Page
    {
        public static int count = 0;
        public static String back_url = "welcome.aspx";
        public static String instituteName = "找不到学院";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["url"] != null)
                    back_url = Session["url"].ToString();
                if (Session["name"] != null)
                    instituteName = Session["name"].ToString();
                init();
                this.institute.Text = instituteName;
                tip.Text = " \t ";
            }
        }

        protected void init()
        {
            id.Text = "";
            name.Text = "";
            department.Value = "";
            credit.Text = "";
        }

        protected void save_Click(object sender, EventArgs e)
        {
            String id = this.id.Text;
            String name = this.name.Text;
            String department = this.department.Value;
            String credit = this.credit.Text;

            if (id == "" || name == "" || department == "")
            {
                tip.Text = "输入栏不能有空";
                return;
            }

            if (Util.IsIdExist("Course", id))
            {
                tip.Text = "课程编号已存在";
                return;
            }

            if (Util.IsNameExist("Course", name))
            {
                tip.Text = "专业名已存在";
                return;
            }

            double real;

            try
            {
                real = Convert.ToDouble(credit);
            }
            catch
            {
                Response.Write("<script   language='javascript'>alert('请输入正确的学分');</script>");
                return;
            }

            count++;
            tip.Text = "成功添加" + count + "个课程";
            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic.Add("id", id);
            dic.Add("name", name);
            dic.Add("institute", instituteName);
            dic.Add("department", department);
            dic.Add("credit", "" + real);
            Util.Insert("Course", dic);
            init();
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect(back_url);
        }
    }
}