<%@ Page Title="" Language="C#" MasterPageFile="~/BackTemplete.Master" AutoEventWireup="true" CodeBehind="sendArticle.aspx.cs" Inherits="Beloit.sendArticle" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <form action="" method="post" runat="server" enctype="multipart/form-data">
        <section id="content">
            <div class="article-box">
                <h3>Post Comment</h3>
                <div class="article-title">
                    <p> 
                        Title:<asp:TextBox ID="title" CssClass="title-input" runat="server"></asp:TextBox>
                    </p>

                    <p>
                         Class: 
                        <select name="classTaken" class="classes" id="class--select">
                            <asp:Repeater ID="classList" runat="server">
                                <ItemTemplate>
                                    <option value='<%#Eval("course_id") %>'><%#Eval("course_code") %>

                                    </option>
                                </ItemTemplate>
                            </asp:Repeater>

                        </select>

                    </p>

                    <div class="article-content">
                    <!-- 加载编辑器的容器 -->
                    <script id="container" name="content" type="text/plain"></script>
                    <!-- 配置文件 -->
                    <script type="text/javascript" src="./ueditor/ueditor.config.js"></script>
                    <!-- 编辑器源码文件 -->
                    <script type="text/javascript" src="./ueditor/ueditor.all.js"></script>
                    <!-- 实例化编辑器 -->
                    <script type="text/javascript">
                        var ue = UE.getEditor('container', {
                            initialFrameHeight: 300
                        });
                    </script>
                    </div>

                    <div class="article-pic">
                    Thumbnail Demo:
                    <input type="radio" name="pic" value="1" id="">Single pic
                    <input type="radio" name="pic" value="2" id="">No pic
                    </div>

                    <div class="pic-detail">
                        <asp:FileUpload ID="ImgUpload" runat="server" />
                    </div>

                    <p class="pic-intro">Supporting format JEPG PNG</p>

                    <asp:Button ID="save1" CssClass="send--btn" runat="server" Text="POST" OnClick="save1_Click" />


            </div>
        </div>
        </section>
    </form>
</asp:Content>
