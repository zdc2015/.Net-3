<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="test3.Courses.AddCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        html,body,form{
            width:100%;
            height:100%;
            margin:0 0 0 0;
            border-width:0px;
            padding:0 0 0 0;
            position:relative;
        }

        .add{
            position:absolute;
            top:0;
            left:0;
            right:0;
            bottom:0;
            margin:auto;
            width:400px;
        }
    </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="add">
                <tr>
                    <td>课程编号</td>
                    <td> <asp:TextBox ID="id"  runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>课程名</td>
                    <td> <asp:TextBox ID="name"  runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>学分</td>
                    <td> <asp:TextBox ID="credit"  runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>学院</td>
                    <td>
                        <asp:Label ID="institute" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>所属部门</td>
                    <td> <input type="text" id="department" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="save" style="margin-top:10px; margin-left:20%;" Text="确定" runat="server" OnClick="save_Click"/>
                        <asp:Button  style="margin-top:10px; margin-left:25%;" ID="back" runat="server" OnClick="back_Click" Text="返回" />
                    </td>
                </tr>
                <tr>
                    <td rowspan="3" colspan="2" style="text-align:center;">
                        <asp:Label ID="tip" runat="server" Height="10px" ></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>