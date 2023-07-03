using System;
using Model;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    //对student表的逻辑功能实现
    public class StudentManager
    {
        //实现注册功能
        public static bool registerStudent(string email, string password)
        {

            //执行注册时判断email是否存在
            Student Info = StudentService.getStudentEmail(email);
            //!= null user exist return false
            if (Info.state == 1)
            {
                return false;
            }


            //拼凑一个用户模型给数据访问层
            Student studentInfo = new Student();
            studentInfo.email = email;
            studentInfo.password = password;
            studentInfo.state = 1;
            studentInfo.create_time = DateTime.Now;

            //执行数据访问层，保存用户信息
            return StudentService.registerStudent(studentInfo);
        }

        //login check
        public static Student checkStudent(string userName, string password)
        {
            //check is user exist
            Student Info = StudentService.getStudentState(userName);
            Student studentInfo = null;
            if(Info == null)
            {
                return null;
            }
            else
            {
                if (Info.state == 0)
                {
                    return null;
                }
                else if (Info.state == 1)
                {
                    studentInfo = StudentService.getStudentInfo(userName);
                    if (studentInfo != null && studentInfo.password != password)
                    {
                        return null;
                    }
                }
            }

            
            return studentInfo;
        }

        //info edit
        public static bool updateStudent(Student studentInfo)
        {
            return StudentService.updateStudent(studentInfo);
        }

        public static Student getCommentStudentInfo(int user_id)
        {
            return StudentService.getCommentStudentInfo(user_id);
        }
    }
}
