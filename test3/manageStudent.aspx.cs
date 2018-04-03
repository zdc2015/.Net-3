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
            
        }


    }
}