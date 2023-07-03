using Model;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CourseService
    {
        public static List<Course> getCourseList(int userId)
        {
            //search sql
            string sql = string.Format("select * from course where student_id = '{0}'",userId);
            //execute sql
            SqlDataReader dr = DBHelper.getData(sql);
            //save into data model
            Course courseInfo = null;
            //course list
            List<Course> courseList = new List<Course>();
            if (dr.Read())
            {
                courseInfo = new Course();
                courseInfo.course_code = dr.GetString(0);
                courseInfo.professor_id = dr.GetInt32(1);
                courseInfo.average_rate = dr.GetInt32(2);
                courseInfo.course_id = dr.GetInt32(3);
                courseInfo.time_offered = dr.GetDateTime(4);
                courseList.Add(courseInfo);
            }
            dr.Close();
            //return info
            return courseList;
        }
    }
}
