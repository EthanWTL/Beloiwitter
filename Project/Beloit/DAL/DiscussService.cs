using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DiscussService
    {
        //save comment
        public static bool saveDiscuss(Discuss discussInfo)
        {
            //save sql
            string sql = string.Format("insert into discuss (discuss, student_id, time, comment_id) values ('{0}','{1}','{2}','{3}')",discussInfo.discuss, discussInfo.student_id, discussInfo.time, discussInfo.comment_id);
            //execute sql 
            return DBHelper.updateData(sql);
        }

        //get discussion list for certain comment 
        public static List<Discuss> getDiscussList(int commentId)
        {
            //search sql
            string sql = string.Format("select d.*, s.nick_name, s.user_avatar from discuss d left join student s on d.student_id = s.student_id where d.comment_id = '{0}'", commentId);
            //execute sql
            SqlDataReader dr = DBHelper.getData(sql);
            //save into data model
            Discuss discussInfo = null;
            List<Discuss> disList = new List<Discuss>();

            while (dr.Read())
            {
                discussInfo = new Discuss();
                discussInfo.discuss_id = dr.GetInt32(0);
                discussInfo.discuss = dr["discuss"].ToString();
                discussInfo.student_id = int.Parse(dr["student_id"].ToString());
                discussInfo.time = DateTime.Parse(dr["time"].ToString());
                discussInfo.comment_id = int.Parse(dr["comment_id"].ToString());
                discussInfo.nick_name = dr["nick_name"].ToString();
                discussInfo.user_avatar = dr["user_avatar"].ToString();
                disList.Add(discussInfo);
            }
            dr.Close();
            //return info
            return disList;
        }
    }
}
