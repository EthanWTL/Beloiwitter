using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ShowClassService
    {
        public static List<ShowClass> getClassList(int student_id)
        {  
            string sql = string.Format("select c.course_code, c.course_id,s.student_id from sc s left join course c on s.course_id = c.course_id where student_id = '{0}'", student_id);
            //execute sql
            SqlDataReader dr = DBHelper.getData(sql);
            //save into data model
            ShowClass classInfo = null;
            List<ShowClass> classList = new List<ShowClass>();

            while (dr.Read())
            {
                classInfo = new ShowClass();
                classInfo.course_code = dr.GetString(0);
                classInfo.course_id = dr.GetInt32(1);
                classInfo.student_id = dr.GetInt32(2);
                classList.Add(classInfo);
            }
            dr.Close();
            //return info
            return classList;
        }
    }
}
