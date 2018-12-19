<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewNews.aspx.cs" Inherits="WeeklyNews.View.News.NewNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Date : "></asp:Label>
            <asp:TextBox ID="txtDate" runat="server" TextMode="DateTime"></asp:TextBox>
        </div>
        <div>

            <asp:Label ID="Label2" runat="server" Text="Title : "></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>

        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Desc : "></asp:Label>
            <asp:TextBox ID="txtDesc" runat="server" Height="115px" TextMode="MultiLine" Width="276px"></asp:TextBox>
          </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Category : "></asp:Label>
            <asp:DropDownList ID="ddCategory" runat="server" Width="210px">
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="Image : "></asp:Label>
            <asp:FileUpload ID="fuImage" runat="server" />
        </div>
        <div>
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
    </form>
</body>
</html>
