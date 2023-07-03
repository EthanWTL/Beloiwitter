<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searchPage.aspx.cs" Inherits="Beloit.searchPage" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Search Page</title>

    <!--link main css-->
    <link rel="stylesheet" href="./css/reset.css">
    <link rel="stylesheet" href="./css/index.css">

</head>

<body>
    <form runat="server">

    <!--Header-->
    <header id="header-top">
        <!--  页眉  -->
        <div id="top-box">
            <div class="top-left">
                <ul>
                    <li><a href="index.aspx">HOME</a></li>
                    <asp:Repeater ID="cateList" runat="server">
                        <ItemTemplate>
                            <li><a href="index.aspx?id=<%# Eval("cate_id") %>"><%# Eval("cate_name") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>

            <div class="top-right">
                <ul>
                    <%
                        if(Session["userInfo"] != null) { 
                        
                    %>
                    <li><a href="user.aspx">Welcome! <asp:Label ID="nick" runat="server" Text=""></asp:Label></a></li>
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
       
    </header>

    <!--Main Body -->
    <section id="content">
        <!--left nav-->
        <div class="content-nav">
            <img src="./img/logo.png" alt="">


        </div>

        <!--middle list-->
        <div class="content-list">
            <!--search bar-->
            <div class="search-content">

                <asp:TextBox ID="ssearch" placeholder="CODE: MATH 110" runat="server"></asp:TextBox>
                <asp:TextBox ID="pprofessor" placeholder="FIRST NAME" runat="server"></asp:TextBox>
                <asp:TextBox ID="ttime" placeholder="SPRING 2021" runat="server"></asp:TextBox>
                <asp:TextBox ID="ddepart" placeholder="DEPART: MATH" runat="server"></asp:TextBox>

                <asp:Button ID="ssearchBtn" runat="server" CssClass="search--btn" Text="Search" OnClick="ssearchBtn_Click" />
            </div>

            <h3 class="search-result">Search result for: 
                <asp:Label ID="notice" CssClass="notice" runat="server" Text=""></asp:Label>
            </h3>

            
            <asp:Repeater ID="commentList" runat="server">
                <ItemTemplate>
                     <!--w/ img single new box begin-->
                     <div class="list-item">
                        <a href='comments.aspx?id=<%#Eval("comment_id") %>'>
                            <asp:Image ID="Image1" CssClass="new--img" ImageUrl='<%#Eval("img") %>' runat="server" />
                            <h3 class="new--h3">
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("title") %>'></asp:Label>
                            </h3>
                            <div>
                                <asp:Label ID="Label5" runat="server" Text=<%#Eval("course_code")%> ></asp:Label>
                                <asp:Label ID="Label6" runat="server" Text=<%#Eval("professor_name")%> ></asp:Label>
                                <asp:Label ID="Label2" runat="server" Text=<%#Eval("time_offered")%> ></asp:Label>
                                <p class="user--info">
                                    <asp:Image ID="Image2" ImageUrl='<%#Eval("user_avatar") %>' runat="server" />
                                <asp:Literal ID="Label3" runat="server" Text=<%#Eval("nick_name") %>></asp:Literal>
                                <asp:Literal ID="Label4" runat="server" Text=<%#Eval("time") %>></asp:Literal>
                                </p>
                                
                            </div>
                        </a>
                    </div>
                    <!--w/ img single new box stop-->
                </ItemTemplate>
            </asp:Repeater>  


        </div>

        <!--right show-->

    </section>

    <!--back to top box-->
    <a href="javascript:void(0)" id="return-box">
        <img src="./img/top.jpg" alt="">
    </a>

        </form>
    <!--jquery link-->
    <script src="./js/jquery-3.5.1.min.js"></script>
    <script src="./js/global.js"></script>


</body>

</html>