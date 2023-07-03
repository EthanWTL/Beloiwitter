using System;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.IO;

namespace Beloit
{
    public partial class userInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStudentInfoData();
            }
        }

        public void GetStudentInfoData()
        {
            //get user information
            Student userInfo = Session["userInfo"] as Student;
            //check if already exist
            if (userInfo == null)
            {
                return;
            }

            Image userImage = this.Master.FindControl("userImage") as Image;
            imgBox.ImageUrl = userImage.ImageUrl = userInfo.user_avatar;
            Label nick = this.Master.FindControl("nick") as Label;
            Label nickName = this.Master.FindControl("nickName") as Label;
            nickNames.Text = nick.Text = nickName.Text = userInfo.nick_name;

            //get intro
            introduce.Text = userInfo.introduce;

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            //get userInfo from session
            Student studentInfo = Session["userInfo"] as Student;
            //icon
            if (FileUpload.HasFile)
            {
                //get file
                string fileName = FileUpload.FileName;
                //check if img
                string back = Path.GetExtension(fileName); //end with .jpg .png
                if (back != ".jpg" && back != ".png" && back != ".jpeg" && back != ".gif")
                {
                    this.notice.Text = "File is not img";
                    return;
                }
                //upload img and save
                string newFile = "~/userIcon/" + DateTime.Now.ToString("yyMMmmss") + back;
                FileUpload.SaveAs(Server.MapPath(newFile));
                //update avatar address
                studentInfo.user_avatar = newFile;


                //nickname change
                studentInfo.nick_name = this.nickNames.Text;


                //introduce change
                studentInfo.introduce = this.introduce.Text;

                //execute info update
                if (StudentManager.updateStudent(studentInfo))
                {
                    //update session info
                    Session["userInfo"] = studentInfo;
                    //refresh the data show up
                    GetStudentInfoData();
                    Response.Write("<script>alert('Update Succeed!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Update Failed!');</script>");
                }

            }
        }
    }
}