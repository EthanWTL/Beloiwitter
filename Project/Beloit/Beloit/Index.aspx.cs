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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            //get comment list for index page

            getCommentList();

            //get user information
            Student userInfo = Session["userInfo"] as Student;
            //check if already exist
            if (userInfo == null)
            {
                return;
            }
            this.nick.Text = this.nickName.Text = userInfo.nick_name;
            this.userImg.ImageUrl = userInfo.user_avatar;

        }

        private void getCommentList()
        {
            int pageNum = 1;
            int pageSize = 10;
            this.commentList.DataSource = CommentManager.getIndexCommentList(pageNum, pageSize);
            this.commentList.DataBind();
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            string key = this.search.Text;
            string name = this.professor.Text.ToUpper();
            string time = this.time.Text.ToUpper();
            string depart = this.depart.Text.ToUpper();
            
            Response.Redirect(string.Format("searchPage.aspx?id={0}&name={1}&time={2}&depart={3}", key, name, time, depart));
        }
    }
}