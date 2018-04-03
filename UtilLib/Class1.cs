using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilLib
{
    public class Util
    {
        public static String sqlCon = "Data Source=(local);Database=test3;Uid=sa;Pwd=123456";

        static public Boolean Login(String account, String password)
        {
            return false;
        }

        public static DataSet GetTableDataSet(String tableName, String Key, String Value)
        {
            string sqlstr = "select * from " + tableName.Trim() + " where " + Key.Trim() + " like '%" + Value.Trim() + "%'";
            return GetDataSet(sqlstr, tableName);
        }

        public static DataSet GetDataSet(String sqlstr, String tableName)
        {
            SqlConnection scn = new SqlConnection(sqlCon);
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, scn);
            DataSet myds = new DataSet();
            scn.Open();
            myda.Fill(myds, tableName);
            scn.Close();
            return myds;
        }

        public static Boolean Delete(String tableName, String Key, String Value)
        {
            String sqlstr = "delete from " + tableName.Trim() + " where " + Key.Trim() + " = '" + Value.Trim() + "'";
            SqlConnection sqlcon = new SqlConnection(sqlCon);
            SqlCommand sqlcom = new SqlCommand(sqlstr, sqlcon);
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
            return true;
        }

        public static void Update(Dictionary<String,String> dic, String tableName, String Key, String Value)
        {
            string sqlstr = "update " + tableName + " set ";
            foreach(KeyValuePair<String,String> kvp in dic)
            {
                sqlstr += kvp.Key.Trim() + "='" + kvp.Value.Trim() + "',";
            }
            sqlstr.Substring(0, sqlstr.Length - 1);
            sqlstr += " where " + Key.Trim() + "='" + Value.Trim() + "'";
            SqlConnection sqlcon = new SqlConnection(sqlCon);
            SqlCommand sqlcom = new SqlCommand(sqlstr, sqlcon);
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }

        public static DataSet GetTableDataSet(String tableName)
        {
            string sqlstr = "select * from "+tableName;
            return GetDataSet(sqlstr, tableName);
        }
    }


}
