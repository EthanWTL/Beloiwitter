<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="Beloit.user" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Backend Module</title>
    <!--link reset css-->
    <link rel="stylesheet" href="./css/reset.css">
    <link rel="stylesheet" href="./css/user.css">
</head>
<body>


    <!--Header-->
    <header id="header-top">
        <!--  页眉  -->
        <div id="top-box">
            <div class="top-left">
                <ul>
                    <li><a href="index.aspx">HOME</a></li>
                </ul>
            </div>

            <div class="top-right">
                <ul>
                    <%
                        if(Session["userInfo"] != null) { 
                        
                    %>
                    <li><a href="user.aspx">Welcome! <asp:Label ID="nick" runat="server" Text=""></asp:Label></a></li>
                    <li><a href="login.aspx">Log out</a></li>
                    <%
                        }
                        else
                        {

            
                    %>
                    <li><a href="login.aspx">Login</a></li>
                    <li><a href="login.aspx">Sign up</a></li>
                    <%} %>
                    <li><a href="sendArticle.aspx">Post</a></li>
                    <li><a href="#">Feedback</a></li>
                    <li><a href="#">Contact us</a></li>
                </ul>
            </div>
        </div>
        <!--top search bar-->
        <div class="header-nav">
            <div class="middle">
                <!--icon-->
                <img src="./img/logo.png" class="header--logo" alt="">

            </div>
        </div>
    </header>
    
    <!--body-->
    <section id="content">

        <!--body header-->
        <div class="content-header middle">
            <div class="content-bg"></div>
            <div class="content-introduce">
                <a href="userInfo.aspx">
                    <asp:Image ID="userImage" runat="server" />
                </a>

                <h3>
                    <asp:Label ID="nickName" runat="server" Text=""></asp:Label>
                </h3>
            </div>
        </div>

        <!--body body content list-->
        <div class="content-list">
            <asp:DataList ID="commentList" runat="server">
                <ItemTemplate>
                    <div class="content__item">
                        <a href="comments.aspx?id=<%# Eval("comment_id") %>">
                            <img src="<%#Eval("img") %>" alt="">
                            <h3>
                                <%#Eval("title") %>
                            </h3>
                            <p>0 read  0 comment  <%#Eval("time") %></p>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>

    </section>

    <!--bottom-->
    <footer id="footer">
        <p>@ 2021 Beloitwitter</p>
        <p>
            <a href="#">XXXX</a>
            <a href="#">YYYY</a>
            <a href="#">ZZZZ</a>
        </p>

    </footer>


</body>
</html>
