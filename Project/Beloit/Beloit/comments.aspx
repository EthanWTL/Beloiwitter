<%@ Page Title="" Language="C#" MasterPageFile="~/WebIndex.Master" AutoEventWireup="true" CodeBehind="comments.aspx.cs" Inherits="Beloit.comments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="./css/detail.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!--show main body-->
    <section id="content">
        <div class="middle">
            <!--news box-->
            <div class="content-detail">
                <!--detail area-->
                <h1>                
                    <asp:Literal ID="title" runat="server"></asp:Literal>
                </h1>
                <p class="subtitle">
                    
                </p>

                <p class="detail--intro">
                    <asp:Label ID="nickName" runat="server" Text="Label"></asp:Label>
                    <asp:Literal ID="titlemini" runat="server"></asp:Literal>
                    
                </p>

                <asp:Image ID="detailImg" CssClass="content-detailimg" runat="server" />

                <div class="detail-box"> <!--dont forget to add content-detailimg to img class-->
                    <asp:Literal ID="comment_text" runat="server"></asp:Literal>
                </div>

                <!--comment area-->
                <div class="comment-box">
                    <h2>
                        <asp:Label ID="discussNum" runat="server" Text="0"> comments</asp:Label>
                    </h2>
                    <asp:Image ID="userImg" CssClass="user-img" runat="server" />
                    <asp:TextBox ID="commentSay" CssClass="commentSay" runat="server"></asp:TextBox>

                    <asp:Button ID="commentBtn" CssClass="commentBtn" runat="server" Text="Comment" OnClick="sendDiscuss"/>

                    <!--comment list-->
                    <div class="comment-list">

                        <asp:Repeater ID="discussList" runat="server">
                            <ItemTemplate>
                                <!--single comment box start-->
                                <div class="comment-item">
                                    <asp:Image ImageUrl='<%#Eval("user_avatar") %>' CssClass="item-left" runat="server" />
                                    <div class="item-right">
                                        <a href="#"><%#Eval("nick_name") %></a>
                                        <span><%#Eval("time") %></span>
                                        <p><%#Eval("discuss") %></p>
                                    </div>
                                </div>
                                <!--single comment box end -->
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </div>

            </div>

            <!--user detail-->
            <div class="detail-user">
                <asp:Image ID="userImage" runat="server" />
                <asp:Label ID="usersName" runat="server" CssClass="user--name" Text="Label"></asp:Label>
                <div class="news-list">
                    <ul>
                        <asp:Repeater ID="sendList" runat="server">
                            <ItemTemplate>
                                <li><a href="comments.aspx?id=<%# Eval("comment_id") %>"><%# Eval("title") %></li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                </div>
            </div>

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

    <!--back to top box-->
    <a href="javascript:void(0)" id="return-box">
        <img src="./img/top.jpg" alt="">
    </a>

    <!--jquery link-->
    <script src="./js/jquery-3.5.1.min.js"></script>
    <script src="./js/global.js"></script>
    <script>
        //comment 
        $("#comment-btn").click(function(){
            //get comment
            var say = $("#comment-say").val();

            //check if null
            if(say.trim() == ""){
                alert("Please leave your comments");
                $("#comment-say").focus();
                return;
            }

            //put comments into the list
            //DOM节点追加 $(html).appendTo(location) 末尾追加
            //前置追加: $(html).prependTo(指定位置)
            $('<div class="comment-item"><img src="'+$(".user-img").attr('src')+'" class="item-left" alt=""><div class="item-right"><a href="#">SuperMario</a><span>1 hour before</span><p>'+say+'</p></div></div>').prependTo(".comment-list");
            
            //clear box
            $("#comment-say").val("");

        });
    </script>
</asp:Content>
