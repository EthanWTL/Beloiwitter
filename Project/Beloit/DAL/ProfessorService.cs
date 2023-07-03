using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class ProfessorService
    {
        public static bool addProfessor(Professor prof)
        {
            //执行插入sql
            string sql = string.Format("insert into professor (first_name, last_name) values ('{0}', '{1}‘)", prof.first_name,prof.last_name);
            //返沪结果
            return DBHelper.updateData(sql);
        }

        public static bool deleteProf(int id)
        {
            //执行删除sql
            string sql = string.Format("delete from professor where professor_id = '{0}'", id);
            //返沪结果
            return DBHelper.updateData(sql);
        }

        public static bool updateProfessor(Professor professorInfo)
        {
            //执行插入sql
            string sql = string.Format("update professor set first_name = '{0}',last_name = '{1}'  where professor_id = '{2}'", professorInfo.first_name, professorInfo.last_name, professorInfo.professor_id);
            //返沪结果
            return DBHelper.updateData(sql);
        }

        public static Professor getProfessor(int id)
        {
            //search sql
            string sql = string.Format("select * from professor where professor_id = '{0}'", id);
            //execute sql
            SqlDataReader dr = DBHelper.getData(sql);
            //save into data model
            Professor profInfo = null;
            if (dr.Read())
            {
                profInfo = new Professor();
                profInfo.professor_id = dr.GetInt32(0);
                profInfo.first_name = dr.GetString(1);
                profInfo.last_name = dr.GetString(2);
            }
            //return info
            return profInfo;
        }
    }
}
