using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Beloit
{
    public partial class sendArticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //without login user not allowed here
            if(Session["userInfo"] == null)
            {
                Response.Redirect("index.aspx");
            }
            

            //get class list back
            Student studentInfo = Session["userInfo"] as Student;
            this.classList.DataSource = ShowClassManager.getClassList(studentInfo.student_id);
            this.classList.DataBind();

            Label nick = this.Master.FindControl("nick") as Label;
            nick.Text = studentInfo.nick_name;
        }

        //save draft
        protected void save1_Click(object sender, EventArgs e)
        {
            //get comment data
            string title = this.title.Text;
            int course_id = int.Parse(Request.Form["classTaken"]);
            string content = Request.Form["content"];
            string pic = Request.Form["pic"];
            string picPath = "";


            //check if we need to upload pic
            if(pic == "1")
            {
                //execute pic upload
                if (ImgUpload.HasFile)
                {
                    //get name for upload file
                    string fileName = ImgUpload.FileName;
                    //check if currently file is a picture
                    string back = Path.GetExtension(fileName).ToLower(); //.jpg, .png
                    if(back != ".jpg" && back != ".png" && back != ".jpeg" && back != ".gif")
                    {
                        Response.Write("<script>alert('choose a picture!!!');</script>");
                        return;
                    }

                    //
                    //upload picture
                    picPath = "/Upload/" + DateTime.Now.ToString("yyMMss") + " " + fileName;
                    ImgUpload.SaveAs(Server.MapPath(picPath));

                }
                else
                {
                    Response.Write("<script>alert('please choose no pic option');</script>");
                    return;
                }
            }

            Student studentInfo = Session["userInfo"] as Student;

            //make a comment model, save into database
            Comment comment = new Comment()
            {
                student_id = studentInfo.student_id,
                course_id = course_id,
                title = title,
                img = picPath,
                comment_text = content,
                course_rate = 10,
                time = DateTime.Now,
            };

            if (CommentManager.addComment(comment))
            {
                Response.Write("<script>alert('Save Succeed!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Save failed!');</script>");
            }
        }
    }
}