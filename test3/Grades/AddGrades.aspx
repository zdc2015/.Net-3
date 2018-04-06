<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddGrades.aspx.cs" Inherits="test3.Grades.AddGrades" %>

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
                    <td>课程</td>
                    <td> <asp:Label ID="name"  runat="server"></asp:Label> </td>
                </tr>
                <tr>
                    <td>学号</td>
                    <td> <asp:TextBox ID="student_id"  runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>成绩</td>
                    <td> <asp:TextBox ID="score"  runat="server"></asp:TextBox></td>
                </tr>
             
                <tr>
                    <td colspan="2">
                        <asp:Button ID="save" style="margin-top:10px; margin-left:15%;" Text="确定" runat="server" OnClick="save_Click"/>
                        <asp:Button  style="margin-top:10px; margin-left:25%;" ID="back" runat="server" OnClick="back_Click" Text="返回" />
                    </td>
                </tr>
                <tr>
                    <td rowspan="3" colspan="2">
                        <asp:Label ID="tip" style="margin-left:20%;" runat="server" Height="10px" ></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
