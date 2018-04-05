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
                        <asp:TreeNode Text="航空宇航学院" Value="航空宇航学院" NavigateUrl="~/Institutes/InstituteDetail.aspx?name=航空宇航学院">
                            <asp:TreeNode Text="专业信息" Value="专业信息"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="机械学院" Value="机械学院" NavigateUrl="~/Institutes/InstituteDetail.aspx?name=机械学院">
                            <asp:TreeNode Text="专业信息" Value="专业信息"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="理学院" Value="理学院" NavigateUrl="~/Institutes/InstituteDetail.aspx?name=理学院"></asp:TreeNode>
                        <asp:TreeNode Text="计算机科学与技术学院" Value="计算机科学与技术学院" NavigateUrl="~/Institutes/InstituteDetail.aspx?name=计算机科学与技术学院" Target="right_frame">
                            <asp:TreeNode Text="专业信息" Value="专业信息"></asp:TreeNode>
                            <asp:TreeNode Text="课程管理" Value="课程管理"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="学生信息管理" Value="学生信息管理" NavigateUrl="~/manageStudent.aspx" Target="right_frame"></asp:TreeNode>
                    </asp:TreeNode>
                </Nodes>
            </asp:TreeView>
        </div>
    </form>
</body>
</html>
