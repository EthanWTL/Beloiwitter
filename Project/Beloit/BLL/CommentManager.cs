using System;
using System.Collections.Generic;
using DAL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class CommentManager
    {

        //get comments list
        public static List<Comment> getCommentList(int userId)
        {
            return CommentService.getCommentList(userId);
        }
        
        //get comment detail
        public static Comment getCommentDetail(int commentId)
        {
            return CommentService.getCommentDetail(commentId);
        }

        public static ShowComment getCommentTitleDetail(int commentId)
        {
            return CommentService.getCommentMiniTitle(commentId);
        }


        //get specific comment list by user
        public static List<Comment> getUserSendCommentList(int student_id)
        {
            return CommentService.getCommentList(student_id, false);
        }

        //get index comment list 
        public static List<ShowComment> getIndexCommentList(int pageNum, int pageSize)
        {
            return CommentService.getIndexCommentList(pageNum, pageSize);
        }

        public static List<ShowComment> getSearchCommentList(string courseCode, string prof_name, string timeOffered,string departName)
        {
            return CommentService.getSearchCommentList(courseCode,prof_name,timeOffered,departName);
        }


        //execute save comment into db
        public static bool addComment(Comment comment)
        {
            return CommentService.addComment(comment);
        }
    }
}
