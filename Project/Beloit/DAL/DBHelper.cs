using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DBHelper
    {
        //数据库连接配置字符串
        public static string connStr = "Data Source=.;Initial Catalog=Beloit;Integrated Security=True";
        //连接数据库对象
        public static SqlConnection conn = null;
        //连接数据库方法
        public static void Open()
        {
            //先判断当前是否已经创建连接对象
            if (conn == null)
            {
                conn = new SqlConnection(connStr);
            }
            //判断当前连接状态
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }

        }

        //对数据库执行增删改
        public static bool updateData(string sql)
        {
            //开启数据库
            Open();
            //数据库的方法
            SqlCommand cmd = new SqlCommand(sql,conn);
            //执行数据库增删改
            int result = cmd.ExecuteNonQuery();

            //返回结果
            return result > 0;
        }

        //对数据库执行查询
        public static SqlDataReader getData(string sql)
        {
            Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
