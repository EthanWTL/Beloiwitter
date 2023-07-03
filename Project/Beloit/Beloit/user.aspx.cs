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
    public partial class user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get user information
            Student userInfo = Session["userInfo"] as Student;
            //check if already exist
            if (userInfo == null)
            {
                return;
            }
            this.userImage.ImageUrl = userInfo.user_avatar;
            this.nick.Text = this.nickName.Text = userInfo.nick_name;



            //从业务逻辑层中获取comment列表回来
            this.commentList.DataSource = CommentManager.getCommentList(userInfo.student_id);
            this.commentList.DataBind();
        }
    }
}