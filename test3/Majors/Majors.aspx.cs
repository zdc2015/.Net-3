using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;

namespace test3.Majors
{
    public partial class Majors : System.Web.UI.Page
    {
        class T
        {
            public int num { set; get; }
            public String id { set; get; }
            public String name { set; get; }
            public String father_id { set; get; }
            public String institute { set; get; }
        }

        public static String id = "";
        public static String ins = "";
        public static String old_father_id = "";
        public static String old_name = "";
        public static String institute;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["name"] != null)
                {
                    institute = Request.QueryString["name"];
                    Databind();
                }
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
            ds = Util.GetTableDataSet("Major", "institute", institute);
            List<T> list = new List<T>();
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                T t = new T
                {
                    name = row["name"].ToString(),
                    id = row["id"].ToString(),
                    father_id = row["fid"].ToString(),
                    institute = row["institute"].ToString(),
                    num = Util.GetStudentNumOfMajor(row["name"].ToString()),
                };
                list.Add(t);
            }
            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int num = Convert.ToInt32(((Label)this.GridView1.Rows[e.RowIndex].FindControl("stuNum")).Text);
            if (num == 0)
            {
                String id = ((Label)this.GridView1.Rows[e.RowIndex].FindControl("lid")).Text;
                Util.Delete("Major", "id", id);
                Databind();
            }
            else
            {
                Response.Write("<script   language='javascript'>alert('当前专业有学生，无法删除');</script>");
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridViewRow row = GridView1.Rows[e.NewEditIndex];
            id = ((Label)row.FindControl("lid")).Text;
            ins = ((Label)row.FindControl("lins")).Text;
            old_name = ((Label)row.FindControl("lname")).Text;
            old_father_id = ((Label)row.FindControl("lfather_id")).Text;
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

            String new_id = ((TextBox)row.FindControl("tid")).Text;
            String new_name = ((TextBox)row.FindControl("tname")).Text;
            String new_institute = ((DropDownList)row.FindControl("dins")).SelectedItem.Text;
            String new_father_id = ((TextBox)row.FindControl("tfather_id")).Text;

            if (new_id == "" || new_name == "" || new_institute == "" || new_father_id == "")
            {
                Response.Write("<script   language='javascript'>alert('输入栏不能有空');</script>");
                return;
            }

            if (id!=new_id && Util.IsIdExist("Major",new_id))
            {
                Response.Write("<script   language='javascript'>alert('id已存在');</script>");
                return;
            }

            if (Convert.ToInt32(new_father_id)!=0 &&  !Util.IsIdExist("Major", new_father_id))
            {
                Response.Write("<script   language='javascript'>alert('父专业Id不存在');</script>");
                return;
            }

            Dictionary<String, String> dic = new Dictionary<string, string>();

            if (old_name != new_name || ins!=new_institute)
            {
                dic.Add("major", new_name);
                dic.Add("institute", new_institute);
                Util.Update(dic, "Student", "major", old_name);
                dic.Clear();
            }

            if (id != new_id)
            {
                dic.Add("fid", new_id);
                Util.Update(dic, "Major", "fid", id);
                dic.Clear();
            }

            dic.Add("name", new_name);
            dic.Add("id", new_id);
            dic.Add("institute", new_institute);
            dic.Add("fid", new_father_id);

            Util.Update(dic, "Major", "id", id);
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

        protected void AddMajor_Click(object sender, EventArgs e)
        {
            Session["url"] = Request.RawUrl;
            Session["name"] = institute;
            Response.Redirect("/AddMajor.aspx");
        }
    }
}