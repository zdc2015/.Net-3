using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;

namespace test3
{
    public partial class manageStudent : System.Web.UI.Page
    {
        public static String[] selectTypeText = {"学号", "姓名", "学院", "年级","班级" ,"专业"};
        public static String[] selectTypeValue = { "id", "name", "institute", "grade", "class", "major" };

        public static String id = ""; 
        public static String ins = "";
        public static String value = "";
        public static String key = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Databind();
                seltypeBind();
            }
        }

        protected void seltypeBind()
        {
            select_type.Items.Clear();
            for(int i = 0; i < selectTypeText.Length; i++)
            {
                select_type.Items.Insert(i, new ListItem(selectTypeText[i],selectTypeValue[i]));
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
                ds = Util.GetTableDataSet("Student",key,value);
            }
            else
            {
                ds = Util.GetTableDataSet("Student");
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
            String id = ((Label)this.GridView1.Rows[e.RowIndex].FindControl("Label1")).Text;
            Util.Delete("Student", "id", id);
            Databind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridViewRow row = GridView1.Rows[e.NewEditIndex];
            id = ((Label)row.FindControl("lid")).Text;
            ins = ((Label)row.FindControl("lins")).Text;
            String maj = ((Label)row.FindControl("lmajor")).Text;
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
            String _class = ((TextBox)row.FindControl("tclass")).Text;
            String grade = ((TextBox)row.FindControl("tgrade")).Text;
            String major = ((DropDownList)row.FindControl("dmajor")).SelectedItem.Text;
            String institute = ((DropDownList)row.FindControl("dins")).SelectedItem.Text;
            String phone = ((TextBox)row.FindControl("tphone")).Text;

            if (name == "" || _class == "" || grade == "" || phone == "")
            {
                Response.Write("<script   language='javascript'>alert('输入栏不能有空');</script>");
                return;
            }

            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic.Add("name", name);
            dic.Add("class", _class);
            dic.Add("grade", grade);
            dic.Add("major", major);
            dic.Add("institute", institute);
            dic.Add("phone", phone);

            Util.Update(dic, "Student", "id", id);
            GridView1.EditIndex = -1;
            Databind();
        }

        protected void dins_TextChanged(object sender, EventArgs e)
        {
            DropDownList majorList = ((DropDownList)this.GridView1.Rows[GridView1.EditIndex].FindControl("dmajor"));
            DropDownList instList = ((DropDownList)this.GridView1.Rows[GridView1.EditIndex].FindControl("dins"));

            majorList.ClearSelection();
            String value = instList.SelectedValue;


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
    }
}