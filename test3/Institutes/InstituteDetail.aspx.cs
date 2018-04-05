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
    public partial class CsDetail : System.Web.UI.Page
    {
        public static String name = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            name = Request.QueryString["name"];
            DataSet ds = Util.GetTableDataSet("Institute", "name", name);
            this.introduction.Text = (String)ds.Tables[0].Rows[0]["introduction"];
            this.dean.Text = (String)ds.Tables[0].Rows[0]["dean"];
        }

        protected void alter_Click(object sender, EventArgs e)
        {
            Session["name"] = title.Text;
            Session["url"] = Request.RawUrl;
            Response.Redirect("AlterDetail.aspx");
        }
    }
}