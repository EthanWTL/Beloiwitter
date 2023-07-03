using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    //对数据库的表实现增删改查
    //UserSerive是对user table的操作
    public class StudentService
    {
        public static bool registerStudent(Student studentInfo)
        {
            //执行插入sql
            string sql = string.Format("update student set password = '{0}', state = '{1}',create_time = '{2}' where email = '{3}'", studentInfo.password,studentInfo.state,studentInfo.create_time,studentInfo.email);
            //返沪结果
            return DBHelper.updateData(sql);
        }

        //增加数据： 添加user到user表
        public static bool addStudent(Student studentInfo)
        {
            //执行插入sql
            string sql = string.Format("insert into student (email, password,first_name,last_name,nick_name,user_avatar, introduce, state,create_time,class_taken) values ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", studentInfo.email,studentInfo.password,studentInfo.first_name,studentInfo.last_name,studentInfo.nick_name,studentInfo.user_avatar, studentInfo.introduce, studentInfo.state, studentInfo.create_time, studentInfo.class_taken);
            //返沪结果
            return DBHelper.updateData(sql);
        }

        //delete
        public static bool deleteStudent(int id)
        {
            //执行删除sql
            string sql = string.Format("delete from student where student_id = '{0}'", id);
            //返沪结果
            return DBHelper.updateData(sql);
        }

        //update
        public static bool updateStudent(Student studentInfo)
        {
            //执行插入sql
            string sql = string.Format("update student set email = '{0}', password = '{1}',first_name = '{2}',last_name = '{3}', nick_name  = '{4}',user_avatar = '{5}' , introduce = '{6}', state = '{7}'where student_id = '{8}'", studentInfo.email, studentInfo.password, studentInfo.first_name, studentInfo.last_name, studentInfo.nick_name, studentInfo.user_avatar, studentInfo.introduce, studentInfo.state, studentInfo.student_id);
            //返沪结果
            return DBHelper.updateData(sql);
        }


        public static Student getStudentState(string email)
        {
            //search sql
            string sql = string.Format("select state from student where email = '{0}'", email);
            //execute sql
            SqlDataReader dr = DBHelper.getData(sql);
            //save into data model
            Student studentInfo = null;
            if (dr.Read())
            {
                studentInfo = new Student();
                studentInfo.state = dr.GetInt32(0);

            }
            //close
            dr.Close();
            //return info
            return studentInfo;
        }
        //search
        public static Student getStudentInfo(string email)
        {
            //search sql
            string sql = string.Format("select * from student where email = '{0}'", email);
            //execute sql
            SqlDataReader dr =  DBHelper.getData(sql);
            //save into data model
            Student studentInfo = null;
            if (dr.Read())
            {
                studentInfo = new Student();
                studentInfo.student_id = dr.GetInt32(0);
                studentInfo.email = dr.GetString(1);
                studentInfo.password = dr.GetString(2);
                studentInfo.first_name = dr.GetString(3);
                studentInfo.last_name = dr.GetString(4);
                studentInfo.nick_name = dr.GetString(5);
                studentInfo.user_avatar = dr.GetString(6);
                studentInfo.introduce = dr.GetString(7);
                studentInfo.state = dr.GetInt32(8);

            }
            //close
            dr.Close();
            //return info
            return studentInfo;
        }
        public static Student getStudentEmail(string email)
        {
            //search sql
            string sql = string.Format("select * from student where email = '{0}'", email);
            //execute sql
            SqlDataReader dr = DBHelper.getData(sql);
            //save into data model
            Student studentInfo = null;
            if (dr.Read())
            {
                studentInfo = new Student();
                studentInfo.email = dr.GetString(1);
                studentInfo.state = dr.GetInt32(8);

            }
            //close
            dr.Close();
            //return info
            return studentInfo;
        }



        //search
        public static Student getCommentStudentInfo(int studentId)
        {
            //search sql
            string sql = string.Format("select nick_name, user_avatar from student where student_id = '{0}'", studentId);
            //execute sql
            SqlDataReader dr = DBHelper.getData(sql);
            //save into data model
            Student studentInfo = null;
            if (dr.Read())
            {
                studentInfo = new Student();

                studentInfo.nick_name = dr["nick_name"].ToString();
                studentInfo.user_avatar = dr["user_avatar"].ToString();


            }
            //close
            dr.Close();
            //return info
            return studentInfo;
        }
    }
}
