<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="WeeklyNews.View.News.News" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/News/NewNews.aspx">Add News</asp:HyperLink>
        </div>
        <div>
            <asp:GridView ID="gvNews" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="/View/News/NewNews.aspx?Id={0}" DataTextField="Id" Text="ID" />
                    <asp:BoundField DataField="CategoryTitle" HeaderText="CategoryTitle" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Date" HeaderText="Date" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <% if (!Eval("Image").Equals(DBNull.Value))
                                { %>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Image")) %>' Height="150px" Width="150px" />
                            <% } %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
