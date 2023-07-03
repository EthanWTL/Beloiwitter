using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Beloit
{
    public partial class searchPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string name = Request.QueryString["name"];
            string time = Request.QueryString["time"];
            string depart_name = Request.QueryString["depart"];
            this.commentList.DataSource = CommentManager.getSearchCommentList(id,name,time,depart_name);
            this.commentList.DataBind();


            //
            this.notice.Text = Request.QueryString["id"].ToString() +" "+ Request.QueryString["name"].ToString() + " " + Request.QueryString["time"].ToString() +" "+ Request.QueryString["depart"];
        }

        protected void ssearchBtn_Click(object sender, EventArgs e)
        {
            string key = this.ssearch.Text;
            string name = this.pprofessor.Text.ToUpper();
            string time = this.ttime.Text.ToUpper();
            string depart = this.ddepart.Text.ToUpper();

            Response.Redirect(string.Format("searchPage.aspx?id={0}&name={1}&time={2}&depart={3}", key, name, time, depart));
        }
    }
}