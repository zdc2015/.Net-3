<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewGrades.aspx.cs" Inherits="test3.Grades.ViewGrades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        html,body{
            margin:0px;
            height:100%;
        }

        form{
            position:absolute;
            width:fit-content;
            height:80%;
            top:50%;
            left:50%;
            transform: translateY(-50%) translateX(-50%);
        }

        .add{
            position:absolute;
            bottom:5%;
        }

        .method{
            margin-bottom:10%;
        }

    </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="method">
            <asp:Button ID="view_all" runat="server" Text="查看全部" OnClick="view_all_Click" style="margin-right:20px;"/>
            <asp:TextBox ID="textkey" runat="server" />
            <asp:DropDownList ID="select_type" runat="server" ></asp:DropDownList>
            <asp:Button ID="view_part" runat="server" Text="查询" OnClick="view_part_Click" />
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" 
                CellPadding="4" 
                ForeColor="#333333" 
                GridLines="None"
                AutoGenerateColumns="False"
                AllowPaging="True"
                OnPageIndexChanging="GridView1_PageIndexChanging"
                OnRowDeleting="GridView1_RowDeleting"
                OnRowEditing="GridView1_RowEditing"
                OnRowCancelingEdit="GridView1_RowCancelingEdit"
                OnRowUpdating="GridView1_RowUpdating"
                OnRowDataBound="GridView1_RowDataBound">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                <Columns>
                    <asp:TemplateField HeaderText="编号">
                        <ItemTemplate>
                            <asp:Label Width="100px" ID="lid" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="学号">
                        <ItemTemplate>
                            <asp:Label Width="100px" ID="lstudent_id" runat="server" Text='<%# Bind("student_id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="姓名">
                        <ItemTemplate>
                            <asp:Label ID="lstudent_name" runat="server" Text='<%# Bind("student_name") %>' Width="100px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="课程编号">
                        <ItemTemplate>
                            <asp:Label ID="lgender" runat="server" Text='<%# Bind("course_id") %>' Width="100px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="课程">
                        <ItemTemplate>
                            <asp:Label ID="lbirthday" runat="server" Text='<%# Bind("course_name") %>' Width="100px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="成绩">
                        <EditItemTemplate>
                            <asp:TextBox ID="tscore" runat="server" Text='<%# Bind("score") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lscore" runat="server" Text='<%# Bind("score") %>' Width="100px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="学分">
                        <ItemTemplate>
                            <asp:Label ID="lcredit" runat="server" Text='<%# Bind("credit") %>' Width="100px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
                </Columns>

                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>

        <div class="add">
            <asp:Button ID="enter" runat="server" Text="录入成绩" OnClick="enter_Click"/>
        </div>
    </form>
</body>
</html>