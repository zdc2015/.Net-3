<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Majors.aspx.cs" Inherits="test3.Majors.Majors" %>

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
                    <asp:TemplateField HeaderText="专业编号">
                        <EditItemTemplate>
                            <asp:TextBox Width="100px" ID="tid" runat="server" Text='<%# Bind("id") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label Width="100px" ID="lid" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="专业名">
                        <EditItemTemplate>
                            <asp:TextBox ID="tname" runat="server" Text='<%# Bind("name") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lname" runat="server" Text='<%# Bind("name") %>' Width="100px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="父专业编号">
                        <ItemTemplate>
                            <asp:Label ID="lfather_id" runat="server" Text='<%# Bind("father_id") %>' Width="100px"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tfather_id" runat="server" Text='<%# Bind("father_id") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="学生人数">
                        <ItemTemplate>
                            <asp:Label ID="stuNum" runat="server" Text='<%# Bind("num") %>' Width="100px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="所属学院">
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
            <asp:Button ID="AddMajor" runat="server" Text="增加专业" OnClick="AddMajor_Click"/>
        </div>
    </form>
</body>
</html>
