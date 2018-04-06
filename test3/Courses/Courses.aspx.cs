using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;

namespace test3.Courses
{
    public partial class Courses : System.Web.UI.Page
    {
        public static String[] selectTypeText = { "编号", "名字", "部门" };
        public static String[] selectTypeValue = { "id", "name", "department" };
        public static Dictionary<String, String> dic = new Dictionary<string, string>();
        //编辑之前的值
        public static String id = "";
        public static String ins = "";
        public static String old_name = "";
        public static String instituteName = "";
        //查询数据
        public static String value = "";
        public static String key = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["name"] != null)
                    instituteName = Request.QueryString["name"];
                Databind();
                seltypeBind();
            }
        }

        protected void seltypeBind()
        {
            select_type.Items.Clear();
            for (int i = 0; i < selectTypeText.Length; i++)
            {
                select_type.Items.Insert(i, new ListItem(selectTypeText[i], selectTypeValue[i]));
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Databind();
        }

        public void Databind()
        {
            DataSet ds = null;
            if (key != "")
            {
                dic.Clear();
                dic.Add("institute", instituteName);
                dic.Add(key, value);
                ds = Util.GetTableDataSet("Course",dic);
            }
            else
            {
                dic.Clear();
                dic.Add("institute", instituteName);
                ds = Util.GetTableDataSet("Course",dic);
            }
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void view_part_Click(object sender, EventArgs e)
        {
            key = select_type.SelectedItem.Value;
            value = textkey.Text;
            Databind();
        }

        protected void view_all_Click(object sender, EventArgs e)
        {
            key = "";
            Databind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = ((Label)this.GridView1.Rows[e.RowIndex].FindControl("lid")).Text;
            Util.Delete("Course", "id", id);
            Databind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridViewRow row = GridView1.Rows[e.NewEditIndex];
            id = ((Label)row.FindControl("lid")).Text;
            ins = ((Label)row.FindControl("lins")).Text;
            old_name = ((Label)row.FindControl("lname")).Text;
            Databind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Databind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];

            String name = ((TextBox)row.FindControl("tname")).Text;
            String department = ((TextBox)row.FindControl("tdepartment")).Text;
            String institute = ((DropDownList)row.FindControl("dins")).SelectedItem.Text;
            String credit = ((TextBox)row.FindControl("tcredit")).Text;

            if (name == "" || name == "" || department == "" || credit=="")
            {
                Response.Write("<script   language='javascript'>alert('输入栏不能有空');</script>");
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

            if (name!=old_name && Util.IsNameExist("Course", name))
            {
                Response.Write("<script   language='javascript'>alert('课程名已存在');</script>");
                return;
            }

            if (name != old_name)
            {
                Dictionary<String, String> dicc = new Dictionary<string, string>();
                dicc.Add("course_name", name);
                Util.Update(dicc, "Grade", "course_name", old_name);
            }

            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic.Add("name", name);
            dic.Add("id", id);
            dic.Add("institute", institute);
            dic.Add("department", department);
            dic.Add("credit", "" + real);


            Util.Update(dic, "Course", "id", id);
            GridView1.EditIndex = -1;
            Databind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList ddl = ((DropDownList)e.Row.FindControl("dins"));
            if (ddl != null)
            {
                ListItem li = ddl.Items.FindByText(ins);
                if (li != null)
                {
                    li.Selected = true;
                }
            }
        }

        protected void AddStudent_Click(object sender, EventArgs e)
        {
            Session["url"] = Request.RawUrl;
            Session["name"] = instituteName;
            Response.Redirect("AddCourse.aspx");
        }

        protected void AddCourse_Click(object sender, EventArgs e)
        {
            AddStudent_Click( sender,  e);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "view_grade")
            {
                Session["url"] = Request.RawUrl;
                Session["name"] = ((Label)this.GridView1.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lname")).Text;
                Response.Redirect("/Grades/ViewGrades.aspx");
            }
        }
    }
}