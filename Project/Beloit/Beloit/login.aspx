 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Beloit.login" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>BeloitwitterLogin</title>
    <!--引入样式表 ctrl+/-->
    <link rel="stylesheet" href="./css/reset.css">
    <!--login page css-->
    <link rel="stylesheet" href="./css/login.css">
</head>

<body>

    <form runat="server">
    <!--登录框-->
        <div id="login-box">
        <h3>BELOITWITTER</h3>
        <p>
            <a href="#" class="active">SIGN IN</a>
            <a href="#">SIGN UP</a>
        </p>
        <div class="login-register">
            <!--login in box-->
            <div class="login-login">
                <div>
                    &nbsp;&nbsp; Email&nbsp; : 
                    <asp:TextBox ID="user" runat="server"></asp:TextBox>
                </div>
                <div>
                    &nbsp;&nbsp;&nbsp;&nbsp;Password&nbsp; : 
                    <asp:TextBox ID="password" TextMode="Password" runat="server"></asp:TextBox>
                </div>
                <div>
                    Verification:
                    <asp:TextBox ID="verify" Maxlength=4 runat="server"></asp:TextBox>
                    <asp:Label ID="verify__code" runat="server" Text="0000"></asp:Label>
                </div>
                <div>
                    <%-- CausesValidation="False" 不校验数据提交表单--%>
                    <asp:Button ID="login__btn" runat="server" Text="LOGIN" CausesValidation="False" OnClick="login__btn_Click" />
                </div>
                <div>
                    <a href="#">"Privicy Term"</a>
                    &
                    <a href="#">"User Agreement"</a>
                    <a href="#" class="login--rem">Forget Password?</a>
                </div>
            </div>
            <!--register box-->
            <div class="login-reg">
                <div>
                    &nbsp;&nbsp; Email&nbsp; : <asp:TextBox ID="newUser"  runat="server" PlaceHolder="toms@beloit.edu"></asp:TextBox>
                </div>
                <div>
                    Verification Code: <asp:TextBox ID="veriCode" runat="server"></asp:TextBox>
                    <asp:Button ID="email__btn" runat="server" Text="Get Code" OnClick="email__btn_Click" />
                </div>
                <div id="divCheckbox" style="display: none;">
                    <asp:Label ID="placeHolderCode" runat="server" Text="0000"></asp:Label>
                </div>
                <div>
                    &nbsp;&nbsp;&nbsp;&nbsp;Password&nbsp; : <asp:TextBox ID="newPass" TextMode="Password" runat="server"></asp:TextBox>
                </div>
                <div>
                    Confirm Pass: <asp:TextBox ID="rePass" TextMode="Password" runat="server"></asp:TextBox>

                </div>

                <div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email cannot be empty!" ControlToValidate="newUser"></asp:RequiredFieldValidator>

                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="password do not match!" ControlToCompare="newPass" ControlToValidate="rePass"></asp:CompareValidator>
                    <asp:Button ID="register__btn" runat="server" Text="REGISTER" OnClick="register__btn_Click" />

                </div>
                <div style="display: none;">
                    <a href="#">"Privicy Term"</a>
                    &
                    <a href="#">"User Agreement"</a>
                </div>
            </div>
        </div>
    </div>
    </form>

    <script src="./js/jquery-3.5.1.min.js"></script>
    <!--Jquery-->
    <script>
        //multiple tags 
        $("#login-box p a").click(function () {
            //get current a tag --> $(this)
            $(this).addClass("active").siblings("a").removeClass("active");

            //先获取当前元素的索引  login-->0 sign up --> 1
            var index = $(this).index();
            //console.log(index);
            //show target box 
            $(".login-register>div").eq(index).show().siblings("div").hide();
        });

    </script>

</body>

</html>
