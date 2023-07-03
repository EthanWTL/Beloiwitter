using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Beloit
{
    public partial class comments : System.Web.UI.Page
    {
        //initialize start up data
        protected void Page_Load(object sender, EventArgs e)
        {


            detailNews();

            //check if the query was right or not (with or without comment_id)
           


            //get user information
            Student userInfo = Session["userInfo"] as Student;
            //check if already exist
            if (userInfo == null)
            {
                return;
            }
            Label nick = this.Master.FindControl("nick") as Label;
            nick.Text = userInfo.nick_name;
            //icon for current logged in user
            this.userImg.ImageUrl = userInfo.user_avatar;

        }

        private void detailNews()
        {
            if (!Request.QueryString.HasKeys())
            {
                Response.Redirect("~/index.aspx");

            }
            //use id and get comment details
            int id = int.Parse(Request.QueryString["id"]);
            Comment detail = CommentManager.getCommentDetail(id);
            //check if the comment is empty
            if (detail == null)
            {
                Response.Redirect("~/index.aspx");

            }

            ShowComment titleDetail = CommentManager.getCommentTitleDetail(id);

            this.title.Text = detail.title;
            this.titlemini.Text = detail.time.ToString();

            this.comment_text.Text = detail.comment_text;
            this.detailImg.ImageUrl = detail.img;

            //comment detail header
            Page.Header.Title = detail.title;

            //get right side box with user news
            getCommentUserInfo(detail.student_id);

            //get comment's discussion list base on comment _id
            getCommetDiscussionList(detail.comment_id);
        }

        private void getCommetDiscussionList(int id)
        {
            this.discussList.DataSource = DiscussManager.getDiscussList(id);
            this.discussList.DataBind();
        }

        private void getCommentUserInfo(int student_id)
        {
            //user comment list
            List<Comment> commList = CommentManager.getUserSendCommentList(student_id);
            //user info 
            Student studentInfo = StudentManager.getCommentStudentInfo(student_id);

            if (commList == null)
            {
                return;
            }
            this.sendList.DataSource = commList;
            this.sendList.DataBind();
            if (studentInfo == null)
            {
                return;
            }
            this.userImage.ImageUrl = studentInfo.user_avatar;
            this.nickName.Text = this.usersName.Text = studentInfo.nick_name;
        }

        //click to send discussion
        protected void sendDiscuss (object sender, EventArgs e)
        {
            //check if logged in!
            Student userInfo = Session["userInfo"] as Student;
            if(userInfo == null)
            {
                Response.Write("<script>alert('please log in first')</script>");
                return;
            }
            //get discussion box detail
            string discuss = this.commentSay.Text;
            if (discuss == string.Empty)
            {
                Response.Write("<script>alert('please leave a comment first')</script>");
                return;
            }
            //prepare a discuss model 
            Discuss discussInfo = new Discuss();
            discussInfo.discuss = discuss;
            discussInfo.student_id = userInfo.student_id;
            discussInfo.time = DateTime.Now;
            discussInfo.comment_id = int.Parse(Request.QueryString["id"]);

            //execute save action
            if (DiscussManager.saveDiscuss(discussInfo))
            {
                Response.Write("<script>alert('leave discussion succeed')</script>");
                Response.Redirect("comments.aspx?id=" + int.Parse(Request.QueryString["id"]));
            }
            else
            {
                Response.Write("<script>alert('Discuss failed')</script>");
            }

        }
    }
}