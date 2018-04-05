using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;

namespace test3.Majors
{
    public partial class AddMajor : System.Web.UI.Page
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
        }

        protected void save_Click(object sender, EventArgs e)
        {
            String id = this.id.Text;
            String name = this.name.Text;
            String father_id = this.father_id.Value;
            
            if (id == "" || name == "" || father_id == "")
            {
                tip.Text = "输入栏不能有空";
                return;
            }

            if (Util.IsIdExist("Major",id))
            {
                tip.Text = "专业编号已存在";
                return;
            }

            if (Convert.ToInt32(father_id)!=0 && (father_id==id || !Util.IsIdExist("Major", father_id)))
            {
                tip.Text = "父专业编号不能为自己或找不到父专业的专业编号";
                return;
            }

            if (Util.IsNameExist("Major",name))
            {
                tip.Text = "专业名已存在";
                return;
            }

            count++;
            tip.Text = "成功添加" + count + "个专业";
            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic.Add("id", id);
            dic.Add("name", name);
            dic.Add("institute", instituteName);
            dic.Add("fid", father_id);
            Util.Insert("Major", dic);
            init();
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect(back_url);
        }
    }
}