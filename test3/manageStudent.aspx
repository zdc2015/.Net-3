<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageStudent.aspx.cs" Inherits="test3.manageStudent" %>

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
                    <asp:TemplateField HeaderText="学号">
                        <EditItemTemplate>
                            <asp:TextBox ID="tid" runat="server" Text='<%# Bind("id") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lid" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="姓名">
                        <EditItemTemplate>
                            <asp:TextBox ID="tname" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lname" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="性别">
                        <ItemTemplate>
                            <asp:Label ID="lgender" runat="server" Text='<%# Bind("gender") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="出生日期">
                        <ItemTemplate>
                            <asp:Label ID="lbirthday" runat="server" Text='<%# Bind("birthday") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="手机">
                        <EditItemTemplate>
                            <asp:TextBox ID="tphone" runat="server" Text='<%# Bind("phone") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lphone" runat="server" Text='<%# Bind("phone") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="学院">
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" ID="dins" OnTextChanged="dins_TextChanged" AutoPostBack="true">
                                <asp:ListItem Value="1">航空宇航学院</asp:ListItem>
                                <asp:ListItem Value="2">自动化学院</asp:ListItem>
                                <asp:ListItem Value="3">机械学院</asp:ListItem>
                                <asp:ListItem Value="4">理学院</asp:ListItem>
                                <asp:ListItem Value="5">计算机科学与技术学院</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lins" runat="server" Text='<%# Bind("institute") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="年级">
                        <EditItemTemplate>
                            <asp:TextBox ID="tgrade" runat="server" Text='<%# Bind("grade") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("grade") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="班级">
                        <EditItemTemplate>
                            <asp:TextBox ID="tclass" runat="server" Text='<%# Bind("class") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("class") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="专业">
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" ID="dmajor" >
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lmajor" runat="server" Text='<%# Bind("major") %>'></asp:Label>
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
            <asp:Button ID="AddStudent" runat="server" Text="增加学生" OnClick="AddStudent_Click"/>
        </div>

    </form>
</body>
</html>
