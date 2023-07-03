<%@ Page Title="" Language="C#" MasterPageFile="~/UserTemplete.Master" AutoEventWireup="true" CodeBehind="userInfo.aspx.cs" Inherits="Beloit.userInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div class="content-list">
         <form runat="server">
            <h3>Editing info</h3>
            <div class="content-item">
                <p>
                    Icon: <asp:Image ID="imgBox" CssClass="head-img" runat="server" />
                    <asp:FileUpload ID="FileUpload" runat="server" />
                </p>
                <div class="blank"></div>
                <p>User name: 
                    <asp:TextBox ID="nickNames" runat="server"></asp:TextBox>
                </p>
                <div class="blank"></div>
                <p>Intro:
                    <asp:TextBox ID="introduce" CssClass="introduce" TextMode="MultiLine" runat="server"></asp:TextBox>
                </p>

                <p>
                    <asp:Label ID="notice" runat="server" ForeColor="Red" Text=""></asp:Label>
                    <asp:Button ID="btn" runat="server" CssClass="update--btn" Text="Edit Info" OnClick="btn_Click" />
                </p>

            </div>
            </form>
     </div>
</asp:Content>
