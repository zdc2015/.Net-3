using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilLib;

namespace test3
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void confirm_Click(object sender, EventArgs e)
        {
            String name = this.userId.Text;
            String password = this.password.Text;
            if (Util.Login(name, password)){
               
            }
            else
            {
                Response.Write("<script   language='javascript'>alert('账号或密码错误');</script>");
            }
            
        }
    }
}