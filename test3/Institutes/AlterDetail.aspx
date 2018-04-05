<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlterDetail.aspx.cs" Inherits="test3.Institutes.AlterDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        html,body,form{
            margin:0px;
            height:100%;
        }

        .content{
            width:fit-content;
            position:absolute;
            top:50%;
            left:50%;
            transform:translateY(-50%) translateX(-50%);
        }

    </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="content">
            <table>
                <tr>
                    <td>学院：</td>
                    <td><asp:Label ID="name" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>简介：</td>
                    <td><asp:TextBox style="margin-top:10px;" runat="server" ID="intro" TextMode="MultiLine" Height="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>院长：</td>
                    <td><asp:TextBox style="margin-top:10px;" runat="server" ID="leader"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button style="margin-left:30%;" runat="server" ID="save" Text="确定" OnClick="save_Click"/>
                        <asp:Button style="margin-left:15%;" runat="server" ID="back" Text="返回" OnClick="back_Click"/>
                    </td>
                </tr>
                <tr>
                    <td rowspan="2">
                        <asp:Label style="margin-top:20px;" ID="tip" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
