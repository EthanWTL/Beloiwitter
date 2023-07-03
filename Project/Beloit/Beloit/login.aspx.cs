using System;
using BLL;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace Beloit
{
    public partial  class login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //验证码生成
            if (!IsPostBack)
            {
                checkVerify();
            }
        }

        //generate verification code
        private void checkVerify()
        {
            Random ran = new Random();
            this.verify__code.Text = ran.Next(1000, 9999).ToString();
        }

        //点击事件，实现注册功能
        protected void register__btn_Click(object sender, EventArgs e)
        {
            //get data
            string userName = this.newUser.Text;
            string password = this.newPass.Text;
            //test data
            int userVeri = int.Parse(this.veriCode.Text);

            if(int.Parse(this.placeHolderCode.Text) == userVeri)
            {
                //save data
                if (StudentManager.registerStudent(userName, password))
                {
                    Response.Write("<script>alert('Successfully sign up!!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Fail to sign up!! or account already exist')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Verification Code wrong!')</script>");
            }
        }

        protected void email__btn_Click(object sender, EventArgs e)
        {

            string userEmail = this.newUser.Text;
            if (CheckEmail(userEmail))
            {
                SendEmail();
            }
            else
            {
                Response.Write("<script>alert('please user Beloit Email')</script>");
            }

        }
        private bool CheckEmail(string email)
        {
            return Regex.IsMatch(email, "^[a-z0-9]+@beloit.edu$");
        }

        public void SendEmail()
        {
            Random rd = new Random();
            int code = rd.Next(10000, 99999);
            this.placeHolderCode.Text = code.ToString();
            MailMessage mm = new MailMessage();

            mm.Subject = "Your Beloiwitter Email verification Code";
            mm.Body = "Your verification code is " + code;
            mm.IsBodyHtml = false;

            mm.From = new MailAddress("beloiwitter@gmail.com", "Beloiwitter");

            string userEmail = this.newUser.Text;
            mm.To.Add(new MailAddress(userEmail, "wtl"));

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;

            NetworkCredential NetworkCred = new NetworkCredential("beloiwitter@gmail.com", "detprvjlscpeajjw");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;

            smtp.Send(mm);
        }

            protected void login__btn_Click(object sender, EventArgs e)
        {
            //获取表单数据
            string userName = this.user.Text;
            string password = this.password.Text;
            string verify = this.verify.Text;
            //校验表单数据
                //user name not null
            if (userName.ToString().Trim() == string.Empty)
            {
                Response.Write("<script>alert('User name can not be empty!')</script>");
                return;
            }
                //password not null
            if (password.ToString().Trim() == string.Empty)
            {
                Response.Write("<script>alert('Password can not be empty!')</script>");
                return;
            }
                //verify not null
            if (verify.ToString().Trim() == string.Empty)
            {
                Response.Write("<script>alert('Verify Code can not be empty!')</script>");
                return;
            }
                //verify if code is correct
            if (this.verify__code.Text != verify.ToString())
            {
                checkVerify();
                Response.Write("<script>alert('Verify Code can not be empty!')</script>");
                return;
            }
            //判断用户名密码是否正确， then执行跳转
            Student userInfo = StudentManager.checkStudent(userName, password);
            if (userInfo != null)
            {
                Response.Write("<script>alert('Login success!')</script>");
                //use SESSION record user info, so we can use it anywhere
                Session["userInfo"] = userInfo;
                //redirect to some page
                Response.Redirect("~/index.aspx");
            }
            else
            {
                Response.Write("<script>alert('Username or password wrong')</script>");
            }



        }


    }
}