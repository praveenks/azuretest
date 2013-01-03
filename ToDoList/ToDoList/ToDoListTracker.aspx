<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoListTracker.aspx.cs" Inherits="ToDoList.ToDoListTracker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView runat="server" ID="grdToDoList" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblId" Text='<%# Eval("Id") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Completed">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkCompleted" runat="server" Checked='<%# Eval("Completed") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button runat="server" ID="btnUpdate" Text="Update" OnClick="btnUpdate_Click" />
        <br />
        <br />
        <asp:TextBox runat="server" Text="" ID="txtTask"></asp:TextBox>
        <asp:Button runat="server" ID="btnAdd" Text="Add" OnClick="btnAdd_Click" />
    </div>
    </form>
</body>
</html>
