﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewCategory.aspx.cs" Inherits="WeeklyNews.View.Category.NewCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Title "></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" Width="179px"></asp:TextBox>
            <asp:Button ID="btnSave" runat="server" OnClick="Button1_Click" Text="Save" Width="76px" />
        </div>
    </form>
</body>
</html>
