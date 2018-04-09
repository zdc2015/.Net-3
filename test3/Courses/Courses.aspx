<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="test3.Courses.Courses" %>

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
            margin-bottom:5%;
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
                OnRowDataBound="GridView1_RowDataBound"
                OnRowCommand="GridView1_RowCommand">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                <Columns>
                    <asp:TemplateField HeaderText="课程编号" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label Width="100px" ID="lid" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="课程" ItemStyle-HorizontalAlign="Center">
                        <EditItemTemplate>
                            <asp:TextBox ID="tname" runat="server" Text='<%# Bind("name") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lname" runat="server" Text='<%# Bind("name") %>' Width="100px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="学分" ItemStyle-HorizontalAlign="Center">
                        <EditItemTemplate>
                            <asp:TextBox ID="tcredit" runat="server" Text='<%# Bind("credit") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lcredit" runat="server" Text='<%# Bind("credit") %>' Width="100px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="学院" ItemStyle-HorizontalAlign="Center">
                        <EditItemTemplate>
                            <asp:DropDownList Width="200px" runat="server" ID="dins">
                                <asp:ListItem Value="1">航空宇航学院</asp:ListItem>
                                <asp:ListItem Value="2">自动化学院</asp:ListItem>
                                <asp:ListItem Value="3">机械学院</asp:ListItem>
                                <asp:ListItem Value="4">理学院</asp:ListItem>
                                <asp:ListItem Value="5">计算机科学与技术学院</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lins" runat="server" Text='<%# Bind("institute") %>' Width="200px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="部门">
                        <ItemTemplate>
                            <asp:Label ID="ldepartment" runat="server" Text='<%# Bind("department") %>' Width="100px"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox Width="100px" ID="tdepartment" runat="server" Text='<%# Bind("department") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
                    <asp:ButtonField ButtonType="Link" Text="成绩" CommandName="view_grade" />
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
            <asp:Button ID="AddCourse" runat="server" Text="增加课程" OnClick="AddCourse_Click"/>

        </div>
    </form>
</body>
</html>
