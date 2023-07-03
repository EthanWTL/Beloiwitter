using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DepartmentService
    {
        public static bool addCourse_information(Department department)
        {
            //执行插入sql
            string sql = string.Format("insert into department (department_name) values ('{0}')", department.department_name);
            //返沪结果
            return DBHelper.updateData(sql);
        }

        public static bool deleteDepartment(int id)
        {
            //执行删除sql
            string sql = string.Format("delete from department where department_id = '{0}'", id);
            //返沪结果
            return DBHelper.updateData(sql);
        }

        public static bool updateDepartment(Department departmentInfo)
        {
            //执行插入sql
            string sql = string.Format("update department set department_name = '{0}'  where department_id = '{1}'", departmentInfo.department_name,departmentInfo.department_id);
            //返沪结果
            return DBHelper.updateData(sql);
        }

        public static Department getDepartment(int id)
        {
            //search sql
            string sql = string.Format("select * from department where department_id = '{0}'",id);
            //execute sql
            SqlDataReader dr = DBHelper.getData(sql);
            //save into data model
            Department departmentInfo = null;
            if (dr.Read())
            {
                departmentInfo = new Department();
                departmentInfo.department_id = dr.GetInt32(0);
                departmentInfo.department_name = dr.GetString(1);
            }
            //return info
            return departmentInfo;
        }
    }
}
