using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;

namespace test3
{
    public partial class AddStudent : System.Web.UI.Page
    {
        public static int count = 0;
        public static String back_url = "welcome.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if(Session["url"]!=null)
                back_url = Session["url"].ToString();
                init();
                tip.Text = " \t ";
            }
        }

        protected void init()
        {
            male.Checked = true;
            id.Text = "";
            name.Text = "";
            phone.Text = "";
            birthday.Value = "";
            dins.ClearSelection();

            DataSet ds = Util.GetTableDataSet("Major", "institute", dins.SelectedItem.Text);
            dmajor.Items.Clear();
            dmajor.DataSource = ds.Tables["Major"].DefaultView;
            dmajor.DataTextField = "name";
            dmajor.DataBind();
        }

        protected void save_Click(object sender, EventArgs e)
        {
            String id = this.id.Text;
            String name = this.name.Text;
            String phone = this.phone.Text;
            String date = this.birthday.Value;
            String gender = null;

            if (male.Checked)
            {
                gender = "男";
            }
            if (female.Checked)
            {
                gender = "女";
            }

            if (id == "" || name == "" || phone == "" || date == "")
            {
                tip.Text = "输入栏不能有空(包括出生日期)";
                return;
            }

            if (Util.IsStudentExist(id))
            {
                tip.Text = "学号已存在";
                return;
            }

            if (!Regex.IsMatch(id, @"\d{9}"))
            {
                tip.Text = "学号格式错误";
                return;
            }

            if (!Regex.IsMatch(phone, @"1\d{10}"))
            {
                tip.Text = "手机号格式错误";
                return;
            }
            count++;
            tip.Text = "成功添加"+count+"个学生";
            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic.Add("id", id);
            dic.Add("name", name);
            dic.Add("phone", phone);
            dic.Add("birthday", date);
            dic.Add("institute", dins.SelectedItem.Text);
            dic.Add("major", dmajor.SelectedItem.Text);
            dic.Add("gender", gender);
            dic.Add("grade", id.Substring(2, 2));
            dic.Add("class", id.Substring(0, 7));
            Util.Insert("Student", dic);
            init();
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect(back_url);
        }

        protected void dins_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = Util.GetTableDataSet("Major", "institute", dins.SelectedItem.Text);
            dmajor.Items.Clear();
            dmajor.DataSource = ds.Tables["Major"].DefaultView;
            dmajor.DataTextField = "name";
            dmajor.DataBind();
        }
    }
}