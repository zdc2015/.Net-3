using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;

namespace test3.Institutes
{
    public partial class AlterDetail : System.Web.UI.Page
    {
        public static String back_url = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["name"] != null)
                {
                    this.name.Text = Session["name"].ToString();
                    DataSet ds = Util.GetTableDataSet("Institute", "name", this.name.Text);
                    intro.Text = ds.Tables[0].Rows[0]["introduction"].ToString();
                    leader.Text = ds.Tables[0].Rows[0]["dean"].ToString();
                }
                back_url = Session["url"].ToString();
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            String introduction = intro.Text;
            String name = this.name.Text;
            String dean = this.leader.Text;

            if(dean==""|| introduction == "")
            {
                this.tip.Text = "输入栏不能有空";
            }

            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic.Add("introduction", intro.Text);
            dic.Add("dean", dean);
            Util.Update(dic, "Institute", "name", name);
            Response.Write("<script   language='javascript'>alert('修改成功');</script>");
            Response.Redirect(back_url);
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect(back_url);
        }
    }
}