<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstituteDetail.aspx.cs" Inherits="test3.Institutes.CsDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        html,body{
            margin:0px;
            height:100%;
        }

        form{
            width:80%;
            height:80%;
            position:absolute;
            top:50%;
            left:50%;
            transform:translateY(-50%) translateX(-50%);
        }

        .alter{
            position:absolute;
            bottom:20%;
            right:20%;
        }

        .intro{
            float:left;
            width:500px;
        }

        .leader{
            float:left;
            width:100%;
        }

    </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h1><asp:Label ID="title" runat="server">计算机科学与技术学院</asp:Label></h1>
        </div>
        <div class="intro">
            <h2>学院简介</h2>
            <p><asp:Label ID="introduction" runat="server" style="word-break:break-all;"></asp:Label></p>
        </div>
        <div class="leader">
            院长：<asp:label ID="dean" runat="server"></asp:label>
        </div>
        <div class="alter">
            <asp:Button ID="alter" runat="server" Text="修改学院信息" OnClick="alter_Click"/>
        </div>
    </form>
</body>
</html>
