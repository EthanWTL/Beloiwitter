using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Course_informationService
    {

        public static bool addCourse_information(Course_information courseInfo)
        {
            //执行插入sql
            string sql = string.Format("insert into course_information (department_id,course_time,course_introduction) values ('{0}', '{1}','{2}')", courseInfo.department_id, courseInfo.course_name, courseInfo.course_introduction);
            //返沪结果
            return DBHelper.updateData(sql);
        }

        public static bool deleteCourse_information(string courseCode)
        {
            //执行删除sql
            string sql = string.Format("delete from course_information where course_code = '{0}'", courseCode);
            //返沪结果
            return DBHelper.updateData(sql);
        }


        public static bool updateCourse_information(Course_information courseInfo)
        {
            //执行插入sql
            string sql = string.Format("update course_information set department_id = '{0}', course_name = '{1}',course_introduction = '{2}' where course_code = '{3}'", courseInfo.department_id, courseInfo.course_name, courseInfo.course_introduction, courseInfo.course_code);
            //返沪结果
            return DBHelper.updateData(sql);
        }

        public static Course_information getCourse_information(string courseCode)
        {
            //search sql
            string sql = string.Format("select * from course where course_code = '{0}'", courseCode);
            //execute sql
            SqlDataReader dr = DBHelper.getData(sql);
            //save into data model
            Course_information courseInfo = null;
            if (dr.Read())
            {
                courseInfo = new Course_information();
                courseInfo.course_code = dr.GetString(0);
                courseInfo.department_id = dr.GetInt32(1);
                courseInfo.course_name = dr.GetString(2);
                courseInfo.course_introduction = dr.GetString(3);
            }
            //return info
            return courseInfo;
        }
    }
}
