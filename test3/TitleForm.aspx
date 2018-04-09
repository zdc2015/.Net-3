<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TitleForm.aspx.cs" Inherits="test3.TitleForm" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style type="text/css">

    .label{
        position:absolute;
        top:50%;
        left:50%;
        transform:translateX(-50%) translateY(-50%);
        width:fit-content;
        height:fit-content;
        margin:0;
    }

    html,body,form{
        margin:0px;
        padding:0px;
        border-width:0px;
        width:100%;
        height:100%;
    }

    .action{
        position:absolute;
        left:90%;
        top:80%;
    }

</style>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="label">
            <h1>欢迎来到学生信息管理系统</h1>
        </div>
        <div class="action">
            <a href="index.aspx" target="_top">退出登录</a>
        </div>
    </form>
</body>
</html>
