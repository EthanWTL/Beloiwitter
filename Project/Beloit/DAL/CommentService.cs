using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CommentService
    {
        public static bool addComment(Comment commentInfo)
        {
            //执行插入sql
            string sql = string.Format("insert into comment (student_id, course_id,title,img,comment_text,course_rate, time) values ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}')", commentInfo.student_id, commentInfo.course_id, commentInfo.title, commentInfo.img, commentInfo.comment_text, commentInfo.course_rate, commentInfo.time);
            //返沪结果
            return DBHelper.updateData(sql);
        }
        public static bool deleteComment(int id)
        {
            //执行删除sql
            string sql = string.Format("delete from comment where comment_id = '{0}'", id);
            //返沪结果
            return DBHelper.updateData(sql);
        }

        //get comment and news list
        public static List<Comment> getCommentList(int userId,bool boolType = true)
        {
            //if true, return all the comments
            string sql = string.Format("select * from comment where student_id = '{0}'", userId);
            //search sql
            if (!boolType)
            {
                //if false, only top five got send back
                sql = string.Format("select top 5 * from comment where student_id = '{0}' order by time desc", userId);
            }

            //execute sql
            SqlDataReader dr = DBHelper.getData(sql);
            //save into data model
            Comment commentInfo = null;
            List<Comment> commentList = new List<Comment>();

            while (dr.Read())
            {
                commentInfo = new Comment();
                commentInfo.comment_id = dr.GetInt32(0);
                commentInfo.student_id = dr.GetInt32(1);
                commentInfo.course_id = dr.GetInt32(2);
                commentInfo.title = dr.GetString(3);
                commentInfo.img = dr.GetString(4);
                commentInfo.comment_text = dr.GetString(5);
                commentInfo.course_rate = dr.GetInt32(6);
                commentInfo.time = dr.GetDateTime(7);
                commentList.Add(commentInfo);

            }
            dr.Close();
            //return info
            return commentList;
        }

        //get index page comments list 
        public static List<ShowComment> getIndexCommentList(int pageNum, int pageSize)
        {
            //split page: page number, comment number each page
            int offsetNum = (pageNum - 1) * pageSize;
            string sql = string.Format("select c.comment_id,c.title, c.time, c.img, s.user_avatar, s.nick_name, course.time_offered, p.first_name, p.last_name, course.course_code from comment c left join student s on c.student_id = s.student_id left join course on course.course_id = c.course_id left join professor p on p.professor_id = course.professor_id order by time desc offset {0} rows fetch next {1} rows only", offsetNum, pageSize);

            //execute sql
            SqlDataReader dr = DBHelper.getData(sql);
            //save into data model
            ShowComment commentInfo = null;
            List<ShowComment> commentList = new List<ShowComment>();

            while (dr.Read())
            {
                commentInfo = new ShowComment();
                commentInfo.comment_id = dr.GetInt32(0);
                commentInfo.title = dr.GetString(1);
                commentInfo.time = dr.GetDateTime(2);
                commentInfo.img = dr.GetString(3);
                commentInfo.user_avatar = dr.GetString(4);
                commentInfo.nick_name = dr.GetString(5);
                commentInfo.time_offered = dr.GetString(6);
                commentInfo.professor_name = dr.GetString(7) + " " + dr.GetString(8);
                commentInfo.course_code = dr.GetString(9);
                commentList.Add(commentInfo);

            }
            dr.Close();
            //return info
            return commentList;
        }

        public static Comment getCommentDetail(int commentId)
        {
            //queary sql, get the details about a comment 
            string sql = string.Format("select * from comment where comment_id = '{0}'", commentId);

            //get comment back
            SqlDataReader dr = DBHelper.getData(sql);
            Comment detail = null;
            if (dr.Read())
            {
                detail = new Comment();
                detail.comment_id = int.Parse(dr["comment_id"].ToString());
                detail.title = dr["title"].ToString();
                detail.comment_text = dr["comment_text"].ToString();
                detail.student_id = int.Parse(dr["student_id"].ToString());
                detail.time = DateTime.Parse(dr["time"].ToString());
                detail.img = dr["img"].ToString();
                //maybe course_id

            }
            dr.Close();
            return detail;

        }

        public static ShowComment getCommentMiniTitle(int commentId)
        {
            //queary sql, get the details about a comment 
            string sql = string.Format("select c.comment_id,c.title, c.time, c.img, s.user_avatar, s.nick_name, b.time_offered, p.first_name, p.last_name, b.course_code, d.department_name from Beloit.dbo.comment c left join Beloit.dbo.student s on c.student_id = s.student_id left join Beloit.dbo.course b on b.course_id = c.course_id left join professor p on p.professor_id = b.professor_id left join course_information on course_information.course_code = b.course_code left join department d on d.department_id = course_information.department_id where comment_id = '{0}'", commentId);

            //get comment back
            SqlDataReader dr = DBHelper.getData(sql);
            ShowComment detail = null;
            if (dr.Read())
            {
                detail = new ShowComment();
                detail.course_code = dr["course_code"].ToString();
                detail.professor_name = dr["first_name"].ToString() + dr["last_name"].ToString();
                detail.time_offered = dr["time_offered"].ToString();

            }
            dr.Close();
            return detail;

        }


        //get comment for search page
        public static List<ShowComment> getSearchCommentList(string courseCode,string prof_name,string timeOffered,string department)
        {

            string cCode = "";
            string pName = "";
            string cTime = "";
            string cDepart = "";

            if (courseCode != string.Empty)
            {
                cCode = "and b.course_code = '{0}'";
            }

            if (prof_name != string.Empty)
            {
                pName = "and p.first_name = '{1}'";
            }

            if (timeOffered != string.Empty)
            {
                cTime = "and b.time_offered = '{2}'";
            }
            if (department != string.Empty)
            {
                cDepart = "and d.department_name = '{3}'";
            }

            string sql = string.Format("select c.comment_id,c.title, c.time, c.img, s.user_avatar, s.nick_name, b.time_offered, p.first_name, p.last_name, b.course_code, d.department_name from Beloit.dbo.comment c left join Beloit.dbo.student s on c.student_id = s.student_id left join Beloit.dbo.course b on b.course_id = c.course_id left join professor p on p.professor_id = b.professor_id left join course_information on course_information.course_code = b.course_code left join department d on d.department_id = course_information.department_id where 1=1" + cCode+pName+cTime+cDepart+"order by time desc", courseCode,prof_name,timeOffered,department);


            //execute sql
            SqlDataReader dr = DBHelper.getData(sql);
            //save into data model
            ShowComment commentInfo = null;
            List<ShowComment> commentList = new List<ShowComment>();

            while (dr.Read())
            {
                commentInfo = new ShowComment();
                commentInfo.comment_id = dr.GetInt32(0);
                commentInfo.title = dr.GetString(1);
                commentInfo.time = dr.GetDateTime(2);
                commentInfo.img = dr.GetString(3);
                commentInfo.user_avatar = dr.GetString(4);
                commentInfo.nick_name = dr.GetString(5);
                commentInfo.time_offered = dr.GetString(6);
                commentInfo.professor_name = dr.GetString(7) + " " + dr.GetString(8);
                commentInfo.course_code = dr.GetString(9);
                commentInfo.department_name = dr.GetString(10);
                commentList.Add(commentInfo);

            }
            dr.Close();
            //return info
            return commentList;
        }

    }
}
