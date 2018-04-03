<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NaviForm.aspx.cs" Inherits="test3.NaviForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TreeView ID="TreeView1" runat="server">
                <Nodes>
                    <asp:TreeNode Text="学校" Value="学校">
                        <asp:TreeNode Text="航空宇航学院" Value="航空宇航学院"></asp:TreeNode>
                        <asp:TreeNode Text="自动化学院" Value="自动化学院"></asp:TreeNode>
                        <asp:TreeNode Text="机械学院" Value="机械学院"></asp:TreeNode>
                        <asp:TreeNode Text="理学院" Value="理学院"></asp:TreeNode>
                        <asp:TreeNode Text="计算机科学与技术学院" Value="计算机科学与技术学院"></asp:TreeNode>
                    </asp:TreeNode>
                </Nodes>
            </asp:TreeView>
        </div>
    </form>
</body>
</html>
