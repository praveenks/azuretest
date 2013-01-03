<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoListTracker.aspx.cs" Inherits="ToDoList.ToDoListTracker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView runat="server">
            <Columns>
                <asp:BoundField DataField="Name" />
                <asp:BoundField DataField="Completed" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
