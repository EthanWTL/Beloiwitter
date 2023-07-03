# Beloitwitter
Welcome Software engineers :computer: and UX Designers :iphone:.

This repo presents you the "[Beloitiwtter](https://github.com/EthanWTL/Beloiwitter)" for Beloit College.

You can preview the website without connection to MS SQL Server [here](https://ethanwtl.github.io/Beloiwitter/).

Here is a demonstration of fully functioning website. 

https://github.com/EthanWTL/Beloiwitter/assets/97998419/4d0f0548-0770-445e-9ac9-0e2acee3de68

## Front-end
```HTML``` ```CSS``` ```JQuery``` ```C#``` ```JavaScript```

HTML and CSS deploy the basic structure of web page

```html
<div class="header-search">
    <asp:TextBox ID="search" placeholder="CODE: MATH 110" CssClass="search" runat="server"></asp:TextBox>
    <asp:TextBox ID="professor" placeholder="FIRST NAME" CssClass="professor" runat="server"></asp:TextBox>
    <asp:TextBox ID="time" placeholder="SPRING 2021" CssClass="time" runat="server"></asp:TextBox>
    <asp:TextBox ID="depart" placeholder="DEPARTMENT: MATH" CssClass="depart" runat="server"></asp:TextBox>               
                
    <asp:Button ID="searchBtn" runat="server" Text="Search" OnClick="searchBtn_Click" />
</div>
```

```css
.content-right #searchBtn{
    width: 342px;
    height: 38px;
    background: #373531;
    border: none;
    outline: none;
    border-radius: 5px;
    color: #fff;
    cursor:pointer;
    margin-top:10px;
}
```

C# takes charge of default functions like loading and freshing

```c#
protected void Page_Load(object sender, EventArgs e)
        {
            //get comment list for index page
            getCommentList();

            //get user information
            Student userInfo = Session["userInfo"] as Student;
            //check if already exist
            if (userInfo == null)
            {
                return;
            }
            this.nick.Text = this.nickName.Text = userInfo.nick_name;
            this.userImg.ImageUrl = userInfo.user_avatar;
        }
```

JQuery and JavaScript take charge of business and functions


## Back-end
The Entire project adopted the .Net framework and MVC Structure. 
1. Business Logic Layer
2. Data Access Layer
3. Data Model
