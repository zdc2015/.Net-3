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
    public partial class ViewGrades : System.Web.UI.Page
    {
        public static String[] selectTypeText = { "学号", "姓名","班级"};
        public static String[] selectTypeValue = { "student_id", "student_name", "student_id" };
        public static Dictionary<String, String> dic = new Dictionary<string, string>();
        //编辑之前的值
        public static String id = "";
        public static String ins = "";
        public static String course_name = "";
        //查询数据
        public static String value = "";
        public static String key = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["name"] != null)
                    course_name = Session["name"].ToString();
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
            dic.Clear();
            dic.Add("course_name", course_name);
            if(key!="")
                dic.Add(key, value);
            DataSet ds = Util.GetTableDataSet("Grade", dic);
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
            value = "";
            Databind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = ((Label)this.GridView1.Rows[e.RowIndex].FindControl("lid")).Text;
            Util.Delete("Grade", "id", id);
            Databind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridViewRow row = GridView1.Rows[e.NewEditIndex];
            id = ((Label)row.FindControl("lid")).Text;
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
            String score = ((TextBox)row.FindControl("tscore")).Text;

            if (score == "")
            {
                Response.Write("<script   language='javascript'>alert('成绩不能为空');</script>");
                return;
            }

            int a;
            try
            {
                a = Convert.ToInt32(score);
            }
            catch
            {
                Response.Write("<script   language='javascript'>alert('成绩无效');</script>");
                return;
            }

            if(a>100 || a < 0)
            {
                Response.Write("<script   language='javascript'>alert('成绩无效');</script>");
                return;
            }

            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic.Add("score", a+"");

            Util.Update(dic, "Grade", "id", id);
            GridView1.EditIndex = -1;
            Databind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void enter_Click(object sender, EventArgs e)
        {
            Session["url"] = Request.RawUrl;
            Session["name"] = course_name;
            Response.Redirect("AddGrades.aspx");
        }
    }
}